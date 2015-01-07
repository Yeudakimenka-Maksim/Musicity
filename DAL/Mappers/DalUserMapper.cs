using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Password = dalUser.Password,
                DateOfBirth = dalUser.DateOfBirth,
                JoinDate = dalUser.JoinDate,
                LastActivity = dalUser.LastActivity,
                Location = dalUser.Location,
                IsOnline = dalUser.IsOnline,
                Categories = dalUser.Categories.Select(c => c.ToOrmCategory()).ToList(),
                Topics = dalUser.Topics.Select(t => t.ToOrmTopic()).ToList(),
                Posts = dalUser.Posts.Select(p => p.ToOrmPost()).ToList(),
                Replies = dalUser.Replies.Select(r => r.ToOrmReply()).ToList(),
                Roles = dalUser.Roles.Select(r => r.ToOrmRole()).ToList()
            };
        }

        public static DalUser ToDalUser(this User ormUser)
        {
            return new DalUser
            {
                Id = ormUser.Id,
                Name = ormUser.Name,
                Password = ormUser.Password,
                DateOfBirth = ormUser.DateOfBirth,
                JoinDate = ormUser.JoinDate,
                LastActivity = ormUser.LastActivity,
                Location = ormUser.Location,
                IsOnline = ormUser.IsOnline,
                Categories = ormUser.Categories.Select(c => c.ToDalCategory()).ToList(),
                Topics = ormUser.Topics.Select(t => t.ToDalTopic()).ToList(),
                Posts = ormUser.Posts.Select(p => p.ToDalPost()).ToList(),
                Replies = ormUser.Replies.Select(r => r.ToDalReply()).ToList(),
                Roles = ormUser.Roles.Select(r => r.ToDalRole()).ToList()
            };
        }
    }
}