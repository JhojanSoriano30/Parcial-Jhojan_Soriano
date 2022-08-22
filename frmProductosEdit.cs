using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parcial_WindForm
{
    public partial class frmProductosEdit : Form
    {


        string cadenaConexion = "server = PC303\\PAREDES; database=Parcial; Integrated Security = true";

        public frmProductosEdit()
        {
            InitializeComponent();
        }




        private void cargarDatos()
        {
      
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                //cargar datos de tipo de cliente
                var sql = "SELECT * FROM Categoria";



                using (var comando = new SqlCommand(sql, conexion))
                {

                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Dictionary<string, string> productoSource = new Dictionary<string, string>();
                            while (lector.Read())
                            {

                                productoSource.Add(lector[0].ToString(), lector[2].ToString());
                             
                            }
                           
                            cboCategoria.DataSource = new BindingSource(productoSource, null);
                            cboCategoria.DisplayMember = "Value";
                            cboCategoria.ValueMember = "Key";
                        }
                    }
                }


            }
        }






        private void btnAcept_Click(object sender, EventArgs e)
        {

            int sto = Convert.ToInt32(txtStock.Text);
            double pre = Convert.ToDouble(txtPrecio.Text);
            if (pre > 2500)
            {
                MessageBox.Show("El precio no debe exceder a los S/2500.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Text = "";
                return;
            }
      
           
                if (sto <= 5)
                {
                    MessageBox.Show("El stock debe ser mayor a 5.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);


                txtStock.Text = "";
                return;
                }

            else
            {

             this.DialogResult = DialogResult.OK;
                
                cargarDatos();

            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
          
      
        }

        private void frmProductosEdit_Load(object sender, EventArgs e)
        {
            btnAcept.Enabled = false;

            cargarDatos();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
                e.Handled = true;

            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

           if (char.IsLetter(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;

            else if (char.IsNumber(e.KeyChar))
                e.Handled = true;

            else if (char.IsSymbol(e.KeyChar))
                e.Handled = true;

            else if (char.IsPunctuation(e.KeyChar))
                e.Handled = true;

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }




            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

            if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text == ""
             && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text == "" && txtMarca.Text == "" && txtPrecio.Text == ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text == ""
               && txtStock.Text == "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text == "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }


            else if (txtProducto.Text == "" && txtMarca.Text != "" && txtPrecio.Text != ""
              && txtStock.Text != "")
            {

                btnAcept.Enabled = false;

            }

            else if (txtProducto.Text != "" && txtMarca.Text != "" && txtPrecio.Text != ""
               && txtStock.Text != "")
            {

                btnAcept.Enabled = true;

            }
        }
    }
}
