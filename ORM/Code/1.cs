            var users = new List<OrmUser>
            {
                new OrmUser
                {
                    Name = "Admin",
                    Password = "123456",
                    DateOfBirth = DateTime.Parse("18-02-1994 09:35:00"),
                    JoinDate = DateTime.Parse("01-01-2015"),
                    LastActivity = DateTime.Now,
                    Location = "Minsk, Belarus",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Admin").ToList()
                },
                new OrmUser
                {
                    Name = "Stewart",
                    Password = "123456",
                    DateOfBirth = DateTime.Parse("01-01-1979"),
                    JoinDate = DateTime.Parse("01-Apr-2008"),
                    LastActivity = DateTime.Parse("17-Dec-2014 11:39"),
                    Location = "Glasgow, UK",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "Admin").ToList()
                },
                new OrmUser
                {
                    Name = "redheadshadz",
                    Password = "123456",
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("14-Oct-2012"),
                    LastActivity = DateTime.Parse("30-Dec-2014 07:49"),
                    Location = "Connecticut, USA",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Heteronym",
                    Password = "123456",
                    DateOfBirth = DateTime.Parse("01-01-1984"),
                    JoinDate = DateTime.Parse("11-May-2008"),
                    LastActivity = DateTime.Parse("25-Nov-2014 00:06"),
                    Location = "Portugal",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Damian Kelleher",
                    Password = "123456",
                    DateOfBirth = DateTime.Parse("March 31, 1982"),
                    JoinDate = DateTime.Parse("25-Sep-2009"),
                    LastActivity = DateTime.Parse("10-Oct-2014 01:00"),
                    Location = "Brisbane, Australia",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Alkibiades",
                    Password = "123456",
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("07-Jan-2013"),
                    LastActivity = DateTime.Parse("14-Jan-2013 12:43"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Cleanthess",
                    Password = "123456",
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("21-Aug-2012"),
                    LastActivity = DateTime.Parse("30-Dec-2014 16:02"),
                    Location = "New Jersey",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "pesahson",
                    Password = "123456",
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("15-Jul-2008"),
                    LastActivity = DateTime.Parse("31-12-2014 01:07"),
                    Location = "Kroke, Polin",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Stiffelio",
                    Password = "123456",
                    DateOfBirth = null,
                    JoinDate = DateTime.Parse("06-Sep-2009"),
                    LastActivity = DateTime.Parse("30-12-2014 06:25"),
                    Location = "Buenos Aires, Argentina",
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                },
                new OrmUser
                {
                    Name = "Elie",
                    Password = "123456",
                    DateOfBirth = DateTime.Parse("01-01-1985"),
                    JoinDate = DateTime.Parse("05-Oct-2008"),
                    LastActivity = DateTime.Parse("27-Dec-2014 18:31"),
                    Location = null,
                    IsOnline = false,
                    Roles = context.Roles.Where(r => r.Name == "User").ToList()
                }
                //new OrmUser
                //{
                //    Name = "",
                //    Password = "123456",
                //    DateOfBirth = ,
                //    JoinDate = DateTime.Parse(""),
                //    LastActivity = DateTime.Parse(""),
                //    Location = ,
                //    IsOnline = false,
                //    Roles = context.Roles.Where(r => r.Name == "").ToList()
                //},
            };
            users.ForEach(s => context.Users.AddOrUpdate(u => u.Name, s));
            context.SaveChanges();
			
			
            var categories = new List<Category>
            {
                new Category { Name = "Literature", Description = null },
                new Category { Name = "Sport", Description = null },
                new Category { Name = "Music", Description = null },
                new Category { Name = "Science", Description = null }
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.Name, s));
            context.SaveChanges();


            var literatureTopics = new List<Topic>
            {
                new Topic
                {
                    Name = "Publishing & Literary News Discussion",
                    Description = null,
                    CategoryId = context.Categories.Single(c => c.Name == "Literature").Id
                },
                new Topic
                {
                    Name = "Writers of the World",
                    Description = null,
                    CategoryId = context.Categories.Single(c => c.Name == "Literature").Id
                },
                new Topic
                {
                    Name = "European Literature",
                    Description = null,
                    CategoryId = context.Categories.Single(c => c.Name == "Literature").Id
                },
                new Topic
                {
                    Name = "Americas Literature",
                    Description = null,
                    CategoryId = context.Categories.Single(c => c.Name == "Literature").Id
                }
            };
            literatureTopics.ForEach(s => context.Topics.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();
			
			
            var publishingLiteraryNewsDiscussionPosts = new List<Post>
            {
                new Post
                {
                    Name = "New Book on Shakespeare",
                    Description = null,
                    CreatorId = context.Users.Single(u => u.Name == "Alkibiades").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Publishing & Literary News Discussion").Id
                },
                new Post
                {
                    Name = "Milan Kundera's new novel",
                    Description = null,
                    CreatorId = context.Users.Single(u => u.Name == "Heteronym").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Publishing & Literary News Discussion").Id
                },
                new Post
                {
                    Name = "Nobel Prize in Literature 2014",
                    Description = null,
                    CreatorId = context.Users.Single(u => u.Name == "Stewart").Id,
                    TopicId = context.Topics.Single(t => t.Name == "Publishing & Literary News Discussion").Id
                }
            };
            publishingLiteraryNewsDiscussionPosts.ForEach(s => context.Posts.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
			
			
            #region New Book on Shakespeare Replies

            var newBookOnShakespeareReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-Jan-2013, 04:27"),
                    IsSubject = true,
                    Content = @"Greetings from Inner Mongolia. While sojourning here in
semi-retirement I wrote a little collection of essays on
Shakespeare. The title is 'Hamlet Made Simple' (New
English Review Press, 2013) I'd be interested if anyone
reads it to learn your impressions.

Thanks!",
                    PostId = context.Posts.Single(p => p.Name == "New Book on Shakespeare").Id,
                    WriterId = context.Users.Single(u => u.Name == "Alkibiades").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-Jan-2013, 16:13"),
                    IsSubject = false,
                    Content =
                        @"Alkibiades, I liked very much the first essay of your book. Truth is I never liked any of the winners in Merchant of Venice and didn't wish them well. I specially disliked that 'cold, snobbish little bitch', Portia. So it was heartwarming to read that Shakespeare also intends unhappy marriages for them.

P.S. Thank you for introducing me to Hank Whittemore's The Monument.",
                    PostId = context.Posts.Single(p => p.Name == "New Book on Shakespeare").Id,
                    WriterId = context.Users.Single(u => u.Name == "Cleanthess ").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("14-Jan-2013, 12:43"),
                    IsSubject = false,
                    Content =
                        @"Thanks, Cleanthess, for your nice comment. This evening I just finished re-reading Coriolanus, a powerful drama in my judgment far better than the overperformed 'Othello'. Have you read Coriolanus? As you wade into Hamlet Made Simple, don't hesitate to share your thoughts with everyone. BTW, I alerted Hank Whittemore about your interest in his scholarship.

-Alkibiades",
                    PostId = context.Posts.Single(p => p.Name == "New Book on Shakespeare").Id,
                    WriterId = context.Users.Single(u => u.Name == "Alkibiades").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("14-Jan-2013, 17:11"),
                    IsSubject = false,
                    Content =
                        @"I second your views on Othello. Somebody once joked about how unmotivated the actions on that play are by calling it: 'Othello, or the Tragedy of the Handkerchief'. 

As a matter of fact, the two Shakespearean plays I find to be the most underrated are Coriolanus and Measure for Measure. Both of them secret masterpieces, to the extent that a work by Shakespeare can be a secret masterpiece.",
                    PostId = context.Posts.Single(p => p.Name == "New Book on Shakespeare").Id,
                    WriterId = context.Users.Single(u => u.Name == "Cleanthess").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("15-Jan-2013, 16:01"),
                    IsSubject = false,
                    Content =
                        @"A Shakespeare-loving friend emailed me last night complaining about my opinions regarding Othello. He said that a piece of clothing bringing tragedy to a powerful man was recently on the news: Monica Lewinsky's stained dress. And as for Iago's unmotivated betrayal and deceptions, my friend wrote that Monica Lewinsky's friend Linda Tripp had even less reasons to behave the way she did than Iago.

Also, the whole Clinton's scandal could be seen as confirmation that things happen twice, first as tragedy, then as farce.",
                    PostId = context.Posts.Single(p => p.Name == "New Book on Shakespeare").Id,
                    WriterId = context.Users.Single(u => u.Name == "Cleanthess").Id
                }
            };

            newBookOnShakespeareReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            #endregion

            #region Nobel Prize in Literature 2014 Replies

            var nobelPrizeInLiterature2014Replies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("09-Oct-2014, 13:02"),
                    IsSubject = true,
                    Content =
                        @"The Nobel Prize in Literature for 2014 has been awarded to Patrick Modiano ""for the art of memory which he has evoked the most ungraspable human destinies and uncovered the life-world of the occupation.""",
                    PostId = context.Posts.Single(p => p.Name == "Nobel Prize in Literature 2014").Id,
                    WriterId = context.Users.Single(u => u.Name == "Stewart").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("09-Oct-2014, 13:07"),
                    IsSubject = false,
                    Content =
                        @"Looks like I'm stuck for a few days at least. None of his books seem to be online yet, hopefully this prize will fix that. He really came out of nowhere, going from not on the betting list to winning! I'm satisfied with the surprise candidate. I'm also a little shocked they gave it to another French writer so soon after Le Clezio.",
                    PostId = context.Posts.Single(p => p.Name == "Nobel Prize in Literature 2014").Id,
                    WriterId = context.Users.Single(u => u.Name == "redheadshadz").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("09-Oct-2014, 13:09"),
                    IsSubject = false,
                    Content =
                        @"I am happy with it because I am in search of a new writer and he seems to fit the bill in terms of what I like. 

