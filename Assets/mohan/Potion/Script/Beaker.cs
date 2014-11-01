using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Beaker : MonoBehaviour {
	
	public Herb[] inputHerbs;
	public Potion[] outcomePotions;
	public Potion none;
	public static GameObjectsSvr scr_gameObjectSvr;
	public static SfsRemote scr_sfsRemote;
	
	public static int herbCount = 0;
	
	public GameObject fire;
	
	static Beaker instance;
	
	public static bool isgotHerbs,isgotPotion;
	
	public static List<int> lst_HerbsSelected = new List<int>();
	
	public AudioController scr_audioController;
	
	void Awake()
	{
		scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	void Start () 
	{
		instance = this;
		instance.inputHerbs = new Herb[4];
	}
	
	
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		
	}
	
	public void FillHerb(Herb herb)
	{
		inputHerbs[herbCount] = herb;
		herbCount ++;
			
		if(herbCount == 2)
		{
			if(fire)
				fire.active = true;
			transform.position = new Vector3(1.37f,3.62f,0.7f);
			transform.eulerAngles = new Vector3(0,180,0);
			PlayFire();
		}
	}
	
	public static Potion GetPotion()
	{
		List<Potion> pos = new List<Potion>();
		foreach(Potion p in instance.outcomePotions) {
			if(p.hrbsRequired.Length == herbCount)
				pos.Add(p);
		}
		string[] names_potions = new string[herbCount];
		string[] names = new string[herbCount];
		
		for(int i = 0 ; i < herbCount ; i++) {
			names[i] = instance.inputHerbs[i].name;
///***			Debug.Log("in-"+names[i]);
			
///***			Debug.Log("TypeId :" +  GetHerbsTypeId(names[i]));
			
			if(lst_HerbsSelected.Count <= 4)
			{
			 lst_HerbsSelected.Add(GetHerbsTypeId(names[i]));
			 Beaker.isgotHerbs = true; 	
			}	
			
		}
		Array.Sort(names);
		
		for(int i = 0 ; i < pos.Count ; i++) {
			for(int j = 0 ; j < herbCount ; j++){ 
				names_potions[j] = pos[i].hrbsRequired[j].name;
///***				Debug.Log("pos-"+names_potions[j]);
			}
			Array.Sort(names_potions);
			for(int j = 0 ; j  < herbCount ; j ++) {
///***				Debug.Log(names[j] + ":" + names_potions[j]);
				if(names[j] == names_potions[j]) {
					if(j == herbCount -1)
						return pos[i];
					continue;
				}
				else
					break;
			}
		}
		if(Beaker.herbCount > 1)
		{
			instance.none.hrbsRequired = new Herb[herbCount];
			for(int i = 0 ; i < herbCount ; i++)
				instance.none.hrbsRequired[i] = instance.inputHerbs[i];
			return instance.none;
		}
		else
			return null;
	}
	
	
	//Harish chander ...
	
	
	void PlayFire()
	{
		scr_audioController.audio_potionFire.Play();
		scr_audioController.audio_potionFire.minDistance = 1;
		scr_audioController.audio_potionFire.maxDistance = 300;
		scr_audioController.audio_potionFire.loop = true;
		scr_audioController.audio_potionFire.volume = 1f;	
	}
	
	private static int herbTypeId;
	public static int GetHerbsTypeId(string herbName)
	{
		switch(herbName)
		{
		case "Costmary":
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objCostmaryherb.objTypeId;
			
			break;
			
		case "Fairylily":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objFairyLilly.objTypeId;
			
			break;
			
		case "mandrake":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objMandrake.objTypeId;
			
			break;
			
		case "pipeweed":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objPipeweed.objTypeId;
			
			break;
			
		case "Sunflower":
			
			Beaker.herbTypeId =  Beaker.scr_gameObjectSvr.objSunflower.objTypeId;
				
				break;
		
		case "vervain":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objVervainHerb.objTypeId;
			
			break;
			
		case "Watercress":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objWatercress.objTypeId;
			
			break;
			
		case "aven":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingAvenHerb.objTypeId;
			
			break;
			
		case "bitterbrush":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingBitterbush.objTypeId;
			
			break;
			
		case "bogbean":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingHerbBogbean.objTypeId;
				
		    break;
			
		case "columbine":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingColumbine.objTypeId;
			
			break;
			
		case "moonflower":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingMoonFlower.objTypeId;
			
			break;
			
		case "wolfbane":
			
			Beaker.herbTypeId = Beaker.scr_gameObjectSvr.objDarklingHerbWolfbane.objTypeId;
			
			break;
			
		}
		
		
		return Beaker.herbTypeId;
	}
}
