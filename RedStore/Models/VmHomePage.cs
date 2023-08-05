using RedStore.Models;

namespace Domains
{
	public class VmHomePage
	{
        public VmHomePage()
        {
			LstHeader = new List<TbHeader>();
			LstoOffers = new List<TbOffer>();
			LstFeatured=new List<TbFeatured>();
			LstMainProduct=new List<TbMainProduct>();
			Lsttestimonial = new List<Tbtestimonial>();
		}
        public List<TbHeader> LstHeader { get; set; }
		public List<TbOffer> LstoOffers { get; set; }
		public List<TbFeatured> LstFeatured { get; set;}
		public List<TbMainProduct> LstMainProduct { get; set; }
		public List<Tbtestimonial> Lsttestimonial { get; set; }

	}
}
