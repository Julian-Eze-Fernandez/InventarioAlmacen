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
    public partial class Form1 : Form
    {
        //Vari
        int contAlimentos = 0;
        int contBebidas = 0;
        int contLimpieza = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Productos Producto = new Productos();

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

            Producto.Contar(ref contAlimentos, ref contBebidas, ref contLimpieza, Producto.CategoriaProducto);
            lblCantAlimentos.Text = contAlimentos.ToString();
            lblCantBebidas.Text = contBebidas.ToString();
            lblCantLimpieza.Text = contLimpieza.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Remove(dgvProductos.CurrentRow);
        }
    }
}
