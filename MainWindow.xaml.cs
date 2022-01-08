namespace kasu.CustomDiscordRP
{
	public struct ColorsStruc
	{
		public static string DisconnectedRED = "#FF5B5B";
		public static string ConnectedGREEN = "#5BFF5B";
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow MW;
		public MainWindow()
		{
			InitializeComponent();

			MW = this;

			// Close
			CloseButton.MouseEnter  += kasuCDRP_Events.kMouseEnter;
			CloseButton.MouseLeave += kasuCDRP_Events.kMouseLeave;
			// Minimize
			MinimizeButton.MouseEnter += kasuCDRP_Events.kMouseEnter;
			MinimizeButton.MouseLeave += kasuCDRP_Events.kMouseLeave;

			Statusbar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ColorsStruc.DisconnectedRED));

		}

		#region Top buttons
		private void TopButtons(object s, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
		private void CloseCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.CloseWindow(this); }
		private void MinimizeCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.MinimizeWindow(this); }
		#endregion

		private void Window_Drag(object sender, MouseButtonEventArgs e) { if(e.ChangedButton == MouseButton.Left)this.DragMove(); }
	}
}
