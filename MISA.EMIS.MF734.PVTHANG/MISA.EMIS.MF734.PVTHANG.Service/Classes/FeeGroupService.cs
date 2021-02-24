using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Classes
{
    public class FeeGroupService : BaseService<FeeGroup>, IFeeGroupService
    {

        #region Constructor
        public FeeGroupService(IFeeGroupConnector feeGroupConnector) : base(feeGroupConnector)
        {

        }
        #endregion

        #region Method
        /// <summary>
        /// Thêm FeeGroup (Chưa được phát triển)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public override ServiceResult Insert(FeeGroup entity)
        {
            _serviceResult.Success = false;
            _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            _serviceResult.ErrorMessage.UserMessage = Common.Properties.Resources.UnDeveloped;
            return _serviceResult;
        }

        /// <summary>
        /// Sửa FeeGroup (Chưa được phát triển)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public override ServiceResult Update(FeeGroup entity)
        {
            _serviceResult.Success = false;
            _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            _serviceResult.ErrorMessage.UserMessage = Common.Properties.Resources.UnDeveloped;
            return _serviceResult;
        }

        /// <summary>
        /// Xóa FeeGroup (Chưa được phát triển)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        public override ServiceResult Delete(int id)
        {
            _serviceResult.Success = false;
            _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
            _serviceResult.ErrorMessage.UserMessage = Common.Properties.Resources.UnDeveloped;
            return _serviceResult;
        }
        #endregion
    }
}
