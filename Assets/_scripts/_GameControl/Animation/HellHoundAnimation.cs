using UnityEngine;
using System.Collections;

public class HellHoundAnimation : MonoBehaviour 
{
	public GameObject hellHoundA;
	public GameObject hellHoundB;
	public GameObject hellHoundRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "HellHound")
		{
			GameObject eTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			hellHoundA = eTG.transform.FindChild("hellHoundPosA").gameObject;
			hellHoundB = eTG.transform.FindChild("hellHoundPosB").gameObject;
			hellHoundRef = eTG.transform.FindChild("hellHoundRef").gameObject;
		}
		
		//hellHoundRef.transform.position = new Vector3(hellHoundA.transform.position.x, hellHoundRef.transform.position.y, hellHoundA.transform.position.z);
		hellHoundRef.transform.localPosition = new Vector3(0, hellHoundRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(hellHoundRef.transform.position, hellHoundB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			hellHoundRef.transform.LookAt(hellHoundB.transform.position);
			hellHoundRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
		//	Debug.Log("B---------A");
			if (Vector3.Distance(hellHoundRef.transform.position, hellHoundA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			hellHoundRef.transform.LookAt(hellHoundA.transform.position);
			hellHoundRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(hellHoundRef.transform.position.x, transform.position.y, hellHoundRef.transform.position.z);
	}
}
