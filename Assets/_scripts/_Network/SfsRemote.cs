using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;
using System;
using System.Runtime;
using System.Collections.Generic;



public class SfsRemote : MonoBehaviour {

	public class ObjectTimes
	{
		public int Id;
		public int TypeId;
		public long tym;
		public string taskId;
		public int creationTym;
		public int ParentObjectId;
	}
	
	public class QuestInfo
	{
		//public string taskId;
		public int questNo;
	}
	
	public class ObjectConstructionTimes
	{
		public int typeId;
		public int constructionTym;
	}
	
	public class GameObjectsDB
	{
		public double spark_cost;
	    public double cost_gold_total;
	    public double xp_earned;
	    public double cost_gold_base;
	    public string  ObjectTypeName;
	    public int ObjectTypeId;

	}
	
	
	public class SvrObjects
	{
		public int typeId;
		public int level;
		public int objId;
		public int currntFeed; 
		public int feedLevel;
		public Vector3 position;
	}
	
	public class SvrUserPurchases
	{
		public int typeId;
		public int Upid;
	}
	
	public class ChildObjects
	{
		public int Cnt;
		public int objId;
	}
	
	public class HerbObjects
	{
		public string ObjectName;
		public int ObjectId;
		public int ObjectTypeId;
	}
	
	public class CreatureObjects
	{
		public double sparkcost;
		public	int morphCreatureId;
		public	int objectTypeId;
	}
	
	public class LevelXpinfo
	{
		public int levelXp;
		public int currentLevel;
	}
	
	public class MiniGametimes
	{
		public int timetoOpen;
		public string taskId;
	}
	
	public class OrcAttackTasks
	{
		public long task_end_time;
	    public int caveId;
		public int attackedObjId;
		public int attackedTypedId;
	    public string attackTaskId;
	    public int creationTime;
		public int caveorObj;
		public int caveTypeId;
	}
	
	public class DefenseTasks
	{
		public int object_type_id;
		public int obeliskId;
		//public long taskEndTime;
		public double taskEndTime;
	}
	
	public class QuestTasks
	{
		public int level;
		public string taskHeading;
		public string taskDetail;
		public int hd;
	}
	
	public class StoryTasks
	{
		public int status;
		public int triggerNo;
		public int triggerDetails;
	}
	private int noOfStoriesUnlocked;
	
	public LoadUserWorld scr_userworld;
	public GameObjectsSvr scr_Gameobjsvr;
	public LevelControl scr_LevelControl;
	public GameManager scr_Gamemanager;
	private OrcAttackSystem scr_OrcAttackSystem;
	
	public bool isUserWorld,isAssignTasks;
	private bool runOnlyOnce = true;
	public bool isgetOrgtym = false;
	public bool isGetObjectTime;
	
	//Variable declaration
	//public string ServerIp = "23.23.224.92";
	//public string ServerIp ;//= "23.23.224.92";
	
	public string ServerIp = "208.87.122.199";
	public int ServerPort = 9933;
	//public string Zone = "BasicExamples";
	public string Zone; // =  "HFWar" ;  //"HFWar";
	public string RoomName = "The Lobby";
	public string userIdforLogin = "";
	
	public bool IsConnectedToSrv = false;
	public SmartFox sfs;
	popUpInformation scr_popUpinfo;
	CreatureSystem scr_creatureSystem;
	taskDetails scr_taskDetails;
	objectCost scr_objectCost;
	
	public guiControl scr_GuiControl;
	private bool isGetFarmObjId;
	
	public GUIStyle _guistyle;
	
	public string messg;
	
	public List<ObjectTimes> lst_times = new List<ObjectTimes>();
	public List<QuestInfo> lst_questInfo = new List<QuestInfo>();
	public List<SvrObjects> lst_ObjSvr = new List<SvrObjects>();
	public List<SvrUserPurchases> lst_UserPurchasesSvr = new List<SvrUserPurchases>();
	public List<ChildObjects> lst_ChildObjects = new List<ChildObjects>();
	public List<HerbObjects> lst_HerbObjects = new List<HerbObjects>();
	public List<GameObjectsDB> lst_GameObjectsDb = new List<GameObjectsDB>();
	public List<CreatureObjects> lst_CreatureObjectsDb = new List<CreatureObjects>();
	public List<LevelXpinfo> lst_LevelXpInfo = new List<LevelXpinfo>();
	public List<MiniGametimes> lst_miniGametimeInfo = new List<MiniGametimes>();
	public List<OrcAttackTasks> lst_OrgAttackTasks = new List<OrcAttackTasks>();
	public List<DefenseTasks> lst_DefenseTasks = new List<DefenseTasks>();
	public List<QuestTasks> lst_QuestTasks = new List<QuestTasks>();
	public List<StoryTasks> lst_StoryTasks = new List<StoryTasks>();
	
	public int PercentageCalc;
	private int transitiontime;
	public 	string elapsedtime;
    public	string state;
	public bool IsSmokePipeweed;
	public bool tavernGameactive,potionGameactive;
	public bool miniGameload;
	public bool isIdleCounttimer;
	private float getOrgattacktym;
	public float getObjTime1, getObjTime2;
	public int getObjId1, getObjId2;
	
	private bool resetBool = true;
	
	public GameObject dial;
	
	//public string ServerIp = "208.87.122.199"; // = "192.168.2.39";
	//public int ServerPort;// = 9933;
	
	public enum currentStatus
	{
		SENDING,WAITING,RECEIVED
		
	}
	public currentStatus RESET;
	
	private ISFSArray creatureArray = new SFSArray();
	private ISFSArray trainingGround = new SFSArray();
	private ISFSArray decoration = new SFSArray();
	private ISFSArray GardenPlot = new SFSArray();
	public ISFSArray Plants = new SFSArray();
	private ISFSArray other = new SFSArray();
	private GameObject AssignObjId;
	
	public bool fightRequestbool = false;
	public GameObject battle;
	private BattleGroundManager bgmScript;
	public string fightuser;
	public string myName;
	public bool startAnimationFightbool = false;
	public bool showMsgBool= false;
	
	public GameObject percentageText;
	public static bool startSounds;
	public getPlantXP scr_plantXP;
	private TimeDial scr_timeDial;
	

	
	void Awake()
	{
		
		if (Application.isWebPlayer||Application.isEditor) {
			if (!Security.PrefetchSocketPolicy(ServerIp, ServerPort, 50000)) {
				//Debug.LogError("Security Exception. Policy file load failed!");
			}
		 }	



		//check for userLogged into facebook

		//scr_registerUser = GameObject.Find("sfxConnect").GetComponent<RegisterUser>();
		scr_popUpinfo = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
		SmartfoxConnection();
		scr_userworld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_Gameobjsvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_creatureSystem = GameObject.Find("GameManager").GetComponent<CreatureSystem>();
		scr_GuiControl = GameObject.Find("GUIManager").GetComponent<guiControl>();
		scr_LevelControl = GameObject.Find("GameManager").GetComponent<LevelControl>();
		scr_Gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
		scr_taskDetails = GameObject.Find("TaskDetails").GetComponent<taskDetails>();
		scr_objectCost = GameObject.Find("GameManager").GetComponent<objectCost>();
		scr_timeDial = GameObject.Find("GameManager").GetComponent<TimeDial>();
		
				
		//myName = sfs.MySelf.Name;
		myName  = PlayerPrefs.GetString("CurrentUserId");
///***		Debug.Log("My name is :" + myName);
	}
	
	public bool isalreadyloggedin;
	private Room currentroom;
	

