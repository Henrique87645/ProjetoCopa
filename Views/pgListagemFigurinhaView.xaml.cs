using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using ProjetoAlbumCopa.Models;
using ProjetoAlbumCopa.Controllers;

namespace ProjetoAlbumCopa.Views
{
    public partial class pgListagemFigurinhaView : ContentPage
    {
        FigurinhaController _Controller;

        public pgListagemFigurinhaView()
        {
            InitializeComponent();
            _Controller = new FigurinhaController();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarLista();
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            string nome = txtBuscaNome.Text ?? "";
            bool adquiridas = swtFiltroAdquiridas.IsToggled;
            bool desejadas = swtFiltroDesejadas.IsToggled;

            List<Figurinha> listaFiltrada = _Controller.GetFiltroCombinado(nome, adquiridas, desejadas);
            ltvFigurinhas.ItemsSource = listaFiltrada;
        }

        private async void Eye_Tapped(object sender, TappedEventArgs e)
        {
            var image = (Image)sender;
            var figurinha = (Figurinha)image.BindingContext;

            if (figurinha != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new pgVisualizarFigurinhaView(figurinha));
            }
        }

        private void Check_Tapped(object sender, TappedEventArgs e)
        {
            var image = (Image)sender;
            var figurinha = (Figurinha)image.BindingContext;

            if (figurinha != null)
            {
                figurinha.Obtido = !figurinha.Obtido;
                _Controller.Update(figurinha);
                CarregarLista();
            }
        }

        private void Heart_Tapped(object sender, TappedEventArgs e)
        {
            var image = (Image)sender;
            var figurinha = (Figurinha)image.BindingContext;

            if (figurinha != null)
            {
                figurinha.Desejado = !figurinha.Desejado;
                _Controller.Update(figurinha);
                CarregarLista();
            }   
        }

        private async void Trash_Tapped(object sender, TappedEventArgs e)
        {
            var image = (Image)sender;
            var figurinha = (Figurinha)image.BindingContext;

            if (figurinha != null)
            {
                bool resposta = await DisplayAlert("Exclusão", $"Deseja excluir definitivamente {figurinha.NomeJogador}?", "Sim", "Não");

                if (resposta)
                {
                    _Controller.Delete(figurinha);
                    CarregarLista();
                }
            }
        }
    }
}