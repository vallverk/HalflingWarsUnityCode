using UnityEngine;
using System.Collections;

public class DryadAnimation : MonoBehaviour 
{
	public GameObject dryadA;
	public GameObject dryadB;
	public GameObject dryadRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Dryad")
		{
			GameObject eTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			dryadA = eTG.transform.FindChild("dryadPosA").gameObject;
			dryadB = eTG.transform.FindChild("dryadPosB").gameObject;
			dryadRef = eTG.transform.FindChild("dryadRef").gameObject;
		}
		
		//dryadRef.transform.position = new Vector3(dryadA.transform.position.x, dryadRef.transform.position.y, dryadA.transform.position.z);
		dryadRef.transform.localPosition = new Vector3(0, dryadRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(dryadRef.transform.position, dryadB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			dryadRef.transform.LookAt(dryadB.transform.position);
			dryadRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(dryadRef.transform.position, dryadA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			dryadRef.transform.LookAt(dryadA.transform.position);
			dryadRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(dryadRef.transform.position.x, transform.position.y, dryadRef.transform.position.z);
	}
}
