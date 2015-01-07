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
                WriterId = dalReply.WriterId,
                Post = dalReply.Post.ToOrmPost(),
                Writer = dalReply.Writer.ToOrmUser()
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
                Post = ormReply.Post.ToDalPost(),
                Writer = ormReply.Writer.ToDalUser()
            };
        }
    }
}