using UnityEngine;
using System.Collections;

public class LurkerAnimation : MonoBehaviour 
{
	public GameObject lurkerA;
	public GameObject lurkerB;
	public GameObject lurkerRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Lurker")
		{
			GameObject eTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			lurkerA = eTG.transform.FindChild("lurkerPosA").gameObject;
			lurkerB = eTG.transform.FindChild("lurkerPosB").gameObject;
			lurkerRef = eTG.transform.FindChild("lurkerRef").gameObject;
		}
		
		//lurkerRef.transform.position = new Vector3(lurkerA.transform.position.x, lurkerRef.transform.position.y, lurkerA.transform.position.z);
		lurkerRef.transform.localPosition = new Vector3(0, lurkerRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
		//	Debug.Log("A-------B");
			if (Vector3.Distance(lurkerRef.transform.position, lurkerB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			lurkerRef.transform.LookAt(lurkerB.transform.position);
			lurkerRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(lurkerRef.transform.position, lurkerA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			lurkerRef.transform.LookAt(lurkerA.transform.position);
			lurkerRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(lurkerRef.transform.position.x, transform.position.y, lurkerRef.transform.position.z);
	}
}
