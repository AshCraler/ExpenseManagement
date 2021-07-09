using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PassbookManagement.Data;
using PassbookManagement.Framework;
using PassbookManagement.Models;
using PassbookManagement.ViewModel;

namespace PassbookManagement.Areas.BankEmployees.Controllers
{
    [Area("BankEmployees")]
    public class EmpPassbookController : Controller
    {
        private readonly PassBookManagementContext _context;

        public EmpPassbookController(PassBookManagementContext context)
        {
            _context = context;
        }

        //done
        // GET: BankEmployees/EmpPassbook
        public async Task<IActionResult> Index()
        {
            var passBookManagementContext = _context.Passbook.Include(p => p.Customer).Include(p => p.Employee).Include(p => p.InterestValue).Include(p => p.SpendingAccount);

            List<PassbookViewModel> result = new();
            List<Passbook> list = await passBookManagementContext.ToListAsync();

            foreach(Passbook passbook in list)
            {
                PassbookViewModel VM = new PassbookViewModel(passbook);
                IQueryable<string> interestQuery = from m in _context.Interest
                                                orderby m.Name
                                                select m.Name;

                VM.InterestList = new SelectList(await interestQuery.Distinct().ToListAsync());
                result.Add(VM);
            }
            return View(result);
        }

        //done
        // GET: BankEmployees/EmpPassbook/Details/5
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

            return View(new PassbookViewModel(passbook));
        }

        // GET: BankEmployees/EmpPassbook/Create
        public IActionResult Create()
        {
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId");
            ViewData["SpendingAccountRefId"] = new SelectList(_context.Set<SpendingAccount>(), "AccountId", "AccountId");
            return View();
        }

        // POST: BankEmployees/EmpPassbook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerRefId,InterestRefId,Balance")] Passbook passbook)
        {
            if (ModelState.IsValid)
            {
                passbook.PassbookId = IdAutoCreator.newPassbook();
                SessionData data = SessionHelper.GetCurrentData(HttpContext.Session);
                passbook.Employee = await _context.Employee.FindAsync(data.Username);
                passbook.EmployeeRefId = passbook.Employee.EmployeeId;
                passbook.OpenMethod = "ofline";
                passbook.CreateDate = new DateTime();
                passbook.Period = passbook.InterestValue.StandardPeriod;
                passbook.IsFinalized = false;
                passbook.SpendingAccount = null;
                passbook.SpendingAccountRefId = null;

                _context.Add(passbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerRefId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", passbook.CustomerRefId);
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.Set<SpendingAccount>(), "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // GET: BankEmployees/EmpPassbook/Edit/5
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
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.Set<SpendingAccount>(), "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // POST: BankEmployees/EmpPassbook/Edit/5
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
            ViewData["EmployeeRefId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "EmployeeId", passbook.EmployeeRefId);
            ViewData["InterestRefId"] = new SelectList(_context.Set<InterestValue>(), "InterestId", "InterestId", passbook.InterestRefId);
            ViewData["SpendingAccountRefId"] = new SelectList(_context.Set<SpendingAccount>(), "AccountId", "AccountId", passbook.SpendingAccountRefId);
            return View(passbook);
        }

        // GET: BankEmployees/EmpPassbook/Delete/5
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

        // POST: BankEmployees/EmpPassbook/Delete/5
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
