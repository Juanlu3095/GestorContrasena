
using GestorContrasena.Contracts.Entities.Password;
using Npgsql;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordModelInterface
    {
        public List<PasswordEntity> GetAll();
        public PasswordEntity? GetById(Guid id);
        public List<PasswordEntity>? GetByName(string name);
        public int? Create(PasswordInput password);
        public int? Update(Guid id, PasswordInput password);
        public int? Delete(Guid id);
    }
}
