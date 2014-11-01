using UnityEngine;
using System.Collections;

public class sparkGoldTimer : MonoBehaviour 
{

	private int oldTime, curTime;
	private int endTime = 1;
	
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
			GameObject goldEff = Instantiate(Resources.Load("HW_rewardGold"), new Vector3(-33.67f, 20, 108.48f), Quaternion.Euler(350,0,0)) as GameObject;
			GameObject sparkEff = Instantiate(Resources.Load("HW_rewardSparks"), new Vector3(-45.47f, 20, 108.48f), Quaternion.Euler(350,0,0)) as GameObject;
			Destroy(this.gameObject);
		}
	}
}
