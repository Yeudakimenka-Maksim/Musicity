using System.Linq;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class DalCategoryMapper
    {
        public static Category ToOrmCategory(this DalCategory dalCategory)
        {
            return new Category
            {
                Id = dalCategory.Id,
                Name = dalCategory.Name,
                Description = dalCategory.Description,
                CreationTime = dalCategory.CreationTime,
                CreatorId = dalCategory.CreatorId,
                Creator = dalCategory.Creator.ToOrmUser(),
                Topics = dalCategory.Topics.Select(t => t.ToOrmTopic()).ToList()
            };
        }

        public static DalCategory ToDalCategory(this Category ormCategory)
        {
            return new DalCategory
            {
                Id = ormCategory.Id,
                Name = ormCategory.Name,
                Description = ormCategory.Description,
                Topics = ormCategory.Topics.Select(topic => new DalTopic
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Description = topic.Description,
                    Posts = topic.Posts.Select(post => new DalPost
                    {
                        Id = post.Id,
                        Name = post.Name,
                        Description = post.Description,
                        CreationTime = post.CreationTime,
                        Creator = new DalUser
                        {
                            Id = post.Creator.Id,
                            Name = post.Creator.Name
                        }
                    }).ToList()
                }).ToList()
            };
        }

        //public static DalCategory ToDalCategory(this Category ormCategory)
        //{
        //    //return new DalCategory
        //    //{
        //    //    Id = ormCategory.Id,
        //    //    Name = ormCategory.Name,
        //    //    Description = ormCategory.Description,
        //    //    CreationTime = ormCategory.CreationTime,
        //    //    CreatorId = ormCategory.CreatorId,
        //    //    Creator = ormCategory.Creator.ToDalUser(),
        //    //    Topics = ormCategory.Topics.Select(t => t.ToDalTopic()).ToList()
        //    //};
        //    return new DalCategory
        //    {
        //        Id = ormCategory.Id,
        //        Name = ormCategory.Name,
        //        Description = ormCategory.Description,
        //        Topics = ormCategory.Topics.Select(topic => new DalTopic
        //        {
        //            Id = topic.Id,
        //            Name = topic.Name,
        //            Description = topic.Description,
        //            Posts = topic.Posts.Select(post => new DalPost
        //            {
        //                Id = post.Id,
        //                Name = post.Name,
        //                Description = post.Description,
        //                CreationTime = post.CreationTime,
        //                Creator = new DalUser
        //                {
        //                    Id = post.Creator.Id,
        //                    Name = post.Creator.Name
        //                }
        //            }).ToList()
        //        }).ToList()
        //    };
        //}
    }
}