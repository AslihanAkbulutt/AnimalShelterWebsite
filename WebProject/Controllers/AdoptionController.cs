﻿using WebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebProject.Controllers
{
    public class AdoptionController : Controller
    {
        public static int Id = 0;
       
        private readonly ApplicationDbContext _context;
        

        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
          
        }
        public IActionResult Index()
        {
           var list = _context.Animals.ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return View(list);
        }
        [Authorize]
        [HttpGet]
        public IActionResult AdoptForm(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Id = id;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdoptForm(Application a)
        {
           
            if (ModelState.IsValid)
            {
                Adopted adopted = new Adopted();
                a.AnimalId = Id;
                _context.Applications.Add(a);
                var animal = await _context.Animals.FindAsync(Id);
                adopted.OldId = animal.Id;
                adopted.Breed = animal.Breed;
                adopted.Info = "adopted";
                adopted.Age = animal.Age;
                _context.Adoptees.Add(adopted);
                _context.Animals.Remove(animal);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }
    }
}
