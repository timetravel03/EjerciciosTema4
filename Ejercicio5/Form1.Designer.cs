﻿namespace Ejercicio5
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonElim = new System.Windows.Forms.Button();
            this.buttonTras = new System.Windows.Forms.Button();
            this.buttonTras2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelIndices = new System.Windows.Forms.Label();
            this.labelPrincipal = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(46, 132);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.Leave += new System.EventHandler(this.listBox1_Leave);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(289, 132);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(187, 64);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Añadir";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonElim
            // 
            this.buttonElim.Location = new System.Drawing.Point(25, 233);
            this.buttonElim.Name = "buttonElim";
            this.buttonElim.Size = new System.Drawing.Size(75, 23);
            this.buttonElim.TabIndex = 3;
            this.buttonElim.Text = "Eliminar";
            this.buttonElim.UseVisualStyleBackColor = true;
            this.buttonElim.Click += new System.EventHandler(this.buttonElim_Click);
            // 
            // buttonTras
            // 
            this.buttonTras.Location = new System.Drawing.Point(106, 233);
            this.buttonTras.Name = "buttonTras";
            this.buttonTras.Size = new System.Drawing.Size(75, 23);
            this.buttonTras.TabIndex = 4;
            this.buttonTras.Text = "Traspasar ->";
            this.buttonTras.UseVisualStyleBackColor = true;
            this.buttonTras.Click += new System.EventHandler(this.buttonTras_Click);
            // 
            // buttonTras2
            // 
            this.buttonTras2.Location = new System.Drawing.Point(314, 233);
            this.buttonTras2.Name = "buttonTras2";
            this.buttonTras2.Size = new System.Drawing.Size(75, 23);
            this.buttonTras2.TabIndex = 5;
            this.buttonTras2.Text = "<- Traspasar";
            this.buttonTras2.UseVisualStyleBackColor = true;
            this.buttonTras2.Click += new System.EventHandler(this.buttonTras2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // labelIndices
            // 
            this.labelIndices.AutoSize = true;
            this.labelIndices.Location = new System.Drawing.Point(43, 105);
            this.labelIndices.Name = "labelIndices";
            this.labelIndices.Size = new System.Drawing.Size(115, 13);
            this.labelIndices.TabIndex = 7;
            this.labelIndices.Text = "Índices seleccionados:";
            // 
            // labelPrincipal
            // 
            this.labelPrincipal.AutoSize = true;
            this.labelPrincipal.Location = new System.Drawing.Point(43, 74);
            this.labelPrincipal.Name = "labelPrincipal";
            this.labelPrincipal.Size = new System.Drawing.Size(97, 13);
            this.labelPrincipal.TabIndex = 8;
            this.labelPrincipal.Text = "Nº de elementos: 0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 299);
            this.Controls.Add(this.labelPrincipal);
            this.Controls.Add(this.labelIndices);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonTras2);
            this.Controls.Add(this.buttonTras);
            this.Controls.Add(this.buttonElim);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Listas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonElim;
        private System.Windows.Forms.Button buttonTras;
        private System.Windows.Forms.Button buttonTras2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelIndices;
        private System.Windows.Forms.Label labelPrincipal;
        private System.Windows.Forms.Timer timer1;
    }
}

