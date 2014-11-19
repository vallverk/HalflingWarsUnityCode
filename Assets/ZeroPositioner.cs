using UnityEngine;
using System.Collections;

public class ZeroPositioner : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
	    var pos = transform.position;
	    pos.y = 0;
	    transform.position = pos;
	}
}
