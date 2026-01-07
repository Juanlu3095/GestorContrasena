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
            this.PasswordDataGridView.ColumnCount = 3; // Necesario para evitar error

            List<PasswordEntity>? Passwords = new List<PasswordEntity>();
            Passwords = this.PasswordListViewModel.GetAllPasswords();

            this.PasswordDataGridView.Columns[0].Name = "Nombre";
            this.PasswordDataGridView.Columns[1].Name = "Servicio";
            this.PasswordDataGridView.Columns[2].Name = "Fecha actualización";

            DataGridViewButtonColumn EditButtonColumn = new DataGridViewButtonColumn();
            EditButtonColumn.Text = "Ver/Editar";
            EditButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn DeleteButtonColumn = new DataGridViewButtonColumn();
            DeleteButtonColumn.Text = "Eliminar";
            DeleteButtonColumn.UseColumnTextForButtonValue = true;
            this.PasswordDataGridView.Columns.Add(EditButtonColumn);
            this.PasswordDataGridView.Columns.Add(DeleteButtonColumn);

            if (Passwords != null && Passwords.Count() > 0)
            {
                foreach (PasswordEntity password in Passwords)
                {
                    object[] row =
                    {
                        password.Name, password.Service, password.Updated_at.ToString()
                    };
                    this.PasswordDataGridView.Rows.Add(row);
                }
            }

        }

        public void OpenCreatePasswordViewAction(object sender, EventArgs e)
        {
            this.PasswordListViewModel.ToPasswordCreate();
        }

        public void OpenEditPasswordViewAction(object sender, EventArgs e)
        {

        }

        public void OpenDeletePasswordViewAction(object sender, EventArgs e)
        {

        }

        public void RefreshTable(object sender, EventArgs e)
        {
            this.PasswordDataGridView.Rows.Clear(); // Limpia las filas antes de volver a cargarlas y que se repitan
            this.InitializeTable();
        }
    }
}
