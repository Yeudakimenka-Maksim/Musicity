using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using ORM.Context;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ForumContext>().InRequestScope();

            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ITopicRepository>().To<TopicRepository>();
            Bind<IPostRepository>().To<PostRepository>();

            Bind<ICategoryService>().To<CategoryService>();
            Bind<ITopicService>().To<TopicService>();
            Bind<IPostService>().To<PostService>();
        }
    }
}