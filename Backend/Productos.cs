using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Productos
    {
        //Getters y Setters
        public string CategoriaProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal CantidadProducto { get; set; }

        //Metodo que suma productos
        public void Contar(ref int contarAlimentos, ref int contarBebidas, ref int contarLimpieza, string categoria)
        {
            if (categoria == "Alimentos")
            {
                contarAlimentos++;
            }
            else if (categoria == "Bebidas")
            {
                contarBebidas++;
            }
            else if (categoria == "Limpieza")
            {
                contarLimpieza++;
            }
        }

        //Metodo que resta productos
        public void Descontar(ref int contarAlimentos, ref int contarBebidas, ref int contarLimpieza, string categoria)
        {
            if (categoria == "Alimentos")
            {
                contarAlimentos--;
            }
            else if (categoria == "Bebidas")
            {
                contarBebidas--;
            }
            else if (categoria == "Limpieza")
            {
                contarLimpieza--;
            }
        }
    }
}
