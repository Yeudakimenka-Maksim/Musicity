using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IReplyService
    {
        IEnumerable<ReplyEntity> GetAllReplies();
        void CreateReply(ReplyEntity reply);
        void DeleteReply(ReplyEntity reply);
    }
}