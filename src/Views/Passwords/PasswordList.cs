using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views.Passwords
{
    public partial class PasswordList : Form
    {
        private PasswordListViewModelInterface PasswordListViewModel;
        internal PasswordList(PasswordListViewModelInterface PasswordListViewModel)
        {
            InitializeComponent(); // Muy importante esto siempre primero
            this.PasswordListViewModel = PasswordListViewModel;
            this.InitializeTable();

            this.FormClosed += this.PasswordListViewModel.ToLogin;
        }

        public void InitializeTable()
        {
            this.Controls.Add(PasswordDataGridView); // esto para qué sirve ??
            this.PasswordDataGridView.ColumnCount = 4; // Necesario para evitar error

            List<PasswordEntity>? Passwords = new List<PasswordEntity>();
            Passwords = this.PasswordListViewModel.GetAllPasswords();

            this.PasswordDataGridView.Columns[0].Name = "Nombre";
            this.PasswordDataGridView.Columns[1].Name = "Servicio";
            this.PasswordDataGridView.Columns[2].Name = "Fecha actualización";
            this.PasswordDataGridView.Columns[3].Name = "Acciones";

            if (Passwords != null && Passwords.Count() > 0)
            {
                foreach (PasswordEntity password in Passwords)
                {
                    this.PasswordDataGridView.Rows.Add(password);
                }
            }
        }

        public void OpenCreatePasswordViewAction(object sender, EventArgs e)
        {
            this.PasswordListViewModel.ToPasswordCreate();
        }

        public void RefreshTable(object sender, EventArgs e)
        {
            this.PasswordListViewModel.GetAllPasswords();
        }
    }
}
