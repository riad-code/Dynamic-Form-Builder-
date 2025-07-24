# Dynamic Form Builder System

📚 **Project Overview**  
The Dynamic Form Builder is a fully functional, responsive ASP.NET Core MVC web application that allows users to create, edit, and preview customizable forms by dynamically adding dropdown fields. The system leverages AJAX and SweetAlert2 for real-time interactivity and uses ADO.NET with raw SQL for data persistence, avoiding Entity Framework or LINQ.

---

## 🧑‍💻 Project Details  
- **Type:** Academic Project  
- **Developed at:** IUBAT  
- **Technologies Used:**  
  - ASP.NET Core MVC  
  - ADO.NET with Raw SQL (SQLConnection, SQLCommand, SQLDataReader)  
  - MS SQL Server  
  - HTML/CSS, JavaScript, jQuery, AJAX  
  - SweetAlert2 for UI feedback  
- **IDE:** Visual Studio 2022  
- **Authentication:** Not implemented (Single-user prototype)

---

## 🎯 Objectives  
- Allow users to dynamically create forms with multiple dropdown fields  
- Save form title and dropdown field data using ADO.NET with raw SQL  
- Enable editing of existing forms with pre-loaded data  
- Display a grid/list of saved forms with preview options  
- Preview forms with required fields clearly marked  
- Provide user-friendly confirmations and alerts using SweetAlert2  
- Responsive and clean UI with Bootstrap and jQuery  

---

## 🧩 Module Features  

### Form Creation  
- Input form title  
- Add multiple dropdown fields dynamically  
- Mark dropdowns as required  
- Save form data asynchronously using AJAX  

### Form Editing  
- Load existing form data for editing  
- Add, remove, or modify dropdown fields  
- Update changes in database using raw SQL  

### Form Listing (Grid View)  
- Show all saved forms with Form ID and Title  
- Provide Preview button for each form  

### Form Preview  
- Display form with dropdowns and selected values  
- Highlight required fields with red asterisk (*)  
- Non-editable view for user reference  

### Backend & Database  
- ADO.NET with raw SQL queries for all DB operations  
- SQL Server database with two main tables:  
  - `Forms` (FormId, Title)  
  - `DropdownFields` (FieldId, FormId, Label, SelectedOption, IsRequired)  

---

## 📦 Technologies & Tools  
- ASP.NET Core MVC  
- jQuery, AJAX  
- SweetAlert2  
- ADO.NET  
- Microsoft SQL Server  
- Visual Studio 2022  

---

## 📊 Bonus / Advanced Features  
- AJAX-based form submission with no page reload  
- Full ADO.NET implementation (no EF Core or LINQ)  
- SweetAlert2 for enhanced user experience  
- Optional: ViewComponent support for dynamic dropdown rendering  
- Optional: PDF/Excel export (not included)

---

## 🛠️ How to Run  
1. Clone the repository  
2. Configure your connection string in `appsettings.json` under `"DefaultConnection"`  
3. Ensure your SQL Server database is created with necessary tables (Forms, DropdownFields)  
4. Build and run the project in Visual Studio 2022  
5. Use the web UI to create, edit, preview, and list dynamic forms  

---



-

*Thank you for checking out the Dynamic Form Builder project!*
