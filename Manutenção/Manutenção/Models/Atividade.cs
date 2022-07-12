using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manutenção.Models
{
    public class Atividade
    {
        [PrimaryKey, AutoIncrement ]

        public int Id { get; set; }

        public DateTime Data1 { get; set; }

        public DateTime DataFim { get; set; }

        public TimeSpan Timing { get; set; }

        public TimeSpan Inicio { get; set; }

        public TimeSpan Fim { get; set; }

        public string TipoServ { get; set; }

        public string SetorX { get; set; }

        public Double? Patrimonio { get; set; }
        
        public string Maquina { get; set; }

        public string Equipamento { get; set; }

        public string Descricao { get; set; }

        public string Responsavel { get; set; }

        public string Realizado { get; set; }

        public string Executante { get; set; }

        public string Executante1 { get; set; }

        public string Executante2 { get; set; }

    }
}
