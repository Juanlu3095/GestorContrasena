namespace GestorContrasena.Views.Passwords
{
    partial class PasswordList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            labelPasswordList = new Label();
            FilterButton = new Button();
            FilterInput = new TextBox();
            PasswordDataGridView = new DataGridView();
            NewElementButton = new Button();
            RefreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PasswordDataGridView).BeginInit();
            SuspendLayout();
            // 
            // labelPasswordList
            // 
            labelPasswordList.AutoSize = true;
            labelPasswordList.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPasswordList.Location = new Point(299, 29);
            labelPasswordList.Name = "labelPasswordList";
            labelPasswordList.Size = new Size(228, 28);
            labelPasswordList.TabIndex = 0;
            labelPasswordList.Text = "Listado de contraseñas";
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(386, 73);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(75, 23);
            FilterButton.TabIndex = 2;
            FilterButton.Text = "Filtrar";
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterAction;
            // 
            // FilterInput
            // 
            FilterInput.Location = new Point(124, 73);
            FilterInput.Name = "FilterInput";
            FilterInput.PlaceholderText = "Introduzca término de búsqueda...";
            FilterInput.Size = new Size(256, 23);
            FilterInput.TabIndex = 3;
            // 
            // PasswordDataGridView
            // 
            PasswordDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PasswordDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            PasswordDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            PasswordDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PasswordDataGridView.Location = new Point(12, 117);
            PasswordDataGridView.Name = "PasswordDataGridView";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            PasswordDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            PasswordDataGridView.Size = new Size(776, 321);
            PasswordDataGridView.TabIndex = 4;
            PasswordDataGridView.CellClick += TableButtonClick;
            // 
            // NewElementButton
            // 
            NewElementButton.Location = new Point(467, 73);
            NewElementButton.Name = "NewElementButton";
            NewElementButton.Size = new Size(126, 23);
            NewElementButton.TabIndex = 5;
            NewElementButton.Text = "Nuevo elemento";
            NewElementButton.UseVisualStyleBackColor = true;
            NewElementButton.Click += OpenCreatePasswordViewAction;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(599, 73);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 6;
            RefreshButton.Text = "Refrescar";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshTable;
            // 
            // PasswordList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RefreshButton);
            Controls.Add(NewElementButton);
            Controls.Add(PasswordDataGridView);
            Controls.Add(FilterInput);
            Controls.Add(FilterButton);
            Controls.Add(labelPasswordList);
            Name = "PasswordList";
            Text = "Listado de contraseñas";
            ((System.ComponentModel.ISupportInitialize)PasswordDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPasswordList;
        private Button FilterButton;
        private TextBox FilterInput;
        private DataGridView PasswordDataGridView;
        private Button NewElementButton;
        private Button RefreshButton;
    }
}