using UnityEngine;
using System.Collections;
using System;

public class progressBar : MonoBehaviour 
{
	public GameObject progressBarObj;
	public GameObject progressBarPov;
	public Material halflingBuildMat;
	public Material trollcaveBuildMat;
	
	// TEXTURE DECLARATION
	//public Texture2D turnip1, turnip2, turnip3;
	//public Texture2D pipeWeed1, pipeWeed2;
	
		
	public int cnt = 0;
	
	public int estimateTime = 0;
	
	public guiControl guiControlInfo;
	public popUpInformation popUpInfoScript;
	public UpgradeTexture upgradeTextureInfo;
	
	public float seconds,SecCnt = 0; //= 15f;
	private bool runOneTimeBool = false;
	
	private GUIText guiTime;
	private Coll c;
	private findPath fp;
	
	private AchivementsDetails ad;
	private Inventory inventoryInfo;
	private Inventory1 inventory1Info;
	private taskDetails taskDetailsInfo;
	// Use this for initialization
	void Start () 
	{
		
		StartCoroutine(updateProgressBar());
		
		StartCoroutine(updateSeconds());
		
		guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		popUpInfoScript = GameObject.Find("PopUPManager").GetComponent("popUpInformation") as popUpInformation;
		upgradeTextureInfo = GameObject.Find("GameManager").GetComponent("UpgradeTexture") as UpgradeTexture;
		
		runOneTimeBool = true;
		
		c= (Coll)FindObjectOfType(typeof(Coll));
		fp = (findPath)FindObjectOfType(typeof(findPath));
		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
		inventoryInfo = (Inventory)FindObjectOfType(typeof(Inventory));
		inventory1Info = (Inventory1)FindObjectOfType(typeof(Inventory1));
		taskDetailsInfo = (taskDetails)FindObjectOfType(typeof(taskDetails));
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
				  
				if (seconds != 0)
				{
					progressBarPov.transform.localScale = new Vector3(progressBarPov.transform.localScale.x + (1f / seconds)/*0.00167f*/,
																		progressBarPov.transform.localScale.y,
																		progressBarPov.transform.localScale.z);
				}
			}
			cnt++;	
			
//			Debug.Log(cnt);
        	yield return new WaitForSeconds(1);
		}
        
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
//			Debug.Log("SecTime :" + (double)SecCnt);
//			Debug.Log("Time :" + assignSecondstoTimespan((double)SecCnt));
			
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
	
	private bool isTextureMidChangeforCreatures;
	private GameObject tgTemp;
	
	private void GetTrainingGroundsSparkLevel1(GameObject Tg)
	{
		tgTemp = Tg;
		
		if(tgTemp != null)
		{
			if(tgTemp.tag == "TrainingGround")
			{
			   tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1EarthTg;
			}
			else if(tgTemp.tag == "PlantTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1PlantTg;
			}
			else if(tgTemp.tag == "WaterTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1WaterTg;
			}
			else if(tgTemp.tag == "DEarthTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1DEarthTg;
			}
			else if(tgTemp.tag == "DFireTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1FireTg;
			}
			else if(tgTemp.tag == "Swamp")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level1SwampTg;
			}
		}
		isTextureMidChangeforCreatures = false;
	}
	
	private void GetTrainingGroundsSparkLevel2(GameObject Tg)
	{
		tgTemp = Tg;
		
		if(tgTemp != null)
		{
			if(tgTemp.tag == "TrainingGround")
			{
			   tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2EarthTg;
			}
			else if(tgTemp.tag == "PlantTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2PlantTg;
			}
			else if(tgTemp.tag == "WaterTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2WaterTg;
			}
			else if(tgTemp.tag == "DEarthTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2DEarthTg;
			}
			else if(tgTemp.tag == "DFireTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2FireTg;
			}
			else if(tgTemp.tag == "Swamp")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level2SwampTg;
			}
		}
		
		isTextureMidChangeforCreatures = false;
	}
	
	private void GetTrainingGroundsSparkLevel3(GameObject Tg)
	{
		tgTemp = Tg;
		
		if(tgTemp != null)
		{
			if(tgTemp.tag == "TrainingGround")
			{
			   tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3EarthTg;
			}
			else if(tgTemp.tag == "PlantTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3PlantTg;
			}
			else if(tgTemp.tag == "WaterTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3WaterTg;
			}
			else if(tgTemp.tag == "DEarthTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3DEarthTg;
			}
			else if(tgTemp.tag == "DFireTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3FireTg;
			}
			else if(tgTemp.tag == "Swamp")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level3SwampTg;
			}
		}
		
		isTextureMidChangeforCreatures = false;
	}
	
	private void GetTrainingGroundsSparkLevel4(GameObject Tg)
	{
		tgTemp = Tg;
		
		if(tgTemp != null)
		{
			if(tgTemp.tag == "TrainingGround")
			{
			   	tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4EarthTg;		
			}
			else if(tgTemp.tag == "PlantTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4PlantTg;
			}
			else if(tgTemp.tag == "WaterTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4WaterTg;
			}
			else if(tgTemp.tag == "DEarthTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4DEarthTg;
			}
			else if(tgTemp.tag == "DFireTG")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4FireTg;
			}
			else if(tgTemp.tag == "Swamp")
			{
				tgTemp.transform.FindChild("Spark").gameObject.renderer.material.mainTexture = upgradeTextureInfo.Spark_level4SwampTg;
			}
		}
		
		isTextureMidChangeforCreatures = false;
	}
	
	
	
	private bool isTextureMidChange;
	private void ChangeTextureInMid(GameObject go)
	{
		if(isTextureMidChange)
		{
			switch(go.tag)
			{
				
			case "Turnip":
			go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Turnip_Mid_tex;
			
				break;
			case "PipeWeed":
			go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_PipeWeed_Mid_tex;	
				
				break;
				
			case "Pumpkin":
			go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Pumpkin_Mid_tex;
				break;
				
			case "Costmary":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Costmary_Mid_tex;
				break;
				
			case "FairyLily":
			go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Fairlilly_Mid_tex;	
				break;
				
			case "Watercress":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Watercress_Mid_tex;
				break;
				
			case "Mandrake":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Mandrake_Mid_tex;
				break;
				
			case "Vervain":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Vervain_Mid_tex;
				break;
				
			case "Sunflower":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Sunflower_Mid_tex;
					break;
			case "DPumpkin" :
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Pumpkin_Mid_tex;
				
				break;
				
			case "DFirePepper":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_FirePepper_Mid_tex;
				break;
				
			case "DColumbine":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Columbine_Mid_tex;
				break;
				
			case "DBlackBerry":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Blackberry_Mid_tex;
				break;
				
			case "DAven":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Aven_Mix_tex;
				break;
				
			case "BitterBrush":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_BitterBrush_Mid_tex;
				break;
				
			case "BogBean":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Bogbean_Mid_tex;
				break;
				
			case "Wolfsbane":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_Wolfsbane_Mid_tex;
				break;
				
			case "Moonflower":
				go.gameObject.renderer.material.mainTexture = upgradeTextureInfo.d_MoonFlower_Mid_tex;
				break;				
				
			}
			isTextureMidChange = false;
		}
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(progressBarPov.transform.localScale.x > 0.5f)
		{
			isTextureMidChange = true;
			ChangeTextureInMid(this.gameObject);
		}
		
		if(this.gameObject.tag == "Barg" || this.gameObject.tag == "Cusith" || this.gameObject.tag == "Dragon" ||
			this.gameObject.tag == "Draug" || this.gameObject.tag == "Dryad" || this.gameObject.tag == "Hound" || 
			this.gameObject.tag == "Nix" || this.gameObject.tag == "Nymph" || this.gameObject.tag == "Sprout" ||
			this.gameObject.tag == "DHound" || this.gameObject.tag == "Djinn" || this.gameObject.tag == "Fenrir" ||
			this.gameObject.tag == "HellHound" || this.gameObject.tag == "Imp" || this.gameObject.tag == "Leech" ||
			this.gameObject.tag == "Leshy" || this.gameObject.tag == "Lurker" || this.gameObject.tag == "Sprite")
		{
		   if(progressBarPov.transform.localScale.x < 0.33f)
			{
				isTextureMidChangeforCreatures = true;
			    GetTrainingGroundsSparkLevel1(this.gameObject.transform.parent.gameObject);
			}
			else if(progressBarPov.transform.localScale.x > 0.33f && progressBarPov.transform.localScale.x < 0.66f)
			{
				isTextureMidChangeforCreatures = true;
				GetTrainingGroundsSparkLevel2(this.gameObject.transform.parent.gameObject);
			}
			else if(progressBarPov.transform.localScale.x > 0.66f)
			{
				isTextureMidChangeforCreatures = true;
				GetTrainingGroundsSparkLevel3(this.gameObject.transform.parent.gameObject);
			}
		}
		
		if (cnt == seconds)
		{
			if (runOneTimeBool)
			{
				runOneTimeBool = false;
				
				progressBarObj.SetActiveRecursively(false);
				
				if (this.gameObject.name == "HC_C_Hound_GO(Clone)")
				{
					GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					//tg.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
					tg.transform.FindChild("Spark1").gameObject.GetComponent<MeshRenderer>().enabled = false;
					tg.transform.FindChild("Spark2").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Destroy(tg.GetComponent<SparkAnimation>());
					
					Destroy(transform.FindChild("ProgressBar").gameObject);
					Destroy(this);
					
					transform.gameObject.GetComponent<getXP>().xpAnimBool = true;
					transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
					
					transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
					transform.gameObject.GetComponent<HoundAnimation>().moveAB_Bool = true;
					Destroy(transform.FindChild("RabbtiButton").gameObject);
					
					// change collider tag name
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					Destroy(this);
					
				
					GameObject go = GameObject.Find("RabbtiButton(Clone)") as GameObject;
				
					if (go != null)
						Destroy(go);
					
					
				
					GameObject gameGO = GameObject.Find("gameRabbtiButton(Clone)") as GameObject;
					
					if (gameGO != null)
						Destroy(gameGO);
			
					if (GameManager.taskCount == 2)
					{
						guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
						GameManager.popUpCount = 5;
						popUpInfoScript.updatePopUpCount();
						
						popUpInfoScript.curPopUpCnt = 5;
						popUpInfoScript.updateCurPopUpCount();
						
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					
						GameManager.taskCount = 3;
						popUpInfoScript.updateTaskCount();
						
						if (GameManager.popUpCount < 5 && popUpInfoScript.curPopUpCnt < 4)
						{
							GameManager.popUpCount = 5;
							popUpInfoScript.updatePopUpCount();
							
							popUpInfoScript.curPopUpCnt = 4;
							popUpInfoScript.updateCurPopUpCount();
						}
						popUpInfoScript.UpdateScore();
					}
					
					if (GameManager.taskCount == 4)
					{
						GameManager.popUpCount = 6;
						popUpInfoScript.updatePopUpCount();
						
						popUpInfoScript.curPopUpCnt = 6;
						popUpInfoScript.updateCurPopUpCount();
						
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					}
					
				    if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
					{
						popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
					}
				}
			
	
				if (this.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_01")
				{
					GameObject arrow = GameObject.Find("gameArrowPF(Clone)") as GameObject;
					if (arrow != null)
						Destroy(arrow);
					Destroy(this.gameObject);
					GameObject go = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
					go.GetComponent<MeshRenderer>().enabled = true;
					popUpInfoScript.task4(3);
					 					ad.percentComplete4=100;
					popUpInfoScript.EnemyCaveBuildings();
				}
				
				// LEVEL 2 //
				if (GameManager.gameLevel == 2)
				{
					if (this.gameObject.tag == "EarthObelisk" && GameManager.taskCount == 10)
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.h_EarthObelisk, "HW", false, false, popUpInfoScript.scr_GameObjSvr.objEarthobelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("RabbtiButton").gameObject.SetActive(false);

						popUpInfoScript.obeliskTutorial(6);
						
						GameManager.taskCount = 11;
						popUpInfoScript.updateTaskCount();
						
						GameManager.popUpCount = 18;
						popUpInfoScript.curPopUpCnt = 18;
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					}
					/*if (this.gameObject.tag == "Turnip")
					{
						Debug.Log("this.gameObject.name == HC_P_Turnip_GO(Clone)...");
						transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						Destroy(this);
						
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.h_Turnip01;
						
						GameManager.popUpCount = 13;
						popUpInfoScript.updatePopUpCount();
						
						popUpInfoScript.curPopUpCnt = 13;
						popUpInfoScript.updateCurPopUpCount();
						
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
						
						GameObject go1 = GameObject.Find("RabbtiButton(Clone)");
						if (go1 != null)
							GameManager.popUpType1_Count++;
						
						//guiControlInfo.popUpType1_spText.Text = "Ready to Harvest turnip plant";
						
						
						Destroy(GameObject.Find("RabbtiButton(Clone)"));
						GameManager.taskCount = 7;
						popUpInfoScript.updateTaskCount();
		
					}*/
					
					if (this.gameObject.name == "HC_B_Inn_GO(Clone)")
					{
						popUpInfoScript.halflinGolumDisable();

						GameManager.popUpType1_Count++;
						
						transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
						transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						//Destroy(transform.FindChild("ProgressBar").gameObject);
						Destroy(this);
						
						transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_1;
						
						transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						
						GameManager.popUpCount = 18;
						popUpInfoScript.updatePopUpCount();
						
						popUpInfoScript.curPopUpCnt = 18;
						popUpInfoScript.updateCurPopUpCount();
						
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
						
						 						ad.percentComplete5 = 100;
						popUpInfoScript.GoldProducingBuildings();
						popUpInfoScript.UpdateScore();
						Destroy(this);
					}
				}
				
				
				
				if (this.gameObject.name == "HC_C_Sprout_GO(Clone)")
				{
					
					Destroy(transform.FindChild("ProgressBar").gameObject);
					Destroy(this);
					
					transform.gameObject.GetComponent<SproutAnimation>().moveAB_Bool = true;
					// change collider tag name
					transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					Destroy(this);
					
					GameObject go = GameObject.Find("RabbtiButton(Clone)") as GameObject;
				
					if (go != null)
						Destroy(go);
				
					GameObject gameGO = GameObject.Find("gameRabbtiButton(Clone)") as GameObject;
					
					if (gameGO != null)
						Destroy(gameGO);
					
					if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
				}
				
				// LEVEL 3 and above
				
				if (GameManager.gameLevel >= 3)
				{
					// HALFLING PLANT
					if (this.gameObject.tag == "Turnip")
						plantProgressBar(upgradeTextureInfo.h_Turnip01);
					
					if (this.gameObject.tag == "PipeWeed")
						plantProgressBar(upgradeTextureInfo.h_PipeWeed01);
						
					
					if (this.gameObject.tag == "Pumpkin")
						plantProgressBar(upgradeTextureInfo.h_Pumpking01);
							
					if (this.gameObject.tag == "Costmary")
						plantProgressBar(upgradeTextureInfo.h_Costmary01);
					
					if (this.gameObject.tag == "FairyLily")
						plantProgressBar(upgradeTextureInfo.h_FairyLily01);
					
					if (this.gameObject.tag == "Potato")
						plantProgressBar(upgradeTextureInfo.h_Potatoes01);
					
					if (this.gameObject.tag == "Watercress")
						plantProgressBar(upgradeTextureInfo.h_Watercress01);
					
					if (this.gameObject.tag == "Mandrake")
						plantProgressBar(upgradeTextureInfo.h_Mandrake01);
					
					if (this.gameObject.tag == "Vervain")
						plantProgressBar(upgradeTextureInfo.h_Vervain01);
					
					if (this.gameObject.tag == "Sunflower")
						plantProgressBar(upgradeTextureInfo.h_SunFlower01);
					
					// DARKLING PLANT
					if (this.gameObject.tag == "DPumpkin")
						plantProgressBar(upgradeTextureInfo.d_Pumpkin01);
					
					if (this.gameObject.tag == "DFirePepper")
						plantProgressBar(upgradeTextureInfo.d_FirePepper01);
					
					if (this.gameObject.tag == "DColumbine")
						plantProgressBar(upgradeTextureInfo.d_Columbine01);
					
					if (this.gameObject.tag == "DBlackBerry")
						plantProgressBar(upgradeTextureInfo.d_BlackBerry01);
					
					if (this.gameObject.tag == "DAven")
						plantProgressBar(upgradeTextureInfo.d_Aven01);
					
					if (this.gameObject.tag == "BitterBrush")
						plantProgressBar(upgradeTextureInfo.d_BitterBrush01);
					
					if (this.gameObject.tag == "BogBean")
						plantProgressBar(upgradeTextureInfo.d_Bogbean01);
					
					if (this.gameObject.tag == "Wolfsbane")
						plantProgressBar(upgradeTextureInfo.d_Wolfsbane01);
					
					if (this.gameObject.tag == "Moonflower")
						plantProgressBar(upgradeTextureInfo.d_MoonFlower01);
					
//======================================================================================================================================================================					
					
					// CREATURE
					
					// hound
					if (this.gameObject.tag == "Hound")
					{
						this.gameObject.GetComponent<HoundAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
				        if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
					}
					
					// Barg
					if (this.gameObject.tag == "Barg")
					{
						this.gameObject.GetComponent<BargAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();

						transform.gameObject.renderer.enabled = true;
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Cusith
					if (this.gameObject.tag == "Cusith")
					{
						this.gameObject.GetComponent<CusithAnimation>().moveBA_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}

					
					// sprout
					if (this.gameObject.tag == "Sprout")
					{
						this.gameObject.GetComponent<SproutAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Nymph
					if (this.gameObject.tag == "Nymph")
					{
						this.gameObject.GetComponent<NymphAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Dryad
					if (this.gameObject.tag == "Dryad")
					{
						this.gameObject.GetComponent<DryadAnimation>().moveBA_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
									
					// Nix
					if (this.gameObject.tag == "Nix")
					{
						this.gameObject.GetComponent<NixAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
						
					}
					
					// Draug
					if (this.gameObject.tag == "Draug")
					{
						this.gameObject.GetComponent<DraugAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
						
					}
					
					// Dragon
					if (this.gameObject.tag == "Dragon")
					{
						//this.gameObject.GetComponent<NixAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.HalflingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();

						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
						
						GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
						
					}
					
					// Leech
					if (this.gameObject.tag == "Leech")
					{
						transform.gameObject.GetComponent<LeechAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
											
						GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Leshy
					if (this.gameObject.tag == "Leshy")
					{
						transform.gameObject.GetComponent<LeshyAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Lurker
					if (this.gameObject.tag == "Lurker")
					{
						transform.gameObject.GetComponent<LurkerAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
				
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// DHound
					if (this.gameObject.tag == "DHound")
					{
						transform.gameObject.GetComponent<DHoundAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
						
						// change collider tag name
					//	transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Fenrir
					if (this.gameObject.tag == "Fenrir")
					{
						transform.gameObject.GetComponent<FenrirAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
						
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Hell Hound
					if (this.gameObject.tag == "HellHound")
					{
						transform.gameObject.GetComponent<HellHoundAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
						
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Sprite
					if (this.gameObject.tag == "Sprite")
					{
						transform.gameObject.GetComponent<SpriteAnimation>().moveAB_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						popUpInfoScript.TrainingGroundCreature();
						
						transform.gameObject.renderer.enabled = true;
						
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Sprite
					if (this.gameObject.tag == "Imp")
					{
						transform.gameObject.GetComponent<ImpAnimation>().moveBA_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
					// Sprite
					if (this.gameObject.tag == "Djinn")
					{
						transform.gameObject.GetComponent<DjinnAnimation>().moveBA_Bool = true;
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
						Destroy(transform.FindChild("ProgressBar").gameObject);
						
						//indra get xp value from server
						GameObject xpValObj = Instantiate(Resources.Load("xpValue"), transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

						Destroy(this);
						
						popUpInfoScript.DarklingCreaturesAchivement();
						popUpInfoScript.CreaturesAchivement();
						
						transform.gameObject.renderer.enabled = true;
						
						// change collider tag name
						//transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this);
												
						GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
						tg.transform.FindChild("Spark").gameObject.active = false;
						tg.transform.FindChild("Spark1").gameObject.active = false;
						tg.transform.FindChild("Spark2").gameObject.active = false;
						tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
						if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
						{
							popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
						}
					}
					
//======================================================================================================================================================================
					
					// GOBLIN CAVE
					if (this.gameObject.tag == "goblinCamp" || this .gameObject.tag == "OrgCave" || this.gameObject.tag == "TrollHouse")
					{
						popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
						Destroy(this.gameObject);
						GameManager.currentCreature.SetActiveRecursively(true);
						
						if (this.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_01")
						{
							GameManager.houndUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hGC_Creature = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
							hGC_Creature.GetComponent<MeshRenderer>().enabled = true;
							hGC_Creature.transform.FindChild("shadow").gameObject.active = true;
						}
						if (this.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_02")
						{
							GameManager.sproutUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hGC_Creature = GameObject.Find("HC_C_Sprout_GO(Clone)") as GameObject;
							hGC_Creature.GetComponent<MeshRenderer>().enabled = true;
							hGC_Creature.transform.FindChild("shadow").gameObject.active = true;
							
							inventoryInfo.RemoveItem(taskDetailsInfo.Four_Half_task3);
							taskDetailsInfo.Four_Half_task3_bool = true;
			
						}
						if (this.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_03")
						{
							GameManager.bargUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hGC_Creature = GameObject.Find("HC_C_Barg_GO(Clone)") as GameObject;
							hGC_Creature.GetComponent<MeshRenderer>().enabled = true;
							hGC_Creature.transform.FindChild("shadow").gameObject.active = true;
							
							inventoryInfo.RemoveItem(taskDetailsInfo.Six_Half_task4);
							taskDetailsInfo.Six_Half_task4_bool = true;
						}
						if(this.gameObject.name == "HC_B_TrollHouse_GO(Clone)_01")
						{
							GameManager.nixUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hTC01_Creature = GameObject.Find("HC_C_Nix_GO(Clone)") as GameObject;
							hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
							
							inventoryInfo.RemoveItem(taskDetailsInfo.Eight_Half_task3);
							taskDetailsInfo.Eight_Half_task3_bool = true;
						}
						if(this.gameObject.name == "HC_B_TrollHouse_GO(Clone)_02")
						{
							GameManager.nymphUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hTC01_Creature = GameObject.Find("HC_C_Nymph_GO(Clone)") as GameObject;
							hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
							hTC01_Creature.transform.FindChild("shadow").gameObject.active = true;
							
							inventoryInfo.RemoveItem(taskDetailsInfo.Ten_Half_task4);
							taskDetailsInfo.Ten_Half_task4_bool = true;
						}
						if(this.gameObject.name == "HC_B_TrollHouse_GO(Clone)_03")
						{
							GameManager.draugUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject hTC01_Creature = GameObject.Find("HC_C_Draug_GO(Clone)") as GameObject;
							hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
							
							inventoryInfo.RemoveItem(taskDetailsInfo.Twelve_Half_task4 );
							taskDetailsInfo.Twelve_Half_task4_bool = true;
						}
						if (this.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_01")
						{
							GameManager.leechUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dGC01_Creature = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
							dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
							
							inventory1Info.RemoveItem1(taskDetailsInfo.Five_Dark_task5);
							taskDetailsInfo.Five_Dark_task5_bool = true;
						}
						if (this.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_02")
						{
							GameManager.dHoundUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dGC01_Creature = GameObject.Find("DL_C_DHound_GO(Clone)") as GameObject;
							dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
							dGC01_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							inventory1Info.RemoveItem1(taskDetailsInfo.Seven_Dark_task3);
							taskDetailsInfo.Seven_Dark_task3_bool = true;
						}
						if (this.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_03")
						{
							GameManager.spriteUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dGC01_Creature = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
							dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
							
							inventory1Info.RemoveItem1(taskDetailsInfo.Nine_Dark_task2);
							taskDetailsInfo.Nine_Dark_task2_bool = true;
						}
						if (this.gameObject.name == "DL_B_TrollHouse_GO(Clone)_01")
						{
							GameManager.leshyUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dTC01_Creature = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
							dTC01_Creature.GetComponent<MeshRenderer>().enabled = true;
							
							inventory1Info.RemoveItem1(taskDetailsInfo.Eleven_Dark_task2);
							taskDetailsInfo.Eleven_Dark_task2_bool = true;
						}
						if (this.gameObject.name == "DL_B_TrollHouse_GO(Clone)_02")
						{
							GameManager.fenrirUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dTC01_Creature = GameObject.Find("DL_C_Fenrir_GO(Clone)") as GameObject;
							dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
							dTC01_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = false;
						}
						if (this.gameObject.name == "DL_B_TrollHouse_GO(Clone)_03")
						{
							GameManager.impUsingBool = false;
							popUpInfoScript.EnemyCaveBuildings();
							GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
							tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							GameObject dTC01_Creature = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
							dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						}
					}
					
//======================================================================================================================================================================
					
					// HALFLING BUILING
					if (this.gameObject.tag == "Inn")
					{
						buildingProgressBar(upgradeTextureInfo.InnLevel_1, "HW", true, true,
						                    popUpInfoScript.scr_GameObjSvr.objInn.objTypeId);
					}
					
					if (this.gameObject.tag == "Stable")
					{
						buildingProgressBar(upgradeTextureInfo.h_Stable1, "HW", false, true,
						                    popUpInfoScript.scr_GameObjSvr.objHalflingStable.objTypeId);
					}
					
					if (this.gameObject.tag == "BlackSmith")
					{
						buildingProgressBar(upgradeTextureInfo.h_BlackSmith, "HW", true, true,
						                    popUpInfoScript.scr_GameObjSvr.objBlackSmith.objTypeId);
					}
					
					if (this.gameObject.tag == "Tavern")
					{
						popUpInfoScript.tavernBuilding();
						buildingProgressBar(upgradeTextureInfo.h_Tavern, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objTavern.objTypeId);
					}
					
					if (this.gameObject.tag == "Apothecary")
					{
						buildingProgressBar(upgradeTextureInfo.h_Apothecary, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objApothecary.objTypeId);
						 						ad.percentComplete23 = 100;
					}
					
					if (this.gameObject.tag == "EarthObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.h_EarthObelisk, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objEarthobelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
					}
					
					if (this.gameObject.tag == "PlantObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.h_PlantObelisk, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objPlantObelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
					}
					
					if (this.gameObject.tag == "WaterObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.h_WaterObelisk, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objWaterObelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
					}
					
					if (this.gameObject.tag == "SunShrine")
					{
						popUpInfoScript.ShrineBuildings();
						buildingProgressBar(upgradeTextureInfo.h_SunShrine, "HW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objSunshrine.objTypeId);
					}
					
					// DARKLING BUILDING
					if (this.gameObject.tag == "DInn")
					{
						buildingProgressBar(upgradeTextureInfo.dInnLevel1, "DW", true, true,
						                    popUpInfoScript.scr_GameObjSvr.objDarkLingInn.objTypeId);
					}
					
					if (this.gameObject.tag == "DStable")
					{
						buildingProgressBar(upgradeTextureInfo.d_Stable1, "DW", false, true,
						                    popUpInfoScript.scr_GameObjSvr.objDarkingStable.objTypeId);
					}
					
					if (this.gameObject.tag == "DBlackSmith")
					{
						buildingProgressBar(upgradeTextureInfo.d_BlackSmith, "DW", true, true,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingSmith.objTypeId);
					}
					
					if (this.gameObject.tag == "DTavern")
					{
						popUpInfoScript.tavernBuilding();
						buildingProgressBar(upgradeTextureInfo.d_Tavern, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingtavern.objTypeId);
					}
					
					if (this.gameObject.tag == "DApothecary")
					{
						buildingProgressBar(upgradeTextureInfo.d_Apothecary, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingApothecary.objTypeId);
					}
					
					if (this.gameObject.tag == "DEarthObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.d_EarthObelisk, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingEarthObelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
					}
					
					if (this.gameObject.tag == "DSwampObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.d_SwampObelisk, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingSwampObelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
					}
					
					if (this.gameObject.tag == "DFireObelisk")
					{
						popUpInfoScript.ObelisksBuild();
						buildingProgressBar(upgradeTextureInfo.d_FireObelisk, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objDarklingFireObelisk.objTypeId);
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
						transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
						transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
					}
					
					if (this.gameObject.tag == "MoonShrine")
					{
						popUpInfoScript.ShrineBuildings();
						buildingProgressBar(upgradeTextureInfo.d_MoonShrine, "DW", false, false,
						                    popUpInfoScript.scr_GameObjSvr.objMoonShrine.objTypeId);
					}
					
					if (this.gameObject.name == "Bridge_GO(Clone)")
					{
						GameObject bridgeRabbitObj = GameObject.Find("Bridge_GO(Clone)") as GameObject;
						
						if (bridgeRabbitObj != null)
							Destroy(bridgeRabbitObj);
						
						GameObject bridgeObj = GameObject.Find("BridgeBroken_GO") as GameObject;
						
						if (bridgeObj != null)
						{
							bridgeObj.renderer.material.mainTexture = upgradeTextureInfo.bridgeTex;
							Destroy(bridgeObj.GetComponent<blinking>());
							bridgeObj.renderer.enabled = true;
						}
						
						CameraControl.newArea = 0;//-17158.5f;
						GameObject bridge = GameObject.Find("BridgeBroken_GO") as GameObject;
						GameObject bridgeCol = GameObject.Find("bridgeCollider") as GameObject;
						guiControlInfo.EnableDarkling(guiControlInfo.DarklingUIbtn,true);
						GameManager.unlockDarklingBool = true;
						if (bridgeCol != null)
						{
							bridgeCol.active = false;
						}
					}
				}
			}
		}
	}
	
	void plantProgressBar(Texture plantTex)
	{
		popUpInfoScript.plantHerbsHarvestCount();
						
		transform.gameObject.GetComponent<plantBurn>().enabled = true;
		popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
		Destroy(transform.gameObject.transform.FindChild("RabbtiButton").gameObject);
		Destroy(transform.FindChild("ProgressBar").gameObject);
		Destroy(this);
						
		transform.gameObject.renderer.material.mainTexture = plantTex;
		transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
		
		Destroy(this);
	}
	
	void buildingProgressBar(Texture buildingTex, string type, bool smokeParticleBool, bool goldProduceBool, int objectID)
	{
		if (type == "HW")
		{
			GameManager.hBuildingConstructBool = true;
			popUpInfoScript.halflinGolumDisable();
		}
		else if (type == "DW")
		{
			GameManager.dBuildingConstructBool = true;
			popUpInfoScript.DarklinGolumDisable();
		}
						
		if (goldProduceBool)		
			popUpInfoScript.GoldProducingBuildings();
		
		if (smokeParticleBool)
			transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
		
		popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
		transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		
		// request for xp
		popUpInfoScript.scr_loadUserWorld.ReturnXPcostTotal(objectID, transform.gameObject);
			//scr_loadUserWorld.ReturnXPcostTotal(objTypeID, innTemp);scr_GameObjSvr.objDarklingtavern.objTypeId

		Destroy(this);
		
		transform.gameObject.renderer.material.mainTexture = buildingTex;
		
		transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		
		Destroy(this);
	}
	
	void CreatureProgressBar(bool moveAB_bool)
	{
		transform.gameObject.GetComponent<DHoundAnimation>().moveAB_Bool = true;
		
		popUpInfoScript.destroyPopUp(GameManager.popUpCount, 2);
		Destroy(this.gameObject.transform.FindChild("RabbtiButton").gameObject);
		Destroy(transform.FindChild("ProgressBar").gameObject);
		
		transform.gameObject.GetComponent<getXP>().xpAnimBool = true;
		transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
		
		Destroy(this);
		
		popUpInfoScript.DarklingCreaturesAchivement();
		popUpInfoScript.CreaturesAchivement();
		popUpInfoScript.TrainingGroundCreature();
		
		transform.gameObject.renderer.enabled = true;
						
		Destroy(this);
								
		GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
		tg.transform.FindChild("Spark").gameObject.active = false;
		tg.transform.FindChild("Spark1").gameObject.active = false;
		tg.transform.FindChild("Spark2").gameObject.active = false;
		tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		
		if(popUpInfoScript.scr_audioController.audio_sparkBirth.isPlaying)
		{
			popUpInfoScript.scr_audioController.audio_sparkBirth.Stop();
		}
	}
}
