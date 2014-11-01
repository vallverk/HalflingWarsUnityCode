using UnityEngine;
using System.Collections;

public class NymphAnimation : MonoBehaviour 
{
	public GameObject nymphA;
	public GameObject nymphB;
	public GameObject nymphRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Nymph")
		{
			GameObject eTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			nymphA = eTG.transform.FindChild("nymphPosA").gameObject;
			nymphB = eTG.transform.FindChild("nymphPosB").gameObject;
			nymphRef = eTG.transform.FindChild("nymphRef").gameObject;
		}
		
		//nymphRef.transform.position = new Vector3(nymphA.transform.position.x, nymphRef.transform.position.y, nymphA.transform.position.z);
		nymphRef.transform.localPosition = new Vector3(0, nymphRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(nymphRef.transform.position, nymphB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			nymphRef.transform.LookAt(nymphB.transform.position);
			nymphRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(nymphRef.transform.position, nymphA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			nymphRef.transform.LookAt(nymphA.transform.position);
			nymphRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(nymphRef.transform.position.x, transform.position.y, nymphRef.transform.position.z);
	}
}
