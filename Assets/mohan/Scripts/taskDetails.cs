using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class taskDetails : MonoBehaviour 
{
	private guiControl gc;
	private QuestTextureControl scr_QuestTexControl;
	private GameManager scr_Gamemanager;
	private disableScript ds;
	public popUpInformation popUpInfoScript;
	
	private Inventory inv;
	private Inventory1 inv1;
	private Inventory2 inv2;
	private LoadUserWorld scr_UserWorld;
	
		
	public GameObject Three_Half_task1,Three_Half_task2,Three_Half_task3,Three_Half_task4,
						Four_Half_task1,Four_Half_task2,Four_Half_task3,Four_Half_task4,
						Five_Half_task1,Five_Half_task2,Five_Half_task3,Five_Half_task4, 
						Six_Half_task1,Six_Half_task2,Six_Half_task3,Six_Half_task4,
						Seven_Half_task1,Seven_Half_task2,
						Eight_Half_task1,Eight_Half_task2,Eight_Half_task3, 
						Nine_Half_task1,Nine_Half_task2,Nine_Half_task3,
						Ten_Half_task1,Ten_Half_task2,Ten_Half_task3,Ten_Half_task4, 
						Eleven_Half_task1,Eleven_Half_task2,
						Twelve_Half_task1,Twelve_Half_task2,Twelve_Half_task3,Twelve_Half_task4,
						Thirteen_Half_task1,Thirteen_Half_task2,
						Fourteen_Half_task1,Fourteen_Half_task2,Fourteen_Half_task3 ; 
	

	public bool Three_Half_task1_bool,Three_Half_task2_bool,Three_Half_task3_bool,Three_Half_task4_bool,
				Four_Half_task1_bool,Four_Half_task2_bool,Four_Half_task3_bool,Four_Half_task4_bool,
				Five_Half_task1_bool,Five_Half_task2_bool,Five_Half_task3_bool,Five_Half_task4_bool,
				Six_Half_task1_bool,Six_Half_task2_bool,Six_Half_task3_bool,Six_Half_task4_bool,
				Seven_Half_task1_bool,Seven_Half_task2_bool,
				Eight_Half_task1_bool,Eight_Half_task2_bool,Eight_Half_task3_bool,
				Nine_Half_task1_bool,Nine_Half_task2_bool,Nine_Half_task3_bool,
				Ten_Half_task1_bool,Ten_Half_task2_bool,Ten_Half_task3_bool,Ten_Half_task4_bool,
				Eleven_Half_task1_bool,Eleven_Half_task2_bool,
				Twelve_Half_task1_bool,Twelve_Half_task2_bool,Twelve_Half_task3_bool,Twelve_Half_task4_bool,
				Thirteen_Half_task1_bool,Thirteen_Half_task2_bool,
				Fourteen_Half_task1_bool,Fourteen_Half_task2_bool,Fourteen_Half_task3_bool;
	
	
	public GameObject 	Four_Dark_task1,Four_Dark_task2,Four_Dark_task3,Four_Dark_task4,Four_Dark_task5,
						Five_Dark_task1,Five_Dark_task2,Five_Dark_task3,Five_Dark_task4,Five_Dark_task5, 
						Six_Dark_task1,Six_Dark_task2,Six_Dark_task3,Six_Dark_task4, 
						Seven_Dark_task1,Seven_Dark_task2,Seven_Dark_task3, 
						Eight_Dark_task1, 
						Nine_Dark_task1,Nine_Dark_task2, 
						Ten_Dark_task1,Ten_Dark_task2,Ten_Dark_task3, 
						Eleven_Dark_task1,Eleven_Dark_task2,Eleven_Dark_task3,
						Twelve_Dark_task1,Twelve_Dark_task2,
						Thirteen_Dark_task1,Thirteen_Dark_task2,Thirteen_Dark_task3,Thirteen_Dark_task4,
						Fourteen_Dark_task1,Fourteen_Dark_task2;
	
	
	public bool Four_Dark_task1_bool,Four_Dark_task2_bool,Four_Dark_task3_bool,Four_Dark_task4_bool,Four_Dark_task5_bool,
				Five_Dark_task1_bool,Five_Dark_task2_bool,Five_Dark_task3_bool,Five_Dark_task4_bool,Five_Dark_task5_bool,
				Six_Dark_task1_bool,Six_Dark_task2_bool,Six_Dark_task3_bool,Six_Dark_task4_bool,
				Seven_Dark_task1_bool,Seven_Dark_task2_bool,Seven_Dark_task3_bool,
				Eight_Dark_task1_bool,
				Nine_Dark_task1_bool,Nine_Dark_task2_bool,
				Ten_Dark_task1_bool,Ten_Dark_task2_bool,Ten_Dark_task3_bool,
				Eleven_Dark_task1_bool,Eleven_Dark_task2_bool,Eleven_Dark_task3_bool,
				Twelve_Dark_task1_bool,Twelve_Dark_task2_bool,
				Thirteen_Dark_task1_bool,Thirteen_Dark_task2_bool,Thirteen_Dark_task3_bool,Thirteen_Dark_task4_bool,
				Fourteen_Dark_task1_bool,Fourteen_Dark_task2_bool;
	
	public GameObject questMenuQuestLog,questMenuHalflingMission,questMenuDarklinkMission,halflingMissions,darklingMissions,questLogMissions;
	
	public bool halfbool = false;
	public bool darkbool = false;
	public bool questbool = false;
	
	public bool HalflingLevelThreeBool,HalflingLevelFourBool,HalflingLevelFiveBool,HalflingLevelSixBool,HalflingLevelSevenBool,HalflingLevelEightBool,
				HalflingLevelNineBool,HalflingLevelTenBool,HalflingLevelElevenBool,HalflingLevelTwelveBool,HalflingLevelThirteenBool,HalflingLevelFourteenBool;
	
	
	public bool darklingLevelFourBool,darklingLevelFiveBool,darklingLevelSixBool,darklingLevelSevenBool,darklingLevelEightBool,darklingLevelNineBool,
				darklingLevelTenBool,darklingLevelElevenBool,darklingLevelTwelveBool,darklingLevelThirteenBool,darklingLevelFourteenBool;
	
//	public SpriteText Three_Half_task1_Text,Three_Half_task2_Text,Three_Half_task3_Text,Three_Half_task4_Text,
//						Four_Half_task1_Text,Four_Half_task2_Text,Four_Half_task3_Text,Four_Half_task4_Text,
//						Five_Half_task1_Text,Five_Half_task2_Text,Five_Half_task3_Text,Five_Half_task4_Text, 
//						Six_Half_task1_Text,Six_Half_task2_Text,Six_Half_task3_Text,Six_Half_task4_Text,
//						Seven_Half_task1_Text,Seven_Half_task2_Text,
//						Eight_Half_task1_Text,Eight_Half_task2_Text,Eight_Half_task3_Text,
//						Nine_Half_task1_Text,Nine_Half_task2_Text,Nine_Half_task3_Text,
//						Ten_Half_task1_Text,Ten_Half_task2_Text,Ten_Half_task3_Text,Ten_Half_task4_Text, 
//						Eleven_Half_task1_Text,Eleven_Half_task2_Text,
//						Twelve_Half_task1_Text,Twelve_Half_task2_Text,Twelve_Half_task3_Text,Twelve_Half_task4_Text,
//						Thirteen_Half_task1_Text,Thirteen_Half_task2_Text,
//						Fourteen_Half_task1_Text,Fourteen_Half_task2_Text,Fourteen_Half_task3_Text;
//
//	
//	
//	public SpriteText	Four_Dark_task1_Text,Four_Dark_task2_Text,Four_Dark_task3_Text,Four_Dark_task4_Text,Four_Dark_task5_Text,
//						Five_Dark_task1_Text,Five_Dark_task2_Text,Five_Dark_task3_Text,Five_Dark_task4_Text,Five_Dark_task5_Text,
//						Six_Dark_task1_Text,Six_Dark_task2_Text,Six_Dark_task3_Text,Six_Dark_task4_Text,
//						Seven_Dark_task1_Text,Seven_Dark_task2_Text,Seven_Dark_task3_Text,
//						Eight_Dark_task1_Text, 
//						Nine_Dark_task1_Text,Nine_Dark_task2_Text,
//						Ten_Dark_task1_Text,Ten_Dark_task2_Text,Ten_Dark_task3_Text,
//						Eleven_Dark_task1_Text,Eleven_Dark_task2_Text,Eleven_Dark_task3_Text,
//						Twelve_Dark_task1_Text,Twelve_Dark_task2_Text,
//						Thirteen_Dark_task1_Text,Thirteen_Dark_task2_Text,Thirteen_Dark_task3_Text,Thirteen_Dark_task4_Text,
//						Fourteen_Dark_task1_Text,Fourteen_Dark_task2_Text;
	
	public GameObject Four_Quest,Five_Quest,Six_Quest,Seven_Quest,Eight_Quest,Nine_Quest,Ten_Quest,Eleven_Quest,Twelve_Quest,Thirteen_Quest,Fourteen_Quest;
		
	public bool Four_Quest_bool,Five_Quest_bool,Six_Quest_bool,Seven_Quest_bool,Eight_Quest_bool,Nine_Quest_bool,Ten_Quest_bool,
				Eleven_Quest_bool,Twelve_Quest_bool,Thirteen_Quest_bool,Fourteen_Quest_bool;
	
	public SpriteText Four_Quest_Text,Five_Quest_Text,Six_Quest_Text,Seven_Quest_Text,Eight_Quest_Text, Nine_Quest_Text,Ten_Quest_Text,
					  Eleven_Quest_Text,Twelve_Quest_Text,Thirteen_Quest_Text,Fourteen_Quest_Text;
	
	public bool QuestLevelFourBool,QuestLevelFiveBool,QuestLevelSixBool,QuestLevelSevenBool,QuestLevelEightBool,QuestLevelNineBool,
				QuestLevelTenBool,QuestLevelElevenBool,QuestLevelTwelveBool,QuestLevelThirteenBool,QuestLevelFourteenBool;
	
	public SpriteText RedQuestCount,blueQuestCount;
	public GameObject redCount,blueCount;
	
//	string[] level_Three_Halfling_Missions =	{"Purchase plant Training \nGround.",
//											"Grow Sprout.",
//										  	"Grow one pipeweed.",
//										  	"Grow one Turnip."
//											};
//	
//	string[] level_Four_Halfling_Missions =		{"Level Upgrade Earth TG.",
//							 			 	"Grow Barg creature.",
//							 			 	"Attack goblin cave 2.",
//							 			 		"Buy Garden Plot."
//											};
//	
//	string[] level_Five_Halfling_Missions =		{"Buy water TG.",
//										 	"Grow Nix Creature.",
//										 	"Buy Stable.",
//										 	"Grow one pumpkin.",
//											};
//	
//	string[] level_Six_Halfling_Missions = 		{"Open Halfling Battle Ground",//////
//												"Grow Nympth Creature.",
//											 	"Buy Halfling \nBlacksmith.",
//										 	"Attack Goblin Camp."
//											};
//	
//	string[] level_Seven_Halfling_Missions =	{"Buy Garden Plot.",
//											 	"Grow pipeweed for \nHalfling to smoke."///////
//											};
//	
//	string[] level_Eight_Halfling_Missions =	{"Grow Draug Creature.",
//											 	"Grow Cusith Creature.",
//											 	"Attack Troll Cave."
//											};
//	
//	string[] level_Nine_Halfling_Missions =		{"Grow Dryad Creature.",
//											 	"Buy Halfling Tavern.",
//												"Buy Plant Obelisk."
//											};
//	
//	string[] level_Ten_Halfling_Missions = 		{"Buy Garden Plot.",
//												"Grow Potatos.",
//											 	"Buy Halfling \nApothecary.",
//											 	"Attack Troll Cave."
//												};
//	
//	string[] level_Eleven_Halfling_Missions =	{"Grow Fairlily Herb.",
//												"Buy water obelisk"
//											};
//	
//	string[] level_Twelve_Halfling_Missions =	{"Grow Dagon Creature.",
//											 	"Grow watercess Herb.",
//											 	"Buy Sun shrine.",//
//										 	"Attack Troll Cave."
//											};
//	
//	string[] level_Thirteen_Halfling_Missions=	{"Buy Garden Plot.",
//												"Grow Vervain Herb."//
//											};
//	
//	string[] level_Fourteen_Halfling_Missions =	{"Buy breeding cave.",//
//												"Grow Mandrake Herb.",//
//												"Attack Orc cave"//
//											};
	
	
//	string[] level_Four_Darkling_Missions =		{
//		                                         "Buy Darkling Inn.",
//											 	"Buy Garden Plot.",
//											 	"Plant one pumpkin.",
//												"Place a well near \nDarkling House.",
//												"Place a dirt path near \ndarkling house",
//		                                         "Purchase Swamp training Ground",
//		                                         "Grow Leech creature",
//												};
//	
//	string[] level_Five_Darkling_Missions =		{"Buy Dark Earth TG.",
//												"Grow Hound.",
//											 	"Buy Dark Stable.",
//											 	"Grow one FirePepper.",
//											 	"Attack Goblin Camp."//
//												};
//	
//	string[] level_Six_Darkling_Missions = 		{"Open Darkling Battle Ground",///////
//												"Buy Fire \nTraning Ground.",
//											 	"Grow Sprite Creature.",
//									 			"Buy Darkling \nBlacksmith."
//												};
//		
//	string[] level_Seven_Darkling_Missions =	{"Buy Garden Plot.",
//											 	"Plant Aven Herb.",
//											 	"Attack Goblin Camp."//
//												};
//	
//	string[] level_Eight_Darkling_Missions =	{"Grow Fenrir Creature."
//											};
//	
//	string[] level_Nine_Darkling_Missions =		{"Grow Imp Creature.",
//											 	"Attack Goblin Camp."//
//											};
//	
//	string[] level_Ten_Darkling_Missions = 		{"Buy Garden Plot.",
//											 	"Grow Blackberry.",//
//										 	"Buy Darkling \nApothecary."
//											};
//	
//	string[] level_Eleven_Darkling_Missions =	{"Grow Columbine Herb.",
//												 "Attack Troll Cave.",//
//												 "Buy Fire Obelisk."
//											};
//	
//	string[] level_Twelve_Darkling_Missions =	{"Grow Lurker Creature.",
//											 	"Grow Bitter brush Herb."//
//												};
//			
//	string[] level_Thirteen_Darkling_Missions =	{"Grow HellHound \nCreature.",
//												"Buy Garden Plot.",
//												"Grow Bogbean Herb.",//
//												"Attack Troll Cave."//
//											};
//	
//	string[] level_Fourteen_Darkling_Missions =	{"Buy breeding cave.",//
//												"Grow Wolfsbane Herb",//
//											};
	
//	string[] level_Six_Darkling_Missions = 		{"Open Darkling Battle Ground",///////
//												"Buy Fire \nTraning Ground.",
//											 	"Grow Sprite Creature.",
//									 			"Buy Darkling \nBlacksmith."
//												};
//		
//	string[] level_Seven_Darkling_Missions =	{"Buy Garden Plot.",
//											 	"Plant Aven Herb.",
//											 	"Attack Goblin Camp."//
//												};
//	
//	string[] level_Eight_Darkling_Missions =	{"Grow Fenrir Creature."
//											};
//	
//	string[] level_Nine_Darkling_Missions =		{"Grow Imp Creature.",
//											 	"Attack Goblin Camp."//
//											};
//	
//	string[] level_Ten_Darkling_Missions = 		{"Buy Garden Plot.",
//											 	"Grow Blackberry.",//
//										 	"Buy Darkling \nApothecary."
//											};
//	
//	string[] level_Eleven_Darkling_Missions =	{"Grow Columbine Herb.",
//												 "Attack Troll Cave.",//
//												 "Buy Fire Obelisk."
//											};
//	
//	string[] level_Twelve_Darkling_Missions =	{"Grow Lurker Creature.",
//											 	"Grow Bitter brush Herb."//
//												};
//			
//	string[] level_Thirteen_Darkling_Missions =	{"Grow HellHound \nCreature.",
//												"Buy Garden Plot.",
//												"Grow Bogbean Herb.",//
//												"Attack Troll Cave."//
//											};
//	
//	string[] level_Fourteen_Darkling_Missions =	{"Buy breeding cave.",//
//												"Grow Wolfsbane Herb",//
//											};
	
//	string[] level_Four_Missions =	{""}; //"Quest 2: Open Darkling \nMap and explore the \nother side of the world."
//	
//	string[] level_Five_Missions =	{"Story 2"};			 //{"Quest 3: Burry Sparks in \nSwamp TG and Grow \nLeech."
//	
//	string[] level_Six_Missions =				{"Quest 4: Send Darkling \nto find Leech."
//											};
//	
//	string[] level_Seven_Missions =				{"Quest 5: Morph Bigger \nCreature"//Open Darkling \nBattle Ground and Fight \nEnemy.
//											};
//	
//	string[] level_Eight_Missions =				{"Quest 6: New Creature."
//											};
//	
//	string[] level_Nine_Missions =				{"Quest 7: Show Me The \nMoney."
//											};
//	
//	string[] level_Ten_Missions =				{"Quest 8: Strange Brew."
//											};
//	
//	string[] level_Eleven_Missions =			{"Quest 9: Master Of The \nHouse."
//											};
//	
//	string[] level_Twelve_Missions =			{"Quest 10: A Lingering \nDarkness."
//											};
//	
//	string[] level_Thirteen_Missions = 			{"Quest 11: The Guardian"
//											};
//	
//	string[] level_Fourteen_Missions =			{"Quest 12: The Hunt"
//												};
	
	private SfsRemote scr_sfsRemote;
	private GameObjectsSvr scr_gameObjSvr;
	
	public GameObject playQuest;
	
	public GameObject halflingQuest, darklingQuest, scrollList;
	private GameObject halflingScrollList, darklingScrollList;
	public SpriteText taskDescription;
	public GameObject questTitle, questDetails;
	private bool isHalflingQuest, isDarklingQuest;
	
	public Dictionary<int, Dictionary<string,string>> halflingQuestTask = new Dictionary<int, Dictionary<string,string>>();
	public Dictionary<int, Dictionary<string,string>> darklingQuestTask = new Dictionary<int, Dictionary<string,string>>();
	
	private GameObject storyLogScrollList;
	public GameObject storyLogQuest, storyTitle, storyDetails, lockPrefab, unlockPrefab;
	
	public class StoryContent
	{
		public int status;
		public int storyNo;
		public string storyDetail;
	}
	public List<StoryContent> storyList = new List<StoryContent>();
	
	public Dictionary<int, List<StoryContent>> storyLogTask = new Dictionary<int, List<StoryContent>>();
	
	void Awake()
	{
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_gameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_UserWorld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
	}
	
	void Start () 
	{
		inv = (Inventory)FindObjectOfType(typeof(Inventory));
		inv1 = (Inventory1)FindObjectOfType(typeof(Inventory1));
		inv2 = (Inventory2)FindObjectOfType(typeof(Inventory2));
		ds = (disableScript)FindObjectOfType(typeof(disableScript));
		gc = (guiControl)FindObjectOfType(typeof(guiControl));
		scr_QuestTexControl = GameObject.Find("GameManager").GetComponent<QuestTextureControl>();
		scr_Gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		if(gc.Halfbtn ==true)
		{
			//questLogButton();
			//questLog();
			halflingMissionButton();
			//half();
				
		}
	}
	GameObject hand;
	
	public void CancleStoryPopUp()
	{
		popUpInfoScript.wall.active = false;
			buttonPulse bp = GameObject.Find("taskCancleButton").GetComponent("buttonPulse") as buttonPulse;
			gc.taskList.SetActiveRecursively(false);
			gc.Halfbtn=false;
			
//			halflingMissions.SetActiveRecursively(false);
//			darklingMissions.SetActiveRecursively(false);
//			questLogMissions.SetActiveRecursively(false);
			hand = GameObject.Find("gameArrowPF(Clone)");
			if(hand != null){
			Destroy(hand);
			}
			halfbool = false;
			darkbool =false;
			questbool = false;
			
			ds.HalflingEntry = false;
			ds.DarklingEntry = false;
			ds.QuestLogEntry = false;
			
			ds.HalflingCurrentTaskNumber = 0;
			ds.DarklingCurrentTaskNumber = 0;
			ds.QuestCurrentTaskNumber=0;
			
			playQuest.active = false;
			
			guiControl.popUpOpenBool = false;
			
			halflingQuest.SetActiveRecursively(false);
		storyLogQuest.SetActiveRecursively(false);
			darklingQuest.SetActiveRecursively(false);
			taskDescription.Text = "";
			Destroy(halflingScrollList);
			Destroy(darklingScrollList);
	}
	
	public void cancleButton()
	{
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.wall.active = false;
			//buttonPulse bp = GameObject.Find("cancel_Btn").GetComponent("buttonPulse") as buttonPulse;
			gc.taskList.SetActiveRecursively(false);
			gc.Halfbtn=false;
			
//			halflingMissions.SetActiveRecursively(false);
//			darklingMissions.SetActiveRecursively(false);
//			questLogMissions.SetActiveRecursively(false);
			hand = GameObject.Find("gameArrowPF(Clone)");
			if(hand != null){
			Destroy(hand);
			}
			halfbool = false;
			darkbool =false;
			questbool = false;
			
			ds.HalflingEntry = false;
			ds.DarklingEntry = false;
			ds.QuestLogEntry = false;
			
			ds.HalflingCurrentTaskNumber = 0;
			ds.DarklingCurrentTaskNumber = 0;
			ds.QuestCurrentTaskNumber=0;
			
			playQuest.active = false;
			
			guiControl.popUpOpenBool = false;
			
		isHalflingQuest = false;
		isDarklingQuest = false;
			halflingQuest.SetActiveRecursively(false);
			storyLogQuest.SetActiveRecursively(false);
			darklingQuest.SetActiveRecursively(false);
			taskDescription.Text = "";
			Destroy(halflingScrollList);
			Destroy(darklingScrollList);
			DestroyChild(storyLogQuest);	//Added
			showStoryNo.Clear();
		}
	}
	
	public void questLogButton()			//quest log button
	{
		//if (PlayerPrefs.GetInt("questtutorial") != 0)
//		GameObject arrowDelObj = GameObject.Find("gameArrowPF(Clone)") as GameObject;
//		if (arrowDelObj != null)
//			Destroy(arrowDelObj);
		
		if (GameManager.taskCount == 15)
			popUpInfoScript.storyTutorial(2);
			
		if (GameManager.taskCount >= 15)
		{
			buttonPulse bp = GameObject.Find("Questmenu_QuestLog_btn").GetComponent("buttonPulse") as buttonPulse;
			
			questMenuQuestLog.active = true ;
			questMenuHalflingMission.active = false;
			questMenuDarklinkMission.active = false;
			
//			halflingMissions.SetActiveRecursively(false);
//			darklingMissions.SetActiveRecursively(false);
//			questLogMissions.SetActiveRecursively(true);
			
			playQuest.active = false;
			
			ds.HalflingEntry = false;
			ds.DarklingEntry = false;
			ds.QuestLogEntry = true;
			
			halflingQuest.SetActiveRecursively(false);
			storyLogQuest.SetActiveRecursively(true);
			darklingQuest.SetActiveRecursively(false);
			taskDescription.Text = "";
			Destroy(halflingScrollList);
			Destroy(darklingScrollList);
			
			ds.HalflingCurrentTaskNumber = 0;
			ds.DarklingCurrentTaskNumber = 0;
			
			scr_sfsRemote.SendRequestforGetHerbs();  //herbs svr
			
//			if(questbool == false)
//			{
//				questLog();
//			}
			QuestStoryLog();
		}
	}
	
	public int totalMissionCount;
	public void mainpanel()
	{
//		Debug.Log("Clicked on main panel");
//		half();
//		dark();
//		questLog();
		//int totalMissionCount;
		//totalMissionCount = inv.halfLengthCount + inv1.darkLengthCount;

//		Debug.Log("totalMissionCount : "+totalMissionCount);
		
		//RedQuestCount.Text = inv2.QuestLengthCount.ToString();
//		RedQuestCount.Text = storyCount.ToString();				//Remove and add in sfs remote when server sends response
//		blueQuestCount.Text = totalMissionCount.ToString();		// Remove and add in sfs remote when server sends response 
		
		if (GameManager.gameLevel >= 3)
		{
			//if(inv2.QuestLengthCount <= 0)
			if(storyList.Count <= 0)
			{
				redCount.active = false;
				RedQuestCount.gameObject.active = false;
			}
			else
			{
				redCount.active = true;
				RedQuestCount.gameObject.active = true;
			}
			if(totalMissionCount <= 0)
			{
				blueCount.active = false;
				blueQuestCount.gameObject.active = false;
			}
			else
			{
				blueCount.active = true;
				blueQuestCount.gameObject.active = true;
			}
		}
	}
	
	public void halflingMissionButton()		//Halfling button
	{
		Debug.Log ("i am here now...");
		buttonPulse bp = GameObject.Find("Questmenu_HalflingMenu_btn").GetComponent("buttonPulse") as buttonPulse;
		
		questMenuQuestLog.active = false ;
		questMenuHalflingMission.active = true;
		questMenuDarklinkMission.active = false;

//		halflingMissions.SetActiveRecursively(true);
//		darklingMissions.SetActiveRecursively(false);
//		questLogMissions.SetActiveRecursively(false);
		
		playQuest.active = false;
		
		ds.HalflingEntry = true;
		ds.DarklingEntry = false;
		ds.QuestLogEntry = false;
		
		ds.QuestCurrentTaskNumber=0;
		ds.DarklingCurrentTaskNumber = 0;
		
		if(halfbool == false)
		{
			//half();
		}
		
		isHalflingQuest = true;
		isDarklingQuest = false;
		taskDescription.Text = "";
		halflingQuest.SetActiveRecursively(true);
		storyLogQuest.SetActiveRecursively(false);
		darklingQuest.SetActiveRecursively(false);
		
		QuestList(true);
		Debug.Log("Halfling clicked");		//Instantiate here
	}
	
	public void darklingMissionButton()			//Darkling button
	{
		if(GameManager.unlockDarklingBool)
		{
			buttonPulse bp = GameObject.Find("Questmenu_DarklingMenu_btn").GetComponent("buttonPulse") as buttonPulse;
			
			questMenuQuestLog.active = false ;
			questMenuHalflingMission.active = false;
			questMenuDarklinkMission.active = true;
			
//			darklingMissions.SetActiveRecursively(true);
//			halflingMissions.SetActiveRecursively(false);
//			questLogMissions.SetActiveRecursively(false);
			
			playQuest.active = false;
			
			ds.HalflingEntry = false;
			ds.DarklingEntry = true;
			ds.QuestLogEntry = false;
			
			ds.QuestCurrentTaskNumber=0;
			ds.HalflingCurrentTaskNumber = 0;
			
///***			Debug.Log("darkling clicked");
			isHalflingQuest = false;
			isDarklingQuest = true;
			taskDescription.Text = "";
			halflingQuest.SetActiveRecursively(false);
			storyLogQuest.SetActiveRecursively(false);
			darklingQuest.SetActiveRecursively(true);
		
			QuestList(false);
		}
	}
	
	//Halfling and darkling quest task
	private void QuestList(bool isHalfling)
	{
		if(halflingQuestTask.Count > 0 && isHalfling)
		{
			//Debug.Log("halflingQuest");
			DestroyChild(halflingQuest);
			halflingScrollList = Instantiate(scrollList) as GameObject;
			halflingScrollList.transform.parent = halflingQuest.transform;
			halflingScrollList.transform.localPosition = new Vector3(0.3f, 15f, -4.5f);
			halflingScrollList.transform.name = "HalflingScrollList";
		
			foreach(int level in halflingQuestTask.Keys)
			{
				//Debug.Log("Level : "+level);
				foreach(string task in halflingQuestTask[level].Keys)
				{
					string title = task;
					string details = halflingQuestTask[level][task];
		
					title = title.Replace(@"\n","\n");
					details = details.Replace(@"\n","\n");
		
					//Debug.Log("Halfling Task : "+title);
					//Debug.Log("Halfling Task Details : "+details);
		
					GameObject halflingQuestTitle = Instantiate(questTitle) as GameObject;
					halflingQuestTitle.transform.FindChild("ButtonText").GetComponent<SpriteText>().Text = title;
					halflingQuestTitle.transform.name = title;
		
					GameObject halflingQuestDetails = Instantiate(questDetails) as GameObject;
					halflingQuestDetails.GetComponent<SpriteText>().Text = details;
					halflingQuestDetails.transform.parent = GameObject.Find(title).transform;
					halflingQuestDetails.transform.localPosition = new Vector3(100f, 1f, 1f);
		
					halflingScrollList.GetComponent<UIScrollList>().AddItem(halflingQuestTitle);
					halflingQuestTitle.gameObject.transform.FindChild("Button").GetComponent<UIButton>().scriptWithMethodToInvoke = this;
				}
				Destroy(darklingScrollList);
				//storyList.Clear();
			}
		}
		
		if(darklingQuestTask.Count > 0 && !isHalfling)
		{
			DestroyChild(darklingQuest);
			darklingScrollList = Instantiate(scrollList) as GameObject;
			darklingScrollList.transform.parent = darklingQuest.transform;
			darklingScrollList.transform.localPosition = new Vector3(0.3f, 15f, -4.5f);
			darklingScrollList.transform.name = "DarklingScrollList";
	
			foreach(int level in darklingQuestTask.Keys)
			{
				//Debug.Log("Level : "+level);
				foreach(string task in darklingQuestTask[level].Keys)
				{
					string title = task;
					string details = darklingQuestTask[level][task];
					
					title = title.Replace(@"\n","\n");
					details = details.Replace(@"\n","\n");
					
					//Debug.Log("Darkling Task : "+title);
					//Debug.Log("Darkling Task Details : "+details);
					
					GameObject darklingQuestTitle = Instantiate(questTitle) as GameObject;
					darklingQuestTitle.transform.FindChild("ButtonText").GetComponent<SpriteText>().Text = title;
					darklingQuestTitle.transform.name = title;
					
					GameObject darklingQuestDetails = Instantiate(questDetails) as GameObject;
					darklingQuestDetails.GetComponent<SpriteText>().Text = details;
					darklingQuestDetails.transform.parent = GameObject.Find(title).transform;
					darklingQuestDetails.transform.localPosition = new Vector3(100f, 1f, 1f);
		
					darklingScrollList.GetComponent<UIScrollList>().AddItem(darklingQuestTitle);
					darklingQuestTitle.gameObject.transform.FindChild("Button").GetComponent<UIButton>().scriptWithMethodToInvoke = this;
				}
				Destroy(halflingScrollList);
				//storyList.Clear();
			}
		}
	}		
	
	private void DestroyChild(GameObject destroyObject)
	{
		foreach(Transform child in destroyObject.transform)
		{
///***			Debug.Log("child : "+child.name);
			Destroy(child.gameObject);
		}
	}
	
	public void ShowTaskDetails()
	{
		//Debug.Log("isHalflingQuest : "+isHalflingQuest);
		//Debug.Log("isDarklingQuest : "+isDarklingQuest);
		//if(GameManager.gameLevel >= 3)
		if(GameManager.gameLevel >= 2)
		{
			if(isHalflingQuest)
			{
///***				Debug.Log("Parent : "+halflingScrollList.GetComponent<UIScrollList>().LastClickedControl.transform.parent.name);
				taskDescription.Text = "";
				//halflingScrollList.GetComponent<UIScrollList>().LastClickedControl
				GameObject taskHeader = halflingScrollList.GetComponent<UIScrollList>().LastClickedControl.transform.parent.gameObject;
				taskDescription.Text = taskHeader.transform.FindChild("QuestDetails(Clone)").GetComponent<SpriteText>().Text;
			}
			if(isDarklingQuest)
			{
///***				Debug.Log("Parent : "+darklingScrollList.GetComponent<UIScrollList>().LastClickedControl.transform.parent.name);
				taskDescription.Text = "";
				GameObject taskHeader = darklingScrollList.GetComponent<UIScrollList>().LastClickedControl.transform.parent.gameObject;
				taskDescription.Text = taskHeader.transform.FindChild("QuestDetails(Clone)").GetComponent<SpriteText>().Text;
			}
		}
	}
	
	private GameObject FindChild(GameObject parentGameObject)
	{
		foreach(Transform child in parentGameObject.transform)
		{
			return child.gameObject;	
		}
		return null;
	}
		
	public void QuestStoryLog()
	{
		Debug.Log("storyList.Count : "+storyList.Count );
		if(storyList.Count > 0)
		{
			DestroyChild(storyLogQuest);
			storyList.Sort(delegate(StoryContent s1, StoryContent s2)
			               {
				return s1.storyNo.CompareTo(s2.storyNo);	
			});
			
			storyLogScrollList = Instantiate(scrollList) as GameObject;
			storyLogScrollList.transform.parent = storyLogQuest.transform;
			storyLogScrollList.transform.localPosition = new Vector3(0.3f, 15f, -4.5f);
			storyLogScrollList.transform.name = "StoryLogList";
			
			for(int i=0; i<storyList.Count; i++)
			{
				GameObject storyLogTtile = Instantiate(storyTitle) as GameObject;
				storyLogTtile.transform.FindChild("StoryText").GetComponent<SpriteText>().Text = "Story "+storyList[i].storyNo.ToString();
				//storyLogTtile.transform.name = storyList[i].storyNo.ToString();
				storyLogTtile.transform.name = storyLogTtile.transform.FindChild("StoryText").GetComponent<SpriteText>().Text;
				
				GameObject storyLogDetail = Instantiate(storyDetails) as GameObject;
				storyLogDetail.GetComponent<SpriteText>().Text = storyList[i].storyDetail;
				storyLogDetail.transform.parent = storyLogTtile.transform;
				storyLogDetail.transform.localPosition = new Vector3(100f, 1f, 1f);
				
				storyLogScrollList.GetComponent<UIScrollList>().AddItem(storyLogTtile);
				storyLogTtile.gameObject.transform.FindChild("StoryButton").GetComponent<UIButton>().scriptWithMethodToInvoke = this;
				
				if(GameManager.gameLevel == 2)				//temp
				{
					storyList[0].status = 1;
				}
				if(isLocked(storyList[i].status))
				{
					//GameObject storyLockTexture = Instantiate(lockPrefab) as GameObject;
					//storyLockTexture.transform.parent = storyLogTtile.transform;
					//storyLockTexture.transform.localPosition = new Vector3(-10f, 0f, -1f);
					storyLogTtile.transform.FindChild("Lock").gameObject.SetActive(true);
					storyLogTtile.transform.FindChild("Unlock").gameObject.SetActive(false);
					storyLogTtile.gameObject.transform.FindChild("StoryButton").GetComponent<UIButton>().methodToInvoke = "StoryDummyButton";
				}
				else if(!isLocked(storyList[i].status))
				{
					//GameObject storyUnlockTexture = Instantiate(unlockPrefab) as GameObject; indra
					storyLogTtile.transform.FindChild("Unlock").gameObject.SetActive(true);
					storyLogTtile.transform.FindChild("Lock").gameObject.SetActive(false);
					//storyUnlockTexture.transform.parent = storyLogTtile.transform;
					//storyUnlockTexture.transform.localPosition = new Vector3(-10f, 0f, -1f);
					storyLogTtile.gameObject.transform.FindChild("StoryButton").GetComponent<UIButton>().methodToInvoke = "StoryButton";
				}
			}
			Destroy(halflingScrollList);
			Destroy(darklingScrollList);
		}
	}
	
	private int storyCount;
	private void StoryButton()
	{
		//Debug.Log("StoryButton");
		if(GameManager.taskCount == 15)				//temp
			gc.stroy01Button();
		taskDescription.Text = "";
		playQuest.active = true;
		GameObject taskHeader = storyLogScrollList.GetComponent<UIScrollList>().LastClickedControl.transform.parent.gameObject;
		taskDescription.Text = taskHeader.transform.FindChild("StoryDetails(Clone)").GetComponent<SpriteText>().Text;
		
		string [] str = taskHeader.name.ToString().Split(new string [] {"Story"}, System.StringSplitOptions.None);
		//		Debug.Log("0 : "+str[0]);
		//		Debug.Log("1 : "+str[1]);
		
		//storyCount = int.Parse(taskHeader.name);
		storyCount = int.Parse(str[1]);
		Debug.Log("Story no. : "+storyCount);

		if(showStoryNo.Count > 0)
			showStoryNo.RemoveAt(0);
		showStoryNo.Add(storyCount);
	}
	
	private void StoryDummyButton()
	{
		taskDescription.Text = "";
		playQuest.active = false;
	}
	
	private bool isLocked(int which)
	{
		if(which == 0)
			return true;
		
		return false;
	}

	public bool isStory;
	//public int storyNo;
	public List<int> showStoryNo = new List<int>();
	public void ShowCurrentStory(int storyNo, int click)
	{
		//Debug.Log("Show story no : "+storyNo);

		Debug.Log("Showstory "+showStoryNo[storyNo]+" ------- click : "+click);

		switch(showStoryNo[storyNo])
		{
		case 1:				//Screenshot 009
			switch(click)
			{
			case 0 :
				Debug.Log("Story 1 message 1 ");
				gc.popUpType5.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest02a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_2B[click];
				//guiControlInfo.popUpType_Dig1_spText.Text = message;
				scr_Gamemanager.WriteText3();
				break;
				
			case 1:
				gc.popUpType_Dig5_spText.Text = scr_Gamemanager.message;
				break;
				
			case 2:
			case 3:
			case 4:
				gc.popUpType5.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;
			
		case 2:				//Screenshot 010
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_2A[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_2A[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
				scr_Gamemanager.message = scr_Gamemanager.quest_2A[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_2A[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 13 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				
				break;
				
			case 14 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default :
				break;
			}
			break;

		case 3:				//Screenshot 11
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest03_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_3[click];
				scr_Gamemanager.WriteText1();
				break;

			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_3[click];
				scr_Gamemanager.WriteText2();
				break;

			case 2 :
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 3:
				scr_Gamemanager.message = scr_Gamemanager.quest_3[2*click/3];
				scr_Gamemanager.WriteText1();
				break;

			case 4 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 5:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default:
				break;
			}
			break;

		case 4:				//Screenshot 12
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest04_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_4[click];
				scr_Gamemanager.WriteText1();
				break;

			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_4[click];
				scr_Gamemanager.WriteText2();
				break;
			
			case 2:
			case 5:
			case 8:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
			
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest_4[2*click/3];
				scr_Gamemanager.WriteText1();
				break;

			case 4:
			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_4[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 9:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default :
				break;
			}
			break;

		case 5:				//Screenshot 13
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_5[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_5[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
				scr_Gamemanager.message = scr_Gamemanager.quest_5[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_5[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
			case 13 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 14 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 6:				//Screenshot 14
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogA[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogA[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogA[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogA[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
			
			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 8:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 7:				//Screenshot 15
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogB[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogB[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogB[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest5_DialogB[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
			case 13 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				
				break;
				
			case 14 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
			}
			break;

		case 8:				//Screenshot 16
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_6[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest_6[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 8:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 9:				//Screenshot 17
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_6A[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6A[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
				scr_Gamemanager.message = scr_Gamemanager.quest_6A[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6A[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
			case 13 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				
				break;
				
			case 14 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
			}
			break;

		case 10:				//Screenshot 18						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_6B[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6B[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest_6B[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_6B[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 8:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 11:				//Screenshot 19						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_7[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_7[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
				scr_Gamemanager.message = scr_Gamemanager.quest_7[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_7[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
			case 13 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 14 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 12:				//Screenshot 20						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_7A[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_7A[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest_7A[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_7A[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
			case 9:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 13:				//Screenshot 21						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest08_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_8[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_8[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
			case 14:
			case 17:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
			case 15:
				scr_Gamemanager.message = scr_Gamemanager.quest_8[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
			case 13:
			case 16:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_8[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 18:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 14:	
		{
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest08_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_8A[click];
				scr_Gamemanager.WriteText1();
				break;

			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 2:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default:
				break;
			}
			break;
		}

		case 15:				//Screenshot 22						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest09a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_9[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_9[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
			case 14:
			case 17:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
			case 15:
				scr_Gamemanager.message = scr_Gamemanager.quest_9[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
			case 13:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_9[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 16:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_9[11];
				scr_Gamemanager.WriteText2();
				break;

			case 18 :
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default:
				break;
			}
			break;

		case 16:				//Screenshot 23						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest09b_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_9A[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_9A[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2 :
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
				scr_Gamemanager.message = scr_Gamemanager.quest_9A[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 5:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default:
				break;
			}
			break;

		case 17:				//Screenshot 24						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest10a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_10[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_10[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
				scr_Gamemanager.message = scr_Gamemanager.quest_10[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_10[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 10 :	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 11:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 18:				//Screenshot 25						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_10A[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_10A[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
				scr_Gamemanager.message = scr_Gamemanager.quest_10A[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_10A[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 7:	
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 8:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;
			}
			break;

		case 19:				//Screenshot 26						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_11[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_11[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
			case 11:
			case 14:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
			case 12:
			case 15:
				scr_Gamemanager.message = scr_Gamemanager.quest_11[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
			case 10:
			case 13:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_11[3*click/4];
				scr_Gamemanager.WriteText2();
				break;

			case 16:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;

			case 17:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;

			default :
				break;
			}
			break;

		case 20:				//Screenshot 27						
			switch(click)
			{
			case 0:
				gc.popUpType4.SetActiveRecursively(true);
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
				scr_Gamemanager.message = scr_Gamemanager.quest_12[click];
				scr_Gamemanager.WriteText1();
				break;
				
			case 1:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_12[click];
				scr_Gamemanager.WriteText2();
				break;
				
			case 2:
			case 5:
			case 8:
				gc.popUpType_Dig2_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 3:
			case 6:
			case 9:
				scr_Gamemanager.message = scr_Gamemanager.quest_12[2*click/3];
				scr_Gamemanager.WriteText1();
				break;
				
			case 4:
			case 7:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.message = scr_Gamemanager.quest_12[3*click/4];
				scr_Gamemanager.WriteText2();
				break;
				
//			case 9 :	
//				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
//				scr_Gamemanager.StopWritingText();
//				break;
			case 10:
				gc.popUpType_Dig1_spText.Text = scr_Gamemanager.message;
				scr_Gamemanager.StopWritingText();
				break;
				
			case 11:
				gc.popUpType4.SetActiveRecursively(false);
				ShowNextStory();
				break;
				
			default :
				break;

			}
			break;

		default:
			showStoryNo.Clear();	
			isStory = false;
			break;
		}
	}
	
	private void ShowNextStory()
	{
		//showStoryNo.Remove(0);
		showStoryNo.RemoveAt(0);
		if(showStoryNo.Count > 0)				
		{
			scr_Gamemanager.clickCounter = 0;
			ShowCurrentStory(0, scr_Gamemanager.clickCounter);
		}
		else
		{
			scr_Gamemanager.clickCounter = 0;
			Debug.Log("Story over");
			isStory = false;
		}
	}

//	int a;
//	private void OnGUI()
//	{
//		if(GUI.Button(new Rect(400, 400, 100, 30), "Unlock story"))
//		{
//			//for(int i=1; i<3; i++)
//			{	
//				showStoryNo.Add(a);
//				Debug.Log("Count :  "+showStoryNo.Count);
//				//Debug.Log(" unlockedStory : "+showStoryNo[i].ToString());
//			}
//			if(showStoryNo.Count > 0)
//			{
//				ShowCurrentStory(0, 0);
//				isStory = true;
//			}
//		}
//		
//		if(GUI.Button(new Rect(500, 500, 100, 30), "Click"))
//		{
//			a++;
//			//ShowCurrentStory(0, clickCounter);
//		}
//	}

	private void PrintStory(GameObject popUp, Material questMaterial, Texture questTexture, int clickCount, SpriteText popUpText, string[] storyText, string message)
	{
		popUp.SetActiveRecursively(true);
		questMaterial.mainTexture = questTexture;

		if(clickCount > 0)
			popUpText.Text = storyText[clickCount - 1];

		message = storyText[clickCount];
	}
		
//	public void dark() 
//	{
//		darkbool = true;
//		if(GameManager.gameLevel == 4)
//		{
//			Fourdark();
//		}
//		
//		if(GameManager.gameLevel == 5)
//		{
//			Fourdark();
//			Fivedark();
//		}
//		
//		if(GameManager.gameLevel == 6)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//		}
//		
//		if(GameManager.gameLevel == 7)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//		}
//		
//		if(GameManager.gameLevel == 8)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//		}
//		
//		if(GameManager.gameLevel == 9)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//		}
//		
//		if(GameManager.gameLevel == 10)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//			Tendark();
//		}
//		
//		if(GameManager.gameLevel == 11)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//			Tendark();
//			Elevendark();
//		}
//		
//		if(GameManager.gameLevel == 12)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//			Tendark();
//			Elevendark();
//			Twelvedark();
//		}
//		
//		if(GameManager.gameLevel == 13)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//			Tendark();
//			Elevendark();
//			Twelvedark();
//			Thirteendark();
//		}
//		
//		if(GameManager.gameLevel == 14)
//		{
//			Fourdark();
//			Fivedark();
//			Sixdark();
//			Sevendark();
//			Eightdark();
//			Ninedark();
//			Tendark();
//			Elevendark();
//			Twelvedark();
//			Thirteendark();
//			Fourteendark();
//		}
//	}
	
//	public void questLog()
//	{
//		questbool = true;
//		if (GameManager.gameLevel >= 2)
//			FourQuest();	
//		
//		if(GameManager.gameLevel == 4)
//		{
//			FourQuest();
//		}
//		
//		if(GameManager.gameLevel == 5)
//		{
//			FourQuest();
//			FiveQuest();
//		}
//		
//		if(GameManager.gameLevel == 6)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//		}
//		
//		if(GameManager.gameLevel == 7)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//		}
//		
//		if(GameManager.gameLevel == 8)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//		}
//		
//		if(GameManager.gameLevel == 9)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//		}
//		
//		if(GameManager.gameLevel == 10)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//			TenQuest();
//		}
//		
//		if(GameManager.gameLevel == 11)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//			TenQuest();
//			ElevenQuest();
//		}
//		
//		if(GameManager.gameLevel == 12)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//			TenQuest();
//			ElevenQuest();
//			TwelveQuest();
//		}
//		
//		if(GameManager.gameLevel == 13)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//			TenQuest();
//			ElevenQuest();
//			TwelveQuest();
//			ThirteenQuest();
//		}
//		
//		if(GameManager.gameLevel == 14)
//		{
//			FourQuest();
//			FiveQuest();
//			SixQuest();
//			SevenQuest();
//			EightQuest();
//			NineQuest();
//			TenQuest();
//			ElevenQuest();
//			TwelveQuest();
//			ThirteenQuest();
//			FourteenQuest();
//		}
//	}
	
//	public void ThreeHalf()
//	{
////		if(HalflingLevelThreeBool == false)
////		{
////			if(Three_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objPlantTrainingGrnd.objTypeId))
////			{
////			inv.AddItem(Three_Half_task1);
////			Three_Half_task1_Text.Text = level_Three_Halfling_Missions[0];
////			}
////			if(Three_Half_task2_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objSprout.objTypeId)) && PlayerPrefs.GetInt("sprout") == 0)
////			{
////			inv.AddItem(Three_Half_task2);
////			Three_Half_task2_Text.Text = level_Three_Halfling_Missions[1];
////			}
////			if(Three_Half_task3_bool == false  && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objPipeweed.objTypeId))
////			{
////			inv.AddItem(Three_Half_task3);
////			Three_Half_task3_Text.Text = level_Three_Halfling_Missions[2];
////			}
////			if(Three_Half_task4_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objTurnips.objTypeId))
////			{
////			inv.AddItem(Three_Half_task4);
////			Three_Half_task4_Text.Text = level_Three_Halfling_Missions[3];
////			}
////			HalflingLevelThreeBool=true;
////		}
//	}
//	
//	public void FourHalf()
//	{
////		if(HalflingLevelFourBool == false)
////		{
////			if(Four_Half_task1_bool == false && CheckLevelObject(scr_gameObjSvr.objTrainingGrnd.objTypeId) == 1)
////			{
////			inv.AddItem(Four_Half_task1);
////			Four_Half_task1_Text.Text = level_Four_Halfling_Missions[0];
////			}
////			if(Four_Half_task2_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objBarg.objTypeId)) && PlayerPrefs.GetInt("barg") == 0)
////			{
////			inv.AddItem(Four_Half_task2);
////			Four_Half_task2_Text.Text = level_Four_Halfling_Missions[1];
////			}
////			if(Four_Half_task3_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objGoblinCamp02.objTypeId))
////			{
////			inv.AddItem(Four_Half_task3);
////			Four_Half_task3_Text.Text = level_Four_Halfling_Missions[2];
////			}
////			if(Four_Half_task4_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objGarden02.objTypeId))
////			{
////			inv.AddItem(Four_Half_task4);
////			Four_Half_task4_Text.Text = level_Four_Halfling_Missions[3];
////			}
////			HalflingLevelFourBool = true;
////		}
//	}
//	
//	public void FiveHalf()
//	{
////		if(HalflingLevelFiveBool == false)
////		{
////			if(Five_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objWaterTrainingGrnd.objTypeId))
////			{
////			inv.AddItem(Five_Half_task1);
////			Five_Half_task1_Text.Text = level_Five_Halfling_Missions[0];
////			}
////			if(Five_Half_task2_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objNix.objTypeId)) && PlayerPrefs.GetInt("nix") == 0)
////			{
////			inv.AddItem(Five_Half_task2);
////			Five_Half_task2_Text.Text = level_Five_Halfling_Missions[1];
////			}
////			if(Five_Half_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objHalflingStable.objTypeId))
////			{
////			inv.AddItem(Five_Half_task3);
////			Five_Half_task3_Text.Text = level_Five_Halfling_Missions[2];
////			}
////			if(Five_Half_task4_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objPumpkin.objTypeId))
////			{
////			inv.AddItem(Five_Half_task4);
////			Five_Half_task4_Text.Text = level_Five_Halfling_Missions[3];
////			}
////			HalflingLevelFiveBool = true;
////		}
//	}
//	
//	public void SixHalf()
//	{
////		if(HalflingLevelSixBool == false)
////		{
//////			if(Six_Half_task1_bool == false)
//////			{
//////			inv.AddItem(Six_Half_task1);
//////			Six_Half_task1_Text.Text = levelSixHalflingMissions[0];
//////			}
////			if(Six_Half_task2_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objNymph.objTypeId)) && PlayerPrefs.GetInt("nymph") == 0)
////			{
////			inv.AddItem(Six_Half_task2);
////			Six_Half_task2_Text.Text = level_Six_Halfling_Missions[1];
////			}
////			if(Six_Half_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objBlackSmith.objTypeId))
////			{
////			inv.AddItem(Six_Half_task3);
////			Six_Half_task3_Text.Text = level_Six_Halfling_Missions[2];
////			}
////			if(Six_Half_task4_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objGoblinCamp03.objTypeId))
////			{
////			inv.AddItem(Six_Half_task4);			
////			Six_Half_task4_Text.Text = level_Six_Halfling_Missions[3];
////			}
////			HalflingLevelSixBool = true;
////		}
//	}
//	
//	public void SevenHalf()
//	{
////		if(HalflingLevelSevenBool == false)
////		{
////			if(Seven_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objGarden03.objTypeId))
////			{
////			inv.AddItem(Seven_Half_task1);
////			Seven_Half_task1_Text.Text = level_Seven_Halfling_Missions[0];
////			}
////			if(Seven_Half_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objPipeweed.objTypeId))
////			{
////			inv.AddItem(Seven_Half_task2);			
////			Seven_Half_task2_Text.Text = level_Seven_Halfling_Missions[1];
////			}
////			HalflingLevelSevenBool = true;
////		}
//	}
//	
//	public void EightHalf()
//	{
////		if(HalflingLevelEightBool == false)
////		{
////			if(Eight_Half_task1_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objDraug.objTypeId) ) && PlayerPrefs.GetInt("draug") == 0)
////			{
////			inv.AddItem(Eight_Half_task1);
////			Eight_Half_task1_Text.Text = level_Eight_Halfling_Missions[0];
////			}
////			if(Eight_Half_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objCusith.objTypeId))
////			{
////			inv.AddItem(Eight_Half_task2);
////			Eight_Half_task2_Text.Text = level_Eight_Halfling_Missions[1];
////			}
////			if(Eight_Half_task3_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objTrollCave01.objTypeId))
////			{
////			inv.AddItem(Eight_Half_task3);			
////			Eight_Half_task3_Text.Text = level_Eight_Halfling_Missions[2];
////			}
////			HalflingLevelEightBool = true;
////		}
//	}
//	
//	public void NineHalf()
//	{
////		if(HalflingLevelNineBool == false)
////		{
////			if(Nine_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDryad.objTypeId))
////			{
////			inv.AddItem(Nine_Half_task1);
////			Nine_Half_task1_Text.Text = level_Nine_Halfling_Missions[0];
////			}
////			if(Nine_Half_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objTavern.objTypeId))
////			{
////			inv.AddItem(Nine_Half_task2);			
////			Nine_Half_task2_Text.Text = level_Nine_Halfling_Missions[1];
////			}
////			if(Nine_Half_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objPlantObelisk.objTypeId))
////			{
////			inv.AddItem(Nine_Half_task3);
////			Nine_Half_task3_Text.Text = level_Nine_Halfling_Missions[2];	
////			}
////			HalflingLevelNineBool = true;
////		}
//	}
//	
//	public void TenHalf()
//	{
////		if(HalflingLevelTenBool == false)
////		{
////			if(Ten_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objGarden04.objTypeId))
////			{
////			inv.AddItem(Ten_Half_task1);
////			Ten_Half_task1_Text.Text = level_Ten_Halfling_Missions[0];
////			}
////			if(Ten_Half_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objPotatoes.objTypeId))
////			{
////			inv.AddItem(Ten_Half_task2);
////			Ten_Half_task2_Text.Text = level_Ten_Halfling_Missions[1];
////			}
////			if(Ten_Half_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objApothecary.objTypeId))
////			{
////			inv.AddItem(Ten_Half_task3);
////			Ten_Half_task3_Text.Text = level_Ten_Halfling_Missions[2];
////			}
////			if(Ten_Half_task4_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objTrollCave02.objTypeId))
////			{
////			inv.AddItem(Ten_Half_task4);			
////			Ten_Half_task4_Text.Text = level_Ten_Halfling_Missions[3];
////			}
////			HalflingLevelTenBool = true;
////		}
//	}
//	
//	public void ElevenHalf()
//	{
////		if(HalflingLevelElevenBool == false)
////		{
////			if(Eleven_Half_task1_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objFairyLilly.objTypeId))
////			{
////			inv.AddItem(Eleven_Half_task1);
////			Eleven_Half_task1_Text.Text = level_Eleven_Halfling_Missions[0];
////			}
////			if(Eight_Half_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objWaterObelisk.objTypeId))
////			{
////			inv.AddItem(Eleven_Half_task2);
////			Eleven_Half_task2_Text.Text = level_Eleven_Halfling_Missions[1];
////			}
////			HalflingLevelElevenBool = true;
////		}
//	}
//	
//	public void TwelveHalf()
//	{
////		if(HalflingLevelTwelveBool == false)
////		{
////			if(Twelve_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDragon.objTypeId))
////			{
////			inv.AddItem(Twelve_Half_task1);
////			Twelve_Half_task1_Text.Text = level_Twelve_Halfling_Missions[0];
////			}
////			if(Twelve_Half_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objWatercress.objTypeId))
////			{
////			inv.AddItem(Twelve_Half_task2);
////			Twelve_Half_task2_Text.Text = level_Twelve_Halfling_Missions[1];
////			}
////			if( Twelve_Half_task3_bool== false && !CheckObjectfrmSvr(scr_gameObjSvr.objSunshrine.objTypeId))
////			{
////			inv.AddItem(Twelve_Half_task3);
////			Twelve_Half_task3_Text.Text = level_Twelve_Halfling_Missions[2];
////			}
////			if(Twelve_Half_task4_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objTrollCave03.objTypeId))
////			{
////			inv.AddItem(Twelve_Half_task4);			
////			Twelve_Half_task4_Text.Text = level_Twelve_Halfling_Missions[3];
////			}
////			HalflingLevelTwelveBool = true;
////		}
//	}
//	
//	public void ThirteenHalf()
//	{
////		if(HalflingLevelThirteenBool == false)
////		{
////			if(Thirteen_Half_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objGarden05.objTypeId))
////			{
////			inv.AddItem(Thirteen_Half_task1);
////			Thirteen_Half_task1_Text.Text = level_Thirteen_Halfling_Missions[0];
////			}
////			if(Thirteen_Half_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objVervainHerb.objTypeId))
////			{
////			inv.AddItem(Thirteen_Half_task2);
////			Thirteen_Half_task2_Text.Text = level_Thirteen_Halfling_Missions[1];
////			}
////			HalflingLevelThirteenBool = true;
////		}
//	}
//	
//	public void FourteenHalf()
//	{
////		if(HalflingLevelFourteenBool == false)
////		{
//////			if(Fourteen_Half_task1_bool == false)
//////			{
//////			inv.AddItem(Fourteen_Half_task1);
//////			Fourteen_Half_task1_Text.Text = level_Fourteen_Halfling_Missions[0];
//////			}
////			if(Fourteen_Half_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objMandrake.objTypeId))
////			{
////			inv.AddItem(Fourteen_Half_task2);
////			Fourteen_Half_task2_Text.Text = level_Fourteen_Halfling_Missions[1];
////			}
////			if(Fourteen_Half_task3_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objOrgCave01.objTypeId))
////			{
////			inv.AddItem(Fourteen_Half_task3);
////			Fourteen_Half_task3_Text.Text = level_Fourteen_Halfling_Missions[2];
////			}
////			HalflingLevelFourteenBool = true;
////		}
//	}
//	
//	public void Fourdark()
//	{
////		if(darklingLevelFourBool == false)
////		{
////			if(Four_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarkLingInn.objTypeId))
////			{
////			inv1.AddItem1(Four_Dark_task1);
////			Four_Dark_task1_Text.Text = level_Four_Darkling_Missions[0];
////			}
////			if(Four_Dark_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGarden.objTypeId))
////			{
////			inv1.AddItem1(Four_Dark_task2);
////			Four_Dark_task2_Text.Text = level_Four_Darkling_Missions[1];
////			}
////			if(Four_Dark_task3_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingPumpkin.objTypeId))
////			{
////			inv1.AddItem1(Four_Dark_task3);
////			Four_Dark_task3_Text.Text = level_Four_Darkling_Missions[2];
////			}
////			if(Four_Dark_task4_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingWell.objTypeId))
////			{
////			inv1.AddItem1(Four_Dark_task4);			
////			Four_Dark_task4_Text.Text = level_Four_Darkling_Missions[3];
////			}
////			if(Four_Dark_task5_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingDirtPath.objTypeId))
////			{
////			inv1.AddItem1(Four_Dark_task5);			
////			Four_Dark_task5_Text.Text = level_Four_Darkling_Missions[4];
////			}
////			
////			darklingLevelFourBool=true;
////		}
//	}
//	
//	public void Fivedark()
//	{
////		if(darklingLevelFiveBool == false)
////		{
////			if(Five_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarkearthTrainingGrnd.objTypeId))
////			{
////			inv1.AddItem1(Five_Dark_task1);
////			Five_Dark_task1_Text.Text = level_Five_Darkling_Missions[0];
////			}
////			if(Five_Dark_task2_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objDarklinghound.objTypeId)) && PlayerPrefs.GetInt("darkhound") == 0)
////			{
////			inv1.AddItem1(Five_Dark_task2);
////			Five_Dark_task2_Text.Text = level_Five_Darkling_Missions[1];
////			}
////			if(Five_Dark_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarkingStable.objTypeId))
////			{
////			inv1.AddItem1(Five_Dark_task3);
////			Five_Dark_task3_Text.Text = level_Five_Darkling_Missions[2];
////			}
////			if(Five_Dark_task4_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingFirePepper.objTypeId))
////			{
////			inv1.AddItem1(Five_Dark_task4);
////			Five_Dark_task4_Text.Text = level_Five_Darkling_Missions[3];
////			}
////			if(Five_Dark_task5_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGoblinCamp01.objTypeId))
////			{
////			inv1.AddItem1(Five_Dark_task5);			
////			Five_Dark_task5_Text.Text = level_Five_Darkling_Missions[4];
////			}
////			darklingLevelFiveBool = true;
////		}
//	}
//	
//	public void Sixdark()
//	{
////		if(darklingLevelSixBool == false)
////		{
//////			if(Six_Dark_task1_bool == false)
//////			{
//////			inv1.AddItem1(Six_Dark_task1);
//////			Six_Dark_task1_Text.Text = levelSixDarklingMissions[0];
//////			}
////			if(Six_Dark_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingFireTrainingGrnd.objTypeId))
////			{
////			inv1.AddItem1(Six_Dark_task2);
////			Six_Dark_task2_Text.Text = level_Six_Darkling_Missions[1];
////			}
////			if(Six_Dark_task3_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objDarklingSprite.objTypeId)) && PlayerPrefs.GetInt("sprite") == 0)
////			{
////			inv1.AddItem1(Six_Dark_task3);
////			Six_Dark_task3_Text.Text = level_Six_Darkling_Missions[2];
////			}
////			if(Six_Dark_task4_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingSmith.objTypeId))
////			{
////			inv1.AddItem1(Six_Dark_task4);			
////			Six_Dark_task4_Text.Text = level_Six_Darkling_Missions[3];
////			}
////			darklingLevelSixBool = true;
////		}
//	}
//	
//	public void Sevendark()
//	{
////		if(darklingLevelSevenBool == false)
////		{
////			if(Seven_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGarden02.objTypeId))
////			{
////			inv1.AddItem1(Seven_Dark_task1);
////			Seven_Dark_task1_Text.Text = level_Seven_Darkling_Missions[0];
////			}
////			if(Seven_Dark_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingAvenHerb.objTypeId))
////			{
////			inv1.AddItem1(Seven_Dark_task2);
////			Seven_Dark_task2_Text.Text = level_Seven_Darkling_Missions[1];
////			}
////			if(Seven_Dark_task3_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGoblinCamp02.objTypeId))
////			{
////			inv1.AddItem1(Seven_Dark_task3);			
////			Seven_Dark_task3_Text.Text = level_Seven_Darkling_Missions[2];
////			}
////			darklingLevelSevenBool = true;
////		}
//	}
//	
//	public void Eightdark()
//	{
////		if(darklingLevelEightBool == false)
////		{
////			if(Eight_Dark_task1_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objDarklingFenrir.objTypeId)) && PlayerPrefs.GetInt("fenrir") == 0)
////			{
////			inv1.AddItem1(Eight_Dark_task1);			
////			Eight_Dark_task1_Text.Text = level_Eight_Darkling_Missions[0];
////			}
////			darklingLevelEightBool = true;
////		}
//	}
//	
//	public void Ninedark()
//	{
////		if(darklingLevelNineBool == false)
////		{
////			if(Nine_Dark_task1_bool == false && (!CheckObjectfrmSvr(scr_gameObjSvr.objDarklingImp.objTypeId)) && PlayerPrefs.GetInt("imp") == 0)
////			{
////			inv1.AddItem1(Nine_Dark_task1);
////			Nine_Dark_task1_Text.Text = level_Nine_Darkling_Missions[0];
////			}
////			if(Nine_Dark_task2_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGoblinCamp03.objTypeId))
////			{
////			inv1.AddItem1(Nine_Dark_task2);			
////			Nine_Dark_task2_Text.Text = level_Nine_Darkling_Missions[1];
////			}
////			darklingLevelNineBool = true;
////		}
//	}
//	
//	public void Tendark()
//	{
////		if(darklingLevelTenBool == false)
////		{
////			if(Ten_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGarden03.objTypeId))
////			{
////			inv1.AddItem1(Ten_Dark_task1);
////			Ten_Dark_task1_Text.Text = level_Ten_Darkling_Missions[0];
////			}
////			if(Ten_Dark_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingBlackberry.objTypeId))
////			{
////			inv1.AddItem1(Ten_Dark_task2);
////			Ten_Dark_task2_Text.Text = level_Ten_Darkling_Missions[1];
////			}
////			if(Ten_Dark_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingApothecary.objTypeId))
////			{
////			inv1.AddItem1(Ten_Dark_task3);			
////			Ten_Dark_task3_Text.Text = level_Ten_Darkling_Missions[2];
////			}
////			darklingLevelTenBool = true;
////		}
//	}
//	
//	public void Elevendark()
//			{
////		if(darklingLevelElevenBool == false)
////		{
////			if(Eleven_Dark_task1_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingColumbine.objTypeId))
////			{
////			inv1.AddItem1(Eleven_Dark_task1);
////			Eleven_Dark_task1_Text.Text = level_Eleven_Darkling_Missions[0];
////			}
////			if(Eleven_Dark_task2_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objTrollCave01.objTypeId))
////			{
////			inv1.AddItem1(Eleven_Dark_task2);			
////			Eleven_Dark_task2_Text.Text = level_Eleven_Darkling_Missions[1];
////			}
////			if(Eleven_Dark_task3_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingFireObelisk.objTypeId))
////			{
////			inv1.AddItem1(Eleven_Dark_task3);			
////			Eleven_Dark_task3_Text.Text = level_Eleven_Darkling_Missions[2];
////			}
////			darklingLevelElevenBool = true;
////		}
//			}
//	
//	public void Twelvedark()
//			{
////		if(darklingLevelTwelveBool == false)
////		{
////			if(Twelve_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingLurker.objTypeId))
////			{
////			inv1.AddItem1(Twelve_Dark_task1);
////			Twelve_Dark_task1_Text.Text = level_Twelve_Darkling_Missions[0];
////			}
////			if(Twelve_Dark_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingBitterbush.objTypeId))
////			{
////			inv1.AddItem1(Twelve_Dark_task2);			
////			Twelve_Dark_task2_Text.Text = level_Twelve_Darkling_Missions[1];
////			}
////			darklingLevelTwelveBool = true;
////		}
//			}
//	
//	public void Thirteendark()
//			{
////		if(darklingLevelThirteenBool == false)
////		{
////			if(Thirteen_Dark_task1_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingHellhound.objTypeId))
////			{
////			inv1.AddItem1(Thirteen_Dark_task1);
////			Thirteen_Dark_task1_Text.Text = level_Thirteen_Darkling_Missions[0];
////			}
////			if(Thirteen_Dark_task2_bool == false && !CheckObjectfrmSvr(scr_gameObjSvr.objDarklingGarden04.objTypeId))
////			{
////			inv1.AddItem1(Thirteen_Dark_task2);
////			Thirteen_Dark_task2_Text.Text = level_Thirteen_Darkling_Missions[1];
////			}
////			if(Thirteen_Dark_task3_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingHerbBogbean.objTypeId))
////			{
////			inv1.AddItem1(Thirteen_Dark_task3);
////			Thirteen_Dark_task3_Text.Text = level_Thirteen_Darkling_Missions[2];
////			}
////			if(Thirteen_Dark_task4_bool == false && CheckObjectfrmSvr(scr_gameObjSvr.objTrollCave02.objTypeId))
////			{
////			inv1.AddItem1(Thirteen_Dark_task4);
////			Thirteen_Dark_task4_Text.Text = level_Thirteen_Darkling_Missions[3];
////			}
////			darklingLevelThirteenBool = true;
////		}
//			}
//	
//	public void Fourteendark()
//	{
//		if(darklingLevelFourteenBool == false)
//		{
////			if(Fourteen_Dark_task1_bool == false)
////			{
////			inv1.AddItem1(Fourteen_Dark_task1);
////			Fourteen_Dark_task1_Text.Text = level_Fourteen_Darkling_Missions[0];
////			}
//			if(Fourteen_Dark_task2_bool == false && !CheckObjectfrmUserPurchases(scr_gameObjSvr.objDarklingHerbWolfbane.objTypeId))
//			{
//			inv1.AddItem1(Fourteen_Dark_task2);
//			Fourteen_Dark_task2_Text.Text = level_Fourteen_Darkling_Missions[1];
//			}
//			darklingLevelFourteenBool =true;
//		}
//			}
	
				
				
//	public bool isStory;
//	public void ShowCurrentStory(int storyNo)
//	{
//		Debug.Log("Show story no : "+storyNo);
//		isStory = true;
//	}
	
//	private List<int> no = new List<int>();
//	private List<string> s1 = new List<string>();
//	private List<string> s2 = new List<string>();
//	private List<bool> flag = new List<bool>();
//	private bool f1 = false, f2 = true, f3 = false, f4 = true, f5 = false, f6 = false, f7 = true;
//	private void OnGUI()
//	{
//		if(GUI.Button(new Rect(300, 500, 100, 20), "Story"))
//		{
//			flag.Add(f1);	flag.Add(f2);	flag.Add(f3);	flag.Add(f4);	flag.Add(f5);	flag.Add(f6);	flag.Add(f7);
//			for(int i=0; i<7; i++)
//			{
//				no.Add(i);
//				string b1 = "Story 0"+(i+1);
//				string b2 = "This is a test story detail \nfor story 0"+(i+1);
//				s1.Add(b1);
//				s2.Add(b2);
//	
//				Debug.Log(i +". "+s1[i]);
//				Debug.Log(i +", "+s2[i]);
//	
//				StoryContent storyContent = new StoryContent();
//				storyContent.storyTitle = s1[i];
//				storyContent.storyDetail = s2[i];
//				storyContent.isLocked = flag[i];
//	
//				storyList.Add(storyContent);
//			}
//			storyCount = flag.FindAll(s => !s).Count;
//			Debug.Log("False count : "+storyCount);
//			Debug.Log("Count : "+storyList.Count);
//		}
//	}

//	public void FourQuest()
//	{
//		if(QuestLevelFourBool == false)
//		{
//			if(Four_Quest_bool == false && CheckQuestfrmSvr(502))
//			{
//				inv2.AddItem2(Four_Quest);
//				Four_Quest_Text.Text = level_Four_Missions[0];
//			}
//			QuestLevelFourBool=true;
//		}
//	}
//	
//	public void FiveQuest()
//	{
//		if(QuestLevelFiveBool == false && CheckQuestfrmSvr(503))
//		{
//			if(Five_Quest_bool == false)
//			{
//				inv2.AddItem2(Five_Quest);			
//				Five_Quest_Text.Text = level_Five_Missions[0];
//			}
//			QuestLevelFiveBool=true;
//		}
//	}
//	
//	public void SixQuest()
//	{
//		if(QuestLevelSixBool == false && CheckQuestfrmSvr(504))
//		{
//			if(Six_Quest_bool == false)
//			{
//			inv2.AddItem2(Six_Quest);			
//			Six_Quest_Text.Text = level_Six_Missions[0];
//			}
//			QuestLevelSixBool=true;
//		}
//	}
//	
//	public void SevenQuest()
//	{
//		if(QuestLevelSevenBool == false)
//		{
//			if(Seven_Quest_bool == false && CheckQuestfrmSvr(505))
//			{
//			inv2.AddItem2(Seven_Quest);	
//			Seven_Quest_Text.Text = level_Seven_Missions[0];
//			}
//			QuestLevelSevenBool=true;
//		}
//	}
//	
//	public void EightQuest()
//	{
//		if(QuestLevelEightBool == false)
//		{
//			if(Eight_Quest_bool == false && CheckQuestfrmSvr(506))
//			{
//			inv2.AddItem2(Eight_Quest);			
//			Eight_Quest_Text.Text = level_Eight_Missions[0];
//			}
//			QuestLevelEightBool=true;
//		}
//	}
//	
//	public void NineQuest()
//	{
//		if(QuestLevelNineBool == false)
//		{
//			if(Nine_Quest_bool == false && CheckQuestfrmSvr(507))
//			{
//			inv2.AddItem2(Nine_Quest);			
//			Nine_Quest_Text.Text = level_Nine_Missions[0];
//			}
//			QuestLevelNineBool=true;
//		}
//	}
//	
//	public void TenQuest()
//	{
//		if(QuestLevelTenBool == false)
//		{
//			if(Ten_Quest_bool == false && CheckQuestfrmSvr(508))
//			{
//			inv2.AddItem2(Ten_Quest);			
//			Ten_Quest_Text.Text = level_Ten_Missions[0];
//			}
//			QuestLevelTenBool=true;
//		}
//	}
//	
//	public void ElevenQuest()
//	{
//		if(QuestLevelElevenBool == false)
//		{
//			if(Eleven_Quest_bool == false && CheckQuestfrmSvr(509))
//			{
//			inv2.AddItem2(Eleven_Quest);			
//			Eleven_Quest_Text.Text = level_Eleven_Missions[0];
//			}
//			QuestLevelElevenBool=true;
//		}
//	}
//	
//	public void TwelveQuest()
//	{
//		if(QuestLevelTwelveBool == false)
//		{
//			if(Twelve_Quest_bool == false && CheckQuestfrmSvr(510))
//			{
//			inv2.AddItem2(Twelve_Quest);			
//			Twelve_Quest_Text.Text = level_Twelve_Missions[0];
//			}
//			QuestLevelTwelveBool=true;
//		}
//	}
//
//	public void ThirteenQuest()
//	{
//		if(QuestLevelThirteenBool == false)
//		{
//			if(Thirteen_Quest_bool == false && CheckQuestfrmSvr(511))
//			{
//			inv2.AddItem2(Thirteen_Quest);
//			Thirteen_Quest_Text.Text = level_Thirteen_Missions[0];
//			}
//			QuestLevelThirteenBool = true;
//		}
//	}
//	
//	public void FourteenQuest()
//	{
//		if(QuestLevelFourteenBool == false)
//		{
//			if(Fourteen_Quest_bool == false && CheckQuestfrmSvr(512))
//			{
//			inv2.AddItem2(Fourteen_Quest);
//			Fourteen_Quest_Text.Text = level_Fourteen_Missions[0];
//			}
//			QuestLevelFourteenBool = true;
//		}
//	}
	//for Tasks Loading from server
	/// <summary>
	/// Temporary this instance.
	/// </summar---
	/// 
	//
	
	// ----- Temporary -----//
	public void Temporary()
	{
//		storyList.Clear();
//		List<int> no = new List<int>();
//		List<string> s1 = new List<string>();
//		List<string> s2 = new List<string>();
//		List<bool> flag = new List<bool>();
//		bool f1 = false, f2 = true, f3 = false, f4 = true, f5 = false, f6 = false, f7 = true;
//		
//		flag.Add(f1);	flag.Add(f2);	flag.Add(f3);	flag.Add(f4);	flag.Add(f5);	flag.Add(f6);	flag.Add(f7);
//		for(int i=0; i<7; i++)
//		{
//			no.Add(i);
//			string b1 = "Story 0"+(i+1);
//			string b2 = "This is a test story detail \nfor story 0"+(i+1);
//			s1.Add(b1);
//			s2.Add(b2);
//	
//			Debug.Log(i +". "+s1[i]);
//			Debug.Log(i +", "+s2[i]);
//	
//			StoryContent storyContent = new StoryContent();
//			storyContent.storyTitle = s1[i];
//			storyContent.storyDetail = s2[i];
//			storyContent.isLocked = flag[i];
//	
//			storyList.Add(storyContent);
//		}
//		storyCount = flag.FindAll(s => !s).Count;
//		Debug.Log("False count : "+storyCount);
//		Debug.Log("Count : "+storyList.Count);	
	}
	// ----- Temporary -----//
	
	public bool CheckObjectfrmSvr(int typeId)
	{
		for(int i=0; i< scr_sfsRemote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].typeId.Equals(typeId))
			{
				return true;
			}
		}		
		return false;
	}
	
	public int CheckLevelObject(int typeId)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_ObjSvr.Count ;i++)
		{
			if(scr_sfsRemote.lst_ObjSvr[i].typeId.Equals(typeId))
			{
				return scr_sfsRemote.lst_ObjSvr[i].level;
			}
		}
		
		return 0;
	}
	
	public bool CheckQuestfrmSvr(int questNo)
	{
		for(int i=0 ; i< scr_sfsRemote.lst_questInfo.Count; i++)
		{
			if(scr_sfsRemote.lst_questInfo[i].questNo.Equals(questNo))
			{
				return true;
			}
		}
		
		return false;
	}	
	
	public bool CheckObjectfrmUserPurchases(int typeId)
	{
		for(int i=0 ; i < scr_sfsRemote.lst_UserPurchasesSvr.Count ; i++)
		{
			if(scr_sfsRemote.lst_UserPurchasesSvr[i].typeId.Equals(typeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	public void RemoveQuest(int questNo)
	{
		switch(questNo)
		{
			case 502:
				
			  inv2.RemoveItem2(Four_Quest);
				Four_Quest_bool = true;
				break;
				
			case 503:
			
			    inv2.RemoveItem2(Five_Quest);
				break;
				
			case 504:
			
			    inv2.RemoveItem2(Six_Quest);
				
				break;
				
			case 505:
				
			   inv2.RemoveItem2(Seven_Quest);
				break;
				
			case 506:
				
			    inv2.RemoveItem2(Eight_Quest);
				break;
				
			case 507:
			    inv2.RemoveItem2(Nine_Quest);	
			
				break;
				
			case 508:
			
			    inv2.RemoveItem2(Ten_Quest);
				
				break;
				
			case 509:
				inv2.RemoveItem2(Eleven_Quest);  
			     
				break;
			
		    case 510:
			
			    inv2.RemoveItem2(Twelve_Quest);
			break;
			
			case 511:
				
			   inv2.RemoveItem2(Thirteen_Quest);
				break;
				
			case 512:
				inv2.RemoveItem2(Fourteen_Quest);
			    
				break;
				
		}
	}
}
