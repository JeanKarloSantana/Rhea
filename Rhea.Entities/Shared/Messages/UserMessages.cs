using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.Shared.Messages
{
    public class UserMessages
    {
        public static readonly string ValidUser = "This user is valid";
        public static readonly string UnderAge = "The user does not meet the age requirement to make reservation";
        public static readonly string NotAvailableStatus = "The user is not available to make reservation at this time";
        public static readonly string UserExist = "This user already exist";
        public static readonly string CanCreate = "This user can be created";
        public static readonly string UserCreated = "The User has been created";
    }
}
