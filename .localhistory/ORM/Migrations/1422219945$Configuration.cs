using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Helpers;
using ORM.Context;
using ORM.Entities;

namespace ORM.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ForumContext context)
        {
            AddRoles(context);
            AddUsers(context);
            AddCategories(context);
            AddTopics(context);
            AddPosts(context);
            AddReplies(context);
        }

        #region Populating all the forum tables

        private static void AddRoles(ForumContext context)
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin", Description = null },
                new Role { Name = "Reader", Description = null },
                new Role { Name = "Guest", Description = null }
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(r => r.Name, s));
            context.SaveChanges();
        }

        private static void AddUsers(ForumContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Name = "Admin",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("18-02-1994 09:35:00"),
                    JoinDate = DateTime.Parse("01-01-2015"),
                    LastActivity = DateTime.Now,
                    Location = "Minsk, Belarus",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Admin").ToList()
                },
                new User
                {
                    Name = "Mirrorball95",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("13-04-2009"),
                    LastActivity = DateTime.Parse("25-12-2010 07:55 AM"),
                    Location = "Our house, In the middle of the street",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "innertide",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("07-11-2004"),
                    LastActivity = DateTime.Parse("27-04-2009 02:54 PM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "anticipation",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("15-06-2005"),
                    LastActivity = DateTime.Parse("30-12-2014 07:01 AM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Pet_Sounds",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("01-01-2000"),
                    JoinDate = DateTime.Parse("17-02-2014"),
                    LastActivity = DateTime.Parse("26-12-2014 09:34 PM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Above",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("28-11-2011"),
                    LastActivity = DateTime.Parse("19-12-2011 04:04 PM"),
                    Location = "England",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Wild7Dustr",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("08-12-2005"),
                    LastActivity = DateTime.Parse("09-02-2008 09:24 PM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "illusion",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("01-01-2006"),
                    LastActivity = DateTime.Parse("19-09-2006 08:39 PM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Zohar",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("07-01-2013"),
                    LastActivity = DateTime.Parse("07-01-2013 10:55 AM"),
                    Location = "Upper Nazareth, Israel",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Plankton",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("August 30, 1966"),
                    JoinDate = DateTime.Parse("30-04-2012"),
                    LastActivity = DateTime.Parse("31-12-2014 02:26 PM"),
                    Location = "See signature...",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Uh_Me",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("24-02-2012"),
                    LastActivity = DateTime.Parse("02-10-2013 04:15 AM"),
                    Location = "Tennessee",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Descendents",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("11-01-2013"),
                    LastActivity = DateTime.Parse("20-01-2013 12:18 AM"),
                    Location = "USA",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Rjinn",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("01-01-1988"),
                    JoinDate = DateTime.Parse("26-06-2012"),
                    LastActivity = DateTime.Parse("16-11-2014 02:05 AM"),
                    Location = "New South Wales, Australia",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "FRED HALE SR.",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("04-04-2011"),
                    LastActivity = DateTime.Parse("05-12-2014 04:20 PM"),
                    Location = "So-Cal",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Kurt_Cobain",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("September 27, 1986"),
                    JoinDate = DateTime.Parse("05-02-2005"),
                    LastActivity = DateTime.Parse("19-06-2014 08:25 AM"),
                    Location = "In bed, with Cheryl Tweedy",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Rainard Jalen",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("03-08-2006"),
                    LastActivity = DateTime.Parse("27-03-2014 06:41 AM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Seltzer",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("May 4, 1988"),
                    JoinDate = DateTime.Parse("02-12-2005"),
                    LastActivity = DateTime.Parse("21-04-2012 07:03 PM"),
                    Location = "Hobbit Land NZ",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "lucifer_sam",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("01-01-1989"),
                    JoinDate = DateTime.Parse("27-06-2008"),
                    LastActivity = DateTime.Parse("06-12-2011 01:19 AM"),
                    Location = "Pennsylvania",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Son of JayJamJah",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("19-07-2007"),
                    LastActivity = DateTime.Parse("22-01-2012 03:02 AM"),
                    Location = "End of the Earth",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "TheBig3",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("November 22, 1982"),
                    JoinDate = DateTime.Parse("23-08-2004"),
                    LastActivity = DateTime.Parse("01-01-2015 01:49 AM"),
                    Location = "Boston, Massachusetts",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Urban Hatˆmonger ?",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("21-12-2004"),
                    LastActivity = DateTime.Parse("26-12-2014 12:37 PM"),
                    Location = "Somewhere cooler than you",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Enfilade",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("August 14, 1989"),
                    JoinDate = DateTime.Parse("09-12-2004"),
                    LastActivity = DateTime.Parse("19-06-2005 09:14 PM"),
                    Location = "Places",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                },
                new User
                {
                    Name = "Sneer",
                    Password = Crypto.HashPassword("123456"),
                    DateOfBirth = DateTime.Parse("September 1, 1987"),
                    JoinDate = DateTime.Parse("01-11-2004"),
                    LastActivity = DateTime.Parse("27-12-2011 12:55 PM"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                }
                //new OrmUser
                //{
                //    Name = "",
                //    Password = Crypto.HashPassword("123456"),
                //    DateOfBirth = ,
                //    JoinDate = DateTime.Parse(""),
                //    LastActivity = DateTime.Parse(""),
                //    Location = ,
                //    IsOnline = false,
                //    Roles = context.Roles.Where(r => r.Name == "Reader").ToList()
                //},
            };
            users.ForEach(s => context.Users.AddOrUpdate(u => u.Name, s));
            context.SaveChanges();
        }

        private static void AddCategories(ForumContext context)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Music News",
                    Description = null,
                    CreationTime = DateTime.Parse("09-08-2012, 04:31 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id
                },
                new Category
                {
                    Name = "Music Genres",
                    Description = null,
                    CreationTime = DateTime.Parse("16-01-2005, 02:38 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id
                },
                new Category
                {
                    Name = "Artists Corner",
                    Description = null,
                    CreationTime = DateTime.Parse("03-01-2006, 03:16 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id
                }
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.Name, s));
            context.SaveChanges();
        }

        private static void AddTopics(ForumContext context)
        {
            var musicNewsTopics = new List<Topic>
            {
                new Topic
                {
                    Name = "Album Reviews",
                    Description = "Post your album reviews here",
                    CreationTime = DateTime.Parse("09-08-2012, 04:31 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Music News").Id
                },
                new Topic
                {
                    Name = "New Releases",
                    Description = "Discuss new and recent releases",
                    CreationTime = DateTime.Parse("14-06-2013, 08:42 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Music News").Id
                }
            };
            musicNewsTopics.ForEach(s => context.Topics.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();

            var musicGenresTopics = new List<Topic>
            {
                new Topic
                {
                    Name = "Rock & Metal",
                    Description = "Discuss Rock and Metal",
                    CreationTime = DateTime.Parse("16-01-2005, 02:38 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Music Genres").Id
                },
                new Topic
                {
                    Name = "Jazz & Blues",
                    Description = "Discuss Jazz and Blues",
                    CreationTime = DateTime.Parse("30-05-2005, 07:40 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Music Genres").Id
                },
                new Topic
                {
                    Name = "Pop",
                    Description = "Discuss Pop",
                    CreationTime = DateTime.Parse("03-07-2008, 08:48 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Music Genres").Id
                }
            };
            musicGenresTopics.ForEach(s => context.Topics.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();

            var artistsCornerTopics = new List<Topic>
            {
                new Topic
                {
                    Name = "Talk Instruments",
                    Description = "Guitars, drums...",
                    CreationTime = DateTime.Parse("03-01-2006, 03:16 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Artists Corner").Id
                },
                new Topic
                {
                    Name = "Song Writing, Lyrics and Poetry",
                    Description = "Develop your lyrics and poetry here and get reviews",
                    CreationTime = DateTime.Parse("06-09-2012, 01:31 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Admin").Id,
                    CategoryId = context.Categories.Single(c => c.Name == "Artists Corner").Id
                }
            };
            artistsCornerTopics.ForEach(s => context.Topics.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();
        }

        private static void AddPosts(ForumContext context)
        {
            var albumReviewsPosts = new List<Post>
            {
                new Post
                {
                    Name = "Pink Floyd \"Endless River\"",
                    Description = null,
                    CreationTime = DateTime.Parse("14-11-2014, 07:09 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Uh_Me").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Album Reviews").Id
                }
            };
            albumReviewsPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var newReleasesPosts = new List<Post>
            {
                new Post
                {
                    Name = "Kanye West - Yeezus",
                    Description = null,
                    CreationTime = DateTime.Parse("14-06-2013, 08:42 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Enfilade").Id,
                    TopicId = context.Topics.Single(t => t.Name == "New Releases").Id
                }
            };
            newReleasesPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var rockMetalPosts = new List<Post>
            {
                new Post
                {
                    Name = "The Official Pink Floyd Thread",
                    Description = null,
                    CreationTime = DateTime.Parse("16-01-2005, 02:38 PM"),
                    CreatorId = context.Users.Single(u => u.Name == "Sneer").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Rock & Metal").Id
                },
                new Post
                {
                    Name = "The Rolling Stones vs. The Beatles",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "anticipation").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Rock & Metal").Id
                },
                new Post
                {
                    Name = "Dire Straits Appreciation Thread",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "Mirrorball95").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Rock & Metal").Id
                }
            };
            rockMetalPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var jazzBluesPosts = new List<Post>
            {
                new Post
                {
                    Name = "Favorite Blues Songs",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "anticipation").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Jazz & Blues").Id
                },
                new Post
                {
                    Name = "Ray Charles",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "Kurt_Cobain").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Jazz & Blues").Id
                }
            };
            jazzBluesPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var popPosts = new List<Post>
            {
                new Post
                {
                    Name = "Elton John",
                    Description = null,
                    CreationTime = DateTime.Parse("03-07-2008, 08:48 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Rainard Jalen").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Pop").Id
                },
                new Post
                {
                    Name = "Billy Joel",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "Above").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Pop").Id
                },
                new Post
                {
                    Name = "Billy Joel vs. Elton John?",
                    Description = null,
                    CreationTime = DateTime.Now, // TODO
                    CreatorId = context.Users.Single(u => u.Name == "Pet_Sounds").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Pop").Id
                }
            };
            popPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var talkInstrumentsPosts = new List<Post>
            {
                new Post
                {
                    Name = "Talk about your instrument/gear!!!",
                    Description = null,
                    CreationTime = DateTime.Parse("03-01-2006, 03:16 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Wild7Dustr").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Talk Instruments").Id
                },
                new Post
                {
                    Name = "Whats your fav guitar?",
                    Description = null,
                    CreationTime = DateTime.Parse("07-01-2013, 10:54 AM"),
                    CreatorId = context.Users.Single(u => u.Name == "Zohar").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Talk Instruments").Id
                }
            };
            talkInstrumentsPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }

        private static void AddReplies(ForumContext context)
        {
            var theOfficialPinkFloydThreadReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("16-01-2005, 02:38 PM"),
                    IsSubject = true,
                    Content =
                        @"i was sitting here listening to the bends when it suddenly hit me how similiar floyd and R'head are. both in sound and their stance in the world of rock. both use studio production and sounds heavily. both are completely experimental and progressive. both have produced to album masterpieces. And both are seen as just about as weird and out there as you can get. anyway, what do you guys think?",
                    PostId = context.Posts.Single(p => p.Name == "The Official Pink Floyd Thread").Id,
                    WriterId = context.Users.Single(u => u.Name == "Sneer").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("16-01-2005, 02:56 PM"),
                    IsSubject = false,
                    Content = @"I see what you mean but I think Radiohead have more in common with Can than Pink Floyd",
                    PostId = context.Posts.Single(p => p.Name == "The Official Pink Floyd Thread").Id,
                    WriterId = context.Users.Single(u => u.Name == "Urban Hatˆmonger ?").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("17-01-2005, 04:38 PM"),
                    IsSubject = false,
                    Content =
                        @"I had the exact same revelation as you! I was sitting on a plane listening to the Bends and I had Dark Side Of The Moon in my bag and thats exactly what I thought too! I definatley agree with you..",
                    PostId = context.Posts.Single(p => p.Name == "The Official Pink Floyd Thread").Id,
                    WriterId = context.Users.Single(u => u.Name == "Enfilade").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("18-01-2005, 03:34 AM"),
                    IsSubject = false,
                    Content = @"cant say ive ever heard can. i'll check them out though",
                    PostId = context.Posts.Single(p => p.Name == "The Official Pink Floyd Thread").Id,
                    WriterId = context.Users.Single(u => u.Name == "Sneer").Id
                }
            };
            theOfficialPinkFloydThreadReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            var eltonJohnReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-07-2008, 08:48 AM"),
                    IsSubject = true,
                    Content =
                        @"An absolutely *FANTASTIC* melodist, one of the best melody writers of all time who could dabble in virtually any style of popular music. Often overlooked by younger music fans (like myself if mid-20s is young) these days due to the lack of the cool factor. I personally had not listened to him for years and knew of his music through my dad, who grew up with it. But I heard some of those classics again recently and he really is an unbelievably good melodist. In fact the sound itself is pretty unique from the standpoint of the early 70s, in that it is more piano-driven pop rock as opposed to the more usual guitar rock format that was all the rage at the time. The arrangements are pretty great too.",
                    PostId = context.Posts.Single(p => p.Name == "Elton John").Id,
                    WriterId = context.Users.Single(u => u.Name == "Rainard Jalen").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-07-2008, 08:51 AM"),
                    IsSubject = false,
                    Content =
                        @"I have Honky Chateau and Goodbye Yellow Brick Road which are both great albums. I think people overlook him past his popular songs.",
                    PostId = context.Posts.Single(p => p.Name == "Elton John").Id,
                    WriterId = context.Users.Single(u => u.Name == "Seltzer").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-07-2008, 02:33 PM"),
                    IsSubject = false,
                    Content =
                        @"Actually, I think a lot of ""overlooking"" was actually prejudice, or so my father says. I wasn't alive when Elton was making his bones, so I don't know the story, but I'm told that it was always something like the Queen phenomenon. Men simply didn't want to listen to a *** singer, no matter how talented he was. Bit unfortunate really, because I can't begin to imagine how many artists remain undiscovered due to this unfair stigma.",
                    PostId = context.Posts.Single(p => p.Name == "Elton John").Id,
                    WriterId = context.Users.Single(u => u.Name == "lucifer_sam").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-07-2008, 02:39 PM"),
                    IsSubject = false,
                    Content =
                        @"That's a very good point, earlier when I first read the thread of was thinking, I wonder if part of the reason Elton does not consistently get considered among the best songwriters ever is because people sort of dismiss him as ""that flamboyant *** guy"" like a lot of casual listeners do.",
                    PostId = context.Posts.Single(p => p.Name == "Elton John").Id,
                    WriterId = context.Users.Single(u => u.Name == "Son of JayJamJah").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-07-2008, 02:54 PM"),
                    IsSubject = false,
                    Content =
                        @"Do people think that? I think he's too general most of the time to fit into anyones genre and he's safe as far as music goes so its not as if he'd fit into any one scene. 

I think his genrelessness is more of a factor than his homosexuality which to me is just a non-issue. I mean, I am more put off by Becks Scientology than John's homosexuality. 

Even his absolutly campy (croc rock) and coked out (I'm still standing) songs are great. But the one that, despite making the first best of, is still too underrated for my liking is Border Song. 

If you listen to one song you've never heard before today, make it Border Song.",
                    PostId = context.Posts.Single(p => p.Name == "Elton John").Id,
                    WriterId = context.Users.Single(u => u.Name == "TheBig3").Id
                }
            };
            eltonJohnReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            var whatsYourFavGuitarReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-01-2013, 10:54 AM"),
                    IsSubject = true,
                    Content = @"Mine will be Epiphone SG G-400 Special.
