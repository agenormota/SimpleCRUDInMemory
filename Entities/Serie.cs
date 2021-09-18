using SeriesControl.Enums;
using System;

namespace SeriesControl.Entities
{
    public class Serie : EntityBase
    {		
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int ReleaseYear { get; set; }
		private bool Deleted { get; set; }

	
		public Serie(int id, Genre genre, string title, string description, int releaseYear)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.ReleaseYear = releaseYear;
			this.Deleted = false;
		}

		public override string ToString()
		{
			string result = "";

			result += "Genre: " + this.Genre + Environment.NewLine;
			result += "Title: " + this.Title + Environment.NewLine;
			result += "Description: " + this.Description + Environment.NewLine;
			result += "Release Year: " + this.ReleaseYear + Environment.NewLine;
			result += "Deleted: " + this.Deleted;

			return result;
		}

		public string titleReturn()
		{
			return this.Title;
		}

		public int idReturn()
		{
			return this.Id;
		}

		public bool deletedReturn()
		{
			return this.Deleted;
		}

		public void Delete()
		{
			this.Deleted = true;
		}
	}
}
