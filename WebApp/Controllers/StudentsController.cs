using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using ApplicationLayer.SearchQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IAddStudentCommand _addCommandStd;
        private readonly IGetStudentsCommand _getCommandStds;
        private readonly IGetStudentCommand _getCommandStd;
        private readonly IEditStudentCommand _editCommandStd;

        public StudentsController(IAddStudentCommand addCommandStd, IGetStudentsCommand getCommandStds, IGetStudentCommand getCommandStd, IEditStudentCommand editCommandStd)
        {
            _addCommandStd = addCommandStd;
            _getCommandStds = getCommandStds;
            _getCommandStd = getCommandStd;
            _editCommandStd = editCommandStd;
        }

        // GET: Students
        public ActionResult Index(StudentSearchQuery searchQuery)
        {
            
            var getStds = _getCommandStds.Execute(searchQuery);
            return View(getStds);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var getStd = _getCommandStd.Execute(id);
                return View(getStd);
            }
            catch(Exception)
            {
                return View();
            }
            
            
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add insert logic here
                _addCommandStd.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                TempData["error"] = "error.";
            }

            return View();
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
               
                var editStd = _getCommandStd.Execute(id);
                return View(editStd);
            }
            catch(Exception)
            {
                return RedirectToAction("index");
            }
            
            
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                _editCommandStd.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}