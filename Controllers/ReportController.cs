using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using Service_Interfaces;

namespace ReportProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUserInfo _userInfo;
        public ReportController(IUserInfo userInfo)
        {
            _userInfo = userInfo;
        }
        public async Task<ActionResult>GenerateUserDetailPDf()
        {
            var result =  await  _userInfo.GenerateReport();
            return File(
                 result,
                 "application/pdf",
                 "UserDetail.pdf"
                );
            //return File(

            //    null,
            //    "application/pdf",
            //    "UserDetail.pdf"

            //     );
        }
    }
}
