using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
//MVCSecurityDiscussion.Models.customRoleProvider

namespace MVCSecurityDiscussion.Models
{
    public class MSARoleProvider : RoleProvider
    {
        public override string ApplicationName { get => "Demo custom MVC security"; set => ApplicationName= value; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "test")
            {
                return new string[] { "admin" };
            }
            else
            {
                return new string[] { "user" };
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "test" && roleName == "admin")
            {
                return true;
            }
            else
                return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}