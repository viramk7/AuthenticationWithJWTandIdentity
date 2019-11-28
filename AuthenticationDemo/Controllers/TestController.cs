using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {

        }

        [Authorize(Policy = "CustomPolicy")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Authentication works!!!");
        }
    }
}