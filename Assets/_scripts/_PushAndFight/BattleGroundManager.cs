using UnityEngine;
using System.Collections;
using Sfs2X.Entities.Data;
using Sfs2X;
using System.Collections.Generic;

public enum state {normalGame, gameInvitePrepare, gameInviteAccept,
				showOnlineUsers, showOfflineUsers, showBusyUsers, 
				fightingScenePreparation, animationScene, creatureSelection,
				potionSelection,tutorial,tutorialCountDown};

public class BattleGroundManager : MonoBehaviour {
	
	public state curState;
	
	
	public GameObject BattleGroundPlayer;
	//BasePlates
	public GameObject gameInvitePrepareBasePlate;
	public GameObject gameInviteAcceptBasePlate;
	public GameObject showOnlineUsersBasePlate;
	public GameObject showOfflineUsersBasePlate;
	public GameObject showBusyUsersBasePlate;
	public GameObject fightingBasePlate;
	public GameObject animationSceneBasePlate;
	public GameObject creatureSelectionBasePlate;
	public GameObject potionSelectionBasePlate;
	public GameObject betPopUpBasePlate;
	
	private bool battleRequestInProgress;	//to avoid multiple button click
		
	public GameObject inviteCreatureImage;
	public GameObject obeliskImage;
	
	public GameObject fightCreatureImage;
	public GameObject fightObeliskImage;
	
	public GameObject menuMyCreatureImage;
	public GameObject menuEnemyCreatureImage;
	public GameObject menuPotionImage;
	public GameObject rewardSelectionImage;
	
	public GameObject betAmount;
	
	//buttons
	public GameObject battle;
	public GameObject battleActive;
	public GameObject battleDeath;
	public GameObject battleDeathActive;
	public GameObject battleSparks;
	public GameObject battleSparksActive;
	
	//GameObjects
	public GameObject inventory;
	
	//Scripts
	private InventoryItems iItemsScript;
	
	//vars required to store information
	//that need to be sent to the server
	private int battleGameType;		//1-friendly, 2-sparks, 3-death
	public int battleCreatureId;
	private int battleObeliskId;
	private int battleSparksBetAmount;
	
	public int opponentBattleCreatureId;
	public int battleId;
	public string opponentId;
	public string myUserId;
	public int potionId;
	public bool gotServerResponse = false;
	
	//prefab
	public GameObject listOne;
	public GameObject listTwo;
	
	public PrefabListItem listOnePrefab;
	public PrefabListItem listTwoPrefab;
	
	public GameObject theScrollObject;
	public UIScrollList theScrollList;
	
	public GameManager gameManager;
	private UpgradeTexture utScript;
	
	public GameObject sfxObject;
	private SfsRemote sfsrScript;
	
	private GameObject scrollGameObject;
	
	private ISFSArray onlineUserListArr;
	private ISFSArray offlineUserListArr;
	private ISFSArray busyUserListArr;
	
	private bool battleRequestReceived;
	public static bool showpopup = false;
	public bool fightAccepted = false;
	public GameObject BattleGroundObj;
	public GameObject BattlePlateObj;
	public string SentUserName = "";
	private GameObject returncreature;
	private string creature_name;
	
	public GameObject BattlePopupObj;
	public GameObject BattleUserName;
	
	public GameObject BattleRequestSent;
	public GameObject BattleRequestUserName;
	
	public GameObject BattleMenuCreature1Name;
	public GameObject BattleMenuCreature2Name;
	
	public GameObject BattleMenuPlayerCreatureLevel;
	public GameObject BattleMenuOppCreatureLevel;
	
	public GameObject BattleStartTime;
	public GameObject BattleTimer;
	
	public GameObject BattleMessageAfterWin;
	public GameObject BattleMessageAfterWinText;
	public GameObject BattleMessageOKButton;
	
	public GameObject BattlePopUpTapCount;
	public GameObject BattlePopUpTapCountText;
	
	public GameObject HUDObj;
	public GameObject InventoryItem;
	public GameObject MainMenuUI;
	public GameObject DayNightSystem;
	
	public GameObject playerTrainingGround, opponentTraingGround;
	
	private GameObject player2Position;
	private GameObject player1Position;

	private int user1CreatureLevel;
	private int user2CreatureLevel;
	
	private int sec;
	
	private SpriteText st,stOpp,time,stWin,stLose,creature1Name,creature2Name,battleTimeCount,battleTapMessage;
	public SpriteText tutorialPrepTime;
	public SpriteText tutorialFightAccepted;
	
	private bool TimeOutFight = false;
	
	public Dictionary<int,int> potDic;
	private Dictionary<int,int> potionOjectId;
	
	
	private Material TGMaterial;
	
	public GameObject MyPlayer,OppPlayer;
	
	private int mycreatureId;
	private int oppoentCreatureId;
	private SmartFox bgmSfs;
	
	string CurName;
	string oppName;
	
	public Texture2D Alpha;
	GameObject player;
	GameObject opponent;
	
	public GameObject busyFriendCollider;
	private int tapCount = 0;
	public GameObject busyScreenCollider;
	
	public bool isBattle = false;
	public CameraControl camControl;
	public static bool battleGuiActive = false;
	
	private bool earth,plant,water,swamp,fire,darkearth;
	private bool trainingGroundPower = false;
	private bool tutorialTrainingGroundPower = false;
	public bool tutorialEffects = false;
	
	private int powerID = 1;
	string powertwoName = "";
	string powerThirdName = "";
	
	private GameObject taptowin;
	private TapCange changetap;
	
	public GUIStyle TapGUIStyle;
	private TappingGroup tapinggroup;
	
	public GameObject dummyBattleAcceptPopup;
	public GameObject DummyPotionImage;
	public GameObject DummyJoinScreen;
	public GameObject DummyPotionSelect;
	public GameObject tap1,tap2,tap3,tap4;
	public GameObject atap1,atap2,atap3,atap4;
	public GameObject ExtraPowerBackPanel;
	public GameObject arrowHand;
	private GameObject write;
	private GameObject arrow;
	
	public static int howMany = 0;
	public int totalTap = 0;
	private int battleType = 0;
	private int sparksInvitation = 0;
	
	private string textToSpeak = "";
	public GameObject OppFireTG;
	public GameObject OppSwampTG;
	public GameObject OppWaterTG;
	public GameObject P_FireTG;
	public GameObject P_SwampTG;
	public GameObject P_WaterTG;
	
	//public GameObject AchievementsIcon;
	public GameObject FriendsBlock;
	public GameObject InviteBattleType;
	public GameObject InviteBattleTypeHost;
	public GameObject InviteBattleType_2;
	public GameObject selectCreature;
	public GameObject startBattleCollider;
	public GameObject selectPotion;
	public GameObject blockDarkling;
	private GameObject animator;
	private GameObject animatorText;
	private GameObject tempPart;
	
	public int pageNumber = 1;
	public int totalNumberOfPages;
	
	//Achievments Variable
	private AchivementsDetails ad;
	// Battle Audio
	
	public AudioSource battleAudio;
	public AudioSource battleStart;
	public AudioSource battleTorch;
	public AudioSource battleBackground;
	
