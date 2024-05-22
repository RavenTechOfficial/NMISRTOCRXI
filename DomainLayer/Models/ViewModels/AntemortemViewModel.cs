using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
    public class AntemortemViewModel
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public int NoOfHeads { get; set; }
        public string Weight { get; set; }
        public string Cause { get; set; }
        public string Other { get; set; }
        public string Remarks { get; set; }
        public Guid ReceivingReportId { get; set; }
    }
}
