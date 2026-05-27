using System.Collections.Generic;
using System.Linq;
using SQLite;
using ProjetoAlbumCopa.Models;
using ProjetoAlbumCopa.Services;

namespace ProjetoAlbumCopa.Controllers
{
    public class FigurinhaController
    {
        DatabaseServices _database;
        SQLiteConnection _connection;

        public FigurinhaController()
        {
            _database = new DatabaseServices();
            _connection = _database.GetConnection();
            _connection.CreateTable<Figurinha>();

            // Força a carga inicial se o banco estiver vazio
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Verificação de segurança: Só adiciona se a tabela estiver realmente vazia
            if (_connection.Table<Figurinha>().Count() == 0)
            {
                _connection.Insert(new Figurinha
                {
                    NomeJogador = "Vinícius Jr.",
                    Selecao = "Brasil",
                    Tipo = "Especial",
                    Obtido = true,
                    Desejado = false,
                    DirImagem = "player_vinijr.jpg" 
                });

                _connection.Insert(new Figurinha
                {
                    NomeJogador = "Kylian Mbappé",
                    Selecao = "França",
                    Tipo = "Especial",
                    Obtido = false,
                    Desejado = true,
                    DirImagem = "player_mbappe.jpg" 
                });

                _connection.Insert(new Figurinha
                {
                    NomeJogador = "Jude Bellingham",
                    Selecao = "Inglaterra",
                    Tipo = "Comum",
                    Obtido = true,
                    Desejado = true,
                    DirImagem = "player_bellingham.jpg" 
                });

                _connection.Insert(new Figurinha
                {
                    NomeJogador = "Lamine Yamal",
                    Selecao = "Espanha",
                    Tipo = "Especial",
                    Obtido = false,
                    Desejado = false,
                    DirImagem = "player_yamal.jpg" 
                });
            }
        }

        // --- Restante dos métodos permanece igual ---
        public bool Insert(Figurinha value)
        {
            return _connection.Insert(value) > 0;
        }

        public bool Update(Figurinha value)
        {
            return _connection.Update(value) > 0;
        }

        public bool Delete(Figurinha value)
        {
            return _connection.Delete(value) > 0;
        }

        public Figurinha GetById(int id)
        {
            return _connection.Find<Figurinha>(id);
        }

        public List<Figurinha> GetAll()
        {
            return _connection.Table<Figurinha>().ToList();
        }

        public List<Figurinha> GetFiltroCombinado(string nomeBusca, bool apenasAdquiridas, bool apenasDesejadas)
        {
            var lista = _connection.Table<Figurinha>().ToList();

            if (!string.IsNullOrWhiteSpace(nomeBusca))
                lista = lista.Where(x => x.NomeJogador.ToLower().Contains(nomeBusca.ToLower())).ToList();

            if (apenasAdquiridas)
                lista = lista.Where(x => x.Obtido == true).ToList();

            if (apenasDesejadas)
                lista = lista.Where(x => x.Desejado == true).ToList();

            return lista;
        }
    }
}