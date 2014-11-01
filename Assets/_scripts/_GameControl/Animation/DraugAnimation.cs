using UnityEngine;
using System.Collections;

public class DraugAnimation : MonoBehaviour 
{
	public GameObject draugA;
	public GameObject draugB;
	public GameObject draugRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Draug")
		{
			GameObject eTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			draugA = eTG.transform.FindChild("draugPosA").gameObject;
			draugB = eTG.transform.FindChild("draugPosB").gameObject;
			draugRef = eTG.transform.FindChild("draugRef").gameObject;
		}
		
		//draugRef.transform.position = new Vector3(draugA.transform.position.x, draugRef.transform.position.y, draugA.transform.position.z);
		draugRef.transform.localPosition = new Vector3(0, draugRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(draugRef.transform.position, draugB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			draugRef.transform.LookAt(draugB.transform.position);
			draugRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(draugRef.transform.position, draugA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			draugRef.transform.LookAt(draugA.transform.position);
			draugRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(draugRef.transform.position.x, transform.position.y, draugRef.transform.position.z);
	}
}
