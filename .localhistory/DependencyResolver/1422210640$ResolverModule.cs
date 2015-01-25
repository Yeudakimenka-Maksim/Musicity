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
            kernel.Bind<DbContext>().To<ForumContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();
            kernel.Bind<ITopicRepository>().To<TopicRepository>().InRequestScope();
            kernel.Bind<IPostRepository>().To<PostRepository>().InRequestScope();
            kernel.Bind<IReplyRepository>().To<ReplyRepository>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();

            kernel.Bind<ICategoryService>().To<CategoryService>().InRequestScope();
            kernel.Bind<ITopicService>().To<TopicService>().InRequestScope();
            kernel.Bind<IPostService>().To<PostService>().InRequestScope();
            kernel.Bind<IReplyService>().To<ReplyService>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IRoleService>().To<RoleService>().InRequestScope();
        }
    }
}