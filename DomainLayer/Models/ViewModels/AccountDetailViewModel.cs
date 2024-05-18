using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
	public class AccountDetailViewModel
	{
		public string Id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string middleName { get; set; }
		public string address { get; set; }
		public string contactNo { get; set; }
		public string email { get; set; }
        public string Role { get; set; } 
		public string MeatEstablishmentName { get; set; }
	}
}
