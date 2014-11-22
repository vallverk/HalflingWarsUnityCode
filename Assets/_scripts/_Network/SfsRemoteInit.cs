using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;


public class SfsRemoteInit : MonoBehaviour {
	
		
	//Variable declaration
	//public string ServerIp = "23.23.224.92";
	//public string ServerIp = "208.87.122.200";
	public string ServerIp;// = "192.168.2.33"; // = "208.87.122.199"; // = "192.168.2.39";
	public int ServerPort;// = 9933;
	//public string Zone = "BasicExamples";
	public string Zone;// = "HFZone" ;  //"HFWar";
	public string RoomName;// = "The Lobby";
	public string userIdforLogin = "";
	public string deviceToken;// = "949e22b638889ca5b5a12b9ef8a16c9cb9993dbd94621c6ad67b664973f366a0"; // change
	
	public static string token;

	public bool isNetworkConnected;
	public bool IsConnectedToSrv = false;
	public SmartFox sfs;
	public int PercentageCalc;
	public GameObject percentageText;
	public mainMenu scr_mainMenu;
	
	private int reconnectionseconds;
	private bool isLoginDone = false;
	private int sec;
	
	private bool sfsConnectionBeforeFacebookFriends;
	private string macAdress = "";

	private List<HalflingWarsFriend> halflingFacebookFriendList;

	public bool displayFriendList;
	private Vector2 scrollPosition;
	private float halfWidth;
	private float halfHeight;
	private float scrollWidth;
	private float scrollHeight;
	
	public GUIStyle playerNameStyle;

	public Texture2D friendListBasePlate;
	public Texture2D friendItem1;
	public Texture2D friendItem2;

	public GUIStyle inviteButtonStyle;
	public GUIStyle waitingButtonStyle;
	public GUIStyle playingButtonStyle;

	private string popUpMessage;
	public int popUpId;
	private string[] popUpButtons;
	public bool showPopUp;

	private string theFriendId;
	private string theFriendName;

	public Texture2D popUpBasePlate;
	public GUIStyle popUpConfirmButtonStyle;
	public GUIStyle popUpDeclineButtonStyle;
	public GUIStyle popUpMessageStyle;

	public Rect popUpWindowRect;

	public GUIStyle friendNameStyle;

	public Texture2D dummy;
	public GUIStyle cancelStyle;


	void Start()
	{
		popUpWindowRect = new Rect (Screen.width*0.25f,Screen.height*0.35f,Screen.width*0.5f,Screen.height*0.3f);
		popUpMessageStyle.fontSize = Mathf.FloorToInt(Screen.width * 0.0225f);

		displayFriendList = false;
		scrollPosition = Vector2.zero;
		halfWidth = Screen.width / 2;
		halfHeight = Screen.height / 2;
		
		scrollWidth = Screen.width / 2;
		scrollHeight = Screen.height / 1.5f;
		playerNameStyle.fontSize = Mathf.FloorToInt (Screen.width * 0.3f);
		
		halflingFacebookFriendList = new List<HalflingWarsFriend> ();

		NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
		int i = 0;
		foreach (NetworkInterface adapter in nics)
		{
			PhysicalAddress address  = adapter.GetPhysicalAddress();
			if(address.ToString() != "")
			{
				macAdress = address.ToString();
				Debug.Log("address mac : " + macAdress);
				//macAdress;
			}
		}



		if (Application.isEditor) {
			deviceToken = "949e22b638889ca5b5a12b9ef8a16c9cb9993dbd94621c6ad67b664973f366a0"; // change
		}

		Debug.Log ("start 008...");
		if (Application.isWebPlayer||Application.isEditor) {
			if (!Security.PrefetchSocketPolicy(ServerIp, ServerPort, 50000)) {
				//Debug.LogError("Security Exception. Policy file load failed!");
			}
		 }	
		
///***		Debug.Log("INSIDE START");
		//sabarish
		if(sfs == null) {
///***			Debug.Log("NULL");
		} else {
///***			Debug.Log("NOT NULL");
			//sabarish
			if(!sfs.IsConnected) {
///***				Debug.Log("NOT CONNECTED");
			}
		}
		
		
//		if(SmartFoxConnection.IsInitialized)
//		{
//			sfs = SmartFoxConnection.Connection;
//		}
//		else
//		{
			sfs = new SmartFox();
	//	}
	
///***		Debug.Log("AFTER SFS");
		//sabarish
		if(sfs == null) {
///***			Debug.Log("NULL");
		} else {
///***			Debug.Log("NOT NULL");
			//sabarish
			if(!sfs.IsConnected) {
///***				Debug.Log("NOT CONNECTED");
			}
		}

	//	scr_mainMenu = GameObject.Find("MenuManager").GetComponent<mainMenu>();

		
//		sfs.ThreadSafeMode = true;		
			
		sfs.AddEventListener(SFSEvent.CONNECTION,OnConnection);
		sfs.AddEventListener(SFSEvent.LOGIN,OnLogin);
		sfs.AddEventListener(SFSEvent.LOGIN_ERROR,OnLoginError);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN,OnJoinRoom);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR,OnJoinRoomError);
		//sfs.AddEventListener(SFSEvent.CONNECTION_LOST,OnConnectionLost);	
		sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,ReceiveResponse);
		//sfs.AddEventListener(SFSEvent.LOGOUT,OnLogout);
		//sfs.Send(new LogoutRequest());
		
		
		//Debug.Log("smartfox connection");
		
		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_SUCCESS, OnConfigLoadSuccessHandler);
   		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_FAILURE, OnConfigLoadFailureHandler);

    	sfs.LoadConfig("testEnvironmentConfig.xml", false);
		
		sfs.Connect(ServerIp,ServerPort);
		
