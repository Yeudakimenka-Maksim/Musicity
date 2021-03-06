﻿using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork uow;

        public PostService(IPostRepository postRepository, IUnitOfWork uow)
        {
            this.postRepository = postRepository;
            this.uow = uow;
        }

        public IEnumerable<PostEntity> GetAllPosts()
        {
            return postRepository.GetAll().Select(BllPostMapper.ToBllPost);
        }

        public PostEntity GetPostById(int id)
        {
            return postRepository.GetById(id).ToBllPost();
        }

        public PostEntity GetPostByName(string name)
        {
            return postRepository.GetByName(name).ToBllPost();
        }

        public void CreatePost(PostEntity post)
        {
            postRepository.Create(post.ToDalPost());
            uow.Commit();
        }

        public void UpdatePost(PostEntity post)
        {
            postRepository.Update(post.ToDalPost());
            uow.Commit();
        }

        public void DeletePost(PostEntity post)
        {
            postRepository.Delete(post.ToDalPost());
            uow.Commit();
        }
    }
}