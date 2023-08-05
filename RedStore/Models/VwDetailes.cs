using Bl;

namespace RedStore.Models
{
	public class VwDetailes
	{		
			public VwDetailes()
			{
				Featured = new TbFeatured();
				Products=new TbMainProduct();
				lstFeatured = new List<TbFeatured>();
				MainProduct = new List<TbMainProduct>();

			}
			public TbFeatured Featured { get; set; }
			public TbMainProduct Products { get; set; }
			public List<TbFeatured> lstFeatured { get; set; }
			public List<TbMainProduct> MainProduct { get; set; }	
	}
}
