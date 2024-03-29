using Rodriguez_EjemploApi.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Rodriguez_EjemploApi.ARViews;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		string latitud = Lat.Text;
		string longitud = lon.Text;

		if(Connectivity.NetworkAccess==NetworkAccess.Internet)
		{
			using (var client  = new HttpClient()) 
			
			{
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=49f2e8e06a0664992f6a284032e3af82";
					var response = await client.GetAsync(url);
				if(response.IsSuccessStatusCode)
				
				{
				var json= await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);

					weatherLabel.Text = clima.weather[0].main;
					cityLabel.Text = clima.name;
					countryLabel.Text = clima.sys.country;
				}
			}

		}
    }
}