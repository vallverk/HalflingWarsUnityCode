using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;
using System.Collections.Generic;
using System;

public class LoadUserWorld : MonoBehaviour 
{
	
	public GameObject house_pref, hc_goblinCamp_pref, hc_trollHouse_pref,hc_OrgCave_pref, dl_goblinCamp_pref, dl_trollHouse_pref, dl_OrgCave_pref,dl_lurker,hl_dragon_pref,dl_DjInn_pref,dl_blackberry,dl_cloumbine,dl_Aven,dl_bitterbush,
					  trainingGrnd_pref,Hound_pref,dirtPath_pref,dl_house_pref,DarklingFireTrainingGrnd,Sprite_pref,halflingBlacksmith_pref,dl_golumPref,hl_cusith_pref,dl_hellhound_pref,hl_watercress,hl_potatoes,hl_fairlilly,dl_pumpkin,dl_herbBogbean,
	                  Plotgarden_pref,dl_MoonFlower,PlantTurnip_pref,Golum_pref,Inn_pref,PlanttrainingGrnd_pref,PlantPipeweed_pref,hl_lanternPref,hl_Nymph,hl_WaterObelsik_pref,dl_darklingFenrir_pref,hl_sunflower,hl_vervain,hl_mandrake,hl_costmary,dl_Tavern,dl_Apothecary,
	                  Sprout_pref,SwampTrainingGrnd_pref,Leech_pref,Tree2_pref,Pumpkin_pref,Well_pref,DarklingInn_pref,DarklingGarden_pref,hl_plantObelsik_pref,dl_darklingLeshy,dl_Imp_pref,hl_tavern_pref,hl_tree1,dl_Tree2_pref,
	                  Tree1_pref,dl_Herbwolfbane,WaterTrainingGrnd_pref,Nix_pref,Darkstable_pref,Halflingstable_pref,DarkearthTrainingGrnd_pref,hl_EarthObelsik_pref,dl_earthObelisk_pref,hl_dryad_pref,hl_Apothecary,
	                  Darkhound_pref,FirePepper_pref,DarklingDirtPath_pref,DarklingBog_pref,Barg_pref,DarklingBlacksmith_pref,dl_SwampObelsik_pref,dl_fireObelisk_pref,dl_draugh_pref,hl_Sunshrine,dl_Moonshrine,dl_ravenPerch,
	                  hl_Scarecrow,hl_partyTent,hl_knollHill,hl_Fence,hl_Cottage,hl_Cornfield,dl_Scarecrow,dl_huntingtent,dl_fence,dl_knollhill,dl_Birdhouse,hl_WheelBarrow,hl_Shroomery,hl_barrel,hl_well,hl_windmill,dl_windmill, bridgePB_pref;
	         
	
	private SfsRemote scr_sfsRemote;
	public UpgradeTexture scr_UpgradeTexture;
	private GameObject Temp;
	public GameManager scr_gameManager;
	public guiControl scr_guiControl;
	public popUpInformation scr_popUpInfo;
	public LevelControl scr_levelControl;
	public GameObjectsSvr scr_gameObjectSvr;
	public CreatureSystem scr_creatureSystem;
	public QuestTextureControl scr_QuestTexControl;
	
	private OrcAttackSystem scr_OrcAttackSystem;
	private taskDetails scr_taskDetails;
	
	private findPath fp;
	//public LevelControl scr_LevelControl;
	
	private bool runOnlyOnceBool = true;
	private int questCb = 0;

    private bool hGoblinCave01_bool = false,
        hGoblinCave02_bool = false,
        hGoblinCave03_bool = false,
        hOrgCave01_bool = false,
        hOrgCave02_bool = false,
        hOrgCave03_bool = false,
        hTrollCave01_bool = false,
        hTrollCave02_bool = false,
        hTrollCave03_bool = false,
        dGoblinCave01_bool = false,
        dGoblinCave02_bool = false,
        dGoblinCave03_bool = false,
        dOrgCave01_bool = false,
        dOrgCave02_bool = false,
        dOrgCave03_bool = false,
        dTrollCave01_bool = false,
        dTrollCave02_bool = false,
        dTrollCave03_bool = false;
	
	private Color curColor;
	public GameObject hGround, dGround;
	public int[] plantsArr = {5,8,213,229,233,220,27,51,55,53,36,45,47,49,202,238,240,235,231};
	
	private AchivementsDetails ad;
	
	private int hDirtPathCnt = 0;
	
	private float	creatureLayerTop = 0.0004f,
					creatureLayerMid = 0.0003f,
					creatureLayerBack = 0.0002f;
	
	public Material bridge_mat;
	public Texture bridge_tex;
	private int dirtPathCount = 0, dDirtPathCount = 0;

	private bool bridgeHandBool = true;
	
	void Awake()
	{
		//scripts Invoke 
		
		scr_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		scr_guiControl = GameObject.Find("GUIManager").GetComponent<guiControl>();
		scr_popUpInfo = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
		scr_levelControl = GameObject.Find("GameManager").GetComponent<LevelControl>();
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_UpgradeTexture = GameObject.Find("GameManager").GetComponent<UpgradeTexture>();
		scr_creatureSystem = GameObject.Find("GameManager").GetComponent<CreatureSystem>();
		scr_taskDetails = GameObject.Find("TaskDetails").GetComponent<taskDetails>();
	}
	
	// Use this for initialization
	void Start () {
		
		fp = (findPath)FindObjectOfType(typeof(findPath));
		ad= (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
		//scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		//AssingUserValuesFromServer();
	//	//Debug.Log("++++++++++++++++   " + GameManager.xp);
		//UnLockItemLoading();
		
		scr_OrcAttackSystem = GameObject.Find("GameManager").GetComponent<OrcAttackSystem>();
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(assignObjIdforOrcAttack)
		{
			assignObjIdforOrcAttack = false;
			
			for(int i= 0 ; i <  scr_sfsRemote.lst_OrgAttackTasks.Count  ; i++)
			{	
				GetattackedObjectsArray(scr_sfsRemote.lst_OrgAttackTasks[i].caveTypeId, 0 );
			}
		}
	}
	
	private Vector3 objPos;
	public Vector3 ReturnObjPositionForOrcattack(int objId)
	{
		for(int i=0; i< scr_sfsRemote.lst_ObjSvr.Count; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].objId.Equals(objId))
			{
				objPos = scr_sfsRemote.lst_ObjSvr[i].position;
				Debug.Log(objPos);
			}
		}
		
