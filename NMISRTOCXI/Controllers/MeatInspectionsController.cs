using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using ServiceLayer.Services.IRepositories;
using AutoMapper;




namespace NMISRTOCXI.Controllers
{
    public class MeatInspectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AccountDetails> _userManager;

        public MeatInspectionsController(IUnitOfWork unitOfWork, 
            IMapper mapper,
            UserManager<AccountDetails> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateInspection(Guid? Id)
        {
            var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id,
                includeProperties: "MeatDealers,AccountDetails,MeatInspectionReport," +
                "Antemortems,PassedForSlaughter,Postmortems,TotalNoFitForHumanConsumption");

            var receivingReportMapped = _mapper.Map<ReceivingReportViewModel>(receivingReport);
            return View(receivingReportMapped);
        }
        // GET: MeatInspectionController
        //public ActionResult Index()
        //{
        //    //var results = _unitOfWork.ReceivingReports
        //    //    .Join(
        //    //        _unitOfWork.MeatDealers,
        //    //        rr => rr.MeatDealersId,
        //    //        md => md.Id,
        //    //        (rr, md) => new MeatInspectionViewModel
        //    //        {
        //    //            ReceivingId = rr.Id,
        //    //            RecTime = rr.RecTime,
        //    //            Species = rr.Species,
        //    //            LiveWeight = rr.LiveWeight,
        //    //            ReceivingNoOfHeads = rr.NoOfHeads,
        //    //            MeatDealer = md.FirstName + " " + md.LastName
        //    //        })
        //    //    .ToList();

        //    //return View(results);
        //    return null;
        //}


        //// GET: MeatInspectionController/Details/5
        //public ActionResult Details(int id)
        //{

        //    return View();
        //}
        //[HttpGet]
        //public JsonResult GetIds(Guid routeId)
        //{
        //    Guid? receivingReportId = routeId;

        //    // Get MeatInspectionReportId using ReceivingReportId
        //    int? meatInspectionReportId = _unitOfWork.MeatInspectionReports
        //        .Where(mir => mir.ReceivingReportId == receivingReportId)
        //        .Select(mir => (int?)mir.Id)
        //        .FirstOrDefault();

        //    // Get ConductOfInspectionId using MeatInspectionReportId
        //    int? conductOfInspectionId = meatInspectionReportId.HasValue
        //        ? _unitOfWork.Antemortems
        //            .Where(coi => coi.MeatInspectionReportId == meatInspectionReportId.Value)
        //            .Select(coi => (int?)coi.Id)
        //            .FirstOrDefault()
        //        : null;

        //    // Get PassedForSlaughterId using ConductOfInspectionId
        //    int? passedForSlaughterId = conductOfInspectionId.HasValue
        //        ? _unitOfWork.PassedForSlaughters
        //            .Where(pfs => pfs.ConductOfInspectionId == conductOfInspectionId.Value)
        //            .Select(pfs => (int?)pfs.Id)
        //            .FirstOrDefault()
        //        : null;

        //    // Get PostmortemId using PassedForSlaughterId
        //    int? postmortemId = passedForSlaughterId.HasValue
        //        ? _unitOfWork.Postmortems
        //            .Where(pm => pm.PassedForSlaughterId == passedForSlaughterId.Value)
        //            .Select(pm => (int?)pm.Id)
        //            .FirstOrDefault()
        //        : null;

        //    // Get TotalNoFitForHumanConsumptionId using PostmortemId
        //    int? totalNoFitForHumanConsumptionId = postmortemId.HasValue
        //        ? _unitOfWork.TotalNoFitForHumanConsumptions
        //            .Where(tnfhc => tnfhc.PostmortemId == postmortemId.Value)
        //            .Select(tnfhc => (int?)tnfhc.Id)
        //            .FirstOrDefault()
        //        : null;

        //    var response = new
        //    {
        //        ReceivingReportId = receivingReportId,
        //        MeatInspectionId = meatInspectionReportId,
        //        ConductOfInspectionId = conductOfInspectionId,
        //        PassedForSlaughterId = passedForSlaughterId,
        //        PostmortemId = postmortemId,
        //        TotalFitId = totalNoFitForHumanConsumptionId
        //    };




