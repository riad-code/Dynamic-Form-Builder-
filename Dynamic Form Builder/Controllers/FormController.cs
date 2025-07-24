using Dynamic_Form_Builder.Models;
using Dynamic_Form_Builder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dynamic_Form_Builder.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var forms = await _context.Forms.ToListAsync();
            return View(forms);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Form model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _context.Forms.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error: " + ex.Message);
                return View(model);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var form = await _context.Forms
                .Include(f => f.Fields)
                .FirstOrDefaultAsync(f => f.FormId == id);

            if (form == null)
                return NotFound();

            return View(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Form model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var form = await _context.Forms
                .Include(f => f.Fields)
                .FirstOrDefaultAsync(f => f.FormId == model.FormId);

            if (form == null)
                return NotFound();

            form.Title = model.Title;
            form.Fields.Clear();

            foreach (var field in model.Fields)
            {
                form.Fields.Add(new DropdownField
                {
                    Label = field.Label,
                    SelectedOption = field.SelectedOption,
                    IsRequired = field.IsRequired
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }



        public async Task<IActionResult> Preview(int id)
        {
            var form = await _context.Forms
                .Include(f => f.Fields)  
                .FirstOrDefaultAsync(f => f.FormId == id);

            if (form == null)
                return NotFound();

            return View(form);
        }
    }
}
