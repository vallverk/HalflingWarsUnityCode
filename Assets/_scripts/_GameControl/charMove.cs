using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]

public class charMove : MonoBehaviour 
{
	public float speed = 3f, length = 5f;
	
	public float f_Direction = 117f, b_Direction = 297f, l_Direction = 62f, r_Direction = 242f;
	
	public Transform[] waypoints = new Transform[7];
	
	RaycastHit hit;
	
	private GameObject curObj, prevObj;
	
	private string  Left = "Left", Right = "Right", Front = "Front", Back = "Back", LeftBack = "LeftBack", RightBack = "RightBack";
	public  string status;
	
	private bool moveBool = false;
	private int type = 0;
	
	private bool turnLeftBool = false, turnRightBool = false, turnLeftBackBool = false, turnRightBackBool = false, turnBackBool = false;
	
	public GameObject hChar;
	public GameManager scr_GameManager;
	
	public GameObject h_BackIdle, h_FrontIdle, h_BackWalk, h_FrontWalk, h_LeftWalk, h_RightWalk, shadow;
	public GameObject h_Animation;
	
	private GameObject dirtPathObj;
	public AudioController scr_audioController;
	
	private RaycastHit charHit;
	public Camera camera;
	
	// Use this for initialization
	void Start () 
	{
		status = "Left";
		
		if (transform.gameObject.name == "h_Character")
			transform.position = new Vector3(-64.24f, transform.position.y, 1.6f);
		
		if (transform.gameObject.name == "d_Character")
			transform.position = new Vector3(64.24f, transform.position.y, 1.6f);
		
		scr_GameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		
		dirtPathObj = GameObject.Find("HC_D_DirtPath_GO(Clone)") as GameObject;
		if (dirtPathObj != null)
		{
			status = "Left";
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = true;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//chk collision with char
		Ray characterRay =  camera.ScreenPointToRay(Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(characterRay, out charHit))
				{
					if (charHit.collider.gameObject.name =="h_Animation")
					{
						//Debug.Log("Hit ......Hit ");
					    PlayHWcharSound();
					}
				}
			}
		
		
		
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		
		// for Front
		if (status == "Front")
		{	
			//Debug.Log("Front...");
			Vector3 forward = transform.TransformDirection(Vector3.forward) * length;
			Debug.DrawRay(transform.position, forward, Color.green);
			moveBool = true;
			
			if (Physics.Raycast(transform.position, fwd, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
				{
					if (curObj != null)
						prevObj = curObj;
				
					curObj = hit.collider.gameObject;
					moveBool = true;
				}
//				else
//					Debug.Log("no animation.......");
			}
			else
			{
//				Debug.Log("dont play animation......");
				moveBool = false;
				if (curObj != null)
					transform.position = curObj.transform.position;
				FindDirection();
				h_WalkAnimation();
			}
		}
		
		if (moveBool)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal)), transform.position.z);
			h_WalkAnimation();
		}
		h_Animation.transform.position = transform.position;
	}
	
	void FindDirection()
	{
		// Front
		if (transform.eulerAngles.y > 115 && transform.eulerAngles.y < 120)
		{
			//Debug.Log("01 Left... Back Right...");
			
			// check Left waypoing available...
			Vector3 lSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f));
			Vector3 leftSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide, Color.green);
			
			// check Right Back waypoint available...
			Vector3 rBSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f));
			Vector3 rightBackSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, rightBackSide, Color.green);
			
			// check left waypoint hit
			if (Physics.Raycast(transform.position, lSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnLeftBool = true;
			}
			else 
				turnLeftBool = false;
			
			if (Physics.Raycast(transform.position, rBSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnRightBackBool = true;
			}
			else
				turnRightBackBool = false;
			
			// random select left right
			if (turnLeftBool && turnRightBackBool)
			{
				int randomVal = Random.Range(1, 15);
				Debug.Log("type :: " + randomVal);
				
				if (randomVal % 2 == 0)
					transform.eulerAngles = new Vector3 (0, 62, 0); //Debug.Log("move left...");
				else
					transform.eulerAngles = new Vector3 (0, 242, 0); //Debug.Log("move right...");
			}
			
			// turn right
			else if (turnRightBackBool)
				transform.eulerAngles = new Vector3 (0, 242, 0); //Debug.Log("turn right........");
			
			// turn left
			else if (turnLeftBool)
				transform.eulerAngles = new Vector3 (0, 62, 0); //Debug.Log("turn left.........");
			
			// turn back
			else
			{
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
			}
		}
		
		// Right
		else if (transform.eulerAngles.y > 240 && transform.eulerAngles.y < 244)
		{
			type = 2;
			//Debug.Log("02 Back Left... Right...");
			
			Vector3 lSide = transform.TransformDirection(new Vector3(-0.6f, 0, -0.4f));
			Vector3 leftSide = transform.TransformDirection(new Vector3(-0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide, Color.green);
			
			// check Right Back waypoint available...
			Vector3 rBSide = transform.TransformDirection(new Vector3(0.6f, 0, 0.4f));
			Vector3 rightBackSide = transform.TransformDirection(new Vector3(0.6f, 0, 0.4f)) * length;
			Debug.DrawRay(transform.position, rightBackSide, Color.green);
			
			// check left waypoint hit
			if (Physics.Raycast(transform.position, lSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnLeftBool = true;
			}
			else 
				turnLeftBool = false;
			
			if (Physics.Raycast(transform.position, rBSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnRightBackBool = true;
			}
			else
				turnRightBackBool = false;
			
			// random select left right
			if (turnLeftBool && turnRightBackBool)
			{
				int randomVal = Random.Range(1, 15);
				Debug.Log("type :: " + randomVal);
				
				if (randomVal % 2 == 0)
					transform.eulerAngles = new Vector3(0, 117, 0); //Debug.Log("move left...");
				else
					transform.eulerAngles = new Vector3(0, 297, 0); //Debug.Log("move right...");
			}
			
			// turn right
			else if (turnRightBackBool)
				transform.eulerAngles = new Vector3(0, 297, 0); //Debug.Log("turn right........");
			
			// turn left
			else if (turnLeftBool)
				transform.eulerAngles = new Vector3(0, 117, 0); //Debug.Log("turn left.........");
			
			// turn back
			else
			{
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
			}
		}
		
		// Back
		else if (transform.eulerAngles.y > 295 && transform.eulerAngles.y < 299)
		{
			type = 3;
			//Debug.Log("03 Right... Back Left...");
			
			Vector3 lSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f));
			Vector3 leftSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide, Color.green);
			
			// check Right Back waypoint available...
			Vector3 rBSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f));
			Vector3 rightBackSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, rightBackSide, Color.green);
			
			// check left waypoint hit
			if (Physics.Raycast(transform.position, lSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnLeftBool = true;
			}
			else 
				turnLeftBool = false;
			
			if (Physics.Raycast(transform.position, rBSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnRightBackBool = true;
			}
			else
				turnRightBackBool = false;
			
			// random select left right
			if (turnLeftBool && turnRightBackBool)
			{
				//speed = 0;
				Debug.Log("111111....");
				int randomVal = Random.Range(1, 15);
				Debug.Log("type :: " + randomVal);
				
				if (randomVal % 2 == 0)
					transform.eulerAngles = new Vector3(0, 242, 0); //Debug.Log("move left...");
				else
					transform.eulerAngles = new Vector3(0, 62, 0); //Debug.Log("move right...");
			}
			
			// turn right
			else if (turnRightBackBool)
			{
				//speed = 0;
				Debug.Log("222222...");
				transform.eulerAngles = new Vector3(0, 62, 0); //Debug.Log("turn right........");
			}
			
			// turn left
			else if (turnLeftBool)
			{
				//speed = 0;
				Debug.Log("3333....");
				transform.eulerAngles = new Vector3(0, 242, 0); //Debug.Log("turn left.........");
			}
			
			// turn back
			else
			{
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
			}
		}
		
		// Left
		else if (transform.eulerAngles.y > 60 && transform.eulerAngles.y < 64)
		{
			type = 4;
			//Debug.Log("04 Back Left... Right...");
			
			Vector3 lSide = transform.TransformDirection(new Vector3(-0.6f, 0, -0.4f));
			Vector3 leftSide = transform.TransformDirection(new Vector3(-0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide, Color.green);
			
			// check Right Back waypoint available...
			Vector3 rBSide = transform.TransformDirection(new Vector3(0.6f, 0, 0.4f));
			Vector3 rightBackSide = transform.TransformDirection(new Vector3(0.6f, 0, 0.4f)) * length;
			Debug.DrawRay(transform.position, rightBackSide, Color.green);
			
			// check left waypoint hit
			if (Physics.Raycast(transform.position, lSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnLeftBool = true;
			}
			else 
				turnLeftBool = false;
			
			if (Physics.Raycast(transform.position, rBSide, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
					turnRightBackBool = true;
			}
			else
				turnRightBackBool = false;
			
			// random select left right
			if (turnLeftBool && turnRightBackBool)
			{
				int randomVal = Random.Range(1, 16);
				
				if (randomVal % 2 == 0)
					transform.eulerAngles = new Vector3(0, 297, 0); //Debug.Log("move left...");
				else
					transform.eulerAngles = new Vector3(0, 117, 0); //Debug.Log("move right...");
			}
			
			// turn right
			else if (turnRightBackBool)
				transform.eulerAngles = new Vector3(0, 117, 0); //Debug.Log("turn right........");
			
			// turn left
			else if (turnLeftBool)
				transform.eulerAngles = new Vector3(0, 297, 0); //Debug.Log("turn left.........");
			
			// turn back
			else
			{
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
			}
		}
	}
	
	void h_WalkAnimation()
	{
		// forward animation
		if (transform.eulerAngles.y > 115 && transform.eulerAngles.y < 120)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = true;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// left animation
		else if (transform.eulerAngles.y > 240 && transform.eulerAngles.y < 244)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = true;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// back animation
		else if (transform.eulerAngles.y > 295 && transform.eulerAngles.y < 299)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = true;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// right animation
		else if (transform.eulerAngles.y > 60 && transform.eulerAngles.y < 64)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = true;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	void PlayHWcharSound()
	{
		if(!scr_audioController.audio_halflingChar_touch.isPlaying)
		{
			scr_audioController.audio_halflingChar_touch.Play();
			scr_audioController.audio_halflingChar_touch.transform.position = transform.position;
			scr_audioController.audio_halflingChar_touch.minDistance = 1;
			scr_audioController.audio_halflingChar_touch.maxDistance = 30;
		}
	}
}
