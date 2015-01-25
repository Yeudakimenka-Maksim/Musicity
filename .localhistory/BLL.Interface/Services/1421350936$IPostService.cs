using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IPostService
    {
        IEnumerable<PostEntity> GetAllPosts();
        PostEntity GetPostById(int id);
        PostEntity GetPostByName(string name);
        void CreatePost(PostEntity post);
        void DeletePost(PostEntity post);
    }
}