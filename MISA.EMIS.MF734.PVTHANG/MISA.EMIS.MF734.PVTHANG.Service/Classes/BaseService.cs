using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Classes;
using MISA.EMIS.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Classes
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        String _className;
        protected ServiceResult _serviceResult;
        protected IDatabaseConnector _dbConnector;
        public BaseService(IDatabaseConnector dbConnector)
        {
            _className = typeof(TEntity).Name;
            _serviceResult = new ServiceResult();
            _dbConnector = dbConnector;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// Created by Phạm Việt Thắng
        public virtual ServiceResult GetAll()
        {
            var sqlCommand = $"SELECT * FROM {_className}";
            _serviceResult.Data = _dbConnector.GetList<TEntity>(sqlCommand, new { }, System.Data.CommandType.Text);
            return _serviceResult;
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Created by Phạm Việt Thắng
        public virtual ServiceResult GetById(int id)
        {
            var sqlCommand = $"SELECT * FROM {_className} WHERE {_className}Id = '{id}'";
            _serviceResult.Data = _dbConnector.GetFirst<TEntity>(sqlCommand, new { }, System.Data.CommandType.Text);
            return _serviceResult;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Đối tượng được thêm</returns>
        /// Created by Phạm Việt Thắng
        public virtual ServiceResult Insert(TEntity entity)
        {
            ValidateData(entity);
            if (_serviceResult.Success)
            {
                var effectRow = _dbConnector.Change($"Proc_Insert{_className}", entity, System.Data.CommandType.StoredProcedure);
                if (effectRow == 1)
                {
                    _serviceResult.Data = 1;
                    _serviceResult.Code = Common.Enum.ResultCode.Created;
                } else
                {
                    _serviceResult.Success = false;
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    if (_serviceResult.ErrorMessage.UserMessage == String.Empty)
                        _serviceResult.ErrorMessage.UserMessage += Common.Properties.Resources.Error;
                }
            }
            return _serviceResult;
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">Đối tương sửa</param>
        /// <returns></returns>
        public virtual ServiceResult Update(TEntity entity)
        {
            ValidateData(entity); 
            if (_serviceResult.Success)
            {
                var effectRow = _dbConnector.Change($"Proc_Update{_className}", entity, System.Data.CommandType.StoredProcedure);
                if (effectRow == 1)
                {
                    _serviceResult.Data = 1;
                    _serviceResult.Code = Common.Enum.ResultCode.Ok;
                }
                else
                {
                    _serviceResult.Success = false;
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    if (_serviceResult.ErrorMessage.UserMessage == String.Empty)
                        _serviceResult.ErrorMessage.UserMessage += Common.Properties.Resources.Error;
                }
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của đối tượng sẽ bị xóa</param>
        /// <returns></returns>
        /// Created by Phạm Việt Thắng
        public virtual ServiceResult Delete(int id)
        {
            var properties = typeof(TEntity).GetProperties();
            var sqlCommand = $"SELECT isSystem FROM {_className} WHERE {_className}Id = '{id}';";
            if (_dbConnector.GetFirst<bool>(sqlCommand, new { }, System.Data.CommandType.Text))
            {
                _serviceResult.Success = false;
                _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                _serviceResult.ErrorMessage.UserMessage = Common.Properties.Resources.ErrorDeleteSystem;
            } else
            {
                sqlCommand = $"DELETE FROM {_className} WHERE {_className}Id = '{id}'";
                var effectRow = _dbConnector.Change(sqlCommand, new { }, System.Data.CommandType.Text);
                if (effectRow == 1)
                {
                    _serviceResult.Success = true;
                    _serviceResult.Data = 1;
                    _serviceResult.Code = Common.Enum.ResultCode.Ok;
                }
                else
                {
                    _serviceResult.Success = false;
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    if (_serviceResult.ErrorMessage.UserMessage == String.Empty)
                        _serviceResult.ErrorMessage.UserMessage += Common.Properties.Resources.Error;
                }
            }
            return _serviceResult;
        }

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// Created by Phạm Việt Thắng
        protected virtual void ValidateData(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                //check Requied
                if (property.IsDefined(typeof(Required), true) && (value == null || value.ToString().Trim() == String.Empty))
                {
                    var propertyName = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (propertyName != null)
                    {
                        var message = (propertyName as Required).propertyName + " " + Common.Properties.Resources.ErrorRequired + ". ";
                        if ((propertyName as Required).errorMessage != null) message = (propertyName as Required).errorMessage;
                        _serviceResult.ErrorMessage.UserMessage = _serviceResult.ErrorMessage.UserMessage == null ? message : (_serviceResult.ErrorMessage.UserMessage + message);
                    }
                    _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                    _serviceResult.Success = false;
                }
                //check duplicate
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                    var id = properties.FirstOrDefault().GetValue(entity);
                    var sqlCommand = $"SELECT COUNT(*) FROM {_className} WHERE {_className}Id != '{id}' AND {property.Name}='{value}';";
                    if (_dbConnector.GetFirst<int>(sqlCommand, new { }, System.Data.CommandType.Text) > 0)
                    {
                        var propertyName = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                        if (propertyName != null)
                        {
                            var message = (propertyName as CheckDuplicate).propertyName + " " + Common.Properties.Resources.ErrorDuplicate + ". ";
                            if ((propertyName as CheckDuplicate).errorMessage != null) message = (propertyName as CheckDuplicate).errorMessage;
                            _serviceResult.ErrorMessage.UserMessage = _serviceResult.ErrorMessage.UserMessage == null ? message : (_serviceResult.ErrorMessage.UserMessage + message);
                        }
                        _serviceResult.Code = Common.Enum.ResultCode.BadRequest;
                        _serviceResult.Success = false;
                    }
                }
                //check length

            }
        }
    }
}
