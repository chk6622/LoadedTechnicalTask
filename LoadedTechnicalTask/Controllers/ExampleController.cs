using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadedTechnicalTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoadedTechnicalTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly TimeclockContext _context;
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger, TimeclockContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<StaffMember> Get()
        {
            return _context.Set<StaffMember>().Include(e => e.Timesheets).OrderBy(e => e.Name);
        }
    }
}
