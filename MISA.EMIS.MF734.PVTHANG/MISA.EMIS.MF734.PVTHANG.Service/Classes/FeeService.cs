using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Classes
{
    public class FeeService : BaseService<Fee>, IFeeService
    {
        #region Constructor
        public FeeService(IFeeConnector feeConnector) : base(feeConnector)
        {

        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy tất cả Fee
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public override ServiceResult GetAll()
        {
            var sqlCommand = "Proc_GetAllFees";
            _serviceResult.Data = _dbConnector.GetList<Fee>(sqlCommand, new { }, System.Data.CommandType.StoredProcedure);
            return _serviceResult;
        }

        /// <summary>
        /// Lấy Fee theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public override ServiceResult GetById(int id)
        {
            var sqlCommand = "Proc_GetFeeById";
            _serviceResult.Data = _dbConnector.GetFirst<Fee>(sqlCommand, new { id = id }, System.Data.CommandType.StoredProcedure);
            return _serviceResult;
        }
        #endregion
    }
}
