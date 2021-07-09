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
    public class EmpSpendingAccountController : Controller
    {
        private readonly PassBookManagementContext _context;

        public EmpSpendingAccountController(PassBookManagementContext context)
        {
            _context = context;
        }

        // GET: BankEmployees/EmpSpendingAccount
        public async Task<IActionResult> Index()
        {
            var passBookManagementContext = _context.SpendingAccount.Include(s => s.Customer).Include(s => s.Employee);
            return View(await passBookManagementContext.ToListAsync());
        }

        // GET: BankEmployees/EmpSpendingAccount/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingAccount = await _context.SpendingAccount
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (spendingAccount == null)
            {
                return NotFound();
            }

            return View(spendingAccount);
        }

        // GET: BankEmployees/EmpSpendingAccount/Create
        public IActionResult Create()
        {
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: BankEmployees/EmpSpendingAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,CustomerRefId,EmployeeRefId,InterestRate,Balance")] SpendingAccount spendingAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spendingAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spendingAccount.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", spendingAccount.EmployeeRefId);
            return View(spendingAccount);
        }

        // GET: BankEmployees/EmpSpendingAccount/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingAccount = await _context.SpendingAccount.FindAsync(id);
            if (spendingAccount == null)
            {
                return NotFound();
            }
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spendingAccount.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", spendingAccount.EmployeeRefId);
            return View(spendingAccount);
        }

        // POST: BankEmployees/EmpSpendingAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountId,CustomerRefId,EmployeeRefId,InterestRate,Balance")] SpendingAccount spendingAccount)
        {
            if (id != spendingAccount.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spendingAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpendingAccountExists(spendingAccount.AccountId))
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
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", spendingAccount.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", spendingAccount.EmployeeRefId);
            return View(spendingAccount);
        }

        // GET: BankEmployees/EmpSpendingAccount/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingAccount = await _context.SpendingAccount
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (spendingAccount == null)
            {
                return NotFound();
            }

            return View(spendingAccount);
        }

        // POST: BankEmployees/EmpSpendingAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var spendingAccount = await _context.SpendingAccount.FindAsync(id);
            _context.SpendingAccount.Remove(spendingAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpendingAccountExists(string id)
        {
            return _context.SpendingAccount.Any(e => e.AccountId == id);
        }
    }
}
