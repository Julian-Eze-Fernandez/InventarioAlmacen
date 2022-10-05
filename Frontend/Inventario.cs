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
    public partial class Inventario : Form
    {
        //Variables
        int contAlimentos = 0;
        int contBebidas = 0;
        int contLimpieza = 0;

        public Inventario()
        {
            InitializeComponent();
        }

        Productos Producto = new Productos();
        List<string> listaCodigos = new List<string>();

        //Carga codigo, nombre, preico y catgoria en el data grid view
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!Error())
            {
                //Guarda codigo dentro de lista
                listaCodigos.Add(txtCodigo.Text);

                //Setea valores del atributo
                Producto.CategoriaProducto = cmbCategorias.Text;
                Producto.CodigoProducto = txtCodigo.Text;
                Producto.NombreProducto = txtNombre.Text;
                Producto.PrecioProducto = Convert.ToDecimal(txtPrecio.Text);

                //Nuevo renglon
                int n = dgvProductos.Rows.Add();

                ////Cargar productos
                dgvProductos.Rows[n].Cells[0].Value = Producto.CategoriaProducto;
                dgvProductos.Rows[n].Cells[1].Value = Producto.CodigoProducto;
                dgvProductos.Rows[n].Cells[2].Value = Producto.NombreProducto;
                dgvProductos.Rows[n].Cells[3].Value = Producto.PrecioProducto;

                //limpiar TextBox
                cmbCategorias.Text = "";
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";

                //Setea valores
                Producto.Contar(ref contAlimentos, ref contBebidas, ref contLimpieza, Producto.CategoriaProducto);
                lblCantAlimentos.Text = contAlimentos.ToString();
                lblCantBebidas.Text = contBebidas.ToString();
                lblCantLimpieza.Text = contLimpieza.ToString();
            }

        }
        //Borrar toda una fila del data grid view.
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Validacion por si se quiere borrar algo no seleccionado.
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show(this, "Elija que fila quiere borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvProductos.Rows.Remove(dgvProductos.CurrentRow);

                Producto.Descontar(ref contAlimentos, ref contBebidas, ref contLimpieza, Producto.CategoriaProducto);
                lblCantAlimentos.Text = contAlimentos.ToString();
                lblCantBebidas.Text = contBebidas.ToString();
                lblCantLimpieza.Text = contLimpieza.ToString();
            }
            
        }
        //Metodo que busca errores 
        private bool Error() 
        {
            bool bandera = false;

            //Validacion por si el usuario ingresa caracteres en precio.
            for (int i = 0; i < txtPrecio.Text.Length; i++)
            {
                char c = txtPrecio.Text[i];
                if (!Char.IsDigit(c))
                {
                    bandera = true;
                    //txtPrecio.Text = "Error, ingrese un numero.";
                    MessageBox.Show(this, "No se pueden cargar los datos porque no ingreso un valor en el precio del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            //Validacion por si el usuario no lleno algun textbox.
            if (!txtCodigo.Text.Any() || !txtNombre.Text.Any() || !cmbCategorias.Text.Any())
            {
                bandera= true;
                MessageBox.Show(this, "Los datos no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validacion para que no se repita un codigo.
            if (listaCodigos.Contains(txtCodigo.Text))
            {
                bandera = true;
                MessageBox.Show(this, "ERROR, Codigo Repetido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bandera;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Form ventas = new Ventas();

            ventas.Show();
        }
    }
}
