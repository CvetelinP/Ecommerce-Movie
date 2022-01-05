using Ecommerce_Movie.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Movie.data
{
    public class DbSeeding
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();


                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Johny Depp",
                            ProfilePictureUrl =
                                "https://i.pinimg.com/736x/91/8f/5a/918f5a33d548113ace4095d33ffa4739--dior-fragrance-first-ad.jpg",
                            Bio = "Short bio from Johny Dept just a test",


                        },
                        new Actor()
                        {
                            FullName = "Orlando bloom",
                            ProfilePictureUrl =
                                "https://assets.mycast.io/actor_images/actor-orlando-bloom-4174_large.jpeg?1577590178",
                            Bio = "Short bio from Orlando Bloom just a test",


                        },
                        new Actor()
                        {
                            FullName = "Silvester Stalone",
                            ProfilePictureUrl =
                                "https://www.desktopbackground.org/p/2012/07/20/423835_sylvester-stallone-wallpapers-jpg_1600x1000_h.jpg",
                            Bio = "Short bio from Orlando Bloom just a test",


                        },
                        new Actor()
                        {
                            FullName = "John Travolta",
                            ProfilePictureUrl =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/John_Travolta_1997.jpg/414px-John_Travolta_1997.jpg",
                            Bio = "Short bio from Orlando Bloom just a test",


                        },
                        new Actor()
                        {
                            FullName = "Christopher Lumbert",
                            ProfilePictureUrl =
                                "https://upload.wikimedia.org/wikipedia/commons/8/84/Christopher_Lambert_66%C3%A8me_Festival_de_Venise_%28Mostra%29_5.jpg",
                            Bio = "Short bio from Orlando Bloom just a test",


                        },
                        new Actor()
                        {
                            FullName = "Keanu Reeves",
                            ProfilePictureUrl =
                                "https://upload.wikimedia.org/wikipedia/commons/9/90/Keanu_Reeves_%28crop_and_levels%29_%28cropped%29.jpg",
                            Bio = "Short bio",


                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Peter Jackson",
                            ProfilePictureUrl =
                                "https://the-talks.com/wp-content/uploads/2011/10/Anthony-Hopkins-01.jpg",
                            Bio = "Create Lord of the rings"
                        },
                        new Producer()
                        {
                            FullName = "Silvester Stallone",
                            ProfilePictureUrl =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Sylvester_Stallone_2012.jpg/424px-Sylvester_Stallone_2012.jpg",
                            Bio = "Creator of rambo"
                        },
                        new Producer()
                        {
                        FullName = "Frank Derabond",
                        ProfilePictureUrl =
                            "https://filmitena.com/img/Actor/Original/613_or.jpg",
                        Bio = "Creator of Shawnshenk Redemption"
                    }
                    });
                    context.SaveChanges();
                }
            }
        }


        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            }
        }
       
    }
}

