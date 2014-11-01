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
//using JsonFx.Json;


public class SfsConnect : MonoBehaviour {
	
	//Variable declaration
	//public string ServerIp = "192.168.2.39";
	public string ServerIp = "208.87.122.200";
	public int ServerPort = 9933;
	public string Zone = "BasicExamples";
	//public string Zone = "Test";
	public string RoomName = "The Lobby";
	public string username = "";
	public bool IsConnectedToSrv = false;
	SmartFox sfs;
	//LoadGameObjects scr_loadGameObj;
    GameManager scr_gameManager;
	
	// Use this for initialization
	void Start () {
	
		Debug.Log ("sfs connect...");
		if (Application.isWebPlayer||Application.isEditor) {
			if (!Security.PrefetchSocketPolicy(ServerIp, ServerPort, 500)) {
				Debug.LogError("Security Exception. Policy file load failed!");
			}
		}	
		
		
		sfs = new SmartFox();
		sfs.ThreadSafeMode = true;
		
		sfs.AddEventListener(SFSEvent.CONNECTION,OnConnection);
		sfs.AddEventListener(SFSEvent.LOGIN,OnLogin);
		sfs.AddEventListener(SFSEvent.LOGIN_ERROR,OnLoginError);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN,OnJoinRoom);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR,OnJoinRoomError);
		//sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,OnExtensionResponseForGetData);		
		//sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,OnExtensionResponseForSrvTime);
		sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE,OnExtensionResponseForGetGameObj);
		sfs.Connect(ServerIp,ServerPort);
		
		//scr_loadGameObj = GameObject.Find("GameLoadfrmSvr").GetComponent<LoadGameObjects>();
		scr_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	//OnLogin to Server
	void OnLogin(BaseEvent e)
	{
		Debug.Log("Loggen In" + e.Params["user"]);
		
		//sfs.Send(new JoinRoomRequest(RoomName));		
		//GetServerTime();
		//SendDataSvr();
		//SendReq();
		
		//SendRequestforGameObjects(5);
		
		
	}
	
	void OnJoinRoom(BaseEvent e)
	{
		Debug.Log("Joined Room" + e.Params["room"]);
	}
	
	void OnJoinRoomError(BaseEvent e)
	{
		Debug.Log("Error " +e.Params["errorCode"] + " | :" + e.Params["errorMessage"]);
	}
	
	void OnLoginError(BaseEvent e)
	{
		Debug.Log("Loggin error:" + e.Params["errorCode"] + "| :" + e.Params["errorMessage"]);
	}
	
	
	//OnConnected to Server
	void OnConnection(BaseEvent e)
	{
		if((bool)e.Params["success"])
		{
			Debug.Log("Success fully connected");
			sfs.Send(new LoginRequest(username,"",Zone));	
	
		}
		else
		{
			Debug.Log("Connection failed");
		}
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		sfs.ProcessEvents();
		
		//GetServerTime();
	
		//SendClientTime();
	}
	
	
	void OnApplicationQuit()
	{
		if(sfs.IsConnected)
		{
			sfs.Disconnect();
		}
	}
	
	
	void OnExtensionResponse(BaseEvent e)
	{
		string cmd = (string)e.Params["cmd"];
		ISFSObject objin= (SFSObject)e.Params["params"];
		
		if(cmd =="SumNumbers")
		{
			Debug.Log("Sum :" + objin.GetInt("NumC"));
			num = objin.GetInt("NumC").ToString();
		}
	}
	
	void OnExtensionResponseForGetData(BaseEvent e)
	{
		string cm = (string)e.Params["cmd"];
		ISFSObject obj = (SFSObject)e.Params["params"];
		ISFSArray arr = obj.GetSFSArray("hw_tb_gameobj_usrplaced");
		
	    if(cm == "getData")
		{
			for(int i=0; i<arr.Size(); i++)
			{
				ISFSObject o = arr.GetSFSObject(i);
				int id = o.GetInt("gameobject_id");
				string pos = o.GetUtfString("position");
				string rot = o.GetUtfString("rotation");
				
				Debug.Log("gameobject id :" + o.GetInt("gameobject_id"));
				Debug.Log("position :" + o.GetUtfString("position"));
				Debug.Log("rotation :" + o.GetUtfString("rotation"));
				
				//scr_loadGameObj.PlaceObjects(id,pos,rot);
			}
		}
	}
	
	void OnExtensionResponseForGetGameObj(BaseEvent e)
	{
		string cd = (string)e.Params["cmd"];
		ISFSObject ob = (SFSObject)e.Params["params"];
		ISFSArray arr = ob.GetSFSArray("hw_tb_gameobjects");
	   
		if(cd == "getGameObjData")
		{
			for(int i=0; i< arr.Size(); i++)
			{
				ISFSObject obj = arr.GetSFSObject(i);
//				Debug.Log("gameobjId :" + obj.GetInt("gameobject_id"));
//				Debug.Log("name :" + obj.GetUtfString("name"));
//				Debug.Log("upgrade_level :" + obj.GetInt("upgrade_level"));
//				Debug.Log("type :" + obj.GetUtfString("type"));
//				Debug.Log("resource_generator :" + obj.GetUtfString("resource_generator"));
//				Debug.Log("currentlevel :" + obj.GetInt("currentlevel"));
//				Debug.Log("cost_gold :" + obj.GetInt("cost_gold"));
//				Debug.Log("manual_adjustment :" + obj.GetInt("manual_adjustment"));
//				Debug.Log("gold_totalcost :"+ obj.GetInt("gold_totalcost"));
//				Debug.Log("spark_cost :" + obj.GetInt("spark_cost"));
//				Debug.Log("sellable :" + obj.GetInt("sellable"));
//				Debug.Log("gameobj_xp_earned :" + obj.GetInt("gameobj_xp_earned"));
//				Debug.Log("time_create :" + obj.GetInt("time_create"));
//				Debug.Log("max_totalcreations :" + obj.GetInt("max_totalcreations"));
//				Debug.Log("sellvalue :" + obj.GetInt("sellvalue"));
					
			//	scr_gameManager.AssignValuesFrmSrv(obj.GetUtfString("name"),obj.GetUtfString("type"),obj.GetUtfString("resource_generator"),
					                            //  obj.GetInt("currentlevel"), obj.GetInt("cost_gold"),obj.GetInt("manual_adjustment"),obj.GetInt("gold_totalcost"),
					                            //  obj.GetInt("spark_cost"),obj.GetInt("sellable"),obj.GetInt("sellvalue"),obj.GetInt("gameobj_xp_earned"),
					                            //  obj.GetInt("time_create"),obj.GetInt("max_totalcreations"));
					                              
			}
		}
	}
	
	
	
	public DateTime srvTym;
	void OnExtensionResponseForSrvTime(BaseEvent e)
	{
		string cmd = (string)e.Params["cmd"];
		ISFSObject obj = (SFSObject)e.Params["params"];
		
		if(cmd == "SendSvrTime")
		{
			//Debug.Log("ServerTime is: " +obj.GetUtfString("SvrTime"));
			//DateTime srvTym = new DateTime();
			srvTym = Convert.ToDateTime(obj.GetUtfString("SvrTime"));
///***			Debug.Log("Server Time is " + srvTym);
			IsConnectedToSrv = true;
		}
		
	}
	
	void SendReq()
	{
		try {
			
		    ISFSObject o = new SFSObject();
			ExtensionRequest r = new ExtensionRequest("getData",o);
			sfs.Send(r);
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
	}
	
	
	public void SendRequestforGameObjects(int objectId)
	{
		try
		{
			ISFSObject o = new SFSObject();
			o.PutInt("GameObjID",objectId);
			
			ExtensionRequest r = new ExtensionRequest("getGameObjData",o);
			sfs.Send(r);
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
	}
	
	void GetServerTime()
	{
		try
		{
			ISFSObject o = new SFSObject();
			ExtensionRequest r = new ExtensionRequest("SendSvrTime",o);
			sfs.Send(r);
			
		}
		catch(Exception e)
		{
			Debug.Log(e);
			IsConnectedToSrv = false;
		}
		
		//Debug.Log(IsConnectedToSrv);
	}
	
	//Send data to the server
	void SendDataSvr()
	{
		try
		{
			ISFSObject obj = new SFSObject();
			obj.PutInt("NumA", 45);
	        obj.PutInt("NumB", 64);
			
			ExtensionRequest req = new ExtensionRequest("SumNumbers",obj);
			sfs.Send(req);
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
	}
	
	void SendClientTime()
	{
		try
		{
			ISFSObject o = new SFSObject();
			o.PutUtfString("ObjectTime",srvTym.ToString());
			
			ExtensionRequest r = new ExtensionRequest("SendPush",o);
			sfs.Send(r);
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
	}
	
	
	string num="";
	void OnGUI()
	{
		if(GUI.Button(new Rect(30,250,100,50),"Send"))
		{
			//SendDataSvr();
			GetServerTime();
		}
		
		//GUI.TextField(new Rect(50,150,50,50), num);
	}
	
	
}
