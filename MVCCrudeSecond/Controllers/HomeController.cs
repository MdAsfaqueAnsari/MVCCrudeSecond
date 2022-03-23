using MVCCrudeSecond.DB_Contex;
using MVCCrudeSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudeSecond.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeEntities1 Db = new EmployeeEntities1();

            List<EmpModel> empobj = new List<EmpModel>();

            var res=Db.tbl_Employee.ToList();

            foreach (var item in res)
            {
                empobj.Add(new EmpModel
                {
                    Id= item.Id,
                    Name= item.Name,
                    Salary= item.Salary,
                    Mob = item.Mob,
                    Email= item.Email,
                    Department= item.Department,
                    City= item.City,    
                });
   

            }

            return View(empobj);
        }


        public ActionResult Delete(int Id)

        {
            EmployeeEntities1 Db=new EmployeeEntities1();
            var deleteitem = Db.tbl_Employee.Where(m => m.Id == Id).First();
            Db.tbl_Employee.Remove(deleteitem);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            EmpModel objEmp= new EmpModel();
            EmployeeEntities1 Db = new EmployeeEntities1();
            var EditItem = Db.tbl_Employee.Where(m => m.Id == Id).First();

            objEmp.Id = EditItem.Id;
            objEmp.Name = EditItem.Name;
            objEmp.Salary = EditItem.Salary;
            objEmp.Mob = EditItem.Mob;
            objEmp.Email = EditItem.Email;
            objEmp.Department = EditItem.Department;
            objEmp.City = EditItem.City;

            ViewBag.Id= EditItem.Id;

            return View("AddEmployee",objEmp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmpModel empobj)
        {
            EmployeeEntities1 Db = new EmployeeEntities1();
            tbl_Employee objnew = new tbl_Employee();

            objnew.Id = empobj.Id;
            objnew.Name = empobj.Name;
            objnew.Salary = empobj.Salary;
            objnew.Mob = empobj.Mob;
            objnew.Email = empobj.Email;
            objnew.Department = empobj.Department;
            objnew.City = empobj.City;

            if (empobj.Id == 0)
            {
                Db.tbl_Employee.Add(objnew);
                Db.SaveChanges();
            }
            else
            {
                Db.Entry(objnew).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
            }
            

            return RedirectToAction("Index");
           // return View();
        }

        [HttpPut]
        public ActionResult EditEmployee(EmpModel empobj)
        {
            EmployeeEntities1 Db = new EmployeeEntities1();
            tbl_Employee objnew = new tbl_Employee();

            objnew.Id = empobj.Id;
            objnew.Name = empobj.Name;
            objnew.Salary = empobj.Salary;
            objnew.Mob = empobj.Mob;
            objnew.Email = empobj.Email;
            objnew.Department = empobj.Department;
            objnew.City = empobj.City;

            if(empobj.Id == 0)
            {
                Db.tbl_Employee.Add(objnew);
                Db.SaveChanges();
            }
            else
            {
                Db.Entry(objnew).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
            }

            Db.tbl_Employee.Add(objnew);
            Db.SaveChanges();

            return RedirectToAction("Index");
            // return View();
        }


        public ActionResult DesingAbout()
        {
            return View();
        }

        public ActionResult IndexDashBoard()
        {
            return View();
        }

        public ActionResult EmpTable()
        {

            EmployeeEntities1 Db = new EmployeeEntities1();

            List<EmpModel> empobj = new List<EmpModel>();

            var res = Db.tbl_Employee.ToList();

            foreach (var item in res)
            {
                empobj.Add(new EmpModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Salary = item.Salary,
                    Mob = item.Mob,
                    Email = item.Email,
                    Department = item.Department,
                    City = item.City,
                });


            }
            return View(empobj);
        }

    }
}