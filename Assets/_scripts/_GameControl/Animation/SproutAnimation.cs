using UnityEngine;
using System.Collections;

public class SproutAnimation : MonoBehaviour 
{
	public GameObject sproutA;
	public GameObject sproutB;
	public GameObject sproutRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Sprout")
		{
			GameObject eTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			sproutA = eTG.transform.FindChild("sproutPosA").gameObject;
			sproutB = eTG.transform.FindChild("sproutPosB").gameObject;
			sproutRef = eTG.transform.FindChild("sproutRef").gameObject;
		}
		
		//sproutRef.transform.position = new Vector3(sproutA.transform.position.x, sproutRef.transform.position.y, sproutA.transform.position.z);
		sproutRef.transform.localPosition = new Vector3(0, sproutRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(sproutRef.transform.position, sproutB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			sproutRef.transform.LookAt(sproutB.transform.position);
			sproutRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(sproutRef.transform.position, sproutA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			sproutRef.transform.LookAt(sproutA.transform.position);
			sproutRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		transform.position = new Vector3(sproutRef.transform.position.x, transform.position.y, sproutRef.transform.position.z);
	}
}
