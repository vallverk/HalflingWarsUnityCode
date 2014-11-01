using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour 
{
	private float panSpeed = 0.15f;
	public float limitLeft = 0f;
	public float limitRight = -16f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (Input.GetMouseButton(0))
		{
			transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * panSpeed);
			
			if (transform.position.x < limitLeft)
				transform.position = new Vector3(limitLeft , transform.position.y, transform.position.z);
			if (transform.position.x > limitRight)
				transform.position = new Vector3(limitRight, transform.position.y, transform.position.z);
		}
		
		if (Input.touchCount == 1)
		{
			Touch touch = Input.touches[0];
			if (touch.phase == TouchPhase.Moved)
			{	
				transform.Translate(Vector3.right * Input.GetTouch(0).deltaPosition.x * panSpeed);
		
				if (transform.position.x < limitLeft)
					transform.position = new Vector3(limitLeft , transform.position.y, transform.position.z);
				if (transform.position.x > limitRight)
					transform.position = new Vector3(limitRight, transform.position.y, transform.position.z);
			}
		}
	}
}
