using static KHM.App;


namespace KHM.Views;
/// <summary>
/// Interaction logic for LoginPage.xaml
/// </summary>
public partial class LoginPage : Window
{
	public LoginPage()
	{
		InitializeComponent();
	}

	#region Button Close | Restore | Minimize 
	#region Button Close
	private void btnClose_Click( object sender, RoutedEventArgs e )
	{
		Close();
	}
	#endregion

	#region Button Restore
	private void btnRestore_Click( object sender, RoutedEventArgs e )
	{
		if ( WindowState == WindowState.Normal )
			WindowState = WindowState.Maximized;
		else
			WindowState = WindowState.Normal;
	}
	#endregion

	#region Button Minimize
	private void btnMinimize_Click( object sender, RoutedEventArgs e )
	{
		WindowState = WindowState.Minimized;
	}
	#endregion
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

	private void btnLogin_Click( object sender, RoutedEventArgs e )
	{
		tbInvalidLogin.Visibility = Visibility.Collapsed;
		// Check if e-mail address belongs to a user
		ObservableCollection<UserModel> Users = DBCommands.GetUsers ( );

		// When UserName seems to be an e-mail address, check if it is a valid e-mail for the user
		tbUserName.Text = tbUserName.Text.Contains( "@" ) ? Login.CheckEmailLogin( tbUserName.Text ) : tbUserName.Text;

		// Check if the password is correct
		int UserId = Login.CheckUserPassword(tbUserName.Text, tbPassword.Password);

		if ( UserId != 0 )
		{
			// Set the user properties
			Login.FillUserProperties( UserId );

			// Write Login to Logfile
			DBCommands.WriteLog( UserId, DBNames.LogUserLoggedIn, $"{ScoreUsers.SelectedUserFullName} is ingelogd" );

			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}
		else
		{
			tbInvalidLogin.Visibility = Visibility.Visible;
		}
	}

	private void PressedEnterOnPassword( object sender, System.Windows.Input.KeyEventArgs e )
	{
		if ( e.Key == Key.Enter )
		{
			btnLogin.RaiseEvent( new RoutedEventArgs( System.Windows.Controls.Primitives.ButtonBase.ClickEvent ) );
		}
	}

	private void btnResetPassword( object sender, RoutedEventArgs e )
	{
		var _userName = "";

		//Check if a username has been entered
		if ( tbUserName.Text.Length > 0 )
		{
			//Check if entered username is an e-mail address otherwise get the E-Mail address for the specified user
			if ( tbUserName.Text.Contains( "@" ) )
			{
				//Username is an e-mail address
				_userName = tbUserName.Text.ToLower();
			}
			else
			{
				// Get the users e-mail address base on the entered login name
				_userName = Login.GetUserEmail( tbUserName.Text.ToLower() );
			}
		}

		PasswordReset passwordReset = new(_userName);
		passwordReset.Show();
		this.Close();
	}

	private void PressedEnterOnUsername( object sender, KeyEventArgs e )
	{
		if ( e.Key == Key.Enter )
		{
			if ( !string.IsNullOrEmpty( tbPassword.Password ) )
			{
				// Theare is a password enterend
				btnLogin.RaiseEvent( new RoutedEventArgs( System.Windows.Controls.Primitives.ButtonBase.ClickEvent ) );
			}
			else
			{
				// No password entered, therefor set focus to PasswordBox
				tbPassword.Focus();
			}

		}
	}
}
