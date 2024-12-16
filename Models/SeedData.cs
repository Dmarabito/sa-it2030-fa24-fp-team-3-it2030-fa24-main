using Microsoft.EntityFrameworkCore;
using sa_it2030_fa24_fp_team_3_it2030_fa24.Models;
namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Models
{
    public class SeedData
    {
        public static void populate(IApplicationBuilder app) {
            DataContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Characters.Any()) {
                context.Characters.AddRange(
                    new Character {name="Lelouch",about="Lelouch is the main character of Code Geass", powers = "Command" }
                    );
                context.SaveChanges();
            }


            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(
                    new Organization { name = "Black Knights", about = "The Black Knights are a organization formed by Lelouch.", Leader = context.Characters.OrderBy(c=>c.Id).FirstOrDefault(c => c.name == "Lelouch") }
                    );
                context.SaveChanges();
            }

            if (!context.Messages.Any())
            {
                context.Messages.AddRange(
                    new Message {Page="Lelouch", Nickname="Project Zero Team", Body="Welcome",SentTime=DateTime.Now}
                    );
                context.SaveChanges();
            }

        }
    }
}
