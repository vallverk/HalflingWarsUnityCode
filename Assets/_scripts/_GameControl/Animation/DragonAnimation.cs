using UnityEngine;
using System.Collections;

public class DragonAnimation : MonoBehaviour 
{
	public GameObject dragonA;
	public GameObject dragonB;
	public GameObject dragonRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Dragon")
		{
			GameObject eTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			dragonA = eTG.transform.FindChild("dragonPosA").gameObject;
			dragonB = eTG.transform.FindChild("dragonPosB").gameObject;
			dragonRef = eTG.transform.FindChild("dragonRef").gameObject;
		}
		
		//dragonRef.transform.position = new Vector3(dragonA.transform.position.x, dragonRef.transform.position.y, dragonA.transform.position.z);
		dragonRef.transform.localPosition = new Vector3(0, dragonRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(dragonRef.transform.position, dragonB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			dragonRef.transform.LookAt(dragonB.transform.position);
			dragonRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(dragonRef.transform.position, dragonA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			dragonRef.transform.LookAt(dragonA.transform.position);
			dragonRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(dragonRef.transform.position.x, transform.position.y, dragonRef.transform.position.z);
	}
}
