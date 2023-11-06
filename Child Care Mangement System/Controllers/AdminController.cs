using Child_Care_Mangement_System.Data;
using Child_Care_Mangement_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public AdminController(ApplicationDbContext context,UserManager<User> userManager)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public IActionResult Index()
        {
            return View("AdminDashboard");
        }
        public async Task<IActionResult> ManageCarer()
        {
            var carerList = await (from u in this.context.Users
                                   join ur in this.context.UserRoles on u.Id equals ur.UserId
                                   join r in this.context.Roles on ur.RoleId equals r.Id where r.Name == "Carer" select u).ToListAsync();
            return View("ManageCarer", carerList);
        }
        public IActionResult CreateCarer()
        {
            
            return View("CreateCarer");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCarer(User user)
        {
            user.UserName = user.Email;
            if (ModelState.IsValid)
            {
                var result = await this.userManager.CreateAsync(user, user.PasswordHash);
                if(result.Succeeded)
                {
                    await this.userManager.AddToRoleAsync(user, "Carer");
                    return RedirectToAction(nameof(ManageCarer));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
               
            }
            return View(user);
        }
        public async Task<IActionResult> CarerDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await this.context.Users.FindAsync(id);

            return View(user);
        }
        [HttpGet]
     
        public async Task<IActionResult> EditCarer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carer = await this.context.Users.FindAsync(id);
            if (carer == null)
            {
                return NotFound();
            }
           
            return View("EditCarer",carer);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCarer(int id,User carer)
        {
            var user = await this.context.Users.FindAsync(id);
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(carer), user);

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(user);
                    await this.context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var r = ex;
                    
                }
                return RedirectToAction(nameof(ManageCarer));
            }
            return View(carer);
        }
        public async Task<IActionResult> DeleteCarer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("DeleteCarer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageCarer));
        }
        [HttpGet]
        [Route("Admin/ScheduleCarer")]
        [Route("Admin/ScheduleCarer/{selectedDate}")]
        public async Task<IActionResult> ScheduleCarer(DateTime? selectedDate)
        {
            if(selectedDate.HasValue)
            {
                ViewBag.selectedDate = selectedDate;
                var carerList= await this.context.SetAvilabilities.Include(c => c.Carer).Where(c => c.Date == selectedDate).ToListAsync();
                ViewBag.availableCarer = carerList;
                ViewBag.carerLookup = from s in carerList select new SelectListItem { Text = s.Carer.FirstName, Value = s.CarerId.ToString() };
            }
            else
            {
                selectedDate = DateTime.Now.Date;
                ViewBag.selectedDate = selectedDate;
                var carerList = await this.context.SetAvilabilities.Include(c => c.Carer).Where(c => c.Date == selectedDate).ToListAsync();
                ViewBag.availableCarer = carerList;
                ViewBag.carerLookup = from s in carerList select new SelectListItem { Text = s.Carer.FirstName, Value = s.CarerId.ToString() };
            }
            
            
            return View("ScheduleCarer");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSchedule(Shift shift)
        {
            if (ModelState.IsValid)
            {
                shift.From = shift.ShiftDate.Date + shift.From.TimeOfDay;
                shift.To = shift.ShiftDate.Date + shift.To.TimeOfDay;
                this.context.Add(shift);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(ScheduleCarer));
              

            }
            return View(shift);
            

        }




    }
}