So I will buy some more, and hopefully he will be my discovery of 2014.",
                    PostId = context.Posts.Single(p => p.Name == "Nobel Prize in Literature 2014").Id,
                    WriterId = context.Users.Single(u => u.Name == "Damian Kelleher").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("09-Oct-2014, 13:12"),
                    IsSubject = false,
                    Content = @"Another year, another nobody...",
                    PostId = context.Posts.Single(p => p.Name == "Nobel Prize in Literature 2014").Id,
                    WriterId = context.Users.Single(u => u.Name == "Heteronym").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("09-Oct-2014, 13:16"),
                    IsSubject = false,
                    Content =
                        @"Actually Heteronym, I did some research on Modiano in the days leading up to this, he's one of the leading French novelists at the time. I think his nobody status says more about us than about him.",
                    PostId = context.Posts.Single(p => p.Name == "Nobel Prize in Literature 2014").Id,
                    WriterId = context.Users.Single(u => u.Name == "redheadshadz").Id
                }
            };
            nobelPrizeInLiterature2014Replies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            #endregion

            #region Milan Kundera's new novel Replies

            var milanKunderasNewNovelReplies = new List<Reply>
            {
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-May-2014, 00:20"),
                    IsSubject = true,
                    Content =
                        @"I just found out at another forum that Milan Kundera published a new novel in 2013, and no one told me about it! 

It was published first in Italian instead of French, and it's called La Festa dell'Insignificanza. Here's the publisher's link and my translation:

""To shine a light upon the most serious problems and at the same time refraining from uttering a single serious sentence, to experience the fascination of the reality of the contemporary world and at the same time to avoid realism altogether - that's The Feast of Insignificance. Whoever knows Kundera's books knows that his wish to incorporate in a novel a drop of ""non seriousness"" is nothing new for him. In Immortality Goethe and Hemingway walk around in several chapters, chatting, having fun. In Slowness, Vera, the author's wife, warns him: ""You've told me so many times that one day you'd write a novel wherein not a single word would be serious... I caution though: be careful."" Why, instead of being careful Kundera has finally accomplished his ancient aesthetic dream - and The Feast of Insignificance can be considered a synthesis of his entire oeuvre. A strange synthesis. A strange epilogue. A strange laughter, inspired by our era which is comical because it has lost all sense of humour. What else is there to say? Nothing. Read it!""

It seems the novel's coming out in Portugal next Fall. But I'll probably wait for the English translation, I've gotten used to reading him in English.",
                    PostId = context.Posts.Single(p => p.Name == "Milan Kundera's new novel").Id,
                    WriterId = context.Users.Single(u => u.Name == "Heteronym").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-May-2014, 07:15"),
                    IsSubject = false,
                    Content =
                        @"Oh wow. That's excellent news! Now that I googled it, it seems that about a month ago there were quite a few articles about it in Polish press but I missed them all. I couldn't find any information about the Polish translation, though. But it's Kundera! I'm sure someone is working on it. 

Btw, I love the covers of the books on the Italian site. Not so much the Kundera one, but others look very appealing.",
                    PostId = context.Posts.Single(p => p.Name == "Milan Kundera's new novel").Id,
                    WriterId = context.Users.Single(u => u.Name == "pesahson").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-May-2014, 07:28"),
                    IsSubject = false,
                    Content =
                        @"Good news! I find it very strange, however, that it was published in Italian since Kundera has been writing directly in French for quite some time.",
                    PostId = context.Posts.Single(p => p.Name == "Milan Kundera's new novel").Id,
                    WriterId = context.Users.Single(u => u.Name == "Stiffelio").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("07-May-2014, 21:12"),
                    IsSubject = false,
                    Content =
                        @"I was wondering this - it's possible, I guess, that it was originally written in Italian, but I think it's more likely that something odd is going on at the publisher's that's allowed the Italians to get their version out first.",
                    PostId = context.Posts.Single(p => p.Name == "Milan Kundera's new novel").Id,
                    WriterId = context.Users.Single(u => u.Name == "Elie").Id
                },
                new Reply
                {
                    WrittenTime = DateTime.Parse("08-May-2014, 18:43"),
                    IsSubject = false,
                    Content =
                        @"On the website that Heteronym linked you can see that it was translated by Massimo Rizzante. Ho translated The Curtain as well which was originally written in French. So that one must have been written in French as well.",
                    PostId = context.Posts.Single(p => p.Name == "Milan Kundera's new novel").Id,
                    WriterId = context.Users.Single(u => u.Name == "pesahson").Id
                }
            };
            milanKunderasNewNovelReplies.ForEach(
                s => context.Replies.AddOrUpdate(r => new { r.WrittenTime, r.Content, r.WriterId }, s));
            context.SaveChanges();

            #endregion