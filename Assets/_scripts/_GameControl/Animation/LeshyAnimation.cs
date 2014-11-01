using UnityEngine;
using System.Collections;

public class LeshyAnimation : MonoBehaviour 
{
	public GameObject leshyA;
	public GameObject leshyB;
	public GameObject leshyRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Leshy")
		{
			GameObject eTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			leshyA = eTG.transform.FindChild("leshyPosA").gameObject;
			leshyB = eTG.transform.FindChild("leshyPosB").gameObject;
			leshyRef = eTG.transform.FindChild("leshyRef").gameObject;
		}
		
		//leshyRef.transform.position = new Vector3(leshyA.transform.position.x, leshyRef.transform.position.y, leshyA.transform.position.z);
		leshyRef.transform.localPosition = new Vector3(0, leshyRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
		//	Debug.Log("A-------B");
			if (Vector3.Distance(leshyRef.transform.position, leshyB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			leshyRef.transform.LookAt(leshyB.transform.position);
			leshyRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(leshyRef.transform.position, leshyA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			leshyRef.transform.LookAt(leshyA.transform.position);
			leshyRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(leshyRef.transform.position.x, transform.position.y, leshyRef.transform.position.z);
	}
}
