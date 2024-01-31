using Android.Mtp;
using notes.Net8.Notes.Domain.Models;
using notes.Net8.Shared.Domain.Constants;
using SQLite;

namespace notes.Net8.Shared.Infrastructure.Data
{
    public sealed class SQLiteRepository
	{
        private bool _isInitialized;

        private static SQLiteRepository? _instance = null;

        internal SQLiteAsyncConnection Database;

        private static readonly object _padlok = new object();

        /// <summary>
        /// Ctor.
        /// </summary>
        SQLiteRepository()
        {
            Database = new SQLiteAsyncConnection(
                 DataConstants.DatabasePath,
                 DataConstants.FLAGS
             );
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
		public static SQLiteRepository Instance
		{
            get
            {
                lock (_padlok)
                {
                    if (_instance is null)
                        _instance = new();

                    return _instance;

                }
            }
        }

        public async Task Initialize()
        {
            if (!_isInitialized)
            {
                //->Create the Note Table
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Note).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Note)).ConfigureAwait(false);

            }

            _isInitialized = true;
        }
    }
}

