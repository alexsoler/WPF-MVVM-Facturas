using FacturasOsprint.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasOsprint.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public Facturas Facturas { get; private set; }

        public MainViewModel()
        {
            Facturas = new Facturas();
            WireCommands();
        }

        private void WireCommands()
        {
            ShowInformation = new RelayCommand(MostrarInformacion);
        }

        public RelayCommand ShowInformation { get; set; }

        private async void MostrarInformacion()
        {
            var sampleMessageDialog = new SampleMessageDialog()
            {
                Message = {Text = "Programa Desarrollado por: \n" +
                "Alex Geovany Soler Chavarria\n\n" +
                "Correo: alexgeovanys@gmail.com\n" +
                "Telefono: +504 9750-8879"}
            };

            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }
    }
}
