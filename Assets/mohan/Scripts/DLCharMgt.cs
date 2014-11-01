using UnityEngine;
using System.Collections;

public class DLCharMgt : MonoBehaviour 
{
	public int DlTimer;
	private GameObject dir;
	private GameObject dirt;
	private DarklingPath dp;
	public GameObject[] Ddirlen;
	public Camera MainGameCam;
	public AudioController scr_audioController;
	
	void Start () 
	{
		InvokeRepeating("DLChar", float.Epsilon, 1f);
		dp = (DarklingPath)FindObjectOfType(typeof(DarklingPath));
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	void DLChar()
	{
		if(dir != null)
		{
			DlTimer++;
		}
	}
	
	private bool isPlay ;
	void PlayDLcharSound()
	{
		isPlay = false;
		scr_audioController.audio_darklingChar_touch.Play();
		scr_audioController.audio_darklingChar_touch.transform.position = dirt.transform.position;
		scr_audioController.audio_darklingChar_touch.minDistance = 1;
		scr_audioController.audio_darklingChar_touch.maxDistance = 30;
	}
	
	void Update () 
	{
		
	    	if(DlTimer == 300)
			{
				isPlay = true;
			}
		
		dir =  GameObject.Find("DL_D_DDirtPath_GO(Clone)");
		dirt = GameObject.Find("DLCharacter(Clone)");
		
		if(MainGameCam == null)
		{
			MainGameCam = GameObject.Find("Main Camera").camera ;
		}
		
		int i = Ddirlen.Length;
		
		if(i<3)
		{
			Ddirlen =  GameObject.FindGameObjectsWithTag("DLwaypoint");
			if(DlTimer >0 && DlTimer <5)
			{
				dirt.gameObject.transform.GetComponent<DarklingPath>().enabled = false;
				dp.DLCharacterFrontIdle.gameObject.active = true;
				dp.DLCharacterFrontIdle.gameObject.renderer.enabled = true;
				dp.DLCharacterBackWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterFrontWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterRightWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterLeftWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterFrontAction01.gameObject.renderer.enabled = false;
			}
			else
			{
				DlTimer = 0;
			}
		}
		else
		{
			if(DlTimer >0 && DlTimer <300)
			{
			dirt.gameObject.transform.GetComponent<DarklingPath>().enabled = true;
		}
			else if(DlTimer >=300 && DlTimer <302)
			{
				
			    	 if(isPlay)
					{
						PlayDLcharSound();
					}
				
				dirt.gameObject.transform.GetComponent<DarklingPath>().enabled = false;
				dp.DLCharacterFrontIdle.gameObject.active = false;
				dp.DLCharacterFrontIdle.gameObject.renderer.enabled = false;
				dp.DLCharacterBackWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterFrontWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterRightWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterLeftWalk.gameObject.renderer.enabled = false;
				dp.DLCharacterFrontAction01.gameObject.renderer.enabled = true;
			}
			else
			{
				dp.DLCharacterFrontIdle.gameObject.active = false;
				dp.DLCharacterFrontAction01.gameObject.renderer.enabled = false;
				DlTimer = 0;
			}
		}
		if(Input.GetMouseButton(0))
		{
			Ray ray = MainGameCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, 100)) 
			{
				if(hit.transform.gameObject.tag == "dlcharacter")
				{
					DlTimer = 300;
				}
			}
		}
	}
}
