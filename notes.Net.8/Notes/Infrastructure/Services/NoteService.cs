using System;
using Android.Mtp;
using notes.Net8.Notes.Domain.Models;
using notes.Net8.Notes.Infrastructure.Interfaces;
using notes.Net8.Shared.Infrastructure.Data;
using SQLite;

namespace notes.Net8.Notes.Infrastructure.Services
{
	public class NoteService : INoteService
	{
        List<Note> _noteList = new();

        readonly SQLiteRepository _repositoryConnection;

        public NoteService()
        {
            _repositoryConnection = SQLiteRepository.Instance;
        }

        public async Task<bool> DeleteAsync(Note note)
        {
            await _repositoryConnection.Database.DeleteAsync(note);

            return true;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var notesList = await _repositoryConnection.Database.Table<Note>().ToListAsync();

            return notesList ?? new List<Note>(); 
        }

        public async Task<bool> SaveAsync(Note note)
        {
            await _repositoryConnection.Database.InsertAsync(note);

            return true;
        }

        public async Task<bool> UpdateAsync(Note note)
        {
            await _repositoryConnection.Database.UpdateAsync(note);

            return true;
        }
    }
}

