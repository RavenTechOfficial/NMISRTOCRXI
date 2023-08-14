using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly thesisContext _context;

        public QRCodeController(thesisContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            //string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //Random random = new Random();
            //char[] idChars = new char[10];

            //for (int i = 0; i < 10; i++)
            //{
            //    idChars[i] = characters[random.Next(characters.Length)];
            //}

            //string id = new string(idChars);

            //Result results = new Result
            //{
            //    Id = id,
            //    Name = result.Name,
            //    Address = result.Address,
            //    MeatEstablishment = result.MeatEstablishment,
            //    Date = result.Date
            //};

            //QrCode qr = new QrCode
            //{
            //    Link = "https://localhost:7116/Result/" + results.Id,
            //    uid = results.Id
            //};

            //_context.Add(results);
            //_context.Add(qr);
            //_context.SaveChanges();

            

            //_context.Results.FirstOrDefault(res => res.Id == results.Id);


            //var res = new QrCode
            //{
            //    Link = "https://localhost:7116/" + add
            //};

            //_context.Add(res);
            //_context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
