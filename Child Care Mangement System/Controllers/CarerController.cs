using Child_Care_Mangement_System.Data;
using Child_Care_Mangement_System.Models;
using Child_Care_Mangement_System.Widgets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Controllers
{
    public class CarerController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public CarerController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<IActionResult> Index()
        {
            var childList = await this.context.Children.Include(c => c.CareCategory).ToListAsync();
            return View("CarerDashboard", childList);
        }
        [HttpPost]
        public async Task<IActionResult> ClockInChild(int ChildId)
        {

            var child = await this.context.Children.Include(c => c.Bills).Include(c => c.ChildClockHistories).Where(c => c.ChildId == ChildId).FirstOrDefaultAsync();
            var existingBill = child.Bills.Where(b => b.Date.Year == DateTime.Now.Year && b.Date.Month == DateTime.Now.Month).ToList();
            Bill curBill = existingBill.FirstOrDefault();
            if (existingBill.Count == 0)
            {
                Bill b = new Bill() { ChildId = ChildId,UserId=child.ParentId, Date = DateTime.Now, Price = 20, Status = BillStatus.Due, TotalDue = 0 };
                this.context.Add(b);
                await this.context.SaveChangesAsync();
                curBill = b;

            }
            var todaysClockIn = child.ChildClockHistories.Where(c => c.ClockIn.Day == DateTime.Now.Day && c.Date.Year == DateTime.Now.Year && c.Date.Month == DateTime.Now.Month).ToList();
            if (todaysClockIn.Count == 0)
            {
                ChildClockHistory childClockHistory = new ChildClockHistory { ChildId = ChildId, Date = DateTime.Now, ClockIn = DateTime.Now, BillId = curBill.BillId };
                this.context.Add(childClockHistory);
                await this.context.SaveChangesAsync();
            }




            return Json(new { success = true, message = "Clock-In Successful" });
        }

        [HttpPost]
        public async Task<IActionResult> SetAvailability(int userId, DateTime availabilityDate, DateTime from, DateTime to)

        {
            SetAvilability s = new SetAvilability() { CarerId = userId, Date = availabilityDate, From = from, To = to };
            this.context.Add(s);
            await this.context.SaveChangesAsync();

            return Json(new { success = true, message = $"Availability set for {availabilityDate.Date}({availabilityDate.DayOfWeek})" });
        }
        [HttpGet]
        public async Task<IActionResult> ManageMeal()
        {
            var qq = await this.context.EatWellCategories.ToListAsync();
            var eatwellGuideList = await (from s in this.context.EatWellCategories select new SelectListItem { Text = s.Description, Value = s.EatWellCategoryId.ToString() }).ToListAsync();
            ViewBag.EatWellCategoryId = eatwellGuideList;
            ViewBag.MealTypeId = new List<SelectListItem>{
    new SelectListItem("Breakfast", MealTypeId.Breakfast.ToString()),
    new SelectListItem("Lunch", MealTypeId.Lunch.ToString()),
    new SelectListItem("Dinner", MealTypeId.Dinner.ToString()),
    new SelectListItem("Snacks", MealTypeId.Snacks.ToString())
};
            var mealList = await this.context.Meals.ToListAsync();
            return View("ManageMeal", mealList);
        }
        [HttpGet]
        public async Task<IActionResult> AddMeal()
        {
            var eatwellGuideList = await (from s in this.context.EatWellCategories select new SelectListItem { Text = s.Description, Value = s.EatWellCategoryId.ToString() }).ToListAsync();
            ViewBag.EatWellCategoryId = eatwellGuideList;
            ViewBag.MealTypeId = new List<SelectListItem>{
    new SelectListItem("Breakfast", MealTypeId.Breakfast.ToString()),
    new SelectListItem("Lunch", MealTypeId.Lunch.ToString()),
    new SelectListItem("Dinner", MealTypeId.Dinner.ToString()),
    new SelectListItem("Snacks", MealTypeId.Snacks.ToString())
};
            var mealList = await this.context.Meals.ToListAsync();
            return View("AddMeal");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMeal(Meal meal)
        {
            if (ModelState.IsValid)
            {

                this.context.Add(meal);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageMeal));
            }

            return View(meal);
        }
        [HttpGet]
        public async Task<IActionResult> EditMeal(int? id)
        {
            var eatwellGuideList = await (from s in this.context.EatWellCategories select new SelectListItem { Text = s.Description, Value = s.EatWellCategoryId.ToString() }).ToListAsync();
            ViewBag.EatWellCategoryId = eatwellGuideList;
            ViewBag.MealTypeId = this.GetMealTypeLookup();
            if (id == null)
            {
                return NotFound();
            }

            var meal = await this.context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMeal(int Id, Meal meal)
        {
            if (Id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                this.context.Update(meal);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(ManageMeal));
            }

            return View(meal);
        }

        public async Task<IActionResult> DeleteMeal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await context.Meals
                .Include(c => c.EatWellCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("DeleteMeal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMealConfirmed(int Id)
        {
            var meal = await context.Meals.FindAsync(Id);
            context.Meals.Remove(meal);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageMeal));
        }
        [HttpGet]
        public async Task<IActionResult> ChildDiet(int? Id)
        {
            var child = await this.context.Children.Include(c => c.Diets).ThenInclude(m => m.Meal).Where(c => c.ChildId == Id).FirstOrDefaultAsync();
            var widget = new WidgetService();
            var latestHealthLog = await this.context.ChildHealthLogs.Where(c => c.ChildId == Id).OrderByDescending(c=>c.ChildHealthLogId).LastOrDefaultAsync();
            ViewBag.recommendedCalorie = widget.CalculateCalorieIntake(child, latestHealthLog);
            return View("ManageDiet", child);
        }

        [HttpGet]
        public async Task<IActionResult> AddDiet(int Id)
        {

            ViewBag.WeekDayId = this.GetWeekDaysLookUp();
            ViewBag.ChildId = Id;
            var mealList = await this.context.Meals.ToListAsync();
            ViewBag.MealId = from m in mealList select new SelectListItem { Text = m.Description, Value = m.Id.ToString() };
            return View("AddDiet");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDiet(Diet diet)
        {
            if (ModelState.IsValid)
            {

                this.context.Add(diet);
                await this.context.SaveChangesAsync();
                return RedirectToAction("ChildDiet", new { Id = diet.ChildId });
            }

            return View(diet);
        }
        [HttpGet]
        public async Task<IActionResult> EditDiet(int? Id)
        {
            var diet = await this.context.Diets.FindAsync(Id);
            ViewBag.WeekDayId = this.GetWeekDaysLookUp();

            var mealList = await this.context.Meals.ToListAsync();
            ViewBag.MealId = from m in mealList select new SelectListItem { Text = $" {m.Description}-{m.Type}", Value = m.Id.ToString() };
            ViewBag.MealTypeId = this.GetMealTypeLookup();
            if (Id == null)
            {
                return NotFound();
            }


            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDiet(int Id, Diet diet)
        {
            if (Id != diet.DietId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                this.context.Update(diet);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(ChildDiet));
            }

            return View(diet);
        }

        public async Task<IActionResult> DeleteDiet(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var diet = await context.Diets
                .Include(c => c.Meal)
                .FirstOrDefaultAsync(m => m.DietId == Id);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("DeleteDiet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDietConfirmed(int Id)
        {
            var diet = await context.Diets.FindAsync(Id);
            context.Diets.Remove(diet);
            await context.SaveChangesAsync();
            return RedirectToAction("ChildDiet", new { Id = diet.ChildId });
        }
        public async Task<IActionResult> MealEntry(int id)
        {
            ViewBag.ChildId = id;
            var currentDay = DateTime.Now.DayOfWeek;
            var child = await this.context.Children
     .Include(c => c.Diets)
         .ThenInclude(d => d.Meal)
     .Where(c => c.ChildId == id)
     .FirstOrDefaultAsync();
            var diets = child.Diets.Where(s => (int)s.WeekDay == (int)currentDay).ToList();
            ViewBag.MealId = from s in diets select new SelectListItem { Text = s.Meal.Description, Value = s.MealId.ToString() };
            return View("MealEntry");
        }
        [HttpPost]
        public async Task<IActionResult> MealEntry(ChildMealLog childMealLog)
        {
            var diet =await this.context.Diets.Where(c => (int)c.WeekDay == (int)DateTime.Now.DayOfWeek && c.MealId==childMealLog.MealId).FirstOrDefaultAsync();
            childMealLog.DietId = diet.DietId;
            if (ModelState.IsValid)
            {

                this.context.Add(childMealLog);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(childMealLog);

        }


        public async Task<IActionResult> ChildInfo(int id)
        {
            ViewBag.ChildId = id;
            var currentDay = DateTime.Now.DayOfWeek;
            var child = await this.context.Children.Include(s => s.ChildHealthLogs).Include(s => s.ChildMealLogs)
     .Include(c => c.Diets)
         .ThenInclude(d => d.Meal)
         .ThenInclude(s=>s.EatWellCategory)
     .Where(c => c.ChildId == id)
     .FirstOrDefaultAsync();
            return View("ChildInfo", child);
        }
        public async Task<IActionResult> AddHealthLog(int id)
        {
            ViewBag.ChildId = id;
            var currentDay = DateTime.Now.DayOfWeek;
            var child = await this.context.Children.Include(s => s.ChildHealthLogs).Include(s => s.ChildMealLogs)
     .Include(c => c.Diets)
         .ThenInclude(d => d.Meal)
     .Where(c => c.ChildId == id)
     .FirstOrDefaultAsync();
            return View("AddHealthLog");
        }
        [HttpPost]
        public async Task<IActionResult> AddHealthLog(ChildHealthLog childHealthLog)
        {
            if (ModelState.IsValid)
            {

                this.context.Add(childHealthLog);
                await this.context.SaveChangesAsync();
                return RedirectToAction("ChildInfo", new { Id = childHealthLog.ChildId });
            }
            return View(childHealthLog);

        }
        [HttpGet]
        [Route("Carer/GetHealthLog/{id}")]
        public async Task<IActionResult> GetHealthLog(int id)
        {
            ViewBag.ChildId = id;
            var currentDay = DateTime.Now.DayOfWeek;
            var child = await this.context.Children.Include(s => s.ChildHealthLogs).Include(s => s.ChildMealLogs)
     .Include(c => c.Diets)
         .ThenInclude(d => d.Meal)
     .Where(c => c.ChildId == id)
     .FirstOrDefaultAsync();
            return Json(from s in child.ChildHealthLogs select new {height=s.Height,weight=s.Weight,date=s.Date.ToShortDateString()});
        }
        [HttpGet]
        public async Task<IActionResult> ViewShift(int id)
        {
            ViewBag.ChildId = id;
            var currentDay = DateTime.Now.DayOfWeek;
            var shifts = await this.context.Shifts.Include(c => c.Carer).Include(c => c.CarerClockHistory).Where(c => c.CarerId == id && c.From >= DateTime.Now).ToListAsync();
            return View("ViewShift", shifts);
        }

        [HttpPost]
        public async Task<IActionResult> ClockInShift(int CarerId)
        {
            var carer = await this.context.Users.Include(c => c.Shifts).Where(c => c.Id == CarerId).FirstOrDefaultAsync();
            var shift = carer.Shifts.Where(c => c.ShiftDate.Date == DateTime.Now.Date).FirstOrDefault();
            var existinClockin = await this.context.CarerClockHistories.Where(c => c.CarerId == CarerId && c.ShiftId == shift.Id).FirstOrDefaultAsync();
            
                if (existinClockin == null)
            {
                CarerClockHistory carerClockHistory = new CarerClockHistory { CarerId = CarerId, ShiftId = shift.Id, ClockIn = DateTime.Now };
                this.context.CarerClockHistories.Add(carerClockHistory);
                await this.context.SaveChangesAsync();
                return Json(new { success = true, message = $"Clocked In at {DateTime.Now.ToShortTimeString()}" });
            }
            else
            {
                return Json(new { success = false, message = "Already Clocked In" });
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> ClockOutShift(int CarerId)
        {
            var carer = await this.context.Users.Include(c => c.Shifts).Where(c => c.Id == CarerId).FirstOrDefaultAsync();
            var shift = carer.Shifts.Where(c => c.ShiftDate.Date == DateTime.Now.Date).FirstOrDefault();
            var existingClockEntry = await this.context.CarerClockHistories.Where(c => c.CarerId == CarerId && c.ShiftId == shift.Id).FirstOrDefaultAsync();
            if (existingClockEntry == null)
            {
                return Json(new { success = false, message = "Not Clocked In Today" });
            }
            if (existingClockEntry.ClockOut != null)
            {
                return Json(new { success = false, message = "Already Clocked Out" });
            }
            existingClockEntry.ClockOut = DateTime.Now;
            this.context.CarerClockHistories.Update(existingClockEntry);
            await context.SaveChangesAsync();
            return Json(new { success = true, message = $"Clocked Out At {DateTime.Now.ToShortTimeString()}" });
        }









        private List<SelectListItem> GetMealTypeLookup()
        {
            var r = new List<SelectListItem>{
    new SelectListItem("Breakfast", MealTypeId.Breakfast.ToString()),
    new SelectListItem("Lunch", MealTypeId.Lunch.ToString()),
    new SelectListItem("Dinner", MealTypeId.Dinner.ToString()),
    new SelectListItem("Snacks", MealTypeId.Snacks.ToString())
};
            return r;

        }
        private List<SelectListItem> GetWeekDaysLookUp()
        {
            var r = new List<SelectListItem>{
    new SelectListItem("Friday", WeekDay.Friday.ToString()),
                 new SelectListItem("Sunday", WeekDay.Sunday.ToString()),
    new SelectListItem("Monday", WeekDay.Monday.ToString()),
    new SelectListItem("Tuesday", WeekDay.Tuesday.ToString()),
    new SelectListItem("Wednesday", WeekDay.Wednesday.ToString()),
    new SelectListItem("Thursday", WeekDay.Thursday.ToString())
};
            return r;

        }


    }
}
