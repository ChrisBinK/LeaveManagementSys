using EmployeeLeaveMng.Web_API.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeLeaveMng.Web_API
{
    public class LeaveTypeController : ApiController
    {

        //create an instance of entity framework
        EmployeeLeaveManagementEntities dbContext = new EmployeeLeaveManagementEntities();

        // GET api/<controller>
        public IEnumerable<LeaveType_GetAll_Result> Get()
        {
            List<LeaveType_GetAll_Result> leaveTypes = dbContext.LeaveType_GetAll().ToList();
            return leaveTypes;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}