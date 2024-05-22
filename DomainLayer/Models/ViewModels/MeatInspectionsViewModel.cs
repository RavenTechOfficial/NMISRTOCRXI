using DomainLayer.Enum;
using System.Web.Mvc;

namespace DomainLayer.Models.ViewModels
{
    public class MeatInspectionsViewModel
	{
        public ReceivingReport? ReceivingReport { get; set; }
        public Antemortem Antemortem { get; set; }
        public PassedForSlaughter PassedForSlaughter { get; set; }
        public Postmortem Postmortem { get; set; }
    }
}
