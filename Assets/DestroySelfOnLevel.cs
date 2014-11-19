using UnityEngine;
using System.Collections;

public class DestroySelfOnLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (GameManager.taskCount == 8 || GameManager.gameLevel > 1)
	    {
            Destroy(gameObject);
	    }
    }
}
