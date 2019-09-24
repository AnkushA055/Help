using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorOrder.Entities
{
    /// <summary>
    /// Interface for Salesman Entity
    /// </summary>
    public interface ISalesman
    {
        Guid SalesmanID { get; set; }
        string SalesmanName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }

    /// <summary>
    /// Represents SystemUser
    /// </summary>
    public class Salesman : ISalesman
    {
        /* Auto-Implemented Properties */
        [Required("SystemUser ID can't be blank.")]
        public Guid SalesmanID { get; set; }

        [Required("SystemUser Name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "SystemUser Name should contain only 2 to 40 characters.")]
        public string SalesmanName { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string Email { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public Salesman()
        {
            SalesmanID = default(Guid);
            SalesmanName = null;
            Email = null;
            Password = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}