using UnityEngine;
using System.Collections;

public class statsbar : MonoBehaviour {
	public float hpbarDisplayp1; 
	public float mbbarDisplayp1;
	public float hpbarDisplayp2; 
	public float mbbarDisplayp2;
	public float hpbarDisplayp3; 
	public float mbbarDisplayp3;
	public float hpbarDisplayp4; 
	public float mbbarDisplayp4;
	public Vector2 poshbp1 = new Vector2(10,40);
	public Vector2 posmbp1 = new Vector2(10,60);	
	public Vector2 poshbp2 = new Vector2(2*((2 * Screen.width / 3) / 4),40);
	public Vector2 posmbp2 = new Vector2(2*((2 * Screen.width / 3) / 4),60);
	public Vector2 poshbp3 = new Vector2(3*((2 * Screen.width / 3) / 4),40);
	public Vector2 posmbp3 = new Vector2(3*((2 * Screen.width / 3) / 4),60);
	public Vector2 poshbp4 = new Vector2(4*((2 * Screen.width / 3) / 4),40);
	public Vector2 posmbp4 = new Vector2(4*((2 * Screen.width / 3) / 4),60);
	private Vector2 size ;
	public  float maxHealthp1 = 100;
	public float curHealthp1 = 100;
	public  float maxManap1 = 100;
	public float curManap1 = 100;
	public  float maxHealthp2 = 100;
	public float curHealthp2 = 100;
	public  float maxManap2 = 100;
	public float curManap2 = 100;
	public  float maxHealthp3 = 100;
	public float curHealthp3 = 100;
	public  float maxManap3 = 100;
	public float curManap3 = 100;
	public  float maxHealthp4 = 100;
	public float curHealthp4 = 100;
	public  float maxManap4 = 100;
	public float curManap4 = 100;
	public float barHeight = 13;
	public float healthBarlenght;
	public float dimbarDinscreen=2;
	public string numep1="nume1";
	public string numep2="nume2";
	public string numep3="nume3";
	public string numep4="nume4";
	private GUIStyle currentStyleempty = null;
	private GUIStyle hpcurrentStyle = null;
	private GUIStyle mncurrentStyle = null;
	private GUIStyle  currentStylebg = null;
	public int numar_playeri=1;
	private GUIStyle myStyle = new GUIStyle();

	void start(){
		int[] player = new int[numar_playeri];
		for (int i=0; i<numar_playeri; i++) {
			player[i]=i+1;
		}
		}
	
