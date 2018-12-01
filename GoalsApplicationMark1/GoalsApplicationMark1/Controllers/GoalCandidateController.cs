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
    public class GoalCandidateController : Controller
    {
        private readonly GoalCandidateRepository goalCandidateRepository;

        public GoalCandidateController(IConfiguration configuration)
        {
            goalCandidateRepository = new GoalCandidateRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(goalCandidateRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalCandidate/Create
        [HttpPost]
        public IActionResult Create(GoalCandidate goalCandidate)
        {
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();

            var findErrors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                goalCandidateRepository.Add(goalCandidate);
                return RedirectToAction("Index");
            }
            return View(goalCandidate);
        }

        //  GET: /GoalCandidate/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GoalCandidate obj = goalCandidateRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: /GoalCandidate/Edit
        [HttpPost]
        public IActionResult Edit(GoalCandidate obj)
        {
            if(ModelState.IsValid)
            {
                goalCandidateRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: /GoalCandidate/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            goalCandidateRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
