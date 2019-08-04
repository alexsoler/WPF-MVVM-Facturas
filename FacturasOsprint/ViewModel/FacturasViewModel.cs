using FacturasOsprint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasOsprint.ViewModel
{
    internal class FacturasViewModel : ViewModelBase
    {
        public Factura Factura { get; set; }
        
        public FacturasViewModel()
        {
            Factura = new Factura();
            Factura.Fecha = DateTime.Now;
            WireCommands();
        }

        public void WireCommands()
        {
            CalcularTotalCommand = new RelayCommand(CalcularTotal);
        }

        public RelayCommand CalcularTotalCommand { get; set; }

        private void CalcularTotal()
        {
            Factura.Importe15 = Factura.Servicios.Sum(x => x.Total);
        }
    }
}
