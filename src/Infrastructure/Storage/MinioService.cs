using Minio;
using Minio.DataModel.Args;

namespace motorbikes_rent_api.Infrastructure.Storage;

public interface IMinioService
{
    Task<string> UploadFileAsync(string objectName, Stream data, string contentType);
    string GetFileUrl(string objectName);
}

public class MinioService : IMinioService
{
    private readonly MinioClient? _client;
    private readonly string _bucketName = "cnh-images";
    private readonly string _endpoint;

    public MinioService(IConfiguration configuration)
    {
        _endpoint = configuration["MinIO:Endpoint"]
                    ?? throw new ArgumentNullException("MinIO:Endpoint");

        _client = (MinioClient?)new MinioClient()
            .WithEndpoint(configuration["MinIO:Endpoint"])
            .WithCredentials(configuration["MinIO:AccessKey"], configuration["MinIO:SecretKey"])
            .Build();

        EnsureBucketExists().GetAwaiter().GetResult();
    }

    private async Task EnsureBucketExists()
    {
        var found = _client != null && await _client.BucketExistsAsync(
            new BucketExistsArgs().WithBucket(_bucketName));

        if (!found)
            await _client.MakeBucketAsync(
                new MakeBucketArgs().WithBucket(_bucketName));
    }

    public async Task<string> UploadFileAsync(string objectName, Stream data, string contentType)
    {
        await _client.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithStreamData(data)
            .WithObjectSize(data.CanSeek ? data.Length : -1)
            .WithContentType(contentType));

        // Retorna a URL pública do objeto
        return GetFileUrl(objectName);
    }

    public string GetFileUrl(string objectName)
    {
        return $"http://{_endpoint}/{_bucketName}/{objectName}";
    }
}