///***		Debug.Log("deviceToken : "+deviceToken);
	}
		

void OnConfigLoadSuccessHandler(BaseEvent evt) {
    Console.WriteLine("Config file loaded, now connecting...");

 //   sfs.Connect(ServerIp, ServerPort);
}

void OnConfigLoadFailureHandler(BaseEvent evt) {
    Console.WriteLine("Failed loading config file: " + evt.Params["message"]);
}
	
	// Use this for initialization
	//void Start () {
		

		
	//}
	
	
	public void CreateConnecion()
	{
		if(SmartFoxConnection.IsInitialized)
		{
			sfs = SmartFoxConnection.Connection;
		}
		else
		{
			sfs = new SmartFox();
		}
	
	}
	
	public void takeDeviceToken(string token)
	{
		
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			deviceToken = token;	
			PlayerPrefs.SetString("Hwid",deviceToken);
///***			Debug.Log("Hardware Id :" + deviceToken);
		}
		else {
			
		//	deviceToken = "949e22b638889ca5b5a12b9ef8a16c9cb9993dbd94621c6ad67b664973f366a0";
			
			//Debug.Log("Its Under else");
			
		}
		
		
	}
	
//	public void SmartfxConnection()
//	{
//		if(isNetworkConnected)
//		sfs.Send(new LoginRequest(userIdforLogin, "tttg", Zone));
//		
//		PercentageCalc = ReturnRandomNumber(20,25);
//		//Debug.Log("Percentage % " + PercentageCalc ); 
//		percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
//	}
	
	
	public void SmartfxConnection(string user_id)
	{
///***		Debug.Log("Login Userid "+user_id);
		if(isNetworkConnected) {
///***			Debug.Log("LoginRequest");
		sfs.Send(new LoginRequest(user_id, "tttg", Zone));
		}
		PercentageCalc = ReturnRandomNumber(20,25);
		//Debug.Log("Percentage % " + PercentageCalc ); 
		percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
///***		Debug.Log("After Login Request");
	}
	
	
	//OnLogin to Server
	void OnLogin(BaseEvent e)
	{
		///***		Debug.Log("OnLogin");

		Debug.Log(PlayerPrefs.GetString("CurrentUserId")  + " device token : " + deviceToken );
		
		Debug.Log ("Successfully logged in");
		Debug.Log ("sfsConnectionBeforeFacebookFriends: "+sfsConnectionBeforeFacebookFriends);
		
		if (sfsConnectionBeforeFacebookFriends) {
			InviteFriendsManager();
			return;	
		}

		Debug.Log ("------------");
		
		mainMenu.isalreadyloggedIn = true;
		scr_mainMenu.isplaygameclicked = false;
		deviceToken = PlayerPrefs.GetString("Hwid",deviceToken);
		
		//SendRequestforUserRegis(PlayerPrefs.GetString("CurrentUserId"),deviceToken);
		
		PercentageCalc = ReturnRandomNumber(30,35);
		//Debug.Log("Percentage % " + PercentageCalc ); 
		percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
		//SendRequestForGetworld();
		//isUserWorld = true;
		
	}
	
	private Room userRoomName;
	void OnJoinRoom(BaseEvent e)
	{
///***		Debug.Log("OnJoinRoom ");
		userRoomName = (Room) e.Params["room"];
		
		SendRequestforUserRegis(PlayerPrefs.GetString("CurrentUserId"),deviceToken,userRoomName);
		PlayerPrefs.SetString("roomname",userRoomName.Name);
///***		Debug.Log("Joined Room" + e.Params["room"]);
	}
	
	void OnJoinRoomError(BaseEvent e)
	{
///***		Debug.Log("Error " +e.Params["errorCode"] + " | :" + e.Params["errorMessage"]);
	}
	
	void OnLoginError(BaseEvent e)
	{
///***		Debug.Log("Loggin error:" + e.Params["errorCode"] + "| :" + e.Params["errorMessage"]);
	}
	
	void OnConnectionLost(BaseEvent e)
	{
	   	//Debug.Log("Connection Lost :: from Server :" + e.Params["reason"].ToString() );
		StartCoroutine("RedirectMainmenu");
	}
	
	
	//OnConnected to Server
	void OnConnection(BaseEvent e)
	{
		Debug.Log ("OnConnection");
		///***		Debug.Log("OnConnection: "+((bool)e.Params["success"]));
		if((bool)e.Params["success"])
		{
			
			Debug.Log ("OnConnectionEstablished");
			
			///***			Debug.Log("CONNECTED: "+sfs.IsConnected);
			
			SmartFoxConnection.Connection = sfs;
			
			PercentageCalc = ReturnRandomNumber(0,5);
			//Debug.Log("Percentage % " + PercentageCalc ); 
			percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
			
			if(scr_mainMenu.disonnectedBeforePlayButtonClick) {
				scr_mainMenu.OnPlayButtonClick();
			}
			
			if(sfsConnectionBeforeFacebookFriends) {
				InviteFriendsManager();
			}
			
			
		}
		else
		{
			
			Debug.Log ("OnConnectionFailed");
			Debug.Log("Connection failed :" + e.Params["errorMessage"]);
			//IsConnectedToSrv = false;
		}
		
	}
	
	
	public void SendRequestforUserRegis(string uid,string hwid,Room roomname)
	{
///***		Debug.Log("uida: "+uid);
		
		try
		{
			string cmd;
			cmd = "1";
			ISFSObject o = new SFSObject();
			Debug.Log(PlayerPrefs.GetString("Firstname")+"-"+PlayerPrefs.GetString("Lastname"));
			o.PutUtfString("token","777");
			o.PutUtfString("hwid", macAdress);



			o.PutUtfString("fName",PlayerPrefs.GetString("Firstname"));
			o.PutUtfString("lName",PlayerPrefs.GetString("Lastname"));
		//	o.PutUtfString("userId",uid);
			o.PutUtfString("subCmd","1");
			o.PutUtfString("pushToken", hwid);

//			Debug.Log("VendorIdentifier: "+ iPhone.vendorIdentifier );


///***			Debug.Log("room name :" + roomname.Name);

			Debug.Log("roomname: "+roomname);

			ExtensionRequest r = new ExtensionRequest(cmd,o,roomname);
			sfs.Send(r);
			
			//Debug.Log("sent");
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
	}
	
	void OnLogout(BaseEvent e)
	{
		//Debug.Log("logout");
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
	
	private string cmd,subCmd,msg;
	void ReceiveResponse(BaseEvent e)
	{

		cmd = (string)e.Params["cmd"];
		ISFSObject obj = (SFSObject)e.Params["params"];
		GetSubCmd(obj);
		////Debug.Log(obj.GetDump());
		///***		Debug.Log("Response Received : ----- cmd : "+cmd +" ---- subCmd : "+subCmd +"----- "+obj.GetDump());

		Debug.Log ("ReceiveResponseCMD: "+cmd);
		Debug.Log ("ReceiveResponseSUBCMD: "+subCmd);

		if (sfsConnectionBeforeFacebookFriends) {
			//			sfsConnectionBeforeFacebookFriends = false;
			Debug.Log ("ReceiveResponse return");

			switch(subCmd) {
			case "31":
				Debug.Log(obj.GetDump());
				FriendsInfoFromServer(obj);
				break;
			case "32":
				Debug.Log(obj.GetDump());
				OnInviteResponse(obj);
				break;
			}

			return;

		}



	     switch(cmd)
			{ 
			
			
		case "5":
			
			switch(subCmd)
			{
			case "32":
				
				//Debug.Log("Friend Invitees >>>>>>> >> :" + obj.GetDump());
				
				if(obj.GetBool("success"))
				mainMenu.disablePlaygame = false;
				scr_mainMenu.playMenubool = true;
				
				break;
				
			case "1":
				
///***				Debug.Log("Reseting Data :" + obj.GetDump());
				
				scr_mainMenu.resetbool = false;
				scr_mainMenu.optionMenubool = true;
				mainMenu.isOptionsClicked = false;
				mainMenu.disablePlaygame = false;
				
			//	Application.Quit();
				
				PlayerPrefs.SetInt("isBattleFirstTime",1);
				PlayerPrefs.SetInt("questtutorial",0);
				
				PlayerPrefs.SetInt("feedtuts", 0);
///***				Debug.Log("Reseting Done");
				break;
			}
			
			break;
			
		case "1":
			
			    //Debug.Log(obj.GetDump());
			
				switch(subCmd)
				{
				
			case "1":
					
				    msg = obj.GetUtfString("msg");
					bool success = obj.GetBool("success");
					string userId = obj.GetUtfString("userId");
					string gold =  obj.GetUtfString("goldBalance");
		            string spark = obj.GetUtfString("sparkBalance");
			    	string isSmokePipeweed = obj.GetBool("isSmooking").ToString();
				    //Debug.Log(obj.GetUtfString("error"));
				
					if(obj.GetBool("success"))
					{
						isLoginDone = true;
						
					}
				
				    long elapsedtime = obj.GetLong("elapsedTime");
				    string Currentstate = obj.GetUtfString("NOW");
				
				    //saving elapsedTime
				    PlayerPrefs.SetString("elapsedtime",elapsedtime.ToString());
				    //saving State
				    PlayerPrefs.SetString("currentstate",Currentstate);
				    //PlayerPrefs.SetString("userId",userIdforLogin);
				    PlayerPrefs.SetString("isalreadyloggedIn",mainMenu.isalreadyloggedIn.ToString());
				
				    //saving issmokepipeweed
				    PlayerPrefs.SetString("isSmokepipeweed",isSmokePipeweed);
				
				    //Debug.Log(obj.GetUtfString("error"));
					//Debug.Log("msg :" + msg);
					//scr_registerUser.messg = msg;
					if(msg != "")
					{
					// Debug.Log("Game >>>>>>>>> 1");
					    mainMenu.isLoginComplete = true;
						if(!mainMenu.disablePlaygame)
						{
						// Debug.Log("Game >>>>>>>>> 2");
///***						 Debug.Log("Option:" + mainMenu.isOptionsClicked);
						
							if(!mainMenu.isOptionsClicked)
							{
							
							if(!scr_mainMenu.IsClickedfriends)
							{
							//  Debug.Log("Game >>>>>>>>> 3");
				                sfs.RemoveAllEventListeners();
								
///***								Debug.Log("Game >>>>>>>>> :");
					            Application.LoadLevel("game");
							}
						}
					}
				
					
					 if(mainMenu.isLoginComplete && scr_mainMenu.IsClickedfriends)
					    
						{
						{
///***						      Debug.Log("Friends...111111111111111");
							  var parameters = new Dictionary<string,string>()
								{
									{ "message", "Check out this great app!" }
								};
								FacebookBinding.showDialog( "apprequests", parameters );
								//Debug.Log("Friends...111111111111111");
								
								 mainMenu.sendRequest = true;
							     scr_mainMenu.IsClickedfriends = false;
						
						   }
						       
						}
						
					}
					//Debug.Log("success :" + success);
					//Debug.Log("userId :" + userId);
					//Debug.Log("gold :" + gold);
					//Debug.Log("spark :" + spark);
				
				PercentageCalc = ReturnRandomNumber(40,45);
				PlayerPrefs.SetInt("Percentage",PercentageCalc);
						//Debug.Log("Percentage % " + PercentageCalc ); 
				percentageText.GetComponent<SpriteText>().Text = PercentageCalc.ToString() + "%";
				break;
				}
			
			break;
			}
	 
	}
	// Update is called once per frame
	public  bool hello,calledOnce;
	void Update () {
				
//		  sfs.ProcessEvents();
		
		
//		CheckSocketConnec();	//sabarish	//commented
		
		if(iPhoneSettings.internetReachability == iPhoneNetworkReachability.ReachableViaWiFiNetwork || 
			iPhoneSettings.internetReachability == iPhoneNetworkReachability.ReachableViaCarrierDataNetwork)
		{	
			isNetworkConnected = true;
		}
		else
		{
			isNetworkConnected = false;	
			ShowRetryPopup();
		}
		
		if(FacebookEventListener.hello == null)
		{
			hello = false;
		}
		else
		{
			hello = true;
			calledOnce = true;
		}
		
		
		if(hello)
		{
			if(calledOnce)
			{
			  scr_mainMenu.InviteFriendsStart();
			}
		}
		
		
		if(FacebookEventListener.isfriendcancel)
		{
	        mainMenu.disablePlaygame = false;
			scr_mainMenu.IsClickedfriends = false;
			FacebookEventListener.isfriendcancel = false;
		}
		
	}
	
	
	void FixedUpdate() {
		if(sfs != null)
		  sfs.ProcessEvents();
	}
	
	private void ShowRetryPopup()
	{
		
		var buttons = new string[] { "RETRY" };
		EtceteraBinding.showAlertWithTitleMessageAndButtons( "Connection Error", "Your Network Connection is slow please Retry", buttons );
		
		
	}
	
	
	public void ReloginUserToGame()
	{

		//do re login
		sfs.Send(new LoginRequest(PlayerPrefs.GetString("CurrentUserId"),"ttg",Zone));
		Debug.Log("Trying to relogin");
		
	}
	
	
	public void SendRequestForGetworld()
	{
		try
		{
			string cmd;
			cmd = "3";
			ISFSObject o = new SFSObject();
			o.PutInt("subCmd",4);
			ExtensionRequest r = new ExtensionRequest(cmd,o,userRoomName);
			sfs.Send(r);
		}
		catch(Exception e)
		{
			//Debug.Log(e);
		}
			
	}
	
	
	public void SendRequestforFriendsInvitees(ISFSArray arrFriends)
	{
		try{
			
			string cmd = "5";
			int subCmd = 32;
			ISFSObject o = new SFSObject();
			o.PutInt("subCmd",subCmd);
			o.PutSFSArray("invitees", arrFriends);
			ExtensionRequest r = new ExtensionRequest(cmd,o,userRoomName);
		    sfs.Send(r);
		}
		catch(Exception ex)
		{
			//Debug.Log(ex.ToString());
		}
	}
	
	private int requiredPercentage;
	public int ReturnRandomNumber(int min,int max)
	{
		System.Random random = new System.Random();
		requiredPercentage = random.Next(min,max);
		
		return requiredPercentage;
	}
	
	void OnApplicationQuit()
	{
//		if(sfs.IsConnected)
//		{
//	//		sfs.Disconnect();
//	//		sfs.Send(new LogoutRequest());
//			
//		}
	}
	
	
	public void SendRequestforResetGame()
	{
		try
		{
			string cmd = "5";
			int subCmd = 1;
			ISFSObject obj = new SFSObject();
			obj.PutInt("subCmd",subCmd);
			ExtensionRequest r = new ExtensionRequest(cmd,obj,userRoomName);
			sfs.Send(r);
		}
		catch(Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}
	
	private bool isSocketConnected;
	private void CheckSocketConnec()
	{
		
		if(sfs.IsConnected)
		{
			//do nothing
			isSocketConnected = true ;
		}
		else
		{
			isSocketConnected = false;
		}
		
		
		if(!isSocketConnected)
		{
		   sfs.Connect(ServerIp,ServerPort);
		}
	}
	
	
	//sabarish
	public void SmartfoxReconnection() {
		
		if (Application.isWebPlayer||Application.isEditor) {
			if (!Security.PrefetchSocketPolicy(ServerIp, ServerPort, 50000)) {
				//Debug.LogError("Security Exception. Policy file load failed!");
			}
		 }	
		
///***		Debug.Log("INSIDE SmartfoxReconnection");
		//sabarish
		if(sfs == null) {
			Debug.Log("NULL");
		} else {
///***			Debug.Log("NOT NULL");
			sfs.RemoveAllEventListeners();
			//sabarish
			if(!sfs.IsConnected) {
///***				Debug.Log("NOT CONNECTED");
			}
		}
		
		
//		if(SmartFoxConnection.IsInitialized)
//		{
//			sfs = SmartFoxConnection.Connection;
//		}
//		else
//		{
			sfs = new SmartFox();
	//	}
	
///***		Debug.Log("AFTER SFS");
		//sabarish
		if(sfs == null) {
			Debug.Log("NULL");
		} else {
///***			Debug.Log("NOT NULL");
			//sabarish
			if(!sfs.IsConnected) {
///***				Debug.Log("NOT CONNECTED");
			}
		}

	//	scr_mainMenu = GameObject.Find("MenuManager").GetComponent<mainMenu>();

		
//		sfs.ThreadSafeMode = true;		
			
		sfs.AddEventListener(SFSEvent.CONNECTION,OnConnection);
		sfs.AddEventListener(SFSEvent.LOGIN,OnLogin);
		sfs.AddEventListener(SFSEvent.LOGIN_ERROR,OnLoginError);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN,OnJoinRoom);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR,OnJoinRoomError);
		//sfs.AddEventListener(SFSEvent.CONNECTION_LOST,OnConnectionLost);	
		sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,ReceiveResponse);
		//sfs.AddEventListener(SFSEvent.LOGOUT,OnLogout);
		//sfs.Send(new LogoutRequest());
		
		
		//Debug.Log("smartfox connection");
		
		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_SUCCESS, OnConfigLoadSuccessHandler);
   		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_FAILURE, OnConfigLoadFailureHandler);

    	sfs.LoadConfig("testEnvironmentConfig.xml", false);
		
		sfs.Connect(ServerIp,ServerPort);
		