I don't know, I really liked the feel of it. I know it's not the best guitar, It's just my favourite.",
                    PostId = context.Posts.Single(p => p.Name == "Whats your fav guitar?").Id,
                    WriterId = context.Users.Single(u => u.Name == "Zohar").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-01-2013, 11:35 AM"),
                    IsSubject = false,
                    Content = @"59' Gibson LP Sunburst. Seriously, if I had the money...",
                    PostId = context.Posts.Single(p => p.Name == "Whats your fav guitar?").Id,
                    WriterId = context.Users.Single(u => u.Name == "Plankton").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-01-2013, 02:38 PM"),
                    IsSubject = false,
                    Content =
                        @"I prefer the Gretsch G5135 to most SGs. It does what they do, just better. My absolute favorite, however, is a Gibson Black Beauty. They are....... beautiful.",
                    PostId = context.Posts.Single(p => p.Name == "Whats your fav guitar?").Id,
                    WriterId = context.Users.Single(u => u.Name == "Uh_Me").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("11-01-2013, 03:10 AM"),
                    IsSubject = false,
                    Content =
                        @"All depends on what I want to play. Twangier, but cleaner sounds would go to my sg-400 1966 reissue. My warmer. muddier sounds would be the les paul. Looking for a blues sound I'm going to play my strat.",
                    PostId = context.Posts.Single(p => p.Name == "Whats your fav guitar?").Id,
                    WriterId = context.Users.Single(u => u.Name == "Descendents").Id
                }
            };
            whatsYourFavGuitarReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            var talkAboutYourInstrumentGearReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-01-2006, 03:16 AM"),
                    IsSubject = true,
                    Content =
                        @"Alright, 1st of all, I'm a proficient drummer that has been involved in music for many years. I have also had tons of fun playing lead guitar for many years, but realized that drumming was my true passion!!!I love jamming to my favorite music styles which include metal, blues, hardrock, funk, soul, r+b, jazz, etc...
