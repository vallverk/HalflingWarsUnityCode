using UnityEngine;
using System.Collections;

public class Coll : MonoBehaviour 
{
	public bool Halfling_MoveStop;
	public bool Darkling_MoveStop;
	private findPath fp;
	public int Halfling_Hammering;
	public int Darkling_Hammering;
	
	void Start () 
	{
		fp = (findPath)FindObjectOfType(typeof(findPath));
		InvokeRepeating("hammer", float.Epsilon, 1f);
	}
	void hammer()
	{
			Halfling_Hammering++;
			Darkling_Hammering++;
	}
	public void OnTriggerEnter(Collider cc )
	{
		if(cc.gameObject.tag == "working")
		{
//			print ("hello i am inn");
			Halfling_MoveStop = true;
			//fp.moveto = false;
		}
		if(cc.gameObject.tag == "Dworking")
		{
			Darkling_MoveStop = true;
		}
	}
	
	
	void Update () 
	{
		if(Halfling_MoveStop == true)
		{
	   	 	StartCoroutine(WaitAndPrint(1.0F));
		}
		if(Darkling_MoveStop == true)
		{
			StartCoroutine(DarkWaitAndPrint(1.0f));
		}
	}
	
	IEnumerator WaitAndPrint(float waitTime) 
	{
        yield return new WaitForSeconds(waitTime);
		
      	if(fp.Halfing_Front_Hammer == true)
		{
			if(fp.golum_Halfling_Front_Generate == null)
			{
				fp.findGolum();
			}
			fp.halfling_Generate = false;
			fp.golum_Halfling_Front_Generate.gameObject.renderer.enabled = false;
			if(Halfling_Hammering >=0 && Halfling_Hammering <=3)
			{
				fp.golum_Halfling_Front_HighHammer.gameObject.renderer.enabled = true;
				fp.golum_Halfling_Front_LowHammer.gameObject.renderer.enabled = false;
			}
			else if(Halfling_Hammering >3 && Halfling_Hammering <=6) 
			{
				fp.golum_Halfling_Front_LowHammer.gameObject.renderer.enabled = true;
				fp.golum_Halfling_Front_HighHammer.gameObject.renderer.enabled = false;
			}
			else if(Halfling_Hammering >6)
			{
				Halfling_Hammering = 0;
			}
		}
    }
	
	IEnumerator DarkWaitAndPrint(float DarkwaitTime) 
	{
        yield return new WaitForSeconds(DarkwaitTime);
		
		if(fp.Darking_Front_Hammer == true)
		{
			if(fp.golum_Darkling_Front_Generate == null)
			{
				fp.findGolum();
			}
			fp.darkling_Generate = false;
			fp.golum_Darkling_Front_Generate.gameObject.renderer.enabled = false;
			if(Darkling_Hammering >= 0 && Darkling_Hammering <=3)
			{
				fp.golum_Darkling_Front_HighHammer.gameObject.renderer.enabled = true;
				fp.golum_Darkling_Front_LowHammer.gameObject.renderer.enabled = false;
			}
			else if(Darkling_Hammering >= 3 && Darkling_Hammering <=6)
			{
				fp.golum_Darkling_Front_HighHammer.gameObject.renderer.enabled = false;
				fp.golum_Darkling_Front_LowHammer.gameObject.renderer.enabled = true;
			}
			else if(Darkling_Hammering >6)
			{
				Darkling_Hammering = 0;
			}
		}
	}
}
