using System;
using SQLite;

namespace notes.Net8.Notes.Domain.Models
{
	public class Note
	{
		[PrimaryKey]
        [AutoIncrement]
        public long? ID             { get; set; }
        public string? Title        { get; set; }
        public string? Description  { get; set; }
        public double? Latitude     { get; set; }
        public double? Longitude    { get; set; }
        public long? CreatedBy      { get; set; }
        public long? UpdatedBy      { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public Note()
        {
            // Default constructor required for SQLite
        }

        public Note( string title, string description)
        {
            Title       = title;
            Description = description;
        }
    }
}

