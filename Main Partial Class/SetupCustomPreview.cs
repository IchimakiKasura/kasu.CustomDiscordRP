namespace kasu.CustomDiscordRP;

public partial class MainWindow
{
    private readonly static Regex CustomPreviewRegex = new("Username:*.\"(?<Username>.*)\"|Tag:*.\"(?<Tag>.*)\"|Background:*.\"(?<Background>.*)\"|Status:*.\"(?<Status>.*)\"", RegexOptions.Compiled|RegexOptions.IgnoreCase|RegexOptions.Multiline);
    private async void LoadCustomPreview()
    {
        string Data = await File.ReadAllTextAsync("Config.kasu");

        try{
            string Username = CustomPreviewRegex.Matches(Data)[0].Groups["Username"].Value.Trim();
            string Tag = CustomPreviewRegex.Matches(Data)[1].Groups["Tag"].Value.Trim().Remove(5);
            string BG = CustomPreviewRegex.Matches(Data)[2].Groups["Background"].Value.Trim();
            string Status = CustomPreviewRegex.Matches(Data)[3].Groups["Status"].Value.Trim();

            if(Username.Length > 14) Username = Username.Remove(14) + "...";
            if(!Regex.IsMatch(Tag, "#")) Tag = "#0000";

            TextBlock TagText = new()
            {
                Text = Tag,
                Foreground = Brushes.DarkGray,
                FontSize = 10,
                FontWeight = FontWeights.Thin
            };

            Preview_Username.Text = Username+" ";
            Preview_Username.Inlines.Add(TagText);
            Preview_Background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(BG));
            
            switch(Status)
            {
                case "Online": Preview_Status.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green")); break;
                case "Busy": Preview_Status.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")); break;
                case "Offline": Preview_Status.Visibility = Visibility.Hidden; break;
            }

        } catch { return; }
    }
}