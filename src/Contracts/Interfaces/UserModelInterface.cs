using GestorContrasena.Contracts.Entities;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface UserModelInterface
    {
        public List<UserEntity>? GetAll();

        public UserEntity? GetById(Guid id);

        public UserEntity? GetByEmail(string email);

        public int? Create(UserEntity user);

        public int? Update(Guid id, UserEntity user);

        public int? Delete(Guid id);
    }
}