        //    return Json(response);
        //}

        //// Populate Ante Table
        //[HttpGet]
        //public JsonResult GetAnteTableData(int MeatInspectionId)
        //{
        //    var data = _unitOfWork.Antemortems
        //                     .Where(c => c.MeatInspectionReportId == MeatInspectionId)
        //                     .Select(c => new {
        //                         Issue = c.Issue.ToString(),
        //                         NoOfHeads = c.NoOfHeads,
        //                         Weight = c.Weight,
        //                         Cause = c.Cause.ToString(),
        //                         Id = c.Id
        //                     })
        //                     .ToList();

        //    var totalNoOfHeads = _unitOfWork.Antemortems
        //                           .Where(c => c.MeatInspectionReportId == MeatInspectionId)
        //                           .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Antemortems
        //                        .Where(c => c.MeatInspectionReportId == MeatInspectionId)
        //                        .Sum(c => c.Weight);

        //    var result = new
        //    {
        //        Data = data,
        //        TotalNoOfHeads = totalNoOfHeads,
        //        TotalWeight = totalWeight
        //    };

        //    return Json(result);
        //}

        //public JsonResult GetPostTableData(int PassedForSlaughterId)
        //{
        //    var data = _unitOfWork.Postmortems
        //                     .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
        //                     .Select(c => new {
        //                         AnimalPart = c.AnimalPart.ToString(),
        //                         NoOfHeads = c.NoOfHeads,
        //                         Weight = c.Weight,
        //                         Cause = c.Cause.ToString(),
        //                         Id = c.Id,
        //                         Image1 = c.Image1,
        //                         Image2 = c.Image2,
        //                         Image3 = c.Image3
        //                     })
        //                     .ToList();

        //    var totalNoOfHeads = _unitOfWork.Postmortems
        //                           .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
        //                           .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Postmortems
        //                        .Where(c => c.PassedForSlaughterId == PassedForSlaughterId)
        //                        .Sum(c => c.Weight);

        //    var result = new
        //    {
        //        Data = data,
        //        TotalNoOfHeads = totalNoOfHeads,
        //        TotalWeight = totalWeight
        //    };

        //    return Json(result);
        //}




        //// GET: MeatInspectionController/Create

        //public async Task<IActionResult> CreateInspection(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //// Add the code to count rows in MeatInspectionReports table
        //    //var inspectionCount = await _unitOfWork.MeatInspectionReports
        //    //    .Where(mir => mir.ReceivingReportId == id)
        //    //    .CountAsync();

        //    //var meatInspectionViewModel = await _unitOfWork.ReceivingReports
        //    //    .Where(rr => rr.Id == id)
        //    //    .Join(
        //    //        _unitOfWork.MeatDealers,
        //    //        rr => rr.MeatDealersId,
        //    //        md => md.Id,
        //    //        (rr, md) => new MeatInspectionViewModel
        //    //        {
        //    //            ReceivingId = rr.Id,
        //    //            RecTime = rr.RecTime,
        //    //            Species = rr.Species,
        //    //            LiveWeight = rr.LiveWeight,
        //    //            MeatDealer = md.FirstName + " " + md.LastName,
        //    //            ReceivingNoOfHeads = rr.NoOfHeads,
        //    //            InspectionCount = inspectionCount,

        //    //        }
        //    //    )
        //    //    .FirstOrDefaultAsync();



        //    //var resultId = _unitOfWork.MeatInspectionReports
        //    // .Where(mir => mir.ReceivingReportId == id)
        //    // .Select(mir => mir.Id)
        //    // .FirstOrDefault();

        //    //var antemortemCount = await _unitOfWork.ConductOfInspections
        //    //    .Where(mir => mir.MeatInspectionReportId == resultId)
        //    //    .CountAsync();


        //    //if (antemortemCount > 0)
        //    //{