	private popUpInformation scr_popUpInformation;
	
	
	void Start () {
		Debug.Log ("Battle ground manager...");
		scr_popUpInformation = GameObject.Find("PopUPManager").gameObject.GetComponent<popUpInformation>();
		
		if(PlayerPrefs.GetInt("isBattleFirstTime")!=2)
		{
			
			PlayerPrefs.SetInt("isBattleFirstTime",1);
			
		}
		//isBattleFirstTime = 1;
		curState = state.normalGame;
		battleRequestInProgress = false;
		iItemsScript = inventory.GetComponent<InventoryItems>();
		utScript = gameManager.GetComponent<UpgradeTexture>();
		sfsrScript = sfxObject.GetComponent<SfsRemote>();
		

		battleSparksBetAmount = 0;
		battleGameType = 0;
		
		myUserId = PlayerPrefs.GetString("CurrentUserId");	//My user ID
		
///***		Debug.Log(myUserId+"+++++++Here your Name+++++++");
		st = BattleMenuPlayerCreatureLevel.GetComponent<SpriteText>();
		stOpp = BattleMenuOppCreatureLevel.GetComponent<SpriteText>();
		time = BattleStartTime.GetComponent<SpriteText>();
		battleTimeCount = BattleTimer.GetComponent<SpriteText>();
		
		stWin = (SpriteText) BattleMessageAfterWinText.GetComponent<SpriteText>();
		stLose = (SpriteText) BattleMessageAfterWinText.GetComponent<SpriteText>();
		battleTapMessage = (SpriteText) BattlePopUpTapCountText.GetComponent<SpriteText>();
		
		creature1Name = BattleMenuCreature1Name.GetComponent<SpriteText>();
		creature2Name = BattleMenuCreature2Name.GetComponent<SpriteText>();
		ActivateBusyCollider(false);
		changetap = (TapCange)FindObjectOfType(typeof(TapCange));
		tapinggroup = (TappingGroup)FindObjectOfType(typeof(TappingGroup));
		
		write = GameObject.Find("FightingTutorial");
		animator = GameObject.Find("Bubble");
		animatorText = GameObject.Find("SpeakText");
		
		if(animator != null)
		{
		 animator.SetActiveRecursively(false);
		}
		animatorText.SetActiveRecursively(false);
		ad =(AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
	}
	
	
	/*void OnGUI()
	{
		
		/*
		if(tutorialTrainingGroundPower)
		{
			ExtraPowerBackPanel.SetActiveRecursively(true);
		
			GUI.enabled = e1;
			if(GUI.Button(new Rect(210,Screen.height - 82,166,80),"E1",TapGUIStyle))
			{
				DestroyHandGameObject();
				ExtraPowerParticalEffect(1);
			}
			
		}
		
		*/
		
		
		/*
		if(trainingGroundPower)
		{
			ExtraPowerBackPanel.SetActiveRecursively(true);
		if(earth | water | fire | plant | swamp | darkearth)
		{	GUI.enabled = e1;
			if(GUI.Button(new Rect(210,Screen.height - 82,166,80),powerOneName,TapGUIStyle))
			{
				tapCount+=10;
				ActivatePower();
				ExtraPowerTap();
				ExtraPowerParticalEffect(powerOneName);
				e1 = false;
			}
			GUI.enabled = e2;
			if(GUI.Button(new Rect(420,Screen.height - 82,166,80),powertwoName,TapGUIStyle))
			{
				tapCount+=20;
				ExtraPowerTap();
				ExtraPowerParticalEffect(powertwoName);
				e2 = false;
			}
			GUI.enabled = e3;
			if(GUI.Button(new Rect(640,Screen.height - 82,166,80),powerThirdName,TapGUIStyle))
			{
				tapCount+=30;
				ExtraPowerTap();
				ExtraPowerParticalEffect(powerThirdName);
				e3 = false;
			}
		}
		}
		

		GUI.enabled = true;
		if(curState == state.fightingScenePreparation)
		{
			
			
			time.Text = "00:"+ (sec - Mathf.FloorToInt(Time.time)).ToString("00");
			
			
		}
		
		if(curState == state.tutorial)
		{
			
			
			tutorialPrepTime.Text = "00:"+ (sec - Mathf.FloorToInt(Time.time)).ToString("00");
			
			
		}
		
		if(curState == state.tutorialCountDown)
		{
			
			
			battleTimeCount.Text = (sec - Mathf.FloorToInt(Time.time)).ToString("00");
			
			
		}
		
		if(curState == state.animationScene)
		{
			
			battleTimeCount.Text = (sec - Mathf.FloorToInt(Time.time)).ToString("00");
			
		}
		
		if((sec - Mathf.FloorToInt(Time.time)) < 0)
		{
			
			battleTimeCount.Text = "00";
			tutorialPrepTime.Text = "00:00";
			
		}
		
		if((sec - Mathf.FloorToInt(Time.time)) == 0)			//When the timer is zero
		{
			if(TimeOutFight)
			{
			Debug.Log("Time Out Fight Started");
			StartFight();
			iItemsScript.inventoryClose();						//when timer is zero close the potion inventory
			iItemsScript.closeMainMenu();
			TimeOutFight = false;
			}
		}
		
		if(gotServerResponse & GameManager.gameLevel>3)
		{
			
			FightRequestHandlerManager();
			BattlePopupObj.SetActiveRecursively(true);
			gotServerResponse = false;
			
		}
		else if(battleRequestReceived & GameManager.gameLevel>3)
		{
			

			FightRequestHandlerManager();
			BattlePopupObj.SetActiveRecursively(true);
			battleRequestReceived = false;
			
			
		}
		
		
//		if(GUI.Button(new Rect(Screen.width - 100,5,100,30),"Battle"))
//		{
//			
//			battleGuiActive = true;
//			ResetGameDataAfterFight();
//			BattleScreenCollider(true);
//			if(!battleRequestInProgress)
//			{
//					battleRequestInProgress = true;		//disable the battle function functionality
//					curState = state.gameInvitePrepare;
//					BattleFightHandler();
//				StartTutorial(0);
//
//			}
//		}
		
		if(sfsrScript.fightRequestbool)
		{
			BattleRequestSent.SetActiveRecursively(true);
			RequestSentForBattle();
			sfsrScript.fightRequestbool = false;
		}
	
	}*/
/*	
	void ActivatePower()
	{
		
			StartCoroutine("chagePower");
		
		
	}
	
	IEnumerator chagePower()
	{
		yield return new WaitForSeconds(5f);
		e2 = true;
		yield return new WaitForSeconds(10f);
		e2 = false;
		e3 = true;
		yield return new WaitForSeconds(5f);
		e3 = false;
	}
	
	*/
	public void BattleStartAudio()
	{
		
		battleStart.PlayOneShot(battleStart.GetComponent<AudioSource>().clip);
		battleTorch.Play();
		battleBackground.Play();
		AudioController.EnableEnviron = false;
	}
	
	
	public void IntroduceBattle()
	{
		
			battleAudio.PlayOneShot(battleAudio.GetComponent<AudioSource>().clip);
			panelControl.panelMoveIn = true;
			GameManager.battleActiveBool = true;
		
			battleGuiActive = true;
			ResetGameDataAfterFight();
			BattleScreenCollider(true);
		
			if(!battleRequestInProgress)
			{
					battleRequestInProgress = true;		//disable the battle function functionality
					curState = state.gameInvitePrepare;
					BattleFightHandler();
					StartTutorial(0);

			}
		
		
		
		
		objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;
		
		objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfoFrm.panelMoveIn = true;
		objPanelInfoFrm.panelMoveOut = false;
		
		objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
		attackPanelInfoAttack.panelMoveIn = true;
		attackPanelInfoAttack.panelMoveOut = false;
		
		objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
		movePanelInfo.panelMoveIn = true;
		movePanelInfo.panelMoveOut = false;
		
		
	}
	public void BattleScreenCollider(bool say)			//Battle Screen Collider
	{
		busyScreenCollider.SetActiveRecursively(say);
		
		
	}
	
	
	
	void BackToMainGame()
	{
		
		curState = state.normalGame;
		
	}
	
	void isRealGamePlay()
	{
		if(PlayerPrefs.GetInt("isBattleFirstTime") == 2)
		{
		GetComponent<BattleGroundPlayer>().RealGamePlay = true;
		}
	}
	
	
	void BattleEndMessage()				//End Battle POPUP OK button
	{
		BattleMessageAfterWin.SetActiveRecursively(false);
		BattleGroundObj.SetActiveRecursively(false);
		
		TransformBackGUIComponent();
		//HUDObj.SetActiveRecursively(true);
		InventoryItem.SetActiveRecursively(true);
		MainMenuUI.SetActiveRecursively(true);
		DayNightSystem.SetActiveRecursively(true);
		
		ResetGameDataAfterFight();
		BattleScreenCollider(false);
		battleGuiActive = false;
		GameManager.battleActiveBool = false;
	
		totalTap = 0;
		battleType = 0;
		BattleGroundPlayer.SetActiveRecursively(false);
		DisableAnimatedTG();
		
		battleTorch.Stop();
		battleBackground.Stop();
		AudioController.EnableEnviron = true;
		
		
	}
	
	void ResetGameDataAfterFight()
	{
		
		fightCreatureImage.renderer.material.mainTexture = Alpha;
		fightObeliskImage.renderer.material.mainTexture = Alpha;
		obeliskImage.renderer.material.mainTexture = Alpha;
		inviteCreatureImage.renderer.material.mainTexture = Alpha;
		rewardSelectionImage.renderer.material.mainTexture = Alpha;
		
		ResetInvitePrepareButtons();
		battleGameType = 0;
		battleSparksBetAmount = 1;
		battleCreatureId = 0;
		tapCount = 0;
		BetAmountText();
	}
	
	void MessageAfterBattleWin(string msg,double xpWin, double goldWin, double sparksWin)
	{
		
		stWin.Text = msg+"XP : "+(int)xpWin+" GOLD : "+(int)goldWin+" Sparks :"+sparksWin;
		
	}
	
	void MessageAfterbattleLose(string msg,double xpWin,double sparksWin)
	{
		
		
		stLose.Text = msg+"XP : "+(int)xpWin;
		
	}
	
	void SelectinventoryPotionsButton()
	{
		
		iItemsScript.inventoryPotionsForFight();
		
	}
	
	void RequestSentForBattle()
	{
		
		SpriteText st = (SpriteText) BattleRequestUserName.GetComponent<SpriteText>();
		st.Text = "Your request to "+SentUserName+"\nhas been sent";
		
	}
	
	void AcceptBattleRequestSent()
	{
		
		closeUIOpen();
		BattleRequestSent.SetActiveRecursively(false);
	}
	
	
	void FightRequestHandlerManager()
	{
		
		SpriteText st = (SpriteText) BattleUserName.GetComponent<SpriteText>();
		st.Text = opponentId;
		
	}
	
	
	void AcceptBattle()
	{
		if(sparksInvitation<GameManager.sparks)
		{
		curState = state.gameInviteAccept;
		BattleFightHandler();
		BattlePopupObj.SetActiveRecursively(false);
		}
		else {
			
	
		}
	}
	
	void CancelBattle()
	{
		
		BattlePopupObj.SetActiveRecursively(false);
		BattleScreenCollider(false);
	}
	
	void SendBattleDeclinedMessage()
	{
		
		sfsrScript.FightRejected(battleId);
		
	}
	
	private void setCreatureLevelText(int creature1,int creature2)			// Set Creature Level Text on Invite Prepare 
	{
		Debug.Log(creature1+" "+creature2+" both Creature Level");
		st.Text = "Level "+creature1;
		stOpp.Text = "Level "+creature2;
		
	}
	
	private void setCreatureNameText(int creature1Id,int creature2Id)		//set Creature Name Text
	{
		
		creature1Name.Text = getNameOfCreature(creature2Id).name;
		creature2Name.Text = getNameOfCreature(creature1Id).name;
		
	}
	
	private GameObject CheckRotationOfObject(GameObject obj)
	{
		switch(obj.tag)
		{
		case "Barg":
			
			obj.transform.localScale = new Vector3(-1,1,1);
			
			break;
			
		case "Fenrir":
			
			obj.transform.localScale = new Vector3(-1,1,1);
			
			break;
			
		case "HellHound":
			
			obj.transform.localScale = new Vector3(-1,1,1);
			
			break;
			
		case "DHound":
			
			obj.transform.localScale = new Vector3(-1,1,1);
			
			break;
			
		case "Hound":
			
			obj.transform.localScale = new Vector3(-1,1,1);
			
				
			break;
			
			Debug.Log(obj.name+" is getting flipped");
			
		}
		return obj;
	}
	
	private GameObject InstantiateObject(int objId)
	{
		
		GameObject gObject = Instantiate(getNameOfCreature(objId)) as GameObject;
		
		gObject = CheckRotationOfObject(gObject);
		
		return gObject;
		
	}
	
//	private void InstantiateGameObjectToSceneDemo(int creature1ID,int creature2ID)								// Instantiate two player for fight
//	{
//		playerPosition = GameObject.Find("Player");
//		opponentPosition = GameObject.Find("Opponent");
//		
//		
//	}
	
	private void InstantiateGameObjectToScene(int creature1ID,int creature2ID)								// Instantiate two player for fight
	{
		//BattleGroundPlayer.SetActiveRecursively(true);
		if(myUserId == CurName)
		{
		
		player1Position = GameObject.Find("Opponent");
		player2Position = GameObject.Find("Player");
		
		player = InstantiateObject(creature1ID);
		opponent = InstantiateObject(creature2ID);
			
		player.transform.position = player1Position.transform.position;
		opponent.transform.position = player2Position.transform.position;
			
		
		player.transform.rotation = Quaternion.Euler(0,0,180);
			
		
		player.name = getNameOfCreature(creature1ID).name;
		opponent.name = getNameOfCreature(creature2ID).name;
			
		GetComponent<BattleGroundPlayer>().my_Player = opponent;  		// Assign Game Object to variable which will be used for Animation
		GetComponent<BattleGroundPlayer>().opp_Player = player;
			
			Debug.Log("Under Current Name "+player.transform.rotation+" "+opponent.transform.rotation);
		}
		else if(myUserId == oppName)
		{
		
		player1Position = GameObject.Find("Player");
		player2Position = GameObject.Find("Opponent");
		
		player = InstantiateObject(creature1ID);
		opponent = InstantiateObject(creature2ID);
		
		player.transform.position = player1Position.transform.position;
		opponent.transform.position = player2Position.transform.position;
		
		opponent.transform.rotation = Quaternion.Euler(0,0,180);
			
		//player = Instantiate(getNameOfCreature(creature1ID),player1Position,Quaternion.Euler(270,180,0)) as GameObject;
		player.name = getNameOfCreature(creature1ID).name;
		//opponent = Instantiate(getNameOfCreature(creature2ID),player2Position,Quaternion.Euler(270,0,0)) as GameObject;
		opponent.name = getNameOfCreature(creature2ID).name;
		
		GetComponent<BattleGroundPlayer>().my_Player = player;  		// Assign Game Object to variable which will be used for Animation
		GetComponent<BattleGroundPlayer>().opp_Player = opponent;
			
			Debug.Log("Under Opp Name "+player.transform.rotation+" "+opponent.transform.rotation);
		}
		
		Debug.Log("Inside Instantiate Object");
		
		
		
		
		GetComponent<BattleGroundPlayer>().CustomStart();
		Debug.Log("Inside Instantiate Object End");
	}
	
	
	
	
	
	private void DestroyCreaturesAfterFight()
	{
		
		Destroy(player);
		Destroy(opponent);
		
	}
	
	private void showExtraPowerToUser(int power)				//Extra Power
	{
		powerID = power;
		
	}
	
	public void FightAcceptInfo(ISFSObject obj)								//Fight Accept Info from server
	{
		
		isRealGamePlay();   //Active it
		GetComponent<BattleGroundPlayer>().generateRandomBubbles = false;
		
		CurName = "";
		oppName = "";
		
		ResetGameDataAfterFight();
		Debug.Log("Inside Fight Accept Info");
		TimeOutFight = true;
		sec = 20 + Mathf.FloorToInt(Time.time);
		
		CurName = obj.GetUtfString("userId");
		oppName = obj.GetUtfString("userId1");
		
		Debug.Log("**********"+"CurName "+CurName+"----"+" OppName "+oppName);
		
		mycreatureId = obj.GetInt("user1CreatureId");
		oppoentCreatureId = obj.GetInt("user2CreatureId");
		user1CreatureLevel = obj.GetInt("user1CreatureFeedLevel");
		user2CreatureLevel = obj.GetInt("user2CreatureFeedLevel");
		
		if(CurName == myUserId)
		{
			showExtraPowerToUser(CreatureFromWhichTrainingGround(oppoentCreatureId));
			
			Debug.Log("Its Your Creature");
		}
		else{
			
			Debug.Log("Its Opponent Creature");
			showExtraPowerToUser(CreatureFromWhichTrainingGround(mycreatureId));
		}
				//At Bottom Extra Power
		Debug.Log(mycreatureId+"-----"+oppoentCreatureId);
		
		
		if(myUserId == CurName)
		{
			
			battleCreatureId = oppoentCreatureId;		//mycreatureId;
			opponentBattleCreatureId = mycreatureId;
			setCreatureLevelText(user1CreatureLevel,user2CreatureLevel);
			setCreatureNameText(mycreatureId,oppoentCreatureId);
			
		}
		else if(myUserId == oppName)
		{
			
			battleCreatureId = mycreatureId;
			opponentBattleCreatureId = oppoentCreatureId;
		
			setCreatureNameText(oppoentCreatureId,mycreatureId);
			setCreatureLevelText(user2CreatureLevel,user1CreatureLevel);
		}
		
		BattleFightHandler();
		BattleMenuCreatureImageManager(battleCreatureId,opponentBattleCreatureId);
		
		BattleScreenCollider(true);
	}
	
	public void LoadFightScene()
	{
		BattleGroundObj.SetActiveRecursively(true);
		BattlePlateObj.SetActiveRecursively(true);
		
		if(myUserId == CurName)
		{
		playerTrainingGround.renderer.material = AssignTGtoRespectiveCreature(oppoentCreatureId);		//My Creature TG
		opponentTraingGround.renderer.material = AssignTGtoRespectiveCreature(mycreatureId);			//Opp Creature TG
		
		AnimatedTG(oppoentCreatureId,true);
		AnimatedTG(mycreatureId,false);
		}
		else if(myUserId == oppName)
		{
			
		playerTrainingGround.renderer.material = AssignTGtoRespectiveCreature(mycreatureId);			//My Creature TG
		opponentTraingGround.renderer.material = AssignTGtoRespectiveCreature(oppoentCreatureId);		//Opp Creature TG

		AnimatedTG(oppoentCreatureId,false);
		AnimatedTG(mycreatureId,true);
		}
		InstantiateGameObjectToScene(mycreatureId,oppoentCreatureId);
		
		
		
	}
	
	public void closeUIOpen()
	{
		ListUsersCloseButton();
		InvitePrepareCancelButton();
		
	}
	
	public void BattleFightHandler()
	{
		BasePlateActivationManager();
		battleRequestInProgress = false;	//enable the battle button functionality
	}
	
	private void BasePlateActivationManager()	//activate base plate according to the cur state
	{
		Debug.Log("state: "+curState);
		BasePlateDeactivationManager();
		if(curState == state.gameInvitePrepare)
		{
			BasePlate(gameInvitePrepareBasePlate, true);
		}
		else if(curState == state.gameInviteAccept)
		{
			BasePlate(gameInviteAcceptBasePlate, true);
			AcceptLockManager(battleType);
		}
		else if(curState == state.showOnlineUsers)
		{
			BasePlate(showOnlineUsersBasePlate, true);
			//UserListManager(1);
		}
		else if(curState == state.showOfflineUsers)
		{
			BasePlate(showOfflineUsersBasePlate, true);
			//UserListManager(3);
		}
		else if(curState == state.showBusyUsers)
		{
			BasePlate(showBusyUsersBasePlate, true);
			//UserListManager(2);
		}
		else if(curState == state.fightingScenePreparation)
		{
			BasePlate(fightingBasePlate, true);
			//BattleMenuCreatureImageManager(1,0);
		}
		else if(curState == state.animationScene)
		{
			BasePlate(animationSceneBasePlate, true);
		}
		else if(curState == state.creatureSelection)
		{
			BasePlate(creatureSelectionBasePlate, true);
		}
		
		
	}
	
	private void BasePlateDeactivationManager()	//deactivate base plate according to the cur state
	{
		Debug.Log("deact");
		BasePlate(gameInvitePrepareBasePlate, false);
		BasePlate(gameInviteAcceptBasePlate, false);
		BasePlate(showOnlineUsersBasePlate, false);
		BasePlate(showOfflineUsersBasePlate, false);
		BasePlate(showBusyUsersBasePlate, false);
		BasePlate(fightingBasePlate, false);
		BasePlate(animationSceneBasePlate, false);
		BasePlate(creatureSelectionBasePlate, false);
		BasePlate(potionSelectionBasePlate, false);
		RemovePreviousScrollList();
	}
	
	private void BasePlate(GameObject g, bool activate)
	{
		if(g != null)
		{
			g.active = activate;
			g.SetActiveRecursively(activate);
		}
	}
	
	private Texture GetCreatureCardImage(int id)
	{
		StartTutorial(2);			//Battle Type
		Texture theTexture = null;
		switch(id) {
		case 3:
			theTexture = utScript.halflingHoundCard;
			break;
		case 22:
			theTexture = utScript.halflingBargCard;
			break;
		case 26:
			theTexture = utScript.halflingCusithCard;
			break;
		case 21:
			theTexture = utScript.halflingSproutCard;
			break;
		case 32:
			theTexture = utScript.halflingNymphCard;
			break;
		case 41:
			theTexture = utScript.halflingDryadCard;
			break;
		case 24:
			theTexture = utScript.halflingNixCard;
			break;
		case 38:
			theTexture = utScript.halflingDraugCard;
			break;
		case 50:
			theTexture = utScript.halflingDagonCard;
			break;
		case 209:
			theTexture = utScript.darklingHoundCard;
			break;
		case 224:
			theTexture = utScript.darklingFenrirCard;
			break;
		case 237:
			theTexture = utScript.darklingHellHoundCard;
			break;
		case 215:
			theTexture = utScript.darklingSpriteCard;
			break;
		case 225:
			theTexture = utScript.darklingImpCard;
			break;
		case 241:
			theTexture = utScript.darklingDjinnCard;
			break;
		case 208:
			theTexture = utScript.darklingLeechCard;
			break;
		case 222:
			theTexture = utScript.darklingLeshyCard;
			break;
		case 234:
			theTexture = utScript.darklingLurkerCard;
			break;
		default:
			break;
		}
		return theTexture;
	}
	
	private Texture GetObeliskImage(int id)
	{
		Texture theTexture = null;
		switch(id) {
		case 3:
		case 22:
		case 26:
			theTexture = utScript.halflingEarthObelisk;
			break;
		case 21:
		case 32:
		case 41:
			theTexture = utScript.halflingPlantObelisk;
			break;
		case 24:
		case 38:
		case 50:
			theTexture = utScript.halflingWaterObelisk;
			break;
		case 209:
		case 224:
		case 237:
			theTexture = utScript.darklingEarthObelisk;
			break;
		case 215:
		case 225:
		case 241:
			theTexture = utScript.darklingFireObelisk;
			break;
		case 208:
		case 222:
		case 234:
			theTexture = utScript.darklingSwampObelisk;
			break;
		default:
			break;
		}
		return theTexture;
	}
	
	private void InvitePrepareCreatureSelectButton()	//called when creature selection button is clicked
	{
		DestroyHandGameObject();
		isBattle = true;
		sfsrScript.getCreatureList();
		fightObeliskImage.renderer.material.mainTexture = Alpha;
		obeliskImage.renderer.material.mainTexture = Alpha;
		
		buttonPulse invPotion = GameObject.Find("BattleSelectCreature").GetComponent("buttonPulse") as buttonPulse;
		//open creature selection window
		//get all the creatures created by the user from server
		//show all of em to the user
		Debug.Log("creature selection");
		iItemsScript.inventoryCreature();
		
		StartTutorial(1);
		
	}
	
	public void InvitePrepareCancelButton()	//called when cancel button is clicked
	{
		isBattle = false;
		Debug.Log("cancel");
		curState = state.normalGame;
		BasePlateActivationManager();
		BattleScreenCollider(false);
		battleGuiActive = false;
		GameManager.battleActiveBool = false;
		DestroyHandGameObject();
	}
	
	private void InvitePrepareHostButton()	//called when host button is clicked
	{
		Debug.Log("host");
		//get creature id, obelisk id, game type and bet amount
		//store em all
		if(battleCreatureId != 0 & battleGameType !=0)
		{
			DestroyHandGameObject();
		//send request to server
			sfsrScript.SendUserListRequest("5",21,pageNumber,1);
			curState = state.showOnlineUsers;
			BasePlateActivationManager();
			StartTutorial(4);
		}
	}
	
	private void OfflineButton()	//called when offline button is clicked
	{
		Debug.Log("offline");
		pageNumber = 1;
		//get creature id, obelisk id, game type and bet amount
		//send em all to server
		sfsrScript.SendUserListRequest("5", 21,pageNumber,2);
		curState = state.showOfflineUsers;
		BasePlateActivationManager();
		
		ActivateBusyCollider(false);
	}
	
	private void OnlineButton()			//called when online button is clicked
	{
		Debug.Log("online");
		pageNumber = 1;
		//get creature id, obelisk id, game type and bet amount
		//send em all to server
		sfsrScript.SendUserListRequest("5", 21,pageNumber,1);
		curState = state.showOnlineUsers;
		BasePlateActivationManager();
		
		ActivateBusyCollider(false);
	}
	
	private void BusyButton()	//called when online button is clicked
	{
		Debug.Log("busy");
		pageNumber = 1;
		//get creature id, obelisk id, game type and bet amount
		//send em all to server
		sfsrScript.SendUserListRequest("5", 21,pageNumber,3);
		curState = state.showBusyUsers;
		BasePlateActivationManager();
		
		ActivateBusyCollider(true);
		
	}
	
	private void ActivateBusyCollider(bool doActivate)			// You cannot play math with busy Friends
	{
		busyFriendCollider.SetActiveRecursively(doActivate);
		
	}
	
	
	private void BetPopUpAcceptButton()
	{
		Debug.Log("accept");
		//get bet amount and store it in a variable
		BasePlate(betPopUpBasePlate, false);
		
		ActivateBusyCollider(false);
	}
	
	private void BetPopUpDeclineButton()
	{
		battleSparksBetAmount = 1;				//Reset bet Value
		BetAmountText();
		
		Debug.Log("decline");
		BasePlate(betPopUpBasePlate, false);
		
		ActivateBusyCollider(false);
		BetAmountText();
	}
	
	private void CloseButton()
	{
		
		curState = state.normalGame;
		BasePlateActivationManager();
		BattleScreenCollider(false);
		battleGuiActive = false;
		GameManager.battleActiveBool = false;
	}
	
	private void ListUsersCloseButton()	 //called when close button is clicked
	{
		Debug.Log("close");
		theScrollObject.active = false;
		theScrollObject.SetActiveRecursively(false);
		curState = state.gameInvitePrepare;
		BasePlateActivationManager();
		
		ActivateBusyCollider(false);
	}
	
	public void InviteCreatureImageManager(int id, int use)
	{
		DestroyHandGameObject();
		Texture creatureTexture = GetCreatureCardImage(id);
		
		if(use ==0){
		if(creatureTexture != null)
			{
			inviteCreatureImage.renderer.material.SetTexture("_MainTex", creatureTexture);
			}
		else
			{
			Debug.Log("nope");
			}
		}
		
		if(use ==1)
		{
			
			if(creatureTexture != null)
				{
					Debug.Log("Yahoo!!");
					fightCreatureImage.renderer.material.SetTexture("_MainTex", creatureTexture);
				}
			else
				{
					Debug.Log("nope");
				}
			
		}
		//inviteCreatureImage.transform.position = new Vector3(inviteCreatureImage.transform.position.x , 9 , inviteCreatureImage.transform.position.z);
		
		battleCreatureId = id;		
		Texture obeliskTexture = null;
		battleObeliskId = 0;
		
		if(HasObelisk(id))
		{
			obeliskTexture = GetObeliskImage(id);
			battleObeliskId = GetObelsikId(id);
		}
		
		if(use ==0)
		{
			if(obeliskTexture != null)
			{
				obeliskImage.renderer.material.SetTexture("_MainTex", obeliskTexture);
				Debug.Log("yep");
			}
			else
			{
				Debug.Log("nope");
			}
			
		}
		
		if(use == 1)
		{
			
			if(obeliskTexture != null)
			{
				fightObeliskImage.renderer.material.SetTexture("_MainTex", obeliskTexture);
				Debug.Log("yep");
			}
			else
			{
				Debug.Log("nope");
			}
			
		
			
		}
		obeliskImage.transform.position = new Vector3(obeliskImage.transform.position.x , 9 , obeliskImage.transform.position.z);
		
		
	}
	
	private int GetObelsikId(int id)
	{
		switch(id) {
		case 3:
		case 22:
		case 26:
			return 37;
		case 21:
		case 32:
		case 41:
			return 43;
		case 24:
		case 38:
		case 50:
			return 48;
		case 209:
		case 224:
		case 237:
			return 227;
		case 215:
		case 225:
		case 241:
			return 232;
		case 208:
		case 222:
		case 234:
			return 223;
		default:
			break;
		}
		return 0;
	}
	
	private bool HasObelisk(int id)
	{
		switch(id) {
		case 3:
		case 22:
		case 26:
			return ObelsikCheck("HC_B_EarthObelisk_GO(Clone)");
		case 21:
		case 32:
		case 41:
			return ObelsikCheck("HC_B_PlantObelisk_GO(Clone)");
		case 24:
		case 38:
		case 50:
			return ObelsikCheck("HC_B_WaterObelisk_GO(Clone)");
		case 209:
		case 224:
		case 237:
			return ObelsikCheck("DL_B_EarthObelisk_GO(Clone)");
		case 215:
		case 225:
		case 241:
			return ObelsikCheck("DL_B_FireObelisk_GO(Clone)");
		case 208:
		case 222:
		case 234:
			return ObelsikCheck("DL_B_SwampObelisk_GO(Clone)");
		default:
			break;
		}
		return false;
	}
	
	private bool ObelsikCheck(string s)
	{
		GameObject g = null;
		g = GameObject.Find(s);
		if(g != null)
			return true;
		else
			return false;
	}
	
	private void ResetInvitePrepareButtons()
	{
		PullItUp(battle);
		PullItUp(battleDeath);
		PullItUp(battleSparks);
		
		PushItDown(battleActive);
		PushItDown(battleDeathActive);
		PushItDown(battleSparksActive);
	}
	
	private void InvitePrepareBattleButton()	//called when battle button is clicked
	{
		PullItUp(battleActive);
		PullItUp(battleDeath);
		PullItUp(battleSparks);
		
		PushItDown(battle);
		PushItDown(battleDeathActive);
		PushItDown(battleSparksActive);
		
		battleGameType = 1;
		CheckForDestroyHandGameObject();
	}
	
	private void InvitePrepareBattleDeathButton()	//called when battle death button is clicked
	{
		PullItUp(battle);
		PullItUp(battleDeathActive);
		PullItUp(battleSparks);
		
		PushItDown(battleActive);
		PushItDown(battleDeath);
		PushItDown(battleSparksActive);
		
		battleGameType = 3;
		CheckForDestroyHandGameObject();
	}
	
	private void InvitePrepareBattleSparksButton()	//called when battle sparks button is clicked
	{
		ActivateBusyCollider(true);
		PullItUp(battle);
		PullItUp(battleDeath);
		PullItUp(battleSparksActive);
		
		PushItDown(battleActive);
		PushItDown(battleDeathActive);
		PushItDown(battleSparks);
		
		BasePlate(betPopUpBasePlate, true);	//to show the pop up window
		
		battleGameType = 2;
		CheckForDestroyHandGameObject();
	}
	
	
	private void PushItDown(GameObject g)	//inactivate active button
	{
		g.transform.position = new Vector3(g.transform.position.x, 0, g.transform.position.z);
	}
	
	private void PullItUp(GameObject g)	//activate inactive button
	{
		g.transform.position = new Vector3(g.transform.position.x, 9, g.transform.position.z);
	}
	
	//--------------------------------New Functionality Pagination---------------------------//
	
	
	void OnlineNextButton()
	{
		
		Debug.Log("Calling Next Online List----->>>>");
		
			ShowNextPage(1);
			curState = state.showOnlineUsers;
		
	}
	
	void OnlinePrevButton()
	{
		Debug.Log("Calling Prev Online List----->>>>");
		
			ShowPrevPage(1);
			curState = state.showOnlineUsers;
			
	}
	
	void BusyNextButton()
	{
		Debug.Log("Calling Next Busy List----->>>>");
		
			ShowNextPage(3);
			curState = state.showBusyUsers;
		
	}
	
	void BusyPrevButton()
	{
		Debug.Log("Calling Prev Busy List----->>>>");
		
		
			ShowPrevPage(3);
			curState = state.showBusyUsers;
			
		
	}
	
	void OfflineNextButton()
	{
		Debug.Log("Calling Next Offline List----->>>>");
		
			ShowNextPage(2);
			curState = state.showOfflineUsers;
			
		
	}
	
	void OfflinePrevButton()
	{
		Debug.Log("Calling Prev Offline List----->>>>");
		
		ShowPrevPage(2);
		curState = state.showOfflineUsers;
	}
	
	
	private void ShowNextPage(int reqType)
	{
		Debug.Log("Total Page "+totalNumberOfPages+" PageNumber "+pageNumber);
		if(totalNumberOfPages>pageNumber)
		{
			pageNumber++;
			sfsrScript.SendUserListRequest("5", 21,pageNumber,reqType);
			BasePlateActivationManager();
			
			Debug.Log("Total Page Inside "+totalNumberOfPages+" PageNumber Inside "+pageNumber);
		}
		
	}
	
	private void ShowPrevPage(int reqType)
	{
		if(pageNumber>1)
		{
			pageNumber--;
			sfsrScript.SendUserListRequest("5", 21,pageNumber,reqType);
			BasePlateActivationManager();
			Debug.Log("Total Page Inside "+totalNumberOfPages+" PageNumber Inside "+pageNumber);
		}
		
	}
	
	
	private void checkForArrowState(int pageNu,int total)
	{
		if(pageNu<total)
		{
			//Active Next Arrow
			
		}
		
		if(pageNu<=total)
		{
			// Deactive Both Arrow
			
		}
		
		
	}
	
	
	//--------------------------------Pagination Ends---------------------------------------//
	

	
	private void UserListManager(int whichTab)					//Display Users
	{
		RemovePreviousScrollList();
		
		int tempNoOfUsers = 0;
		
		if(whichTab == 1)
			tempNoOfUsers = onlineUserListArr.Size();
		else if(whichTab == 2)
			tempNoOfUsers = busyUserListArr.Size();
		else if(whichTab == 3)
			tempNoOfUsers = offlineUserListArr.Size();
		
		
		scrollGameObject = (GameObject) GameObject.Instantiate(theScrollObject, theScrollObject.transform.position, theScrollObject.transform.rotation);
		theScrollList = (UIScrollList) scrollGameObject.GetComponent<UIScrollList>();
		if(theScrollList != null)
		{
			Debug.Log(tempNoOfUsers+"TEMP_____");
			theScrollList.sceneItems = new GameObject[tempNoOfUsers];
			CreateScrollItems(tempNoOfUsers, whichTab);
			//theScrollObject.active = true;
			
		}
		else
			Debug.Log("nope!");
	}
	
	
	
	
	private void NewUserListManager(int whichTab)					//Sumit Display Users
	{
		RemovePreviousScrollList();
		
		int tempNoOfUsers = 0;
		
		if(whichTab == 1)
			tempNoOfUsers = onlineUserListArr.Size();
		else if(whichTab == 2)
			tempNoOfUsers = busyUserListArr.Size();
		else if(whichTab == 3)
			tempNoOfUsers = offlineUserListArr.Size();
		
		
		scrollGameObject = (GameObject) GameObject.Instantiate(theScrollObject, theScrollObject.transform.position, theScrollObject.transform.rotation);
		theScrollList = (UIScrollList) scrollGameObject.GetComponent<UIScrollList>();
		if(theScrollList != null)
		{
			Debug.Log(tempNoOfUsers+"TEMP_____");
			theScrollList.sceneItems = new GameObject[tempNoOfUsers];
			CreateScrollItems(tempNoOfUsers, whichTab);
			//theScrollObject.active = true;
			
		}
		else
			Debug.Log("nope!");
	}
	
	private void RemovePreviousScrollList()
	{
		if(scrollGameObject != null)
		{
			Destroy(scrollGameObject);
		}
	}
	
	private void CreateScrollItems(int limit, int whichTab)
	{
		for(int i=0; i<limit; i++)
		{
			if(i%2 == 0)
				theScrollList.sceneItems[i] = GetGameObject(listOne, i, whichTab);
			else
				theScrollList.sceneItems[i] = GetGameObject(listTwo, i, whichTab);
		}
	}
	
	private GameObject GetGameObject(GameObject g, int i, int whichTab)
	{
		
		ISFSObject obj = null;
		
		if(whichTab == 1)
			obj = onlineUserListArr.GetSFSObject(i);
		else if(whichTab == 2)
			obj = busyUserListArr.GetSFSObject(i);
		else if(whichTab == 3)
			obj = offlineUserListArr.GetSFSObject(i);
		
		
		GameObject scrollListObject;
		scrollListObject = (GameObject)GameObject.Instantiate(g, g.transform.position, g.transform.rotation);
		SetText(GetChild(scrollListObject, "zIndex"), (i+1).ToString());
		SetText(GetChild(scrollListObject, "zUserName"), obj.GetUtfString("userId"));
		SetText(GetChild(scrollListObject, "zUserID"), obj.GetUtfString("userId"));
		return scrollListObject;
	}
	
	
	private GameObject NewGetGameObject(GameObject g, int i,string userid, int score,string FightUserid)			//Changed sumit
	{
		
		
		
		GameObject scrollListObject;
		scrollListObject = (GameObject)GameObject.Instantiate(g, g.transform.position, g.transform.rotation);
		SetText(GetChild(scrollListObject, "zIndex"), (i+1).ToString());
		SetText(GetChild(scrollListObject, "zUserName"), userid);
		SetText(GetChild(scrollListObject, "zUserID"), FightUserid);
		SetText(GetChild(scrollListObject, "zScore"), score.ToString());
		
		return scrollListObject;
	}
	
	
	private GameObject GetChild(GameObject parent, string childName)
	{
		
		return (GameObject) parent.transform.FindChild(childName).gameObject;
	}
	
	private void SetText(GameObject g, string dataInfo)
	{
		if( g != null )
		{
			SpriteText st = (SpriteText) g.GetComponent<SpriteText>();
			if(st != null)
				st.Text = dataInfo;
			else
				Debug.Log("null");
		}
		else
			Debug.Log("null");
	}
		
	private void ListUsersSelectedUserManager()
	{
		Debug.Log("yeah");
		Debug.Log("ff : "+ theScrollList.LastClickedControl);
		
		UIButton uiB = (UIButton) theScrollList.LastClickedControl;
		
		Debug.Log("name: "+uiB.gameObject.name);
		
		GameObject parentObj = uiB.gameObject.transform.parent.gameObject;
		
		Debug.Log("name: "+parentObj.name);
		
		Debug.Log("HERE WE GO------------"+GetUserId(GetChild(parentObj, "zUserID")));
		
		SendFightRequset(GetUserId(GetChild(parentObj, "zUserID")));
		
		SentUserName = GetUserId(GetChild(parentObj, "zUserName")).ToString();
		
//		Debug.Log(GetUserId(GetChild(parentObj, "zIndex")));
		
	}
	
	private string GetUserId(GameObject g)
	{
		if(g != null)
		{
			Debug.Log(g.name);
			SpriteText st = (SpriteText) g.GetComponent<SpriteText>();
			if(st != null)
				return st.Text;
			else
				Debug.Log("null");
		}
		else
			Debug.Log("null");
		return "";
	}
	
	public void changeState()
	{
		AcceptBattleRequestSent();
		Debug.Log("Change State Method++++++++++++");
		curState = state.fightingScenePreparation;
		
	}
	
	public void BattleMenuCreatureImageManager(int myCreatureId, int enemyCreatureId)
	{
		Texture creatureTexture;
		creatureTexture = GetCreatureImage(myCreatureId);
		if(creatureTexture != null)
		{
			menuMyCreatureImage.renderer.material.SetTexture("_MainTex", creatureTexture);
			Debug.Log("yep");
		}
		else
		{
			Debug.Log("nope");
		}
		menuMyCreatureImage.transform.position = new Vector3(menuMyCreatureImage.transform.position.x , 9 , menuMyCreatureImage.transform.position.z);
		
		creatureTexture = GetCreatureImage(enemyCreatureId);
		if(creatureTexture != null)
		{
			menuEnemyCreatureImage.renderer.material.SetTexture("_MainTex", creatureTexture);
			Debug.Log("yep");
		}
		else
		{
			Debug.Log("nope");
		}
		menuEnemyCreatureImage.transform.position = new Vector3(menuEnemyCreatureImage.transform.position.x , 9 , menuEnemyCreatureImage.transform.position.z);
	}
	
	public GameObject getNameOfCreature(int id)
	{
		switch(id)
		{
		case 3:
			
			returncreature = Resources.Load("Creature/Hound") as GameObject;//"haund"; Earth
			
			break;
		case 22:
			
			returncreature = Resources.Load("Creature/barg") as GameObject;//"barg"; Earth
			
			break;
		case 26:
			
			returncreature = Resources.Load("Creature/Cusith") as GameObject;//"Cusith"; Earth
			
			break;
		case 21:
			
			returncreature = Resources.Load("Creature/Sprout") as GameObject;//"Sprout"; Plant
			break;
		case 32:
			
			returncreature = Resources.Load("Creature/Nymph") as GameObject;//"Nymph"; Plant
			break;
		case 41:
			
			returncreature = Resources.Load("Creature/Dryad") as GameObject;//"Dryad"; Plant
			break;
		case 24:
			
			returncreature = Resources.Load("Creature/Nix") as GameObject;//"Nix"; Water
			break;
		case 38:
			
			returncreature = Resources.Load("Creature/Draug") as GameObject;//"Draug"; Water
			break;
		case 50:
			
			returncreature = Resources.Load("Creature/Dagon") as GameObject;//"Dagon"; Water
			break;
		case 209:
			
			returncreature = Resources.Load("Creature/DHound") as GameObject;//"Dhound"; DarkEarth
			break;
		case 224:
			
			returncreature = Resources.Load("Creature/DFenrir") as GameObject;//"DFenrir"; DarkEarth
			break;
		case 237:
			
			returncreature = Resources.Load("Creature/DHellHound") as GameObject;//"DHellHound"; DarkEarth
			break;
		case 215:
			
			returncreature = Resources.Load("Creature/Sprite") as GameObject;//"DSprite"; Fire
			
			break;
		case 225:
			
			returncreature = Resources.Load("Creature/Imp") as GameObject;//"DImp"; Fire
			break;
		case 241:
			
			returncreature = Resources.Load("Creature/Djinn") as GameObject;//"DDjinn"; Fire
			break;
		case 208:
			
			returncreature = Resources.Load("Creature/Leech") as GameObject;//"DLeech"; Swamp
			break;
		case 222:
			
			returncreature = Resources.Load("Creature/Leshy") as GameObject;//"DLeshy"; Swamp
			break;
		case 234:
			
			returncreature = Resources.Load("Creature/Lurker") as GameObject;//"DLurker"; Swamp
			break;
		default:
			break;
		}
		
		return returncreature;	
		
	}
	
	
	public string deleteCreatureName(int id)			// Delete Looser creature
	{
		switch(id)
		{
		case 3:
			
			creature_name ="Hound";//"haund"; Earth
			GameManager.earthTG_Creature_Cnt-=1;
			break;
		case 22:
			
			creature_name = "Barg";//"barg"; Earth
			GameManager.earthTG_Creature_Cnt-=1;
			break;
		case 26:
			
			creature_name = "Cusith";//"Cusith"; Earth
			GameManager.earthTG_Creature_Cnt-=1;
			break;
		case 21:
			
			creature_name = "Sprout";//"Sprout"; Plant
			GameManager.plantTG_Creature_Cnt-=1;
			break;
		case 32:
			
			creature_name = "Nymph";//"Nymph"; Plant
			GameManager.plantTG_Creature_Cnt-=1;
			break;
		case 41:
			
			creature_name = "Dryad";//"Dryad"; Plant
			GameManager.plantTG_Creature_Cnt-=1;
			break;
		case 24:
			
			creature_name = "Nix";//"Nix"; Water
			GameManager.waterTG_Creature_Cnt-=1;
			break;
		case 38:
			
			creature_name = "Draug";//"Draug"; Water
			GameManager.waterTG_Creature_Cnt-=1;
			break;
		case 50:
			
			creature_name = "Dragon";//"Dagon"; Water
			GameManager.waterTG_Creature_Cnt-=1;
			break;
		case 209:
			
			creature_name = "DHound";//"Dhound"; DarkEarth
			GameManager.dEarthTG_Creature_Cnt-=1;
			break;
		case 224:
			
			creature_name = "Fenrir";//"DFenrir"; DarkEarth
			GameManager.dEarthTG_Creature_Cnt-=1;
			break;
		case 237:
			
			creature_name = "HellHound";//"DHellHound"; DarkEarth
			GameManager.dEarthTG_Creature_Cnt-=1;
			break;
		case 215:
			
			creature_name = "Sprite";//"DSprite"; Fire
			GameManager.fireTG_Creature_Cnt-=1;
			break;
		case 225:
			
			creature_name = "Imp";//"DImp"; Fire
			GameManager.fireTG_Creature_Cnt-=1;
			break;
		case 241:
			
			creature_name = "Djinn";//"DDjinn"; Fire
			GameManager.fireTG_Creature_Cnt-=1;
			break;
		case 208:
			
			creature_name = "Leech";//"DLeech"; Swamp
			GameManager.swampTG_Creature_Cnt-=1;
			break;
		case 222:
			
			creature_name = "Leshy";//"DLeshy"; Swamp
			GameManager.swampTG_Creature_Cnt-=1;
			break;
		case 234:
			
			creature_name = "Lurker";//"DLurker"; Swamp
			GameManager.swampTG_Creature_Cnt-=1;
			break;
		default:
			break;
		}
		
		return creature_name;	
		
	}
	
	
	private void AnimatedTG(int creatureID,bool player_c)
	{
		switch(creatureID)
		{
		case 215:
		case 225:
		case 241:
			
			if(player_c)
			{
				P_FireTG.SetActiveRecursively(true);
				
			}
			else
			{
				OppFireTG.SetActiveRecursively(true);
				
			}
			//Activate Fire
			
			break;
			
		case 208:
		case 222:
		case 234:
			
			//swamp
			
			if(player_c)
			{
				P_SwampTG.SetActiveRecursively(true);
				
			}
			else
			{
				OppSwampTG.SetActiveRecursively(true);
				
			}
			
			break;
		
		case 24:
		case 38:
		case 50:
			
			//water
			
			if(player_c)
			{
				P_WaterTG.SetActiveRecursively(true);
				
			}
			else
			{
				OppWaterTG.SetActiveRecursively(true);
				
			}
			
			break;
			
			
		}
		
		
	}
	
	private Material AssignTGtoRespectiveCreature(int Creature)
	{
		
		switch(Creature)
		{
		case 3:
		case 22:
		case 26:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Earth_BattleGround") as Material; // load materia of TG from resources Earth
			
			break;
			
		case 215:
		case 225:
		case 241:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Fire_BattleGround") as Material; // Fire
			
			break;
		
		case 21:
		case 32:
		case 41:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Plant_BattleGround") as Material; // Plant
			
			break;
			
		case 208:
		case 222:
		case 234:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Swamp_BattleGround") as Material; // swamp
			
			break;
			
		case 24:
		case 38:
		case 50:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Water_BattleGround") as Material; // water
			
			break;
			
		case 209:
		case 224:
		case 237:
			
			TGMaterial = Resources.Load("BattleGroundMaterial/Dark_Earth_BattleGround") as Material; // Dark Earth
			
			break;
			
		default:
				
			TGMaterial = null;
			
			break;
			
		}
		
		return TGMaterial;
		
	}
	
	
	private int CreatureFromWhichTrainingGround(int Creature)
	{
		
		switch(Creature)
		{
		case 3:
		case 22:
		case 26:
			
			return 1; // load materia of TG from resources Earth
			
			break;
			
		case 215:
		case 225:
		case 241:
			
			return 6; // Fire
			
			break;
		
		case 21:
		case 32:
		case 41:
			
			return 2; // Plant
			
			break;
			
		case 208:
		case 222:
		case 234:
			
			return 4; // swamp
			
			break;
			
		case 24:
		case 38:
		case 50:
			
			return 3; // water
			
			break;
			
		case 209:
		case 224:
		case 237:
			
			return 5; // Dark Earth
			
			break;
			
		default:
				
			return 0;
			
			break;
			
		}
		
	}
	
	
	private Texture GetCreatureImage(int id)
	{
		Texture theTexture = null;
		switch(id) {
		case 3:
			theTexture = utScript.halflingHound;
			break;
		case 22:
			theTexture = utScript.halflingBarg;
			break;
		case 26:
			theTexture = utScript.halflingCusith;
			break;
		case 21:
			theTexture = utScript.halflingSprout;
			break;
		case 32:
			theTexture = utScript.halflingNymph;
			break;
		case 41:
			theTexture = utScript.halflingDryad;
			break;
		case 24:
			theTexture = utScript.halflingNix;
			break;
		case 38:
			theTexture = utScript.halflingDraug;
			break;
		case 50:
			theTexture = utScript.halflingDagon;
			break;
		case 209:
			theTexture = utScript.darklingHound;
			break;
		case 224:
			theTexture = utScript.darklingFenrir;
			break;
		case 237:
			theTexture = utScript.darklingHellHound;
			break;
		case 215:
			theTexture = utScript.darklingSprite;
			break;
		case 225:
			theTexture = utScript.darklingImp;
			break;
		case 241:
			theTexture = utScript.darklingDjinn;
			break;
		case 208:
			theTexture = utScript.darklingLeech;
			break;
		case 222:
			theTexture = utScript.darklingLeshy;
			break;
		case 234:
			theTexture = utScript.darklingLurker;
			break;
		default:
			break;
		}
		return theTexture;
	}
	
	
	public void PotionImageManager(int id)		// apply potion texture to plane
	{
		Texture2D potionTexture;
		potionTexture = GetPotionImage(id);
		if(potionTexture != null)
		{
			menuPotionImage.renderer.material.SetTexture("_MainTex", potionTexture);
			Debug.Log("yep");
		}
		else
		{
			Debug.Log("nope");
		}
		menuPotionImage.transform.position = new Vector3(menuPotionImage.transform.position.x , 9 , menuPotionImage.transform.position.z);
	}
	
	private Texture2D GetPotionImage(int id)			// return potion Texture
	{
		Texture2D theTexture = null;
		switch(id) {
		case 401:
			theTexture = utScript.potionImage[0];
			Debug.Log(id+" Number Potion");
			break;
		case 402:
			theTexture = utScript.potionImage[1];
			Debug.Log(id+" Number Potion");
			break;
			
		case 403:
			theTexture = utScript.potionImage[2];
			Debug.Log(id+" Number Potion");
			break;
		
		case 404:
			theTexture = utScript.potionImage[3];
			Debug.Log(id+" Number Potion");
			break;
			
		case 405:
			theTexture = utScript.potionImage[4];
			Debug.Log(id+" Number Potion");
			break;
			
		case 406:
			theTexture = utScript.potionImage[5];
			Debug.Log(id+" Number Potion");
			break;
			
		case 407:
			theTexture = utScript.potionImage[6];
			Debug.Log(id+" Number Potion");
			break;
			
		case 408:
			theTexture = utScript.potionImage[7];
			Debug.Log(id+" Number Potion");
			break;
			
		case 409:
			theTexture = utScript.potionImage[8];
			Debug.Log(id+" Number Potion");
			break;
			
		case 410:
			theTexture = utScript.potionImage[9];
			Debug.Log(id+" Number Potion");
			break;
			
		case 411:
			theTexture = utScript.potionImage[10];
			Debug.Log(id+" Number Potion");
			break;
			
		case 412:
			theTexture = utScript.potionImage[11];
			Debug.Log(id+" Number Potion");
			break;
			
		case 413:
			theTexture = utScript.potionImage[12];
			Debug.Log(id+" Number Potion");
			break;
			
		case 414:
			theTexture = utScript.potionImage[13];
			Debug.Log(id+" Number Potion");
			break;
			
		case 415:
			theTexture = utScript.potionImage[14];
			Debug.Log(id+" Number Potion");
			break;
			
		case 416:
			theTexture = utScript.potionImage[15];
			Debug.Log(id+" Number Potion");
			break;
			
		case 417:
			theTexture = utScript.potionImage[16];
			Debug.Log(id+" Number Potion");
			break;
			
		case 418:
			theTexture = utScript.potionImage[17];
			Debug.Log(id+" Number Potion");
			break;
			
		default:
			break;
		}
		return theTexture;
	}
	
	
	private void BetSparksUp()
	{
		if(battleSparksBetAmount == GameManager.sparks)	//tapcou bet amt is 999
			return;
		battleSparksBetAmount++;
		BetAmountTextManager();
	}
	
	private void BetSparksDown()
	{
		if(battleSparksBetAmount < 2)	//min bet amt is 1
			return;
		battleSparksBetAmount--;
		BetAmountTextManager();
	}
	
	private void BetAmountTextManager()
	{
		BetAmountText();
	}
	
	private void BetAmountText()
	{
		SpriteText st = (SpriteText) betAmount.GetComponent<SpriteText>();
		st.Text = battleSparksBetAmount.ToString("000");
	}
	
	private void AcceptLockManager(int whichGame)
	{
		if(whichGame == 1)	//friendly
		{
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleButton"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleButtonActive"), true);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleDeathButtonActive"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleSparkButtonActive"), false);
		}
		else if(whichGame == 2)	//sparks
		{
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleDeathButton"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleButtonActive"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleDeathButtonActive"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleSparkButtonActive"), true);
		}
		else if(whichGame == 3)	//death
		{
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleSparkButton"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleButtonActive"), false);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleDeathButtonActive"), true);
			AcceptLock(GetChild(gameInviteAcceptBasePlate, "BattleSparkButtonActive"), false);
		}
	}
	
	private void AcceptLock(GameObject g, bool lockOption)
	{
		if(g != null)
			g.active = lockOption;
	}
	
	public void UserInfoManager(ISFSObject obj)
	{
		Debug.Log("BGM: \n"+obj.GetDump());
		
		ISFSObject theObj;
		int reqType = obj.GetInt("reqType");
		int size = 0;
		onlineUserListArr = new SFSArray();
		offlineUserListArr = new SFSArray();
		busyUserListArr = new SFSArray();

		if(obj != null)
		{
			
			ISFSArray arr = obj.GetSFSArray("opponentList");
			if(arr != null)
			{
				for(int i=0; i<arr.Size(); i++)
				{
					theObj = arr.GetSFSObject(i);
					if(theObj != null)
					{
						if(theObj.GetInt("online") == 0)
						{
							offlineUserListArr.AddSFSObject(theObj);
						}
						else
						{
							if(theObj.GetInt("battle") == 0)
							{
								if(theObj.GetUtfString("userId") != myUserId)//
									onlineUserListArr.AddSFSObject(theObj);
							}
							else
							{
								busyUserListArr.AddSFSObject(theObj);
							}
						}
					}
					else
						Debug.Log("obj is NULL");
				}
			}
			else
				Debug.Log("arr is NULL");
		}
		else
			Debug.Log("reponse is NULL");
		
		Debug.Log("Online: \n" + onlineUserListArr.GetDump() );
		Debug.Log("Offline: \n" + offlineUserListArr.GetDump() );
		Debug.Log("Busy: \n" + busyUserListArr.GetDump() );
		
//		03.01.2012
		
		
		
	}
	
	
	
	public void NewUserInfoManager(ISFSObject obj)
	{
		Debug.Log("BGM: \n"+obj.GetDump());
		
		string NameOnTheList = null;
		string fightUserId = null;
		ArrayList nameArray = new ArrayList();
		RemovePreviousScrollList();
		ISFSObject theObj;
		ISFSArray arr = null;
		int reqType = obj.GetInt("reqType");
		totalNumberOfPages = obj.GetInt("noOfPages");
		int size = 0;
		int index = 0;
		if(obj != null)
		{
			switch(reqType)
			{
			case 1:	//Online User
				
				
					arr = obj.GetSFSArray("online");
					size = arr.Size();
				
				Debug.Log("SIZE000 "+size );
				break;
				
			case 2:	//Offline User
				
				arr = obj.GetSFSArray("offline");
				size = arr.Size();
				break;
				
			case 3:	//Busy User
				
				arr = obj.GetSFSArray("busy");
				size = arr.Size();
				break;
				
			}
			
			
			scrollGameObject = (GameObject) GameObject.Instantiate(theScrollObject, theScrollObject.transform.position, theScrollObject.transform.rotation);
			theScrollList = (UIScrollList) scrollGameObject.GetComponent<UIScrollList>();
			theScrollList.sceneItems = new GameObject[size];
			
			if(arr != null)
			{
				for(int i=0; i<size; i++)
				{
					if(arr.GetSFSObject(i).GetUtfString("userid") != myUserId)
					{
						index++;
						
						Debug.Log(index);
						
						theObj = arr.GetSFSObject(i);
	
						
						if(theObj.GetUtfString("firstName") == "")
						{
							NameOnTheList = theObj.GetUtfString("userid");
							fightUserId = theObj.GetUtfString("userid");
						}
						else
						{
							
							NameOnTheList = theObj.GetUtfString("firstName")+" "+theObj.GetUtfString("lastName");
							fightUserId = theObj.GetUtfString("userid");
						}
						
						Debug.Log(theObj.GetUtfString("firstName"));
						
						if(i%2 == 0)
							theScrollList.sceneItems[i] = NewGetGameObject(listOne, index, NameOnTheList,theObj.GetInt("xp"),fightUserId);
						else
							theScrollList.sceneItems[i] = NewGetGameObject(listTwo, index, NameOnTheList,theObj.GetInt("xp"),fightUserId);
					
					}
				}
				
				
//				for(int i = 0;i<nameArray.Count;i++)
//				{
//					
//					if(i%2 == 0)
//							theScrollList.sceneItems[i] = NewGetGameObject(listOne, i, nameArray[i].ToString());
//						else
//							theScrollList.sceneItems[i] = NewGetGameObject(listTwo, i, nameArray[i].ToString());
//					
//				}
				
			}
			
			else
				Debug.Log("arr is NULL");
		}
		else
			Debug.Log("reponse is NULL");

		
		
		
	}
	
	
	
	
	private void SendFightRequset(string opponentId)			// Send Fight Request with all parameters
	{
		Debug.Log("opponentId: "+opponentId);
		if(battleGameType!=0)
		{
			sfsrScript.SendFightRequest("5", 23, opponentId, battleCreatureId, battleObeliskId, battleGameType, battleSparksBetAmount);
		}
	}
	
	public void FightRequestReceived(ISFSObject obj)			// Fight Requst Data from Server
	{
		if(PlayerPrefs.GetInt("isBattleFirstTime") == 2)
		{
			if(obj != null)
			{
			
				battleType = obj.GetInt("battleType");
				opponentId = obj.GetUtfString("userId");
				battleId = obj.GetInt("battleId");
				sparksInvitation = obj.GetInt("sparks");
				opponentBattleCreatureId = obj.GetInt("user1CretureId");
				
				Debug.Log(obj.GetUtfString("userId"));
				if(obj.GetUtfString("userId").ToString() != myUserId)
				{
					battleRequestReceived = true;
					
					Debug.Log("Its Not You");
				}
				else {
					
					Debug.Log("Its You");
					
				}
				
					Debug.Log("Battle Type --"+obj.GetInt("battleType"));
				
				BattleScreenCollider(true);
			}
		}
		else
		{
			Debug.Log("First complete battle tutorial... " + PlayerPrefs.GetInt("isBattleFirstTime"));
		}
	}
	
	public void StartAnimationFight()			// Starting Fight Animation
	{
		
		GameObject plate = GameObject.Find("BattleGroundObject");
		plate.SetActiveRecursively(true);
		
		//BattleScreenCollider(true);
		
		
	}
	
	public void StopAnimationFight()				// Stop FIght
	{
		
		GameObject plate = GameObject.Find("BattleGroundObject");
		plate.SetActiveRecursively(false);
	}
	
	public void getFightDuration(int duration)
	{
		
		sec = duration + Mathf.FloorToInt(Time.time);
		
		Debug.Log("Battle Duration is "+duration);
	}
	
	private void StartFight()							// Method Call for Start Fight
	{
		Resources.UnloadUnusedAssets();
		
		Debug.Log("Hey its your opponent ID "+opponentId);
		TimeOutFight = false;
		Debug.Log("StartFight Method calling----");
		sfsrScript.StartFightRequest(battleId,potionId,opponentId);
		curState = state.animationScene;
		BasePlateActivationManager();
		
		BattleScreenCollider(true);
	}
	
	
	public void PopupMessage(string Message)
	{
		BattlePopUpTapCount.SetActiveRecursively(true);
		battleTapMessage.Text = Message;
	}
	
	public void ShowBubbleMessage(string Message)				// Creature Power PopUps
	{
		
		Invoke("ShowCreaturePower",5f);
		Invoke("StopCreaturePower",25f);
		BattlePopUpTapCount.SetActiveRecursively(true);
		battleTapMessage.Text = Message;
		
	}
	
	void BattleMessageClose()
	{
		
		BattlePopUpTapCount.SetActiveRecursively(false);
		
	}
	
	void ShowCreaturePower()					//Creature Power
	{
		//trainingGroundPower = true;
		BattlePopUpTapCount.SetActiveRecursively(false);
		//TappingGroup.enableTappingButtons = true;
		//GetComponent<TappingGroup>().Activate();
		
	}
	
	void StopCreaturePower()
	{
		
		TapManagerHandler();
		TappingGroup.enableTappingButtons = false;
		
		
	}
	
	
	public void getFightPotionList(ISFSObject obj)				//Fight Potion List
	{
		potDic = new Dictionary<int, int>();
		potionOjectId = new Dictionary<int, int>();
		
///***		Debug.Log("You have this much potion");
		ISFSArray arr = null;
		int size = 0;
///***		Debug.Log(obj.GetDump());
		

		arr = obj.GetSFSArray("potionList");
		size = arr.Count;
		ISFSObject sfsObjPotionList;
		
			for(int i=0;i<size;i++)
			{
				sfsObjPotionList = arr.GetSFSObject(i);
				potDic.Add(i,sfsObjPotionList.GetInt("object_type_id"));
				potionOjectId.Add(sfsObjPotionList.GetInt("object_type_id"),sfsObjPotionList.GetInt("object_id"));
			}
			
			//Debug.Log("Potion Dictonary Log " +potionOjectId[401]);
		
		
	}
	
	private void AcceptJoinButton()					// Accepting to join Fight
	{
		if(battleCreatureId != 0)
		{
			 SendAcceptFightRequest();
		}
	}
	
	private void SendAcceptFightRequest()
	{
		//call sfsremote script
		//SendFightAcceptRequest -- line no 642
		sfsrScript.SendFightAcceptRequest("5",24,opponentId,battleCreatureId,battleObeliskId,battleId);
		
		//sfsrScript.SendFightAcceptRequest("5",24,opponentId,opponentBattleCreatureId,battleObeliskId,battleId);
	}
	
	public void SetOtherGUIComponentOff()
	{
		TransformOtherGUIOutOfTheScreen();
		InventoryItem.SetActiveRecursively(false);
		MainMenuUI.SetActiveRecursively(false);
		DayNightSystem.SetActiveRecursively(false);
		
	}
	
	
	private void TransformOtherGUIOutOfTheScreen()
	{
		//AchievementsIcon.transform.localPosition = new Vector3(-86.27844f,10f,123.7192f);
		HUDObj.transform.localPosition = new Vector3(-49.78344f,8f,40f);
		
		
	}
	
	private void TransformBackGUIComponent()
	{
		//AchievementsIcon.transform.localPosition = new Vector3(-76.27844f,10f,123.7192f);
		HUDObj.transform.localPosition = new Vector3(-49.78344f,8f,29f);
		
	}
	
	private void DeleteLooserCreature(string creatureName)
	{
		
		Destroy(GameObject.FindGameObjectWithTag(creatureName));
		
	}
	
	
	public void BattleWinnerResult(ISFSObject obj)			//Battle Win Result
	{
		
		GetComponent<BattleGroundPlayer>().ResetPlayerData();
		//ExtraPowerBackPanel.SetActiveRecursively(false);
		trainingGroundPower = false;
		DestroyCreaturesAfterFight();
		BattleMessageAfterWin.SetActiveRecursively(true);
		
		Debug.Log("My User ID---"+myUserId+"  ----"+obj.GetInt("loserCreatureTypeId"));

		
		if(myUserId.Equals(obj.GetUtfString("winnerUserId")))
		{
			string msg = "Congratulations !!!\nYou have won the battle\n";
			MessageAfterBattleWin(msg,obj.GetDouble("xpWin"),obj.GetDouble("goldWin"),obj.GetDouble("sparksWin"));
			
			Debug.Log("Congrats--");
			
			 			ad.wonfightcount = PlayerPrefs.GetInt("wonfight");
			 			PlayerPrefs.SetInt("wonfight",(ad.wonfightcount+1));

			 			Debug.Log("wonfight count :"+PlayerPrefs.GetInt("wonfight"));
			 			ad.percentComplete9 = 100*PlayerPrefs.GetInt("wonfight");
			 			ad.percentComplete15 = 10*PlayerPrefs.GetInt("wonfight");
			 			ad.percentComplete22 = 4*PlayerPrefs.GetInt("wonfight");
			 			ad.percentComplete35 = 2*PlayerPrefs.GetInt("wonfight");
			 			ad.percentComplete44 = 1*PlayerPrefs.GetInt("wonfight");
			
			 			ad.totalfightcount = PlayerPrefs.GetInt("totalfight");
			 			PlayerPrefs.SetInt("totalfight",(ad.totalfightcount+1));

			 			Debug.Log("totalfight count :"+PlayerPrefs.GetInt("totalfight"));
			 			ad.percentComplete48 =1*PlayerPrefs.GetInt("totalfight");
			
			
		}
		else if(myUserId.Equals(obj.GetUtfString("loserUserId")))
		{
			string msg1 = "Sorry !!!\nYou have lost the battle\n";
			
			DeleteLooserCreature(deleteCreatureName(obj.GetInt("loserCreatureTypeId")));
			MessageAfterbattleLose(msg1,obj.GetDouble("loserXpWin"),obj.GetDouble("sparksWin"));
			
			Debug.Log("Opps---");
			 			ad.totalfightcount = PlayerPrefs.GetInt("totalfight");
			 			PlayerPrefs.SetInt("totalfight",(ad.totalfightcount+1));

			 			Debug.Log("totalfight count :"+PlayerPrefs.GetInt("totalfight"));
			 			ad.percentComplete48 = 1*PlayerPrefs.GetInt("totalfight");
			
		}
		
		
		
	}
	
	
	
	//---------------------------Set PotionId ---------------------------------//
	
	void setSlugTonicPotion()			//Object Type id - 401
	{
		
		potionId = potionOjectId[401];
		PotionImageManager(401);
		iItemsScript.inventoryClose();
	}
	
	void setPoppySnapPotion()			//Object Type id - 402
	{
		
		potionId = potionOjectId[402];
		PotionImageManager(402);
		iItemsScript.inventoryClose();
	}
	
	void setFeverPitchPotion()			//Object Type id - 403
	{
		
		potionId = potionOjectId[403];
		PotionImageManager(403);
		iItemsScript.inventoryClose();
	}
	
	void setBitterRootPotion()			//Object Type id - 404
	{
		
		potionId = potionOjectId[404];
		PotionImageManager(404);
		iItemsScript.inventoryClose();
	}
	
	void setMorrowDraughtPotion()		//Object Type id - 405
	{
		
		potionId = potionOjectId[405];
		PotionImageManager(405);
		iItemsScript.inventoryClose();
	}
	
	void setVetchSprayPotion()			//Object Type id - 406
	{
		
		potionId = potionOjectId[406];
		PotionImageManager(406);
		iItemsScript.inventoryClose();
	}
	
	void setBoggleHomPotion()			//Object Type id - 407
	{
		
		potionId = potionOjectId[407];
		PotionImageManager(407);
		iItemsScript.inventoryClose();
	}
	
	void setSpleenBitePotion()				//Object Type id - 408
	{
		
		potionId = potionOjectId[408];
		PotionImageManager(408);
		iItemsScript.inventoryClose();
	}
	
	void setMossSalvePotion()			//Object Type id - 409
	{
		
		potionId = potionOjectId[409];
		PotionImageManager(409);
		iItemsScript.inventoryClose();
	}
	
	void setSeaWhipPotion()				//Object Type id - 410
	{
		
		potionId = potionOjectId[410];
		PotionImageManager(410);
		iItemsScript.inventoryClose();
	}
	
	void setMonkBloodPotion()			//Object Type id - 411
	{
		
		potionId = potionOjectId[411];
		PotionImageManager(411);
		iItemsScript.inventoryClose();
	}
	
	void setScorchEllixirPotion()		//Object Type id - 412
	{
		
		potionId = potionOjectId[412];
		PotionImageManager(412);
		iItemsScript.inventoryClose();
	}
	
	void setWolfTonguePotion()			//Object Type id - 413
	{
		
		potionId = potionOjectId[413];
		PotionImageManager(413);
		iItemsScript.inventoryClose();
	}
	
	void setGrubSproutPotion()			//Object Type id - 414
	{
		
		potionId = potionOjectId[414];
		PotionImageManager(414);
		iItemsScript.inventoryClose();
	}
	
	void setDwaleBilePotion()			//Object Type id - 415
	{
		
		potionId = potionOjectId[415];
		PotionImageManager(415);
		iItemsScript.inventoryClose();
	}
	
	void setNecrobanePotion()			//Object Type id - 416
	{
		
		potionId = potionOjectId[416];
		PotionImageManager(416);
		iItemsScript.inventoryClose();
	}
	
	void setDevilIchorPotion()			//Object Type id - 417
	{
		
		potionId = potionOjectId[417];
		PotionImageManager(417);
		iItemsScript.inventoryClose();
	}
	
	void setStunkMangePotion()			////Object Type id - 418
	{
		
		potionId = potionOjectId[418];
		PotionImageManager(418);
		iItemsScript.inventoryClose();
	}
	
	
	
	//-------------------------------END---------------------------------------//
	
	
	//------------------------------REWARD SYSTEM----------------------------//
	
	
	void BloodstoneTrinket()
	{
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_bloodstone_trinket") as Texture2D;
		
	}
	void BloodstoneMedallion()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_bloodstone_Medallion") as Texture2D;
		
	}
	
	void BloodstoneAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_bloodstone_amulet") as Texture2D;
		
	}
	
	void emeraldTrinket()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_emerald_trinket") as Texture2D;
	}
	
	void emeraldMedallion()
	{
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_emerald_Medallion") as Texture2D;
		
	}
	
	void emeraldAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_emerald_amulet") as Texture2D;
	}
	
	void sapphireTrinket()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_sapphire_trinket") as Texture2D;
		
	}
	
	void sapphireMedallion()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_sapphire_Medallion") as Texture2D;
		
	}
	
	void sapphireAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/HW_sapphire_amulet") as Texture2D;
		
	}
	
	void amethystTrinket()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_amethyst_trinket") as Texture2D;
		
	}
	
	void amethystMedallion()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_amethyst_Medallion") as Texture2D;
		
	}
	
	void amethystAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_amethyst_amulet") as Texture2D;
		
	}
	
	void rubyTrinket()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_ruby_trinket") as Texture2D;
		
	}
	
	void rubyMedallion()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_ruby_Medallion") as Texture2D;
		
	}
	
	void rubyAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_ruby_amulet") as Texture2D;
		
	}
	
	void onyxTrinket()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_onyx_trinket") as Texture2D;
		
	}
	
	void onyxMedallion()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_onyx_Medallion") as Texture2D;
		
	}
	
	void onyxAmulet()
	{
		
		rewardSelectionImage.renderer.material.mainTexture = Resources.Load("Rewards_Cards/DL_onyx_amulet") as Texture2D;
		
	}
	
	
	
	
	//---------------------------------END-------------------------------------//
	
	private void TapManagerHandler()
	{
		
		sfsrScript.setExtraPower(tapCount,battleId);
		
		Debug.Log("Tap Count Sent "+tapCount);
		
		
		
	}
	
	
	private void BattleTapToWin(GameObject g,GameObject atap)
	{
		Debug.Log("tapping "+tapCount );

		g.SetActiveRecursively(true);
		tapCount+=10;
		atap.SetActiveRecursively(false);
		StartCoroutine(DeactivateGreenBubbules(g));
	}
	
	IEnumerator DeactivateGreenBubbules(GameObject go)
	{
		Debug.Log(go.name+" Getting False");
		yield return new WaitForSeconds(2f);
		go.SetActiveRecursively(false);
		
	}
	
	private void BattleTapToWinButton1()
	{
		totalTap+=1;
		BattleTapToWin(tap1,atap1);
		AllBubbleTapped();
	}
	private void BattleTapToWinButton2()
	{
		totalTap+=1;
		BattleTapToWin(tap2,atap2);
		AllBubbleTapped();
	}
	private void BattleTapToWinButton3()
	{
		totalTap+=1;
		BattleTapToWin(tap3,atap3);
		AllBubbleTapped();
	}
	private void BattleTapToWinButton4()
	{
		totalTap+=1;
		BattleTapToWin(tap4,atap4);
		AllBubbleTapped();
	}
	
	public void AllBubbleTapped()
	{
//		if(totalTap == 3)	//if(tutorialEffects)						// Only for Tutorial
//		{
//			ExtraPowerTap();
//			ExtraPowerParticalEffect(1);
//			tutorialEffects = false;
//			
//			totalTap = 0;
//			Debug.Log("BLAST--------BLAST");
//		}
		if(totalTap == howMany)
		{
			ExtraPowerParticalEffect(powerID);
			ExtraPowerTap();
			
			Debug.Log("BLAST--------BLAST------HUNT "+powerID);
		}
		
		Debug.Log("Totap Tap Count..."+totalTap+"  Tap Generated"+howMany);
	}
	
	private void ExtraPowerTap()
	{
		
		GetComponent<BattleGroundPlayer>().BringPlayertoCenter();
		
	}
	
	
	private void ExtraPowerParticalEffect(int TGName)
	{
		switch(TGName)	
		{
			
		case 1:				//1 - earth
		
			
			tempPart = Resources.Load("ParticalEffects/GroundHit01") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
		
		case 2:			//2 - plant
		
			tempPart = Resources.Load("ParticalEffects/Battle_PlantCreatures") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
			
		case 3:			//3 - water
		
			tempPart = Resources.Load("ParticalEffects/Battle_WaterCreatures") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
			
		case 4:			// 4 - swamp
		
			tempPart = Resources.Load("ParticalEffects/Battle_SwampCratures") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
			
		case 5:			//Dark earth
		
			tempPart = Resources.Load("ParticalEffects/Battle_DarkEarthCreatures") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
			
		case 6:			//fire
		
			tempPart = Resources.Load("ParticalEffects/Battle_FireCreatures") as GameObject;
			InstantiateParticalSystem(tempPart);
			
			break;
			
		}
		
	}
	
	
	private void InstantiateParticalSystem(GameObject particalSys)
	{
		
		GameObject part = Instantiate(particalSys) as GameObject;
		part.transform.localPosition = new Vector3(431.09f,1f,3f);
		if(part.name == "Battle_PlantCreatures(Clone)")
		{
			part.transform.localRotation = Quaternion.Euler(0,90,0);
		}
		else
		{
		part.transform.localRotation = Quaternion.Euler(0,0,0);
		}
		
	}
	
	
	private void DisableAnimatedTG()
	{
		
		OppFireTG.SetActiveRecursively(false);
		P_FireTG.SetActiveRecursively(false);
		OppSwampTG.SetActiveRecursively(false);
		OppWaterTG.SetActiveRecursively(false);
		P_SwampTG.SetActiveRecursively(false);
		P_WaterTG.SetActiveRecursively(false);
		
	}
	
	
	
	//--------------------------Fighting System Tutorial---------------------------------//
	
	public void StartTutorial(int place)
	{
		
		Debug.Log("Player Pref----"+PlayerPrefs.GetInt("isBattleFirstTime"));
		
		if(PlayerPrefs.GetInt("isBattleFirstTime")!=1)
		{
			place = 100;
		}
		else
		{
			
			arrow = Instantiate(arrowHand) as GameObject;
			bringAnimator();
		}
		
		switch(place)
		{
		case 0:				//Invite Prepare Select Creature	
			
			tutorialEffects = true;
			arrow.transform.localPosition = new Vector3(-59.23477f,10,116.14f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "Hi,Welcome to Battle Tutorial In order to Start Click \"Select Creature\"..";
			InviteBattleType.SetActiveRecursively(true);
			break;
			
		case 1:				//Invite Prepare Crature Selection Screen
			
			arrow.transform.localPosition = new Vector3(-73.27695f,13,121.8132f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "Select the Hound from the creature menu";
			InviteBattleType.SetActiveRecursively(false);
			blockDarkling.SetActiveRecursively(true);
			Invoke("NewMessageAboutCreature",2f);
			break;
			
		case 2:				//Invite Battle Type Screen Screen
			
			TransformAnimator();
			arrow.transform.localPosition = new Vector3(-59.23477f,13,98.34f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "For now, select just a standard battle";
			blockDarkling.SetActiveRecursively(false);
			InviteBattleType_2.SetActiveRecursively(true);
			break;
			
		case 3:				//Invite Prepare Host Button
			
			arrow.transform.localPosition = new Vector3(-39.7f,13,89.5f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "Lets start with\nhosting tutorial fight.";
			InviteBattleType_2.SetActiveRecursively(false);
			InviteBattleTypeHost.SetActiveRecursively(true);
			break;
			
		case 4:				//Select Friends From List
			
			arrow.transform.localPosition = new Vector3(-39.7f,13,119.5f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "For now invitation\nhas been sent to CPU user";
			InviteBattleTypeHost.SetActiveRecursively(false);
			FriendsBlock.SetActiveRecursively(true);
			Invoke("WaitAndShowMessage",3f);
			break;
			
		case 5:				//Select Potion Button
			
			arrow.transform.localPosition = new Vector3(-60.7f,13,96.07f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "Potions, special herbs, magical relics...you will soon become a master of your creatures magic. For now, use this potion I created";
			busyScreenCollider.SetActiveRecursively(true);
			startBattleCollider.SetActiveRecursively(true);
			Invoke("DummysetPoppySnapPotion",5f);
			break;
		
		case 6:				//Select Potion From List
			
			arrow.transform.localPosition = new Vector3(-73.6f,12,120.3f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "you have potion to select....";
			
			break;
			
		case 7:				//Start Fight
			
			selectPotion.SetActiveRecursively(true);
			TransformAnimatorBack();
			arrow.transform.localPosition = new Vector3(-39.9f,13,91.1f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "Let the battle begin...";
			break;
			
		case 8:				//Creature Power
			
			TransformAnimator();
			arrow.transform.localPosition = new Vector3(-44.9f,12,109.5f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "";
			
			Invoke("HelpHandDestroy",5f);
			
			break;
			
		case 9:				//Creature Power
			
			
			arrow.transform.localPosition = new Vector3(-41.1f,18,102.6f);
			arrow.transform.localRotation = Quaternion.Euler(-90f,0,0);
			textToSpeak = "";
			break;
			
		
		}
		
		if(PlayerPrefs.GetInt("isBattleFirstTime") == 1)
		{
			arrow.transform.localScale = new Vector3(0.3f,0.3f,0.2f);
			arrow.layer = 8;
			GameObject child = arrow.transform.FindChild("Arrow").gameObject;
			child.layer = 8;
			write.GetComponent<AutoSpeak>().callToWriteText(textToSpeak);
		}
		
		
	}
	
	private void HelpHandDestroy()
	{
		
		DestroyHandGameObject();
		
	}
	
	private void DestroyHandGameObject()
	{
		
		
		if(arrow!=null)
		{
			Destroy(arrow);
			
		}
	}
	
	private void CheckForDestroyHandGameObject()
	{
		
		if(battleGameType==1 | battleGameType==2 | battleGameType==3)
		{
			DestroyHandGameObject();
			
		}
		
		StartTutorial(3);
		
	}
	
	
	private void NewMessageAboutCreature()
	{
		textToSpeak = "Remember, this is just a training exercise. Later, you will be able to choose to wager your precious sparks, or even fight to the death";
		write.GetComponent<AutoSpeak>().callToWriteText(textToSpeak);
	}
	
	public void MessageSpeak(int id)
	{
		
		switch(id)
		{
		case 1:
			
		textToSpeak = "Yes...Your request has been accepted..";
		break;
			
		case 2:
			
		textToSpeak = "fight started...";
		
			break;
			
		case 3:
			
		textToSpeak = "Congratulations...You have completed battle tutorial...";
		
		busyScreenCollider.SetActiveRecursively(false);
			break;
			
		case 4:
			
		textToSpeak = "Yes..I can feel its power emanating Every creature has a special attack. Watch closely for the right moment";
			
			break;
			
		case 5:
			
			textToSpeak = "Potions, special herbs, magical relics...you will soon become a master of your creatures magic.For now, use this potion I created";
			busyScreenCollider.SetActiveRecursively(true);
			startBattleCollider.SetActiveRecursively(true);
			Invoke("DummysetPoppySnapPotion",5f);
			
			break;
			
		case 6:
			
			textToSpeak = "Congratulations!!!\nyou have unlocked the battle..";
			
			break;
		}
		
		write.GetComponent<AutoSpeak>().callToWriteText(textToSpeak);
	}
	
	private void WaitAndShowMessage()
	{
		dummyBattleAcceptPopup.SetActiveRecursively(true);
		tutorialFightAccepted.Text = "CPU\nresponded to your request..";
		FriendsBlock.SetActiveRecursively(false);
		DestroyHandGameObject();
		
		StartTutorial(9);
		MessageSpeak(1);
			
	}
	
	private void PromptUserForBubbleTap()
	{
		MessageSpeak(4);
		
		
	}
	
	private void ActivateDummyJoinScreen()
	{
		DestroyHandGameObject();
		closeUIOpen();
		dummyBattleAcceptPopup.SetActiveRecursively(false);
		curState = state.tutorial;
		DummyJoinScreen.SetActiveRecursively(true);
		sec = 20 + Mathf.FloorToInt(Time.time);
		//StartTutorial(5);
		
		MessageSpeak(5);
		
	}
	
	
//	private void SelectDummyPotion()
//	{
//		DestroyHandGameObject();
//		DummyPotionSelect.SetActiveRecursively(true);
//		StartTutorial(6);
//	}
	
	private void SelectDummyStart()
	{
		DestroyHandGameObject();
		
		DummyJoinScreen.SetActiveRecursively(false);
		BattleGroundObj.SetActiveRecursively(true);
		BattlePlateObj.SetActiveRecursively(true);
		
		MessageSpeak(2);
		selectPotion.SetActiveRecursively(false);
		
		GameObject tempPlayer = Instantiate(getNameOfCreature(3)) as GameObject;
		GameObject tempOpp = Instantiate(getNameOfCreature(209)) as GameObject;
		
		GetComponent<BattleGroundPlayer>().my_Player = tempPlayer;  		
		GetComponent<BattleGroundPlayer>().opp_Player = tempOpp;
		
		GetComponent<BattleGroundPlayer>().CustomStart();
		
		
		tempPlayer.transform.localPosition = new Vector3(431.2361f,-2.232596f,2.983105f);
		tempOpp.transform.localPosition = new Vector3(440.6386f,-2.232596f,2.983105f);
		tempOpp.transform.localScale = new Vector3(1,1,1);
		
		TutorialGUIComponentOff();
		
		Invoke("PromptUserForBubbleTap",3f);
		Invoke("DisplayTutorialGroundPower",5f);
		Invoke("CallAfterTutorialEnds",20f);
		curState = state.tutorialCountDown;
		sec = 20 + Mathf.FloorToInt(Time.time);
		
	}
	
	void DummysetPoppySnapPotion()			//Object Type id - 402
	{
		Debug.Log("Set Dummy Potion From List");
		DestroyHandGameObject();
		startBattleCollider.SetActiveRecursively(false);
		DummyPotionImage.renderer.material.mainTexture = utScript.potionImage[1];
		//DummyPotionSelect.SetActiveRecursively(false);
		StartTutorial(7);
	}
	
	public void TutorialGUIComponentOff()
	{
		TransformOtherGUIOutOfTheScreen();
		InventoryItem.SetActiveRecursively(false);
		MainMenuUI.SetActiveRecursively(false);
		//DayNightSystem.SetActiveRecursively(false);
		
	}
	
	public void TutorialGUIComponentOn()
	{
		TransformBackGUIComponent();
		InventoryItem.SetActiveRecursively(true);
		MainMenuUI.SetActiveRecursively(true);
		//DayNightSystem.SetActiveRecursively(false);
		tutorialTrainingGroundPower = false;
		//ExtraPowerBackPanel.SetActiveRecursively(false);
	}
	
	
	void DisplayTutorialGroundPower()
	{
		//StartTutorial(8);
		GetComponent<BattleGroundPlayer>().enableTutorialEffect = true;
	}
	
	
	void TransformAnimator()
	{
		
		
		animator.transform.localPosition = new Vector3(-22.8f,19.22f,85f);
		animator.transform.localScale = new Vector3(-2.89f,0.64f,1f);
		animatorText.transform.localPosition = new Vector3(-35.7f,19.22f,88.71f);
		
	}
	
	void TransformAnimatorBack()
	{
		
		GameObject animator = GameObject.Find("Bubble");
		GameObject animatorText = GameObject.Find("SpeakText");
		animator.transform.localPosition = new Vector3(-56.82189f,19.22f,85.7f);
		animator.transform.localScale = new Vector3(2.89f,0.64f,1f);
		animatorText.transform.localPosition = new Vector3(-66.5265f,19.22f,88.71f);
		
	}
	
	void EndBattleTutorial()
	{
		Destroy(GameObject.Find("Hound(Clone)"));
		Destroy(GameObject.Find("DHound(Clone)"));
		BattleGroundObj.SetActiveRecursively(false);
		BattlePlateObj.SetActiveRecursively(false);
		TransformAnimatorBack();
		Invoke("tutorialEndHideCharacter",3.5f);
		PlayerPrefs.SetInt("isBattleFirstTime",2);
		DestroyHandGameObject();
		
		GameManager.popUpCount = 35;
		scr_popUpInformation.curPopUpCnt = 35;
		scr_popUpInformation.curPopUpType = 0;
		scr_popUpInformation.generatePopUp(scr_popUpInformation.curPopUpCnt, scr_popUpInformation.curPopUpType);
		
		GameObject congParticle = Instantiate(gameManager.par_Congratulation_PF, new Vector3(-39.45f, 38.75f, 121.5f), Quaternion.Euler(0, 180, 360)) as GameObject;
		congParticle.GetComponent<ParticleSystem>().Play();
		congParticle.transform.FindChild("Congratulations_Conf03").gameObject.GetComponent<ParticleSystem>().Play();
		congParticle.transform.FindChild("Congratulations_Conf02").gameObject.GetComponent<ParticleSystem>().Play();
	}
	
	void CallAfterTutorialEnds()
	{
		
		TutorialGUIComponentOn();			//tutorial
		EndBattleTutorial();
		MessageSpeak(3);
		GetComponent<BattleGroundPlayer>().ResetPlayerData();
		Debug.Log("End tutorial");
		
		if(tap1.active == true)
			tap1.SetActiveRecursively(false);
		if(tap2.active == true)
			tap2.SetActiveRecursively(false);
		if(tap3.active == true)
			tap3.SetActiveRecursively(false);
		if(tap4.active == true)
			tap4.SetActiveRecursively(false);
		
		if(atap1.active == true)
			atap1.SetActiveRecursively(false);
		if(atap2.active == true)
			atap2.SetActiveRecursively(false);
		if(atap3.active == true)
			atap3.SetActiveRecursively(false);
		if(atap4.active == true)
			atap4.SetActiveRecursively(false);
	}
	
	
	void TransformChachaTomainScreen()
	{
		GameObject chacha = GameObject.Find("Bubble");
		chacha.transform.localPosition = Vector3.Lerp(new Vector3(-92.82f,19.22f,85f),new Vector3(-55.2f,19.22f,85f),0.2f);
		
	}
	
	void bringAnimator()
	{

		animator.SetActiveRecursively(true);
		animatorText.SetActiveRecursively(true);
		
	}
	
	void tutorialEndHideCharacter()
	{
		Debug.Log("Player Pref----"+PlayerPrefs.GetInt("isBattleFirstTime"));
		animator.SetActiveRecursively(false);
		animatorText.SetActiveRecursively(false);
		
	}
	
	
	//--------------------Tutorial End--------------------------------------------------//
	
	
	
}
