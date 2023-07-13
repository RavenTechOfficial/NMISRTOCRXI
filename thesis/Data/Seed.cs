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

				if (context.totalNoFitForHumanConsumptions.Any())
				{
					// Seed initial data
					context.totalNoFitForHumanConsumptions.AddRange(new List<totalNoFitForHumanConsumptions>()
				{
					new totalNoFitForHumanConsumptions()
					{
						Species = Species.Swine,
						NoOfHeads = 12,
						DressedWeight = 10,
						Postmortem = new Postmortem()
						{
							AnimalPart = AnimalPart.Liver,
							Cause = Cause.something,
							Weight = 10,
							NoOfHeads = 9,
							Images = "Dwadwd",
							PassedForSlaughter = new PassedForSlaughter()
							{
								NoOfHeads = 10,
								Weight = 9,
								ConductOfInspection = new ConductOfInspection()
								{
									Issue = Issue.Suspect,
									NoOfHeads = 10,
									Weight = 11,
									Cause = Cause.something,
									Antemortem = new Antemortem()
									{
										MeatInspectionReport = new MeatInspectionReport()
										{
											RepDate = DateTime.Now,
											VerifiedByPOSMSHead = "something"
										}
									}
								}
							}
						}
					}
				});

					context.SaveChanges();
				}

				// Seed additional 100 sets of data
				//for (int i = 0; i < 100; i++)
				//{
				//	var species = GetRandomSpecies();
				//	var noOfHeads = GetRandomNumber(1, 20);
				//	var dressedWeight = GetRandomNumber(5, 20);
				//	var animalPart = GetRandomAnimalPart();
				//	var cause = GetRandomCause();
				//	var weight = GetRandomNumber(5, 20);
				//	var images = GetRandomImages();
				//	var passedForSlaughterNoOfHeads = GetRandomNumber(5, 20);
				//	var passedForSlaughterWeight = GetRandomNumber(5, 20);
				//	var conductOfInspectionIssue = GetRandomIssue();
				//	var conductOfInspectionNoOfHeads = GetRandomNumber(5, 20);
				//	var conductOfInspectionWeight = GetRandomNumber(5, 20);
				//	var conductOfInspectionCause = GetRandomCause();
				//	var antemortemMeatInspectionReportRepDate = GetRandomDate();
				//	var antemortemMeatInspectionReportVerifiedByPOSMSHead = GetRandomString();

				//	context.totalNoFitForHumanConsumptions.Add(new totalNoFitForHumanConsumptions()
				//	{
				//		Species = species,
				//		NoOfHeads = noOfHeads,
				//		DressedWeight = dressedWeight,
				//		Postmortem = new Postmortem()
				//		{
				//			AnimalPart = animalPart,
				//			Cause = cause,
				//			Weight = weight,
				//			NoOfHeads = noOfHeads,
				//			Images = images,
				//			PassedForSlaughter = new PassedForSlaughter()
				//			{
				//				NoOfHeads = passedForSlaughterNoOfHeads,
				//				Weight = passedForSlaughterWeight,
				//				ConductOfInspection = new ConductOfInspection()
				//				{
				//					Issue = conductOfInspectionIssue,
				//					NoOfHeads = conductOfInspectionNoOfHeads,
				//					Weight = conductOfInspectionWeight,
				//					Cause = conductOfInspectionCause,
				//					Antemortem = new Antemortem()
				//					{
				//						MeatInspectionReport = new MeatInspectionReport()
				//						{
				//							RepDate = antemortemMeatInspectionReportRepDate,
				//							VerifiedByPOSMSHead = antemortemMeatInspectionReportVerifiedByPOSMSHead
				//						}
				//					}
				//				}
				//			}
				//		}
				//	});
				//}

				//context.SaveChanges();
			}
		}

		// Helper methods to generate random values
		private static Species GetRandomSpecies()
		{
			var values = System.Enum.GetValues(typeof(Species));
			var random = new Random();
			return (Species)values.GetValue(random.Next(values.Length));
		}

		private static AnimalPart GetRandomAnimalPart()
		{
			var values = System.Enum.GetValues(typeof(AnimalPart));
			var random = new Random();
			return (AnimalPart)values.GetValue(random.Next(values.Length));
		}
		private static Cause GetRandomCause()
		{
			var values = System.Enum.GetValues(typeof(Cause));
			var random = new Random();
			return (Cause)values.GetValue(random.Next(values.Length));
		}

		private static Issue GetRandomIssue()
		{
			var values = System.Enum.GetValues(typeof(Issue));
			var random = new Random();
			return (Issue)values.GetValue(random.Next(values.Length));
		}

		private static int GetRandomNumber(int min, int max)
		{
			var random = new Random();
			return random.Next(min, max);
		}

		private static string GetRandomImages()
		{
			// Generate random image names or URLs
			// Replace this with your logic to generate random images
			return "RandomImage" + Guid.NewGuid().ToString();
		}

		private static DateTime GetRandomDate()
		{
			var random = new Random();
			var start = new DateTime(2023, 1, 1);
			var range = (DateTime.Today - start).Days;
			return start.AddDays(random.Next(range));
		}

		private static string GetRandomString()
		{
			// Generate random string values
			// Replace this with your logic to generate random strings
			return "RandomString" + Guid.NewGuid().ToString();
		}
	}

}
