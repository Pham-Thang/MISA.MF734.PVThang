using MISA.EMIS.MF734.PVTHANG.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.EMIS.MF734.PVTHANG.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        ServiceResult GetAll();

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        ServiceResult GetById(int id);

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        ServiceResult Insert(TEntity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">Đối tương sửa</param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        ServiceResult Update(TEntity entity);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của đối tượng sẽ bị xóa</param>
        /// <returns>ServiceResult</returns>
        /// Created by Phạm Việt Thắng (22/02/2021)
        ServiceResult Delete(int id);
    }
}
