﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "{\"status\": \"OK\"}";
        }
    }
}
