namespace KHM.Views;
/// <summary>
/// Interaction logic for PasswordReset.xaml
/// </summary>
public partial class PasswordReset : Window
{
	private string _pendingInput = "";

	public PasswordReset( string _userName )
	{
		InitializeComponent();

		//Fill in the already entered e-mail address from the login page
		tbUserName.Text = _userName;

		// Set focus to the TextBox
		tbUserName.Focus();

		// Put cursor at the end of the existing text
		tbUserName.SelectionStart = tbUserName.Text.Length;
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

	#region Drag Window
	private void Window_MouseDown( object sender, MouseButtonEventArgs e )
	{
		if ( e.LeftButton == MouseButtonState.Pressed )
		{
			DragMove();
		}
	}

	#endregion

	#region E-mail address for login changed
	private void LoginNameChanged( object sender, TextChangedEventArgs e )
	{
		if ( tbUserName.Text.Length > 3 && Login.IsValidEmail( tbUserName.Text ) != false )
		{
			// Also check if this E-Mail is in the database
			// Yes: Show btnChange to send the resetcode to the mailbox
			// No: Show message about asking for an account
			var _userId = Login.GetUserId(tbUserName.Text);
			if ( _userId != -1 )
			{
				btnSendMail.Visibility = Visibility.Visible;
				InvalidLogin.Visibility = Visibility.Collapsed;
			}
			else
			{
				btnSendMail.Visibility = Visibility.Collapsed;
				InvalidLogin.Visibility = Visibility.Visible;
			}
		}
		else
		{
			btnSendMail.Visibility = Visibility.Collapsed;
		}
	}
	#endregion

	#region Button to send request mail is clicked
	private void BtnSendMail( object sender, RoutedEventArgs e )
	{
		var resetCode = Codes.GenerateCharacterCode( 2 ) + Codes.GenerateNumberCode( 4 );

		Login.FillUserProperties( Login.GetUserId( tbUserName.Text ) );

		tbSecretCode.Text = resetCode;

		MailHelper.SendResetCodeEmail( tbUserName.Text, App.ScoreUsers.SelectedUserFullName, resetCode );

		ShowEmail.Text = tbUserName.Text;

		ResetCode.Visibility = Visibility.Visible;
		tbResetCode.Focus();
	}
	#endregion

	#region Input for resetcode has changed, validate format
	private void ResetCodeInputPreview( object sender, TextCompositionEventArgs e )
	{
		System.Windows.Controls.TextBox? textBox = sender as System.Windows.Controls.TextBox;

		if ( textBox.Text.Length < 2 )
		{
			// Only accept alphabetic characters for the first two characters
			e.Handled = !( char.IsLetter( e.Text, 0 ) && !char.IsDigit( e.Text, 0 ) );
			if ( !e.Handled )
			{
				_pendingInput += e.Text.ToUpper();
			}
		}
		else if ( textBox.Text.Length >= 2 && textBox.Text.Length < 6 )
		{
			// Only accept numeric characters for next four characters
			e.Handled = !char.IsDigit( e.Text, 0 );
			if ( !e.Handled )
			{
				_pendingInput += e.Text;
			}
		}
		else
		{
			e.Handled = true;
		}
	}
	#endregion

	#region Resetcode has changed
	private void ResetCodeTextChanged( object sender, TextChangedEventArgs e )
	{
		System.Windows.Controls.TextBox? textBox = sender as System.Windows.Controls.TextBox;

		if ( textBox.Text.Length > 6 )
		{
			textBox.Text = _pendingInput.Substring( 0, 6 );
			textBox.CaretIndex = textBox.Text.Length;
		}
		else
		{
			textBox.Text = _pendingInput;
			textBox.CaretIndex = textBox.Text.Length;
		}

		_pendingInput = textBox.Text;

		if ( textBox.Text.Length == 6 )
		{
			if ( textBox.Text == tbSecretCode.Text )
			{
				// Entered Code is correct
				PasswordChange.Visibility = Visibility.Visible;
				tbWrongCode.Visibility = Visibility.Collapsed;
				HelpText.Visibility = Visibility.Collapsed;
				btnSendMail.Visibility = Visibility.Collapsed;
				ResetCode.Visibility = Visibility.Collapsed;
				EmailInput.Visibility = Visibility.Collapsed;
				pbPassword.Focus();
			}
			else
			{
				//Entered code is incorrect
				PasswordChange.Visibility = Visibility.Collapsed;
				tbWrongCode.Visibility = Visibility.Visible;
			}
		}
	}
	#endregion

	#region Delete or Backspace entered during entering resetcode
	private void ResetCodePreviewKeyDown( object sender, System.Windows.Input.KeyEventArgs e )
	{
		System.Windows.Controls.TextBox? textBox = sender as System.Windows.Controls.TextBox;

		if ( e.Key == Key.Back && textBox.Text.Length > 0 )
		{
			_pendingInput = _pendingInput.Substring( 0, _pendingInput.Length - 1 );
		}
		else if ( e.Key == Key.Delete && textBox.Text.Length > 0 )
		{
			textBox.Text = _pendingInput = "";
		}
	}
	#endregion

	#region Save new password button is clicked
	private void SavePassword( object sender, RoutedEventArgs e )
	{
		ObservableCollection<UserModel> ModifiedUser = [];

		tbName.Text = tbUserName.Text.Contains( "@" ) ? Login.CheckEmailLogin( tbUserName.Text ) : tbName.Text;

		var _checkPassword = Helper.HashPepperPassword(pbPassword.Password, tbName.Text);
		var _userId = Login.GetUserId(tbUserName.Text);

		App.ScoreUsers.SelectedUserId = _userId;
		App.ScoreUsers.SelectedUserPassword = _checkPassword;
		App.ScoreUsers.SelectedUserName = tbName.Text;
		App.ScoreUsers.SelectedUserEmail = tbUserName.Text;

		ModifiedUser.Add( new UserModel
		{
			UserId = _userId,
			UserPassword = _checkPassword
		} );

		//Update user
		DBCommands.UpdateUser( ModifiedUser );

		Login.FillUserProperties( _userId );

		#region Write logging information
		DBCommands.WriteLog( App.ScoreUsers.SelectedUserId, DBNames.LogUserChanged, App.ScoreUsers.SelectedUserFullName );

		int historyId = DBCommands.GetAddedHistoryId ();

		DBCommands.WriteDetailLog( historyId, DBNames.LogUserPassword, "", "" );
		#endregion



		Login.FillUserProperties( _userId );

		// Write Login to Logfile
		DBCommands.WriteLog( _userId, DBNames.LogUserLoggedIn, $"{App.ScoreUsers.SelectedUserFullName} is ingelogt" );

		//Login the main application
		MainWindow mainWindow = new();
		mainWindow.Show();
		this.Close();

		//ModifyScoreUserData( ModifiedUser );
	}
	#endregion

	#region Password has been changed, validate criteria
	private void PasswordChanged( object sender, RoutedEventArgs e )
	{
		btnSavePassword.Visibility = pbPassword.Password.Length > 2 ? Visibility.Visible : Visibility.Collapsed;
	}
	#endregion
}
