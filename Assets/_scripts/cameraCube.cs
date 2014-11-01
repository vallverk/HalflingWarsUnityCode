using UnityEngine;
using System.Collections;

public class cameraCube : MonoBehaviour 
{
	public Transform cube;
	public Camera cam;
	
	private float cal = 0, calY;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//cube.position = new Vector3(cam.transform.position.x, -0.1f, cam.transform.position.z);
		
		//cube.localScale = new Vector3(cam.orthographicSize * 2.3f, cam.orthographicSize * 2, cube.localScale.z);
		
		//Debug.Log("---> " + cube.position.x + " --- " + cam.orthographicSize);
		
		cal = (1.65f + (((cam.orthographicSize - 15)/10) + ((cam.orthographicSize - 15)/100)))/cam.orthographicSize;
///***		Debug.Log("cal :: " + cal + " -- " + (-148.39f + (cal * ((cam.orthographicSize - 15) * 10))));
		
		float newY = (22.5f - (cam.orthographicSize - 15));
		
		float newX = (-148.39f + (cal * ((cam.orthographicSize - 15) * 10)));
		
		//cam.transform.position = new Vector3(newX, cam.transform.position.y, newY);
		
		cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, newX, (newX * -1)), cam.transform.position.y,
											Mathf.Clamp(cam.transform.position.z, (newY * -1), newY));
	}
}
