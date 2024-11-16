namespace Ejercicio7
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAlumno = new System.Windows.Forms.ComboBox();
            this.comboBoxAsig = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInfoAlumno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAlumno
            // 
            this.comboBoxAlumno.FormattingEnabled = true;
            this.comboBoxAlumno.Location = new System.Drawing.Point(12, 25);
            this.comboBoxAlumno.Name = "comboBoxAlumno";
            this.comboBoxAlumno.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAlumno.TabIndex = 0;
            this.comboBoxAlumno.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlumno_SelectedIndexChanged);
            // 
            // comboBoxAsig
            // 
            this.comboBoxAsig.FormattingEnabled = true;
            this.comboBoxAsig.Location = new System.Drawing.Point(155, 25);
            this.comboBoxAsig.Name = "comboBoxAsig";
            this.comboBoxAsig.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAsig.TabIndex = 1;
            this.comboBoxAsig.SelectedIndexChanged += new System.EventHandler(this.comboBoxAsig_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alumno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asignatura";
            // 
            // labelInfoAlumno
            // 
            this.labelInfoAlumno.AutoSize = true;
            this.labelInfoAlumno.Location = new System.Drawing.Point(318, 9);
            this.labelInfoAlumno.Name = "labelInfoAlumno";
            this.labelInfoAlumno.Size = new System.Drawing.Size(35, 13);
            this.labelInfoAlumno.TabIndex = 4;
            this.labelInfoAlumno.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 498);
            this.Controls.Add(this.labelInfoAlumno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAsig);
            this.Controls.Add(this.comboBoxAlumno);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlumno;
        private System.Windows.Forms.ComboBox comboBoxAsig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInfoAlumno;
    }
}

