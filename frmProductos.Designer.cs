
namespace Parcial_WindForm
{
    partial class frmProductos
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnAñad = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnElimi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 173);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowTemplate.Height = 25;
            this.dgvDatos.Size = new System.Drawing.Size(668, 379);
            this.dgvDatos.TabIndex = 0;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(173, 64);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(128, 35);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "Listar productos";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnAñad
            // 
            this.btnAñad.Location = new System.Drawing.Point(173, 122);
            this.btnAñad.Name = "btnAñad";
            this.btnAñad.Size = new System.Drawing.Size(128, 35);
            this.btnAñad.TabIndex = 2;
            this.btnAñad.Text = "Añadir producto";
            this.btnAñad.UseVisualStyleBackColor = true;
            this.btnAñad.Click += new System.EventHandler(this.btnAñad_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(388, 122);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(132, 35);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Actualizar producto";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnElimi
            // 
            this.btnElimi.Location = new System.Drawing.Point(388, 64);
            this.btnElimi.Name = "btnElimi";
            this.btnElimi.Size = new System.Drawing.Size(132, 35);
            this.btnElimi.TabIndex = 4;
            this.btnElimi.Text = "Eliminar producto";
            this.btnElimi.UseVisualStyleBackColor = true;
            this.btnElimi.Click += new System.EventHandler(this.btnElimi_Click);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 586);
            this.Controls.Add(this.btnElimi);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAñad);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnAñad;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnElimi;
    }
}

