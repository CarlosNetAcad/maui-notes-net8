using System;
using System.Linq;
using notes.Net8.Notes.Domain.Models;
using notes.Net8.Notes.Infrastructure.Interfaces;

namespace notes.Net8.Notes.Presentation.ViewModels
{
	public partial class NotesViewModel : BaseViewModel
	{
        #region Flds

        readonly INoteService _noteService;

        #endregion

        #region Props

        /// <summary>
        /// Notes List
        /// </summary>
        public ObservableCollection<Note> NotesCollection { get; private set; } = new();

        #endregion


        #region Ctors

        public NotesViewModel(
            string title,
            INoteService noteService
        ) : base(title)
        {
            _noteService = noteService;

        }

        #endregion
        [RelayCommand]
        async Task GetNotesAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var NoteList = await _noteService.GetNotesAsync();

                if (NoteList?.Count > 0)
                {
                    NotesCollection?.Clear();

                    foreach (var note in NoteList)
                        NotesCollection?.Add(note);

                    /*var result = NoteList.Select( note =>
                    {
                        NotesCollection.Add(note);

                        return note;
                    });*/

                    //foreach( var item in NotesCollection)
                    //    Debug.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

