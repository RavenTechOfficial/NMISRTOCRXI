using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Data
{
    public class Seed3
    {
        public static void SeedDatas(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<thesisContext>();
                context.Database.EnsureCreated();

                if (context.ConductOfInspections.Any())
                {
                    var random = new Random();

                    for (int i = 0; i < 50; i++)
                    {
                        DateTime startDate = new DateTime(2023, 1, 1);
                        DateTime currentDate = DateTime.Now;
                        TimeSpan timeSpan = currentDate - startDate;
                        TimeSpan newTimeSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);

                        DateTime randomDateTime = startDate + newTimeSpan;

                        ConductOfInspection inspection = new ConductOfInspection()
                        {
                            Issue = (Issue)random.Next(1, System.Enum.GetValues(typeof(Issue)).Length),
                            NoOfHeads = random.Next(1, 50),
                            Weight = random.Next(1, 101),
                            Cause = (Cause)random.Next(1, System.Enum.GetValues(typeof(Cause)).Length),
                                MeatInspectionReport = new MeatInspectionReport
                                {
                                    RepDate = randomDateTime,
                                    VerifiedByPOSMSHead = "jess",
                                    ReceivingReport = new ReceivingReport
                                    {
                                        RecTime = randomDateTime,
                                        BatchCode = random.Next(100, 1000),
                                        Species = (Species)random.Next(1, System.Enum.GetValues(typeof(Species)).Length),
                                        Category = (CategoryOfFoodAnimals)random.Next(1, System.Enum.GetValues(typeof(CategoryOfFoodAnimals)).Length),
                                        NoOfHeads = random.Next(1, 50),
                                        LiveWeight = random.Next(1, 101),
                                        Origin = "jess",
                                        ShippingDoc = (ShippingDocuments)random.Next(1, System.Enum.GetValues(typeof(ShippingDocuments)).Length),
                                        HoldingPenNo = random.Next(1, 10),
                                        ReceivingBy = "jess"
                                    }
                                }
                            
                        };

                        context.ConductOfInspections.Add(inspection);
                    }

                    context.SaveChanges();
                }
            }

            

        }

    }
}
