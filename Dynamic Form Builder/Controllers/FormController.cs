using Dynamic_Form_Builder.Data;
using Dynamic_Form_Builder.Models;
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

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Form model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Title) || model.Fields == null || !model.Fields.Any())
            {
                return Json(new { success = false, message = "Invalid form data." });
            }

            _context.Forms.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Form created successfully!" });
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
        public async Task<IActionResult> Edit([FromBody] Form model)
        {
            if (model == null)
                return Json(new { success = false, message = "Model is null." });

            if (string.IsNullOrWhiteSpace(model.Title))
                return Json(new { success = false, message = "Title is empty." });

            if (model.Fields == null || !model.Fields.Any())
                return Json(new { success = false, message = "No fields provided." });

            foreach (var f in model.Fields)
            {
                if (string.IsNullOrWhiteSpace(f.Label))
                    return Json(new { success = false, message = "A field label is empty." });
                if (string.IsNullOrWhiteSpace(f.SelectedOption))
                    return Json(new { success = false, message = "A field selected option is empty." });
            }

            var form = await _context.Forms.Include(f => f.Fields)
                                           .FirstOrDefaultAsync(f => f.FormId == model.FormId);

            if (form == null)
                return Json(new { success = false, message = "Form not found." });

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

            return Json(new { success = true, message = "Form updated successfully!" });
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
