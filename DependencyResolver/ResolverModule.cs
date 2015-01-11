﻿using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repositories;
using Ninject.Modules;
using ORM.Context;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ForumContext>().InSingletonScope();

            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ITopicRepository>().To<TopicRepository>();
            Bind<IPostRepository>().To<PostRepository>();
            Bind<IReplyRepository>().To<ReplyRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();

            Bind<ICategoryService>().To<CategoryService>();
            Bind<ITopicService>().To<TopicService>();
            Bind<IPostService>().To<PostService>();
            Bind<IReplyService>().To<ReplyService>();
            Bind<IUserService>().To<UserService>();
            Bind<IRoleService>().To<RoleService>();
        }
    }
}