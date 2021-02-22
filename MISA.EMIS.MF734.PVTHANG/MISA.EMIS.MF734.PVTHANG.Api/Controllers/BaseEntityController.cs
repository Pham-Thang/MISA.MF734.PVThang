using Microsoft.AspNetCore.Mvc;
using MISA.EMIS.MF734.PVTHANG.Service.Classes;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.EMIS.MF734.PVTHANG.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseService.GetAll();
            if (result.Success == true)
                return StatusCode(200, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _baseService.GetById(id);
            if (result.Success == true)
                return StatusCode(200, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _baseService.Insert(entity);
            if (result.Success == true)
                return StatusCode(201, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity)
        {
            var result = _baseService.Update(entity);
            if (result.Success == true)
                return StatusCode(200, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseService.Delete(id);
            if (result.Success == true)
                return StatusCode(200, result.Data);
            else
                return StatusCode((int)result.Code, result.ErrorMessage);
        }
    }
}
