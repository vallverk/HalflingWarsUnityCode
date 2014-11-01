using UnityEngine;
using System.Collections;

public class barallelmover : MonoBehaviour
{
	public GameObject BeerA;
	public GameObject BeerB;
	public GameObject instmug;
	public GameObject remmove;
	public GameObject rigidRemover;
	//public GameObject LeftArrow;
	public Camera maincamera;
	public GameObject RightArrw;

	public bool moveAB_Bool, moveBA_Bool,firsttimeArrow;

	public float speed;
	private ProjectileCube pc;
	public int timer;
	public GUIStyle speedupstyle;
	
	public float leverSpeed = 20;
	Rect temp;
	public GUITexture leveler;
	
	public AudioController scr_audioController;
	
	void Start ()
	{
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		leveler = GameObject.Find("GlassFillLeveler").GetComponent<GUITexture>();
		temp = leveler.pixelInset;
		temp.height = 63;
		leveler.pixelInset = temp;
		BeerA = GameObject.Find ("BeerPosA");
		BeerB = GameObject.Find("BeerPosB");
		moveAB_Bool = true;
		pc = (ProjectileCube)FindObjectOfType(typeof(ProjectileCube));
		
		maincamera = GameObject.Find("BeerCamera").camera ;
		InvokeRepeating("BrallelTimer", float.Epsilon, 1f);
		
		Instantiate(instmug,new Vector3(2.18f,-2.4f,60f),Quaternion.Euler(0,0,180));
	}
	
	void BrallelTimer()
	{
		timer++;
	}
	
	void Update () 
	{
		remmove = GameObject.FindGameObjectWithTag("destorymug");
		rigidRemover = GameObject.Find("Rigidbody dragger");
		
		if(timer >=0 && timer<15)
		{speed = 2.5f;}
		else if(timer >=15 && timer<30)
		{speed = 5.0f;}
		else if(timer >=30 && timer<45)
		{speed = 6.5f;}
		else if(timer >=45 && timer<60)
		{speed = 8.0f;}
		else if(timer >=60 && timer<80)
		{speed = 10.0f;}
		else if(timer >=80 && timer<100)
		{speed = 12.5f;}
		else{this.GetComponent<barallelmover>().enabled = false;
//		remmove.transform.GetComponent<DragRigidbody>().enabled = false;
		remmove.rigidbody.constraints = RigidbodyConstraints.FreezeAll;  }
		
		if (moveAB_Bool)
		{
			if (Vector3.Distance(transform.position, BeerB.transform.position) < 0.5f)
			{
				moveAB_Bool = false;
				moveBA_Bool = true;
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			}
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}

		if (moveBA_Bool)
		{
			if (Vector3.Distance(transform.position, BeerA.transform.position) < 0.5f)
			{
				moveAB_Bool = true;
				moveBA_Bool = false;
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			}
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		
		if(pc.filler == true)
		{
			temp.height += leverSpeed * Time.deltaTime;
			temp.height = Mathf.Clamp( temp.height, 0 , 295);
			leveler.pixelInset = temp;
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			Destroy(rigidRemover);
		}
		
		if(remmove.transform.position.x > 9.0f&& leveler.pixelInset.height > 290 || remmove.transform.position.x < -9.0f && leveler.pixelInset.height > 290)
		{
			leveler.pixelInset = new Rect(0,-1,122,63);
			temp = leveler.pixelInset;
			temp.height = 63;
			maincamera.SendMessage("UpdateCount");
			Instantiate(instmug,new Vector3(2.18f,-2.4f,60f),Quaternion.Euler(0,0,180));
			firsttimeArrow = true;
			Destroy(remmove); 
		}
		else if(remmove.transform.position.x >9.0f || remmove.transform.position.x < -9.0f)
		{
			leveler.pixelInset = new Rect(0,-1,122,63);
			temp = leveler.pixelInset;
			temp.height = 63;
			Instantiate(instmug,new Vector3(2.18f,-2.4f,60f),Quaternion.Euler(0,0,180));
			Destroy(remmove);
		}
		else{}
		
		if(leveler.pixelInset.height > 290 && firsttimeArrow == false)
		{
//			LeftArrow.active = true;
			RightArrw.active = true;
		}
		else
		{
//			LeftArrow.active = false;
			RightArrw.active = false;
		}
	}
}