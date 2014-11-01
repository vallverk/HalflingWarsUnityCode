using UnityEngine;
using System.Collections;

public class BargAnimation : MonoBehaviour 
{
	public GameObject bargA;
	public GameObject bargB;
	public GameObject bargRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Barg")
		{
			GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			bargA = eTG.transform.FindChild("bargPosA").gameObject;
			bargB = eTG.transform.FindChild("bargPosB").gameObject;
			bargRef = eTG.transform.FindChild("bargRef").gameObject;
		}
		
		//bargRef.transform.position = new Vector3(bargA.transform.position.x, bargRef.transform.position.y, bargA.transform.position.z);
		bargRef.transform.localPosition = new Vector3(0, bargRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(bargRef.transform.position, bargB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			bargRef.transform.LookAt(bargB.transform.position);
			bargRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(bargRef.transform.position, bargA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			bargRef.transform.LookAt(bargA.transform.position);
			bargRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(bargRef.transform.position.x, transform.position.y, bargRef.transform.position.z);
	}
}
