using notes.Net8.Shared.Presentation.Handlers;

namespace notes.Net._8;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

