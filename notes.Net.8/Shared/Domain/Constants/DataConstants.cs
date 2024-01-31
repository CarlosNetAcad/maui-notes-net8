using System;

namespace notes.Net8.Shared.Domain.Constants
{
	public static class DataConstants
	{
		/// <summary>
		/// DatabaseFileName
		/// </summary>
		public const string DATABASE_FILE_NAME = "SQLiteDB.db";

        /// <summary>
        /// Flags
        /// </summary>
        public const SQLite.SQLiteOpenFlags FLAGS =
           // open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite |
           // create the database if it doesn't exist
           SQLite.SQLiteOpenFlags.Create |
           // enable multi-threaded database access
           SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                ), DATABASE_FILE_NAME
           );
    }
}

