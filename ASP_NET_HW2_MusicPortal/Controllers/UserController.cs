using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ASP_NET_HW2_MusicPortal.Models;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.BLL.Infrastructure;

namespace ASP_NET_HW2_MusicPortal.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService rep)
        {
            this.userService = rep;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDTO log)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDTO user = userService.GetUser(log.Login);
                    string salt = user.Salt;
                    byte[] password = Encoding.Unicode.GetBytes(salt + log.Password); 
                    MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider(); 
                    byte[] byteHash = CSP.ComputeHash(password);
                    StringBuilder hash = new StringBuilder(byteHash.Length);
                    for (int i = 0; i < byteHash.Length; i++)
                        hash.Append(string.Format("{0:X2}", byteHash[i]));

                    if (user.Password != hash.ToString())
                    {
                        ModelState.AddModelError("", "Wrong login or password!");
                        return View(log);
                    }
                    Session["idUser"] = user.Id;
                    Session["login"] = user.Name;
                    Session["role"] = user.Role;
                    Session["status"] = user.Status;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(log);
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            Session["role"] = null;
            Session["status"] = null;
            Session["idUser"] = null;
            return RedirectToAction("Index","Home");
        }
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Name, string Login, string Password)
        {
            try
            {
                List<UserDTO> usersCheck = userService.GetUsers().ToList();
                UserDTO newUser = new UserDTO();
                newUser.Name = Name;
                newUser.Login = Login;
                if (usersCheck.Count == 0)
                {
                    newUser.Status = "1";
                    newUser.Role = "admin";
                }
                else
                {
                    newUser.Status = "0";
                    newUser.Role = "user";
                }
              
                byte[] saltbuf = new byte[16];              
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(saltbuf);
                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();
                byte[] password = Encoding.Unicode.GetBytes(salt + Password);      
                MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
                byte[] byteHash = CSP.ComputeHash(password);
                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                newUser.Password = hash.ToString();
                newUser.Salt = salt;
                userService.CreateUser(newUser);
                
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            UserDTO tmp = userService.GetUser(id);

            ViewBag.userEditStatus = tmp.Status;
            ViewBag.userEditRole = tmp.Role;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string status, string role)
        {
           
                UserDTO user = userService.GetUser(id);
                user.Role = role;
                user.Status = status;
                userService.UpdateUser(user);
                return RedirectToAction("Index");           
        }

        public ActionResult Delete(int id)
        {
            UserDTO userDelete = userService.GetUser(id);
            return View(userDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