	// Use this for initialization
	void Start () {
		Debug.Log ("sfs remote...");
		RoomName = PlayerPrefs.GetString("roomname");
		currentroom = sfs.RoomManager.GetRoomByName(RoomName);
		
//		Debug.Log("room ------------:" + currentroom.Name);
		
		
		bgmScript = battle.GetComponent<BattleGroundManager>();
		scr_OrcAttackSystem = GameObject.Find("GameManager").GetComponent<OrcAttackSystem>();
		
		 SetScene();
		 SendRequestforGetscheduleTasks();
		 SetMusicNSound();
		//SendRequestForGetworld();
		//SendRequestForFarmItems("4","1"); // for userRelated data
		
         isUserWorld = true;
		 miniGameload = false;
		 isalreadyloggedin = bool.Parse(PlayerPrefs.GetString("isalreadyloggedIn"));
	//	Debug.Log("is already logged in :" + PlayerPrefs.GetString("isalreadyloggedIn"));
	//	Debug.Log("logged :" + isalreadyloggedin);
		if(isUserWorld)
		{
		 PercentageCalc = ReturnRandomNumber(50,55);
		 //Debug.Log("Percentage :" + PercentageCalc);
		 percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
		 }
		//isAssignTasks = true;
	}
	
	
	public void SmartfoxConnection()
	{

		if ( SmartFoxConnection.IsInitialized ) {
			sfs = SmartFoxConnection.Connection;
		} else {
			Application.LoadLevel("MainMenu");
			return;
		}
			
		sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,ReceiveResponseforall);
		sfs.AddEventListener(SFSEvent.CONNECTION_LOST,OnConnectionLost);
		//sfs.AddEventListener(SFSEvent.SOCKET_ERROR,OnSocketError);
		sfs.AddEventListener(SFSEvent.CONNECTION_RETRY, OnConnectionLost);
      	sfs.AddEventListener(SFSEvent.CONNECTION_RESUME, OnConnectionLost);
	}
	
	
	//OnLogin to Server
	void OnLogin(BaseEvent e)
	{
		//Debug.Log("Loggen In" + e.Params["user"]);
	}
	
	void OnLogout(BaseEvent e)
	{
		//Debug.Log("logout");
	}
	
	void OnJoinRoom(BaseEvent e)
	{
		//Debug.Log("Joined Room" + e.Params["room"]);
	}
	
	void OnJoinRoomError(BaseEvent e)
	{
		//Debug.Log("Error " +e.Params["errorCode"] + " | :" + e.Params["errorMessage"]);
	}
	
	void OnLoginError(BaseEvent e)
	{
		//Debug.Log("Loggin error:" + e.Params["errorCode"] + "| :" + e.Params["errorMessage"]);
	}
	
	void OnConnectionLost(BaseEvent e)
	{
	   	//Debug.Log("Connection Lost :: from Server :" + e.Params["reason"].ToString() );
		//scr_popUpinfo.defaultPopUpBool = true;
		//scr_popUpinfo.defaultPopUp(39, 0);
		
		StartCoroutine("RedirectMainmenu");
	}
	
	void OnSocketError(BaseEvent e)
	{
///***		Debug.Log("Socket Error from Server" + e.Params["errorMessage"].ToString());
	}
	
	//OnConnected to Server
	void OnConnection(BaseEvent e)
	{
		if((bool)e.Params["success"])
		{
			//Debug.Log("Success fully connected");
			//Debug.Log("uidb: "+userIdforLogin);
			//SmartFoxConnection.Connection = sfs;
		}
		else
		{
			//Debug.Log("Connection failed :" + e.Params["errorMessage"]);
			//IsConnectedToSrv = false;
		}
		
	}
	
	private bool isNetworkConnected;
	
	public bool runRedirectBool = false;

	// Update is called once per frame
	void Update () 
	{
		if(iPhoneSettings.internetReachability == iPhoneNetworkReachability.ReachableViaWiFiNetwork || 
			iPhoneSettings.internetReachability == iPhoneNetworkReachability.ReachableViaCarrierDataNetwork)
		{	
			isNetworkConnected = true;
		}
		else
		{
			isNetworkConnected = false;		
		}
		
		
		if(!isNetworkConnected)
		{
			scr_popUpinfo.defaultPopUpBool = true;
		    scr_popUpinfo.defaultPopUp(39, 0);
			
			StartCoroutine("RedirectMainmenu");
		}
		else
		{
			//scr_popUpinfo.defaultPopUpBool = false;
			//scr_popUpinfo.destroyPopUp(39,0);	
		}
		
		
		//Debug.Log("speed :: " + scr_Gamemanager.kbps);
		if (runRedirectBool || FacebookEventListener.foregroundQuitBool == true)
		{
///***			Debug.Log("done it two");
			StartCoroutine("RedirectMainmenu");
			FacebookEventListener.foregroundQuitBool = false;
		}
		
	}
	
	
		//----------------------------SUMIT Coding for Fight------------------------------------//
	
	public void getFightScheduleTask()
	{
		ISFSObject obj =  SFSObject.NewInstance(); 
		obj.PutInt("subCmd",25);
		ExtensionRequest r = new ExtensionRequest("5",obj,currentroom);
		sfs.Send(r);
		
	}
	
	public void SendUserListRequest(string cmd, int sCmd, int page,int reqType)
	{
///***		Debug.Log("HOST : "+cmd+" : "+sCmd+" : "+reqType+" : "+page);
	    try
	    {
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", sCmd);
			obj.PutInt("page",page);
			obj.PutInt("reqType",reqType);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendFightRequest(string cmd, int sCmd, string opponentId, int creatureId, int obeliskId, int battleType, int betSparks)
	{
///***		Debug.Log("Send Fight Invite to User  "+opponentId);
	    try
	    {
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", sCmd);
			
			obj.PutUtfString("userId2", opponentId);
			obj.PutInt("creatureId", creatureId);
			obj.PutInt("obeliskObjectTypeId", obeliskId);
			obj.PutInt("battleType", battleType);
			obj.PutInt("sparks", betSparks);
			
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	

	public void SendFightAcceptRequest(string cmd, int sCmd, string opponentId, int creatureId, int obeliskId, int battleId)
	{
		//Debug.Log("i'm here: "+cmd+" : "+sCmd+" "+opponentId+" "+creatureId+" "+obeliskId+" "+battleId);
	    try
	    {
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", sCmd);
			
			obj.PutUtfString("userId1", opponentId);
			obj.PutInt("creatureId", creatureId);
			obj.PutInt("obeliskObjectTypeId", obeliskId);
			obj.PutInt("battleId", battleId);
			
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
					
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	
	public void StartFightRequest(int battleid,int potionid,string opponentId)
	{
		
		try
	    {
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", 27);
	
			obj.PutInt("battleId", battleid);
			obj.PutInt("potionId", potionid);
			obj.PutUtfString("opponentId",opponentId);
			
		    sfs.Send(new ExtensionRequest("5",obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
		
		
	}
	
	//------------POTION LIST----------//
	
	public void getPotionList()
	{
		
		try{
			
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",26);
			sfs.Send(new ExtensionRequest("5",obj,currentroom));
			
		}
		catch(Exception e)
		{
			//Debug.Log("Problem while getting potion list"+e.ToString());
		}
		
	}
	
	//------------POTION LIST END---------------------//
	
	
	//----------------Creature List ------------------------//
	
	
	
	
	public void getCreatureList()
	{
		
		try{
			
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",22);
			sfs.Send(new ExtensionRequest("5",obj,currentroom));
			
		}
		catch(Exception e)
		{
			//Debug.Log("Problem while getting potion list"+e.ToString());
		}
		
	}
	
	
	
	
	//--------------------Creature List End-----------------//
	
	
	//----------------------Extra Power---------------------//
	
	
	public void setExtraPower(int power,int battleId)
	{
		try{
			
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",29);
			obj.PutInt("extraPower",power);
			obj.PutInt("battleId",battleId);
			sfs.Send(new ExtensionRequest("5",obj,currentroom));
			
			//Debug.Log("Extra Power "+power);
		}
		catch(Exception e)
		{
			//Debug.Log("Problem Submitting Extra Power "+e.ToString());
		}
		
		
	}
	
	
	public void FightRejected(int battleId)
	{
		try{
			
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",31);
			obj.PutInt("battleId",battleId);
			sfs.Send(new ExtensionRequest("5",obj,currentroom));
			
			//Debug.Log("Fight Rejected id "+battleId);
		}
		catch(Exception e)
		{
			//Debug.Log("ERROR: "+e.ToString());
		}
		
		
	}
	
	
	
	
	//------------------------Extra Power End-----------------//
	
	
	//------------------------------------END-------------------------------------------------//
	
	
		//30Nov2012
	void FixedUpdate() 
	{
		sfs.ProcessEvents();
	}
	
	void OnApplicationQuit()
	{
//		if(sfs.IsConnected)
//		{
//			sfs.Disconnect();
//			sfs.Send(new LogoutRequest());		
//		}	
		
		//SendRequestforCameraPosition(scr_Gamemanager.cam.transform.position.ToString());
	}
	
	IEnumerator RedirectMainmenu()
	{
		yield return new WaitForSeconds(0.3f);
		
		sfs.Connect(ServerIp, ServerPort);
		if(isalreadyloggedin) 
		{
			PlayerPrefs.SetString("isalreadyloggedIn","false");
		}
		//----------
		if(SmartFoxConnection.IsInitialized)
		{
			sfs = SmartFoxConnection.Connection;
		}
		else
		{
			sfs = new SmartFox();
		}
	
		
		
		sfs.Send(new LogoutRequest());
		sfs.RemoveAllEventListeners();
///***		Debug.Log("Player is log out change the scene...");
		Application.LoadLevel("MainMenu");
	}
			
    public void SendRequestForGetworld()
	{
		try
		{
			string cmd;
			cmd = "3";
			ISFSObject o = new SFSObject();
			o.PutInt("subCmd",4);
			ExtensionRequest r = new ExtensionRequest(cmd,o,currentroom);
			sfs.Send(r);
			
			if(isUserWorld)
			{
			 	PercentageCalc = ReturnRandomNumber(65,70);
	         	//Debug.Log("Percentage :" + PercentageCalc);
			 	percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
			}
			 
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
			
	}
	
   public void SendrequestForAddCreature(int userPid,int objectTypeid,int parentObjid,string position,string rotation)
	{
		try
		{
			string cmd = "3";
			int subCmd = 8;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",userPid);
			obj.PutInt("objectTypeId",objectTypeid);
			obj.PutInt("parentObjectId",parentObjid);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",rotation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			//Debug.Log("sent server");
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendrequestForCreateStructure(int userPurchaseId,int objTypeId,string position,string orientation)
	{
		try
		{
			string cmd = "3";
			int subCmd = 2;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",userPurchaseId);
			obj.PutInt("objectTypeId",objTypeId);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForClearCave(int CaveObjid,int ObjectTypeId,int CreatureObjid)
	{
///***		Debug.Log("caveObjid :" + CaveObjid + "typeId :" + ObjectTypeId);
		
		try
		{
			string cmd = "3";
			int subCmd = 7;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("caveObjectId",CaveObjid);
			obj.PutInt("objectId",ObjectTypeId);
			obj.PutInt("creatureObjId",CreatureObjid);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendrequestForAddFarm(int PurchaseId,int objTypeid,string position,string orientation)
	{
		try
		{
			string cmd = "3";
			int subCmd = 3;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",PurchaseId);
			obj.PutInt("objectTypeId",objTypeid);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendrequestForPlantplants(int PurchaseId,int objecttype,int farmObjId,string position ,string orientation)
	{
		try
		{
			string cmd = "3";
			int subCmd = 5;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",PurchaseId);
			obj.PutInt("objectTypeId",objecttype);
			obj.PutInt("farmObjectId",farmObjId);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);		
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForHarverst(int farmid,int harvestid)
	{
		try
		{
			string cmd = "3";
			int subCmd = 6;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd" ,subCmd);
			obj.PutInt("farmId",farmid);
			obj.PutInt("harvestObjectId",harvestid);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch (Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForAddDecorationItems(int PurchaseId,int objecttypeId,string position,string orientation)
	{
		try
		{
			string cmd = "3";
			int subCmd = 12;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",PurchaseId);
			obj.PutInt("objectTypeId",objecttypeId);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
	}
	
    public void SendRequestForAddTrainingGround(int PurchaseId,int objecttypeId,string position,string orientation)
	{
		try			
		{
			string cmd = "3";
			int subCmd = 1;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("userPurchaseId",PurchaseId);
			obj.PutInt("objectTypeId",objecttypeId);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);			
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	string resetMsg = "";
	string str="";
	string str1="";
	string payload;
	
	public void OnReset()
	{
		/*if(GUI.Button(new Rect(100,100,100,20),"Reset"))
		{
			resetBool = false;
			if (RESET == currentStatus.SENDING)
			{
				
				SendRequestforResetGame();
				
				RESET = currentStatus.WAITING;
				PlayerPrefs.SetInt("isBattleFirstTime",1);
			}
		}*/

//		if(GUI.Button(new Rect(100,500,100,20),"Next Level"))
//		{
//			if (GameManager.gameLevel >= 3)
//				GameManager.xp = GameManager.xp + 100;
//		}
		
		if(RESET == currentStatus.WAITING)
		{
			resetMsg = "Please Wait While your data is Resetting...";
		}
		
		if(RESET == currentStatus.RECEIVED)
		{
			
			resetMsg = "Your Data is Reseted.";
			if(GUI.Button(new Rect(Screen.width/2 - 50,Screen.height/2+50,100,50),"OK"))
			{
				resetBool = true;
				sfs.Send(new LogoutRequest());
				sfs.Disconnect();
				
				Application.Quit();
				
			}
			
		}
		
		if(!resetBool)
		{
			GUI.Box(new Rect(Screen.width/2 - 250,Screen.height/2 - 200 ,500,400),resetMsg);
		}
		
	}
	
	void OnGUI()
	{
		this.OnReset();
		
		if(PushNotificationsIOS.pushNotificationForFight)
		{
			
			payload = PushNotificationsIOS.load;
			
			SendJsonDataToServer(payload);
			
			//Debug.Log("You Are Sending--"+payload);
			
			PushNotificationsIOS.pushNotificationForFight = false;
		}
		else{
			
			////Debug.Log("Load is Null");
			
		}
		
		//GUI.TextField(new Rect(200,200,100,20),str);
		//GUI.TextField(new Rect(200,250,100,20),str1);
		
		
		
//		if(GUI.Button(new Rect(100,200,100,20),"Level Increment"))
//		{
//			//GameManager.xp += 50;
//			// SendRequestforGameObjects(101);
//			SendrequestforDayNightStatus();
//		}
	}
	
	
	public void SendJsonDataToServer(string load)
	{
		try
		{
			string Cmd = "5";
			int paramSubCmd = 28;
			
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",paramSubCmd);
			obj.PutUtfString("jsonString",load);
			ExtensionRequest r = new ExtensionRequest(Cmd,obj,currentroom);
			sfs.Send(r);			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForBuyItems(string paramSubCmd,string paramCmdName,string ObjType,string Cmd)
	{
		try
		{
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",paramSubCmd);
			obj.PutUtfString(paramCmdName,ObjType);
			ExtensionRequest r = new ExtensionRequest(Cmd,obj,currentroom);
			sfs.Send(r);
		
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
	}
	
	public void SendRequestforResetGame()
	{
		try
		{
			string cmd = "5";
			int subCmd = 1;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestForFarmItems(string paramSubCmd,string Cmd)
	{
		try
		{
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",paramSubCmd);
			ExtensionRequest r = new ExtensionRequest(Cmd,obj,currentroom);
			sfs.Send(r);			
			
			if(isUserWorld)
			{
			 PercentageCalc = ReturnRandomNumber(55,60);
	         //Debug.Log("Percentage :" + PercentageCalc);
			 percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
			 }
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForTasksCompleted(int tasksCompleted)
	{
		try 
		{
			string cmd = "1";
			string subCmd = "6";
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",subCmd);
			obj.PutInt("taskComplete",tasksCompleted);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
//			//Debug.Log("sent to server");
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForFood(int food)
	{
		try 
		{
			string cmd = "1";
			string subCmd = "10";
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",subCmd);
			obj.PutInt("foodId",food);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForPopUpsCompleted(int popUpsCompleted)
	{
		try
		{
			string cmd = "1";
			string subCmd = "7";
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",subCmd);
			obj.PutInt("popupsDisplayed",popUpsCompleted);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForAccelrateTask(string taskId,double sparks)
	{
		try
		{
			string cmd = "3";
			int subCmd = 13;
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		  //  obj.PutDouble("sparks", sparks);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void SendRequestForQuestAccelrateTask(string taskId)
	{
		try
		{
			string cmd = "3";
			int subCmd = 16;
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	private string getminiGametask;
	private string GetminiGametask()
	{
		return getminiGametask;
	}
	
	public void SendRequestForAccelerateMinigames(string taskId)
	{
		try
		{
			string cmd = "6";
			int subCmd = 5;
			getminiGametask = taskId;
			
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			
		}
		catch(Exception ex)
		{
			Debug.Log(ex);
		}
		
	}
	
	public void UpgradeObjectLevel(int ObjectId,int ObjectTypeId)
	{
	    try
	    {
			string cmd = "1";
			string subCmd = "16";
		    ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd", subCmd);
		    obj.PutInt("objectTypeId", ObjectTypeId);
			obj.PutInt("objectId",ObjectId);		
			
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	public void AccelerateUpgradeObjectLevel(string taskId)
	{
		try
		{
			string cmd = "1";
			string subCmd = "17";
		    ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
	}
	
	void GetSubCmd(ISFSObject ob)
	{
		try
		{
		    subCmd = ob.GetUtfString ("subCmd");
		}
		catch (Exception ex)
		{
			subCmd = ob.GetInt("subCmd").ToString();
		}
	}
	
	string subCmd;
	public string msg;
	public double xpGainedSvr;
	private int CreatureidforCave,CaveObjid,CaveTypeid;
	private int feedLevelSvr,feedLevelBarSvr;
	public int HarvestObjectId;
	public bool isBurn;
	public int burnObjid;
	public long CurrentTimeSvr;
	public bool isPlayTavernGame;

    public void ReceiveResponseforall(BaseEvent e)
    {
        //try
        {
            string cmd = (string) e.Params["cmd"];
            ISFSObject obj = (SFSObject) e.Params["params"];

            GetSubCmd(obj);

            Debug.Log("cmd : " + cmd + "   subcmd : " + subCmd + "     DUMP :" + obj.GetDump());
            if (cmd == "5")
            {
                UpdateFightFromServer(obj);

            }

            switch (cmd)
            {
                case "100":
                    HandleValuesFromServer(obj);
                    break;

                case "6":
                    //MiniGame Handler
                    HandleMiniGame(obj);
                    break;

                case "5":
                    //Game request Handler
                    //Debug.Log("RequestHandler >>>>>>> :" + obj.GetDump());
                    HandleGameRequests(obj);
                    break;
                case "1":
                    //User request Handler

                    HandleUserRequests(obj);
                    break;

                case "3":
                    //Game Action Handler

                    //Debug.Log(obj.GetUtfString("error"));	
//				Debug.Log("case id ::>>>>> " + subCmd);
                    HandleGameActions(obj);
                    break;

                case "2":

                    HandleBuilding(obj);
                    break;

                case "4":

                    //Economy Hanlder

                    HandleEconomy(obj);

                    break;

            }
        }

//		catch(Exception ex)
//		{
//			//Debug.Log(ex.ToString());
//		}
    }

    private void HandleEconomy(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "1":

                GameManager.coins += obj.GetDouble("goldEarned");
                Debug.Log("earn coind ~~~~~> " + obj.GetDouble("goldEarned"));
                GameManager.earnGoldVal = (int) obj.GetDouble("goldEarned");
                scr_popUpinfo.UpdateScore();
                Debug.Log("gold object --- : " + GameManager.curGoldBuilding.name);
                GameObject earnGoldTxt =
                    Instantiate(Resources.Load("goldValue"), GameManager.curGoldBuilding.transform.position,
                        Quaternion.Euler(90, 0, 0)) as GameObject;
                //UpdateText();
                //Debug.Log("CreditGold : " + obj.GetDump());

                break;

            case "2":

                //Debug.Log("Purchase >>>>>>> :" + obj.GetDump());

                scr_popUpinfo.UpdateScore();
                break;
            case "177":

                //Debug.Log("Gold :" + obj.GetDump());
                ISFSArray arrUsergold = new SFSArray();
                arrUsergold = obj.GetSFSArray("goldObjects");

                for (int i = 0; i < arrUsergold.Size(); i++)
                {
                    ISFSObject objGold = arrUsergold.GetSFSObject(i);
                    scr_userworld.EnableGoldButton(objGold.GetInt("object_type_id"),
                        objGold.GetDouble("object_gold"));
                }


                break;
        }
    }

    private void HandleBuilding(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "1":


                if (!ChkPosNRot(scr_popUpinfo.GetPosition(), scr_popUpinfo.GetRotation()))
                {
                    SendRequestForAddTrainingGround(int.Parse(obj.GetUtfString("userPurchaseId")),
                        int.Parse(obj.GetUtfString("objectTypeId")),
                        scr_popUpinfo.GetPosition(), scr_popUpinfo.GetRotation());
                }

                break;

            case "2":

                // //Debug.Log(obj.GetDump());

                creatureUserPurchaseid = int.Parse(obj.GetUtfString("userPurchaseId"));
                creatureObjecttypeid = int.Parse(obj.GetUtfString("objectTypeId"));

                SendRequestForGetworld();

                break;

            case "3":
//								Debug.Log("2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 " + obj.GetDump());
                if (!ChkPosNRot(scr_popUpinfo.GetPosition(), scr_popUpinfo.GetRotation()))
                {
                    SendrequestForCreateStructure(int.Parse(obj.GetUtfString("userPurchaseId")),
                        int.Parse(obj.GetUtfString("objectTypeId")),
                        scr_popUpinfo.GetPosition(), scr_popUpinfo.GetRotation());
                }
                break;

            case "4":


                break;

            case "5":

                if (scr_popUpinfo.isTaskFarming)
                {
                    {
                        //Debug.Log("Plant baby :" + obj.GetDump());
                        isGetFarmObjId = true;
                        PlantPurchaseid = int.Parse(obj.GetUtfString("userPurchaseId"));
                        PlantObjectTypeid = int.Parse(obj.GetUtfString("objectTypeId"));

                        SendRequestForGetworld();
                        scr_popUpinfo.isTaskFarming = false;
                    }
                }

                break;

            case "6":

                ///***					          Debug.Log("dump: " +obj.GetDump());

                ///***						   Debug.Log("Decos : " + scr_popUpinfo.GetDecorationPos());

                if (!ChkPosNRot(scr_popUpinfo.GetDecorationPos(), scr_popUpinfo.GetRotation()))
                {
                    SendRequestForAddDecorationItems(int.Parse(obj.GetUtfString("userPurchaseId")),
                        int.Parse(obj.GetUtfString("objectTypeId")),
                        scr_popUpinfo.GetDecorationPos(), scr_popUpinfo.GetRotation());
                }

                break;
        }
    }

    private void HandleGameActions(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "1":

                ////Debug.Log(obj.GetDump());
                //Debug.Log ("sfsobj :" + obj.GetUtfString("objId"));
                //Debug.Log("success :" + obj.GetUtfString("success"));
                //Debug.Log("TaskId : " + obj.GetUtfString("taskId"));
                //Debug.Log("error :" + obj.GetUtfString("error"));

                SendRequestforGetscheduleTasks();
                break;

            case "2":
                SendRequestforGetscheduleTasks();
                break;
            case "12":
                //	Debug.Log("DUMP :" + obj.GetDump());
                if (GameManager.taskCount == 8)
                {
                    scr_popUpinfo.placeDirtPathTutorial(6);
                    ///***											Debug.Log("~~~~~~~~~~~~~~~> place dirt path <~~~~~~~~~~~~~~~~");
                }

                if (GameManager.gameLevel > 1)
                {
                    if (obj.GetUtfString("objectTypeId") == "12")
                    {
                        ///***							Debug.Log("^^^^^^^^^^^^^^^^^^");
                        grid.curObj.name = "HC_D_DirtPath_GO(Clone)";
                        scr_popUpinfo.CreateAnotherHalflingdirthPath();
                    }
                    else if (obj.GetUtfString("objectTypeId") == "205")
                    {
                        grid.curObj.name = "DL_D_DDirtPath_GO(Clone)";
                        scr_popUpinfo.CreateAnotherDarklingdirthPath();
                    }
                }

                //Debug.Log ("sfsobj :" + obj.GetUtfString("objId"));
                //Debug.Log("success :" + obj.GetUtfString("success"));
                //Debug.Log("TaskId Goblin Camp : " + obj.GetUtfString("taskId"));
                //					//Debug.Log("error :" + obj.GetUtfString("error"));

                SendRequestforGetscheduleTasks();


                break;
            case "7":
                ///***										Debug.Log("cave dump :" + obj.GetDump());
                SendRequestforGetscheduleTasks();
                break;

            case "18":
                ///***										Debug.Log("3 ------ 18 : "+obj.GetDump());
                //Debug.Log(obj.GetInt("attackedObjId1") +"     "+obj.GetInt("attackedObjId2"));
                scr_userworld.RemoveCaveTask(obj.GetUtfString("taskId"));
                scr_popUpinfo.UpdateScore();
                scr_OrcAttackSystem.StopAttackTask(obj.GetInt("attackedObjId1"), obj.GetInt("attackedObjId2"));
                break;

            case "19":
                //Debug.Log("Creature Morphed :" + obj.GetDump());
                SendRequestforGetscheduleTasks();
                break;

            case "150":
                //Debug.Log("Creature Morphed :" + obj.GetDump());
                GameManager.xp += float.Parse(obj.GetDouble("xpGained").ToString());
                Debug.Log("creature xp = " + float.Parse(obj.GetUtfString("xpGained")));
                UpdateText();
                scr_creatureSystem.AssignPreviousCreatureFeedLevel(obj.GetInt("objectTypeId"),
                    obj.GetInt("feedLevel"));
                break;

            case "13":
                Debug.Log("Accelerated :" + obj.GetDump());
                Debug.Log("my creature xp : " + float.Parse(obj.GetUtfString("xpGained")));
                scr_userworld.RemoveTask(int.Parse(obj.GetUtfString("objectId")));
                scr_popUpinfo.UpdateScore();

                //GameManager.earnXpVal = int.Parse(obj.GetUtfString("xpGained"));
                // indra
//					GameManager.earnXpVal = int.Parse(obj.GetUtfString("xpGained"))//(int)scr_sfsRemote.lst_GameObjectsDb[i].xp_earned;

                // show xp value
//					GameObject xpValObj = Instantiate(Resources.Load("xpValue"), 
//					                                  new Vector3(obj.transform.position.x, obj.transform.position.y + 0.5f, obj.transform.position.z), 
//					                                  Quaternion.Euler(90, 0, 0)) as GameObject;
//					Debug.Log("obj ---> " + obj.name);	
//					xpValObj.transform.parent = obj.transform.root.gameObject.transform;
                break;

            case "14":
                //Debug.Log(obj.GetDump());

                string msg = obj.GetUtfString("msg");

                if (isUserWorld)
                {
                    SendRequestForFarmItems("4", "1");
                    PercentageCalc = ReturnRandomNumber(60, 65);
                    //Debug.Log("Percentage :" + PercentageCalc);
                    percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
                }

                if (obj.GetBool("success"))
                {
                    if (msg != "no task found")
                    {
                        ISFSArray arrUserTasks = obj.GetSFSArray("userTasks");

                        if (lst_times.Count > 0)
                        {
                            lst_times.Clear();
                        }

                        for (int i = 0; i < arrUserTasks.Size(); i++)
                        {
                            ISFSObject o = arrUserTasks.GetSFSObject(i);

                            scr_userworld.AllocateProgressBar(o.GetInt("object_id"),
                                o.GetInt("objectTypeId"),
                                o.GetLong("task_end_time"),
                                o.GetUtfString("task_id"),
                                o.GetInt("creationTime"),
                                o.GetInt("parentObjectId"));
                        }
                    }
                }

                break;
            case "15":

                ///***									Debug.Log("quest kill : " + obj.GetDump());

                if (int.Parse(obj.GetUtfString("questNo")).Equals(502))
                {
                    scr_taskDetails.RemoveQuest(int.Parse(obj.GetUtfString("questNo")));
                }
                SendRequestforGetscheduleTasks();
                scr_popUpinfo.UpdateScore();


                break;

            case "16":

                //Debug.Log("accelerate quest :" + obj.GetDump());
                scr_popUpinfo.AssignQuestNo(int.Parse(obj.GetUtfString("questNo")));
                scr_taskDetails.RemoveQuest(int.Parse(obj.GetUtfString("questNo"))); //Remove from log
                if (bool.Parse(obj.GetUtfString("success")))
                {
                    GameManager.xp += float.Parse(obj.GetUtfString("xpGained"));
                    Debug.Log("creature xp = " + float.Parse(obj.GetUtfString("xpGained")));
                    UpdateText();
                }

                break;

            case "6":

                //Debug.Log("Dump Baby >>>>>:" + obj.GetDump());

                //Debug.Log("harvest :" + obj.GetUtfString("success"));

                scr_userworld.RemoveTask(GetHarverstId());
                GameManager.food += int.Parse(obj.GetUtfString("foodGained"));
                GameManager.plants += int.Parse(obj.GetUtfString("foodGained"));
                GameManager.xp += float.Parse(obj.GetUtfString("xpGained"));
                Debug.Log("creature xp = " + float.Parse(obj.GetUtfString("xpGained")));
                GameManager.coins += double.Parse(obj.GetUtfString("goldGained"));

//										GameObject xpValTemp = GameObject.Find("xpValue(Clone)") as GameObject;
//					
//										if (xpValTemp != null)
//										{
//					                    	scr_plantXP = GameObject.Find("xpValue(Clone)").GetComponent<getPlantXP>();
//											GetxpforPlants = obj.GetUtfString("xpGained");
//					                    	scr_plantXP.objectPlantXP();
//										}


                UpdateText();


                break;

            case "4":

//									    Debug.Log("3 <<<<<<<<<<< 4 : "+obj.GetDump());

                if (obj.GetBool("success"))
                {
                    ISFSArray arrUserworld = obj.GetSFSArray("userWorld");
                    ISFSArray arrUserInventory = obj.GetSFSArray("userInventory");
                    //error = obj.GetUtfString("error");
                    string mg = obj.GetUtfString("msg");
                    ////Debug.Log("error :" + _error);
                    int siz = arrUserworld.Size();

                    creatureArray = new SFSArray();
                    decoration = new SFSArray();
                    trainingGround = new SFSArray();
                    GardenPlot = new SFSArray();
                    Plants = new SFSArray();
                    other = new SFSArray();


                    if (scr_GuiControl.isGetMaxFeed)
                    {
                        if (lst_ObjSvr.Count > 0)
                        {
                            lst_ObjSvr.Clear();
                        }
                    }


                    for (int i = 0; i < arrUserworld.Size(); i++)
                    {
                        SaveUserworld(arrUserworld.GetSFSObject(i));
                    }

                    CalluserWorld(trainingGround);
                    CalluserWorld(creatureArray);
                    CalluserWorld(GardenPlot);
                    CalluserWorld(Plants);
                    CalluserWorld(decoration);
                    CalluserWorld(other);

                    if (scr_GuiControl.isGetMaxFeed)
                    {
                        //Debug.Log("Feed");
                    }

                    for (int j = 0; j < arrUserInventory.Size(); j++)
                    {
                        ISFSObject o = arrUserInventory.GetSFSObject(j);
                        //send to popInformation for adding creature and Dirtpath

                        //array user inventory
                        if (isUserWorld)
                        {
                            scr_userworld.AddUserPurchases(o.GetInt("objectTypeId"),
                                o.GetInt("userPurchaseId"));
                        }
                    }
                }
                if (isUserWorld)
                {
                    SendRequestforquestPlayed();
                    PercentageCalc = ReturnRandomNumber(80, 85);
                    //Debug.Log("Percentage :" + PercentageCalc);
                    percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
                }

                break;

            case "5":

                //Debug.Log("success :" + obj.GetUtfString("success"));
                //Debug.Log("TaskId : " + obj.GetUtfString("taskId"));
                //Debug.Log("ObjectIds for plants :" + obj.GetUtfString("objId"));
                //Debug.Log("Dump :" + obj.GetDump());
                AssignObjId = scr_popUpinfo.GetGameObject();
                AssignObjId.name = AssignObjId.name + "_" + obj.GetUtfString("objId");
                if (AssignObjId.name != null)
                {
                    TempAssignName = AssignObjId.name;
                }
                SendRequestforGetscheduleTasks();

                break;


            case "8":

                //Debug.Log("Creature Task :" + obj.GetDump());
                //Debug.Log(obj.GetUtfString("error"));	
                SendRequestforGetscheduleTasks();

                break;

            case "9":

                //Debug.Log(obj.GetDump());
                break;


            case "100":

                //Debug.Log(obj.GetDump());	

                xpGainedSvr = obj.GetDouble("xpGained");
                Debug.Log(" TG xp :------- " + xpGainedSvr);

                //update xp 

                GameManager.xp = GameManager.xp + (int) xpGainedSvr;
                UpdateText();

                break;

            case "101":

                //Debug.Log(obj.GetDump());
                HarvestObjectId = obj.GetInt("objectId");
                //Debug.Log("harvest : " + HarvestObjectId);

                break;

            case "102":

                //Debug.Log(obj.GetDump());
                // //Debug.Log(obj.GetUtfString("error"));

                xpGainedSvr = obj.GetDouble("xpGained");
                Debug.Log(" creature xp : " + xpGainedSvr);
                //update xp 

                GameManager.xp = GameManager.xp + (int) xpGainedSvr;
                UpdateText();

                break;

            case "103":
                //Debug.Log(obj.GetDump());
                //Debug.Log("Cave cleared");

                xpGainedSvr = obj.GetDouble("xpGained");

                Debug.Log(" creature xp : " + xpGainedSvr);
                //update xp

                GameManager.xp = GameManager.xp + (int) xpGainedSvr;
                UpdateText();


                break;

            case "111":

                //Debug.Log("Quest Success :" + obj.GetDump());
                xpGainedSvr = obj.GetDouble("xpGained");
                Debug.Log(" creature xp : " + xpGainedSvr);
                QuestNoSvr = obj.GetInt("questNo");
                scr_popUpinfo.AssignQuestNo(QuestNoSvr);
                scr_taskDetails.RemoveQuest(QuestNoSvr); //Remove from log
                GameManager.xp = GameManager.xp + (int) xpGainedSvr;
                GameManager.sparks = GameManager.sparks + (int) (obj.GetDouble("sparksGained"));
                UpdateText();
                break;

            case "112":

                //Debug.Log("Burned Plant :" + obj.GetDump());
                isBurn = obj.GetBool("isBurn");
                burnObjid = obj.GetInt("objectId");
                break;

            case "20":

                //Debug.Log("Accelerate Morphing Task :" + obj.GetDump());
                GameManager.xp = GameManager.xp + (int) (obj.GetDouble("xpGained"));
                UpdateText();
                scr_creatureSystem.AssignPreviousCreatureFeedLevel(obj.GetInt("objectTypeId"),
                    obj.GetInt("feedLevel"));

                break;

            case "21":

                //Debug.Log("Accelerate Plant plants: " + obj.GetDump());

                break;

            case "22":
                // cave attack time coming from server
                Debug.Log("Recieved Cave Time :" + obj.GetDump());
                bool isThreshold = obj.GetBool("SecondThreshold");
                getOrgattacktym = float.Parse(obj.GetUtfString("taskEndTime"));
                scr_userworld.GetCaveCreatures(obj.GetInt("objectTypeId"), isThreshold); //Added
                scr_OrcAttackSystem.AddCaveTimer();
                isgetOrgtym = true;

                break;

            case "23":


                int obj1 = 0;
                int obj2 = 0;

                //SendRequestForGetworld();
                Debug.Log("Recieved Building Time :" + obj.GetDump());
                int caveId = obj.GetInt("fromObjId");
                //scr_userworld.GetCaveCreatures(scr_userworld.ReturnTypeIdfromObjId(caveId));
                scr_userworld.GetCaveCreatures(scr_userworld.ReturnTypeIdfromObjId(caveId), false);
                Debug.Log("cave ID = " + scr_userworld.ReturnTypeIdfromObjId(caveId));

                if (caveId != -1)
                {
//											obj1 = obj.GetInt("toObjId1");
//											obj2 = obj.GetInt("toObjId2");
//											
//											
//											getObjTime1 = float.Parse(obj.GetUtfString("toObjId1EndTime"));
//											getObjTime2 = float.Parse(obj.GetUtfString("toObjId2EndTime"));

                    if (scr_OrcAttackSystem.caveCreature_01 != null && scr_OrcAttackSystem.caveCreature_02 != null)
                    {
                        if (scr_OrcAttackSystem.caveCreature_01.gameObject.tag == "Untagged" &&
                            scr_OrcAttackSystem.caveCreature_02.gameObject.tag == "Untagged")
                        {
//												scr_OrcAttackSystem.attackObjId_01 = obj.GetInt("toObjId1");
//												scr_OrcAttackSystem.attackObjId_02 = obj.GetInt("toObjId2");

                            obj1 = obj.GetInt("toObjId1");
                            obj2 = obj.GetInt("toObjId2");


                            getObjTime1 = float.Parse(obj.GetUtfString("toObjId1EndTime"));
                            getObjTime2 = float.Parse(obj.GetUtfString("toObjId2EndTime"));


                            Debug.Log("Object Ids For Attack " + obj1 + " And " + obj2);
                        }
                        else if (scr_OrcAttackSystem.caveCreature_01.gameObject.tag == "busy" &&
                                 scr_OrcAttackSystem.caveCreature_02.gameObject.tag == "Untagged")
                        {
//												scr_OrcAttackSystem.attackObjId_01 = 0;
//												scr_OrcAttackSystem.attackObjId_02 = obj.GetInt("toObjId1");

                            obj1 = 0;
                            obj2 = obj.GetInt("toObjId1");

                            getObjTime1 = 0;
                            getObjTime2 = float.Parse(obj.GetUtfString("toObjId1EndTime"));
                        }
                        else if (scr_OrcAttackSystem.caveCreature_01.gameObject.tag == "Untagged" &&
                                 scr_OrcAttackSystem.caveCreature_02.gameObject.tag == "busy")
                        {
                            scr_OrcAttackSystem.attackObjId_01 = obj.GetInt("toObjId1");
                            scr_OrcAttackSystem.attackObjId_02 = 0;

                            obj1 = obj.GetInt("toObjId1");
                            obj2 = 0;

                            getObjTime1 = float.Parse(obj.GetUtfString("toObjId1EndTime"));
                            getObjTime2 = 0;
                        }

                        scr_OrcAttackSystem.CreatureAttackMode(obj1, obj2);
                    }
                }
                //isGetObjectTime = true;
                //Debug.Log("Building Time Recieved");

                break;

            case "24":


                break;

            case "25":

                ///***					                    Debug.Log("Attack user task : " + obj.GetDump());

                if (obj.GetBool("success"))
                {
                    ISFSArray arrAttackOrgtask = obj.GetSFSArray("userTasks");

                    for (int i = 0; i < arrAttackOrgtask.Size(); i++)
                        //  foreach(ISFSObject attckobj in arrAttackOrgtask)
                    {
                        ISFSObject attackObj = arrAttackOrgtask.GetSFSObject(i); //attckobj; //
                        scr_userworld.AddOrgCaveTasks(attackObj);

                        if (i == arrAttackOrgtask.Size() - 1)
                        {
                            scr_userworld.assignObjIdforOrcAttack = true;
                        }
                    }
                }
                SendRequestForGetworld();

                break;

            case "26": //----- Defense task ---- //

                ///***										Debug.Log("Defense Task : "+obj.GetDump());
                scr_userworld.currentShieldTime = float.Parse(obj.GetUtfString("ShieldTime"));

                if (obj.GetBool("success"))
                {
                    ISFSArray defenseTask = obj.GetSFSArray("objectList");

                    int obliskId = obj.GetInt("objectTypeId");
                    //Debug.Log("obliskID = "+obliskID);

                    for (int i = 0; i < defenseTask.Size(); i++)
                    {
                        int defenseId = defenseTask.GetInt(i);

                        scr_userworld.AddDefenseTimer(defenseId, obliskId);
                    }
                }

                break;

            case "27": //----- Restart Defense task ---- //

                ///***										Debug.Log("Restart defense task : "+obj.GetDump());

                if (obj.GetBool("success"))
                {
                    //scr_userworld.currentShieldTime = (float)obj.GetLong("taskEndTime");
                    //scr_userworld.ConvertLongToFloat(obj.GetLong("taskEndTime"));

                    ISFSArray defenseTask = obj.GetSFSArray("userTasks");

                    for (int i = 0; i < defenseTask.Size(); i++)
                    {
                        ISFSObject defenseObj = defenseTask.GetSFSObject(i);

                        scr_userworld.ResumeDefenseTimer(defenseObj);
                    }
                }

                break;

            case "29": //Stop cave destroy

                ///***										Debug.Log("Stop cave destroy : "+obj.GetDump());
                int typeId = obj.GetInt("caveTypeId");
                string caveName = scr_userworld.ReturnCaveNameFromTypeid(typeId);
                GameObject currentCave = GameObject.Find(caveName);
                ///***										Debug.Log("currentCave : "+currentCave.name);

                if (currentCave != null)
                {
                    progressBar progressBarScript = currentCave.GetComponent<progressBar>();
                    progressBarScript.cnt = 0;
                    progressBarScript.seconds = 0;
                    progressBarScript.SecCnt = 0;
                    progressBarScript.enabled = false;

                    currentCave.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
                    currentCave.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
                }

                break;

            case "30":
                Debug.Log("Storry trigger list : " + obj.GetDump());
                ISFSArray storyList = obj.GetSFSArray("storyTriggerList");

                for (int i = 0; i < storyList.Size(); i++)
                {
                    ISFSObject storyObject = storyList.GetSFSObject(i);
                    //Debug.Log("Trigger no. : "+storyObject.GetInt("triggerNo"));
                    scr_userworld.AddStoryLogList(storyObject);

                    if (storyObject.GetInt("status") == 1)
                        noOfStoriesUnlocked++;
                }
                scr_taskDetails.RedQuestCount.Text = noOfStoriesUnlocked.ToString();
                //scr_taskDetails.QuestStoryLog();
                //scr_taskDetails.FindChild(scr_taskDetails.storyLogQuest).SetActiveRecursively(false);
                break;

            case "31":
                Debug.Log("Unlock story : " + obj.GetDump());

                ISFSArray storyUnlockArray = obj.GetSFSArray("storyTriggerList");

//									for(int i=0; i<storyUnlockArray.Size(); i++)
//									{
//										ISFSObject storyUnlockObject = storyUnlockArray.GetSFSObject(i);
//										scr_userworld.AddStoryLogList(storyUnlockObject);
//						
////										if(storyUnlockObject.GetInt("status") == 1)
////											noOfStoriesUnlocked++;
//										
//									}
                Debug.Log(" unlockedStory length : " + obj.GetIntArray("unlockedStory").Length);

                for (int i = 0; i < obj.GetIntArray("unlockedStory").Length; i++)
                {
                    //scr_taskDetails.showStoryNo.Add(i);
                    scr_taskDetails.showStoryNo.Add((int) obj.GetIntArray("unlockedStory").GetValue(i));
                    Debug.Log(" unlockedStory : " + scr_taskDetails.showStoryNo[i]);
                }
                if (scr_taskDetails.showStoryNo.Count > 0)
                {
                    Debug.Log("Show story");
                    scr_taskDetails.ShowCurrentStory(0, 0);
                    scr_taskDetails.isStory = true;
                }
                noOfStoriesUnlocked = noOfStoriesUnlocked + obj.GetIntArray("unlockedStory").Length;
                scr_taskDetails.RedQuestCount.Text = noOfStoriesUnlocked.ToString();
                break;
        }
    }

    private void HandleUserRequests(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "1":

                //	Debug.Log("Dump : >>>>> " + obj.GetDump());
                //					  msg = obj.GetUtfString("msg");
                bool success = obj.GetBool("success");

                if (success)

                {
                    elapsedtime = obj.GetLong("elapsedTime").ToString();
                    state = obj.GetUtfString("NOW");

                    scr_timeDial.scr_DayNightTime.dnCnt = int.Parse(elapsedtime);

                    //saving elapsedTime
                    PlayerPrefs.SetString("elapsedtime", elapsedtime);
                    //saving State
                    PlayerPrefs.SetString("currentstate", state);
                }

                //string userId = obj.GetUtfString("userId");
                //string gold =  obj.GetUtfString("goldBalance");
                //string spark = obj.GetUtfString("sparkBalance");
                //Debug.Log("msg :" + msg);
                //scr_registerUser.messg = msg;
                //if(msg != "")
                //{
                // Application.LoadLevel("game");
                //}
                //Debug.Log("success :" + success);
                //Debug.Log("userId :" + userId);
                //Debug.Log("gold :" + gold);
                //Debug.Log("spark :" + spark);

                break;

            case "5":

                //Debug.Log("Tasks :"+ obj.GetUtfString("noOfTasksComplete"));
                //Debug.Log("PopUps :" + obj.GetUtfString("noOfPopupsDisplayed"));


                break;

            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":

                //Debug.Log("success :" + obj.GetDump());

                break;

            case "4":

//											Debug.Log("1 : >>>>>>>>>>> 4 :" + obj.GetDump());

                if (obj.GetBool("success"))
                {
                    ISFSArray arrUserInfo = obj.GetSFSArray("userAccountInfo");

                    for (int i = 0; i < arrUserInfo.Size(); i++)
                    {
                        ISFSObject o = arrUserInfo.GetSFSObject(i);
                        scr_userworld.AssingUserValuesFromServer(o.GetInt("darklingOpened"),
                            o.GetInt("story_count"),
                            o.GetInt("no_of_task"),
                            o.GetDouble("balance_gold"),
                            o.GetDouble("balance_xp"),
                            o.GetDouble("maxXpForLevel"),
                            o.GetDouble("currentLevelXp"),
                            o.GetInt("food"),
                            o.GetInt("dnSavings"),
                            o.GetInt("quest"),
                            o.GetInt("level"),
                            o.GetInt("no_of_popup"),
                            o.GetInt("popup_count"),
                            o.GetDouble("balance_spark"));
                    }
                }
                // isAssignTasks = false;
                if (isUserWorld)
                {
                    SendRequestForGetworld();
                    PercentageCalc = ReturnRandomNumber(70, 75);
                    //Debug.Log("Percentage :" + PercentageCalc);
                    percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
                }


                break;

            case "13":

                //Debug.Log("Currnet :: " + obj.GetUtfString("NOW"));
                //Debug.Log("Remaining time :: " + obj.GetLong("elapsedTime"));
                ///***											Debug.Log("DayNnight" + obj.GetDump());

                state = obj.GetUtfString("NOW");
                elapsedtime = obj.GetLong("elapsedTime").ToString();

                scr_timeDial.SetDial();

                break;

            case "12":

                //Debug.Log(obj.GetDump());
                scr_userworld.ResetValues(obj.GetDouble("balance_xp"),
                    obj.GetDouble("maxXpForLevel"),
                    obj.GetDouble("currentLevelXp"));

                ///***											Debug.Log("task 1 ---- 12 :" + obj.GetDump());		//Task List on every level change
                if (obj.GetBool("success"))
                {
                    scr_userworld.ClearQuestTasks();
                    ISFSArray taskList = obj.GetSFSArray("userLevelTask");

                    for (int i = 0; i < taskList.Size(); i++)
                    {
                        ISFSObject taskObj = taskList.GetSFSObject(i);
                        scr_userworld.AddQuestTaskList(taskObj);
                    }
                    scr_taskDetails.totalMissionCount = taskList.Size();
                    //	Debug.Log("Size "+taskList.Size());
                    scr_taskDetails.blueQuestCount.Text = scr_taskDetails.totalMissionCount.ToString();
                }

                break;

            case "14":

                //Debug.Log("gameObjectConstant : " + obj.GetDump());
                ISFSArray arrGameObj = obj.GetSFSArray("gameObjectConstants");
                int size = arrGameObj.Size();
                for (int i = 0; i < size; i++)
                {
                    ISFSObject gameObj = arrGameObj.GetSFSObject(i);
                    ObjectCreationtime = gameObj.GetInt("time_to_create");
                }
                break;

            case "15":

//										    Debug.Log("1 and 15 : >>>>>>>>>> "+ obj.GetDump());

                if ((obj.GetBool("success")))
                {
                    ISFSArray arrUserQuest = obj.GetSFSArray("questsRemain");
                    for (int i = 0; i < arrUserQuest.Size(); i++)
                    {
                        ISFSObject quest = arrUserQuest.GetSFSObject(i);
                        int questNo = quest.GetInt("quest_no");

                        scr_userworld.AddQuest(questNo);
                    }
                }
                if (isUserWorld)
                {
                    //RunOnce();
                    //SendRequestforChildCount();

                    SendRequestforLevelXp();

                    PercentageCalc = ReturnRandomNumber(90, 95);
                    ///***					                         Debug.Log("Percentage :" + PercentageCalc);
                    percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
                    //isUserWorld = false;
                }

                //GameManager.quest = 5 - arrUserQuest.Size();
                ////Debug.Log("quest size " + arrUserQuest.Size() + " --- " + GameManager.quest);


                break;

            case "16":

                //once task upgrade is saved on server here the response should come for it 

                ///***											Debug.Log("Object Upgrade :" + obj.GetDump());
                SendRequestforGetscheduleTasks();


                break;

            case "17":

                //Debug.Log("TG : >>>>>>>" + obj.GetDump());

                scr_userworld.RemoveTask(int.Parse(obj.GetUtfString("objectId")));
                GameManager.xp += float.Parse(obj.GetUtfString("xpGained"));
                Debug.Log("creature xp = " + float.Parse(obj.GetUtfString("xpGained")));
                UpdateText();
                break;

            case "18":

                ///***											Debug.Log("DUMP ::" + obj.GetDump());
                GameManager.xp += float.Parse(obj.GetDouble("xpEarned").ToString());
                UpdateText();
                feedLevelSvr = int.Parse(obj.GetInt("feedLevel").ToString());
                feedLevelBarSvr = int.Parse(obj.GetInt("feedLevelBar").ToString());
                scr_creatureSystem.AssignFeedPb(float.Parse(obj.GetInt("currentFoodFeed").ToString()),
                    float.Parse(obj.GetInt("maxFeed").ToString()), feedLevelSvr, feedLevelBarSvr);

                break;
            case "19":

                //Debug.Log("Child :" + obj.GetDump());

                ISFSArray arrChildObjects = obj.GetSFSArray("childObjects");

                if (obj.GetBool("success"))
                {
                    for (int i = 0; i < arrChildObjects.Size(); i++)
                    {
                        ISFSObject parent = arrChildObjects.GetSFSObject(i);
                        int cnt = (int) (parent.GetLong("creatureCount"));
                        int parentId = parent.GetInt("parent_object_id");
                        scr_userworld.AddTgInfo(cnt, parentId);
                    }


                    if (obj.GetBool("success"))
                    {
                        scr_userworld.AddChildItems();
                    }
                }

                // scr_Mainmenu.loadingBool = false;
                SendRequestforGameObjectsInfo();

                break;

            case "20":

                ///***											Debug.Log("Max Feed :" + obj.GetDump());					

                if (obj.GetBool("success"))
                {
                    ISFSObject feeddetails = obj.GetSFSObject("feedDetails");
                    scr_userworld.SetFoodLevelPB((float) (feeddetails.GetInt("maxFood")),
                        (float) (feeddetails.GetInt("currentFoodFeed")),
                        (int) feeddetails.GetLong("nextFeedLevel"), feeddetails.GetInt("x"));
                }

                break;

            case "21":

                ISFSArray arrUserObjectsDB = obj.GetSFSArray("gameObjectInfo");
                for (int i = 0; i < arrUserObjectsDB.Size(); i++)
                {
                    ISFSObject objdb = arrUserObjectsDB.GetSFSObject(i);

                    scr_userworld.AddUserObjectsDB(objdb.GetDouble("spark_cost"),
                        objdb.GetDouble("cost_gold_total"),
                        objdb.GetDouble("xp_earned"),
                        objdb.GetDouble("cost_gold_base"),
                        objdb.GetUtfString("objectType"),
                        objdb.GetInt("objectTypeId"));
                }


                SendRequestforCreatureSpark();

                break;

            case "22":

                if (obj.GetBool("success"))
                {
                    elapsedtime = obj.GetLong("elapsedTime").ToString();
                    state = obj.GetUtfString("NOW");
                    IsSmokePipeweed = obj.GetBool("isSmooking");
                    scr_timeDial.scr_DayNightTime.dnCnt = int.Parse(elapsedtime);
                    ///***						                     Debug.Log("Day Night stuff :: >>" + obj.GetDump());
                }

                break;


            case "115":

                //Debug.Log(obj.GetDump());

                break;

            case "110":


                elapsedtime = obj.GetLong("elapsedTime").ToString();
                state = obj.GetUtfString("NOW");
                IsSmokePipeweed = obj.GetBool("isSmooking");
                GameManager.xp += (float) obj.GetDouble("xpEarned");
                UpdateText();
                ///***										Debug.Log("::::::: current state :: " + state + " -------- " + elapsedtime);
                scr_timeDial.scr_DayNightTime.dnCnt = int.Parse(elapsedtime);
                break;

            case "131":

                //Debug.Log("Award Spark >>>>>> :" + obj.GetDump());

                break;

            case "24": //Halfling & darkling task list

                ///***										Debug.Log("task 1---- 24 :" + obj.GetDump());
                if (obj.GetBool("success"))
                {
                    scr_userworld.ClearQuestTasks();
                    ISFSArray taskList = obj.GetSFSArray("userLevelTask");

                    for (int i = 0; i < taskList.Size(); i++)
                    {
                        ISFSObject taskObj = taskList.GetSFSObject(i);
                        scr_userworld.AddQuestTaskList(taskObj);
                    }
                    //Debug.Log("Size : "+taskList.Size());
                    scr_taskDetails.totalMissionCount = taskList.Size();
                    scr_taskDetails.blueQuestCount.Text = scr_taskDetails.totalMissionCount.ToString();
                }

                break;
        }
        return;
    }

    private void HandleGameRequests(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "1":

                if (obj.GetBool("success"))
                {
                    RESET = currentStatus.RECEIVED;
                }

                break;

            case "3":


//					Debug.Log("1 1 1 1 1 1 1 1 1 1 1 1 1 1 11 1 1 1 1 1");
                //Debug.Log("Delete :" + obj.GetDump());

                GameManager.coins += obj.GetDouble("goldEarned");
                Debug.Log("gold earn :---> " + obj.GetDouble("goldEarned"));
                UpdateText();

                break;

            case "30":

                SendRequestforScheduleTasksinMinigames();

                ISFSArray arrCreatureMorphInfo = obj.GetSFSArray("morphList");
                for (int i = 0; i < arrCreatureMorphInfo.Size(); i++)
                {
                    ISFSObject o = arrCreatureMorphInfo.GetSFSObject(i);
                    scr_userworld.AddCreatureMorphInfo(o.GetDouble("spark_cost"),
                        o.GetInt("morphCreatureId"),
                        o.GetInt("objectTypeId"));
                }

                scr_objectCost.ObjectcostLoad();

                break;

            case "32":

                //Debug.Log("Friends added : >>>>>>>>>> " + obj.GetDump());
                break;

            case "33":

                //Debug.Log("DUMP ::>>>>" + obj.GetDump());
                ISFSArray arrLvlXp = null;

                if (obj.GetBool("success"))
                {
                    arrLvlXp = obj.GetSFSArray("xpsToNextLevels");

                    if (arrLvlXp != null)
                        scr_userworld.AddLevelxpInfo(arrLvlXp);
                }


                break;
        }
    }

    private void HandleMiniGame(ISFSObject obj)
    {
        switch (subCmd)
        {
            case "4":

                if (obj.GetBool("success"))
                {
                    ISFSArray userHerbarray = obj.GetSFSArray("herbList");

                    if (lst_HerbObjects.Count > 0)
                    {
                        lst_HerbObjects.Clear();
                    }

                    for (int i = 0; i < userHerbarray.Size(); i++)
                    {
                        ISFSObject herb = userHerbarray.GetSFSObject(i);
                        AddHerbObjects(herb.GetUtfString("objectType"),
                            herb.GetInt("objectId"),
                            herb.GetInt("objectTypeId"));
                    }
                }

                break;

            case "1":

                //Debug.Log("Tavern :" + obj.GetDump());

                break;

            case "2":

                //Debug.Log("Mini Game:" + obj.GetDump());

                break;

            case "666":

                tavernGameactive = obj.GetBool("success");

                break;

            case "777":

                //Debug.Log("Opened :" + obj.GetDump());

                potionGameactive = obj.GetBool("success");

                break;

            case "5":

                //Debug.Log("Accelerate Mini :: " + obj.GetDump());

                if (GetminiGametask() == "TavernMiniGame")
                {
                    tavernGameactive = true;
                }

                if (GetminiGametask() == "ApothecaryMiniGame")
                {
                    potionGameactive = true;
                }

                break;

            case "6":


                //Debug.Log("Mini :: " + obj.GetDump());

                isIdleCounttimer = true;

                getPotionList();

                if (obj.GetBool("success"))
                {
                    ISFSArray arrMinigameTimes = obj.GetSFSArray("miniGames");

                    if (lst_miniGametimeInfo.Count > 0)
                    {
                        lst_miniGametimeInfo.Clear();
                    }

                    for (int i = 0; i < arrMinigameTimes.Size(); i++)
                    {
                        ISFSObject objTime = arrMinigameTimes.GetSFSObject(i);

                        MiniGametimes timeInfo = new MiniGametimes();
                        timeInfo.timetoOpen = (int) (objTime.GetDouble("secondsRemainToOpen"));
                        timeInfo.taskId = objTime.GetUtfString("task_id");

                        lst_miniGametimeInfo.Add(timeInfo);
                        //Debug.Log("count ::" + lst_miniGametimeInfo.Count);
                    }


                    if (!miniGameload)
                    {
                        miniGameload = true;
                        scr_userworld.ChkMiniGames();
                    }
                }
                break;
        }
    }

    private void HandleValuesFromServer(ISFSObject obj)
    {
        Debug.Log("DUMP SCORE:" + obj.GetDump());


        GameManager.food = obj.GetInt("food");
        GameManager.plants = (int) obj.GetInt("food");
        GameManager.coins = (int) (obj.GetDouble("balance_gold"));
        GameManager.sparks = (int) obj.GetDouble("balance_spark");

        UpdateText();
    }

    private void UpdateFightFromServer(ISFSObject obj)
    {
        switch (int.Parse(subCmd))
        {
            case 1:

                RESET = currentStatus.RECEIVED;

                break;
            case 21:

                bgmScript.NewUserInfoManager(obj);

                break;

            case 22: //get Creature List from server

                int size = 0;
                ISFSArray arr = null;
                ISFSObject sfsObjCreatureList = null;

                arr = obj.GetSFSArray("creatureList");
                size = arr.Count;


                for (int i = 0; i < size; i++)
                {
                    sfsObjCreatureList = arr.GetSFSObject(i);
                }

                break;


            case 23:

                if (PlayerPrefs.GetInt("isBattleFirstTime") == 2)
                {
                    if (obj.GetBool("success"))
                    {
                        fightuser = obj.GetUtfString("userId").ToString();

                        ///***							Debug.Log("Fight request successfully send to "+obj.GetUtfString("userId"));
                    }
                    if (fightuser == myName)
                    {
                        fightRequestbool = true;
                    }

                    GameManager.battleActiveBool = true;


                    bgmScript.FightRequestReceived(obj);
                }
                else
                    Debug.Log("first complete battle tutorals...");

                break;


            case 24:

                //Debug.Log("----------FIGHT INVITE ACCEPT RESPONSE----------");
                //Debug.Log(obj.GetDump());

                //if(PlayerPrefs.GetInt("isBattleFirstTime") == 2)
                //{
                if (obj.GetBool("success"))
                {
                    bgmScript.BattleScreenCollider(true);
                    bgmScript.changeState();
                    bgmScript.FightAcceptInfo(obj);
                    getPotionList(); // Call this for Potion List
                }
                //}
                //else
                //Debug.Log("play first battle...");


                break;


            case 25:

                // Get Scheduled task when connection is lost

                //Debug.Log(obj.GetDump());

                break;

            case 26:

                SendRequestforOrgAttacktask();
                // Get Potion List
                if (obj.GetBool("success"))
                {
                    bgmScript.getFightPotionList(obj);
                }
                else
                {
                    //Debug.Log("No Potion List Found");
                }
                break;

            case 27:

                // Update Fight Potion

                //Debug.Log(obj.GetDump());

                if (obj.GetBool("isOpponentOnline"))
                {
                    //Start Fight
                }
                else
                {
                    bgmScript.PopupMessage("Fight cannot start\nYour opponent\nis not online.");
                    // Show Popup That user went offline
                }


                break;

            case 29:

                // Update Extra Power

                //Debug.Log(obj.GetDump());

                break;

            case 30:

                SendRequestForDefenseTask();
                SendRequestForQuestTask();
                SendRequestForStoryLog();

                break;

            case 31:

                // Fight Rejected...

                //Debug.Log(obj.GetDump());

                break;

            case 100:
                // Remaining Balance HUD

                // inder change 3march
//					GameManager.sparks = (int)obj.GetDouble("balance_spark");
//					GameManager.coins = obj.GetDouble("balance_gold");
//					GameManager.xp = (float)obj.GetDouble("currentLevelXp");

                scr_GuiControl.goldCoinScoreInfo.Text = ((int) obj.GetDouble("balance_gold")).ToString();

                scr_GuiControl.sparkScoreInfo.Text = ((int) obj.GetDouble("balance_spark")).ToString();

                //Debug.Log(obj.GetDump());


                break;

            case 1000:

                // Fight Winner Message

                //Debug.Log("Winning msg at sfsRemote");
                //Debug.Log(obj.GetDump());

                BattleGroundPlayer.isBattleOver = true;

                bgmScript.BattleWinnerResult(obj);

                break;

            case 2000:

                //Start Fight Message


                if (obj.GetBool("success"))
                {
                    bgmScript.LoadFightScene();
                    startAnimationFightbool = true;
                    bgmScript.SetOtherGUIComponentOff();

                    bgmScript.getFightDuration(obj.GetInt("battleDuration"));

                    bgmScript.ShowBubbleMessage("Tap Bubbles to increase\nYour Creature Power!");

                    bgmScript.BattleStartAudio();
                }

                break;


            case 28:

                //Json Test

                //Debug.Log(obj.GetDump());


                if (obj.GetBool("success"))
                {
                    ISFSObject sfsObj = obj.GetSFSObject("custom");

                    bgmScript.battleId = sfsObj.GetInt("battleId");
                    bgmScript.opponentId = sfsObj.GetUtfString("userId");
                    bgmScript.opponentBattleCreatureId = sfsObj.GetInt("user1CreatureId");
                    bgmScript.gotServerResponse = true;

                    //Debug.Log("Battle Id Form Server "+sfsObj.GetUtfString("userId"));
                }


                break;
        }
    }

    public float GetOrgattackTym()
	{
		return getOrgattacktym;
	}
	
	private string GetxpforPlants;
	public float GetxpPlants()
	{
	   return float.Parse(GetxpforPlants);
	}
	
	private int ChildCount;
	private void ChildArray(ISFSArray arr)
	{
		ChildCount = arr.Size();
	}
	
	public int GetChildCount() 
	{
		return ChildCount;
	}
	
	private int QuestNoSvr;
	public int ReturnQuestCompletedSvr()
	{
		return QuestNoSvr;
	}
	
	public int ReturnBurnId()
	{
		return burnObjid;
	}
	
	public int ReturnParentObjectidSvr()
	{
		return finalParentObjid;
	}
	
	private int creatureUserPurchaseid,creatureObjecttypeid;
	
	public int GetCreaturePurchaseid()
	{
		return creatureUserPurchaseid;
	}
	
	public int GetCreatureObjecttypeid()
	{
		return creatureObjecttypeid;
	}
	
	private int PlantPurchaseid,PlantObjectTypeid;
	
	public int GetPlantPurchaseid()
	{
		return PlantPurchaseid;
	}
	
	public int GetPlantObjectTypeid()
	{
		return PlantObjectTypeid;
	}
	
	
	public void RemoveBurnedPlant(int burnid)
	{
		try
		{
			string cmd = "3";
			int subCmd = 17;
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutInt("objectId", burnid);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
		
	}
	
	public void AcceleratePlantPlantsTask(string taskId)
	{
		try
		{
			string cmd = "3";
			int subCmd = 21;
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
		
	}
	public void AccelerateCaveClearTask(string taskId)
	{
		try
		{
			string cmd = "3";
			int subCmd = 18;
		    ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
		    obj.PutUtfString("taskId", taskId);
		    sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex);
		}
		
	}
	
//	public void GetChildObjectsAfterTypeId(int typeId,int typeIdSvr,int objidSvr)
//	{
//		if(typeIdSvr.Equals(typeId))
//		{
//			//SendRequestforChildCount(objidSvr);
//			scr_Gamemanager.IsGetChild = false;			
//		}
//	}
	
	public void UpgradeObjectAfterTypeid(int typeId,int typeIdSvr,int objidSvr)
	{
		if(typeIdSvr.Equals(typeId))
		{
			//once typeid is equal to the typeid in getworld objectid is retrieved and upgrade task is sent to server.
		  UpgradeObjectLevel(objidSvr,typeIdSvr);
		  //Debug.Log("Object Inn >>>> :" + objidSvr);	
			
		  scr_popUpinfo.Isupgrade = false;	
		}
	}
	
	public void MorphCreatureAfterTypeid(int typeId,int typeIdSvr,int objidSvr)
	{
		if(typeIdSvr.Equals(typeId))
		{
			SendRequestforMorphCreature(objidSvr);
			scr_creatureSystem.isMorphCreature = false;				
		}
	}
	
	public void FeedCreatureAfterTypeid(int typeId,int typeIdSvr,int objidSvr)
	{
		if(typeIdSvr.Equals(typeId))
		{
			SendRequestforFeedCreature(objidSvr,typeIdSvr,scr_creatureSystem.GetCurrentFood());
			scr_creatureSystem.isFeedCreature = false;
		}
	}
	
	private Vector3 temp1,temp2;
	public void DeleteObjectAfterPosition(string position,string positionSvr,int objidSvr)
	{
		
		temp1 = parseVector3(position);
		temp2 = parseVector3(positionSvr);
		
		if(temp1 != Vector3.zero && temp2 != Vector3.zero)
		{
		if(temp1.x.Equals(temp2.x) && temp1.z.Equals(temp2.z))
		{
			SendRequestforDeleteObjects(objidSvr);
			scr_GuiControl.isDelete = false;
		}
	}
	}
	
	public void MoveObjectAfterObjectid(string positionBeforeMove,string position,string rotation,string positionSvr,int objidSvr)
	{
		temp1 = parseVector3(positionBeforeMove);
		temp2 = parseVector3(positionSvr);
		
		if(temp1 != Vector3.zero && temp2 != Vector3.zero)
		{
		if(temp1.x.Equals(temp2.x) && temp1.z.Equals(temp2.z))
		{
			SendRequestforMoveObjects(objidSvr,position,rotation);
			scr_popUpinfo.isObjectMove = false;
		}
	}
	}
	
	
	int temp,finalParentObjid;
	public int ParentObjectAfterTypeid(int typeId,int typeIdSvr,int objidSvr)
	{
		if(typeIdSvr.Equals(typeId))
		{
			temp = objidSvr;	 //ReturnParentObjectidSvr()
			
			//Debug.Log("Parent Obj id >>> : " + temp );
			
			if(!ChkPosNRot(scr_popUpinfo.GetPosition(),scr_popUpinfo.GetRotation()))
			{
		    SendrequestForAddCreature(GetCreaturePurchaseid(),GetCreatureObjecttypeid(),
						              temp,scr_popUpinfo.GetPosition(),scr_popUpinfo.GetRotation());
			scr_popUpinfo.isTaskCreature = false;
		}
		}
		
		return temp;
	}
	
	public void SendFarmObjectIdForPlantPlants(int typeId,int typeIdSvr,int objidSvr)
	{
		if(typeIdSvr.Equals(typeId))
		{
			//Debug.Log("Plant Plants Server :" + objidSvr);
			if(!ChkPosNRot(scr_popUpinfo.GetPosition(),scr_popUpinfo.GetRotation()))
			{
			SendrequestForPlantplants(GetPlantPurchaseid(),GetPlantObjectTypeid(),objidSvr,scr_popUpinfo.GetPosition(),scr_popUpinfo.GetRotation());
			isGetFarmObjId = false;
		}
		}
		
	}
	
	public void AccelerateQuestTask(string taskid)
	{
		try{
		string cmd = "3";
	    int subCmd = 16;
		ISFSObject obj = new SFSObject();
	    obj.PutInt("subCmd", subCmd);
		obj.PutUtfString("taskId", taskid);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void AccelerateMorphingTask(string taskid)
	{
		try 
		{
			string cmd = "3";
		    int subCmd = 20;
			ISFSObject obj = new SFSObject();
		    obj.PutInt("subCmd", subCmd);
			obj.PutUtfString("taskId", taskid);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void ForSendingRequest()
	{
		string id = PlayerPrefs.GetString("CurrentUserId");
		sfs.Send(new LoginRequest(id,"tttg",Zone));		
	}
	
	public void SendStoryCount(int storyCnt)
	{
		try{
		string cmd = "1";
	    string subCmd = "8";
		ISFSObject obj = new SFSObject();
	    obj.PutUtfString("subCmd", subCmd);
		obj.PutInt("storyCountId", storyCnt);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendCurrentPopupCount(int popUpid)
	{
		try{
		string cmd = "1";
	    string subCmd = "11";
		ISFSObject obj = new SFSObject();
	    obj.PutUtfString("subCmd", subCmd);
		obj.PutInt("popupId", popUpid);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendCurrentLevelrequest(int level)
	{
		try{
		string cmd = "1";
	    string subCmd = "12";
		ISFSObject obj = new SFSObject();
	    obj.PutUtfString("subCmd", subCmd);
		obj.PutInt("levelId", level);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
//		Debug.Log("Level from server : "+obj.GetDump());
			}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendPlayQuestCount(int quest)
	{
		try{
		string cmd = "3";
		int subCmd = 15;
		ISFSObject obj = new SFSObject();
	    obj.PutInt("subCmd", subCmd);
		obj.PutInt("questNo", quest);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendRequestforGetscheduleTasks()
	{  
		try{
		string cmd = "3";
		int subCmd = 14;
		ISFSObject obj = new SFSObject();
		obj.PutInt("subCmd",subCmd);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			
			if(isUserWorld)
			{
			 PercentageCalc = ReturnRandomNumber(40,45);
	         //Debug.Log("Percentage :" + PercentageCalc);
			 percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
			 }
			
			}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendRequestforDayNnightActivation()
	{
		try{
		string cmd = "1";
		string subCmd = "13";
		ISFSObject obj = new SFSObject();
		obj.PutUtfString("subCmd",subCmd);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendRequestforquestPlayed()
	{
		try{
		string cmd = "1";
	    string subCmd = "15";
		ISFSObject obj = new SFSObject();
	    obj.PutUtfString("subCmd", subCmd);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			
			
			 PercentageCalc = ReturnRandomNumber(75,80);
	         //Debug.Log("Percentage :" + PercentageCalc);
			 percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	
	public void SendRequestforMorphCreature(int objectId)
	{
		try
		{
		    string cmd = "3";
			int subCmd = 19;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("objectId",objectId);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforFeedCreature(int objectId,int objectTypeId,int food)
	{
		try
		{
		   	string cmd = "1";
			string subCmd = "18";
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",subCmd);
			obj.PutInt("objectId",objectId);
			obj.PutInt("objectTypeId",objectTypeId);
			obj.PutInt("food",food);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	private Vector3 parseVector3(string rString)		//Modified
	{
//		Debug.Log("rString : "+rString);
//		Debug.Log("Length : "+rString.Length);
		if(rString != "")
		{
		    string[] temp = rString.Substring(1,rString.Length-2).Split(',');
			float x = float.Parse(temp[0]);
		    float y = float.Parse(temp[1]);
		    float z = float.Parse(temp[2]);
		    Vector3 rValue = new Vector3(x,y,z);
			return rValue;
		}
	    return Vector3.zero;		//Added
	}
		
	private int requiredPercentage;
	public int ReturnRandomNumber(int min,int max)
	{
		System.Random random = new System.Random();
		requiredPercentage = random.Next(min,max);
		
		return requiredPercentage;
	}
		
	public void SendRequestforCameraPosition(string cameraPos)
	{
		try
		{
		   	string cmd = "5";
			int subCmd = 5;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutUtfString("cameraPosition",cameraPos);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforQuestCount(int questId)
	{ 
		try
		{
			string cmd = "1";
		    string subCmd = "9";
			ISFSObject obj = new SFSObject();
		    obj.PutUtfString("subCmd", subCmd);
			obj.PutInt("questId",questId);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforOrgAttacktask()
	{
		try
		{
			string cmd = "3";
		    int subCmd = 25;
			ISFSObject obj = new SFSObject();
		    obj.PutInt("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	private void SendRequestForDefenseTask()
	{
		try
		{
			string cmd = "3";
		    int subCmd = 27;
			ISFSObject obj = new SFSObject();
		    obj.PutInt("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	private void SendRequestForQuestTask()
	{
		try
		{
			string cmd = "1";
		    string subCmd = "24";
			ISFSObject obj = new SFSObject();
		    obj.PutUtfString("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	private void SendRequestForStoryLog()
	{
		try
		{
			string cmd = "3";
		    int subCmd = 30;
			ISFSObject obj = new SFSObject();
		    obj.PutInt("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforInAppPurchase(int sparks,int gold)
	{
		try
		{
			string cmd = "4";
			int subCmd = 2;
			ISFSObject o = new SFSObject();
			o.PutInt("gold",gold);
			o.PutInt("sparks",sparks);
			o.PutInt("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,o,currentroom);
			sfs.Send(r);
		}
		catch(Exception e)
	    {
			//Debug.Log(e);
		}
	}
	
	public void SendRequestforCreditGold(int objectId)
	{
		try{
		string cmd = "4";
	    int subCmd = 1;
		ISFSObject obj = new SFSObject();
	    obj.PutInt("subCmd", subCmd);
		obj.PutInt("objectId", objectId);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	public void SendRequestforGameObjectsInfo()
	{
		try
		{
		string cmd = "1";
		string subCmd = "21";
		ISFSObject obj = new SFSObject();
	    obj.PutUtfString("subCmd", subCmd);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
		
	}
	
	// send creature name
	public void SendCreatureName(string creatureName, int objId)
	{
		try
		{
///***			Debug.Log("send creature name...................." +  objId + " -- " + creatureName + " -- " + currentroom.Name);
			string cmd = "1";
			string subCmd = "23";
			ISFSObject obj = new SFSObject();
			obj.PutInt("objectId", objId);
			obj.PutUtfString("newName", creatureName);
			obj.PutUtfString("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd, obj, currentroom));
		}
		catch(Exception ex)
		{
			
		}
	}
	
	public void SendRequestforLevelXp()
	{
		try
		{
			string cmd = "5";
			int subCmd = 33;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			
			  PercentageCalc = ReturnRandomNumber(85,90);
///***	          Debug.Log("Percentage :" + PercentageCalc);
			  percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
		}
		catch(Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforCreatureSpark()
	{
		try
		{
		 string cmd = "5";
		 int subCmd = 30;
		 ISFSObject obj = new SFSObject();
	         obj.PutInt("subCmd", subCmd);
		 sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforDeleteObjects(int objectId)
	{
		try
		{
		    string cmd = "5";
			int subCmd = 3;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("objectId",objectId);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforMoveObjects(int objectId,string position,string orientation)
	{
		try
		{
		    string cmd = "5";
			int subCmd = 4;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			obj.PutInt("objectId",objectId);
			obj.PutUtfString("position",position);
			obj.PutUtfString("orientation",orientation);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	//MiniGame Server Request API 's 
	
	public void SendRequestforAddbeer(double beer)
	{
		try
		{
			string cmd = "6";
			int subCmd = 1;
			ISFSObject obj = new SFSObject();
			obj.PutDouble("xpFromBeerGlass",beer);
			obj.PutInt("subCmd",subCmd);	
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforGetHerbs()
	{
		try
		{
			string cmd = "6";
			int subCmd = 4;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforPotionMix(int potionId,int herbObjId1,int herbObjId2,int herbObjId3,int herbObjId4)
	{
		try 
		{
			string cmd = "6";
			int subCmd = 2;
			ISFSObject obj = new SFSObject();
			obj.PutInt("potionId",potionId);
			obj.PutInt("h1",herbObjId1);
			obj.PutInt("h2",herbObjId2);
			obj.PutInt("h3",herbObjId3);
			obj.PutInt("h4",herbObjId4);
			obj.PutInt("subCmd",subCmd);
			ExtensionRequest r = new  ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforBeerGlass(double xpfrmBeer)
	{
		try
		{
			string cmd = "6";
			int subCmd = 1;
			ISFSObject obj = new SFSObject();
			obj.PutDouble("xpFromBeerGlass",xpfrmBeer);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforScheduleTasksinMinigames()
	{
		try{
			
			string cmd = "6";
			int subCmd = 6;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
		}
		
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendrequestforDayNightStatus()
	{
		try{
			
			string cmd = "1";
			string subCmd = "22";
			ISFSObject obj = new SFSObject();
			obj.PutUtfString("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,currentroom);
			sfs.Send(r);
			
		}
		
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	
	public int GetFeedLevelSvr()
	{
		return feedLevelSvr;
	}
	
	public int GetHarverstId()
	{
		return HarvestObjectId;
	}
	
	public long GetCurrentTime()
	{
		return CurrentTimeSvr;
	}
	
	private int ObjectCreationtime;
	public int GetObjectCreationtime()
	{
		return ObjectCreationtime;
	}
	
	private string TempAssignName;
	public string GetPlantName()
	{
		return TempAssignName;
	}
	
	
	public void SendRequestforChildCount()
	{
		try
		{
			string cmd = "1";
			string subCmd = "19";
			ISFSObject obj = new SFSObject();
		    obj.PutUtfString("subCmd", subCmd);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
			
			 PercentageCalc = ReturnRandomNumber(95,100);
///***	         Debug.Log("Percentage :" + PercentageCalc);
			 percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
			 percentageText.active = false;
			 
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendrequestforCurrenttime()
	{
		string cmd = "5";
	    int subCmd = 2;
		ISFSObject obj = new SFSObject();
	    obj.PutInt("subCmd", subCmd);
		sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
	}
	
	
	public void SendRequestforMaxfeed(int objectId,int objectTypeId)
	{
		try
		{			
			string cmd = "1";
		    string subCmd = "20";
			ISFSObject obj = new SFSObject();
		    obj.PutUtfString("subCmd", subCmd);
			obj.PutInt("objectId",objectId);
			obj.PutInt("objectTypeId",objectTypeId);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}	
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	public void SendRequestforOrgcaveAttacktime(int fromObjId, int toObjId1, int toObjId2)
	{
		try
		{			
			string cmd = "3";
		    int subCmd = 22;
			ISFSObject obj = new SFSObject();
		    obj.PutInt("subCmd", subCmd);
			obj.PutInt("fromObjId",fromObjId);
			obj.PutInt("toObjId1",toObjId1);
			obj.PutInt("toObjId2", toObjId2);
			sfs.Send(new ExtensionRequest(cmd,obj,currentroom));
		}	
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	//----Added -----//
	public void SendRequestForOrgCaveTimer(int caveId)
	{
		try
		{
			string cmd = "3";
			int subCmd = 22;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd", subCmd);
			obj.PutInt("fromObjId", caveId);
			sfs.Send(new ExtensionRequest(cmd, obj, currentroom));
		}
		catch(Exception e)
		{
		}
	}
	
	public void SetScene()
	{
		elapsedtime = PlayerPrefs.GetString("elapsedtime");
		state = PlayerPrefs.GetString("currentstate");
		IsSmokePipeweed = bool.Parse(PlayerPrefs.GetString("isSmokepipeweed"));
		
		PercentageCalc = PlayerPrefs.GetInt("Percentage");
		PercentageCalc += ReturnRandomNumber(0,3);
		
		scr_timeDial.SetDial();
		
		//Debug.Log("percentage ::" + PercentageCalc);
	}
	
	
	public void SendRequestforFriendsInvitees(ISFSArray arrFriends)
	{
		try{
			
			string cmd = "5";
			int subCmd = 32;
			ISFSObject o = new SFSObject();
			o.PutInt("subCmd",subCmd);
			o.PutSFSArray("invitees", arrFriends);
			ExtensionRequest r = new ExtensionRequest(cmd,o,currentroom);
		    sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	
	
	public void RunOnce()
	{
		//Debug.Log("run Once 2 >>>>>>>>>");
		//if (i == (i - 1))
		 {
		   if (runOnlyOnce)
			 {
				//Debug.Log("run Once 3 >>>>>>>>>");
				if (GameManager.gameLevel != 0)
				{
					//Debug.Log("run Once 4 >>>>>>>>>");
					runOnlyOnce = false;
					scr_userworld.setCurrentTutLevel();
					scr_userworld.UnLockItemLoading();
					//scr_LevelControl.UnlockItems();
				}
				GameManager.levelCheckBool = true;
			  }
		  }
	}
	
	public void SaveUserworld(ISFSObject obj)
	{
		switch(obj.GetInt("object_type_id"))
		{
		case 210:
		case 214:
		case 29:
		case 2:
		case 20:
		case 207:
			trainingGround.AddSFSObject(obj);
			
			break;
		case 3:
		case 21:
		case 22:
		case 24:
		case 26:
		case 32:
		case 38:
		case 39:
		case 41:
		case 50:
		case 56:
		case 208:
		case 209:
		case 215:
		case 222:
		case 224:
		case 225:
		case 234:
		case 237:
		case 241:
		case 242:
			creatureArray.AddSFSObject(obj);
			
			break;
			
		case 1:
		case 12:
		case 13:
		case 14:
		case 15:
		case 31:
		case 33:
		case 35:
		case 40:
		case 204:
		case 205:
		case 206:
		case 212:
		case 217:
		case 221:
			
			decoration.AddSFSObject(obj);
			break;
			
		case 4:
		case 28:
		case 34:
		case 46:
		case 54:
		case 201:
		case 219:
		case 230:
		case 239:
			
			GardenPlot.AddSFSObject(obj);
			
			break;
			
		case 5:
		case 8:
		case 27:
		case 202:
		case 36:
		case 213:
		case 220:
		case 45:
		case 47:
		case 49:
		case 55:
		case 53:
		case 51:
		case 238:
		case 229:
		case 231:
		case 233:
		case 235:
			
			Plants.AddSFSObject(obj);
			break;
		default: 
			other.AddSFSObject(obj);
			
			break;
		}
	}
	
	
	private void AddHerbObjects(string herbname,int herbid,int herbtypeId)
	{
		HerbObjects herbObj = new HerbObjects();
		herbObj.ObjectName = herbname;
		herbObj.ObjectId = herbid;
		herbObj.ObjectTypeId = herbtypeId;
		
		lst_HerbObjects.Add(herbObj);
		
		//Debug.Log("Herb Count :" + lst_HerbObjects.Count);
	}
	
	private void CalluserWorld(ISFSArray ar)
	{
		for(int i=0 ; i< ar.Size(); i++)
		{
		ISFSObject o = ar.GetSFSObject(i);						
						//Debug.Log("ar : "+ar.GetDump());
						if(isUserWorld)
						{
							scr_userworld.PlaceObjects(o);
						}
		
			            if(scr_GuiControl.isGetMaxFeed)
			            { scr_userworld.ObjectInfo(o) ;}
			
			            if(scr_popUpinfo.GetCaveCreaturetypeId().Equals(o.GetInt("object_type_id")) && scr_popUpinfo.isTask4)
		              	{
				            CreatureidforCave = o.GetInt("object_id");
				            scr_popUpinfo.isGotCreatureid = true;
			            }
			            
			              
			           //Debug.Log("parse vector3" + o.GetUtfString("position") + "cavetypeid "+ o.GetInt("object_type_id") + "cavetobecleared :" + scr_popUpinfo.caveTobeCleared + "taskbool:" + scr_popUpinfo.isTask4);
						if(scr_popUpinfo.caveTobeCleared.Equals(o.GetUtfString("position")) && scr_popUpinfo.isTask4)
						{
							CaveObjid = o.GetInt("object_id");
							CaveTypeid = o.GetInt("object_type_id");
							scr_popUpinfo.isGotCaveids = true;
						}
						
			
			            
						if(scr_popUpinfo.isTask4 && 
						   scr_popUpinfo.isGotCreatureid && scr_popUpinfo.isGotCaveids)
						{						
				             //  Debug.Log("got creture");
						       SendRequestForClearCave(CaveObjid,CaveTypeid,CreatureidforCave);
							   scr_popUpinfo.isTask4 = false; 
						       scr_popUpinfo.isGotCreatureid = false;
						       scr_popUpinfo.isGotCaveids = false;							
						}

					
						if(scr_popUpinfo.Isupgrade)
						{
				            //second getworld is called and in this respose below method is called with parameters ..
							UpgradeObjectAfterTypeid(scr_popUpinfo.GetTypeId(),o.GetInt("object_type_id"),o.GetInt("object_id"));
						}
						
						if(scr_creatureSystem.isMorphCreature)
						{
							MorphCreatureAfterTypeid(scr_creatureSystem.GetMorphTypeid(),o.GetInt("object_type_id"),o.GetInt("object_id"));
						}
						
						if(scr_popUpinfo.isTaskCreature)
						{
							finalParentObjid = ParentObjectAfterTypeid(scr_popUpinfo.GetParentObjectid(),o.GetInt("object_type_id"),o.GetInt("object_id"));
						}
						
						if(scr_creatureSystem.isFeedCreature)
						{
							FeedCreatureAfterTypeid(scr_creatureSystem.GetFeedTypeid(),o.GetInt("object_type_id"),o.GetInt("object_id"));
						}
						
						if(scr_GuiControl.isDelete)
						{
						    DeleteObjectAfterPosition(scr_GuiControl.GetDeletePosition(),o.GetUtfString("position"),o.GetInt("object_id"));
						}
						
			            if(scr_GuiControl.isDeleteDec)
						{
						    DeleteObjectAfterPosition(scr_GuiControl.GetDeleteDecPos(),o.GetUtfString("position"),o.GetInt("object_id"));
						}
			
						if(scr_popUpinfo.isObjectMove)
						{
							MoveObjectAfterObjectid(scr_GuiControl.GetPositionBeforeMove(),scr_popUpinfo.GetPosition(),scr_popUpinfo.GetRotation(),o.GetUtfString("position"),o.GetInt("object_id"));
						}
						
			            if(isGetFarmObjId)
			            {
				            SendFarmObjectIdForPlantPlants(scr_popUpinfo.ReturnGardenPlotTypeId(scr_popUpinfo.GetUpgradePlotName()),o.GetInt("object_type_id"),o.GetInt("object_id"));
			            }
			
			           
		}
					
	}
	
	public bool ChkPosNRot(string pos,string rot)
	{
		Vector3 vect3pos = parseVector3(pos);
		Vector3 vect3rot = parseVector3(rot);
		
		if(vect3pos == Vector3.zero || vect3rot == Vector3.zero) 
		{
			return true;
		}
		
		return false;
	}
	
	public void UpdateText()
	{
		scr_GuiControl.goldCoinScoreInfo.Text = GameManager.coins.ToString();
		scr_GuiControl.plantsScoreInfo.Text = GameManager.food.ToString();
		scr_GuiControl.sparkScoreInfo.Text = GameManager.sparks.ToString();
		
	}
	
	
	public void SendRequestforUserRegis(string uid,string hwid)
	{
///***		Debug.Log("uida: "+uid);
		
		try
		{
			string cmd;
			cmd = "1";
			ISFSObject o = new SFSObject();
			
			o.PutUtfString("token","777");
			o.PutUtfString("hwid",hwid);
			o.PutUtfString("fName",PlayerPrefs.GetString("Firstname"));
			o.PutUtfString("lName",PlayerPrefs.GetString("Lastname"));
		//	o.PutUtfString("userId",uid);
			o.PutUtfString("subCmd","1");
			
			ExtensionRequest r = new ExtensionRequest(cmd,o,currentroom);
			sfs.Send(r);
			
			//Debug.Log("sent");
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
	}
	
	private string soundSave;
	private string musicSave;
	
	public void SetMusicNSound()
	{
///***		Debug.Log("Music :" + PlayerPrefs.GetString("MusicSave").ToString());
///***		Debug.Log("Sound :" + PlayerPrefs.GetString("SoundSave").ToString());
		
	    soundSave = PlayerPrefs.GetString("SoundSave").ToString();
		musicSave = PlayerPrefs.GetString("MusicSave").ToString();
		
		
		if(soundSave == "false")
		{
			scr_popUpinfo.scr_audioController.audio_Apothecary.mute = true;
			scr_popUpinfo.scr_audioController.audio_applaud.mute = true;
			scr_popUpinfo.scr_audioController.audio_barg.mute = true;
			scr_popUpinfo.scr_audioController.audio_Blacksmith.mute = true;
			scr_popUpinfo.scr_audioController.audio_buttonClick.mute = true;
			scr_popUpinfo.scr_audioController.audio_cusith.mute = true;
			scr_popUpinfo.scr_audioController.audio_darkhound.mute = true;
			scr_popUpinfo.scr_audioController.audio_Darklinghouse.mute = true;
			scr_popUpinfo.scr_audioController.audio_Djinn.mute = true;
			scr_popUpinfo.scr_audioController.audio_dl.mute = true;
			scr_popUpinfo.scr_audioController.audio_DLswamp.mute = true;
			scr_popUpinfo.scr_audioController.audio_dragon.mute = true;
			scr_popUpinfo.scr_audioController.audio_draugh.mute = true;
			scr_popUpinfo.scr_audioController.audio_dryad.mute = true;
			scr_popUpinfo.scr_audioController.audio_fenrir.mute = true;
			scr_popUpinfo.scr_audioController.audio_FireCracker.mute = true;
			scr_popUpinfo.scr_audioController.audio_Halfinghouse.mute = true;
			scr_popUpinfo.scr_audioController.audio_harvestCrop.mute = true;
			scr_popUpinfo.scr_audioController.audio_hellhound.mute = true;
			scr_popUpinfo.scr_audioController.audio_hl.mute = true;
			scr_popUpinfo.scr_audioController.audio_hound.mute = true;
			scr_popUpinfo.scr_audioController.audio_imp.mute = true;
			scr_popUpinfo.scr_audioController.audio_Inn.mute = true;
			scr_popUpinfo.scr_audioController.audio_leech.mute = true;
			scr_popUpinfo.scr_audioController.audio_leshy.mute = true;
			scr_popUpinfo.scr_audioController.audio_lurker.mute = true;
			scr_popUpinfo.scr_audioController.audio_nix.mute = true;
			scr_popUpinfo.scr_audioController.audio_nymph.mute = true;
			scr_popUpinfo.scr_audioController.audio_plantCrop.mute = true;
			scr_popUpinfo.scr_audioController.audio_potionBubbles.mute = true;
			scr_popUpinfo.scr_audioController.audio_potionFire.mute = true;
			scr_popUpinfo.scr_audioController.audio_potionStirring.mute = true;
			scr_popUpinfo.scr_audioController.audio_Quest.mute = true;
			scr_popUpinfo.scr_audioController.audio_River.mute = true;
			scr_popUpinfo.scr_audioController.audio_Scaffolding.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkEarth.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkFire.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkPlant.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkSwamp.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkWater.mute = true;
			scr_popUpinfo.scr_audioController.audio_sprite.mute = true;
			scr_popUpinfo.scr_audioController.audio_sprout.mute = true;
			scr_popUpinfo.scr_audioController.audio_stables.mute = true;
			scr_popUpinfo.scr_audioController.audio_storyScreen.mute = true;
			scr_popUpinfo.scr_audioController.audio_tavern.mute = true;
			scr_popUpinfo.scr_audioController.audio_tavernMugfill.mute = true;
			scr_popUpinfo.scr_audioController.audio_tavernMugslide.mute = true;
			scr_popUpinfo.scr_audioController.audio_tavernPouring.mute = true;
			scr_popUpinfo.scr_audioController.audio_wizardMaster.mute = true;
			scr_popUpinfo.scr_audioController.audio_achievement.mute = true;
			scr_popUpinfo.scr_audioController.audio_GoldBtn.mute = true;
			scr_popUpinfo.scr_audioController.audio_RabbitBtn.mute= true;
			scr_popUpinfo.scr_audioController.audio_morph.mute = true;
			scr_popUpinfo.scr_audioController.audio_feed.mute = true;
			scr_popUpinfo.scr_audioController.audio_sparkBirth.mute = true;
			scr_popUpinfo.scr_audioController.audio_halflingChar_touch.mute = true;
			scr_popUpinfo.scr_audioController.audio_darklingChar_touch.mute = true;
			scr_popUpinfo.scr_audioController.audio_Swordclash.mute = true;
			scr_popUpinfo.scr_audioController.audio_Goblincave.mute = true;
			scr_popUpinfo.scr_audioController.audio_TrollCave.mute = true;
			scr_popUpinfo.scr_audioController.audio_Orgcave.mute = true;
			scr_popUpinfo.scr_audioController.audio_nightHL.mute = true;
			
			
				
				//internal sounds
		}
		else if(soundSave == "true")
		{
			AudioController.EnableEnviron = false;
			scr_popUpinfo.scr_audioController.audio_Apothecary.mute = false;
			scr_popUpinfo.scr_audioController.audio_applaud.mute = false;
			scr_popUpinfo.scr_audioController.audio_barg.mute = false;
			scr_popUpinfo.scr_audioController.audio_Blacksmith.mute = false;
			scr_popUpinfo.scr_audioController.audio_buttonClick.mute = false;
			scr_popUpinfo.scr_audioController.audio_cusith.mute = false;
			scr_popUpinfo.scr_audioController.audio_darkhound.mute = false;
			scr_popUpinfo.scr_audioController.audio_Darklinghouse.mute = false;
			scr_popUpinfo.scr_audioController.audio_Djinn.mute = false;
			scr_popUpinfo.scr_audioController.audio_dl.mute = false;
			scr_popUpinfo.scr_audioController.audio_DLswamp.mute = false;
			scr_popUpinfo.scr_audioController.audio_dragon.mute = false;
			scr_popUpinfo.scr_audioController.audio_draugh.mute = false;
			scr_popUpinfo.scr_audioController.audio_dryad.mute = false;
			scr_popUpinfo.scr_audioController.audio_fenrir.mute = false;
			scr_popUpinfo.scr_audioController.audio_FireCracker.mute = false;
			scr_popUpinfo.scr_audioController.audio_Halfinghouse.mute = false;
			scr_popUpinfo.scr_audioController.audio_harvestCrop.mute = false;
			scr_popUpinfo.scr_audioController.audio_hellhound.mute= false;
			scr_popUpinfo.scr_audioController.audio_hl.mute = false;
			scr_popUpinfo.scr_audioController.audio_hound.mute = false;
			scr_popUpinfo.scr_audioController.audio_imp.mute = false;
			scr_popUpinfo.scr_audioController.audio_Inn.mute = false;
			scr_popUpinfo.scr_audioController.audio_leech.mute = false;
			scr_popUpinfo.scr_audioController.audio_leshy.mute = false;
			scr_popUpinfo.scr_audioController.audio_lurker.mute = false;
			scr_popUpinfo.scr_audioController.audio_nix.mute = false;
			scr_popUpinfo.scr_audioController.audio_nymph.mute = false;
			scr_popUpinfo.scr_audioController.audio_plantCrop.mute = false;
			scr_popUpinfo.scr_audioController.audio_potionBubbles.mute = false;
			scr_popUpinfo.scr_audioController.audio_potionFire.mute = false;
			scr_popUpinfo.scr_audioController.audio_potionStirring.mute = false;
			scr_popUpinfo.scr_audioController.audio_Quest.mute = false;
			scr_popUpinfo.scr_audioController.audio_River.mute = false;
			scr_popUpinfo.scr_audioController.audio_Scaffolding.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkEarth.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkFire.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkPlant.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkSwamp.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkWater.mute = false;
			scr_popUpinfo.scr_audioController.audio_sprite.mute = false;
			scr_popUpinfo.scr_audioController.audio_sprout.mute = false;
			scr_popUpinfo.scr_audioController.audio_stables.mute = false;
			scr_popUpinfo.scr_audioController.audio_storyScreen.mute = false;
			scr_popUpinfo.scr_audioController.audio_tavern.mute = false;
			scr_popUpinfo.scr_audioController.audio_tavernMugfill.mute = false;
			scr_popUpinfo.scr_audioController.audio_tavernMugslide.mute = false;
			scr_popUpinfo.scr_audioController.audio_tavernPouring.mute = false;
			scr_popUpinfo.scr_audioController.audio_wizardMaster.mute = false;
			scr_popUpinfo.scr_audioController.audio_achievement.mute = false;
			scr_popUpinfo.scr_audioController.audio_GoldBtn.mute = false;
			scr_popUpinfo.scr_audioController.audio_RabbitBtn.mute = false;
			scr_popUpinfo.scr_audioController.audio_morph.mute = false;
			scr_popUpinfo.scr_audioController.audio_feed.mute = false;
			scr_popUpinfo.scr_audioController.audio_sparkBirth.mute = false;
			scr_popUpinfo.scr_audioController.audio_halflingChar_touch.mute = false;
			scr_popUpinfo.scr_audioController.audio_darklingChar_touch.mute = false;
			scr_popUpinfo.scr_audioController.audio_Swordclash.mute = false;
			scr_popUpinfo.scr_audioController.audio_Goblincave.mute = false;
			scr_popUpinfo.scr_audioController.audio_TrollCave.mute = false;
			scr_popUpinfo.scr_audioController.audio_Orgcave.mute = false;
			scr_popUpinfo.scr_audioController.audio_nightHL.mute = false;
			
			
		}
		
		
		if(musicSave == "false")
		{
			//background
			
			//already disabled in main menu
			scr_popUpinfo.scr_audioController.audio_DrinkingTheme.mute = true;
			scr_popUpinfo.scr_audioController.audio_PotionTheme.mute = true;
		}
			
		else if(musicSave == "true")
		{
			scr_popUpinfo.scr_audioController.audio_DrinkingTheme.mute = false;
			scr_popUpinfo.scr_audioController.audio_PotionTheme.mute = false;
		}
	}
}


