using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bursa.Models;
using Bursa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bursa.Controllers
{
    [Route("")]
    [Route("Paper")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private ApplicationContext db;
        private readonly PaperService paperService;
        public PaperController(ApplicationContext context, PaperService paperService)
        {
            db = context;
            this.paperService = paperService;
        }

        [HttpGet]
         public IActionResult GetPapers(int page, int rows, DateTime from, DateTime to)
        {
            string res = "Welcome to the club";
            if (!(page == 0 || rows == 0 || from == DateTime.MinValue || to == DateTime.MinValue) )
                res = paperService.GetPapers(page, rows, from, to);
            return Ok(res); 
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult GetPaperById(int id)
        {
            string res = paperService.GetPaperById(id);
            return Ok(res);
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult SearchPapersByName(string name)
        {
            string res = paperService.SearchPapersByName(name);
            return Ok(res);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult GetPapersByNameAll()
        {
            string res = paperService.GetPapersByNameAll();
            return Ok(res);
        }
    }
}
