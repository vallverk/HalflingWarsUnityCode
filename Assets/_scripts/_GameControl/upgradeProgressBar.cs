using UnityEngine;
using System.Collections;
using System;

public class upgradeProgressBar : MonoBehaviour 
{
	public GameObject progressBar;
	public GameObject ProgressBarPlate;
	public GameObject progressBarPov;
	
	public int currentUpgradeLevel = 1;
	
	public int objTypeId = 0;
	
	private UpgradeTexture upgradeTextureInfo;
	
	public int cnt = 0;
	public float seconds,SecCnt = 0f;
	public bool runOneTimeBool = false;
	public popUpInformation popUpInfoScript;
	
	private guiControl guiControlInfo;
	private findPath fp;
	private AchivementsDetails ad;
	// Use this for initialization
	void Start () 
	{
		popUpInfoScript = GameObject.Find("PopUPManager").gameObject.GetComponent("popUpInformation") as popUpInformation;
		//progressBar.renderer.enabled = false;
		runOneTimeBool = true;
		upgradeTextureInfo = GameObject.Find("GameManager").GetComponent("UpgradeTexture") as UpgradeTexture;
		
		StartCoroutine(updateProgressBar());
		StartCoroutine(updateSeconds());
		
		fp = (findPath)FindObjectOfType(typeof(findPath));
		guiControlInfo = (guiControl)FindObjectOfType(typeof(guiControl));
		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
	}
	
	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
	             SecCnt--;
			}
			
		    yield return new WaitForSeconds(1);
			
