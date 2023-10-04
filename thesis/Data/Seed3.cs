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

                if (!context.totalNoFitForHumanConsumptions.Any())
                {
                    var random = new Random();

                    for (int i = 0; i < 100; i++)
                    {
                        //DateTime startDate = new DateTime(2023, 1, 1);
                        DateTime startDate = new DateTime(2023,1, 1);
                        DateTime currentDate = DateTime.Now;
                        TimeSpan timeSpan = currentDate - startDate;
                        TimeSpan newTimeSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);

                        DateTime randomDateTime = startDate + newTimeSpan;
                        totalNoFitForHumanConsumptions totalfit = new totalNoFitForHumanConsumptions()
                        {
                            Species = (Species)random.Next(1, System.Enum.GetValues(typeof(Species)).Length),
                            NoOfHeads = random.Next(1, 50),
                            DressedWeight = random.Next(1, 50),
                            Postmortem = new Postmortem()
                            {
                                AnimalPart = (AnimalPart)random.Next(1, System.Enum.GetValues(typeof(AnimalPart)).Length),
                                Cause = (Cause)random.Next(1, System.Enum.GetValues(typeof(Cause)).Length),
                                Weight = random.Next(1, 50),
                                NoOfHeads = random.Next(1, 50),
                                PassedForSlaughter = new PassedForSlaughter()
                                {
                                    NoOfHeads = random.Next(1, 50),
                                    Weight = random.Next(1, 50),
                                    ConductOfInspection = new ConductOfInspection()
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
                                                ReceivingBy = "jess",
                                                AccountDetails = new Areas.Identity.Data.AccountDetails
                                                {
                                                    firstName = "jess",
                                                    lastName = "ingles",
                                                    middleName = "arreza",
                                                    address = "11, DAVAO DEL SUR, DAVAO CITY, MA-A",
                                                    contactNo = "920925902",
                                                    image = "none",
                                                    birthdate = new DateTime(2023, 1, 1),
                                                    sex = "male",
                                                    Roles = Roles.MEATESTABLISHMENTREPRESENTATIVE,
                                                    MeatEstablishment = new MeatEstablishment
                                                    {
                                                        Type = (EstablishmentType)random.Next(1, System.Enum.GetValues(typeof(EstablishmentType)).Length),
                                                        Name = "jess",
                                                        Address = "11, DAVAO DEL SUR, DAVAO CITY, ULAS",
                                                        LicenseToOperateNumber = "09dawjd",
                                                        LicenseStatus = (LicenseStatus)random.Next(1, System.Enum.GetValues(typeof(LicenseStatus)).Length)
                                                    },
                                                    EmailConfirmed = true,
                                                    
                                                },
                                                MeatDealers = new MeatDealers
                                                {
                                                    FirstName = "jess",
                                                    MiddleName = "dwad",
                                                    LastName = "arreza",
                                                    Address = "11, DAVAO DEL SUR, DAVAO CITY, MA-A",
                                                    ContactNo = "09125125",
                                                    MeatEstablishment = new MeatEstablishment
                                                    {
                                                        Type = (EstablishmentType)random.Next(1, System.Enum.GetValues(typeof(EstablishmentType)).Length),
                                                        Name = "jess",
                                                        Address = "11, DAVAO DEL SUR, DAVAO CITY, ULAS",
                                                        LicenseToOperateNumber = "09dawjd",
                                                        LicenseStatus = (LicenseStatus)random.Next(1, System.Enum.GetValues(typeof(LicenseStatus)).Length)
                                                    }

                                                }
                                            }
                                        }

                                    }

                                }
                    }
                        };
                        

                        context.totalNoFitForHumanConsumptions.Add(totalfit);
                    }

                    context.SaveChanges();
                }
            }

            

        }

    }
}
