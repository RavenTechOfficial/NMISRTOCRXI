using Microsoft.AspNetCore.Identity;
using System;
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
                if (!context.ReceivingReports.Any())
                {
                    Random random = new Random();
                    DateTime currentDate = DateTime.Now.Date;
                    DateTime startDate = new DateTime(2023, 1, 1);

                    for (int i = 0; i < 100; i++)
                    {
                        int dayOffset = (int)(currentDate - startDate).TotalDays;
                        int randomDayOffset = random.Next(0, dayOffset);
                        DateTime recTime = startDate.AddDays(randomDayOffset);

                        var receivingReport = new ReceivingReport()
                        {
                            RecTime = recTime,
                            BatchCode = random.Next(1, 100),
                            Species = (Species)random.Next(1, System.Enum.GetValues(typeof(Species)).Length),
                            Category = (CategoryOfFoodAnimals)random.Next(1, System.Enum.GetValues(typeof(CategoryOfFoodAnimals)).Length),
                            NoOfHeads = random.Next(1, 100),
                            LiveWeight = random.Next(1, 100),
                            Origin = "jdead",
                            ShippingDoc = (ShippingDocuments)random.Next(1, System.Enum.GetValues(typeof(ShippingDocuments)).Length),
                            HoldingPenNo = random.Next(1, 100),
                            ReceivingBy = "jess",
                            MeatDealers = new MeatDealers()
                            {
                                FirstName = "jess",
                                MiddleName = "ingles",
                                LastName = "arere",
                                Address = "Davao City, Ma-a",
                                ContactNo = "0935353",
                                MeatEstablishment = new MeatEstablishment()
                                {
                                    Address = "DAVAO CITY, MINTAL",
                                    Type = (EstablishmentType)random.Next(1, System.Enum.GetValues(typeof(EstablishmentType)).Length),
                                    Name = "jeff",
                                    LicenseToOperateNumber = "jess"
                                }
                            }
                        };

                        context.ReceivingReports.Add(receivingReport);
                    }

                    context.SaveChanges();
                }
            }
        }
    }

}
