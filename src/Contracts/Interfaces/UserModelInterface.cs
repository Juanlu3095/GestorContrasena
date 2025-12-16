using GestorContrasena.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
