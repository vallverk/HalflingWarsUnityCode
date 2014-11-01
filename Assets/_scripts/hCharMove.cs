	using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hCharMove : MonoBehaviour 
{
	public List<GameObject> waypoints = new List<GameObject>();
	
	private List<GameObject> multipleWaypoints = new List<GameObject>();
	
	public List<GameObject> usedWaypoints = new List<GameObject>();
	
	public static bool addWaypointBool = false;
	
	public float speed = 3f;
	
	public bool moveBool = false;
	
	private GameObject curWaypoint, prevWaypoint, nearestWaypoint;
	
	public static bool findWaypointBool = false; 
	public bool checkIndexBool = true;
	
	public int index = 0;
	
	public static GameObject firstWaypoint;
	
	public GameObject h_BackIdle, h_FrontIdle, h_BackWalk, h_FrontWalk, h_LeftWalk, h_RightWalk, shadow;
	public GameObject hAnimation;
	
	public bool findPathBool = false;
	
	// Use this for initialization
	void Start () 
	{
		moveBool = true;
		transform.position = new Vector3(-64.24f, 0.1f, 1.6f);
		hAnimation.transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal)+0.0001f), transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (addWaypointBool)
		{
			GameObject[] objs = GameObject.FindGameObjectsWithTag("HWwaypoint");// as GameObject;
			foreach (GameObject obj in objs)
			{
				waypoints.Add(obj);
			}
			addWaypointBool = false;
		}
		
		if (findPathBool)
		{
			findPathBool = false;
			findWaypointBool = true;
		}
		
		if (waypoints.Count == 0)
		{
			//Debug.Log("^ ^ ^ ^ ^ ^ ^^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
			moveBool = false;
			findWaypointBool = true;
		}
		else if (waypoints.Count > 0 && !moveBool)
			moveBool = true;
		
		if (findWaypointBool)
		{
			
			waypoints.Remove(nearestWaypoint);
			FindWaypoint();
			findWaypointBool = false;
		}
		
		if (moveBool)
		{
//			Debug.Log("distance -> " + Vector3.Distance(transform.position, curWaypoint.transform.position) + " - " + curWaypoint.transform.position);
			if (curWaypoint != null)
			{
				if (Vector3.Distance(transform.position, curWaypoint.transform.position) > 2.5f)
				{
					//moveBool = false;
					//findWaypointBool = true;
					
					waypoints.Remove(nearestWaypoint);
					FindWaypoint();
					//findWaypointBool = false;
				}
			
			
			
			
				if (Vector3.Distance(transform.position, curWaypoint.transform.position) > 0.05f)
				{
					//curWaypoint.GetComponent<MeshRenderer>().enabled = true;
					transform.Translate(Vector3.forward * speed * Time.deltaTime);
					transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
					hAnimation.transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal))+0.00001f, transform.position.z);
				}
				else
				{
					findWaypointBool = true;
					//curWaypoint.GetComponent<MeshRenderer>().enabled = false;
				}
			}
			else
				findWaypointBool = true;
		}
	}
	
	void FindWaypoint()
	{
		foreach (GameObject waypoint in waypoints)
		{
			if ((Vector3.Distance(transform.position, waypoint.transform.position) <= 1.75f) &&
				(Vector3.Distance(transform.position, waypoint.transform.position) >= 1.5f))
			{
				multipleWaypoints.Add(waypoint);
			}
			
			if (Vector3.Distance(transform.position, waypoint.transform.position) < 0.5f)
				nearestWaypoint = waypoint;
		}
		
		if (multipleWaypoints.Count >= 1)
		{
			index = Random.Range(1, (multipleWaypoints.Count+1));
		}
		
		if (checkIndexBool)
		{
			if (index > 0)
			{
				curWaypoint = multipleWaypoints[index-1];
				waypoints.Remove(curWaypoint);
				multipleWaypoints.Clear();
				moveBool = true;
				transform.LookAt(curWaypoint.transform.position);
				//Debug.Log("cur waypoint -> " + curWaypoint.transform.position + " - " + curWaypoint.name);
				SetCharacterDirection();
				index = 0;
			}
			else
			{
				waypoints.Clear();
				usedWaypoints.Clear();
				//moveBool = false;
				addWaypointBool = true;
			}
		}
	}
	
	void SetCharacterDirection()
	{
		// Front
		if (transform.eulerAngles.y > 115 && transform.eulerAngles.y < 120)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = true;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Left
		else if (transform.eulerAngles.y > 238 && transform.eulerAngles.y < 246)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = true;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Back
		else if (transform.eulerAngles.y > 293 && transform.eulerAngles.y < 301)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = true;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Right
		else if (transform.eulerAngles.y > 58 && transform.eulerAngles.y < 66)
		{
			h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			h_RightWalk.GetComponent<MeshRenderer>().enabled = true;
			h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		
	}
}
