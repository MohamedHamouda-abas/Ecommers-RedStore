using RedStore.Models;

namespace Bl
{
	public interface Itesmoniles
	{
		public List<Tbtestimonial> GetAll();
		public Tbtestimonial GetById(int TestimonialsId);
		public bool Save(Tbtestimonial item);
	}
	public class ClsTesMoniles: Itesmoniles
	{
		RedStoreShopContext Context;
        public ClsTesMoniles(RedStoreShopContext ctx)
        {
			Context = ctx;

		}


		public List<Tbtestimonial> GetAll()
		{
			try
			{
				var testimonia = Context.Tbtestimonials.ToList();
				return testimonia;
			}
			catch
			{
				return new List<Tbtestimonial>();
			}
		}

		public Tbtestimonial GetById(int TestimonialsId)
		{
			try
			{
				var testimonias = Context.Tbtestimonials.FirstOrDefault(a => a.TestimonialsId == TestimonialsId);
				return testimonias;
			}
			catch
			{
				return new Tbtestimonial();
			}
		}





		public bool Save(Tbtestimonial item)
		{
			try
			{


				if (item.TestimonialsId == 0)
				{
				
					Context.Tbtestimonials.Add(item);
				}
				else
				{
					
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





	}
}
