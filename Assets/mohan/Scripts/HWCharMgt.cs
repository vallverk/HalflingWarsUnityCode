using UnityEngine;
using System.Collections;

public class HWCharMgt : MonoBehaviour 
{
	public int HwTimer;
	private GameObject dir;
	private GameObject dirt;
	public GameObject[] dirlen;
	private HalflingPath hp;
	public Camera MainGameCam;
	public AudioController scr_audioController;
	
	void Start () 
	{
		InvokeRepeating("HWChar", float.Epsilon, 1f);
		hp = (HalflingPath)FindObjectOfType(typeof(HalflingPath));
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	void HWChar()
	{
		if(dir != null)
		{
			HwTimer++;
		}
	}
	
	
	private bool isPlay ;
	void PlayHWcharSound()
	{
		isPlay = false;
		scr_audioController.audio_halflingChar_touch.Play();
		scr_audioController.audio_halflingChar_touch.transform.position = dirt.transform.position;
		scr_audioController.audio_halflingChar_touch.minDistance = 1;
		scr_audioController.audio_halflingChar_touch.maxDistance = 30;
	}
	
	void Update () 
	{
		
		if(HwTimer == 300)
		{
			isPlay = true;
		}
		
		
		dir =  GameObject.Find("HC_D_DirtPath_GO(Clone)");
		dirt = GameObject.Find("HWCharacter(Clone)");
		
		if(MainGameCam == null)
		{
			MainGameCam = GameObject.Find("Main Camera").camera ;
		}
		
		int i = dirlen.Length;
	
		if(i<3)
		{
			dirlen =  GameObject.FindGameObjectsWithTag("HWwaypoint");
			if(HwTimer >0 && HwTimer <600)
			{
				dirt.gameObject.transform.GetComponent<HalflingPath>().enabled = false;
				hp.HWCharacterFrontIdle.gameObject.active = true;
				hp.HWCharacterFrontIdle.gameObject.renderer.enabled = true;
				hp.HWCharacterBackWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterFrontWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterRightWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterLeftWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterFrontAction01.gameObject.renderer.enabled = false;
			}
			else
			{
				HwTimer = 0;
			}
		}
		else
		{
			if(HwTimer >0 && HwTimer <300)
			{
			dirt.gameObject.transform.GetComponent<HalflingPath>().enabled = true;
		}
			else if(HwTimer >=300 && HwTimer <302)
			{
				
				    if(isPlay)
					{
						PlayHWcharSound();
					}
				
				dirt.gameObject.transform.GetComponent<HalflingPath>().enabled = false;
				hp.HWCharacterFrontIdle.gameObject.active = false;
				hp.HWCharacterFrontIdle.gameObject.renderer.enabled = false;
				hp.HWCharacterBackWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterFrontWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterRightWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterLeftWalk.gameObject.renderer.enabled = false;
				hp.HWCharacterFrontAction01.gameObject.renderer.enabled = true;
			}
			else
			{
				hp.HWCharacterFrontIdle.gameObject.active = false;
				hp.HWCharacterFrontAction01.gameObject.renderer.enabled = false;
				HwTimer = 0;
			}
		}
		
		if(Input.GetMouseButton(0))
		{
			Ray ray = MainGameCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, 100)) 
			{
				if(hit.transform.gameObject.tag == "hlcharacter")
				{
					HwTimer = 300;
				}
			}
		}
	}
}
