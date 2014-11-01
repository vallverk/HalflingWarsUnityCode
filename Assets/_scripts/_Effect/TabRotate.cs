using UnityEngine;
using System.Collections;

public class TabRotate : MonoBehaviour 
{
	private  float yRotation = 0F;
	private float speed = 0.3f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		yRotation += speed;//Input.GetAxis("Horizontal");
        transform.localEulerAngles = new Vector3(90, yRotation, 0);
	}
}
