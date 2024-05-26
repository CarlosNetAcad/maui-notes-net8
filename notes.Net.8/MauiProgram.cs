using Microsoft.Extensions.Logging;
using notes.Net8.Notes.Infrastructure.Interfaces;
using notes.Net8.Notes.Infrastructure.Services;
using notes.Net8.Notes.Presentation.ViewModels;

namespace notes.Net._8;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		Bootstrap( builder );

		MapHandlers();

		return builder.Build();
	}

	static void Bootstrap( MauiAppBuilder builder)
	{
		//-> Main pages

		//->Essentials

		//->Notes
		builder.Services.AddSingleton<INoteService>(b => new NoteService());
		builder.Services.AddTransient<NotesViewModel>(
			b => new NotesViewModel(
				title: PageTitles.NOTES_DASHBOARD,
				b.GetRequiredService<INoteService>()
			)
		);

	}

	static void MapHandlers()
	{
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderLessEntry", (handler, view) =>
        {
            //if (view is BorderLessEntry)
            //{
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Red);
#elif __IOS__
				handler.PlatformView.BackgroundColor	= UIKit.UIColor.Clear;
				handler.PlatformView.BorderStyle		= UIKit.UITextBorderStyle.None;
#endif
            //}
        });
    }
}

