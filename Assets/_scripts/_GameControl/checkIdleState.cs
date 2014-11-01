using UnityEngine;
using System.Collections;

public class checkIdleState : MonoBehaviour 
{

	private int curTime = 0;
	private float oldTime = 0;
	
	// Use this for initialization
	void Start () 
	{
		oldTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curTime = (int)(Time.time - oldTime);
//		Debug.Log(curTime);
		if (Input.GetMouseButtonDown(0))
		{
			oldTime = Time.time;
		}
	}
}
