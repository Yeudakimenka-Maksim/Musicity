using System;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using Mvc.PL.Mappers;

namespace Mvc.PL.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public CustomMembershipProvider()
        {
            roleService = System.Web.Mvc.DependencyResolver.Current.GetService<IRoleService>();
            userService = System.Web.Mvc.DependencyResolver.Current.GetService<IUserService>();
        }

        public MembershipUser CreateUser(string name, string password, DateTime? dateOfBirth, DateTime joinDate,
            DateTime lastActivity, string location, bool isOnline)
        {
            if (GetUser(name, false) != null)
                return null;

            userService.CreateUser(new UserEntity
            {
                Name = name,
                Password = password,
                DateOfBirth = dateOfBirth,
                JoinDate = joinDate,
                LastActivity = lastActivity,
                Location = location,
                IsOnline = isOnline,
                Roles = new[] { roleService.GetRoleByName("Reader") }
            });

            return GetUser(name, false);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return userService.GetUserByName(username).ToMembershipUser();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = userService.GetUserByName(username);
            return user != null && Crypto.VerifyHashedPassword(user.Password, password);
        }

        #region Not Implemented

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey,
            out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}