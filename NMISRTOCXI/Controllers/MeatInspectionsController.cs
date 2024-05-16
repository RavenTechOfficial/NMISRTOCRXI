using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;
using DomainLayer.Enum;




namespace thesis.Controllers
{
    public class MeatInspectionsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AccountDetail> _userManager;

        public MeatInspectionsController(AppDbContext context, UserManager<AccountDetail> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: MeatInspectionController
        public ActionResult Index()
        {
            var results = _context.ReceivingReports
                .Join(
                    _context.MeatDealers,
                    rr => rr.MeatDealersId,
                    md => md.Id,
                    (rr, md) => new MeatInspectionViewModel
                    {
                        ReceivingId = rr.Id,
                        RecTime = rr.ReceivedDate,
                        Species = rr.Species,
                        LiveWeight = rr.LiveWeight,
                        ReceivingNoOfHeads = rr.NumberOfHeads,
                        MeatDealer = md.FirstName + " " + md.LastName
                    })
                .ToList();

            return View(results);
        }


        // GET: MeatInspectionController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }
        [HttpGet]
        public JsonResult GetIds(int routeId)
        {
            int? receivingReportId = routeId;

            // Get MeatInspectionReportId using ReceivingReportId
            int? meatInspectionReportId = _context.MeatInspectionReports
                .Where(mir => mir.ReceivingReportId == receivingReportId)
                .Select(mir => (int?)mir.Id)
                .FirstOrDefault();

            // Get ConductOfInspectionId using MeatInspectionReportId
            int? conductOfInspectionId = meatInspectionReportId.HasValue
                ? _context.Antemortems
                    .Where(coi => coi.MeatInspectionReportId == meatInspectionReportId.Value)
                    .Select(coi => (int?)coi.Id)
                    .FirstOrDefault()
                : null;

            // Get PassedForSlaughterId using ConductOfInspectionId
            int? passedForSlaughterId = conductOfInspectionId.HasValue
                ? _context.PassedForSlaughters
                    .Where(pfs => pfs.ConductOfInspectionId == conductOfInspectionId.Value)
                    .Select(pfs => (int?)pfs.Id)
                    .FirstOrDefault()
                : null;

            // Get PostmortemId using PassedForSlaughterId
            int? postmortemId = passedForSlaughterId.HasValue
                ? _context.Postmortems
                    .Where(pm => pm.PassedForSlaughterId == passedForSlaughterId.Value)
                    .Select(pm => (int?)pm.Id)
                    .FirstOrDefault()
                : null;

            // Get TotalNoFitForHumanConsumptionId using PostmortemId
            int? totalNoFitForHumanConsumptionId = postmortemId.HasValue
                ? _context.TotalNoFitForHumanConsumptions
                    .Where(tnfhc => tnfhc.PostmortemId == postmortemId.Value)
                    .Select(tnfhc => (int?)tnfhc.Id)
                    .FirstOrDefault()
                : null;

            var response = new
            {
                ReceivingReportId = receivingReportId,
                MeatInspectionId = meatInspectionReportId,
                ConductOfInspectionId = conductOfInspectionId,
                PassedForSlaughterId = passedForSlaughterId,
                PostmortemId = postmortemId,
                TotalFitId = totalNoFitForHumanConsumptionId
            };




            return Json(response);
        }

        // Populate Ante Table
        [HttpGet]
        public JsonResult GetAnteTableData(int MeatInspectionId)
        {
            var data = _context.Antemortems
                             .Where(c => c.MeatInspectionReportId == MeatInspectionId)
                             .Select(c => new {
                                 Issue = c.Issue.ToString(),
                                 NoOfHeads = c.NoOfHeads,
                                 Weight = c.Weight,
                                 Cause = c.Cause.ToString(),
                                 Id = c.Id
                             })
                             .ToList();

            var totalNoOfHeads = _context.Antemortems
                                   .Where(c => c.MeatInspectionReportId == MeatInspectionId)
                                   .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Antemortems
                                .Where(c => c.MeatInspectionReportId == MeatInspectionId)
                                .Sum(c => c.Weight);

            var result = new
            {
                Data = data,
                TotalNoOfHeads = totalNoOfHeads,
                TotalWeight = totalWeight
            };

            return Json(result);
        }

        public JsonResult GetPostTableData(int PassedForSlaughterId)
        {
            var data = _context.Postmortems
                             .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
                             .Select(c => new {
                                 AnimalPart = c.AnimalPart.ToString(),
                                 NoOfHeads = c.NoOfHeads,
                                 Weight = c.Weight,
                                 Cause = c.Cause.ToString(),
                                 Id = c.Id,
                                 Image1 = c.Image1,
                                 Image2 = c.Image2,
                                 Image3 = c.Image3
                             })
                             .ToList();

            var totalNoOfHeads = _context.Postmortems
                                   .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
                                   .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Postmortems
                                .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
                                .Sum(c => c.Weight);

            var result = new
            {
                Data = data,
                TotalNoOfHeads = totalNoOfHeads,
                TotalWeight = totalWeight
            };

            return Json(result);
        }




        // GET: MeatInspectionController/Create

        public async Task<IActionResult> CreateInspection(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Add the code to count rows in MeatInspectionReports table
            var inspectionCount = await _context.MeatInspectionReports
                .Where(mir => mir.ReceivingReportId == id)
                .CountAsync();

            var meatInspectionViewModel = await _context.ReceivingReports
                .Where(rr => rr.Id == id)
                .Join(
                    _context.MeatDealers,
                    rr => rr.MeatDealersId,
                    md => md.Id,
                    (rr, md) => new MeatInspectionViewModel
                    {
                        ReceivingId = rr.Id,
                        RecTime = rr.RecTime,
                        Species = rr.Species,
                        LiveWeight = rr.LiveWeight,
                        MeatDealer = md.FirstName + " " + md.LastName,
                        ReceivingNoOfHeads = rr.NoOfHeads,
                        InspectionCount = inspectionCount,

                    }
                )
                .FirstOrDefaultAsync();



            var resultId = _context.MeatInspectionReports
             .Where(mir => mir.ReceivingReportId == id)
             .Select(mir => mir.Id)
             .FirstOrDefault();

            var antemortemCount = await _context.Antemortems
                .Where(mir => mir.MeatInspectionReportId == resultId)
                .CountAsync();


            if (antemortemCount > 0)
            {

                var result = _context.Antemortems
                    .Join(
                        _context.MeatInspectionReports,
                        coi => coi.MeatInspectionReportId,
                        mir => mir.Id,
                        (coi, mir) => new { coi, mir }
                    )
                    .Join(
                        _context.ReceivingReports,
                        coiMir => coiMir.mir.ReceivingReportId,
                        rr => rr.Id,
                        (coiMir, rr) => new
                        {
                            coiMir.coi.MeatInspectionReportId,
                            coiMir.coi.Issue,
                            coiMir.coi.NoOfHeads,
                            coiMir.coi.Weight,
                            coiMir.coi.Cause
                        }
                    )
                    .ToList();

                var antemortemInspectionData = _context.Antemortems.Where(item => item.MeatInspectionReportId == resultId).ToList();
                meatInspectionViewModel.AntemortemInspectionData = antemortemInspectionData;

            }

            var postmortemCount = await _context.ReceivingReports
                .Where(rr => rr.Id == id)
                .Join(
                    _context.MeatInspectionReports,
                    rr => rr.Id,
                    mir => mir.ReceivingReportId,
                    (rr, mir) => mir
                )
                .Join(
                    _context.Antemortems,
                    mir => mir.Id,
                    coi => coi.MeatInspectionReportId,
                    (mir, coi) => coi
                )
                .Join(
                    _context.PassedForSlaughters,
                    coi => coi.Id,
                    pfs => pfs.ConductOfInspectionId,
                    (coi, pfs) => pfs
                )
                .Join(
                    _context.Postmortems,
                    pfs => pfs.Id,
                    pm => pm.PassedForSlaughterId,
                    (pfs, pm) => pm
                )
                .CountAsync();

            var passedForSlaughterId = _context.ReceivingReports
                .Where(rr => rr.Id == id)
                .Join(
                    _context.MeatInspectionReports,
                    rr => rr.Id,
                    mir => mir.ReceivingReportId,
                    (rr, mir) => mir
                )
                .Join(
                    _context.Antemortems,
                    mir => mir.Id,
                    coi => coi.MeatInspectionReportId,
                    (mir, coi) => coi
                )
                .Join(
                    _context.PassedForSlaughters,
                    coi => coi.Id,
                    pfs => pfs.ConductOfInspectionId,
                    (coi, pfs) => pfs
                )
                .Join(
                    _context.Postmortems,
                    pfs => pfs.Id,
                    pm => pm.PassedForSlaughterId,
                    (pfs, pm) => pfs.Id
                )
                .FirstOrDefault();

            if (postmortemCount > 0)
            {
                var resultPost = _context.ReceivingReports
                   .Where(rr => rr.Id == id)
                   .Join(
                       _context.MeatInspectionReports,
                       rr => rr.Id,
                       mir => mir.ReceivingReportId,
                       (rr, mir) => mir
                   )
                   .Join(
                       _context.Antemortems,
                       mir => mir.Id,
                       coi => coi.MeatInspectionReportId,
                       (mir, coi) => coi
                   )
                   .Join(
                       _context.PassedForSlaughters,
                       coi => coi.Id,
                       pfs => pfs.ConductOfInspectionId,
                       (coi, pfs) => pfs
                   )
                   .Join(
                       _context.Postmortems,
                       pfs => pfs.Id,
                       pm => pm.PassedForSlaughterId,
                       (pfs, pm) => new
                       {
                           pm.AnimalPart,
                           pm.Cause,
                           pm.Weight,
                           pm.NoOfHeads,
                           pm.Image1,
                           pm.Image2,
                           pm.Image3
                       }
                   )
                   .ToList();

                var postmortemInspectionData = _context.Postmortems.Where(item => item.PassedForSlaughterId == passedForSlaughterId).ToList();
                meatInspectionViewModel.PostmortemInspectionData = postmortemInspectionData;
            }

            if (meatInspectionViewModel == null)
            {
                return NotFound();
            }

            return View(meatInspectionViewModel);
        }



        // ACTIONS FOR AJAX //


        //Random UID Function
        private string GenerateRandomUID(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // INSPECT BUTTON // add data to MeatInspectionReport
        [HttpPost]
        public IActionResult AddMeatInspectionTBL(int receivingId, DateTime dateInspected)
        {
            string randomUID = GenerateRandomUID(8);
            Console.WriteLine($"Received request for receivingId: {receivingId}");



            var loggedInUserId = _userManager.GetUserId(User);
            var result = new MeatInspectionReport
            {
                ReceivingReportId = receivingId,
                ReportDate = dateInspected,
                InspectedById = loggedInUserId,
                UID = randomUID,

            };
            _context.Add(result);
            _context.SaveChanges();

            int MeatInspectionId = result.Id;

            var response = new
            {
                success = true,
                message = "Meat inspection report added successfully.",
                id = MeatInspectionId
            };
            return Json(response);
        }

        // ADD BUTTON // add row to antemortem table 
        [HttpPost]
        public IActionResult AddAntemortemTBL(int meatInsId, int conductHead, double conductWeight, int issue, int cause)
        {


            var result = new MeatInspectionAntemortem
            {
                MeatInspectionReportId = meatInsId,
                NoOfHeads = conductHead,
                Weight = conductWeight,
                Issue = (Issue)issue,
                Cause = (Cause)cause,
            };

            _context.Add(result);
            _context.SaveChanges();

            var totalNoOfHeads = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.Weight);


            var response = new
            {
                success = true,
                message = "Meat inspection report added successfully.",
                id = result.Id,
                issue = result.Issue.ToString(),
                cause = result.Cause.ToString(),
                head = result.NoOfHeads,
                weight = result.Weight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight

            };
            return Json(response);
        }








        [HttpPost]
        // Edit row in Ante Table
        public IActionResult AntemortemRowEdit(int meatInsId, int anteRowId, int conductHead, double conductWeight, int issue, int cause)
        {

            var existingAntemortem = _context.Antemortems.Find(anteRowId);


            existingAntemortem.Issue = (Issue)issue;
            existingAntemortem.NoOfHeads = conductHead;
            existingAntemortem.Weight = conductWeight;
            existingAntemortem.Cause = (Cause)cause;



            // Save the changes to the database
            _context.SaveChanges();

            var enumIssue = (Issue)issue;
            var enumCause = (Cause)cause;

            var totalNoOfHeads = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.Weight);

            var response = new
            {
                success = true,
                issue = enumIssue.ToString(),
                cause = enumCause.ToString(),
                head = conductHead,
                weight = conductWeight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight

            };

            return Json(response);
        }

