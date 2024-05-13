namespace KHM.Views;

/// <summary>
/// Interaction logic for NewScores.xaml
/// </summary>
public partial class AvailableScores : Page
{
	public NewScoreViewModel? scores;
	public AvailableScores()
	{
		InitializeComponent();
		scores = new NewScoreViewModel();
		DataContext = scores;
	}
}