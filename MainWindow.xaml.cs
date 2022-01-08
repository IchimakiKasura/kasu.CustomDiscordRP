namespace kasu.CustomDiscordRP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		#region Top buttons
		private void TopButtons(object s, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
		private void CloseCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.CloseWindow(this); }
		private void MinimizeCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.MinimizeWindow(this); }

		#endregion

		private void Window_Drag(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}
	}
}
