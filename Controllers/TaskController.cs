using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practyca02_04_2023.Models;
using System.Security.Policy;

namespace Practyca02_04_2023.Controllers
{
    public class TaskController : Controller
    {
        public List<Practyca02_04_2023.Models.Task> tasks;
        TaskContext db = new TaskContext();
        int Check = 1;
        public TaskController() { 
            tasks = new List<Practyca02_04_2023.Models.Task>();
            db.Database.EnsureCreated();
       
        }
        // GET: TaskController
        public ActionResult List(int check)
        {
            TaskList taskList = new TaskList();
            if(check == null || check == 0)
                check = 1;

            if (check == 1)
				taskList.Tasks = db.Tasks.ToList();
            else if (check == 2)
				taskList.Tasks = db.Tasks.Where(s => s.Status == true).ToList();
            else if (check == 3)
				taskList.Tasks = db.Tasks.Where(s => s.Status == false).ToList();
          
			return View(taskList);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Practyca02_04_2023.Models.Task task = new Practyca02_04_2023.Models.Task();

                task.Name = collection.ElementAt(0).Value;
                task.Description = collection.ElementAt(1).Value;
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5   
        public ActionResult Edit(int id)
        {
            return View(GetTask(id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Practyca02_04_2023.Models.Task task = GetTask(id);
                task.Name = collection.ElementAt(0).Value;
                task.Description = collection.ElementAt(1).Value;
                db.Tasks.Update(task);
                db.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                db.Tasks.Remove(GetTask(id));
                db.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return RedirectToAction(nameof(List));
            }
          
        }

        // POST: TaskController/Delete/5
        

        public void StatusChange(bool check, int id)
        {
            Practyca02_04_2023.Models.Task task = GetTask(id);
            task.Status = check;
            db.Tasks.Update(task);
            db.SaveChanges();
        }

        public ActionResult ShowFilter(int check)
        {

            Console.WriteLine(check);
          
			return RedirectToAction(nameof(List), new { check = check});

        }

        public Practyca02_04_2023.Models.Task GetTask(int id)
        {
            return db.Tasks.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
