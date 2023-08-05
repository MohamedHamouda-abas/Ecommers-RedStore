using Microsoft.AspNetCore.Authentication;
using RedStore.Models;

namespace Bl
{
	public interface IHeader
	{
		public List<TbHeader> GetAll();
		public TbHeader GetById(int? HeaderId);
		public bool Save(TbHeader item);
		public bool Delete(int CategoryId);
	}
	public class ClsHeader : IHeader
	{
		RedStoreShopContext Context;
		public ClsHeader(RedStoreShopContext ctx)
		{
			Context = ctx;

		}
		public List<TbHeader> GetAll()
		{
			try
			{
				var Header=Context.TbHeaders.Where(a=>a.CurrentState==1).ToList();
				return Header;
			}
			catch
			{
				return new List<TbHeader>();
			}
		}

		public TbHeader GetById(int? HeaderId)
		{
			try
			{			
				var Header = Context.TbHeaders.FirstOrDefault(a=>a.HeaderId == HeaderId && a.CurrentState==1);
				return Header;
			}
			catch
			{
				return new TbHeader();
			}
		}





		public bool Save(TbHeader item)
		{
			try
			{


				if (item.HeaderId == 0)
				{
					item.CurrentState = 1;				
					Context.TbHeaders.Add(item);
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
		public bool Delete(int HeaderId)
		{
			try
			{

				var prodcut = GetById(HeaderId);
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
