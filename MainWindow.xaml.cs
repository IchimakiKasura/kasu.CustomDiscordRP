namespace kasu.CustomDiscordRP
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Initializes the Debug script.
			Debug();

			// Loads the Custom settings on the "Customize_Preview.txt"
			LoadCustomPreview();

			// Setups all the inputs/buttons event args.
			InitializeListeners();

			// status bar
			Statusbar.Foreground = DisconnectColor;
		
		}
	}
}