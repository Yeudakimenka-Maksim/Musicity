﻿using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IPostService
    {
        IEnumerable<PostEntity> GetAllPosts();
        PostEntity GetPostByName(string name);
        void CreatePost(PostEntity post);
    }
}