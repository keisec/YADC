using UnityEngine;
using System.Collections;
using System.Data;

public class DatabaseInterogationScript : MonoBehaviour {

	// Use this for initialization
	public bool checkIfUserExists(string user){
		DataSet ds = gameObject.GetComponent<DatabaseAccessScript> ().Get (string.Format("SELECT 1 " +
		                                                                                 "FROM utilizator " + 
		                                                                                 "WHERE username = '{0}'",user));
		if (ds.Tables [0].Rows.Count == 0) {
						return false;
				}
		return true;
	}

	public bool checkPassword(string username,string password){
		DataSet ds=gameObject.GetComponent<DatabaseAccessScript>().Get (string.Format("SELECT 1 " + 
		                                                                              "FROM utilizator " +
		                                                                              "WHERE username='{0}'" +
		                                                                              "AND password='{1}'",username,password));
		if(ds.Tables[0].Rows.Count==0){
			return false;
		}
		return true;
	}
}
