using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
		Destroy(gameObject,0.9f);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x+Time.deltaTime*17,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
	
	}
}
