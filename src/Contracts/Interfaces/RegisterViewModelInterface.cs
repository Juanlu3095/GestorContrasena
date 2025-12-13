using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorContrasena.Contracts.Interfaces
{
    public interface RegisterViewModelInterface
    {
        public void ToLogin();

        public void RegisterAction(string name, string email, string password);
    }
}
