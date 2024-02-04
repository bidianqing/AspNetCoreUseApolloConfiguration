using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreUseApolloConfiguration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string Get()
        {
            _logger.LogInformation("日志测试");
            return _configuration["db_server"];
        }
    }
}
