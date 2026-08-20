using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private static readonly List<ExpenseModel> expenseList = new();
        [HttpGet]
        public IActionResult getAllExpenses()
        {
            return Ok(expenseList);
        }

        [HttpGet("{id}")]
        public IActionResult getExpenseById(int id)
        {
            var expense = expenseList.FirstOrDefault(e => e.Id == id);
            if(expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public IActionResult addExpense(ExpenseModel toAddExpense)
        {
            toAddExpense.Id = expenseList.Count + 1;
            expenseList.Add(toAddExpense);
            return CreatedAtAction(
                nameof(getExpenseById),
                new { id = toAddExpense.Id },
                toAddExpense
            );
        }

        [HttpPut("{id}")]
        public IActionResult updateExpense(int id, ExpenseModel toUpdateExpense)
        {
            var expense = expenseList.FirstOrDefault(e => e.Id == id);
            if(expense == null)
            {
                return NotFound();
            }
            expense.Name = toUpdateExpense.Name;
            expense.Amount = toUpdateExpense.Amount;
            expense.Date = toUpdateExpense.Date;
            expense.Category = toUpdateExpense.Category;
            return Ok(expense);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteExpense(int id)
        {
            var expense = expenseList.FirstOrDefault(e => e.Id == id);
            if(expense == null)
            {
                return NotFound();
            }
            expenseList.Remove(expense);
            return NoContent();
        }
    }
}
