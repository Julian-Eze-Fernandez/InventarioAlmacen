using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend;

namespace Frontend
{
    public partial class Ventas : Form
    {
        // Creamos nuestro objeto de clase producto
        Productos Producto = new Productos();

        public Ventas()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (!Error())
            {
                //Setea valores del atributo
                Producto.CodigoProducto = txtCodigo.Text;
                Producto.CantidadProducto = Convert.ToDecimal(txtCantidad.Text);

                //Nuevo renglon
                int n = dgvVentas.Rows.Add();

                //Cargar datos al dgv
                dgvVentas.Rows[n].Cells[0].Value = Producto.CodigoProducto;
                dgvVentas.Rows[n].Cells[1].Value = Producto.CantidadProducto;

                decimal total = Producto.CantidadProducto * Producto.PrecioProducto;
                dgvVentas.Rows[n].Cells[3].Value = total;

                //Limpiar TextBox
                txtCantidad.Text = "";
                txtCodigo.Text = "";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Validacion por si se quiere borrar algo no seleccionado.
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show(this, "Elija que fila quiere borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvVentas.Rows.Remove(dgvVentas.CurrentRow);
            }
        }

        //Metodo que busca errores 
        private bool Error()
        {
            bool bandera = false;

            //Validacion por si el usuario ingresa caracteres en cantidad.
            for (int i = 0; i < txtCantidad.Text.Length; i++)
            {
                char c = txtCantidad.Text[i];
                if (!Char.IsDigit(c))
                {
                    bandera = true;
                    //txtCantidad.Text = "Error, ingrese un numero.";
                    MessageBox.Show(this, "No se pueden cargar los datos porque no ingreso un valor en la cantidad del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            //Validacion por si el usuario no lleno algun textbox.
            if (!txtCodigo.Text.Any() || !txtCantidad.Text.Any())
            {
                bandera = true;
                MessageBox.Show(this, "Faltan datos de cargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bandera;
        }
    }
}
