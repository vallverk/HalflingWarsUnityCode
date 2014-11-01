using UnityEngine;
using System.Collections;

public class destroyParticle : MonoBehaviour 
{
	private int oldTime, curTime;
	public int endTime = 2;

	// Use this for initialization
	void Start () 
	{
		oldTime = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curTime = (int)Time.time - oldTime;

		if(curTime > endTime)
		{
			Destroy(this.gameObject);
		}
	}
}
