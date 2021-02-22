using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces
{
    public interface IDatabaseConnector
    {
        IEnumerable<TEntity> GetList<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);

        TEntity GetFirst<TEntity>(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);

        int Change(String sqlCommand, Object input, CommandType type = CommandType.StoredProcedure);
    }
}
