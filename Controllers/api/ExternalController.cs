using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cardslanding.Models;
using cardslanding.Data;
using cardslanding.Data.Repositories;
using Microsoft.Extensions.Options;
using cardslanding.Infrustructure;
using Microsoft.AspNetCore.Authorization;

namespace cardslanding.Controllers.api
{
    public class ExternalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<AppSettings> _config;

        public ExternalController(ApplicationDbContext context,
                              IOptions<AppSettings> config)
        {
            _context = context;
            _config = config;
        }


        [HttpGet]
        [ApiAllowCrossSiteJson]
        [Route("Api/External/GetUserDetails")]
        public IActionResult GetUseDetails()
        {
            if(User.Identity.IsAuthenticated)
            {
                return Json(new {
                            success = true
                        });
            }   
            
            return Json(new {
                        success = false
                    });
            
        }

    }
}
