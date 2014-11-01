using UnityEngine;
using System.Collections;

public class DHoundAnimation : MonoBehaviour 
{
	public GameObject dHoundA;
	public GameObject dHoundB;
	public GameObject dHoundRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "DHound")
		{
			GameObject eTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			dHoundA = eTG.transform.FindChild("dHoundPosA").gameObject;
			dHoundB = eTG.transform.FindChild("dHoundPosB").gameObject;
			dHoundRef = eTG.transform.FindChild("dHoundRef").gameObject;
		}
		
		//dHoundRef.transform.position = new Vector3(dHoundA.transform.position.x, dHoundRef.transform.position.y, dHoundA.transform.position.z);
		dHoundRef.transform.localPosition = new Vector3(0, dHoundRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(dHoundRef.transform.position, dHoundB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			dHoundRef.transform.LookAt(dHoundB.transform.position);
			dHoundRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
		//	Debug.Log("B---------A");
			if (Vector3.Distance(dHoundRef.transform.position, dHoundA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			dHoundRef.transform.LookAt(dHoundA.transform.position);
			dHoundRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(dHoundRef.transform.position.x, transform.position.y, dHoundRef.transform.position.z);
	}
}
