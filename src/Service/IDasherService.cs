using motorbikes_rent_api.Core.DTOs;
using motorbikes_rent_api.Core.Mappers;
using motorbikes_rent_api.Core.Model;
using motorbikes_rent_api.Core.Repositories.Interfaces;
using motorbikes_rent_api.Infrastructure.Storage;

namespace motorbikes_rent_api.Service;

public interface IDasherService
{
    Task<Dasher> CreateDasher(Dasher dasher);
    Dasher GetDasherById(string id);
    Task<Dasher> AddCnhImageAsync(string id, CnhImageDto cnhImageDto);
}

public class DasherService : IDasherService
{
    private readonly IDasherRepository _dasherRepository;
    private readonly IMinioService _minioService;

    public DasherService(IDasherRepository dasherRepository, IMinioService minioService)
    {
        _dasherRepository = dasherRepository;
        _minioService = minioService;
    }

    public async Task<Dasher> CreateDasher(Dasher dasher)
    {
        ArgumentNullException.ThrowIfNull(dasher);

        var existing = await _dasherRepository.GetByIdAsync(dasher.Id);
        if (existing != null)
            throw new InvalidOperationException($"Dasher with id {dasher.Id} has already been registered");

        var cnpjAlreadyExists = await _dasherRepository.GetByCnpjAsync(dasher.Cnpj);
        if (cnpjAlreadyExists != null)
            throw new InvalidOperationException($"Cnpj {dasher.Cnpj} is already registered");

        var cnhDocumentNumberAlreadyExists = await _dasherRepository.GetByCnhNumber(dasher.CnhNumber);
        if (cnhDocumentNumberAlreadyExists != null)
            throw new InvalidOperationException($"CnhNumber {dasher.CnhNumber} is already registered");

        var createdEntity = await _dasherRepository.CreateAsync(dasher.ToEntity());
        return createdEntity.ToModel();
    }

    public Dasher GetDasherById(string id)
    {
        var retrievedDasher = _dasherRepository.GetByIdAsync(id).Result;
        return retrievedDasher?.ToModel() ??
               throw new InvalidOperationException($"Dasher with id {id} was not registered");
    }

    public async Task<Dasher> AddCnhImageAsync(string id, CnhImageDto cnhImageDto)
    {
        ArgumentNullException.ThrowIfNull(id);
        var existing = await _dasherRepository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException($"Dasher with id {id} was not found");

        var objectName = $"dashers/{id}/cnh_{Guid.NewGuid()}.jpg";

        var content = Convert.FromBase64String(cnhImageDto.CnhImage);
        await using var stream = new MemoryStream(content);

        await _minioService.UploadFileAsync(objectName, stream, "image/png");

        var cnhUrl = _minioService.GetFileUrl(objectName);

        existing.CnhImageUrl = cnhUrl;
        await _dasherRepository.UpdateAsync(existing);

        return existing.ToModel();
    }
}