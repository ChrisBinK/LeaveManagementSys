using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLeaveMng.Models
{ 
    /**
     * Class to contain information about a leave request
     * */
    public class LeaveRequest
    {
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartLeaveOn { get; set; }
        public DateTime EndLeaveOn { get; set; }

        /**
         * Method to calculate the number of days between StartLeaveOn and EndLeaveOn
         */
        public int GetLeaveNumberDays
        { 
             get { return (EndLeaveOn - StartLeaveOn).Days; }
        }
    }
}