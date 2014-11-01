using UnityEngine;
using System.Collections;

public class DarklingPath : MonoBehaviour 
{
	public GameObject DLCharacterBackAction01;
	public GameObject DLCharacterBackWalk;
	public GameObject DLCharacterFrontAction01;
	public GameObject DLCharacterFrontIdle;
	public GameObject DLCharacterFrontWalk;
	public GameObject DLCharacterLeftWalk;
	public GameObject DLCharacterRightWalk;
	
	public GameObject DLCharacter;
	
	public float duration = 10;
	public float speed = 2.5f;
	
	public GameObject[] WayPoints;
	private GameObject TargetTile;
	private guiControl gc;
	private RaycastHit hit;
	
	float xx;
	float zz;
	
	void Start()
	{

		xx=DLCharacter.transform.position.x;
		zz=DLCharacter.transform.position.z;
		gc = (guiControl)FindObjectOfType(typeof(guiControl));
	}
	
	void DeleteWaypoint(GameObject waypoint)
	{
		if(WayPoints.Length>0)
		{
	    GameObject[] temp = new GameObject[WayPoints.Length-1];
	    int i = 0;
	
		foreach (GameObject elem in WayPoints)
		{
	        if (elem != waypoint) temp[i++] = elem;
	    }
	    WayPoints = temp;
		}
	}
		
	GameObject FindWaypoint()
	{
	    if (WayPoints.Length == 0)
		{ 
	        WayPoints = GameObject.FindGameObjectsWithTag("DLwaypoint");
			//xx=DLCharacter.transform.position.x;
			//zz=DLCharacter.transform.position.z;
	    }
	    
		GameObject closest = null;
	    float distance = Mathf.Infinity;
	    Vector3 position = transform.position;
	    
		foreach (GameObject item in WayPoints) 
	    {
	        Vector3 diff = item.transform.position - position;
	        float curDistance = diff.sqrMagnitude;
	        if (curDistance < distance) 
	        {
	            closest = item;
	            distance = curDistance;
	        }
	    }
		
		xx=DLCharacter.transform.position.x;
		zz=DLCharacter.transform.position.z;
	    DeleteWaypoint(closest);
	    return closest;
	}
	
	void Update()
	{	
	    if (TargetTile && Vector3.Distance(transform.position, TargetTile.transform.position) > 0.75 && Vector3.Distance(transform.position, TargetTile.transform.position) < 2.6)
	    {
	        transform.position = Vector3.MoveTowards(transform.position, TargetTile.transform.position, Time.deltaTime * speed);
	    }
	    else 
		{
	        TargetTile = FindWaypoint();
	    }
		if(gc.DarklingCancleBool == true)
		{
			WayPoints = new GameObject[0];
	        //WayPoints = GameObject.FindGameObjectsWithTag("DLwaypoint");
			gc.DarklingCancleBool = false;
		}
		if(DLCharacter.transform.position.x > xx && DLCharacter.transform.position.z > zz)
		{
			DLCharacterFrontIdle.gameObject.active = false;
			DLCharacterBackWalk.gameObject.renderer.enabled = false;
			DLCharacterFrontWalk.gameObject.renderer.enabled = false;
			DLCharacterRightWalk.gameObject.renderer.enabled = true;
			DLCharacterLeftWalk.gameObject.renderer.enabled = false;
		}
		
		if(DLCharacter.transform.position.x > xx && DLCharacter.transform.position.z < zz)
		{
			DLCharacterFrontIdle.gameObject.active = false;
			DLCharacterBackWalk.gameObject.renderer.enabled = false;
			DLCharacterFrontWalk.gameObject.renderer.enabled = true;
			DLCharacterRightWalk.gameObject.renderer.enabled = false;
			DLCharacterLeftWalk.gameObject.renderer.enabled = false;
		}
		
		if(DLCharacter.transform.position.x < xx && DLCharacter.transform.position.z > zz)
		{
			DLCharacterFrontIdle.gameObject.active = false;
			DLCharacterBackWalk.gameObject.renderer.enabled = true;
			DLCharacterFrontWalk.gameObject.renderer.enabled = false;
			DLCharacterRightWalk.gameObject.renderer.enabled = false;
			DLCharacterLeftWalk.gameObject.renderer.enabled = false;
		}
		
		if(DLCharacter.transform.position.x < xx && DLCharacter.transform.position.z < zz)
		{
			DLCharacterFrontIdle.gameObject.active = false;
			DLCharacterBackWalk.gameObject.renderer.enabled = false;
			DLCharacterFrontWalk.gameObject.renderer.enabled = false;
			DLCharacterRightWalk.gameObject.renderer.enabled = false;
			DLCharacterLeftWalk.gameObject.renderer.enabled = true;
		}
	}
}