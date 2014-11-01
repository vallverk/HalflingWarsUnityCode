using UnityEngine;
using System.Collections;
using System;

public class HealthProgressBar : MonoBehaviour 
{
	public Transform progressBarPov;
	
	public float seconds;
	public double SecCnt;
	public int cnt;
	public GameObject attackCreature;
	public Vector3 caveCreaturePosOld;
	
	private SfsRemote scr_SfsRemote;
	
	public float totalTime = 0;
	
	private Transform col;
	
	private float waitTime = 1f;
	
	private float remainTime;
	public bool isProgressBarIncreasing;
	public UpgradeTexture upgradeTextureInfo;
	public upgradeProgressBar scr_UpgradeProgressBar;
	public GameManager scr_GameManager;
	public GameObject parOrcAttackEff;
	
	// Use this for initialization
	void Start () 
	{	
		StartCoroutine(updateProgressBar());
		StartCoroutine(updateSeconds());
		//Debug.Log(this.gameObject.name + " Start time = "+SecCnt);
		scr_GameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>() as GameManager;

		scr_UpgradeProgressBar = this.gameObject.GetComponent<upgradeProgressBar>();
		
		progressBarPov = this.gameObject.transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("ProgressBarPov") as  Transform;
		
		col = transform.FindChild("Isometric_Collider") as Transform;
		transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfoTG.panelMoveIn = true;
		objPanelInfoTG.panelMoveOut = false;
		
		// hide move panel
		objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
		movePanelInfo.panelMoveIn = true;
		movePanelInfo.panelMoveOut = false;
		
		// hide plant panel
		objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;
		
		if (totalTime != 0)
		{
			remainTime = ((float)SecCnt / totalTime); 
			progressBarPov.transform.localScale = new Vector3(remainTime,
																progressBarPov.transform.localScale.y,
																progressBarPov.transform.localScale.z);
		}
		
		upgradeTextureInfo = GameObject.Find("GameManager").GetComponent("UpgradeTexture") as UpgradeTexture;

	}

	public void createOrcEffect()
	{

		Invoke ("PlayParticle", 0.5f);

	}


	void PlayParticle()
	{

		Debug.Log("```````````````` " + transform.gameObject.name);
		if (transform != null)
		{
			parOrcAttackEff = Instantiate(scr_GameManager.par_OrcAttack_PF, transform.position, Quaternion.Euler(330, 0, 0)) as GameObject;
			if(parOrcAttackEff!=null)parOrcAttackEff.GetComponent<ParticleSystem>().Play();
			
			else return;
		}

	}
	
	void LateUpdate()
	{	
		if (seconds != 0)
		{
			if (progressBarPov != null)
			{
				if (progressBarPov.localScale.x >= 0)
				{
					if(isProgressBarIncreasing)
					{
						progressBarPov.localScale = new Vector3(progressBarPov.localScale.x + 0.1f * Time.deltaTime,
																progressBarPov.localScale.y,
																progressBarPov.localScale.z);
						
						//StopAllCoroutines();
						
						if(progressBarPov.transform.localScale.x > 1f)
						{
//							Destroy(this);
//							Destroy(parOrcAttackEff);
//							transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
//							transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							OriginalTexture(this.gameObject);		//Amogh
						}
					}
				}
			}
		}
		
		// change destruction textures
		changeDestructionTexture();
	}

	public void ResetProgressbarScale()
	{
		progressBarPov.localScale = new Vector3(1,1,1);
	}
	
	// change destruction textures function
	void changeDestructionTexture()
	{
		// change building texture
		if (transform.gameObject.tag == "Inn" || transform.gameObject.tag == "Apothecary" || transform.gameObject.tag == "BlackSmith" ||
			transform.gameObject.tag == "Stable" || transform.gameObject.tag == "SunShrine" || transform.gameObject.tag == "Tavern" ||
			transform.gameObject.tag == "DApothecary" || transform.gameObject.tag == "DBlackSmith" || transform.gameObject.tag == "DInn" ||
			transform.gameObject.tag == "MoonShrine" || transform.gameObject.tag == "DStable" || transform.gameObject.tag == "DTavern")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionBldg01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionBldg02_tex;
		}
		
