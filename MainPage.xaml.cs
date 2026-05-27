using System;
using Microsoft.Maui.Controls;
using ProjetoAlbumCopa.Views;

namespace ProjetoAlbumCopa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCadastro_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new pgCadFigurinhaView());
        }

        private void btnListagem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new pgListagemFigurinhaView());
        }
    }
}