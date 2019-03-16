using GoalsApplicationMark1.Models;
using GoalsApplicationMark1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Controllers
{
    interface IGoalsController 
    {

        IActionResult Index();

        IActionResult Create();
        
        IActionResult Create(GoalEntity goals);

        IActionResult Edit(int? id);

        IActionResult Edit(GoalEntity obj);

        IActionResult Delete(int? id);
        
    }
}