		return objPos;
	}
	
	public void ResetValues(double balanceXp,double maxXpforLevel,double currentlevelXp)
	{
		GameManager.xp = (float)currentlevelXp;
		GameManager.MaxLevelxp = (int)maxXpforLevel;
		GameManager.TotalLevelxp = (int)balanceXp;
	}

	public void AddLevelxpInfo(ISFSArray arr)
	{
		int size = arr.Size();
		ISFSObject lvlObj = null;
		
		for(int i = 0 ; i< size ; i++)
		{				
			SfsRemote.LevelXpinfo lvlInfo = new SfsRemote.LevelXpinfo();
			lvlObj = arr.GetSFSObject(i);
			lvlInfo.levelXp = (int) lvlObj.GetDouble("maxXp");
			lvlInfo.currentLevel = lvlObj.GetInt("level");
			
			scr_sfsRemote.lst_LevelXpInfo.Add(lvlInfo);
		}
		
	    if(scr_sfsRemote.isUserWorld)
	    {    
		    scr_sfsRemote.RunOnce();
		    scr_sfsRemote.SendRequestforChildCount();
		    scr_sfsRemote.isUserWorld = false;
		
		    if(GameManager.gameLevel != 0)
		    {
		    AudioController.EnableEnviron = true;
		    }
	    }   
	}
	

	public void AssingUserValuesFromServer(int darklingopen,int storyCnt,int no_task,double balance_gold,
		                                   double balance_xp,double maxlevelxp,double currentLevelxp,
		                                   int food,int dnSavings,int quest,int level,int no_popup,
		                                   int currntPopup, double spark)
	{
		if(popUpInformation.isScoreUpdate)
		{
			GameManager.coins = (int)balance_gold;
		    scr_guiControl.goldCoinScoreInfo.Text = GameManager.coins.ToString();
				
			PlayerPrefs.SetFloat("goldvaiue",(float)(GameManager.coins));
			 			ad.percentComplete37 = (int)(0.0001f * PlayerPrefs.GetFloat("goldvaiue"));
			
			GameManager.food = food;
			scr_guiControl.plantsScoreInfo.Text = GameManager.food.ToString();
			
		    GameManager.sparks = (int)spark;
			scr_guiControl.sparkScoreInfo.Text = GameManager.sparks.ToString();
			
			GameManager.TotalLevelxp = (int)balance_xp;
			
			GameManager.MaxLevelxp = (int)maxlevelxp;
			
		    GameManager.xp = (float)currentLevelxp;
			popUpInformation.isScoreUpdate = false;
		}
		else
		{
			GameManager.coins = (int)balance_gold;
			scr_guiControl.goldCoinScoreInfo.Text = GameManager.coins.ToString();
			
			GameManager.food = food;
			GameManager.plants = food;
			
			scr_guiControl.plantsScoreInfo.Text = GameManager.plants.ToString();
			
		    GameManager.sparks = (int)spark;
			scr_guiControl.sparkScoreInfo.Text = GameManager.sparks.ToString();
			
			GameManager.TotalLevelxp = (int)balance_xp;
			
			GameManager.MaxLevelxp = (int)maxlevelxp;
		
		    GameManager.xp = (float)currentLevelxp;
	
			GameManager.gameLevel = level;
			
			UnlockHalflingGardenPlots(GameManager.gameLevel);
			UnlockdarklingGardenPlots(GameManager.gameLevel);
			
			// first time game generate story
			if (GameManager.gameLevel == 0)
			{
				//wizard sounds enable
				scr_popUpInfo.scr_audioController.audio_wizardMaster.Play();
				scr_popUpInfo.scr_audioController.audio_wizardMaster.minDistance = 1;
				scr_popUpInfo.scr_audioController.audio_wizardMaster.maxDistance = 300;
				scr_popUpInfo.scr_audioController.audio_wizardMaster.volume = 0.8f;
				
				scr_gameManager.loadingBool = false;
				scr_gameManager.bubbleObj.SetActiveRecursively(true);
				scr_gameManager.speakTextObj.active = true;
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Greetings friend!  And welcome to the Crest!");
			}
			else
			{
				if (GameManager.questRunningBool == false)
				{
					scr_guiControl.popUpType4.SetActiveRecursively(false);
					scr_guiControl.popUpType5.SetActiveRecursively(false);
				}
			}
			
			GameManager.curLevel = level;
			
			GameManager.storyCnt = storyCnt;
			
			scr_popUpInfo.curPopUpCnt = currntPopup;
			GameManager.popUpCount = no_popup;
			GameManager.taskCount = no_task;
			
			scr_guiControl.levelScoreInfo.Text = GameManager.gameLevel.ToString();
		
			if(darklingopen == 1)
			{
				//GameManager.unlockDarklingBool = true;
				CameraControl.newArea = 0;//-17158.5f;
				GameObject bridge = GameObject.Find("BridgeBroken_GO") as GameObject;
				GameObject bridgeCol = GameObject.Find("bridgeCollider") as GameObject;
				scr_guiControl.EnableDarkling(scr_guiControl.DarklingUIbtn,true);
				
				if (bridgeCol != null)
				{
					bridgeCol.active = false;
					bridge.renderer.material.mainTexture = scr_UpgradeTexture.bridgeTex;
				}
			}
			else
			{
			    //GameManager.unlockDarklingBool = false;
				Debug.Log("disable-------------------->>>>>>> " + GameManager.unlockDarklingBool);
				if (!GameManager.unlockDarklingBool)
					scr_guiControl.EnableDarkling(scr_guiControl.DarklingUIbtn,false);
			}
			
			if(scr_sfsRemote.isUserWorld)
			{
			  GameManager.quest = quest;
			}
		}
	}
	
	public double ReturnSparkCostTotal(int typeId)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_GameObjectsDb.Count; i++)
		{
			if(scr_sfsRemote.lst_GameObjectsDb[i].ObjectTypeId.Equals(typeId))
			{
				return scr_sfsRemote.lst_GameObjectsDb[i].spark_cost;
			}
		}
		
		return -1;
	}
	
	private bool ChkIsPlants(int typeId)
	{
		for(int i=0 ; i< plantsArr.Length ; i++)
		{
			if(plantsArr[i].Equals(typeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	public GameObject attackTimer;
	public float attackTym;
	private int caveId;
	private bool isHalfling, isDarkling;
	public void AttachTimerforObjectsforCaves(int CaveTypeid,int Caveobjid)						//---- Attach cave timer while resuming game ------ //
	{
		//Debug.Log("Cave typeId :" + CaveTypeid);
		caveId = CaveTypeid;
		switch(CaveTypeid)
		{
			//<<<<<<<<<<<<<<<-------------- Halfling Caves ---------------->>>>>>>>>>>>>>>//
			
		case 101:			//HL_Goblin_01
			
			break;
			
		case 102:			//HL_Goblin_02
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
			
			//orcTimer.GetComponent<SpriteText>().Text = orcTimer.assignSecToTimeSpan(orcTimer.SecCnt).ToString();
			
		}	
			break;
			
		case 103:			//HL_Goblin_03
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 104:			//HL_Org_01
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_OrgCave_GO(Clone)_01");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("OrgChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("OrgChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 105:			//HL_Org_02
			
			break;
			
		case 106:			//HL_Org_03
			
			break;
			
			
		case 107:			//HL_Troll_01
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}
			break;
		
		case 108:			//HL_Troll_02
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}
			break;
			
		case 109:			//HL_Troll_03
		{
			scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}
			break;
			
			
		//<<<<<<<<<<<<<<<-------------- Darkling Caves ---------------->>>>>>>>>>>>>>>//	
			
			
		case 111:		//DGloblin_01
		{
			scr_OrcAttackSystem.cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);

			if (scr_OrcAttackSystem.cave.transform.localScale.x < 0)
				scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(scr_OrcAttackSystem.caveTimer.transform.localScale.x * -1,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.y,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.z);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 112:		//DGloblin_02
		{
			scr_OrcAttackSystem.cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);

			if (scr_OrcAttackSystem.cave.transform.localScale.x < 0)
				scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(scr_OrcAttackSystem.caveTimer.transform.localScale.x * -1,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.y,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.z);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}		
			break;	
			
		case 113:		//DGloblin_03
		{
			scr_OrcAttackSystem.cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);

			if (scr_OrcAttackSystem.cave.transform.localScale.x < 0)
				scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(scr_OrcAttackSystem.caveTimer.transform.localScale.x * -1,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.y,
				                                                                 scr_OrcAttackSystem.caveTimer.transform.localScale.z);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 114:		//DOrg_01
		
			break;
			
		case 115:		//DOrg_02
			
			break;	
			
		case 116:		//DOrg_03
			
			break;
			
		case 117:		//DTroll_01
		{
			scr_OrcAttackSystem.cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 118:		//DTroll_02
		{
			scr_OrcAttackSystem.cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}	
			break;
			
		case 119:		//DTroll_03
		{
			scr_OrcAttackSystem.cave = 	GameObject.Find("DL_B_TrollHouse_GO(Clone)_03");
			GameObject caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
			GameObject caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.cave.AddComponent<OrcAttackTimer>();
			scr_OrcAttackSystem.caveTimer = Instantiate(scr_OrcAttackSystem.attackTimer, new Vector3(scr_OrcAttackSystem.cave.transform.position.x, scr_OrcAttackSystem.cave.transform.position.y, scr_OrcAttackSystem.cave.transform.position.z + 4f), scr_OrcAttackSystem.attackTimer.transform.rotation) as GameObject;
			scr_OrcAttackSystem.caveTimer.transform.parent = scr_OrcAttackSystem.cave.transform;
			
			GameObject cooldownObject = scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject;			//Added
			scr_OrcAttackSystem.caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);
			scr_OrcAttackSystem.caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
			
			OrcAttackTimer orcTimer = scr_OrcAttackSystem.cave.GetComponent<OrcAttackTimer>();
			orcTimer.SecCnt = ReturnSecondsfromTasks(Caveobjid);	
			orcTimer.cave = scr_OrcAttackSystem.cave;
			orcTimer.caveCreature01 = caveCreature_01;
			orcTimer.caveCreature02 = caveCreature_02;
		}
			
			break;	
			
		default :
			
			break;
		}
	}
	
	public bool assignObjIdforOrcAttack;
	public float GetattackTym()
	{
		return attackTym;
	}
			
	public void GetCaveCreatures(int CaveTypeid, bool isThreshold)								//---- Get cave creatures to attack the buildings ---- //
	{
		if(!isThreshold)
	{
		switch(CaveTypeid)
		{
			//<<<<<<<<<<<<<<<-------------- Halfling Caves ---------------->>>>>>>>>>>>>>>//
			
		case 101:			//HL_Goblin_01
			
			break;
			
		case 102:			//HL_Goblin_02
		
			GameObject hlGoblinCave_02 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02");
			
			scr_OrcAttackSystem.caveCreature_01 = hlGoblinCave_02.transform.FindChild("GoblinChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlGoblinCave_02.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlGoblinCave_02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 103:			//HL_Goblin_03
			
			GameObject hlGoblinCave_03 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03");
			
			scr_OrcAttackSystem.caveCreature_01 = hlGoblinCave_03.transform.FindChild("GoblinChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlGoblinCave_03.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlGoblinCave_03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 104:			//HL_Org_01
		
			GameObject hlOrgCave_01 = 	GameObject.Find("HC_B_OrgCave_GO(Clone)_01");
			
			scr_OrcAttackSystem.caveCreature_01 = hlOrgCave_01.transform.FindChild("OrgChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlOrgCave_01.transform.FindChild("OrgChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlOrgCave_01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 105:			//HL_Org_02
			
			break;
			
		case 106:			//HL_Org_03
			
			break;
			
		case 107:			//HL_Troll_01
		
			GameObject hlTrollCave_01 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01");
			
			scr_OrcAttackSystem.caveCreature_01 = hlTrollCave_01.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlTrollCave_01.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlTrollCave_01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
		
		case 108:			//HL_Troll_02
		
			GameObject hlTrollCave_02 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02");
			
			scr_OrcAttackSystem.caveCreature_01 = hlTrollCave_02.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlTrollCave_02.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlTrollCave_02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 109:			//HL_Troll_03
		
			GameObject hlTrollCave_03 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03");
			
			scr_OrcAttackSystem.caveCreature_01 = hlTrollCave_03.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = hlTrollCave_03.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			hlTrollCave_03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
					
		//<<<<<<<<<<<<<<<-------------- Darkling Caves ---------------->>>>>>>>>>>>>>>//	
			
			
		case 111:		//DGloblin_01
		
			GameObject dlGloblinCave_01 = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01");
			
			scr_OrcAttackSystem.caveCreature_01 = dlGloblinCave_01.transform.FindChild("GoblinChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlGloblinCave_01.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlGloblinCave_01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;	
			
		case 112:		//DGloblin_02
		
			GameObject dlGloblinCave_02 = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02");
			
			scr_OrcAttackSystem.caveCreature_01 = dlGloblinCave_02.transform.FindChild("GoblinChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlGloblinCave_02.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlGloblinCave_02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 113:		//DGloblin_03
		
			GameObject dlGloblinCave_03 = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03");
			
			scr_OrcAttackSystem.caveCreature_01 = dlGloblinCave_03.transform.FindChild("GoblinChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlGloblinCave_03.transform.FindChild("GoblinChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlGloblinCave_03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 114:		//DOrg_01
		
			break;
			
		case 115:		//DOrg_02
			
			break;	
			
		case 116:		//DOrg_03
			
			break;
			
		case 117:		//DTroll_01
		
			GameObject dlTrollCave_01 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01");
			
			scr_OrcAttackSystem.caveCreature_01 = dlTrollCave_01.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlTrollCave_01.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlTrollCave_01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
		case 118:		//DTroll_02
		
			GameObject dlTrollCave_02 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02");
			
			scr_OrcAttackSystem.caveCreature_01 = dlTrollCave_02.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlTrollCave_02.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlTrollCave_02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;	
		
		case 119:		//DTroll_03
		
			GameObject dlTrollCave_03 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_03");
			
			scr_OrcAttackSystem.caveCreature_01 = dlTrollCave_03.transform.FindChild("TrollChar01").gameObject;
			scr_OrcAttackSystem.caveCreature_02 = dlTrollCave_03.transform.FindChild("TrollChar02").gameObject;
			
			scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
			scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
			
			dlTrollCave_03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
			
			break;
			
			
		default :
			break;
		}
				}
		else if(isThreshold)
		{
			switch(CaveTypeid)
			{
				//<<<<<<<<<<<<<<<-------------- Halfling Caves ---------------->>>>>>>>>>>>>>>//
				
			case 101:			//HL_Goblin_01
				
				break;
				
			case 102:			//HL_Goblin_02
			
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 103:			//HL_Goblin_03
				
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 104:			//HL_Org_01
			
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_OrgCave_GO(Clone)_01");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("OrgChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("OrgChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 105:			//HL_Org_02
				
				break;
				
			case 106:			//HL_Org_03
				
				break;
				
			case 107:			//HL_Troll_01
			
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
			
			case 108:			//HL_Troll_02
			
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 109:			//HL_Troll_03
			
				scr_OrcAttackSystem.cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
						
			//<<<<<<<<<<<<<<<-------------- Darkling Caves ---------------->>>>>>>>>>>>>>>//	
				
				
			case 111:		//DGloblin_01
			
				scr_OrcAttackSystem.cave = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;	
				
			case 112:		//DGloblin_02
			
				scr_OrcAttackSystem.cave = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 113:		//DGloblin_03
			
				scr_OrcAttackSystem.cave = 	GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("GoblinChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 114:		//DOrg_01
			
				break;
				
			case 115:		//DOrg_02
				
				break;	
				
			case 116:		//DOrg_03
				
				break;
				
			case 117:		//DTroll_01
			
				scr_OrcAttackSystem.cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
			case 118:		//DTroll_02
			
				scr_OrcAttackSystem.cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;	
			
			case 119:		//DTroll_03
			
				scr_OrcAttackSystem.cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_03");
				
				scr_OrcAttackSystem.caveCreature_01 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar01").gameObject;
				scr_OrcAttackSystem.caveCreature_02 = scr_OrcAttackSystem.cave.transform.FindChild("TrollChar02").gameObject;
				
				scr_OrcAttackSystem.currentCreature_01Pos = scr_OrcAttackSystem.caveCreature_01.transform.position;
				scr_OrcAttackSystem.currentCreature_02Pos = scr_OrcAttackSystem.caveCreature_02.transform.position;
				
				scr_OrcAttackSystem.cave.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(true);		//Amogh
				
				break;
				
				
			default :
				break;
			}	
		}
	}
	
	
	
	private int beforeCaveId,afterCaveId;
	public void AddOrgCaveTasks(ISFSObject attackobj)							//---- Check for cave attack time or building destroy time when user resumes the game ----- //
	{
		SfsRemote.OrcAttackTasks orcAttack = new SfsRemote.OrcAttackTasks();
		orcAttack.attackedObjId = attackobj.GetInt("attackedObjId");			//--- building ID = xxxx ---- //
		orcAttack.attackTaskId = attackobj.GetUtfString("attackTaskId");	
		orcAttack.creationTime = attackobj.GetInt("creationTime");				//---- initial Time ---- //
		orcAttack.caveId = attackobj.GetInt("caveId");							//--- cave Id = xxxx ---//
		orcAttack.task_end_time = attackobj.GetLong("task_end_time");			//---- cave Time ---- //
		orcAttack.caveorObj = attackobj.GetInt("caveorobj");					//---- 0 = cave Resume..... 1 = Building Resume ----- //
		orcAttack.caveTypeId = attackobj.GetInt("caveTypeId");					//---- cave Type Id = xxx ---- //
		orcAttack.attackedTypedId = attackobj.GetInt("attackedObjTypeId");		//------ building Type Id = xx ---- //
		
		scr_sfsRemote.lst_OrgAttackTasks.Add(orcAttack);
		
		Debug.Log("Task Count : " + scr_sfsRemote.lst_OrgAttackTasks.Count + " Attack Type :"  + orcAttack.caveorObj);
		Debug.Log("taskEndTime : "+orcAttack.task_end_time);
		
		if(orcAttack.caveorObj == 0) 											//---- Cave Resume Time ------ //
		{
			Debug.Log(" ** Cave ** Cave Type ID = "+ReturnTypeIdfromObjId(orcAttack.caveId));
	
			//GetCaveCreatures(ReturnTypeIdfromObjId(orcAttack.caveId));	
			GetCaveCreatures(ReturnTypeIdfromObjId(orcAttack.caveId), false);
			AttachTimerforObjectsforCaves(ReturnTypeIdfromObjId(orcAttack.caveId),orcAttack.caveId);
			
			if(scr_OrcAttackSystem.cave != null)
			{
				scr_OrcAttackSystem.cave.transform.FindChild("caveEffect").renderer.enabled = true;
				scr_OrcAttackSystem.caveCreature_01.renderer.enabled = false;
				scr_OrcAttackSystem.caveCreature_02.renderer.enabled = false;
			}
		}
		
		else if(orcAttack.caveorObj == 1)										//----- Building Resume Time ----- //
		{
			Debug.Log(" ** Building ** Cave Type ID = "+ReturnTypeIdfromObjId(orcAttack.caveId));
			
			//GetCaveCreatures(ReturnTypeIdfromObjId(orcAttack.caveId));	
			GetCaveCreatures(ReturnTypeIdfromObjId(orcAttack.caveId), false);
			
			beforeCaveId = orcAttack.caveTypeId;
				
			if(beforeCaveId != afterCaveId)
			{
				scr_OrcAttackSystem.attackObjId_01 = orcAttack.attackedTypedId;
				
				string buildingName1 = ReturnBuildingNameFromTypeid(scr_OrcAttackSystem.attackObjId_01);
				
				Debug.Log("Resume Obj Id 01 = "+scr_OrcAttackSystem.attackObjId_01);
				Debug.Log("Resume attacked Building 1 = "+buildingName1);
				
				scr_OrcAttackSystem.attackedBuilding_01 = GameObject.Find(buildingName1);
				
				if(scr_OrcAttackSystem.attackedBuilding_01 != null)
				{
					scr_OrcAttackSystem.attackedBuilding_01.transform.FindChild("Isometric_Collider").gameObject.tag = "attack";
					scr_OrcAttackSystem.attackedBuilding_01.AddComponent("HealthProgressBar");
					scr_OrcAttackSystem.attackedBuilding_01.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					HealthProgressBar hPB = scr_OrcAttackSystem.attackedBuilding_01.GetComponent<HealthProgressBar>() as HealthProgressBar;

					if (hPB != null)
						hPB.createOrcEffect();


					hPB.SecCnt = ReturnSecondsfromTasks(orcAttack.attackedTypedId);
					Debug.Log("Time 1 : " + hPB.SecCnt);
					hPB.seconds = (float)hPB.SecCnt;
					hPB.attackCreature = scr_OrcAttackSystem.caveCreature_01;
					hPB.caveCreaturePosOld = scr_OrcAttackSystem.currentCreature_01Pos;
					hPB.totalTime = (float)orcAttack.creationTime;
					
					GameObject currentCave = scr_OrcAttackSystem.caveCreature_01.transform.parent.gameObject;
					
					if(scr_OrcAttackSystem.attackedBuilding_01.transform.position.x < currentCave.transform.position.x)
						scr_OrcAttackSystem.caveCreature_01.transform.localScale = new Vector3(scr_OrcAttackSystem.caveCreature_01.transform.localScale.x * -1, scr_OrcAttackSystem.caveCreature_01.transform.localScale.y, scr_OrcAttackSystem.caveCreature_01.transform.localScale.z);
					else if(scr_OrcAttackSystem.attackedBuilding_01.transform.position.x >= currentCave.transform.position.x)
						scr_OrcAttackSystem.caveCreature_01.transform.localScale = new Vector3(scr_OrcAttackSystem.caveCreature_01.transform.localScale.x, scr_OrcAttackSystem.caveCreature_01.transform.localScale.y, scr_OrcAttackSystem.caveCreature_01.transform.localScale.z);
				
					scr_OrcAttackSystem.caveCreature_01.gameObject.tag = "busy";
					scr_OrcAttackSystem.newCreature_01Pos = scr_OrcAttackSystem.attackedBuilding_01.transform.position;
					
					scr_OrcAttackSystem.caveCreature_01.transform.renderer.enabled = false;									
					scr_OrcAttackSystem.caveCreature_01.transform.FindChild("Walk_anim").renderer.enabled = false;
					scr_OrcAttackSystem.caveCreature_01.transform.FindChild("LessAgg1_anim").renderer.enabled = false;
					scr_OrcAttackSystem.caveCreature_01.transform.FindChild("attack_anim").renderer.enabled = true;
					
					// mywork
					
					if(scr_OrcAttackSystem.attackedBuilding_01.gameObject.tag == "Plot" || scr_OrcAttackSystem.attackedBuilding_01.gameObject.tag == "DPlot")
					{
						scr_OrcAttackSystem.caveCreature_01.transform.position = new Vector3(scr_OrcAttackSystem.newCreature_01Pos.x - 3f, 1, scr_OrcAttackSystem.newCreature_01Pos.z - 1f);
					}
					else
					{
						scr_OrcAttackSystem.caveCreature_01.transform.position = new Vector3(scr_OrcAttackSystem.newCreature_01Pos.x - 4f, 1, scr_OrcAttackSystem.newCreature_01Pos.z - 4.5f);
					}
				}
			}
				
			if(beforeCaveId == afterCaveId)
			{
				scr_OrcAttackSystem.attackObjId_02 = orcAttack.attackedTypedId;
				
				string buildingName2 = ReturnBuildingNameFromTypeid(scr_OrcAttackSystem.attackObjId_02);
				
				Debug.Log("Resume Obj Id 02 = "+scr_OrcAttackSystem.attackObjId_02);
				Debug.Log("Resume attacked Building 2 = "+buildingName2);
				
				scr_OrcAttackSystem.attackedBuilding_02 = GameObject.Find(buildingName2);
				
				if(scr_OrcAttackSystem.attackedBuilding_02 != null)
				{
					scr_OrcAttackSystem.attackedBuilding_02.transform.FindChild("Isometric_Collider").gameObject.tag = "attack";
					scr_OrcAttackSystem.attackedBuilding_02.AddComponent("HealthProgressBar");
					scr_OrcAttackSystem.attackedBuilding_02.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					HealthProgressBar hPB = scr_OrcAttackSystem.attackedBuilding_02.GetComponent<HealthProgressBar>() as HealthProgressBar;

					if (hPB != null)
						hPB.createOrcEffect();

					//scr_OrcAttackSystem.attackedBuilding_02.GetComponent<HealthProgressBar>().createOrcEffect();

					hPB.SecCnt = ReturnSecondsfromTasks(orcAttack.attackedTypedId);
					Debug.Log("Time 2 : "+hPB.SecCnt);
					hPB.seconds = (float)hPB.SecCnt;
					hPB.attackCreature = scr_OrcAttackSystem.caveCreature_02;
					hPB.caveCreaturePosOld = scr_OrcAttackSystem.currentCreature_02Pos;
					hPB.totalTime = (float)orcAttack.creationTime;
					
					GameObject currentCave = scr_OrcAttackSystem.caveCreature_02.transform.parent.gameObject;
					Debug.Log("currentCave : "+currentCave.name);
					
					if(scr_OrcAttackSystem.attackedBuilding_02.transform.position.x < currentCave.transform.position.x)
						scr_OrcAttackSystem.caveCreature_02.transform.localScale = new Vector3(scr_OrcAttackSystem.caveCreature_02.transform.localScale.x * -1, scr_OrcAttackSystem.caveCreature_02.transform.localScale.y, scr_OrcAttackSystem.caveCreature_02.transform.localScale.z);
					else if(scr_OrcAttackSystem.attackedBuilding_02.transform.position.x >= currentCave.transform.position.x)
						scr_OrcAttackSystem.caveCreature_02.transform.localScale = new Vector3(scr_OrcAttackSystem.caveCreature_02.transform.localScale.x, scr_OrcAttackSystem.caveCreature_02.transform.localScale.y, scr_OrcAttackSystem.caveCreature_02.transform.localScale.z);
				
					scr_OrcAttackSystem.caveCreature_02.gameObject.tag = "busy";
					scr_OrcAttackSystem.newCreature_02Pos = scr_OrcAttackSystem.attackedBuilding_02.transform.position;
					
					scr_OrcAttackSystem.caveCreature_02.transform.renderer.enabled = false;									
					scr_OrcAttackSystem.caveCreature_02.transform.FindChild("Walk_anim").renderer.enabled = false;
					scr_OrcAttackSystem.caveCreature_02.transform.FindChild("LessAgg2_anim").renderer.enabled = false;
					scr_OrcAttackSystem.caveCreature_02.transform.FindChild("attack_anim").renderer.enabled = true;
					
					if(scr_OrcAttackSystem.attackedBuilding_02.gameObject.tag == "Plot" || scr_OrcAttackSystem.attackedBuilding_02.gameObject.tag == "DPlot")
					{
						scr_OrcAttackSystem.caveCreature_02.transform.position = new Vector3(scr_OrcAttackSystem.newCreature_02Pos.x - 3f, 1, scr_OrcAttackSystem.newCreature_02Pos.z - 1f);
					}
					else
					{
						scr_OrcAttackSystem.caveCreature_02.transform.position = new Vector3(scr_OrcAttackSystem.newCreature_02Pos.x - 4f, 1, scr_OrcAttackSystem.newCreature_02Pos.z - 4.5f);
					}
				}
			}
			afterCaveId = orcAttack.caveTypeId;
		}
	}
	
	
	private List<int> lst_attackedObjIds = new List<int>();
	private void GetattackedObjectsArray(int cavetypeid,int cavernt)							//----- If not working try inside thie method ----- //
	{
		for(int i= 0 ; i< scr_sfsRemote.lst_OrgAttackTasks.Count; i++)
		{
			if(scr_sfsRemote.lst_OrgAttackTasks[i].caveorObj.Equals(cavernt))
			{		
				if(scr_sfsRemote.lst_OrgAttackTasks[i].caveTypeId.Equals(cavetypeid))
				{
					lst_attackedObjIds.Add(scr_sfsRemote.lst_OrgAttackTasks[i].attackedObjId);
				}
			}
		}
	}
	
	//Get cave name from type id
	public string ReturnCaveNameFromTypeid(int objTypeid)
	{
		switch(objTypeid)
		{
		case 102:
			return "HC_B_GoblinCamp_GO(Clone)_02";
			break;
			
		case 103:
			return "HC_B_GoblinCamp_GO(Clone)_03";
			break;
			
		case 104:
			return "HC_B_OrgCave_GO(Clone)_01";
			break;
			
		case 105:
			return "HC_B_OrgCave_GO(Clone)_02";
			break;
			
		case 106:
			return "HC_B_OrgCave_GO(Clone)_03";
			break;
			
		case 107:
			return "HC_B_TrollHouse_GO(Clone)_01";
			break;
			
		case 108:
			return "HC_B_TrollHouse_GO(Clone)_02";
			break;
			
		case 109:
			return "HC_B_TrollHouse_GO(Clone)_03";
			break;
			
			
		case 111:
			return "DL_B_GoblinCamp_GO(Clone)_01";
			break;
			
		case 112:
			return "DL_B_GoblinCamp_GO(Clone)_02";
			break;
			
		case 113:
			return "DL_B_GoblinCamp_GO(Clone)_03";
			break;
			
		case 114:	//Darkling org01
			return "";
			break;
			
		case 115:	//Darkling org02
			return "";
			break;
			
		case 116:	//Darkling org03
			return "";
			break;
			
		case 117:
			return "DL_B_TrollHouse_GO(Clone)_01";
			break;
			
		case 118:
			return "DL_B_TrollHouse_GO(Clone)_02";
			break;
			
		case 119:
			return "DL_B_TrollHouse_GO(Clone)_03";
			break;
			
		default :
			break;
		}
		return "";
	}
	
	string buildingName;
	public string ReturnBuildingNameFromTypeid(int objTypeid)						//---- Find the attacked object by sendling type id of the object ------//
	{
		switch(objTypeid)
		{
		
		case 6 :	// Halfling Inn //			
			
			buildingName = "HC_B_Inn_GO(Clone)";
			break;
			
		case 30	:	// Halfling Stable //
			
			buildingName = "HC_B_Stable_GO(Clone)";
			break;
			
		case 19 :
			
			buildingName = "HC_B_BlackSmith_GO(Clone)";
			break;
			
		case 44 :
			
			buildingName = "HC_B_Apothecary_GO(Clone)";
			break;
			
		case 42 :
			
			buildingName = "HC_B_Tavern_GO(Clone)";
			break;
			
		case 52 :
			
			buildingName = "HC_B_SunShrine_GO(Clone)";
			break;
			
		case 2 :
			
			buildingName = "HC_TG_TrainingGround_GO(Clone)";
			break;
			
		case 20 :
			
			buildingName = "HC_TG_Plant_GO(Clone)";
			break;
			
		case 29 :
			buildingName = "HC_TG_Water_GO(Clone)";
			break;
			
		case 4:
			buildingName = "HC_B_Plot_GO(Clone)";
			break;	
			
		case 28:
			buildingName = "HC_B_Plot_GO(Clone)_2";
			break;	
			
		case 34:
			buildingName = "HC_B_Plot_GO(Clone)_3";
			break;	
			
		case 46:
			buildingName = "HC_B_Plot_GO(Clone)_4";
			break;	
			
		case 54:
			buildingName = "HC_B_Plot_GO(Clone)_5";
			break;	
			
			
		
		case 203 :
			buildingName = "DL_B_Inn_GO(Clone)";
			break;
			
		case 211 :
			buildingName = "DL_B_Stable_GO(Clone)";
			break;
			
		case 218 :
			buildingName = "DL_B_DBlackSmith_GO(Clone)";
			break;
			
		case 228 :
			buildingName = "DL_B_Apothecary_GO(Clone)";
			break;
			
		case 226 :
			buildingName = "DL_B_Tavern_GO(Clone)";
			break;
			
		case 236 :
			buildingName = "DL_B_MoonShrine_GO(Clone)";
			break;
			
		case 207 :
			buildingName = "DL_TG_Swamp_GO(Clone)";
			break;
			
		case 214 :
			buildingName = "DL_TG_Fire_GO(Clone)";
			break;
			
		case 210 :
			buildingName = "DL_TG_Earth_GO(Clone)";
			break;
			
		case 201 :
			buildingName = "DL_B_Plot_GO(Clone)_1";
			break;	
			
		case 219 :
			buildingName = "DL_B_Plot_GO(Clone)_2";
			break;	
			
		case 230 :
			buildingName = "DL_B_Plot_GO(Clone)_3";
			break;	
			
		case 239 :
			buildingName = "DL_B_Plot_GO(Clone)_4";
			break;	
			
		default :
			buildingName = "";
			break;
			
		}
		return buildingName;
	}
	
	public float currentShieldTime;
	public void AddDefenseTimer(int objTypeId, int obliskTypeId)
	{
		string defenseBuilding = ReturnBuildingNameFromTypeid(objTypeId);
		string obliskBuilding = ReturnOblisknameFromTypeId(obliskTypeId);
		
		GameObject defenseObject = GameObject.Find(defenseBuilding);
		if(defenseObject != null)
		{
			Debug.Log("defenseObject : "+defenseObject.gameObject.name);
			
			if(defenseObject.GetComponent<HealthProgressBar>() != null)			//if objext is being defended send creature back to cave
			{
				Debug.Log("Send creature back");
				HealthProgressBar hPB = defenseObject.GetComponent<HealthProgressBar>();
				hPB.attackCreature.transform.position = hPB.caveCreaturePosOld;
				hPB.attackCreature.transform.FindChild("attack_anim").renderer.enabled = false;

				hPB.attackCreature.tag = "Untagged";
				hPB.ResetProgressbarScale();
				Debug.Log("Creature Name "+hPB.attackCreature.name);

				hPB.attackCreature.renderer.enabled = true;
				hPB.attackCreature.transform.localScale = new Vector3(1.111111f, 1.111111f, 1.666667f);
				
				defenseObject.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				defenseObject.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Destroy(hPB.parOrcAttackEff);
				Destroy(hPB);
			}
			
			//defenseObject.transform.FindChild("defenceTime").gameObject.SetActiveRecursively(true);
			//defenseObject.transform.FindChild("defenceTime").renderer.enabled = true;
			
			defenseObject.AddComponent("DefenseProgressBar");
			DefenseProgressBar dPB = defenseObject.GetComponent<DefenseProgressBar>();
			dPB.SecCnt = currentShieldTime;
			
			GameObject obliskObject = GameObject.Find(obliskBuilding);
			//dPB.oblisk = obliskObject;
			Debug.Log("obliskObject + "+obliskObject);
			
			if(obliskObject.GetComponent<ObliskProgressBar>() == null)
			{
				obliskObject.transform.FindChild("DefenceObeliskIcon").gameObject.SetActiveRecursively(true);
				obliskObject.AddComponent<ObliskProgressBar>();
				ObliskProgressBar oPB = obliskObject.GetComponent<ObliskProgressBar>();
				oPB.SecCnt = currentShieldTime;
				Debug.Log("oPB.SecCnt : "+oPB.SecCnt);
			}
			
			if(defenseObject.tag == "Plot" || defenseObject.tag == "DPlot")
			{
				GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk3x3, new Vector3(defenseObject.transform.position.x, 1, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
				defenseEffect.transform.parent = defenseObject.transform;
				dPB.defenseParticle = defenseEffect;
			}
			
			string [] splitWords = defenseObject.name.Split('_');
			foreach(string objectType in splitWords)
			{
				if(objectType == "B" && defenseObject.tag != "Plot" && defenseObject.tag != "DPlot")
				{
					GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk4x4, new Vector3(defenseObject.transform.position.x, 0.1f, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
					defenseEffect.transform.parent = defenseObject.transform;
					dPB.defenseParticle = defenseEffect;
				}
				else if(objectType == "TG")
				{
					GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk8x8, new Vector3(defenseObject.transform.position.x, 1, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
					defenseEffect.transform.parent = defenseObject.transform;
					dPB.defenseParticle = defenseEffect;
				}
			}
		}
	}
	
	//Resume defense timer when defense task is running
	public void ResumeDefenseTimer(ISFSObject defenseobj)
	{
		SfsRemote.DefenseTasks defenseTask = new SfsRemote.DefenseTasks();
		
		defenseTask.object_type_id = defenseobj.GetInt("object_type_id");
		defenseTask.obeliskId = defenseobj.GetInt("obeliskId");
		//defenseTask.taskEndTime = defenseobj.GetLong("taskEndTime");
		defenseTask.taskEndTime = defenseobj.GetDouble("taskEndTime");
		
		scr_sfsRemote.lst_DefenseTasks.Add(defenseTask);
		
		string defenseBuilding = ReturnBuildingNameFromTypeid(defenseTask.object_type_id);
		string obliskBuilding = ReturnOblisknameFromTypeId(defenseTask.obeliskId);
		
		GameObject defenseObject = GameObject.Find(defenseBuilding);
		if(defenseObject != null)
		{
			Debug.Log("defenseObject : "+defenseObject.gameObject.name);
			
			//defenseObject.transform.FindChild("defenceTime").gameObject.SetActiveRecursively(true);
			//defenseObject.transform.FindChild("defenceTime").renderer.enabled = true;
			defenseObject.AddComponent("DefenseProgressBar");
			DefenseProgressBar dPB = defenseObject.GetComponent<DefenseProgressBar>();
			dPB.SecCnt = ReturnSecondsforDefenseTasks(defenseTask.object_type_id);
			Debug.Log("Resume shield time : "+dPB.SecCnt);
			
			GameObject obliskObject = GameObject.Find(obliskBuilding);
			//dPB.oblisk = obliskObject;
			Debug.Log("obliskObject + "+obliskObject);
			if (obliskObject != null)
			{
				if(obliskObject.GetComponent<ObliskProgressBar>() == null)
				{
					obliskObject.transform.FindChild("DefenceObeliskIcon").gameObject.SetActiveRecursively(true);
					obliskObject.AddComponent<ObliskProgressBar>();
					ObliskProgressBar oPB = obliskObject.GetComponent<ObliskProgressBar>();
					oPB.SecCnt = ReturnSecondsforDefenseTasks(defenseTask.object_type_id);
					Debug.Log("oPB.SecCnt : "+oPB.SecCnt);
				}
			}
			if(defenseObject.tag == "Plot" || defenseObject.tag == "DPlot")
			{
				GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk3x3, new Vector3(defenseObject.transform.position.x, 1, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
				defenseEffect.transform.parent = defenseObject.transform;
				dPB.defenseParticle = defenseEffect;
			}
			
			string [] splitWords = defenseObject.name.Split('_');
			foreach(string objectType in splitWords)
			{
				if(objectType == "B" && defenseObject.tag != "Plot" && defenseObject.tag != "DPlot")
				{
					GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk4x4, new Vector3(defenseObject.transform.position.x, 0.1f, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
					defenseEffect.transform.parent = defenseObject.transform;
					dPB.defenseParticle = defenseEffect;
				}
				else if(objectType == "TG")
				{
					GameObject defenseEffect = (GameObject)Instantiate(scr_gameManager.obelisk8x8, new Vector3(defenseObject.transform.position.x, 1, defenseObject.transform.position.z), scr_gameManager.obelisk3x3.transform.rotation);
					defenseEffect.transform.parent = defenseObject.transform;
					dPB.defenseParticle = defenseEffect;
				}
			}
		}
	}
	
	
	private string obliskName;
	private string ReturnOblisknameFromTypeId(int objTypeId)
	{
		switch(objTypeId)
		{
		
		case 37 :
			obliskName = "HC_B_EarthObelisk_GO(Clone)";
			break;
			
		case 43 :
			obliskName = "HC_B_PlantObelisk_GO(Clone)";
			break;
			
		case 48:
			obliskName = "HC_B_WaterObelisk_GO(Clone)";
			break;
			
		case 223:
			obliskName = "DL_B_SwampObelisk_GO(Clone)";
			break;
		
		case 227:
			obliskName = "DL_B_EarthObelisk_GO(Clone)";
			break;
		
		case 232:
			obliskName = "DL_B_FireObelisk_GO(Clone)";
			break;
			
		
		default :
			obliskName = "";
			break;
		}
		return obliskName;
	}
	
	public void AddQuestTaskList(ISFSObject questTaskObj)
	{
		SfsRemote.QuestTasks questTask = new SfsRemote.QuestTasks();
		
		questTask.level = questTaskObj.GetInt("level");						
		questTask.taskHeading = questTaskObj.GetUtfString("taskHeading");
		questTask.taskDetail = questTaskObj.GetUtfString("taskDetail");
		questTask.hd = questTaskObj.GetInt("HD");							//HD = 0 Halfling.... HD = 1 Darkling
		
		scr_sfsRemote.lst_QuestTasks.Add(questTask);
		//Debug.Log("Level : "+questTask.level +" ------ Title : " + questTask.taskHeading.ToString());

		if(IsHalfling(questTask.hd))
		{
			if(scr_taskDetails.halflingQuestTask.ContainsKey(questTask.level))
			{
				scr_taskDetails.halflingQuestTask[questTask.level].Add(questTask.taskHeading, questTask.taskDetail);
			}
			else
			{
				Dictionary<string, string> halfDict =  new Dictionary<string,string>();
				halfDict.Add(questTask.taskHeading, questTask.taskDetail);
				scr_taskDetails.halflingQuestTask.Add(questTask.level, halfDict);
			}
		}
		else if(!IsHalfling(questTask.hd))
		{
			if(scr_taskDetails.darklingQuestTask.ContainsKey(questTask.level))
			{
				scr_taskDetails.darklingQuestTask[questTask.level].Add(questTask.taskHeading, questTask.taskDetail);
			}
			else
			{
				Dictionary<string, string> darkDict = new Dictionary<string, string>();
				darkDict.Add(questTask.taskHeading, questTask.taskDetail);
				scr_taskDetails.darklingQuestTask.Add(questTask.level, darkDict);
			}
		}
	}
	
	private bool IsHalfling(int which)
	{
		if(which == 0)
			return true;
		
		return false;
	}
	
	public void ClearQuestTasks()
	{
		if(scr_taskDetails.halflingQuestTask.Count > 0)
		{
			scr_taskDetails.halflingQuestTask.Clear();
		}
		if(scr_taskDetails.darklingQuestTask.Count > 0)
		{
			scr_taskDetails.darklingQuestTask.Clear();
		}
	}
	
	public void AddStoryLogList(ISFSObject storyTaskObj)
	{
		taskDetails.StoryContent storyContent = new taskDetails.StoryContent();
		
		storyContent.status = storyTaskObj.GetInt("status");
		storyContent.storyNo = storyTaskObj.GetInt("triggerNo");
		storyContent.storyDetail = "";			//temp
		
		Debug.Log(storyContent.storyNo + " -------- " +storyContent.status);
		
		scr_taskDetails.storyList.Add(storyContent);
		
	}
	
	public static bool IsquestRunning,TrainingGrndUpgrade;
	private int plantid;
	private string plantname;
	
	public void AllocateProgressBar(int id,int typeId,long time,string taskId,int creationTym,int parentObj)
	{		
//		Debug.Log("Allocate Progress Bar...");
		SfsRemote.ObjectTimes obj = new SfsRemote.ObjectTimes();
		obj.Id = id;
		obj.TypeId = typeId;
		obj.tym = time;
		obj.taskId = taskId;
		obj.creationTym = creationTym;
		obj.ParentObjectId = parentObj;
		
		scr_sfsRemote.lst_times.Add(obj);
		
		if(!scr_sfsRemote.isUserWorld)
		{
			if(!ChkIsPlants(scr_popUpInfo.GetTypeId()))
			{
		     if(typeId == scr_popUpInfo.GetTypeId())
		       {
//					Debug.Log("a a a a a  aa  a a a a a a a  a");
			    	ProgressBar(scr_popUpInfo.GetTypeId(),id);
				//	 Debug.Log("ID :" + id);
				//	 Debug.Log("type ID :" + scr_popUpInfo.GetTypeId());
				}
			}
			else if(ChkIsPlants(scr_popUpInfo.GetTypeId()))
			{
				plantname = scr_sfsRemote.GetPlantName();
				plantid = scr_popUpInfo.GetIdFromString(plantname);
				Debug.Log("ID :" + plantid );
				Debug.Log("Name :" + plantname );
				
				if(id == plantid)
				{
					ProgressBar(scr_popUpInfo.GetTypeId(),id);
				//	Debug.Log("ID :" + id);
				}
			}
		}
		else
		{
			if(ChkforQuest(id))
			{
				ProgressBar(scr_gameObjectSvr.QuestCreation.objTypeId,id);
			}
		}
		
	}
	
	public void AddUserObjectsDB(double spark_cost,
								 double cost_gold_total,
								 double xp_earned,
								 double cost_gold_base,
								 string ObjectType,
								 int ObjectTypeId)
	{
		
		SfsRemote.GameObjectsDB gameObjDb = new SfsRemote.GameObjectsDB();
		
		gameObjDb.spark_cost = spark_cost;
		gameObjDb.cost_gold_total = cost_gold_total;
		gameObjDb.xp_earned = xp_earned;
		gameObjDb.cost_gold_base = cost_gold_base;
		gameObjDb.ObjectTypeName = ObjectType;
		gameObjDb.ObjectTypeId = ObjectTypeId;
		
		
		//Debug.Log("Obj Count typeiD >>>>>> :" + gameObjDb.ObjectTypeId);
		//Debug.Log("Obj Count Xp >>>>>> :" + gameObjDb.xp_earned);
		scr_sfsRemote.lst_GameObjectsDb.Add(gameObjDb);
		
		//Debug.Log("cost :---> " + gameObjDb.ObjectTypeName + " <--> " + gameObjDb.spark_cost);
	}
	
	public double ReturnGoldCostTotal(int typeId)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_GameObjectsDb.Count ; i++)
		{
			if(scr_sfsRemote.lst_GameObjectsDb[i].ObjectTypeId.Equals(typeId))
			{
				return scr_sfsRemote.lst_GameObjectsDb[i].cost_gold_total;
			}	
		}
		
		return -1;
	}
	
	
	public bool ChkTrainingGround(int Type)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].typeId.Equals(Type))
			{
				return true;
			}
		}
		return false;
	}
	
	
	public static bool activateQuestProgressBar;
	
	string TemptaskId;
	public  string ReturnTaskId(int typeId)
	{
		for(int i=0; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].TypeId.Equals(typeId))
			{
				TemptaskId = scr_sfsRemote.lst_times[i].taskId;				
			}
		}
		return TemptaskId;
	}
	
	string TemptaskIdforIds;
	public  string ReturnTaskIdforIds(int Id)
	{
		for(int i=0; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(Id))
			{
				TemptaskIdforIds = scr_sfsRemote.lst_times[i].taskId;				
			}
		}
		return TemptaskIdforIds;
	}
	
	private bool IsConstructedOrNot(int typeId)
	{
		for(int i= 0; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].TypeId.Equals(typeId))
			{
				return true;
			}
		}
		return false;
	}
	
	private int ReturnTgChild(int id)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_ChildObjects.Count ; i++)
		{
			if(scr_sfsRemote.lst_ChildObjects[i].objId.Equals(id))
			{
				return scr_sfsRemote.lst_ChildObjects[i].Cnt;
			}
		}
		
		return 0;
	}
	
	private bool IsConstructedOrNotforIds(int Id)
	{
		for(int i= 0; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(Id))
			{
				return true;
			}
		}
		return false;
	}
	
	private int TempConstruct;
	public int ReturnConstructionTime(int typeId)
	{
		for(int i=0; i<scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].TypeId.Equals(typeId))
			{
				TempConstruct = scr_sfsRemote.lst_times[i].creationTym;
			}
		}
		return TempConstruct;
	}
	
	private int TempConstructId;
	public int ReturnConstructionTimeforIds(int Id)
	{
		for(int i= 0; i< scr_sfsRemote.lst_times.Count ; i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(Id))
			{
				TempConstructId = scr_sfsRemote.lst_times[i].creationTym;
			}
		}
		return TempConstructId;
	}
	
	private int farmId;
	public int ReturnFarmId(int Id)
	{
		for(int i= 0; i< scr_sfsRemote.lst_times.Count ; i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(Id))
			{
				farmId = scr_sfsRemote.lst_times[i].ParentObjectId;
			}
		}		
		return farmId;
	}
	
	public int ReturnPlantsfromUserPurchases(int typeId)
	{
		cnt = 0;
		
		for(int i=0 ; i< scr_sfsRemote.lst_UserPurchasesSvr.Count ;i++)
		{
			if(scr_sfsRemote.lst_UserPurchasesSvr[i].typeId.Equals(typeId))
			{
				cnt++ ;
			}
		}
		
		return cnt;
	}
	
	
	public int ReturnTimefromMiniGameTimes(string taskId)
	{
		for(int i= 0 ; i< scr_sfsRemote.lst_miniGametimeInfo.Count; i++)
		{
			if(scr_sfsRemote.lst_miniGametimeInfo[i].taskId.Equals(taskId))
			{
				return scr_sfsRemote.lst_miniGametimeInfo[i].timetoOpen;
			}
		}
		
		return -1;
	}
	
	private int c = 0;
	public int ReturnGardenPlotCount(int typeId)
	{
		c = 0;
		for(int i=0 ; i< scr_sfsRemote.lst_UserPurchasesSvr.Count; i++)
		{
			if(scr_sfsRemote.lst_UserPurchasesSvr[i].typeId.Equals(typeId))
			{
				c++;
			}
		}
		
		return c;
	}
	
	bool ChkforQuest(int id)
	{
		if(id > 500 && id < 513 && id != 502)
		{
			return true;
		}
		
		return false;
	}
	
	
	public void AddTgInfo(int cnt,int id)
	{
		SfsRemote.ChildObjects child = new SfsRemote.ChildObjects();
		child.Cnt = cnt;
		child.objId = id;
		
		scr_sfsRemote.lst_ChildObjects.Add(child);
	}
	
    public void AddChildItems()
	{	
		
			if(ChkTrainingGround(scr_gameObjectSvr.objTrainingGrnd.objTypeId))
			{
			   int tgid = ReturnObjIdfromTypeId(scr_gameObjectSvr.objTrainingGrnd.objTypeId);
			   GameManager.earthTG_Creature_Cnt = ReturnTgChild(tgid);
			   //Debug.Log("earth tg Count >>>>>>>>>>>>>>> :" + GameManager.earthTG_Creature_Cnt);
			}
	    	    		
		    if(ChkTrainingGround(scr_gameObjectSvr.objPlantTrainingGrnd.objTypeId))
		    {
				int tgid = ReturnObjIdfromTypeId(scr_gameObjectSvr.objPlantTrainingGrnd.objTypeId);
			    GameManager.plantTG_Creature_Cnt = ReturnTgChild(tgid);
				//Debug.Log("Plant tg Count >>>>>>>>>>>>>>> :" + GameManager.plantTG_Creature_Cnt);
			}

			
		    if(ChkTrainingGround(scr_gameObjectSvr.objSwampTrainingGrnd.objTypeId))
			{
				int tgid = ReturnObjIdfromTypeId(scr_gameObjectSvr.objSwampTrainingGrnd.objTypeId);
			    GameManager.swampTG_Creature_Cnt = ReturnTgChild(tgid);
			    //Debug.Log("Swamp Count >>>>>>>>>>>>>>> :" + GameManager.swampTG_Creature_Cnt);
			}
			
			if(ChkTrainingGround( scr_gameObjectSvr.objWaterTrainingGrnd.objTypeId))
			{
				int tgid = ReturnObjIdfromTypeId( scr_gameObjectSvr.objWaterTrainingGrnd.objTypeId);
			    GameManager.waterTG_Creature_Cnt =  ReturnTgChild(tgid);
			    //Debug.Log("WaterTg Count >>>>>>>>>>>>>>> :" + GameManager.waterTG_Creature_Cnt);
     		}
				
		    if(ChkTrainingGround( scr_gameObjectSvr.objDarkearthTrainingGrnd.objTypeId))
			{
				int tgid = ReturnObjIdfromTypeId(scr_gameObjectSvr.objDarkearthTrainingGrnd.objTypeId);
        	    GameManager.dEarthTG_Creature_Cnt =  ReturnTgChild(tgid);
			    //Debug.Log("DarkEarth tg Count >>>>>>>>>>>>>>> :" + GameManager.dEarthTG_Creature_Cnt);
		    }
		
			if(ChkTrainingGround(scr_gameObjectSvr.objDarklingFireTrainingGrnd.objTypeId))
			{
				int tgid = ReturnObjIdfromTypeId(scr_gameObjectSvr.objDarklingFireTrainingGrnd.objTypeId);
			    GameManager.fireTG_Creature_Cnt = ReturnTgChild(tgid);
			    //Debug.Log("FireTG Count >>>>>>>>>>>>>>> :" + GameManager.fireTG_Creature_Cnt);
			}	
			
	}
	
	
	private int tempParent;
    public int ParentObjSvr()
	{
		return tempParent;
	}
	
	
	int cnt = 0;
	public int ReturnHerbandPlantsCount(int TypeId)
	{
		cnt = 0;
		
		for(int i=0 ; i< scr_sfsRemote.lst_HerbObjects.Count ;i++)
		{
			if(scr_sfsRemote.lst_HerbObjects[i].ObjectTypeId.Equals(TypeId))
			{
				cnt++ ;
			}
		}
		
		return cnt;		
	}	
	
	public void RemoveTask(int objid)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(objid))
			{
				scr_sfsRemote.lst_times.Remove(scr_sfsRemote.lst_times[i]);
				//Debug.Log("Task Removed >>>>>");
			}
		}
	}
	
	public void RemoveCaveTask(string taskid)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_times.Count ;i++)
		{
			if(scr_sfsRemote.lst_times[i].taskId.Equals(taskid))
			{
				scr_sfsRemote.lst_times.Remove(scr_sfsRemote.lst_times[i]);
			}
		}
	}
	
	private int TempSpark;
	public int ReturnSparkCostFromCreatureInfo(int typeId)
	{
		for(int i= 0; i< scr_sfsRemote.lst_CreatureObjectsDb.Count ; i++)
		{
			if(scr_sfsRemote.lst_CreatureObjectsDb[i].objectTypeId.Equals(typeId))
			{
				TempSpark = (int)(scr_sfsRemote.lst_CreatureObjectsDb[i].sparkcost);
			}
		}
		
		return TempSpark;
	}
	
	public int ReturnCreatureIdforCave(int CaveTypeId)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_times.Count ; i++)
		{
			if(scr_sfsRemote.lst_times[i].TypeId.Equals(CaveTypeId))
			{
				return scr_sfsRemote.lst_times[i].ParentObjectId;
			}
		}
		
		return -1;
	}
	
	private int MaxFoodforcreature;
	public int GetMaxFoodforcreature()
	{
		return MaxFoodforcreature;
	}
	
	public void AddCreatureMorphInfo(double sparkcost,int morphcreatureId,int objectTypeId)
	{
		SfsRemote.CreatureObjects creature = new SfsRemote.CreatureObjects();
		
		creature.sparkcost = sparkcost;
		creature.morphCreatureId = morphcreatureId;
		creature.objectTypeId = objectTypeId;
		
		scr_sfsRemote.lst_CreatureObjectsDb.Add(creature);
	}
	
	
	private float calCurfeed;
	public void SetFoodLevelPB(float max,float currnt,int nextLevel,int x)
	{
		MaxFoodforcreature = (int)max;
		//Debug.Log("Max >>>>>>>>>>>>> :" + MaxFoodforcreature  + "currnt " + currnt);
        scr_creatureSystem.feedPB.transform.localScale = new Vector3((currnt / max),1,1);
		scr_creatureSystem.feed_spText.Text = (max - currnt).ToString();
		
		switch(scr_guiControl.GetInitialId())
		{
		case 3:
			  
		    calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.hound.curFeed = calCurfeed;
			GameManager.hound_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text  = GameManager.hound_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objHound.objTypeId).ToString();
			break;
			
		case 21:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.sprout.curFeed = calCurfeed;
			GameManager.sprout_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.sprout_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objSprout.objTypeId).ToString();
			break;
			
		case 22:
			
		    calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.barg.curFeed = calCurfeed;
			GameManager.barg_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.barg_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objBarg.objTypeId).ToString();
			
			break;
			
		case 24:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.nix.curFeed = calCurfeed;
			GameManager.nix_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.nix_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objNix.objTypeId).ToString();
			
			break;
			
		case 26:
			
		    calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.cusith.curFeed = calCurfeed;
			GameManager.cusith_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.cusith_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objCusith.objTypeId).ToString();
			
			break;
			
		case 32:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.nymph.curFeed = calCurfeed;
			GameManager.nymph_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.nymph_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objNymph.objTypeId).ToString();
			
			break;
			
		case 38:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.draug.curFeed = calCurfeed;
			GameManager.draug_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.draug_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDraug.objTypeId).ToString();
			
			break;
			
		case 41:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.dryad.curFeed = calCurfeed;
			GameManager.dryad_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.dryad_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDryad.objTypeId).ToString();
			
			break;
			
		case 50:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.dragon.curFeed = calCurfeed;
			GameManager.dragon_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.dragon_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDragon.objTypeId).ToString();
			
			break;
			
		case 208:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.leech.curFeed = calCurfeed;
			GameManager.leech_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.leech_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objLeech.objTypeId).ToString();
			
			break;
			
		case 209:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.dHound.curFeed = calCurfeed;
			GameManager.dHound_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.dHound_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklinghound.objTypeId).ToString();
			
			break;
				
		case 215:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.sprite.curFeed = calCurfeed;
			GameManager.sprite_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.sprite_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingSprite.objTypeId).ToString();
			
			break;
			
		case 222:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.leshy.curFeed = calCurfeed;
			GameManager.leshy_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.leshy_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingLeshy.objTypeId).ToString();
			
			break;
			
		case 224:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.fenrir.curFeed = calCurfeed;
			GameManager.fenrir_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.fenrir_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingFenrir.objTypeId).ToString();
			
			break;
			
		case 225:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.imp.curFeed = calCurfeed;
			GameManager.imp_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.imp_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingImp.objTypeId).ToString();
			
			break;
			
		case 234:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel - 1));
			scr_creatureSystem.lurker.curFeed = calCurfeed;
			GameManager.lurker_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.lurker_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingLurker.objTypeId).ToString();
			
			break;
			
		case 237:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel + 1));
			scr_creatureSystem.hellHound.curFeed = calCurfeed;
			GameManager.hellHound_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.hellHound_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingHellhound.objTypeId).ToString();
			
			break;
			
		case 241:
			
			calCurfeed = (float) Math.Pow(2,(nextLevel));
			scr_creatureSystem.djinn.curFeed = calCurfeed;
			GameManager.djinn_lvl = nextLevel - 1;
			scr_creatureSystem.cLevel_spText.Text = GameManager.djinn_lvl.ToString();
			scr_creatureSystem.morph_spText.Text = ReturnSparkCostFromCreatureInfo(scr_gameObjectSvr.objDarklingDjInn.objTypeId).ToString();
			
			break;

		}
	}
	
	private void UnlockHalflingGardenPlots(int level)
	{
		if(level == 2 || level == 4 || level == 7 || level == 10 || level == 13)
		{
			if(scr_popUpInfo.cnGrnd <= 2)
			{
			   GameManager.placeHGardenPlotBool = true;   
			}
			else 
			{
				GameManager.placeHGardenPlotBool = false;
			}
		}
		
	}
	
	private void UnlockdarklingGardenPlots(int level)
	{
		if(level == 4 || level == 7 || level == 10 || level == 13)
		{
			if(scr_popUpInfo.cnDGrnd <= 1)
			{
				GameManager.placeDGardenPlotBool = true;
			}
			else 
			{
				GameManager.placeDGardenPlotBool = false;
			}
		}
	}
	
	private float secondsforOrcattack;
	public float ReturnSecondsfrmSvrforOrgattack(int objid)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_OrgAttackTasks.Count ; i++)
		{
			if(scr_sfsRemote.lst_OrgAttackTasks[i].caveId.Equals(objid))
			{		
				
				/*
				long r1 = (long)(DateTime.UtcNow-new DateTime (1970, 1, 1)).TotalMilliseconds;
				long r2 = (scr_sfsRemote.lst_OrgAttackTasks[i].task_end_time);
				//long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
					
				long r =  r2 - r1;
				
				//Debug.Log("time for server :" + r2);
//				//Debug.Log("epoch :" + r1);
//				//Debug.Log(r);
		        
				secondsforOrcattack = (int)(r / 1000);
//				//Debug.Log("Left over seconds :" + SecondsfrmSvr);
             */
				
				secondsforOrcattack = (float) scr_sfsRemote.lst_OrgAttackTasks[i].task_end_time;
			}
			
		}
		return secondsforOrcattack;
	}
	
	public float ReturnSecondsfromTasks(int objid)
	{
		for(int i= 0 ; i< scr_sfsRemote.lst_OrgAttackTasks.Count ; i++)
		{
			if(scr_sfsRemote.lst_OrgAttackTasks[i].caveId.Equals(objid) || scr_sfsRemote.lst_OrgAttackTasks[i].attackedTypedId.Equals(objid))
			{
				return (long)scr_sfsRemote.lst_OrgAttackTasks[i].task_end_time;
			}
		}
		
		return -1;
	}
	
	public float ReturnSecondsforDefenseTasks(int typeId)
	{
		for(int i=0; i<scr_sfsRemote.lst_DefenseTasks.Count; i++)
		{
			if(scr_sfsRemote.lst_DefenseTasks[i].object_type_id.Equals(typeId))
			{
				//return (long)scr_sfsRemote.lst_DefenseTasks[i].taskEndTime;	
				//return (double)scr_sfsRemote.lst_DefenseTasks[i].taskEndTime;
				return Convert.ToInt64(scr_sfsRemote.lst_DefenseTasks[i].taskEndTime);
			}
		}
		return -1;
	}
	
	private float SecondsfrmSvr;
	public float ReturnTimefrmSvr(int typeId)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_times.Count ; i++)
		{
			if(scr_sfsRemote.lst_times[i].TypeId.Equals(typeId))
			{		
				
				/*
				long r1 = (long)(DateTime.UtcNow-new DateTime (1970, 1, 1)).TotalMilliseconds;
				long r2 = (scr_sfsRemote.lst_times[i].tym);
				//long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
					
				long r =  r2 - r1;
				
				//Debug.Log("time for server :" + r2);
//				//Debug.Log("epoch :" + r1);
//				//Debug.Log(r);
		        
				SecondsfrmSvr = (int)(r / 1000);
//				//Debug.Log("Left over seconds :" + SecondsfrmSvr);
                */
				
				SecondsfrmSvr = (float)scr_sfsRemote.lst_times[i].tym;
			}
			
		}
		return SecondsfrmSvr;
	}
	
	private float SecondsfrmSvrforIds;
	public float ReturnTimefrmSvrforIds(int Id)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_times.Count ; i++)
		{
			if(scr_sfsRemote.lst_times[i].Id.Equals(Id))
			{		
				/*
				long r1 = (long)(DateTime.UtcNow-new DateTime (1970, 1, 1)).TotalMilliseconds;
				long r2 = (scr_sfsRemote.lst_times[i].tym);
				//long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
					
				long r =  r2 - r1;
				
				//Debug.Log("time for server :" + r2);
//				//Debug.Log("epoch :" + r1);
//				//Debug.Log(r);
		        
				SecondsfrmSvrforIds = (int)(r / 1000);
//				//Debug.Log("Left over seconds :" + SecondsfrmSvr);
                */
				
				SecondsfrmSvrforIds = (float)scr_sfsRemote.lst_times[i].tym;
			}
			
		}
		return SecondsfrmSvrforIds;
	}
	
	private int s;
	public int convertToseconds(long Svrsec)
	{
		long r1 = (long)(DateTime.UtcNow-new DateTime (1970, 1, 1)).TotalMilliseconds;
		long r2 = Svrsec;
		
		long r = r2 - r1;
		
		s = (int)(r/1000);
		
		Debug.Log("Svr seconds :" + s);
		
		return s;
	}
	
	private void assingQuestNo(int id)
	{
		GameManager.quest = id - 501;
	}
	
	

	void ProgressBar(int typeId,int id)
	{
//		Debug.Log("type id :: >> " + typeId);
		switch(typeId)
		{
			// hound
			case 3:	
			{
			   	GameObject go = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject; 
				GameObject goChild = go.transform.FindChild("HC_C_Hound_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
			   		pb.seconds = ReturnTimefrmSvr(3);
			}
				break;
			
			// cusith
			case 26:
			{
			    GameObject go = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Cusith_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(26);
				
			}
				break;
		
			case 4:	
			case 28:
			case 34:
			case 46:
			case 54:
			case 201:
			case 219:
			case 230:
			
			// darkling gardon 4
			case 239:
			{
				GameObject go = GameObject.Find(scr_popUpInfo.GetUpgradePlotName()) as GameObject;
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if (upb != null)
			   		upb.seconds = ReturnTimefrmSvr(typeId);
			}
				break;
			
			// earth training ground
			case 2:
		    {
				Debug.Log("upgrade earth tg -------------------> ???");
			 	//Debug.Log("cur second Training Grnd ---> " + ReturnTimefrmSvr(2));
				GameObject go = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;  
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				upgradeProgressBar uPB = go.GetComponent<upgradeProgressBar>();
				if (uPB != null)
				{
					uPB.seconds = ReturnTimefrmSvr(2);
					uPB.SecCnt = uPB.seconds;
				}
	        }
				break;
	
			// darkling blacksmith
			case 218:
		    {
			   	GameObject go = GameObject.Find("DL_B_DBlackSmith_GO(Clone)") as GameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
	
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(218);		
				
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if(upb != null)
					upb.seconds = ReturnTimefrmSvr(218);
	    	}
				break;
	  
			// plant training ground
			case 20:
		    {
			   	GameObject go = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;  
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar uPB = go.GetComponent<upgradeProgressBar>();
				if (uPB != null)
			   		uPB.seconds = ReturnTimefrmSvr(20);
	        }
				break;
			
			// Inn
			case 6:
			{	
				GameObject go = GameObject.Find("HC_B_Inn_GO(Clone)").gameObject;
				GameObject rabbitButt = null;
				if (go != null)
					rabbitButt = go.transform.FindChild("RabbtiButton").gameObject;
				
				if (rabbitButt != null)
				{
					rabbitButt.SetActiveRecursively(true);
				}
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(6);	
				
				rabbitButt.SetActiveRecursively(true); 
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if(upb != null)
					upb.seconds = ReturnTimefrmSvr(6);
			}
				break;
		
			// sprout
			case 21:
			{
				
				GameObject go = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Sprout_GO(Clone)").gameObject;	
				GameObject rabbitButt21 = goChild.transform.FindChild("RabbtiButton").gameObject;
				if (rabbitButt21 != null)
					rabbitButt21.SetActiveRecursively(true);
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(21);
			}
				break;
		
			// darkling lurker
			case 234:
			{
				GameObject go = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_Lurker_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(234);
				
			}
				break;
       
			// nix
			case 24:
		    {
				GameObject go = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Nix_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(24);
		    }
				break;
	  
			// stable
			case 30:
			{
				GameObject go = GameObject.Find("HC_B_Stable_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				
				progressBar pb = go.GetComponent<progressBar>();
				if(pb != null)
					pb.seconds = ReturnTimefrmSvr(30);
				
				upgradeProgressBar Upb = go.GetComponent<upgradeProgressBar>();
				if (Upb != null)
					Upb.seconds = ReturnTimefrmSvr(30);	
			}
				break;
		
			// darkling leshy
			case 222:
			{
				GameObject go = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_Leshy_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(222);
			}
				break;
		
			// earth obelisk
			case 37:
			{
//				GameObject go = GameObject.Find("HC_B_EarthObelisk_GO(Clone)") as GameObject;
//				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
//				progressBar pb = go.GetComponent<progressBar>();
//				if (pb != null)
//					pb.seconds = ReturnTimefrmSvr(37);	
			
			
				GameObject go = GameObject.Find("HC_B_EarthObelisk_GO(Clone)") as GameObject;
				GameObject rabbitButt = null;
				if (go != null)
					rabbitButt = go.transform.FindChild("RabbtiButton").gameObject;
				
				if (rabbitButt != null)
				{
					rabbitButt.SetActiveRecursively(true);
				}
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(37);	
				
				rabbitButt.SetActiveRecursively(true); 
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if(upb != null)
					upb.seconds = ReturnTimefrmSvr(37);
			}
				break;
		
			// tavern
			case 42:
			{
				GameObject go = GameObject.Find("HC_B_Tavern_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(42);	
			}
				break;
		
			// plant obelilsk
			case 43:
			{
				GameObject go = GameObject.Find("HC_B_PlantObelisk_GO(Clone)") as GameObject;
				GameObject rabbitButt = null;
				if (go != null)
					rabbitButt = go.transform.FindChild("RabbtiButton").gameObject;
			
				if (rabbitButt != null)
				{
					rabbitButt.SetActiveRecursively(true);
				}
				
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(43);	
			
				rabbitButt.SetActiveRecursively(true); 
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if(upb != null)
					upb.seconds = ReturnTimefrmSvr(43);
			}
				break;
		
			// water obelisk
			case 48:
			{
				GameObject go = GameObject.Find("HC_B_WaterObelisk_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(48);	
			}
				break;
	
			// fire obelisk
			case 232:
			{
				GameObject go = GameObject.Find("DL_B_FireObelisk_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(232);	
			}
				break;
		
			// darkling moon shrine
			case 236:
			{
				GameObject go = GameObject.Find("DL_B_MoonShrine_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(236);	
			}
				
				break;
			
			// sunshrine
			case 52:
			{
				GameObject go = GameObject.Find("HC_B_SunShrine_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(52);	
			}
				break;
			
			// dakling hound
			case 209:
			{
				GameObject go = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_DHound_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(209);
			}
				break;
		
			// darkling stable
			case 211:
			{
				GameObject go = GameObject.Find("DL_B_Stable_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				
				progressBar pb = go.GetComponent<progressBar>();
				
				if(pb != null)
					pb.seconds = ReturnTimefrmSvr(211);
				
				upgradeProgressBar Upb = go.GetComponent<upgradeProgressBar>();
				if (Upb != null)
					Upb.seconds = ReturnTimefrmSvr(211);			
			}
				break;
		
			// sprite
			case 215:
			{
				GameObject go =GameObject.Find("DL_TG_Fire_GO(Clone)").gameObject;  
				GameObject goChild = go.transform.FindChild("DL_C_Sprite_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)	
				    pb.seconds = ReturnTimefrmSvr(215);	
			}
				break;
	   
			// nymph
			case 32:
			{
		 	    GameObject go =GameObject.Find("HC_TG_Plant_GO(Clone)").gameObject;  
				GameObject goChild = go.transform.FindChild("HC_C_Nymph_GO(Clone)").gameObject;
				
				Transform rabbitBut = goChild.transform.FindChild("RabbtiButton") as Transform;
				
				if (rabbitBut != null)
					rabbitBut.gameObject.SetActiveRecursively(true); 
				
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
			    	pb.seconds = ReturnTimefrmSvr(32);
			}
				break;
			
			
	                //Progress Bar attachment for plants..
			case 5:
			case 8:
			case 213:
			case 229:
			case 233:
			case 220:
			case 27:
			case 51:
			case 55:
			case 53:
			case 36:
			case 45:
			case 47:
			case 49:
			case 202:
			case 238:
			case 240:
			case 235:
			
			// DarklingColumbine
			case 231:
				
			{
				//Debug.Log("Garden Plot Name >>>>>>>>> :" + scr_popUpInfo.GetUpgradePlotName());
				GameObject go =GameObject.Find(scr_popUpInfo.GetUpgradePlotName()).gameObject; 
				GameObject goChild = null;
				if(scr_sfsRemote.GetPlantName() != null)
				{
				   goChild = go.transform.FindChild(scr_sfsRemote.GetPlantName()).gameObject;
				}
				goChild.renderer.material.color = new Color(goChild.renderer.material.color.r, goChild.renderer.material.color.g, goChild.renderer.material.color.b, 1f); 
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
		   	 		pb.seconds = ReturnTimefrmSvrforIds(id);
				
				
				//particle system
				
				if(goChild.transform.tag == "Turnip" || goChild.transform.tag == "Pumpkin" || goChild.transform.tag == "Potato" || goChild.transform.tag == "DPumpkin" || goChild.transform.tag == "DFirePepper" || goChild.transform.tag == "DBlackBerry")
				{
				Debug.Log("---------------------> particle <----------------------------");
					GameObject plantEffect = Instantiate(scr_gameManager.par_Plant_PF, new Vector3(go.transform.position.x, go.transform.position.y+2.5f, go.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
					plantEffect.GetComponent<ParticleSystem>().Play();
				}
				
				if (goChild.transform.tag == "DAven" || goChild.transform.tag == "DColumbine" || goChild.transform.tag == "MoonFlower" || goChild.transform.tag == "BitterBrush" || goChild.transform.tag == "BogBean" || goChild.transform.tag == "Wolfsbane" ||
					goChild.transform.tag == "PipeWeed" || goChild.transform.tag == "Costmary" || goChild.transform.tag == "FairyLily" || goChild.transform.tag == "SunFlower" || goChild.transform.tag == "Watercress" || goChild.transform.tag == "Vervain" || goChild.transform.tag == "Mandrake")
				{
					GameObject plantEffect = Instantiate(scr_gameManager.par_Herb_PF, new Vector3(go.transform.position.x, go.transform.position.y+0.05f, go.transform.position.z), Quaternion.Euler(300, 0, 0)) as GameObject;
					plantEffect.GetComponent<ParticleSystem>().Play();
				}
				
			}
			break;
			
			// quest progress bar
			case 0:
			{
				if(ChkforQuest(id))                         
				{
					if(id > 501)
				    {
					 assingQuestNo(id);
				    }
					
					GameObject quest = GameObject.Find("QuestPB_Spwan");
					GameObject qPB = Instantiate(scr_popUpInfo.guiControlInfo.questProgressBar, quest.transform.position,
								                     Quaternion.Euler(0, 180, 0)) as GameObject;
				
				     GameObject qbar = GameObject.Find("QuestProgressBar(Clone)").gameObject;
				     questProgressBar q = qbar.GetComponent<questProgressBar>();
				     scr_gameObjectSvr.QuestCreation.CreateTime = ( ReturnConstructionTime(0)  * 60);
						
				     q.qSeconds = ReturnTimefrmSvr(0);
				   
					Debug.Log("seconds Time : " +  q.qSeconds);
					Debug.Log("creation Time : " + scr_gameObjectSvr.QuestCreation.CreateTime);
						
					int Cnt = (int)((scr_gameObjectSvr.QuestCreation.CreateTime) - q.qSeconds);
					
					if(Cnt >= 0)
					{
					    q.cnt = Cnt;
					}
					else
					{
						q.cnt = 0;
					}
					
					float remainTime = ((float)q.cnt) / scr_gameObjectSvr.QuestCreation.CreateTime;
					Debug.Log("Remian>>>>>>:" + remainTime + " --- " + q.cnt + " --- " + scr_gameObjectSvr.QuestCreation.CreateTime + " --- " + q.qSeconds);	
					q.qSeconds = scr_gameObjectSvr.QuestCreation.CreateTime;
					Debug.Log("Remian>>>>>>:" + remainTime + " --- " + q.cnt + " --- " + scr_gameObjectSvr.QuestCreation.CreateTime + " --- " + q.qSeconds);	
					
					q.progressBarPov.transform.localScale = new Vector3(remainTime, q.progressBarPov.transform.localScale.y, q.progressBarPov.transform.localScale.z);
					GameManager.questRunningBool = true;
					
					qPB.transform.FindChild("qRabbitButton").GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
					
					
					
					
				}
				
				break;
			}
	
			// goblin camp 01
			case 101:
			{
				GameObject go = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = null;
				if (go != null)
					 pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(101);
			}
				break;
		

			case 102:
			case 103:
			case 104:
			case 105:
			case 106:
			case 107:
			case 108:
			case 109:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			
			// darkling troll cave
			case 119:
				
			{
				GameObject go = GameObject.Find(scr_popUpInfo.GetGoblinCaveName()) as GameObject;
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				progressBar pb = go.GetComponent<progressBar>();
				if(pb != null)
					pb.seconds = ReturnTimefrmSvr(typeId);
				
			}
				break;
			
			// hafling house
			case 110:
				
				{
				 	GameObject go = GameObject.Find("HC_B_House_GO(Clone)") as GameObject;
					go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
					upgradeProgressBar Upb = go.GetComponent<upgradeProgressBar>();
					if (Upb != null)
						Upb.seconds = ReturnTimefrmSvr(110);
			     }
				
				break;
			
			// darkling house
			case 120:
			   {
				
				 	GameObject go = GameObject.Find("DL_B_House_GO(Clone)") as GameObject;
					go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
					upgradeProgressBar Upb = go.GetComponent<upgradeProgressBar>();
					if (Upb != null)
						Upb.seconds = ReturnTimefrmSvr(120);
		    	}
				break;
			
			// barg
			case 22:
			{
			 	GameObject go = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Barg_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(22);
			}
				break;
	    
			// blacksmith
			case 19:
		    {
			  	GameObject go = GameObject.Find("HC_B_BlackSmith_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				
				upgradeProgressBar upb = go.GetComponent<upgradeProgressBar>();
				if(upb != null)
				  upb.seconds = ReturnTimefrmSvr(19);
				
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
			  		pb.seconds = ReturnTimefrmSvr(19);
			}
				break;
		
			// darkling tavern
			case 226:
			{
				GameObject go = GameObject.Find("DL_B_Tavern_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
			  		pb.seconds = ReturnTimefrmSvr(226);
			}
				break;
		
			// darkling apothecary
			case 228:
			{
				GameObject go = GameObject.Find("DL_B_Apothecary_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
			  		pb.seconds = ReturnTimefrmSvr(228);
			}
				break;
		
			// apothecary
			case 44:
			{
			  	GameObject go = GameObject.Find("HC_B_Apothecary_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
			  		pb.seconds = ReturnTimefrmSvr(44);
			}
				break;
		
			// leech
			case 208:
		    {
		     	GameObject go = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				Transform goChild = go.transform.FindChild("DL_C_Leech_GO(Clone)") as Transform;
				if (goChild != null)
				{
					goChild.gameObject.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
					progressBar pb = goChild.gameObject.GetComponent<progressBar>();
					if (pb != null)
						pb.seconds = ReturnTimefrmSvr(208);
				}
		    }
				break;
		
			// swamp training ground
			case 207:
			{
				GameObject go = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar pb = go.GetComponent<upgradeProgressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(207);
			}
				break;
		
			// dark earth training ground
			case 210:
			{
				GameObject go = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar pb = go.GetComponent<upgradeProgressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(210);
			}
				break;
		
			// water training ground
			case 29:
			{
				GameObject go = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar pb = go.GetComponent<upgradeProgressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(29);
			}
				break;
		
			// fire training ground
			case 214:
			{
				GameObject go = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar pb = go.GetComponent<upgradeProgressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(214);
			}
			break;
		
			// swamp obelisk
			case 223:
			{
				GameObject go = GameObject.Find("DL_B_SwampObelisk_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(223);
			}
				break;
			
			// dark earth obelisk
			case 227:
			{
				GameObject go = GameObject.Find("DL_B_EarthObelisk_GO(Clone)") as GameObject;
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(227);
			}
				
				break;
		
			// fenrir
			case 224:
			{
				GameObject go = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_Fenrir_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(224);
			}
				break;
			
			// dryad
			case 41:
			{
				GameObject go = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Dryad_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(41);
			}	
				break;
		
			// draug
			case 38:
			{
				GameObject go = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Draug_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(38);
			}
				break;
		
			// dagon
			case 50:
			{
				GameObject go = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("HC_C_Dragon_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(50);
			}
				break;
		
			// hell hound
			case 237:
			{
				GameObject go = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_HellHound_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(237);
			}
				break;
		
			// imp
			case 225:
			{
				GameObject go = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_Imp_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(225);
			}
				break;
		
			// djinn
			case 241:
			{
				GameObject go = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				GameObject goChild = go.transform.FindChild("DL_C_Djinn_GO(Clone)").gameObject;
				goChild.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				progressBar pb = goChild.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(241);
			}
				break;
	  
			// darkling inn
			case 203:
			{
				GameObject go =GameObject.Find("DL_B_Inn_GO(Clone)").gameObject; 
				go.renderer.material.color = new Color(go.renderer.material.color.r, go.renderer.material.color.g, go.renderer.material.color.b, 1f); 
				go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true); 
				upgradeProgressBar Upb = go.GetComponent<upgradeProgressBar>();
				if (Upb != null)
					Upb.seconds = ReturnTimefrmSvr(203);	
				
				progressBar pb = go.GetComponent<progressBar>();
				if (pb != null)
					pb.seconds = ReturnTimefrmSvr(203);	
			}
				break;
			
		case -1:
		  {
			//Debug.Log ("Type Id is empty");
		  }
			
			break;
			
		case 409:
		{
			Debug.Log("^^^^^^^^^^^^^^^^          bridge progress bar ---------------");
			bridgeHandBool = false;
			// Create Bridge Progress Bar
			GameObject bridgePBObj = Instantiate(bridgePB_pref, new Vector3(0, 0.1f, -5f), Quaternion.Euler(0, 180, 0)) as GameObject;
			progressBar bPB = bridgePBObj.GetComponent<progressBar>();
			GameManager.bridgeBuildBool = true;
			//objectSelection.objectSelectionBool = true;
			
			Transform rabbitButton = bridgePBObj.transform.FindChild("RabbtiButton") as Transform;
			if (rabbitButton != null)
			{
				rabbitButton.FindChild("Rabbit").gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_popUpInfo;
				rabbitButton.FindChild("Rabbit").gameObject.GetComponent<UIButton>().methodToInvoke = "taskBuildBridgePopup";
			}
			
			if (bPB != null)
			{
				bPB.seconds = ReturnTimefrmSvr(409);
				bPB.enabled = true;
			}
			
			GameObject bridge = GameObject.Find("BridgeBroken_GO") as GameObject;
			GameObject bridgeCol = GameObject.Find("bridgeCollider") as GameObject;
			if (bridgeCol != null)
			{
				bridgeCol.active = false;
			}
			
		}
			break;
		}
		
		if(scr_popUpInfo.TempTypeId != null)
		{
			scr_popUpInfo.TempTypeId = -1;
		}
	}
	
	public void AddQuest(int questNo)
	{ 
		SfsRemote.QuestInfo ques = new SfsRemote.QuestInfo();
		ques.questNo = questNo;
		
		scr_sfsRemote.lst_questInfo.Add(ques);
		
	}
	
	public void AddUserPurchases(int typeId,int Upid)
	{
		SfsRemote.SvrUserPurchases purchase = new SfsRemote.SvrUserPurchases();
		purchase.typeId = typeId;
		purchase.Upid = Upid;
		
		scr_sfsRemote.lst_UserPurchasesSvr.Add(purchase);
	}
	
    private void AddGameObjects(int objTypeid,int level,int objId,int currntFeed,int feedLevel,Vector3 position)
	{
		//adding typeIds 
		SfsRemote.SvrObjects svrObj = new SfsRemote.SvrObjects();
		svrObj.typeId = objTypeid;
		svrObj.level = level;
		svrObj.objId = objId;
		svrObj.currntFeed = currntFeed;
		svrObj.feedLevel = feedLevel;
		svrObj.position = position;
		
		scr_sfsRemote.lst_ObjSvr.Add(svrObj);
	}
	
	public void ObjectInfo(ISFSObject o)
	{
	    int objId = o.GetInt("object_id");
		int objTypeid = o.GetInt("object_type_id");
		int status = o.GetInt("status");
		string position = o.GetUtfString("position");
		string rotation = o.GetUtfString("orientation");
		int level = o.GetInt("level");
		int feedLevel = o.GetInt("feedLevel");
		double objgold = o.GetDouble("object_gold");
		int currentfoodfeed = o.GetInt("currentFoodFeed");
		
		AddGameObjects(objTypeid,level,objId,currentfoodfeed, feedLevel,parseVector3(position));
	}
	
	public void updateSvrObjects()
	{
		scr_guiControl.isGetMaxFeed = true;
		scr_sfsRemote.SendRequestForGetworld();
	}
	
	float tavernTym,apothecaryTym;
	public void ChkMiniGames()
	{
		GameObject tavern = GameObject.Find("HC_B_Tavern_GO(Clone)") as GameObject;
		GameObject apothecary = GameObject.Find("HC_B_Apothecary_GO(Clone)") as GameObject;
		GameObject darklingapothecary = GameObject.Find("DL_B_Apothecary_GO(Clone)") as GameObject;
		GameObject darklingtavern = GameObject.Find("DL_B_Tavern_GO(Clone)") as GameObject;
		
		if(tavern != null)
		{
			if (tavern.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				  tavernTym = ReturnTimefromMiniGameTimes("TavernMiniGame");
				   
				  if(tavernTym == -1)
				  {
					 tavern.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
					
					 Transform tavernBtn = tavern.transform.FindChild("TavernButton").gameObject.transform.FindChild("Tavern") as Transform;
					 tavernBtn.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
				  }
			}
		}
		
		
		if(darklingtavern != null)
		{
			if (darklingtavern.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				 tavernTym = ReturnTimefromMiniGameTimes("TavernMiniGame");
				   
				 if(tavernTym == -1)
				 {
					darklingtavern.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
					
					Transform tavernBtn = darklingtavern.transform.FindChild("TavernButton").gameObject.transform.FindChild("Tavern") as Transform;
					tavernBtn.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
				 }
			}
		}
		
		if(darklingapothecary != null)
		{
			if (darklingapothecary.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				apothecaryTym = ReturnTimefromMiniGameTimes("ApothecaryMiniGame");
			
			 	if(apothecaryTym == -1)
			 	{
					darklingapothecary.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
				
					Transform apothecaryBtn = darklingapothecary.transform.FindChild("ApothecaryButton").gameObject.transform.FindChild("Apothecary") as Transform;
					apothecaryBtn.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
			 	}
			}
		}
		
		
		if(apothecary != null)
		{
			if (apothecary.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
			 	apothecaryTym = ReturnTimefromMiniGameTimes("ApothecaryMiniGame");
			
			 	if(apothecaryTym == -1)
			 	{
					apothecary.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
				
					Transform apothecaryBtn = apothecary.transform.FindChild("ApothecaryButton").gameObject.transform.FindChild("Apothecary") as Transform;
					apothecaryBtn.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
			 	}
			}
		}
	}
	
	private GameObject goldBuilding;
	public void EnableGoldButton(int typeId ,double gold)
	{
		if(gold > 1)
		{
			switch(typeId)
			{
			case 6:
				goldBuilding = GameObject.Find("HC_B_Inn_GO(Clone)") as GameObject;
				
				break;
			case 19:
				goldBuilding = GameObject.Find("HC_B_BlackSmith_GO(Clone)") as GameObject;
				
				break; 
			case 30:
				goldBuilding = GameObject.Find("HC_B_Stable_GO(Clone)") as GameObject;
				
				break;
			case 203:
				goldBuilding = GameObject.Find("DL_B_Inn_GO(Clone)") as GameObject;
				
				break;
			case 218:
				goldBuilding = GameObject.Find("DL_B_DBlackSmith_GO(Clone)") as GameObject;
				
				break;
			case 211:
				goldBuilding = GameObject.Find("DL_B_Stable_GO(Clone)") as GameObject;
				
				break;
			}
			
			        GameObject goldButton = goldBuilding.transform.FindChild("GoldButton").gameObject;
					GameObject tempGold = goldButton.transform.FindChild("Gold").gameObject;
					tempGold.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
					goldButton.SetActiveRecursively(true);
		}
	}
	
	int tempFeed;
	public int ReturnCurrentFeed(int typeId)
	{
		for(int i=0; i< scr_sfsRemote.lst_ObjSvr.Count; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].typeId.Equals(typeId))
			{
				tempFeed = scr_sfsRemote.lst_ObjSvr[i].currntFeed;
			}
		}
		
		return tempFeed;
	}
	
	int tempObj;
	public int ReturnObjIdfromTypeId(int typeId)
	{
		for(int i=0; i< scr_sfsRemote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].typeId.Equals(typeId))
			{
				tempObj = scr_sfsRemote.lst_ObjSvr[i].objId;
				//Debug.Log("ObjId >>>> : "+ scr_sfsRemote.lst_ObjSvr[i].objId);
			}
		}
		return tempObj;
	}
	
	// find object with type id
	public int ReturnTypeIdfromObjId(int objId)
	{
//		Debug.Log("List count : " + scr_sfsRemote.lst_ObjSvr.Count);
		for(int i=0 ; i< scr_sfsRemote.lst_ObjSvr.Count; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].objId == objId)
			{
				return scr_sfsRemote.lst_ObjSvr[i].typeId;
			}
//			Debug.Log("id : "+scr_sfsRemote.lst_ObjSvr[i].typeId);
		}
		return -1;
	}
	
	private int leechCnt = 0, spriteCnt = 0;
	public void PlaceObjects(ISFSObject o)
	{
		
		int objId = o.GetInt("object_id");
		int objTypeid = o.GetInt("object_type_id");
		int status = o.GetInt("status");
		string position = o.GetUtfString("position");
		string rotation = o.GetUtfString("orientation");
		int level = o.GetInt("level");
		int feedLevel = o.GetInt("feedLevel");
		double objgold = o.GetDouble("object_gold");
		int currentfoodfeed = o.GetInt("currentFoodFeed");
		string cName = o.GetUtfString("objectNickName");
		
		AddGameObjects(objTypeid,level,objId,currentfoodfeed,feedLevel,parseVector3(position));
		
		switch(objTypeid)
		{
		case 101: // goblin cave 01			
			
			GameObject tempGC01 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)") as GameObject;
			
			if (tempGC01 == null)
			{
				Vector3  GoblinCavePos01 = parseVector3(position);	
				{
			 	 	Temp = Instantiate(hc_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
					Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
					//Temp.transform.position = new Vector3(-118.4f,(0.0306f - (0.95f/GameManager.layerDivVal)), 0.95f);
					
					Temp.gameObject.name = "HC_B_GoblinCamp_GO(Clone)_01";
					GameManager.hGCreature01 = Temp.transform.FindChild("GoblinChar01").gameObject.transform.position;
					GameManager.hGCreature02 = Temp.transform.FindChild("GoblinChar02").gameObject.transform.position;
					
					Transform healthPBHGB1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
					if (healthPBHGB1 != null)
						healthPBHGB1.gameObject.SetActiveRecursively(false);
					
					GameObject hGC01 = Temp.gameObject;
					hGC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
					hGC01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
					hGC01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
					
					//change textrue
					if (GameManager.gameLevel == 2)
					{
						hGC01.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
						hGC01.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
						hGC01.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
						hGC01.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
					}
					
					Transform rabbit = hGC01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
					UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
					delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
					
					if (IsConstructedOrNot(101))
					{
						
						hGoblinCave01_bool = true;
						hGC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						GameObject rabbitButtenEff = hGC01.transform.FindChild("RabbtiButton").gameObject;
						rabbitButtenEff.SetActiveRecursively(true);
						//rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = true;						
						buttonPulse rabbitButtBP = rabbitButtenEff.AddComponent("buttonPulse") as buttonPulse;
						rabbitButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
						rabbitButtBP.minSpeed = 3;
						rabbitButtBP.maxSpeed = 8;
						rabbitButtBP.minVal = 0.02f;
						rabbitButtBP.maxVal = 0.09f;
						rabbitButtBP.scaleAnim = true;
						
						hGC01.transform.GetComponent<progressBar>().enabled = true;
						progressBar bar = hGC01.transform.GetComponent<progressBar>();
					    scr_gameObjectSvr.objGoblinCamp01.CreateTime = (float)( ReturnConstructionTime(101));
						
						bar.seconds = (float) ReturnTimefrmSvr(101);
						
						//Debug.Log("creation Time : " + scr_gameObjectSvr.objGoblinCamp01.CreateTime);
						
						bar.cnt = (int)((scr_gameObjectSvr.objGoblinCamp01.CreateTime) - bar.seconds);
						float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGoblinCamp01.CreateTime;
						bar.seconds = scr_gameObjectSvr.objGoblinCamp01.CreateTime;
						bar.SecCnt = bar.seconds - bar.cnt;
						
						bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
						
						
						if (GameManager.gameLevel >= 3)
							delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
						else
							delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
						
						FindCreature(101, Temp);
						
						Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
						Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
						
						Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					}	
					else
					{
						if (GameManager.taskCount == 4)
						{
							//Debug.Log("----- goblin complete---- ");
							GameManager.taskCount = 5;
							scr_popUpInfo.updateTaskCount();
						}
					}
				}
			}
			
			break;
			
		case 102: // Goblin Camp 02
			
			GameObject tempGC02 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)") as GameObject;
			
			if (tempGC02 == null)
			{
				Vector3  GoblinCavePos02 = parseVector3(position);	
			 	Temp = Instantiate(hc_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
								
				Temp.gameObject.name = "HC_B_GoblinCamp_GO(Clone)_02";
				
				Transform healthPBHGB1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHGB1 != null)
					healthPBHGB1.gameObject.SetActiveRecursively(false);
				
				GameObject hGC02 = Temp.gameObject;
				hGC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				hGC02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hGC02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				//change textrue
				if (GameManager.gameLevel >= 4)
				{
					hGC02.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
				}
				
				Transform rabbit = hGC02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(102))
				{
					hGoblinCave02_bool = true;
					//Debug.Log("---- goblin cave not remove ---");
					hGC02.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
					hGC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hGC02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hGC02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hGC02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objGoblinCamp02.CreateTime = (float)( ReturnConstructionTime(102));
					
					bar.seconds = (float) ReturnTimefrmSvr(102);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objGoblinCamp02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objGoblinCamp02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGoblinCamp02.CreateTime;
					//bar.seconds = scr_gameObjectSvr.objGoblinCamp02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(102, Temp);
					//GameObject houndAttackObj = Instantiate(scr_gameManager.houndAttack_PF, new Vector3(Temp.transform.position.x + 5, Temp.transform.position.y, Temp.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
					//houndAttackObj.transform.localScale = new Vector3(houndAttackObj.transform.localScale.x * -1, houndAttackObj.transform.lossyScale.y, houndAttackObj.transform.localScale.z);
					Debug.Log("Temp : "+Temp.name);
					Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
					
					if(Temp.transform.FindChild("GoblinChar01").gameObject.tag == "Untagged" && Temp.GetComponent<OrcAttackTimer>() == null)
					{
						Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
					if(Temp.transform.FindChild("GoblinChar02").gameObject.tag == "Untagged" && Temp.GetComponent<OrcAttackTimer>() == null)
					{
						Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
						Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
						Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				
			}			
			break;
			
			
			
			
		case 103: // Goblin Camp 03
		
			GameObject tempGC03 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)") as GameObject;
			
			if (tempGC03 == null)
			{
				Vector3  GoblinCavePos03 = parseVector3(position);	
				Temp = Instantiate(hc_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				
				Temp.gameObject.name = "HC_B_GoblinCamp_GO(Clone)_03";
				
				Transform healthPBHGB1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHGB1 != null)
					healthPBHGB1.gameObject.SetActiveRecursively(false);
				
				GameObject hGC03 = Temp.gameObject;
				hGC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				hGC03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hGC03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				//change textrue
				if (GameManager.gameLevel >= 6)
				{
					hGC03.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
				}
				
				Transform rabbit = hGC03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;					
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(103))
				{
					
					int crId =  ReturnCreatureIdforCave(103);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					//Debug.Log("---- goblin cave not remove ---");
					hGoblinCave03_bool = true;
					hGC03.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
					hGC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hGC03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					if(rabbitButtenEff.GetComponent<buttonPulse>())
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hGC03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hGC03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objGoblinCamp03.CreateTime = (float)( ReturnConstructionTime(103));
					
					
					
//					progressBar bar = Temp.transform.GetComponent<progressBar>() ;
//			
//					float construct = (ReturnConstructionTime(objTypeID) * 60);
//			
//					//bar.seconds = (float) ReturnTimefrmSvr(objTypeID); 
//							
//					bar.cnt = (int)(construct - bar.seconds);
//					float remainTime = ((float)bar.cnt) / construct;
//					bar.seconds = construct;
//			
//					bar.SecCnt = (bar.seconds - ((float)bar.cnt));

					
					
					
					bar.seconds = (float)ReturnTimefrmSvr(103);
					
					Debug.Log("------> " + scr_gameObjectSvr.objGoblinCamp03.CreateTime + " <---------> " + bar.seconds);
					bar.cnt = (int)((scr_gameObjectSvr.objGoblinCamp03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGoblinCamp03.CreateTime;
					
					bar.seconds = scr_gameObjectSvr.objGoblinCamp03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					//float remainTime = (float)(bar.SecCnt / bar.seconds);
					//bar.cnt = (int)bar.SecCnt;
						
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(103, Temp);
					
					Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}			
			break;
			
		case 104: // hafling org cave
			
			
			GameObject tempOC01 = GameObject.Find("HC_B_OrgCave_GO(Clone)") as GameObject;
			//Vector3 OrgCavePos01 = parseVector3(position);
			
			if(tempOC01 == null)
			{
				Temp = Instantiate(hc_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_OrgCave_GO(Clone)_01";
				
				Transform healthPBHOC1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHOC1 != null)
					healthPBHOC1.gameObject.SetActiveRecursively(false);
				
				GameObject hOC01 = Temp.gameObject;
				hOC01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hOC01.transform.Find("ProgressBar").gameObject.SetActiveRecursively(false);
				hOC01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hOC01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(104))
				{
					//Debug.Log("---- Orgcave cave not remove ---");
					hOC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hOC01.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hOC01.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hOC01.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objOrgCave01.CreateTime = (float) ( ReturnConstructionTime(104));
					
					bar.seconds = (float) ReturnTimefrmSvr(104);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objOrgCave01.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objOrgCave01.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objOrgCave01.CreateTime;
					bar.seconds = scr_gameObjectSvr.objOrgCave01.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(104, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Orgcave  complete---- ");
				}
			}
			break;
			
		case 105: // halfling org cave 2
					
			GameObject tempOC02 = GameObject.Find("HC_B_OrgCave_GO(Clone)") as GameObject;
			
			if(tempOC02 == null)
			{
				Temp = Instantiate(hc_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_OrgCave_GO(Clone)_02";
				
				Transform healthPBHOC2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHOC2 != null)
					healthPBHOC2.gameObject.SetActiveRecursively(false);
				
				GameObject hOC02 = Temp.gameObject;
				hOC02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hOC02.transform.Find("ProgressBar").gameObject.SetActiveRecursively(false);
				hOC02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hOC02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(105))
				{
					//Debug.Log("---- Orgcave cave not remove ---");
					hOC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hOC02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hOC02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hOC02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objOrgCave02.CreateTime = (float)(ReturnConstructionTime(105));
					
					bar.seconds = (float)(ReturnTimefrmSvr(105));
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objOrgCave02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objOrgCave02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objOrgCave02.CreateTime;
					bar.seconds = scr_gameObjectSvr.objOrgCave02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(105, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Orgcave  complete---- ");
				}
			}
			
			break;
			
		case 106: // halfling org cave 3
			
			//Vector3 OrgCavePos03 = parseVector3(position);
			GameObject tempOC03 = GameObject.Find("HC_B_OrgCave_GO(Clone)") as GameObject;
			
			if(tempOC03 == null)
			{
				Temp = Instantiate(hc_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_OrgCave_GO(Clone)_03";
				
				Transform healthPBHOC3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHOC3 != null)
					healthPBHOC3.gameObject.SetActiveRecursively(false);
				
				GameObject hOC03 = Temp.gameObject;
				hOC03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hOC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				hOC03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hOC03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(106))
				{
					//Debug.Log("---- Orgcave cave not remove ---");
					hOC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hOC03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hOC03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hOC03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objOrgCave03.CreateTime = (float)(ReturnConstructionTime(106));
					
					bar.seconds = (float)(ReturnTimefrmSvr(106));
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objOrgCave03.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objOrgCave03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objOrgCave03.CreateTime;
					bar.seconds = scr_gameObjectSvr.objOrgCave03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(106, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Orgcave  complete---- ");
				}
			}
			break;
			
		case 107: // hafling troll house 1
			
			GameObject tempTC01 = GameObject.Find("HC_B_TrollHouse_GO(Clone)") as GameObject;
			//Vector3 TrollHousePos01 = parseVector3(position);
					
			if(tempTC01 == null)
			{
				Temp = Instantiate(hc_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_TrollHouse_GO(Clone)_01";
				
				Transform healthPBHTH1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHTH1 != null)
					healthPBHTH1.gameObject.SetActiveRecursively(false);
				
				GameObject hTH01 = Temp.gameObject;
		    	hTH01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);	
				hTH01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hTH01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hTH01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(107))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					hTrollCave01_bool = true;
					hTH01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hTH01.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					if(rabbitButtenEff.GetComponent<buttonPulse>())
						rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hTH01.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hTH01.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objTrollCave01.CreateTime = (float)(ReturnConstructionTime(107));
					
					bar.seconds = (float)(ReturnTimefrmSvr(107));
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objTrollCave01.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objTrollCave01.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objTrollCave01.CreateTime;
					bar.seconds = scr_gameObjectSvr.objTrollCave01.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(107, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
				
			}
			break;
			
		case 109: // hafling troll house 3
			
			GameObject tempTC03 = GameObject.Find("HC_B_TrollHouse_GO(Clone)") as GameObject;
			//Vector3 TrollHousePos02 = parseVector3(position);
			
			if(tempTC03 == null)
			{
				Temp = Instantiate(hc_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_TrollHouse_GO(Clone)_03";
				
				Transform healthPBHTH2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHTH2 != null)
					healthPBHTH2.gameObject.SetActiveRecursively(false);
				
				GameObject hTH03 = Temp.gameObject;
				hTH03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				hTH03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hTH03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hTH03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(109))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					hTrollCave03_bool = true;
					hTH03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hTH03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hTH03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hTH03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objTrollCave03.CreateTime = (float) (ReturnConstructionTime(109));
					
					bar.seconds = (float)(ReturnTimefrmSvr(109));
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objTrollCave03.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objTrollCave03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objTrollCave03.CreateTime;
					bar.seconds = scr_gameObjectSvr.objTrollCave03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(109, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 108: // hafling troll house 2
			
			GameObject tempTC02 = GameObject.Find("HC_B_TrollHouse_GO(Clone)") as GameObject;
			//Vector3 TrollHousePos03 = parseVector3(position);
			
			if(tempTC02 == null)
			{
				Temp = Instantiate(hc_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "HC_B_TrollHouse_GO(Clone)_02";
				
				Transform healthPBHTH3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBHTH3 != null)
					healthPBHTH3.gameObject.SetActiveRecursively(false);
				
				GameObject hTH02 = Temp.gameObject;
				hTH02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				hTH02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				hTH02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = hTH02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(108))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					hTrollCave02_bool = true;
					hTH02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = hTH02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					hTH02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = hTH02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objTrollCave02.CreateTime = (float)(ReturnConstructionTime(108));
					
					bar.seconds = (float) ReturnTimefrmSvr(108);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objTrollCave02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objTrollCave02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objTrollCave02.CreateTime;
					bar.seconds = scr_gameObjectSvr.objTrollCave02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(108, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 110: // halfling house
			
			
			Temp = Instantiate(house_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
		    Temp.transform.position = new Vector3(-67.16f, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), 5.98f);
			
			if(IsConstructedOrNot(110))
			{
				//Debug.Log("--- halfling house not Complete --- " + Temp.transform.Find("Isometric_Collider").gameObject.tag);
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";//"working";
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.constuctionLevel;
				//Debug.Log("new tag -------> " + Temp.transform.Find("Isometric_Collider").gameObject.tag);
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);

				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objHalflingHouse.CreateTime = (float) (ReturnConstructionTime(110) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(110);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(110));
			    bar.cnt = (int)(scr_gameObjectSvr.objHalflingHouse.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objHalflingHouse.CreateTime;
				bar.seconds = scr_gameObjectSvr.objHalflingHouse.CreateTime;

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				delObjUIButtonInfo.methodToInvoke = "upgradeHHouseRabbitButton";
				//GameManager.upgradeHHouseRabbit = true;
				
				scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				
				if(scr_guiControl.golum != null)
				{
					Destroy(scr_guiControl.golum);
					
					//Debug.Log("i am here buddy half");
					Vector3 unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
					GameObject golum = Instantiate(scr_guiControl.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
					
					scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
					fp.findGolum();
					fp.halfling_Generate = true;
					fp.Halfing_Front_Hammer = true;
				}
			}
			else
			{
				//Debug.Log("--- Halfling house Complete --- ");
			
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
				
			}
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			
			if (level == 2)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_House2;
				Temp.transform.FindChild("_House_Night").gameObject.renderer.material.mainTexture = scr_UpgradeTexture.h_House2N;
			}
			
			break;
			
		case 111: // darklilng goblin camp 1
			
			GameObject tempDGC01 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)") as GameObject;
			//Vector3  DarklingGoblinCavePos01 = parseVector3(position);	
			
			if(tempDGC01 == null)
			{
		 		Temp = Instantiate(dl_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "DL_B_GoblinCamp_GO(Clone)_01";
				
				Transform healthPBDGC1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDGC1 != null)
					healthPBDGC1.gameObject.SetActiveRecursively(false);
				
				GameObject dGC01 = Temp.gameObject;
				dGC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				dGC01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dGC01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dGC01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(111))
				{
					dGoblinCave01_bool = true;
					//Debug.Log("---- Troll cave cave not remove ---");
					dGC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dGC01.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dGC01.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dGC01.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingGoblinCamp01.CreateTime = (float)(ReturnConstructionTime(111));
					
					bar.seconds = (float)ReturnTimefrmSvr(111);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingGoblinCamp01.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingGoblinCamp01.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGoblinCamp01.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingGoblinCamp01.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
						
					FindCreature(111, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 112: // darklilng goblin camp 2
		
			GameObject tempDGC02 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)") as GameObject;
			//Vector3  DarklingGoblinCavePos02 = parseVector3(position);	
			
			if(tempDGC02 == null)
			{
		 		Temp = Instantiate(dl_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "DL_B_GoblinCamp_GO(Clone)_02";
				
				Transform healthPBDGC2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDGC2 != null)
					healthPBDGC2.gameObject.SetActiveRecursively(false);
				
				GameObject dGC02 = Temp.gameObject;
				dGC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				dGC02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dGC02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dGC02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(112))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dGoblinCave02_bool = true;
					dGC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dGC02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dGC02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dGC02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingGoblinCamp02.CreateTime = (float)(ReturnConstructionTime(112));
					
					bar.seconds = (float)ReturnTimefrmSvr(112);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingGoblinCamp02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingGoblinCamp02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGoblinCamp02.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingGoblinCamp02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(112, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			
			break;
			
		case 113: // darklilng goblin camp 3
		
			GameObject tempDGC03 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)") as GameObject;
			//Vector3  DarklingGoblinCavePos03 = parseVector3(position);	
			
			if(tempDGC03 == null)
			{
		 		Temp = Instantiate(dl_goblinCamp_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "DL_B_GoblinCamp_GO(Clone)_03";
				
				Transform healthPBDGC3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDGC3 != null)
					healthPBDGC3.gameObject.SetActiveRecursively(false);
				
				GameObject dGC03 = Temp.gameObject;
				dGC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				dGC03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dGC03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dGC03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(113))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dGoblinCave03_bool = true;
					dGC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dGC03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dGC03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dGC03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingGoblinCamp03.CreateTime = (float) (ReturnConstructionTime(113));
					
					bar.seconds = (float)ReturnTimefrmSvr(113);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingGoblinCamp03.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingGoblinCamp03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGoblinCamp03.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingGoblinCamp03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(113, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			
			break;
			
		case 114: // darklilng org cave 1
			
			GameObject tempDOC01 = GameObject.Find("DL_B_OrgCave_GO(Clone)") as GameObject;
			//Vector3 DarklingOrgCavePos01 = parseVector3(position);
			
			if(tempDOC01 == null)
			{
				Temp = Instantiate(dl_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				
				Temp.gameObject.name = "DL_B_OrgCave_GO(Clone)_01";
				
				Transform healthPBDOC1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDOC1 != null)
					healthPBDOC1.gameObject.SetActiveRecursively(false);
				
				GameObject dOC01 = Temp.gameObject;
				dOC01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dOC01.transform.Find("ProgressBar").gameObject.SetActiveRecursively(false);
				dOC01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dOC01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(114))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dOC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dOC01.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dOC01.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dOC01.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingOrgCave01.CreateTime = (float)(ReturnConstructionTime(114));
					
					bar.seconds = (float) ReturnTimefrmSvr(114);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingOrgCave01.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingOrgCave01.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingOrgCave01.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingOrgCave01.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(114, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 115: // darklilng org cave 2
			
			GameObject tempDOC02 = GameObject.Find("DL_B_OrgCave_GO(Clone)") as GameObject;
			
			//Vector3 DarklingOrgCavePos02 = parseVector3(position);
			
			if(tempDOC02 == null)
			{
				Temp = Instantiate(dl_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				
				Temp.gameObject.name = "DL_B_OrgCave_GO(Clone)_02";
				
				Transform healthPBDOC2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDOC2 != null)
					healthPBDOC2.gameObject.SetActiveRecursively(false);
				
				GameObject dOC02 = Temp.gameObject;
				dOC02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dOC02.transform.Find("ProgressBar").gameObject.SetActiveRecursively(false);
				dOC02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dOC02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(115))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dOC02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dOC02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dOC02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dOC02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingOrgCave02.CreateTime = (float) (ReturnConstructionTime(115));
					
					bar.seconds = (float) ReturnTimefrmSvr(115);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingOrgCave02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingOrgCave02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingOrgCave02.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingOrgCave02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(115, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 116: // darklilng org cave 3
			
			GameObject tempDOC03 = GameObject.Find("DL_B_OrgCave_GO(Clone)") as GameObject;
			//Vector3 DarklingOrgCavePos03 = parseVector3(position);
			
			if(tempDOC03 == null)
			{
				Temp = Instantiate(dl_OrgCave_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				
				Temp.gameObject.name = "DL_B_OrgCave_GO(Clone)_03";
				
				Transform healthPBDOC3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDOC3 != null)
					healthPBDOC3.gameObject.SetActiveRecursively(false);
				
				GameObject dOC03 = Temp.gameObject;
				dOC03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dOC03.transform.Find("ProgressBar").gameObject.SetActiveRecursively(false);
				dOC03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dOC03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(116))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dOC03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dOC03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dOC03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dOC03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingOrgCave03.CreateTime = (float) (ReturnConstructionTime(116));
					
					bar.seconds = (float) ReturnTimefrmSvr(116);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingOrgCave03.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingOrgCave03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingOrgCave03.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingOrgCave03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
					
					FindCreature(116, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("OrgChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("OrgChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("OrgChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
			
		case 117: // darklilng troll house 1
		
			GameObject tempDTH01 = GameObject.Find("DL_B_TrollHouse_GO(Clone)") as GameObject;
			// darkling troll house
			//Vector3 DarklingTrollHousePos01 = parseVector3(position);
			
			if(tempDTH01 == null)
			{
				Temp = Instantiate(dl_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "DL_B_TrollHouse_GO(Clone)_01";
				
				
				Transform healthPBDTH1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDTH1 != null)
					healthPBDTH1.gameObject.SetActiveRecursively(false);
				
				GameObject dTH01 = Temp.gameObject;
		    	dTH01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);	
				dTH01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dTH01.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dTH01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(117))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dTrollCave01_bool = true;
					dTH01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dTH01.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dTH01.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dTH01.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingTrollCave01.CreateTime = (float) (ReturnConstructionTime(117));
					
					bar.seconds = (float) ReturnTimefrmSvr(117);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingTrollCave01.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingTrollCave01.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingTrollCave01.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingTrollCave01.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
						
					FindCreature(117, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 118: // darklilng troll house 2
		
			GameObject tempDTH02 = GameObject.Find("DL_B_TrollHouse_GO(Clone)") as GameObject;
			//Vector3 DarklingTrollHousePos02 = parseVector3(position);
		
			if(tempDTH02 == null)
			{
				Temp = Instantiate(dl_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				Temp.transform.localScale = new Vector3(Temp.transform.localScale.x * -1, Temp.transform.localScale.y, Temp.transform.localScale.z);
				Temp.gameObject.name = "DL_B_TrollHouse_GO(Clone)_02";
				
				Transform healthPBDTH2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDTH2 != null)
					healthPBDTH2.gameObject.SetActiveRecursively(false);
				
				GameObject dTH02 = Temp.gameObject;
		    	dTH02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);	
				dTH02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);	
				dTH02.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dTH02.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(118))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dTrollCave02_bool = true;
					dTH02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dTH02.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dTH02.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dTH02.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingTrollCave02.CreateTime = (float) (ReturnConstructionTime(118));
					
					bar.seconds = (float) ReturnTimefrmSvr(118);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingTrollCave02.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingTrollCave02.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingTrollCave02.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingTrollCave02.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
							
					FindCreature(118, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			
			break;
			
		case 119: // darklilng troll house 3
			
			GameObject tempDTH03 = GameObject.Find("DL_B_TrollHouse_GO(Clone)") as GameObject;
			//Vector3 DarklingTrollHousePos03 = parseVector3(position);
			
			if(tempDTH03 == null)
			{
				Temp = Instantiate(dl_trollHouse_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
				Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
				
				Temp.gameObject.name = "DL_B_TrollHouse_GO(Clone)_03";
				
				Transform healthPBDTH3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
				if (healthPBDTH3 != null)
					healthPBDTH3.gameObject.SetActiveRecursively(false);
				
				GameObject dTH03 = Temp.gameObject;
		    	dTH03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);	
				dTH03.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				dTH03.transform.FindChild("CoolDown").gameObject.SetActiveRecursively(false);		//Amogh
				
				Transform rabbit = dTH03.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				
				if (IsConstructedOrNot(119))
				{
					//Debug.Log("---- Troll cave cave not remove ---");
					dTrollCave03_bool = true;
					dTH03.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					GameObject rabbitButtenEff = dTH03.transform.FindChild("RabbtiButton").gameObject;
					rabbitButtenEff.SetActiveRecursively(true);
					rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = false;						
					
					dTH03.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = dTH03.transform.GetComponent<progressBar>();
				    scr_gameObjectSvr.objDarklingTrollCave03.CreateTime = (float) (ReturnConstructionTime(119));
					
					bar.seconds = (float) ReturnTimefrmSvr(119);
					
					//Debug.Log("creation Time : " + scr_gameObjectSvr.objDarklingTrollCave03.CreateTime);
					
					bar.cnt = (int)((scr_gameObjectSvr.objDarklingTrollCave03.CreateTime) - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingTrollCave03.CreateTime;
					bar.seconds = scr_gameObjectSvr.objDarklingTrollCave03.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
						
					FindCreature(119, Temp);
					
					if (GameManager.gameLevel >= 3)
						delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
					else
						delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
					
					Temp.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = false;
					Temp.transform.FindChild("TrollChar02").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					Temp.transform.FindChild("TrollChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Temp.transform.FindChild("TrollChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				}	
				else
				{
						//Debug.Log("----- Troll cave  complete---- ");
				}
			}
			break;
			
		case 120: // darkling house
			
			Vector3 dHousePos = parseVector3(position);
			
			Temp = Instantiate(dl_house_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
		   	Temp.transform.position = new Vector3(67.16f, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), 5.98f);
			
			if(IsConstructedOrNot(120))
			{
				//Debug.Log("--- darkling house not Complete --- " + Temp.transform.Find("Isometric_Collider").gameObject.tag);
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "Dworking";//"working";
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.constuctionLevel;
				//Debug.Log("new tag -------> " + Temp.transform.Find("Isometric_Collider").gameObject.tag);

				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
							
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objDarklingHouse.CreateTime = (float) (ReturnConstructionTime(120) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(120);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(120));
			    bar.cnt = (int)(scr_gameObjectSvr.objDarklingHouse.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingHouse.CreateTime;
				bar.seconds = scr_gameObjectSvr.objDarklingHouse.CreateTime;

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				delObjUIButtonInfo.methodToInvoke = "upgradeDHouseRabbitButton";
				//GameManager.upgradeTrainingGroundBool = true;
				
				Vector3 unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
				GameObject Darkgolum = Instantiate(scr_guiControl.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
				scr_guiControl.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
			
				fp.darkling_Generate = true;
				fp.Darking_Front_Hammer = true;
			}
			else
			{
				//Debug.Log("--- Halfling house Complete --- ");
			
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			}
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			if (level == 2)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_house2;
				Temp.transform.FindChild("_DHouse_Night").gameObject.renderer.material.mainTexture = scr_UpgradeTexture.d_house2N;
			}
			
			break;
				
		case 2: // Halfling Earth Training Ground Upgrade
			
			Vector3 earthTGPos = parseVector3(position);
			
			Temp = Instantiate(trainingGrnd_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad(Temp, 2);
			
			GameManager.curTG = Temp;
			GameManager.earthTG_lvl = level;
			
			if (GameManager.earthTG_lvl == 2)
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.earthTG2;
			else if (GameManager.earthTG_lvl == 3)
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.earthTG3;
			
			break;
					
		case 3: // Halfling Hound
			
			Vector3 houndPos = parseVector3(position);
			GameObject go = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			
			CreatureLoad(Hound_pref, creatureLayerTop, houndPos,new Vector3(270, 180, 0), go, 3);
			scr_gameManager.houndName = cName;
			break;
			
		case 38:
			
			// Draug
		     Vector3 DraughPos = parseVector3(position);
			GameObject DraughTg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_draugh_pref, creatureLayerMid, DraughPos, new Vector3(90, 0, 0), DraughTg, 38);
			scr_gameManager.draugName = cName;
			GameManager.draug_lvl = feedLevel;
			
			break;
			
		case 41:
			
			// Dryad 
			
		     Vector3 DraydPos = parseVector3(position);
			GameObject DraydTg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			
			CreatureLoad(hl_dryad_pref, creatureLayerBack, DraydPos, new Vector3(90, 0, 0), DraydTg, 41);
			scr_gameManager.dryadName = cName;
			GameManager.dryad_lvl = feedLevel;
			
			break;
			
		case 42:
			
			//Halfling Tavern 
			
			Vector3 TavernPos = parseVector3(position);
			
			BuildingLoad(hl_tavern_pref, TavernPos, new Vector3(0, 180, 0), 42, scr_UpgradeTexture.h_Tavern, 
							scr_UpgradeTexture.h_Tavern, scr_UpgradeTexture.h_Tavern, false, scr_UpgradeTexture.h_Tavern, 
							scr_UpgradeTexture.h_Tavern, " ", status, level, objgold, true, false,objId);
			
			break;
			
		
		case 19: // Blacksmith
			
			Vector3 blacksmith = parseVector3(position);
			
			BuildingLoad(halflingBlacksmith_pref, blacksmith, new Vector3(0, 180, 0), 19, scr_UpgradeTexture.h_BlackSmith,
							scr_UpgradeTexture.h_BlackSmith2, scr_UpgradeTexture.h_BlackSmith2, true, 
							scr_UpgradeTexture.h_BlackSmith2, scr_UpgradeTexture.h_BlackSmith2, "_Night_BlackSmith", 
							status, level, objgold, true, false,objId);
			
			break;
			
		case 227:
			
			//Darkling EarthObelisk
			
			Vector3 darklingearthOblesikPos = parseVector3(position);
			
			BuildingLoad(dl_earthObelisk_pref, darklingearthOblesikPos, new Vector3(0, 180, 0), 227, 
							scr_UpgradeTexture.d_EarthObelisk, scr_UpgradeTexture.d_EarthObelisk2, 
							scr_UpgradeTexture.d_EarthObelisk3, false, scr_UpgradeTexture.d_EarthObelisk3,
							scr_UpgradeTexture.d_EarthObelisk3, " ", status, level, objgold, false, true,objId);
			
			break;
			
		case 232:
			//Darkling FireObelisk
			
			Vector3 FireOblesikPos = parseVector3(position);
			
			BuildingLoad(dl_fireObelisk_pref, FireOblesikPos, new Vector3(0, 180, 0), 232, 
							scr_UpgradeTexture.d_FireObelisk, scr_UpgradeTexture.d_FireObelisk2, 
							scr_UpgradeTexture.d_FireObelisk3, false, scr_UpgradeTexture.d_FireObelisk3, 
							scr_UpgradeTexture.d_FireObelisk3, " ", status, level, objgold, false, true,objId);
			
			break;
		case 37:
			
			// Earth obelsik 
			Vector3 EarthOblesikPos = parseVector3(position);
			
			BuildingLoad(hl_EarthObelsik_pref, EarthOblesikPos, new Vector3(0, 180, 0), 37, 
							scr_UpgradeTexture.h_EarthObelisk, scr_UpgradeTexture.h_EarthObelisk2, 
							scr_UpgradeTexture.h_EarthObelisk3, false, scr_UpgradeTexture.h_EarthObelisk3, 
				 			scr_UpgradeTexture.h_EarthObelisk3, " ", status, level, objgold, true, true, objId);
			
			break;
			
		case 43:
			
			//plant Obelisk
			
			Vector3 PlantOblesikPos = parseVector3(position);
			
			BuildingLoad(hl_plantObelsik_pref, PlantOblesikPos, new Vector3(0, 180, 0), 43, 
							scr_UpgradeTexture.h_PlantObelisk, scr_UpgradeTexture.h_PlantObelisk2, 
							scr_UpgradeTexture.h_PlantObelisk3, false, scr_UpgradeTexture.h_PlantObelisk3, 
							scr_UpgradeTexture.h_PlantObelisk3, " ", status, level, objgold, true, true,objId);
			
			break;
			
		case 48:
			
			//Water obelisk
			
			Vector3 WaterOblesikPos = parseVector3(position);
			
			BuildingLoad(hl_WaterObelsik_pref, WaterOblesikPos, new Vector3(0, 180, 0), 48, 
							scr_UpgradeTexture.h_WaterObelisk, scr_UpgradeTexture.h_WaterObelisk2, 
							scr_UpgradeTexture.h_WaterObelisk3, false, scr_UpgradeTexture.h_WaterObelisk3, 
							scr_UpgradeTexture.h_WaterObelisk3, " ", status, level, objgold, true, true,objId);
			
			break;
			
		case 12:	// Halfling DirtPath
			
			Vector3 dirtPos = parseVector3(position);
			Vector3 dirtRot = parseVector3(rotation);
			
			Temp = Instantiate(dirtPath_pref,parseVector3(position),Quaternion.Euler(0, 180, 0)) as GameObject;
			
			
			LoadDecoration(Temp);
			
//			Debug.Log("^^^^^^^^^^^^^^^^ " + Temp.transform.position.x + "  " + Temp.transform.position.z);
			
			if (//(Temp.transform.position.x == -62.6f && Temp.transform.position.z == 1.4f)||
				(Temp.transform.position.x == -64.24f && Temp.transform.position.z == 1.47f))
			{
				Debug.Log("****************** " + Temp.transform.position.x + "  " + Temp.transform.position.z);
				Temp.transform.position = new Vector3(-64.24f, Temp.transform.position.y, 1.46f);
				Temp.tag = "notDelete";
				//boxMove.checkBool = true;
				hCharMove.addWaypointBool = true;
				hCharMove.findWaypointBool = true;
			}
			
			hDirtPathCnt++;
			
			if (hDirtPathCnt == 1)
				scr_popUpInfo.scr_CharMove.status = "Left";
			else
			{
				scr_popUpInfo.scr_CharMove.status = "Front";
				scr_popUpInfo.scr_CharMove.h_FrontWalk.GetComponent<MeshRenderer>().enabled = true;
				scr_popUpInfo.scr_CharMove.h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
			}
			
			if (dirtPathCount == 0)
			{
//				Debug.Log("~~~> Dirt path ~~~> " + Temp.transform.position);
				GameManager.lastDirtPathPosition = Temp.transform.position;
				dirtPathCount++;
			}
			GameObject desCol = GameObject.Find("pathCol") as GameObject;
			if (desCol != null)
				Destroy(desCol);
			
			break;
		
		case 32:	// Nymph
			
			Vector3 NymphPos = parseVector3(position);
			GameObject goPlantTg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			
			CreatureLoad(hl_Nymph, creatureLayerMid, NymphPos, new Vector3(270, 180, 0), goPlantTg, 32);
			scr_gameManager.nymphName = cName;
			GameManager.nymph_lvl = feedLevel;
			
			break;
			
		case 33:	// Halfling Lantern
			
		    Vector3 LanternPos = parseVector3(position);
			Vector3 lanternRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_lanternPref,parseVector3(position),Quaternion.Euler(lanternRot.x, lanternRot.y, lanternRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 58: //Barrel
			
			Vector3 BarrelPos = parseVector3(position);
			Vector3 barrelRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_barrel,parseVector3(position),Quaternion.Euler(barrelRot.x, barrelRot.y, barrelRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
		case 212:	// Darkling Bog
			
			Vector3 bogPos = parseVector3(position);
			Vector3 bogRot = parseVector3(rotation);
			
			Temp = Instantiate(DarklingBog_pref,parseVector3(position),Quaternion.Euler(bogRot.x, bogRot.y, bogRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 13:
			
			//Debug.Log("halfling Tree1");
			Vector3 Tree1Pos = parseVector3(position);
			Vector3 tree1Rot = parseVector3(rotation);
			
			Temp = Instantiate(hl_tree1,parseVector3(position),Quaternion.Euler(tree1Rot.x, tree1Rot.y, tree1Rot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 15:
			//Debug.Log("halfling well");
			
			Vector3 WellPos = parseVector3(position);
			Vector3 wellRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_well,parseVector3(position),Quaternion.Euler(wellRot.x, wellRot.y, wellRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
        	case 31:	// Halfling Fruit Tree
			
			//Debug.Log("Fruit tree1");
			Vector3 fruitTreePos = parseVector3(position);
			Vector3 fruitTreeRot = parseVector3(rotation);
			
			Temp = Instantiate(scr_gameManager.h_FruitTree_PF, parseVector3(position), Quaternion.Euler(fruitTreeRot.x, fruitTreeRot.y, fruitTreeRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
			
		case 4:		// Garden Plot
			
			Vector3 plotPos = parseVector3(position);
			
			Temp = Instantiate(Plotgarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			Temp.gameObject.name = "HC_B_Plot_GO(Clone)";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
					
			Transform healthPB = Temp.transform.FindChild("HealthProgressBar") as Transform;
			if (healthPB != null)
				healthPB.gameObject.SetActiveRecursively(false);
			
			if(IsConstructedOrNot(4))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objGarden.CreateTime = (float) (ReturnConstructionTime(4) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(4);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(4));
			    bar.cnt = (int)(scr_gameObjectSvr.objGarden.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGarden.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGarden.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject plotUI = Temp.transform.FindChild("UI").gameObject;
				GameObject plotButt = plotUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				plotButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject plotCancle = plotUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				plotCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(plotPos);
			//GameManager.plot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			break;
			
			
		case 50:
			//Dragon
			
			Vector3 DragonPos = parseVector3(position);
			GameObject DragonTg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			
			CreatureLoad(hl_dragon_pref, creatureLayerBack, DragonPos, new Vector3(90, 0, 0), DragonTg, 50);
			scr_gameManager.dragonName = cName;
			GameManager.dragon_lvl = feedLevel;
			//SetFoodLevelPB((float)currentfoodfeed,(float)scr_creatureSystem.dragon.maxFeed);
			
			break;
		case 228:
			//Darkling Apotecary
			
			Vector3 DarklingApothecaryPos = parseVector3(position);
			
			BuildingLoad(dl_Apothecary, DarklingApothecaryPos, new Vector3(0, 180, 0), 228, 
							scr_UpgradeTexture.d_Apothecary, scr_UpgradeTexture.d_Apothecary, 
							scr_UpgradeTexture.d_Apothecary, false, scr_UpgradeTexture.d_Apothecary, 
							scr_UpgradeTexture.d_Apothecary, " ", status, level, objgold, false, false,objId);
			
			break;
		case 226:
			
			//Darkling Tavern
			Vector3 DarklingTavernPos = parseVector3(position);
			
			BuildingLoad(dl_Tavern, DarklingTavernPos, new Vector3(0, 180, 0), 226, 
							scr_UpgradeTexture.d_Tavern, scr_UpgradeTexture.d_Tavern, 
							scr_UpgradeTexture.d_Tavern, false, scr_UpgradeTexture.d_Tavern, 
							scr_UpgradeTexture.d_Tavern, " ", status, level, objgold, false, false,objId);
			
			break;
			
			
		case 52:
			
			Vector3 SunShrinePos = parseVector3(position);
			
			Temp = Instantiate(hl_Sunshrine,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			if (IsConstructedOrNot(52))
			{
				//Debug.Log("--- Sunshrine not Complete --- ");
				GameManager.hBuildingConstructBool = false;
				Temp.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.constuctionLevel;
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<progressBar>().enabled = true;
				progressBar bar = Temp.transform.GetComponent<progressBar>() ;
				
				scr_gameObjectSvr.objSunshrine.CreateTime = (float) (ReturnConstructionTime(52) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(52);
				
			    bar.cnt = (int)(scr_gameObjectSvr.objSunshrine.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objSunshrine.CreateTime;
				bar.seconds = scr_gameObjectSvr.objSunshrine.CreateTime;

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
				{
					delObjUIButtonInfo.methodToInvoke = "rabbitButton";
					Temp.transform.FindChild("RabbtiButton").GetComponent<buttonPulse>().scaleAnim = true;
				}
			}
			else
			{
				GameObject SunShrineUI = Temp.transform.FindChild("UI").gameObject;
				GameObject SunShrineButt = SunShrineUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				SunShrineButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject SunShrineCancle = SunShrineUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			    SunShrineCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				//Debug.Log("--- Inn Complete --- ");
				Transform rabbitButt = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				rabbitButt.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
				rabbitButt.gameObject.GetComponent<UIButton>().methodToInvoke = "upgradeInnRabbitButton";
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Destroy(Temp.GetComponent<progressBar>());				
				
			}
			
			break;
			
		case 409: // bridge progress bar
			
			GameObject bridgePBDummy = GameObject.Find("Bridge_GO(Clone)") as GameObject;
			
			
			if (IsConstructedOrNot(409))
			{
				if (bridgePBDummy == null)
				{
					Temp = Instantiate(bridgePB_pref, new Vector3(0, 0.1f, -5), Quaternion.Euler(0, 180, 0)) as GameObject;
				
					Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
					
					Transform rabbitButton = Temp.transform.FindChild("RabbtiButton") as Transform;
					if (rabbitButton != null)
					{
						rabbitButton.FindChild("Rabbit").gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_popUpInfo;
						rabbitButton.FindChild("Rabbit").gameObject.GetComponent<UIButton>().methodToInvoke = "taskBuildBridgePopup";
					}
					
					Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
					Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
					Temp.transform.GetComponent<progressBar>().enabled = true;
					progressBar bar = Temp.transform.GetComponent<progressBar>() ;
					
					scr_gameObjectSvr.objBridge.CreateTime = (float) (ReturnConstructionTime(409) * 60);
					bar.seconds = (float) ReturnTimefrmSvr(409);
					
				    bar.cnt = (int)(scr_gameObjectSvr.objBridge.CreateTime - bar.seconds);
					float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objBridge.CreateTime;
					bar.seconds = scr_gameObjectSvr.objBridge.CreateTime;
					bar.SecCnt = bar.seconds - bar.cnt;
					
					bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																			bar.progressBarPov.transform.localScale.y, 
																			bar.progressBarPov.transform.localScale.z);
					GameManager.unlockDarklingBool = false;
					GameManager.bridgeBuildBool = true;
				}
				
			}
			else
			{
				GameManager.bridgeBuildBool = true;
				Debug.Log("Bridge construction is complete.......................................................");
				//bridge_mat.mainTexture = bridge_tex;
				GameObject.Find("BridgeBroken_GO").gameObject.renderer.material.mainTexture = bridge_tex;
				
				CameraControl.newArea = 0;//-17158.5f;
				GameObject bridge = GameObject.Find("BridgeBroken_GO") as GameObject;
				GameObject bridgeCol = GameObject.Find("bridgeCollider") as GameObject;
				scr_guiControl.EnableDarkling(scr_guiControl.DarklingUIbtn,true);
				GameManager.unlockDarklingBool = true;
				if (bridgeCol != null)
				{
					bridgeCol.active = false;
				}	
			}
			
			break;
			
		case 6: // Inn building
			
			Vector3 innPos = parseVector3(position);
			
			BuildingLoad(Inn_pref, innPos, new Vector3(0, 180, 0), 6, scr_UpgradeTexture.InnLevel_1, 
							scr_UpgradeTexture.InnLevel_2, scr_UpgradeTexture.InnLevel3, true, 
							scr_UpgradeTexture.InnLevel_2N, scr_UpgradeTexture.InnLevel_2N, "_Inn_Night", 
							status, level, objgold, true, false,objId);
			
			break;
			
			
		case 44:
			// apothecary
			
			Vector3 HalflingApothePos = parseVector3(position);
			
			BuildingLoad(hl_Apothecary, HalflingApothePos, new Vector3(0, 180, 0), 44, 
							scr_UpgradeTexture.h_Apothecary, scr_UpgradeTexture.h_Apothecary, 
							scr_UpgradeTexture.h_Apothecary, false, scr_UpgradeTexture.h_Apothecary, 
							scr_UpgradeTexture.h_Apothecary, " ", status, level, objgold, true, false,objId);
			
			break;
		case 14:
			
			Vector3 golumPos = parseVector3(position);
			Temp = Instantiate(Golum_pref,new Vector3(golumPos.x,0.02f,golumPos.z),Quaternion.Euler(90,0,0)) as GameObject;
			
			break;			
				
		case 244:
			
			Vector3 DarklinggolumPos = parseVector3(position);
			Temp = Instantiate(dl_golumPref,new Vector3(DarklinggolumPos.x,0.02f,DarklinggolumPos.z),Quaternion.Euler(90,0,0)) as GameObject;
				
			break;	
			
		case 20:	// Plant Training Ground
			
			Vector3 PlantTGPos = parseVector3(position);
			
			Temp = Instantiate(PlanttrainingGrnd_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad (Temp, 20);
			
			GameManager.curTG = Temp;
			GameManager.plantTG_lvl = level;
			
			if (GameManager.plantTG_lvl == 2)
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantTG2;
			else if (GameManager.plantTG_lvl == 3)
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantTG3;
			
			break;
			
		case 54:
			
			
			Vector3 plotPos4 = parseVector3(position);
			
			Temp = Instantiate(Plotgarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			Temp.gameObject.name = "HC_B_Plot_GO(Clone)_5";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform healthPB1 = Temp.transform.FindChild("HealthProgressBar") as Transform;
			if (healthPB1 != null)
				healthPB1.gameObject.SetActiveRecursively(false);
			
					
			if(IsConstructedOrNot(54))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objGarden05.CreateTime = (float) (ReturnConstructionTime(54) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(54);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(54));
			    bar.cnt = (int)(scr_gameObjectSvr.objGarden05.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGarden05.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGarden05.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject plot4UI = Temp.transform.FindChild("UI").gameObject;
				GameObject plot4Butt = plot4UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				plot4Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject plot4Cancle = plot4UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				plot4Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(plotPos4);
			//GameManager.plot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			scr_popUpInfo.cnGrnd ++;
			//Debug.Log("cnhhjhjkhkh>>>" + scr_popUpInfo.cnGrnd);
			break;
			
		case 35:
			
			// wheel barrow
			
			Vector3 WheelBarrowPos = parseVector3(position);
			Vector3 wheelBarrowRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_WheelBarrow,parseVector3(position),Quaternion.Euler(wheelBarrowRot.x, wheelBarrowRot.y, wheelBarrowRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 40:
			
			Vector3 ShroomeryPos = parseVector3(position);
			Vector3 shroomeryRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_Shroomery,parseVector3(position),Quaternion.Euler(shroomeryRot.x, shroomeryRot.y, shroomeryRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
				
			
		case 46:
			
			Vector3 plotPos3 = parseVector3(position);
			
			Temp = Instantiate(Plotgarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			Temp.gameObject.name = "HC_B_Plot_GO(Clone)_4";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform healthPB2 = Temp.transform.FindChild("HealthProgressBar") as Transform;
			if (healthPB2 != null)
				healthPB2.gameObject.SetActiveRecursively(false);
					
			if(IsConstructedOrNot(46))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objGarden04.CreateTime = (float)  (ReturnConstructionTime(46) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(46);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(46));
			    bar.cnt = (int)(scr_gameObjectSvr.objGarden04.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGarden04.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGarden04.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject plot3UI = Temp.transform.FindChild("UI").gameObject;
				GameObject plot3Butt = plot3UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				plot3Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject plot3Cancle = plot3UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				plot3Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(plotPos3);
			//GameManager.plot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			scr_popUpInfo.cnGrnd ++;
			//Debug.Log("cnhhjhjkhkh>>>" + scr_popUpInfo.cnGrnd);
			
			
			break;
			
		case 34:
			
			Vector3 plotPos2 = parseVector3(position);
			
			Temp = Instantiate(Plotgarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			Temp.gameObject.name = "HC_B_Plot_GO(Clone)_3";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform healthPB3 = Temp.transform.FindChild("HealthProgressBar") as Transform;
			if (healthPB3 != null)
				healthPB3.gameObject.SetActiveRecursively(false);
					
			if(IsConstructedOrNot(34))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objGarden03.CreateTime = (float) (ReturnConstructionTime(34) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(34);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(34));
			    bar.cnt = (int)(scr_gameObjectSvr.objGarden03.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGarden03.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGarden03.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject plot2UI = Temp.transform.FindChild("UI").gameObject;
				GameObject plot2Butt = plot2UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				plot2Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject plot2Cancle = plot2UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				plot2Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(plotPos2);
			//GameManager.plot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			scr_popUpInfo.cnGrnd ++;
			//Debug.Log("cnhhjhjkhkh>>>" + scr_popUpInfo.cnGrnd);
			
			break;
			
		case 28:	// Garden Plot 1
			Vector3 plotPos1 = parseVector3(position);
			
			Temp = Instantiate(Plotgarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			Temp.gameObject.name = "HC_B_Plot_GO(Clone)_2";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform healthPB4 = Temp.transform.FindChild("HealthProgressBar") as Transform;
			if (healthPB4 != null)
				healthPB4.gameObject.SetActiveRecursively(false);
			
					
			if(IsConstructedOrNot(28))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objGarden02.CreateTime = (float)(ReturnConstructionTime(28) * 60);
				bar.seconds = (float)ReturnTimefrmSvr(28);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(28));
			    bar.cnt = (int)(scr_gameObjectSvr.objGarden02.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGarden02.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGarden02.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject plot1UI = Temp.transform.FindChild("UI").gameObject;
				GameObject plot1Butt = plot1UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				plot1Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject plot1Cancle = plot1UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				plot1Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(plotPos1);
			//GameManager.plot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			
			scr_popUpInfo.cnGrnd ++;
			//Debug.Log("cnhhjhjkhkh>>>" + scr_popUpInfo.cnGrnd);
			break;
			
			
		case 21:	// Sprout Creature
			
			Vector3 SproutPos = parseVector3(position);
			GameObject goSproutTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			
			CreatureLoad(Sprout_pref, creatureLayerTop, SproutPos, new Vector3(270, 180, 0), goSproutTG, 21);
			scr_gameManager.sproutName = cName;
			GameManager.sprout_lvl = feedLevel;
			Debug.Log("???????? : " + feedLevel);
			if (feedLevel == 0)
				feedLevel = 1;
			
			break;
			
		case 214:	// Darkling Fire Training Ground
			
			Vector3 DarkFireTGPos = parseVector3(position);
			
			Temp = Instantiate(DarklingFireTrainingGrnd,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad(Temp, 214);
			
			
			GameManager.curTG = Temp;
			GameManager.fireTG_lvl = level;
			
			if (level == 1)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.fireTG1;
				Temp.transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("FireTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 2)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.fireTG2;
				Temp.transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("FireTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 3)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.fireTG1;
				Temp.transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("FireTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}			
			
			break;
			
		case 215:	// Sprite Creature
			
			Vector3 SpritePos = parseVector3(position);
			GameObject goSpriteTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			
			CreatureLoad(Sprite_pref, creatureLayerTop, SpritePos, new Vector3(90, 0, 0), goSpriteTG, 215);
			scr_gameManager.spriteName = cName;
			GameManager.sprite_lvl = feedLevel;
			
			break;
			
			
		case 207:	// Swamp Training Ground
			
			Vector3 swampTGPos = parseVector3(position);
			
			Temp = Instantiate(SwampTrainingGrnd_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad(Temp, 207);
			
			
			GameManager.curTG = Temp;
			GameManager.swampTG_lvl = level;
			
			if (level == 1)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.swampTG1;
				Temp.transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("swampTG03_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 2)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.swampTG2;
				Temp.transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("swampTG03_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 3)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.swampTG3;
				Temp.transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("swampTG03_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			break;
			
			
		case 208:	// Leech Creature
			
			Vector3 LeechPos = parseVector3(position);
			
			GameObject leechTGObj = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			
			CreatureLoad(Leech_pref, creatureLayerTop, LeechPos, new Vector3(270, 180, 0), leechTGObj, 208);
			scr_gameManager.leechName = cName;
			GameManager.leech_lvl = feedLevel;
			
			break;
			
		case 203:	// Darkling Inn
			
			Vector3 dInnPos = parseVector3(position);
			
			BuildingLoad(DarklingInn_pref, dInnPos, new Vector3(0, 180, 0), 203, 
							scr_UpgradeTexture.dInnLevel1, scr_UpgradeTexture.dInnLevel_2, 
							scr_UpgradeTexture.dInnLevel_2, true, scr_UpgradeTexture.dInnLevel_2N, 
							scr_UpgradeTexture.dInnLevel_2N, "_DInn_Night", status, level, objgold, false, false,objId);
			
			break;
			
		case 201:	//  Darkling Garden Plot
			
			Vector3 DplotPos = parseVector3(position);
			
			Temp = Instantiate(DarklingGarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			Temp.gameObject.name = "DL_B_Plot_GO(Clone)_1";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					
			if(IsConstructedOrNot(201))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objDarklingGarden.CreateTime = (float) (ReturnConstructionTime(201) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(201);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(201));
			    bar.cnt = (int)(scr_gameObjectSvr.objDarklingGarden.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGarden.CreateTime;
				bar.seconds = scr_gameObjectSvr.objDarklingGarden.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject dPlotUI = Temp.transform.FindChild("UI").gameObject;
				GameObject dPlotButt = dPlotUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				dPlotButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject dPlotCancle = dPlotUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				dPlotCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
//				Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(DplotPos);
			//GameManager.dPlot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			scr_popUpInfo.cnDGrnd ++;
			
			break;
			
		case 205:	// Darkling DirtPath
			
			Vector3 dDirtPos = parseVector3(position);
			Vector3 dDirtRot = parseVector3(rotation);
			
			Temp = Instantiate(DarklingDirtPath_pref,parseVector3(position),Quaternion.Euler(dDirtRot.x, dDirtRot.y, dDirtRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			//if (Temp.transform.position.Equals(new Vector3(62.6f, 0, 1.4f)))
			if (Temp.transform.position.x == 64.24f && Temp.transform.position.z == 1.6f)
			{
				Debug.Log(">>>>>>>>>>>>>>>>>> DEC " + Temp.transform.position.x + "  " + Temp.transform.position.z);
				Temp.transform.position = new Vector3(64.24f, Temp.transform.position.y, 1.6f);
				Temp.tag = "notDelete";
				dCharMove.addWaypointBool = true;
				dCharMove.findWaypointBool = true;
			}
			
			if (dDirtPathCount == 0)
			{
//				Debug.Log("~~~> Dirt path ~~~> " + Temp.transform.position);
				Debug.Log("~~~> d dirtpath ~~~> " + Temp.transform.position);
				GameManager.lastDDirtPathPosition = Temp.transform.position;
				dDirtPathCount++;
			}
			
			GameObject dDesCol = GameObject.Find("dPathCol") as GameObject;
				if (dDesCol != null)
					Destroy(dDesCol);
			//	Temp.tag = "notDelete";
			//scr_popUpInfo.scr_DCharMove.status = "Front";
			
			
			break;
			
			
			
		case 206:	// Halfling Well
		
			Vector3 wellPos = parseVector3(position);
			Vector3 hWellRot = parseVector3(rotation);
			
			Temp = Instantiate(Well_pref,parseVector3(position),Quaternion.Euler(hWellRot.x, hWellRot.y, hWellRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 204:	// Halfling Tree 2
			
			Vector3 tree2Pos = parseVector3(position);
			Vector3 tree2Rot = parseVector3(rotation);
			
			Temp = Instantiate(Tree2_pref,parseVector3(position),Quaternion.Euler(tree2Rot.x, tree2Rot.y, tree2Rot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 22:	// Barg
			
			Vector3 BargPos = parseVector3(position);
			GameObject goTg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			
			CreatureLoad(Barg_pref, creatureLayerMid, BargPos,new Vector3(90, 0, 0), goTg, 22);
			scr_gameManager.bargName = cName;
			GameManager.barg_lvl = feedLevel;
			
			break;
			
		case 216:
			
			break;
			
		case 217:
			
			
			Vector3 dltree2Pos = parseVector3(position);
			Vector3 dltree2Rot = parseVector3(rotation);
			
			Temp = Instantiate(dl_Tree2_pref,parseVector3(position),Quaternion.Euler(dltree2Rot.x, dltree2Rot.y, dltree2Rot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 225: // Imp
			
			Vector3 ImpPos = parseVector3(position);
			GameObject FireTg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_Imp_pref, creatureLayerMid, ImpPos, new Vector3(90, 0, 0), FireTg, 225);
			scr_gameManager.impName = cName;
			GameManager.imp_lvl = feedLevel;
			//SetFoodLevelPB((float)currentfoodfeed,(float)scr_creatureSystem.imp.maxFeed);
			
			break;
			
		case 218:	// Darkling Black Smith
			
			Vector3 dblacksmith = parseVector3(position);
			
			BuildingLoad(DarklingBlacksmith_pref, dblacksmith, new Vector3(0, 180, 0), 218, 
							scr_UpgradeTexture.d_BlackSmith, scr_UpgradeTexture.dBlackSmith2, 
							scr_UpgradeTexture.dBlackSmith2, true, scr_UpgradeTexture.dBlackSmith2_N, 
							scr_UpgradeTexture.dBlackSmith2_N, "_DBlackSmith_Night", status, level, objgold, 
							false, false,objId);
			
		    break;
			
		case 239:
			
			Vector3 DplotPos3 = parseVector3(position);
			
			Temp = Instantiate(DarklingGarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			Temp.gameObject.name = "DL_B_Plot_GO(Clone)_4";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
					
			if(IsConstructedOrNot(239))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objDarklingGarden04.CreateTime = (float) (ReturnConstructionTime(239) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(239);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(239));
			    bar.cnt = (int)(scr_gameObjectSvr.objDarklingGarden04.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGarden04.CreateTime;
				bar.seconds = scr_gameObjectSvr.objDarklingGarden04.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject dPlot4UI = Temp.transform.FindChild("UI").gameObject;
				GameObject dPlot4Butt = dPlot4UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				dPlot4Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject dPlot4Cancle = dPlot4UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				dPlot4Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(DplotPos3);
			//GameManager.dPlot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			scr_popUpInfo.cnDGrnd ++ ;
						
			break;
			
		case 230:
			
			Vector3 DplotPos2 = parseVector3(position);
			
			Temp = Instantiate(DarklingGarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			Temp.gameObject.name = "DL_B_Plot_GO(Clone)_3";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;		
			
					
			if(IsConstructedOrNot(230))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objDarklingGarden03.CreateTime = (float) (ReturnConstructionTime(230) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(230);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(230));
			    bar.cnt = (int)(scr_gameObjectSvr.objDarklingGarden03.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGarden03.CreateTime;
				bar.seconds = scr_gameObjectSvr.objDarklingGarden03.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject dPlot3UI = Temp.transform.FindChild("UI").gameObject;
				GameObject dPlot3Butt = dPlot3UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				dPlot3Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject dPlot3Cancle = dPlot3UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				dPlot3Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(DplotPos2);
			//GameManager.dPlot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			scr_popUpInfo.cnDGrnd ++ ;
			
			break;
			
		case 219:	// Darkling Garden Plot 2
			Vector3 DplotPos1 = parseVector3(position);
			
			Temp = Instantiate(DarklingGarden_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			Temp.gameObject.name = "DL_B_Plot_GO(Clone)_2";
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;	
			
					
			if(IsConstructedOrNot(219))
			{
				//Debug.Log("--- Upgrade Plot not Complete --- ");
				
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.GetComponent<Sensors>().enabled = false;
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
				upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
				
				scr_gameObjectSvr.objDarklingGarden02.CreateTime = (float) (ReturnConstructionTime(219) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(219);
				//Debug.Log(">>>>>>>>>>>>>  " + ReturnTimefrmSvr(219));
			    bar.cnt = (int)(scr_gameObjectSvr.objDarklingGarden02.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objDarklingGarden02.CreateTime;
				bar.seconds = scr_gameObjectSvr.objDarklingGarden02.CreateTime;
				bar.SecCnt = bar.seconds - bar.cnt;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				//GameManager.upgradePlotBool = true;
			}
			else
			{
				GameObject dPlot2UI = Temp.transform.FindChild("UI").gameObject;
				GameObject dPlot2Butt = dPlot2UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				dPlot2Butt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject dPlot2Cancle = dPlot2UI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				dPlot2Cancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				Temp.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
			}
			AssignPlantsUnderGardenPlots(DplotPos1);
			//GameManager.dPlot_lvl = level;
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
			scr_popUpInfo.cnDGrnd ++ ;
			
			break;
			
		case 221:
			
			Vector3 RavenPerchPos = parseVector3(position);
			Vector3 ravenPerchRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_ravenPerch,parseVector3(position),Quaternion.Euler(ravenPerchRot.x, ravenPerchRot.y, ravenPerchRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		//decorations
			
		case 59:
			
			Vector3 ScareCrowPos = parseVector3(position);
			Vector3 scareCrowRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_Scarecrow,parseVector3(position),Quaternion.Euler(scareCrowRot.x, scareCrowRot.y, scareCrowRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
		case 60:
			
			Vector3 PartyTentPos = parseVector3(position);
			Vector3 partyTentRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_partyTent,parseVector3(position),Quaternion.Euler(partyTentRot.x, partyTentRot.y, partyTentRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 61:
			
			Vector3 KnollhillPos = parseVector3(position);
			Vector3 knollHillRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_knollHill,parseVector3(position),Quaternion.Euler(knollHillRot.x, knollHillRot.y, knollHillRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 62:
			
			Vector3 FencePos = parseVector3(position);
			Vector3 fenceRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_Fence,parseVector3(position),Quaternion.Euler(fenceRot.x, fenceRot.y, fenceRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 63:
			
			Vector3 CottagePos = parseVector3(position);
			Vector3 cottageRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_Cottage,parseVector3(position),Quaternion.Euler(cottageRot.x, cottageRot.y, cottageRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
			
		case 64:
			
			Vector3 CornfieldPos = parseVector3(position);
			Vector3 cornfieldRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_Cornfield,parseVector3(position),Quaternion.Euler(cornfieldRot.x, cornfieldRot.y, cornfieldRot.z)) as GameObject;
			
			LoadDecoration(Temp);
						
			break;
			
			
			//darkling decorations
			
		case 246:
			
			
			Vector3 darklingScarecrowPos = parseVector3(position);
			Vector3 darklingScarecrowRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_Scarecrow,parseVector3(position),Quaternion.Euler(darklingScarecrowRot.x, darklingScarecrowRot.y, darklingScarecrowRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
		case 247:
			
			
			
			Vector3 darklinghunttentPos = parseVector3(position);
			Vector3 darklingHuntRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_huntingtent,parseVector3(position),Quaternion.Euler(darklingHuntRot.x, darklingHuntRot.y, darklingHuntRot.z)) as GameObject;
			
			LoadDecoration(Temp);
						
			break;
		case 248:
			
			Vector3 darklingKnollhillPos = parseVector3(position);
			Vector3 dKnollHillRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_knollhill,parseVector3(position),Quaternion.Euler(dKnollHillRot.x, dKnollHillRot.y, dKnollHillRot.z)) as GameObject;
			
			LoadDecoration(Temp);
						
			break;
			
		case 249:
			
			Vector3 darklingFencePos = parseVector3(position);
			Vector3 dFenceRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_fence,parseVector3(position),Quaternion.Euler(dFenceRot.x, dFenceRot.y, dFenceRot.z)) as GameObject;
			
			LoadDecoration(Temp);
		
			break;
		case 250:
				
			
			Vector3 darklingBirdhousePos = parseVector3(position);
			Vector3 dBirdHouseRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_Birdhouse,parseVector3(position),Quaternion.Euler(dBirdHouseRot.x, dBirdHouseRot.y, dBirdHouseRot.z)) as GameObject;
			
			LoadDecoration(Temp);
									
			break;
			
		case 251:
			
			Vector3 darklingWindmill = parseVector3(position);
			Vector3 dWindMillRot = parseVector3(rotation);
			
			Temp = Instantiate(dl_windmill,parseVector3(position),Quaternion.Euler(dWindMillRot.x, dWindMillRot.y, dWindMillRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 65:
			
			Vector3 Windmill = parseVector3(position);
			Vector3 windMillRot = parseVector3(rotation);
			
			Temp = Instantiate(hl_windmill,parseVector3(position),Quaternion.Euler(windMillRot.x, windMillRot.y, windMillRot.z)) as GameObject;
			
			LoadDecoration(Temp);
			
			break;
			
		case 241:
									// Djinn
			
			Vector3 DjInnPos = parseVector3(position);
			
			GameObject DjInnTGObj = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_DjInn_pref, creatureLayerBack, DjInnPos, new Vector3(90, 0, 0), DjInnTGObj, 241);
			scr_gameManager.djinnName = cName;
			break;
			
	
		case 237:
			
			//darkling Hellhound
			
			Vector3 HellhoundPos = parseVector3(position);
			
			GameObject HellhoundTGObj = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_hellhound_pref, creatureLayerBack, HellhoundPos, new Vector3(90, 0, 0), HellhoundTGObj, 237);
			scr_gameManager.hellHoundName = cName;
			GameManager.hellHound_lvl = feedLevel;
			
			break;
			
		case 234:
			
			//darkling lurker
			
			Vector3 LurkerPos = parseVector3(position);
			
			GameObject lurkerTGObj = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_lurker, creatureLayerBack, LurkerPos, new Vector3(90, 0, 0), lurkerTGObj, 234);
			scr_gameManager.lurkerName = cName;
			GameManager.lurker_lvl = feedLevel;
			
			break;
			
		case 222:
			
			//darkling leshy
			
			Vector3 LeshyPos = parseVector3(position);
			
			GameObject leshyTGObj = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_darklingLeshy, creatureLayerMid, LeshyPos, new Vector3(270, 180, 0), leshyTGObj, 222);
			scr_gameManager.leshyName = cName;
			GameManager.leshy_lvl = feedLevel;
			
			break;
			
		case 223:
			
			//Darkling Swamp obelisk
			
			Vector3 DarklingSwampOblesikPos = parseVector3(position);
			
			BuildingLoad(dl_SwampObelsik_pref, DarklingSwampOblesikPos, new Vector3(0, 180, 0), 223, 
							scr_UpgradeTexture.d_SwampObelisk, scr_UpgradeTexture.d_SwampObelisk, 
							scr_UpgradeTexture.d_SwampObelisk3, false, scr_UpgradeTexture.d_SwampObelisk, 
							scr_UpgradeTexture.d_SwampObelisk3, " ", status, level, objgold, false, true,objId);
			
			break;
			
		case 224: // Fenrir
			
			Vector3 FenrirPos = parseVector3(position);
			GameObject FenrirTg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			
			CreatureLoad(dl_darklingFenrir_pref, creatureLayerMid, FenrirPos, new Vector3(90, 0, 0), FenrirTg, 224);
			scr_gameManager.fenrirName = cName;
			GameManager.fenrir_lvl = feedLevel;
			
			break;
			
		case 29:	// water TG
			
				Vector3 WaterTGPos = parseVector3(position);
			
			Temp = Instantiate(WaterTrainingGrnd_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad(Temp, 29);
			
			GameManager.curTG = Temp;
			GameManager.waterTG_lvl = level;
			
			if (level == 1)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.waterTG1;
				Temp.transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("waterTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 2)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.waterTG2;
				Temp.transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
				Temp.transform.FindChild("waterTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else if (level == 3)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.waterTG1;
				Temp.transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Temp.transform.FindChild("waterTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			break;
			
		case 26: // Cusith
			
			Vector3 CusithPos = parseVector3(position);
			GameObject CusithTg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			
			CreatureLoad(hl_cusith_pref, creatureLayerBack, CusithPos, new Vector3(90, 0, 0), CusithTg, 26);
			scr_gameManager.cusithName = cName;
			GameManager.cusith_lvl = feedLevel;
			
			break;
			
		case 24:	// Nix
			
			Vector3 NixPos = parseVector3(position);
			GameObject nixGo = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			
			CreatureLoad(Nix_pref, creatureLayerTop, NixPos, new Vector3(90, 0, 0), nixGo, 24);
			scr_gameManager.nixName = cName;
			GameManager.nix_lvl = feedLevel;
			//SetFoodLevelPB((float)currentfoodfeed,(float)scr_creatureSystem.nix.maxFeed);
			
			break;
			
		case 236:
			// moonshrine
			
			Vector3 Pos = parseVector3(position);
			
			Temp = Instantiate(dl_Moonshrine,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
			
			if (IsConstructedOrNot(236))
			{
				//Debug.Log("--- Moonshrine Working --- ");
				GameManager.dBuildingConstructBool = false;
				Temp.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.constuctionLevel;
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				//Temp.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				//Destroy(Temp.gameObject.GetComponent<Sensors>());
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<progressBar>().enabled = true;
				progressBar bar = Temp.transform.GetComponent<progressBar>() ;
				
				scr_gameObjectSvr.objMoonShrine.CreateTime = (float) (ReturnConstructionTime(236) * 60);
				bar.seconds = (float) ReturnTimefrmSvr(236);
				
			    bar.cnt = (int)(scr_gameObjectSvr.objMoonShrine.CreateTime - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objMoonShrine.CreateTime;
				bar.seconds = scr_gameObjectSvr.objMoonShrine.CreateTime;

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
					delObjUIButtonInfo.methodToInvoke = "rabbitButton";
			}
			
			else
			{
				//Debug.Log("--- MoonShrine Complete --- ");
				
				GameObject MoonShrineUI = Temp.transform.FindChild("UI").gameObject;
				GameObject MoonShrineButt = MoonShrineUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
				MoonShrineButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
				
				GameObject MoonShrineCancle = MoonShrineUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
				MoonShrineCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
				//Temp.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
				Temp.transform.FindChild("touchMovePlane").gameObject.active = false;
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("redPatch").gameObject.active = false;
				Temp.transform.FindChild("greenPatch").gameObject.active = false;
				Temp.transform.FindChild("selectionPatch").gameObject.active = false;
				Temp.gameObject.GetComponent<Sensors>().enabled = false;
				//Destroy(Temp.gameObject.GetComponent<Sensors>());
			}
			
			
			break;
		case 211:	// Darkling Stable
			
			Vector3 dStablePos = parseVector3(position);
			
			BuildingLoad(Darkstable_pref, dStablePos, new Vector3(0, 180, 0), 211, 
							scr_UpgradeTexture.d_Stable1, scr_UpgradeTexture.d_Stable2, 
							scr_UpgradeTexture.d_Stable2, false, scr_UpgradeTexture.d_Stable2, 
							scr_UpgradeTexture.d_Stable2, " ", status, level, objgold, false, false,objId);
			
			break;
			
		case 30:	// Stable
			
			Vector3 hStablePos = parseVector3(position);
			
			BuildingLoad(Halflingstable_pref, hStablePos, new Vector3(0, 180, 0), 30, 
							scr_UpgradeTexture.h_Stable1, scr_UpgradeTexture.h_Stable2, 
							scr_UpgradeTexture.h_Stable2, false, scr_UpgradeTexture.h_Stable1, 
							scr_UpgradeTexture.h_Stable2, "_Night_Stable", status, level, objgold, true, false,objId);
			
			break;
			
		case 210:	// Darkling Eirth Training Ground
			
				Vector3 DarkearthTGPos = parseVector3(position);
			
			Temp = Instantiate(DarkearthTrainingGrnd_pref,parseVector3(position),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			
			TrainingGroundLoad(Temp, 210);
			
			GameManager.curTG = Temp;
			GameManager.dEarthTG_lvl = level;
			
			break;
			
		case 209:	// Dark Hound
			
			Vector3 DarkHoundPos = parseVector3(position);
			GameObject Darkearth = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			
			CreatureLoad(Darkhound_pref, creatureLayerTop, DarkHoundPos, new Vector3(90, 0, 0), Darkearth, 209);
			scr_gameManager.dHoundName = cName;
			GameManager.dHound_lvl = feedLevel;
			
			break;
			
		}
	}
	
	
	private Vector3 parseVector3(string rString)	
	{
       // Debug.Log("rstring" + rString);
		string[] temp = rString.Substring(1,rString.Length-2).Split(',');
		Vector3 rValue = Vector3.zero;
		if (temp.Length > 0) {
				float x = float.Parse (temp [0]);
				float y = float.Parse (temp [1]);
				float z = float.Parse (temp [2]);
				 rValue = new Vector3 (x, y, z);	   
				}
		 return rValue;
	}
	
	private int myCnt = 0;
	public void setCurrentTutLevel()
	{
		//Debug.Log("Set Current Level :: check :: setCurrentTutLevel() Start");
		myCnt++;
		//Debug.Log("myCnt :: " + myCnt);
		
		if (runOnlyOnceBool)
		{
			//Debug.Log("Set Current Level :: check :: runOnlyOnceBool" + GameManager.gameLevel + " --- " + GameManager.levelXPCnt);
			if (GameManager.gameLevel >= 3)
			{
				//Debug.Log("Set Current Level :: check :: GameManager.gameLevel >= 3");
				scr_guiControl.timeDisplayHUD.SetActiveRecursively(true);// = true;
			}
			
			if (GameManager.gameLevel >= 1)
			{
				GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				
//				hGround.renderer.material.color = eTG.renderer.material.color;
//				dGround.renderer.material.color = eTG.renderer.material.color;
				
				scr_gameManager.loadingBool = false;
				
				//Debug.Log("Set Current Level :: check :: GameManager.gameLevel >= 3");
				scr_gameManager.loadingBool = false;
				if (scr_guiControl.popUpType4.active == true)
				{
					//Debug.Log("oooooooooooooooooooooooooooooooooooooooooooooooooooo");
					scr_guiControl.popUpType4.SetActiveRecursively(false);
				}
				if (scr_guiControl.popUpType5.active == true)
					scr_guiControl.popUpType5.SetActiveRecursively(false);
				
				if (GameManager.taskCount > 2)
				{
					//Debug.Log("Set Current Level :: check :: GameManager.taskCount > 2");
					GameObject delCol = GameObject.Find("pathCol") as GameObject;
					Destroy(delCol);
				}
			}

			// Level 1
			if(GameManager.gameLevel == 1)
			{
				
				Debug.Log("Set Current Level :: check :: game level == 1");
				GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				GameObject hnd = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
				GameObject dirtPath = GameObject.Find("HC_D_DirtPath_GO(Clone)") as GameObject;
				GameObject plot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
				Transform col = null;
//				Debug.Log("plot ---> " + plot.name);
				if (hnd != null)
					col = hnd.transform.FindChild("Isometric_Collider") as Transform;
				
				GameObject turnip = null;
				if(GetTurnips1() != null)
				{
					
				   turnip = plot.transform.FindChild(GetTurnips1()).gameObject;
//				Debug.Log("***************************** " + GetTurnips1());
				}
				
				Transform harvestButt = null;
				if (turnip != null)
				{
					harvestButt = turnip.transform.FindChild("HarvestButton") as Transform;
//					Debug.Log("***************************** " + harvestButt.gameObject.name + "  " + plot.gameObject.name + "  " + GameManager.xp);
				}
//				Debug.Log("plot 2 ---> " + plot.name + " -- " + hnd.name + " -- " + eTG.name);
				if (eTG == null)
				{
					Debug.Log("Set Current Level :: check :: eTG == null");
					GameManager.popUpCount = 1;
					GameManager.taskCount = 1;
					scr_popUpInfo.curPopUpCnt = 1;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
					
					panelControl.panelMoveOut = false;
					panelControl.panelMoveIn = true;
					GameObject arrow = GameObject.Find("ArrowPF(Clone)") as GameObject;
					Destroy(arrow);
					// market button effect
//					buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
//					marketBP.scaleAnim = false;
				}
				else if (hnd == null)
				{
					Debug.Log("Set Current Level :: check :: hnd == null");
					GameManager.popUpCount = 2;
					GameManager.taskCount = 2;
					scr_popUpInfo.curPopUpCnt = 1;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					GameObject.Find("ObjectEditPanel").gameObject.transform.FindChild("objUpgrade").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
					objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
				
					objEditPanelInfo.panelMoveIn = false;
					objEditPanelInfo.panelMoveOut = true;
				
					GameObject objInfo_spwan = GameObject.Find("objInfo_spwan") as GameObject;
					GameObject temp = Instantiate(scr_guiControl.arrow, objInfo_spwan.transform.position, Quaternion.Euler(90, 90,0)) as GameObject;
					scr_guiControl.delArrow = temp;
					
				}
				else if (col.gameObject.tag == "movableObj")
				{
					Debug.Log("Set Current Level :: check :: col.gameObject.tag == movableObj");
					
					GameManager.popUpCount = 4;
					scr_popUpInfo.updatePopUpCount();
					
					objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
					objEditPanelInfo.panelMoveIn = true;
					objEditPanelInfo.panelMoveOut = false;
				}
				else if (plot == null && hnd != null && eTG != null)
				{
					Debug.Log("Set Current Level :: check :: plot == null && hnd != null && eTG != null");
					
					GameObject arrow = GameObject.Find("ArrowPF(Clone)") as GameObject;
					if (arrow != null)
						Destroy(arrow);
					
					GameManager.popUpCount = 7;
					GameManager.taskCount = 3;
					scr_popUpInfo.curPopUpCnt = 6;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					
					panelControl.panelMoveOut = true;
					panelControl.panelMoveIn = false;
					
					// market button effect
					buttonPulse marketBP = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
					marketBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
					marketBP.minSpeed = 3;
					marketBP.maxSpeed = 8;
					marketBP.minVal = 0.05f;
					marketBP.maxVal = 0.2f;
					marketBP.scaleAnim = true;
					
					// arrow on market button
					GameObject ms = GameObject.Find("marketSpwan");
					GameObject temp = Instantiate(scr_guiControl.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
					scr_guiControl.delArrow = temp;
				}
				
				else if (plot != null && turnip == null && GameManager.xp <= 75)
				{
					Debug.Log("Set Current Level :: check :: plot != null && turnip == null...");
					GameManager.popUpCount = 8;
					scr_popUpInfo.updatePopUpCount();
					GameManager.taskCount = 4;
					scr_popUpInfo.curPopUpCnt = 7;
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					
					GameObject gArrow = Instantiate(scr_guiControl.gameArrow, new Vector3(plot.transform.position.x, plot.transform.position.y, plot.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
					scr_guiControl.delArrow = gArrow;
					GameManager.readyFarm = true;
				}
				
				else if (plot != null && turnip != null && GameManager.xp == 75 && harvestButt.gameObject.active == false)
				{
					Debug.Log("Set Current Level :: check :: plot != null && turnip == null...");
					GameManager.popUpCount = 8;
					scr_popUpInfo.updatePopUpCount();
					GameManager.taskCount = 4;
					scr_popUpInfo.curPopUpCnt = 8;
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
				}
				
				else if (turnip != null && GameManager.xp == 75)  //GameManager.xp >75 && GameManager.xp <= 76)// && GameManager.xp < 70)
				{
					if (harvestButt.gameObject.active == true)
					{
						Debug.Log("Set Current Level :: check :: turnip != null && GameManager.xp < 160");
						GameManager.popUpCount = 10;
						GameManager.taskCount = 5;
						scr_popUpInfo.curPopUpCnt = 9;
						scr_popUpInfo.curPopUpType = 0;
						scr_popUpInfo.updatePopUpCount();
						scr_popUpInfo.updateCurPopUpCount();
						scr_popUpInfo.updateTaskCount();
						scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
					}
					else
					{
						Debug.Log("Set Current Level :: check :: harvesh button.active == false");
						GameManager.popUpCount = 8;
						GameManager.taskCount = 4;
						scr_popUpInfo.curPopUpCnt = 7;
						scr_popUpInfo.curPopUpType = 0;
						scr_popUpInfo.updatePopUpCount();
						scr_popUpInfo.updateCurPopUpCount();
						scr_popUpInfo.updateTaskCount();
					}
				}
				
				else if (dirtPath == null && GameManager.xp > 75 && GameManager.taskCount != 7 && GameManager.taskCount != 8)
				{
					Debug.Log("Set Current Level :: check :: finish turnip and ready to feed");
					GameManager.popUpCount = 10;
					scr_popUpInfo.curPopUpCnt = 10;
					scr_popUpInfo.curPopUpType = 0;
					Debug.Log("-> task count : " + GameManager.taskCount);
					GameManager.taskCount = 6;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (dirtPath == null && GameManager.xp > 75 && GameManager.taskCount == 7)
				{
					Debug.Log("Set Current Level :: check :: rename the creature");
					GameManager.popUpCount = 12;
					scr_popUpInfo.curPopUpCnt = 12;
					scr_popUpInfo.curPopUpType = 0;
					GameManager.taskCount = 7;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (dirtPath == null && GameManager.taskCount == 8)
				{
					Debug.Log("Set Current Level :: check :: place dirtPath");
					
					GameManager.popUpCount = 13;
					scr_popUpInfo.curPopUpCnt = 13;
					scr_popUpInfo.curPopUpType = 0;
					GameManager.taskCount = 8;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (dirtPath != null && GameManager.taskCount == 8)
				{
					GameObject[] dpathList = GameObject.FindGameObjectsWithTag("Decoration");
					Debug.Log("Set Current Level :: check :: place dirtPath : count :: " + dpathList.Length); 
					scr_popUpInfo.placeDirtPathTutorial(6);
				}
				
//				else if (dirtPath == null && hnd != null && eTG != null)
//				{
//					Debug.Log("Set Current Level :: check :: dirthPath == null && hnd != null && eTG != null");
//					GameObject arrow = GameObject.Find("ArrowPF(Clone)") as GameObject;
//					if (arrow != null)
//						Destroy(arrow);
//					
//					GameManager.popUpCount = 6;
//					GameManager.taskCount = 3;
//					scr_popUpInfo.curPopUpCnt = 5;
//					scr_popUpInfo.updatePopUpCount();
//					scr_popUpInfo.updateCurPopUpCount();
//					scr_popUpInfo.updateTaskCount();
//					
//					panelControl.panelMoveOut = true;
//					panelControl.panelMoveIn = false;
//				
//					// market button effect
//					buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
//					marketBP.scaleAnim = true;
//					
//					// arrow on market button
//					GameObject ms = GameObject.Find("marketSpwan");
//					GameObject temp = Instantiate(scr_guiControl.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
//					scr_guiControl.delArrow = temp;
//					
//					objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
//					objEditPanelInfo.panelMoveIn = true;
//					objEditPanelInfo.panelMoveOut = false;
//				}
			}
			
			// Level 2
			if (GameManager.gameLevel == 2)
			{
				Debug.Log("Set Current Level :: check :: GameManager.gameLevel == 2");
				
				GameObject goblinCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
				GameObject earthObelisk = GameObject.Find("HC_B_EarthObelisk_GO(Clone)") as GameObject;
				
				if(GameManager.taskCount == 9)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 9");
					
					if (goblinCamp != null)
					{
						scr_gameManager.scr_UnlockCaveTimerTut = goblinCamp.AddComponent<unlockCaveTimerTut>();
						GameObject.Find("Main Camera").transform.position = GameObject.Find("goblinCamp_cPos").transform.position;
					}
				}
				
				if (GameManager.taskCount == 10 && earthObelisk == null)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 10");
					
					GameObject gPlot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
					GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					
					Transform cavCreature01 = goblinCamp.transform.FindChild("GoblinChar01") as Transform;
					Transform cavCreature02 = goblinCamp.transform.FindChild("GoblinChar02") as Transform;
					
					cavCreature01.position = new Vector3(gPlot.transform.position.x -3, cavCreature01.position.y, gPlot.transform.position.z - 1);
					cavCreature02.position = new Vector3(eTG.transform.position.x -4, cavCreature01.position.y, eTG.transform.position.z - 4.5f);
					
					cavCreature01.gameObject.GetComponent<MeshRenderer>().enabled = false;
					cavCreature02.gameObject.GetComponent<MeshRenderer>().enabled = false;
					
					cavCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					cavCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
					
					gPlot.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					gPlot.AddComponent<HealthProgressBarTutorial>();
					
					eTG.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
					eTG.AddComponent<HealthProgressBarTutorial>();
					
					GameManager.popUpCount = 17;
					scr_popUpInfo.curPopUpCnt = 17;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.popUpGuidObj.renderer.material.mainTexture = scr_popUpInfo.samTex;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (GameManager.taskCount == 10 && earthObelisk != null)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == earth Obelisk");
					
					GameManager.popUpCount = 18;
					scr_popUpInfo.curPopUpCnt = 18;
					GameManager.taskCount = 11;

					GameManager.popUpCount = 18;
					scr_popUpInfo.curPopUpCnt = 18;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (GameManager.taskCount == 11)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 11");
					
					GameManager.popUpCount = 18;
					scr_popUpInfo.curPopUpCnt = 18;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				
				else if (GameManager.taskCount == 12)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 12");
					GameObject.Find("Main Camera").transform.position = GameObject.Find("goblinCamp_cPos").transform.position;
				}
				
				else if (GameManager.taskCount == 13)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 13");
					
					GameManager.popUpCount = 20;
					scr_popUpInfo.curPopUpCnt = 19;
					
					scr_popUpInfo.task13Bubble();
				}
				
				else if (GameManager.taskCount == 14)
				{
					Debug.Log("Set Current Level :: check :: GameManager.taskCount == 14");
					
					scr_popUpInfo.task10(1);
				}
				
				else if (GameManager.taskCount == 15)
				{
					scr_guiControl.timeDisplayHUD.SetActiveRecursively(true);
					PlayerPrefs.SetInt("questtutorial",0);
					// log tutorial
					panelControl.panelMoveOut = true;
					panelControl.panelMoveIn = false;
					
					// market button effect
					buttonPulse marketBP = GameObject.Find("button_Task").AddComponent("buttonPulse") as buttonPulse;
					marketBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
					marketBP.minSpeed = 3;
					marketBP.maxSpeed = 8;
					marketBP.minVal = 0.05f;
					marketBP.maxVal = 0.2f;
					marketBP.scaleAnim = true;
					
					GameObject temp = Instantiate(scr_guiControl.arrow, new Vector3(-49, 10, 84), Quaternion.Euler(90, 180,0)) as GameObject;
					scr_guiControl.delArrow = temp;
					
					scr_taskDetails.RedQuestCount.Text = "1";
					scr_taskDetails.blueQuestCount.Text = "3";
				}
				
				/*GameObject goblinCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
				GameObject plot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
				GameObject turnip = null;
				
				if (GameManager.taskCount == 9)
				{
					Debug.Log("-> GameManager.taskCound == 9");
				}
				
				if(GetTurnips1() != null)
				{
				   turnip = plot.transform.FindChild(GetTurnips1()).gameObject;
				}
				//int turnipCount = ReturnGardenPlotCount(scr_gameObjectSvr.objTurnips.objTypeId);
				
				Debug.Log("Cout ????" + GetTurnips1());
				GameObject golum = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				GameObject innObj = GameObject.Find("HC_B_Inn_GO(Clone)") as GameObject;
				GameObject timeDisplayObje = GameObject.Find("timeDisplay") as GameObject;
				
				Transform harvestButt = null;
				if (turnip != null)
				{
					harvestButt = turnip.transform.FindChild("HarvestButton") as Transform;
				}
				
				// check goblin camp
				if (goblinCamp != null && GameManager.taskCount ==1)
				{
					//Debug.Log("Set Current Level :: check :: goblinCamp != null");
					GameObject arrow = GameObject.Find("ArrowPF(Clone)") as GameObject;
					if (arrow != null)
						Destroy(arrow);
					
					GameManager.popUpCount = 8;
					GameManager.taskCount = 4;
					scr_popUpInfo.curPopUpCnt = 7;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					
					// market button effect
					buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
					marketBP.scaleAnim = false;
					panelControl.panelMoveOut = false;
					panelControl.panelMoveIn = true;
					
					GameObject gCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
					
					if (!IsConstructedOrNot(101))
					{
						GameObject gArrow = Instantiate(scr_guiControl.gameArrow, new Vector3(gCamp.transform.position.x, gCamp.transform.position.y, gCamp.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
					}
					else
					{
						if (hGoblinCave01_bool)
						{
							Transform shadow = null;
							int crId =  ReturnCreatureIdforCave(101);
							scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
							string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
							//Debug.Log("Creature Name >>>>>> :" + creatureName);
							GameObject hGC_Creature = GameObject.Find(creatureName) as GameObject;
							
							if (hGC_Creature != null)
							{
								hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
								
								shadow = hGC_Creature.transform.FindChild("shadow") as Transform;
								if (shadow != null)
									shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
							}
						}
					}
					GameManager.readyAttact = true;
					
					
					GameObject camPos = GameObject.Find("Main Camera") as GameObject;
					GameObject goblinCampPos = GameObject.Find("goblinCamp_cPos") as GameObject;
					camPos.transform.position = new Vector3(goblinCampPos.transform.position.x, 40, goblinCampPos.transform.position.z);
				}
				else if (plot == null && goblinCamp == null && GameManager.xp < 50)
				{
					//Debug.Log("Set Current Level :: check :: plot == null && goblinCamp == null && GameManager.xp < 70");
					
					GameObject arrow = GameObject.Find("ArrowPF(Clone)") as GameObject;
					if (arrow != null)
						Destroy(arrow);
					buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
					marketBP.scaleAnim = false;
					panelControl.panelMoveOut = false;
					panelControl.panelMoveIn = true;
					
					GameManager.popUpCount = 9;
					GameManager.taskCount = 4;
					scr_popUpInfo.curPopUpCnt = 9;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				else if (plot != null && turnip == null && golum == null && GameManager.xp < 70)
				{
					//Debug.Log("Set Current Level :: check :: plot != null && turnip == null && golum == null && GameManager.xp < 160");
					GameManager.popUpCount = 12;
					scr_popUpInfo.updatePopUpCount();
					GameManager.taskCount = 6;
					scr_popUpInfo.curPopUpCnt = 11;
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					
					//GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
					
					GameObject gArrow = Instantiate(scr_guiControl.gameArrow, new Vector3(plot.transform.position.x, plot.transform.position.y, plot.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
					scr_guiControl.delArrow = gArrow;
					GameManager.readyFarm = true;
				}
				else if (turnip != null && GameManager.xp < 70)
				{
					if (harvestButt.gameObject.active == true)
					{
						//Debug.Log("Set Current Level :: check :: turnip != null && GameManager.xp < 160");
						GameManager.popUpCount = 13;
						GameManager.taskCount = 7;
						scr_popUpInfo.curPopUpCnt = 13;
						scr_popUpInfo.curPopUpType = 0;
						scr_popUpInfo.updatePopUpCount();
						scr_popUpInfo.updateCurPopUpCount();
						scr_popUpInfo.updateTaskCount();
						scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
					}
				}
				else if (plot != null && GameManager.xp > 70 && GameManager.xp < 80)
				{	
					//Debug.Log("Set Current Level :: check :: plot != null && GameManager.xp > 160 && GameManager.xp < 170");
					GameManager.popUpCount = 14;
					GameManager.taskCount = 7;
					scr_popUpInfo.curPopUpCnt = 14;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				else if (golum != null && innObj == null)
				{
					//Debug.Log("Set Current Level :: check :: golum != null && innObj == null");
					GameObject arrow = GameObject.Find("gameArrowPF(Clone)") as GameObject;
					if (arrow != null)
						Destroy(arrow);
					GameManager.popUpCount = 16;
					GameManager.taskCount = 9;
					scr_popUpInfo.curPopUpCnt = 16;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				else if (innObj != null && scr_guiControl.timeDisplayHUD.active == false && GameManager.xp < 149)//timeDisplayObje.active == false)
				{
					//Debug.Log("Set Current Level :: check :: innObj != null && scr_guiControl.timeDisplayHUD.active == false && GameManage.xp < 235");
					GameManager.popUpCount = 17;
					GameManager.taskCount = 9;
					scr_popUpInfo.curPopUpCnt = 16;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
				}
				else if (scr_guiControl.timeDisplayHUD.active == false && GameManager.xp > 149)
				{
					//Debug.Log("Set Current Level :: check :: scr_guiControl.timeDisplayHUD.active == false && GameManager.xp > 235");
					GameManager.popUpCount = 18;
					GameManager.taskCount = 9;
					scr_popUpInfo.curPopUpCnt = 18;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}*/
				//Debug.Log("Set Current Level :: check :: Level 2 Complete");
			}
			
			// Level 3
			if (GameManager.gameLevel == 3)
			{
				Debug.Log("Set Current Level :: check :: Level 3 Start");
				
				if (GameManager.taskCount >= 16)
				{
					Debug.Log("Set Current Level :: check :: task 16");
					GameManager.popUpCount = 22;
					scr_popUpInfo.curPopUpCnt = 22; // 21;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
				}
				
				/*GameObject qPBObj = GameObject.Find("QuestProgressBar(Clone)") as GameObject;
//				//Debug.Log("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
//				//Debug.Log("--- quest 0 --- ");
				if (GameManager.quest == 0 && qPBObj == null && GameManager.xp < 120)
				{
					//Debug.Log("Set Current Level :: check :: GameManager.quest == 0 && GameManager.storyCnt == 1");
					GameManager.questActivateBool = true;
					GameManager.popUpCount = 26;
					GameManager.taskCount = 9;
					scr_popUpInfo.curPopUpCnt = 26;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}
				else if (GameManager.quest == 0 && qPBObj != null)
				{
					GameManager.questRunningBool = true;
					scr_guiControl.popUpType4.SetActiveRecursively (true);
				}
			
				else if (GameManager.quest == 2 && GameManager.xp <= 120)
				{
					//Debug.Log("Set Current Level :: check :: GameManager.quest == 2 && GameManager.xp <= 120");
					GameManager.quest = 2;
					scr_sfsRemote.SendRequestforQuestCount(GameManager.quest);
				}
				else if (GameManager.quest == 2 && GameManager.xp >= 300)
				{
					//Debug.Log("Set Current Level :: check :: GameManager.quest == 2 && GameManager.xp >= 300");
					////Debug.Log(" --- quest 2 --- ");
					GameManager.popUpCount = 30;
					//GameManager.taskCount = 9;
					scr_popUpInfo.curPopUpCnt = 29;
					scr_popUpInfo.curPopUpType = 0;
					scr_popUpInfo.updatePopUpCount();
					scr_popUpInfo.updateCurPopUpCount();
					//scr_popUpInfo.updateTaskCount();
					scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				}*/
				//Debug.Log("Set Current Level :: check :: Level 3 Complete");
			}
			
			// level 4
			if (GameManager.gameLevel == 4 && GameManager.quest == 2 && !GameManager.unlockDarklingBool)
			{
				//Debug.Log("Set Current Level :: check :: GameManager.gameLevel == 4 && GameManager.quest == 2 && !GameManager.unlockDarklingBool");
				GameManager.popUpCount = 30;
				//GameManager.taskCount = 9;
				scr_popUpInfo.curPopUpCnt = 29;
				scr_popUpInfo.curPopUpType = 0;
				scr_popUpInfo.updatePopUpCount();
				scr_popUpInfo.updateCurPopUpCount();
				//scr_popUpInfo.updateTaskCount();
				//scr_popUpInfo.generatePopUp(scr_popUpInfo.curPopUpCnt, scr_popUpInfo.curPopUpType);
				GameObject bridgeSpwan = GameObject.Find("bridge_spwan") as GameObject;
				GameObject gArrow = Instantiate(scr_guiControl.gameArrow, bridgeSpwan.transform.position, Quaternion.Euler(270, 0, 0)) as GameObject;
				scr_guiControl.delArrow = gArrow;
				
				GameObject camPos =	GameObject.Find("Main Camera") as GameObject;
				GameObject bridgePos = GameObject.Find("bridge_cPos") as GameObject;
				
				camPos.transform.position = new Vector3(bridgePos.transform.position.x, 40, bridgePos.transform.position.z);
			}
			else if (GameManager.gameLevel >= 4)
			{
				//Debug.Log("Set Current Level :: check :: GameManager.gameLevel >= 4");
				scr_gameManager.loadingBool = false;
				
				// check halfling goblin cave remove task
				if (hGoblinCave01_bool)
				{
					//GameManager.houndUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(101);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject hGC_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hGC_Creature != null)
					{
						hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
					
						shadow = hGC_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (hGoblinCave02_bool)
				{
					//GameManager.sproutUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(102);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject hGC_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hGC_Creature != null)
					{
						hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = hGC_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (hGoblinCave03_bool)
				{
					//GameObject 
					//GameManager.bargUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(103);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject hGC_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hGC_Creature != null)
					{
						hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = hGC_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (dGoblinCave01_bool)
				{
					//GameManager.leechUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(111);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject dGC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dGC01_Creature != null)
					{
						dGC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dGC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (dGoblinCave02_bool)
				{
					//GameManager.dHoundUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(112);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject dGC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dGC01_Creature != null)
					{
						dGC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dGC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (dGoblinCave03_bool)
				{
					//GameManager.spriteUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(113);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject dGC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dGC01_Creature != null)
					{
						dGC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dGC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (hTrollCave01_bool)
				{
					//GameManager.nixUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(107);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject hTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hTC01_Creature != null)
					{
						hTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = hTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (hTrollCave02_bool)
				{
					//GameManager.nymphUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(108);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject hTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hTC01_Creature != null)
					{
						hTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = hTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (hTrollCave03_bool)
				{
					//GameManager.draugUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(109);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
										
					GameObject hTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (hTC01_Creature != null)
					{
						hTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = hTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
					}
				}
				if (dTrollCave01_bool)
				{
					//GameManager.leshyUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(117);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
															
					GameObject dTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dTC01_Creature != null)
					{
						dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;		
					}
				}
				
				if (dTrollCave02_bool)
				{
					//GameManager.fenrirUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(118);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject dTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dTC01_Creature != null)
					{
						dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;	
					}
				}
				
				if (dTrollCave03_bool)
				{
					//GameManager.impUsingBool = true;
					Transform shadow = null;
					int crId =  ReturnCreatureIdforCave(119);
					scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
					GameObject dTC01_Creature = GameObject.Find(creatureName) as GameObject;
					
					if (dTC01_Creature != null)
					{
						dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
						
						shadow = dTC01_Creature.transform.FindChild("shadow") as Transform;
						if (shadow != null)
							shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;	
					}
				}
			}
			
			if (GameManager.gameLevel >= 3)
			{
				if (GameManager.questRunningBool)
				{
					//Debug.Log("GameManager.questRunningBool...............");
					if (GameManager.quest == 0)
					{
						//Debug.Log("GameManager.quest == 0............................................");
						GameObject hGC_Creature = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
						
						if (hGC_Creature != null)
						{
							hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
							hGC_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = false;
						}
					}
				}
			}

			if (GameManager.gameLevel >= 4)
			{
				if (bridgeHandBool && !GameManager.unlockDarklingBool)
				{
					scr_popUpInfo.taskArrowOnBrokenBridge();
				}
			}
		}
		Debug.Log("~~~~~~~~~~~~~~~~~~ Dakling bool = " + GameManager.unlockDarklingBool + " -- " + bridgeHandBool);
	}
	
	Vector3 plantPos,plantRot; int plantTypeId; int plantId; int plantStatus;
	GameObject TempChild;
	public void AssignPlantsUnderGardenPlots(Vector3 pos)
	{
		for(int i=0 ; i < scr_sfsRemote.Plants.Size() ; i++)
		{
			ISFSObject plant = scr_sfsRemote.Plants.GetSFSObject(i);
			plantPos = parseVector3(plant.GetUtfString("position"));
			plantRot = parseVector3(plant.GetUtfString("orientation"));
			plantTypeId = plant.GetInt("object_type_id");
			plantId = plant.GetInt("object_id");
			plantStatus = plant.GetInt("status");
			
			if(pos.x.Equals(plantPos.x) && pos.z.Equals(plantPos.z))
			{
				if(plantTypeId == 5)
				{
			      	TempChild = Instantiate(PlantTurnip_pref,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				  	TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
				  	ConstructTurnips(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 27)
				{
					//halfling Pumpkin
					TempChild = Instantiate(Pumpkin_pref,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
					TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructHalflingPlants(plantId,TempChild,plantStatus);
					
				}
				else if(plantTypeId == 45)
				{
					//halfling Potatoes
					TempChild = Instantiate(hl_potatoes,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				    TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructHalflingPlants(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 47)
				{
					//halfling fairlilly
					TempChild = Instantiate(hl_fairlilly,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				    TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructHalflingPlants(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 49)
				{
					//halfling waterCress
					TempChild = Instantiate(hl_watercress,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				    TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructHalflingPlants(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 8)
				{
				  	TempChild = Instantiate(PlantPipeweed_pref,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				   	TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructHalflingPlants(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 202)
				{
					TempChild = Instantiate(dl_pumpkin,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				    TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructDarklingPlants(plantId,TempChild,plantStatus);
				}
				else if(plantTypeId == 213)
				{
					TempChild = Instantiate(FirePepper_pref,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
				    TempChild.transform.parent = Temp.transform;
					TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
					ConstructDarklingPlants(plantId,TempChild,plantStatus);
				}
				else 
				{
					if(plantTypeId == 229)
					{
						TempChild = Instantiate(dl_blackberry,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 231)
					{
						TempChild = Instantiate(dl_cloumbine,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 233)
					{
						TempChild = Instantiate(dl_bitterbush,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 238)
					{
						TempChild = Instantiate(dl_herbBogbean,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 235)
					{
						TempChild = Instantiate(dl_MoonFlower,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 240)
					{
						TempChild = Instantiate(dl_Herbwolfbane,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 220)
					{
						TempChild = Instantiate(dl_Aven,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructDarklingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 51)
					{
						TempChild = Instantiate(hl_sunflower,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructHalflingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 53)
					{
						TempChild = Instantiate(hl_vervain,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructHalflingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 55)
					{
						TempChild = Instantiate(hl_mandrake,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructHalflingPlants(plantId,TempChild,plantStatus);
					}
					else if(plantTypeId == 36)
					{
						TempChild = Instantiate(hl_costmary,new Vector3(plantPos.x,0.05f,plantPos.z),Quaternion.Euler(plantRot)) as GameObject;
						TempChild.transform.parent = Temp.transform;
						TempChild.transform.localPosition = new Vector3(0,0.0001f,0);
						ConstructHalflingPlants(plantId,TempChild,plantStatus);
					}
				}
			}
		}
	}
	
	private void ConstructPipeweed(int id,GameObject Temp,int status)
	{
		
			//Vector3 PipeweedPos = parseVector3(position);
			//Temp = Instantiate(PlantPipeweed_pref,new Vector3(PipeweedPos.x,0.05f,PipeweedPos.z),Quaternion.Euler(parseVector3(rotation))) as GameObject;
			Temp.name = Temp.name + "_" + id;
			if (IsConstructedOrNotforIds(id) && status != 6)
			{
				//Debug.Log("--- Pipe weed Plant Not Complete --- ");
				Temp.transform.root.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<progressBar>().enabled = true;
				progressBar bar = Temp.transform.GetComponent<progressBar>() ;
				
				scr_gameObjectSvr.objPipeweed.CreateTime = (ReturnConstructionTimeforIds(id) * 60);
				bar.seconds = ReturnTimefrmSvrforIds(id);
				
				bar.cnt = (int)(scr_gameObjectSvr.objPipeweed.CreateTime - bar.seconds);
				float remainTime = bar.cnt / scr_gameObjectSvr.objPipeweed.CreateTime;
				bar.seconds = scr_gameObjectSvr.objPipeweed.CreateTime;
			     bar.SecCnt = (bar.seconds - ((float)bar.cnt));
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
					delObjUIButtonInfo.methodToInvoke = "rabbitButton";
				
				Transform harvest1 = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
				UIButton delObjUIButtonInfo1 = harvest1.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo1.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
					delObjUIButtonInfo1.methodToInvoke = "harvestButton";
				else
					delObjUIButtonInfo1.methodToInvoke = "farmHarvestButton";
			}
			else
			{
				//Debug.Log("--- PipeWeed Plant Complete --- ");
				Destroy(Temp.GetComponent<progressBar>());
				Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
				UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
				//Debug.Log(harvest.gameObject.name + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				delObjUIButtonInfo.methodToInvoke = "farmHarvestButton";
				
				Temp.transform.GetComponent<progressBar>().enabled = false;
				
				Temp.gameObject.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.h_PipeWeed01;
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("HarvestButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
				
				if(status == 3)
				{
					Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantBurnTex;
					Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "burn";
					Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
				  //scr_sfsRemote.RemoveBurnedPlant(id);
				}
			}
	}
	
    private string Turnips; 
	public string GetTurnips1()
	{
	    return Turnips;
	}
		
	private void ConstructHalflingPlants(int id,GameObject Temp ,int status)
	{
		//Halfling Plants 
		
		Temp.name = Temp.name + "_" + id;
		  if (IsConstructedOrNotforIds(id) && status != 6)
		{
			////Debug.Log("--- Halfling Plant Not Complete --- pumpkin  " + Temp.transform.root.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag);
			//Debug.Log("---Halfling plants not complete --- " + Temp.name);
			
			Temp.transform.root.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("RabbtiButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			Temp.transform.GetComponent<progressBar>().enabled = true;
			progressBar bar = Temp.transform.GetComponent<progressBar>() ;
		
			
			float construct = (ReturnConstructionTimeforIds(id) * 60);
			bar.seconds = ReturnTimefrmSvrforIds(id);
			
			bar.cnt = (int)(construct - bar.seconds);
			float remainTime = bar.cnt / construct;
			bar.seconds = construct;
			bar.SecCnt = (bar.seconds - ((float)bar.cnt));

			
			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			delObjUIButtonInfo.methodToInvoke = "farmRabbitButton";
		    
			
			Transform harvest1 = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
			UIButton delObjUIButtonInfo1 = harvest1.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo1.scriptWithMethodToInvoke = scr_guiControl;
		        delObjUIButtonInfo1.methodToInvoke = "farmHarvestButton";
			
		}
		else
		{
			//Debug.Log("---Halfling plants complete --- " + Temp.name);
			
			if (Temp.tag == "Pumpkin")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Pumpking01;
			if (Temp.tag == "PipeWeed")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_PipeWeed01;
			if (Temp.tag == "Costmary")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Costmary01;
			if (Temp.tag == "FairyLily")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_FairyLily01;
			if (Temp.tag == "Mandrake")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Mandrake01;
			if (Temp.tag == "Potato")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Potatoes01;
			if (Temp.tag == "SunFlower")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_SunFlower01;
			if (Temp.tag == "Vervain")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Vervain01;
			if (Temp.tag == "Watercress")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_Watercress01;
		
			Destroy(Temp.GetComponent<progressBar>());
			Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
			UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
			//Debug.Log(harvest.gameObject.name + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			delObjUIButtonInfo.methodToInvoke = "farmHarvestButton";
			
			Temp.transform.GetComponent<progressBar>().enabled = false;
			
			//Temp.gameObject.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.h_PipeWeed01;
			Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			
			//Temp.transform.FindChild("HarvestButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
			
			if(status == 3)
			{
				//Debug.Log("---Halfling plants burn --- " + Temp.name);
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantBurnTex;
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "burn";
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
			  //scr_sfsRemote.RemoveBurnedPlant(id);
			}
		}
	}
	
	private void ConstructDarklingPlants(int id,GameObject Temp,int status)
	{
		// darkling plants
		 Temp.name = Temp.name + "_" + id;
	    
		if (IsConstructedOrNotforIds(id) && status != 6)
		{
			//Debug.Log("--- plant Not Complete --- ");
			Temp.transform.root.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("RabbtiButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
			Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
			
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
			Temp.transform.GetComponent<progressBar>().enabled = true;
			progressBar bar = Temp.transform.GetComponent<progressBar>() ;
			
			float construct = (ReturnConstructionTimeforIds(id) * 60);
			bar.seconds = ReturnTimefrmSvrforIds(id);
			
			bar.cnt = (int)(construct - bar.seconds);
			float remainTime = bar.cnt / construct;
			bar.seconds = construct;
			bar.SecCnt = (bar.seconds - ((float)bar.cnt));

			
			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
		
		        UIButton harvestUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
			harvestUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
		}
		else
		{
			//Debug.Log("--- plant Complete --- ");
			
			if (Temp.tag == "DAven")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_Aven01;
			if (Temp.tag == "BitterBrush")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_BitterBrush01;
			if (Temp.tag == "DBlackBerry")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_BlackBerry01;
			if (Temp.tag == "BogBean")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_Bogbean01;
			if (Temp.tag == "DColumbine")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_Columbine01;
			if (Temp.tag == "DFirePepper")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_FirePepper01;
			if (Temp.tag == "MoonFlower")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_MoonFlower01;
			if (Temp.tag == "DPumpkin")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_Pumpkin01;
			if (Temp.tag == "Wolfsbane")
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.d_Wolfsbane01;
			
		
			Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
			Temp.transform.FindChild("HarvestButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
			UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			if (GameManager.gameLevel <= 2)
				delObjUIButtonInfo.methodToInvoke = "harvestButton";
			else
				delObjUIButtonInfo.methodToInvoke = "darklingFarmHarvestButton";
			
			
			Temp.transform.GetComponent<progressBar>().enabled = false;
			Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		
			if(status == 3)
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantBurnTex;
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "burn";
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
			  //scr_sfsRemote.RemoveBurnedPlant(id);
			}
		}				
	}
	
	private void ConstructTurnips(int id,GameObject Temp,int status)
	{
		//			
		    Temp.name = Temp.name + "_" + id;
		     
			Turnips = Temp.name;			
			if (IsConstructedOrNotforIds(id) && status != 6)
			{
				//Debug.Log("--- Turnip Plant Not Complete --- ");
				GameObject plot = Temp.transform.root.gameObject;
				Temp.transform.root.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
				//Temp.transform.FindChild("RabbtiButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
				
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Rabbit") as Transform;
				Temp.transform.GetComponent<progressBar>().enabled = true;
				progressBar bar = Temp.transform.GetComponent<progressBar>() ;
				
				scr_gameObjectSvr.objTurnips.CreateTime = (ReturnConstructionTimeforIds(id) * 60);
				bar.seconds = ReturnTimefrmSvrforIds(id);
				
				bar.cnt = (int)(scr_gameObjectSvr.objTurnips.CreateTime - bar.seconds);
				float remainTime = bar.cnt / scr_gameObjectSvr.objTurnips.CreateTime;
				bar.seconds = scr_gameObjectSvr.objTurnips.CreateTime;
		    	bar.SecCnt = (bar.seconds - ((float)bar.cnt));

				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																		bar.progressBarPov.transform.localScale.y, 
																		bar.progressBarPov.transform.localScale.z);
				
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
				{
					delObjUIButtonInfo.methodToInvoke = "rabbitButton";
					//Temp.transform.FindChild("RabbtiButton").GetComponent<buttonPulse>().scaleAnim = true;
					
					buttonPulse rabbitButtBP = Temp.transform.FindChild("RabbtiButton").gameObject.AddComponent("buttonPulse") as buttonPulse;
					rabbitButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
					rabbitButtBP.minSpeed = 3;
					rabbitButtBP.maxSpeed = 8;
					rabbitButtBP.minVal = 0.02f;
					rabbitButtBP.maxVal = 0.09f;
					rabbitButtBP.scaleAnim = true;
				}
				
				Transform harvest1 = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
				UIButton delObjUIButtonInfo1 = harvest1.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo1.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
					delObjUIButtonInfo1.methodToInvoke = "harvestButton";
				else
					delObjUIButtonInfo1.methodToInvoke = "farmHarvestButton";
			}
			else
			{
				//Debug.Log("--- Turnip Plant Complete --- " + GameManager.gameLevel);
				Transform harvest = Temp.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
				UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
				if (GameManager.gameLevel <= 2)
					delObjUIButtonInfo.methodToInvoke = "harvestButton";
				else
					delObjUIButtonInfo.methodToInvoke = "farmHarvestButton";
				
				
				Temp.transform.GetComponent<progressBar>().enabled = false;
				
				Temp.gameObject.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.h_Turnip01;
				Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
				Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				
				
				//buttonPulse harvestButton_BP = Temp.transform.FindChild("HarvestButton").gameObject.GetComponent<buttonPulse>();
				if (GameManager.gameLevel < 3)
				{
					buttonPulse harvestButtBP = Temp.transform.FindChild("HarvestButton").gameObject.AddComponent("buttonPulse") as buttonPulse;
					harvestButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
					harvestButtBP.minSpeed = 3;
					harvestButtBP.maxSpeed = 8;
					harvestButtBP.minVal = 0.02f;
					harvestButtBP.maxVal = 0.09f;
					harvestButtBP.scaleAnim = true;	
					//harvestButton_BP.scaleAnim = true;
				}
//				else
//					harvestButton_BP.scaleAnim = false;
				
			
			    if(status == 3)
				{
					Temp.renderer.material.mainTexture = scr_UpgradeTexture.plantBurnTex;
					Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "burn";
					Temp.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
				  //scr_sfsRemote.RemoveBurnedPlant(id);
				}
			}
			
			
			
	}
	
	public void UnLockItemLoading()
	{	
		//Debug.Log("UnLockItemLoading :: Start");
		GameObject hGoblinCave01 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
		GameObject hGoblinCave02 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02") as GameObject;
		GameObject hGoblinCave03 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03") as GameObject;
		
		GameObject hOrgCave01 = GameObject.Find("HC_B_OrgCave_GO(Clone)_01") as GameObject;
		GameObject hOrgCave02 = GameObject.Find("HC_B_OrgCave_GO(Clone)_02") as GameObject;
		GameObject hOrgCave03 = GameObject.Find("HC_B_OrgCave_GO(Clone)_03") as GameObject;
		
		GameObject hTrollHouse01 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01") as GameObject;
		GameObject hTrollHouse02 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02") as GameObject;
		GameObject hTrollHouse03 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03") as GameObject;
		
		GameObject dGoblinCave01 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01") as GameObject;
		GameObject dGoblinCave02 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02") as GameObject;
		GameObject dGoblinCave03 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03") as GameObject;
		
		GameObject dOrgCave01 = GameObject.Find("DL_B_OrgCave_GO(Clone)_01") as GameObject;
		GameObject dOrgCave02 = GameObject.Find("DL_B_OrgCave_GO(Clone)_02") as GameObject;
		GameObject dOrgCave03 = GameObject.Find("DL_B_OrgCave_GO(Clone)_03") as GameObject;
		
		GameObject dTrollHouse01 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01") as GameObject;
		GameObject dTrollHouse02 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02") as GameObject;
		GameObject dTrollHouse03 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_03") as GameObject;
		
		//Debug.Log("UnLockItemLoading :: Find Cave complete");
		
		if (GameManager.gameLevel == 1)	GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level1);
		if (GameManager.gameLevel == 2)	GameManager.levelXPCnt = 341; //GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level2);//151;  //241;
		if (GameManager.gameLevel == 3) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level3);//600;
		if (GameManager.gameLevel == 4) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level4);//1200;
		if (GameManager.gameLevel == 5) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level5);//1600;
		if (GameManager.gameLevel == 6) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level6);//2300;
		if (GameManager.gameLevel == 7) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level7);//4500;
		if (GameManager.gameLevel == 8) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level8);//5625;
		if (GameManager.gameLevel == 9) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level9);//6900;
		if (GameManager.gameLevel == 10) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level10);//8250;
		if (GameManager.gameLevel == 11) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level11);//16125;
		if (GameManager.gameLevel == 12) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level12); //18625;
		if (GameManager.gameLevel == 13) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level13); //30000;
		if (GameManager.gameLevel == 14) GameManager.levelXPCnt = ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level14); //37500;
	
		
		int tempLVL = 0;
		//Debug.Log("--- Unlock Item Loadling --- " + tempLVL);
		for(tempLVL = 0; tempLVL <= GameManager.gameLevel; tempLVL++)
		{
			if (tempLVL == 1)
			{
				scr_gameManager.loadingBool = false;
				scr_guiControl.popUpType4.SetActiveRecursively(false);
				
				Transform h_Earthlock = scr_levelControl.h_Earth.transform.FindChild("lock") as Transform;
				Transform h_Houndlock = scr_levelControl.h_Hound.transform.FindChild("lock") as Transform;
				Transform h_Dirthpathlock = scr_levelControl.h_DirtPath.transform.FindChild("lock") as Transform;
				Transform h_Plotlock = scr_levelControl.h_Plot.transform.FindChild("lock") as Transform;
				Transform h_Turniplock = scr_levelControl.h_Turnip.transform.FindChild("lock") as Transform;
				
				if(h_Earthlock != null)
					Destroy(scr_levelControl.h_Earth.transform.FindChild("lock").gameObject);
				
				if(h_Houndlock != null)
					Destroy(scr_levelControl.h_Hound.transform.FindChild("lock").gameObject);
				
				if(h_Dirthpathlock != null)
					Destroy(scr_levelControl.h_DirtPath.transform.FindChild("lock").gameObject);
				
				if(h_Plotlock != null)
					Destroy(scr_levelControl.h_Plot.transform.FindChild("lock").gameObject);
				
				if(h_Turniplock != null)
					Destroy(scr_levelControl.h_Turnip.transform.FindChild("lock").gameObject);
			}
			
			else if (tempLVL == 2)
			{
				scr_gameManager.loadingBool = false;
				
				Transform h_Inn01lock = scr_levelControl.h_Inn01.transform.FindChild("lock") as Transform;
				Transform h_earthObelisklock = scr_levelControl.h_earthObelisk.transform.FindChild("lock") as Transform;
				
				if(h_Inn01lock != null)
					Destroy(scr_levelControl.h_Inn01.transform.FindChild("lock").gameObject);
				
				if(h_earthObelisklock != null)
					Destroy(scr_levelControl.h_earthObelisk.transform.FindChild("lock").gameObject);
			}
			
			else if (tempLVL == 3)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 3");
				scr_gameManager.loadingBool = false;
				
				Transform h_plantlock = scr_levelControl.h_Plant.transform.FindChild("lock") as Transform;
				Transform h_sproutlock = scr_levelControl.h_Sprout.transform.FindChild("lock") as Transform;
				Transform h_pipeweedlock = scr_levelControl.h_PipeWeed.transform.FindChild("lock") as Transform;
				Transform h_treelock = scr_levelControl.h_Tree.transform.FindChild("lock") as Transform;
				Transform h_woodpilelock = scr_levelControl.h_Woodpile.transform.FindChild("lock") as Transform;
				Transform h_well = scr_levelControl.h_Well.transform.FindChild("lock") as Transform;
				Transform h_plantObelisk = scr_levelControl.h_plantObelisk.transform.FindChild("lock") as Transform;

				
				if(h_plantlock != null)
					Destroy(scr_levelControl.h_Plant.transform.FindChild("lock").gameObject);
				
				if(h_sproutlock != null)
					Destroy(scr_levelControl.h_Sprout.transform.FindChild("lock").gameObject);
				
				if(h_pipeweedlock != null)
					Destroy(scr_levelControl.h_PipeWeed.transform.FindChild("lock").gameObject);
				
				if (h_treelock != null)
					Destroy(scr_levelControl.h_Tree.transform.FindChild("lock").gameObject);
				
				if (h_woodpilelock != null)
					Destroy(scr_levelControl.h_Woodpile.transform.FindChild("lock").gameObject);
				
				if (h_well != null)
					Destroy(scr_levelControl.h_Well.transform.FindChild("lock").gameObject);

				if (h_plantObelisk != null)
					Destroy(scr_levelControl.h_plantObelisk.transform.FindChild("lock").gameObject);
			}
			
			else if (tempLVL == 4)
			{		
				//Debug.Log("UnLockItemLoading :: tempLVL == 4");
				scr_gameManager.loadingBool = false;
				GameManager.placeHGardenPlotBool = true;
				GameManager.placeDGardenPlotBool = true;
				
//				Destroy(scr_levelControl.h_Barg.transform.FindChild("lock").gameObject);
				
				
				Transform d_dirtpathlock = scr_levelControl.d_DirtPath.transform.FindChild("lock") as Transform;
				Transform d_Welllock = scr_levelControl.d_Well.transform.FindChild("lock") as Transform;
				Transform d_Treelock = scr_levelControl.d_Tree.transform.FindChild("lock") as Transform;
				Transform d_Inn01lock = scr_levelControl.d_Inn01.transform.FindChild("lock") as Transform;
				Transform d_plotlock = scr_levelControl.d_Plot.transform.FindChild("lock") as Transform;
				Transform d_pumpkinlock = scr_levelControl.d_Plot.transform.FindChild("lock") as Transform;
				Transform d_swamplock = scr_levelControl.d_Swamp.transform.FindChild("lock") as Transform;
				Transform d_leechlock = scr_levelControl.d_Leech.transform.FindChild("lock") as Transform;
				Transform h_Barrellock = scr_levelControl.h_Barrel.transform.FindChild("lock") as Transform;
				Transform bridge = scr_levelControl.bridge.transform.FindChild("lock") as Transform;
				Transform d_swampObelisklock = scr_levelControl.d_swampObelisk.transform.FindChild("lock") as Transform;
				
				if(d_dirtpathlock != null)
				Destroy(scr_levelControl.d_DirtPath.transform.FindChild("lock").gameObject);
				
				if(d_Welllock != null)
				Destroy(scr_levelControl.d_Well.transform.FindChild("lock").gameObject);
				
				if(d_Treelock != null)
				Destroy(scr_levelControl.d_Tree.transform.FindChild("lock").gameObject);
				
				if(d_Inn01lock != null)
				Destroy(scr_levelControl.d_Inn01.transform.FindChild("lock").gameObject);
				
				if(d_plotlock != null)
				Destroy(scr_levelControl.d_Plot.transform.FindChild("lock").gameObject);
				
				if(d_pumpkinlock != null)
				Destroy(scr_levelControl.d_Pumpkin.transform.FindChild("lock").gameObject);
				
				if(d_swamplock != null)
				Destroy(scr_levelControl.d_Swamp.transform.FindChild("lock").gameObject);

				if(d_swampObelisklock != null)
					Destroy(scr_levelControl.d_swampObelisk.transform.FindChild("lock").gameObject);
				
				if(d_leechlock != null) Destroy(scr_levelControl.d_Leech.transform.FindChild("lock").gameObject);
				
				if(h_Barrellock != null) Destroy(scr_levelControl.h_Barrel.transform.FindChild("lock").gameObject);
				
				if (bridge != null) Destroy(scr_levelControl.bridge.transform.FindChild("lock").gameObject);
				
				//scr_levelControl.hGateObj.renderer.material.mainTexture = scr_UpgradeTexture.h_BattleGround;
				//scr_levelControl.dGateObj.renderer.material.mainTexture = scr_UpgradeTexture.d_BattleGround;
				//scr_levelControl.hGateObj.GetComponent<MeshCollider>().enabled = true;
				//scr_levelControl.dGateObj.GetComponent<MeshCollider>().enabled = true;
				
				if (hGoblinCave02 != null)
				{
					hGoblinCave02.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
					if (hGoblinCave02.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						hGoblinCave02.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
					
					if (hGoblinCave02.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						hGoblinCave02.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
					hGoblinCave02.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 5)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 5");
				scr_gameManager.loadingBool = false;
				
				Transform h_fruittreelock = scr_levelControl.h_FruitTree.transform.FindChild("lock") as Transform;
				Transform h_waterlock = scr_levelControl.h_Water.transform.FindChild("lock") as Transform;
				Transform h_Nixlock = scr_levelControl.h_Nix.transform.FindChild("lock") as Transform;
				Transform h_pumpkinlock = scr_levelControl.h_Pumpkin.transform.FindChild("lock") as Transform;
				Transform h_stablelock = scr_levelControl.h_Stable.transform.FindChild("lock") as Transform;
				Transform d_earthlock = scr_levelControl.d_Earth.transform.FindChild("lock") as Transform;
				Transform d_houndlock = scr_levelControl.d_Hound.transform.FindChild("lock") as Transform;
				Transform d_stablelock = scr_levelControl.d_Stable.transform.FindChild("lock") as Transform;
				Transform d_boglock = scr_levelControl.d_Bog.transform.FindChild("lock") as Transform;
				Transform d_firepepperlock = scr_levelControl.d_FirePepper.transform.FindChild("lock") as Transform;
				Transform h_well = scr_levelControl.h_Well.transform.FindChild("lock") as Transform;

				Transform h_waterObelisklock = scr_levelControl.h_waterObelisk.transform.FindChild("lock") as Transform;
				Transform d_earthObelisklock = scr_levelControl.d_earthObelisk.transform.FindChild("lock") as Transform;
				
				if(h_fruittreelock != null)
					Destroy(scr_levelControl.h_FruitTree.transform.FindChild("lock").gameObject);
				
				if(h_waterlock != null)
					Destroy(scr_levelControl.h_Water.transform.FindChild("lock").gameObject);
				
				if(h_Nixlock != null)
					Destroy(scr_levelControl.h_Nix.transform.FindChild("lock").gameObject);
				
				if(h_pumpkinlock != null)
					Destroy(scr_levelControl.h_Pumpkin.transform.FindChild("lock").gameObject);
				
				if(h_stablelock != null)
					Destroy(scr_levelControl.h_Stable.transform.FindChild("lock").gameObject);
				
				if(d_earthlock != null)
					Destroy(scr_levelControl.d_Earth.transform.FindChild("lock").gameObject);
				
				if(d_houndlock != null)
					Destroy(scr_levelControl.d_Hound.transform.FindChild("lock").gameObject);
				
				if(d_stablelock != null)
					Destroy(scr_levelControl.d_Stable.transform.FindChild("lock").gameObject);
				
				if(d_boglock != null)
					Destroy(scr_levelControl.d_Bog.transform.FindChild("lock").gameObject);
				
				if(d_firepepperlock != null)
					Destroy(scr_levelControl.d_FirePepper.transform.FindChild("lock").gameObject);
				
				if(h_well != null)
					Destroy(scr_levelControl.h_Well.transform.FindChild("lock").gameObject);

				if (h_waterObelisklock != null)
					Destroy(scr_levelControl.h_waterObelisk.transform.FindChild("lock").gameObject);

				if(d_earthObelisklock != null)
					Destroy(scr_levelControl.d_earthObelisk.transform.FindChild("lock").gameObject);
								
				if (dGoblinCave01 != null)
				{
					dGoblinCave01.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
					if (dGoblinCave01.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						dGoblinCave01.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
					
					if (dGoblinCave01.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						dGoblinCave01.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
					dGoblinCave01.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if(tempLVL == 6)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 6");
				scr_gameManager.loadingBool = false;
				
				Transform h_laternlock = scr_levelControl.h_Lantern.transform.FindChild("lock") as Transform;
				Transform h_blacksmithlock = scr_levelControl.h_BlackSmith.transform.FindChild("lock") as Transform;
				Transform h_Nymphlock = scr_levelControl.h_Nymph.transform.FindChild("lock") as Transform;
				Transform d_blacksmithlock = scr_levelControl.d_BlackSmith.transform.FindChild("lock") as Transform;
				Transform d_firelock = scr_levelControl.d_Fire.transform.FindChild("lock") as Transform;
				Transform d_spritelock = scr_levelControl.d_sprite.transform.FindChild("lock") as Transform;
				Transform d_tree2lock = scr_levelControl.d_Tree2.transform.FindChild("lock") as Transform;
				Transform d_fireObelisklock = scr_levelControl.d_fireObelisk.transform.FindChild("lock") as Transform;

				if(h_laternlock != null)
					Destroy(scr_levelControl.h_Lantern.transform.FindChild("lock").gameObject);
				
				if(h_blacksmithlock != null)
					Destroy(scr_levelControl.h_BlackSmith.transform.FindChild("lock").gameObject);
				
				if(h_Nymphlock != null) 
					Destroy(scr_levelControl.h_Nymph.transform.FindChild("lock").gameObject);
				
				if(d_blacksmithlock != null)
					Destroy(scr_levelControl.d_BlackSmith.transform.FindChild("lock").gameObject);
				
				if(d_firelock != null)
					Destroy(scr_levelControl.d_Fire.transform.FindChild("lock").gameObject);
				
				if(d_spritelock != null)
					Destroy(scr_levelControl.d_sprite.transform.FindChild("lock").gameObject);
				
				if(d_tree2lock != null)
					Destroy(scr_levelControl.d_Tree2.transform.FindChild("lock").gameObject);
				
//				if(h_plantObliskLock != null)																//Amogh
//					Destroy(scr_levelControl.h_plantObelisk.transform.FindChild("lock").gameObject);		//Amogh	

				if(d_fireObelisklock != null)
					Destroy(scr_levelControl.d_fireObelisk.transform.FindChild("lock").gameObject);
				
				if (hGoblinCave03 != null)
				{
					hGoblinCave03.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
					if (hGoblinCave03.transform.FindChild("GoblinChar01").gameObject.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						hGoblinCave03.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
					
					if (hGoblinCave03.transform.FindChild("GoblinChar02").gameObject.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled == false)
						hGoblinCave03.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
					hGoblinCave03.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if(tempLVL == 7)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 7");
				scr_gameManager.loadingBool = false;
				GameManager.placeHGardenPlotBool = true;
				GameManager.placeDGardenPlotBool = true;
				
				Transform h_wheelburrowlock = scr_levelControl.h_WheelBurrow.transform.FindChild("lock") as Transform;
				
				Transform h_costmarylock = scr_levelControl.h_Costmary.transform.FindChild("lock") as Transform;
				Transform d_avenlock = scr_levelControl.d_Aven.transform.FindChild("lock") as Transform;
				Transform d_ravenPerchlock = scr_levelControl.d_RavenPerch.transform.FindChild("lock") as Transform;
				
				if(h_wheelburrowlock != null)
				Destroy(scr_levelControl.h_WheelBurrow.transform.FindChild("lock").gameObject);
						
				if(h_costmarylock != null)
				Destroy(scr_levelControl.h_Costmary.transform.FindChild("lock").gameObject);
				
				if(d_avenlock != null)
				Destroy(scr_levelControl.d_Aven.transform.FindChild("lock").gameObject);
				
				if(d_ravenPerchlock != null)
				Destroy(scr_levelControl.d_RavenPerch.transform.FindChild("lock").gameObject);
				
				if (dGoblinCave02 != null)
				{
					dGoblinCave02.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
					dGoblinCave02.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
					dGoblinCave02.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
					dGoblinCave02.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 8)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 8");
				
				Transform h_shroomerylock = scr_levelControl.h_Shroomrey.transform.FindChild("lock") as Transform;
				Transform d_Scarcrowlock = scr_levelControl.d_ScareCrow.transform.FindChild("lock") as Transform;
				Transform h_scarecrowlock = scr_levelControl.h_Scarecrow.transform.FindChild("lock") as Transform;
				Transform h_plantObelisklock = scr_levelControl.h_plantObelisk.transform.FindChild("lock") as Transform;

				
				if (h_scarecrowlock != null)
					Destroy(scr_levelControl.h_Scarecrow.transform.FindChild("lock").gameObject);
				
				if(h_shroomerylock != null)
					Destroy(scr_levelControl.h_Shroomrey.transform.FindChild("lock").gameObject);
				
			    if(d_Scarcrowlock != null)
					Destroy(scr_levelControl.d_ScareCrow.transform.FindChild("lock").gameObject);
				
				if(h_plantObelisklock != null)
					Destroy(scr_levelControl.h_plantObelisk.transform.FindChild("lock").gameObject);
				

				
				
				if (hTrollHouse01 != null)
				{
					hTrollHouse01.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
					hTrollHouse01.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 9)
			{
				
				Transform h_Tavernlock = scr_levelControl.h_Tavern.transform.FindChild("lock") as Transform;
				Transform d_Tavernlock = scr_levelControl.d_Tavern.transform.FindChild("lock") as Transform;
				
				Transform d_huntingtentlock = scr_levelControl.d_HuntingTent.transform.FindChild("lock") as Transform;
				Transform h_partyTentlock = scr_levelControl.h_PartyTent.transform.FindChild("lock") as Transform;
				
				
				
				if(h_Tavernlock != null)
				Destroy(scr_levelControl.h_Tavern.transform.FindChild("lock").gameObject);
				
				if(d_Tavernlock != null)
				Destroy(scr_levelControl.d_Tavern.transform.FindChild("lock").gameObject);
				
				
				if(d_huntingtentlock != null)
				Destroy(scr_levelControl.d_HuntingTent.transform.FindChild("lock").gameObject);
				
				if(h_partyTentlock != null)
				Destroy(scr_levelControl.h_PartyTent.transform.FindChild("lock").gameObject);
				
				if (dGoblinCave03 != null)
				{
					dGoblinCave03.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
					dGoblinCave03.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
					dGoblinCave03.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
					dGoblinCave03.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 10)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 10");
				GameManager.placeHGardenPlotBool = true;
				GameManager.placeDGardenPlotBool = true;
				
				Transform h_apothecarylock = scr_levelControl.h_apothecary.transform.FindChild("lock") as Transform;
				Transform d_apothecarylock = scr_levelControl.d_Apothecary.transform.FindChild("lock") as Transform;
				Transform h_potatolock = scr_levelControl.h_Potato.transform.FindChild("lock") as Transform;
				Transform d_blackberylock = scr_levelControl.d_BlackBery.transform.FindChild("lock") as Transform;
				Transform h_knollHilllock = scr_levelControl.h_KnollHill.transform.FindChild("lock") as Transform;
				Transform d_knollHilllock = scr_levelControl.d_KnollHill.transform.FindChild("lock") as Transform;
				
				if(h_apothecarylock != null)
				Destroy(scr_levelControl.h_apothecary.transform.FindChild("lock").gameObject);
				
				if(d_apothecarylock != null)
				Destroy(scr_levelControl.d_Apothecary.transform.FindChild("lock").gameObject);
				
				if(h_potatolock != null)
				Destroy(scr_levelControl.h_Potato.transform.FindChild("lock").gameObject);
				
				if(d_blackberylock != null)
				Destroy(scr_levelControl.d_BlackBery.transform.FindChild("lock").gameObject);
				
				if(h_knollHilllock != null)
				Destroy(scr_levelControl.h_KnollHill.transform.FindChild("lock").gameObject);
				
				if(d_knollHilllock != null)
				Destroy(scr_levelControl.d_KnollHill.transform.FindChild("lock").gameObject);
				
				if (hTrollHouse02 != null)
				{
					hTrollHouse02.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
					hTrollHouse02.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 11)
			{
				Transform h_waterObelisklock = scr_levelControl.h_waterObelisk.transform.FindChild("lock") as Transform;

				Transform h_FairyLilylock = scr_levelControl.h_FairyLily.transform.FindChild("lock") as Transform;
				Transform d_columbinelock = scr_levelControl.d_Columbine.transform.FindChild("lock") as Transform;
				Transform d_fencelock = scr_levelControl.d_Fence.transform.FindChild("lock") as Transform;
				Transform h_fencelock = scr_levelControl.h_Fence.transform.FindChild("lock") as Transform;
				
				if(h_waterObelisklock != null)
				Destroy(scr_levelControl.h_waterObelisk.transform.FindChild("lock").gameObject);

				if(h_FairyLilylock != null)
				Destroy(scr_levelControl.h_FairyLily.transform.FindChild("lock").gameObject);
				
				if(d_columbinelock != null)
				Destroy(scr_levelControl.d_Columbine.transform.FindChild("lock").gameObject);
				
				if(d_fencelock != null)
				Destroy(scr_levelControl.d_Fence.transform.FindChild("lock").gameObject);
				
				if(h_fencelock != null)
				Destroy(scr_levelControl.h_Fence.transform.FindChild("lock").gameObject);
				
				if (dTrollHouse01 != null)
				{
					dTrollHouse01.renderer.material.mainTexture = scr_UpgradeTexture.dl_TrollHouse_Tex;
					dTrollHouse01.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 12)
			{
				Transform h_sunshrinlock = scr_levelControl.h_sunShrine.transform.FindChild("lock") as Transform;
				Transform d_moonshrinelock = scr_levelControl.d_moonShrine.transform.FindChild("lock") as Transform;
				Transform h_Sunflowerlock = scr_levelControl.h_Sunflower.transform.FindChild("lock") as Transform;
				Transform h_waterCresslock = scr_levelControl.h_Watercress.transform.FindChild("lock") as Transform;
				Transform d_moonFlowerlock = scr_levelControl.d_Moonflower.transform.FindChild("lock") as Transform;
				Transform d_bitterbrushlock = scr_levelControl.d_BitterBush.transform.FindChild("lock") as Transform;
				Transform h_cottagelock = scr_levelControl.h_Cottage.transform.FindChild("lock") as Transform;
				
				if(h_sunshrinlock != null)
					Destroy(scr_levelControl.h_sunShrine.transform.FindChild("lock").gameObject);
				
				if(d_moonFlowerlock != null)
					Destroy(scr_levelControl.d_moonShrine.transform.FindChild("lock").gameObject);
				
				if(h_Sunflowerlock != null)
					Destroy(scr_levelControl.h_Sunflower.transform.FindChild("lock").gameObject);
				
				if(h_waterCresslock != null)
					Destroy(scr_levelControl.h_Watercress.transform.FindChild("lock").gameObject);
				
				if(d_moonFlowerlock != null)
					Destroy(scr_levelControl.d_Moonflower.transform.FindChild("lock").gameObject);
				
				if(d_bitterbrushlock != null)
					Destroy(scr_levelControl.d_BitterBush.transform.FindChild("lock").gameObject);
				
				if(h_cottagelock != null)
					Destroy(scr_levelControl.h_Cottage.transform.FindChild("lock").gameObject);
				
				if (hTrollHouse03 != null)
				{
					hTrollHouse03.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
					hTrollHouse03.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 13)
			{
				//Debug.Log("UnLockItemLoading :: tempLVL == 13");
				GameManager.placeHGardenPlotBool = true;
				GameManager.placeDGardenPlotBool = true;
			
				Transform h_vervainlock = scr_levelControl.transform.FindChild("lock") as Transform;
				Transform d_bogBeanlock = scr_levelControl.transform.FindChild("lock") as Transform;
				Transform h_cornFieldlock = scr_levelControl.transform.FindChild("lock") as Transform;
				Transform d_Birdhouselock = scr_levelControl.transform.FindChild("lock") as Transform;
				
				if(h_vervainlock != null)
					Destroy(scr_levelControl.h_Vervain.transform.FindChild("lock").gameObject);
				
				if(d_bogBeanlock != null)
					Destroy(scr_levelControl.d_BogBean.transform.FindChild("lock").gameObject);
				
				if(h_cornFieldlock != null)
					Destroy(scr_levelControl.h_CornField.transform.FindChild("lock").gameObject);
				
				if(d_Birdhouselock != null)
					Destroy(scr_levelControl.d_BirdHouse.transform.FindChild("lock").gameObject);
				
				if (dTrollHouse02 != null)
				{
					dTrollHouse02.renderer.material.mainTexture = scr_UpgradeTexture.dl_TrollHouse_Tex;
					dTrollHouse02.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
			else if (tempLVL == 14)
			{
				Transform h_mandrakelock = scr_levelControl.h_Mandrake.transform.FindChild("lock") as Transform;
				Transform d_wolfsbanselock = scr_levelControl.d_Wolfsbane.transform.FindChild("lock") as Transform;
				Transform d_windmilllock = scr_levelControl.d_WindMill.transform.FindChild("lock") as Transform;
				Transform h_windmilllock = scr_levelControl.h_WindMill.transform.FindChild("lock") as Transform;
				
				if(h_mandrakelock != null)
					Destroy(scr_levelControl.h_Mandrake.transform.FindChild("lock").gameObject);
				
				if(d_wolfsbanselock != null)
					Destroy(scr_levelControl.d_Wolfsbane.transform.FindChild("lock").gameObject);
				
				if(d_windmilllock != null)
					Destroy(scr_levelControl.d_WindMill.transform.FindChild("lock").gameObject);
				
				if(h_windmilllock != null)
					Destroy(scr_levelControl.h_WindMill.transform.FindChild("lock").gameObject);
				
				if (hOrgCave01 != null)
				{
					hOrgCave01.renderer.material.mainTexture = scr_UpgradeTexture.hc_OrgCave_Tex;
					hOrgCave01.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
			}
		}
	}
	
	public double ReturnXPcostTotal(int typeId, GameObject obj)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_GameObjectsDb.Count ; i++)
		{
			if(scr_sfsRemote.lst_GameObjectsDb[i].ObjectTypeId.Equals(typeId))
			{
				Debug.Log("xp name : " + scr_sfsRemote.lst_GameObjectsDb[i].ObjectTypeName);
				Debug.Log("obj xp :--> " + scr_sfsRemote.lst_GameObjectsDb[i].xp_earned);
				Debug.Log("---> " + scr_sfsRemote.lst_GameObjectsDb[i].ObjectTypeName + " <---");

				GameManager.earnXpVal = (int)scr_sfsRemote.lst_GameObjectsDb[i].xp_earned;

				switch(obj.tag)
				{
				case "Barg": GameManager.earnXpVal = 120; break;
				case "Cusith": GameManager.earnXpVal = 563; break;
				case "Dragon": GameManager.earnXpVal = 1863; break;
				case "Draug": GameManager.earnXpVal = 563; break;
				case "Dryad": GameManager.earnXpVal = 690; break;
				case "Hound": GameManager.earnXpVal = 5; break;
				case "Nix": GameManager.earnXpVal = 160; break;
				case "Nymph": GameManager.earnXpVal = 230; break;
				case "Sprout": GameManager.earnXpVal = 30; break;

				case "DHound": GameManager.earnXpVal = 160; break;
				case "Djinn": GameManager.earnXpVal = 3750; break;
				case "Fenrir": GameManager.earnXpVal = 563; break;
				case "HellHound": GameManager.earnXpVal = 3000; break;
				case "Imp": GameManager.earnXpVal = 690; break;
				case "Leech": GameManager.earnXpVal = 120; break;
				case "Leshy": GameManager.earnXpVal = 450; break;
				case "Lurker": GameManager.earnXpVal = 1863; break;
				case "Sprite": GameManager.earnXpVal = 230; break;
				}



				// show xp value
				GameObject xpValObj = Instantiate(Resources.Load("xpValue"), 
				                                  new Vector3(obj.transform.position.x, obj.transform.position.y + 0.5f, obj.transform.position.z), 
				                                  Quaternion.Euler(90, 0, 0)) as GameObject;
				Debug.Log("obj ---> " + obj.name);	
				xpValObj.transform.parent = obj.transform.root.gameObject.transform;
				return scr_sfsRemote.lst_GameObjectsDb[i].xp_earned;
			}	
		}
		
		return -1;
	}
	
	public int ReturnXpfromLevelInfo(int lvl)
	{
		for(int i = 0; i< scr_sfsRemote.lst_LevelXpInfo.Count ; i++)
		{
			if(scr_sfsRemote.lst_LevelXpInfo[i].currentLevel.Equals(lvl))
			{
				return scr_sfsRemote.lst_LevelXpInfo[i].levelXp;
			}
		}
		
		return -1;
	}
	
	
//----------------------------------------------------------------------------------------------------------------------------------------------------------
	
	// creature load
	void CreatureLoad(GameObject currentPref, float yVal, Vector3 objPos, Vector3 objRot, GameObject TG, int objTypeID)
	{
		
		Temp = Instantiate(currentPref ,new Vector3(objPos.x, objPos.y,objPos.z),Quaternion.Euler(objRot.x, objRot.y, objRot.z)) as GameObject;
		Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		Temp.transform.parent = TG.transform;
		Temp.transform.localPosition = new Vector3(Temp.transform.position.x, yVal, Temp.transform.position.z);
		
		if(IsConstructedOrNot(objTypeID))
		{
			TG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			//TG.transform.FindChild("Spark").gameObject.active = true;
			TG.transform.FindChild("Spark2").gameObject.GetComponent<MeshRenderer>().enabled = true;
			Temp.GetComponent<MeshRenderer>().enabled = false;
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			GameObject rabbitButton = Temp.transform.FindChild("RabbtiButton").gameObject;
			rabbitButton.SetActiveRecursively(true);
			
			if (GameManager.gameLevel < 3)
				rabbitButton.GetComponent<buttonPulse>().scaleAnim = true;
							
			Transform rabbit = rabbitButton.transform.FindChild("Rabbit") as Transform;
			Temp.transform.GetComponent<progressBar>().enabled = true;

			progressBar bar = Temp.transform.GetComponent<progressBar>() ;
			
			float construct = (ReturnConstructionTime(objTypeID) * 60);
			
			bar.seconds = (float) ReturnTimefrmSvr(objTypeID); 
							
			bar.cnt = (int)(construct - bar.seconds);
			float remainTime = ((float)bar.cnt) / construct;
			bar.seconds = construct;
			
			bar.SecCnt = (bar.seconds - ((float)bar.cnt));

			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			
			if (GameManager.gameLevel == 1)
				delObjUIButtonInfo.methodToInvoke = "rabbitButton";
			else
				delObjUIButtonInfo.methodToInvoke = "creatureRabbitButton";
			
			objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			objEditPanelInfo.panelMoveIn = false;
			objEditPanelInfo.panelMoveOut = true;
			Destroy(scr_guiControl.delArrow);
			
			scr_popUpInfo.scr_audioController.audio_sparkEarth.transform.position = TG.transform.position;
			scr_popUpInfo.scr_audioController.audio_sparkEarth.volume = 0.7f;
			scr_popUpInfo.scr_audioController.audio_sparkEarth.Play();
			scr_popUpInfo.scr_audioController.audio_sparkEarth.minDistance = 1;
			scr_popUpInfo.scr_audioController.audio_sparkEarth.maxDistance = 20;
				
				
			scr_popUpInfo.PlaySparkBirthsound(TG.transform.position);
		}
		else
		{
			TG.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			Temp.GetComponent<MeshRenderer>().enabled = true;
			Destroy(Temp.transform.FindChild("RabbtiButton").gameObject);
			Destroy(Temp.transform.FindChild("ProgressBar").gameObject);
			
			if (Temp.tag == "Hound")
			{
				Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				Temp.GetComponent<HoundAnimation>().moveAB_Bool = true;
			}
			else if (Temp.tag == "Barg")
				Temp.GetComponent<BargAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Cusith")
				Temp.GetComponent<CusithAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Dragon")
				Temp.GetComponent<DragonAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Barg")
				Temp.GetComponent<BargAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Draug")
				Temp.GetComponent<DraugAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Dryad")
				Temp.GetComponent<DryadAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Nix")
				Temp.GetComponent<NixAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Nymph")
				Temp.GetComponent<NymphAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Sprout")
				Temp.GetComponent<SproutAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "DHound")
				Temp.GetComponent<DHoundAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Djinn")
				Temp.GetComponent<DjinnAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Fenrir")
				Temp.GetComponent<FenrirAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "HellHound")
				Temp.GetComponent<HellHoundAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Imp")
				Temp.GetComponent<ImpAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Leech")
				Temp.GetComponent<LeechAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Leshy")
				Temp.GetComponent<LeshyAnimation>().moveAB_Bool = true;
			else if (Temp.tag == "Lurker")
				Temp.GetComponent<LurkerAnimation>().moveBA_Bool = true;
			else if (Temp.tag == "Sprite")
				Temp.GetComponent<SpriteAnimation>().moveAB_Bool = true;
			
			Destroy(Temp.transform.FindChild("greenPatch").gameObject);
			Destroy(Temp.transform.FindChild("redPatch").gameObject);
		}
	}
	
	// training ground load
	void TrainingGroundLoad(GameObject Temp, int objTypeID)
	{
		GameObject dummySphere = GameObject.Find("Sphere") as GameObject;
		
		dummySphere.transform.position = Temp.transform.FindChild("Isometric_Collider").gameObject.transform.position;
		Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f - (dummySphere.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		
		//Temp = Instantiate(tgPref, objPos, Quaternion.Euler(objRot.x, objRot.y, objRot.z)) as GameObject;
		//Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		
		Transform healthPB = Temp.transform.FindChild("HealthProgressBar") as Transform;
		if (healthPB != null)
			healthPB.gameObject.SetActiveRecursively(false);
		
		Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		if(IsConstructedOrNot(objTypeID))
		{	
			Temp.transform.Find("Isometric_Collider").gameObject.tag = "using";//"working";
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
			Temp.transform.Find("Spark").gameObject.active = false;
			Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("selectionPatch").gameObject.active = false;
			Temp.transform.FindChild("redPatch").gameObject.active = false;
			Temp.transform.FindChild("greenPatch").gameObject.active = false;
			Temp.GetComponent<Sensors>().enabled = false;
			
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
			upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
		
			float construct = (ReturnConstructionTime(objTypeID) * 60);
			
			bar.seconds = (float) ReturnTimefrmSvr(objTypeID);
			
		    bar.cnt = (int) (construct - bar.seconds);
			float remainTime = ((float)bar.cnt) / construct;
			bar.seconds = construct;
			bar.SecCnt = bar.seconds - bar.cnt;

			
			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
		}
		else
		{
			GameObject pTGUI = Temp.transform.FindChild("UI").gameObject;
			GameObject pTGButt = pTGUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			pTGButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject pTGCancle = pTGUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			pTGCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			Temp.transform.FindChild("greenPatch").gameObject.active = false;
			Temp.transform.FindChild("redPatch").gameObject.active = false;
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
			Temp.gameObject.GetComponent<Sensors>().enabled = false;
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			UIButton delObjUIButtonInfoETG = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfoETG.scriptWithMethodToInvoke = scr_guiControl;
		}
	}
	
	// decoration load
	void LoadDecoration(GameObject Temp)
	{
		GameObject dummySphere = GameObject.Find("Sphere") as GameObject;
		
		//Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		
		dummySphere.transform.position = Temp.transform.FindChild("Isometric_Collider").gameObject.transform.position;
		Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f - (dummySphere.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		
		GameObject decorationObjUI = Temp.transform.FindChild("UI").gameObject;
		GameObject decorationButt = decorationObjUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
		decorationButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
		GameObject decorationCancelButt = decorationObjUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
		decorationCancelButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
		Temp.transform.FindChild("greenPatch").gameObject.active = false;
		Temp.transform.FindChild("redPatch").gameObject.active = false;
		Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
		Temp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		Temp.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
		Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
		Destroy(Temp.GetComponent<getXP>());
		Temp.gameObject.GetComponent<Sensors>().enabled = false;
		
		if (Temp.name == "HC_D_DirtPath_GO(Clone)" || Temp.name == "DL_D_DDirtPath_GO(Clone)")
		{
			Temp.GetComponent<dirtPathPlacement>().enabled = false;
		}
	}
	
	// load building
	void BuildingLoad( GameObject buildingPref, Vector3 objPos, Vector3 objRot, int objTypeID,Texture objLevel01_Tex, 
						Texture objLevel02_Tex, Texture objLevel03_Tex, bool nightObjBool, Texture nightObjTex_L02, 
						Texture nightObjTex_L03, string nightObjName, int status, int level, double objgold, 
						bool halflingBool, bool obeliskBool,int objId)
	{
		// instantiate building object
		Temp = Instantiate(buildingPref, objPos,Quaternion.Euler(objRot)) as GameObject;
		
		GameObject dummySphere = GameObject.Find("Sphere") as GameObject;
		
		dummySphere.transform.position = Temp.transform.FindChild("Isometric_Collider").gameObject.transform.position;
		Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f - (dummySphere.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		
		//Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / GameManager.layerDivVal)), Temp.transform.position.z);
		Transform gldButton = Temp.transform.FindChild("GoldButton") as Transform;
		
		Transform healthPB = Temp.transform.FindChild("HealthProgressBar") as Transform;
		if (healthPB != null)
			healthPB.gameObject.SetActiveRecursively(false);
		
		if (!obeliskBool)
			Temp.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		if (IsConstructedOrNot(objTypeID) && status == 1)
		{
			if (halflingBool)
			{
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				
				scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				//Debug.Log("222222222222222222222222222 -- golum create here..." + scr_guiControl.golum.name);
				if(scr_guiControl.golum == null)
				{
					Destroy(scr_guiControl.golum);
					Vector3 unknown = Vector3.zero;
					
					if (!obeliskBool)
						unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
					else
						unknown = new Vector3(Temp.transform.position.x-1f,Temp.transform.position.y+0.011f,Temp.transform.position.z+0.80f);

					Debug.Log("11111111111111111111111111 -- golum create here...");
					GameObject golum = Instantiate(scr_guiControl.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
					
					scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
					fp.findGolum();
					fp.halfling_Generate = true;
					fp.Halfing_Front_Hammer = true;
					
					scr_popUpInfo.PlayScaffolding(Temp.transform.position);
				}
			}
			else if (!halflingBool)
			{
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "Dworking";
				
				Vector3 unknown = Vector3.zero;
					
				if (!obeliskBool)
					unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
				else
					unknown = new Vector3(Temp.transform.position.x-1.31f,Temp.transform.position.y+0.011f,Temp.transform.position.z-0.79f);
				
				GameObject Darkgolum = Instantiate(scr_guiControl.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
				scr_guiControl.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
			
				fp.darkling_Generate = true;
				fp.Darking_Front_Hammer = true;
				
				scr_popUpInfo.PlayScaffolding(Temp.transform.position);
			}
			
			
			GameManager.hBuildingConstructBool = false;
			if (!obeliskBool)
				Temp.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.constuctionLevel;
			else
			{
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_ObeliskContruction;
				Temp.transform.FindChild("DefenceObeliskIcon").gameObject.SetActiveRecursively(false);
			}
			
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("selectionPatch").gameObject.active = false;
			Temp.transform.FindChild("redPatch").gameObject.active = false;
			Temp.transform.FindChild("greenPatch").gameObject.active = false;
			Temp.gameObject.GetComponent<Sensors>().enabled = false;
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			rabbit.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
			Temp.transform.GetComponent<progressBar>().enabled = true;
			progressBar bar = Temp.transform.GetComponent<progressBar>() ;

			Transform chimneyObj = Temp.transform.FindChild("HWgame_ChimneySmoke") as Transform;

			if (chimneyObj != null)
				chimneyObj.gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
			
			if (Temp.tag == "DTavern")
				Temp.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			if (Temp.tag == "Tavern")
				Temp.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			if (Temp.tag == "Apothecary")
				Temp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			if (Temp.tag == "DApothecary")
				Temp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			
			if (gldButton != null)
				gldButton.gameObject.SetActiveRecursively(false);
			
			float construct = (ReturnConstructionTime(objTypeID) * 60);
			bar.seconds = (float) ReturnTimefrmSvr(objTypeID);
			
		    bar.cnt = (int)(construct - bar.seconds);
			float remainTime = ((float)bar.cnt) / construct;
			bar.seconds = construct;
			
			bar.SecCnt = (bar.seconds - ((float)bar.cnt));
			
			
			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
//			if (GameManager.gameLevel <= 2)
//			{
//				delObjUIButtonInfo.methodToInvoke = "rabbitButton";
//				Temp.transform.FindChild("RabbtiButton").GetComponent<buttonPulse>().scaleAnim = true;
//			}
			
		
		}
		else if(IsConstructedOrNot(objTypeID) && status == 5)
		{
			if (halflingBool)
			{
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "working";
				
				scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
			
				if(scr_guiControl.golum != null)
				{
					Destroy(scr_guiControl.golum);
					Vector3 unknown = Vector3.zero;
					
					if (!obeliskBool)
						unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
					else
						unknown = new Vector3(Temp.transform.position.x-1f,Temp.transform.position.y+0.011f,Temp.transform.position.z+0.8f);
					
					GameObject golum = Instantiate(scr_guiControl.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
					
					scr_guiControl.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
					fp.findGolum();
					fp.halfling_Generate = true;
					fp.Halfing_Front_Hammer = true;
					
					scr_popUpInfo.PlayScaffolding(Temp.transform.position);
				}
			}
			else if (!halflingBool)
			{
				Temp.transform.Find("Isometric_Collider").gameObject.tag = "Dworking";
				
				Vector3 unknown = Vector3.zero;
					
				if (!obeliskBool)
					unknown = new Vector3(Temp.transform.position.x-1.75f,Temp.transform.position.y+0.011f,Temp.transform.position.z-1.75f);
				else
					unknown = new Vector3(Temp.transform.position.x-1.31f,Temp.transform.position.y+0.011f,Temp.transform.position.z+0.79f);
				
				GameObject Darkgolum = Instantiate(scr_guiControl.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
				scr_guiControl.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
			
				fp.darkling_Generate = true;
				fp.Darking_Front_Hammer = true;
				
				scr_popUpInfo.PlayScaffolding(Temp.transform.position);
			}
			
			Destroy(Temp.GetComponent<progressBar>());
			
			if (!obeliskBool)
				Temp.renderer.material.mainTexture = scr_popUpInfo.upgradeTextureInfo.constuctionLevel;
			else
				Temp.renderer.material.mainTexture = scr_UpgradeTexture.h_ObeliskContruction;
			
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(true);
			Temp.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("selectionPatch").gameObject.active = false;
			Temp.transform.FindChild("redPatch").gameObject.active = false;
			Temp.transform.FindChild("greenPatch").gameObject.active = false;
			Temp.gameObject.GetComponent<Sensors>().enabled = false;
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			Transform rabbit = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			rabbit.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
			Temp.transform.GetComponent<upgradeProgressBar>().enabled = true;
			upgradeProgressBar bar = Temp.transform.GetComponent<upgradeProgressBar>() ;
			//bar.objTypeId = objTypeID;
			bar.objTypeId = objId;
			
			if (gldButton != null)
					gldButton.gameObject.SetActiveRecursively(false);
			
			float construct = (ReturnConstructionTime(objTypeID) * 60);
			bar.seconds = (float) ReturnTimefrmSvr(objTypeID);
			
		    bar.cnt = (int)(construct - bar.seconds);
			float remainTime = ((float)bar.cnt) / construct;
			bar.seconds = construct;

			bar.SecCnt = (bar.seconds - ((float)bar.cnt));

			
			bar.progressBarPov.transform.localScale = new Vector3(remainTime, 
																	bar.progressBarPov.transform.localScale.y, 
																	bar.progressBarPov.transform.localScale.z);
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			
			if (Temp.tag == "Inn")
				delObjUIButtonInfo.methodToInvoke = "upgradeInnRabbitButton";
			else if (Temp.tag == "DInn")
				delObjUIButtonInfo.methodToInvoke = "upgradeDarklingInnRabbitButton";
			else if (Temp.tag == "DBlackSmith")
				delObjUIButtonInfo.methodToInvoke = "upgradeDarklingBlackSmithRabbitButton";
			else if (Temp.tag == "BlackSmith")
				delObjUIButtonInfo.methodToInvoke = "upgradeBlackSmithRabbitButton";
			else if (Temp.tag == "Stable")
				delObjUIButtonInfo.methodToInvoke = "upgradeStableRabbitButton";
			else if (Temp.tag == "DStable")
				delObjUIButtonInfo.methodToInvoke = "upgradeDarklingStableRabbitButton";
			
		}
		else
		{
			GameObject objUI = Temp.transform.FindChild("UI").gameObject;
			GameObject objButt = objUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			objButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject objCancle = objUI.transform.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			objCancle.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			Transform rabbitButt = Temp.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			rabbitButt.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
			
			if (Temp.tag == "Inn")
				rabbitButt.gameObject.GetComponent<UIButton>().methodToInvoke = "upgradeInnRabbitButton";
			
			Temp.transform.Find("Isometric_Collider").gameObject.tag = "editableObj";
			Temp.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
			Temp.transform.FindChild("touchMovePlane").gameObject.active = false;
			Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
			Temp.transform.FindChild("redPatch").gameObject.active = false;
			Temp.transform.FindChild("greenPatch").gameObject.active = false;
			Temp.transform.FindChild("selectionPatch").gameObject.active = false;
			Temp.gameObject.GetComponent<Sensors>().enabled = false;
			
			if (Temp.tag == "DTavern")
				Temp.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			if (Temp.tag == "Tavern")
			{
				Temp.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			}
			if(Temp.tag == "Apothecary")
			   Temp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			if(Temp.tag == "DApothecary")
			   Temp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			
			Destroy(Temp.GetComponent<progressBar>());
			
			if (obeliskBool)
			{
				Temp.transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
				Temp.transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
				Temp.transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
				Temp.transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
			}
			
			if (gldButton != null)
					gldButton.gameObject.SetActiveRecursively(false);
			
			if(level == 1 && status == 2)
				Temp.renderer.material.mainTexture = objLevel01_Tex;
			else if (level == 2 && status == 2)
			{
				Temp.renderer.material.mainTexture = objLevel02_Tex;
				if (nightObjBool)
					Temp.transform.FindChild(nightObjName).gameObject.renderer.material.mainTexture = nightObjTex_L02;
			}
			else if (level == 3 && status == 2)
			{
				Temp.renderer.material.mainTexture = objLevel03_Tex;
				if (nightObjBool)
					Temp.transform.FindChild(nightObjName).gameObject.renderer.material.mainTexture = nightObjTex_L03;
			}
		}
		//if (!obeliskBool)
			Temp.GetComponent<upgradeProgressBar>().currentUpgradeLevel = level;
		//On Object click call the below api
		
		if (gldButton != null)
		{
			if(objgold > 1 && status != 1)
			{
		    	GameObject tempGold = gldButton.transform.FindChild("Gold").gameObject;
				tempGold.GetComponent<UIButton>().scriptWithMethodToInvoke = scr_guiControl;
				gldButton.gameObject.SetActiveRecursively(true);
			}
		}
	}
	
	// cave load
	/*void CaveLoad(GameObject cavePref, Vector3 objPos, Vector3 objRot, int objTypeID, string objName)
	{
		Temp = Instantiate(cavePref, objPos, Quaternion.Euler(objRot)) as GameObject;
		
		Temp.transform.position = new Vector3(Temp.transform.position.x, (0.0306f -(Temp.transform.position.z / 10000)), Temp.transform.position.z);
				
		Temp.gameObject.name = objName;//"HC_B_GoblinCamp_GO(Clone)_01";
			
		GameObject hGC01 = Temp.gameObject;
		
		Temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		Temp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			
		//change textrue only for level 2
		if (GameManager.gameLevel == 2 && hGC01.name == "HC_B_GoblinCamp_GO(Clone)_01")
		{
			hGC01.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
			hGC01.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			hGC01.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
			hGC01.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
			
		Transform rabbit = hGC01.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = scr_guiControl;
			
		if (IsConstructedOrNot(objTypeID))
		{
				
				hGoblinCave01_bool = true;
				hGC01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				GameObject rabbitButtenEff = hGC01.transform.FindChild("RabbtiButton").gameObject;
				rabbitButtenEff.SetActiveRecursively(true);
				rabbitButtenEff.GetComponent<buttonPulse>().scaleAnim = true;						
				
				hGC01.transform.GetComponent<progressBar>().enabled = true;
				progressBar bar = hGC01.transform.GetComponent<progressBar>();
			    scr_gameObjectSvr.objGoblinCamp01.CreateTime = (float)( ReturnConstructionTime(101)  * 60);
				
				bar.seconds = (float) ReturnTimefrmSvr(101);
				
				//Debug.Log("creation Time : " + scr_gameObjectSvr.objGoblinCamp01.CreateTime);
				
				bar.cnt = (int)((scr_gameObjectSvr.objGoblinCamp01.CreateTime) - bar.seconds);
				float remainTime = ((float)bar.cnt) / scr_gameObjectSvr.objGoblinCamp01.CreateTime;
				bar.seconds = scr_gameObjectSvr.objGoblinCamp01.CreateTime;
				
				bar.progressBarPov.transform.localScale = new Vector3(remainTime, bar.progressBarPov.transform.localScale.y, bar.progressBarPov.transform.localScale.z);
				
				
				if (GameManager.gameLevel >= 3)
					delObjUIButtonInfo.methodToInvoke = ("goblinCaveRabbitButton");
				else
					delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
			}	
			else
			{
				if (GameManager.taskCount == 4)
				{
					//Debug.Log("----- goblin complete---- ");
					GameManager.taskCount = 5;
					scr_popUpInfo.updateTaskCount();
				}
			}
		}
	}*/
	
	void FindCreature(int id, GameObject cave)
	{
		Transform shadow = null;
			
		int crId =  ReturnCreatureIdforCave(id);
		scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
		string creatureName = scr_popUpInfo.GetCreatureNamefromTypeId(ReturnTypeIdfromObjId(crId));
					
		GameObject hGC_Creature = GameObject.Find(creatureName) as GameObject;
		
		if (hGC_Creature != null)
		{
			hGC_Creature.GetComponent<MeshRenderer>().enabled = false;
					
			shadow = hGC_Creature.transform.FindChild("shadow") as Transform;
		
			if (shadow != null)
				shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;	
			
			// Play animation
			if (hGC_Creature.tag == "Hound")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.houndAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Barg")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.bargAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Cusith")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.cusithAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			
			else if (hGC_Creature.tag == "Sprout")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.sproutAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Nymph")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.nymphAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Dryad")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.dryadAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			
			else if (hGC_Creature.tag == "Nix")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.nixAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Draug")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.draugAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Dragon")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.dragonAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			
			else if (hGC_Creature.tag == "Leech")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.leechAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Leshy")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.leshyAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Lurker")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.lurkerAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			
			else if (hGC_Creature.tag == "DHound")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.dHoundAttack_PF, new Vector3(cave.transform.position.x - 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Fenrir")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.fenrirAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "HellHound")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.hellHoundAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			
			else if (hGC_Creature.tag == "Sprite")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.spriteAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Imp")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.impAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
			else if (hGC_Creature.tag == "Djinn")
			{
				GameObject creatureAttackObj = Instantiate(scr_gameManager.djinnAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
				creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
			}
		}
	}
}
