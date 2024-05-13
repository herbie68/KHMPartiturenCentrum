namespace KHM.Views
{
	/// <summary>
	/// Interaction logic for NewScore.xaml
	/// </summary>
	public partial class NewScore : Window
	{
		public NewScore( object selectedRow, string selectedScore )
		{
			InitializeComponent();

			DataContext = selectedRow;

			var Scores = DBCommands.GetEmptyScores(DBNames.AvailableScoresView, DBNames.ScoresFieldNameScoreNumber);

			cbxNewScores.ItemsSource = Scores.Select( x => x.ScoreNumber ).ToList();
		}

		#region Selected a new Score number
		private void NewScoreChanged( object sender, SelectionChangedEventArgs e )
		{
			btnCreate.Visibility = Visibility.Visible;

			btnText.Text = cbxNewScores.SelectedValue.ToString();
		}
		#endregion

		#region Create the new score
		private void Create_Click( object sender, RoutedEventArgs e )
		{
			DBCommands.AddNewScore( cbxNewScores.SelectedValue.ToString() );
			NewScoreNo.NewScoreNumber = cbxNewScores.SelectedValue.ToString();

			this.Close();
		}
		#endregion

		#region Close Window
		private void Close_Click( object sender, RoutedEventArgs e )
		{
			this.Close();
		}
		#endregion

		#region Drag Widow
		private void Window_MouseDown( object sender, MouseButtonEventArgs e )
		{
			if ( e.LeftButton == MouseButtonState.Pressed )
			{
				DragMove();
			}
		}
		#endregion

	}
}
