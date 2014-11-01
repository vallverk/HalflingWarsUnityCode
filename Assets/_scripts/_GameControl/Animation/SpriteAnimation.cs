using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour 
{
	public GameObject spriteA;
	public GameObject spriteB;
	public GameObject spriteRef;
	
	private Transform curLookAt;
	public bool moveAB_Bool = false, moveBA_Bool = false;
	
	public float speed = 3;
	
	// Use this for initialization
	void Start () 
	{
		if (transform.gameObject.tag == "Sprite")
		{
			GameObject eTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			spriteA = eTG.transform.FindChild("dSpritePosA").gameObject;
			spriteB = eTG.transform.FindChild("dSpritePosB").gameObject;
			spriteRef = eTG.transform.FindChild("dSpriteRef").gameObject;
		}
		
		//spriteRef.transform.position = new Vector3(spriteA.transform.position.x, spriteRef.transform.position.y, spriteA.transform.position.z);
		spriteRef.transform.localPosition = new Vector3(0, spriteRef.transform.position.y, 0);
		//moveAB_Bool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveAB_Bool)
		{
			//Debug.Log("A-------B");
			if (Vector3.Distance(spriteRef.transform.position, spriteB.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = false;
				moveBA_Bool = true;
			}
			spriteRef.transform.LookAt(spriteB.transform.position);
			spriteRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
			
		}
		
		if (moveBA_Bool)
		{
//			Debug.Log("B---------A");
			if (Vector3.Distance(spriteRef.transform.position, spriteA.transform.position) < 0.5f)
			{
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				moveAB_Bool = true;
				moveBA_Bool = false;
			}
			spriteRef.transform.LookAt(spriteA.transform.position);
			spriteRef.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		transform.position = new Vector3(spriteRef.transform.position.x, transform.position.y, spriteRef.transform.position.z);
	}
}
