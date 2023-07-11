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
                                                RepDate = DateTime.Now.Date,
                                                VerifiedByPOSMSHead = "something"
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        },
						new totalNoFitForHumanConsumptions()
						{
							Species = Species.Carabao,
							NoOfHeads = 21,
							DressedWeight = 30,
							Postmortem = new Postmortem()
							{
								AnimalPart = AnimalPart.Trimmings,
								Cause = Cause.something,
								Weight = 90,
								NoOfHeads = 32,
								Images = "Dwadwd",
								PassedForSlaughter = new PassedForSlaughter()
								{
									NoOfHeads = 20,
									Weight = 10,
									ConductOfInspection = new ConductOfInspection()
									{
										Issue = Issue.Rejected,
										NoOfHeads = 10,
										Weight = 11,
										Cause = Cause.something,
										Antemortem = new Antemortem()
										{
											MeatInspectionReport = new MeatInspectionReport()
											{
												RepDate = DateTime.Now.AddHours(6).AddMinutes(30),
												VerifiedByPOSMSHead = "something"

											}
										}
									}
								}
							}
						},


					});
                    context.SaveChanges();
                }
            }
        }
    }
}
