using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllUserMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Password = userEntity.Password,
                DateOfBirth = userEntity.DateOfBirth,
                JoinDate = userEntity.JoinDate,
                LastActivity = userEntity.LastActivity,
                Location = userEntity.Location,
                IsOnline = userEntity.IsOnline,
                //Replies = (ICollection<DalReply>) userEntity.Replies.Select(r => r.ToDalReply()),
                //Posts = (ICollection<DalPost>) userEntity.Posts.Select(p => p.ToDalPost()),
                //Roles = (ICollection<DalRole>) userEntity.Roles.Select(r => r.ToDalRole())
                //
                //
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            return new UserEntity
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Password = dalUser.Password,
                DateOfBirth = dalUser.DateOfBirth,
                JoinDate = dalUser.JoinDate,
                LastActivity = dalUser.LastActivity,
                Location = dalUser.Location,
                IsOnline = dalUser.IsOnline,
                Categories = dalUser.Categories.Select(c => c.ToBllCategory()).ToList(),
                Topics = dalUser.Topics.Select(t => t.ToBllTopic()).ToList(),
                Posts = dalUser.Posts.Select(p => p.ToBllPost()).ToList(),
                Replies = dalUser.Replies.Select(r => r.ToBllReply()).ToList(),
                Roles = dalUser.Roles.Select(r => r.ToBllRole()).ToList()
            };
        }
    }
}