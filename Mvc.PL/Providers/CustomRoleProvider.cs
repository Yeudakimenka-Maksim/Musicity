using System;
using System.Linq;
using System.Web.Security;
using BLL.Interface.Services;
using Ninject;

namespace Mvc.PL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IUserService userService;

        public CustomRoleProvider()
        {
            userService = NinjectWebCommon.GetKernel().Get<IUserService>();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = userService.GetUserByName(username);
            if (user == null)
                return false;
            return user.Roles.SingleOrDefault(role =>
                String.Equals(role.Name, roleName, StringComparison.CurrentCultureIgnoreCase)) != null;
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = userService.GetUserByName(username);
            return user == null ? null : user.Roles.Select(role => role.Name).ToArray();
        }

        #region Not Implemented

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}