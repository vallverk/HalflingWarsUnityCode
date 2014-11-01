using UnityEngine;
using System.Collections;

public class unlockCaveTimerTut : MonoBehaviour 
{
	private int oldTime, curTime;
	private popUpInformation scrPopupInformation;
	
	private Transform cavCreature01, cavCreature02;
	private GameObject gPlot, eTG;
	
	public static bool creatureWalkBool = false, runOnceBool = false;
	private float speed = 2.5f;

	private bool effectGenOnceBool = true;
	
	
	// Use this for initialization
	void Start () 
	{
		scrPopupInformation = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
		cavCreature01 = transform.FindChild("GoblinChar01") as Transform;
		cavCreature02 = transform.FindChild("GoblinChar02") as Transform;
		
		gPlot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
		eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
		
		oldTime = (int)Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.taskCount == 9)
		{
			if (curTime == 0)
			{
				effectGenOnceBool = true;
				transform.FindChild("caveEffect").gameObject.GetComponent<MeshRenderer>().enabled = true;
				transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
				transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (curTime == 5)
			{
				// add creature gen effect
				if (effectGenOnceBool)
				{
					effectGenOnceBool = false;
					GameObject orcEff = Instantiate(scrPopupInformation.gameManagerInfo.par_OrcGen_PF, 
				    	                            new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z),
				        	                        Quaternion.Euler(330, 0, 0)) as GameObject;
					orcEff.GetComponent<ParticleSystem>().Play();
				}

				transform.FindChild("caveEffect").gameObject.GetComponent<MeshRenderer>().enabled = false;
				transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			else if (curTime == 8)
			{
				GameManager.popUpCount = 15;
				scrPopupInformation.curPopUpCnt = 15;
				scrPopupInformation.curPopUpType = 0;
				scrPopupInformation.popUpGuidObj.renderer.material.mainTexture = scrPopupInformation.goblinTex;
				scrPopupInformation.generatePopUp(scrPopupInformation.curPopUpCnt, scrPopupInformation.curPopUpType);
			}
			
			curTime = (int)Time.time - oldTime;
//			Debug.Log(" ~~> " + curTime);
		
			if (creatureWalkBool)
			{
				if (runOnceBool)
				{
					cavCreature01.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					cavCreature02.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					cavCreature01.GetComponent<MeshRenderer>().enabled = false;
					cavCreature02.GetComponent<MeshRenderer>().enabled = false;
					runOnceBool = false;
				}
				
				if (Vector3.Distance(cavCreature01.transform.position, gPlot.transform.position) > 6f)
					cavCreature01.transform.position =  Vector3.MoveTowards(cavCreature01.transform.position , gPlot.transform.position, speed * Time.deltaTime);
				
				else if (cavCreature01.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled == true)
				{
					Debug.Log("cave 01 walk over");
					cavCreature01.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
					cavCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					gPlot.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					gPlot.AddComponent<HealthProgressBarTutorial>();
				}
				
				if (Vector3.Distance(cavCreature02.transform.position, eTG.transform.position) > 9f)
					cavCreature02.transform.position =  Vector3.MoveTowards(cavCreature02.transform.position , eTG.transform.position, speed * Time.deltaTime);
				else if (cavCreature02.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled == true)
				{
					Debug.Log("cave 02 walk over");
					cavCreature02.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
					cavCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					eTG.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					eTG.AddComponent<HealthProgressBarTutorial>();
				}
				//Debug.Log("-> " + Vector3.Distance(cavCreature02.transform.position, eTG.transform.position));
				
				if (cavCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled == true &&
					cavCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled == true)
				{
					creatureWalkBool = false;
					//GameManager.taskCount = 10;
					//scrPopupInformation.updateTaskCount();
					
					//cavCreature01.transform.position = transform.FindChild("GoblinChar01_loc").gameObject.transform.position;
					//cavCreature02.transform.position = transform.FindChild("GoblinChar02_loc").gameObject.transform.position;
					
//					cavCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
//					cavCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
//					cavCreature01.GetComponent<MeshRenderer>().enabled = true;
//					cavCreature02.GetComponent<MeshRenderer>().enabled = true;
					
					GameManager.popUpCount = 17;
					scrPopupInformation.curPopUpCnt = 17;
					scrPopupInformation.curPopUpType = 0;
					GameManager.taskCount = 10;
					scrPopupInformation.updateTaskCount();
					scrPopupInformation.updatePopUpCount();
					scrPopupInformation.popUpGuidObj.renderer.material.mainTexture = scrPopupInformation.samTex;
					scrPopupInformation.generatePopUp(scrPopupInformation.curPopUpCnt, scrPopupInformation.curPopUpType);
					GameObject.Find("Main Camera").transform.position = new Vector3(-75, 40, -3);
				}
			}
		}
	}
}
