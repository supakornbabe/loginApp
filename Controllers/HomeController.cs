using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using loginApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace loginApp.Controllers {
    public class HomeController : Controller {
        MyProjectContext db = new MyProjectContext ();
        public IActionResult Index () {
            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register () {
            return View ();
        }

        [HttpPost]
        public async Task<ActionResult> Register (UserModel model) {
            model.password = getHash (model.password);
            db.User.Add (model);
            await db.SaveChangesAsync ();
            return RedirectToAction ("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login (UserDTO model) {
            var username = model.username;
            var password = model.password;

            var userFromDB = await db.User.FindAsync (username);
            // return userFromDB.password;
            Console.Out.WriteLine (getHash (password));
            if (userFromDB == null) {
                return RedirectToAction ("Index");
            }
            if (userFromDB.password == getHash (password)) {
                // return $"Welcome: {userFromDB.name}";
                // @todo #1 Display Name in Login View
                return View (model.name);
            } else {
                
                // return "Invalid Password";
                return RedirectToAction ("Index");
            }
        }

        private static string getHash (string text) {
            // SHA256 is disposable by inheritance.  
            using (var sha256 = SHA256.Create ()) {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash (Encoding.UTF8.GetBytes ("hello world"));
                // Get the hashed string.  
                var hash = BitConverter.ToString (hashedBytes).Replace ("-", "").ToLower ();
                // Print the string.   
                // Console.WriteLine (hash);
                return hash;
            }
        }
    }
}