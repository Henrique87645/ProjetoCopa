using System;
using Microsoft.Maui.Controls;
using ProjetoAlbumCopa.Models;
using ProjetoAlbumCopa.Services;
using ProjetoAlbumCopa.Controllers;

namespace ProjetoAlbumCopa.Views
{
    public partial class pgCadFigurinhaView : ContentPage
    {
        FigurinhaController _Controller;
        string _imgSelecionada = "";

        public pgCadFigurinhaView()
        {
            InitializeComponent();
            _Controller = new FigurinhaController();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void btnAdcionarImagem_Clicked(object sender, EventArgs e)
        {
            _imgSelecionada = await ImageService.SelecionarImagem();

            if (!string.IsNullOrEmpty(_imgSelecionada))
            {
                imgCadastro.Source = _imgSelecionada;
                btnRemoverImagem.IsVisible = true;
            }
        }

        void RemoverImagem()
        {
            imgCadastro.Source = "";
            _imgSelecionada = "";
            btnRemoverImagem.IsVisible = false;
        }

        private void btnRemoverImagem_Clicked(object sender, EventArgs e)
        {
            RemoverImagem();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string selecao = txtSelecao.Text;
            string tipo = pckTipo.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(selecao) ||
                string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(_imgSelecionada))
            {
                DisplayAlert("Atenção", "Preencha todos os campos e selecione uma imagem.", "OK");
                return;
            }

            Figurinha figurinha = new Figurinha
            {
                NomeJogador = nome,
                Selecao = selecao,
                Tipo = tipo,
                Obtido = swtObtido.IsToggled,
                Desejado = swtDesejado.IsToggled,
                DirImagem = ImageService.CopiarImagem(_imgSelecionada)
            };

            if (_Controller.Insert(figurinha))
            {
                DisplayAlert("Sucesso", "Figurinha salva no álbum!", "OK");

                txtNome.Text = "";
                txtSelecao.Text = "";
                pckTipo.SelectedItem = null;
                swtObtido.IsToggled = false;
                swtDesejado.IsToggled = false;
                RemoverImagem();
            }
            else
            {
                DisplayAlert("Erro", "Ocorreu uma falha ao salvar.", "OK");
            }
        }
    }
}