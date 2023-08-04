using LocalicationOnMAUI;
using LocalizationOnMAUI.Resources.Languages;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace LocalizationOnMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;
    IConfiguration configuration;

    public LocalizationResourceManager LocalizationResourceManager
		=> LocalizationResourceManager.Instance;
    public MainPage(IConfiguration config)
    {
        InitializeComponent();
        BindingContext = this;

        configuration = config;
    }



        private async void OnCounterClicked(object sender, EventArgs e)
	{
		var switchToCulture = AppResources.Culture.TwoLetterISOLanguageName
			.Equals("fr", StringComparison.InvariantCultureIgnoreCase) ?
			new CultureInfo("en-US") : new CultureInfo("fr-FR");
		count++;

		LocalizationResourceManager.Instance.SetCulture(switchToCulture);

		CounterBtn.Text = String.Format(LocalizationResourceManager.Instance["Counter"].ToString(), count);

		SemanticScreenReader.Announce(CounterBtn.Text);

        var settings = configuration.GetRequiredSection("Settings").Get<Settings>();
        await DisplayAlert("Config", $"{nameof(settings.KeyOne)}: {settings.KeyOne}" +
            $"{nameof(settings.KeyTwo)}: {settings.KeyTwo}" +
            $"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}", "OK");
    }
}

