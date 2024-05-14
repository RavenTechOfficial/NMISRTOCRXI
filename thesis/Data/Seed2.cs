//using Microsoft.AspNetCore.Identity;
//using System;
//using DomainLayer.Enum;
//using DomainLayer.Models;

//namespace thesis.Data
//{
//    public class Seed2
//    {
//        public static void SeedDatas(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<thesisContext>();

//                context.Database.EnsureCreated();

//                if (context.totalNoFitForHumanConsumptions.Any())
//                {
//                    // Seed initial data
//                    context.totalNoFitForHumanConsumptions.AddRange(new List<totalNoFitForHumanConsumptions>()
//                {
//                    var totalfit = new totalNoFitForHumanConsumptions()
//                    {
//                        Species = Species.Swine,
//                        NoOfHeads = 12,
//                        DressedWeight = 10,
//                        Postmortem = new Postmortem()
//                        {
//                            AnimalPart = AnimalPart.Liver,
//                            Cause = Cause.Actinobacillosis,
//                            Weight = 10,
//                            NoOfHeads = 9,
//                            PassedForSlaughter = new PassedForSlaughter()
//                        {
//                            NoOfHeads = random.Next(1, 50),
//                            Weight = random.Next(1, 50),
//                            ConductOfInspection = new ConductOfInspection()
//                            {
//                                Issue = (Issue)random.Next(1, System.Enum.GetValues(typeof(Issue)).Length),
//                                NoOfHeads = random.Next(1, 50),
//                                Weight = random.Next(1, 101),
//                                Cause = (Cause)random.Next(1, System.Enum.GetValues(typeof(Cause)).Length),
//                                MeatInspectionReport = new MeatInspectionReport
//                                {
//                                    RepDate = randomDateTime,
//                                    VerifiedByPOSMSHead = "jess",
//                                    ReceivingReport = new ReceivingReport
//                                    {
//                                        RecTime = randomDateTime,
//                                        BatchCode = random.Next(100, 1000),
//                                        Species = (Species)random.Next(1, System.Enum.GetValues(typeof(Species)).Length),
//                                        Category = (CategoryOfFoodAnimals)random.Next(1, System.Enum.GetValues(typeof(CategoryOfFoodAnimals)).Length),
//                                        NoOfHeads = random.Next(1, 50),
//                                        LiveWeight = random.Next(1, 101),
//                                        Origin = "jess",
//                                        ShippingDoc = (ShippingDocuments)random.Next(1, System.Enum.GetValues(typeof(ShippingDocuments)).Length),
//                                        HoldingPenNo = random.Next(1, 10),
//                                        ReceivingBy = "jess"
//                                    }
//                                }

//                            }

//                        };
//                }
//                    }
//                });

//                    context.SaveChanges();
//                }

//                //if (!context.MeatDealers.Any())
//                //{
//                //    context.MeatDealers.AddRange(new List<MeatDealers>()
//                //    {
//                //        new MeatDealers()
//                //        {
//                //            FirstName = "jess clarence",
//                //            MiddleName = "ingle",
//                //            LastName = "Arreza",
//                //            Address = "DAVAO CITY, ACACIA",
//                //            ContactNo = "09215125",
//                //            MeatEstablishment = new MeatEstablishment()
//                //            {
//                //                Address = "DAVAO CITY, AGDAO",
//                //                Type = EstablishmentType.CSW,
//                //                Name = "jeff",
//                //                LicenseToOperateNumber = 092
//                //            }
//                //        },
//                //        new MeatDealers()
//                //        {
//                //            FirstName = "jess clarence",
//                //            MiddleName = "ingle",
//                //            LastName = "Arreza",
//                //            Address = "DAVAO CITY, ALAMBRE",
//                //            ContactNo = "09215125",
//                //            MeatEstablishment = new MeatEstablishment()
//                //            {
//                //                Address = "DAVAO CITY, ANGALAN",
//                //                Type = EstablishmentType.CSW,
//                //                Name = "jeff",
//                //                LicenseToOperateNumber = 092
//                //            }
//                //        },
//                //        new MeatDealers()
//                //        {
//                //            FirstName = "jess clarence",
//                //            MiddleName = "ingle",
//                //            LastName = "Arreza",
//                //            Address = "DAVAO CITY, CARMEN",
//                //            ContactNo = "09215125",
//                //            MeatEstablishment = new MeatEstablishment()
//                //            {
//                //                Address = "DAVAO CITY, MA-A",
//                //                Type = EstablishmentType.CSW,
//                //                Name = "jeff",
//                //                LicenseToOperateNumber = 092
//                //            }
//                //        },
//                //        new MeatDealers()
//                //        {
//                //            FirstName = "jess clarence",
//                //            MiddleName = "ingle",
//                //            LastName = "Arreza",
//                //            Address = "DAVAO CITY, MATINA",
//                //            ContactNo = "09215125",
//                //            MeatEstablishment = new MeatEstablishment()
//                //            {
//                //                Address = "DAVAO CITY, MINTAL",
//                //                Type = EstablishmentType.CSW,
//                //                Name = "jeff",
//                //                LicenseToOperateNumber = 092
//                //            }
//                //        },

