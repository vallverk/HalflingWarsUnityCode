using UnityEngine;
using System.Collections;

public class NixAnimation : MonoBehaviour 
{
	public GameObject nixA;
	public GameObject nixB;
	public GameObject nixRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Nix")
		{
			GameObject eTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			nixA = eTG.transform.FindChild("nixPosA").gameObject;
			nixB = eTG.transform.FindChild("nixPosB").gameObject;
			nixRef = eTG.transform.FindChild("nixRef").gameObject;
		}
		
		//nixRef.transform.position = new Vector3(nixA.transform.position.x, nixRef.transform.position.y, nixA.transform.position.z);
		nixRef.transform.localPosition = new Vector3(0, nixRef.transform.position.y, 0);	
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(nixRef.transform.position, nixB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			nixRef.transform.LookAt(nixB.transform.position);
			nixRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(nixRef.transform.position, nixA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			nixRef.transform.LookAt(nixA.transform.position);
			nixRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(nixRef.transform.position.x, transform.position.y, nixRef.transform.position.z);
	}
}
