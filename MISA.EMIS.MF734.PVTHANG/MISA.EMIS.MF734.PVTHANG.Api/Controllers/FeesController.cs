using Microsoft.AspNetCore.Mvc;
using MISA.EMIS.MF734.PVTHANG.Common.Models;
using MISA.EMIS.MF734.PVTHANG.Service.Classes;
using MISA.EMIS.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.EMIS.MF734.PVTHANG.Api.Controllers
{
    public class FeesController : BaseEntityController<Fee>
    {
        public FeesController(IFeeService feeService) : base (feeService)
        {

        }
    }
}
