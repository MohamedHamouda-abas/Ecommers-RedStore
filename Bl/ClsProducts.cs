using Domains;
using Microsoft.AspNetCore.Authentication;
using RedStore.Models;

namespace Bl
{
	public interface IProducts
	{
		public List<TbMainProduct> GetAll();
		public TbMainProduct GetById(int? MainId);
		public bool Save(TbMainProduct item);
		public bool Delete(int MainId);
    }
	public class ClsProducts : IProducts
	{
		RedStoreShopContext Context;
		public ClsProducts(RedStoreShopContext ctx)
		{
			Context = ctx;
		}

		public List<TbMainProduct> GetAll()
		{
			try
			{
				var Products = Context.TbMainProducts.Where(a => a.CurrentState == 1).ToList();
				return Products;

			}
			catch
			{

				return new List<TbMainProduct>();
			}

		}

		public TbMainProduct GetById(int? MainId)
		{
			try
			{
				var Main = Context.TbMainProducts.FirstOrDefault(a => a.MainId == MainId && a.CurrentState == 1);
				return Main;
			}
			catch
			{
				return new TbMainProduct();
			}
		}



		public bool Save(TbMainProduct item)
		{
			try
			{
				if (item.MainId == 0)
				{
					item.CurrentState = 1;
					Context.TbMainProducts.Add(item);
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


		public bool Delete(int MainId)
		{
			try
			{

				var prodcut = GetById(MainId);
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