        // Delete Row in Ante Table
        [HttpPost]
        public IActionResult AntemortemDelete(int meatInsId, int anteRowId)
        {

            var entityToDelete = _context.Antemortems.Find(anteRowId);


            _context.Antemortems.Remove(entityToDelete);
            _context.SaveChanges();

            var firstConductId = _context.Antemortems
                             .Where(c => c.MeatInspectionReportId == meatInsId)
                             .OrderBy(c => c.Id)
                             .Select(c => c.Id)
                             .FirstOrDefault();

            var totalNoOfHeads = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Antemortems
                .Where(c => c.MeatInspectionReportId == meatInsId)
                .Sum(c => c.Weight);

            var response = new
            {
                success = true,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                firstConductId = firstConductId

            };
            return Json(response);
        }

        // NEXT BUTTON // 
        [HttpPost]
        public IActionResult AddPostmortem(int passedHead, double passedWeight, int meatInsId)
        {
            var firstConductId = _context.Antemortems
                             .Where(c => c.MeatInspectionReportId == meatInsId)
                             .OrderBy(c => c.Id)
                             .Select(c => c.Id)
                             .FirstOrDefault();

            var result = new MeatInspectionPassedForSlaughter
            {
                ConductOfInspectionId = firstConductId,
                NumberOfHeads = passedHead,
                Weight = passedWeight,
            };

            _context.Add(result);
            _context.SaveChanges();



            var response = new
            {
                success = true,
                id = result.Id,


            };
            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadImages(List<IFormFile> images, string filename)
        {
            var imagePaths = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePaths.Add(filePath);
                    imageNumber++;
                }
            }

