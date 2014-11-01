using UnityEngine;
using System.Collections;

public class CaveCreatureWalk : MonoBehaviour 
{
	public GameObject caveCreature;
	public Vector3 targetPosition;
	private float speed;
	
	void Start () 
	{
		speed = 1.8f;
		if(caveCreature != null)
		{
//			Debug.Log("caveCreature : "+caveCreature.name);
			caveCreature.transform.FindChild("attack_anim").GetComponent<MeshRenderer>().enabled = false;
			caveCreature.transform.FindChild("Walk_anim").GetComponent<MeshRenderer>().enabled = true;
			caveCreature.transform.localScale = new Vector3(caveCreature.transform.localScale.x * -1f, caveCreature.transform.localScale.y, caveCreature.transform.localScale.z);
//			Debug.Log("Creature scale : "+caveCreature.transform.localScale);
		}
	}
	
	void Update () 
	{
		if(caveCreature != null)
		{
			if(Vector3.Distance(caveCreature.transform.position, targetPosition) <= 0.5f)
			{
				Destroy(this);
				caveCreature.transform.FindChild("Walk_anim").GetComponent<MeshRenderer>().enabled = false;
				caveCreature.transform.FindChild("attack_anim").GetComponent<MeshRenderer>().enabled = false;
			}
			else
				caveCreature.transform.position = Vector3.MoveTowards(caveCreature.transform.position , targetPosition, speed * Time.deltaTime);	
		}
		else if(caveCreature == null)
		{
			Destroy(this);	
		}
	}
}
