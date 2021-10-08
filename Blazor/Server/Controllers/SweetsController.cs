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
    public class SweetsController : ControllerBase
    {
        private readonly ILogger<SweetsController> _logger;
        private readonly eDbContext dbcontext;

        public SweetsController(ILogger<SweetsController> logger, eDbContext _db)
        {
            _logger = logger;
            dbcontext = _db;
        }

        [Route("/api/Sweets")]
        [HttpGet]
        public List<cSweet> Get()
        {
            return dbcontext.Sweets.ToList();
        }

        [Route("/api/Sweet/{id}")]
        [HttpGet]
        public cSweet Get(int id)
        {
            cSweet obj = dbcontext.Sweets.Where(q => q.ID == id).FirstOrDefault();
            if (obj == null)
                return new cSweet();
            return obj;
        }

        [Route("/api/Sweet/Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] cSweet Obj)
        {
            if (Obj == null)
                return new BadRequestResult();
            if (dbcontext.Sweets.Where(q => q.ID == Obj.ID).Any())
            {
                dbcontext.Update(Obj);
                List<cIngrediant> toremove = dbcontext.Ingrediants.Where(q => q.SweetID == Obj.ID).ToList();
                if (toremove != null && toremove.Count > 0)
                    dbcontext.RemoveRange(toremove);

            }
            else
            {
                dbcontext.Add(Obj);
            }
            try
            {
                int ret = await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
            if (Obj.Ingrediants != null && Obj.Ingrediants.Count > 0)
            {
                foreach (cIngrediant ing in Obj.Ingrediants)
                {
                    ing.SweetID = Obj.ID;                  
                }
                dbcontext.AddRange(Obj.Ingrediants);
            }
           
            try
            {
                int ret = await dbcontext.SaveChangesAsync();
                return new OkResult();

            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        [Route("/api/Sweet/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int ID)
        {
            cSweet obj = dbcontext.Sweets.Where(q => q.ID == ID).FirstOrDefault();
            if (obj != null)
            {
                List<cIngrediant> ing = dbcontext.Ingrediants.Where(q => q.SweetID == ID).ToList();
                dbcontext.Remove(obj);
                dbcontext.RemoveRange(ing);
                int ret = await dbcontext.SaveChangesAsync();

            }
            return new OkResult();
        }
    }
}
