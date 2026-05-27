using System;
using SQLite;
using PCLExt.FileStorage.Folders;

namespace ProjetoAlbumCopa.Services
{
    public class DatabaseServices
    {
        public SQLiteConnection GetConnection()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("projetoCopa", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            return new SQLiteConnection(arquivo.Path);
        }
    }
}