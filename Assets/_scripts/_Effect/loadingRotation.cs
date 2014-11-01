using UnityEngine;
using System.Collections;

public class loadingRotation : MonoBehaviour 
{
	private  float yRotation = 0F;
	private float speed = 1.5f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		yRotation -= speed;//Input.GetAxis("Horizontal");
        transform.localEulerAngles = new Vector3(yRotation, 270, 90);
	}
}
