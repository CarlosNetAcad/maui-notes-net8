using System;
using notes.Net8.Notes.Domain.Models;

namespace notes.Net8.Notes.Infrastructure.Interfaces
{
	public interface INoteService
	{
        /// <summary>
        /// Store the note in the repository.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<bool> SaveAsync(Note note);

        /// <summary>
        /// Upate the note in the repository,
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Note note);

        /// <summary>
        /// Get the note list from the repository.
        /// </summary>
        /// <returns></returns>
        Task<List<Note>> GetNotesAsync();

        /// <summary>
        /// Hard note delete in the repository.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Note note);
    }
}

