using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Server.Data;
using Microsoft.AspNetCore.Cors;
using Blazor.Shared.Data;

namespace Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly eDbContext dbcontext;

        public UsersController(ILogger<UsersController> logger, eDbContext _db)
        {
            _logger = logger;
            dbcontext = _db;
        }

        [Route("/api/Users")]
        [HttpGet]
        public List<cUser> Get()
        {
            return dbcontext.Users.ToList();
        }

        [Route("/api/User/{Username}/{Password}")]
        [HttpGet]
        public cUser Get(string Username, string Password)
        {
            cUser obj = dbcontext.Users.Where(q => q.Username == Username && q.Password == Password).FirstOrDefault();
            if (obj == null)
                return new cUser();
            return obj;
        }

        [Route("/api/User/{ID}")]
        [HttpGet]
        public cUser Get(long ID)
        {
            try
            {
                var usr = dbcontext.Users.Where(q => q.ID == ID);
                if (usr == null || !usr.Any())
                    return new cUser();
                return usr.FirstOrDefault();
            }
            catch (Exception ex)
            { }
            return null;
        }
    }
}
