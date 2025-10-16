using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using AppTroveV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace AppTroveV1.Controllers
{
    public class HelloWorldController : Controller
    {
        
        
        private App2Context context { get; set; }
        public HelloWorldController(App2Context ctx)
        {
            context = ctx;
        }


        public IActionResult Index(string searchText = "")
        {
            var apps = new List<App>();
            if(searchText != "" && searchText != null)
            {
                apps = context.Apps
                    .Where(p => p.Name.Contains(searchText)).OrderBy(m => m.Name).ToList();
            }
            else
            {
                apps = context.Apps.OrderBy(m => m.Name).ToList();
            }
            
            
            return View(apps);
        }

        /*
        public IActionResult Search()
        {
            var apps = context.Apps.
        }*/

        [Authorize]
        public IActionResult Edit(App app)
        {
            if (ModelState.IsValid)
            {
                if (app.AppId == 0)
                {
                    context.Apps.Add(app);
                }
                else
                {
                    context.Apps.Update(app);
                }
                    context.SaveChanges();
                    return RedirectToAction("Index", "HelloWorld");
            } else
            {
                ViewBag.Action = (app.AppId == 0) ? "Add" : "Edit";
                return View("Create",app);
            }
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if(username=="KelseyR" && password == "Turtle")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, "Kelsey"));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Error: username/password invalid";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        
    }
}
