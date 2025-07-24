using Dynamic_Form_Builder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic_Form_Builder.Controllers
{
    public class FormController : Controller
    {
        private readonly IConfiguration _configuration;

        public FormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString => _configuration.GetConnectionString("DefaultConnection");

        public async Task<IActionResult> Index()
        {
            var forms = new List<Form>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("SELECT FormId, Title FROM Forms", conn);
                var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    forms.Add(new Form
                    {
                        FormId = reader.GetInt32(0),
                        Title = reader.GetString(1)
                    });
                }
            }

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

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                string insertFormQuery = "INSERT INTO Forms (Title) OUTPUT INSERTED.FormId VALUES (@Title)";
                SqlCommand cmd = new SqlCommand(insertFormQuery, conn);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                int formId = (int)await cmd.ExecuteScalarAsync();

                foreach (var field in model.Fields)
                {
                    string insertFieldQuery = @"INSERT INTO DropdownFields (FormId, Label, SelectedOption, IsRequired)
                                                VALUES (@FormId, @Label, @SelectedOption, @IsRequired)";
                    SqlCommand fieldCmd = new SqlCommand(insertFieldQuery, conn);
                    fieldCmd.Parameters.AddWithValue("@FormId", formId);
                    fieldCmd.Parameters.AddWithValue("@Label", field.Label);
                    fieldCmd.Parameters.AddWithValue("@SelectedOption", field.SelectedOption);
                    fieldCmd.Parameters.AddWithValue("@IsRequired", field.IsRequired);
                    await fieldCmd.ExecuteNonQueryAsync();
                }
            }

            return Json(new { success = true, message = "Form created successfully!" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            Form form = null;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand formCmd = new SqlCommand("SELECT FormId, Title FROM Forms WHERE FormId = @Id", conn);
                formCmd.Parameters.AddWithValue("@Id", id);
                var reader = await formCmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    form = new Form
                    {
                        FormId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Fields = new List<DropdownField>()
                    };
                }
                await reader.CloseAsync();

                SqlCommand fieldCmd = new SqlCommand("SELECT FieldId, Label, SelectedOption, IsRequired FROM DropdownFields WHERE FormId = @Id", conn);
                fieldCmd.Parameters.AddWithValue("@Id", id);
                var fieldReader = await fieldCmd.ExecuteReaderAsync();

                while (await fieldReader.ReadAsync())
                {
                    form.Fields.Add(new DropdownField
                    {
                        FieldId = fieldReader.GetInt32(0),
                        Label = fieldReader.GetString(1),
                        SelectedOption = fieldReader.GetString(2),
                        IsRequired = fieldReader.GetBoolean(3)
                    });
                }
            }

            if (form == null)
                return NotFound();

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Form model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Title) || model.Fields == null || !model.Fields.Any())
            {
                return Json(new { success = false, message = "Invalid form data." });
            }

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                string updateFormQuery = "UPDATE Forms SET Title = @Title WHERE FormId = @FormId";
                SqlCommand updateCmd = new SqlCommand(updateFormQuery, conn);
                updateCmd.Parameters.AddWithValue("@Title", model.Title);
                updateCmd.Parameters.AddWithValue("@FormId", model.FormId);
                await updateCmd.ExecuteNonQueryAsync();

                // Clear old fields
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM DropdownFields WHERE FormId = @FormId", conn);
                deleteCmd.Parameters.AddWithValue("@FormId", model.FormId);
                await deleteCmd.ExecuteNonQueryAsync();

                // Insert new fields
                foreach (var field in model.Fields)
                {
                    string insertFieldQuery = @"INSERT INTO DropdownFields (FormId, Label, SelectedOption, IsRequired)
                                                VALUES (@FormId, @Label, @SelectedOption, @IsRequired)";
                    SqlCommand fieldCmd = new SqlCommand(insertFieldQuery, conn);
                    fieldCmd.Parameters.AddWithValue("@FormId", model.FormId);
                    fieldCmd.Parameters.AddWithValue("@Label", field.Label);
                    fieldCmd.Parameters.AddWithValue("@SelectedOption", field.SelectedOption);
                    fieldCmd.Parameters.AddWithValue("@IsRequired", field.IsRequired);
                    await fieldCmd.ExecuteNonQueryAsync();
                }
            }

            return Json(new { success = true, message = "Form updated successfully!" });
        }

        public async Task<IActionResult> Preview(int id)
        {
            Form form = null;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.OpenAsync();

                SqlCommand formCmd = new SqlCommand("SELECT FormId, Title FROM Forms WHERE FormId = @Id", conn);
                formCmd.Parameters.AddWithValue("@Id", id);
                var reader = await formCmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    form = new Form
                    {
                        FormId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Fields = new List<DropdownField>()
                    };
                }
                await reader.CloseAsync();

                SqlCommand fieldCmd = new SqlCommand("SELECT FieldId, Label, SelectedOption, IsRequired FROM DropdownFields WHERE FormId = @Id", conn);
                fieldCmd.Parameters.AddWithValue("@Id", id);
                var fieldReader = await fieldCmd.ExecuteReaderAsync();

                while (await fieldReader.ReadAsync())
                {
                    form.Fields.Add(new DropdownField
                    {
                        FieldId = fieldReader.GetInt32(0),
                        Label = fieldReader.GetString(1),
                        SelectedOption = fieldReader.GetString(2),
                        IsRequired = fieldReader.GetBoolean(3)
                    });
                }
            }

            if (form == null)
                return NotFound();

            return View(form);
        }
    }
}