        //    //    var result = _unitOfWork.ConductOfInspections
        //    //        .Join(
        //    //            _unitOfWork.MeatInspectionReports,
        //    //            coi => coi.MeatInspectionReportId,
        //    //            mir => mir.Id,
        //    //            (coi, mir) => new { coi, mir }
        //    //        )
        //    //        .Join(
        //    //            _unitOfWork.ReceivingReports,
        //    //            coiMir => coiMir.mir.ReceivingReportId,
        //    //            rr => rr.Id,
        //    //            (coiMir, rr) => new
        //    //            {
        //    //                coiMir.coi.MeatInspectionReportId,
        //    //                coiMir.coi.Issue,
        //    //                coiMir.coi.NoOfHeads,
        //    //                coiMir.coi.Weight,
        //    //                coiMir.coi.Cause
        //    //            }
        //    //        )
        //    //        .ToList();

        //    //    var antemortemInspectionData = _unitOfWork.ConductOfInspections.Where(item => item.MeatInspectionReportId == resultId).ToList();
        //    //    meatInspectionViewModel.AntemortemInspectionData = antemortemInspectionData;

        //    //}

        //    //var postmortemCount = await _unitOfWork.ReceivingReports
        //    //    .Where(rr => rr.Id == id)
        //    //    .Join(
        //    //        _unitOfWork.MeatInspectionReports,
        //    //        rr => rr.Id,
        //    //        mir => mir.ReceivingReportId,
        //    //        (rr, mir) => mir
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.ConductOfInspections,
        //    //        mir => mir.Id,
        //    //        coi => coi.MeatInspectionReportId,
        //    //        (mir, coi) => coi
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.PassedForSlaughters,
        //    //        coi => coi.Id,
        //    //        pfs => pfs.ConductOfInspectionId,
        //    //        (coi, pfs) => pfs
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.Postmortems,
        //    //        pfs => pfs.Id,
        //    //        pm => pm.PassedForSlaughterId,
        //    //        (pfs, pm) => pm
        //    //    )
        //    //    .CountAsync();

        //    //var passedForSlaughterId = _unitOfWork.ReceivingReports
        //    //    .Where(rr => rr.Id == id)
        //    //    .Join(
        //    //        _unitOfWork.MeatInspectionReports,
        //    //        rr => rr.Id,
        //    //        mir => mir.ReceivingReportId,
        //    //        (rr, mir) => mir
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.ConductOfInspections,
        //    //        mir => mir.Id,
        //    //        coi => coi.MeatInspectionReportId,
        //    //        (mir, coi) => coi
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.PassedForSlaughters,
        //    //        coi => coi.Id,
        //    //        pfs => pfs.ConductOfInspectionId,
        //    //        (coi, pfs) => pfs
        //    //    )
        //    //    .Join(
        //    //        _unitOfWork.Postmortems,
        //    //        pfs => pfs.Id,
        //    //        pm => pm.PassedForSlaughterId,
        //    //        (pfs, pm) => pfs.Id
        //    //    )
        //    //    .FirstOrDefault();

        //    //if (postmortemCount > 0)
        //    //{
        //    //    var resultPost = _unitOfWork.ReceivingReports
        //    //       .Where(rr => rr.Id == id)
        //    //       .Join(
        //    //           _unitOfWork.MeatInspectionReports,
        //    //           rr => rr.Id,
        //    //           mir => mir.ReceivingReportId,
        //    //           (rr, mir) => mir
        //    //       )
        //    //       .Join(
        //    //           _unitOfWork.ConductOfInspections,
        //    //           mir => mir.Id,
        //    //           coi => coi.MeatInspectionReportId,
        //    //           (mir, coi) => coi
        //    //       )
        //    //       .Join(
        //    //           _unitOfWork.PassedForSlaughters,
        //    //           coi => coi.Id,
        //    //           pfs => pfs.ConductOfInspectionId,
        //    //           (coi, pfs) => pfs
        //    //       )
        //    //       .Join(
        //    //           _unitOfWork.Postmortems,
        //    //           pfs => pfs.Id,
        //    //           pm => pm.PassedForSlaughterId,
        //    //           (pfs, pm) => new
        //    //           {
        //    //               pm.AnimalPart,
        //    //               pm.Cause,
        //    //               pm.Weight,
        //    //               pm.NoOfHeads,
        //    //               pm.Image1,
        //    //               pm.Image2,
        //    //               pm.Image3
        //    //           }
        //    //       )
        //    //       .ToList();