		// change garden plot texture
		if (transform.gameObject.tag == "Plot" || transform.gameObject.tag == "DPlot")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionGarden01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionGarden02_tex;
		}
		
		// change earth training ground texture
		if (transform.gameObject.tag  == "TrainingGround")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionEarth01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionEarth02_tex;
		}

		if (transform.gameObject.tag == "DEarthTG")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionDarkEarth01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionDarkEarth02_tex;
		}
		
		// change plant training ground texture
		if (transform.gameObject.tag == "PlantTG")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionPlant01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionPlant02_tex;
		}
		
		// change fire training ground texture
		if (transform.gameObject.tag == "DFireTG")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionFire01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionFire02_tex;
		}
		
		// change water swamp training ground texture
		if (transform.gameObject.tag == "Swamp")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionSwamp01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionSwamp02_tex;
		}

		if (transform.gameObject.tag == "WaterTG")
		{
			if (progressBarPov.transform.localScale.x < 0.5f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionWater01_tex;
			
			if (progressBarPov.transform.localScale.x < 0.2f)
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.destructionWater02_tex;
		}
	}
	
	void OriginalTexture(GameObject attackedObject)			//Amogh
	{
		Debug.Log("attackedObject name : "+attackedObject.name);
		Debug.Log("attackedObject level : "+scr_UpgradeProgressBar.currentUpgradeLevel);
		switch(attackedObject.tag)
		{
			// ------------------Halfling Buildings --------------------//
		case "Inn" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.InnLevel3;
				break;
					
			default :
				break;
			}
			break;
			
		case "Apothecary" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_Apothecary;
			break;
			
		case "BlackSmith" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_BlackSmith;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_BlackSmith2;
				break;
		
			default :
				break;
			}
			break;
			
		case "Stable" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_Stable1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_Stable2;
				break;
			
			default :
				break;
			}
			break;
			
		case "SunShrine" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_SunShrine;
			break;
			
		case "Tavern" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.h_Tavern;
			break;
			
		// ------------------Halfling Training grounds --------------------//
			
		case "TrainingGround" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.earthTG1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.earthTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.earthTG3;
				break;
					
			default :
				break;
			}
			break;
			
		case "PlantTG" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plantTG1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plantTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plantTG3;
				break;
					
			default :
				break;
			}
			break;
			
		case "WaterTG" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.waterTG1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.waterTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.waterTG3;
				break;
					
			default :
				break;
			}
			break;
			
		// ------------------Halfling garden plots --------------------//	
		
		case "Plot" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel3;
				break;
					
			default :
				break;
			}
			break;
			
			
		// ------------------Darkling Buildings --------------------//
		case "DInn" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel_2;
				break;
				
			default :
				break;
			}
			break;
			
		case "DApothecary" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_Apothecary;
			break;
			
		case "DBlackSmith" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_BlackSmith;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dBlackSmith2;
				break;
		
			default :
				break;
			}
			break;
			
		case "DStable" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_Stable1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_Stable2;
				break;
			
			default :
				break;
			}
			break;
			
		case "MoonShrine" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_MoonShrine;
			break;
			
		case "DTavern" :
			attackedObject.renderer.material.mainTexture = upgradeTextureInfo.d_Tavern;
			break;
			
		// ------------------Darkling Training grounds --------------------//
			
		case "DEarthTG" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dEarthTF1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG3;
				break;
					
			default :
				break;
			}
			break;
			
		case "Swamp" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.swampTG1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.swampTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.swampTG3;
				break;
					
			default :
				break;
			}
			break;
			
		case "DFireTG" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.fireTG1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.fireTG2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.fireTG3;
				break;
					
			default :
				break;
			}
			break;
			
		// ------------------Darkling garden plots --------------------//	
		
		case "DPlot" :
			switch(scr_UpgradeProgressBar.currentUpgradeLevel)
			{
			case 1 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel1;
				break;
				
			case 2 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel2;
				break;
				
			case 3 :
				attackedObject.renderer.material.mainTexture = upgradeTextureInfo.plotLevel3;
				break;
					
			default :
				break;
			}
			break;
			
		default :
			break;
		}
	}
	
	IEnumerator updateProgressBar()
    {	
        while(true)
        {
			if (SecCnt == 0)
			{
				SecCnt = seconds;
			}
				
			if (cnt < seconds)
			{
				if (seconds != 0)
				{
					if (progressBarPov != null)
					{
						if (progressBarPov.localScale.x >= 0)
						{
//							Debug.Log("isProgressBarIncreasing updateProgressBar : "+isProgressBarIncreasing);
							if(!isProgressBarIncreasing)
							{
							progressBarPov.localScale = new Vector3(progressBarPov.localScale.x - (1f / seconds)/*0.00167f*/,
																	progressBarPov.localScale.y,
																	progressBarPov.localScale.z);
								
							if (col != null)
							{
								if (col.gameObject.tag != "attack")
									col.gameObject.tag = "attack";
							}
						}
					}
				}
				}
			}
			else
			{
				if(attackCreature != null)
				{
///***					Debug.Log("Object destroyed");
					//attackCreature.transform.position  = caveCreaturePosOld;				//commented
					attackCreature.gameObject.tag = "Untagged";
					
					attackCreature.renderer.enabled = false;									//was true before				//Enable default animation
					attackCreature.transform.FindChild("Walk_anim").renderer.enabled = false;				//Disable walk animation
					attackCreature.transform.FindChild("attack_anim").renderer.enabled = false;				//Disable attack animation
					
					//attackCreature.transform.localScale = new Vector3(1.111111f, 1.111111f, 1.666667f);			//commented
					
					attackCreature.AddComponent<CaveCreatureWalk>();								//Added
					CaveCreatureWalk caveCreatureWalkScript = attackCreature.GetComponent<CaveCreatureWalk>();
					caveCreatureWalkScript.caveCreature = attackCreature;
					caveCreatureWalkScript.targetPosition = caveCreaturePosOld;
				}
				Destroy(parOrcAttackEff);
				Destroy(this.gameObject);
			}
			cnt++;	
	
			yield return new WaitForSeconds(1);
		}
        
    }
	
	
	
	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
//				Debug.Log("isProgressBarIncreasing updateSeconds : "+isProgressBarIncreasing);
				if(!isProgressBarIncreasing)
	             SecCnt--;
				
				Transform remainTimeObj = transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime") as Transform;
			
				if (remainTimeObj != null)
				{
					if(!isProgressBarIncreasing)
						transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime").gameObject.GetComponent<SpriteText>().Text = (assignSecondstoTimespan((double)SecCnt)).ToString();
					else if(isProgressBarIncreasing)
						//transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime").renderer.enabled = false;
						transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime").GetComponent<MeshRenderer>().enabled = false;
				}
			}
			else if(SecCnt <= 0)
			{
			}
			
		    yield return new WaitForSeconds(1);
		}
	}
	
	private TimeSpan assignSecondstoTimespan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
}
