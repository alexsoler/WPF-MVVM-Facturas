using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UrySoft.Utilities.Extensions;

namespace FacturasOsprint.Model
{
    public class Factura : ModelBase
    {
        public Factura()
        {
            Servicios = new ObservableCollection<Servicio>();
            Fecha = DateTime.Now;
        }
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set
            {
                if (cliente == value) return;
                cliente = value;
                OnPropertyChanged();
            }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (direccion == value) return;
                direccion = value;
                OnPropertyChanged();
            }
        }

        private string rtn;

        public string RTN
        {
            get { return rtn; }
            set
            {
                if (rtn == value) return;
                rtn = value;
                OnPropertyChanged();
            }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha == value) return;
                fecha = value;
                OnPropertyChanged();
            }
        }

        private string constanciaExonerados;

        public string ConstanciaExonerados
        {
            get { return constanciaExonerados; }
            set
            {
                if (constanciaExonerados == value) return;
                constanciaExonerados = value;
                OnPropertyChanged();
            }
        }


        private string ordenCompraExenta;

        public string OrdenCompraExenta
        {
            get { return ordenCompraExenta; }
            set
            {
                if (ordenCompraExenta == value) return;
                ordenCompraExenta = value;
                OnPropertyChanged();
            }
        }

        private string numRegSAG;

        public string NumRegSAG
        {
            get { return numRegSAG; }
            set
            {
                if (numRegSAG == value) return;
                numRegSAG = value;
                OnPropertyChanged();
            }
        }

        private string cantLetras;

        public string CantLetras
        {
            get { return cantLetras; }
            set
            {
                if (cantLetras == value) return;
                cantLetras = value;
                OnPropertyChanged();
            }
        }

        private decimal importeExento;

        public decimal ImporteExento
        {
            get { return importeExento; }
            set
            {
                if (importeExento == value) return;
                importeExento = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private decimal exonerados;

        public decimal Exonerados
        {
            get { return exonerados; }
            set
            {
                if (exonerados == value) return;
                exonerados = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private decimal importe18;

        public decimal Importe18
        {
            get { return importe18; }
            set
            {
                if (importe18 == value) return;
                importe18 = value;
                OnPropertyChanged();
                ISV18 = importe18 * 0.18M;
            }
        }

        private decimal importe15;

        public decimal Importe15
        {
            get { return importe15; }
            set
            {
                if (importe15 == value) return;
                importe15 = value;
                OnPropertyChanged();
                ISV15 = importe15 * 0.15M;
            }
        }

        private decimal isv18;

        public decimal ISV18
        {
            get { return isv18; }
            set
            {
                if (isv18 == value) return;
                isv18 = value;
                OnPropertyChanged();
                CalcularTotal();
            }
        }

        private decimal isv15;

        public decimal ISV15
        {
            get { return isv15; }
            set
            {
                if (isv15 == value) return;
                isv15 = value;
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

        public ObservableCollection<Servicio> Servicios { get; set; }


        private void CalcularTotal()
        {
            Total = ImporteExento + Exonerados + Importe15 + Importe18 + ISV15 + ISV18;
            string cantidadLetras = Convert.ToDouble(Total)
                .ToAmountLetters(UrySoft.Utilities.Converts.Types.ToLettersCurrencyNamesSupportedType.Euro, UrySoft.Utilities.Converts.Types.ToLettersLanguageSupportedType.Spanish)
                .Replace("euros", "lempiras").Replace("centimos", "centavos");

            if (Total % 1 == 0)
            {
                CantLetras = cantidadLetras.First().ToString().ToUpper() + cantidadLetras.Substring(1) + " exactos";
            }
            else
            {
                CantLetras = cantidadLetras.First().ToString().ToUpper() + cantidadLetras.Substring(1);
            }
        }
    }
}
