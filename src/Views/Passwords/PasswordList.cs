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

            this.PasswordDataGridView.Columns[0].Name = "Id";
            this.PasswordDataGridView.Columns[1].Name = "Nombre";
            this.PasswordDataGridView.Columns[2].Name = "Servicio";
            this.PasswordDataGridView.Columns[3].Name = "Fecha actualización";

            this.PasswordDataGridView.Columns[0].Visible = false; // Ocultamos la id de la vista, pero la podemos usar para identificar el registro en base de datos para editar.

            DataGridViewButtonColumn EditButtonColumn = new DataGridViewButtonColumn();
            EditButtonColumn.Text = "Ver/Editar";
            EditButtonColumn.Name = "Editar"; // Esto es lo que se muestra en el header de la tabla, deberia quitarse pero si no, no se puede abrir el MODAL !!
            EditButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn DeleteButtonColumn = new DataGridViewButtonColumn();
            DeleteButtonColumn.Text = "Eliminar";
            DeleteButtonColumn.Name = "Eliminar"; // Esto es lo que se muestra en el header de la tabla
            DeleteButtonColumn.UseColumnTextForButtonValue = true;
            this.PasswordDataGridView.Columns.Add(EditButtonColumn);
            this.PasswordDataGridView.Columns.Add(DeleteButtonColumn);

            if (Passwords != null && Passwords.Count() > 0)
            {
                foreach (PasswordEntity password in Passwords)
                {
                    object[] row =
                    {
                        password.Id, password.Name, password.Service, password.Updated_at.ToString()
                    };
                    this.PasswordDataGridView.Rows.Add(row);
                }
            }

        }

        public void OpenCreatePasswordViewAction(object sender, EventArgs e)
        {
            this.PasswordListViewModel.ToPasswordCreate();
        }

        public void FilterAction(object sender, EventArgs e)
        {
            var FilteredPasswords = this.PasswordListViewModel.FilterPasswordsByName(this.FilterInput.Text);
            if (FilteredPasswords != null && FilteredPasswords.Count > 0)
            {
                this.PasswordDataGridView.Rows.Clear(); // Limpia las filas antes de volver a cargarlas y que se repitan
                foreach (PasswordEntity password in FilteredPasswords)
                {
                    object[] row =
                    {
                        password.Id, password.Name, password.Service, password.Updated_at.ToString()
                    };
                    this.PasswordDataGridView.Rows.Add(row);
                }
            }
        }

        // Función que escucha los clicks en la tabla, el cual se asigna en PasswordList.Designer
        public void TableButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se debe comprobar si estos valores no son menores de 0 porque sino da un error "Index out of range"
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            if (columnIndex >= 0 && rowIndex >= 0 && this.PasswordDataGridView.Columns[columnIndex].Name == "Editar") // También podría sólo comprobarse que columnIndex es 3 para edit y 4 para delete
            {
                if (this.PasswordDataGridView.Rows[e.RowIndex].Cells[0].Value == null) return; // Se hace esto para que al pulsar fuera de los datos no salte error al devolver alguno de estos dos el valor null
                Guid id = Guid.Parse(this.PasswordDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString() ?? "");
                this.OpenEditPasswordViewAction(id);
            }

            if (columnIndex >= 0 && rowIndex >= 0 && this.PasswordDataGridView.Columns[columnIndex].Name == "Eliminar")
            {
                if (this.PasswordDataGridView.Rows[e.RowIndex].Cells[0].Value == null) return; // Igual que en el if de antes, cuando se pulsa en columna eliminar donde no hay valor
                var id = PasswordDataGridView.Rows[e.RowIndex].Cells[0].Value ?? "";
                var name = PasswordDataGridView.Rows[e.RowIndex].Cells[1].Value ?? "";
                this.OpenDeletePasswordViewAction(Guid.Parse(id.ToString() ?? ""), name.ToString() ?? "");
            }

            return;
        }

        public void OpenEditPasswordViewAction(Guid id)
        {
            this.PasswordListViewModel.ToPasswordEdit(id);
        }

        public void OpenDeletePasswordViewAction(Guid id, string name)
        {
            var DeleteConfirmation = MessageBox.Show("¿Estás seguro/a de querer eliminar la contraseña de nombre '" + name + "'?",
                "Confirmación para eliminar registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (DeleteConfirmation == DialogResult.Yes) this.PasswordListViewModel.DeletePassword(id);
        }

        public void RefreshTable(object sender, EventArgs e)
        {
            this.PasswordDataGridView.Rows.Clear(); // Limpia las filas antes de volver a cargarlas y que se repitan
            this.InitializeTable();
        }
    }
}
