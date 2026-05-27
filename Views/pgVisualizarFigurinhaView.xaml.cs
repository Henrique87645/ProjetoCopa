using System;
using Microsoft.Maui.Controls;
using ProjetoAlbumCopa.Models;

namespace ProjetoAlbumCopa.Views
{
    public partial class pgVisualizarFigurinhaView : ContentPage
    {
        public pgVisualizarFigurinhaView(Figurinha figurinha)
        {
            InitializeComponent();

            lblId.Text = figurinha.Id.ToString();
            lblNome.Text = figurinha.NomeJogador;
            lblSelecao.Text = figurinha.Selecao;
            lblTipo.Text = figurinha.Tipo;

            lblObtido.Text = figurinha.Obtido ? "Sim" : "Não";
            lblDesejado.Text = figurinha.Desejado ? "Sim" : "Não";

            imgCadastro.Source = string.IsNullOrEmpty(figurinha.DirImagem) ? "placeholder.png" : figurinha.DirImagem;
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}