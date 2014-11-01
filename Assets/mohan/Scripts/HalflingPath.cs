using UnityEngine;
using System.Collections;

public class HalflingPath : MonoBehaviour 
{
	public GameObject HWCharacterBackAction01;
	public GameObject HWCharacterBackIdle;
	public GameObject HWCharacterBackWalk;
	public GameObject HWCharacterFrontAction01;
	public GameObject HWCharacterFrontIdle;
	public GameObject HWCharacterFrontWalk;
	public GameObject HWCharacterLeftWalk;
	public GameObject HWCharacterRightWalk;
	
	public GameObject HWCharacter;
	
	public float duration = 10;
	public float speed = 2.5f;

	public GameObject[] WayPoints;
	private GameObject TargetTile;
	
	private RaycastHit hit;
	
	
	void Start()
	{
		
	}
	
/*	void DeleteWaypoint(GameObject waypoint)
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
	}*/
		
	/*GameObject FindWaypoint()
	{
	    if (WayPoints.Length == 0)
		{ 
	        WayPoints = GameObject.FindGameObjectsWithTag("HWwaypoint");
			
		//	xx=HWCharacter.transform.position.x;
		//	zz=HWCharacter.transform.position.z;
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
		
		xx=HWCharacter.transform.position.x;
		zz=HWCharacter.transform.position.z;
	    DeleteWaypoint(closest);
	    return closest;
	}*/
	
	void Update()
	{
		
	}
}