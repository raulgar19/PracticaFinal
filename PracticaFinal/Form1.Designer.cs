namespace PracticaFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cmbDepartamentos = new ComboBox();
            btnInsertar = new Button();
            lstEmpleados = new ListBox();
            txtId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtSalario = new TextBox();
            txtOficio = new TextBox();
            txtApellido = new TextBox();
            txtLocalidad = new TextBox();
            txtNombre = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Departamentos";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(12, 27);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(121, 23);
            cmbDepartamentos.TabIndex = 1;
            cmbDepartamentos.SelectedIndexChanged += cmbDepartamentos_SelectedIndexChanged;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(12, 212);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(100, 46);
            btnInsertar.TabIndex = 2;
            btnInsertar.Text = "Insertar departamento";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(149, 27);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(189, 214);
            lstEmpleados.TabIndex = 3;
            lstEmpleados.SelectedIndexChanged += lstEmpleados_SelectedIndexChanged;
            // 
            // txtId
            // 
            txtId.Location = new Point(12, 81);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 9);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 5;
            label2.Text = "Empleados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 6;
            label3.Text = "Id";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 112);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 7;
            label4.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(358, 9);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 8;
            label5.Text = "Apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(358, 63);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 9;
            label6.Text = "Oficio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 165);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 10;
            label7.Text = "Localidad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(358, 112);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 11;
            label8.Text = "Salario";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(358, 130);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(100, 23);
            txtSalario.TabIndex = 12;
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(358, 81);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(100, 23);
            txtOficio.TabIndex = 13;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(358, 27);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 14;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(12, 183);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(100, 23);
            txtLocalidad.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 130);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 16;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(367, 159);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 270);
            Controls.Add(btnUpdate);
            Controls.Add(txtNombre);
            Controls.Add(txtLocalidad);
            Controls.Add(txtApellido);
            Controls.Add(txtOficio);
            Controls.Add(txtSalario);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(lstEmpleados);
            Controls.Add(btnInsertar);
            Controls.Add(cmbDepartamentos);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbDepartamentos;
        private Button btnInsertar;
        private ListBox lstEmpleados;
        private TextBox txtId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtSalario;
        private TextBox txtOficio;
        private TextBox txtApellido;
        private TextBox txtLocalidad;
        private TextBox txtNombre;
        private Button btnUpdate;
    }
}
