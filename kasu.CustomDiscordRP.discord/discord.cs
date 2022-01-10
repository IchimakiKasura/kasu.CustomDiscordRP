namespace kasu.CustomDiscordRP.discord;

public struct kasu_Discord_Obj
{ 
	public string Details { get; set; }
	public string State { get; set; }
	public string LargeKey { get; set; }
	public string LargeText { get; set; }
	public string SmallKey { get; set; }
	public string SmallText { get; set; }
	public string PartyID { get; set; }
	public int PartySizeMin { get; set; }
	public int PartySizeMax { get; set; }
	public string ButtonOneText { get; set; }
	public string ButtonOneURL { get; set; }
	public string ButtonTwoText { get; set; }
	public string ButtonTwoURL { get; set; }
}

public class kasu_Discord
{
	public static string status = "Disconnected";
	private DiscordRpcClient client;
	
	private async void Initialize(string ID)
	{
		client = new(ID);
		await Task.Run(()=> client.Initialize());
	}

	public kasu_Discord(string ID, kasu_Discord_Obj Text)
	{
		Initialize(ID);
		SetPresence(Text);
		status = "Connected";
	}

	private void SetPresence(kasu_Discord_Obj Text)
	{
		Assets Images = new()
		{
			LargeImageKey = Text.LargeKey,
			LargeImageText = Text.LargeText,
			SmallImageKey = Text.SmallKey,
			SmallImageText = Text.SmallText,
		};

		Party party = new()
		{
			ID = Text.PartyID,
			Size = Text.PartySizeMin,
			Max = Text.PartySizeMax
		};

		DiscordRPC.Button buttonsOne = new()
		{
			Label = Text.ButtonOneText,
			Url = Text.ButtonOneURL
		};

		DiscordRPC.Button buttonsTwo = new()
		{
			Label = Text.ButtonTwoText,
			Url = Text.ButtonTwoURL
		};

		client.SetPresence(new()
		{
			Details = Text.Details,
			State = Text.State,
			Assets = Images,
			Party = party,
			Buttons = new[]
			{
				buttonsOne,
				buttonsTwo
			}
		});
	}

	public void Disconnect()
	{
		client.ClearPresence();
		client.Dispose();
		status = "Disconnected";
	}

	public void Update()
	{

	}
}