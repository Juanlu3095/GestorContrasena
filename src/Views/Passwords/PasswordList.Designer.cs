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
            labelPasswordList = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            FilterButton = new Button();
            FilterInput = new TextBox();
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(12, 117);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 321);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(517, 74);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(75, 23);
            FilterButton.TabIndex = 2;
            FilterButton.Text = "Filtrar";
            FilterButton.UseVisualStyleBackColor = true;
            // 
            // FilterInput
            // 
            FilterInput.Location = new Point(240, 74);
            FilterInput.Name = "FilterInput";
            FilterInput.PlaceholderText = "Introduzca término de búsqueda...";
            FilterInput.Size = new Size(256, 23);
            FilterInput.TabIndex = 3;
            // 
            // PasswordList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FilterInput);
            Controls.Add(FilterButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(labelPasswordList);
            Name = "PasswordList";
            Text = "Listado de contraseñas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPasswordList;
        private TableLayoutPanel tableLayoutPanel1;
        private Button FilterButton;
        private TextBox FilterInput;
    }
}