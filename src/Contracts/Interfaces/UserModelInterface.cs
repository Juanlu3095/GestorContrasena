using GestorContrasena.Contracts.Entities.User;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface UserModelInterface
    {
        public List<UserEntity>? GetAll();

        public UserEntity? GetById(Guid id);

        public UserEntity? GetByEmail(string email);

        public int? Create(UserRegisterInput user);

        public int? Update(UserEntity user);

        public int? Delete(Guid id);
    }
}
