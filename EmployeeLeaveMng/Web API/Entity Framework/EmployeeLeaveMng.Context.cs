﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeLeaveMng.Web_API.Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeLeaveManagementEntities : DbContext
    {
        public EmployeeLeaveManagementEntities()
            : base("name=EmployeeLeaveManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<LeaveType_GetAll_Result> LeaveType_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeaveType_GetAll_Result>("LeaveType_GetAll");
        }
    
        public virtual int Employee_InsertEmployee(string employeeId)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Employee_InsertEmployee", employeeIdParameter);
        }
    
        public virtual ObjectResult<Employee_GetEmployee_Result> Employee_GetEmployee(string employeeID)
        {
            var employeeIDParameter = employeeID != null ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_GetEmployee_Result>("Employee_GetEmployee", employeeIDParameter);
        }
    
        public virtual int Employee_UpdateEmployee(string employeeId, string firstName, string lastName, string middleName, string address, string picturePath, Nullable<int> jobTitleId, Nullable<int> levelId, Nullable<System.DateTime> startEmploymentOn, Nullable<System.DateTime> endDateEmployment)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var picturePathParameter = picturePath != null ?
                new ObjectParameter("picturePath", picturePath) :
                new ObjectParameter("picturePath", typeof(string));
    
            var jobTitleIdParameter = jobTitleId.HasValue ?
                new ObjectParameter("JobTitleId", jobTitleId) :
                new ObjectParameter("JobTitleId", typeof(int));
    
            var levelIdParameter = levelId.HasValue ?
                new ObjectParameter("levelId", levelId) :
                new ObjectParameter("levelId", typeof(int));
    
            var startEmploymentOnParameter = startEmploymentOn.HasValue ?
                new ObjectParameter("startEmploymentOn", startEmploymentOn) :
                new ObjectParameter("startEmploymentOn", typeof(System.DateTime));
    
            var endDateEmploymentParameter = endDateEmployment.HasValue ?
                new ObjectParameter("EndDateEmployment", endDateEmployment) :
                new ObjectParameter("EndDateEmployment", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Employee_UpdateEmployee", employeeIdParameter, firstNameParameter, lastNameParameter, middleNameParameter, addressParameter, picturePathParameter, jobTitleIdParameter, levelIdParameter, startEmploymentOnParameter, endDateEmploymentParameter);
        }
    
        public virtual ObjectResult<employeeLevel_GetAll_Result> employeeLevel_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<employeeLevel_GetAll_Result>("employeeLevel_GetAll");
        }
    
        public virtual ObjectResult<JobTitle_GetAll_Result> JobTitle_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<JobTitle_GetAll_Result>("JobTitle_GetAll");
        }
    
        public virtual int LeaveLog_RequestLeave(string employeeID, Nullable<int> leaveTypeID, Nullable<System.DateTime> startLeaveOn, Nullable<System.DateTime> endLeaveOn)
        {
            var employeeIDParameter = employeeID != null ?
                new ObjectParameter("employeeID", employeeID) :
                new ObjectParameter("employeeID", typeof(string));
    
            var leaveTypeIDParameter = leaveTypeID.HasValue ?
                new ObjectParameter("leaveTypeID", leaveTypeID) :
                new ObjectParameter("leaveTypeID", typeof(int));
    
            var startLeaveOnParameter = startLeaveOn.HasValue ?
                new ObjectParameter("startLeaveOn", startLeaveOn) :
                new ObjectParameter("startLeaveOn", typeof(System.DateTime));
    
            var endLeaveOnParameter = endLeaveOn.HasValue ?
                new ObjectParameter("endLeaveOn", endLeaveOn) :
                new ObjectParameter("endLeaveOn", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LeaveLog_RequestLeave", employeeIDParameter, leaveTypeIDParameter, startLeaveOnParameter, endLeaveOnParameter);
        }
    
        public virtual ObjectResult<LeaveLog_GetLeavePerEmployee_Result> LeaveLog_GetLeavePerEmployee(string employeeId)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("employeeId", employeeId) :
                new ObjectParameter("employeeId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeaveLog_GetLeavePerEmployee_Result>("LeaveLog_GetLeavePerEmployee", employeeIdParameter);
        }
    
        public virtual ObjectResult<LeaveLog_GetLeaveSummaryPerEmployee_Result> LeaveLog_GetLeaveSummaryPerEmployee(string employeeId)
        {
            var employeeIdParameter = employeeId != null ?
                new ObjectParameter("employeeId", employeeId) :
                new ObjectParameter("employeeId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LeaveLog_GetLeaveSummaryPerEmployee_Result>("LeaveLog_GetLeaveSummaryPerEmployee", employeeIdParameter);
        }
    }
}