            var response = new
            {
                success = true,
                image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
                image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
                image3 = imagePaths.Count > 2 ? imagePaths[2] : null
            };

            return Json(response);
        }



        // ADD BUTTON // add row to post table 
        [HttpPost]
        public IActionResult AddPostmortemRow(int passedId, int postPart, int postCause, double postWeight, int postHead, List<IFormFile> images)
        {

            var result = new MeatInspectionPostmortem
            {
                PassedForSlaughterId = passedId,
                AnimalPart = (AnimalPart)postPart,
                Cause = (Cause)postCause,
                Weight = postWeight,
                NoOfHeads = postHead,
                //Image1 = null,
                //Image2 = image2,
                //Image3 = image3,
            };
            _context.Add(result);
            _context.SaveChanges();

            var totalNoOfHeads = _context.Postmortems
                .Where(p => p.PassedForSlaughterId == passedId)
                .Sum(p => p.NoOfHeads);

            var totalWeight = _context.Postmortems
                .Where(p => p.PassedForSlaughterId == passedId)
                .Sum(p => p.Weight);

            var filename = passedId + "-" + result.Id + "-" + postPart + "-" + postCause + "-img";

            var imagePaths = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePaths.Add(filePath);
                    imageNumber++;
                }
            }
            var uploadresponse = new
            {
                success = true,
                image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
                image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
                image3 = imagePaths.Count > 2 ? imagePaths[2] : null
            };

            var existingAntemortem = _context.Postmortems.Find(result.Id);

            existingAntemortem.Image1 = uploadresponse.image1;
            existingAntemortem.Image2 = uploadresponse.image2;
            existingAntemortem.Image3 = uploadresponse.image3;



            // Save the changes to the database
            _context.SaveChanges();

            var response = new
            {
                success = true,
                id = result.Id,
                issue = result.AnimalPart.ToString(),
                cause = result.Cause.ToString(),
                head = result.NoOfHeads,
                weight = result.Weight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                image1 = uploadresponse.image1,
                image2 = uploadresponse.image2,
                image3 = uploadresponse.image3
            };

            return Json(response);
        }

        // Postmortem Delete
        [HttpPost]
        public IActionResult PostmortemDelete(int passedId, int postRowId)
        {

            var entityToDelete = _context.Postmortems.Find(postRowId);

            // Get file paths from the Postmortem entity
            var imagePaths = new List<string>
            {
                entityToDelete.Image1,
                entityToDelete.Image2,
                entityToDelete.Image3
            };


            DeleteImageFiles(imagePaths);

            _context.Postmortems.Remove(entityToDelete);
            _context.SaveChanges();

            var firstPostId = _context.Postmortems
                             .Where(c => c.PassedForSlaughterId == passedId)
                             .OrderBy(c => c.Id)
                             .Select(c => c.Id)
                             .FirstOrDefault();

            var totalNoOfHeads = _context.Postmortems
                .Where(c => c.PassedForSlaughterId == passedId)
                .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Postmortems
                .Where(c => c.PassedForSlaughterId == passedId)
                .Sum(c => c.Weight);

            var response = new
            {
                success = true,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                firstPostId

            };
            return Json(response);
        }

        private void DeleteImageFiles(List<string> imagePaths)
        {
            try
            {
                foreach (var imagePath in imagePaths)
                {
                    if (!string.IsNullOrEmpty(imagePath))
                    {



                        if (System.IO.File.Exists(imagePath))
                        {

                            System.IO.File.Delete(imagePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Edit row in postmortem 

        public IActionResult PostmortemRowEdit(int passedId, int postRowId, int postHead, double postWeight, int postPart, int postCause, List<string> imagePaths, List<IFormFile> images)
        {

            DeleteImageFiles(imagePaths);


            var filename = passedId + "-" + postRowId + "-" + postPart + "-" + postCause + "-img";

            var imagePath = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePath.Add(filePath);
                    imageNumber++;
                }
            }
            var uploadresponse = new
            {
                success = true,
                image1 = imagePath.Count > 0 ? imagePath[0] : null,
                image2 = imagePath.Count > 1 ? imagePath[1] : null,
                image3 = imagePath.Count > 2 ? imagePath[2] : null
            };

            var existingAntemortem = _context.Postmortems.Find(postRowId);


            existingAntemortem.AnimalPart = (AnimalPart)postPart;
            existingAntemortem.NoOfHeads = postHead;
            existingAntemortem.Weight = postWeight;
            existingAntemortem.Cause = (Cause)postCause;
            existingAntemortem.Image1 = uploadresponse.image1;
            existingAntemortem.Image2 = uploadresponse.image2;
            existingAntemortem.Image3 = uploadresponse.image3;

            // Save the changes to the database
            _context.SaveChanges();

            var enumPart = (AnimalPart)postPart;
            var enumCause = (Cause)postCause;

            var totalNoOfHeads = _context.Postmortems
                .Where(c => c.PassedForSlaughterId == passedId)
                .Sum(c => c.NoOfHeads);

            var totalWeight = _context.Postmortems
                .Where(c => c.PassedForSlaughterId == passedId)
                .Sum(c => c.Weight);

            var response = new
            {
                success = true,
                postPart = enumPart.ToString(),
                postCause = enumCause.ToString(),
                postHead = postHead,
                postWeight = postWeight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                image1 = uploadresponse.image1,
                image2 = uploadresponse.image2,
                image3 = uploadresponse.image3

            };

            return Json(response);
        }

        //
        [HttpPost]
        public IActionResult AddTotal(int totalHead, double totalWeight, int passedId)
        {
            var firstPostId = _context.Postmortems
                             .Where(c => c.PassedForSlaughterId == passedId)
                             .OrderBy(c => c.Id)
                             .Select(c => c.Id)
                             .FirstOrDefault();

            var result = new TotalNoFitForHumanConsumptions
            {
                PostmortemId = firstPostId,
                NumberOfHeads = totalHead,
                DressedWeight = totalWeight,
            };

            _context.Add(result);
            _context.SaveChanges();


            var response = new
            {
                success = true,
                id = result.Id,
                firstPostId

            };
            return Json(response);
        }

        // 
        [HttpPost]
        public IActionResult AddSummary(int totalId, string destinationName, string destinationAddress, int micIssued, int micCancelled)
        {

            var result = new MeatInspectionSummaryAndDistributionOfMIC
            {
                TotalNoFitForHumanConsumptionId = totalId,
                DestinationName = destinationName,
                DestinationAddress = destinationAddress,
                //CertificateStatus = (CertificateStatus)certStatus,
                MICIssued = micIssued,
                MICCancelled = micCancelled,
            };

            _context.Add(result);
            _context.SaveChanges();


            var response = new
            {
                success = true,
                id = result.Id


            };
            return Json(response);
        }


        // removed old action...


        [HttpPost]
        public IActionResult CreateSummaryTBL(int MeatInsId, string NameVal, string AddVal, int micIssued, int micCancelled, int ReceivingId, int PassedId, MeatInspectionViewModel viewModel)
        {
            int inspectionReportCount = _context.MeatInspectionReports
                .Where(mir => mir.ReceivingReportId == ReceivingId)
                .Count();

            var result = new MeatInspectionSummaryAndDistributionOfMIC
            {
                TotalNoFitForHumanConsumptionId = PassedId,
                DestinationName = NameVal,
                DestinationAddress = AddVal,
                //CertificateStatus = (CertificateStatus)CertStat,
                MICIssued = micIssued,
                MICCancelled = micCancelled,
            };

            _context.Add(result);
            _context.SaveChanges();

            var meatInspectionViewModel = (from rr in _context.ReceivingReports
                                           where rr.Id == ReceivingId
                                           join md in _context.MeatDealers on rr.MeatDealersId equals md.Id
                                           join mir in _context.MeatInspectionReports on rr.Id equals mir.ReceivingReportId
                                           join coi in _context.Antemortems on mir.Id equals coi.MeatInspectionReportId
                                           join pfs in _context.PassedForSlaughters on coi.Id equals pfs.ConductOfInspectionId
                                           join pm in _context.Postmortems on pfs.Id equals pm.PassedForSlaughterId
                                           join tnfhc in _context.TotalNoFitForHumanConsumptions on pm.Id equals tnfhc.PostmortemId
                                           join sadmic in _context.SummaryAndDistributionOfMICs on tnfhc.Id equals sadmic.TotalNoFitForHumanConsumptionId
                                           select new MeatInspectionViewModel
                                           {
                                               ReceivingId = rr.Id,
                                               RecTime = rr.RecTime,
                                               Species = rr.Species,
                                               LiveWeight = rr.LiveWeight,
                                               MeatDealer = md.FirstName + " " + md.LastName,
                                               ReceivingNoOfHeads = rr.NoOfHeads,
                                               MeatInspectionReportId = mir.Id,
                                               NoOfHeadsPassed = pfs.NoOfHeads,
                                               WeightPassed = pfs.Weight,
                                               AntemortemId = coi.Id,
                                               DressedWeight = tnfhc.DressedWeight,
                                               DestinationName = sadmic.DestinationName,
                                               DestinationAddress = sadmic.DestinationAddress,
                                               MICIssued = sadmic.MICIssued,
                                               MICCancelled = sadmic.MICCancelled,
                                               Passed = pfs.Id
                                           })
                            .FirstOrDefault();

            // Assign the values to viewModel properties
            viewModel.RecTime = meatInspectionViewModel.RecTime;
            viewModel.Species = meatInspectionViewModel.Species;
            viewModel.LiveWeight = meatInspectionViewModel.LiveWeight;
            viewModel.MeatDealer = meatInspectionViewModel.MeatDealer;
            viewModel.ReceivingNoOfHeads = meatInspectionViewModel.ReceivingNoOfHeads;
            viewModel.MeatInspectionReportId = meatInspectionViewModel.MeatInspectionReportId;
            viewModel.AntemortemId = meatInspectionViewModel.AntemortemId;
            //   viewModel.Passed = result.Id;
            viewModel.Passed = meatInspectionViewModel.Passed;

            viewModel.NoOfHeadsPassed = meatInspectionViewModel.NoOfHeadsPassed;
            viewModel.WeightPassed = meatInspectionViewModel.WeightPassed;

            viewModel.TotalNoOfHeads = meatInspectionViewModel.NoOfHeadsPassed;
            viewModel.DressedWeight = meatInspectionViewModel.WeightPassed;

            viewModel.DestinationName = meatInspectionViewModel.DestinationName;
            viewModel.DestinationAddress = meatInspectionViewModel.DestinationAddress;
            viewModel.MICIssued = meatInspectionViewModel.MICIssued;
            viewModel.MICCancelled = meatInspectionViewModel.MICCancelled;

            var antemortemInspectionData = _context.Antemortems.Where(item => item.MeatInspectionReportId == MeatInsId).ToList();
            viewModel.AntemortemInspectionData = antemortemInspectionData;

            var postmortemInspectionData = _context.Postmortems.Where(item => item.PassedForSlaughterId == meatInspectionViewModel.Passed).ToList();
            viewModel.PostmortemInspectionData = postmortemInspectionData;

            var receivingReportToUpdate = _context.ReceivingReports.FirstOrDefault(rr => rr.Id == ReceivingId);
            if (receivingReportToUpdate != null)
            {
                // Update the specific column value
                receivingReportToUpdate.InspectionStatus = InspectionStatus.Done;

                // Save the changes to the database
                _context.SaveChanges();
            }

            viewModel.InspectionCount = inspectionReportCount;
            // return View("~/Views/MeatInspections/CreateInspection.cshtml", viewModel);
            return RedirectToAction("DailyInspection", "MeatInspectionReports");
        }


    }
}
