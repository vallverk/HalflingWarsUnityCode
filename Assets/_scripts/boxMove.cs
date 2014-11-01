using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]

public class boxMove : MonoBehaviour 
{
	public float speed = 3f, length = 5f;
	
	public float f_Direction = 117f, b_Direction = 297f, l_Direction = 62f, r_Direction = 242f;
	
	RaycastHit hit, rHit, lHit;
	
	private GameObject curObj, prevObj;
	
	private string  Left = "Left", Right = "Right", Front = "Front", Back = "Back", LeftBack = "LeftBack", RightBack = "RightBack";
	public  string status;
	
	public bool moveBool = false;
	private int type = 0;
	
	private bool turnLeftBool = false, turnRightBool = false, turnLeftBackBool = false, turnRightBackBool = false, turnBackBool = false;
	
	//public GameObject h_BackIdle, h_FrontIdle, h_BackWalk, h_FrontWalk, h_LeftWalk, h_RightWalk, shadow;
	//public GameObject h_Animation;
	
	private GameObject dirtPathObj;
	//public AudioController scr_audioController;
	
	private RaycastHit charHit;
	public Camera camera;
	
	public bool runBool;
	public static bool checkBool;
	
	private GameObject fObj, lObj, rObj, referenceObj;
	
	private List<GameObject> objList = new List<GameObject>();
	
	public int index = 0, moveCount = 0;
	
	public string statusMove;
	
	// Use this for initialization
	void Start () 
	{
		status = "Front";
		transform.position = new Vector3(-64.24f, 0.1f, 1.6f);
		
//		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		
		dirtPathObj = GameObject.Find("HC_D_DirtPath_GO(Clone)") as GameObject;
/*		if (dirtPathObj != null)
		{
			status = "Left";
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = true;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}*/
		
		moveBool = true;
		checkBool = true;
		
	}
	
	// Update is called once per frame
	/*void Update () 
	{
		if (checkBool)
		{
			index = 0;
			// Front Ray Cast
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			Vector3 forward = transform.TransformDirection(Vector3.forward) * length;
			Debug.DrawRay(transform.position, forward, Color.green);
			
			// Left
			Vector3 lSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f));
			Vector3 leftSide = transform.TransformDirection(new Vector3(-0.6f, 0, 0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide, Color.red);
			
			// Right
			Vector3 lSide1 = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f));
			Vector3 leftSide1 = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, leftSide1, Color.green);
		
			if (Physics.Raycast(transform.position, fwd, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
				{
					statusMove = "Front";
					Debug.Log("f f f f f f f f f f f f f f f f f f f f f");
					fObj = hit.collider.gameObject;
					index++;
				}
			}
			
			if (Physics.Raycast(transform.position, lSide, out lHit, length))
			{
				if (lHit.collider.gameObject.name == "waypoint1")
				{
					statusMove = "Left";
					Debug.Log("l l l l l l l l l l l ll l l l l l");
					lObj = lHit.collider.gameObject;
					index++;
				}
			}
			
			if (Physics.Raycast(transform.position, leftSide1, out rHit, length))
			{
				if (rHit.collider.gameObject.name == "waypoint1")
				{
					statusMove = "Right";
					Debug.Log("r r r r r r r r r r r r r r r r r r");
					rObj = rHit.collider.gameObject;
					index++;
				}
			}
			moveCount = Random.Range(1, index+1);
			
			checkBool = false;
			
			if (fObj != null)
			{
				Debug.Log("front object :: " + fObj.name);
				objList.Add(fObj);
			}
			
			if (rObj != null)
			{
				Debug.Log("right object :: " + rObj.name);
				objList.Add(rObj);
			}
			
			if (lObj != null)
			{
				Debug.Log("left object :: " + lObj.name);
				objList.Add(lObj);
			}
			
			referenceObj = objList[moveCount-1];
			Debug.Log("*******************************  " + "   " + referenceObj.transform.position + "   " + objList.Count);
			
			if (statusMove == "Front")
				transform.eulerAngles = new Vector3 (0, 117, 0);
			else if (statusMove == "Left")
				transform.eulerAngles = new Vector3 (0, 62, 0);
			else if (statusMove == "Right")
				transform.eulerAngles = new Vector3 (0, 242, 0);
			
		}
		
		if (runBool)
		{
			if (moveBool)
			{
				if (Vector3.Distance(transform.position, referenceObj.transform.position) > 0.1f)
					transform.Translate(Vector3.forward * speed * Time.deltaTime);
				else
				{
					prevObj = referenceObj;
					prevObj.active = false;
					checkBool = true;
					moveBool = false;
					objList.Clear();
				}
			}
		}
		
		
		//chk collision with char
		/*Ray characterRay =  camera.ScreenPointToRay(Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(characterRay, out charHit))
				{
					if (charHit.collider.gameObject.name =="h_Animation")
					{
						//Debug.Log("Hit ......Hit ");
//					    PlayHWcharSound();
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
			
			// start
			Vector3 rBSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f));
			Vector3 rightBackSide = transform.TransformDirection(new Vector3(0.6f, 0, -0.4f)) * length;
			Debug.DrawRay(transform.position, rightBackSide, Color.green);
			
			if (Physics.Raycast(transform.position, rBSide, out rBHit, length))
			{
				if (rBHit.collider.gameObject.name == "waypoint1")
				{
					Debug.Log("rBHit :: " + rBHit.collider.gameObject.name);
					moveBool = false;
				}
			}
			else 
				moveBool = true;
			
			// end
			
			//moveBool = true;
			
			if (Physics.Raycast(transform.position, fwd, out hit, length))
			{
				if (hit.collider.gameObject.name == "waypoint1")
				{
					if (curObj != null)
						prevObj = curObj;
				
					curObj = hit.collider.gameObject;
					moveBool = true;
				}
				else
					Debug.Log("no animation.......");
			}
			else
			{
				Debug.Log("dont play animation......");
				//moveBool = false;
				if (curObj != null)
					transform.position = curObj.transform.position;
				FindDirection();
//				h_WalkAnimation();
			}
		}
		
		if (moveBool)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal)), transform.position.z);
//			h_WalkAnimation();
		}
//		h_Animation.transform.position = transform.position;*/
	//}
	
	/*void FindDirection()
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
	}*/
	
/*	void h_WalkAnimation()
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
	}*/
	
	/*void PlayHWcharSound()
	{
		if(!scr_audioController.audio_halflingChar_touch.isPlaying)
		{
			scr_audioController.audio_halflingChar_touch.Play();
			scr_audioController.audio_halflingChar_touch.transform.position = transform.position;
			scr_audioController.audio_halflingChar_touch.minDistance = 1;
			scr_audioController.audio_halflingChar_touch.maxDistance = 30;
		}
	}*/
}
