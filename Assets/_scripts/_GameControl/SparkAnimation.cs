using UnityEngine;
using System.Collections;

public class SparkAnimation : MonoBehaviour 
{
	public Transform spark1, spark2;
	
	// Use this for initialization
	void Start () 
	{
		spark1 = transform.FindChild("Spark1") as Transform;
		spark2 = transform.FindChild("Spark2") as Transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (spark1.gameObject.GetComponent<MeshRenderer>().enabled == false)
			spark2.gameObject.GetComponent<MeshRenderer>().enabled = true;
	}
}
