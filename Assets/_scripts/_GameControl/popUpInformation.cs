using UnityEngine;
using System.Collections;

public class popUpInformation: MonoBehaviour 
{
	//[HideInInspector]
	private string[] popUpText = {"00 Take some spark and gold to start game",
								 "01 Halfling, to bury the spark visit my market and purchase a Training Ground, you will find these grounds have a mysterious power when you bury your spark deep in the earth",//In order to bury a spark, you must own the right kind of land. Everything you need can be found at the local market. Go there now to purchase a training ground.",
								 "02 Training Ground Info",
								 "03 Plant a spark in the Earth Training Ground to grow an earth creature",
								 "04 Your creature will take some time to generate. Invest one spark. Do you want to invest one spark now?",
								 "05 A strange hound like creature has been born from the earth.", 
								 "06 It seems hungry, better feed it before it feeds on you", //Next, lets help our Halfling friend move around.  He needs some paths to walk around his farm.  Go to the market to buy some.",
								 "07 Now grow something to feed that creature", //Congratulations Level 1 sucessfully completed",
								 "08 The turnip plant will take time to grow. In order to speedup growth invest one spark. Would you like to invest one spark now?",//It's hard to build things with so many unwanted guests about. Now that you have a creature to fight with, lets get rid of some of those pests.",
								 "09 Your crops are ready to Harvest", //It will take time to destroy the goblin camp. Don't delay! Invest one spark to eliminate the threat. Would you like to invest one spark now?",
								 "10 Your food is grown, now feed your creature",//Nice work. The goblins and their camp have been destroyed. Be on the lookout for other invaders trying to occupy your land.",
								 "11 Tap the food icon to feed your creature", //However. Hunting goblins is not our young friend's main source of income. He is a halfling after all and halflings are farmers. Go to the market to purchase some farm land.",
								 "12 It seems to like you, lets name our new friend",//Now plant some turnips on it you can use yourself.",
								 "13 Next, let's help our Halfling friend move around. He need some paths to walk around his farm.", //The turnip plant will take time to grow. In order to speedup growth invest one spark. Would you like to invest one spark now?",
								 "14 Congratulations level 1 sucessfully completed.",
								 "15 Leave our lands or die",
								 "16 You are under attack.Beware when Goblins/Trolls/Orcs attack they effect your global gold & food by reducing them gradually.",//You are under attack", // You could make extra gold by giving weary travelers a place a rest; only Halflings don't build buildings, some extra help is needed.",
								 "17 Quick young Halfling, put up magical wards to push the goblins back", // Go to the market and purchase an inn and I will lend you one of my golems to assist with the building.",
								 "18 That was tool close. Now that we have them on the run... lets finish them off", // The inn will take time to build. In order to speedup building invest one spark. Would you like to invest one spark now?",
								 "19 It will take time to destroy the goblin camp. Don't delay! Invest one spark to eliminate the threat. Would you like to invest one spark now?", //You have sucessfully built an inn",
								 "20 Halfling Wars runs on a global clock. You'll find that day vs night (when your play) affect many aspects of game play", //The Crest runs on a global clock. You will find this affects many aspects of game play.",
								 "21 All this work has made me thirsty. Perhaps a pint down at the Tavern...",
								 "22 Congratulations you have successfully completed your training & now you are on your own", //Congratulations Level 2 sucessfully completed",
								 "23 Town Tavern",
								 "24 While drinking a refreshing beverage, you can't help but overhear some of the townsfolk chatter.",
								 "25 The pint is finish and it is time to go home.",
								 "26 Farmer McGee visits your farm.",
								 "27 Now purchase Training Ground from market and grow creature...",
								 "28 Quest 1 completed.",
								 "29 Create plant training ground!",
								 "30 Congratulations Level 3 sucessfully completed",
								 "31 Purchase Bridge from Market to unlock the Darkling Side...",
								 "32 Are you sure you want to rebuild the bridge?",
								 "33 The bridge cost 25 sparks to rebuild, and it unlocks Darkling side, Are you sure you'd like to accept this quest?",
								 "34 Quest 2 completed.",
								 "35 You have unlocked darkling items.",
								 "36 Congratulation battle tutorial is completed.",
								 "37 Congratulations level 4 sucessfully completed.",
								 "38 Accept quest, 'Leeching'",
								 "39 Quest 3 completed.",
								 "40 Congratulations level 5 sucessfully completed.",
								 "41 Accept quest 'To Battle (find your leech)'?",
								 "42 Quest 4 completed.",
								 "43 You need a bigger creature, Accept quest 'Morph'?",
								 "44 Quest 5 completed.",
								 "45 Accept quest 'Widow Stufflebrew'?",
								 "46 Quest accepted, Leeching.",
								 "47 Quest accepted 'To Battle (find your leech)'",
								 "48 Quest accepted 'Morph'?",
								 "49 Accept quest 'New Creature'?",
							 	 "50 Quest 6 completed.",
								 "51 Quest accepted 'New Creature'",
								 "52 Accept quest 'Show me the Money'?",
								 "53 Quest 7 completed.",
								 "53 Quest accepted 'Show me the Money'",
								 "54 Accept quest 'Strange Brew'?",
								 "55 Quest 8 completed.",
								 "56 Quest accepted 'Strange Brew'.",
								 "57 Accept quest 'Master of the House'?",
								 "58 Quest 9 completed.",
								 "59 Quest accepted 'Master of the House'",
								 "60 Accept quest 'A Lingering Darkness'?",
								 "61 Quest 10 completed.",
								 "62 Quest accepted 'A Lingering Darkness'",
		                         "63 Accept quest 'The Guardian'?",
		                         "64 Quest 11 completed",
		                         "65 Quest accepted 'The Guardian'",
		                         "66 Accept Quest 'The Hunt'?",
		                         "67 Quest 12 completed",
		                         "68 Quest accepted 'The Hunt'",
								 "69 Congratulation You have unlocked the battle ground. Lets start with battle tutorial.",
								 "70 Place leech creature to play this quest",
								 "71 Grow Darkling Pumpkin To Play Quest",
								 "72 Build Halfling Tarven To Play Quest",
								 "73 Build Darkling Apothecary and 10 Aven Plants To Play Quest",
								 "74 Build MoonShrine and SunShrine To Play Quest",
								 "75 You Don't Have Enough Sparks To Play Quest",
								 "76 Grow Atleast 20 pipeWeed To Play Quest",
								 "77 Purchase Earth Obelisk to stop goblin attack...", //Place Cusith,Dryad and Dragon Creatures To Play Quest",
								 "78 Purchase Earth Obelisk to stop goblin attack..."
								};
	
	private string[] dPopUpText = {"0",
									"1 Creature will generate in sometime. In order to speedup the growth invest one spark. Would you like to invest one spark now?",
									"2 Turnip will take time to grow. In order to speedup the growth invest one spark. Would you like to invest one spark now?",
									"3 Goblin Cave will take time to destory. In order to speedup destruction invest one spark. Would you like to invest one spark now?",
									"4 Are you sure you want to upgrade?",
									"5 This building will take time to build. In order to speedup the build invest one spark. Would you like to invest one spark now?",
									"6 TrainingGround will take time to Upgrade. In order to speedup upgrade invest one spark. Would you like to invest one spark now?",
									"7 Not enough food",
									"8 Not enough sparks",
									"9 This halfling goblin camp 02 destroy on 4th level",
									"10 This darkling goblin camp 01 destroy on 5th level",
									"11 This halfling goblin camp 03 destroy on 6th level",
									"12 This darkling goblin camp 02 destroy on 7th level",
									"13 This halfling troll cave 01 destroy on 8th level",
									"14 This darkling goblin camp 03 destroy on 9th level",
									"15 This halfling troll cave 02 destroy on 10th level",
									"16 This darkling troll cave 01 destroy on 11th level",
									"17 This halfling troll cave 03 destroy on 12th level",
									"18 Not enough gold.",
									"19 You cannot upgrade at this level.",
									"20 You cannot purchase at this level.",
									"21 Congratulations level 6 sucessfully completed.",
									"22 Congratulations level 7 sucessfully completed.",
									"23 Congratulations level 8 sucessfully completed.",
									"24 Congratulations level 9 sucessfully completed.",
									"25 Congratulations level 10 sucessfully completed.",
									"26 Congratulations level 11 sucessfully completed.",
									"27 Congratulations level 12 sucessfully completed.",
									"28 Congratulations level 13 sucessfully completed.",
									"29 Congratulations level 14 sucessfully completed.",
									"30 You cannot morph at this level.",
									"31 Upgrade this training ground.",
									"32 You cannot feed creature at this level.",
									"33 Garden Plot will time to upgrade. In order to speedup invest one spark. Would you like to invest one spark now?",
									"34 This object already exist.",
									"35 Halfling Inn will take time to upgrade. In order to speedup invest one spark. Would you like to invest one spark now?",
									"36 You cannot delete this object.",
									"37 You cannot move this object.",
									"38 Creature already placed.",
		                            "39 Connection lost.",
									"40 Another building construction in progress.",
									"41 Upgrade in progress.",
									"42 Cannot place this creature on this training ground.",
									"43 You have reached the maximum level.",
									"44 You selected wrong creature, please check cave information and select appropriate creature.",
									"45 Upgrade your Creature using feed button inside creature info panel.",
									"46 You cannot select this object now.",
									"47 You cannot select this creature now.",
									"48 Select garden plot.",
									"49 Place garden plot first.",
									"50 You cannot place more than 2 creatures on the same training ground.",
									"51 Complete the previous quest first.",
									"52 Quest will take time to complete. In order to speedup invest one spark. Would you like to invest one spark now?",
									"53 Quest is already running...",
									"54 You cannot upgrade this object...",
									"55 Are you sure, you want to burry a spark now?",
									"56 Please upgrade garden plot...",
								 	"57 Grow leech creature to play this quest",
		                            "58 Are you sure ,you want to accelerate ",
		                            "59 Sorry your internet connection is slow to run the game ",
									"60 Bridge will take time to build. In order to speedup invest one spark. Would you like to invest one spark now?",
									"61 Something strange seems to be growing under the earth",
									"62 Warning Goblin creatures are comming to attack..."
								  };
	
//	private string[] iPopUpText = { "000",
//									"001 
	
	private int[] popUpNo = new int[30];
	private int[] popUpType = {1, 2, 3, 4};
	
	private int index = 0;
	public int curPopUpCnt = 1, curPopUpType = 0;
	
	public guiControl guiControlInfo;
	public GameManager gameManagerInfo;
	public UpgradeTexture upgradeTextureInfo;
	public Inventory inventoryInfo;
	public taskDetails taskDetailsInfo;
	public Inventory1 inventory1Info;
	public charMove scr_CharMove;
	public dCharMove scr_DCharMove;
	public grid scr_grid;
	public objectSelection scr_ObjectSelection;
	public objectCost scr_ObjectCost;
	
	private bool nextPopUpBool;
	
	public bool pipweedBoolThree = false;
	public bool turnipBool= false;
	public bool turnipBoolThree = false;
	public bool gardenPlotFive = false;
	public bool gardenPlotSeven = false;
	public bool gardenPlotTen = false;
	public bool gardenPlotThirteen = false;
	
	public bool DarkPlotFour =false;
	public bool DarkPlotSeven = false;
	public bool DarkPlotTen = false;
	public bool DarkPlotThirteen = false;
	
	public GUIText guiCurPopupCnt, guiCurPopupType;
	public bool defaultPopUpBool = false;
	public bool sparkPopUpBool = false;
	
	public GameObject wall;
	public SfsRemote scr_sfsRemoteCnt;
	public LoadUserWorld scr_loadUserWorld;
	public GameObjectsSvr scr_GameObjSvr;
	public string TaskIdforServer;
	public findPath fp;
	public infoImageList scr_infoImageList;
	
	public int cnDGrnd = 0;
	public int cnGrnd = 1;
	
	private InventoryItems scr_inventoryItems;
	private AchivementsDetails ad;
	
	private AudioSource audio_constructing;
	public AudioSource audio_buttonClick;
	public AudioController scr_audioController;
	public Vector3 halfdirtpath;
	public Vector3 darkdirtpath;
	public dirtPathPlacement dirtpathplace;
	
	private float 	creatureLayerTop = 0.0004f, 
					creatureLayerMid = 0.0003f, 
					creatureLayerBack = 0.0002f;
	
	private bool bridgeRabbitBool = false;
	
	private OrcAttackSystem scr_orcAttack;
	
	public Texture goblinTex, orcTex, trollTex, samTex;
	public GameObject popUpGuidObj;
	
	void Awake()
	{
		scr_sfsRemoteCnt = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_loadUserWorld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_infoImageList = GameObject.Find("GameManager").GetComponent<infoImageList>();
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		scr_orcAttack = GameObject.Find("GameManager").GetComponent<OrcAttackSystem>();
		scr_ObjectCost = GameObject.Find("GameManager").GetComponent<objectCost>();
	}
	// Use this for initialization
	void Start () 
	{
		fp = (findPath)FindObjectOfType(typeof(findPath));
		
		scr_inventoryItems = (InventoryItems)FindObjectOfType(typeof(InventoryItems));
		ad= (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiCurPopupCnt.text = "Cur PopUp Count :: " + curPopUpCnt.ToString();
		guiCurPopupType.text = "PopUp Type :: " + curPopUpType.ToString();
		
		if(isQuest1Completed == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//gameManagerInfo.Quest1();
		}
		if(isQuest5Completed == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest5();
		}
		if(isQuest6Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest6();
		}
		if(isQuest7Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest7();
		}
		if(isQuest8Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest8 ();
		}
		if(isQuest9Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest9();
		}
		if(isQuest10Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B should start");
			//gameManagerInfo.Quest10 ();
		}
		
		if(isQuest11Complete == true)
		{
			wall.active = true;
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			//Debug.Log("Quest B of 11 should start");
			//gameManagerInfo.Quest11();	
		}
		
		EnableMiniGames();
	}
	
//=======================================================================================================================================
	
	// generate pop ups
	public void generatePopUp(int popUpCnt, int pType)
	{
		if (GameManager.popUpCount == popUpCnt)
		{
			if (guiControlInfo.popUpType1.activeInHierarchy == true)
				guiControlInfo.popUpType1.SetActiveRecursively(false);
			if (guiControlInfo.popUpType2.activeInHierarchy == true)
				guiControlInfo.popUpType2.SetActiveRecursively(false);
			if (guiControlInfo.popUpType3.activeInHierarchy == true)
				guiControlInfo.popUpType3.SetActiveRecursively(false);
			if (guiControlInfo.popUpType4.activeInHierarchy == true)
			{
				guiControlInfo.popUpType4.SetActiveRecursively(false);
			}
			
			Debug.Log("popUpType : "+popUpType[pType]);
			Debug.Log("popUpCnt : "+popUpCnt);
			if (popUpType[pType] == 1)
			{
				wall.active = true;
				guiControlInfo.popUpType1.SetActiveRecursively(true);
				guiControlInfo.popUpType1_spText.Text = popUpText[popUpCnt];
				
				Transform popupImageObj = guiControlInfo.popUpType1.transform.FindChild("popUpImage") as Transform;
				popupImageObj.gameObject.renderer.material.mainTexture = scr_infoImageList.popUpImageList[popUpCnt];
				
				if (GameManager.gameLevel < 3)
					guiControlInfo.popUpType1.transform.FindChild("samImage").gameObject.active = true;
				else
					guiControlInfo.popUpType1.transform.FindChild("samImage").gameObject.active = false;

				if (curPopUpCnt == 22)
					guiControlInfo.popUpType1.transform.FindChild("samImage").gameObject.active = true;
			}
			else if (popUpType[pType] == 2)
			{
				wall.active = true;
				guiControlInfo.popUpType2.SetActiveRecursively(true);
				guiControlInfo.title_spText.Text = " ";
				guiControlInfo.info_spText.Text = popUpText[popUpCnt];
			}
			else if (popUpType[pType] == 3)
			{
				wall.active = true;
				guiControlInfo.popUpType3.SetActiveRecursively(true);
				guiControlInfo.popUpType3_spText.Text = popUpText[popUpCnt];
				
				Transform popupImageObj = guiControlInfo.popUpType3.transform.FindChild("popUpImage") as Transform;
				popupImageObj.gameObject.renderer.material.mainTexture = scr_infoImageList.popUpImageList[popUpCnt];
			}
			
		
		}
	}

//=======================================================================================================================================
	
	
	// Create Defalult popups
	public void defaultPopUp(int dPopUpCnt, int dPopUpType)
	{
		// pop up restrictions for overlaping
		if (guiControlInfo.buildingUI.active == true)
			guiControlInfo.buildingUI.SetActiveRecursively(false);
		if (guiControlInfo.creatureUI.active == true)
			guiControlInfo.creatureUI.SetActiveRecursively(false);
		if (guiControlInfo.decorationUI.active == true)
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		if (guiControlInfo.plantsUI.active == true)
			guiControlInfo.plantsUI.SetActiveRecursively(false);
		if (guiControlInfo.storeUI.active == true)
			guiControlInfo.storeUI.SetActiveRecursively(false);
		if (guiControlInfo.trainingGroundUI.active == true)
			guiControlInfo.trainingGroundUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingBuildingUI.active == true)
			guiControlInfo.darklingBuildingUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingCreatureUI.active == true)
			guiControlInfo.darklingCreatureUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingDecorationUI.active == true)
			guiControlInfo.darklingDecorationUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingPlantUI.active == true)
			guiControlInfo.darklingPlantUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingStoreUI.active == true)
			guiControlInfo.darklingStoreUI.SetActiveRecursively(false);
		if (guiControlInfo.darklingTrainingGroundUI.active == true)
			guiControlInfo.darklingTrainingGroundUI.SetActiveRecursively(false);
		if (guiControlInfo.inventoryUI.active == true)
			guiControlInfo.inventoryUI.SetActiveRecursively(false);
		if (guiControlInfo.storeHDUI.active == true)
			guiControlInfo.storeHDUI.SetActiveRecursively(false);
		if (scr_inventoryItems.invCreatureBasePlate.active == true)
			scr_inventoryItems.invCreatureBasePlate.SetActiveRecursively(false);
		
		
		if (guiControlInfo.popUpType1.active == true)
			guiControlInfo.popUpType1.SetActiveRecursively(false);
		if (guiControlInfo.popUpType2.active == true)
			guiControlInfo.popUpType2.SetActiveRecursively(false);
		if (guiControlInfo.popUpType3.active == true)
			guiControlInfo.popUpType3.SetActiveRecursively(false);
		if (guiControlInfo.popUpType4.active = true)
		{
			guiControlInfo.popUpType4.SetActiveRecursively(false);
		}
		
		if (popUpType[dPopUpType] == 1)
		{
			wall.active = true;
			guiControlInfo.popUpType1.SetActiveRecursively(true);
			guiControlInfo.popUpType1_spText.Text = dPopUpText[dPopUpCnt];
			
			Transform popupImageObj = guiControlInfo.popUpType1.transform.FindChild("popUpImage") as Transform;
			popupImageObj.gameObject.renderer.material.mainTexture = scr_infoImageList.defaultPopUpImageList[dPopUpCnt];
		}
		else if (popUpType[dPopUpType] == 2)
		{
			wall.active = true;
			guiControlInfo.popUpType2.SetActiveRecursively(true);
			guiControlInfo.title_spText.Text = " ";
			guiControlInfo.info_spText.Text = dPopUpText[dPopUpCnt];
		}
		else if (popUpType[dPopUpType] == 3)
		{
			wall.active = true;
			guiControlInfo.popUpType3.SetActiveRecursively(true);
			guiControlInfo.popUpType3_spText.Text = dPopUpText[dPopUpCnt];
			
			Transform popupImageObj = guiControlInfo.popUpType3.transform.FindChild("popUpImage") as Transform;
			popupImageObj.gameObject.renderer.material.mainTexture = scr_infoImageList.defaultPopUpImageList[dPopUpCnt];
		}
	}

//=======================================================================================================================================
	
	// destroy pop ups
	public void destroyPopUp(int popUpCnt, int pType)
	{
		if (GameManager.popUpCount == popUpCnt)
		{
			wall.active = false;
			if (popUpType[pType] == 1)
				guiControlInfo.popUpType1.SetActiveRecursively(false);
			else if (popUpType[pType] == 2)
				guiControlInfo.popUpType2.SetActiveRecursively(false);
			else if (popUpType[pType] == 3)
				guiControlInfo.popUpType3.SetActiveRecursively(false);
		}
	}
	
//=======================================================================================================================================
		
	void popUpOkButton()
	{
		nextPopUpBool = true;
		wall.active = false;
		
		if (GameManager.popUpCount == curPopUpCnt && nextPopUpBool)
		{
			GameManager.popUpCount++;
			updatePopUpCount();
			
			nextPopUpBool = false;
			
			if (popUpType[curPopUpType] == 1)
			{
				guiControlInfo.popUpType1.SetActiveRecursively(false);
			}
			else if (popUpType[curPopUpType] == 2)
			{
				guiControlInfo.popUpType2.SetActiveRecursively(false);
			}
			else if (popUpType[curPopUpType] == 3)
			{
				guiControlInfo.popUpType3.SetActiveRecursively(false);
			}
			else if (popUpType[curPopUpType] == 4)
			{
				guiControlInfo.popUpType4.SetActiveRecursively(false);
			}
			
			Debug.Log("GameManager.popUpCount : "+GameManager.popUpCount);

			if (GameManager.popUpCount == 1 && GameManager.taskCount == 0)
			{
				Debug.Log("task count is 0..............................");
				GameManager.popUpCount = 1;
				curPopUpCnt = 1;
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
			}

			if (GameManager.popUpCount == 2)
			{
				GameManager.taskCount = 1;
			}
			// task 1
			if (GameManager.taskCount == 1)
			{
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;
			
				// market button effect
				//buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				buttonPulse marketBP = GameObject.Find("button_Market").gameObject.AddComponent("buttonPulse") as buttonPulse;
				marketBP.minSpeed = 3;
				marketBP.maxSpeed = 8;
				marketBP.minVal = 0.05f;
				marketBP.maxVal = 0.2f;
				marketBP.scaleAnim = true;
				
				// arrow on market button
				GameObject ms = GameObject.Find("marketSpwan");
				GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
				guiControlInfo.delArrow = temp;
			}
			
			// pop up 3
			if (GameManager.popUpCount == 3)
			{
				Debug.Log("---> GameManager.popUpCount == 3 <---");
				curPopUpCnt++;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
				guiControl.executeTaskBool = true;
			
			}
			
			if (curPopUpCnt == 3)
			{
				GameObject.Find("ObjectEditPanel").gameObject.transform.FindChild("objUpgrade").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
				Debug.Log("---> curPopUpCnt == 3 <---");
				objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
				
				objEditPanelInfo.panelMoveIn = false;
				objEditPanelInfo.panelMoveOut = true;
		
				GameObject objInfo_spwan = GameObject.Find("objInfo_spwan") as GameObject;
				GameObject temp = Instantiate(guiControlInfo.arrow, objInfo_spwan.transform.position, Quaternion.Euler(90, 90,0)) as GameObject;
				guiControlInfo.delArrow = temp;
			}
			
			// task 2 use rabbit option for hound
			if (curPopUpCnt == 4)
			{
				Debug.Log("---> curPopUpCnt == 4 <---");
				guiControl.useRabbitBool = false;
				
				GameObject go = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
				GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				//tg.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
				tg.transform.FindChild("Spark1").gameObject.GetComponent<MeshRenderer>().enabled = false;
				tg.transform.FindChild("Spark2").gameObject.GetComponent<MeshRenderer>().enabled = false;
				Destroy(tg.GetComponent<SparkAnimation>());
				
				(go.GetComponent("progressBar") as progressBar).enabled = true;
				Transform rabbit = go.transform.FindChild("RabbtiButton") as Transform;
				if (rabbit != null)
					Destroy(rabbit.gameObject);
				
				// find creature "Hound" progress bar and destroy
				Destroy(go.GetComponent("progressBar"));
				Destroy(go.transform.FindChild("ProgressBar").gameObject);

				//indra get xp value from server
//				Debug.Log("hound XP : " + scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objHound.objTypeId));
//				GameObject xpValObj = Instantiate(Resources.Load("xpValue"), grid.curObj.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

				go.GetComponent<MeshRenderer>().enabled = true;
				go.GetComponent<HoundAnimation>().moveAB_Bool = true;
				
				// change "Hound" collider tag name
				go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameManager.taskCount = 3;
				updateTaskCount();
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objHound.objTypeId);
		    	scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				if(scr_audioController.audio_sparkBirth.isPlaying)
				{
					scr_audioController.audio_sparkBirth.Stop();
				}	
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				Destroy(go.transform.FindChild("greenPatch").gameObject);
				Destroy(go.transform.FindChild("redPatch").gameObject);
			}
			
			// pop up 5
			if (GameManager.popUpCount == 5)
			{	
				Debug.Log("---> GameManager.popUpCount == 5 <---");
				curPopUpCnt = 5;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
			}
			
			// pop up 6
			if (GameManager.popUpCount == 6)
			{
				Debug.Log("---> GameManager.popUpCount == 6 <---");
				curPopUpCnt = 6;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
			}
			
			// task 3
			if (GameManager.taskCount == 3 && GameManager.popUpCount == 7)
			{
				Debug.Log("---> GameManager.taskCount == 3 && GameManager.popupCount == 7 <---");
				// main menu control
				panelControl.panelMoveIn = false;
				panelControl.panelMoveOut = true;
				
				// market button effect
				buttonPulse marketBP = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
				marketBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
				marketBP.minSpeed = 3;
				marketBP.maxSpeed = 8;
				marketBP.minVal = 0.05f;
				marketBP.maxVal = 0.2f;
				marketBP.scaleAnim = true;
				
				// arrow on market button
				GameObject mSpwan = GameObject.Find("marketSpwan");
				GameObject temp = Instantiate(guiControlInfo.arrow, mSpwan.transform.position, mSpwan.transform.rotation) as GameObject;
				guiControlInfo.delArrow = temp;
			}
			
//			// pop up 7
//			if (GameManager.popUpCount == 7)
//			{
//				curPopUpCnt = 7;
//				updateCurPopUpCount();
//				
//				curPopUpType = 0;
//				generatePopUp(curPopUpCnt, curPopUpType);
//			}
			
			if (GameManager.popUpCount == 8)
			{
				Debug.Log("farm turnip...");
				task6(1);
				//task4(1); *change
			}
			
			// turnip glow complete
			if (GameManager.popUpCount == 9)
			{
				Debug.Log("farm turnip rabbit button...");
				task6 (6);
				curPopUpCnt = 9;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
				GameManager.taskCount = 5;
				updateTaskCount();
			}
				//task4(4);
			
			if (GameManager.popUpCount == 10)
			{
				Debug.Log("---> GameManager.popUpCount == 10");
				task7(1);
				/*curPopUpCnt = 10;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
				GameManager.taskCount = 5;
				updateTaskCount();*/
			}
			
			// pop up count 13 rename creature tutorial
			if (GameManager.popUpCount == 13)
			{
				Debug.Log("--> GameManager.popUpCount == 13");
				renameCreatureTutorial(1);
			}
			
			// pop up 19 inn builing complete
			if (GameManager.popUpCount == 18)
			{
				Debug.Log("--> GameManager.popUpCount == 18");
				//taskDetailsInfo.totalMissionCount = 3;			//Added
				obeliskTutorial(1);
				//task9(4);
			}
			
			// pop up 19
			if (GameManager.popUpCount == 19)
			{
				Debug.Log("---> GameManager.popCount == 19 <---");
				task4(1);
				//task10(1);
			}
			
			// pop up 20 goblin camp rabbit button
			if (GameManager.popUpCount == 20)
			{
				Debug.Log("---> GameManager.popCount == 20 <---");
				task4(4);
			}
			
			// pop up 21
			if (GameManager.popUpCount == 21)
			{
				Debug.Log("---> GameManager.popCount == 21 <---");
				//taskDetailsInfo.totalMissionCount = 3;			//Added
				GameManager.taskCount = 15;
				updateTaskCount();
				
				// log tutorial
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;

				// destroy market button effect
				buttonPulse marketBP1 = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				if (marketBP1 != null)
					Destroy(marketBP1);

				// market button effect
				buttonPulse market_BP = GameObject.Find("button_Task").AddComponent("buttonPulse") as buttonPulse;
				market_BP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
				market_BP.minSpeed = 3;
				market_BP.maxSpeed = 8;
				market_BP.minVal = 0.05f;
				market_BP.maxVal = 0.2f;
				market_BP.scaleAnim = true;

				// destroy market button effect
				buttonPulse marketBP2 = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				if (marketBP2 != null)
					Destroy(marketBP2);

				// destroy market button effect
				buttonPulse marketBP3 = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				if (marketBP3 != null)
					Destroy(marketBP3);


				GameObject temp = Instantiate(guiControlInfo.arrow, new Vector3(-49, 10, 84), Quaternion.Euler(90, 180,0)) as GameObject;
				guiControlInfo.delArrow = temp;
				
				taskDetailsInfo.RedQuestCount.Text = "1";
				taskDetailsInfo.blueQuestCount.Text = "3";
			}
			
			// pop up 23
			if (GameManager.popUpCount == 22)
			{
				Debug.Log("---> GameManager.popCount == 22 <---");
				GameManager.xp = GameManager.xp + 3;
			
				GameManager.taskCount = 16;
				updateTaskCount();
				
//				GameManager.popUpCount = 23;
//				curPopUpCnt = 23;
//				curPopUpType = 0;
//				generatePopUp(curPopUpCnt, curPopUpType);
			}
			
			// pop up 26 quest 1 dialog C
			if (GameManager.popUpCount == 27)
			{
				//gameManagerInfo.LookIntoQuest();
			}
			
			// pop up 27 quest 1 dialog D
			if (GameManager.popUpCount == 24)
			{
				if (GameManager.questActivateBool)
				{
					GameManager.questActivateBool = false;
					GameManager.questRunningBool = true;
					
					wall.active = true;
					guiControlInfo.popUpType4.SetActiveRecursively(true);
					guiControlInfo.popUpType_Dig2_spText.Text = "";
					
					guiControlInfo.popUpType_Dig1_spText.Text = gameManagerInfo.level3Dialog[0];
					gameManagerInfo.message = gameManagerInfo.level3Dialog[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					if(!gameManagerInfo.enableQuest)
					{
						gameManagerInfo.PlayQuestSounds();
					}
				}
			}
			
			// pop up 28 build second training ground
			if (GameManager.popUpCount == 28)
			{
				curPopUpCnt = 28;
				updateCurPopUpCount();
				
				GameObject go = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				if (go == null)
				{
					curPopUpType = 0;
					generatePopUp(curPopUpCnt, curPopUpType);
				}
			}
			
			// pop up 30 arrow pulsing on bridge
			if (GameManager.popUpCount == 30)
			{
				GameManager.popUpCount = 69;
				curPopUpCnt = 69;
				curPopUpType = 0;
				generatePopUp(curPopUpCnt,curPopUpType);
			}
			
//			// pop up 31 play quest 2
//			if (GameManager.popUpCount == 31)
//			{
//				Debug.Log("-------------------------------------------------");
//				
//				// open market and builing section
//				wall.active = true;
//				guiControlInfo.buildingUI.SetActiveRecursively(true);
//				Destroy(guiControlInfo.delArrow);
//				curPopUpCnt = 31;
//				updateCurPopUpCount();
//			}
//			
//			if (GameManager.popUpCount == 32)
//			{
//				Destroy(guiControlInfo.delArrow);
//				curPopUpCnt = 32;
//				updateCurPopUpCount();
//				
//				curPopUpType = 2;
//				generatePopUp(curPopUpCnt, curPopUpType);
//			}
			
			// pop up 31 play quest 2
			if (GameManager.popUpCount == 31)
			{
				Debug.Log("-------------------- 31 -----------------------------");
				
				// open market and builing section
				//wall.active = true;
				//guiControlInfo.buildingUI.SetActiveRecursively(true);
				Destroy(guiControlInfo.delArrow);
				curPopUpCnt = 31;
				curPopUpType = 0;
				updateCurPopUpCount();
				generatePopUp(curPopUpCnt, curPopUpType);
				taskArrowOnBrokenBridge();
			}
			
			if (GameManager.popUpCount == 32)
			{
				Debug.Log(" -------- 32 ------- ");
				wall.active = true;
				guiControlInfo.buildingUI.SetActiveRecursively(true);
				Destroy(guiControlInfo.delArrow);
				curPopUpCnt = 32;
				updateCurPopUpCount();
				
//				curPopUpType = 2;
//				generatePopUp(curPopUpCnt, curPopUpType);
				GameObject buildingScroll = GameObject.Find("buildingScroll") as GameObject;
				buildingScroll.transform.localPosition = new Vector3(7.5f, buildingScroll.transform.localPosition.y, buildingScroll.transform.localPosition.z);

				if (GameManager.unlockDarklingBool == false)
				{
					guiControlInfo.buildingUI.transform.FindChild("buildingScroll").gameObject.transform.FindChild("03_Bridge").gameObject.transform.FindChild("block").gameObject.SetActive(false);
				}
			}
			
			if (GameManager.popUpCount == 33)// && GameManager.readyToUnlockDarklingBool)
			{
				curPopUpCnt = 33;
				updateCurPopUpCount();
				
				curPopUpType = 0;
				generatePopUp(curPopUpCnt, curPopUpType);
				taskUnlockDarklingSide(1);
			}
			
			if (GameManager.popUpCount == 34)
			{
//				updateCurPopUpCount();
//				
//				wall.active = true;
//				guiControlInfo.popUpType5.SetActiveRecursively(true);
//				gameManagerInfo.scr_QuestTexControl.questSingleMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest02a_tex;
//				guiControlInfo.popUpType_Dig5_spText.Text = gameManagerInfo.quest_2B[0];
//				gameManagerInfo.message = gameManagerInfo.quest_2B[0];
//				gameManagerInfo.WriteText3();
//				gameManagerInfo.dialogCnt = 1;
//				gameManagerInfo.questA = true;
//				
//				if(!gameManagerInfo.enableQuest)
//				{
//					gameManagerInfo.PlayQuestSounds();
//				}
			}
			
			
//			if (GameManager.popUpCount == 36)
//			{
//				if (!GameManager.questRunningBool)
//					taskArrowOnBrokenBridge();
//			}
			
			
			if (GameManager.popUpCount == 37)
			{
				
			}
			
			// Quest 3
			if (GameManager.popUpCount == 38)
			{
				if (GameManager.questActivateBool && GameManager.quest == 2)
				{
					GameObject qCeeature = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
					if(qCeeature != null)
					{
						GameObject.Find("DL_C_Leech_GO(Clone)").gameObject.GetComponent<MeshRenderer>().enabled = false;
						GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest3); //Quest Activation 3
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
					}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 70;
						curPopUpCnt = 70;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			
			// quest 4 story
			if (GameManager.popUpCount == 40)
			{
				if (GameManager.questActivateBool && GameManager.quest == 3)
				{
					scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest4); //Quest Activation 4
					TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
					
					GameManager.questActivateBool = false;
					GameManager.questRunningBool = true;
					wall.active = true;
					guiControlInfo.popUpType4.SetActiveRecursively(true);
					guiControlInfo.popUpType_Dig1_spText.Text = "";
					guiControlInfo.popUpType_Dig2_spText.Text = "";
				}
			}
			// quest 4
			if (GameManager.popUpCount == 41)
			{
				if (GameManager.questActivateBool && GameManager.quest == 3)
				{
					GameObject.Find("DL_C_Leech_GO(Clone)").gameObject.GetComponent<MeshRenderer>().enabled = false;
					gameManagerInfo.dChar.SetActiveRecursively(false);
					GameManager.questActivateBool = false;
					scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest4);
					TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
			}
			
			// quest 5
			if (GameManager.popUpCount == 43)
			{
				if (GameManager.questActivateBool && GameManager.quest == 4)
				{
					if(GameManager.sparks >= 5)
					{
					GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest5);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 75;
						curPopUpCnt = 75;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			
			if(GameManager.popUpCount == 44)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest5);
			}
			
			// quest 6
			if (GameManager.popUpCount == 49)
			{
				if (GameManager.questActivateBool && GameManager.quest == 5)
				{
					if(scr_loadUserWorld.ReturnHerbandPlantsCount(scr_GameObjSvr.objDarklingPumpkin.objTypeId) > 0)
					{
					GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest6);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
					}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 71;
						curPopUpCnt = 71;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			if(GameManager.popUpCount == 50)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest6);
			}
			
			// quest 7
			if (GameManager.popUpCount == 52)
			{
				if (GameManager.questActivateBool && GameManager.quest == 6)
				{
					GameObject halfTarven = GameObject.Find("HC_B_Tavern_GO(Clone)") as GameObject;
					if(halfTarven != null)
					{
					GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest7);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 72;
						curPopUpCnt = 72;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			if(GameManager.popUpCount == 53)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest7);
			}
			// quest 8
			if (GameManager.popUpCount == 55)
			{
				if (GameManager.questActivateBool && GameManager.quest == 7)
				{
					GameObject darkApoth = GameObject.Find("DL_B_Apothecary_GO(Clone)") as GameObject;
					if(darkApoth != null && scr_loadUserWorld.ReturnHerbandPlantsCount(scr_GameObjSvr.objDarklingAvenHerb.objTypeId) >= 10)
					{
					GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest8);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 73;
						curPopUpCnt = 73;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			if(GameManager.popUpCount == 56)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest8);
			}
			
			// quest 9
			if (GameManager.popUpCount == 58)
			{
				if (GameManager.questActivateBool && GameManager.quest == 8)
				{
					GameManager.questActivateBool = false;
				scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest9);
				TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
			}
			}
			if(GameManager.popUpCount == 59)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest9);
			}
			
			// quest 10
			if (GameManager.popUpCount == 61)
			{
				if (GameManager.questActivateBool && GameManager.quest == 9)
				{
					GameObject moonshine = GameObject.Find("DL_B_MoonShrine_GO(Clone)") as GameObject;
					GameObject sunshine = GameObject.Find("HC_B_SunShrine_GO(Clone)") as GameObject;
					if(moonshine != null && sunshine != null)
					{
					GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest10);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 74;
						curPopUpCnt = 74;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			if(GameManager.popUpCount == 62)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest10);
			}
			
			//quest 11
			if(GameManager.popUpCount == 64)
			{
				if(GameManager.questActivateBool && GameManager.quest == 10)
				{
					if(scr_loadUserWorld.ReturnHerbandPlantsCount(scr_GameObjSvr.objPipeweed.objTypeId) >= 20)
					{
						GameManager.questActivateBool = false;
						scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest11);
						TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
					}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 76;
						curPopUpCnt = 76;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}
			
			if(GameManager.popUpCount == 65)
			{
				AssignQuestNo((int)GameObjectsSvr.QuestNo.Quest11);
			}
			
		    //quest 12
		
			if (GameManager.popUpCount == 67)
			{
				if (GameManager.questActivateBool && GameManager.quest == 11)
				{
					GameObject halfCusith = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
					GameObject halfDryad = GameObject.Find("HC_C_Dryad_GO(Clone)") as GameObject;
					GameObject halfDragon = GameObject.Find("HC_C_Dragon_GO(Clone)") as GameObject;
					
					if(halfCusith != null && halfDryad != null && halfDragon != null)
					{
					GameManager.questActivateBool = false;
					scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest12);
				    TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				}
					else
					{
						GameManager.questRunningBool = false;
						GameManager.questActivateBool = false;
						GameManager.popUpCount = 77;
						curPopUpCnt = 77;
						curPopUpType = 0;
						generatePopUp(curPopUpCnt,curPopUpType);
					}
				}
			}

			// purchase first earth obelisk
			if (GameManager.popUpCount == 79)
			{
				Debug.Log("------> <-------");
				//buttonPulse trainingGroundBP = GameObject.Find("storeDefenceButt").GetComponent("buttonPulse") as buttonPulse;
				//trainingGroundBP.scaleAnim = false;
				
				guiControlInfo.storeUI.SetActiveRecursively(false);
				wall.active = true;
				guiControlInfo.defenceUI.SetActiveRecursively(true);
				
				if (guiControlInfo.delArrow != null)
					Destroy(guiControlInfo.delArrow);
				
				GameObject ms = GameObject.Find("earthDefence_Spwan");
				GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, Quaternion.Inverse(ms.transform.rotation)) as GameObject;
				guiControlInfo.delArrow = temp;
				temp.transform.parent = ms.transform;

			}
		}
		else if (popUpType[curPopUpType] == 2)
				guiControlInfo.popUpType2.SetActiveRecursively(false);
		
		// show arrwo on food icon
		if (GameManager.popUpCount == 11)
		{
			Debug.Log("---> GameManager.popUpCount == 11");
			feedTutorial(1);
			//task5(1);
		}
		
		if (GameManager.popUpCount == 12)
		{
			Debug.Log("---> GameManager.popUpCount == 12");
			//task6(1);
			//feedTutorial(2);
			
		}
		
		// pop up 14 dirtPath Task
		if (GameManager.popUpCount == 14)
		{
			Debug.Log("---> GameManager.popUpCount == 14");
			placeDirtPathTutorial(1);
			//task7(1);
		}
		
		// pop up 15 
		if (GameManager.popUpCount == 15)
		{
			Debug.Log("---> GameManager.popCount == 15 <---");
			
			GameObject goblinCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			gameManagerInfo.scr_UnlockCaveTimerTut = goblinCamp.AddComponent<unlockCaveTimerTut>();
			
//			curPopUpCnt = 15;
//			updateCurPopUpCount();
//			
//			curPopUpType = 0;
//			generatePopUp(curPopUpCnt, curPopUpType);
		}
		
		// pop up 16
		if (GameManager.popUpCount == 16)
		{
			Debug.Log("---> GameManager.popCount == 16 <---");
			
			GameManager.popUpCount = 16;
			curPopUpCnt = 16;
			curPopUpType = 0;
			generatePopUp(curPopUpCnt, curPopUpType);
			updateCurPopUpCount();

			buttonPulse foodBP =  GameObject.Find("foodHUD").gameObject.AddComponent("buttonPulse") as buttonPulse;
			foodBP.gameObject.transform.localScale = new Vector3(1, 1, 1);
			foodBP.minSpeed = 3;
			foodBP.maxSpeed = 8;
			foodBP.minVal = 0.05f;
			foodBP.maxVal = 0.25f;
			foodBP.scaleAnim = true;

			buttonPulse goldBP =  GameObject.Find("goldHUD").gameObject.AddComponent("buttonPulse") as buttonPulse;
			goldBP.gameObject.transform.localScale = new Vector3(1, 1, 1);
			goldBP.minSpeed = 3;
			goldBP.maxSpeed = 8;
			goldBP.minVal = 0.05f;
			goldBP.maxVal = 0.25f;
			goldBP.scaleAnim = true;

			/*curPopUpCnt = 16;
			updateCurPopUpCount();
			
			curPopUpType = 0;
			generatePopUp(curPopUpCnt, curPopUpType);
			task8(1);*/
		}
		
		// pop up 17 task 9 build Inn building
		if (GameManager.popUpCount == 17)
		{
			Debug.Log("---> GameManager.popCount == 17 <---");
			unlockCaveTimerTut.creatureWalkBool = true;
			unlockCaveTimerTut.runOnceBool = true;

			buttonPulse foodBP =  GameObject.Find("foodHUD").gameObject.GetComponent("buttonPulse") as buttonPulse;
			foodBP.gameObject.transform.localScale = new Vector3(1,1,1);
			Destroy(foodBP);

			buttonPulse goldBP =  GameObject.Find("goldHUD").gameObject.GetComponent("buttonPulse") as buttonPulse;
			goldBP.gameObject.transform.localScale = new Vector3(1,1,1);
			Destroy(goldBP);

			//task9(1);
		}
		
