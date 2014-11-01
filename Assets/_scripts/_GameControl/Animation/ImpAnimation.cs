using UnityEngine;
using System.Collections;

public class ImpAnimation : MonoBehaviour 
{
	public GameObject impA;
	public GameObject impB;
	public GameObject impRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Imp")
		{
			GameObject eTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			impA = eTG.transform.FindChild("impPosA").gameObject;
			impB = eTG.transform.FindChild("impPosB").gameObject;
			impRef = eTG.transform.FindChild("impRef").gameObject;
		}
		
		//impRef.transform.position = new Vector3(impA.transform.position.x, impRef.transform.position.y, impA.transform.position.z);
		impRef.transform.localPosition = new Vector3(0, impRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(impRef.transform.position, impB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			impRef.transform.LookAt(impB.transform.position);
			impRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(impRef.transform.position, impA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			impRef.transform.LookAt(impA.transform.position);
			impRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		transform.position = new Vector3(impRef.transform.position.x, transform.position.y, impRef.transform.position.z);
	}
}
