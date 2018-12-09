using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalsApplicationMark1.Models;
using GoalsApplicationMark1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GoalsApplicationMark1.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskRepository taskRepository;

        public TaskController(IConfiguration configuration)
        {
            taskRepository = new TaskRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(taskRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Goal/Create
        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            if (ModelState.IsValid)
            {
                taskRepository.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: /Task/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tasks obj = taskRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: /Task/Edit
        [HttpPost]
        public IActionResult Edit(Tasks obj)
        {
            if (ModelState.IsValid)
            {
                taskRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Get /Task/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            taskRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
