using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using VeritabaniKatmani.Interface;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace VeritabaniKatmani.Repository
{
    public abstract class AbstractDapperRepository : IDisposable
    {
        public readonly IDbConnection DbConnection;
        protected AbstractDapperRepository()
        {

            DbConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
        }
        public AbstractDapperRepository(string connectionName)
        {
            DbConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }
        public AbstractDapperRepository(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        #region Crud Operation

        public TEntity Insert<TEntity>(String sqlQuery, TEntity item) where TEntity : IDbModel
        {

            var result = DbConnection.ExecuteScalar(sqlQuery, item);
            item.SetId(result);

            /*

            try
            {
                var result = DbConnection.ExecuteScalar(sqlQuery, item);
                item.SetId(result);

            }
            catch (Exception ex)
            {
                

            }  */
            return item;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(String sqlQuery) where TEntity : IDbModel
        {
            return DbConnection.Query<TEntity>(sqlQuery).ToList();
            /*
            try
            {
                return DbConnection.Query<TEntity>(sqlQuery).ToList();


            }
            catch (Exception ex)
            {
                return null;
            }  */

        }

        public IEnumerable<TEntity> GetById<TEntity>(String sqlQuery, object parameters) where TEntity : IDbModel
        {
            return DbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            /*
            try
            {
                return DbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }  */
        }

        public IEnumerable<TEntity> GetSearch<TEntity>(String sqlQuery, object parameters) where TEntity : IDbModel
        {
            return DbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            /*
            try
            {
                return DbConnection.Query<TEntity>(sqlQuery, parameters).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
            */
        }

        public TEntity Update<TEntity>(string sqlQuery, TEntity item) where TEntity : IDbModel
        {
            DbConnection.Execute(sqlQuery, item);

            /*
            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception ex)
            {

            }  */
            return item;

        }
        public void Delete<TEntity>(string sqlQuery, TEntity item) where TEntity : IDbModel
        {
            DbConnection.Execute(sqlQuery, item);
            /*
            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception ex)
            {

            }
            */

        }

        public void Onay<TEntity>(string sqlQuery, TEntity item) where TEntity : IDbModel
        {

            DbConnection.Execute(sqlQuery, item);
            /*
            try
            {
                DbConnection.Execute(sqlQuery, item);
            }
            catch (Exception ex)
            {

            } */


        }






        #endregion

        #region execute

        public void ExecuteNonQuery(String sqlQuery, object parameter)
        {
            DbConnection.Execute(sqlQuery, parameter);
            /*
            try
            {
                DbConnection.Execute(sqlQuery, parameter);
            }
            catch (Exception ex)
            {

            }  */
        }
        public void ExecuteNonQuery(String sqlQuery)
        {
            DbConnection.Execute(sqlQuery);
            /*
            try
            {
                DbConnection.Execute(sqlQuery);
            }
            catch (Exception ex)
            {

            }  */
        }
        public int Execute(string sqlQuery, object parameter)
        {
            return DbConnection.ExecuteScalar<int>(sqlQuery, parameter);
            /*
            try
            {
                return DbConnection.ExecuteScalar<int>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                return -1;
            }  */
        }

        public object Execute<T>(string sqlQuery, object parameter)
        {

            return DbConnection.ExecuteScalar<T>(sqlQuery, parameter);
            /*
            try
            {
                return DbConnection.ExecuteScalar<T>(sqlQuery, parameter);
            }
            catch (Exception ex)
            {
                return null;
            } */
        }
        #endregion


        public virtual void Dispose(bool Disposing)
        {
            if (Disposing)
                DbConnection.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
