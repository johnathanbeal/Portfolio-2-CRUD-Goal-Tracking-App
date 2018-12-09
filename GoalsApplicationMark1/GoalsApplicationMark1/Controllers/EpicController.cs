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
    public class EpicsController : Controller
    {
        private readonly EpicRepository epicRepository;

        public EpicsController(IConfiguration configuration)
        {
            epicRepository = new EpicRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(epicRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Epic/Create
        [HttpPost]

        public IActionResult Create(Epics epics)
        {
            if (ModelState.IsValid)
            {
                epicRepository.Add(epics);
                return RedirectToAction("Index");
            }
            return View(epics);
        }

        // GET: /Epic/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Epics obj = epicRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: /Goal/Edit
        [HttpPost]
        public IActionResult Edit(Epics obj)
        {
            if(ModelState.IsValid)
            {
                epicRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //  Get:/Goal/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            epicRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
