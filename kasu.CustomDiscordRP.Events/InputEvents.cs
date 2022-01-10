namespace kasu.CustomDiscordRP.Events;

public partial class kasuCDRP_Events
{
	private static void ReplaceCharOnChange(object s, bool NumberOnly)
	{
		TextBox value = s as TextBox;
		string Text = value.Text;
		Regex reg;
		if (NumberOnly) reg = new("[^0-9]+");
			else reg = new("[^a-zA-Z]+");
		value.Text = reg.Replace(Text, "");
	}

	public static void _DetailOnChange(object s, TextChangedEventArgs e)
	{
		MW.Preview_Details.Text = MW.Input_Details.Text;
		if (MW.Preview_Details.Text.Length > 20) MW.Preview_Details.Text = MW.Input_Details.Text.Remove(20) + "...";
		if (MW.Input_Details.Text == string.Empty) MW.Preview_Details.Text = "Details";
	}

	public static void _StateOnChange(object s, TextChangedEventArgs e)
	{
		MW.Preview_State.Text = MW.Input_State.Text;
		if (MW.Preview_State.Text.Length > 17) MW.Preview_State.Text = MW.Input_State.Text.Remove(17) + "...";
		if (MW.Preview_State.Text == string.Empty) MW.Preview_State.Text = "State";
	}

	public static void _ButtonOnChange(object s, TextChangedEventArgs e)
	{
		ReplaceCharOnChange(s, false);
		if (MW.Input_ButtonOneText.Text.Length > 20) return;
		MW.Preview_ButtonOne.Content = MW.Input_ButtonOneText.Text;
		if (MW.Input_ButtonOneText.Text == string.Empty) MW.Preview_ButtonOne.Content = "Button 1";
	}

	public static void _NumberOnly(object s, TextChangedEventArgs e)
	{
		ReplaceCharOnChange(s, true);
	}
}