///***		Debug.Log("deviceToken : "+deviceToken);
	}

	//sabz
	public void InviteFriendsManager() {
		
		Debug.Log("Logged into Facebook: "+FacebookBinding.isSessionValid());
		
		if(FacebookBinding.isSessionValid() || Application.isEditor) {
			//logged in to facebook
			Debug.Log("Connected to SFS: "+sfs.IsConnected);
			if(sfs.IsConnected) {
				//connected to smartfox server
				if(sfs.MySelf != null) {
					//					sfsConnectionBeforeFacebookFriends = false;
					Debug.Log("Logged in to SFS");
					Debug.Log("RetrieveFriendList");
					//connection is fine
					//good to go
					RetrieveFriendList();
				} else {
					Debug.Log("Not logged in to SFS");
					Debug.Log("Logging in to SFS");
					sfsConnectionBeforeFacebookFriends = true;
					sfs.Send(new LoginRequest(PlayerPrefs.GetString("CurrentUserId"),"",Zone));
				}
			} else {
				//not connected to smartfox server
				Debug.Log("Connect to smartfox");
				
				Debug.Log("NOT CONNECTED");
				//disonnectedBeforePlayButtonClick = true;
				sfsConnectionBeforeFacebookFriends = true;
				SmartfoxReconnection();
				return;
				
			}
		} else {
			//not logged in to facebook
			Debug.Log("Prompt User to log into Facebook");
		}
		
	}
	
	private void RetrieveFriendList() {
		Debug.Log("RetrieveFriendList");

		if (Application.isEditor) {
						SendFriendIdToServer ();
						return;
				}
		
		Facebook.instance.getFriends((error, obj) => {
			// if we have an error we dont proceed any further
			if( error != null )
				return;
			if( obj == null )
				return;
			
			// grab the userId and persist it for later use
			//			var ht = obj as Dictionary<string, object>;

			Debug.Log("Fb Success");

			var ht = obj as FacebookFriendsResult;

			if(ht != null) {
				Debug.Log("ht");
				List<FacebookFriend> fbFriendList = ht.data;
				Debug.Log("Count: "+fbFriendList.Count);

				halflingFacebookFriendList = new List<HalflingWarsFriend>();
				foreach(FacebookFriend ff in fbFriendList) {
					halflingFacebookFriendList.Add(new HalflingWarsFriend(ff.id, ff.name));
				}
				
				StartCoroutine(DownloadFriendProfilePicture());

				displayFriendList = true;
				SendFriendIdToServer();

			} else {
				Debug.Log("ht null");
			}
		});
	}

	IEnumerator DownloadFriendProfilePicture() {
		foreach(HalflingWarsFriend ff in halflingFacebookFriendList) {

			string url = "http://graph.facebook.com/" + ff.Id + "/picture?type=large";

			WWW www = new WWW( url );
			
			yield return www;
			
			if( www.error != null ) {
				Debug.Log( "Error attempting to load profile image: " + www.error );
			} else {
				ff.ProfilePicture = www.texture;
			}

		}
	}

