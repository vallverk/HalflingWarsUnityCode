using UnityEngine;
using System.Collections;

public class CusithAnimation : MonoBehaviour 
{
	public GameObject cusithA;
	public GameObject cusithB;
	public GameObject cusithRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Cusith")
		{
			GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			cusithA = eTG.transform.FindChild("cusithPosA").gameObject;
			cusithB = eTG.transform.FindChild("cusithPosB").gameObject;
			cusithRef = eTG.transform.FindChild("cusithRef").gameObject;
		}
		
		//cusithRef.transform.position = new Vector3(cusithA.transform.position.x, cusithRef.transform.position.y, cusithA.transform.position.z);
		cusithRef.transform.localPosition = new Vector3(0, cusithRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(cusithRef.transform.position, cusithB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			cusithRef.transform.LookAt(cusithB.transform.position);
			cusithRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(cusithRef.transform.position, cusithA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			cusithRef.transform.LookAt(cusithA.transform.position);
			cusithRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(cusithRef.transform.position.x, transform.position.y, cusithRef.transform.position.z);
	}
}
