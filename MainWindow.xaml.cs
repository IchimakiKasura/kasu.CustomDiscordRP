namespace kasu.CustomDiscordRP
{
	public struct ColorsStruc
	{
		public static string DisconnectedRED = "#FF5B5B";
		public static string ConnectedGREEN = "#5BFF5B";
	}
	
	public partial class MainWindow : Window
	{
		public static MainWindow MW;

		public kasu_Discord client;

		private bool IsDebug = false;

		public MainWindow()
		{
			InitializeComponent();

			// Initializes the Debug script.
			Debug();

			MW = this;

			// Close
			CloseButton.MouseEnter += kMouseEnter;
			CloseButton.MouseLeave += kMouseLeave;
			// Minimize
			MinimizeButton.MouseEnter += kMouseEnter;
			MinimizeButton.MouseLeave += kMouseLeave;

			// status bar
			Statusbar.Foreground = DisconnectColor;

			// Inputs Events
			Input_Details.TextChanged += DetailOnChange;
			Input_State.TextChanged += StateOnChange;
			Input_ButtonOneText.TextChanged += ButtonPreview;
			Input_ButtonTwoText.TextChanged += ButtonPreview;
			Input_Time.TextChanged += NumberBoxOnChange;
			Input_PartySizeMin.TextChanged += NumberBoxOnChange;
			Input_PartySizeMax.TextChanged += NumberBoxOnChange;

			// Inputs Attributes
			Input_ButtonOneText.MaxLength =
				Input_ButtonTwoText.MaxLength = 20;

			Button_Connect.Click += ConnectClick;
			Button_Disconnect.Click += DisconnectClick;
			
		}
	}
}