//	private void SendFriendIdToServer() {	//editor only
//		ISFSObject dataToSend = new SFSObject();
//		
//		Debug.Log("SendFriendIdToServer");
//		
//		ISFSArray friendListData = new SFSArray();
//		ISFSObject friendData = new SFSObject();
//		
//
//
//				for (int t=0; t<6; t++) {
//					friendData.PutUtfString("friendId", t.ToString());
//					friendListData.AddSFSObject(friendData);
//		
//					halflingFacebookFriendList.Add(new HalflingWarsFriend(t.ToString(), t.ToString()));
//				}
//		
//		dataToSend.PutSFSArray("friendListData", friendListData);
//		
//		try
//		{
//			string cmd = "11";
//			string subCmd = "31";
//			
//			dataToSend.PutUtfString("cmd", cmd);
//			dataToSend.PutUtfString("subCmd", subCmd);
//			
//			ExtensionRequest r = new ExtensionRequest(cmd, dataToSend);
//			sfs.Send(r);
//			
//		}
//		catch(Exception ex)
//		{
//			Debug.Log(ex.ToString());
//		}
//
//	}

	private void SendFriendIdToServer() {
//	private void SendFriendIdToServer() {

		ISFSObject dataToSend = new SFSObject();
		
		Debug.Log("SendFriendIdToServer");
		
		ISFSArray friendListData = new SFSArray();
		ISFSObject friendData;	// = new SFSObject();
		
//		foreach(FacebookFriend fbFriend in halflingFacebookFriendList) {

			
		foreach(HalflingWarsFriend fbFriend in halflingFacebookFriendList) {
			Debug.Log("id: "+fbFriend.Id);

			friendData = new SFSObject();
			friendData.PutUtfString("friendId", fbFriend.Id);

			friendListData.AddSFSObject(friendData);
		}

//		for (int t=0; t<3; t++) {
//			friendData.PutUtfString("friendId", t.ToString());
//			friendListData.AddSFSObject(friendData);
		//
		//			halflingFacebookFriendList.Add(new HalflingWarsFriend(t.ToString(), t.ToString()));
		//		}

		dataToSend.PutSFSArray("friendListData", friendListData);
		
		try
		{
			string cmd = "11";
			string subCmd = "31";
			
			dataToSend.PutUtfString("cmd", cmd);
			dataToSend.PutUtfString("subCmd", subCmd);


			Debug.Log(dataToSend.GetDump());

			
			ExtensionRequest r = new ExtensionRequest(cmd, dataToSend);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		
	}
	
	private void FriendsInfoFromServer(ISFSObject responseData) {
		
		ISFSArray friendListData = responseData.GetSFSArray("theFriendListData");

				Debug.Log ("Count: "+halflingFacebookFriendList.Count);

		for(int i=0; i<friendListData.Count; i++) {
			foreach(HalflingWarsFriend ff in halflingFacebookFriendList) {
				if(friendListData.GetSFSObject(i).GetUtfString("friendId") == ff.Id) {
//					if(friendListData.GetSFSObject(i).GetInt("alreadyRegistered") == 1) {
//						//ff.RegisteredUser = true;
//					} else {
//						ff.RegisteredUser = false;
//					}

					ff.UserStatus = friendListData.GetSFSObject(i).GetInt("alreadyRegistered");
					break;
				}
			}
		}


		Debug.Log ("displayFriendList");
		displayFriendList = true;

	}

    public void DisplayFacebookFriendList()
    {
        //displays facebook friends list

        GUI.DrawTexture(new Rect(Screen.width*0.05f, Screen.height*0.05f, Screen.width*0.9f, Screen.height*0.9f),
            friendListBasePlate);

        if (GUI.Button(new Rect(Screen.width*0.8f, Screen.height*0.13f, Screen.width*0.085f, Screen.height*0.09f), "",
            cancelStyle))
        {
            Debug.Log("Close");
            displayFriendList = false;
        }

        scrollPosition = GUI.BeginScrollView(
                new Rect(Screen.width*0.06f, Screen.height*0.25f, Screen.width*0.84f, Screen.height*0.57f),
                scrollPosition,
                new Rect(Screen.width*0.06f, Screen.height*0.25f, Screen.width*0.8f,
                    (halflingFacebookFriendList.Count*Screen.height*0.14f)));

        int i = 0;
        foreach (HalflingWarsFriend ff in halflingFacebookFriendList)
        {

            if (i%2 == 0)
            {
                GUI.DrawTexture(
                    new Rect(Screen.width*0.15f, (Screen.height*0.25f) + (Screen.height*0.14f*i), Screen.width*0.69f,
                        Screen.height*0.14f), friendItem1);
            }
            else
            {
                GUI.DrawTexture(
                    new Rect(Screen.width*0.15f, (Screen.height*0.25f) + (Screen.height*0.14f*i), Screen.width*0.69f,
                        Screen.height*0.14f), friendItem2);
            }
            if (ff.ProfilePicture != null)
            {
                GUI.DrawTexture(
                    new Rect(Screen.width*0.162f, (Screen.height*0.265f) + (Screen.height*0.14f*i), Screen.width*0.083f,
                        Screen.height*0.11f), ff.ProfilePicture);
            }

            GUI.Label(
                new Rect(Screen.width*0.25f, (Screen.height*0.25f) + (Screen.height*0.14f*i), Screen.width*0.3f,
                    Screen.height*0.08f), ff.FullName, friendNameStyle);

            switch (ff.UserStatus)
            {
                //0-invite,1-playing-,2-waiting
                case 1:

                    if (GUI.Button(
                            new Rect(Screen.width*0.625f, (Screen.height*0.275f) + (Screen.height*0.14f*i),
                                Screen.width*0.175f, Screen.height*0.08f), "", playingButtonStyle))
                    {
                        Debug.Log("Invite" + ff.Id);
                    }

                    break;
                case 2:
                    if (GUI.Button(
                            new Rect(Screen.width*0.625f, (Screen.height*0.275f) + (Screen.height*0.14f*i),
                                Screen.width*0.175f, Screen.height*0.08f), "", waitingButtonStyle))
                    {
                        Debug.Log("Invite" + ff.Id);
                    }
                    break;
                default:
                    if (GUI.Button(
                            new Rect(Screen.width*0.625f, (Screen.height*0.275f) + (Screen.height*0.14f*i),
                                Screen.width*0.175f, Screen.height*0.08f), "", inviteButtonStyle))
                    {
                        Debug.Log("Invite" + ff.Id);
                        OnFacebookFriendInviteClick(ff.Id, ff.FullName);
                    }
                    break;
            }


            i++;
        }
        GUI.EndScrollView();

    }

    private void OnFacebookFriendInviteConfirm() {
		
		ISFSObject dataToSend = new SFSObject();
		
		try
		{
			string cmd = "11";
			string subCmd = "32";
			
			dataToSend.PutUtfString("cmd", cmd);
			dataToSend.PutUtfString("subCmd", subCmd);
			dataToSend.PutUtfString("friendId", theFriendId);
			dataToSend.PutUtfString("friendName", theFriendName);

//			Debug.Log(dataToSend.GetDump());

			ExtensionRequest r = new ExtensionRequest(cmd, dataToSend);
			sfs.Send(r);
			
		}
		catch(Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		

	}
	


	
	private void OnInviteResponse(ISFSObject responseData) {
		//successfully invited
		Debug.Log ("OnInviteResponse");
		//		invitationStatus
		Debug.Log (responseData.GetInt("invitationStatus"));
		
		if (responseData.GetInt ("invitationStatus") == 1) {
			Debug.Log ("Successfully Invited");	
			OnSuccessfullInvitation(responseData.GetUtfString("friendName"));

		} else {
			Debug.Log("Invitation Failed");
			OnInvitationFailure(responseData.GetUtfString("friendName"));
		}
	}

	private class HalflingWarsFriend {
		private string friendId;
		private string friendName;
		private Texture2D profilePicture;
		private bool alreadyRegistered;
		private int userStatus;

		public HalflingWarsFriend(string id, string name) {
			friendId = id;
			friendName = name;
			profilePicture = null;
			alreadyRegistered = false;
			userStatus = 0;
		}

		public string Id {
			get { 
				return friendId; 
			}
		}

		public Texture2D ProfilePicture {
			get { 
				return profilePicture; 
			}
			set {
				profilePicture = value;		
			}
		}
		
		public string FullName {
			get { 
				return friendName; 
			}
		}
		
		public bool RegisteredUser {
			get { 
				return alreadyRegistered; 
			}
			set {
				alreadyRegistered = value;		
			}
		}
		
		public int UserStatus {
			get { 
				return userStatus; 
			}
			set {
				userStatus = value;		
			}
		}


	}


	
	public void PopUpWindow(int windowId) {
//		popUpMessage = "Player "+"0"+" has accepted your invite to \nplay HalflingWars. You \nhave been rewarded with 1 spark";	//Do you want to send AAA invite to play HalflingWars?

//		popUpMessage = "Failed to sent invitation to "+"Charanjeev Sawhney"+" \nto play HalflingWars";	//Do you want to send AAA invite to play HalflingWars?

		GUI.DrawTexture (new Rect(0f, 0f, popUpWindowRect.width,popUpWindowRect.height), popUpBasePlate);
		GUI.Label(new Rect(popUpWindowRect.width*0.15f, popUpWindowRect.height*0.1f, popUpWindowRect.width*0.7f,popUpWindowRect.height*0.65f), popUpMessage, popUpMessageStyle);	//the pop up message
		switch(popUpButtons.Length) {
		case 1:
			//one button
			if (GUI.Button(new Rect(popUpWindowRect.width*0.4f, popUpWindowRect.height*0.625f, popUpWindowRect.width*0.2f,popUpWindowRect.height*0.15f), "", popUpConfirmButtonStyle)){
				PopUpWindowButtonClickHandler(windowId, 1);
			}
			break;
		case 2:
			//two buttons
			if (GUI.Button(new Rect(popUpWindowRect.width*0.275f, popUpWindowRect.height*0.625f, popUpWindowRect.width*0.2f,popUpWindowRect.height*0.15f), "", popUpConfirmButtonStyle)){
				PopUpWindowButtonClickHandler(windowId, 1);
			}
			if (GUI.Button(new Rect(popUpWindowRect.width*0.525f, popUpWindowRect.height*0.625f, popUpWindowRect.width*0.2f,popUpWindowRect.height*0.15f), "", popUpDeclineButtonStyle)){
				PopUpWindowButtonClickHandler(windowId, 2);
			}
			break;
		default:
			break;
		}
	}
	
	private void PopUpWindowButtonClickHandler(int windowId, int buttonId) {
		switch(windowId) {
		case 1:
			switch(buttonId) {
			case 1:
				OnFacebookFriendInviteConfirm();
				break;
			default:
				break;
			}
			break;
		case 2:
			switch(buttonId) {
			case 1:
				SendFriendIdToServer ();
				break;
			default:
				break;
			}
			break;
		case 3:
			break;
		default:
			break;
		}



		popUpMessage = "";
		popUpId = 0;
		popUpButtons = new string[]{};
		showPopUp = false;

	}

	private void OnSuccessfullInvitation(string friendFullName) {
		//show confirm message
		//invitation sent successfully
		popUpMessage = "An invite has been sent to "+friendFullName+" play Halfling Wars";	//Do you want to send AAA invite to play HalflingWars?

		SetPopUpMessage (popUpMessage);

		popUpId = 2;
		popUpButtons = new string[]{"OK"};
		showPopUp = true;


	}
	
	private void OnInvitationFailure(string friendFullName) {
		//show confirm message
		//invitation sent successfully
		popUpMessage = "Failed to sent invitation to "+friendFullName+" to play Halfling Wars";	//Do you want to send AAA invite to play HalflingWars?

		SetPopUpMessage (popUpMessage);

		popUpId = 4;
		popUpButtons = new string[]{"OK"};
		showPopUp = true;
	}

	private void OnFriendAcceptInvitation(string friendFullName) {
		//show user the message
		//friend accepted invitation
		popUpMessage = friendFullName+" has accepted your invite to play Halfling Wars. You have been rewarded with 1 spark";	//Do you want to send AAA invite to play HalflingWars?

		SetPopUpMessage (popUpMessage);

		popUpId = 3;
		popUpButtons = new string[]{"OK"};
		showPopUp = true;
	}

	private void OnFacebookFriendInviteClick(string friendId, string friendFullName) {
		//show confirm po up
		theFriendId = friendId;
		theFriendName = friendFullName;
		
		popUpMessage = "Do you want to send "+friendFullName+" invite to play HalflingWars?";	//Do you want to send AAA invite to play HalflingWars?
//		popUpMessage = "Do you want to send "+"Charanjeev Sawhney"+" invite to play HalflingWars?";	//Do you want to send AAA invite to play HalflingWars?
//		popUpMessage = "Charanjeev Sawhney"+" has accepted your invite to play Halfling Wars You have been rewarded with 1 spark";	//Do you want to send AAA invite to play HalflingWars?

		SetPopUpMessage (popUpMessage);

		popUpId = 1;
		popUpButtons = new string[]{"Yes", "No"};
		showPopUp = true;
	}

	private void SetPopUpMessage(string theMessage) {


		if (theMessage.Length > 105) {
			for(int i=105; i>0; i--) {
				if(theMessage[i] == ' ') {	//space found
					//					theMessage[i] = '\n';
					theMessage = theMessage.Substring(0, i) + "\n" + theMessage.Substring(i+1, theMessage.Length - (i+1));
					break;
				}
			}
		}


		if (theMessage.Length > 70) {
			for(int i=70; i>0; i--) {
				if(theMessage[i] == ' ') {	//space found
//					theMessage[i] = '\n';
					theMessage = theMessage.Substring(0, i) + "\n" + theMessage.Substring(i+1, theMessage.Length - (i+1));
					break;
				}
			}
		}

		if (theMessage.Length > 35) {
			for(int i=35; i>0; i--) {
				if(theMessage[i] == ' ') {	//space found
//					theMessage[i] = '\n';
					theMessage = theMessage.Substring(0, i) + "\n" + theMessage.Substring(i+1, theMessage.Length - (i+1));
					break;
				}
			}
		}


		popUpMessage = theMessage;

	}



}
