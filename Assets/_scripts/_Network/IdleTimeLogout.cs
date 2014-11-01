using UnityEngine;
using System.Collections;
using System;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;
using System.Runtime;


public class IdleTimeLogout : MonoBehaviour {
	
	
	private int curTime = 0;
	private float oldTime = 0;
	private SfsRemote scr_remote;
	
	// Use this for initialization
	void Start () {
	
		scr_remote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		
		oldTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(scr_remote.isIdleCounttimer)
		{
		  checkIdleState();
		}
	
	}
	
	
	IEnumerator RedirectMainmenu()
	{
		yield return new WaitForSeconds(0.2f);
		
		if(scr_remote.isalreadyloggedin) 
		{
			PlayerPrefs.SetString("isalreadyloggedIn","false");
		}
		
		scr_remote.sfs.Send(new LogoutRequest());
		scr_remote.sfs.RemoveAllEventListeners();
		Application.LoadLevel("MainMenu");
	}
	
	
	void checkIdleState()
	{
		curTime = (int)(Time.time - oldTime);
		//Debug.Log(curTime);
		if (Input.GetMouseButtonDown(0))
		{
			oldTime = Time.time;
		}
		
		if (curTime > 3600f)
		{
			scr_remote.isIdleCounttimer = false;
			StartCoroutine("RedirectMainmenu");
		}
	}
}
