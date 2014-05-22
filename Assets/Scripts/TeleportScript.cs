using UnityEngine;
using System.Collections;
using System.IO;


public class TeleportScript : MonoBehaviour {
	private static int[,] m;
	private int whichMap;

	void init(int index)
	{
		whichMap = index;
		m=new int[45,35];
		
		//FileStream theSourceFile = new FileStream(@"map"+whichMap+".txt", 
		//                                          FileMode.OpenOrCreate, 
		//                                          FileAccess.ReadWrite, 
		//                                          FileShare.None);
		//FileInfo theSourceFile = new FileInfo ("Assets\\Resources\\map" +whichMap+
		//	".txt");
		StreamReader reader = new StreamReader("Assets\\Resources\\map" +whichMap+".txt");
		string text;
		text = reader.ReadLine();
		int j=0;
		int i;
		while (text != null)
		{
			string[] tokens = text.Split(',');
			for( i=0; i<tokens.Length; i++ ) 
			{
				m[j,i]=int.Parse(tokens[i]);
			}
			j++;
			text = reader.ReadLine();
			
		}
	}

	void Start () {
		init (1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
<<<<<<< HEAD
		//Debug.Log("Collision with "+other.gameObject.tag);
        if (other.tag != "Bullet") {
            int n1, n2;
            int x, y;
            int newx, newy;
            Vector3 temp = other.transform.position;
            bool goon = true;
            do {
                n1 = Mathf.RoundToInt(Random.Range(-33, 33));
                n2 = Mathf.RoundToInt(Random.Range(-43, 43));

                //n1+=0.47;
                //n2-=0.47;

                newx = Mathf.FloorToInt(temp.x);
                newy = Mathf.FloorToInt(temp.y);
                x = newx + n1;
                y = newy + n2;
                if (x > 33 || x < 1) {
                    Debug.Log("out of bounds: x=" + x);
                    continue;
                } else
                    if (y < -43 || y > -1) {
                        Debug.Log("out of bounds: y=" + y);
                    } else
                        if (m[Mathf.Abs(y), x] == 0) {
                            Debug.Log("wall: " + x + " , " + y);

                        } else
                            goon = false;

            }
            while (goon);
            Debug.Log("new coords: x=" + x + " y=" + y);

            float nx = (temp.x - (newx + 0.5f));
            float ny = (temp.y - (newy + 0.5f));
            other.transform.Translate(n1 - nx, n2 - ny, 0);
        }
=======
		Debug.Log("Collision with "+other.gameObject.tag);
		int n1,n2;
		int x,y;
		int newx,newy;
		Vector3 temp=other.transform.position;
		bool goon=true;
		do
		{
			n1 = Mathf.RoundToInt(Random.Range(-33,33)); 
			n2 = Mathf.RoundToInt(Random.Range(-43,43));
			newx=Mathf.FloorToInt(temp.x);
			newy=Mathf.FloorToInt(temp.y);
			x=newx+n1;
			y=newy+n2;
			if (x>33 || x<1)
			{
				Debug.Log("out of bounds: x="+x);
				continue;
			}
			else
				if (y<-43 || y>-1)
			{
				Debug.Log("out of bounds: y="+y);
			}
			else
				if (m[Mathf.Abs(y),x]==0)
			{
				Debug.Log("wall: "+x+" , "+y);
				
			}
			else
				goon=false;
			
		}
		while(goon);
		Debug.Log("new coords: x="+x+" y="+y);
		
		float nx=(temp.x-(newx+0.5f));
		float ny=(temp.y-(newy+0.5f));
		other.transform.Translate(n1-nx,n2-ny,0);
>>>>>>> b0f355bb15a2a8d2032474b175a46d132ef83efd
	}
}
