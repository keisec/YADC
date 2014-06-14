using UnityEngine;
using System.Collections;
//using Mono.Data.SqliteClient;
using Mono.Data.Sqlite;

public class DatabaseAddingScript : MonoBehaviour {
	
	// Use this for initialization
	void Start(){
	}

	public void AddNewUser(string user,string password){
		gameObject.GetComponent<DatabaseAccessScript>().Do(string.Format ("INSERT INTO utilizator(username,password) "+
		                                                                  "VALUES ('{0}','{1}')",user,password));
	}
	public void AddNewChar(string name,string cls,int hp,int mana){
		int id=gameObject.GetComponent<DatabaseInterogationScript>().getId_Utiliz(gameObject.GetComponent<storeDataScript>().username);
		gameObject.GetComponent<DatabaseAccessScript>().Do(string.Format("INSERT INTO caracter(name,class,health,mana,id_utiliz) "+
		                                                                 "VALUES ('{0}','{1}','{2}','{3}','{4}')",name,cls,hp,mana,id));
	}
}
