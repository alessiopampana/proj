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
    public class IngrediantsController : ControllerBase
    {
        private readonly ILogger<IngrediantsController> _logger;
        private readonly eDbContext dbcontext;

        public IngrediantsController(ILogger<IngrediantsController> logger, eDbContext _db)
        {
            _logger = logger;
            dbcontext = _db;
        }

        [Route("/api/Ingrediants/{SweetID}")]
        [HttpGet]
        public List<cIngrediant> Get(int SweetID)
        {
            List<cIngrediant> obj = dbcontext.Ingrediants.Where(q => q.SweetID == SweetID).ToList();
            if (obj == null)
                return new List<cIngrediant>();
            return obj;
        }

        [Route("/api/Ingredient/Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] cIngrediant Obj)
        {
            if (Obj == null)
                return new BadRequestResult();
            if (dbcontext.Ingrediants.Where(q => q.SweetID == Obj.SweetID && q.Name == Obj.Name).Any())
            {
                dbcontext.Update(Obj);
            }
            else
            {
                dbcontext.Add(Obj);
            }
            try
            {
                int ret = await dbcontext.SaveChangesAsync();
                if (ret == 1)
                    return new OkResult();
            }
            catch (Exception ex)
            {
            
            }
            return new BadRequestResult();
        }

        [Route("/api/Ingredient/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int SweetID)
        {
            cIngrediant obj = dbcontext.Ingrediants.Where(q => q.SweetID == SweetID).FirstOrDefault();
            if (obj != null)
            {
                dbcontext.Remove(obj);
                int ret = await dbcontext.SaveChangesAsync();
            }
            return new OkResult();
        }
    }
}
