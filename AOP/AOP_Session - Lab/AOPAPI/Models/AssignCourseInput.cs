using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.Models
{
    public class AssignCourseInput
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int PaidAmount { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, CourseId: {CourseId}, PaidAmount: {PaidAmount}.";
        }
    }
}