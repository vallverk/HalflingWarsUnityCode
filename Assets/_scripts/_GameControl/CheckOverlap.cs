using UnityEngine;
using System.Collections;

public class CheckOverlap : MonoBehaviour 
{
	//public Material redMat;
	//public Material greenMat;
	
	public Transform redPatch;
	public Transform greenPatch;
	
	public bool objectPlacedBool = false;
	
	// Use this for initialization
	void Start () 
	{
		redPatch = transform.FindChild("redPatch");
		greenPatch = transform.FindChild("greenPatch");
		
		
		redPatch.gameObject.active = false;
		greenPatch.gameObject.active = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerStay(Collider other)
	{
//		Debug.Log(other.collider.gameObject.name);
		if (objectPlacedBool == false)
		{
			if (other.collider.gameObject.tag == "movableObj" || other.collider.gameObject.tag == "editableObj" || other.collider.gameObject.tag == "nonMovableObj")
			{
				redPatch.gameObject.active = true;
				greenPatch.gameObject.active = false;
				grid.readyToPlace = false;
				GameManager.placeObjectBool = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Exit...");
		
		if (objectPlacedBool == false)
		{
			redPatch.gameObject.active = false;
			greenPatch.gameObject.active = true;
			grid.readyToPlace = true;
			GameManager.placeObjectBool = true;
		}	
	}
}