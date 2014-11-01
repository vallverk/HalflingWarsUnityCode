using UnityEngine;
using System.Collections;
using System;

public class ObliskProgressBar : MonoBehaviour 
{
	public float SecCnt;
	//public GameObject oblisk;
	
	void Start () 
	{
		StartCoroutine(updateSeconds());
	}
	
	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
	            SecCnt--;
				this.gameObject.transform.FindChild("DefenceObeliskIcon").FindChild("RemainTime").GetComponent<SpriteText>().Text = assignSecToTimeSpan(SecCnt).ToString();
				//this.gameObject.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			else
			{			
				//Destroy(this);
				if(this.gameObject != null)
				{
					//Destroy(this.gameObject.GetComponent<DefenseProgressBar>());
					//if(oblisk != null)
						//Destroy(oblisk);
					
					Destroy(this.gameObject);
					//this.gameObject.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
					//this.gameObject.transform.FindChild("DefenceObeliskIcon").gameObject.SetActiveRecursively(false);
					Debug.Log("Defense time is over");
				}
			}
//			
		    yield return new WaitForSeconds(1);
////			Debug.Log("time :::: " + assignSecToTimeSpan(SecCnt));
		}
	}
	
	private TimeSpan assignSecToTimeSpan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
}
