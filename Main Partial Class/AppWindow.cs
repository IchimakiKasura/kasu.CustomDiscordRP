namespace kasu.CustomDiscordRP;

public partial class MainWindow
{
    private void TopButtons(object s, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }
    private void CloseCommand(object s, ExecutedRoutedEventArgs e) { if(client !=null) { client.Disconnect(); } SystemCommands.CloseWindow(this); }
    private void MinimizeCommand(object s, ExecutedRoutedEventArgs e) { SystemCommands.MinimizeWindow(this); }

    // Windows Drag
    private void Window_Drag(object sender, MouseButtonEventArgs e) { if(e.ChangedButton == MouseButton.Left)this.DragMove(); }
}