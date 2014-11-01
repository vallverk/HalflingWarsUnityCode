using UnityEngine;
using System.Collections;

public class FenrirAnimation : MonoBehaviour 
{
	public GameObject fenrirA;
	public GameObject fenrirB;
	public GameObject fenrirRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Fenrir")
		{
			GameObject eTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			fenrirA = eTG.transform.FindChild("fenrirPosA").gameObject;
			fenrirB = eTG.transform.FindChild("fenrirPosB").gameObject;
			fenrirRef = eTG.transform.FindChild("fenrirRef").gameObject;
		}
		
		//fenrirRef.transform.position = new Vector3(fenrirA.transform.position.x, fenrirRef.transform.position.y, fenrirA.transform.position.z);
		fenrirRef.transform.localPosition = new Vector3(0, fenrirRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
//			Debug.Log("A-------B");
			if (Vector3.Distance(fenrirRef.transform.position, fenrirB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			fenrirRef.transform.LookAt(fenrirB.transform.position);
			fenrirRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
		//	Debug.Log("B---------A");
			if (Vector3.Distance(fenrirRef.transform.position, fenrirA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			fenrirRef.transform.LookAt(fenrirA.transform.position);
			fenrirRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(fenrirRef.transform.position.x, transform.position.y, fenrirRef.transform.position.z);
	}
}
