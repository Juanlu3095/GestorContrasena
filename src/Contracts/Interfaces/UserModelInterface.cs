using GestorContrasena.Contracts.Entities;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface UserModelInterface
    {
        public List<UserEntity>? GetAll();

        public UserEntity? GetById(int id);

        public int? Create(UserEntity user);

        public int? Update(int id, UserEntity user);

        public int? Delete(int id);
    }
}
