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
	public int getId_Utiliz(string username){
		DataSet ds=gameObject.GetComponent<DatabaseAccessScript>().Get(string.Format ("SELECT id_utiliz "+
		                                                                              "FROM utilizator "+
		                                                                              "WHERE username='{0}'",username));
		int aux;
		int.TryParse(ds.Tables[0].Rows[0][0].ToString(),out aux);
		return aux;
	}
	public bool checkCharName(string name){
		DataSet ds=gameObject.GetComponent<DatabaseAccessScript>().Get(string.Format ("SELECT 1 "+
		                                                                              "FROM caracter "+
		                                                                              "WHERE name='{0}'",name));
		if(ds.Tables[0].Rows.Count==0){
			return false;
		}
		return true;
	}
	public string[] getCharNames(string username){
		DataSet ds=gameObject.GetComponent<DatabaseAccessScript>().Get(string.Format("SELECT caracter.name "+
		                                                                             "FROM caracter, utilizator "+
		                                                                             "WHERE caracter.id_utiliz= utilizator.id_utiliz "+
		                                                                             "AND utilizator.username = '{0}'",username));
		string[]aux=new string[ds.Tables[0].Rows.Count];
		for(int i=0;i<aux.Length;i++){
			aux[i]=ds.Tables[0].Rows[i][0].ToString();
		}
		return aux;
	}
}
