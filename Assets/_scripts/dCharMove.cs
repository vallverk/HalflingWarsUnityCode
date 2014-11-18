using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dCharMove : MonoBehaviour 
{
	public List<GameObject> waypoints = new List<GameObject>();
	
	private List<GameObject> multipleWaypoints = new List<GameObject>();
	
	public List<GameObject> usedWaypoints = new List<GameObject>();
	
	public static bool addWaypointBool = false;
	
	public float speed = 1f;
	
	public bool moveBool = false;
	
	private GameObject curWaypoint, prevWaypoint, nearestWaypoint;
	
	public static bool findWaypointBool = false; 
	public bool checkIndexBool = true;
	
	public int index = 0;
	
	public static GameObject firstWaypoint;
	
	public GameObject d_BackIdle, d_FrontIdle, d_BackWalk, d_FrontWalk, d_LeftWalk, d_RightWalk, shadow;
	public GameObject dAnimation;
	
	public bool findPathBool = false;
	
	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(64.24f, 0.1f, 1.6f);
		dAnimation.transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal))+0.00001f, transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (addWaypointBool)
		{
			GameObject[] objs = GameObject.FindGameObjectsWithTag("DWWaypoint");// as GameObject;
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
//			Debug.Log("^ ^ ^ ^ ^ ^ ^^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
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
			if (curWaypoint != null)
			{
				if (Vector3.Distance(transform.position, curWaypoint.transform.position) > 5f)
				{
					moveBool = false;
					findWaypointBool = true;
				}
				
				if (Vector3.Distance(transform.position, curWaypoint.transform.position) > 0.05f)
				{
					transform.Translate(Vector3.forward * speed * Time.deltaTime);
					dAnimation.transform.position = new Vector3(transform.position.x, (0.0306f -(transform.position.z / GameManager.layerDivVal))+0.0001f, transform.position.z);
				}
				else
				{
					findWaypointBool = true;
					moveBool = false;
				}
			}
			else
				findWaypointBool = true;
		}
		else
			findWaypointBool = true;
	}
	
	void FindWaypoint()
	{
		foreach (GameObject waypoint in waypoints)
		{
//			Debug.Log("distance ----> " + Vector3.Distance(transform.position, waypoint.transform.position));
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
				SetCharacterDirection();
				index = 0;
			}
			else
			{
				waypoints.Clear();
				usedWaypoints.Clear();
				addWaypointBool = true;
			}
		}
	}
	
	void SetCharacterDirection()
	{
		// Front
		if (transform.eulerAngles.y > 115 && transform.eulerAngles.y < 120)
		{
			d_FrontWalk.GetComponent<MeshRenderer>().enabled = true;
			d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Left
		else if (transform.eulerAngles.y > 238 && transform.eulerAngles.y < 246)
		{
			d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			d_LeftWalk.GetComponent<MeshRenderer>().enabled = true;
			d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Back
		else if (transform.eulerAngles.y > 293 && transform.eulerAngles.y < 301)
		{
			d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			d_BackWalk.GetComponent<MeshRenderer>().enabled = true;
			d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
			d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		// Right
		else if (transform.eulerAngles.y > 58 && transform.eulerAngles.y < 66)
		{
			d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
			d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
			d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
			d_RightWalk.GetComponent<MeshRenderer>().enabled = true;
			d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
		}
		
		
	}
}
