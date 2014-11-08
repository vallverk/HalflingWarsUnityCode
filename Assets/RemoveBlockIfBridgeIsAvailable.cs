using UnityEngine;
using System.Collections;

public class RemoveBlockIfBridgeIsAvailable : MonoBehaviour 
{	
	void Start () 
	{
	
	}

	void Update () 
	{
		Debug.Log("u " + GameManager.unlockDarklingBool);
		Debug.Log("READY " + GameManager.readyToUnlockDarklingBool);

		if((GameManager.unlockDarklingBool || GameManager.readyToUnlockDarklingBool) && !GameManager.bridgeBuildBool)
		{
			Debug.Log("HELLYEAH");
			gameObject.SetActive(false);
		}
	}
}
