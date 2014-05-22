using UnityEngine;
using System.Collections;

public class statsbar : MonoBehaviour {
	public float hpbarDisplay; //current progress
	public float mbbarDisplay;
	public Vector2 poshb = new Vector2(20,40);
	public Vector2 posmb = new Vector2(20,60);
	private Vector2 size ;
	public  float maxHealth = 100;
	public float curHealth = 100;
	public  float maxMana = 100;
	public float curMana = 100;
	public float barHeight = 9;
	public float healthBarlenght;
	public float dimbarDinscreen=2;
	private GUIStyle currentStyleempty = null;
	private GUIStyle hpcurrentStyle = null;
	private GUIStyle mncurrentStyle = null;
	
	void OnGUI() {
		//draw the background:
		InitStyles ();
		GUI.BeginGroup(new Rect(poshb.x, poshb.y, healthBarlenght, 20));
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, healthBarlenght * hpbarDisplay, 20));
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"", hpcurrentStyle);
		GUI.EndGroup();
		GUI.EndGroup();

		GUI.BeginGroup(new Rect(posmb.x, posmb.y, healthBarlenght, 20));
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, healthBarlenght * mbbarDisplay, 20));
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"", mncurrentStyle);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	void Start () {
		healthBarlenght = Screen.width /dimbarDinscreen;

	}

	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		AdjustcurHealth (0);
		AdjustcurMana (0);
		//   hpbarDisplay = MyControlScript.staticHealth;
	}
	public void AdjustcurHealth (int adjhp) {
		curHealth += adjhp;
		if(curHealth < 0)
			curHealth = 0;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		if(maxHealth < 1)
			maxHealth = 1;
		hpbarDisplay =  (curHealth / (float)maxHealth);
	 healthBarlenght = Screen.width / dimbarDinscreen;
}

	public void AdjustcurMana (int adjmana) {
		curMana += adjmana;
		if(curMana < 0)
			curMana = 0;
		if(curMana > maxMana)
			curMana = maxMana;
		if(maxMana < 1)
			maxMana = 1;
		mbbarDisplay =  (curMana / (float)maxMana);
		healthBarlenght = Screen.width / dimbarDinscreen;
	}
	private void InitStyles()
	{
		if( hpcurrentStyle == null )		
		{			
			hpcurrentStyle = new GUIStyle( GUI.skin.box );			
			hpcurrentStyle.normal.background = MakeTex( 2, 2, new Color( 1, 0, 0, 1 ) );			
		}	
		if( currentStyleempty == null )		
		{			
			currentStyleempty = new GUIStyle( GUI.skin.box );			
			currentStyleempty.normal.background = MakeTex( 2, 2, new Color( 0, 0, 0, 1 ) );			
		}	
		if( mncurrentStyle == null )		
		{			
			mncurrentStyle = new GUIStyle( GUI.skin.box );			
			mncurrentStyle.normal.background = MakeTex( 2, 2, new Color( 0, 0, 1, 1 ) );			
		}	
	}
	

	
	private Texture2D MakeTex( int width, int height, Color col )		
	{		
		Color[] pix = new Color[width * height];		
		for( int i = 0; i < pix.Length; ++i )			
		{			
			pix[ i ] = col;			
		}		
		Texture2D result = new Texture2D( width, height );		
		result.SetPixels( pix );		
		result.Apply();		
		return result;		
	}

}