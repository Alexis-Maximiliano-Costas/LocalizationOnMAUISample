using LocalicationOnMAUI;
using LocalizationOnMAUI.Resources.Languages;
using System.Globalization;

namespace LocalizationOnMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public LocalizationResourceManager LocalizationResourceManager
		=> LocalizationResourceManager.Instance;
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		var switchToCulture = AppResources.Culture.TwoLetterISOLanguageName
			.Equals("fr", StringComparison.InvariantCultureIgnoreCase) ?
			new CultureInfo("en-US") : new CultureInfo("fr-FR");
		count++;

		LocalizationResourceManager.Instance.SetCulture(switchToCulture);

		CounterBtn.Text = String.Format(LocalizationResourceManager.Instance["Counter"].ToString(), count);

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

