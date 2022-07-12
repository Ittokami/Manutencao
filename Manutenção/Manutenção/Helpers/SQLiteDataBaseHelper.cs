using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Manutenção.Models;
using SQLite;

namespace Manutenção.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SQLiteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Atividade>().Wait();
        }
        public Task<List<Atividade>> GetAllRows()
        {
            return _db.Table<Atividade>().OrderByDescending(i => i.Id).ToListAsync();
        }

        public Task<Atividade> GetById(int id)
        {
            return _db.Table<Atividade>().FirstAsync(i => i.Id == id);
        }

        public Task<int> Insert(Atividade model)
        {
            return _db.InsertAsync(model);
        }

        public Task<List<Atividade>> Update(Atividade model)
        {
            string sql = "UPDATE Atividade SET Data1=?, Timing=?, Inicio=?, DataFim=?, Fim=?, TipoServ=?, SetorX=?, Patrimonio=?, Maquina=?, Equipamento=?, Descricao=?, Responsavel=?, Realizado=?, Executante=?";

            return _db.QueryAsync<Atividade>(
                sql,
                model.Data1,               
                model.Timing,
                model.Inicio,
                model.DataFim,
                model.Fim,
                model.TipoServ,
                model.SetorX,
                model.Patrimonio,
                model.Maquina,
                model.Equipamento,               
                model.Descricao,
                model.Responsavel,               
                model.Realizado,
                model.Executante,
                model.Id
            );
        }

        public Task<int> Delete(int id)
        {
            return _db.Table<Atividade>().DeleteAsync(i => i.Id == id);
        }


        public Task<List<Atividade>> Search(string q)
        {
            string sql = "SELECT * FROM Atividade WHERE Descricao LIKE '%" + q + "%'";

            return _db.QueryAsync<Atividade>(sql);
        }
    }
}