using CommunityToolkit.Mvvm.ComponentModel;

namespace KHM.ViewModels;
public partial class UserViewModel : ObservableObject
{
	[ObservableProperty]
	public int userId;

	[ObservableProperty]
	public string userName;

	[ObservableProperty]
	public string userEmail;

	[ObservableProperty]
	public string userPassword;

	[ObservableProperty]
	public string userFullName;

	[ObservableProperty]
	public int userRoleId;

	[ObservableProperty]
	public string coverSheetFolder;

	[ObservableProperty]
	public string downloadFolder;

	[ObservableProperty]
	public string roleName;

	[ObservableProperty]
	public string roleDescription;

	[ObservableProperty]
	public object selectedItem ="";

	public ObservableCollection<UserModel> Users { get; set; }

	public UserViewModel()
	{
		Users = new ObservableCollection<UserModel>();
		Users = DBCommands.GetUsers();
	}

}
