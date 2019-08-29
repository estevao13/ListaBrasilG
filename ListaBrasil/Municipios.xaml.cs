using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ListaBrasil.Modelo;
using System.Linq;

namespace ListaBrasil
{
    public partial class Municipios : ContentPage
    {
        private List<Municipio> ListaInternaMunicipio { get; set; }
        private List<Municipio> ListaFiltradaMunicipio { get; set; }

        public Municipios(Estado estado)
        {
            InitializeComponent();

            ListaInternaMunicipio = Servico.Servico.GetMunicipios(estado.id);
            ListaMunicipios.ItemsSource = ListaInternaMunicipio;
        }

        private void BuscaRapida (Object sender, TextChangedEventArgs args)
        {
            ListaFiltradaMunicipio = ListaInternaMunicipio.Where(a => a.nome.Contains(args.NewTextValue)).ToList();
            ListaMunicipios.ItemsSource = ListaFiltradaMunicipio;
        }
    }
}
