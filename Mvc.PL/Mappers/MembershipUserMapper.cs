using System;
using System.Web.Security;
using BLL.Interface.Entities;

namespace Mvc.PL.Mappers
{
    public static class MembershipUserMapper
    {
        public static MembershipUser ToMembershipUser(this UserEntity userEntity)
        {
            if (userEntity == null)
                return null;
            return new MembershipUser("CustomMembershipProvider", userEntity.Name, null, null, null, null, false,
                false, userEntity.JoinDate, DateTime.MinValue, userEntity.LastActivity, DateTime.MinValue,
                DateTime.MinValue);
        }
    }
}