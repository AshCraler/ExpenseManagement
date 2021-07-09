using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PassbookManagement.Data;
using PassbookManagement.Models;

namespace PassbookManagement.Areas.BankEmployees.Controllers
{
    [Area("BankEmployees")]
    public class EmpTransactionController : Controller
    {
        private readonly PassBookManagementContext _context;

        public EmpTransactionController(PassBookManagementContext context)
        {
            _context = context;
        }

        // GET: BankEmployees/EmpTransaction
        public async Task<IActionResult> Index()
        {
            var passBookManagementContext = _context.Transaction.Include(t => t.Employee).Include(t => t.Passbook).Include(t => t.SpendingAccount);
            return View(await passBookManagementContext.ToListAsync());
        }

        // GET: BankEmployees/EmpTransaction/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Employee)
                .Include(t => t.Passbook)
                .Include(t => t.SpendingAccount)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: BankEmployees/EmpTransaction/Create
        public IActionResult Create()
        {
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId");
            ViewData["PassbookRefId"] = new SelectList(_context.Passbook, "PassbookId", "PassbookId");
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId");
            return View();
        }

        // POST: BankEmployees/EmpTransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,PassbookRefId,EmployeeRefId,TransactionMethod,TransactionType,Amount,IsViolation,ReleaseDate,SpendingAccountRefId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", transaction.EmployeeRefId);
            ViewData["PassbookRefId"] = new SelectList(_context.Passbook, "PassbookId", "PassbookId", transaction.PassbookRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", transaction.SpendingAccountRefId);
            return View(transaction);
        }

        // GET: BankEmployees/EmpTransaction/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", transaction.EmployeeRefId);
            ViewData["PassbookRefId"] = new SelectList(_context.Passbook, "PassbookId", "PassbookId", transaction.PassbookRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", transaction.SpendingAccountRefId);
            return View(transaction);
        }

        // POST: BankEmployees/EmpTransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TransactionId,PassbookRefId,EmployeeRefId,TransactionMethod,TransactionType,Amount,IsViolation,ReleaseDate,SpendingAccountRefId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", transaction.EmployeeRefId);
            ViewData["PassbookRefId"] = new SelectList(_context.Passbook, "PassbookId", "PassbookId", transaction.PassbookRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", transaction.SpendingAccountRefId);
            return View(transaction);
        }

        // GET: BankEmployees/EmpTransaction/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Employee)
                .Include(t => t.Passbook)
                .Include(t => t.SpendingAccount)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: BankEmployees/EmpTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(string id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
