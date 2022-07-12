namespace Servico
{
    using SQLite;
    using System;

    public partial class Funcionarios
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Servico { get; set; }
    }
}
