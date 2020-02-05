using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RawCMS.Library.Core.Attributes;
using RawCMS.Plugins.Core.Model;
using RawCMS.Plugins.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawCMS.Plugins.Core.Controllers
{
    [AllowAnonymous]
    [RawAuthentication]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly StatsService service;
        public StatsController(StatsService service)
        {
            this.service = service;
        }

        [HttpGet("api-call")]
        public RestMessage<ApiCallStats> Get()
        {
            return new RestMessage<ApiCallStats>(this.service.GetCount());
        }
    }
}
