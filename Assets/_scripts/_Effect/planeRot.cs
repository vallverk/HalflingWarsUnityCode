using UnityEngine;
using System.Collections;

public class planeRot : MonoBehaviour 
{
	public Transform leftRot;
	public Transform rightRot;
	public Transform midRot;
	public Transform scrollObj;
	
	private float speed = 10f;
	
	public float min = -1;
	public float max = 1;
	
	private float scrollVal = 0;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("plane rotate...");
		scrollVal = scrollObj.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (transform.position.x < scrollVal - min)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.9f, 0.9f, 1), Time.deltaTime * speed);
			//transform.rotation = Quaternion.Slerp(transform.rotation, leftRot.rotation, Time.deltaTime * speed);
		}
		
		if (transform.position.x > scrollVal + max)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.9f, 0.9f, 1), Time.deltaTime * speed);
			//transform.rotation = Quaternion.Slerp(transform.rotation, rightRot.rotation, Time.deltaTime * speed);
		}
		
		if (transform.position.x > scrollVal - min && transform.position.x < scrollVal + max)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.1f, 1.1f, 1), Time.deltaTime * speed);
			//transform.rotation = Quaternion.Slerp(transform.rotation, midRot.rotation, Time.deltaTime * speed);
		}
	}
}
