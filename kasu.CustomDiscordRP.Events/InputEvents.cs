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

	// Textbox for the button's Text not the actual Buttons
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

	public static void _ClickConnect(object s, RoutedEventArgs e)
	{
		// the "DiscordRPC.Button" is interferring with the System's Button.
		System.Windows.Controls.Button text = s as System.Windows.Controls.Button;
		text.Content = "Update";

		kasu_Discord_Obj Inputs = new()
		{
			Details = MW.Input_Details.Text,
			State = MW.Input_State.Text,
			LargeKey = MW.Input_LargeImage.Text,
			LargeText = MW.Input_LargeText.Text,
			SmallKey = MW.Input_SmallImage.Text,
			SmallText = MW.Input_SmallText.Text,
			PartyID = MW.Input_PartyID.Text,
			ButtonOneText = MW.Input_ButtonOneText.Text,
			ButtonOneURL = MW.Input_ButtonOneURL.Text,
			ButtonTwoText = MW.Input_ButtonTwoText.Text,
			ButtonTwoURL = MW.Input_ButtonTwoURL.Text
		};

		if(MW.Input_PartySizeMin.Text != string.Empty && MW.Input_PartySizeMax.Text != string.Empty)
		{
			Inputs.PartySizeMin = int.Parse(MW.Input_PartySizeMin.Text);
			Inputs.PartySizeMax = int.Parse(MW.Input_PartySizeMax.Text);
		}

		MW.client = new(MW.Input_ClientID.Text, Inputs);
		MW.Statusbar.Foreground = ConnectedColor;
		MW.Status_Text.Text = kasu_Discord.status;
	}

	public static void _ClickDisconnect(object s, RoutedEventArgs e)
	{
		if (MW.client == null) return;
		MW.Button_Connect.Content = "Connect";
		MW.client.Disconnect();
		MW.Statusbar.Foreground = DisconnectColor;
		MW.Status_Text.Text = kasu_Discord.status;
	}
}