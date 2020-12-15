namespace ProyectoAdo
{
    partial class Form09ClasesEnfermo
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
            this.lsvEnfermos = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.INSCRIPCION = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.APELLIDO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DIR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FECH_NAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvEnfermos
            // 
            this.lsvEnfermos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.INSCRIPCION,
            this.APELLIDO,
            this.DIR,
            this.FECH_NAC});
            this.lsvEnfermos.HideSelection = false;
            this.lsvEnfermos.Location = new System.Drawing.Point(13, 40);
            this.lsvEnfermos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvEnfermos.Name = "lsvEnfermos";
            this.lsvEnfermos.Size = new System.Drawing.Size(481, 273);
            this.lsvEnfermos.TabIndex = 0;
            this.lsvEnfermos.UseCompatibleStateImageBehavior = false;
            this.lsvEnfermos.View = System.Windows.Forms.View.Details;
            this.lsvEnfermos.SelectedIndexChanged += new System.EventHandler(this.lsvEnfermos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enfermos";
            // 
            // INSCRIPCION
            // 
            this.INSCRIPCION.Text = "INSCRIPCION";
            this.INSCRIPCION.Width = 115;
            // 
            // APELLIDO
            // 
            this.APELLIDO.Text = "APELLIDO";
            this.APELLIDO.Width = 87;
            // 
            // DIR
            // 
            this.DIR.Text = "DIRECCION";
            this.DIR.Width = 114;
            // 
            // FECH_NAC
            // 
            this.FECH_NAC.Text = "FECHA NACIMIENTO";
            this.FECH_NAC.Width = 159;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(12, 320);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(223, 37);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form09ClasesEnfermo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 369);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvEnfermos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form09ClasesEnfermo";
            this.Text = "Form09ClasesEnfermo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvEnfermos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader INSCRIPCION;
        private System.Windows.Forms.ColumnHeader APELLIDO;
        private System.Windows.Forms.ColumnHeader DIR;
        private System.Windows.Forms.ColumnHeader FECH_NAC;
        private System.Windows.Forms.Button btnEliminar;
    }
}