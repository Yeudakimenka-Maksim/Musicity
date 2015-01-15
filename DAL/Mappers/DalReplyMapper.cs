using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalReplyMapper
    {
        public static Reply ToOrmReply(this DalReply dalReply)
        {
            return new Reply
            {
                Id = dalReply.Id,
                WrittenTime = dalReply.WrittenTime,
                IsSubject = dalReply.IsSubject,
                Content = dalReply.Content,
                PostId = dalReply.PostId,
                WriterId = dalReply.WriterId
            };
        }

        public static DalReply ToDalReply(this Reply ormReply)
        {
            return new DalReply
            {
                Id = ormReply.Id,
                WrittenTime = ormReply.WrittenTime,
                IsSubject = ormReply.IsSubject,
                Content = ormReply.Content,
                PostId = ormReply.PostId,
                WriterId = ormReply.WriterId,
                Post = new DalPost
                {
                    Id = ormReply.Post.Id,
                    Name = ormReply.Post.Name,
                    Description = ormReply.Post.Description,
                    CreationTime = ormReply.Post.CreationTime
                },
                Writer = new DalUser
                {
                    Id = ormReply.Writer.Id,
                    Name = ormReply.Writer.Name,
                    DateOfBirth = ormReply.Writer.DateOfBirth,
                    JoinDate = ormReply.Writer.JoinDate,
                    LastActivity = ormReply.Writer.LastActivity,
                    Location = ormReply.Writer.Location,
                    IsOnline = ormReply.Writer.IsOnline
                }
            };
        }
    }
}