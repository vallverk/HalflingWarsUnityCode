using UnityEngine;
using System.Collections;

public class dayNightTime : MonoBehaviour 
{
	public SfsRemote scr_sfsRemote;
	public int dnCnt = 0;
	public GUIText dayNightTimeRemainTxt;
	
	
	// Use this for initialization
	void Start () 
	{
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		StartCoroutine(dayNightCnt());
		scr_sfsRemote.SendrequestforDayNightStatus();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if(dnCnt == 1)
		{
			//scr_sfsRemote.SendRequestforUserRegis(PlayerPrefs.GetString("CurrentUserId"),PlayerPrefs.GetString("Hwid"));
			scr_sfsRemote.SendrequestforDayNightStatus();
		}
	}
	
	IEnumerator dayNightCnt()
    {
		//if (progressBarPov.gameObject == null)
		//	return;
		
        while(true)
        {
			dnCnt--;
        	yield return new WaitForSeconds(1);
		}
        
    }
	
//	void OnGUI()
//	{
//		dayNightTimeRemainTxt.text = dnCnt.ToString();
//	}
}
