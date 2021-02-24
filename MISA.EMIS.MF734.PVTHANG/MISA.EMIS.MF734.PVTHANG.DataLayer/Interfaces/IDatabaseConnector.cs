using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces
{
    public interface IDatabaseConnector
    {
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>danh sách kiểu dữ liệu TEntity</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        IEnumerable<TEntity> GetList<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);

        /// <summary>
        /// Lấy một đối tượng dữ liệu
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>TEntity</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        TEntity GetFirst<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);

        /// <summary>
        /// Thêm, sửa, xóa dữ liệu
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns>Số dòng thay đổi</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        int Change(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);
    }
}
