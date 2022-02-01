using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.DbSqlContexts
{
    public class Conection
    {
        private readonly SqlConnection _sqlConexao;
        private SqlTransaction _sqlTransação;
        private SqlCommand _sqlComando;

        public int RegistrosAfetados { get; private set; }

        public Conection(string connectionString)
        {
            _sqlConexao = new SqlConnection(connectionString);
        }

        public List<TEntity> Query<TEntity>(string sql)
        {
            if (EmTransacao)
            {
                return _sqlConexao.Query<TEntity>(sql, "", _sqlTransação).ToList();
            }
            else
            {
                return _sqlConexao.Query<TEntity>(sql).ToList();
            }
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            if (EmTransacao)
                _sqlConexao.Insert(entity, _sqlTransação);
            else
                _sqlConexao.Insert(entity);

        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (EmTransacao)
                _sqlConexao.Update(entity, _sqlTransação);
            else
                _sqlConexao.Update(entity);
        }

        public void Abrir()
        {
            try
            {
                if (_sqlConexao.State != ConnectionState.Closed) return;
                _sqlConexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível estabelecer conexão.\n" + ex.Message);
            }
        }
        public void Fechar()
        {
            EmTransacao = false;
            _sqlConexao.Close();
        }
        public bool Conectado
        {
            get
            {
                return _sqlConexao.State != ConnectionState.Closed
                    && _sqlConexao.State != ConnectionState.Broken
                      && _sqlConexao.State != ConnectionState.Connecting;
            }
        }

        public bool EmTransacao;


        public void BeginTransacao()
        {
            Abrir();

            _sqlTransação = _sqlConexao.BeginTransaction();

            EmTransacao = true;
        }

        public void CommitTransacao()
        {
            try
            {
                _sqlTransação.Commit();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                EmTransacao = false;
            }
        }

        public void RollbackTransacao()
        {
            try
            {
                if (_sqlConexao.State == ConnectionState.Open && EmTransacao)
                {
                    _sqlTransação.Rollback();
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                EmTransacao = false;
            }
        }
        //CONTROLE DE COMANDOS E CONSULTAS

        public int Executar(string comando)
        {
            Abrir();

            _sqlComando = EmTransacao ?
                new SqlCommand(comando, _sqlConexao, _sqlTransação) :
                new SqlCommand(comando, _sqlConexao);
            var alterados = _sqlComando.ExecuteNonQuery();
            return alterados;
        }

        public DataTable Consultar(string comando)
        {
            if (_sqlConexao.State == ConnectionState.Open)
            {
                Fechar();
            }
            Abrir();
            SqlCommand _sqlComando = new SqlCommand(comando, _sqlConexao);
            DataTable dataTable = new DataTable();
            var reader = _sqlComando.ExecuteReader();
            dataTable.Load(reader);
            return dataTable;
        }


        public void SetTimeOutComando(int valor)
        {
            _sqlComando.CommandTimeout = valor;
        }
    }
}