My gear includes a Tama StarClassic Performer kit in the color of transparent green.After using that for a little while, I added on a 18"" Floor Tom of the same type/brand of drum.Another add on, or what I like to call a replacement, was my 12"" by 5"" Simon Phillips signature Tama drum.It is a handpainted, signature drum with maple wood and gold diecast rims!!!Lately, I haven't actually used any of the toms at all!!!Focusing mainly on the bass, snare and cymbals definitely brings out the talent and creativity in a drummer, including myself!!!I do have Tama's Iron Cobra hardware for my kit as well, including the PowerGlide double pedal.
My cymbals includeall Sabian.)
1.14"" AAX Metal Hats.
2.18"" AAX Metal Crash.
3.18"" HH Rock Crash.
4.22"" HH PowerBell Ride.
5.12"" AAX Metal Splash.
6.14"" AAX Dark Crash.
I'm happy with my gear and love every single jam that I perform in!!!I'd recommend anyone to try to be creative like I have, by taking out all toms and focusing more on the basics...
...You become a better drummer this way!!!Just try for yourself, peace!!!",
                    PostId = context.Posts.Single(p => p.Name == "Talk about your instrument/gear!!!").Id,
                    WriterId = context.Users.Single(u => u.Name == "Wild7Dustr").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-01-2006, 03:18 AM"),
                    IsSubject = false,
                    Content =
                        @"Well I don't really get enough money to purchase my own instruments so I just use my dad's Fender Stratocaster. I also use his Mesa Boogie amp, *drooling* 30 watt glass valves",
                    PostId = context.Posts.Single(p => p.Name == "Talk about your instrument/gear!!!").Id,
                    WriterId = context.Users.Single(u => u.Name == "illusion").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-01-2006, 03:29 AM"),
                    IsSubject = false,
                    Content =
                        @"Hey man, I understand about the prices and all!!! It's always hard to save up ""that much"", if ya know what I mean!!!I've saved and, overtime, got all that I wanted or need!!!
The funny thing is that, right now, I'm trying to save up for one of those nice $3,500 V-Drum sets from Roland!!!Too bad we've always gotta limit the noise because of our neighbors...
...I guess they're the one's costing me all this money, ya know?Otherwise, I got a great sounding kit and wouldn't necessarily need the Roland V-Drums, see?",
                    PostId = context.Posts.Single(p => p.Name == "Talk about your instrument/gear!!!").Id,
                    WriterId = context.Users.Single(u => u.Name == "Wild7Dustr").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("03-01-2006, 03:36 AM"),
                    IsSubject = false,
                    Content =
                        @"I was heavily into drums before my dad got his guitar, the only problem was the price. I was going to buy exactly the same drum set as you. I decided to go with a cheaper and worse drum sets. Then dad got his guitar and I decided against getting the drums, I still regret it today",
                    PostId = context.Posts.Single(p => p.Name == "Talk about your instrument/gear!!!").Id,
                    WriterId = context.Users.Single(u => u.Name == "illusion").Id
                }
            };
            talkAboutYourInstrumentGearReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();
        }

        #endregion
    }
}