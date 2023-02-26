using FluentValidation;
using FluentValidation.Results;
using FluentValidationStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IValidator<Employee> _validator;

        public EmployeesController(IValidator<Employee> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            ValidationResult result = await _validator.ValidateAsync(employee);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            //Save the Employee to the database, or some other logic

            return RedirectToAction("Index");
        }
    }
}
