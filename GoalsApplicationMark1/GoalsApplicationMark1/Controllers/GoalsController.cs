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
    public class GoalsController : Controller
    {
        private readonly GoalRepository goalRepository;

        public GoalsController(IConfiguration configuration)
        {
            goalRepository = new GoalRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(goalRepository.FindAll());
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
                goalRepository.Add(goals);
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
            GoalEntity obj = goalRepository.FindByID(id.Value);
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
                goalRepository.Update(obj);
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
            goalRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
