using System;
using notes.Net8.Notes.Domain.Models;
using SQLite;
using static Android.Provider.CalendarContract;

namespace notes.Net8.Shared.Infrastructure.Data
{
	public class MockRepository
	{
        #region Flds

        private static readonly object _padlok = new object();

        private static MockRepository? _instance = null;

        private List<Note> _notes = new List<Note>();

        private bool _isInitialized = false;

        internal IList<List<Note>> Database = new List<List<Note>>();


        #endregion


        MockRepository()
		{
		
		}


        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static MockRepository Instance
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
                //->Create the Note info
                var task = Task.Run( () =>
                {
                    Database.Add(CreateNoteTable());
                });
                task.Wait();
            }

            _isInitialized = true;
        }

        public List<Note> CreateNoteTable()
        {
            List<Note> notes = new List<Note>
                {
                   new Note( "Title 1", "Desc 1"),
                   new Note( "Title 2", "Desc 2" ),
                   new Note( "Title 3", "Desc 3")
                };

            return notes;
        }

    }
}