//                //    });
//                //    context.SaveChanges();
//                //}




//                //Seed additional 100 sets of data
//                //for (int i = 0; i < 50; i++)
//                //{
//                //    var species = GetRandomSpecies();

//                //    var noOfHeads = GetRandomNumber(1, 20);
//                //    var dressedWeight = GetRandomNumber(5, 20);
//                //    var animalPart = GetRandomAnimalPart();
//                //    var cause = GetRandomCause();
//                //    var weight = GetRandomNumber(30, 100);
//                //    var images = GetRandomImages();
//                //    var passedForSlaughterNoOfHeads = GetRandomNumber(5, 20);
//                //    var passedForSlaughterWeight = GetRandomNumber(5, 20);
//                //    var conductOfInspectionIssue = GetRandomIssue();
//                //    var conductOfInspectionNoOfHeads = GetRandomNumber(5, 20);
//                //    var conductOfInspectionWeight = GetRandomNumber(5, 20);
//                //    var conductOfInspectionCause = GetRandomCause();
//                //    var antemortemMeatInspectionReportRepDate = GetRandomDate();
//                //    var antemortemMeatInspectionReportVerifiedByPOSMSHead = GetRandomString();

//                //    context.totalNoFitForHumanConsumptions.Add(new totalNoFitForHumanConsumptions()
//                //    {
//                //        Species = species,
//                //        NoOfHeads = noOfHeads,
//                //        DressedWeight = dressedWeight,
//                //        Postmortem = new Postmortem()
//                //        {
//                //            AnimalPart = animalPart,
//                //            Cause = cause,
//                //            Weight = weight,
//                //            NoOfHeads = noOfHeads,
//                //            Images = images,
//                //            PassedForSlaughter = new PassedForSlaughter()
//                //            {
//                //                NoOfHeads = passedForSlaughterNoOfHeads,
//                //                Weight = passedForSlaughterWeight,
//                //                ConductOfInspection = new ConductOfInspection()
//                //                {
//                //                    Issue = conductOfInspectionIssue,
//                //                    NoOfHeads = conductOfInspectionNoOfHeads,
//                //                    Weight = conductOfInspectionWeight,
//                //                    Cause = conductOfInspectionCause,
//                //                        MeatInspectionReport = new MeatInspectionReport()
//                //                        {
//                //                            RepDate = antemortemMeatInspectionReportRepDate,
//                //                            VerifiedByPOSMSHead = antemortemMeatInspectionReportVerifiedByPOSMSHead
//                //                        }
//                //                }
//                //            }
//                //        }
//                //    });
//                //}

//                context.SaveChanges();
//            }
//        }






//        // Helper methods to generate random values
//        private static Species GetRandomSpecies()
//        {
//            var values = System.Enum.GetValues(typeof(Species));
//            var random = new Random();
//            return (Species)values.GetValue(random.Next(values.Length));
//        }

//        private static AnimalPart GetRandomAnimalPart()
//        {
//            var values = System.Enum.GetValues(typeof(AnimalPart));
//            var random = new Random();
//            return (AnimalPart)values.GetValue(random.Next(values.Length));
//        }
//        private static Cause GetRandomCause()
//        {
//            var values = System.Enum.GetValues(typeof(Cause));
//            var random = new Random();
//            return (Cause)values.GetValue(random.Next(values.Length));
//        }

//        private static Issue GetRandomIssue()
//        {
//            var values = System.Enum.GetValues(typeof(Issue));
//            var random = new Random();
//            return (Issue)values.GetValue(random.Next(values.Length));
//        }

//        private static int GetRandomNumber(int min, int max)
//        {
//            var random = new Random();
//            return random.Next(min, max);
//        }

//        private static string GetRandomImages()
//        {
//            // Generate random image names or URLs
//            // Replace this with your logic to generate random images
//            return "RandomImage" + Guid.NewGuid().ToString();
//        }

//        private static DateTime GetRandomDate()
//        {
//            var random = new Random();
//            var start = new DateTime(2023, 1, 1);
//            var range = (DateTime.Today - start).Days;
//            return start.AddDays(random.Next(range));
//        }

//        private static string GetRandomString()
//        {
//            // Generate random string values
//            // Replace this with your logic to generate random strings
//            return "RandomString" + Guid.NewGuid().ToString();
//        }
//    }

//}
