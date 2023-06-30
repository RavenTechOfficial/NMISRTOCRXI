using Microsoft.AspNetCore.Identity;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<thesisContext>();

                context.Database.EnsureCreated();

                if (!context.totalNoFitForHumanConsumptions.Any())
                {
                    context.totalNoFitForHumanConsumptions.AddRange(new List<TotalNoFitForHumanConsumption>()
                    {
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Carabao,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 2,
                            Date = DateTime.Now.AddDays(-7),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Carabao,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 2,
                            Date = DateTime.Now,
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Carabao,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 2,
                            Date = DateTime.Now,
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Hog,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 2,
                            Date = DateTime.Now.AddDays(-7),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Chicken,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 2,
                            Date = DateTime.Now,
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Cattle,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-31),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Cattle,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-31),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Cattle,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-31),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Cattle,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-366),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Duck,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-366),
                        },
                        new TotalNoFitForHumanConsumption()
                        {
                            Species = Species.Sheep,
                            NoOfAnimals = 2,
                            DressedWeightInKg = 32,
                            Date = DateTime.Now.AddDays(-366),
                        },

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
