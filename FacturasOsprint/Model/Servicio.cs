using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasOsprint.Model
{
    public class Servicio : ModelBase
    {
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (cantidad == value) return;
                cantidad = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion == value) return;
                descripcion = value;
                OnPropertyChanged();
            }
        }


        private decimal precioUnitario;

        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                if (precioUnitario == value) return;
                precioUnitario = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private decimal descuento;

        public decimal Descuento
        {
            get { return descuento; }
            set
            {
                if (descuento == value) return;
                descuento = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set
            {
                if (total == value) return;
                total = value;
                OnPropertyChanged();
            }
        }

        private void CalcularTotal()
        {
            Total = Cantidad * PrecioUnitario - Descuento;
        }
    }
}