        //    //    var postmortemInspectionData = _unitOfWork.Postmortems.Where(item => item.PassedForSlaughterId == passedForSlaughterId).ToList();
        //    //    meatInspectionViewModel.PostmortemInspectionData = postmortemInspectionData;
        //    //}

        //    //if (meatInspectionViewModel == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(meatInspectionViewModel);
        //    return null;
        //}



        //// ACTIONS FOR AJAX //


        ////Random UID Function
        //private string GenerateRandomUID(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        //    var random = new Random();
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}


        //// INSPECT BUTTON // add data to MeatInspectionReport
        //[HttpPost]
        //public IActionResult AddMeatInspectionTBL(Guid receivingId, DateTime dateInspected)
        //{
        //    string randomUID = GenerateRandomUID(8);
        //    Console.WriteLine($"Received request for receivingId: {receivingId}");



        //    var loggedInUserId = _userManager.GetUserId(User);
        //    var result = new MeatInspectionReport
        //    {
        //        ReceivingReportId = receivingId,
        //        RepDate = dateInspected,
        //        AccountDetailsId = loggedInUserId,
        //        UID = randomUID,

        //    };
        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();

        //    int MeatInspectionId = result.Id;

        //    var response = new
        //    {
        //        success = true,
        //        message = "Meat inspection report added successfully.",
        //        id = MeatInspectionId
        //    };
        //    return Json(response);
        //}

        //// ADD BUTTON // add row to antemortem table 
        //[HttpPost]
        //public IActionResult AddAntemortemTBL(Guid Id, int conductHead, double conductWeight, int issue, int cause)
        //{


        //    var result = new Antemortem
        //    {
        //        ReceivingReportId = Id,
        //        NoOfHeads = conductHead,
        //        Weight = conductWeight,
        //        Issue = (Issue)issue,
        //        Cause = (Cause)cause,
        //    };

        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();

        //    var totalNoOfHeads = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == Id)
        //        .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == Id)
        //        .Sum(c => c.Weight);


        //    var response = new
        //    {
        //        success = true,
        //        message = "Meat inspection report added successfully.",
        //        id = result.Id,
        //        issue = result.Issue.ToString(),
        //        cause = result.Cause.ToString(),
        //        head = result.NoOfHeads,
        //        weight = result.Weight,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight

        //    };
        //    return Json(response);
        //}








        //[HttpPost]
        //// Edit row in Ante Table
        //public IActionResult AntemortemRowEdit(int meatInsId, int anteRowId, int conductHead, double conductWeight, int issue, int cause)
        //{

        //    var existingAntemortem = _unitOfWork.Antemortems.Find(anteRowId);


        //    existingAntemortem.Issue = (Issue)issue;
        //    existingAntemortem.NoOfHeads = conductHead;
        //    existingAntemortem.Weight = conductWeight;
        //    existingAntemortem.Cause = (Cause)cause;



        //    // Save the changes to the database
        //    _unitOfWork.SaveChanges();

        //    var enumIssue = (Issue)issue;
        //    var enumCause = (Cause)cause;

        //    var totalNoOfHeads = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == meatInsId)
        //        .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == meatInsId)
        //        .Sum(c => c.Weight);

        //    var response = new
        //    {
        //        success = true,
        //        issue = enumIssue.ToString(),
        //        cause = enumCause.ToString(),
        //        head = conductHead,
        //        weight = conductWeight,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight

        //    };

        //    return Json(response);
        //}

        //// Delete Row in Ante Table
        //[HttpPost]
        //public IActionResult AntemortemDelete(int meatInsId, int anteRowId)
        //{

        //    var entityToDelete = _unitOfWork.Antemortems.Find(anteRowId);


        //    _unitOfWork.Antemortems.Remove(entityToDelete);
        //    _unitOfWork.SaveChanges();

        //    var firstConductId = _unitOfWork.Antemortems
        //                     .Where(c => c.MeatInspectionReportId == meatInsId)
        //                     .OrderBy(c => c.Id)
        //                     .Select(c => c.Id)
        //                     .FirstOrDefault();

        //    var totalNoOfHeads = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == meatInsId)
        //        .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Antemortems
        //        .Where(c => c.MeatInspectionReportId == meatInsId)
        //        .Sum(c => c.Weight);

        //    var response = new
        //    {
        //        success = true,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight,
        //        firstConductId = firstConductId

        //    };
        //    return Json(response);
        //}

        //// NEXT BUTTON // 
        //[HttpPost]
        //public IActionResult AddPostmortem(int passedHead, double passedWeight, int meatInsId)
        //{
        //    var firstConductId = _unitOfWork.Antemortems
        //                     .Where(c => c.MeatInspectionReportId == meatInsId)
        //                     .OrderBy(c => c.Id)
        //                     .Select(c => c.Id)
        //                     .FirstOrDefault();

        //    var result = new PassedForSlaughter
        //    {
        //        ConductOfInspectionId = firstConductId,
        //        NoOfHeads = passedHead,
        //        Weight = passedWeight,
        //    };

        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();



        //    var response = new
        //    {
        //        success = true,
        //        id = result.Id,


        //    };
        //    return Json(response);
        //}

        //[HttpPost]
        //public IActionResult UploadImages(List<IFormFile> images, string filename)
        //{
        //    var imagePaths = new List<string>();
        //    var imageNumber = 1;
        //    foreach (var image in images)
        //    {
        //        if (image != null && image.Length > 0)
        //        {
        //            // Construct the unique filename by appending the imageNumber to the provided filename
        //            var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
        //            var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                image.CopyTo(fileStream);
        //            }

        //            imagePaths.Add(filePath);
        //            imageNumber++;
        //        }
        //    }

        //    var response = new
        //    {
        //        success = true,
        //        image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
        //        image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
        //        image3 = imagePaths.Count > 2 ? imagePaths[2] : null
        //    };

        //    return Json(response);
        //}



        //// ADD BUTTON // add row to post table 
        //[HttpPost]
        //public IActionResult AddPostmortemRow(int passedId, int postPart, int postCause, double postWeight, int postHead, List<IFormFile> images)
        //{

        //    var result = new Postmortem
        //    {
        //        PassedForSlaughterId = passedId,
        //        AnimalPart = (AnimalPart)postPart,
        //        Cause = (Cause)postCause,
        //        Weight = postWeight,
        //        NoOfHeads = postHead,
        //        //Image1 = null,
        //        //Image2 = image2,
        //        //Image3 = image3,
        //    };
        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();

        //    var totalNoOfHeads = _unitOfWork.Postmortems
        //        .Where(p => p.PassedForSlaughterId == passedId)
        //        .Sum(p => p.NoOfHeads);

        //    var totalWeight = _unitOfWork.Postmortems
        //        .Where(p => p.PassedForSlaughterId == passedId)
        //        .Sum(p => p.Weight);

        //    var filename = passedId + "-" + result.Id + "-" + postPart + "-" + postCause + "-img";

        //    var imagePaths = new List<string>();
        //    var imageNumber = 1;
        //    foreach (var image in images)
        //    {
        //        if (image != null && image.Length > 0)
        //        {
        //            // Construct the unique filename by appending the imageNumber to the provided filename
        //            var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
        //            var filePath = Path.Combine($"wwwroot/img/PostmortemImages/{postPart}/{postCause}", uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                image.CopyTo(fileStream);
        //            }

        //            imagePaths.Add(filePath);
        //            imageNumber++;
        //        }
        //    }
        //    var uploadresponse = new
        //    {
        //        success = true,
        //        image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
        //        image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
        //        image3 = imagePaths.Count > 2 ? imagePaths[2] : null
        //    };

        //    var existingAntemortem = _unitOfWork.Postmortems.Find(result.Id);

        //    existingAntemortem.Image1 = uploadresponse.image1;
        //    existingAntemortem.Image2 = uploadresponse.image2;
        //    existingAntemortem.Image3 = uploadresponse.image3;



        //    // Save the changes to the database
        //    _unitOfWork.SaveChanges();

        //    var response = new
        //    {
        //        success = true,
        //        id = result.Id,
        //        issue = result.AnimalPart.ToString(),
        //        cause = result.Cause.ToString(),
        //        head = result.NoOfHeads,
        //        weight = result.Weight,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight,
        //        image1 = uploadresponse.image1,
        //        image2 = uploadresponse.image2,
        //        image3 = uploadresponse.image3
        //    };

        //    return Json(response);
        //}

        //// Postmortem Delete
        //[HttpPost]
        //public IActionResult PostmortemDelete(int passedId, int postRowId)
        //{

        //    var entityToDelete = _unitOfWork.Postmortems.Find(postRowId);

        //    // Get file paths from the Postmortem entity
        //    var imagePaths = new List<string>
        //    {
        //        entityToDelete.Image1,
        //        entityToDelete.Image2,
        //        entityToDelete.Image3
        //    };


        //    DeleteImageFiles(imagePaths);

        //    _unitOfWork.Postmortems.Remove(entityToDelete);
        //    _unitOfWork.SaveChanges();

        //    var firstPostId = _unitOfWork.Postmortems
        //                     .Where(c => c.PassedForSlaughterId == passedId)
        //                     .OrderBy(c => c.Id)
        //                     .Select(c => c.Id)
        //                     .FirstOrDefault();

        //    var totalNoOfHeads = _unitOfWork.Postmortems
        //        .Where(c => c.PassedForSlaughterId == passedId)
        //        .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Postmortems
        //        .Where(c => c.PassedForSlaughterId == passedId)
        //        .Sum(c => c.Weight);

        //    var response = new
        //    {
        //        success = true,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight,
        //        firstPostId

        //    };
        //    return Json(response);
        //}

        //private void DeleteImageFiles(List<string> imagePaths)
        //{
        //    try
        //    {
        //        foreach (var imagePath in imagePaths)
        //        {
        //            if (!string.IsNullOrEmpty(imagePath))
        //            {



        //                if (System.IO.File.Exists(imagePath))
        //                {

        //                    System.IO.File.Delete(imagePath);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //// Edit row in postmortem 

        //public IActionResult PostmortemRowEdit(int passedId, int postRowId, int postHead, double postWeight, int postPart, int postCause, List<string> imagePaths, List<IFormFile> images)
        //{

        //    DeleteImageFiles(imagePaths);


        //    var filename = passedId + "-" + postRowId + "-" + postPart + "-" + postCause + "-img";

        //    var imagePath = new List<string>();
        //    var imageNumber = 1;
        //    foreach (var image in images)
        //    {
        //        if (image != null && image.Length > 0)
        //        {
        //            // Construct the unique filename by appending the imageNumber to the provided filename
        //            var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
        //            var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                image.CopyTo(fileStream);
        //            }

        //            imagePath.Add(filePath);
        //            imageNumber++;
        //        }
        //    }
        //    var uploadresponse = new
        //    {
        //        success = true,
        //        image1 = imagePath.Count > 0 ? imagePath[0] : null,
        //        image2 = imagePath.Count > 1 ? imagePath[1] : null,
        //        image3 = imagePath.Count > 2 ? imagePath[2] : null
        //    };

        //    var existingAntemortem = _unitOfWork.Postmortems.Find(postRowId);


        //    existingAntemortem.AnimalPart = (AnimalPart)postPart;
        //    existingAntemortem.NoOfHeads = postHead;
        //    existingAntemortem.Weight = postWeight;
        //    existingAntemortem.Cause = (Cause)postCause;
        //    existingAntemortem.Image1 = uploadresponse.image1;
        //    existingAntemortem.Image2 = uploadresponse.image2;
        //    existingAntemortem.Image3 = uploadresponse.image3;

        //    // Save the changes to the database
        //    _unitOfWork.SaveChanges();

        //    var enumPart = (AnimalPart)postPart;
        //    var enumCause = (Cause)postCause;

        //    var totalNoOfHeads = _unitOfWork.Postmortems
        //        .Where(c => c.PassedForSlaughterId == passedId)
        //        .Sum(c => c.NoOfHeads);

        //    var totalWeight = _unitOfWork.Postmortems
        //        .Where(c => c.PassedForSlaughterId == passedId)
        //        .Sum(c => c.Weight);

        //    var response = new
        //    {
        //        success = true,
        //        postPart = enumPart.ToString(),
        //        postCause = enumCause.ToString(),
        //        postHead = postHead,
        //        postWeight = postWeight,
        //        totalhead = totalNoOfHeads,
        //        totalweight = totalWeight,
        //        image1 = uploadresponse.image1,
        //        image2 = uploadresponse.image2,
        //        image3 = uploadresponse.image3

        //    };

        //    return Json(response);
        //}

        ////
        //[HttpPost]
        //public IActionResult AddTotal(int totalHead, double totalWeight, int passedId)
        //{
        //    var firstPostId = _unitOfWork.Postmortems
        //                     .Where(c => c.PassedForSlaughterId == passedId)
        //                     .OrderBy(c => c.Id)
        //                     .Select(c => c.Id)
        //                     .FirstOrDefault();

        //    var result = new TotalNoFitForHumanConsumptions
        //    {
        //        PostmortemId = firstPostId,
        //        NoOfHeads = totalHead,
        //        DressedWeight = totalWeight,
        //    };

        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();


        //    var response = new
        //    {
        //        success = true,
        //        id = result.Id,
        //        firstPostId

        //    };
        //    return Json(response);
        //}

        //// 
        //[HttpPost]
        //public IActionResult AddSummary(int totalId, string destinationName, string destinationAddress, int micIssued, int micCancelled)
        //{

        //    var result = new SummaryAndDistributionOfMIC
        //    {
        //        TotalNoFitForHumanConsumptionId = totalId,
        //        DestinationName = destinationName,
        //        DestinationAddress = destinationAddress,
        //        //CertificateStatus = (CertificateStatus)certStatus,
        //        MICIssued = micIssued,
        //        MICCancelled = micCancelled,
        //    };

        //    _unitOfWork.Add(result);
        //    _unitOfWork.SaveChanges();


        //    var response = new
        //    {
        //        success = true,
        //        id = result.Id


        //    };
        //    return Json(response);
        //}


        //// removed old action...


        //[HttpPost]
        //public IActionResult CreateSummaryTBL(int MeatInsId, string NameVal, string AddVal, int micIssued, int micCancelled, int ReceivingId, int PassedId, MeatInspectionViewModel viewModel)
        //{
        //    //int inspectionReportCount = _unitOfWork.MeatInspectionReports
        //    //    .Where(mir => mir.ReceivingReportId == ReceivingId)
        //    //    .Count();

        //    //var result = new SummaryAndDistributionOfMIC
        //    //{
        //    //    TotalNoFitForHumanConsumptionId = PassedId,
        //    //    DestinationName = NameVal,
        //    //    DestinationAddress = AddVal,
        //    //    //CertificateStatus = (CertificateStatus)CertStat,
        //    //    MICIssued = micIssued,
        //    //    MICCancelled = micCancelled,
        //    //};

        //    //_unitOfWork.Add(result);
        //    //_unitOfWork.SaveChanges();

        //    //var meatInspectionViewModel = (from rr in _unitOfWork.ReceivingReports
        //    //                               where rr.Id == ReceivingId
        //    //                               join md in _unitOfWork.MeatDealers on rr.MeatDealersId equals md.Id
        //    //                               join mir in _unitOfWork.MeatInspectionReports on rr.Id equals mir.ReceivingReportId
        //    //                               join coi in _unitOfWork.ConductOfInspections on mir.Id equals coi.MeatInspectionReportId
        //    //                               join pfs in _unitOfWork.PassedForSlaughters on coi.Id equals pfs.ConductOfInspectionId
        //    //                               join pm in _unitOfWork.Postmortems on pfs.Id equals pm.PassedForSlaughterId
        //    //                               join tnfhc in _unitOfWork.TotalNoFitForHumanConsumptions on pm.Id equals tnfhc.PostmortemId
        //    //                               join sadmic in _unitOfWork.SummaryAndDistributionOfMICs on tnfhc.Id equals sadmic.TotalNoFitForHumanConsumptionId
        //    //                               select new MeatInspectionViewModel
        //    //                               {
        //    //                                   ReceivingId = rr.Id,
        //    //                                   RecTime = rr.RecTime,
        //    //                                   Species = rr.Species,
        //    //                                   LiveWeight = rr.LiveWeight,
        //    //                                   MeatDealer = md.FirstName + " " + md.LastName,
        //    //                                   ReceivingNoOfHeads = rr.NoOfHeads,
        //    //                                   MeatInspectionReportId = mir.Id,
        //    //                                   NoOfHeadsPassed = pfs.NoOfHeads,
        //    //                                   WeightPassed = pfs.Weight,
        //    //                                   AntemortemId = coi.Id,
        //    //                                   DressedWeight = tnfhc.DressedWeight,
        //    //                                   DestinationName = sadmic.DestinationName,
        //    //                                   DestinationAddress = sadmic.DestinationAddress,
        //    //                                   MICIssued = sadmic.MICIssued,
        //    //                                   MICCancelled = sadmic.MICCancelled,
        //    //                                   Passed = pfs.Id
        //    //                               })
        //    //                .FirstOrDefault();

        //    //// Assign the values to viewModel properties
        //    //viewModel.RecTime = meatInspectionViewModel.RecTime;
        //    //viewModel.Species = meatInspectionViewModel.Species;
        //    //viewModel.LiveWeight = meatInspectionViewModel.LiveWeight;
        //    //viewModel.MeatDealer = meatInspectionViewModel.MeatDealer;
        //    //viewModel.ReceivingNoOfHeads = meatInspectionViewModel.ReceivingNoOfHeads;
        //    //viewModel.MeatInspectionReportId = meatInspectionViewModel.MeatInspectionReportId;
        //    //viewModel.AntemortemId = meatInspectionViewModel.AntemortemId;
        //    ////   viewModel.Passed = result.Id;
        //    //viewModel.Passed = meatInspectionViewModel.Passed;

        //    //viewModel.NoOfHeadsPassed = meatInspectionViewModel.NoOfHeadsPassed;
        //    //viewModel.WeightPassed = meatInspectionViewModel.WeightPassed;

        //    //viewModel.TotalNoOfHeads = meatInspectionViewModel.NoOfHeadsPassed;
        //    //viewModel.DressedWeight = meatInspectionViewModel.WeightPassed;

        //    //viewModel.DestinationName = meatInspectionViewModel.DestinationName;
        //    //viewModel.DestinationAddress = meatInspectionViewModel.DestinationAddress;
        //    //viewModel.MICIssued = meatInspectionViewModel.MICIssued;
        //    //viewModel.MICCancelled = meatInspectionViewModel.MICCancelled;

        //    //var antemortemInspectionData = _unitOfWork.ConductOfInspections.Where(item => item.MeatInspectionReportId == MeatInsId).ToList();
        //    //viewModel.AntemortemInspectionData = antemortemInspectionData;

        //    //var postmortemInspectionData = _unitOfWork.Postmortems.Where(item => item.PassedForSlaughterId == meatInspectionViewModel.Passed).ToList();
        //    //viewModel.PostmortemInspectionData = postmortemInspectionData;

        //    //var receivingReportToUpdate = _unitOfWork.ReceivingReports.FirstOrDefault(rr => rr.Id == ReceivingId);
        //    //if (receivingReportToUpdate != null)
        //    //{
        //    //    // Update the specific column value
        //    //    receivingReportToUpdate.InspectionStatus = InspectionStatus.Done;

        //    //    // Save the changes to the database
        //    //    _unitOfWork.SaveChanges();
        //    //}

        //    //viewModel.InspectionCount = inspectionReportCount;
        //    //// return View("~/Views/MeatInspections/CreateInspection.cshtml", viewModel);
        //    //return RedirectToAction("DailyInspection", "MeatInspectionReports");
        //    return null;
        //}


    }
}
