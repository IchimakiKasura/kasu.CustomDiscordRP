namespace kasu.CustomDiscordRP;

public partial class MainWindow
{
	public static MainWindow MW;
	public kasu_Discord client;
	private bool IsDebug = false;

	private void InitializeListeners()
	{

		MW = this;

		#region Top Buttons

			#region close
			CloseButton.MouseEnter += kMouseEnter;
			CloseButton.MouseLeave += kMouseLeave;
			#endregion

			#region Minimize
			MinimizeButton.MouseEnter += kMouseEnter;
			MinimizeButton.MouseLeave += kMouseLeave;
		#endregion

		#endregion

		#region Inputs

			#region Inputs Events
			Input_Details.TextChanged += DetailOnChange;
			Input_State.TextChanged += StateOnChange;
			Input_ButtonOneText.TextChanged += ButtonPreview;
			Input_ButtonTwoText.TextChanged += ButtonPreview;
			Input_Time.TextChanged += NumberBoxOnChange;
			Input_PartySizeMin.TextChanged += NumberBoxOnChange;
			Input_PartySizeMax.TextChanged += NumberBoxOnChange;
			#endregion

			#region Inputs Attributes
			Input_ButtonOneText.MaxLength =
			Input_ButtonTwoText.MaxLength = 20;

			Button_Connect.Click += ConnectClick;
			Button_Disconnect.Click += DisconnectClick;
			#endregion

		#endregion
	}
}