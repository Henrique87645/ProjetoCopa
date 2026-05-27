using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Media;

namespace ProjetoAlbumCopa.Services
{
    public class ImageService
    {
        public static async Task<string> SelecionarImagem()
        {
            string diretorio = "";
            var imgSelecionada = await MediaPicker.PickPhotoAsync();

            if (imgSelecionada != null)
                diretorio = imgSelecionada.FullPath;

            return diretorio;
        }

        public static string CopiarImagem(string dirOrigem)
        {
            string dirDestino = "";

            if (!string.IsNullOrEmpty(dirOrigem))
            {
                var dirPasta = Path.Combine(AppContext.BaseDirectory, "Imagens");

                if (!Directory.Exists(dirPasta))
                    Directory.CreateDirectory(dirPasta);

                string nomeOriginal = Path.GetFileName(dirOrigem);
                dirDestino = Path.Combine(dirPasta, nomeOriginal);

                File.Copy(dirOrigem, dirDestino, overwrite: true);
            }
            return dirDestino;
        }
    }
}