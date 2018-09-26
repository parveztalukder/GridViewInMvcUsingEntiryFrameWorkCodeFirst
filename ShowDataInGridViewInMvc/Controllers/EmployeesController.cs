using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShowDataInGridViewInMvc.Models;
using ShowDataInGridViewInMvc.ViewModel;

namespace ShowDataInGridViewInMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var emp = (from e in db.Employees
                       select new EmployeeViewModel
                       {
                        Id=e.Id,
                        Name=e.Name,
                        Gender=e.Gender,
                        Basic=e.Basic,
                        Medical=e.Medical,
                        Travel=e.Travel,
                        Tax=e.Tax,
                        Provident=e.Provident,
                        Deduction=e.Deduction,
                        GrossSalary=e.GrossSalary,
                        NetSalary=e.NetSalary
                       }).ToList();
            return View(emp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,Basic,Medical,Travel,Provident,Tax,GrossSalary,Deduction,NetSalary")] Employee employee)
        {
            employee.GrossSalary = employee.grossSal();
            employee.Deduction = employee.totaldeduc();
            employee.NetSalary = employee.netsal();
            employee.Medical = employee.medical();
            employee.Travel = employee.travel();
            employee.Tax = employee.tax();
            employee.Provident = employee.provident();
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Basic,Medical,Travel,Provident,Tax,GrossSalary,Deduction,NetSalary")] Employee employee)
        {
            employee.GrossSalary = employee.grossSal();
            employee.Deduction = employee.totaldeduc();
            employee.NetSalary = employee.netsal();
            employee.Medical = employee.medical();
            employee.Travel = employee.travel();
            employee.Tax = employee.tax();
            employee.Provident = employee.provident();
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
