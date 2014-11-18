using UnityEngine;
using System.Collections;
using Prime31;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;
using System.Linq;

public class mainMenu : MonoBehaviour 
{
	public Texture2D mainMenuTex;
	public Texture2D OptionsBase;
	private string userId="";
	private SfsRemoteInit scr_SfsRemoteInit;
	public bool IsClicked,IsClickedfriends,isplaygameclicked;
	private int tempId = 0;
	public GUIText userIdTxt;
	public Texture2D loadingScreen;
	public bool loadingBool = false;
	public bool loadingMainMenu = false;
	public static bool disablePlaygame = false;
	public static bool isOptionsClicked = false;
	public static bool isalreadyloggedIn = false;
	public bool playMenubool,optionMenubool;
	public static bool isLoginComplete ;
	
	public GUIStyle play, option, friend, facebook, gamecenter;
	public GUIStyle Music,Reset,Sound,Back,Credit;
	
	public GameObject loadingScreenObj;
		
	public static bool sendRequest = false;
	
	private FacebookEventListener fbListener;
	private AudioListener audioListener;
	
	int noOfUsers = 1000;
	int[] len = new int[1000];
	string[] userIdList = new string[1000-1];
	
	public string compare = null;
	private ISFSArray arrFriends = new SFSArray();
	private AudioSource scr_Bg;
	private AudioSource scr_btnClick;

	public Texture2D MusicOff,SoundOff,MusicOn,SoundOn;
	private AchivementsDetails ad;
	
	//private List<GameCenterLeaderboard> _leaderboards;
	public bool resetbool;
	public Texture2D resetPopup, creditWindow;
	public GUIStyle ok,no,labelStyle;
	
	public Texture2D splashScreen;
	
	private string firstname = "Sachin";
	private string lastname = "Tendulkar";  //for temp
	
	
	public bool disonnectedBeforePlayButtonClick;	//sabarish
	public bool disonnectedBeforeInviteButtonClick;	//sabarish
	private bool displayFriendList;
	
	private bool facebookIdRequestInProgress, creditWindowBool = false;

	public float val1, val2, val3, val4;

	public Texture2D popUpBasePlate;



	void Awake()
	{
		Debug.Log(Screen.width);

	}
	
	void Start () 
	{
		facebookIdRequestInProgress = false;
		Debug.Log ("main menu...");
		FacebookBinding.init();
	    _RegisterNew();
		
		scr_SfsRemoteInit = GameObject.Find("SmartfoxConnect").GetComponent<SfsRemoteInit>();
		fbListener = GameObject.Find("FacebookEventListener").GetComponent<FacebookEventListener>();
		audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
		scr_Bg = GameObject.Find("AudioBG").GetComponent<AudioSource>();
		loadingScreenObj = GameObject.Find("LoadingScreen") as GameObject;
		scr_Bg = GameObject.Find("AudioBG").GetComponent<AudioSource>();
		scr_btnClick = GameObject.Find("AudioButtonClick").GetComponent<AudioSource>();
		
		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
		
		IsClicked = false;
		IsClickedfriends = false;
		playMenubool = true;
		optionMenubool = false;
		isLoginComplete = false;
		
		/*GameCenterManager.categoriesLoaded += delegate( List<GameCenterLeaderboard> leaderboards )
		{
			_leaderboards = leaderboards;
		};*/
		
		//GameCenterBinding.authenticateLocalPlayer();
		
		if(PlayerPrefs.GetString("MusicSave").ToString() == "false")
		{
			Music.normal.background = MusicOff;
			//scr_Bg.mute = true;
			if(scr_Bg.isPlaying)
			{
				scr_Bg.Stop();
			}
		}
		else if(PlayerPrefs.GetString("MusicSave").ToString() == "true")
		{
			Music.normal.background = MusicOn;
			//scr_Bg.mute = false;
			if(!scr_Bg.isPlaying)
			{
				scr_Bg.Play();
			}
		}
		
		if(PlayerPrefs.GetString("SoundSave").ToString() == "false")
		{
			Sound.normal.background = SoundOff;
		}
		else if(PlayerPrefs.GetString("SoundSave").ToString() == "true")
		{
			Sound.normal.background = SoundOn;			
		}
		
		Debug.Log("is already logged in :" + PlayerPrefs.GetString("isalreadyloggedIn").ToString());
		if(PlayerPrefs.GetString("isalreadyloggedIn").ToString() == "false")
		{
			isalreadyloggedIn = false;
		}
		Debug.Log("is already logged in :" + isalreadyloggedIn);

		if(Application.isEditor)
			PlayerPrefs.SetString(("CurrentUserId"),"shiva_02");  //change
		Debug.Log ("main menu end...");

		AdBinding.createAdBanner( true );
	}
	
	
	public void UpdateFacebookUserId()
	{
		if(FacebookBinding.isSessionValid())
		{
			Facebook.instance.getMe( ( error, result ) =>
			                        {
				// if we have an error we dont proceed any further
				if( error != null )
					return;
				
				if( result == null )
					return;
				
				//Debug.Log(result);

				
				// grab the userId and persist it for later use
				//var ht = obj as Hashtable;
				string user_Id = result.id;
				firstname = result.first_name;
			    lastname = result.last_name;
				Debug.Log("Item >>>>>>>> :" + firstname);
				Debug.Log("Item >>>>>>>>: "+ lastname);
				PlayerPrefs.SetString("CurrentUserId",user_Id);
				PlayerPrefs.SetString("Firstname",firstname);
				PlayerPrefs.SetString("Lastname",lastname);
				PlayerPrefs.SetInt("foregroundProcess",1);
				Debug.Log(user_Id);
				if(user_Id == null)
				{
					UpdateFacebookUserId();
					
					//Debug.Log("Item >>>>>>>> :" + firstname);
				       // Debug.Log("Item >>>>>>>>: "+ lastname);
				}
				else
				{
					return;
				}
			});
			Debug.Log("Facebook user id "+PlayerPrefs.GetString("CurrentUserId"));
		}
	}
	
