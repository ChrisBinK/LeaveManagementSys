//------------------------------------------------------------------------------
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
    
    public partial class Employee_GetEmployee_Result
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> StartDateEmployment { get; set; }
        public Nullable<System.DateTime> EndDateEmployment { get; set; }
        public string PicturePath { get; set; }
        public Nullable<System.DateTime> SignUpOn { get; set; }
        public Nullable<System.DateTime> LoggedOn { get; set; }
        public int LevelID { get; set; }
        public string LevelDesciprtion { get; set; }
        public Nullable<int> AllotedVacation { get; set; }
        public int JobTitleId { get; set; }
        public string TitleDecription { get; set; }
        public string Address { get; set; }
    }
}
