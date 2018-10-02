using EmployeeLeaveMng.Web_API.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeLeaveMng.Web_API
{
    public class JobTitleController : ApiController
    {

        //create an instance of entity framework
        EmployeeLeaveManagementEntities dbContext = new EmployeeLeaveManagementEntities();

        // GET: api/JobTitle
        public IEnumerable<JobTitle_GetAll_Result> Get()
        {
            var jobTitles = dbContext.JobTitle_GetAll().ToList();
            return jobTitles;
        }

        // GET: api/JobTitle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobTitle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JobTitle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobTitle/5
        public void Delete(int id)
        {
        }
    }
}
