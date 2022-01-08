namespace kasu.CustomDiscordRP.Events;

public class kasuCDRP_Events : MainWindow
{ 

	public static void kMouseEnter(object s, MouseEventArgs e)
	{
		if (MW.CloseButton.IsMouseOver) MW.CloseButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#821515"));
		if (MW.MinimizeButton.IsMouseOver) MW.MinimizeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#26292b"));
	}

	public static void kMouseLeave(object s, MouseEventArgs e)
	{
		MW.CloseButton.Background = MW.MinimizeButton.Background = Brushes.Transparent;
	}
}