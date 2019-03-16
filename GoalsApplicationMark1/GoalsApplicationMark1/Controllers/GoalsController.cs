using GoalsApplicationMark1.Models;
using GoalsApplicationMark1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Controllers
{
    public class GoalsController : Controller, IGoalsController
    {
        private readonly IRepository<GoalEntity> _iGoalRepository;

        public GoalsController(IConfiguration configuration)
        {
            _iGoalRepository = new GoalRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(_iGoalRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Goal/Create
        [HttpPost]
        public IActionResult Create(GoalEntity goals)
        {
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();

            var findErrors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {               
                _iGoalRepository.Add(goals);
                return RedirectToAction("Index");
            }
            return View(goals);
        }

        // GET: /Goal/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GoalEntity obj = _iGoalRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: /Goal/Edit
        [HttpPost]
        public IActionResult Edit(GoalEntity obj)
        {
            if (ModelState.IsValid)
            {
                _iGoalRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Get:/Goal/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _iGoalRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
