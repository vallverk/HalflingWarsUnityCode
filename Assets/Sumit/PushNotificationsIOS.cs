using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

public class PushNotificationsIOS : MonoBehaviour {
	
	
	
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void setListenerName(string listenerName);

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public System.IntPtr _getPushToken();
	
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void setIntTag(string tagName, int tagValue);

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void setStringTag(string tagName, string tagValue);
	
	
	public static string load = null;
	public static bool pushNotificationForFight = false;
	
	private SfsRemoteInit remoteInit;
	
	// Use this for initialization
	void Start () {

		Debug.Log ("Push Notifications IOS...");
		remoteInit = (SfsRemoteInit)FindObjectOfType(typeof(SfsRemoteInit));
		
		setListenerName(this.gameObject.name);
		DontDestroyOnLoad(this.gameObject);
	}

	
	static public string getPushToken()
	{
		return Marshal.PtrToStringAnsi(_getPushToken());
	}

	void onRegisteredForPushNotifications(string token)
	{
		//do handling here
		Debug.Log("token : "+token);
		remoteInit.takeDeviceToken(token);
	}

	void onFailedToRegisteredForPushNotifications(string error)
	{
		//do handling here
		Debug.Log(error);
	}

	void onPushNotificationsReceived(string payload)
	{
		//do handling here
		Debug.Log(payload);
		
		if(payload.Contains("battleId"))
		{
			load = payload;
			pushNotificationForFight = true;
		}
		
	}
	
	
}
