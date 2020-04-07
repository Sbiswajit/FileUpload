using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileUpload.Models;
using FileUpload.ViewModels;
using Microsoft.AspNetCore.Hosting;


namespace FileUpload.Controllers
{
    public class FilesController : Controller
    {
        private readonly FileContext _context;
        private readonly IWebHostEnvironment _env;

        public FilesController(FileContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Files
        public async Task<IActionResult> Index()
        {
            return View(await _context.yogas.ToListAsync());
        }

        // GET: Files/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.yogas
                .FirstOrDefaultAsync(m => m.Yid == id);
            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }

        // GET: Files/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewFile model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if(model.formFile!=null)
                {
                    string upload = System.IO.Path.Combine(_env.WebRootPath, "images");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + model.formFile.FileName;
                    string filepath = System.IO.Path.Combine(upload, uniqueFilename);
                    model.formFile.CopyTo(new System.IO.FileStream(filepath, System.IO.FileMode.Create));
                    //string filepath = $"{_env.WebRootPath}/images/{model.formFile.FileName}";
                    //var stream = System.IO.File.Create(filepath);
                    //model.formFile.CopyTo(stream);
                }
                try
                {
                    File newfile = new File
                    {
                        Yid = model.Yid,
                        Yoganame = model.Yoganame,
                        photo = uniqueFilename,

                    };
                    _context.Add(newfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    return BadRequest();
                }
            }
            return View();
        }

        // GET: Files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.yogas.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }
            return View(file);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Yid,Yoganame,photo")] File file)
        {
            if (id != file.Yid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(file);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileExists(file.Yid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(file);
        }

        // GET: Files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.yogas
                .FirstOrDefaultAsync(m => m.Yid == id);
            if (file == null)
            {
                return NotFound();
            }

            return View(file);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var file = await _context.yogas.FindAsync(id);
            _context.yogas.Remove(file);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileExists(int id)
        {
            return _context.yogas.Any(e => e.Yid == id);
        }
    }
}
