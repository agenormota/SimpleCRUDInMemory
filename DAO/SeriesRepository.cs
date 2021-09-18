using SeriesControl.Entities;
using SeriesControl.Interfaces;
using System.Collections.Generic;

namespace SeriesControl.DAO
{
    public class SeriesRepository : IRepository<Serie>
    {
		private List<Serie> serieList = new List<Serie>();
		
		public Serie ReturnById(int id)
		{
			return serieList[id];
		}

        public List<Serie> List()
        {
			return serieList;
		}

        public void Insert(Serie obj)
		{
			serieList.Add(obj);
		}

		public void Update(int id, Serie objeto)
		{
			serieList[id] = objeto;
		}

		public void Delete(int id)
		{
			serieList[id].Delete();
		}

		public int NextId()
        {
			return serieList.Count;
		}
    }	
}
