namespace kasu.CustomDiscordRP;

public partial class MainWindow
{
    private void Debug()
    {
        KeyDown += delegate(object s, KeyEventArgs e)
        {
            ImageBrush BG = new();
            if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                if(!IsDebug)
                {
                    IsDebug = true;
                    BG.ImageSource = new BitmapImage(new Uri("./Images/test.png", UriKind.Relative));
                    Preview_TestBG.Background = BG;

                    Preview_ClientID.Text = "CustomDiscordRP [TEST]";
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
                else
                {
                    IsDebug = false;
                    BG.ImageSource = new BitmapImage(new Uri("./Images/discord.png", UriKind.Relative));
                    Preview_TestBG.Background = BG;

                    // Damn this looks weird
                    Preview_ClientID.Text = "Client ID's Title";
                    Input_ClientID.Text = 
                    Input_Details.Text = 
                    Input_State.Text = 
                    Input_LargeImage.Text = 
                    Input_SmallImage.Text = 
                    Input_LargeText.Text = 
                    Input_SmallText.Text = 
                    Input_ButtonOneText.Text = 
                    Input_ButtonTwoText.Text = 
                    Input_ButtonOneURL.Text = 
                    Input_ButtonTwoURL.Text = string.Empty;
                }
            }
        };
    }
}