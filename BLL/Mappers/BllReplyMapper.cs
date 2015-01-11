using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllReplyMapper
    {
        public static DalReply ToDalReply(this ReplyEntity replyEntity)
        {
            return new DalReply
            {
                Id = replyEntity.Id,
                WrittenTime = replyEntity.WrittenTime,
                IsSubject = replyEntity.IsSubject,
                Content = replyEntity.Content,
                PostId = replyEntity.PostId,
                WriterId = replyEntity.WriterId
            };
        }

        public static ReplyEntity ToBllReply(this DalReply dalReply)
        {
            return new ReplyEntity
            {
                Id = dalReply.Id,
                WrittenTime = dalReply.WrittenTime,
                IsSubject = dalReply.IsSubject,
                Content = dalReply.Content,
                PostId = dalReply.PostId,
                WriterId = dalReply.WriterId
            };
        }
    }
}