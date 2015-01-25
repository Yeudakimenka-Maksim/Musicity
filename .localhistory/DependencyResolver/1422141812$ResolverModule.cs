using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM.Context;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ForumContext>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ITopicRepository>().To<TopicRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IReplyRepository>().To<ReplyRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ITopicService>().To<TopicService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IReplyService>().To<ReplyService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
        }
    }
}