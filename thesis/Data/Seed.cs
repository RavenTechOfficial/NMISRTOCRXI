using Microsoft.AspNetCore.Identity;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Data
{
    public class Seed
    {
        public static void SeedDatas(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<thesisContext>();

                context.Database.EnsureCreated();

                if (context.totalNoFitForHumanConsumptions.Any())
                {
                    context.totalNoFitForHumanConsumptions.AddRange(new List<totalNoFitForHumanConsumptions>()
                    {
                        new totalNoFitForHumanConsumptions()
                        {
                            Species = Species.Swine,
                            //NoOfAnimals = 2,
                            //DressedWeightInKg = 1,
                            //Date = DateTime.Now.AddDays(-7),
                        },
                        new totalNoFitForHumanConsumptions()
                        {
                            Species = Species.Swine,
                            //NoOfAnimals = 2,
                            //DressedWeightInKg = 2,
                            //Date = DateTime.Now.AddDays(-6),
                        },
                        new totalNoFitForHumanConsumptions()
                        {
                            Species = Species.Swine,
                            //NoOfAnimals = 2,
                            //DressedWeightInKg = 3,
                            //Date = DateTime.Now.AddDays(-5),
                        },
                        new totalNoFitForHumanConsumptions()
                        {
                            Species = Species.Swine,
                            //NoOfAnimals = 2,
                            //DressedWeightInKg = 4,
                            //Date = DateTime.Now.AddDays(-4),
                        },
                        new totalNoFitForHumanConsumptions()
                        {
                            Species = Species.Swine,
                            //NoOfAnimals = 2,
                            //DressedWeightInKg = 5,
                            //Date = DateTime.Now.AddDays(-3),
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
