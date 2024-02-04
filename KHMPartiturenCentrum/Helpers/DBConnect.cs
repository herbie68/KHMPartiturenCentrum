﻿using System;

using Microsoft.Win32;

using MySql.Data.MySqlClient;

namespace KHM.Helpers;

public class DBConnect
{
    public MySqlConnection? connection;
    public static readonly string server = RegHelper.GetIP();
    //public static readonly string server = "95.99.95.112";
    //public static readonly string server = "192.168.1.100";
    public static readonly string database = DBNames.Database;
    public static readonly string port = "3306";
    public static readonly string uid = "root";
    public static readonly string password = "OefenenKHMK24!";
    public static string ConnectionString = "SERVER=" + server + ";PORT=" + port + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";
 
}

