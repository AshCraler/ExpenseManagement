using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PassbookManagement.Data;
using PassbookManagement.Models;

namespace PassbookManagement.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class CusPassbookController : Controller
    {
        private readonly PassBookManagementContext _context;

        public CusPassbookController(PassBookManagementContext context)
        {
            _context = context;
        }

        // GET: Customers/CusPassbook
        public async Task<IActionResult> Index()
        {
            var passBookManagementContext = _context.Passbook.Include(p => p.Customer).Include(p => p.Employee).Include(p => p.InterestValue).Include(p => p.SpendingAccount);
            return View(await passBookManagementContext.ToListAsync());
        }

        // GET: Customers/CusPassbook/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passbook = await _context.Passbook
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Include(p => p.InterestValue)
                .Include(p => p.SpendingAccount)
                .FirstOrDefaultAsync(m => m.PassbookId == id);
            if (passbook == null)
            {
                return NotFound();
            }

            return View(passbook);
        }

        // GET: Customers/CusPassbook/Create
        public IActionResult Create()
        {
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["EmployeeRefId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId");
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId");
            return View();
        }

        // POST: Customers/CusPassbook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassbookId,CustomerRefId,EmployeeRefId,OpenMethod,CreateDate,Period,InterestRefId,Balance,IsFinalized,SpendingAccountRefId")] Passbook passbook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", passbook.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // GET: Customers/CusPassbook/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passbook = await _context.Passbook.FindAsync(id);
            if (passbook == null)
            {
                return NotFound();
            }
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", passbook.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // POST: Customers/CusPassbook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PassbookId,CustomerRefId,EmployeeRefId,OpenMethod,CreateDate,Period,InterestRefId,Balance,IsFinalized,SpendingAccountRefId")] Passbook passbook)
        {
            if (id != passbook.PassbookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passbook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassbookExists(passbook.PassbookId))
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
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", passbook.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.SpendingAccount, "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // GET: Customers/CusPassbook/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passbook = await _context.Passbook
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Include(p => p.InterestValue)
                .Include(p => p.SpendingAccount)
                .FirstOrDefaultAsync(m => m.PassbookId == id);
            if (passbook == null)
            {
                return NotFound();
            }

            return View(passbook);
        }

        // POST: Customers/CusPassbook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var passbook = await _context.Passbook.FindAsync(id);
            _context.Passbook.Remove(passbook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassbookExists(string id)
        {
            return _context.Passbook.Any(e => e.PassbookId == id);
        }
    }
}
