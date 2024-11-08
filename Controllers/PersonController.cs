using Microsoft.AspNetCore.Mvc;
using MiniLibrary.Database.Service;
using MiniLibrary.Models;
using System.Collections.Generic;

namespace MiniLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {

        private readonly IPersonService personService;

        public PersonController(IPersonService per)
        {
            personService = per;
        }

        [HttpPost]
        public JsonResult Add(Person p)
        {
            return Json(new
            {
                Result = this.personService.Add(p)
            });

        }

    }
}
