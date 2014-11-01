using UnityEngine;
using System.Collections;

public class DjinnAnimation : MonoBehaviour 
{
	public GameObject djinnA;
	public GameObject djinnB;
	public GameObject djinnRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Djinn")
		{
			GameObject eTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			djinnA = eTG.transform.FindChild("djinnPosA").gameObject;
			djinnB = eTG.transform.FindChild("djinnPosB").gameObject;
			djinnRef = eTG.transform.FindChild("djinnRef").gameObject;
		}
		
		//djinnRef.transform.position = new Vector3(djinnA.transform.position.x, djinnRef.transform.position.y, djinnA.transform.position.z);
		djinnRef.transform.localPosition = new Vector3(0, djinnRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(djinnRef.transform.position, djinnB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			djinnRef.transform.LookAt(djinnB.transform.position);
			djinnRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(djinnRef.transform.position, djinnA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			djinnRef.transform.LookAt(djinnA.transform.position);
			djinnRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		transform.position = new Vector3(djinnRef.transform.position.x, transform.position.y, djinnRef.transform.position.z);
	}
}
