using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
namespace AirportTracker.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public decimal milage { get; set; }
        public bool employed { get; set; } = false;

        public User() {}
        public User( string fName, string lName, decimal milage)
        {
            this.fName = fName;
            this.lName = lName;
            this.milage = milage;
        }


        public bool isEmployed()
        {
            return employed;
        }

        [NotMapped]
        public IList<string> Rolename { get; set; } = null;
    }
}