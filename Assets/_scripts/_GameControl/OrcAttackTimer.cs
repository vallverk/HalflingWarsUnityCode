using UnityEngine;
using System.Collections;
using System;

public class OrcAttackTimer : MonoBehaviour 
{
	public float SecCnt;
	public GameObject cave;
	public GameObject caveCreature01, caveCreature02;

	public popUpInformation scrPopUpInformation;
	
	void Start () 
	{	
		scrPopUpInformation = GameObject.Find("PopUPManager").gameObject.GetComponent<popUpInformation>() as popUpInformation;
//		Debug.Log("Cave Unlock Time : " + SecCnt);
//		Debug.Log("Cave : "+cave.name);
		StartCoroutine(updateSeconds());

		transform.FindChild("CoolDown").gameObject.SetActive(true);

		//if (
	}
	
	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
	             SecCnt--;
				
				//this.gameObject.transform.FindChild("AttackTimer(Clone)").GetComponent<SpriteText>().Text = ""+ assignSecToTimeSpan(SecCnt);
				Transform atkTimerObj = this.gameObject.transform.FindChild("AttackTimer(Clone)") as Transform;
				if (atkTimerObj != null)
				{
					this.gameObject.transform.FindChild("AttackTimer(Clone)").GetComponent<SpriteText>().Text = assignSecToTimeSpan(SecCnt).ToString();
					if(caveCreature01 != null)
						caveCreature01.renderer.enabled = false;
					if(caveCreature02 != null)
						caveCreature02.renderer.enabled = false;
				}

				if (SecCnt == 30)
				{
					scrPopUpInformation.defaultPopUpBool = true;
					scrPopUpInformation.defaultPopUp(62, 0);
				}
			}
			else
			{			
				//Destroy(this);
				if(this.gameObject != null)
				{
					//OrcSystem.isCaveCreature = true;
					Destroy(this.gameObject.GetComponent<OrcAttackTimer>());
					Destroy(this.gameObject.transform.FindChild("AttackTimer(Clone)").gameObject);
					cave.transform.FindChild("caveEffect").renderer.enabled = false;
					cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);
					
					Debug.Log("Time over");
					if(caveCreature01 != null)
					{
						if(this.gameObject.transform.FindChild("ProgressBar").gameObject.active == true)
						{
							Debug.Log("Start caveCreature01 Attack");
							caveCreature01.renderer.enabled = false;
							caveCreature01.transform.FindChild("LessAgg1_anim").gameObject.renderer.enabled = true;
//							caveCreature01.transform.FindChild("Walk_anim").renderer.enabled = false;
//							caveCreature01.transform.FindChild("attack_anim").renderer.enabled = false;
						}
						else
						{
						caveCreature01.renderer.enabled = true;
							caveCreature01.transform.FindChild("LessAgg1_anim").gameObject.renderer.enabled = false;
							//caveCreature01.transform.FindChild("Walk_anim").renderer.enabled = false;
							//caveCreature01.transform.FindChild("attack_anim").renderer.enabled = false;
						}
						caveCreature01.transform.localScale = cave.transform.FindChild("GoblinChar01_loc").transform.localScale;
						caveCreature01.transform.localPosition = cave.transform.FindChild("GoblinChar01_loc").transform.localPosition;
					}
					
					if(caveCreature02 != null)
					{
						if(this.gameObject.transform.FindChild("ProgressBar").gameObject.active == true)
						{
							Debug.Log("Start caveCreature02 Attack");
							caveCreature02.renderer.enabled = false;
							caveCreature02.transform.FindChild("LessAgg2_anim").gameObject.renderer.enabled = true;
							//caveCreature02.transform.FindChild("Walk_anim").renderer.enabled = false;
							//caveCreature02.transform.FindChild("attack_anim").renderer.enabled = false;
						}
						else
						{
						caveCreature02.renderer.enabled = true;
							caveCreature02.transform.FindChild("LessAgg2_anim").gameObject.renderer.enabled = false;
							//caveCreature02.transform.FindChild("Walk_anim").renderer.enabled = false;
							//caveCreature02.transform.FindChild("attack_anim").renderer.enabled = false;
						}
						caveCreature02.transform.localScale = cave.transform.FindChild("GoblinChar02_loc").transform.localScale;
						caveCreature02.transform.localPosition = cave.transform.FindChild("GoblinChar02_loc").transform.localPosition;
					}
				}
			}
			
		    yield return new WaitForSeconds(1);
		}
	}
	
	public TimeSpan assignSecToTimeSpan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
	
}
