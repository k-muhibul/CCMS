using Child_Care_Mangement_System.Data;
using Child_Care_Mangement_System.Models;
using Child_Care_Mangement_System.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Controllers
{
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly StripeSettings stripeSettings;
        public ParentController(ApplicationDbContext context, UserManager<User> userManager, IOptions<StripeSettings> stripeSettings)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.stripeSettings = stripeSettings.Value ?? throw new ArgumentNullException(nameof(stripeSettings));
        }
        public async Task<IActionResult> Index()
        {
            var child = await this.context.Children.Include(c => c.CareCategory).Include(c => c.Parent).Where(c => c.Parent == this.userManager.GetUserAsync(User).Result).ToListAsync();

            return View("ParentDashboard");
        }
        [HttpGet]

        public async Task<IActionResult> EditParent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await this.context.Users.FindAsync(id);
            var parentVM = new UserViewModel();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(parent), parentVM);
            if (parent == null)
            {
                return NotFound();
            }

            return View("EditParent", parentVM);
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParent(int id, UserViewModel parent)
        {
            var user = await this.context.Users.FindAsync(id);
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(parent), user);

            if (ModelState.IsValid)
            {
                try
                {
                    user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, parent.Password);
                    this.context.Update(user);
                    await this.context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var r = ex;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(parent);
        }
        public IActionResult AddChild()
        {
            ViewData["ParentId"] = new SelectList(this.context.Users, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddChild(Child child)
        {
            if (ModelState.IsValid)
            {

                this.context.Add(child);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(this.context.Users, "Id", "Id", child.ParentId);
            return View(child);
        }
        [HttpGet]
        public async Task<IActionResult> EditChild(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await this.context.Children.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditChild(int ChildId, Child child)
        {
            if (ChildId != child.ChildId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingChild = await this.context.Children.FindAsync(ChildId);
                existingChild.FirstName = child.FirstName;
                existingChild.LastName = child.LastName;
                existingChild.Name = $"{child.FirstName} {child.LastName}";
                existingChild.DOB = child.DOB;
                existingChild.Gender = child.Gender;
                try
                {
                    this.context.Update(existingChild);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(child);
        }
        public async Task<IActionResult> DeleteChild(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await context.Children
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.ChildId == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("DeleteChild")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChildConfirmed(int ChildId)
        {
            var child = await context.Children.FindAsync(ChildId);
            context.Children.Remove(child);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ClockOutChild(int ChildId)
        {
            var child = await this.context.Children.Include(c => c.ChildClockHistories).Where(c => c.ChildId == ChildId).FirstOrDefaultAsync();
            var existingClockEntry = child.ChildClockHistories.Where(c => c.ClockIn.Day == DateTime.Now.Day && c.ClockIn.Month == DateTime.Now.Month && c.ClockIn.Year == DateTime.Now.Year).FirstOrDefault();
            if (existingClockEntry == null)
            {
                return Json(new { success = false, message = "Child is not clocked In Today" });
            }
            if (existingClockEntry.ClockOut != null)
            {
                return Json(new { success = false, message = "Already Clocked Out" });
            }
            existingClockEntry.ClockOut = DateTime.Now;
            this.context.ChildClockHistories.Update(existingClockEntry);
            await context.SaveChangesAsync();
            return Json(new { success = true, message = "Clock Out Successful" });
        }

        [HttpGet]
        public async Task<IActionResult> BillIndex(int? id)
        {
            var bills = await this.context.Bills.Include(c => c.Child).Include(c => c.ChildClockHistories).Where(s => s.UserId == id).ToListAsync();


            return View("BillIndex", bills);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsBill(int? id)
        {
            
            var history = await this.context.ChildClockHistories.Include(c => c.Bill).Include(c => c.Child).Where(c => c.BillId == id).ToListAsync();
            return View("DetailsBill", history);
        }


        [HttpGet]
        [Route("Parent/UpdatePayment/{userId}/Bill/{billId}")]
        public IActionResult UpdatePaymentHistory(int userId,int billId)
        {
            var bill = this.context.Bills.Where(c => c.BillId == billId).FirstOrDefault();
            bill.Status = BillStatus.Paid;
            this.context.Update(bill);
            this.context.SaveChanges();
            if(bill.PaymentHistoryId==null)
            {
                var payment = new PaymentHistory { BillId = billId, ParentId = userId, ChildId = bill.ChildId, Date = DateTime.Now };
                this.context.Add(payment);
                this.context.SaveChanges();
                bill.Status = BillStatus.Paid;
                bill.PaymentHistoryId = payment.PaymentHistoryId;
                this.context.Update(bill);
                this.context.SaveChanges();

            }
            return RedirectToAction("BillIndex", new { Id = userId });
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession(double amount, int userId, int billId)
        {
            var currency = "gbp";
            var successUrl = $"https://localhost:44383/Parent/UpdatePayment/{userId}/Bill/{billId}";
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            var options = new SessionCreateOptions
            {
                
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData=new SessionLineItemPriceDataOptions
                        {
                            Currency=currency,
                            UnitAmount=(long)amount*100,
                            ProductData= new SessionLineItemPriceDataProductDataOptions
                            {
                                Name="Monthly Bill",
                                Description=$"Monthly Bill for Bill ID: {billId}"
                            }
                        },
                        Quantity=1
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                
            };
            var service = new SessionService();
            try
            {
                var session = service.Create(options);

                if (session.Url != null)
                {
                    return Redirect(session.Url);
                }
                else
                {
                    
                    return RedirectToAction("ErrorView");
                }
            }
            catch (StripeException ex)
            {
               
                return RedirectToAction("StripeErrorView");
            }
            catch (Exception ex)
            {

                return RedirectToAction("GeneralErrorView");
            }


        }










        private (int AgeInMonth, CareCategoryType type) DetermineChildCategory(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int ageInMonths = (currentDate.Year - birthDate.Year) * 12 + (currentDate.Month - birthDate.Month);

            if (ageInMonths <= 18)
            {
                return(ageInMonths, CareCategoryType.Infant);
            }
            else if (ageInMonths > 18 && ageInMonths <= 36)
            {
                return (ageInMonths, CareCategoryType.Toddler);
            }
            else if (ageInMonths > 36 && ageInMonths <= 60)
            {
                return (ageInMonths, CareCategoryType.PreSchool);
            }
            else
            {
                return  (ageInMonths, CareCategoryType.Unknown);
            }
        }

    }
}
