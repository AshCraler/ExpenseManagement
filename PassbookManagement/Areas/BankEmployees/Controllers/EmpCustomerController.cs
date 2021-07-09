using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class EmpCustomerController : Controller
    {
        private readonly PassBookManagementContext _context;
        private IWebHostEnvironment webHostEnvironment;
        private SessionData decent;

        public EmpCustomerController(PassBookManagementContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: BankEmployees/EmpCustomer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: BankEmployees/EmpCustomer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: BankEmployees/EmpCustomer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankEmployees/EmpCustomer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,BirthDay,IdCardNumber,Email,PhoneNumber")] CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                
                Customer customer = new Customer
                {
                    CustomerId = IdAutoCreator.newCustomer(),
                    FullName = customerVM.FullName,
                    BirthDay = customerVM.BirthDay,
                    IdCardNumber = customerVM.IdCardNumber,
                    Email = customerVM.Email,
                    PhoneNumber = customerVM.PhoneNumber,
                    SignatureImagePath = null,

                };
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerVM);
        }

        // GET: BankEmployees/EmpCustomer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(new CustomerViewModel(customer));
        }

        // POST: BankEmployees/EmpCustomer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,BirthDay,IdCardNumber,Email,PhoneNumber,SignatureImagePath,SignatureImage")] CustomerViewModel customerVM)
        {
            if (id != customerVM.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Customer customer = new Customer
                    {
                        CustomerId = IdAutoCreator.newCustomer(),
                        FullName = customerVM.FullName,
                        BirthDay = customerVM.BirthDay,
                        IdCardNumber = customerVM.IdCardNumber,
                        Email = customerVM.Email,
                        PhoneNumber = customerVM.PhoneNumber,
                        

                    };
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customerVM.CustomerId))
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
            return View(customerVM);
        }

        // GET: BankEmployees/EmpCustomer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: BankEmployees/EmpCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Signature");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
