using FacturasOsprint.Model;
using FacturasOsprint.ReportsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasOsprint.ViewModel
{
    internal class FacturasViewModel : ViewModelBase
    {
        #region Propiedades
        private Factura _factura;
        public Factura Factura
        {
            get => _factura;
            set
            {
                if (_factura == value) return;
                _factura = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public FacturasViewModel()
        {
            Factura = new Factura();
            WireCommands();
        }

        #region Comandos
        public void WireCommands()
        {
            CalcularTotalCommand = new RelayCommand(CalcularTotal);
            GenerarFacturaCommand = new RelayCommand(GenerarFactura);
            NuevaFacturaCommand = new RelayCommand(NuevaFactura);
        }
        

        public RelayCommand CalcularTotalCommand { get; set; }
        public RelayCommand GenerarFacturaCommand { get; set; }
        public RelayCommand NuevaFacturaCommand { get; set; }
        #endregion

        #region Metodos
        private void CalcularTotal()
        {
            Factura.Importe15 = Factura.Servicios.Sum(x => x.Total);
        }

        public void GenerarFactura()
        {
            int i = 1;
            foreach (var item in Factura.Servicios)
            {
                item.Id = i;
                i++;
            }

            FormFactura frm = new FormFactura(Factura);
            frm.Show();
        }

        public void NuevaFactura()
        {
            Factura = new Factura();
        }
        #endregion
    }
}