	void OnGUI() {
		//draw the background:
		if(numar_playeri==1)
		{
		InitStyles ();
			GUI.BeginGroup(new Rect(0, 0,2*Screen.width/3,80),"",currentStylebg);
		
		GUI.BeginGroup(new Rect(poshbp1.x, poshbp1.y, healthBarlenght, 20));
		
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp1+ "/"+maxHealthp1 , myStyle);
		GUI.EndGroup();
		GUI.BeginGroup(new Rect(posmbp1.x, posmbp1.y, healthBarlenght, 20));
		GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp1, barHeight),"", mncurrentStyle);	
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap1+ "/"+maxManap1 , myStyle);
		GUI.EndGroup();	
		GUI.EndGroup ();
			}
		else
			if(numar_playeri==2)
		{
			InitStyles ();
			GUI.BeginGroup(new Rect(0, 0,2*Screen.width/3,80),"",currentStylebg);			
			GUI.BeginGroup(new Rect(poshbp1.x, poshbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp1+ "/"+maxHealthp1 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp1.x, posmbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp1, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap1+ "/"+maxManap1 , myStyle);
			GUI.EndGroup();	



						
			GUI.BeginGroup(new Rect(poshbp2.x, poshbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp2, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp2+ "/"+maxHealthp2 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp2.x, posmbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp2, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap2+ "/"+maxManap2 , myStyle);
			GUI.EndGroup();	


			GUI.EndGroup ();

		}
		else
			if(numar_playeri==3)
		{
			InitStyles ();
			GUI.BeginGroup(new Rect(0, 0,2*Screen.width/3,80),"",currentStylebg);			
			GUI.BeginGroup(new Rect(poshbp1.x, poshbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp1+ "/"+maxHealthp1 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp1.x, posmbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp1, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap1+ "/"+maxManap1 , myStyle);
			GUI.EndGroup();	

			GUI.BeginGroup(new Rect(poshbp2.x, poshbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp2, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp2+ "/"+maxHealthp2 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp2.x, posmbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp2, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap2+ "/"+maxManap2 , myStyle);
			GUI.EndGroup();	


			GUI.BeginGroup(new Rect(poshbp3.x, poshbp3.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp3, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp3+ "/"+maxHealthp3 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp3.x, posmbp3.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp3, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap3+ "/"+maxManap3 , myStyle);
			GUI.EndGroup();	

			
			GUI.EndGroup ();
		}
		else

		{
			InitStyles ();
			GUI.BeginGroup(new Rect(0, 0,2*Screen.width/3,80),"",currentStylebg);			
			GUI.BeginGroup(new Rect(poshbp1.x, poshbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp1+ "/"+maxHealthp1 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp1.x, posmbp1.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp1, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap1+ "/"+maxManap1 , myStyle);
			GUI.EndGroup();	
			
			GUI.BeginGroup(new Rect(poshbp2.x, poshbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp2, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp2+ "/"+maxHealthp2 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp2.x, posmbp2.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp2, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap2+ "/"+maxManap2 , myStyle);
			GUI.EndGroup();	

			
			GUI.BeginGroup(new Rect(poshbp3.x, poshbp3.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp3, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp3+ "/"+maxHealthp3 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp3.x, posmbp3.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp3, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap3+ "/"+maxManap3 , myStyle);
			GUI.EndGroup();	


			GUI.BeginGroup(new Rect(poshbp4.x, poshbp4.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp4, barHeight),"", hpcurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curHealthp4+ "/"+maxHealthp4 , myStyle);
			GUI.EndGroup();			
			GUI.BeginGroup(new Rect(posmbp4.x, posmbp4.y, healthBarlenght, 20));
			GUI.Box(new Rect(0,0, healthBarlenght, barHeight),"",currentStyleempty);					
			GUI.Box(new Rect(0,0, healthBarlenght * mbbarDisplayp4, barHeight),"", mncurrentStyle);
			GUI.Box(new Rect(0,0, healthBarlenght * hpbarDisplayp1, barHeight),curManap4+ "/"+maxManap4 , myStyle);
			GUI.EndGroup();	

			
			GUI.EndGroup ();
		}
	}

	void Start () {
		healthBarlenght = ((2*Screen.width/3)/4)-10;

	}

	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		AdjustcurHealth (0,1);
		AdjustcurMana (0,1);
		AdjustcurHealth (0,2);
		AdjustcurMana (0,2);
		AdjustcurHealth (0,3);
		AdjustcurMana (0,3);
		AdjustcurHealth (0,4);
		AdjustcurMana (0,4);
		 poshbp1 = new Vector2(0,40);
		 posmbp1 = new Vector2(0,60);	
		 poshbp2 = new Vector2(((2 * Screen.width / 3) / 4),40);
		 posmbp2 = new Vector2(((2 * Screen.width / 3) / 4),60);
		 poshbp3 = new Vector2(2*((2 * Screen.width / 3) / 4),40);
		 posmbp3 = new Vector2(2*((2 * Screen.width / 3) / 4),60);
		 poshbp4 = new Vector2(3*((2 * Screen.width / 3) / 4),40);
		 posmbp4 = new Vector2(3*((2 * Screen.width / 3) / 4),60);
		//   hpbarDisplay = MyControlScript.staticHealth;
	}
	public void AdjustcurHealth (int adjhp,int p_nr) {
		if (p_nr == 1) {
						curHealthp1 += adjhp;
						if (curHealthp1 < 0)
				curHealthp1 = 0;
			if (curHealthp1 > maxHealthp1)
				curHealthp1 = maxHealthp1;
			if (maxHealthp1 < 1)
				maxHealthp1 = 1;
			hpbarDisplayp1 = (curHealthp1 / (float)maxHealthp1);
						healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
				}
		else
		if (p_nr == 2) {
			curHealthp2 += adjhp;
			if (curHealthp2 < 0)
				curHealthp2 = 0;
			if (curHealthp2 > maxHealthp2)
				curHealthp2 = maxHealthp2;
			if (maxHealthp2 < 1)
				maxHealthp2 = 1;
			hpbarDisplayp2 = (curHealthp2 / (float)maxHealthp2);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
		else
		if (p_nr == 3) {
			curHealthp3 += adjhp;
			if (curHealthp3 < 0)
				curHealthp3 = 0;
			if (curHealthp3 > maxHealthp3)
				curHealthp3 = maxHealthp3;
			if (maxHealthp3 < 1)
				maxHealthp3 = 1;
			hpbarDisplayp3 = (curHealthp3 / (float)maxHealthp3);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
		else  {
			curHealthp4 += adjhp;
			if (curHealthp4 < 0)
				curHealthp4 = 0;
			if (curHealthp4 > maxHealthp4)
				curHealthp4 = maxHealthp4;
			if (maxHealthp4 < 1)
				maxHealthp4 = 1;
			hpbarDisplayp4 = (curHealthp4 / (float)maxHealthp4);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
}

	public void AdjustcurMana (int adjmana,int p_nr) {
		if (p_nr == 1) {
						curManap1 += adjmana;
			if (curManap1 < 0)
				curManap1 = 0;
			if (curManap1 > maxManap1)
				curManap1 = maxManap1;
			if (maxManap1 < 1)
				maxManap1 = 1;
			mbbarDisplayp1 = (curManap1 / (float)maxManap1);
						healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
				}
		else
		if (p_nr == 2) {
			curManap2 += adjmana;
			if (curManap2 < 0)
				curManap2 = 0;
			if (curManap2 > maxManap2)
				curManap2 = maxManap2;
			if (maxManap2 < 1)
				maxManap2 = 1;
			mbbarDisplayp2 = (curManap2/ (float)maxManap2);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
		else
		if (p_nr == 3) {
			curManap3 += adjmana;
			if (curManap3 < 0)
				curManap3 = 0;
			if (curManap3 > maxManap3)
				curManap3 =  maxManap3;
			if ( maxManap3 < 1)
				maxManap3 = 1;
			mbbarDisplayp3 = (curManap3 / (float) maxManap3);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
		else{
			curManap4 += adjmana;
			if (curManap4  < 0)
				curManap4  = 0;
			if (curManap4  > maxManap4)
				curManap4  = maxManap4;
			if (maxManap4 < 1)
				maxManap4 = 1;
			mbbarDisplayp4 = (curManap4  / (float)maxManap4);
			healthBarlenght = ((2 * Screen.width / 3) / 4) - 10;
		}
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
			currentStyleempty.normal.background = MakeTex( 2, 2, new Color( 0.5f, 0.5f, 0.5f, 1 ) );			
		}	
		if( currentStylebg == null )		
		{			
			currentStylebg = new GUIStyle( GUI.skin.box );			
			currentStylebg.normal.background = MakeTex( 2, 2, new Color( 0, 0, 0, 1 ) );			
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