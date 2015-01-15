using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository replyRepository;
        private readonly IUnitOfWork uow;

        public ReplyService(IReplyRepository replyRepository, IUnitOfWork uow)
        {
            this.replyRepository = replyRepository;
            this.uow = uow;
        }

        public IEnumerable<ReplyEntity> GetAllReplies()
        {
            return replyRepository.GetAll().Select(BllReplyMapper.ToBllReply);
        }

        public void CreateReply(ReplyEntity reply)
        {
            replyRepository.Create(reply.ToDalReply());
            uow.Commit();
        }

        public void DeleteReply(ReplyEntity reply)
        {
            replyRepository.Delete(reply.ToDalReply());
            uow.Commit();
        }
    }
}