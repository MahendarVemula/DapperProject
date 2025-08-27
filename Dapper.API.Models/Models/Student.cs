using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Models.Models
{
    public class Student
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
