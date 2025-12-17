using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface UserQueriesInterface
    {
        public int? CountByEmail(string email);
    }
}