	void Update () 
	{
	}
	
	void OnGUI()
	{	
		
				if (FacebookEventListener.sessionOpened) {
						if (PlayerPrefs.GetString ("CurrentUserId") == "") {
								if (!facebookIdRequestInProgress) {
										facebookIdRequestInProgress = true;
										Debug.Log ("facebookIdRequestInProgress");
										RetrieveFacebookUserId ();
								}
						}
				}
		
				if (PlayerPrefs.GetString ("CurrentUserId") == "") {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), splashScreen);
				} else {
	

						if (loadingMainMenu == false) {
								GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mainMenuTex);
						}

						if (disonnectedBeforePlayButtonClick == true) {		//Sabz.... remove
								GUI.Label (new Rect (100, 600, 100, 100), "Connecting to server...");	
						}
						if (loadingBool == false) {	
								if (playMenubool) {	
										// play button
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 3.0236f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, play)) {
												scr_btnClick.Play ();

												OnPlayButtonClick ();
												return;
										}
								}
			
								if (playMenubool) {	
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 2.1215f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, option)) {
												if (scr_SfsRemoteInit.displayFriendList)
														return;
												//Debug.Log("Option...");
												scr_btnClick.Play ();
												scr_SfsRemoteInit.percentageText.active = false;
												playMenubool = false;
												optionMenubool = true;
												isOptionsClicked = true;
												disablePlaygame = true;
												if (!mainMenu.isalreadyloggedIn) {
				     
														if (Application.isEditor)
																ForTest ();
														else
																GetFacebookUserId (); // change

														Debug.Log ("play menu bool 0!!!!!!!....");
												} else {
														disablePlaygame = false;
												}
										}
								}
			
								if (playMenubool) {
								    if (GUI.Button(
								            new Rect(Screen.width/2.7161f, Screen.height/1.6375f, Screen.width/3.7925f, Screen.height/7.68f),
								            GUIContent.none, friend))
								    {
								        if (scr_SfsRemoteInit.displayFriendList)
								            return;
								        Debug.Log("Friends...");
								        scr_btnClick.Play();
								        scr_SfsRemoteInit.InviteFriendsManager();
								    }

								    if (GUI.Button (new Rect (Screen.width / 2.7527f, Screen.height / 1.3151f, Screen.width / 7.877f, Screen.height / 5.9077f), GUIContent.none, facebook)) {
												if (scr_SfsRemoteInit.displayFriendList)
														return;

												//Debug.Log("Face book...");
												scr_btnClick.Play ();
												Application.OpenURL ("https://www.facebook.com/HalflingWars");
										}
				
										if (GUI.Button (new Rect (Screen.width / 1.9430f, Screen.height / 1.3151f, Screen.width / 7.877f, Screen.height / 5.9077f), GUIContent.none, gamecenter)) {
												if (scr_SfsRemoteInit.displayFriendList)
														return;

												//Debug.Log("Game center...");
												scr_btnClick.Play ();
												ad.gameCenterAchivementList ();
												/*if( _leaderboards != null && _leaderboards.Count > 0 )
				{
					//Debug.Log( "about to report a random score for leaderboard: " + _leaderboards[0].leaderboardId );
					GameCenterBinding.reportScore(GameManager.TotalLevelxp , _leaderboards[0].leaderboardId );
				}
				GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );*/
										}
								}
			
								if (optionMenubool) {
										GUI.DrawTexture (new Rect (Screen.width / 3.3247f, Screen.height / 5.2965f, Screen.width / 2.48f, Screen.height / 1.216f), OptionsBase);
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 2.56f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, Sound)) {
												scr_btnClick.Play ();
												switch (Sound.normal.background.name) {
												case "HW_main_menu_Options_Popup_SoundON_Button":
						//scr_Bg.mute = true;
														Sound.normal.background = SoundOff;
														scr_btnClick.mute = true;
														PlayerPrefs.SetString ("SoundSave", "false");
														break;
						
												case "HW_main_menu_Options_Popup_SoundOFF_Button":
						//scr_Bg.mute = false;
														Sound.normal.background = SoundOn;
														scr_btnClick.mute = false;
														PlayerPrefs.SetString ("SoundSave", "true");
														break;
												}
										}		
				   
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 1.92f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, Music)) {
												// //Debug.Log(Music.normal.background.name);
												scr_btnClick.Play ();
												switch (Music.normal.background.name) {
												case "HW_main_menu_Options_Popup_MusicOFF_Button":
							
														if (!scr_Bg.isPlaying) {
																scr_Bg.Play ();
																Music.normal.background = MusicOn;
																PlayerPrefs.SetString ("MusicSave", "true");
														}
														break;
							
												case "HW_main_menu_Options_Popup_MusicON_Button":
											
														if (scr_Bg.isPlaying) {
																scr_Bg.Stop ();
																Music.normal.background = MusicOff;
																PlayerPrefs.SetString ("MusicSave", "false");
														}
														break;
												}
										}  
										////Debug.Log(Screen.width) ;
										if (GUI.Button (new Rect (Screen.width / 1.1070f, Screen.height / 1.1636f, Screen.width / 10.24f, Screen.height / 7.68f), GUIContent.none, Back)) {
												scr_btnClick.Play ();
												optionMenubool = false;
												playMenubool = true;
												IsClicked = false;
												loadingBool = false;
												mainMenu.disablePlaygame = false;
												isOptionsClicked = false;
										}

										//Credit button
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 1.53f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, Credit)) {
												scr_btnClick.Play ();
												creditWindowBool = true;
										}
				
										GUI.enabled = isLoginComplete;
										if (GUI.Button (new Rect (Screen.width / 2.7161f, Screen.height / 1.28f, Screen.width / 3.7925f, Screen.height / 7.68f), GUIContent.none, Reset)) {
												scr_btnClick.Play ();
												if (isLoginComplete)
														resetbool = true;
										}
								}
						} else if (loadingBool) {
								//GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loadingScreen);
								if (loadingScreenObj.active == false)
										loadingScreenObj.SetActiveRecursively (true);
						} else {
								if (loadingScreenObj.active == true)
										loadingScreenObj.SetActiveRecursively (false);
						}
						// credit window
						if (creditWindowBool) {
								Debug.Log ("credit window...");
								optionMenubool = false;
								GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), creditWindow);

								if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 1.2f, Screen.width / 10.24f, Screen.height / 7.68f), GUIContent.none, Back)) {
										scr_btnClick.Play ();
										creditWindowBool = false;
										optionMenubool = true;
								}
						}
		
						if (resetbool == true) {
								optionMenubool = false;
								GUI.DrawTexture (new Rect (Screen.width / 4.8762f, Screen.height / 2.8445f, Screen.width / 1.7655f, Screen.height / 2.0757f), resetPopup);
								if (GUI.Button (new Rect (Screen.width / 2.6948f, Screen.height / 1.506f, Screen.width / 10.24f, Screen.height / 15.36f), "", ok)) {
										scr_btnClick.Play ();
										Debug.Log ("before reset.....");
										scr_SfsRemoteInit.SendRequestforResetGame ();
										Debug.Log ("After reset...");
										PlayerPrefs.SetInt ("sprout", 0);
										PlayerPrefs.SetInt ("barg", 0);
										PlayerPrefs.SetInt ("nix", 0);
										PlayerPrefs.SetInt ("nymph", 0);
										PlayerPrefs.SetInt ("draug", 0);
										PlayerPrefs.SetInt ("darkhound", 0);
										PlayerPrefs.SetInt ("sprite", 0);
										PlayerPrefs.SetInt ("fenrir", 0);
										PlayerPrefs.SetInt ("imp", 0);
										Debug.Log ("OK...");
								}
								if (GUI.Button (new Rect (Screen.width / 1.9321f, Screen.height / 1.506f, Screen.width / 10.24f, Screen.height / 15.36f), "", no)) {
										scr_btnClick.Play ();
										resetbool = false;
										optionMenubool = true;
										//Debug.Log("no...");
								}
						}
				}


		if (scr_SfsRemoteInit.displayFriendList) {
			scr_SfsRemoteInit.DisplayFacebookFriendList();
		}

		if (scr_SfsRemoteInit.showPopUp) {
			scr_SfsRemoteInit.popUpWindowRect = GUI.Window(scr_SfsRemoteInit.popUpId, scr_SfsRemoteInit.popUpWindowRect, scr_SfsRemoteInit.PopUpWindow, "", GUIStyle.none);
//			scr_SfsRemoteInit.popUpWindowRect = GUI.Window(scr_SfsRemoteInit.popUpId, scr_SfsRemoteInit.popUpWindowRect, scr_SfsRemoteInit.PopUpWindow, popUpBasePlate);
		}


	}
	
	
	public void InviteFriendsStart()
	{
		if(FacebookEventListener.hello != null)
		{
			compare = FacebookEventListener.hello;
			GetId(compare);
			
			if(mainMenu.sendRequest)
			{
				PrintId();
				mainMenu.sendRequest = false;
				FacebookEventListener.hello = null;
			}
		}
		scr_SfsRemoteInit.calledOnce = false;
	}
	
	
	public string GetId(string s)
	{
		//Debug.Log("Friends...33333333333333");
		for(int i =0;i<noOfUsers; i++)
		{
			len[i] = s.IndexOf("&to%5B"+i+"%5D");
			if(len[i] == -1)
				break;
		}
		
		for(int i= 1; i<noOfUsers; i++)
		{
			if(len[i-1] != -1)
			{
				if(len[i] != -1)
					userIdList[i-1] = s.Substring(len[i-1]+11, len[i]-(len[i-1]+11));
				else
					userIdList[i-1] = s.Substring(len[i-1]+11, s.Length-(len[i-1]+11));
			}
			else
			{
				userIdList[i-1] = "exit"; 
				break;
			}
		}
		return "";
	}
	
	public void PrintId()
	{
		for(int i=0; i<noOfUsers-1; i++)
		{
			if(userIdList[i] != "exit")
			{
				arrFriends.AddUtfString(userIdList[i]);
				
				 				ad.friendcount = PlayerPrefs.GetInt("friendinvite");
				 				PlayerPrefs.SetInt("friendinvite",(ad.friendcount+1));

				 				ad.percentComplete16 = 100*PlayerPrefs.GetInt("friendinvite");
				 				ad.percentComplete20 = 10*PlayerPrefs.GetInt("friendinvite");
				 				ad.percentComplete34 = 5*PlayerPrefs.GetInt("friendinvite");
				 				ad.percentComplete39 = 2*PlayerPrefs.GetInt("friendinvite");
				 				ad.percentComplete47 = 1*PlayerPrefs.GetInt("friendinvite");
			}
			else
			break;
		}
		scr_SfsRemoteInit.SendRequestforFriendsInvitees(arrFriends);
	}
					
	void ForTest()
	{
		isLoggedIn = true;
		//userId = "indra001";
		firstname = "hello";
		lastname = "hell";
		//PlayerPrefs.SetString("CurrentUserId",userId);
		PlayerPrefs.SetString("Firstname",firstname);
		PlayerPrefs.SetString("Lastname",lastname);
		Debug.Log ("for test...");
		GetFacebookUserId();
	}
	
	 bool isLoggedIn;
	 public void _RegisterNew()
	 {
			isLoggedIn = FacebookBinding.isSessionValid();
			if(isLoggedIn)
		    {
			Facebook.instance.getMe( ( error, result ) =>
			                        {
				// if we have an error we dont proceed any further
				if( error != null )
					return;
				
				if( result == null )
					return;
				
					// grab the userId and persist it for later use
					//var ht = obj as Hashtable;
				string user_Id = result.id;

				Debug.Log("FB Result :" + result);

				PlayerPrefs.SetString("CurrentUserId",user_Id);
				Debug.Log( "Graph Request finished: "+user_Id);
				});
			}
			else
			{
			//Debug.Log("hi2");
			     var permissions = new string[] { "user_games_activity" };
				FacebookBinding.loginWithReadPermissions( permissions );  
			}
	 }
	
	  void GetFacebookUserId()		
	  {
				if(PlayerPrefs.GetString("CurrentUserId") != "")
				{	
					Debug.Log("UseridforLogin :" + PlayerPrefs.GetString("CurrentUserId"));	
			            scr_SfsRemoteInit.PercentageCalc = scr_SfsRemoteInit.ReturnRandomNumber(10,15);
			Debug.Log( "After PercentageCalc");
						scr_SfsRemoteInit.percentageText.GetComponent<SpriteText>().Text = scr_SfsRemoteInit.PercentageCalc.ToString() + "%";
			Debug.Log( "After percentageText");
				     	scr_SfsRemoteInit.SmartfxConnection(PlayerPrefs.GetString("CurrentUserId"));
			Debug.Log( "After SmartfxConnection");
				}
			
	}
	
	//sabarish
	public void OnPlayButtonClick() {
		AdBinding.destroyAdBanner();
//	    scr_btnClick.Play();
		Debug.Log("INSIDE PLAY BUTTON");
		//sabarish
		if(scr_SfsRemoteInit.sfs == null) {
			Debug.Log("NULL ");
			disonnectedBeforePlayButtonClick = true;
			scr_SfsRemoteInit.SmartfoxReconnection();
			return;
		} else {
			//sabarish
			Debug.Log("NOT NULL");
			if(!scr_SfsRemoteInit.sfs.IsConnected) {
				Debug.Log("NOT CONNECTED");
				disonnectedBeforePlayButtonClick = true;
				scr_SfsRemoteInit.SmartfoxReconnection();
				return;
			}
		}

		disonnectedBeforePlayButtonClick = false;

		//	Debug.Log("11111");
		if(!IsClicked  && !mainMenu.disablePlaygame && scr_SfsRemoteInit.isNetworkConnected)
		{
			//Debug.Log("11111");
		    if(!mainMenu.isalreadyloggedIn)
		    {	

				if(Application.isEditor)
					ForTest();
				else
					GetFacebookUserId(); // change



				Debug.Log(" is click disable play game 00001111");

				
				
				scr_SfsRemoteInit.percentageText.active = true;	
	           scr_SfsRemoteInit.PercentageCalc = scr_SfsRemoteInit.ReturnRandomNumber(5,10);
		       //Debug.Log("Percentage % " + scr_SfsRemoteInit. PercentageCalc ); 
		        scr_SfsRemoteInit.percentageText.GetComponent<SpriteText>().Text = scr_SfsRemoteInit.PercentageCalc.ToString() + "%";	
//				Debug.Log("my step 01...");
				
	        }
	        else
	        {
				//Debug.Log("3333");
				scr_SfsRemoteInit.percentageText.active = true;	
				scr_SfsRemoteInit.PercentageCalc = scr_SfsRemoteInit.ReturnRandomNumber(40,45);
	            PlayerPrefs.SetInt("Percentage",scr_SfsRemoteInit.PercentageCalc);
	                  //Debug.Log("Percentage % " + PercentageCalc ); 
	            scr_SfsRemoteInit.percentageText.GetComponent<SpriteText>().Text = scr_SfsRemoteInit.PercentageCalc.ToString() + "%";	
					
				scr_SfsRemoteInit.sfs.RemoveAllEventListeners();
				Application.LoadLevel("game");
	        }
	
			IsClicked = true;
			loadingBool = true;
			loadingMainMenu = true;
			
			//Debug.Log("my step 02...");
			if(scr_Bg != null)
			{
				//Debug.Log("my step 03...");
				scr_Bg.Stop();
				//Debug.Log("my step 04...");
			}
		}
		

	}

	private void RetrieveFacebookUserId() {
		Debug.Log ("RetrieveFacebookUserId");
		
		if (FacebookBinding.isSessionValid ()) {
			Debug.Log ("Session Valid");	
			Facebook.instance.getMe (( error, result ) => {
				
				Debug.Log ("ERROR");
				// if we have an error we dont proceed any further
				if (error != null) {
					return;
				}
				
				Debug.Log ("RESULT");
				
				if (result == null) {
					return;
				}
				
				Debug.Log ("FINE");
				
				// grab the userId and persist it for later use
				//var ht = obj as Hashtable;
				Debug.Log ("FB Id :" + result.id);
				
				PlayerPrefs.SetString ("CurrentUserId", result.id);
				Debug.Log ("Graph Request finished: " + result.id);
			});
		} else {
			Debug.Log("Not Logged in");
		}
		
	}


}
