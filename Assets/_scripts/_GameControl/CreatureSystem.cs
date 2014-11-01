using UnityEngine;
using System.Collections;
using System;

public class CreatureSystem : MonoBehaviour 
{
	public SpriteText feed_spText;
	public SpriteText morph_spText;
	public SpriteText cLevel_spText;
	
	public SpriteText habitatInfo_spText, info_spText, creatureName_spText, level_spText;
	
	public GameObject creatureImage;
	
	public popUpInformation popUpInfoScript;
	public guiControl guiControlInfo;
	//public GameManager gameManagerInfo;
	
	public GameObject feedPB;
	
	public Texture c_Hound, c_Barg, c_Cusith, c_Sprout, c_Nymph, c_Dryad, c_Nix, c_Draug, c_Dragon;
	public Texture c_DHound, c_Fenrir, c_HellHound, c_Sprite, c_Imp, c_Djinn, c_Leech, c_Leshy, c_Lurker;
	
	public GUIText gui_curLevel;
	public GUIText gui_maxLevel;
	public GUIText gui_startFeed;
	public GUIText gui_maxFeed;
	public GUIText gui_curFeed;
	public GUIText gui_nextFeed;
	public GUIText gui_feedIncreament;
	public GUIText gui_food;
	
	public class CreatureInfo
	{
		public string name = "";
		public int curLevel = 0;
		public int maxLevel = 0;
		public int maxFeed = 0;
		public int startFeed = 0;
		public float curFeed = 0;
		public float feedIncreament = 0;
		public int nextFeed = 0;
		public int sparkCost = 0;
	};
	
	public CreatureInfo hound = new CreatureInfo();
	public CreatureInfo barg = new CreatureInfo();
	public CreatureInfo cusith = new CreatureInfo();
	
	public CreatureInfo dHound = new CreatureInfo();
	public CreatureInfo fenrir = new CreatureInfo();
	public CreatureInfo hellHound = new CreatureInfo();
	
	public CreatureInfo sprite = new CreatureInfo();
	public CreatureInfo imp = new CreatureInfo();
	public CreatureInfo djinn = new CreatureInfo();
	
	public CreatureInfo sprout = new CreatureInfo();
	public CreatureInfo nymph = new CreatureInfo();
	public CreatureInfo dryad = new CreatureInfo();
	
	public CreatureInfo leech = new CreatureInfo();
	public CreatureInfo leshy = new CreatureInfo();
	public CreatureInfo lurker = new CreatureInfo();
	
	public CreatureInfo nix = new CreatureInfo();
	public CreatureInfo draug = new CreatureInfo();
	public CreatureInfo dragon = new CreatureInfo();
	
	private SfsRemote scr_sfsRemote;
	private GameObjectsSvr scr_gameObjectSvr;
	private LoadUserWorld scr_loadUserworld;
	private AudioController scr_audioController;
	
