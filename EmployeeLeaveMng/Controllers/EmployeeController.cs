using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;
using EmployeeLeaveMng.Models;
using EmployeeLeaveMng.Web_API.Entity_Framework;

namespace EmployeeLeaveMng.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        //create an instance of entity framework
        EmployeeLeaveManagementEntities dbContext = new EmployeeLeaveManagementEntities();

        /**
         * View to display the calendar where user can request a leave
         * */
        // GET: Employee
        public ActionResult Index()
        {

            var  user = (Employee_GetEmployee_Result) dbContext.Employee_GetEmployee(User.Identity.GetUserId()).FirstOrDefault();
            ViewBag.userId =  user.EmployeeID;
            ViewBag.ImagePath = user.PicturePath;
            ViewBag.Name = user.MiddleName + " " + user.LastName;
            ViewBag.Position = user.LevelDesciprtion + " " + user.TitleDecription;
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            // return an employee details
            var user = (Employee_GetEmployee_Result)dbContext.Employee_GetEmployee(User.Identity.GetUserId()).FirstOrDefault();
            return View(user);
        }
 
        // GET: Employee/Edit/5
        public ActionResult Edit(string id = "")
        {
             var  user = (Employee_GetEmployee_Result) dbContext.Employee_GetEmployee(User.Identity.GetUserId()).FirstOrDefault();
            return View(user);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit( Employee_GetEmployee_Result employee)
        {
            if (ModelState.IsValid)
            {
                // check if  the file uploaded is not an image 
                if (this.checkExtension(Request.Files["userImg"]) == false)
                {
                    //display the error message to the user
                    ModelState.AddModelError("", "The file uploaded is not accepted. only image file Please");
                    return View(employee);
                }
               
                employee.EmployeeID = User.Identity.GetUserId();
                employee.PicturePath = this.saveImage(employee.EmployeeID, Request.Files["userImg"]);
                // update in the db
                dbContext.Employee_UpdateEmployee(employee.EmployeeID, employee.FirstName, employee.LastName, employee.MiddleName, employee.Address,employee.PicturePath,employee.JobTitleId,employee.LevelID ,null, null);
                return RedirectToAction("Index");
            }
            return View(employee);
           
        }


        /*
         * Mehtod to display a leave report Per Employee
         * */
        public ActionResult GetLeaveHistory(string id)
        {
            var requestLeaves = dbContext.LeaveLog_GetLeavePerEmployee(id).ToList();
            return View(requestLeaves);
        }

        [HttpPost]
        public ActionResult GetLeaveHistory(string id, string  type )
        {
            List<LeaveLog_GetLeavePerEmployee_Result> result = null;
            var requestLeaves = dbContext.LeaveLog_GetLeavePerEmployee(id);
            //when the button selected is  all return all leave request the user has ever made
            switch (type)
            {
                case "all":
                    // retrieve all the  reuest leave that an employee has ever made
                    result = (from employee in requestLeaves
                              orderby employee.LeaveRequestedOn
                              select employee).ToList();
                    break;
                case "approved":
                    // retrieve only approved request leave  for an employee
                    result = (from employee in requestLeaves
                              where employee.LeaveApproved == true
                              orderby employee.LeaveRequestedOn
                              select employee).ToList();
                    break;
                case "rejected":
                    // retrieve all rejected request leave of the employee
                    result = (from employee in requestLeaves
                                              where employee.LeaveApproved == false
                                              select employee).ToList();
                    break;

                default:
                    //retrieve all request leave of the employee that the admistrator has not attended
                    result = (from employee in requestLeaves
                                              where employee.LeaveApproved == null
                                              select employee).ToList();
                    break;

            }

            return View(result);
        }
      
       public ActionResult LeaveSummary(string id)
       {
            // get the allocated  vacation of an employee
            var employee = dbContext.Employee_GetEmployee(id).FirstOrDefault();
            ViewBag.AllotedVacation = employee.AllotedVacation;

            // get the report 
            var summary = dbContext.LeaveLog_GetLeaveSummaryPerEmployee(id).ToList();

            return View(summary);
       }

        //*********************************************************************************
        //utility method to save a picture in the folder Image and return the image path
        [NonAction]
        public String saveImage(string userId, HttpPostedFileBase file)
        {
            string userImagePath = null;
           
                //default image for user
                userImagePath = GlobalVariable.IMAGE_DIR + "/noimage.png";

                // create a file  name apppended with the userId
                var userFileName = userId + "_" + file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    //get the path of the server where the image will be saved
                    // var uri = new Uri(GlobalVariable.IMAGE_DIR,);
                    var imagePath = Path.Combine(Server.MapPath(GlobalVariable.IMAGE_DIR), userFileName);
                    userImagePath = Path.Combine(GlobalVariable.IMAGE_DIR, userFileName);

                    try
                    {
                        // save the file on server in Image folder
                        file.SaveAs(imagePath);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
           
            

            return userImagePath;
        }

        //Utility method to check if the file extension is accepted
        [NonAction]
        public bool checkExtension(HttpPostedFileBase file)
        {
            // set a list of accepted extention
            var acceptedExtension = new[] { ".jpeg", ".png", "jpg" };
            // get the file extension
            var uploadedFileExtension = Path.GetExtension(file.FileName).ToLower();
            if (acceptedExtension.Contains(uploadedFileExtension) == true)
            {
                return true;
            }
            return false;
        }
    }
}
