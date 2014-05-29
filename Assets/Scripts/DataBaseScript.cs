using UnityEngine;
using System.Collections;
using System.Data.SQLite;

public static class DataBaseScript {

	// Use this for initialization

	public static SQLiteConnection connection;

	public static void init(string conectionString)
	{
		connection = new SQLiteConnection (conectionString);
	}

	public static void addUser(
}
