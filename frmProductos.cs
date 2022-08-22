using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_WindForm
{
    public partial class frmProductos : Form
    {
        string cadenaConexion = "server = PC303\\PAREDES; database=Parcial; Integrated Security = true";
        DataTable dtPro;
        SqlDataAdapter daPro;
        SqlConnection conexion;
        DataSet daset;

       

        public frmProductos()
        {
            

            InitializeComponent();
           
            daPro = new SqlDataAdapter();

            dtPro = new DataTable();
         
            conexion = new SqlConnection(cadenaConexion);

            daPro.UpdateCommand =
             new SqlCommand("UPDATE Producto SET Nombre=@nombre, Marca=@marca, Precio = @precio, Stock = @stock, IdCategoria=@idcateg WHERE IdProducto=@id", conexion);
            //definir parametros
            daPro.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 20, "Nombre");
            daPro.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 20, "Marca");
            daPro.UpdateCommand.Parameters.Add("@precio", SqlDbType.Money, 20, "Precio");
            daPro.UpdateCommand.Parameters.Add("@stock", SqlDbType.Int, 10, "Stock");
            daPro.UpdateCommand.Parameters.Add("@idcateg", SqlDbType.Int, 10, "IdCategoria");
            daPro.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "IdProducto");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            listar();
        }

        public void listar()
        {
            dtPro.Clear();

            var cadenaConexion = "server = PC303\\PAREDES; database=Parcial; Integrated Security = true";


            var conexion = new SqlConnection(cadenaConexion);
            var adaptador = new SqlDataAdapter("select Producto.IdProducto, Producto.Nombre, Marca,  Categoria.Nombre as Categoría, precio, Stock from Producto inner join Categoria on Producto.IdCategoria = Categoria.IdCategoria", conexion);
            var datos = new DataSet();
            adaptador.Fill(datos, "Producto");

            dgvDatos.DataSource = datos.Tables["Producto"];

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dtPro.Clear();
            listar();

        }

        private void btnAñad_Click(object sender, EventArgs e)
        {
            var frm = new frmProductosEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Text = "Nuevo";
                var producto = ((TextBox)frm.Controls["txtProducto"]).Text;
                var marca = ((TextBox)frm.Controls["txtMarca"]).Text;
                var precio = ((TextBox)frm.Controls["txtPrecio"]).Text;
                var stock = ((TextBox)frm.Controls["txtStock"]).Text;
                var categoria = ((ComboBox)frm.Controls["cboCategoria"]).SelectedValue.ToString();

                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "INSERT INTO Producto (Nombre ,Marca, Precio, Stock," +
                           "IdCategoria)" +
                           "VALUES(@producto, @marca, @precio, @stock, @idcategoria)";

                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@producto", producto);
                        comando.Parameters.AddWithValue("@marca", marca);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@stock", stock);
                        comando.Parameters.AddWithValue("@idcategoria", categoria);

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("El producto fue registrado",
                                "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listar();
                        }
                        else
                        {
                            MessageBox.Show("La inserción del producto ha fallado.", "Sistemas",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var filaActual = dgvDatos.CurrentRow;
            daset = new DataSet();

            if (filaActual != null)
            {
                var filaEditar = dtPro.Rows[filaActual.Index];
                var frm = new frmProductosEdit();

                ((TextBox)frm.Controls["txtProducto"]).Text = filaEditar["Nombre"].ToString();
                ((TextBox)frm.Controls["txtMarca"]).Text = filaEditar["Marca"].ToString();
                ((TextBox)frm.Controls["txtPrecio"]).Text = filaEditar["Precio"].ToString();
                ((TextBox)frm.Controls["txtStock"]).Text = filaEditar["Stock"].ToString();
                ((ComboBox)frm.Controls["cboCategoria"]).SelectedValue = filaEditar["Categoria"].ToString();


                if (frm.ShowDialog() == DialogResult.OK)
                {

                    this.Text = "Editar";

                    filaEditar["Nombre"] = ((TextBox)frm.Controls["txtProducto"]).Text;
                    filaEditar["Marca"] = ((TextBox)frm.Controls["txtMarca"]).Text;
                    filaEditar["Categoria"] = ((ComboBox)frm.Controls["cboCategoria"]).SelectedText;
                    filaEditar["Precio"] = ((TextBox)frm.Controls["txtProducto"]).Text;
                    filaEditar["Stock"] = ((TextBox)frm.Controls["txtStock"]).Text;

                }
                else
                {
                    this.Text = "Nuevo";


                }

            }

        }

        private void btnElimi_Click(object sender, EventArgs e)
        {

            var respuesta = MessageBox.Show("¿Realmente desea eliminar el producto?", "Sistemas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {

                if (dgvDatos.CurrentRow == null)

                    return;

                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IdProducto"].Value);

                using (var conexion = new SqlConnection(cadenaConexion))
                {

                    conexion.Open();

                    string comand = "DELETE FROM Producto where IdProducto = @id";

                    SqlCommand cmd = new SqlCommand(comand, conexion);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }

                dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                MessageBox.Show("Se eliminó correctamente", "Satisfactorio",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }

            else if (respuesta == DialogResult.No)
            {
                listar();

            }

            else
            {
                MessageBox.Show("Hubo un error al borrar el registro", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }



        }

    }
}

