using UnityEngine;
using System.Collections;

public class buttonPulse : MonoBehaviour 
{
	
	private Vector3 newScale;
	private Vector3 oldScale;
	
	private float speed;
	public float minSpeed = 3f;
	public float maxSpeed = 8f;
	
	public float minVal = 0.05f;
	public float maxVal = 0.5f;
	
	public bool scaleAnim = false;
		
	// Use this for initialization
	void Start () 
	{
		//Debug.Log ("button pulse...");
		oldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("button pulse : " + transform.gameObject.name);
		if (scaleAnim)
		{
			if (transform.localScale.x < oldScale.x + minVal)
			{
				speed = minSpeed;
				newScale = new Vector3(oldScale.x + maxVal, oldScale.y + maxVal, oldScale.z + maxVal);
			}
		
			if (transform.localScale.x > oldScale.x + maxVal - minVal)
			{
				speed = maxSpeed;
				newScale = oldScale;
			}
			
			transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime * speed);
			
			
		}		
		else
		{
			transform.localScale = oldScale;
		}
	}
}
