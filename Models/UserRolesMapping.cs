using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
    public class UserRolesMapping
    {
        #region ORM
        public int UserRolesMappingId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        #endregion

        public UserRolesMapping()
        {  }

        public UserRolesMapping(string userName, string roleId)
        {
            UserName = userName;
            RoleId = roleId;
        }
    }
}