//			Debug.Log("Time :" + assignSecondstoTimespan((double)SecCnt));
			
			
		}
	}
	
	IEnumerator updateProgressBar()
    {
		//if (progressBarPov.gameObject == null)
		//	return;
		
        while(true)
        {
			
			if (SecCnt == 0)
			{
				SecCnt = seconds;
			}
			
			if (cnt <= seconds)
			{
				if(seconds != 0)
				{
				progressBarPov.transform.localScale = new Vector3(progressBarPov.transform.localScale.x + (1f / seconds)/*0.00167f*/,
																	progressBarPov.transform.localScale.y,
																	progressBarPov.transform.localScale.z);
				}
			}
			cnt++;	
			
//			Debug.Log(cnt);
        	yield return new WaitForSeconds(1);
			
			Transform remainTimeObj = transform.FindChild("ProgressBar").gameObject.transform.FindChild("RemainTime") as Transform;
			
			if (remainTimeObj != null)
				transform.FindChild("ProgressBar").gameObject.transform.FindChild("RemainTime").gameObject.GetComponent<SpriteText>().Text = (assignSecondstoTimespan((double)SecCnt)).ToString();
			
		}
	}
	
	private TimeSpan assignSecondstoTimespan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log(transform.gameObject.name + " --- cnt :: " + cnt + " ----- " + seconds + " --- " + progressBarPov.transform.localScale.x);
		
		if(cnt == seconds)
		{
			if (runOneTimeBool)
			{
				runOneTimeBool = false;
				transform.gameObject.GetComponent<upgradeProgressBar>().enabled = false;
				progressBarPov.transform.localScale = new Vector3(0, progressBarPov.transform.localScale.y, progressBarPov.transform.localScale.z);
				cnt = 0;
				
				// earth training ground
				if (transform.gameObject.tag == "TrainingGround")
				{
					//if(currentUpgradeLevel == 1)
					if (GameManager.earthTG_lvl == 1 && GameManager.gameLevel >= 4)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.earthTG2;
						GameManager.upgradeTrainingGroundBool = false;
						
						// remove item from task list
						popUpInfoScript.inventoryInfo.RemoveItem(popUpInfoScript.taskDetailsInfo.Four_Half_task2);
						popUpInfoScript.taskDetailsInfo.Four_Half_task2_bool = true;
					}
					else if (GameManager.earthTG_lvl == 2 && GameManager.gameLevel >= 8)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.earthTG3;
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.earthTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				// plant training ground
				if (transform.gameObject.tag == "PlantTG")
				{
					if (GameManager.plantTG_lvl == 1 && GameManager.gameLevel >= 6)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plantTG2;
						GameManager.upgradeTrainingGroundBool = false;
					}
					else if (GameManager.plantTG_lvl == 2 && GameManager.gameLevel >= 9)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plantTG3;
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.plantTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				// water training ground
				if (transform.gameObject.tag == "WaterTG")
				{
					if (GameManager.waterTG_lvl == 1 && GameManager.gameLevel >= 8)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.waterTG2;
						transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					else if (GameManager.waterTG_lvl == 2 && GameManager.gameLevel >= 12)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.waterTG3;
						transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("waterTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.waterTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				// Swamp Training Ground
				if (transform.gameObject.tag == "Swamp")
				{
					if (GameManager.swampTG_lvl == 1 && GameManager.gameLevel >= 7)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.swampTG2;
						transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					else if (GameManager.swampTG_lvl == 2 && GameManager.gameLevel >= 12)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.swampTG3;
						transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("swampTG03_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.swampTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				// Fire Training Ground
				if (transform.gameObject.tag == "DFireTG")
				{
					if (GameManager.fireTG_lvl == 1 && GameManager.gameLevel >= 9)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.fireTG2;
						transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					else if (GameManager.fireTG_lvl == 2 && GameManager.gameLevel >= 14)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.fireTG3;
						transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						transform.FindChild("FireTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.fireTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				// DEarth Training Ground
				if (transform.gameObject.tag == "DEarth")
				{
					if (GameManager.dEarthTG_lvl == 1 && GameManager.gameLevel >= 8)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG2;
						GameManager.upgradeTrainingGroundBool = false;
					}
					else if (GameManager.dEarthTG_lvl == 2 && GameManager.gameLevel >= 13)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG3;
						GameManager.upgradeTrainingGroundBool = false;
					}
					GameManager.dEarthTG_lvl++;
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				}
				
				
			//---------------------------------------------------------------------------------------------------
				
				// garden plot
				if (transform.gameObject.tag == "Plot")
				{
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					}
					else if (currentUpgradeLevel == 2)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel3;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					}
				}
				 // garden plot
				else if (transform.gameObject.tag == "DPlot")
				{
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					}
					else if (currentUpgradeLevel == 2)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel3;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					}
				}
			
			//---------------------------------------------------------------------------------------------------
				// inn building
				if (transform.gameObject.tag == "Inn")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						 						ad.percentComplete28 = 100;
						
						popUpInfoScript.halflinGolumDisable();
					}
				}
				
				// Stable building
				if (transform.gameObject.tag == "Stable")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Stable2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
						popUpInfoScript.halflinGolumDisable();
					}
				}
				
				// House building
				if (transform.gameObject.tag == "HHouse")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_House2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
			
						 						ad.percentComplete17 = 100;
						
						popUpInfoScript.halflinGolumDisable();
					}
				}
				
				// D House building
				if (transform.gameObject.tag == "DHouse")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_house2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
				
						popUpInfoScript.DarklinGolumDisable();
					}
				}
				
				// d inn building
				if (transform.gameObject.tag == "DInn")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel_2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
				
						popUpInfoScript.DarklinGolumDisable();
					}
				}
				
				// d inn building
				if (transform.gameObject.tag == "DStable")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Stable2;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
						 						ad.percentComplete29 = 100;
						
						popUpInfoScript.DarklinGolumDisable();
					}
				}
				
				// d BlackSmith building
				if (transform.gameObject.tag == "DBlackSmith")
				{
					if (currentUpgradeLevel == 1)
					{
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.dBlackSmith2;
						transform.FindChild("_DBlackSmith_Night").gameObject.renderer.material.mainTexture = upgradeTextureInfo.dBlackSmith2_N;
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
				
						popUpInfoScript.DarklinGolumDisable();
					}
				}
				
				// earth obelisk
				if (transform.gameObject.tag == "EarthObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_EarthObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_EarthObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				// plant obelisk
				if (transform.gameObject.tag == "PlantObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_PlantObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_PlantObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				// water obelisk
				if (transform.gameObject.tag == "WaterObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_WaterObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_WaterObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				// swamp obelisk
				if (transform.gameObject.tag == "SwampObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_SwampObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_SwampObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				// dark earth obelisk
				if (transform.gameObject.tag == "DEarthObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_EarthObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_EarthObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				// fire obelisk
				if (transform.gameObject.tag == "FireObelisk")
				{
					if (currentUpgradeLevel == 1)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_FireObelisk2;
					else if (currentUpgradeLevel == 2)
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_FireObelisk3;
					
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
					popUpInfoScript.DarklinGolumDisable();
				}
				
				currentUpgradeLevel++;
				transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				this.enabled = false;
			}
		}
	}
}
