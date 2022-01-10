namespace kasu.CustomDiscordRP.Events;

public partial class kasuCDRP_Events : MainWindow
{ 

	public static void _MouseEnter(object s, MouseEventArgs e)
	{
		if (MW.CloseButton.IsMouseOver) MW.CloseButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#821515"));
		if (MW.MinimizeButton.IsMouseOver) MW.MinimizeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#26292b"));
	}

	public static void _MouseLeave(object s, MouseEventArgs e)
	{
		MW.CloseButton.Background = MW.MinimizeButton.Background = Brushes.Transparent;
	}
}