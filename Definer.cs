namespace kasu.CustomDiscordRP;
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
    
    public static RoutedEventHandler ConnectClick { get { return kasuCDRP_Events._ClickConnect; } }
    public static RoutedEventHandler DisconnectClick { get { return kasuCDRP_Events._ClickDisconnect; } }
}