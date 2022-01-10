namespace kasu.CustomDiscordRP
{
	public struct ColorsStruc
	{
		public static string DisconnectedRED = "#FF5B5B";
		public static string ConnectedGREEN = "#5BFF5B";
	}

	public partial class MainWindow
	{
		public static MouseEventHandler kMouseEnter { get { return kasuCDRP_Events._MouseEnter; } }
		public static MouseEventHandler kMouseLeave { get { return kasuCDRP_Events._MouseLeave; } }

		public static TextChangedEventHandler DetailOnChange { get { return kasuCDRP_Events._DetailOnChange;  } }
		public static TextChangedEventHandler StateOnChange { get { return kasuCDRP_Events._StateOnChange; } }
		public static TextChangedEventHandler ButtonPreview { get { return kasuCDRP_Events._ButtonOnChange; } }
		public static TextChangedEventHandler NumberBoxOnChange { get { return kasuCDRP_Events._NumberOnly; } }
	
		public static SolidColorBrush DisconnectColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorsStruc.DisconnectedRED));
		public static SolidColorBrush ConnectedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorsStruc.ConnectedGREEN));
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow MW;

		kasu_Discord client;

		public MainWindow()
		{
			InitializeComponent();

			MW = this;

			#region Debug
			this.KeyDown += delegate(object s, KeyEventArgs e)
			{
				if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
				{
					Preview_ClientID.Text = "CustomDiscordRP [TEST]";
					//Preview_TestBG.SetValue(BackgroundProperty, new BitmapImage(new Uri("./Images/test.png", UriKind.Relative)));
					Input_ClientID.Text = "930012072417320982";
					Input_Details.Text = "Test Details";
					Input_State.Text = "Test State";
					Input_LargeImage.Text = "big";
					Input_SmallImage.Text = "small";
					Input_LargeText.Text = "Test";
					Input_SmallText.Text = "Test";
					Input_ButtonOneText.Text = "Test button one";
					Input_ButtonTwoText.Text = "Test button two";
					Input_ButtonOneURL.Text = "https://github.com/Ichimakikasura";
					Input_ButtonTwoURL.Text = "https://github.com/Ichimakikasura";
				}
			};
			#endregion

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

			Button_Connect.Click += delegate
			{
				kasu_Discord_Obj Inputs = new()
				{
					Details = Input_Details.Text,
					State = Input_State.Text,
					LargeKey = Input_LargeImage.Text,
					LargeText = Input_LargeText.Text,
					SmallKey = Input_SmallImage.Text,
					SmallText = Input_SmallText.Text,
					PartyID = Input_PartyID.Text,
					ButtonOneText = Input_ButtonOneText.Text,
					ButtonOneURL = Input_ButtonOneURL.Text,
					ButtonTwoText = Input_ButtonTwoText.Text,
					ButtonTwoURL = Input_ButtonTwoURL.Text
				};

				if(Input_PartySizeMin.Text != string.Empty && Input_PartySizeMax.Text != string.Empty)
				{
					Inputs.PartySizeMin = int.Parse(Input_PartySizeMin.Text);
					Inputs.PartySizeMax = int.Parse(Input_PartySizeMax.Text);
				}

				client = new(Input_ClientID.Text, Inputs);
				Statusbar.Foreground = ConnectedColor;
				Status_Text.Text = kasu_Discord.status;
			};
			Button_Disconnect.Click += delegate
			{
				if (client == null) return;
				client.Disconnect();
				Statusbar.Foreground = DisconnectColor;
				Status_Text.Text = kasu_Discord.status;
			};
		}

		#region Top buttons
		private void TopButtons(object s, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
		private void CloseCommand(object s, ExecutedRoutedEventArgs e) { if(client !=null) client.Disconnect(); SystemCommands.CloseWindow(this); }
		private void MinimizeCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.MinimizeWindow(this); }
		#endregion

		#region Window Drag
		private void Window_Drag(object sender, MouseButtonEventArgs e) { if(e.ChangedButton == MouseButton.Left)this.DragMove(); }
		#endregion
	}
}