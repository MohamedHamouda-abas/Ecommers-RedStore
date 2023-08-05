using RedStore.Models;

namespace Bl
{
	public interface Ioffers
	{
		public List<TbOffer> GetAll();
		public TbOffer GetById(int OffersId);
		public bool Save(TbOffer item);
		public bool Delete(int OffersId);
	}
	public class ClsOffers : Ioffers
	{
		RedStoreShopContext Context;
        public ClsOffers(RedStoreShopContext ctx)
        {
			Context=ctx;

		}

		public List<TbOffer> GetAll()
		{
			try
			{
				var Header = Context.TbOffers.Where(a => a.CurrentState == 1).ToList();
				return Header;
			}
			catch
			{
				return new List<TbOffer>();
			}
		}

		public TbOffer GetById(int OffersId)
		{
			try
			{
				var Header = Context.TbOffers.FirstOrDefault(a => a.OffersId == OffersId && a.CurrentState == 1);
				return Header;
			}
			catch
			{
				return new TbOffer();
			}
		}
		public bool Save(TbOffer item)
		{
			try
			{


				if (item.OffersId == 0)
				{
					item.CurrentState = 1;
					Context.TbOffers.Add(item);
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

		public bool Delete(int OffersId)
		{
			try
			{

				var prodcut = GetById(OffersId);
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
