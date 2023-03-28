using AppBuscaCep.Model;
using AppBuscaCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscaCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BairrosPorCidade : ContentPage
    {
        ObservableCollection<Cidade> lista_cidade = new ObservableCollection<Cidade>(); 
        ObservableCollection<Bairro> lista_bairros= new ObservableCollection<Bairro>();     
        public BairrosPorCidade()
        {
            InitializeComponent();

            pck_cidade.ItemsSource= lista_cidade;   
            lst_bairros.ItemsSource= lista_bairros;
   
           
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker Disparador = sender as Picker;

                string estado_selecionado = Disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadeByUf(estado_selecionado);
                lista_cidade.Clear();

                arr_cidades.ForEach(i => lista_cidade.Add(i));
            }
            catch(Exception ex) 
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            
        }

        private async void pck_Cidade_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                Cidade cidade_selecionada = disparador.SelectedItem as Cidade;

                List<Bairro> arr_bairros = await DataService.GetBairrosByIdCidade(cidade_selecionada.id_cidade);

                lista_bairros.Clear();
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}