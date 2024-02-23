﻿using System.Collections.ObjectModel;
using System.Windows;
using KHM.Models;

namespace KHM;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App ( )
    {
        //Register Syncfusion license
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense ("Ngo9BigBOggjHTQxAR8/V1NHaF5cWWNCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWH9fdXVURWJeUkBzW0Y=");
    }
    public class ScoreUsers
    {
        public static int SelectedUserId { get; set; }
        public static string SelectedUserName { get; set; }
        public static string SelectedUserFullName { get; set; }
        public static string SelectedUserEmail { get; set; }
        public static string SelectedUserPassword { get; set; }
        public static int SelectedUserRoleId { get; set; }
        public static string SelectedUserCoverSheetFolder { get; set; }
        public static int SelectedUserRoleName { get; set; }
        public static int SelectedUserRoleDescription { get; set; }
        public static string SelectedUserDownloadFolder {get; set; }
        public static ObservableCollection<UserModel> User { get; set; }
    }
}
