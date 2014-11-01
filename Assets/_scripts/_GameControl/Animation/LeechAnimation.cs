using UnityEngine;
using System.Collections;

public class LeechAnimation : MonoBehaviour 
{
	public GameObject leechA;
	public GameObject leechB;
	public GameObject leechRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Leech")
		{
			GameObject eTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			leechA = eTG.transform.FindChild("leechPosA").gameObject;
			leechB = eTG.transform.FindChild("leechPosB").gameObject;
			leechRef = eTG.transform.FindChild("leechRef").gameObject;
		}
		
		//leechRef.transform.position = new Vector3(leechA.transform.position.x, leechRef.transform.position.y, leechA.transform.position.z);
		leechRef.transform.localPosition = new Vector3(0, leechRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
		//	Debug.Log("A-------B");
			if (Vector3.Distance(leechRef.transform.position, leechB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			leechRef.transform.LookAt(leechB.transform.position);
			leechRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(leechRef.transform.position, leechA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			leechRef.transform.LookAt(leechA.transform.position);
			leechRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(leechRef.transform.position.x, transform.position.y, leechRef.transform.position.z);
	}
}
