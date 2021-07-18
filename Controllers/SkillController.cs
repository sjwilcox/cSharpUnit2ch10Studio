using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsTracker.Controllers
{
    [Route("/skills/")]
    public class SkillController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string skillTitle = "<h1>Skills Tracker </h1>\n" + "<h2>Coding Skills </h2>\n" + "<ol><li>C#</li><li>C++</li><li>Python</li>";
            return Content(skillTitle, "text/html");
        }
        private string GenerateSkillLevel(int idNum)
        {
            string skillLevel = $"<select name='skilllevel{idNum}' id='skillLevel' style='margin-bottom:5px'>" + "<option vaule='novice'>Learning Basics</option>" + "<option vaule='intermediate'>Making Apps</option>" + "<option vaule='master'>Master Coder</option>" + "</select>";
            return skillLevel;
        }
        [HttpGet]
        [Route("form")]
        public IActionResult SkillForm()
        {
            
            string displayStyle = "style ='display:block;padding-bottom: 5px;'";
            string formList = "<form method='post' action='/skills/form/result'>" + $"<label for='skilldate' {displayStyle}>Date:</label>" + "<input type='date' name='skilldate'/>" + $"<label for='csharp' {displayStyle}>C#:</label>"+ GenerateSkillLevel(0) + $"<label for='cplus'{displayStyle}>C++:</label>"+ GenerateSkillLevel(1) + $"<label for='python'{displayStyle}>Python:</label>" + GenerateSkillLevel(2) + $"<input {displayStyle} type= 'submit' value= 'Submit' />" + "</form>";
            return Content(formList, "text/html");
        }

        [HttpPost]
        [Route("form/result")]
        public IActionResult SkillForm(string skilldate, string skilllevel0, string skilllevel1, string skilllevel2)
        {
            
            return Content($"<h1>{skilldate}</h1>" + $"<table style='width:25%'><tr><th>Coding Language</th><th>Skill Level</th></tr><tr><td>C#</td><td>{skilllevel0}</td></tr><tr><td>C++</td><td>{skilllevel1}</td></tr><tr><td>Python</td><td>{skilllevel2}</td></tr></table>","text/html");
        }

        
    }
}
