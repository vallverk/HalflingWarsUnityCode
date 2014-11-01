using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardsSvr : MonoBehaviour {
	
	
	public SfsRemote scr_sfsremote;
	public LoadUserWorld scr_loaduserworld;
	public GameObjectsSvr scr_gameobjectSvr;
	
	// Use this for initialization
	void Start () {

		Debug.Log ("rewards svr...");
		scr_sfsremote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_loaduserworld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
	    scr_gameobjectSvr  = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool bloodstoneTrinket()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objBarg.objTypeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	public bool bloodstoneMedallion()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objBarg.objTypeId))
			{
				if(scr_sfsremote.lst_ObjSvr[i].feedLevel.Equals(5))
				{
					return true;
				}
			}
		}
		
		return false;
	}
	
	public bool bloodstoneAmulet()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objCusith.objTypeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	public bool emeraldTrinket()
	{
		if(GameManager.gameLevel >= 5)
		{
			return true;
		}
		
		return false;
	}
	
//	public bool emeraldMedallion()
//	{
//		//win 10 fights
//	}
	
	private int potionCnt = 0;
	public bool emeraldAmulet()
	{
		potionCnt = 0;
		
		for(int i= 0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objSlugTonic.objTypeId) || 
			   scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objPoppySnap.objTypeId) ||
			   scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objFeverPitch.objTypeId) ||
			   scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objBitterRoot.objTypeId) ||
			   scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objMorrowDraught.objTypeId) ||
			   scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objVetchSpray.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objBoggleHom.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objSpleenBite.objTypeId))
			{
				potionCnt ++;
				
				
				if(potionCnt >= 5)
				{
					return true;
				}
			}
		}
		
		return false;
		
	}
	
	public bool sapphireTrinket()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDraug.objTypeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	
	public bool sapphireMedallion()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDragon.objTypeId))
			{
				if(scr_sfsremote.lst_ObjSvr[i].feedLevel.Equals(10))
				{
					return true;
				}
			}
		}
		
		return false;
	}
	
	private int creatureCnt = 0;
	public bool sapphireAmulet()
	{
		creatureCnt = 0;
		
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objHound.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objBarg.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objCusith.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objSprout.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objNymph.objTypeId) || 
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDryad.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objNix.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDraug.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDragon.objTypeId) )
			{
				creatureCnt ++;
				
				if(creatureCnt >= 6)
				{
					return true;
				}
			}
		}
			
	   return false;
	}
	
	
	public bool amethystTrinket()
	{
		return GameManager.unlockDarklingBool;
	}
	
	private int CampCnt = 0;
	private int totCnt = 9;
	public bool amethystMedallion()
	{
		CampCnt = 0;
		
		for(int i= 0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingGoblinCamp01.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingGoblinCamp02.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingGoblinCamp03.objTypeId)  ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingOrgCave01.objTypeId) || 
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingOrgCave02.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingOrgCave03.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingTrollCave01.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingTrollCave02.objTypeId) ||
				scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingTrollCave03.objTypeId))
			{
				CampCnt ++ ;
			}
			
			if(totCnt - CampCnt >= 2)
			{
				return true;
			}
			
		}
		
		return false;
	}
	
	private int pumkintCnt = 0;
	public bool amethystAmulet()
	{
		pumkintCnt = 0;
		
		for(int i = 0; i< scr_sfsremote.lst_HerbObjects.Count ; i++)
		{
			if(scr_sfsremote.lst_HerbObjects[i].ObjectTypeId.Equals(scr_gameobjectSvr.objDarklingPumpkin.objTypeId))
			{
				pumkintCnt ++;
				
				if(pumkintCnt >= 20)
				{
					return true;
				}
			}			
		}
		
		return false;
	}
	
	
	public bool rubyTrinket()
	{
		for(int i=0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingDjInn.objTypeId))
			{
				if(scr_sfsremote.lst_ObjSvr[i].feedLevel >= 10)
				{
					return true;
				}
			}
		}
		
		return false;
	}
	
	public bool rubyMedallion()
	{
		for(int i=0 ; i < scr_sfsremote.lst_ObjSvr.Count; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingDjInn.objTypeId))
			{
				return true;
			}
		}
		
		return false;
	}
	
	
	public bool rubyYamlet()
	{
		for(int i=0 ; i< scr_sfsremote.lst_questInfo.Count ; i++)
		{
			if(scr_sfsremote.lst_questInfo.Equals((int)GameObjectsSvr.QuestNo.Quest6))
			{
				return true;
			}
		}
		
		return false;
	}
	
	public bool onynxTrinket()
	{
		if(rubyYamlet() && emeraldAmulet())
		{
			return true;
		}
		
		return false;
	}
	
	public bool onynxMedallion()
	{
		for(int i = 0 ; i< scr_sfsremote.lst_questInfo.Count ; i++)
		{
			if(scr_sfsremote.lst_questInfo.Equals((int)GameObjectsSvr.QuestNo.Quest12))
			{
				return true;
			}
		}
		
		return false;
	}
	
	private int dcreatureCnt = 0;
	public bool onynxAmulet()
	{
		dcreatureCnt = 0;
		
		for(int i= 0 ; i< scr_sfsremote.lst_ObjSvr.Count ; i++)
		{
			if(scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklinghound.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingFenrir.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingHellhound.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingSprite.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingImp.objTypeId) || 
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingDjInn.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objLeech.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingLeshy.objTypeId) ||
					scr_sfsremote.lst_ObjSvr[i].typeId.Equals(scr_gameobjectSvr.objDarklingLurker.objTypeId) )
			{
				dcreatureCnt ++ ;
				
				if(dcreatureCnt >= 6)
				{
					return true;
				}
			}
		
		}
		
		return false;
	}
	
}
