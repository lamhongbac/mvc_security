using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CustomAuthentication.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            return new string[] {"User","Admin","Supper" };
        }

        /// <summary>
        /// trả ve tat cả roles của user chỉ ra, tuong ung thuoc tinh
        /// Roles= cua attribute authorize(Roles=()]
        /// this happen before authorize
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            return new string[] { "User" };

            //we can call method IsUserInRole

            //doc het cac role, duyet qua tung role va kiem tra user is in Role
            // neu thoa dieu kien thi add vao mang va return
        }
        /// <summary>
        /// tra ve danh sach user co rolename
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// that this happens "after" a user is authenticated and hence there is no need for a password. 
        /// If this step fails, a value of false is returned indicating that the user does not belong to this role. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "test" && roleName == "User")
            {
                return true;
            }
            else
                return false;
        }
        public ObjectRight IsRoleHaveRightToDo(string objectName,string roleName)
        {
            return GetRightForRole(roleName, objectName);
        }

        private ObjectRight GetRightForRole(string roleName, string objectName)
        {
            ObjectRight right = new ObjectRight();
            if (roleName=="user" && objectName=="demo")
            {
                right.CanRead = true;
                right.CanEdit = true;
                right.CanAdd = true;
                right.CanDelet = false;
            }
            else
            {
                right.CanRead = true;
                right.CanEdit = false;
                right.CanAdd = false;
                right.CanDelet = false;
            }
            return right;
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
    public class ObjectRight
    {
        public bool CanRead { get; set; }
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelet { get; set; }
    }
}