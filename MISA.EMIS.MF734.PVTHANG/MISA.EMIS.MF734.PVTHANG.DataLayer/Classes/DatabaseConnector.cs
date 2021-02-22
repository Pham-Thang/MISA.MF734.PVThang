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
        protected String _connectionString;
        protected IDbConnection _dbConnection;
        public DatabaseConnector()
        {
            _connectionString = "User Id=dev;Password=12345678;Database=MISA.FeeManagement.MF734_PVTHANG;Port=3306;Host=47.241.69.179;Character Set=utf8";
            _dbConnection = new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>danh sách kiểu dữ liệu TEntity</returns>
        /// Created by Phạm Việt Thắng
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
        /// Created by Phạm Việt Thắng
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
        /// Created by Phạm Việt Thắng
        public virtual int Change(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure)
        {
            return _dbConnection.Execute(sqlCommand, input, commandType: type);
        }
    }
}
