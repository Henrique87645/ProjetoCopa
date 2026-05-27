using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProjetoAlbumCopa.Models
{
    public class Figurinha
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int teste { get; set; }  
        public string NomeJogador { get; set; }
        public string Selecao { get; set; }
        public string Tipo { get; set; }
        public bool Obtido { get; set; }
        public bool Desejado { get; set; }
        public string DirImagem { get; set; }
    }
}
