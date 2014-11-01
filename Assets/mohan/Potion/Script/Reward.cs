using UnityEngine;
using System.Collections;

public class Reward : MonoBehaviour 
{
	public GameObject nextReward;
	Vector3 initPos;

	void OnEnable() 
	{
		initPos = transform.position;
		transform.position = new Vector3(initPos.x,initPos.y,0);
	}
	
	public void OnDisable()
	{
		transform.position = initPos;
	}
	
	void Update () 
	{
		transform.Translate(Vector3.up * 2 * Time.deltaTime);
		if(transform.position.y > 5) 
		{
			gameObject.active = false;
			if(nextReward)
			nextReward.active = true;
		}
	}
}
