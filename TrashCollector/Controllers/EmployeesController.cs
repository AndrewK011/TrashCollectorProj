using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("PickupsForToday", new { id = employee.EmployeeId });
        }
        public IActionResult PickupsForToday(int? id)
        {
            CustomerDayViewModel customerDayViewModel = new CustomerDayViewModel();
            customerDayViewModel.DayOfWeek = DateTime.Today.DayOfWeek;
            Employee employee = _context.Employees
                .Include(c => c.IdentityUser)
                .FirstOrDefault(e => e.EmployeeId == id);
            bool oneTimePickupIsInView;
            foreach (var customer in _context.Customers)
            {
                oneTimePickupIsInView = false;
                if (customer.OneTimePickup.DayOfWeek == customerDayViewModel.DayOfWeek)
                {
                    oneTimePickupIsInView = true;
                }

                if (_context.Customers.Where(c => (c.ZipCode == employee.ZipCode && oneTimePickupIsInView && c.CustomerId == customer.CustomerId) ||
                     (c.ZipCode == employee.ZipCode && c.PickupDay == customerDayViewModel.DayOfWeek && c.CustomerId == customer.CustomerId)).SingleOrDefault() != null)
                {

                    customerDayViewModel.Customers.Add(_context.Customers
                        .Where(c => (c.ZipCode == employee.ZipCode && oneTimePickupIsInView && c.CustomerId == customer.CustomerId) ||
                        (c.ZipCode == employee.ZipCode && c.PickupDay == customerDayViewModel.DayOfWeek && c.CustomerId == customer.CustomerId)).SingleOrDefault());
                }

            }

            
            // ||
            //(c.OneTimePickup.DayOfWeek == customerDayViewModel.DayOfWeek)).ToList();
            return View(customerDayViewModel);
        }
        [HttpPost]
        public IActionResult PickupsForToday(CustomerDayViewModel customerDayViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            bool oneTimePickupIsInView;
            foreach (var customer in _context.Customers)
            {
                oneTimePickupIsInView = false;
                if (customer.OneTimePickup.DayOfWeek == customerDayViewModel.DayOfWeek)
                {
                    oneTimePickupIsInView = true;
                }

                if (_context.Customers.Where(c => (c.ZipCode == employee.ZipCode && oneTimePickupIsInView && c.CustomerId == customer.CustomerId) ||
                     (c.ZipCode == employee.ZipCode && c.PickupDay == customerDayViewModel.DayOfWeek && c.CustomerId == customer.CustomerId)).SingleOrDefault() != null)
                {

                    customerDayViewModel.Customers.Add(_context.Customers
                        .Where(c => (c.ZipCode == employee.ZipCode && oneTimePickupIsInView && c.CustomerId == customer.CustomerId) ||
                        (c.ZipCode == employee.ZipCode && c.PickupDay == customerDayViewModel.DayOfWeek && c.CustomerId == customer.CustomerId)).SingleOrDefault());
                }

            }
            //customerDayViewModel.Customers = _context.Customers
            //    .Where(c => (c.ZipCode == employee.ZipCode && c.OneTimePickup.Date == customerDayViewModel) ||
            //    (c.ZipCode == employee.ZipCode && c.PickupDay == customerDayViewModel.DayOfWeek)).ToList();
            return View(customerDayViewModel);
        }

        public IActionResult ConfirmPickup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customers.Where(m => m.CustomerId == id).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            customer.WeeklyPickupConfirmed = true;
            customer.MonthlyBalanceOwed += 10.00;
            _context.SaveChanges();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return RedirectToAction("PickupsForToday", new { id = employee.EmployeeId });
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("PickupsForToday", new { id = employee.EmployeeId });
            }
            return RedirectToAction("Index");
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
