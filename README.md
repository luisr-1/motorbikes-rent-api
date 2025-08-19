# 🚀 Motorbikes Rent API

API RESTful para gerenciamento de aluguel de motos e entregadores.  
O projeto foi desenvolvido utilizando **.NET + C#**, com **PostgreSQL** como banco de dados e containerização via **Docker Compose**.

---

## ✅ O que já foi implementado

- Estrutura de **entidades e relacionamentos** consistente.
- Regras de **unicidade** aplicadas para atributos sensíveis como `CNPJ` e `CNH`.
- Organização seguindo **boas práticas de DDD (Domain Driven Design)**.
- Configuração com **Docker Compose**, permitindo subir o banco de dados facilmente.
- Estrutura preparada para futura implementação de **testes e casos de uso**.

---

## 🔧 Melhorias e pontos pendentes

Ainda existem melhorias importantes a serem aplicadas no projeto:

1. **Testes automatizados**
    - Testes unitários para os casos de uso.
    - Testes de integração para os endpoints.

2. **Validações de dados**
    - Verificação se o `CNPJ` informado é realmente válido.
    - Regras adicionais para validar `CNH` e outros atributos.
    - Essas validações serão aplicadas diretamente nos **UseCases**, garantindo consistência de domínio.

3. **Endpoints pendentes**
    - Implementação de dois endpoints restantes para completar o fluxo de negócio.

4. **Segurança e autenticação**
    - Implementar autenticação diferenciada para **administradores** e **entregadores**, garantindo acesso controlado por perfil.

---

## 📦 Como rodar o projeto

### Pré-requisitos
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/)

### Subindo a aplicação

1. Clone este repositório:
   ```bash
   git clone git@github.com:luisr-1/motorbikes-rent-api.git
   cd motorbikes-rent-api
   ```
2. Suba os containers: 
```bash
  docker compose up -d
```
3. A API estará disponível em:
```bash
  http://localhost:8080
```
4. MinIO (armazenamento de arquivos):
   - API:
    ```bash
    http://172.18.0.4:9000
    http://127.0.0.1:9000
    ```
   - WebUI:
   ```bash
    http://172.18.0.4:35199
    http://127.0.0.1:35199
   ```
   - Usuário e senha podem ser consultados no `compose.yaml`
   ```yaml
    MINIO_ROOT_USER: minioadmin
    MINIO_ROOT_PASSWORD: minioadmin
   ```
---
## 📖 Próximos Passos
* Implementar validações de domínio em UseCases (CNPJ, CNH, etc).
* Criar testes unitários e de integração.
* Implementar os endpoints restantes.
* Adicionar segurança e autenticação diferenciando Admin x Entregador.
---
✍️ Desenvolvido com dedicação para consolidar boas práticas em arquitetura limpa e DDD.