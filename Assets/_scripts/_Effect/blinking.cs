using UnityEngine;
using System.Collections;

public class blinking : MonoBehaviour 
{
	private float curTime, oldTime, blinkTime = 1;
	// Use this for initialization
	void Start () 
	{
		oldTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curTime = Time.time - oldTime;

		if (curTime > blinkTime)
		{
			blinkTime = blinkTime + 0.3f;
			if (transform.renderer.enabled == false)
				transform.renderer.enabled = true;
			else
				transform.renderer.enabled = false;
		}
	}
}
