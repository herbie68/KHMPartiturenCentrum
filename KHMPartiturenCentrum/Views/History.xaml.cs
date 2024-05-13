namespace KHM.Views
{
	/// <summary>
	/// Interaction logic for History.xaml
	/// </summary>
	public partial class History : Page
	{
		public HistoryViewModel? history;
		public History()
		{
			InitializeComponent();

			history = new HistoryViewModel();
			DataContext = history;
		}
	}
}