	void Awake()
	{
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_loadUserworld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_audioController  = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	// Use this for initialization
	void Start () 
	{
		/*
		hound.name = "Hound"; hound.curLevel = 1; hound.maxLevel = 15; hound.startFeed = 4; hound.maxFeed = 64; hound.curFeed = 1; hound.feedIncreament = 4; hound.nextFeed = 4; hound.sparkCost = 1;
		barg.name = "Barg"; barg.curLevel = 1; barg.maxLevel = 15; barg.startFeed = 4; barg.maxFeed = 2048; barg.curFeed = 1; barg.feedIncreament = 4; barg.nextFeed = 4; barg.sparkCost = 6;		
		cusith.name = "Cusith"; cusith.curLevel = 1; cusith.maxLevel = 15; cusith.startFeed = 4; cusith.maxFeed = 65536; cusith.curFeed = 1; cusith.feedIncreament = 4; cusith.nextFeed = 4; cusith.sparkCost = 12;
		
		sprout.name = "Sprout"; sprout.curLevel = 1; sprout.maxLevel = 15; sprout.startFeed = 8; sprout.maxFeed = 128; sprout.curFeed = 2; sprout.feedIncreament = 4; sprout.nextFeed = 8; sprout.sparkCost = 4;
		nymph.name = "Nymph"; nymph.curLevel = 1; nymph.maxLevel = 15; nymph.startFeed = 8; nymph.maxFeed = 4096; nymph.curFeed = 2; nymph.feedIncreament = 4; nymph.nextFeed = 8; nymph.sparkCost = 8;
		dryad.name = "Dryad"; dryad.curLevel = 1; dryad.maxLevel = 15; dryad.startFeed = 8; dryad.maxFeed = 131072; dryad.curFeed = 2; dryad.feedIncreament = 4; dryad.nextFeed = 8; dryad.sparkCost = 24;
		
		nix.name = "Nix"; nix.curLevel = 1; nix.maxLevel = 15; nix.startFeed = 16; nix.maxFeed = 256; nix.curFeed = 4; nix.feedIncreament = 4; nix.nextFeed = 16; nix.sparkCost = 8;
		draug.name = "Draug"; draug.curLevel = 1; draug.maxLevel = 15; draug.startFeed = 16; draug.maxFeed = 8192; draug.curFeed = 4; draug.feedIncreament = 4; draug.nextFeed = 16; draug.sparkCost = 16;
		dragon.name = "Dragon"; dragon.curLevel = 1; dragon.maxLevel = 15; dragon.startFeed = 16; dragon.maxFeed = 262144; dragon.curFeed = 4; dragon.feedIncreament = 4; dragon.nextFeed = 16; dragon.sparkCost = 32;
		
		dHound.name = "DHound"; dHound.curLevel = 1; dHound.maxLevel = 15; dHound.startFeed = 20; dHound.maxFeed = 320; dHound.curFeed = 4; dHound.feedIncreament = 5; dHound.nextFeed = 20; dHound.sparkCost = 2;
		fenrir.name = "Fenrir"; fenrir.curLevel = 1; fenrir.maxLevel = 15; fenrir.startFeed = 20; fenrir.maxFeed = 10240; fenrir.curFeed = 4; fenrir.feedIncreament = 5; fenrir.nextFeed = 20; fenrir.sparkCost = 6;
		hellHound.name = "HellHound"; hellHound.curLevel = 1; hellHound.maxLevel = 15; hellHound.startFeed = 20; hellHound.maxFeed = 327680; hellHound.curFeed = 4; hellHound.feedIncreament = 5; hellHound.nextFeed = 20; hellHound.sparkCost = 12;
		
		sprite.name = "Sprite"; sprite.curLevel = 1; sprite.maxLevel = 15; sprite.startFeed = 10; sprite.maxFeed = 160; sprite.curFeed = 2; sprite.feedIncreament = 5; sprite.nextFeed = 10; sprite.sparkCost = 4;
		imp.name = "Imp"; imp.curLevel = 1; imp.maxLevel = 15; imp.startFeed = 10; imp.maxFeed = 5120; imp.curFeed = 5; imp.feedIncreament = 2; imp.nextFeed = 10; imp.sparkCost = 8;
		djinn.name = "Djinn"; djinn.curLevel = 1; djinn.maxLevel = 15; djinn.startFeed = 10; djinn.maxFeed = 163840; djinn.curFeed = 2; djinn.feedIncreament = 5; djinn.nextFeed = 10; djinn.sparkCost = 24;
		
		leech.name = "Leech"; leech.curLevel = 1; leech.maxLevel = 15; leech.startFeed = 5; leech.maxFeed = 80; leech.curFeed = 1; leech.feedIncreament = 5; leech.nextFeed = 5; leech.sparkCost = 8;
		leshy.name = "Leshy"; leshy.curLevel = 1; leshy.maxLevel = 15; leshy.startFeed = 5; leshy.maxFeed = 2560; leshy.curFeed = 1; leshy.feedIncreament = 5; leshy.nextFeed = 5; leshy.sparkCost = 16;
		lurker.name = "Lurker"; lurker.curLevel = 1; lurker.maxLevel = 15; lurker.startFeed = 5; lurker.maxFeed = 81920; lurker.curFeed = 1; lurker.feedIncreament = 5; lurker.nextFeed = 5; lurker.sparkCost = 32;
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{	
		gui_curLevel.text = "Cur Level :: " + hound.curLevel.ToString();
		gui_maxLevel.text = "Max Level :: " + hound.maxLevel.ToString();
		gui_startFeed.text = "Start Feed :: " + hound.startFeed.ToString();
		gui_maxFeed.text = "Max Feed :: " + hound.maxFeed.ToString();
		gui_curFeed.text = "Cur Feed :: " + hound.curFeed.ToString();
		gui_nextFeed.text = "Next Feed :: " + hound.nextFeed.ToString();
		gui_feedIncreament.text = "Feed Increament :: " + hound.feedIncreament.ToString();
		gui_food.text = "Food :: " + GameManager.food.ToString();
	}
	
//========================================================================================================
//========================================================================================================
//========================================================================================================
	
	
	public bool isMorphCreature,isFeedCreature;
	// morph Hound to Barg creature
	public void morphHoundToBarg()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 4)
		{
			if (GameManager.earthTG_lvl >= 2)
			{
				if (GameManager.sparks > barg.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Barg");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objHound.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objBarg.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = cusith.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	private int Morphid;
	public int GetMorphTypeid()
	{
		return Morphid;
	}
	
	private int SendFeedTypeid;
	public int GetFeedTypeid()
	{
		return SendFeedTypeid;
	}
	
	private int SendFood;
	public int GetCurrentFood()
	{
		return SendFood;
	}
	
	void PlayMorphSounds()
	{
		scr_audioController.audio_morph.Play();
		scr_audioController.audio_morph.minDistance = 1;
		scr_audioController.audio_morph.maxDistance = 300;
		scr_audioController.audio_morph.volume = 0.8f;
	}
	
	
	void PlayFeedSounds()
	{
		scr_audioController.audio_feed.Play();
		scr_audioController.audio_feed.minDistance = 1;
		scr_audioController.audio_feed.maxDistance = 300;
		scr_audioController.audio_feed.volume = 0.8f;
	}
	
	// morph Barg to Cusith creature
	public void morphBargToCusith()
	{
		PlayMorphSounds();
		
		if (GameManager.gameLevel >= 8)
		{
			if (GameManager.earthTG_lvl >= 3)
			{
				if (GameManager.sparks > cusith.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Cusith");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objBarg.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objCusith.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					//morph_spText.Text = cusith.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Sprout to Nymph creature
	public void morphSproutToNymph()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 6)
		{
			if (GameManager.plantTG_lvl >= 2)
			{
				if (GameManager.sparks > nymph.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Nymph");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objSprout.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objNymph.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = dryad.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Sprout to Nymph creature
	public void morphNymphToDryad()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 9)
		{
			if (GameManager.plantTG_lvl >= 3)
			{
				if (GameManager.sparks > dryad.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Dryad");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objNymph.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDryad.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					morph_spText.Text = dryad.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Nix to Draug creature
	public void morphNixToDraug()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 8)
		{
			if (GameManager.waterTG_lvl >= 2)
			{
				if (GameManager.sparks > draug.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Draug");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objNix.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDraug.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = dragon.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Draug to Dragon creature
	public void morphDraugToDragon()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 12)
		{
			if (GameManager.waterTG_lvl >= 3)
			{
				if (GameManager.sparks > dragon.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Dragon");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDraug.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDragon.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					//morph_spText.Text = dragon.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph DHound to Fenrir creature
	public void morphDHoundToFenrir()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 8)
		{
			if (GameManager.dEarthTG_lvl >= 2)
			{
				if (GameManager.sparks > fenrir.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Fenrir");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDarklinghound.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingFenrir.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = hellHound.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Fenrir to HellHound creature
	public void morphFenrirToHellHound()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 13)
		{
			if (GameManager.dEarthTG_lvl >= 3)
			{
				if (GameManager.sparks > hellHound.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "HellHound");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDarklingFenrir.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingHellhound.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					//morph_spText.Text = dragon.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Sprite to Imp creature
	public void morphSpriteToImp()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 9)
		{
			if (GameManager.fireTG_lvl >= 2)
			{
				if (GameManager.sparks > imp.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Imp");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDarklingSprite.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingImp.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = djinn.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Imp to Djinn creature
	public void morphImpToDjinn()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 14)
		{
			if (GameManager.fireTG_lvl >= 3)
			{
				if (GameManager.sparks > djinn.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Djinn");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDarklingImp.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingDjInn.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					//morph_spText.Text = dragon.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Leech to Leshy creature
	public void morphLeechToLeshy()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 7)
		{
			if (GameManager.swampTG_lvl >= 2)
			{
				if (GameManager.sparks > leshy.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Leshy");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//morphing sent to server
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objLeech.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingLeshy.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					morph_spText.Text = lurker.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	// morph Leshy to Lurker creature
	public void morphLeshyToLurker()
	{
		PlayMorphSounds();
		if (GameManager.gameLevel >= 12)
		{
			if (GameManager.swampTG_lvl >= 3)
			{
				if (GameManager.sparks > lurker.sparkCost)
				{
					popUpInfoScript.taskCreature(1, "Lurker");
					Destroy(GameManager.currentCreature);
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.wall.active = false;
					
					//morphing sent to server
					//calling morphing from server
					isMorphCreature = true;
					scr_gameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					Morphid = scr_gameObjectSvr.objDarklingLeshy.objTypeId;
					popUpInfoScript.TempTypeId = scr_gameObjectSvr.objDarklingLurker.objTypeId;
					scr_sfsRemote.SendRequestForGetworld();
					
					//morph_spText.Text = dragon.sparkCost.ToString();
				}
				else
				{
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(8, 0);
				}
			}
			else
			{
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(31, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(30, 0);
		}
	}

//========================================================================================================
	
	
	
//========================================================================================================
//========================================================================================================
//========================================================================================================
	
	// Hound update
	public void updateHoundCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 1)
		{
			//if(GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > hound.curFeed)
			{
				if(GameManager.hound_lvl <= 5)
				{
						//feeding sent to server 
						
					    isFeedCreature = true;
						SendFeedTypeid = scr_gameObjectSvr.objHound.objTypeId;
						SendFood = (int)hound.curFeed;
						scr_sfsRemote.SendRequestForGetworld();
					    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
//Update Barg 
	public void updateBargCreature()
	{
		
		PlayFeedSounds();
		
		if (GameManager.gameLevel >= 4)
		{
			//if(GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > barg.curFeed)
			{
				if(GameManager.barg_lvl <= 10)
				{
						isFeedCreature = true;
						SendFeedTypeid = scr_gameObjectSvr.objBarg.objTypeId;
						SendFood = (int)barg.curFeed;					
						scr_sfsRemote.SendRequestForGetworld();
					    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
		
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Cusith update
	public void updateCusithCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > cusith.curFeed)
			{
				if(GameManager.cusith_lvl <= 15)
				{
						
						isFeedCreature = true;
						SendFeedTypeid = scr_gameObjectSvr.objCusith.objTypeId;
						SendFood = (int)cusith.curFeed;					
						scr_sfsRemote.SendRequestForGetworld();
						 MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
				
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Sprout update
	public void updateSproutCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 3)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > sprout.curFeed)
			{
				if(GameManager.sprout_lvl <= 5)
				{
					//feeding sent to server 
					
				    isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objSprout.objTypeId;
					SendFood = (int)sprout.curFeed;						
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Nymph update
	public void updateNymphCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > nymph.curFeed)
			{
				if(GameManager.nymph_lvl <= 10)
				{
						isFeedCreature = true;
						SendFeedTypeid = scr_gameObjectSvr.objNymph.objTypeId;
						SendFood = (int)nymph.curFeed;					
						scr_sfsRemote.SendRequestForGetworld();
					    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Dryad update
	public void updateDryadCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > dryad.curFeed)
			{
				if(GameManager.dryad_lvl <= 15)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDryad.objTypeId;
					SendFood = (int)dryad.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Nix update
	public void updateNixCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > nix.curFeed)
			{
				if(GameManager.nix_lvl <= 5)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objNix.objTypeId;
					SendFood = (int)nix.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Draug update
	public void updateDraugCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > draug.curFeed)
			{
				if(GameManager.draug_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDraug.objTypeId;
					SendFood = (int)draug.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Dragon update
	public void updateDragonCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > dragon.curFeed)
			{
				if(GameManager.dragon_lvl <= 15)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDragon.objTypeId;
					SendFood = (int)dragon.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// DHound update
	public void updateDHoundCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > dHound.curFeed)
			{
				if(GameManager.dHound_lvl <= 5)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklinghound.objTypeId;
					SendFood = (int)dHound.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Fenrir update
	public void updateFenrirCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > fenrir.curFeed)
			{
				if(GameManager.fenrir_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingFenrir.objTypeId;
					SendFood = (int)fenrir.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Hell Hound update
	public void updateHellHoundCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > hellHound.curFeed)
			{
				if(GameManager.hellHound_lvl <= 5)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingHellhound.objTypeId;
					SendFood = (int)hellHound.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();					
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Sprite update
	public void updateSpriteCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food >  scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > sprite.curFeed)
			{
				if(GameManager.sprite_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingSprite.objTypeId;
					SendFood = (int)sprite.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Imp update
	public void updateImpCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > imp.curFeed)
			{
				if(GameManager.imp_lvl <= 5)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingImp.objTypeId;
					SendFood = (int)imp.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Djinn update
	public void updateDjinnCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > djinn.curFeed)
			{
				if(GameManager.djinn_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingDjInn.objTypeId;
					SendFood = (int)djinn.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Leech update
	public void updateLeechCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > leech.curFeed)
			{
				if(GameManager.leech_lvl <= 5)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objLeech.objTypeId;
					SendFood = (int)leech.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Leshy update
	public void updateLeshyCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > leshy.curFeed)
			{
				if(GameManager.leshy_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingLeshy.objTypeId;
					SendFood = (int)leshy.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
//========================================================================================================
	
	// Lurker update
	public void updateLurkerCreature()
	{
		PlayFeedSounds();
		if (GameManager.gameLevel >= 4)
		{
			//if (GameManager.food > scr_loadUserworld.GetMaxFoodforcreature())
			if(GameManager.food > lurker.curFeed)
			{
				if(GameManager.lurker_lvl <= 10)
				{
					isFeedCreature = true;
					SendFeedTypeid = scr_gameObjectSvr.objDarklingLurker.objTypeId;
					SendFood = (int)lurker.curFeed;					
					scr_sfsRemote.SendRequestForGetworld();
				    MorphNFeedButtonStateManager(guiControlInfo.Feedbtn.gameObject ,false);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
					popUpInfoScript.defaultPopUp(54, 0);
				}
			}
		
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUp(7, 0);
			}
		}
		else
		{
			guiControlInfo.FeedMorphPopUp.SetActiveRecursively(false);
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(32, 0);
		}
	}
	
	private float res ,calCurfeed;
	public void AssignFeedPb(float currentFeed,float MaxFeed,int feedLevel,int feedleveBar)
	{
		
		if(MaxFeed > 0)
		{
		  res = (currentFeed / MaxFeed);
		}		
		
		switch(GetFeedTypeid())
		{
		case 22:
		
			//barg		
						
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
			GameManager.barg_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.barg_lvl.ToString();	
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
			barg.curFeed = calCurfeed;
			
		break;
		case 3:
		{
			//Hound
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
			GameManager.hound_lvl = feedLevel;
			Debug.Log(" max feed >>>>>> " + MaxFeed + " >>>>>>>> " + currentFeed);
			if (MaxFeed == currentFeed)
				MaxFeed = MaxFeed * 2;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.hound_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
		    hound.curFeed = calCurfeed;
			
		}
			break;
		
		case 224:
		{
			//Fenrir
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.fenrir_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.fenrir_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			fenrir.curFeed = calCurfeed;
			
		}
			break;
		case 237:
		{
			//Hell Hound
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.hellHound_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.hellHound_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			hellHound.curFeed = calCurfeed;
			
		}
			break;
		case 209:
		{
			//Dark Hound				
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.dHound_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.dHound_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			dHound.curFeed = calCurfeed;
			
		}
			break;
		case 26:
		{
		    //cusith	
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.cusith_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.cusith_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
			cusith.curFeed = calCurfeed;
		}
			break;
		case 215:
		{
			//sprite
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.sprite_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.sprite_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			sprite.curFeed = calCurfeed;
		}
			break;
		case 225:
		{
			//Imp
			
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.imp_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.imp_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			imp.curFeed = calCurfeed;
		}
			break;
		case 241:
		{
			//DjInn
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.djinn_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.djinn_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			djinn.curFeed = calCurfeed;
		}
			
			break;
		case 21:
		{
			//sprout
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.sprout_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.sprout_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			sprout.curFeed = calCurfeed;
		}
			
			break;
		case 32:
		{
			//Nymph
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.nymph_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.nymph_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			nymph.curFeed = calCurfeed;
		
		}
			break;
		case 41:
		{
			//Dryad
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.dryad_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.dryad_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 1));
			dryad.curFeed = calCurfeed;
		}
			break;
		case 38:
		{
			//Draug
			
		    Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.draug_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.draug_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			draug.curFeed = calCurfeed;
		}
			break;
		case 208:
		{
			//Leech
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.leech_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.leech_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
			leech.curFeed = calCurfeed;
		}
			break;
		case 222:
		{
			//Leshy
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.leshy_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.leshy_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
			leshy.curFeed = calCurfeed;
		}
			break;
		case 234:
		{
			//Lurker
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.lurker_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.lurker_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel));
			lurker.curFeed = calCurfeed;
		}
			break;
		case 24:
		
			//Nix
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.nix_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.nix_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			nix.curFeed = calCurfeed;
			
		 break;
		case 50:
		
			//Dagon
			
			Debug.Log("Result >>>>>> :" + res);
			feedPB.transform.localScale = new Vector3(res,1,1);
		
			GameManager.dragon_lvl = feedLevel;
			feed_spText.Text = (MaxFeed - currentFeed).ToString();
			cLevel_spText.Text = GameManager.dragon_lvl.ToString();
			
			calCurfeed = (float) Math.Pow(2,(feedLevel + 2));
			dragon.curFeed = calCurfeed;
			
			break;
		
		}
		
		popUpInfoScript.UpdateScore();
		MorphNFeedButtonStateManager(guiControlInfo.Feedbtn ,true);
		
		if(currentFeed == MaxFeed )
		{
			isReset = true;
		}
		
		if(isReset)
		{
			StartCoroutine("reset");
		}
		
	}
	
	bool isReset;
	IEnumerator reset()
	{
		yield return new WaitForSeconds(0.3f);
	    feedPB.transform.localScale = new Vector3(0,1,1);
		isReset = false;
	}
	
	public void AssignPreviousCreatureFeedLevel(int typeId,int feedLevel)
	{
		switch(typeId)
		{
		case 22:
			//barg
			
			GameManager.barg_lvl = feedLevel;
			
			break;
			
		case 26:
			//cusith
			GameManager.cusith_lvl = feedLevel;			
			
			break;
				
		case 224:
			//fenrir
			GameManager.fenrir_lvl = feedLevel;
			
			break;
			
		case 50:
			//Dragon
			GameManager.dragon_lvl = feedLevel;
			
			break;
			
		case 237:
			//Hell hound
			GameManager.hellHound_lvl = feedLevel;
			
			break;
			
		case 241:
			//Dj Inn 
			GameManager.djinn_lvl = feedLevel;
			
			break;
			
		case 222:
			//Leshy
			GameManager.leshy_lvl = feedLevel;		
			
			break;
			
		case 234:
			//Lurker
			GameManager.lurker_lvl = feedLevel;
			
			break;
			
		case 38:
			//Draug
			GameManager.draug_lvl = feedLevel;
			
			break;
			
		case 41:
			//Dryad
			GameManager.dryad_lvl = feedLevel;
			
			break;
			
		case 225:
			//Imp
			GameManager.imp_lvl = feedLevel;
			
			break;
			
		case 32:
			//Nymph
			GameManager.nymph_lvl = feedLevel;
			
			break;
			
		}
	
	}
	
	private void MorphNFeedButtonStateManager(GameObject go, bool normalState)
	{
		if(go != null)
		{
			UIButton uiB = go.GetComponent<UIButton>();
			if(uiB != null)
			{
				if(normalState)
					uiB.SetControlState(UIButton.CONTROL_STATE.NORMAL);
				else
					uiB.SetControlState(UIButton.CONTROL_STATE.DISABLED);
			}
		}
	}

	
//========================================================================================================
}
