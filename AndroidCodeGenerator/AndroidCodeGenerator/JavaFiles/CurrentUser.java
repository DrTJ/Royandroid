package ir.royapajoohesh.utils;

/* Created by DrTJ @ September 2015 */ 

public class CurrentUser {
	public static int UserID = -1;
	public static String Username = "";
	public static String DisplayName = "";
	
	public static void SetUser(int id, String username, String displayName){
		CurrentUser.UserID = id;
		CurrentUser.Username = username;
		CurrentUser.DisplayName = displayName;
	}
}


