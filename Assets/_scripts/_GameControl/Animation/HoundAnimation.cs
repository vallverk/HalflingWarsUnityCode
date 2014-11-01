using UnityEngine;
using System.Collections;

public class HoundAnimation : MonoBehaviour 
{
	public GameObject houndA;
	public GameObject houndB;
	public GameObject houndRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Hound")
		{
			GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			houndA = eTG.transform.FindChild("houndPosA").gameObject;
			houndB = eTG.transform.FindChild("houndPosB").gameObject;
			houndRef = eTG.transform.FindChild("houndRef").gameObject;
		}
		
		//houndRef.transform.position = new Vector3(houndA.transform.position.x, houndRef.transform.position.y, houndA.transform.position.z);
		houndRef.transform.localPosition = new Vector3(0, houndRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(houndRef.transform.position, houndB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			houndRef.transform.LookAt(houndB.transform.position);
			houndRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(houndRef.transform.position, houndA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			houndRef.transform.LookAt(houndA.transform.position);
			houndRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(houndRef.transform.position.x, transform.position.y, houndRef.transform.position.z);
	}
}
