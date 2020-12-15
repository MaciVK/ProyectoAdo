namespace ProyectoAdo
{
    partial class Form10ClasesEmpleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOficios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvEmpleados = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIncremento = new System.Windows.Forms.TextBox();
            this.btnIncrementar = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oficios";
            // 
            // cmbOficios
            // 
            this.cmbOficios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOficios.FormattingEnabled = true;
            this.cmbOficios.Location = new System.Drawing.Point(15, 31);
            this.cmbOficios.Name = "cmbOficios";
            this.cmbOficios.Size = new System.Drawing.Size(193, 26);
            this.cmbOficios.TabIndex = 1;
            this.cmbOficios.SelectedIndexChanged += new System.EventHandler(this.cmbOficios_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empleados";
            // 
            // lsvEmpleados
            // 
            this.lsvEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lsvEmpleados.HideSelection = false;
            this.lsvEmpleados.Location = new System.Drawing.Point(12, 101);
            this.lsvEmpleados.Name = "lsvEmpleados";
            this.lsvEmpleados.Size = new System.Drawing.Size(779, 327);
            this.lsvEmpleados.TabIndex = 3;
            this.lsvEmpleados.UseCompatibleStateImageBehavior = false;
            this.lsvEmpleados.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Incremento Salarial:";
            // 
            // txtIncremento
            // 
            this.txtIncremento.Location = new System.Drawing.Point(430, 6);
            this.txtIncremento.Name = "txtIncremento";
            this.txtIncremento.Size = new System.Drawing.Size(182, 24);
            this.txtIncremento.TabIndex = 5;
            // 
            // btnIncrementar
            // 
            this.btnIncrementar.Location = new System.Drawing.Point(358, 53);
            this.btnIncrementar.Name = "btnIncrementar";
            this.btnIncrementar.Size = new System.Drawing.Size(131, 42);
            this.btnIncrementar.TabIndex = 6;
            this.btnIncrementar.Text = "Incrementar";
            this.btnIncrementar.UseVisualStyleBackColor = true;
            this.btnIncrementar.Click += new System.EventHandler(this.btnIncrementar_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "APELLIDO";
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DIR";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "FECHA ALTA";
            this.columnHeader4.Width = 138;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SALARIO";
            this.columnHeader5.Width = 122;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "COMISION";
            this.columnHeader6.Width = 112;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nº DEPARTAMENTO";
            this.columnHeader7.Width = 156;
            // 
            // Form10ClasesEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 434);
            this.Controls.Add(this.btnIncrementar);
            this.Controls.Add(this.txtIncremento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsvEmpleados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOficios);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form10ClasesEmpleado";
            this.Text = "Form10ClasesEmpleado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOficios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvEmpleados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIncremento;
        private System.Windows.Forms.Button btnIncrementar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}