using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	
	public AudioSource audio_hl;
	public AudioSource audio_dl;
	public AudioSource audio_River;
	public AudioSource audio_DLswamp;
	public AudioSource audio_storyScreen;
	public AudioSource audio_Quest;
	
	
	public AudioSource audio_darkhound;
	public AudioSource audio_fenrir;
	public AudioSource audio_hellhound;
	public AudioSource audio_barg;
	public AudioSource audio_cusith;
	public AudioSource audio_hound;
	public AudioSource audio_Djinn;
	public AudioSource audio_imp;
	public AudioSource audio_sprite;
	public AudioSource audio_dryad;
	public AudioSource audio_nymph;
	public AudioSource audio_sprout;
	public AudioSource audio_leech;
	public AudioSource audio_leshy;
	public AudioSource audio_lurker;
	public AudioSource audio_dragon;
	public AudioSource audio_draugh;
	public AudioSource audio_nix;
	
	
	public AudioSource audio_Apothecary;
	public AudioSource audio_Blacksmith;
	public AudioSource audio_Darklinghouse;
	public AudioSource audio_Halfinghouse;
	public AudioSource audio_Inn;
	public AudioSource audio_Scaffolding;
	public AudioSource audio_stables;
	public AudioSource audio_tavern;
	
	
	public AudioSource audio_sparkEarth;
	public AudioSource audio_sparkFire;
	public AudioSource audio_sparkPlant;
	public AudioSource audio_sparkSwamp;
	public AudioSource audio_sparkWater;
	
	
	public AudioSource audio_potionBubbles;
	public AudioSource audio_potionFire;
	public AudioSource audio_potionStirring;
	public AudioSource audio_tavernMugfill;
	public AudioSource audio_tavernMugslide;
	public AudioSource audio_tavernPouring;

	public AudioSource audio_PotionTheme;
	public AudioSource audio_DrinkingTheme;

	
	public AudioSource audio_plantCrop;
	public AudioSource audio_harvestCrop;
	
	public AudioSource audio_FireCracker;
	public AudioSource audio_applaud;
	
	public AudioSource audio_GoldBtn;
	public AudioSource audio_RabbitBtn;
	
	public AudioSource audio_wizardMaster;
	public AudioSource audio_halflingChar_touch;
	public AudioSource audio_darklingChar_touch;
	
	public AudioSource audio_Swordclash;
	
	public Camera cameraforAudio;
	private bool enableHl,enableDl;
	
	public AudioSource audio_buttonClick;
	public AudioSource audio_achievement;
	
	public static bool EnableEnviron;
	
	public AudioSource audio_morph,audio_feed,audio_sparkBirth;
	public AudioSource audio_Goblincave,audio_TrollCave,audio_Orgcave;
	
	public AudioSource audio_nightHL;
	
	
	public popUpInformation scr_popupInfo;
	public SfsRemote scr_sfsRemote;
	
	// Use this for initialization
	void Start () {
		
	 //  audio_hl = GameObject.Find("Audio").transform.FindChild("AudioHL").GetComponent<AudioSource>();
	//	audio_dl = GameObject.Find("Audio").transform.FindChild("AudioDL").GetComponent<AudioSource>();
	//	audio_River = GameObject.Find("Audio").transform.FindChild("AudioRiver").GetComponent<AudioSource>();
	//	audio_DLswamp = GameObject.Find("Audio").transform.FindChild("AudioDLswamp").GetComponent<AudioSource>();
	//	audio_storyScreen = GameObject.Find("Audio").transform.FindChild("AudioStoryScreen").GetComponent<AudioSource>();
	//	audio_Quest = GameObject.Find("Audio").transform.FindChild("AudioQuest").GetComponent<AudioSource>();
		
		if(Application.loadedLevel == 1)
		{
			scr_popupInfo = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
			scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		 //Debug.Log("State >>>>>>>>>> :" + scr_sfsRemote.state);
		//if(SfsRemote.startSounds)
		{
		
			if(cameraforAudio.transform.position.x < 0 && cameraforAudio.transform.position.x > -110f)
			{
				enableHl = true;
				enableDl = false;
			}
			else if(cameraforAudio.transform.position.x > 0 && cameraforAudio.transform.position.x < 110f)
			{
				enableDl = true;
				enableHl = false;
			}
			
			
			if(AudioController.EnableEnviron)
			{
		    	ShiftAudio();
				ShiftWaterTgAudio(cameraforAudio.transform.position);
				ShiftScaffoldingSound(cameraforAudio.transform.position,audio_Scaffolding.transform.position);
				ShiftSparkBirthSound(cameraforAudio.transform.position,audio_sparkBirth.transform.position,audio_sparkBirth);
			}
			else 
			{
				if(audio_dl.isPlaying)
				{
					audio_dl.Stop();
				}
				
				if(audio_hl.isPlaying)
				{
					audio_hl.Stop();
				}
				
				if(audio_nightHL.isPlaying)
				{
					audio_nightHL.Stop();
				}
				
				if(audio_River.isPlaying)
				{
					audio_River.Stop();
				}
				
				if(audio_DLswamp.isPlaying)
				{
					audio_DLswamp.Stop();
				}
			}
			}
		}
	
	
	private float Scaffdis;
	void ShiftScaffoldingSound(Vector3 camPos,Vector3 scaffPos)
	{
//		Scaffdis = camPos.x;
//		
//		if(Scaffdis > -80f && Scaffdis < -20f)
//		{
//			audio_Scaffolding.volume = 0.8f;
//		}
//		else
//		{
//			audio_Scaffolding.volume = 0.2f;
//		}
		
		float dis = Vector3.Distance(camPos,scaffPos);
		//Debug.Log("Dis :" + dis);
		
		if(audio_Scaffolding.isPlaying)
		{
			if(dis >= 40 && dis <= 46)
		{
				audio_Scaffolding.volume = 0.7f;
		}
		else
		{
			audio_Scaffolding.volume = 0.2f;
		}
		
	}
	
	}
	
	private float BirthDis;
	void ShiftSparkBirthSound(Vector3 camPos,Vector3 Birthpos,AudioSource audio)
	{
		float BirthDis = Vector3.Distance(camPos,Birthpos);
		//Debug.Log("Dis :" + dis);
		
		if(audio.isPlaying)
		{
			if(BirthDis >= 40 && BirthDis <= 46)
			{
				audio.volume = 0.7f;
			}
			else
			{
				audio.volume = 0.1f;
			}
		}
	}
	
	
	private float dis;
	void ShiftWaterTgAudio(Vector3 camPos)
	{
		dis = camPos.x;
		
		if(dis > -130f && dis < -90f)
		{
			audio_River.volume = 0.9f;
		}
		else if(dis > -90f && dis < -70f)
		{
			audio_River.volume = 0.4f;
		}
		else if(dis > -70f)
		{
			audio_River.volume = 0.1f;
		}
		
		
		//Debug.Log("Dis >>>"+ Vector3.Distance(camPos,audio_River.transform.position));
		
	}
	
	void ShiftAudio()
	{
		if(enableHl)
		{
			//enable hl
			
			if(scr_sfsRemote.state != "NIGHT")
			{
				if(audio_hl != null && !audio_hl.isPlaying)
				{
					audio_hl.Play();
					
					 if(audio_nightHL.isPlaying)
					 {
						audio_nightHL.Stop();
					 }
				}
			}
			else
			{
				if(audio_nightHL != null && !audio_nightHL.isPlaying)
				{
				    audio_nightHL.Play();
					
					 if(audio_hl.isPlaying)
					 {
						audio_hl.Stop();
					 }
				}
			}
			
			if(audio_dl != null && audio_dl.isPlaying)
			  audio_dl.Stop();
			
			
//           if(audio_Scaffolding != null && !audio_Scaffolding.isPlaying)
//			{	
//				if(scr_popupInfo.fp.Darking_Front_Hammer)
//				{
//					audio_Scaffolding.transform.position = scr_popupInfo.fp.transform.position;
//					audio_Scaffolding.Play();
//					audio_Scaffolding.loop = true;
//					audio_Scaffolding.volume = 0.8f;
//					audio_Scaffolding.minDistance = 1;
//					audio_Scaffolding.maxDistance = 10;
//				}
//			}
			
			
			
//            if(audio_Scaffolding != null && audio_Scaffolding.isPlaying)
//			{	
//				if(scr_popupInfo.fp.Halfing_Front_Hammer)
//				{
//			       audio_Scaffolding.Stop();
//				}
//			}
			
			
			if(audio_DLswamp != null && audio_DLswamp.isPlaying)
				audio_DLswamp.Stop();
			
				
			if(audio_River != null && !audio_River.isPlaying)
			{
				audio_River.Play();
				audio_River.loop = true;
				audio_River.volume = 0.4f;
				audio_River.minDistance = 2;
				audio_River.maxDistance = 30;
			}
			
			
		}
		else if(enableDl) 
		{
			//enable dl
			if(audio_dl != null && !audio_dl.isPlaying)
			audio_dl.Play();
			
			if(audio_hl != null && audio_hl.isPlaying)
			audio_hl.Stop();
			
			if(audio_nightHL != null && audio_nightHL.isPlaying)
				audio_nightHL.Stop();
			
			if(audio_River != null && audio_River.isPlaying)
				audio_River.Stop();
			
			
//            if(audio_Scaffolding != null && audio_Scaffolding.isPlaying)
//			{		
//			   if(scr_popupInfo.fp.Halfing_Front_Hammer)
//				{
//			      audio_Scaffolding.Stop();
//				}
//			}
			
			
//			if(audio_Scaffolding != null && !audio_Scaffolding.isPlaying)
//			{	
//				if(scr_popupInfo.fp.Darking_Front_Hammer)
//				{
//					audio_Scaffolding.transform.position = scr_popupInfo.fp.transform.position;
//					audio_Scaffolding.Play();
//					audio_Scaffolding.loop = true;
//					audio_Scaffolding.volume = 0.8f;
//					audio_Scaffolding.minDistance = 1;
//					audio_Scaffolding.maxDistance = 10;
//				}
//			}
			
			if(audio_DLswamp != null && !audio_DLswamp.isPlaying)
			{
				audio_DLswamp.Play();
				audio_DLswamp.loop = true;
				audio_DLswamp.volume = 0.4f;
				audio_DLswamp.minDistance = 2;
				audio_DLswamp.maxDistance = 30;
			}
			
		}
	}
	
	
	void disableAudio()
	{
	  
	}
	
}
