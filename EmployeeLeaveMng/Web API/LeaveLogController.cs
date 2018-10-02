using EmployeeLeaveMng.Models;
using EmployeeLeaveMng.Web_API.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeLeaveMng.Web_API
{
    public class LeaveLogController : ApiController
    {
        //create an instance of entity framework
        EmployeeLeaveManagementEntities dbContext = new EmployeeLeaveManagementEntities();

        // GET: api/LeaveLog
        public IEnumerable<string> Get()
        {     
            return new string[] { "value1", "value2" };
        }

        // GET: api/LeaveLog/5
        public string Get(int id)
        {
            return "value";
        }

        /**
         * Post method is used to request a leave by an employee
         * */
        // POST: api/LeaveLog
        public HttpResponseMessage Post([FromBody]LeaveRequest leaveRequest)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {

                try
                {
                    // post the request on server
                    dbContext.LeaveLog_RequestLeave(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId,
                                                              leaveRequest.StartLeaveOn, leaveRequest.EndLeaveOn);
                    response = Request.CreateResponse(HttpStatusCode.OK, leaveRequest);                 
                }
                catch (Exception)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, leaveRequest);
                    
                }                
            }
            return response;
        }

        // PUT: api/LeaveLog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LeaveLog/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public void GetEmployeeLeaveRequests(string employee)
        {

        }
    }
}