//		// pop up 19
//		if (GameManager.popUpCount == 19)
//		{
//			Debug.Log("---> GameManager.popCount == 19 <---");
//			task4(1);
//			//task10(1);
//		}
		
		// pop up 20
		if (GameManager.popUpCount == 20)
		{
//			curPopUpCnt = 20;
//			updateCurPopUpCount();
//			
//			curPopUpType = 0;
//			generatePopUp(curPopUpCnt, curPopUpType);
//			GameManager.xp++;
		}
		
		// pop up 35
		if (GameManager.popUpCount == 35)
		{
			if (GameManager.questRunningBool && GameManager.quest == 1)
			{
				
			}
		}
	
		
		if (sparkPopUpBool)
		{
			destroyPopUp(GameManager.popUpCount, 0);
			sparkPopUpBool = false;
		}
			
		// default popup
		if (defaultPopUpBool)
		{
			Debug.Log("---> default popup bool : " + houndRabbitInfoBool + " <---");
			destroyPopUp(GameManager.popUpCount, 0);
			destroyPopUp(GameManager.popUpCount, 2);
			defaultPopUpBool = false;
			
		    if(GameManager.miniGamesaccelerateBool)
			{
				Debug.Log("---> 1 <---");
				GameManager.miniGamesaccelerateBool = false;
				
				if(guiControlInfo.GetAccelerateMiniGameItem() == "TavernMiniGame")
				{
					scr_sfsRemoteCnt.SendRequestForAccelerateMinigames("TavernMiniGame");
				}
				else if(guiControlInfo.GetAccelerateMiniGameItem() == "ApothecaryMiniGame")
				{
					scr_sfsRemoteCnt.SendRequestForAccelerateMinigames("ApothecaryMiniGame");
				}
			    guiControlInfo.popUpType2.transform.FindChild("InfoProgressBar").gameObject.SetActiveRecursively(false);
				
			}
			
			if (houndRabbitInfoBool)
			{
				Debug.Log("---> 2 <---");
				Debug.Log("---> hound rabbit info bool <---");
				houndRabbitInfoBool = false;
				gameManagerInfo.bubbleObj.SetActiveRecursively(true);
				gameManagerInfo.speakTextObj.active = true;
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("If you'd like to speed it up, simply add more sparks.  You can do this by clicking on the rabbit speed icon.");
			}
			
		
			if (GameManager.burrySparkBool)
			{
				Debug.Log("---> 3 <---");
				if (GameManager.curTG.tag == "TrainingGround")
				{
					//Debug.Log("current creature is HOUND........");
					guiControlInfo.creaturePlate01Button();
				}
				else if (GameManager.curTG.tag == "PlantTG")
				{
					//Debug.Log("current creature is Sprout........");
					guiControlInfo.creaturePlate04Button();
				}
				else if (GameManager.curTG.tag == "WaterTG")
				{
					//Debug.Log("current creature is Nix........");
					guiControlInfo.creaturePlate07Button();
				}
				else if (GameManager.curTG.tag == "Swamp")
				{
					//Debug.Log("current creature is Leech........");
					guiControlInfo.darklingCreature01Button();
				}
				else if (GameManager.curTG.tag == "DEarthTG")
				{
					//Debug.Log("current creature is Dark Hound........");
					guiControlInfo.darklingCreature04Button();
				}
				else if (GameManager.curTG.tag == "DFireTG")
				{
					//Debug.Log("current creature is Sprite........");
					guiControlInfo.darklingCreature07Button();
				}
				GameManager.burrySparkBool = false;
			}
			
			if (bridgeRabbitBool)
			{
				Debug.Log("---> 4 <---");
				bridgeRabbitBool = false;
				taskBuildBridge(3);
			}
		
			if (GameManager.quest == 0 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 5 <---");
				Destroy(guiControlInfo.qGO);
				
				GameObject hGC_Creature = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
				hGC_Creature.GetComponent<MeshRenderer>().enabled = true;
				hGC_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				//GameManager.questRunningBool = false;
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
				 				ad.percentComplete6 = 100;
			}
		
			if (GameManager.quest == 2 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 6 <---");
				Destroy(guiControlInfo.qGO);
				
				GameObject leech = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
				leech.GetComponent<MeshRenderer>().enabled = true;
				
				GameManager.questRunningBool = false;
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}
			
			if (GameManager.quest == 3 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 7 <---");
				Destroy(guiControlInfo.qGO);
				
				GameObject leech = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
				leech.GetComponent<MeshRenderer>().enabled = true;
				gameManagerInfo.dChar.SetActiveRecursively(true);
				
				GameManager.questRunningBool = false;
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 4 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 8 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 5 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 9 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
				 				ad.percentComplete19 = 100;
			}	
			if (GameManager.quest == 6 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 10 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 7 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 11 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 8 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 12 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 9 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 13 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 10 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 14 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
			}	
			if (GameManager.quest == 11 && GameManager.questRunningBool && GameManager.destroyQuestPbBool)
			{
				Debug.Log("---> 15 <---");
				Destroy(guiControlInfo.qGO);
				
				GameManager.destroyQuestPbBool = false;
				string questTaskid = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.QuestCreation.objTypeId);
				scr_sfsRemoteCnt.SendRequestForQuestAccelrateTask(questTaskid);
				 				ad.percentComplete42 = 100;
			}
		
			if (GameManager.quest == 2 && GameManager.questActivateBool && GameManager.questRunningBool == false)
			{
				Debug.Log("---> 16 <---");
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Turnip")
			{
				Debug.Log("---> 17 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Turnip");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "PipeWeed")
			{
				Debug.Log("---> 18 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "PipeWeed");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Pumpkin")
			{
				Debug.Log("---> 19 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Pumpkin");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Costmary")
			{
				Debug.Log("---> 20 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Costmary");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "FairyLily")
			{
				Debug.Log("---> 21 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "FairyLily");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Potato")
			{
				Debug.Log("---> 22 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Potatoes");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Watercress")
			{
				Debug.Log("---> 23 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Watercress");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Mandrake")
			{
				Debug.Log("---> 24 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Mandrake");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Vervain")
			{
				Debug.Log("---> 25 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "Vervain");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "SunFlower")
			{
				Debug.Log("---> 26 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskFarming(3, "SunFlower");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DPumpkin")
			{
				Debug.Log("---> 27 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "DPumpkin");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DFirePepper")
			{
				Debug.Log("---> 28 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "DFirePepper");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DColumbine")
			{
				Debug.Log("---> 29 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "DColumbine");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DBlackBerry")
			{
				Debug.Log("---> 30 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "DBlackBerry");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DAven")
			{
				Debug.Log("---> 31 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "DAven");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "BitterBrush")
			{
				Debug.Log("---> 32 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "BitterBrush");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "BogBean")
			{
				Debug.Log("---> 33 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "BogBean");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Wolfsbane")
			{
				Debug.Log("---> 34 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "Wolfsbane");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "MoonFlower")
			{
				Debug.Log("---> 35 <---");
				GameManager.currentPlant = guiControlInfo.currentRabbitButton;
				taskDarklingFarming(3, "MoonFlower");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Hound")
			{
				Debug.Log("---> 36 <---");
				taskCreature(3, "Hound");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Barg")
			{
				Debug.Log("---> 37 <---");
				taskCreature(3, "Barg");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Cusith")
			{
				taskCreature(3, "Cusith");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Sprout")
			{
				taskCreature(3, "Sprout");
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Nymph")
			{
				taskCreature(3, "Nymph");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Dryad")
			{
				taskCreature(3, "Dryad");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Nix")
			{
				taskCreature(3, "Nix");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Draug")
			{
				taskCreature(3, "Draug");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Dragon")
			{
				taskCreature(3, "Dragon");
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Leech")
			{
				taskCreature(3, "Leech");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Leshy")
			{
				taskCreature(3, "Leshy");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Lurker")
			{
				taskCreature(3, "Lurker");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DHound")
			{
				taskCreature(3, "DHound");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Fenrir")
			{
				taskCreature(3, "Fenrir");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "HellHound")
			{
				taskCreature(3, "HellHound");
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Sprite")
			{
				taskCreature(3, "Sprite");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Imp")
			{
				taskCreature(3, "Imp");
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Djinn")
			{
				taskCreature(3, "Djinn");
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && (guiControlInfo.currentRabbitButton.tag == "goblinCamp" || guiControlInfo.currentRabbitButton.tag == "TrollHouse"))
			{
				taskGoblinCave(5);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Inn" && GameManager.upgradeInnRabbit == false)
			{
				taskBuildInn(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Inn" && GameManager.upgradeInnRabbit == true)
			{
				taskUpgradeInn(2);
				GameManager.upgradeInnRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "HHouse" && GameManager.upgradeHHouseRabbit == true)
			{
				taskUpgradeHHouse(2);
				GameManager.upgradeHHouseRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DHouse" && GameManager.upgradeDHouseRabbit == true)
			{
				taskUpgradeDHouse(2);
				GameManager.upgradeDHouseRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}	
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Stable" && GameManager.upgradeStableRabbit == true)
			{
				taskUpgradeStable(2);
				GameManager.upgradeStableRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "BlackSmith" && GameManager.upgradeBlackSmithRabbit == true)
			{
				taskUpgradeBlackSmith(2);
				GameManager.upgradeBlackSmithRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}	
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DInn" && GameManager.upgradeDInnRabbit == true)
			{
				taskUpgradeDarklingInn(2);
				GameManager.upgradeDInnRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "EarthObelisk" && GameManager.upgradeEarthObeliskRabbit == true)
			{
				Debug.Log("task upgrade earth obelisk 2...");
				taskUpgradeEarthObelisk(2);
				GameManager.upgradeEarthObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "PlantObelisk" && GameManager.upgradePlantObeliskRabbit == true)
			{
				Debug.Log("task upgrade plant obelisk 2...");
				taskUpgradePlantObelisk (2);
				GameManager.upgradePlantObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "WaterObelisk" && GameManager.upgradeWaterObeliskRabbit == true)
			{
				Debug.Log("task upgrade water obelisk 2...");
				taskUpgradeWaterObelisk (2);
				GameManager.upgradeWaterObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "SwampObelisk" && GameManager.upgradeSwampObeliskRabbit == true)
			{
				Debug.Log("task upgrade swamp obelisk 2...");
				taskUpgradeSwampObelisk (2);
				GameManager.upgradeSwampObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DEarthObelisk" && GameManager.upgradeDEarthObeliskRabbit == true)
			{
				Debug.Log("task upgrade d earth obelisk 2...");
				taskUpgradeDEarthObelisk (2);
				GameManager.upgradeDEarthObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "FireObelisk" && GameManager.upgradeFireObeliskRabbit == true)
			{
				Debug.Log("task upgrade fire obelisk 2...");
				taskUpgradeFireObelisk (2);
				GameManager.upgradeFireObeliskRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DStable" && GameManager.upgradeDStableRabbit == true)
			{
				taskUpgradeDarklingStable(2);
				GameManager.upgradeDStableRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}	
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DBlackSmith" && GameManager.upgradeDBlackSmithRabbit == true)
			{
				taskUpgradeDarklingBlackSmith(2);
				GameManager.upgradeDBlackSmithRabbit = false;
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Stable" && GameManager.upgradeStableRabbit == false)
			{
				taskBuildStable(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "BlackSmith")
			{
				taskBuildBlackSmith(4);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Apothecary")
			{
				taskBuildApothecary(4);
				guiControlInfo.currentRabbitButton = null;
			}	
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "Tavern")
			{
				taskBuildTavern(4);
				guiControlInfo.currentRabbitButton = null;
			}	
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DBlackSmith")
			{
				taskDarklingBlackSmith(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "EarthObelisk")
			{
				taskBuildEarthObelisk(4);
				guiControlInfo.currentRabbitButton = null;
				
				if (GameManager.taskCount == 10)
				{
					obeliskTutorial(6);
				}
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "PlantObelisk")
			{
				taskBuildPlantObelisk(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "WaterObelisk")
			{
				taskBuildWaterObelisk(4);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "SunShrine")
			{
				taskBuildSunShrine(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DInn" && GameManager.upgradeDInnRabbit == false)
			{
				taskDarklingInn(4);
				guiControlInfo.currentRabbitButton = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DStable")
			{
				taskDarklingStable(4);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DTavern")
			{
				taskDarklingTavern(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DApothecary")
			{
				taskDarklingApothecary(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DEarthObelisk")
			{
				taskDarklingEarthObelisk(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DSwampObelisk")
			{
				taskDarklingSwampObelisk(4);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DFireObelisk")
			{
				taskDarklingFireObelisk(4);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "MoonShrine")
			{
				taskDarklingMoonShrine(4);
				guiControlInfo.currentRabbitButton = null;
			}	
			
			if (GameManager.curBuilding != null && GameManager.upgradeInn == true && GameManager.curBuilding.tag == "Inn")
			{
				//Debug.Log("taskUpgradeInn(1) is ready...");
				taskUpgradeInn(1);
				GameManager.curBuilding = null;
			}
				
			if (GameManager.curBuilding != null && GameManager.upgradeHHouse == true && GameManager.curBuilding.tag == "HHouse")
			{
				Debug.Log("taskUpgradeHouse(1) is ready...");
				taskUpgradeHHouse(1);
				GameManager.curBuilding = null;
			}	
		
			if (GameManager.curBuilding != null && GameManager.upgradeDHouse == true && GameManager.curBuilding.tag == "DHouse")
			{
				//Debug.Log("taskUpgrade D House(1) is ready...");
				taskUpgradeDHouse(1);
				GameManager.curBuilding = null;
			}		
				
			if (GameManager.curBuilding != null && GameManager.upgradeStable == true && GameManager.curBuilding.tag == "Stable")
			{
				//Debug.Log("taskUpgradeStable(1) is ready...");
				taskUpgradeStable(1);
				GameManager.curBuilding = null;
			}
				
			if (GameManager.curBuilding != null && GameManager.upgradeBlackSmith == true && GameManager.curBuilding.tag == "BlackSmith")
			{
				//Debug.Log("taskUpgradeBlackSmith(1) is ready...");
				taskUpgradeBlackSmith(1);
				GameManager.curBuilding = null;
			}	
			
			if (GameManager.curBuilding != null && GameManager.upgradeDInn == true && GameManager.curBuilding.tag == "DInn")
			{
				//Debug.Log("taskUpgradeDarklingInn(1) is ready...");
				taskUpgradeDarklingInn(1);
				GameManager.curBuilding = null;
			}
				
			if (GameManager.curBuilding != null && GameManager.upgradeDStable == true && GameManager.curBuilding.tag == "DStable")
			{
				//Debug.Log("taskUpgradeDarklingStable(1) is ready...");
				taskUpgradeDarklingStable(1);
				GameManager.curBuilding = null;
			}	
			
			if (GameManager.curBuilding != null && GameManager.upgradeDBlackSmith == true && GameManager.curBuilding.tag == "DBlackSmith")
			{
				//Debug.Log("taskUpgradeDarkling BlackSmith(1) is ready...");
				taskUpgradeDarklingBlackSmith(1);
				GameManager.curBuilding = null;
			}	
				
			if (GameManager.curBuilding != null && GameManager.upgradeEarthObelisk == true && GameManager.curBuilding.tag == "EarthObelisk")
			{
				GameManager.upgradeEarthObelisk = false;
				Debug.Log("earth obelisk upgrade 1...");
				taskUpgradeEarthObelisk(1);
				//GameManager.curBuilding == null;	
			}
			
			if (GameManager.curBuilding != null && GameManager.upgradePlantObelisk == true && GameManager.curBuilding.tag == "PlantObelisk")
			{
				GameManager.upgradePlantObelisk = false;
				Debug.Log("plant obelisk upgrade 1...");
				taskUpgradePlantObelisk(1);
			}
			
			if (GameManager.curBuilding != null && GameManager.upgradeWaterObelisk == true && GameManager.curBuilding.tag == "PlantObelisk")
			{
				GameManager.upgradeWaterObelisk = false;
				Debug.Log("water obelisk upgrade 1...");
				taskUpgradeWaterObelisk (1);
			}
			
			if (GameManager.curBuilding != null && GameManager.upgradeSwampObelisk == true && GameManager.curBuilding.tag == "PlantObelisk")
			{
				GameManager.upgradeSwampObelisk = false;
				Debug.Log("swamp obelisk upgrade 1...");
				taskUpgradeSwampObelisk (1);
			}
			
			if (GameManager.curBuilding != null && GameManager.upgradeDEarthObelisk == true && GameManager.curBuilding.tag == "PlantObelisk")
			{
				GameManager.upgradeDEarthObelisk = false;
				Debug.Log("d earth obelisk upgrade 1...");
				taskUpgradeDEarthObelisk (1);
			}
			
			if (GameManager.curBuilding != null && GameManager.upgradeFireObelisk == true && GameManager.curBuilding.tag == "PlantObelisk")
			{
				GameManager.upgradeFireObelisk = false;
				Debug.Log("fire obelisk upgrade 1...");
				taskUpgradeFireObelisk (1);
			}
			
			if (GameManager.curTG != null && GameManager.upgradeTrainingGroundBool == true && (GameManager.curTG.tag == "TrainingGround" || GameManager.curTG.tag == "PlantTG" || GameManager.curTG.tag == "WaterTG" ||
												GameManager.curTG.tag == "Swamp" || GameManager.curTG.tag == "DFireTG" || GameManager.curTG.tag == "DEarthTG"))
			{
				taskUpgradeTrainingGround(1);
				GameManager.curTG = null;
				//Debug.Log("dussed " + GameManager.earthTG_lvl);
			}
				
			if (GameManager.curPlot != null && GameManager.upgradePlotBool == true && (GameManager.curPlot.tag == "Plot" || GameManager.curPlot.tag == "DPlot"))
			{
				Debug.Log("taskUpgradePlot(1)...");
				GameManager.upgradePlotBool = false;
				taskUpgradePlot(1);
				GameManager.curPlot = null;
			}
		
			if (guiControlInfo.currentRabbitButton != null && (guiControlInfo.currentRabbitButton.tag == "TrainingGround" || guiControlInfo.currentRabbitButton.tag == "PlantTG" || guiControlInfo.currentRabbitButton.tag == "WaterTG" ||
																guiControlInfo.currentRabbitButton.tag == "Swamp" || guiControlInfo.currentRabbitButton.tag == "DFireTG" || guiControlInfo.currentRabbitButton.tag == "DEarthTG"))
			{
				//Debug.Log("dussed------> " + GameManager.earthTG_lvl);
				GameManager.upgradeTrainingGroundBool = true;
				taskUpgradeTrainingGround(2);
				guiControlInfo.currentRabbitButton = null;
			}
			
			if (guiControlInfo.currentRabbitButton != null && GameManager.upgradePlotRabbitBool && (guiControlInfo.currentRabbitButton.tag == "Plot" || guiControlInfo.currentRabbitButton.tag == "DPlot"))
			{
				GameManager.upgradePlotRabbitBool = false;
				taskUpgradePlot(2);
				guiControlInfo.currentRabbitButton = null;
			}
				
			if (guiControlInfo.currentRabbitButton != null && guiControlInfo.currentRabbitButton.tag == "DPumpkin")
			{
				taskFarming(3, "DPumpkin");
				guiControlInfo.currentRabbitButton = null;
			}
		}
	}
		
			
	
//=======================================================================================================================================
	
	public void storyTutorial(int currentStep)
	{
		if (currentStep == 1)
		{
			GameObject arrowDelObj = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if (arrowDelObj != null)
			{
				arrowDelObj.transform.position = new Vector3(-20, 13, 119);
				arrowDelObj.transform.eulerAngles = new Vector3(90, 0, 0);
			}
		}
		
		if (currentStep == 2)
		{
			GameObject arrowDelObj = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if (arrowDelObj != null)
			{
				arrowDelObj.transform.position = new Vector3(-33, 13, 109);
				arrowDelObj.transform.eulerAngles = new Vector3(270, 270, 0);
			}
		}
	}
	
//=======================================================================================================================================	
	
	// task 1 place Earth Training Ground
	public void task1()
	{
		GameObject delCol = GameObject.Find("pathCol") as GameObject;
		Destroy(delCol);
		
		Sensors.sensorWorkBool = false;
				
		grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
		
		grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
		grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
		Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
								
		redPatch.gameObject.active = false; // hide red patch current game object
		greenPatch.gameObject.active = false; // hide green patch current game object
				
		// change current game object and collider tag name
		grid.curCol.tag = "editableObj";
		
		guiControlInfo.creaturePos = grid.curObj.transform.position;
		
		grid.curObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = true;
		GameManager.curTG = grid.curObj;
		// hide current object UI
		Transform tempUI = grid.curObj.transform.FindChild("UI");
		
		GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
		placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
		
		GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
		cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
		tempUI.gameObject.SetActiveRecursively(false);
		
		// destroy current sensor script
		Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
		//Destroy(sensorInof);
		Sensors.sensorWorkBool = false;
		sensorInof.enabled = false;

		//indra get xp value from server
//		Debug.Log("my xp : " + (int)scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTrainingGrnd.objTypeId));
//		GameObject xpValObj = Instantiate(Resources.Load("xpValue"), grid.curObj.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
		
	    scr_sfsRemoteCnt.ForSendingRequest();
		//task1 sent to server by harish 
		
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objTrainingGrnd.objname,"2");		
		SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
		SendRot = new Vector3(0,180,0);
		
		//StartCoroutine(addTrainingGrndafterResponse(grid.curObj.transform.position.ToString(),new Vector3(0,180,0).ToString()));
			                                          
								
		grid.curObj = null;
		
		// hide object panel menu
		GameObject obj1 = GameObject.Find("ObjectPlacePanel") as GameObject;
		Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ " + obj1);
		objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		Debug.Log("********************************** " + objPanelInfo);
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;	
		
		UpdateScore();
		
		TrainingGroundCreature();
		
		GameManager.popUpCount = 3;
		curPopUpCnt = 3;
		curPopUpType = 0;
		generatePopUp(curPopUpCnt, curPopUpType);
	}
	
	public bool isTask2;
	public Vector3 SendRot;
	public string SendPosDec,SendPos;
	public int SendParentObjid;
//=======================================================================================================================================

  
	private bool houndRabbitInfoBool = false;
	// task 2 function Place Hound Creature
	public void task2()
	{
		Vector3 houndPos = GameObject.Find("HC_TG_TrainingGround_GO(Clone)").transform.position;
		GameObject go1 = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
		
		go1.AddComponent<SparkAnimation>();
		go1.transform.FindChild("Spark1").gameObject.GetComponent<MeshRenderer>().enabled = true;
		go1.transform.FindChild("Spark1").gameObject.GetComponent<Sprite>().PlayAnim("Effect");
		
		GameObject go = Instantiate(gameManagerInfo.c_Hound_PF, new Vector3(houndPos.x, houndPos.y + 0.2f, houndPos.z), Quaternion.Euler(270, 180, 0)) as GameObject;
		
		go.GetComponent<MeshRenderer>().enabled = false;
		(go.GetComponent("progressBar") as progressBar).enabled = true;
		
		go.transform.parent = go1.transform;
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		go.transform.FindChild("RabbtiButton").gameObject.GetComponent<buttonPulse>().scaleAnim = true;
			
		// attach guiControl script to rabbit ui button
		Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform; //rabbitButton_BP.gameObject.transform.FindChild("Rabbit") as Transform;
			
		UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		delObjUIButtonInfo.methodToInvoke = "rabbitButton";
				
		panelControl.panelAnimBool = false;
		
		guiControl.executeTaskBool = false;
		
		
		//task2 sent to server
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemoteCnt.SendRequestForBuyItems("2","creatureType",scr_GameObjSvr.objHound.objname,"2");
		SendParentObjid = scr_GameObjSvr.objTrainingGrnd.objTypeId;
		TempTypeId = scr_GameObjSvr.objHound.objTypeId;
		SendPos = GetabsolutePos(houndPos.x,houndPos.y,houndPos.z);
		SendRot = new Vector3(0,180,0);
		isTaskCreature = true;
		
		GameManager.earthTG_Creature_Cnt = 1;
		 		ad.percentComplete1 = 100;
		
		houndRabbitInfoBool = true;
		curPopUpCnt = 3;
		wall.active = true;
		defaultPopUpBool = true;
		defaultPopUp(61, 0);
		
//		objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
//		objPanelInfo.panelMoveIn = true;
//		objPanelInfo.panelMoveOut = false;
		
		//gameManagerInfo.bubbleObj.SetActiveRecursively(true);
		//gameManagerInfo.speakTextObj.active = true;
		//GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("If you'd like to speed it up, simply add more sparks.  You can do this by clicking on the rabbit speed icon.");
		
		scr_audioController.audio_sparkEarth.Play();
		scr_audioController.audio_sparkEarth.minDistance = 1;
		scr_audioController.audio_sparkEarth.maxDistance = 300;
		scr_audioController.audio_sparkEarth.volume = 0.8f;
		
		PlaySparkBirthsound(go1.transform.position);

		GameCenterBinding.reportAchievement("product.hwwar.achive01", 100);
	}
	
//=======================================================================================================================================
	
	// task 3 Place Dirt Path
	public void task3()
	{
		GameManager.placeObjectBool = false;
		Sensors.sensorWorkBool = false;
				
		grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ 0.02912191f, grid.curObj.transform.position.z);
		
		grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
		grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
		Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
								
		redPatch.gameObject.active = false; // hide red patch current game object
		greenPatch.gameObject.active = false; // hide green patch current game object
				
		// change current game object and collider tag name
		grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		grid.curObj.tag = "notDelete";
		//grid.curCol.tag = "editableObj";
		
		guiControlInfo.creaturePos = grid.curObj.transform.position;
		
		guiControlInfo.halfwayone.gameObject.active = true;
		guiControlInfo.halfwayone = null;
		
		// hide current object UI
		Transform tempUI = grid.curObj.transform.FindChild("UI");
		
		GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
		placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
		
		GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
		cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
		
		tempUI.gameObject.SetActiveRecursively(false);
		
		
			//task 3 send to server 
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemoteCnt.SendRequestForBuyItems("6","decorationType",scr_GameObjSvr.objDirtPath.objname,"2");
		//SendPos = grid.curObj.transform.position;
		SendPosDec = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
		SendRot = new Vector3(grid.curObj.transform.rotation.x,grid.curObj.transform.rotation.y,grid.curObj.transform.rotation.z);
		
		// destroy current sensor script
		Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
		sensorInof.enabled = false;
		Sensors.sensorWorkBool = false;
		
		grid.curObj.gameObject.GetComponent<getXP>().xpAnimBool = true;
		grid.curObj.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
		
		// update score
		UpdateScore();
		
		grid.curObj = null;
		//GameManager.xp =  GameManager.xp + 1;
		 		ad.percentComplete3 = 100;
		
		//scr_CharMove.status = "Front";
	}
	
//=======================================================================================================================================
	private string taskidSvr;
	// task 4 destroy goblin camp tutorial
	private int nextSteps = 0;
	public bool isTask4,isGotCreatureid,isGotCaveids;
	public string caveTobeCleared;
	
	public void task4(int currentStep)
	{
		if (currentStep == 1)
		{
			GameObject.Find("Main Camera").transform.position = GameObject.Find("goblinCamp_cPos").transform.position;
			GameObject gCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
				
			// create arrow on goblin house
			GameObject gArrow = Instantiate(guiControlInfo.gameArrow, new Vector3(gCamp.transform.position.x, gCamp.transform.position.y, gCamp.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
			GameManager.readyAttact = true;
			nextSteps++;
		}
		
		if (currentStep == 2)
		{
			GameObject arrow = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if (arrow != null)
				Destroy(arrow);
			
			GameObject curCreatureSel = GameObject.Find("HC_C_Hound_GO(Clone)");
			guiControlInfo.curAttackingCreature = curCreatureSel;
			//curCreatureSel.SetActiveRecursively(false);
			curCreatureSel.transform.FindChild("shadow").gameObject.active = false;
			curCreatureSel.GetComponent<MeshRenderer>().enabled = false;
			wall.active = false;
			guiControlInfo.creatureUI.SetActiveRecursively(false);
			GameObject gCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			CreatureAttackAnimation(curCreatureSel, gCamp);

			// activate Goblin Camp Progress Bar
			GameObject curGoblicHouse = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01");
			GameObject rabbitButton = curGoblicHouse.transform.FindChild("RabbtiButton").gameObject;
			rabbitButton.SetActiveRecursively(false);
			Transform curProgressBar = curGoblicHouse.transform.FindChild("ProgressBar");
			curProgressBar.gameObject.SetActiveRecursively(true);
			progressBar ghPB = curGoblicHouse.GetComponent("progressBar") as progressBar;
			ghPB.enabled = true;
			
			//clear cave sent to server
			StartCoroutine("GetWorld");
			isTask4 = true;
			//caveTobeCleared = new Vector3(-43,0.01f,3);
			caveTobeCleared  = GetabsolutePos(curGoblicHouse.transform.position.x,0.03f,curGoblicHouse.transform.position.z);
			//caveTobeCleared = new Vector3(-119,0.03f,0.5f).ToString();
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			CaveCreature = scr_GameObjSvr.objHound.objTypeId;
			TempTypeId = scr_GameObjSvr.objGoblinCamp01.objTypeId;
		
			Destroy(guiControlInfo.delArrow);
			
			// activate rabbit button pulse effect
			//buttonPulse rabbitButton_BP = rabbitButton.GetComponent("buttonPulse") as buttonPulse;
			//rabbitButton_BP.scaleAnim = true;

			buttonPulse rabbitButtBP = rabbitButton.AddComponent("buttonPulse") as buttonPulse;
			rabbitButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
			rabbitButtBP.minSpeed = 3;
			rabbitButtBP.maxSpeed = 8;
			rabbitButtBP.minVal = 0.02f;
			rabbitButtBP.maxVal = 0.09f;
			rabbitButtBP.scaleAnim = true;

			// attach guiControl script to rabbit ui button
			Transform rabbit = rabbitButton.transform.FindChild("Rabbit") as Transform;
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			delObjUIButtonInfo.methodToInvoke = "rabbitButton";
			
			GameManager.taskCount = 12;
			updateTaskCount();
		}
		
		if (currentStep == 3)
		{
			UpdateScore();
			guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
			
			Destroy(GameObject.Find("RabbtiButton(Clone)"));
			
			if (guiControlInfo.curAttackingCreature != null)
				guiControlInfo.curAttackingCreature.SetActiveRecursively(true);
			
			GameManager.popUpCount = 9;
			updatePopUpCount();
			
			curPopUpCnt = 9;
			updateCurPopUpCount();
			
			curPopUpType = 0;
			generatePopUp(curPopUpCnt, curPopUpType);
		}
		
		if (currentStep == 4)
		{
			GameObject goblinCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			Destroy(goblinCamp);
			GameObject arrow = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if (arrow != null)
				Destroy(arrow);
				
			GameObject go = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
			go.GetComponent<MeshRenderer>().enabled = true;
			guiControlInfo.curAttackingCreature = null;
				
			Destroy(GameObject.Find("RabbtiButton(Clone)"));
			
			GameObject attackHoundObj = GameObject.Find("HoundAttack(Clone)") as GameObject;
			if (attackHoundObj != null)
				Destroy(GameObject.Find("HoundAttack(Clone)").gameObject);
			go.GetComponent<MeshRenderer>().enabled = true;
			go.transform.FindChild("shadow").gameObject.active = true;
			
			
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objGoblinCamp01.objTypeId);
			scr_sfsRemoteCnt.AccelerateCaveClearTask(taskidSvr);
			
			// update SCORE
			UpdateScore();
			guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
			guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
				
//			GameManager.popUpCount = 20;
//			updatePopUpCount();
//			
//			curPopUpCnt = 20;
//			curPopUpType = 0;
			
			GameManager.taskCount = 13;
			updateTaskCount();
			
			//generatePopUp(curPopUpCnt, curPopUpType);
			
			task13Bubble();
			
			 			ad.percentComplete4 = 100;
			EnemyCaveBuildings();
		}
	}
	
//=======================================================================================================================================
	
	// task 5 place Garden on land
	public void task5(int currentStep)
	{
		if (currentStep == 1)
		{
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
				
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
			GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			guiControlInfo.delArrow = temp;
		}
		
		if (currentStep == 2)
		{
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;
			
			grid.curCol = null;
			grid.curObj = null;
			
			GameObject go = Instantiate(guiControlInfo.farmPlot, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.farmPlot.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			upgradeProgressBar plotUPBInfo = go.GetComponent<upgradeProgressBar>();
			
			go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform rabbitBP = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton rabbitButtInfo = rabbitBP.gameObject.GetComponent("UIButton") as UIButton;
			rabbitButtInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			grid.placeButtonBool = true;
			grid.curObj = go;
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		}
		
		if (currentStep == 3)
		{
			GameManager.placeObjectBool = false;
			Sensors.sensorWorkBool = false;
				
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
		
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
								
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
		
			//indra get xp value from server
//			Debug.Log("my xp : " + (int)scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objGarden.objTypeId));
//			GameObject xpValObj = Instantiate(Resources.Load("xpValue"), grid.curObj.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
			
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
		
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
								
				//task 5 sent to server  
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType", scr_GameObjSvr.objGarden.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			
								
			grid.curObj = null;
			
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;
			
			GameManager.placeHPlotCnt++;
		}
	}
	
//=======================================================================================================================================
	public bool isTaskFarming;
	
	// task 6 farm Turnip Plant
	public void task6(int currentStep)
	{
		if (currentStep == 1)
		{
			GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			GameObject pCol = plotGO.transform.FindChild("Isometric_Collider").gameObject;
			
			if (pCol.tag == "editableObj")
			{
				GameObject gArrow = Instantiate(guiControlInfo.gameArrow, new Vector3(plotGO.transform.position.x, plotGO.transform.position.y, plotGO.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
				guiControlInfo.delArrow = gArrow;
				GameManager.readyFarm = true;
			}
		}
		
		if (currentStep == 2)
		{
			wall.active = true;
			guiControlInfo.inventoryUI.SetActiveRecursively(true);
			Destroy(guiControlInfo.delArrow);

			buttonPulse inventoryPlantBP = GameObject.Find("inventoryPlantButt").AddComponent("buttonPulse") as buttonPulse;
			inventoryPlantBP.gameObject.transform.localScale = new Vector3(0.1f, 0.14f, 1);			
			inventoryPlantBP.minSpeed = 3;
			inventoryPlantBP.maxSpeed = 8;
			inventoryPlantBP.minVal = 0.001f;
			inventoryPlantBP.maxVal = 0.01f;
			inventoryPlantBP.scaleAnim = true;
		
			GameObject iPlantSpwan = GameObject.Find("iPlantSpwan");
			GameObject inventoryPlantArrow = Instantiate(guiControlInfo.arrow, new Vector3(iPlantSpwan.transform.position.x, iPlantSpwan.transform.position.y, iPlantSpwan.transform.position.z + 12), Quaternion.Euler(90, 180, 0)) as GameObject;
			guiControlInfo.delArrow = inventoryPlantArrow;
		}
		
		if (currentStep == 3)
		{
			if (guiControlInfo.delArrow != null)
				Destroy(guiControlInfo.delArrow);
			
			wall.active = true;
			guiControlInfo.plantsUI.SetActiveRecursively(true);
			
			// creature button arrow and button effect
			GameObject creatureButtSpwan = GameObject.Find("plant01_Spwan") as GameObject;
			GameObject creatureArrow = Instantiate(guiControlInfo.arrow, creatureButtSpwan.transform.position, Quaternion.Inverse(creatureButtSpwan.transform.rotation)) as GameObject;
			guiControlInfo.delArrow = creatureArrow;
			creatureArrow.transform.parent = creatureButtSpwan.transform;
			
			wall.active = false;
			guiControlInfo.inventoryUI.SetActiveRecursively(false);
		}
		
		// inventory cancle
		if (currentStep == 4)
		{
			if (guiControlInfo.delArrow != null)
				Destroy(guiControlInfo.delArrow);
				
			wall.active = false;
			guiControlInfo.inventoryUI.SetActiveRecursively(false);
			
			GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			plotGO.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			GameObject gArrow = Instantiate(guiControlInfo.gameArrow, new Vector3(plotGO.transform.position.x, plotGO.transform.position.y, plotGO.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
			guiControlInfo.delArrow = gArrow;
			GameManager.readyFarm = true;	
		}
		
		// start growing turnip plant
		if (currentStep == 5)
		{
			GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			GameObject go = Instantiate(guiControlInfo.turnipPlantGO, new Vector3(GameManager.selObjectPos.x, GameManager.selObjectPos.y+0.05f, GameManager.selObjectPos.z), Quaternion.Euler(0, 180, 0)) as GameObject;
			
			
			
			plotGO.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			go.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			go.transform.parent = plotGO.transform;
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(false);
			
			progressBar turnipPB = go.GetComponent("progressBar") as progressBar;
			turnipPB.enabled = true;
			
			
				//task 6 sent to server
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("5","plantType",scr_GameObjSvr.objTurnips.objname,"2");			
			//SendPos = GameManager.selObjectPos;
			SendPos = GetabsolutePos(GameManager.selObjectPos.x,GameManager.selObjectPos.y,GameManager.selObjectPos.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objTurnips.objTypeId;
			isTaskFarming = true;
			plotname = plotGO.name;
			SendGo = go;

			// activate rabbit button pulse effect
//			buttonPulse rabbitButton_BP = go.transform.FindChild("RabbtiButton").gameObject.GetComponent("buttonPulse") as buttonPulse;
//			rabbitButton_BP.scaleAnim = true;

			buttonPulse rabbitButtBP = go.transform.FindChild("RabbtiButton").gameObject.AddComponent("buttonPulse") as buttonPulse;
			rabbitButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
			rabbitButtBP.minSpeed = 3;
			rabbitButtBP.maxSpeed = 8;
			rabbitButtBP.minVal = 0.02f;
			rabbitButtBP.maxVal = 0.09f;
			rabbitButtBP.scaleAnim = true;
		
			// attach guiControl script to rabbit ui button
			Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			delObjUIButtonInfo.methodToInvoke = "rabbitButton";
			
			if (guiControlInfo.delArrow != null)
				Destroy(guiControlInfo.delArrow);
			
			gameManagerInfo.bubbleObj.SetActiveRecursively(true);
			gameManagerInfo.speakTextObj.active = true;
			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("And remember to speed things along with extra sparks... Time, I'm afraid, is not our ally");
			
			scr_audioController.audio_plantCrop.transform.position = go.transform.position;
			scr_audioController.audio_plantCrop.Play();
			scr_audioController.audio_plantCrop.volume = 0.7f;
			scr_audioController.audio_plantCrop.minDistance = 1;
			scr_audioController.audio_plantCrop.maxDistance = 20;
		}
		
		// turnip plant grow complete
		if (currentStep == 6)
		{
			GameObject tunipObj = null;
			if(scr_loadUserWorld.GetTurnips1() != null)
			{
			   tunipObj =  GameObject.Find(scr_loadUserWorld.GetTurnips1()) as GameObject;
			}
			else if(scr_sfsRemoteCnt.GetPlantName() != null)
			{
			   tunipObj = GameObject.Find(scr_sfsRemoteCnt.GetPlantName()) as GameObject;
			}
			
			GameObject turnipPB = tunipObj.transform.FindChild("ProgressBar").gameObject;
			progressBar pb = tunipObj.GetComponent<progressBar>();
			Destroy(pb);
			Destroy(turnipPB);
					
			tunipObj.renderer.material.mainTexture = upgradeTextureInfo.h_Turnip01;
			Destroy(tunipObj.transform.FindChild("RabbtiButton").gameObject);
			
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		     taskidSvr = scr_loadUserWorld.ReturnTaskIdforIds(GetIdFromString(tunipObj.name));
			scr_sfsRemoteCnt.AcceleratePlantPlantsTask(taskidSvr);
			
			UpdateScore();
			// update spark score
			guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
			
			if (guiControlInfo.delArrow != null)
				Destroy(guiControlInfo.delArrow);
		}
	}
	
//=======================================================================================================================================
	
	// goblin camp remove bubble
	public void task13Bubble()
	{
		gameManagerInfo.bubbleObj.SetActiveRecursively(true);
		gameManagerInfo.speakTextObj.active = true;
		GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Well done Halfling, that creature of yours is fierce. Keep an eye out for more unwelcomed visitors less they attack you while your sleeping");	
	}
	
//=======================================================================================================================================	
	
	public void obeliskTutorial(int currentStep)
	{
		if (currentStep == 1)
		{
			Debug.Log("open market panel for obelisk");
			
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
				
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
			GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			guiControlInfo.delArrow = temp;
		}
		
		if (currentStep == 2)
		{
			Debug.Log("Instantiate earth obelisk");
			taskBuildEarthObelisk(1);
			
		}
		
		if (currentStep == 6)
		{
			Debug.Log ("show pop up...");
			GameObject goblinCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			Transform cavCreature01 = goblinCamp.transform.FindChild("GoblinChar01") as Transform;
			Transform cavCreature02 = goblinCamp.transform.FindChild("GoblinChar02") as Transform;
			
			cavCreature01.transform.position = goblinCamp.transform.FindChild("GoblinChar01_loc").gameObject.transform.position;
			cavCreature02.transform.position = goblinCamp.transform.FindChild("GoblinChar02_loc").gameObject.transform.position;
					
			cavCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			cavCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			cavCreature01.GetComponent<MeshRenderer>().enabled = true;
			cavCreature02.GetComponent<MeshRenderer>().enabled = true;
			
			GameObject gPlot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			GameObject eTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			
			gPlot.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			Destroy(gPlot.GetComponent<HealthProgressBarTutorial>());
			eTG.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			Destroy(eTG.GetComponent<HealthProgressBarTutorial>());

			// destroy particle
			GameObject[] parEff = GameObject.FindGameObjectsWithTag("orcDestructEff");
			
			foreach(GameObject p in parEff)
			{
				if (p != null)
					Destroy(p);
			}
			
			GameManager.taskCount = 11;
			updateTaskCount();
			
			GameManager.popUpCount = 18;
			curPopUpCnt = 18;
			curPopUpType = 0;
			updatePopUpCount();
			updateCurPopUpCount();	
			generatePopUp(curPopUpCnt, curPopUpType);


		}
	}
	
//=======================================================================================================================================
	
	public void feedTutorial(int currentStep)
	{
		if (currentStep == 1)
		{
			Debug.Log("---> Show arrow on food icon on hud bar");
			
			buttonPulse foodBP =  GameObject.Find("foodHUD").gameObject.AddComponent("buttonPulse") as buttonPulse;
			foodBP.gameObject.transform.localScale = new Vector3(1, 1, 1);
			foodBP.minSpeed = 3;
			foodBP.maxSpeed = 8;
			foodBP.minVal = 0.05f;
			foodBP.maxVal = 0.35f;
			foodBP.scaleAnim = true;
			
			GameObject foodIconSpwan = GameObject.Find("foodIcon_spwan");
			GameObject foodIconArrow = Instantiate(guiControlInfo.arrow, new Vector3(foodIconSpwan.transform.position.x, foodIconSpwan.transform.position.y, foodIconSpwan.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			guiControlInfo.delArrow = foodIconArrow;
			
			GameObject foodIconColObj = Instantiate(gameManagerInfo.foodIconCol_pf, new Vector3(-38, 9.23f, 128), Quaternion.identity) as GameObject;

			gameManagerInfo.bubbleObj.SetActiveRecursively(true);
			gameManagerInfo.speakTextObj.active = true;
			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("This is where all your available food gets collected after harvesting.");
		}
		
		if (currentStep == 2)
		{
			Debug.Log("---> show arrow on training ground");
			GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			GameObject tgArrow = Instantiate(guiControlInfo.gameArrow, new Vector3(tgObj.transform.position.x, tgObj.transform.position.y, tgObj.transform.position.z+8f), Quaternion.Euler(270, 0, 0)) as GameObject;
			guiControlInfo.delArrow = tgArrow;
		}
		
		if (currentStep == 3)
		{
			Debug.Log("---> show arrow on chreature button");
			
			GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			objectSelection.curSelectedObj = tgObj;
			tgObj.transform.FindChild("selectionPatch").gameObject.active = true;
			tgObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = true;
			Destroy(guiControlInfo.delArrow);
			
			scr_ObjectSelection.TrainingGroundCreature();
			objectSelection.selectionPatchEnableBool = true;
			
			gameManagerInfo.houndName = "Hound";
			
			objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = false;
			objPanelInfo.panelMoveOut = true;
			
			GameObject creatureButt01Obj = GameObject.Find("objCreature01") as GameObject;
			GameObject creatureButtArrow = Instantiate(guiControlInfo.arrow, new Vector3(creatureButt01Obj.transform.position.x - 22f, 
														creatureButt01Obj.transform.position.y, creatureButt01Obj.transform.position.z), 
														Quaternion.Euler(270, 270, 0)) as GameObject;
			
			
		}
		
		if (currentStep == 4)
		{
			Debug.Log("---> show arrow on feed button");
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
				Destroy(arrowDel);
			
			guiControlInfo.FeedMorphPopUp.transform.FindChild("MorphButt").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
			GameManager.editCreatureNameTutBool = true;
			GameManager.FeedMorphPopupCancleBool = false;
			
		}
		
		if (currentStep == 5)
		{
			Debug.Log("---> show arrow on Ok button " + GameManager.hound_lvl);
			guiControlInfo.FeedMorphPopUp.transform.FindChild("FeedButt").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
			GameObject arrowDel = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
			{
				arrowDel.transform.position = new Vector3(-20.5f, 13, 92);
			}
			
			GameManager.editCreatureNameTutBool = false;
			objectSelection.selectionPatchEnableBool = false;
			GameManager.FeedMorphPopupCancleBool = true;
		}
		
		if (currentStep == 6)
		{
			Debug.Log("---> task 6 is complete");
			curPopUpCnt = 12;
			curPopUpType = 0;
			//generatePopUp(curPopUpCnt, curPopUpType);
			GameManager.taskCount = 7;
			updateTaskCount();
			
			gameManagerInfo.bubbleObj.SetActiveRecursively(true);
			gameManagerInfo.speakTextObj.active = true;
			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Nice job you fed your creature well.");	
	
			
			//GameObject gStory = GameObject.Find("FightingTutorial");
			//gStory.GetComponent<AutoSpeak>().callToWriteText("Nice job you fed your creature well.");
		
		}
	}
	
//=======================================================================================================================================	
	
	public void placeDirtPathTutorial(int currentStep)
	{
		if (currentStep == 1)
		{
			Debug.Log("Arrow on main menu panel...");
			
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
				
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
			GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			guiControlInfo.delArrow = temp;
		}
		
		if (currentStep == 2)
		{
			Debug.Log("Arrow on Halfling button...");
		}
		
		if (currentStep == 3)
		{
			Debug.Log("Arrow on decoration button in market...");
		}
		
		if (currentStep == 4)
		{
			Debug.Log("Arrow on dirtpath button in market...");
		}
		
		if (currentStep == 5)
		{
			Debug.Log("place first dirtpath...");
			
			GameManager.placeObjectBool = false;
			Sensors.sensorWorkBool = false;
					
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ 0.02912191f, grid.curObj.transform.position.z);
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
								
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
					
			// change current game object and collider tag name
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			//grid.curObj.tag = "notDelete";
			//grid.curCol.tag = "editableObj";
		
			guiControlInfo.creaturePos = grid.curObj.transform.position;
			
			guiControlInfo.halfwayone.gameObject.active = true;
			guiControlInfo.halfwayone = null;
			
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";

			GameObject charObj = GameObject.Find("Characters") as GameObject;
			if (charObj != null)
			{
				Transform animObj = charObj.transform.FindChild("h_Animation") as Transform;
				if (animObj != null)
				{
					if (animObj.FindChild("HWCharacterFrontWalk").gameObject.renderer.enabled == false)
					{
						animObj.FindChild("HWCharacterFrontidle").gameObject.renderer.enabled = false;
						animObj.FindChild("HWCharacterFrontWalk").gameObject.renderer.enabled = true;
					}
				}
			}
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
		
			//indra get xp from server
//			Debug.Log("my xp : " + (int)scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDirtPath.objTypeId));
//			GameObject xpValObj = Instantiate(Resources.Load("xpValue"), grid.curObj.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
			
		
				//task 3 send to server 
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("6","decorationType",scr_GameObjSvr.objDirtPath.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPosDec = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(grid.curObj.transform.rotation.x,grid.curObj.transform.rotation.y,grid.curObj.transform.rotation.z);
			
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;

			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDirtPath.objTypeId, grid.curObj);

			//grid.curObj.gameObject.GetComponent<getXP>().xpAnimBool = true;
			//grid.curObj.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			// update score
			UpdateScore();
			
			grid.curObj = null;
			//GameManager.xp =  GameManager.xp + 1;
			 			ad.percentComplete3 = 100;
			
			//placeDirtPathTutorial(6);
		}
		
		if (currentStep == 6)
		{
			Debug.Log("place second dirtpath...");
			
			GameObject[] dirtPathList = GameObject.FindGameObjectsWithTag("Decoration");
			
			Debug.Log("size -> " + dirtPathList.Length);
			
			if (dirtPathList.Length < 5)
			{
//				GameObject go = Instantiate(guiControlInfo.dirtPath, new Vector3(GameManager.firstDirtPathPos.x +(1.46f * (dirtPathList.Length)),
//																					GameManager.firstDirtPathPos.y, 
//																					GameManager.firstDirtPathPos.z -(0.73f * (dirtPathList.Length))),
//																					guiControlInfo.dirtPath.transform.rotation) as GameObject;
//				
				GameObject go = Instantiate(guiControlInfo.dirtPath, new Vector3(-64.24f +(1.46f * (dirtPathList.Length)),
																					GameManager.firstDirtPathPos.y, 
																					1.46f -(0.73f * (dirtPathList.Length))),
																					guiControlInfo.dirtPath.transform.rotation) as GameObject;
				
				guiControlInfo.curObj = go;
				GameManager.lastDirtPathPosition = go.transform.position;
				
				GameObject dirt = GameObject.Find("HWCharacter(Clone)");
				
				guiControlInfo.halfwayone = guiControlInfo.curObj.transform.FindChild("waypoint1") ;
				if (guiControlInfo.halfwayone != null)
					guiControlInfo.halfwayone.gameObject.active = false;
				
				Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
				Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
				Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
				Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
				Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
			
				go.transform.FindChild("redPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
				
				UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
	//			guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
				delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
				UIButton flipButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
				flipButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
				UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
				placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
				tempObjFlip.gameObject.active = false;
				
				tempObjDelete.gameObject.active = false;
				
				grid.placeButtonBool = true;
				grid.curObj = go;
				hCharMove.findWaypointBool = true;
			}
			else
			{
				Debug.Log("dirt path task complete...");
				
//				curPopUpCnt = 14;
//				curPopUpType = 0;
				GameManager.taskCount = 9;
				updateTaskCount();
//				generatePopUp(curPopUpCnt, curPopUpType);
				hCharMove.findWaypointBool = true;
				GameObject desCol = GameObject.Find("pathCol") as GameObject;
				if (desCol != null)
					Destroy(desCol);
			}
		}
		
		if (currentStep == 7)
		{
			Debug.Log("place third dirtpath...");
		}
		
		if (currentStep == 8)
		{
			Debug.Log("place fourth dirpath...");
		}
		
		if (currentStep == 9)
		{
			Debug.Log("place fifth dirtpath...");
		}
	}
	
//=======================================================================================================================================		
	
	public void renameCreatureTutorial(int currentStep)
	{
		if (currentStep == 1)
		{
			Debug.Log("select training ground");
			GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			GameObject tgArrow = Instantiate(guiControlInfo.gameArrow, new Vector3(tgObj.transform.position.x, tgObj.transform.position.y, tgObj.transform.position.z+8f), Quaternion.Euler(270, 0, 0)) as GameObject;
			guiControlInfo.delArrow = tgArrow;
		}
		
		if (currentStep == 2)
		{
			Debug.Log("select creature button");
			
			GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			objectSelection.curSelectedObj = tgObj;
			tgObj.transform.FindChild("selectionPatch").gameObject.active = true;
			tgObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = true;
			Destroy(guiControlInfo.delArrow);
			
			scr_ObjectSelection.TrainingGroundCreature();
			objectSelection.selectionPatchEnableBool = true;
			
			gameManagerInfo.houndName = "Hound";
			
			objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = false;
			objPanelInfo.panelMoveOut = true;
			
			GameObject creatureButt01Obj = GameObject.Find("objCreature01") as GameObject;
			GameObject creatureButtArrow = Instantiate(guiControlInfo.arrow, new Vector3(creatureButt01Obj.transform.position.x - 22f, 
														creatureButt01Obj.transform.position.y, creatureButt01Obj.transform.position.z), 
														Quaternion.Euler(270, 270, 0)) as GameObject;
		}
		
		if (currentStep == 3)
		{
			Debug.Log("select rename creature button");
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
				Destroy(arrowDel);
			
			GameObject creatureButtArrow = Instantiate(guiControlInfo.arrow, new Vector3(-31,13,95), Quaternion.Euler(270, 0, 0)) as GameObject;
			
			guiControlInfo.FeedMorphPopUp.transform.FindChild("FeedButt").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
			guiControlInfo.FeedMorphPopUp.transform.FindChild("MorphButt").gameObject.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);
			
			GameManager.FeedMorphPopupCancleBool = false;
		}
		
		if (currentStep == 4)
		{
			Debug.Log("enter name change arrow position...");
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
				arrowDel.transform.position = new Vector3(-31, 13, 100);
		}
		
		if (currentStep == 5)
		{
			Debug.Log("press confirm button");
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
			{
				arrowDel.transform.position = new Vector3(-31, 13, 82);
				arrowDel.transform.eulerAngles = new Vector3(270, 180, 0);
			}
		}
		
		if (currentStep == 6)
		{
			Debug.Log(" press ok close info popup");
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
			{
				arrowDel.transform.position = new Vector3(-20, 13, 93);
				arrowDel.transform.eulerAngles = new Vector3(270, 0, 0);
			}
			GameManager.FeedMorphPopupCancleBool = true;
		}
		
		if (currentStep == 7)
		{
			Debug.Log("Finish rename tutorial...");

			GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			if (tgObj != null)
			{
				tgObj.transform.FindChild("selectionPatch").gameObject.renderer.enabled = false;
			}

			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
				Destroy(arrowDel);
			
			curPopUpCnt = 13;
			curPopUpType = 0;
			GameManager.taskCount = 8;
			updateTaskCount();
			generatePopUp(curPopUpCnt, curPopUpType);
		}
	}
	
//=======================================================================================================================================		
	
	int harvestId;
	// task 7 harvest Turnip plant
	public void task7(int currentStep)
	{
		if (currentStep == 1)
		{
			GameObject go = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			GameObject plantGo = null;
			
			if(scr_loadUserWorld.GetTurnips1() != null)
			{
			   plantGo =  go.transform.FindChild(scr_loadUserWorld.GetTurnips1()).gameObject;
			}
			else if(scr_sfsRemoteCnt.GetPlantName() != null)
			{
			  plantGo =  go.transform.FindChild(scr_sfsRemoteCnt.GetPlantName()).gameObject;
			}
			 plantGo.transform.Find("HarvestButton").gameObject.SetActiveRecursively(true);
			
			// activate rabbit button pulse effect
			//buttonPulse harvestButton_BP = plantGo.transform.Find("HarvestButton").gameObject.GetComponent<buttonPulse>();
			//harvestButton_BP.scaleAnim = true;
			buttonPulse harvestButtBP = plantGo.transform.FindChild("HarvestButton").gameObject.AddComponent("buttonPulse") as buttonPulse;
			harvestButtBP.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
			harvestButtBP.minSpeed = 3;
			harvestButtBP.maxSpeed = 8;
			harvestButtBP.minVal = 0.02f;
			harvestButtBP.maxVal = 0.09f;
			harvestButtBP.scaleAnim = true;	
		
			//Debug.Log("---> " + harvestButton_BP
			// attach guiControl script to rabbit ui button
			Transform harvest = harvestButtBP.gameObject.transform.FindChild("Harvest") as Transform;
		
			UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			delObjUIButtonInfo.methodToInvoke = "harvestButton";
		}
		
		// harvest turnip plant
		if (currentStep == 2)
		{
			GameObject go = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			GameObject turnipPlant = null;
	
			if(scr_loadUserWorld.GetTurnips1() != null)
			{
			   turnipPlant =  go.transform.FindChild(scr_loadUserWorld.GetTurnips1()).gameObject;
			}
			else if(scr_sfsRemoteCnt.GetPlantName() != null)
			{
			  turnipPlant =  go.transform.FindChild(scr_sfsRemoteCnt.GetPlantName()).gameObject;
			}
			
	        GameObject harvest  = turnipPlant.transform.Find("HarvestButton").gameObject;
			Destroy(harvest);

			//indra get xp from server
//			Debug.Log("turnip xp : " + (int)scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTurnips.objTypeId));
//			GameObject xpValObj = Instantiate(Resources.Load("xpValue"), go.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
			
			// score update
			//GameManager.coins = GameManager.coins + 5;
			
			// gui score update
			guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
			
			GameManager.taskCount = 6;
			updateTaskCount();
				//task 7 sent to server 
			
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			
			int PlantId = GetIdFromString(turnipPlant.name);
			scr_sfsRemoteCnt.SendRequestForHarverst(scr_loadUserWorld.ReturnFarmId(PlantId), PlantId);
			
			Destroy(turnipPlant);
			curPopUpCnt = 10;
			updateCurPopUpCount();
			
			curPopUpType = 0;
			generatePopUp(curPopUpCnt, curPopUpType);
			
			GameObject.Find("HC_B_Plot_GO(Clone)").transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			 			ad.percentComplete2 = 100;
			
			scr_audioController.audio_harvestCrop.transform.position = go.transform.position;
			scr_audioController.audio_harvestCrop.Play();
			scr_audioController.audio_harvestCrop.volume = 0.7f;
			scr_audioController.audio_harvestCrop.minDistance = 1;
			scr_audioController.audio_harvestCrop.maxDistance = 20;
		}
	}

//=======================================================================================================================================
	
	// task 8 activate Golum character
	public void task8(int currentStep)
	{
		if (currentStep == 1)
		{
			GameObject golumSpwan = GameObject.Find("golumSpwan") as GameObject;
			GameObject golum = Instantiate(guiControlInfo.golumGO, golumSpwan.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;	
			GameManager.taskCount = 9;
			updateTaskCount();
			
				//task sent to server 
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("6","decorationType",scr_GameObjSvr.objGolum.objname,"2");
			//SendPos = golumSpwan.transform.position;
			SendPosDec = GetabsolutePos(golumSpwan.transform.position.x,golumSpwan.transform.position.y,golumSpwan.transform.position.z);
			SendRot = new Vector3(0,180,0);
			
		}
	}
	
//=======================================================================================================================================
	
	// task 9 build INN building
	public void task9(int currentStep)
	{
		if (currentStep == 1)
		{
			// goto market menu
			panelControl.panelMoveOut = true;
			panelControl.panelMoveIn = false;
			// arrow button create and place
			buttonPulse marketBP = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
			marketBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
			marketBP.minSpeed = 3;
			marketBP.maxSpeed = 8;
			marketBP.minVal = 0.05f;
			marketBP.maxVal = 0.2f;
			marketBP.scaleAnim = true;
			
			GameObject ms = GameObject.Find("marketSpwan");
			GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			guiControlInfo.delArrow = temp;
		}
		
		if (currentStep == 2)
		{
			GameObject go = Instantiate(guiControlInfo.innGO, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.innGO.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
			go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
			
			if (guiControlInfo.delArrow != null)
				Destroy(guiControlInfo.delArrow);
		}
		
		if (currentStep == 3)
		{
			//Debug.Log("i m here...");
			GameManager.placeObjectBool = false;
			Sensors.sensorWorkBool = false;

			GameObject[] effs = GameObject.FindGameObjectsWithTag("orcDestructEff");
			foreach(GameObject e in effs)
			{
				if (e != null)
					Destroy(e);
			}

			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			halflinGolumEnableBuildings();
		
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
			
			grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
			grid.curObj.renderer.material.color = new Color(grid.curObj.renderer.material.color.r,
															grid.curObj.renderer.material.color.g,
															grid.curObj.renderer.material.color.b, 1);
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.tag = "working";
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.active = false;
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
		
			// activate rabbit button pulse effect
			buttonPulse rabbitButton_BP = grid.curObj.transform.FindChild("RabbtiButton").gameObject.GetComponent("buttonPulse") as buttonPulse;
			rabbitButton_BP.scaleAnim = true;
		
			// attach guiControl script to rabbit ui button
			Transform rabbit = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			delObjUIButtonInfo.methodToInvoke = "rabbitButton";	
			
			GameObject goldButton = grid.curObj.transform.FindChild("GoldButton").gameObject;
			GameObject tempGold = goldButton.transform.FindChild("Gold").gameObject;
			tempGold.GetComponent<UIButton>().scriptWithMethodToInvoke = guiControlInfo;
			goldButton.SetActiveRecursively(false);
				
						//task 9 sent to server  
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType",scr_GameObjSvr.objInn.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objInn.objTypeId;
			
			PlayScaffolding(grid.curObj.transform.position);	
			grid.curObj = null;
			
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
			
			GameManager.popUpType1_Count = 10;
			
			gameManagerInfo.bubbleObj.SetActiveRecursively(true);
			gameManagerInfo.speakTextObj.active = true;
			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("And remember to speed things along with extra sparks... Time, I'm afraid, is not our ally");
		}
		
		if (currentStep == 4)
		{
			GameObject innTemp = GameObject.Find("HC_B_Inn_GO(Clone)") as GameObject;
			innTemp.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_1;
			innTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			innTemp.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
			
			Destroy(innTemp.GetComponent<progressBar>());
			innTemp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			innTemp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			
			halflinGolumDisable();
			
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objInn.objTypeId);
			scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
			    if(scr_audioController.audio_Scaffolding.isPlaying)
				{
					scr_audioController.audio_Scaffolding.Stop();
				}
			
			curPopUpCnt = 18;
			updateCurPopUpCount();
			
			curPopUpType = 0;
			generatePopUp(curPopUpCnt, curPopUpType);
			
			UpdateScore();
			GoldProducingBuildings();
			 			ad.percentComplete5 = 100;
		}
	}
	
	public static bool isScoreUpdate;
	public void UpdateScore()  //for score update
	{
		popUpInformation.isScoreUpdate = true;
		scr_sfsRemoteCnt.SendRequestForFarmItems("4","1");
	}
	
//=======================================================================================================================================
	
	// task 10 open clock
	public void task10(int currentStep)
	{
		if (currentStep == 1)
		{
			Debug.Log("task 10 <-------------");
			// arrow button create and place
			guiControlInfo.timeDisplayHUD.SetActiveRecursively(true);
			GameObject ms = GameObject.Find("timeDisplayUI_spwan");
			GameObject temp = Instantiate(guiControlInfo.arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			guiControlInfo.delArrow = temp;
			
			scr_sfsRemoteCnt.SendRequestforDayNnightActivation(); //harish chander
			
			GameManager.taskCount = 14;
			updateTaskCount();
			
//			gameManagerInfo.bubbleObj.SetActiveRecursively(true);
//			gameManagerInfo.speakTextObj.active = true;
//			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Watch the global clock carefully.  Tap on the clock to activate");
		}
	}
	
//=======================================================================================================================================
	
	public void PlaySparkBirthsound(Vector3 go)
	{
		scr_audioController.audio_sparkBirth.transform.position = go;
		scr_audioController.audio_sparkBirth.Play();
		scr_audioController.audio_sparkBirth.minDistance = 1;
		scr_audioController.audio_sparkBirth.maxDistance = 20;
		scr_audioController.audio_sparkBirth.volume = 1f;
		scr_audioController.audio_sparkBirth.loop = true;
	}
	
	// Task Training ground
	public void taskTrainingGround()
	{
		GameManager.placeObjectBool = false;
		Sensors.sensorWorkBool = false;
				
		grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
		
		grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
		grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
		Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
		
		GameObject map = GameObject.Find("HalfLing_Map").gameObject;
		grid.curObj.renderer.material.color = map.renderer.material.color;
								
		redPatch.gameObject.active = false; // hide red patch current game object
		greenPatch.gameObject.active = false; // hide green patch current game object
				
		// change current game object and collider tag name
		grid.curCol.tag = "editableObj";
		
		guiControlInfo.creaturePos = grid.curObj.transform.position;
		
		// hide current object UI
		Transform tempUI = grid.curObj.transform.FindChild("UI");
		
		GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
		placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
		
		GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
		cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
		
		tempUI.gameObject.SetActiveRecursively(false);
				
		// destroy current sensor script
		Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
		sensorInof.enabled = false;
		Sensors.sensorWorkBool = false;
		
		if (grid.curObj.tag == "TrainingGround")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTrainingGrnd.objTypeId, grid.curObj);

			GameManager.earthTG_Cnt++;
			
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objTrainingGrnd.objname,"2");		
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		}
		else if (grid.curObj.tag == "PlantTG")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objPlantTrainingGrnd.objTypeId, grid.curObj);

			GameManager.plantTG_Cnt++;
			inventoryInfo.RemoveItem(taskDetailsInfo.Three_Half_task1);
			taskDetailsInfo.Three_Half_task1_bool = true;
			
			TrainingGroundCreature();
			 //Harish chander		
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objPlantTrainingGrnd.objname,"2");		
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		}
		else if (grid.curObj.tag == "WaterTG")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWaterTrainingGrnd.objTypeId, grid.curObj);

			GameManager.waterTG_Cnt++;
			// remove item from task list
			inventoryInfo.RemoveItem(taskDetailsInfo.Five_Half_task1);
			taskDetailsInfo.Five_Half_task1_bool = true;
			
			TrainingGroundCreature();
			
			//Harish chander
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objWaterTrainingGrnd.objname,"2");		
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		  
			
		  
		}
		else if (grid.curObj.tag == "Swamp")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objSwampTrainingGrnd.objTypeId, grid.curObj);

			GameManager.swampTG_Cnt++;
			
			TrainingGroundCreature();
			//Harish Chander
		    scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		    scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objSwampTrainingGrnd.objname,"2");
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		 
		 
	        }
		else if (grid.curObj.tag == "DFireTG")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId, grid.curObj);

			inventory1Info.RemoveItem1(taskDetailsInfo.Six_Dark_task2);
			taskDetailsInfo.Six_Dark_task2_bool =true;
			GameManager.fireTG_Cnt++;
			
			TrainingGroundCreature();
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		    scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objDarklingFireTrainingGrnd.objname,"2");
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		  
		}
		else if (grid.curObj.tag == "DEarthTG")
		{
			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId, grid.curObj);

			inventory1Info.RemoveItem1(taskDetailsInfo.Five_Dark_task1);
			taskDetailsInfo.Five_Dark_task1_bool =true;
			GameManager.dEarthTG_Cnt++;
			
			TrainingGroundCreature();
			
			//Harish Chander
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();	//sab
		    scr_sfsRemoteCnt.SendRequestForBuyItems("1","trainingGroundType",scr_GameObjSvr.objDarkearthTrainingGrnd.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
		   
		}
		
		grid.curObj = null;
		
		UpdateScore();
	}
	
//=======================================================================================================================================
	
	public bool isTaskCreature;
	// Task Crecture
	public void taskCreature(int currentStep, string creatureName)
	{
		if (currentStep == 1)
		{
			// Hound Creature Instantiate
			if (creatureName == "Hound")
			{
				CreateCreature(gameManagerInfo.c_Hound_PF, scr_GameObjSvr.objHound.objname, scr_GameObjSvr.objHound.objTypeId,
								scr_GameObjSvr.objTrainingGrnd.objTypeId, false, 270, 180, 0, creatureLayerTop,
								"Hound");
			}
			
			// Barg Creature Instantiate
			if (creatureName == "Barg")
			{
				CreateCreature(gameManagerInfo.c_Barg_PF, scr_GameObjSvr.objBarg.objname, scr_GameObjSvr.objBarg.objTypeId,
								scr_GameObjSvr.objTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerMid, "Barg");
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Four_Half_task2);
				PlayerPrefs.SetInt("barg",1);
				taskDetailsInfo.Four_Half_task2_bool = true;
			}
			
			// Cusith Creature Instantiate
			if (creatureName == "Cusith")
			{
				CreateCreature(gameManagerInfo.c_Cusith_PF, scr_GameObjSvr.objCusith.objname, scr_GameObjSvr.objCusith.objTypeId,
								scr_GameObjSvr.objTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Cusith");
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Eight_Half_task2);
				taskDetailsInfo.Eight_Half_task2_bool = true;
			}
			
			// Sprout Creature Instantiate
			if (creatureName == "Sprout")
			{
				CreateCreature(gameManagerInfo.c_Sprout_PF, scr_GameObjSvr.objSprout.objname, scr_GameObjSvr.objSprout.objTypeId,
								scr_GameObjSvr.objPlantTrainingGrnd.objTypeId, false, 270, 180, 0, creatureLayerTop, "Sprout");
				
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Three_Half_task2);
				PlayerPrefs.SetInt("sprout",1);
				taskDetailsInfo.Three_Half_task2_bool = true;
			}
			
			// Nymph Creature Instantiate
			if (creatureName == "Nymph")
			{
				CreateCreature(gameManagerInfo.c_Nymph_PF, scr_GameObjSvr.objNymph.objname, scr_GameObjSvr.objNymph.objTypeId,
								scr_GameObjSvr.objPlantTrainingGrnd.objTypeId, true, 270, 180, 0, creatureLayerMid, "Nymph");
				
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Six_Half_task2);
				PlayerPrefs.SetInt("nymph",1);
				taskDetailsInfo.Six_Half_task2_bool = true;
			}
			
			// Dryad Creature Instantiate
			if (creatureName == "Dryad")
			{
				CreateCreature(gameManagerInfo.c_Dryad_PF, scr_GameObjSvr.objDryad.objname, scr_GameObjSvr.objDryad.objTypeId,
								scr_GameObjSvr.objPlantTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Dryad");
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Nine_Half_task1);
					taskDetailsInfo.Nine_Half_task1_bool = true;
			}
			
			// Nix Creature Instantiate
			if (creatureName == "Nix")
			{
				CreateCreature(gameManagerInfo.c_Nix_PF, scr_GameObjSvr.objNix.objname, scr_GameObjSvr.objNix.objTypeId,
								scr_GameObjSvr.objWaterTrainingGrnd.objTypeId, false, 90, 0, 0, creatureLayerTop, "Nix");
				
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Five_Half_task2);
				PlayerPrefs.SetInt("nix",1);
				taskDetailsInfo.Five_Half_task2_bool = true;
			}
			
			// Draug Creature Instantiate
			if (creatureName == "Draug")
			{
				CreateCreature(gameManagerInfo.c_Draug_PF, scr_GameObjSvr.objDraug.objname, scr_GameObjSvr.objDraug.objTypeId,
								scr_GameObjSvr.objWaterTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerMid, "Draug");
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Eight_Half_task1);
				PlayerPrefs.SetInt("draug",1);
				taskDetailsInfo.Eight_Half_task1_bool = true;
			}
			
			// Dragon Creature Instantiate
			if (creatureName == "Dragon")
			{
				CreateCreature(gameManagerInfo.c_Dragon_PF, scr_GameObjSvr.objDragon.objname, scr_GameObjSvr.objDragon.objTypeId,
								scr_GameObjSvr.objWaterTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Dagon");
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Twelve_Half_task1);
				taskDetailsInfo.Twelve_Half_task1_bool = true;
			}
			
			// Leech Creature Instantiate
			if (creatureName == "Leech")
			{
				CreateCreature(gameManagerInfo.c_Leech_PF, scr_GameObjSvr.objLeech.objname, scr_GameObjSvr.objLeech.objTypeId,
								scr_GameObjSvr.objSwampTrainingGrnd.objTypeId, false, 270, 180, 0, creatureLayerTop, "Leech");
			}
			
			// Leshy Creature Instantiate
			if (creatureName == "Leshy")
			{
				CreateCreature(gameManagerInfo.c_Leshy_PF, scr_GameObjSvr.objDarklingLeshy.objname, scr_GameObjSvr.objDarklingLeshy.objTypeId,
								scr_GameObjSvr.objSwampTrainingGrnd.objTypeId, true, 270, 180, 0, creatureLayerMid, "Leshy");
			}
			
			// Lurker Creature Instantiate
			if (creatureName == "Lurker")
			{
				CreateCreature(gameManagerInfo.c_Lurker_PF, scr_GameObjSvr.objDarklingLurker.objname, scr_GameObjSvr.objDarklingLurker.objTypeId,
								scr_GameObjSvr.objSwampTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Lurker");
			}
			
			// DHound Creature Instantiate
			if (creatureName == "DHound")
			{
				CreateCreature(gameManagerInfo.c_DHound_PF, scr_GameObjSvr.objDarklinghound.objname, scr_GameObjSvr.objDarklinghound.objTypeId,
								scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId, false, 90, 0, 0, creatureLayerTop, "Dark Hound");
			}
			
			// Fenrir Creature Instantiate
			if (creatureName == "Fenrir")
			{
				CreateCreature(gameManagerInfo.c_Fenrir_PF, scr_GameObjSvr.objDarklingFenrir.objname, scr_GameObjSvr.objDarklingFenrir.objTypeId,
								scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerMid, "Fenrir");
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Eight_Dark_task1);
				PlayerPrefs.SetInt("fenrir",1);
				taskDetailsInfo.Eight_Dark_task1_bool =true;
			}
			
			// Hell Hound Creature Instantiate
			if (creatureName == "HellHound")
			{
				CreateCreature(gameManagerInfo.c_HellHound_PF, scr_GameObjSvr.objDarklingHellhound.objname, scr_GameObjSvr.objDarklingHellhound.objTypeId,
								scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Hell Hound");
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Thirteen_Dark_task1);
				taskDetailsInfo.Thirteen_Dark_task1_bool =true;
			}
			
			// Sprite Creature Instantiate
			if (creatureName == "Sprite")
			{
				CreateCreature(gameManagerInfo.c_Sprite_PF, scr_GameObjSvr.objDarklingSprite.objname, scr_GameObjSvr.objDarklingSprite.objTypeId,
								scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId, false, 90, 0, 0, creatureLayerTop, "Sprite");
			}
			
			// Imp Creature Instantiate
			if (creatureName == "Imp")
			{
				CreateCreature(gameManagerInfo.c_Imp_PF, scr_GameObjSvr.objDarklingImp.objname, scr_GameObjSvr.objDarklingImp.objTypeId,
								scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerMid, "Imp");
				inventory1Info.RemoveItem1(taskDetailsInfo.Nine_Dark_task1);
				PlayerPrefs.SetInt("imp",1);
				taskDetailsInfo.Nine_Dark_task1_bool =true;
			}
			
			// Djinn Creature Instantiate
			if (creatureName == "Djinn")
			{
				CreateCreature(gameManagerInfo.c_Djinn_PF, scr_GameObjSvr.objDarklingDjInn.objname, scr_GameObjSvr.objDarklingDjInn.objTypeId,
								scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId, true, 90, 0, 0, creatureLayerBack, "Djinn");
			}
		}
		
		if (currentStep == 2)
		{
			defaultPopUpBool = true;
			defaultPopUp(1, 2);
		}
		
		if (currentStep == 3)
		{	
			GameObject go = guiControlInfo.currentRabbitButton;
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			
			if (go.tag == "Hound")
			{
				GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<HoundAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objHound.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Hound", scr_GameObjSvr.objHound.objTypeId);
				gameManagerInfo.houndName = "Hound";

				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objHound.objTypeId, go);
			}
			else if (go.tag == "Barg")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objBarg.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
								
				go.GetComponent<BargAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objBarg.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Barg", scr_GameObjSvr.objBarg.objTypeId);
				gameManagerInfo.bargName = "Barg";
			}
			else if (go.tag == "Sprout")
			{	
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objSprout.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<SproutAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objSprout.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Sprout", scr_GameObjSvr.objSprout.objTypeId);
				gameManagerInfo.sproutName = "Sprout";
			}
			else if (go.tag == "Nymph")
			{	
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objNymph.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<NymphAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objNymph.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Nymph", scr_GameObjSvr.objNymph.objTypeId);
				gameManagerInfo.nymphName = "Nymph";
			}
			else  if(go.tag == "DHound")
		    {
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingHellhound.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<DHoundAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklinghound.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				scr_sfsRemoteCnt.SendCreatureName("Dark Hound", scr_GameObjSvr.objDarklinghound.objTypeId);
				gameManagerInfo.dHoundName = "Dark Hound";
			}
			
			else if(go.tag == "Leech")
			{  
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objLeech.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<LeechAnimation>().moveAB_Bool = true;
			   	taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objLeech.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Leech", scr_GameObjSvr.objLeech.objTypeId);
				gameManagerInfo.leechName = "Leech";
			} 
			else if(go.tag == "Nix")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objNix.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<NixAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objNix.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Nix", scr_GameObjSvr.objNix.objTypeId);
				gameManagerInfo.nixName = "Nix";
			}
			else if(go.tag == "Sprite")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingSprite.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				TrainingGroundCreature();
				
				go.GetComponent<SpriteAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingSprite.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks); 
				
				scr_sfsRemoteCnt.SendCreatureName("Sprite", scr_GameObjSvr.objDarklingSprite.objTypeId);
				gameManagerInfo.spriteName = "Sprite";
			}
			else if(go.tag == "Fenrir")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingFenrir.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<FenrirAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingFenrir.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Fenrir", scr_GameObjSvr.objDarklingFenrir.objTypeId);
				gameManagerInfo.fenrirName = "Fenrir";
		    }
			else if(go.tag == "Draug")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDraug.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<DraugAnimation>().moveBA_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDraug.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Draug", scr_GameObjSvr.objDraug.objTypeId);
				gameManagerInfo.draugName = "Draug";
			}
			else if(go.tag == "Cusith")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objCusith.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<CusithAnimation>().moveBA_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objCusith.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Cusith", scr_GameObjSvr.objCusith.objTypeId);
				gameManagerInfo.cusithName = "Cusith";
			}
			else if(go.tag == "Leshy")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingLeshy.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<LeshyAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingLeshy.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Leshy", scr_GameObjSvr.objDarklingLeshy.objTypeId);
				gameManagerInfo.leshyName = "Leshy";
			}
			else if(go.tag == "Lurker")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingLurker.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
				DarklingCreaturesAchivement();
				CreaturesAchivement();
			
				go.GetComponent<LurkerAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingLurker.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Lurker", scr_GameObjSvr.objDarklingLurker.objTypeId);
				gameManagerInfo.lurkerName = "Lurker";
			}
			else if(go.tag == "Djinn")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingDjInn.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<DjinnAnimation>().moveBA_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingDjInn.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Djinn", scr_GameObjSvr.objDarklingDjInn.objTypeId);
				gameManagerInfo.djinnName = "Djinn";
			}
			else if(go.tag == "Imp"	)
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingImp.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<ImpAnimation>().moveBA_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingImp.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Imp", scr_GameObjSvr.objDarklingImp.objTypeId);
				gameManagerInfo.impName = "Imp";
			}
			else if(go.tag == "HellHound")
			{		
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingHellhound.objTypeId, go);

				GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				DarklingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<HellHoundAnimation>().moveAB_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingHellhound.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Hell Hound", scr_GameObjSvr.objDarklingHellhound.objTypeId);
				gameManagerInfo.hellHoundName = "Hell Hound";
			}
			else if(go.tag == "Dryad")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDryad.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<DryadAnimation>().moveBA_Bool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDryad.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Dryad", scr_GameObjSvr.objDryad.objTypeId);
				gameManagerInfo.dryadName = "Dryad";
			}
			else if(go.tag == "Dragon")
			{
				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDragon.objTypeId, go);

				GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				if (tg != null)
					tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				HalflingCreaturesAchivement();
				CreaturesAchivement();
				
				go.GetComponent<DragonAnimation>().moveBA_Bool = true;
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDragon.objTypeId);
				scr_sfsRemoteCnt.AccelerateMorphingTask(taskidSvr);
				
				scr_sfsRemoteCnt.SendCreatureName("Dagon", scr_GameObjSvr.objDragon.objTypeId);
				gameManagerInfo.dragonName = "Dagon";
			}
			 	
			
			if(scr_audioController.audio_sparkBirth.isPlaying)
			{
				scr_audioController.audio_sparkBirth.Stop();
			}
			
			defaultPopUpBool = true;
			Destroy(go.transform.FindChild("RabbtiButton").gameObject);
			Destroy(go.transform.FindChild("ProgressBar").gameObject);
			Destroy(go.GetComponent("progressBar"));
				
			go.renderer.enabled = true;
				
			go.transform.root.gameObject.transform.FindChild("Spark").gameObject.active = false;
			go.transform.root.gameObject.transform.FindChild("Spark1").gameObject.active = false;
			go.transform.root.gameObject.transform.FindChild("Spark2").gameObject.active = false;
			
			UpdateScore();
			guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
			
		}
	}
	
//=======================================================================================================================================
	
	void Farming(GameObject plantPF, string objName, int objTypeId)
	{
		GameObject go = Instantiate(plantPF, new Vector3(GameManager.curPlot.transform.position.x, 
																					GameManager.curPlot.transform.position.y+0.0001f, 
																					GameManager.curPlot.transform.position.z), 
																					Quaternion.Euler(0, 180, 0)) as GameObject;
				
		GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.parent = GameManager.curPlot.transform;
		
		plotInformation plotInfo = go.GetComponent("plotInformation") as plotInformation;
		plotInfo.usingGardenPlot = GameManager.curPlot;
		
		progressBar plantPB = go.GetComponent("progressBar") as progressBar;
		plantPB.enabled = true;
		
		// task sent to server
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemoteCnt.SendRequestForBuyItems("5","plantType", objName,"2");			
		//SendPos = GameManager.curPlot.transform.position;
		SendPos = GetabsolutePos(GameManager.curPlot.transform.position.x,GameManager.curPlot.transform.position.y,GameManager.curPlot.transform.position.z);
		SendRot = new Vector3(0,180,0);
		TempTypeId = objTypeId;
		isTaskFarming = true;
		SendGo = go;
	    plotname = GameManager.curPlot.name;
		
		// activate rabbit button
		Transform harvest = go.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
		Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false); 

		
		UIButton h_DelObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
		h_DelObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		UIButton r_DelObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		r_DelObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		harvest.gameObject.SetActiveRecursively(false);
	}
	
//----------------------------------------------------------------	
	
	void HarvestActivation(Texture plantTex)
	{
		GameObject go = GameManager.currentPlant;
		Destroy(go.GetComponent<progressBar>());
		Destroy(go.transform.FindChild("ProgressBar").gameObject);
		go.renderer.material.mainTexture = plantTex;

		// destroy rabbit button
		Destroy(go.transform.FindChild("RabbtiButton").gameObject);
	
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
        taskidSvr = scr_loadUserWorld.ReturnTaskIdforIds(GetIdFromString(go.name));
		scr_sfsRemoteCnt.AcceleratePlantPlantsTask(taskidSvr);
		

		// update spark score
		UpdateScore();
		guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
		go.GetComponent<plantBurn>().enabled = true;
		go.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
	}
	
//---------------------------------------	
	
	void Harvesting()
	{
		plantHerbsHarvestCount();
				
		guiControlInfo.currentHarvestButton.transform.parent.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
		// request for xp
		if (guiControlInfo.currentHarvestButton.tag == "Costmary")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objCostmaryherb.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "FairyLily")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objFairyLilly.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Mandrake")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objMandrake.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "PipeWeed")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objPipeweed.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Potato")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objPotatoes.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Pumpkin")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objPumpkin.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "SunFlower")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objSunflower.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Turnip")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTurnips.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Vervain")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objVervainHerb.objTypeId, guiControlInfo.currentHarvestButton);
		else if (guiControlInfo.currentHarvestButton.tag == "Watercress")
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWatercress.objTypeId, guiControlInfo.currentHarvestButton);

//		GameObject getXpPref = Instantiate(gameManagerInfo.xpValObj, guiControlInfo.currentHarvestButton.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
//		getXpPref.GetComponent<getPlantXP>().xpObj = guiControlInfo.currentHarvestButton.tag;
//		getXpPref.GetComponent<getPlantXP>().xpAnimBool = true;
				
		Destroy(guiControlInfo.currentHarvestButton);
				
		//sent to server
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				
		int PlantId = GetIdFromString(guiControlInfo.currentHarvestButton.name);
		scr_sfsRemoteCnt.SendRequestForHarverst(scr_loadUserWorld.ReturnFarmId(PlantId), PlantId);
	}
	
//=======================================================================================================================================
	
	public bool isTaskDarklingFarming;
	// Task Farming
	public void taskFarming(int currentStep, string farmName)
	{
		//Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
		if (currentStep == 1)
		{
			// find empty Garden plot
			foreach(GameObject plot in GameObject.FindGameObjectsWithTag("Plot"))
			{
    			if(plot.name == "Plot")
    			{
					if (GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "using")
					{
       			 		if(plot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
							GameManager.curPlot = plot;
					}
    			}
			}
			
			
			// Halfling Turnip
			if (farmName == "Turnip" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(guiControlInfo.turnipPlantGO, scr_GameObjSvr.objTurnips.objname, scr_GameObjSvr.objTurnips.objTypeId);
				
				if (turnipBoolThree == false && GameManager.gameLevel >= 3)
				{
					// remove item from task list
					inventoryInfo.RemoveItem(taskDetailsInfo.Three_Half_task4);
					taskDetailsInfo.Three_Half_task4_bool =true;
					turnipBoolThree = true;
				}
			}
			
			// Earth PipeWeed
			if (farmName == "PipeWeed" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(guiControlInfo.pipeWeedGO, scr_GameObjSvr.objPipeweed.objname, scr_GameObjSvr.objPipeweed.objTypeId);
				
				if (pipweedBoolThree == false && GameManager.gameLevel >= 3)
				{
					// remove item from task list
					inventoryInfo.RemoveItem(taskDetailsInfo.Three_Half_task3);
					taskDetailsInfo.Three_Half_task3_bool = true;
					pipweedBoolThree = true;
				}
			}
			
			// Halfling Pumpkin
			if (farmName == "Pumpkin" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Pumpkin_PF, scr_GameObjSvr.objPumpkin.objname, scr_GameObjSvr.objPumpkin.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Five_Half_task4);
				taskDetailsInfo.Five_Half_task4_bool = true;
			}
			
			// Halfling Costmary
			if (farmName == "Costmary" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Costmary_PF, scr_GameObjSvr.objCostmaryherb.objname, scr_GameObjSvr.objCostmaryherb.objTypeId);
				
			}
			
			// Halfling FairyLily
			if (farmName == "FairyLily" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_FairyLily_PF, scr_GameObjSvr.objFairyLilly.objname, scr_GameObjSvr.objFairyLilly.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Eleven_Half_task1);
				taskDetailsInfo.Eleven_Half_task1_bool = true;
			}
			
			// Halfling Potatoes
			if (farmName == "Potatoes" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Potatoes_PF, scr_GameObjSvr.objPotatoes.objname, scr_GameObjSvr.objPotatoes.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Ten_Half_task2);
				taskDetailsInfo.Ten_Half_task2_bool = true;
			}
			
			// Halfling Watercress
			if (farmName == "Watercress" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Watercress_PF, scr_GameObjSvr.objWatercress.objname, scr_GameObjSvr.objWatercress.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Twelve_Half_task2);
				taskDetailsInfo.Twelve_Half_task2_bool =true;
			}
			
			// Halfling Mandrake
			if (farmName == "Mandrake" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Mandrake_PF, scr_GameObjSvr.objMandrake.objname, scr_GameObjSvr.objMandrake.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Fourteen_Half_task2);
				taskDetailsInfo.Fourteen_Half_task2_bool =true;
			}
			
			// Halfling Vervain
			if (farmName == "Vervain" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				Farming(gameManagerInfo.h_Vervain_PF, scr_GameObjSvr.objVervainHerb.objname, scr_GameObjSvr.objVervainHerb.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Thirteen_Half_task2);
				taskDetailsInfo.Thirteen_Half_task2_bool =true;
			}
			
			// Halfling Sunflower
			if (farmName == "SunFlower" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj" && GameManager.curPlot.tag == "Plot")
			{
				
				Farming(gameManagerInfo.h_Sunflower_PF, scr_GameObjSvr.objSunflower.objname, scr_GameObjSvr.objSunflower.objTypeId);
				
			}
			
			
			scr_audioController.audio_plantCrop.transform.position = GameManager.curPlot.transform.position;
			scr_audioController.audio_plantCrop.Play();
			scr_audioController.audio_plantCrop.volume = 0.7f;
			scr_audioController.audio_plantCrop.minDistance = 1;
			scr_audioController.audio_plantCrop.maxDistance = 20;
		}
		
		// rabbit button pop up
		if (currentStep == 2)
		{
			if (farmName == "tempFarm")
			{
				defaultPopUpBool = true;
				defaultPopUp(2, 2);
			}
		}
		
		// harvest button activation
		if (currentStep == 3)
		{
			if (farmName == "Turnip")
			{
				HarvestActivation(upgradeTextureInfo.h_Turnip01);
			}
			
			if (farmName == "PipeWeed")
			{
				HarvestActivation(upgradeTextureInfo.h_PipeWeed01);
			}
			
			if (farmName == "Pumpkin")
			{
				HarvestActivation(upgradeTextureInfo.h_Pumpking01);
			}
			
			if (farmName == "Costmary")
			{
				HarvestActivation(upgradeTextureInfo.h_Costmary01);
			}
			
			if (farmName == "FairyLily")
			{
				HarvestActivation(upgradeTextureInfo.h_FairyLily01);
			}
			
			if (farmName == "Potatoes")
			{
				HarvestActivation(upgradeTextureInfo.h_Potatoes01);
			}
			
			if (farmName == "Watercress")
			{
				HarvestActivation(upgradeTextureInfo.h_Watercress01);
			}
			
			if (farmName == "Mandrake")
			{
				HarvestActivation(upgradeTextureInfo.h_Mandrake01);
			}
			
			if (farmName == "Vervain")
			{
				HarvestActivation(upgradeTextureInfo.h_Vervain01);
			}
			
			if (farmName == "SunFlower")
			{
				HarvestActivation(upgradeTextureInfo.h_SunFlower01);
			}
		}
		
		// harvesting 
		if (currentStep == 4)
		{
			Harvesting();

			//indra get xp value from server
//			Debug.Log("plant xp : " + scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTurnips.objTypeId));
//			GameObject xpValObj = Instantiate(Resources.Load("xpValue"), guiControlInfo.currentHarvestButton.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;

			scr_audioController.audio_harvestCrop.transform.position = guiControlInfo.currentHarvestButton.transform.position;
			scr_audioController.audio_harvestCrop.Play();
			scr_audioController.audio_harvestCrop.volume = 0.7f;
			scr_audioController.audio_harvestCrop.minDistance = 1;
			scr_audioController.audio_harvestCrop.maxDistance = 20;
		}
	}
	
//=======================================================================================================================================
	
	// Task Arrow on broken bridge
	public void taskArrowOnBrokenBridge()
	{
		//GameObject arrowChk = GameObject.Find("gameArrowPF(Clone)") as GameObject;
		Debug.Log("---------------- arrow on bridge -----------------------");
		GameObject bridgeSpwan = GameObject.Find("bridge_spwan") as GameObject;
		//if (arrowChk == null)
		//{
		GameObject gArrow = Instantiate(guiControlInfo.gameArrow, bridgeSpwan.transform.position, Quaternion.Euler(270, 0, 0)) as GameObject;
		gArrow.name = "bridgeArrow";
			//guiControlInfo.delArrow = gArrow;
		//}
		GameObject.Find("Main Camera").gameObject.transform.position = GameObject.Find("bridge_cPos").gameObject.transform.position;

		GameObject brdg = GameObject.Find("BridgeBroken_GO") as GameObject;
		if (brdg != null)
		{
			brdg.AddComponent<blinking>();
		}
	}
	
	
	
	
	// Task Arrow on Battle Tutorial
	
	
	public void BattleUnlock()
	{
		Debug.Log(PlayerPrefs.GetInt("isBattleFirstTime"));
		
		if(PlayerPrefs.GetInt("isBattleFirstTime")!=2)
		{
		//Debug.Log("Unlock The Battle");
		GameObject arrowChk = GameObject.Find("gameArrowPF(Clone)") as GameObject;
		
		GameObject bridgeSpwan = GameObject.Find("Fight_Gate") as GameObject;
		if (arrowChk == null)
		{
			
			GameObject gArrow = Instantiate(guiControlInfo.gameArrow, bridgeSpwan.transform.FindChild("Hgate").gameObject.transform.position, Quaternion.Euler(270, 0, 0)) as GameObject;
			guiControlInfo.delArrow = gArrow;
			
		}
		GameObject.Find("Main Camera").gameObject.transform.position = new Vector3(-49f,40f,-13f);
		GameObject.Find("Main Camera").gameObject.camera.orthographicSize = 20;
		}
	}
	
//=======================================================================================================================================
	
	// Task Destroy Goblin Cave
	public void taskGoblinCave(int currentStep)
	{
		if (currentStep == 1)
		{
			//Debug.Log("public void taskGoblinCave(int currentStep) :: if (currentStep == 1)...........");
			objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
			
			// hide training ground panel
			objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfoTG.panelMoveIn = true;
			objPanelInfoTG.panelMoveOut = false;
			
			// hide farm panel
			objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfoFrm.panelMoveIn = true;
			objPanelInfoFrm.panelMoveOut = false;
		}
		
		if (currentStep == 2)
		{
			//Debug.Log("if (currentStep == 2)..............");
			objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
			attackPanelInfo.panelMoveIn = true;
			attackPanelInfo.panelMoveOut = false;
			
			wall.active = true;
			scr_inventoryItems.inventoryCreature();
		}
		
		// start progress bar
		if (currentStep == 3)
		{
			GameManager.readyAttackBool = false;
			Transform shadow = GameManager.currentCreature.transform.FindChild("shadow") as Transform;
			GameManager.currentCreature.GetComponent<MeshRenderer>().enabled = false;
			if (shadow != null)
				shadow.gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			GameManager.curTG = null;
			
			GameManager.curCave.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			GameManager.curCave.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			progressBar goblinCampPB = GameManager.curCave.GetComponent("progressBar") as progressBar;
			GameManager.curCave.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
			goblinCampPB.enabled = true;
			
			
			//Clear Cave sent ot server			
			StartCoroutine("GetWorld");
		    isTask4 = true;
		   // caveTobeCleared = new Vector3(goblinCampPB.gameObject.transform.position.x, goblinCampPB.gameObject.transform.position.y, goblinCampPB.gameObject.transform.position.z); 
			caveTobeCleared  = GetabsolutePos(goblinCampPB.gameObject.transform.position.x,0.03f,goblinCampPB.transform.position.z);
		//	Debug.Log("cavetobecleared :" + caveTobeCleared);
			caveName = goblinCampPB.transform.name;
			GetCreatureTypeIdfromName(GameManager.currentCreature.name);
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			if(goblinCampPB.transform.name == "HC_B_GoblinCamp_GO(Clone)_02")
			{
				GameManager.sproutUsingBool = true;
				TempTypeId = scr_GameObjSvr.objGoblinCamp02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_GoblinCamp_GO(Clone)_01")
			{
				GameManager.leechUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingGoblinCamp01.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_GoblinCamp_GO(Clone)_02")
			{
				GameManager.dHoundUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingGoblinCamp02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_GoblinCamp_GO(Clone)_03")
			{
				GameManager.bargUsingBool = true;
				TempTypeId = scr_GameObjSvr.objGoblinCamp03.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_OrgCave_GO(Clone)_01")
			{
				GameManager.cusithUsingBool = true;
				TempTypeId = scr_GameObjSvr.objOrgCave01.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_OrgCave_GO(Clone)_02")
			{
				GameManager.dryadUsingBool = true;
				TempTypeId = scr_GameObjSvr.objOrgCave02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_OrgCave_GO(Clone)_03")
			{
				GameManager.dragonUsingBool = true;
				TempTypeId = scr_GameObjSvr.objOrgCave03.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_TrollHouse_GO(Clone)_01")
			{
				GameManager.nixUsingBool = true;
				TempTypeId = scr_GameObjSvr.objTrollCave01.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_TrollHouse_GO(Clone)_03")
			{
				GameManager.draugUsingBool = true;
				TempTypeId = scr_GameObjSvr.objTrollCave03.objTypeId;
			}
			else if(goblinCampPB.transform.name == "HC_B_TrollHouse_GO(Clone)_02")
			{
				GameManager.nymphUsingBool = true;
				TempTypeId = scr_GameObjSvr.objTrollCave02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_GoblinCamp_GO(Clone)_03")
			{
				GameManager.spriteUsingBool = true;
				TempTypeId  = scr_GameObjSvr.objDarklingGoblinCamp03.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_OrgCave_GO(Clone)_01")
			{
				GameManager.lurkerUsingBool = true; 
			    TempTypeId = scr_GameObjSvr.objDarklingOrgCave01.objTypeId;	
			}
			else if(goblinCampPB.transform.name == "DL_B_OrgCave_GO(Clone)_02")
			{
				GameManager.hellHoundUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingOrgCave02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_OrgCave_GO(Clone)_03")
			{
				GameManager.djinnUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingOrgCave03.objTypeId; 
			}
			else if(goblinCampPB.transform.name == "DL_B_TrollHouse_GO(Clone)_01")
			{
				GameManager.leshyUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingTrollCave01.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_TrollHouse_GO(Clone)_02")
			{
				GameManager.fenrirUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingTrollCave02.objTypeId;
			}
			else if(goblinCampPB.transform.name == "DL_B_TrollHouse_GO(Clone)_03")
			{
				GameManager.impUsingBool = true;
				TempTypeId = scr_GameObjSvr.objDarklingTrollCave03.objTypeId;
			}
			
			CreatureAttackAnimation(GameManager.currentCreature, GameManager.curCave);
			
			// attach guiControl script to rabbit ui button
			Transform rabbit = GameManager.curCave.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			
			UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		}
		
		if (currentStep == 4)
		{
			defaultPopUpBool = true;
				defaultPopUp(3, 2);
		}
		
		// rabbit button
		if (currentStep == 5)
		{
		
			//task sent to server 
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			if(guiControlInfo.currentRabbitButton.name == "HC_B_GoblinCamp_GO(Clone)_02")
			{
				
				SendCreatureHome(scr_GameObjSvr.objGoblinCamp02.objTypeId);
				
			}
			else if(guiControlInfo.currentRabbitButton.name == "HC_B_GoblinCamp_GO(Clone)_03")
			{
				/*GameManager.bargUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject hGC_Creature = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
				if (hGC_Creature != null)
				{
					hGC_Creature.GetComponent<MeshRenderer>().enabled = true;
					hGC_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}	
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objGoblinCamp03.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Six_Half_task4);
				taskDetailsInfo.Six_Half_task4_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objGoblinCamp03.objTypeId);
				
			}
			
			else if(guiControlInfo.currentRabbitButton.name == "DL_B_GoblinCamp_GO(Clone)_01")
			{
				/*GameManager.leechUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				GameObject dGC01_Creature = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
				
				if (dGC01_Creature != null)
					dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
				
			    taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingGoblinCamp01.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Five_Dark_task5);
				taskDetailsInfo.Five_Dark_task5_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objDarklingGoblinCamp01.objTypeId);
			}
			
			else if(guiControlInfo.currentRabbitButton.name == "DL_B_GoblinCamp_GO(Clone)_02")
			{
				/*GameManager.dHoundUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject dGC01_Creature = GameObject.Find("DL_C_DHound_GO(Clone)") as GameObject;
				
				if (dGC01_Creature != null)
				{
					dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
					dGC01_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingGoblinCamp02.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Seven_Dark_task3);
				taskDetailsInfo.Seven_Dark_task3_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objDarklingGoblinCamp02.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_GoblinCamp_GO(Clone)_03")
			{
				/*GameManager.spriteUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject dGC01_Creature = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
				
				if (dGC01_Creature != null)
					dGC01_Creature.GetComponent<MeshRenderer>().enabled = true;
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingGoblinCamp03.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Nine_Dark_task2);
				taskDetailsInfo.Nine_Dark_task2_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objDarklingGoblinCamp03.objTypeId);
			}
			
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_OrgCave_GO(Clone)_01")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objOrgCave01.objTypeId);
				
				SendCreatureHome(scr_GameObjSvr.objOrgCave01.objTypeId);
			}
			
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_OrgCave_GO(Clone)_02")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objOrgCave02.objTypeId);
				SendCreatureHome(scr_GameObjSvr.objOrgCave02.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_OrgCave_GO(Clone)_03")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objOrgCave03.objTypeId);
				SendCreatureHome(scr_GameObjSvr.objOrgCave03.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_TrollHouse_GO(Clone)_01")
			{
				/*GameManager.nixUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject hTC01_Creature = GameObject.Find("HC_C_Nix_GO(Clone)") as GameObject;
				
				if (hTC01_Creature != null)
				{
					hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
				}
				
			    	taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objTrollCave01.objTypeId);
				inventoryInfo.RemoveItem(taskDetailsInfo.Eight_Half_task3);
				taskDetailsInfo.Eight_Half_task3_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objTrollCave01.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_TrollHouse_GO(Clone)_03")
			{
				/*GameManager.draugUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject hTC01_Creature = GameObject.Find("HC_C_Draug_GO(Clone)") as GameObject;
				
				if (hTC01_Creature != null)
				{
					hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
				}
				
					taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objTrollCave03.objTypeId);
				inventoryInfo.RemoveItem(taskDetailsInfo.Twelve_Half_task4 );
				taskDetailsInfo.Twelve_Half_task4_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objTrollCave03.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "HC_B_TrollHouse_GO(Clone)_02")
			{
				/*GameManager.nymphUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject hTC01_Creature = GameObject.Find("HC_C_Nymph_GO(Clone)") as GameObject;
				
				if (hTC01_Creature != null)
				{
					hTC01_Creature.GetComponent<MeshRenderer>().enabled = true;	
					hTC01_Creature.transform.FindChild("shadow").gameObject.active = true;
				}
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objTrollCave02.objTypeId);
				
				inventoryInfo.RemoveItem(taskDetailsInfo.Ten_Half_task4);
				taskDetailsInfo.Ten_Half_task4_bool = true;*/
				
				SendCreatureHome(scr_GameObjSvr.objTrollCave02.objTypeId);
			}
			
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_OrgCave_GO(Clone)_01")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingOrgCave01.objTypeId);
				SendCreatureHome(scr_GameObjSvr.objDarklingOrgCave01.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_OrgCave_GO(Clone)_02")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingOrgCave02.objTypeId);
				SendCreatureHome(scr_GameObjSvr.objDarklingOrgCave02.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_OrgCave_GO(Clone)_03")
			{
				//taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingOrgCave03.objTypeId);
				SendCreatureHome(scr_GameObjSvr.objDarklingOrgCave03.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_TrollHouse_GO(Clone)_01")
			{
				/*GameManager.leshyUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject dTC01_Creature = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
				
				if (dTC01_Creature != null)
					dTC01_Creature.GetComponent<MeshRenderer>().enabled = true;
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingTrollCave01.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Eleven_Dark_task2);
				taskDetailsInfo.Eleven_Dark_task2_bool = true;*/
				SendCreatureHome(scr_GameObjSvr.objDarklingTrollCave01.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_TrollHouse_GO(Clone)_02")
			{
				/*GameManager.fenrirUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject dTC01_Creature = GameObject.Find("DL_C_Fenrir_GO(Clone)") as GameObject;
				
				if (dTC01_Creature != null)
				{
					dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
					dTC01_Creature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = false;
				}
			    
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingTrollCave02.objTypeId);	*/
				
				SendCreatureHome(scr_GameObjSvr.objDarklingTrollCave02.objTypeId);
			}
			else if(guiControlInfo.currentHarvestButton.name == "DL_B_TrollHouse_GO(Clone)_03") 
			{
				/*GameManager.impUsingBool = false;
				EnemyCaveBuildings();
				GameObject tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
				tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				GameObject dTC01_Creature = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
				
				if (dTC01_Creature != null)
					dTC01_Creature.GetComponent<MeshRenderer>().enabled = false;
				
				 taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingTrollCave03.objTypeId); */
				
				SendCreatureHome(scr_GameObjSvr.objDarklingTrollCave03.objTypeId);
			}
			
			scr_sfsRemoteCnt.AccelerateCaveClearTask(taskidSvr);
			
			Destroy(guiControlInfo.currentRabbitButton);
		}
	}
	
	private string caveName;
	public string GetGoblinCaveName()
	{
		return caveName;
	}
	
	private int CaveCreature;
	public int GetCaveCreaturetypeId()
	{
		return CaveCreature;
	}
	
	
	private string objhalflingGardenplot;
//=======================================================================================================================================
	//private string objhalflingGardenplot;
	// Task Garden Plot
	public void taskGardenPlot(int currentStep)
	{
		if (currentStep == 1)
		{
			objGridMove.gridObjSetBool = true;
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;
		
			GameObject go = Instantiate(guiControlInfo.farmPlot, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.farmPlot.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			//Debug.Log("count >>>>"+ cnGrnd);
            cnGrnd++;
			go.name = go.name + "_" +cnGrnd ;

			//Debug.Log("Name : " + go.name);
			
			
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			upgradeProgressBar plotUBPInfo = go.GetComponent<upgradeProgressBar>();
			plotUBPInfo.enabled = false;
			
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
					
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		if (currentStep == 2)
		{
			GameManager.placeHGardenPlotBool = false;
			
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
				
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
		
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
							
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
		
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
		
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
								
			//sent to server
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			
			
			objhalflingGardenplot = ReturnGardenNameSvr(grid.curObj.name);
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType", objhalflingGardenplot ,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);


			// request for xp
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objGarden.objTypeId, grid.curObj);

			grid.curObj = null;

			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;
			
			GameManager.gardenPlotCnt++;
			
			GameManager.placeHGardenPlotBool = false;
			
			if (GameManager.gameLevel >= 4 && gardenPlotFive == false)
			{
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Four_Half_task4);
				taskDetailsInfo.Four_Half_task4_bool = true;
				gardenPlotFive = true;
			}
			if (GameManager.gameLevel >= 7 && gardenPlotSeven == false)
			{
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Seven_Half_task1);
				taskDetailsInfo.Seven_Half_task1_bool = true;
				gardenPlotSeven = true;
			}
			
			if (GameManager.gameLevel >= 10 && gardenPlotTen == false)
			{
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Ten_Half_task1);
				taskDetailsInfo.Ten_Half_task1_bool = true;
				gardenPlotTen = true;
			}
			
			if (GameManager.gameLevel >= 13 && gardenPlotThirteen == false)
			{
				// remove item from task list
				inventoryInfo.RemoveItem(taskDetailsInfo.Thirteen_Half_task1 );
				taskDetailsInfo.Thirteen_Half_task1_bool = true;
				gardenPlotThirteen = true;
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeInn(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 4 && GameManager.curBuilding.tag == "Inn")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeInn = false;
				GameManager.curBuilding.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeInnRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objInn.objTypeId;
				StartCoroutine("GetWorld"); 
				
				//first it comes here and we pass typeid as the paramenter and make isUpgrade to true.
				
				PlayScaffolding(GameManager.curBuilding.transform.position);
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			guiControlInfo.currentRabbitButton.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objInn.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.InnLevel_2;
			
			 			ad.percentComplete28 = 100;
			
			halflinGolumDisable();
			
			if(scr_audioController.audio_Scaffolding.isPlaying)
			{
				scr_audioController.audio_Scaffolding.Stop();
			}
		}
	}
	
//=======================================================================================================================================
	
	// upgrade H House
	public void taskUpgradeHHouse(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 7 && GameManager.curBuilding.tag == "HHouse")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				Debug.Log("house is upgrading...");
				guiControlInfo.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				
				halflinGolumEnableUpgradeBuildings();
					
				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeHHouse = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeHHouseRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objHalflingHouse.objTypeId;
				StartCoroutine("GetWorld"); 
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objHalflingHouse.objTypeId);
			scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_House2;
			
			 			ad.percentComplete17 = 100;
			
			halflinGolumDisable();
		}
	}
	
//=======================================================================================================================================
	
	// upgrade D House
	public void taskUpgradeDHouse(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 7 && GameManager.curBuilding.tag == "DHouse")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				darklinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeDHouse = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDHouseRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarklingHouse.objTypeId;
				StartCoroutine("GetWorld"); 
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "nonMovableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingHouse.objTypeId);
			scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_house2;
			
			DarklinGolumDisable();
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeStable(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar stableUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 4 && GameManager.curBuilding.tag == "Stable")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				stableUPB.progressBarPov.transform.localScale = new Vector3(0.01f, stableUPB.progressBarPov.transform.localScale.y, stableUPB.progressBarPov.transform.localScale.z);
				stableUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeStableRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objHalflingStable.objTypeId;
				StartCoroutine("GetWorld"); 
				
				PlayScaffolding(GameManager.curBuilding.transform.position);
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objHalflingStable.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_Stable2;
			
			halflinGolumDisable();
			
			if(scr_audioController.audio_Scaffolding.isPlaying)
			{
				scr_audioController.audio_Scaffolding.Stop();
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeBlackSmith(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar stableUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 14 && GameManager.curBuilding.tag == "BlackSmith")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				stableUPB.progressBarPov.transform.localScale = new Vector3(0.01f, stableUPB.progressBarPov.transform.localScale.y, stableUPB.progressBarPov.transform.localScale.z);
				stableUPB.enabled = true;
				GameManager.upgradeStable = false;
				GameManager.curBuilding.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeBlackSmithRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objBlackSmith.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			guiControlInfo.currentRabbitButton.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objBlackSmith.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_BlackSmith2;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}

//=======================================================================================================================================	
	
	public void taskBuildingUpgrade(int currentStep, int unlockLevel, string buildingTag, bool halflingBool, 
									bool obeliskBool, Texture constructionTex, bool smokeBool, string rabbitButtMethode, 
									int typeID, Texture level2Tex, Texture level3Tex, bool nightObjBool, 
									string nightObjName, Texture nightObjTex)
	{
		if (currentStep == 1)
		{
			Debug.Log("----------->> 1 ");
			upgradeProgressBar buildingUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= unlockLevel && GameManager.curBuilding.tag == buildingTag)
			{
				if (halflingBool)
				{
					halflinGolumEnableUpgradeBuildings();
					GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				}
				else
				{
					darklinGolumEnableUpgradeBuildings();
					GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
				}
				
				GameManager.curBuilding.renderer.material.mainTexture = constructionTex;
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				
				buildingUPB .progressBarPov.transform.localScale = new Vector3(0.01f, buildingUPB.progressBarPov.transform.localScale.y, buildingUPB.progressBarPov.transform.localScale.z);
				buildingUPB.enabled = true;
				
				if (smokeBool)
					GameManager.curBuilding.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = rabbitButtMethode;
				
				Isupgrade = true;
				
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = typeID;
				StartCoroutine("GetWorld"); 
				
				PlayScaffolding(GameManager.curBuilding.transform.position);
			}
			
			if (currentStep == 2)
			{
				Debug.Log("----------->>>> 2222");
				guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				if (smokeBool)
					guiControlInfo.currentRabbitButton.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
			
				//accelerate task
				taskidSvr = scr_loadUserWorld.ReturnTaskId(typeID);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
				upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
				tgUpgradePBInfo.currentUpgradeLevel++;
			
				if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				{
					guiControlInfo.currentRabbitButton.renderer.material.mainTexture = level2Tex;
					
					if (nightObjBool)
						guiControlInfo.currentRabbitButton.transform.FindChild(nightObjName).gameObject.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel_2N;
				}
				
				if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				{
					guiControlInfo.currentRabbitButton.renderer.material.mainTexture = level3Tex;
					
					if (nightObjBool)
						guiControlInfo.currentRabbitButton.transform.FindChild(nightObjName).gameObject.renderer.material.mainTexture = nightObjTex;
				}
				
				if (!halflingBool)
					DarklinGolumDisable();
				
				if(scr_audioController.audio_Scaffolding.isPlaying)
				{
					scr_audioController.audio_Scaffolding.Stop();
				}
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeEarthObelisk(int currentStep)
	{
		// upgrade earth obelisk here
		
		if (currentStep == 1)
		{
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 6 && GameManager.curBuilding.tag == "EarthObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.h_ObeliskContruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeEarthObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objEarthobelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			
			if (tgUpgradePBInfo.currentUpgradeLevel <= 3)
			{
				guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
					
				//accelerate task
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objEarthobelisk.objTypeId);
					scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
				
				
				tgUpgradePBInfo.currentUpgradeLevel++;
				
				if (tgUpgradePBInfo.currentUpgradeLevel == 2)
					guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_EarthObelisk2;
				else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
					guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_EarthObelisk3;
				
				halflinGolumDisable();
				
				if(audio_constructing.isPlaying)
				{
					audio_constructing.Stop();
				}
			}
		}
		
		
		
		
//		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
//		
//		upgradeProgressBar uPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
//		
////		if (uPB.currentUpgradeLevel == 1 && GameManager.gameLevel >=6)
////		{
//			taskBuildingUpgrade(currentStep, 6, "EarthObelisk", true, true, upgradeTextureInfo.h_ObeliskContruction, false, "upgradeEarthObeliskRabbitButton",scr_GameObjSvr.objEarthobelisk.objTypeId,
//								upgradeTextureInfo.h_EarthObelisk2, upgradeTextureInfo.h_EarthObelisk3, false, "", upgradeTextureInfo.h_EarthObelisk);
////		//}
//////		else if (uPB.currentUpgradeLevel == 2 && GameManager.gameLevel >= 7)
//////		{
//////			taskBuildingUpgrade(currentStep, 7, "EarthObelisk", true, true, upgradeTextureInfo.h_ObeliskContruction, false, "upgradeEarthObeliskRabbitButton",scr_GameObjSvr.objEarthobelisk.objTypeId,
//////								upgradeTextureInfo.h_EarthObelisk2, upgradeTextureInfo.h_EarthObelisk3, false, "", upgradeTextureInfo.h_EarthObelisk);
//////		}
////		
							
	}
	
//=======================================================================================================================================
	
	public void taskUpgradePlantObelisk(int currentStep)
	{
		// upgrade earth obelisk here
		
		if (currentStep == 1)
		{
			Debug.Log("------> plant obelisk step 1...");
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 9 && GameManager.curBuilding.tag == "PlantObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.h_ObeliskContruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradePlantObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objPlantObelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			Debug.Log("------> plant obelisk step2...");
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objPlantObelisk.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_PlantObelisk2;
			else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_PlantObelisk3;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}
		
	
//=======================================================================================================================================
	
	public void taskUpgradeWaterObelisk(int currentStep)
	{
		// upgrade water obelisk here
		
		if (currentStep == 1)
		{
			Debug.Log("------> water obelisk step 1...");
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 12 && GameManager.curBuilding.tag == "WaterObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.h_ObeliskContruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeWaterObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objWaterObelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			Debug.Log("------> water obelisk step2...");
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objWaterObelisk.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_WaterObelisk2;
			else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.h_WaterObelisk3;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}
	
	
//=======================================================================================================================================
	
	public void taskUpgradeSwampObelisk(int currentStep)
	{
		// upgrade swamp obelisk here
		
		if (currentStep == 1)
		{
			Debug.Log("------> swamp obelisk step 1...");
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 6 && GameManager.curBuilding.tag == "SwampObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.d_ObeliskConstruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeSwampObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarklingSwampObelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			Debug.Log("------> swamp obelisk step2...");
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingSwampObelisk.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_SwampObelisk2;
			else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_SwampObelisk3;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}
	
	
//=======================================================================================================================================
	
	public void taskUpgradeDEarthObelisk(int currentStep)
	{
		// upgrade d earth obelisk here
		
		if (currentStep == 1)
		{
			Debug.Log("------> d earth obelisk step 1...");
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 9 && GameManager.curBuilding.tag == "DEarthObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.d_ObeliskConstruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDEarthObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarklingEarthObelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			Debug.Log("------> d earth obelisk step2...");
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingEarthObelisk.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_EarthObelisk2;
			else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_EarthObelisk3;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}
	

//=======================================================================================================================================
	
	public void taskUpgradeFireObelisk(int currentStep)
	{
		// upgrade fire obelisk here
		
		if (currentStep == 1)
		{
			Debug.Log("------> fire obelisk step 1...");
			upgradeProgressBar earthObeliskUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 12 && GameManager.curBuilding.tag == "FireObelisk" && earthObeliskUPB.currentUpgradeLevel <= 3)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				halflinGolumEnableObelisksUpgrade();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.d_ObeliskConstruction;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				earthObeliskUPB.progressBarPov.transform.localScale = new Vector3(0.01f, earthObeliskUPB.progressBarPov.transform.localScale.y, earthObeliskUPB.progressBarPov.transform.localScale.z);
				earthObeliskUPB.enabled = true;
				GameManager.upgradeStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDEarthObeliskRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarklingFireObelisk.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			Debug.Log("------> fire obelisk step2...");
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingFireObelisk.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_FireObelisk2;
			else if (tgUpgradePBInfo.currentUpgradeLevel == 3)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_FireObelisk3;
			
			halflinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeDarklingInn(int currentStep)
	{
		if (currentStep == 1)
		{
			
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 8 && GameManager.curBuilding.tag == "DInn")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				darklinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeDInn = false;
				GameManager.curBuilding.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDarklingInnRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarkLingInn.objTypeId;
				StartCoroutine("GetWorld"); 
				
				PlayScaffolding(GameManager.curBuilding.transform.position);
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			guiControlInfo.currentRabbitButton.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarkLingInn.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
			{
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel_2;
				guiControlInfo.currentRabbitButton.transform.FindChild("_DInn_Night").gameObject.renderer.material.mainTexture = upgradeTextureInfo.dInnLevel_2N;
			}
				
			DarklinGolumDisable();
			
			if(scr_audioController.audio_Scaffolding.isPlaying)
			{
				scr_audioController.audio_Scaffolding.Stop();
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeDarklingStable(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 11 && GameManager.curBuilding.tag == "DStable")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				darklinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeDStable = false;
				
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDarklingStableRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarkingStable.objTypeId;
				StartCoroutine("GetWorld"); 
				
				PlayScaffolding(GameManager.curBuilding.transform.position);
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarkingStable.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.d_Stable2;
				
			 			ad.percentComplete29 = 100;
			
			DarklinGolumDisable();
			
			if(scr_audioController.audio_Scaffolding.isPlaying)
			{
				scr_audioController.audio_Scaffolding.Stop();
			}
		}
	}
	
//=======================================================================================================================================
	
	public void taskUpgradeDarklingBlackSmith(int currentStep)
	{
		if (currentStep == 1)
		{
			upgradeProgressBar innUPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.gameLevel >= 11 && GameManager.curBuilding.tag == "DBlackSmith")
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curBuilding.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				darklinGolumEnableUpgradeBuildings();

				GameManager.curBuilding.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
				GameManager.curBuilding.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
				Destroy(GameManager.curBuilding.GetComponent<progressBar>());
				GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				GameManager.curBuilding.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				innUPB.progressBarPov.transform.localScale = new Vector3(0.01f, innUPB.progressBarPov.transform.localScale.y, innUPB.progressBarPov.transform.localScale.z);
				innUPB.enabled = true;
				GameManager.upgradeDBlackSmith = false;
				GameManager.curBuilding.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				GameObject rabbitBut = GameManager.curBuilding.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject;
				rabbitBut.GetComponent<UIButton>().methodToInvoke = "upgradeDarklingBlackSmithRabbitButton";
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = scr_GameObjSvr.objDarklingSmith.objTypeId;
				StartCoroutine("GetWorld"); 
				
				if(audio_constructing != null) //Constructing Audio
				{
					audio_constructing.transform.position = grid.curObj.transform.position;
					audio_constructing.Play();
					audio_constructing.loop = true;
					audio_constructing.minDistance = 10;
					audio_constructing.maxDistance = 20;
				}
			}
		}
		
		// rabbit button
		if (currentStep == 2)
		{
			guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
			guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			guiControlInfo.currentRabbitButton.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
			
			//accelerate task
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingSmith.objTypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
			
			upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			tgUpgradePBInfo.currentUpgradeLevel++;
			
			if (tgUpgradePBInfo.currentUpgradeLevel == 2)
			{
				guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.dBlackSmith2;
				guiControlInfo.currentRabbitButton.transform.FindChild("_DBlackSmith_Night").gameObject.renderer.material.mainTexture = upgradeTextureInfo.dBlackSmith2_N;
			}
				
			DarklinGolumDisable();
			
			if(audio_constructing.isPlaying)
			{
				audio_constructing.Stop();
			}
		}
	}	
	
//=======================================================================================================================================
	private int AcctypeId;
	public bool Isupgrade;
	// Task Upgrade Plot
	public void taskUpgradePlot(int currentStep)
	{	
		if (currentStep == 1)// && GameManager.upgradePlotBool == true)
		{
			upgradeProgressBar plotUPBInfo = GameManager.curPlot.GetComponent("upgradeProgressBar") as upgradeProgressBar;
			
			// upgrade halfling plot level 2
			if (GameManager.gameLevel >= 3 && GameManager.curPlot.tag == "Plot" && plotUPBInfo.currentUpgradeLevel == 1)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curPlot.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				upgradeProgressBar plotUBPInfo = GameManager.curPlot.GetComponent<upgradeProgressBar>();
				plotUBPInfo.progressBarPov.transform.localScale = new Vector3(0, plotUBPInfo.progressBarPov.transform.localScale.y, plotUBPInfo.progressBarPov.transform.localScale.z);
				GameManager.curPlot.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				plotUBPInfo.enabled = true;
				
				GameManager.upgradeHGardenPlotBool = false;
				Transform rabbit = GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		        delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		      
				//upgrade plot sent to server 
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();				
				TempTypeId = ReturnGardenPlotTypeId(GameManager.curPlot.name);
				plotname = GameManager.curPlot.name;
				StartCoroutine("GetWorld"); //Harish chander
			}
			else if (GameManager.gameLevel >= 3 && GameManager.curPlot.tag == "Plot" && plotUPBInfo.currentUpgradeLevel == 2)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curPlot.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
				GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				upgradeProgressBar plotUBPInfo = GameManager.curPlot.GetComponent<upgradeProgressBar>();
				plotUBPInfo.progressBarPov.transform.localScale = new Vector3(0, plotUBPInfo.progressBarPov.transform.localScale.y, plotUBPInfo.progressBarPov.transform.localScale.z);
				GameManager.curPlot.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				plotUBPInfo.enabled = true;
				
				GameManager.upgradeHGardenPlotBool = false;
				Transform rabbit = GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		        delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		      
				//upgrade plot sent to server 
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();				
				TempTypeId = ReturnGardenPlotTypeId(GameManager.curPlot.name);
				plotname = GameManager.curPlot.name;
				StartCoroutine("GetWorld"); //Harish chander
			}
			
			// upgrade darkling plot level 2
			if (GameManager.gameLevel >= 4 && GameManager.curPlot.tag == "DPlot" && plotUPBInfo.currentUpgradeLevel == 1)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curPlot.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				upgradeProgressBar plotUBPInfo = GameManager.curPlot.GetComponent<upgradeProgressBar>();
				plotUBPInfo.progressBarPov.transform.localScale = new Vector3(0, plotUBPInfo.progressBarPov.transform.localScale.y, plotUBPInfo.progressBarPov.transform.localScale.z);
				plotUBPInfo.enabled = true;
				GameManager.curPlot.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		        delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
				GameManager.upgradeHGardenPlotBool = false;
				
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				TempTypeId = ReturnGardenPlotTypeId(GameManager.curPlot.name);
				plotname = GameManager.curPlot.name;
				StartCoroutine("GetWorld"); //Harish chander
			}
			else if (GameManager.gameLevel >= 4 && GameManager.curPlot.tag == "DPlot" && plotUPBInfo.currentUpgradeLevel == 2)
			{
				// upgrade effect
				GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curPlot.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

				GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				upgradeProgressBar plotUBPInfo = GameManager.curPlot.GetComponent<upgradeProgressBar>();
				plotUBPInfo.progressBarPov.transform.localScale = new Vector3(0, plotUBPInfo.progressBarPov.transform.localScale.y, plotUBPInfo.progressBarPov.transform.localScale.z);
				plotUBPInfo.enabled = true;
				GameManager.curPlot.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
				Transform rabbit = GameManager.curPlot.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
				UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		        delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
				GameManager.upgradeHGardenPlotBool = false;
				
				
				Isupgrade = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();			
		        	TempTypeId = ReturnGardenPlotTypeId(GameManager.curPlot.name);
				plotname = GameManager.curPlot.name;
				StartCoroutine("GetWorld"); //Harish chander
			}
		}
		// rabbit button
		if (currentStep == 2)
		{
			if (GameManager.gameLevel >= 3 && guiControlInfo.currentRabbitButton.tag == "Plot")
			{
				guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
				upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
				tgUpgradePBInfo.currentUpgradeLevel++;
				GameManager.plot_lvl++;
				GameManager.upgradePlotBool = false;
				
				//accelerate task		
				AcctypeId = ReturnGardenPlotTypeId(guiControlInfo.currentRabbitButton.name);
				taskidSvr = scr_loadUserWorld.ReturnTaskId(AcctypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
				
				guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
				
			}
			else if (GameManager.gameLevel >= 4 && guiControlInfo.currentRabbitButton.tag == "DPlot")
			{
				guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
				guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
				upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
				tgUpgradePBInfo.currentUpgradeLevel++;
				GameManager.dPlot_lvl++;
				GameManager.upgradePlotBool = false;
				
				//accelerate task
			
				AcctypeId = ReturnGardenPlotTypeId(guiControlInfo.currentRabbitButton.name);
				taskidSvr = scr_loadUserWorld.ReturnTaskId(AcctypeId);
				scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
				
				guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
			}
		}
	}
	
	private string PlantName;
	public string GetPlantName()
	{
		return PlantName;
	}
	
	private string plotname;
	public string GetUpgradePlotName()
	{
		return plotname;
	}
	
	public string GetGardenPlotName()
	{
		return grid.curObj.name.ToString();
	}
//=======================================================================================================================================
	public bool isObjectMove;
	
	public void PlayScaffolding(Vector3 pos)
	{
		scr_audioController.audio_Scaffolding.transform.position = pos;
		scr_audioController.audio_Scaffolding.Play();
		scr_audioController.audio_Scaffolding.minDistance = 1;
		scr_audioController.audio_Scaffolding.maxDistance = 10;
		scr_audioController.audio_Scaffolding.loop = true;
		scr_audioController.audio_Scaffolding.volume = 0.8f;
	}
//=======================================================================================================================================
	
	void createBuilding(int currentStep, GameObject buildObj, bool goldButtonBool, bool smokeBool, 
	                    bool halflingBool, string subCommand, string commandName, string objType, 
	                    string command, int objTypeID, int dPopUpCnt, int dPopUpType, 
	                    Texture buildingTex, bool tavernBool, bool apothecaryBool, 
	                    bool obeliskBool, string cost, Texture scaffHold)
	{
		if (currentStep == 1)
		{
			objGridMove.gridObjSetBool = true;
			GameObject go = Instantiate(buildObj, new Vector3(gameManagerInfo.cam.transform.position.x, 1f, gameManagerInfo.cam.transform.position.z), buildObj.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			// hide object gui button
			if (!obeliskBool)
			{
				go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
				go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			
			if (goldButtonBool)
				go.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
			
			if (tavernBool)
				go.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			
			if (apothecaryBool)
				go.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			
			if (smokeBool)
				go.transform.FindChild("HWgame_ChimneySmoke").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
			
			if (obeliskBool)
			{
				go.transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				go.transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = false;
				go.transform.FindChild("DefenceObeliskIcon").gameObject.SetActiveRecursively(false);
			}
			
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		if (currentStep == 2)
		{
			if (halflingBool)
				GameManager.hBuildingConstructBool = false;
			else
				GameManager.dBuildingConstructBool = false;

			// generate gold cost text
			GameManager.objectCost = cost;
			GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), 
			                                     new Vector3(grid.curObj.transform.position.x, grid.curObj.transform.position.y + 5f, grid.curObj.transform.position.z),
			                                     Quaternion.Euler(90,0,0)) as GameObject;


			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x,  grid.axisY, grid.curObj.transform.position.z);
			
			//if (obeliskBool)
				//grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.h_ObeliskContruction;
			//else
				grid.curObj.renderer.material.mainTexture = scaffHold; //upgradeTextureInfo.constuctionLevel;
			
			grid.curObj.renderer.material.color = new Color(grid.curObj.renderer.material.color.r,
															grid.curObj.renderer.material.color.g,
															grid.curObj.renderer.material.color.b, 1);
			
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			if (halflingBool)
			{
				if (obeliskBool)
					halflinGolumEnableObelisks();
				else
					halflinGolumEnableBuildings();
				grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
			}
			else
			{
				if (obeliskBool)
					darklinGolumEnableObelisks();
				else
					darklinGolumEnableBuildings();
				grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
			}
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
			
			// create rabbit button
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Transform rabbitButton = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
			
			if (goldButtonBool)
			{
				grid.curObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(true);
				Transform goldButt = grid.curObj.transform.FindChild("GoldButton").gameObject.transform.FindChild("Gold") as Transform;
				goldButt.gameObject.GetComponent<UIButton>().scriptWithMethodToInvoke =guiControlInfo;
				grid.curObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
			}
			
			if (tavernBool)
			{
				grid.curObj.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
				Transform beerGame = grid.curObj.transform.FindChild("TavernButton").gameObject.transform.FindChild("Tavern") as Transform;
				UIButton TavernButtonInfo = beerGame.gameObject.GetComponent("UIButton") as UIButton;
				TavernButtonInfo.scriptWithMethodToInvoke = guiControlInfo;	
				grid.curObj.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
			}
			
			if (apothecaryBool)
			{
				grid.curObj.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
				Transform ApothecaryGame = grid.curObj.transform.FindChild("ApothecaryButton").gameObject.transform.FindChild("Apothecary") as Transform;
				UIButton ApothercaryButtonInfo = ApothecaryGame.gameObject.GetComponent("UIButton") as UIButton;
				ApothercaryButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				grid.curObj.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			}
			
			UIButton delObjUIButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;

			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			
			scr_sfsRemoteCnt.SendRequestForBuyItems(subCommand, commandName, objType, command);
			
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = objTypeID; //scr_GameObjSvr.objInn.objTypeId;
			
			PlayScaffolding(grid.curObj.transform.position);
			grid.curObj = null;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
		}
		
		// rabbit popup
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
			defaultPopUp(dPopUpCnt, dPopUpType);
		}
		
		// build Inn using rabbit button
		if (currentStep == 4)
		{
			if (GameManager.sparks >= 1)
			{
				if (halflingBool)
					GameManager.hBuildingConstructBool = true;
				else
					GameManager.dBuildingConstructBool = true;
				
				taskidSvr = scr_loadUserWorld.ReturnTaskId(objTypeID);
			    scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				UpdateScore();
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				GameObject innTemp = guiControlInfo.currentRabbitButton;
				
				innTemp.renderer.material.mainTexture = buildingTex; //upgradeTextureInfo.InnLevel_1;
				
				innTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				if (smokeBool)
					innTemp.transform.FindChild("HWgame_ChimneySmoke").GetComponent<ParticleSystem>().renderer.enabled = true;
				
				if (obeliskBool)
				{
					innTemp.transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
					innTemp.transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().renderer.enabled = true;
					innTemp.transform.FindChild("HWgame_Obelisk").gameObject.transform.FindChild("SubEmitter").gameObject.GetComponent<ParticleSystem>().Play();
					innTemp.transform.FindChild("HWgame_Obelisk").gameObject.GetComponent<ParticleSystem>().Play();
				}
				
				innTemp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				innTemp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				Destroy(innTemp.GetComponent<progressBar>());
				
				if (tavernBool)
					innTemp.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
				
				if (apothecaryBool)
					innTemp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);

				// request for xp
				scr_loadUserWorld.ReturnXPcostTotal(objTypeID, innTemp);

				if (goldButtonBool)
					GoldProducingBuildings();
				
				if (halflingBool)
					halflinGolumDisable();
				else
					DarklinGolumDisable();
				
				if(scr_audioController.audio_Scaffolding.isPlaying)
				{
					scr_audioController.audio_Scaffolding.Stop();
				}
			}
		}
	}
	
//=======================================================================================================================================	
	
	// Task Build Inn
	public void taskBuildInn(int currentStep)
	{
		// create Inn
		createBuilding(currentStep, guiControlInfo.innGO, true, true, true, "3", "buildingType", 
						scr_GameObjSvr.objInn.objname, "2", scr_GameObjSvr.objInn.objTypeId, 5, 2, 
						upgradeTextureInfo.InnLevel_1, false, false, false, 
		               scr_ObjectCost.innCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.constuctionLevel);
		
	}
	
//=======================================================================================================================================
	
	// Task Build Sun Shrine
	public void taskBuildSunShrine(int currentStep)
	{
		// create Sun Shrine
		if (currentStep == 1)
		{
			GameObject go = Instantiate(gameManagerInfo.h_SunShrine_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.innGO.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		// place Sun Shrine
		if (currentStep == 2)
		{
			GameManager.hBuildingConstructBool = false;
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
				
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
						
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			halflinGolumEnableObelisks();
						
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
			
			// create rabbit button
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Transform rabbitButton = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType",scr_GameObjSvr.objSunshrine.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objSunshrine.objTypeId;
				
			grid.curObj = null;
			
			inventoryInfo.RemoveItem(taskDetailsInfo.Twelve_Half_task3);
			taskDetailsInfo.Twelve_Half_task3_bool =true;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
		}
		
		// rabbit popup
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
				defaultPopUp(5, 2);
		}
		
		// build SunShrine using rabbit button
		if (currentStep == 4)
		{
			if (GameManager.sparks >= 1)
			{
				GameManager.hBuildingConstructBool = true;	
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objSunshrine.objTypeId);
			    scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				UpdateScore();
				
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				GameObject earthObeliskTemp = guiControlInfo.currentRabbitButton;
				earthObeliskTemp.renderer.material.mainTexture = upgradeTextureInfo.h_SunShrine;
				earthObeliskTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
								
				Destroy(earthObeliskTemp.GetComponent<progressBar>());
				Destroy(earthObeliskTemp.transform.FindChild("ProgressBar").gameObject);
				Destroy(earthObeliskTemp.transform.FindChild("RabbtiButton").gameObject);
				
				earthObeliskTemp.gameObject.GetComponent<getXP>().xpAnimBool = true;
				earthObeliskTemp.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				ShrineBuildings();
				halflinGolumDisable();
			}
		}
	}	
	
	
//=======================================================================================================================================
	
	// Task Build Earth Obelisk
	public void taskBuildEarthObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.h_EarthObelisk_PF, false, false, true, "3", "buildingType",
						scr_GameObjSvr.objEarthobelisk.objname, "2", scr_GameObjSvr.objEarthobelisk.objTypeId,
						5, 2, upgradeTextureInfo.h_EarthObelisk, false, false, true,
		               scr_ObjectCost.earthObeliskCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.h_ObeliskContruction);


	}
	
//=======================================================================================================================================
	
	// Task Build Plant Obelisk
	public void taskBuildPlantObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.h_PlantObelisk_PF, false, false, true, "3", "buildingType",
						scr_GameObjSvr.objPlantObelisk.objname, "2", scr_GameObjSvr.objPlantObelisk.objTypeId,
						5, 2, upgradeTextureInfo.h_PlantObelisk, false, false, true,
		               scr_ObjectCost.plantObeliskCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.h_ObeliskContruction);
		
		if (currentStep == 2)
		{
			inventoryInfo.RemoveItem(taskDetailsInfo.Nine_Half_task3);
			taskDetailsInfo.Nine_Half_task3_bool = true;
		}
	}
	
//=======================================================================================================================================
	
	// Task Build Water Obelisk
	public void taskBuildWaterObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.h_WaterObelisk_PF, false, false, true, "3", "buildingType",
						scr_GameObjSvr.objWaterObelisk.objname, "2", scr_GameObjSvr.objWaterObelisk.objTypeId,
						5, 2, upgradeTextureInfo.h_WaterObelisk, false, false, true,
		               scr_ObjectCost.waterObeliskCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.h_ObeliskContruction);
		
		if (currentStep == 2)
		{
			inventoryInfo.RemoveItem(taskDetailsInfo.Eleven_Half_task2);
			taskDetailsInfo.Eleven_Half_task2_bool = true;
		}
	}

	
//=======================================================================================================================================
	
	// Task Build Stable
	public void taskBuildStable(int currentStep)
	{
		//createBuilding(currentStep, gameManagerInfo.h_Stable_PF, true, false, true, "3", "buildingType", scr_GameObjSvr.objHalflingStable.objname, "2", scr_GameObjSvr.objHalflingStable.objTypeId, 5, 2, upgradeTextureInfo.h_Stable1);
		
		createBuilding(currentStep, gameManagerInfo.h_Stable_PF, true, false, true, "3", "buildingType", 
						scr_GameObjSvr.objHalflingStable.objname, "2", scr_GameObjSvr.objHalflingStable.objTypeId,
						5, 2, upgradeTextureInfo.h_Stable1, false, false, false,
		               scr_ObjectCost.stableCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.constuctionLevel);
		
		if (currentStep == 2)
		{
			// remove item from task list
			inventoryInfo.RemoveItem(taskDetailsInfo.Five_Half_task3);
			taskDetailsInfo.Five_Half_task3_bool = true;
		}
	}
	
//=======================================================================================================================================
	

	// Task Build BlackSmith
	public void taskBuildBlackSmith(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.h_BlackSmith_PF, true, true, true, "3", "buildingType", 
						scr_GameObjSvr.objBlackSmith.objname, "2", scr_GameObjSvr.objBlackSmith.objTypeId, 
						5, 2, upgradeTextureInfo.h_BlackSmith, false, false, false,
		               scr_ObjectCost.blacksmithCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.constuctionLevel);
		
		if (currentStep == 2)
		{
			// remove item from task list
			inventoryInfo.RemoveItem(taskDetailsInfo.Six_Half_task3);
			taskDetailsInfo.Six_Half_task3_bool = true;
		}
	}
	
//=======================================================================================================================================
	
	// Task Build Apothecary
	public void taskBuildApothecary(int currentStep)
	{
		// create Apothecary
		if (currentStep == 1)
		{
			GameObject go = Instantiate(gameManagerInfo.h_Apothecary_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Stable_PF.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
		
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			//guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		// place Apothecary
		if (currentStep == 2)
		{
			GameManager.hBuildingConstructBool = false;
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
			
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
			grid.curObj.renderer.material.color = new Color(grid.curObj.renderer.material.color.r,
															grid.curObj.renderer.material.color.g,
															grid.curObj.renderer.material.color.b, 1);
			
			//grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			halflinGolumEnableBuildings();
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			//grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "working";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
			
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType",scr_GameObjSvr.objApothecary.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objApothecary.objTypeId;
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
			
			// create rabbit button
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Transform rabbitButton = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			// attach guiControl script to rabbit ui button
			//Transform rabbit = rabbitButton.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			
			Transform ApothecaryGame = grid.curObj.transform.FindChild("ApothecaryButton").gameObject.transform.FindChild("Apothecary") as Transform;
			UIButton ApothercaryButtonInfo = ApothecaryGame.gameObject.GetComponent("UIButton") as UIButton;
			ApothercaryButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			PlayScaffolding(grid.curObj.transform.position);
			
			grid.curObj = null;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
			
			inventoryInfo.RemoveItem(taskDetailsInfo.Ten_Half_task3);
			taskDetailsInfo.Ten_Half_task3_bool = true;
		
			
		
		}
		
		// rabbit popup
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
				defaultPopUp(5, 2);
		}
		
		// build Apothecary using rabbit button
		if (currentStep == 4)
		{
			if (GameManager.sparks >= 1)
			{
				GameManager.hBuildingConstructBool = true;
				scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objApothecary.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				UpdateScore();
				//GameManager.sparks = GameManager.sparks - 1;
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				GameObject innTemp = guiControlInfo.currentRabbitButton;
				innTemp.renderer.material.mainTexture = upgradeTextureInfo.h_Apothecary;
				innTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				innTemp.renderer.material.color = new Color(innTemp.renderer.material.color.r,
															innTemp.renderer.material.color.g,
															innTemp.renderer.material.color.b, 1);
				
				Destroy(innTemp.GetComponent<progressBar>());
				innTemp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				innTemp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				innTemp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
				
				innTemp.gameObject.GetComponent<getXP>().xpAnimBool = true;
				innTemp.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
				
				 				ad.percentComplete23 =100;
				halflinGolumDisable();
				
				if(scr_audioController.audio_Scaffolding.isPlaying)
				{
					scr_audioController.audio_Scaffolding.Stop();
				}
			}
		}
	}
	
//=======================================================================================================================================
	
	// Task Build Tavern
	public void taskBuildTavern(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.h_Tavern_PF, false, false, true, "3", "buildingType",
						scr_GameObjSvr.objTavern.objname, "2", scr_GameObjSvr.objTavern.objTypeId, 5, 2,
						upgradeTextureInfo.h_Tavern, true, false, false,
		               scr_ObjectCost.tavernCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.constuctionLevel);
		
		if (currentStep == 2)
		{
			// remove item from task list
			inventoryInfo.RemoveItem(taskDetailsInfo.Nine_Half_task2);
			taskDetailsInfo.Nine_Half_task2_bool =true;
		}
	}
	
//=======================================================================================================================================
	
	public bool quest2StoryBool = false;
	
	// Task Unlock Darkling Map
	public void taskUnlockDarklingSide(int currentStep)
	{
		/*if (currentStep == 1)
		{
			if (GameManager.sparks >= 25)
			{
				Debug.Log("Darkling is unlocked.......... :)");
				quest2StoryBool = true;
				GameManager.questRunningBool = true;
				UpdateScore();
				//GameManager.sparks = GameManager.sparks - 25;
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				//GameManager.xp = GameManager.xp + 100;
				GameObject bridge = GameObject.Find("BridgeBroken_GO") as GameObject;
				bridge.renderer.material.mainTexture = upgradeTextureInfo.bridgeTex;
				GameObject go = GameObject.Find("bridgeCollider") as GameObject;
				if (go.active == true)
					go.active = false;
				CameraControl.newArea = 0;//158.5f;
				gameManagerInfo.dialogCnt = 0;
				gameManagerInfo.questA = true;
				//GameManager.unlockDarklingBool = true;
				LevelControl levelControlInfo = GameObject.Find("GameManager").GetComponent("LevelControl") as LevelControl;
				
				GameObject.Find("Main Camera").transform.position = GameObject.Find("darklingHouse_cPos").transform.position;
				
				scr_sfsRemoteCnt.SendPlayQuestCount((int)GameObjectsSvr.QuestNo.Quest2); //Quest Activation 2
				TempTypeId = scr_GameObjSvr.QuestCreation.objTypeId;
				ad.percentComplete8 = 100;
				
				guiControlInfo.EnableDarkling(guiControlInfo.DarklingUIbtn,true);
			}
		}*/
	}

//=======================================================================================================================================
	public int TempTypeId;
	// Task Upgrade Halfling training ground
	public void taskUpgradeTrainingGround(int currentStep)
	{
		if (GameManager.upgradeTrainingGroundBool)
		{
			GameManager.upgradeTrainingGroundBool = false;
			if (currentStep == 1)
			{
				//Debug.Log("I m here ha a aha ah.................");
				// Upgrade Training Ground
				if (GameManager.curTG.tag == "TrainingGround")
				{
					// upgrade earth training ground on level 4
					if (GameManager.gameLevel >= 4 && GameManager.earthTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						//Debug.Log("444444444444444444444444444444444444444444444");
						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
						//upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						// remove item from task list
						inventoryInfo.RemoveItem(taskDetailsInfo.Four_Half_task1);
						taskDetailsInfo.Four_Half_task1_bool = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
				        
					}
					// Upgrade earth training ground on level 8
					else if (GameManager.gameLevel >= 8 && GameManager.curTG.tag == "TrainingGround" && GameManager.earthTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						//Debug.Log("55555555555555555555555555555555555");
						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
//						upgradePBInfo.progressBar.renderer.enabled = true;
						
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
				
				// Upgrade Plant Training Ground
				else if (GameManager.curTG.tag == "PlantTG")
				{
					if (GameManager.gameLevel >= 6 && GameManager.plantTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
					//	upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objPlantTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
					else if (GameManager.gameLevel >= 9 && GameManager.plantTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
					//	upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objPlantTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
				
				// Upgrade Water Training Ground
				else if (GameManager.curTG.tag == "WaterTG")
				{
					if (GameManager.gameLevel >= 8 && GameManager.waterTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
						//upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objWaterTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
					else if (GameManager.gameLevel >= 12 && GameManager.waterTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
					//	upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
							//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objWaterTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
				
				// Upgrade Swamp Training Ground
				else if (GameManager.curTG.tag == "Swamp")
				{
					if (GameManager.gameLevel >= 7 && GameManager.swampTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
						//upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objSwampTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
					else if (GameManager.gameLevel >= 12 && GameManager.swampTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
						//upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objSwampTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
				
				// Upgrade Fire Training Ground
				else if (GameManager.curTG.tag == "DFireTG")
				{
					//Debug.Log("Upgrade TG :: GameManager.curTG.tag == DFireTG...");
					if (GameManager.gameLevel >= 9 && GameManager.fireTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						//Debug.Log("Upgrade TG :: GameManager.gameLevel >= 9 && GameManager.fireTG_lvl == 1");
						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
//						upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
					else if (GameManager.gameLevel >= 14 && GameManager.fireTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
						//upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
				
				// Upgrade DEarth Training Ground
				else if (GameManager.curTG.tag == "DEarthTG")
				{
					if (GameManager.gameLevel >= 8 && GameManager.dEarthTG_lvl == 1)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
//						upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
					else if (GameManager.gameLevel >= 13 && GameManager.dEarthTG_lvl == 2)
					{
						// upgrade effect
						GameObject eff = Instantiate(gameManagerInfo.par_ObjectUpgrade_PF, GameManager.curTG.transform.position, Quaternion.Euler(0,0,0)) as GameObject;

						GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
						GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
						GameManager.curTG.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
						upgradeProgressBar upgradePBInfo = GameManager.curTG.GetComponent<upgradeProgressBar>();
						upgradePBInfo.progressBarPov.transform.localScale = new Vector3(0, upgradePBInfo.progressBarPov.transform.localScale.y, upgradePBInfo.progressBarPov.transform.localScale.z);
					//	upgradePBInfo.progressBar.renderer.enabled = true;
						GameManager.curTG.GetComponent<upgradeProgressBar>().enabled = true;
						
						//sent to server
						Isupgrade = true;
						scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
						TempTypeId = scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId;
						StartCoroutine("GetWorld");
					}
				}
			}
		
			// rabbit button
			if (currentStep == 2)
			{
				//Debug.Log("Upgrade Rabbit button execute check spark...");
				if (GameManager.sparks >= 1)
				{
					//Debug.Log("Upgrade Rabbit button execute...");
					UpdateScore();
					//GameManager.sparks = GameManager.sparks - 1;
					guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
					
					//  Earth Training Ground Upgrade using rabbit button
					if (guiControlInfo.currentRabbitButton.tag == "TrainingGround")
					{
						if (GameManager.gameLevel >= 4 && GameManager.earthTG_lvl == 1)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
							
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.earthTG2;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.earthTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
							
							//Debug.Log("Task killed >>>>>>>>>>>>>>>>> :" + taskidSvr);
							
						}
						
						if (GameManager.gameLevel >= 8 && GameManager.earthTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.earthTG3;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.earthTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
							
							
							
						}
					}
					
					// Plant Trainging Ground Upgrade using rabbit button
					else if (guiControlInfo.currentRabbitButton.tag == "PlantTG")
					{
						//Debug.Log("Plant TG Upgrade Rabbit is exicute...");
						if (GameManager.gameLevel >= 6 && GameManager.plantTG_lvl == 1)
						{
							//Debug.Log("Plant TG Upgrade Rabbit is exicuted and complete...");
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.plantTG2;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.plantTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objPlantTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
						else if (GameManager.gameLevel >= 9 && GameManager.plantTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.plantTG3;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.plantTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objPlantTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
					}
					
					// Water Training Ground Upgrade using rabbit button
					if (guiControlInfo.currentRabbitButton.tag == "WaterTG")
					{
						if (GameManager.gameLevel >= 8 && GameManager.waterTG_lvl == 1)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.waterTG2;
							guiControlInfo.currentRabbitButton.transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.waterTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objWaterTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
							
						}
						else if (GameManager.gameLevel >= 12 && GameManager.waterTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.waterTG3;
							guiControlInfo.currentRabbitButton.transform.FindChild("waterTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("waterTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("waterTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.waterTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objWaterTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
							
						}
					}
					
					// Swamp Training Groound Upgrade using rabbit button
					if (guiControlInfo.currentRabbitButton.tag == "Swamp")
					{
						if (GameManager.gameLevel >= 7 && GameManager.swampTG_lvl == 1)
						{
							//Debug.Log("Swamp TG Upgrade Rabbit button Execute...");
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.swampTG2;
							guiControlInfo.currentRabbitButton.transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.swampTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objSwampTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
						else if (GameManager.gameLevel >= 12 && GameManager.swampTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.swampTG3;
							guiControlInfo.currentRabbitButton.transform.FindChild("swampTG01_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("swampTG02_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("swampTG03_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.swampTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objSwampTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
					}
					
					// Fire Training Ground Upgrade using rabbit button
					if (guiControlInfo.currentRabbitButton.tag == "DFireTG")
					{
						if (GameManager.gameLevel >= 9 && GameManager.fireTG_lvl == 1)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.fireTG2;
							guiControlInfo.currentRabbitButton.transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.fireTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
						else if (GameManager.gameLevel >= 14 && GameManager.fireTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.fireTG3;
							guiControlInfo.currentRabbitButton.transform.FindChild("FireTG01_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("FireTG02_Anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("FireTG03_Anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.fireTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingFireTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
					}
					
					// DEarth Training Ground Upgrade using rabbit button
					if (guiControlInfo.currentRabbitButton.tag == "DEarthTG")
					{
						if (GameManager.gameLevel >= 8 && GameManager.dEarthTG_lvl == 1)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG2;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.dEarthTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
						else if (GameManager.gameLevel >= 13 && GameManager.dEarthTG_lvl == 2)
						{
							guiControlInfo.currentRabbitButton.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit").gameObject.active = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
							guiControlInfo.currentRabbitButton.GetComponent<upgradeProgressBar>().enabled = false;
							guiControlInfo.currentRabbitButton.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
							guiControlInfo.currentRabbitButton.renderer.material.mainTexture = upgradeTextureInfo.dEarthTG3;
							
							upgradeProgressBar tgUpgradePBInfo = guiControlInfo.currentRabbitButton.GetComponent("upgradeProgressBar") as upgradeProgressBar;
							tgUpgradePBInfo.currentUpgradeLevel++;
							GameManager.dEarthTG_lvl++;
							GameManager.upgradeTrainingGroundBool = false;
							
							//accelerate task
							scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
							taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarkearthTrainingGrnd.objTypeId);
							scr_sfsRemoteCnt.AccelerateUpgradeObjectLevel(taskidSvr);
						}
					}
				}
			}
		}
	}
	
	
//=======================================================================================================================================
	private string darklinggardenplotObjname;
	
	// Task Darkling Garden Plot
	public void taskDarklingPlot(int currentStep)
	{
		if (currentStep == 1)
		{
			objGridMove.gridObjSetBool = true;
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;
		
			GameObject go = Instantiate(gameManagerInfo.d_Plot_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.farmPlot.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			cnDGrnd++;
			go.name = go.name + "_" +cnDGrnd ;

			//Debug.Log("DName : " + go.name);
			
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			upgradeProgressBar plotUBPInfo = go.GetComponent<upgradeProgressBar>();
			//plotUBPInfo.progressBar.renderer.enabled = false;
			plotUBPInfo.enabled = false;
			
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
					
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		if (currentStep == 2)
		{
			GameManager.placeDGardenPlotBool = false;
			
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
			
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
		
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
							
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
		
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
		
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
							
				//task sent to server by harish  
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();	
				
				
			darklinggardenplotObjname = ReturnGardenNameSvr(grid.curObj.name);
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType", darklinggardenplotObjname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			
			grid.curObj = null;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;
			
			GameManager.placeDPlotCnt++;
			if(GameManager.gameLevel >= 4 && DarkPlotFour == false)
			{
			inventory1Info.RemoveItem1(taskDetailsInfo.Four_Dark_task2);
			taskDetailsInfo.Four_Dark_task2_bool =true;
				DarkPlotFour = true;
			}
			if(GameManager.gameLevel >= 4 && DarkPlotSeven == false)
			{
			inventory1Info.RemoveItem1(taskDetailsInfo.Seven_Dark_task1);
			taskDetailsInfo.Seven_Dark_task1_bool =true;
				DarkPlotSeven =true;
			}
			if(GameManager.gameLevel >= 10 && DarkPlotTen == false)
			{
				inventory1Info.RemoveItem1(taskDetailsInfo.Ten_Dark_task1 );
				taskDetailsInfo.Ten_Dark_task1_bool =true;
				DarkPlotTen =true;
			}
			if(GameManager.gameLevel >= 13 && DarkPlotThirteen == false)
			{
				inventory1Info.RemoveItem1(taskDetailsInfo.Thirteen_Dark_task2);
				taskDetailsInfo.Thirteen_Dark_task2_bool =true;
				DarkPlotThirteen = true;
			}
		}
	}

//=======================================================================================================================================
	
	// task darkling Inn
	public void taskDarklingInn(int currentStep)
	{
		// create Inn
		
		//createBuilding(currentStep, gameManagerInfo.d_Inn_PF, true, true, false, "3", "buildingType", scr_GameObjSvr.objDarkLingInn.objname, "2", scr_GameObjSvr.objDarkLingInn.objTypeId, 5, 2, upgradeTextureInfo.dInnLevel1);
		createBuilding(currentStep, gameManagerInfo.d_Inn_PF, true, true, false, "3", "buildingType", 
						scr_GameObjSvr.objDarkLingInn.objname, "2", scr_GameObjSvr.objDarkLingInn.objTypeId, 
						5, 2, upgradeTextureInfo.dInnLevel1, false, false, false,
		               scr_ObjectCost.dInnCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_constructionLevel);
		
		if (currentStep == 2)
		{
			//----- dont remove 
			GameManager.placeDInn01Cnt++;
			
			// remove item from task list
			inventory1Info.RemoveItem1(taskDetailsInfo.Four_Dark_task1);
			taskDetailsInfo.Four_Dark_task1_bool = true;
			//----- dont remove
		}
	}
	
//=======================================================================================================================================
	
	// task darkling Moon Shrine
	public void taskDarklingMoonShrine(int currentStep)
	{
		// create Inn
		if (currentStep == 1)
		{
			GameObject go = Instantiate(gameManagerInfo.d_MoonShrine_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), guiControlInfo.innGO.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
		
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		// place D Moon Shrine
		if (currentStep == 2)
		{
			GameManager.dBuildingConstructBool = false;
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
				
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
			
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			darklinGolumEnableObelisks();
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			//grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
			
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
			
			// create rabbit button
			Transform rabbitButton = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType",scr_GameObjSvr.objMoonShrine.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objMoonShrine.objTypeId;
				
			grid.curObj = null;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
			
		}
		
		// rabbit popup
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
				defaultPopUp(5, 2);
		}
		
		// build D Moon Shrine using rabbit button
		if (currentStep == 4)
		{
			if (GameManager.sparks >= 1)
			{
				GameManager.dBuildingConstructBool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objMoonShrine.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				UpdateScore();
				
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				GameObject dEarthObeliskTemp = guiControlInfo.currentRabbitButton;
				dEarthObeliskTemp.renderer.material.mainTexture = upgradeTextureInfo.d_MoonShrine;
				dEarthObeliskTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				Destroy(dEarthObeliskTemp.GetComponent<progressBar>());
				Destroy(dEarthObeliskTemp.transform.FindChild("ProgressBar").gameObject);
				Destroy(dEarthObeliskTemp.transform.FindChild("RabbtiButton").gameObject);
				
				dEarthObeliskTemp.gameObject.GetComponent<getXP>().xpAnimBool = true;
				dEarthObeliskTemp.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
				ShrineBuildings();
				DarklinGolumDisable();
			}
		}
	}

	
//=======================================================================================================================================
	
	// task darkling Earth Obelisk
	public void taskDarklingEarthObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_EarthObelisk_PF, false, false, false, "3", "buildingType",
						scr_GameObjSvr.objDarklingEarthObelisk.objname, "2", scr_GameObjSvr.objDarklingEarthObelisk.objTypeId,
						5, 2, upgradeTextureInfo.d_EarthObelisk, false, false, true,
		               scr_ObjectCost.dEarthObeliskCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_ObeliskConstruction);
		
	}

//=======================================================================================================================================
	
	// task darkling Swamp Obelisk
	public void taskDarklingSwampObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_SwampObelisk_PF, false, false, false, "3", "buildingType",
						scr_GameObjSvr.objDarklingSwampObelisk.objname, "2", scr_GameObjSvr.objDarklingSwampObelisk.objTypeId,
						5, 2, upgradeTextureInfo.d_SwampObelisk, false, false, true,
		               scr_ObjectCost.dSwampCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_ObeliskConstruction);
		
	}
	
//=======================================================================================================================================
	
	// task darkling Fire Obelisk
	public void taskDarklingFireObelisk(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_FireObelisk_PF, false, false, false, "3", "buildingType",
						scr_GameObjSvr.objDarklingFireObelisk.objname, "2", scr_GameObjSvr.objDarklingFireObelisk.objTypeId,
						5, 2, upgradeTextureInfo.d_FireObelisk, false, false, true,
		               scr_ObjectCost.dFireObeliskCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_ObeliskConstruction);
		
		
		if (currentStep == 2)
		{
			inventory1Info.RemoveItem1(taskDetailsInfo.Eleven_Dark_task3);
			taskDetailsInfo.Eleven_Dark_task3_bool =true;
		}
	}

	
//=======================================================================================================================================	
	
	// task darkling Stable
	public void taskDarklingStable(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_DStable_PF, true, false, false, "3", "buildingType", 
					scr_GameObjSvr.objDarkingStable.objname, "2", scr_GameObjSvr.objDarkingStable.objTypeId, 
					5, 2, upgradeTextureInfo.d_Stable1, false, false, false,
		               scr_ObjectCost.dStableCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_constructionLevel);
		
		if (currentStep == 2)
		{
			inventory1Info.RemoveItem1(taskDetailsInfo.Five_Dark_task3);
			taskDetailsInfo.Five_Dark_task3_bool = true;
			
			GameManager.placeDStableCnt++;
		}
	}
	
//=======================================================================================================================================
	
	// task darkling BlackSmith
	public void taskDarklingBlackSmith(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_BlackSmith_PF, true, true, false, "3", "buildingType", 
						scr_GameObjSvr.objDarklingSmith.objname, "2", scr_GameObjSvr.objDarklingSmith.objTypeId, 
						5, 2, upgradeTextureInfo.d_BlackSmith, false, false, false,
		               scr_ObjectCost.dBlackSmithCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_constructionLevel);
		
		if (currentStep == 2)
		{
			inventory1Info.RemoveItem1(taskDetailsInfo.Six_Dark_task4);
			taskDetailsInfo.Six_Dark_task4_bool =true;
			
			GameManager.placeDStableCnt++;
		}
	}
	
//=======================================================================================================================================
	
	// task darkling Tavern
	public void taskDarklingTavern(int currentStep)
	{
		createBuilding(currentStep, gameManagerInfo.d_Tavern_PF, false, false, false, "3", "buildingType",
						scr_GameObjSvr.objDarklingtavern.objname, "2", scr_GameObjSvr.objDarklingtavern.objTypeId,
						5, 2, upgradeTextureInfo.d_Tavern, true, false, false,
		               scr_ObjectCost.dTavernCost.GetComponent<SpriteText>().Text, upgradeTextureInfo.d_constructionLevel);
		
		if (currentStep == 2)
			GameManager.placeDStableCnt++;
		
	}
	
//=======================================================================================================================================
	
	// task darkling Apothecary
	public void taskDarklingApothecary(int currentStep)
	{
		// create Stable
		if (currentStep == 1)
		{
			GameObject go = Instantiate(gameManagerInfo.d_Apothecary_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_DStable_PF.transform.rotation) as GameObject;
			guiControlInfo.curObj = go;
			
			
			go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
			go.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
			
			Transform tempObjUI = guiControlInfo.curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			
		
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			//guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			wall.active = false;
			guiControlInfo.storeUI.SetActiveRecursively(false);
			guiControlInfo.decorationUI.SetActiveRecursively(false);
		
			grid.placeButtonBool = true;
			grid.curObj = go;
		}
		
		// place Inn
		if (currentStep == 2)
		{
			GameManager.dBuildingConstructBool = false;
			Sensors.sensorWorkBool = false;
			GameManager.placeObjectBool = false;
			
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			grid.curObj.renderer.material.mainTexture = upgradeTextureInfo.constuctionLevel;
			grid.curObj.renderer.material.color = new Color(grid.curObj.renderer.material.color.r,
															grid.curObj.renderer.material.color.g,
															grid.curObj.renderer.material.color.b, 1);
			
			grid.curObj.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
			
			darklinGolumEnableBuildings();
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			//grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "Dworking";
			
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
				
										
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
				
			grid.curCol.tag = "editableObj";
			
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3","buildingType",scr_GameObjSvr.objDarklingApothecary.objname,"2");
			//SendPos = grid.curObj.transform.position;
			SendPos = GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			SendRot = new Vector3(0,180,0);
			TempTypeId = scr_GameObjSvr.objDarklingApothecary.objTypeId;
				
				
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			tempUI.gameObject.SetActiveRecursively(false);
				
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			Sensors.sensorWorkBool = false;
						
			progressBar innProgressBar = grid.curObj.GetComponent("progressBar") as progressBar;
			innProgressBar.enabled = true;
			
			// create rabbit button
			grid.curObj.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			Transform rabbitButton = grid.curObj.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
			// attach guiControl script to rabbit ui button
			//Transform rabbit = rabbitButton.FindChild("Rabbit") as Transform;
		
			UIButton delObjUIButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
			
			Transform darklingApothecaryGame = grid.curObj.transform.FindChild("ApothecaryButton").gameObject.transform.FindChild("Apothecary") as Transform;
			UIButton darklingApothercaryButtonInfo = darklingApothecaryGame.gameObject.GetComponent("UIButton") as UIButton;
			darklingApothercaryButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			PlayScaffolding(grid.curObj.transform.position);
			grid.curObj = null;
			
			// hide object panel menu
			objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;	
			
			GameManager.placeDStableCnt++;
			
			inventory1Info.RemoveItem1(taskDetailsInfo.Ten_Dark_task3 );
			taskDetailsInfo.Ten_Dark_task3_bool =true;
			
			
		}
		
		// rabbit popup
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
				defaultPopUp(5, 2);
		}
		
		// build Inn using rabbit button
		if (currentStep == 4)
		{
			if (GameManager.sparks >= 1)
			{
				GameManager.dBuildingConstructBool = true;
				taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objDarklingApothecary.objTypeId);
				scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
				
				UpdateScore();
				//GameManager.sparks = GameManager.sparks - 1;
				guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
				
				GameObject innTemp = guiControlInfo.currentRabbitButton;
				innTemp.renderer.material.mainTexture = upgradeTextureInfo.d_Apothecary;
				innTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
				innTemp.renderer.material.color = new Color(innTemp.renderer.material.color.r,
															innTemp.renderer.material.color.g,
															innTemp.renderer.material.color.b, 1);
				
				Destroy(innTemp.GetComponent<progressBar>());
				innTemp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				innTemp.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
				innTemp.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
				
				innTemp.gameObject.GetComponent<getXP>().xpAnimBool = true;
				innTemp.transform.FindChild("xpValue").gameObject.GetComponent<MeshRenderer>().enabled = true;
							
				DarklinGolumDisable();
				
				if(scr_audioController.audio_Scaffolding.isPlaying)
				{
					scr_audioController.audio_Scaffolding.Stop();
				}
			}
		}
	}
	
//=======================================================================================================================================
	
	
	// Task darkling Farming
	public void taskDarklingFarming(int currentStep, string farmName)
	{
		
		if (currentStep == 1)
		{
			// find empty Garden plot
			foreach(GameObject plot in GameObject.FindGameObjectsWithTag("DPlot"))
			{
    			if(plot.name == "DPlot")
    			{
					if (GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "using")
					{
       			 		if(plot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
							GameManager.curPlot = plot;
					}
    			}
			}
			
			if (farmName == "DPumpkin" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_Pumpkin_PF, scr_GameObjSvr.objDarklingPumpkin.objname, scr_GameObjSvr.objDarklingPumpkin.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Four_Dark_task3);
				taskDetailsInfo.Four_Dark_task3_bool =true;
	
			}
			
			// Fire Pepper
			if (farmName == "DFirePepper" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_FirePepper_PF, scr_GameObjSvr.objDarklingFirePepper.objname, scr_GameObjSvr.objDarklingFirePepper.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Five_Dark_task4);
				taskDetailsInfo.Five_Dark_task4_bool =true;
			}
			
			// Columbine
			if (farmName == "DColumbine" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_Columbine_PF, scr_GameObjSvr.objDarklingColumbine.objname, scr_GameObjSvr.objDarklingColumbine.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Eleven_Dark_task1);
				taskDetailsInfo.Eleven_Dark_task1_bool =true;
			}
			
			// BlackBerry
			if (farmName == "DBlackBerry" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_BlackBerry_PF, scr_GameObjSvr.objDarklingBlackberry.objname, scr_GameObjSvr.objDarklingBlackberry.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Ten_Dark_task2);
				taskDetailsInfo.Ten_Dark_task2_bool = true;
				
			}
			
			// Aven
			if (farmName == "DAven" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_Aven_PF, scr_GameObjSvr.objDarklingAvenHerb.objname, scr_GameObjSvr.objDarklingAvenHerb.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Seven_Dark_task2);
				taskDetailsInfo.Seven_Dark_task2_bool =true;
			}
			// Darkling Bitter Bush
			if (farmName == "BitterBrush" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_BitterBush_PF, scr_GameObjSvr.objDarklingBitterbush.objname, scr_GameObjSvr.objDarklingBitterbush.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Twelve_Dark_task2);
				taskDetailsInfo.Twelve_Dark_task2_bool =true;
			}
			
			// Darkling BogBean
			if (farmName == "BogBean" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_BogBean_PF, scr_GameObjSvr.objDarklingHerbBogbean.objname, scr_GameObjSvr.objDarklingHerbBogbean.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Thirteen_Dark_task3);
				taskDetailsInfo.Thirteen_Dark_task3_bool =true;
			}
			
			// Darkling Wolfsbane
			if (farmName == "Wolfsbane" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_Wolfsbane_PF, scr_GameObjSvr.objDarklingHerbWolfbane.objname, scr_GameObjSvr.objDarklingHerbWolfbane.objTypeId);
				
				inventory1Info.RemoveItem1(taskDetailsInfo.Fourteen_Dark_task2);
				taskDetailsInfo.Fourteen_Dark_task2_bool =true;
			}
			
			// Darkling Moonflower
			if (farmName == "MoonFlower" && GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
			{
				Farming(gameManagerInfo.d_Moonflower_PF, scr_GameObjSvr.objDarklingMoonFlower.objname, scr_GameObjSvr.objDarklingMoonFlower.objTypeId);
				
			}
			
			scr_audioController.audio_plantCrop.transform.position = GameManager.curPlot.transform.position;
			scr_audioController.audio_plantCrop.Play();
			scr_audioController.audio_plantCrop.volume = 0.7f;
			scr_audioController.audio_plantCrop.minDistance = 1;
			scr_audioController.audio_plantCrop.maxDistance = 20;
		}
		
		if (currentStep == 2)
		{
			if (farmName == "tempDFarm")
			{
				defaultPopUpBool = true;
				defaultPopUp(2, 2);
			}
		}
		
		if (currentStep == 3)
		{
			if (GameManager.sparks >= 1)
			{
				if (farmName == "DPumpkin")
				{
					HarvestActivation(upgradeTextureInfo.d_Pumpkin01);
				}
				
				if (farmName == "DFirePepper")
				{
					HarvestActivation(upgradeTextureInfo.d_FirePepper01);
				}
				
				// Columbine
				if (farmName == "DColumbine")
				{
					HarvestActivation(upgradeTextureInfo.d_Columbine01);
				}
				
				// BlackBerry
				if (farmName == "DBlackBerry")
				{
					HarvestActivation(upgradeTextureInfo.d_BlackBerry01);
				}
				
				if (farmName == "DAven")
				{
					HarvestActivation(upgradeTextureInfo.d_Aven01);
				}
				
				if (farmName == "BitterBrush")
				{
					HarvestActivation(upgradeTextureInfo.d_BitterBrush01);
				}
				
				if (farmName == "BogBean")
				{
					HarvestActivation(upgradeTextureInfo.d_Bogbean01);
				}
				
				if (farmName == "Wolfsbane")
				{
					HarvestActivation(upgradeTextureInfo.d_Wolfsbane01);
				}
				
				if (farmName == "MoonFlower")
				{
					HarvestActivation(upgradeTextureInfo.d_MoonFlower01);
				}
			}
		}
		
		// harvesting 
		if (currentStep == 4)
		{
			Harvesting();
			
			scr_audioController.audio_harvestCrop.transform.position = guiControlInfo.currentHarvestButton.transform.position;
			scr_audioController.audio_harvestCrop.Play();
			scr_audioController.audio_harvestCrop.volume = 0.7f;
			scr_audioController.audio_harvestCrop.minDistance = 1;
			scr_audioController.audio_harvestCrop.maxDistance = 20;
			
		}
	}
	
	
//=======================================================================================================================================
	public void CreateAnotherDarklingdirthPath()
	{
		if (grid.curObj.name == "DL_D_DDirtPath_GO(Clone)")
			{
				//scr_DCharMove.status = "Front";
				if (grid.curObj.transform.position.Equals(new Vector3(62.6f, 0.01f, 1.36f)))
					grid.curObj.tag = "notDelete";
					
				guiControlInfo.darkwayone.gameObject.active = true;
				guiControlInfo.darkwayone = null;
				dirtpathplace = GameManager.darkCurrDirtPath.GetComponent<dirtPathPlacement>() ;
				if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.left == true )
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.back == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.left == true && dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.back == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.left == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.right == true)
				{
					darkdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else
				{
				}
				guiControlInfo.createDDirtPath();
			}
	}
	
	public void CreateAnotherHalflingdirthPath()
	{
		Debug.Log("%%%%%%%%%%%%%%%%%%%%");
		// create another dirt path
			if (grid.curObj.name == "HC_D_DirtPath_GO(Clone)")
			{
			Debug.Log("% % % % % % % %% % % % % % % % % % % % ");
				scr_CharMove.status = "Front";
				guiControlInfo.halfwayone.gameObject.active = true;
				guiControlInfo.halfwayone = null;
				dirtpathplace = GameManager.halfCurrDirtPath.GetComponent<dirtPathPlacement>() ;
				if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.left == true )
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true && dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.back == true && dirtpathplace.left == true && dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true && dirtpathplace.back == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.left == true && dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.front == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.back == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else if(dirtpathplace.left == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x - scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z - scr_grid.gridSizeY);
				}
				else if(dirtpathplace.right == true)
				{
					halfdirtpath = new Vector3(grid.curObj.transform.position.x + scr_grid.gridSizeX,0.2f,grid.curObj.transform.position.z + scr_grid.gridSizeY);
				}
				else
				{
				}
				guiControlInfo.createDirtPath();
			}
	}
	
	private string absolutePos;
	public string GetabsolutePos(float x,float y ,float z)
	{
		absolutePos = "("+ x + "," + y + "," + z + ")";
	
//		Debug.Log("Absolute Pos :" + absolutePos);
		return absolutePos;
	}
	
	
	private float x,y,z;
	private Vector3 tempVector;
	// PLACE DECORATION ITEM
	public void taskDecorationItem()
	{
		//Debug.Log("why u r no placing...");
		// generate gold cost text

		//GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
		 //                                    Quaternion.Euler(90,0,0)) as GameObject;

		Sensors.sensorWorkBool = false;
		GameManager.placeObjectBool = false;
		
		grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
		grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
		grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
		Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
		
		//grid.curObj.GetComponent<getXP>().xpAnimBool = true;

		redPatch.gameObject.active = false; // hide red patch current game object
		greenPatch.gameObject.active = false; // hide green patch current game object
				
		// change current game object and collider tag name

		grid.curCol.tag = "editableObj";
		
		// hide current object UI
		Transform tempUI = grid.curObj.transform.FindChild("UI");
		
		GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
		placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
		
		GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
		cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
		
		tempUI.gameObject.SetActiveRecursively(false);
		
		// destroy current sensor script
		Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
		sensorInof.enabled = false;
		Sensors.sensorWorkBool = false;
		GameObject goldCostTxt;
		// request for xp
		switch(grid.curObj.name)
		{
		case "HC_D_Barrel_GO(Clone)": 
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objBarrel.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.barelCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Cornfield_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objCornfield.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.cornfield.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Cottage_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objCottage.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.cottage.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_DirtPath_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDirtPath.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.dirtPathCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_FruitTree_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objFruitTree1.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_HalflingKnoll_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objKnollhill.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Lantern_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objLamp.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_PartyTent_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objPartytent.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Scarecrow_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objScarescrow.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Shroomrey_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objShroomery.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_StoneFence_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objFence.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Tree_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objTree1.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Well_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWell.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_WheelBurrow_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWheelbarrow.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_WindMill_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWindmill.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "HC_D_Woodpile_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objWoodpile.objTypeId, grid.curObj);
//			GameManager.objectCost = scr_ObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//			goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//			                                     Quaternion.Euler(90,0,0)) as GameObject;
			break;

		case "DL_D_BirdHouse_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingBirdHouse.objTypeId, grid.curObj);
			break;

		case "DL_D_DBog_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingBog.objTypeId, grid.curObj);
			break;

		case "DL_D_DDirtPath_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingDirtPath.objTypeId, grid.curObj);
			break;

		case "DL_D_DTree_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingTree1.objTypeId, grid.curObj);
			break;

		case "DL_D_DWell_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingWell.objTypeId, grid.curObj);
			break;

		case "DL_D_DWindMill_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingWindmill.objTypeId, grid.curObj);
			break;

		case "DL_D_HuntingTent_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingHuntingtent.objTypeId, grid.curObj);
			break;

		case "DL_D_RavenPerch_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingRavenPerch.objTypeId, grid.curObj);
			break;

		case "DL_D_Scarecrow_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingScarecrow.objTypeId, grid.curObj);
			break;

		case "DL_D_StoneFence_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingFence.objTypeId, grid.curObj);
			break;

		case "DL_D_SwampKnoll_GO(Clone)":
			scr_loadUserWorld.ReturnXPcostTotal(scr_GameObjSvr.objDarklingKnollhill.objTypeId, grid.curObj);
			break;


		}



		if(grid.curObj.name == "DL_D_DWell_GO(Clone)")
		{
			inventory1Info.RemoveItem1(taskDetailsInfo.Four_Dark_task4);
		    taskDetailsInfo.Four_Dark_task4_bool =true;
		}
		
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();		
		scr_sfsRemoteCnt.SendRequestForBuyItems("6","decorationType",PlaceDecorationSvr(grid.curObj.name),"2");
		//SendPos = grid.curObj.transform.position;//new Vector3(grid.curObj.transform.position.x, grid.axisY, grid.curObj.transform.position.z);
		//tempVector = grid.curObj.transform.position;
		x= grid.curObj.transform.position.x;
		y = grid.axisY;
		z = grid.curObj.transform.position.z;
		//SendPos = new Vector3(grid.curObj.transform.position.x,grid.axisY,grid.curObj.transform.position.z);
		SendPosDec = "("+ x + "," + y + "," + z + ")";
		
		Debug.Log("Send Pos ::: " + SendPosDec);
	    SendRot = new Vector3(grid.curObj.transform.eulerAngles.x, grid.curObj.transform.eulerAngles.y, grid.curObj.transform.eulerAngles.z);
		
		if (grid.curObj.name == "HC_D_DirtPath_GO(Clone)" || grid.curObj.name == "DL_D_DDirtPath_GO(Clone)")
		{
			grid.curObj.GetComponent<dirtPathPlacement>().enabled = false;
			
			if (grid.curObj.name == "HC_D_DirtPath_GO(Clone)")
			{
				GameManager.lastDirtPathPosition = grid.curObj.transform.position;
				if (!hCharMove.findWaypointBool)
					hCharMove.findWaypointBool = true;
			}
			
			if (grid.curObj.name == "DL_D_DDirtPath_GO(Clone)")
			{
				Debug.Log("Last placement position +-----------------> " + grid.curObj.transform.position);
				GameManager.lastDDirtPathPosition = grid.curObj.transform.position;
				if (!dCharMove.findWaypointBool)
					dCharMove.findWaypointBool = true;
			}
		}
		
		if (GameManager.multipleDecorationBool)
		{
			if (grid.curObj.name == "HC_D_FruitTree_GO(Clone)")
				guiControlInfo.createFruitTree();
			if (grid.curObj.name == "HC_D_Lantern_GO(Clone)")
				guiControlInfo.createLantern();
			if (grid.curObj.name == "HC_D_WheelBurrow_GO(Clone)")
				guiControlInfo.createWheelBurrow();
			if (grid.curObj.name == "HC_D_Shroomrey_GO(Clone)")
				guiControlInfo.createShroomrey();
			if (grid.curObj.name == "DL_D_DTree_GO(Clone)")
				guiControlInfo.createDTree();
			if (grid.curObj.name == "DL_D_DWell_GO(Clone)")
				guiControlInfo.createDWell();
			if (grid.curObj.name == "DL_D_DBog_GO(Clone)")
				guiControlInfo.createDBog();
		}
		
		//grid.curObj = null;
	
		// hide object panel menu
//		objPanelControl objPanelInfo = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
//		objPanelInfo.panelMoveIn = true;
//		objPanelInfo.panelMoveOut = false;	
		
		objPanelControl objPanelInfo1 = GameObject.Find("ObjectPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo1.panelMoveIn = true;
		objPanelInfo1.panelMoveOut = false;	
	}

//=======================================================================================================================================	
	
	public bool isQuest1Completed,isQuest5Completed,isQuest6Complete,isQuest7Complete,isQuest8Complete,isQuest9Complete,isQuest10Complete,isQuest11Complete,isQuestStoryAvailable;
	public void AssignQuestNo(int questNo)
	{
		switch(questNo)
		{
			
		case 501:
				
			if(isQuestStoryAvailable == false)
			{
				isQuest1Completed  = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
				Debug.Log("quest 501");
			GameManager.quest  = 1;
				isQuestStoryAvailable = false;
			}
		   break;
				
		case 502:
			
			GameManager.quest  = 2;
			
			break;
			
		case 503:
			
			GameManager.quest  = 3;
			break;
				
		case 504:
				
			GameManager.quest  = 4;
			break;
			
		case 505:
			if(isQuestStoryAvailable == false)
			{
				isQuest5Completed  = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
				//Debug.Log("quest 505");
			GameManager.quest  = 5;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 506:
			if(isQuestStoryAvailable == false)
			{
				isQuest6Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
			GameManager.quest  = 6;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 507:
			if(isQuestStoryAvailable == false)
			{
				isQuest7Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
			GameManager.quest  = 7;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 508:
			if(isQuestStoryAvailable == false)
			{
				isQuest8Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
			GameManager.quest  = 8;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 509:
			if(isQuestStoryAvailable == false)
			{
				isQuest9Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
			GameManager.quest  = 9;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 510:
			if(isQuestStoryAvailable == false)
			{
				isQuest10Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
				GameManager.quest = 10;
				isQuestStoryAvailable = false;
			}
			break;
			
		case 511:
			if(isQuestStoryAvailable == false)
			{
				isQuest11Complete = true;
			}
			
			if(isQuestStoryAvailable == true)
			{
			    GameManager.quest = 11;
				isQuestStoryAvailable = false;				
			}
			
			
			break;
			
		case 512:
			GameManager.quest  = 12;
			break;
			
		}
		
		scr_sfsRemoteCnt.SendRequestforQuestCount(GameManager.quest);
	}
	
	private string name;
	public string PlaceDecorationSvr(string gridName)
	{
		switch(gridName)
		{
			
		 	case "HC_D_DirtPath_GO(Clone)":
				name = scr_GameObjSvr.objDirtPath.objname;
				break;
			
			case "HC_D_FruitTree_GO(Clone)":
				name = scr_GameObjSvr.objFruitTree1.objname;
				break;
			
			case "HC_D_Lantern_GO(Clone)":
				name = scr_GameObjSvr.objLamp.objname;
				break;
			
			case "HC_D_WheelBurrow_GO(Clone)":
				name = scr_GameObjSvr.objWheelbarrow.objname;
				break;
			
			case "HC_D_Shroomrey_GO(Clone)":
				name = scr_GameObjSvr.objShroomery.objname;
				break;
			
			case "HC_D_Barrel_GO(Clone)":
				name = scr_GameObjSvr.objBarrel.objname;
				break;
			
			case "HC_D_Tree_GO(Clone)":			
				name = scr_GameObjSvr.objTree1.objname;
				break;
			
			case "HC_D_Well_GO(Clone)":			
				name = scr_GameObjSvr.objWell.objname;
				break;			
			
			case "HC_D_Woodpile_GO(Clone)":			
				name = scr_GameObjSvr.objWoodpile.objname;
				break;			
			
			case "HC_D_Cornfield_GO(Clone)":			
				name = scr_GameObjSvr.objCornfield.objname;
				break;			
			
			case "HC_D_Cottage_GO(Clone)":			
				name = scr_GameObjSvr.objCottage.objname;
				break;			
			
			case "HC_D_HalflingKnoll_GO(Clone)":			
				name = scr_GameObjSvr.objKnollhill.objname;
				break;			
			
			case "HC_D_PartyTent_GO(Clone)":			
				name = scr_GameObjSvr.objPartytent.objname;
				break;			
			
			case "HC_D_Scarecrow_GO(Clone)":			
				name = scr_GameObjSvr.objScarescrow.objname;
				break;			
			
			case "HC_D_StoneFence_GO(Clone)":			
				name = scr_GameObjSvr.objFence.objname;
				break;			
			
			case "HC_D_WindMill_GO(Clone)":			
				name = scr_GameObjSvr.objWindmill.objname;
				break;			
			
			case "DL_D_DDirtPath_GO(Clone)":			
				name = scr_GameObjSvr.objDarklingDirtPath.objname;
				break;
			
			case "DL_D_DTree_GO(Clone)":			
				name = scr_GameObjSvr.objDarklingTree1.objname;
				break;
			
			case "DL_D_DWell_GO(Clone)":			
				name = scr_GameObjSvr.objDarklingWell.objname;
				break;
			
			case "DL_D_DBog_GO(Clone)":
				name = scr_GameObjSvr.objDarklingBog.objname;
				break;
			
			case "DL_D_RavenPerch_GO(Clone)":
				name = scr_GameObjSvr.objDarklingRavenPerch.objname;
				break;
			
			case "DL_D_BirdHouse_GO(Clone)":
				name = scr_GameObjSvr.objDarklingBirdHouse.objname;
				break;
			
			case "DL_D_DWindMill_GO(Clone)":
				 name = scr_GameObjSvr.objDarklingWindmill.objname;
				break;
			
			case "DL_D_HuntingTent_GO(Clone)":
				 name = scr_GameObjSvr.objDarklingHuntingtent.objname;
				break;
			
			case "DL_D_Scarecrow_GO(Clone)":
				 name = scr_GameObjSvr.objDarklingScarecrow.objname;
				break;
			
			case "DL_D_StoneFence_GO(Clone)":
				 name = scr_GameObjSvr.objDarklingFence.objname;
				break;
			
			case "DL_D_SwampKnoll_GO(Clone)":
				 name = scr_GameObjSvr.objDarklingKnollhill.objname;
				break;
			
		}					
		
		if (gridName == "HC_D_DirtPath_GO(Clone)" || gridName == "DL_D_DirtPath_GO(Clone)")
		{
			DecorationCountWithPath();
		}
		else
		{
			DecorationCount();
		}
	 return name;   
	}
	
	
	// Task Darkling Crecture
	public void taskDarklingCreature(int currentStep, string creatureName)
	{
		if (currentStep == 2)
		{
			defaultPopUpBool = true;
			defaultPopUp(1, 2);
		}
		
		if (currentStep == 3)
		{
			defaultPopUpBool = true;
			GameObject go = GameObject.Find("DL_C_"+creatureName+"_GO(Clone)");
			Destroy(go.transform.FindChild("RabbtiButton").gameObject);
			Destroy(go.transform.FindChild("ProgressBar").gameObject);
			Destroy(go.GetComponent("progressBar"));
			
			go.renderer.enabled = true;
			
			
			// change collider tag name
			go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			go.transform.root.gameObject.transform.FindChild("Spark").gameObject.active = false;
			go.transform.root.gameObject.transform.FindChild("Spark1").gameObject.active = false;
			go.transform.root.gameObject.transform.FindChild("Spark2").gameObject.active = false;
			//GameObject.Find("HC_TG_Plant_GO(Clone)").gameObject.transform.FindChild("Spark").gameObject.active = false;
			
			UpdateScore();
			//GameManager.sparks = GameManager.sparks - 1;
			guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
		}
	}
	
		//harish chander for server 
	private GameObject SendGo;
	public GameObject GetGameObject()
	{
		return SendGo;
	}
	
	public string GetDecorationPos()
	{
		return SendPosDec;
	}
	
	public string GetPosition()
	{
		return SendPos.ToString();
	}
	
	public string GetRotation()
	{
		return SendRot.ToString();
	}
	
	public int GetParentObjectid()
	{
		return SendParentObjid;
	}
	
	public IEnumerator GetWorld()
	{
		yield return new WaitForSeconds(1f);
//		//Debug.Log("calling Getworld");
		scr_sfsRemoteCnt.SendRequestForGetworld();
	}
	
	public int GetTypeId()
	{
		return TempTypeId;
	}
	
	// update pop up count in database
	
	private int GardenPlottypeId;
	public int ReturnGardenPlotTypeId(string gardenplotName)
	{
		if(gardenplotName == "HC_B_Plot_GO(Clone)")
		{
			GardenPlottypeId = scr_GameObjSvr.objGarden.objTypeId;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_2")
		{
			GardenPlottypeId = scr_GameObjSvr.objGarden02.objTypeId;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_3")
		{
			GardenPlottypeId = scr_GameObjSvr.objGarden03.objTypeId;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_4")
		{
			GardenPlottypeId = scr_GameObjSvr.objGarden04.objTypeId;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_5")
		{
			GardenPlottypeId = scr_GameObjSvr.objGarden05.objTypeId;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_1")
		{
			GardenPlottypeId = scr_GameObjSvr.objDarklingGarden.objTypeId;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_2")
		{
			GardenPlottypeId = scr_GameObjSvr.objDarklingGarden02.objTypeId;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_3")
		{
			GardenPlottypeId = scr_GameObjSvr.objDarklingGarden03.objTypeId;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_4")
		{
			GardenPlottypeId = scr_GameObjSvr.objDarklingGarden04.objTypeId;
		}
		
		return GardenPlottypeId;
	}
	
	private string GardenPlotName;
	public string ReturnGardenNameSvr(string gardenplotName)
	{
		if(gardenplotName == "HC_B_Plot_GO(Clone)")
		{
			GardenPlotName = scr_GameObjSvr.objGarden.objname;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_2")
		{
			GardenPlotName = scr_GameObjSvr.objGarden02.objname;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_3")
		{
			GardenPlotName = scr_GameObjSvr.objGarden03.objname;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_4")
		{
			GardenPlotName = scr_GameObjSvr.objGarden04.objname;
		}
		else if(gardenplotName == "HC_B_Plot_GO(Clone)_5")
		{
			GardenPlotName = scr_GameObjSvr.objGarden05.objname;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_1")
		{
			GardenPlotName = scr_GameObjSvr.objDarklingGarden.objname;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_2")
		{
			GardenPlotName = scr_GameObjSvr.objDarklingGarden02.objname;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_3")
		{
			GardenPlotName = scr_GameObjSvr.objDarklingGarden03.objname;
		}
		else if(gardenplotName == "DL_B_Plot_GO(Clone)_4")
		{
			GardenPlotName = scr_GameObjSvr.objDarklingGarden04.objname;
		}
		
		return GardenPlotName;
	}
	
	public void updatePopUpCount()
	{
		scr_sfsRemoteCnt.SendRequestForPopUpsCompleted(GameManager.popUpCount);
	}
	
	public void updateCurPopUpCount()
	{
		scr_sfsRemoteCnt.SendCurrentPopupCount(curPopUpCnt);
	}
	
	public void updateTaskCount()
	{
		scr_sfsRemoteCnt.SendRequestForTasksCompleted(GameManager.taskCount);
	}
	
	public int GetIdFromString(string s)
	{
		//Debug.Log(s);
		int i = s.IndexOf("(Clone)_");
		//Debug.Log(i);
		//Debug.Log(s.Length);
		if(i != -1)
		{
			string subS = s.Substring((i+8), (s.Length-(i+8))); 
			return int.Parse(subS);
		}
		else{
			//Debug.Log("not found");
			return -1;
		}
	}
	
	private string CreatureAttack;
	public string GetCreatureNamefromTypeId(int typeId)
	{
		switch(typeId)
		{
		case 22:
			CreatureAttack = "HC_C_Barg_GO(Clone)";
			
			break;
			
		case 26:
			 CreatureAttack = "HC_C_Cusith_GO(Clone)";
			break;
			
		case 50:
			CreatureAttack  = "HC_C_Dragon_GO(Clone)";
			break;
			
		case 38:
			CreatureAttack  = "HC_C_Draug_GO(Clone)";
			break;
			
		case 41:
			CreatureAttack  = "HC_C_Dryad_GO(Clone)";
			break;
			
		case 3:
			CreatureAttack  =  "HC_C_Hound_GO(Clone)";
			break;
		case 24:
			CreatureAttack  = "HC_C_Nix_GO(Clone)";
			break;
			
		case 32:
			CreatureAttack  = "HC_C_Nymph_GO(Clone)";
			break;
			
		case 21:
			CreatureAttack  = "HC_C_Sprout_GO(Clone)";
			break;
			
		case 209:
			CreatureAttack  = "DL_C_DHound_GO(Clone)";
			break;
			
		case 241:
			CreatureAttack  = "DL_C_Djinn_GO(Clone)";
			break;
			
		case 224:
			CreatureAttack  = "DL_C_Fenrir_GO(Clone)";
			break;
			
		case 237:
			CreatureAttack  = "DL_C_HellHound_GO(Clone)";
			break;
			
		case 225:
			CreatureAttack  = "DL_C_Imp_GO(Clone)";
			break;
			
		case 208:
			CreatureAttack  = "DL_C_Leech_GO(Clone)";
			break;
			
		case 222:
			CreatureAttack  = "DL_C_Leshy_GO(Clone)";
			break;
			
		case 234:
			CreatureAttack  = "DL_C_Lurker_GO(Clone)";
			break;
			
		case 215:
			CreatureAttack  = "DL_C_Sprite_GO(Clone)";
			break;
			
			
		}
		
		return CreatureAttack;
	}
	
	private void GetCreatureTypeIdfromName(string creatureName)
	{
		
		switch(creatureName)
		{
		case "HC_C_Barg_GO(Clone)":
		
			CaveCreature = scr_GameObjSvr.objBarg.objTypeId;
			
		     break;
			
		case "HC_C_Cusith_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objCusith.objTypeId;
			break;
			
		case "HC_C_Dragon_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDragon.objTypeId;
			break;
			
		case "HC_C_Draug_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDraug.objTypeId;
			
			break;
			
		case "HC_C_Dryad_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDryad.objTypeId;
			break;
			
		case "HC_C_Hound_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objHound.objTypeId;
			break;
			
		case "HC_C_Nix_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objNix.objTypeId;
			
			break;
			
		case "HC_C_Nymph_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objNymph.objTypeId;
			
			break;
			
		case "HC_C_Sprout_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objSprout.objTypeId;
			
			break;
			
		case "DL_C_DHound_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklinghound.objTypeId;
			break;
			
		case "DL_C_Djinn_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingDjInn.objTypeId;
			break;
			
		case "DL_C_Fenrir_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingFenrir.objTypeId;
			break;
			
		case "DL_C_HellHound_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingHellhound.objTypeId;
			break;
			
		case "DL_C_Imp_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingImp.objTypeId;
			break;
			
		case "DL_C_Leech_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objLeech.objTypeId;
			break;
			
		case "DL_C_Leshy_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingLeshy.objTypeId;
			break;
			
		case "DL_C_Lurker_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingLurker.objTypeId;
			break;
			
		case "DL_C_Sprite_GO(Clone)":
			
			CaveCreature = scr_GameObjSvr.objDarklingSprite.objTypeId;
			break;
		}
	}
	
	public void plantHerbsHarvestCount()
	{
		 		ad.plantHarvestCount = PlayerPrefs.GetInt("plantharvestcount");
		 		PlayerPrefs.SetInt("plantharvestcount",(ad.plantHarvestCount+1));
				
		//Debug.Log("harvest count :"+PlayerPrefs.GetInt("plantharvestcount"));
		 		ad.percentComplete7 = 10*PlayerPrefs.GetInt("plantharvestcount");
		 		ad.percentComplete46 = PlayerPrefs.GetInt("plantharvestcount");
	}
	
	public void DecorationCount()
	{
		 		ad.DecorationCount = PlayerPrefs.GetInt("decorationcount");
		 		PlayerPrefs.SetInt("decorationcount",(ad.DecorationCount+1));
		
		//Debug.Log("decoration count :"+PlayerPrefs.GetInt("decorationcount"));
		 		ad.percentComplete11 = 10*PlayerPrefs.GetInt("decorationcount");
		 		ad.percentComplete26 = 2*PlayerPrefs.GetInt("decorationcount");
		 		ad.percentComplete45 = PlayerPrefs.GetInt("decorationcount");
	}
	
	public void DecorationCountWithPath()
	{
		 		ad.DecorationCount = PlayerPrefs.GetInt("decorationcount");
		 		PlayerPrefs.SetInt("decorationcount",(ad.DecorationCount+1));
		
		//Debug.Log("decoration count :"+PlayerPrefs.GetInt("decorationcount"));
		 		ad.percentComplete26 = 2*PlayerPrefs.GetInt("decorationcount");
		
	}
	
	public void GoldProducingBuildings()
	{
		 		ad.GoldProducingBuildingsCount = PlayerPrefs.GetInt("goldproducingbuildings");
		 		PlayerPrefs.SetInt("goldproducingbuildings",(ad.GoldProducingBuildingsCount+1));

		//Debug.Log("goldproducingbuildings count :"+PlayerPrefs.GetInt("goldproducingbuildings"));
		 		ad.percentComplete13 = 34*PlayerPrefs.GetInt("goldproducingbuildings");
		 		ad.percentComplete14 = 17*PlayerPrefs.GetInt("goldproducingbuildings");
		
	}
	
	public void tavernBuilding()
	{
		 		ad.tavernCount = PlayerPrefs.GetInt("tavernbuildings");
		 		PlayerPrefs.SetInt("tavernbuildings",(ad.tavernCount+1));

		//Debug.Log("tavernbuildings count :"+PlayerPrefs.GetInt("tavernbuildings"));
		 		ad.percentComplete18 = 50*PlayerPrefs.GetInt("tavernbuildings");
		
	}
	
	public void ObelisksBuild()
	{
		 		ad.obelisksCount = PlayerPrefs.GetInt("obelisksbuildings");
		 		PlayerPrefs.SetInt("obelisksbuildings",(ad.obelisksCount+1));

		//Debug.Log("obelisksbuildings count :"+PlayerPrefs.GetInt("obelisksbuildings"));
		 		ad.percentComplete25 = 50*PlayerPrefs.GetInt("obelisksbuildings");
		
	}
	
	public void ShrineBuildings()
	{
		 		ad.ShrinesCount = PlayerPrefs.GetInt("shrinebuildings");
		 		PlayerPrefs.SetInt("shrinebuildings",(ad.ShrinesCount+1));

		//Debug.Log("shrinebuildings count :"+PlayerPrefs.GetInt("shrinebuildings"));
		 		ad.percentComplete36 = 50*PlayerPrefs.GetInt("shrinebuildings");
		
	}
	
	public void HalflingCreaturesAchivement()
	{
		 		ad.halflingCreaturesCount = PlayerPrefs.GetInt("halflingcreaturesachivement");
		 		PlayerPrefs.SetInt("halflingcreaturesachivement",(ad.halflingCreaturesCount+1));

		//Debug.Log("halflingcreaturesachivement count :"+PlayerPrefs.GetInt("halflingcreaturesachivement"));
		 		ad.percentComplete30 = 12*PlayerPrefs.GetInt("halflingcreaturesachivement");
	}
	
	public void DarklingCreaturesAchivement()
	{
		 		ad.darklingCreaturesCount = PlayerPrefs.GetInt("darklingcreaturesachivement");
		 		PlayerPrefs.SetInt("darklingcreaturesachivement",(ad.darklingCreaturesCount+1));

		//Debug.Log("darklingcreaturesachivement count :"+PlayerPrefs.GetInt("darklingcreaturesachivement"));
		 		ad.percentComplete31 = 12*PlayerPrefs.GetInt("darklingcreaturesachivement");
	}
	
	public void CreaturesAchivement()
	{
		 		ad.CreatureCount = PlayerPrefs.GetInt("creaturesachivement");
		 		PlayerPrefs.SetInt("creaturesachivement",(ad.CreatureCount+1));

		//Debug.Log("creaturesachivement count :"+PlayerPrefs.GetInt("creaturesachivement"));
		 		ad.percentComplete27 = 9*PlayerPrefs.GetInt("creaturesachivement");
	}
	public void EnemyCaveBuildings()
	{
		 		ad.enemyCaveCount = PlayerPrefs.GetInt("enemycavebuildings");
		 		PlayerPrefs.SetInt("enemycavebuildings",(ad.enemyCaveCount+1));

		//Debug.Log("enemycavebuildings count :"+PlayerPrefs.GetInt("enemycavebuildings"));
		 		ad.percentComplete33 = 10*PlayerPrefs.GetInt("enemycavebuildings");
	}
	public void TrainingGroundCreature()
	{
		 		ad.traininggroundCreatureCount = PlayerPrefs.GetInt("traininggroundcreature");
		 		PlayerPrefs.SetInt("traininggroundcreature",(ad.traininggroundCreatureCount+1));

		//Debug.Log("traininggroundcreature count :"+PlayerPrefs.GetInt("traininggroundcreature"));
		 		ad.percentComplete12 = 9*PlayerPrefs.GetInt("traininggroundcreature");
	}
	public void halflinGolumDisable()
	{
		Debug.Log("halflinGolumDisable");
		fp.golum_Halfling_Front_Generate.gameObject.renderer.enabled = false;
		fp.golum_Halfling_Front_HighHammer.gameObject.renderer.enabled = false;
		fp.golum_Halfling_Front_LowHammer.gameObject.renderer.enabled = false;
						
		fp.halfling_Generate = false;
		fp.Halfing_Front_Hammer = false;
						
		guiControlInfo.golum = GameObject.Find("HC_C_Golum_GO(Clone)");
		
		if(scr_audioController.audio_Scaffolding.isPlaying)
		{
			scr_audioController.audio_Scaffolding.Stop();
		}
	}
	
	public void DarklinGolumDisable()
	{
		if (fp!= null)
		{
			fp.golum_Darkling_Front_Generate.gameObject.renderer.enabled = false;
			fp.golum_Darkling_Front_HighHammer.gameObject.renderer.enabled = false;
			fp.golum_Darkling_Front_LowHammer.gameObject.renderer.enabled = false;
							
			fp.darkling_Generate = false;
			fp.Darking_Front_Hammer = false;
							
			guiControlInfo.Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
			
				if(scr_audioController.audio_Scaffolding.isPlaying)
			{
				scr_audioController.audio_Scaffolding.Stop();
			}
		}
	}
	
	public void halflinGolumEnableBuildings()
	{
		Vector3 unknown = new Vector3(grid.curObj.transform.position.x-1.75f,grid.axisY+0.011f,grid.curObj.transform.position.z-1.75f);
		GameObject golum = Instantiate(guiControlInfo.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
		guiControlInfo.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
			
		fp.halfling_Generate = true;
		fp.Halfing_Front_Hammer = true;
		
		GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
		golumEffect.GetComponent<ParticleSystem>().Play();
	}
	public void halflinGolumEnableUpgradeBuildings()
	{
		if(guiControlInfo.golum != null)
		{
			Destroy(guiControlInfo.golum);
			Vector3 unknown = new Vector3(GameManager.curBuilding.transform.position.x-1.75f,grid.axisY+0.011f,GameManager.curBuilding.transform.position.z-1.75f);
			GameObject golum = Instantiate(guiControlInfo.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
	
			guiControlInfo.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
			
			fp.halfling_Generate = true;
			fp.Halfing_Front_Hammer = true;
		
			GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
			golumEffect.GetComponent<ParticleSystem>().Play();
		}
	}
	
	
	// enable hafling golum for obelisk
	public void halflinGolumEnableObelisks()
	{
		Debug.Log("---> " + grid.curObj.gameObject.name + " <---");
		Vector3 unknown = new Vector3(grid.curObj.transform.position.x-1f,grid.axisY+0.011f,grid.curObj.transform.position.z+0.8f);
		GameObject golum = Instantiate(guiControlInfo.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
		guiControlInfo.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
			
		fp.halfling_Generate = true;
		fp.Halfing_Front_Hammer = true;
		
		GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
		golumEffect.GetComponent<ParticleSystem>().Play();
	}
	
	public void halflinGolumEnableObelisksUpgrade()
	{
		Vector3 unknown = new Vector3(GameManager.curBuilding.transform.position.x+1f,grid.axisY+0.011f,GameManager.curBuilding.transform.position.z-0.8f);
		GameObject golum = Instantiate(guiControlInfo.golumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			
		guiControlInfo.golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
			
		fp.halfling_Generate = true;
		fp.Halfing_Front_Hammer = true;
		
		GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
		golumEffect.GetComponent<ParticleSystem>().Play();
	}
	
	public void darklinGolumEnableBuildings()
	{
		Debug.Log("create darkling golum.............");
		Vector3 unknown = new Vector3(grid.curObj.transform.position.x-1.75f,grid.axisY+0.011f,grid.curObj.transform.position.z-1.75f);
		//Vector3 unknown = new Vector3(grid.curObj.transform.position.x-1f,grid.axisY+0.011f,grid.curObj.transform.position.z+0.8f);		
		GameObject Darkgolum = Instantiate(guiControlInfo.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
		Debug.Log("a a a a a a a a a a a--------");
		guiControlInfo.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
				
		fp.darkling_Generate = true;
		fp.Darking_Front_Hammer = true;
		
		GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
		golumEffect.GetComponent<ParticleSystem>().Play();
	}
	
	public void darklinGolumEnableUpgradeBuildings()
	{
		if(guiControlInfo.Darkgolum != null)
		{
			Destroy(guiControlInfo.Darkgolum);
			Vector3 unknown = new Vector3(GameManager.curBuilding.transform.position.x-1.75f,grid.axisY+0.011f,GameManager.curBuilding.transform.position.z-1.75f);
			GameObject Darkgolum = Instantiate(guiControlInfo.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
			Debug.Log("b b bb b b b b bb --------");
			guiControlInfo.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
			
			fp.darkling_Generate = true;
			fp.Darking_Front_Hammer = true;
		
			GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
			golumEffect.GetComponent<ParticleSystem>().Play();
		}
	}
	public void darklinGolumEnableObelisks()
	{
		//Vector3 unknown = new Vector3(grid.curObj.transform.position.x-2f,grid.axisY+0.011f,grid.curObj.transform.position.z-0.30f);
		Vector3 unknown = new Vector3(grid.curObj.transform.position.x-1.28f,grid.axisY+0.011f,grid.curObj.transform.position.z+0.90f);
		GameObject Darkgolum = Instantiate(guiControlInfo.DarkgolumGO,unknown, Quaternion.Euler(90, 0, 0)) as GameObject;
		Debug.Log("c c c c c c c c c c c--------");
		guiControlInfo.Darkgolum  = GameObject.Find("DL_C_Golum_GO(Clone)") as GameObject;
			
		fp.darkling_Generate = true;
		fp.Darking_Front_Hammer = true;	
		
		GameObject golumEffect = Instantiate(gameManagerInfo.par_GolumAppear_PF, unknown, Quaternion.Euler(-30, 0, 0)) as GameObject;
		golumEffect.GetComponent<ParticleSystem>().Play();
	}
	
	void EnableMiniGames()
	{
		
		if(scr_sfsRemoteCnt.tavernGameactive)
		{
		   GameObject.Find("HC_B_Tavern_GO(Clone)").transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
		   GameObject.Find("DL_B_Tavern_GO(Clone)").transform.FindChild("TavernButton").gameObject.SetActiveRecursively(true);
		   scr_sfsRemoteCnt.tavernGameactive = false;
		}
		
		if(scr_sfsRemoteCnt.potionGameactive)
		{
		   GameObject.Find("HC_B_Apothecary_GO(Clone)").transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
		   GameObject.Find("DL_B_Apothecary_GO(Clone)").transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(true);
		   scr_sfsRemoteCnt.potionGameactive = false;
		}
		
	}
	
	// Create creature step 1
	void CreateCreature(GameObject creaturePref, string objName, int objTypeId, int objTrainingGroundId, bool morphingBool, 
						float rotX, float rotY, float rotZ, float posY, string creatureName)
	{
		GameObject go = Instantiate(creaturePref, new Vector3(GameManager.curTG.transform.position.x,
																GameManager.curTG.transform.position.y + 0.01f,
																GameManager.curTG.transform.position.z + 2f), Quaternion.Euler(rotX, rotY, rotZ)) as GameObject;
		
		go.transform.parent = GameManager.curTG.transform;
		go.transform.localPosition = new Vector3(go.transform.localPosition.x, posY, go.transform.localPosition.z);
				
		GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		GameObject map = GameObject.Find("HalfLing_Map").gameObject;
		
		Transform sparkObj = GameManager.curTG.transform.FindChild("Spark") as Transform;
		if (sparkObj != null)
			GameManager.curTG.transform.FindChild("Spark").gameObject.active = true;
		
		// change
		Transform animSpark = GameManager.curTG.transform.FindChild("Spark1") as Transform;
		Transform animSpark2 = GameManager.curTG.transform.FindChild("Spark2") as Transform;
		
		if (animSpark2 != null)
			animSpark2.gameObject.active = true;
		
		if (animSpark != null)
		{
			animSpark.gameObject.active = true;
			GameManager.curTG.AddComponent<SparkAnimation>();
			animSpark.gameObject.GetComponent<MeshRenderer>().enabled = true;
			animSpark.gameObject.GetComponent<Sprite>().PlayAnim("Effect");
		}
		// end change
				
		//enable Sounds
		scr_audioController.audio_sparkEarth.transform.position = GameManager.curTG.transform.position;
		scr_audioController.audio_sparkEarth.volume = 0.7f;
		scr_audioController.audio_sparkEarth.Play();
		scr_audioController.audio_sparkEarth.minDistance = 1;
		scr_audioController.audio_sparkEarth.maxDistance = 20;
				
		PlaySparkBirthsound(GameManager.curTG.transform.position);
		
		GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		go.renderer.enabled = false;
		
		// activate creature progress bar
		(go.GetComponent("progressBar") as progressBar).enabled = true;
		guiControlInfo.creatureTemp = go;
		
		// attach guiControl script to rabbit ui button
		Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false); 
		
		UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
		panelControl.panelAnimBool = false; //main menu animation off
		
		
		
		//scr_sfsRemoteCnt.SendCreatureName(creatureName, objTypeId);
				
		if (!morphingBool)
		{
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("2","creatureType", objName,"2");
			SendParentObjid = objTrainingGroundId;
			TempTypeId = objTypeId;
			//SendPos = new Vector3(GameManager.curTG.transform.position.x,GameManager.curTG.transform.position.y,GameManager.curTG.transform.position.z);
			SendPos = GetabsolutePos(GameManager.curTG.transform.position.x,GameManager.curTG.transform.position.y,GameManager.curTG.transform.position.z);
			SendRot = new Vector3(0,180,0);
			isTaskCreature = true;
		}
	}
	
	public void taskBuildBridge(int step)
	{
		Debug.Log("Genereate ProgressBar for bridge...");
		
		if (step == 1)
		{
			objectSelection.objectSelectionBool = true;
			GameManager.placeObjectBool = false;
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("3", "buildingType", scr_GameObjSvr.objBridge.objname, "2");
			TempTypeId = scr_GameObjSvr.objBridge.objTypeId;
			SendPos = GetabsolutePos(10, 10, 10);
			SendRot = new Vector3(0,180,0);
			GameObject.Find("Main Camera").transform.position = new Vector3(-15f, 40f, 0f);
		}
		
		
		
		if (step == 3)
		{	
			taskidSvr = scr_loadUserWorld.ReturnTaskId(scr_GameObjSvr.objBridge.objTypeId);
			scr_sfsRemoteCnt.SendRequestForAccelrateTask(taskidSvr,GameManager.sparks);
			
			GameObject bridgeRabbitObj = GameObject.Find("Bridge_GO(Clone)") as GameObject;
			
			if (bridgeRabbitObj != null)
				Destroy(bridgeRabbitObj);
			
			GameObject bridgeObj = GameObject.Find("BridgeBroken_GO") as GameObject;
			
			if (bridgeObj != null)
			{
				bridgeObj.renderer.material.mainTexture = scr_loadUserWorld.bridge_tex;
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
	
	public void taskBuildBridgePopup()
	{
		bridgeRabbitBool = true;
			
		defaultPopUpBool = true;
		defaultPopUp(60, 2);
	}
	
	public void DestroyCave(int objTypeId)
	{
		GameManager.readyAttackBool = false;
		
		Debug.Log("cave ---------------> " + GameManager.curCave.name);
		Debug.Log("creature -----------> " + GameManager.currentCreature.name);
		
		// hide creature on training ground 
		GameManager.currentCreature.GetComponent<MeshRenderer>().enabled = false;
		GameManager.currentCreature.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		// show creature attack animation near cave
		GameObject attackCreatureObj = Instantiate(gameManagerInfo.houndAttack_PF, new Vector3(GameManager.curCave.transform.position.x, 
																								GameManager.curCave.transform.position.y,
																								GameManager.curCave.transform.position.z),
																								Quaternion.Euler(90, 0, 0)) as GameObject;
		
		GameManager.curCave.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		GameManager.curCave.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(true);
		progressBar goblinCampPB = GameManager.curCave.GetComponent("progressBar") as progressBar;
		GameManager.curCave.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		goblinCampPB.enabled = true;
		
		
		//Clear Cave sent ot server			
		StartCoroutine("GetWorld");
	    isTask4 = true;
	    caveTobeCleared = new Vector3(goblinCampPB.gameObject.transform.position.x,0.01f,goblinCampPB.gameObject.transform.position.z).ToString();
		caveName = goblinCampPB.transform.name;
		GetCreatureTypeIdfromName(GameManager.currentCreature.name);
		
		TempTypeId = objTypeId;// scr_GameObjSvr.objGoblinCamp02.objTypeId;
		
		// attach guiControl script to rabbit ui button
		Transform rabbit = GameManager.curCave.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		
		UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
	}
	private Vector3 parseVector3(string rString)	
	{
	    string[] temp = rString.Substring(1,rString.Length-2).Split(',');
		float x = float.Parse(temp[0]);
	    float y = float.Parse(temp[1]);
	    float z = float.Parse(temp[2]);
	    Vector3 rValue = new Vector3(x,y,z);
		
	    return rValue;
	}
	
	private GameObject caveCreature01, caveCreature02, creatureAttackObj;
	void CreatureAttackAnimation(GameObject creature, GameObject cave)
	{
		Debug.Log("cave : "+cave.name);
		Debug.Log("creature tag : "+creature.tag);
	
		GameObject trainingGround = creature.transform.parent.gameObject;
	
		switch(cave.tag)
		{
		case "goblinCamp" :
			caveCreature01 = cave.transform.FindChild("GoblinChar01").gameObject;
			caveCreature02 = cave.transform.FindChild("GoblinChar02").gameObject;
			break;
			
		case "TrollHouse" :
			caveCreature01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature02 = cave.transform.FindChild("TrollChar02").gameObject;
			break;
			
		case "OrgCave" :
			caveCreature01 = cave.transform.FindChild("OrgChar01").gameObject;
			caveCreature02 = cave.transform.FindChild("OrgChar02").gameObject;
			break;
			
		default :
			break;
		}

				
		if (creature.tag == "Hound")
		{
			// create effect
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;
			creatureAttackObj = Instantiate(gameManagerInfo.houndAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Barg")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;
			creatureAttackObj = Instantiate(gameManagerInfo.bargAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * -1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Cusith")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.cusithAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		
		else if (creature.tag == "Sprout")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.sproutAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Nymph")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.nymphAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Dryad")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.dryadAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		
		else if (creature.tag == "Nix")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.nixAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Draug")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.draugAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Dragon")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_HCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.dragonAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		
		else if (creature.tag == "Leech")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.leechAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Leshy")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.leshyAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Lurker")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.lurkerAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		
		else if (creature.tag == "DHound")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.dHoundAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Fenrir")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.fenrirAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "HellHound")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.hellHoundAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		
		else if (creature.tag == "Sprite")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.spriteAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Imp")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.impAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		else if (creature.tag == "Djinn")
		{
			GameObject eff = Instantiate(gameManagerInfo.par_DCreatureGenEff_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(0,0,0)) as GameObject;

			creatureAttackObj = Instantiate(gameManagerInfo.djinnAttack_PF, new Vector3(cave.transform.position.x + 5, 0.1f, cave.transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
			creatureAttackObj.transform.localScale = new Vector3(creatureAttackObj.transform.localScale.x * 1, creatureAttackObj.transform.localScale.y, creatureAttackObj.transform.localScale.z);
		}
		creatureAttackObj.transform.parent = trainingGround.transform;
		
		if(caveCreature01.gameObject.tag == "Untagged" && cave.GetComponent<OrcAttackTimer>() == null)
		{
			caveCreature01.GetComponent<MeshRenderer>().enabled = false;
			caveCreature01.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			caveCreature01.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			caveCreature01.transform.FindChild("LessAgg1_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			caveCreature01.transform.localScale = cave.transform.FindChild("GoblinChar01_loc").transform.localScale;
			caveCreature01.transform.localPosition = cave.transform.FindChild("GoblinChar01_loc").transform.localPosition;
		}
		if(caveCreature02.gameObject.tag == "Untagged" && cave.GetComponent<OrcAttackTimer>() == null)
		{
			caveCreature02.GetComponent<MeshRenderer>().enabled = false;
			caveCreature02.transform.FindChild("attack_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			caveCreature02.transform.FindChild("Walk_anim").gameObject.GetComponent<MeshRenderer>().enabled = false;
			caveCreature02.transform.FindChild("LessAgg2_anim").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			caveCreature02.transform.localScale = cave.transform.FindChild("GoblinChar02_loc").transform.localScale;
			caveCreature02.transform.localPosition = cave.transform.FindChild("GoblinChar02_loc").transform.localPosition;
		}
	}

	
	void SendCreatureHome(int typeID)
	{
		Debug.Log("Rabbit button click.......");
		
		int crId =  scr_loadUserWorld.ReturnCreatureIdforCave(typeID);
		Debug.Log("crId : "+crId);
		Debug.Log("crTypeID : "+scr_loadUserWorld.ReturnTypeIdfromObjId(crId));
		GetCreatureNamefromTypeId(scr_loadUserWorld.ReturnTypeIdfromObjId(crId));
		string creatureName = GetCreatureNamefromTypeId(scr_loadUserWorld.ReturnTypeIdfromObjId(crId));
		GameObject creatureObj = GameObject.Find(creatureName) as GameObject;
		Debug.Log("creature name :: " + creatureName);
		
		GameObject tg = null;
		
		if (creatureObj != null)
		{
			if (creatureObj.tag == "Hound" || creatureObj.tag == "Barg" || creatureObj.tag == "Cusith")
				tg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
			
			else if (creatureObj.tag == "Sprout" || creatureObj.tag == "Nymph" || creatureObj.tag == "Dryad")
				tg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
			
			else if (creatureObj.tag == "Nix" || creatureObj.tag == "Draug" || creatureObj.tag == "Dragon")
				tg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
			
			else if (creatureObj.tag == "Leech" || creatureObj.tag == "Leshy" || creatureObj.tag == "Lurker")
				tg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
			
			else if (creatureObj.tag == "DHound" || creatureObj.tag == "Fenrir" || creatureObj.tag == "HellHound")
				tg = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
			
			else if (creatureObj.tag == "Djinn" || creatureObj.tag == "Imp" || creatureObj.tag == "Sprite")
				tg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
		}
		
		EnemyCaveBuildings();	
		
		tg.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
				
		if (creatureObj != null)
		{
			if (creatureObj.tag == "Hound")
			{
				Destroy(GameObject.Find("HoundAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Barg")
			{
				Destroy(GameObject.Find("BargAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Cusith")
			{
				Destroy(GameObject.Find("CusithAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Sprout")
			{
				Destroy(GameObject.Find("SproutAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Nymph")
			{
				Destroy(GameObject.Find("NymphAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Dryad")
			{
				Destroy(GameObject.Find("DryadAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Nix")
			{
				Destroy(GameObject.Find("NixAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Draug")
			{
				Destroy(GameObject.Find("DraugAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Dragon")
			{
				Destroy(GameObject.Find("DragonAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Leech")
			{
				Destroy(GameObject.Find("LeechAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Leshy")
			{
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Lurker")
			{
				Destroy(GameObject.Find("LeshyAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "DHound")
			{
				Destroy(GameObject.Find("DHoundAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Fenrir")
			{
				Destroy(GameObject.Find("FenrirAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "HellHound")
			{
				Destroy(GameObject.Find("HellHoundAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
				creatureObj.transform.FindChild("shadow").gameObject.active = true;
			}
			else if (creatureObj.tag == "Djinn")
			{
				Destroy(GameObject.Find("DjinnAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Imp")
			{
				Destroy(GameObject.Find("ImpAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
			else if (creatureObj.tag == "Sprite")
			{
				Destroy(GameObject.Find("SpriteAttack(Clone)").gameObject);
				creatureObj.GetComponent<MeshRenderer>().enabled = true;
			}
		}
				
				
		taskidSvr = scr_loadUserWorld.ReturnTaskId(typeID); //scr_GameObjSvr.objGoblinCamp02.objTypeId);
				
		inventoryInfo.RemoveItem(taskDetailsInfo.Four_Half_task3);
		taskDetailsInfo.Four_Half_task3_bool = true;
	}
}

