using EmployeeLeaveMng.Web_API.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeLeaveMng.Web_API
{
    public class EmployeeLevelController : ApiController
    {

        //create an instance of entity framework
        EmployeeLeaveManagementEntities dbContext = new EmployeeLeaveManagementEntities();

        // GET: api/EmployeeLevel
        public IEnumerable<employeeLevel_GetAll_Result> Get()
        {
            var levels = dbContext.employeeLevel_GetAll().ToList();

            return levels;
        }

        // GET: api/EmployeeLevel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmployeeLevel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EmployeeLevel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeLevel/5
        public void Delete(int id)
        {
        }
    }
}
