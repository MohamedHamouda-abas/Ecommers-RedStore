using RedStore.Models;

namespace Bl
{
	public interface IFeatured
	{
		public List<TbFeatured> GetAll();
		public TbFeatured GetById(int? FeaturedId);
		public bool Save(TbFeatured item);
		public bool Delete(int FeaturedId);

	}
	public class ClsFeatured : IFeatured
	{
		RedStoreShopContext Context { get; set; }
		public ClsFeatured(RedStoreShopContext Ctx)
		{
			Context = Ctx;
		}
		
		public List<TbFeatured> GetAll()

		{
			try
			{
				var Data = Context.TbFeatureds.Where(a=>a.CurrentState==1).ToList();
				return Data;

			}
			catch
			{
				return new List<TbFeatured>();
			}

		}


		public TbFeatured GetById(int? FeaturedId)
		{
			try
			{
				var GetData = Context.TbFeatureds.FirstOrDefault(a => a.FeaturedId == FeaturedId && a.CurrentState==1);
				return GetData;
			}
			catch
			{
				return new TbFeatured();
			}

		}
		public bool Save(TbFeatured item)
		{
			try
			{


				if (item.FeaturedId == 0)
				{
					item.CurrentState = 1;
					Context.TbFeatureds.Add(item);
				}
				else
				{
					item.CurrentState = 1;
					Context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				}
				Context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int FeaturedId)
		{
			try
			{

				var prodcut = GetById(FeaturedId);
				Context.Entry(prodcut).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				prodcut.CurrentState = 0;
				Context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}








	}
}
