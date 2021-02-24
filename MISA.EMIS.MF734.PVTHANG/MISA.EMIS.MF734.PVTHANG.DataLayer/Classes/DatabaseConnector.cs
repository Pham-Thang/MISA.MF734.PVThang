using Dapper;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.DataLayer.Classes
{
    public class DatabaseConnector : IDatabaseConnector
    {
        #region Declare
        /// <summary>
        /// Chuỗi chứa thông tin kết nối tới database
        /// </summary>
        /// Created by Phạm Việt Thắng (22/02/2021)
        protected String _connectionString;
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DatabaseConnector()
        {
            _connectionString = Common.Properties.Resources.ConnectionString;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>danh sách kiểu dữ liệu TEntity</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public virtual IEnumerable<TEntity> GetList<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Query<TEntity>(sqlCommand, input, commandType: type).ToList();
        }

        /// <summary>
        /// Lấy một đối tượng dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>TEntity</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public virtual TEntity GetFirst<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Query<TEntity>(sqlCommand, input, commandType: type).FirstOrDefault();
        }

        /// <summary>
        /// Thêm, sửa, xóa dữ liệu
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public virtual int Change(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Execute(sqlCommand, input, commandType: type);
        }
        #endregion
    }
}
