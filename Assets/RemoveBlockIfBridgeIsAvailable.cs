using UnityEngine;
using System.Collections;

public class RemoveBlockIfBridgeIsAvailable : MonoBehaviour 
{	
	void Start () 
	{
		//GameObject.Find();
	}

	void Update () 
	{
		if((GameManager.unlockDarklingBool || GameManager.readyToUnlockDarklingBool) && (!GameManager.bridgeBuildBool))
		{
			Debug.Log("Fake unlock");
			gameObject.SetActive(false);
		}
	}
}
