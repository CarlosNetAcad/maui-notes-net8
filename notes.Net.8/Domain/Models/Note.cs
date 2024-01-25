using System;
using SQLite;

namespace notes.Net8.Domain.Models
{
	public class Note
	{
		[PrimaryKey]
        [AutoIncrement]
        public long ID              { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string? Title        { get; set; }
        public string? Description  { get; set; }
        public long UserId          { get; set; }
        public double Latitude      { get; set; }
        public double Longitude     { get; set; }
	}
}

