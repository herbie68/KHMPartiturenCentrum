﻿namespace KHM.Models;
public class UserModel
{
	public int UserId { get; set; }
	public string UserName { get; set; }
	public string UserEmail { get; set; }
	public string UserPassword { get; set; }
	public string UserFullName { get; set; }
	public int UserRoleId { get; set; }
	public string RoleName { get; set; }
	public string RoleDescription { get; set; }
	public string CoverSheetFolder { get; set; }
	public string DownloadFolder { get; set; }
}
