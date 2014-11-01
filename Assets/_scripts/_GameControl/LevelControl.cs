using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour 
{
	public guiControl guiControlInfo;
	
	public GameObject h_Plot, h_Inn01, bridge, h_Stable, h_BlackSmith, h_earthObelisk, h_plantObelisk, h_waterObelisk, h_Tavern, h_apothecary, h_sunShrine, 
						d_Plot, d_Inn01, d_Stable, d_BlackSmith, d_earthObelisk, d_swampObelisk, d_fireObelisk, d_Apothecary, d_moonShrine, d_Tavern;
	
	public GameObject h_Turnip, h_PipeWeed, h_Pumpkin, h_Costmary, h_Potato, h_FairyLily, h_Sunflower, h_Watercress, h_Vervain, h_Mandrake,
						d_Pumpkin, d_FirePepper, d_Aven, d_BlackBery, d_Columbine, d_Moonflower, d_BitterBush, d_BogBean, d_Wolfsbane;
	
	public GameObject h_Earth, h_Plant, h_Water, d_Swamp, d_Earth, d_Fire;
	
	public GameObject h_Hound, h_Barg, h_Sprout, h_Nymph, h_Nix,  d_Leech, d_Hound,d_sprite;
	
	public GameObject h_DirtPath, h_FruitTree, h_Lantern, h_WheelBurrow, h_Shroomrey, h_Tree, h_Woodpile, h_Well, h_Barrel, h_Scarecrow, h_PartyTent, h_KnollHill, h_Fence, h_Cottage, h_CornField, h_WindMill, 
						d_DirtPath, d_Well, d_Tree, d_Bog, d_Tree2, d_RavenPerch, d_ScareCrow, d_HuntingTent, d_KnollHill, d_Fence, d_BirdHouse, d_WindMill;
	
	public int loadCurrentLevel = 4;
	public bool cheat = true;
	
	public popUpInformation popUpScriptInfo;
	public UpgradeTexture scr_UpgradeTexture;
	
	public GameObject hGateObj, dGateObj;
	
	private OrcAttackSystem orcAttackSystem;
	
	private SfsRemote scr_SfsRemote;
	private LoadUserWorld scr_LoadUserWorld;
	
	void Awake()
	{
		//foreach(MeshRenderer renderer in guiControlInfo.trainingGroundUI.GetComponentsInChildren<MeshRenderer>())
			//renderer.enabled = false;
		scr_UpgradeTexture = GameObject.Find("GameManager").GetComponent<UpgradeTexture>();
		
		orcAttackSystem = GameObject.Find("GameManager").GetComponent<OrcAttackSystem>();
		scr_LoadUserWorld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_SfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
	}
	
	void Start () 
	{
		Debug.Log ("level control...");
		GameManager.gameLevel = 0;		//Amogh
		UnlockItems();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void UnlockItems()
	{
///***		Debug.Log("UnlockItems.gameLevel : "+GameManager.gameLevel);
		// LEVEL 1 //
		if (GameManager.gameLevel == 1)
		{
			GameManager.levelXPCnt = 184;
			Destroy(h_Hound.transform.FindChild("lock").gameObject);
			Destroy(h_Earth.transform.FindChild("lock").gameObject);
			Destroy(h_DirtPath.transform.FindChild("lock").gameObject); // move to 3rd level
			Destroy(h_Plot.transform.FindChild("lock").gameObject);
			Destroy(h_Turnip.transform.FindChild("lock").gameObject);
		}
		
		if (GameManager.gameLevel == 2)
		{	
			GameManager.levelXPCnt = 341 ; //241;
			
			Destroy(h_Inn01.transform.FindChild("lock").gameObject);
			Destroy(h_earthObelisk.transform.FindChild("lock").gameObject);
			
			if (GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01").gameObject != null)
			{
				GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01").gameObject.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
				
				GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01").gameObject.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01").gameObject.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01").gameObject.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
		}
		
		if (GameManager.gameLevel == 3)
		{
			GameManager.levelXPCnt = 600 ;//300;
			
			Destroy(h_Plant.transform.FindChild("lock").gameObject);
			Destroy(h_Sprout.transform.FindChild("lock").gameObject);
			Destroy(h_PipeWeed.transform.FindChild("lock").gameObject);
			Destroy(h_Well.transform.FindChild("lock").gameObject);
			Destroy(h_Woodpile.transform.FindChild("lock").gameObject);
			Destroy(h_Tree.transform.FindChild("lock").gameObject);
			Destroy(h_plantObelisk.transform.FindChild("lock").gameObject);				//Added
		}
		
		if (GameManager.gameLevel == 4)
		{
			GameObject hGC02 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02") as GameObject;
						
			GameManager.levelXPCnt = 1200 ;// 600;
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
			
			Destroy(d_DirtPath.transform.FindChild("lock").gameObject);
			Destroy(d_Well.transform.FindChild("lock").gameObject);
			Destroy(d_Tree.transform.FindChild("lock").gameObject);
			Destroy(d_Inn01.transform.FindChild("lock").gameObject);
			Destroy(d_Plot.transform.FindChild("lock").gameObject);
			Destroy(d_Pumpkin.transform.FindChild("lock").gameObject);
			Destroy(d_Swamp.transform.FindChild("lock").gameObject);
			Destroy(d_Leech.transform.FindChild("lock").gameObject);
			Destroy(h_Barrel.transform.FindChild("lock").gameObject);
			Destroy(bridge.transform.FindChild("lock").gameObject);
			Destroy(d_swampObelisk.transform.FindChild("lock").gameObject);
			
			//hGateObj.renderer.material.mainTexture = scr_UpgradeTexture.h_BattleGround;
			//hGateObj.renderer.material.mainTexture = scr_UpgradeTexture.d_BattleGround;
			//hGateObj.GetComponent<MeshCollider>().enabled = true;
			//dGateObj.GetComponent<MeshCollider>().enabled = true;
			
			if (hGC02 != null)
			{
				hGC02.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
				hGC02.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				hGC02.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				hGC02.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
		
///***			Debug.Log("currentLevel = "+GameManager.gameLevel);
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 5)
		{
			GameObject dGC01 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01") as GameObject;
			
			GameManager.levelXPCnt = 1600 ;//800;
			Destroy(h_FruitTree.transform.FindChild("lock").gameObject);
			Destroy(h_Water.transform.FindChild("lock").gameObject);
			Destroy(h_Nix.transform.FindChild("lock").gameObject);
			Destroy(h_Pumpkin.transform.FindChild("lock").gameObject);
			Destroy(h_Stable.transform.FindChild("lock").gameObject);
			Destroy(d_Earth.transform.FindChild("lock").gameObject);
			Destroy(d_Hound.transform.FindChild("lock").gameObject);
			Destroy(d_Stable.transform.FindChild("lock").gameObject);
			Destroy(d_Bog.transform.FindChild("lock").gameObject);
			Destroy(d_FirePepper.transform.FindChild("lock").gameObject);
			Destroy(h_waterObelisk.transform.FindChild("lock").gameObject);
			Destroy(d_earthObelisk.transform.FindChild("lock").gameObject);
			Debug.Log("----------------------> unlock obelisk...");

			if (dGC01 != null)
			{
				dGC01.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
				dGC01.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC01.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC01.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 6)
		{
			GameObject hGC03 = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03") as GameObject;
			
			GameManager.levelXPCnt = 2300 ;//800;
			Destroy(h_Lantern.transform.FindChild("lock").gameObject);
			Destroy(h_BlackSmith.transform.FindChild("lock").gameObject);
			//Destroy(h_Nymph.transform.FindChild("lock").gameObject);
			Destroy(d_BlackSmith.transform.FindChild("lock").gameObject);
			Destroy(d_Fire.transform.FindChild("lock").gameObject);
			Destroy(d_sprite.transform.FindChild("lock").gameObject);
			Destroy(d_fireObelisk.transform.FindChild("lock").gameObject);

			if (hGC03 != null)
			{
				hGC03.renderer.material.mainTexture = scr_UpgradeTexture.hc_GoblinCamp_Tex;
				hGC03.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				hGC03.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				hGC03.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 7)
		{
			GameObject dGC02 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02") as GameObject;
			
			GameManager.levelXPCnt = 4500 ;//800;
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
			
			Destroy(h_WheelBurrow.transform.FindChild("lock").gameObject);
			Destroy(h_Costmary.transform.FindChild("lock").gameObject);
			Destroy(d_Aven.transform.FindChild("lock").gameObject);
			Destroy(d_RavenPerch.transform.FindChild("lock").gameObject);
			
			if (dGC02 != null)
			{
				dGC02.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
				dGC02.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC02.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC02.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 8)
		{
			GameObject hTC01 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01") as GameObject;
			GameManager.levelXPCnt = 5625 ;//800;
			Destroy(h_Shroomrey.transform.FindChild("lock").gameObject);
			Destroy(d_ScareCrow.transform.FindChild("lock").gameObject);
			Destroy(h_Scarecrow.transform.FindChild("lock").gameObject);
			//Destroy(h_plantObelisk.transform.FindChild("lock").gameObject);

			
			if (hTC01 != null)
			{
				hTC01.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
				hTC01.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 9)
		{
			GameObject dGC03 = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03") as GameObject;
			GameManager.levelXPCnt = 6900 ;//800;
			Destroy(h_Tavern.transform.FindChild("lock").gameObject);
			Destroy(d_Tavern.transform.FindChild("lock").gameObject);
			
			Destroy(d_HuntingTent.transform.FindChild("lock").gameObject);
			Destroy(h_PartyTent.transform.FindChild("lock").gameObject);
			
			if (dGC03 != null)
			{
				dGC03.renderer.material.mainTexture = scr_UpgradeTexture.dl_GoblinCamp_Tex;
				dGC03.transform.FindChild("GoblinChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC03.transform.FindChild("GoblinChar02").gameObject.GetComponent<MeshRenderer>().enabled = true;
				dGC03.transform.FindChild("burnFood").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 10)
		{
			GameObject hTC02 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02") as GameObject;
			GameManager.levelXPCnt = 8250 ;//800;
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
			
			Destroy(h_apothecary.transform.FindChild("lock").gameObject);
			Destroy(d_Apothecary.transform.FindChild("lock").gameObject);
			Destroy(h_Potato.transform.FindChild("lock").gameObject);
			Destroy(d_BlackBery.transform.FindChild("lock").gameObject);
			Destroy(d_KnollHill.transform.FindChild("lock").gameObject);
			Destroy(h_KnollHill.transform.FindChild("lock").gameObject);
			
			if (hTC02 != null)
			{
				hTC02.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
				hTC02.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 11)
		{
			GameObject dTC01 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01") as GameObject;
			GameManager.levelXPCnt = 16125 ;//800;
			
			Destroy(h_FairyLily.transform.FindChild("lock").gameObject);
			Destroy(d_Columbine.transform.FindChild("lock").gameObject);
			Destroy(d_Fence.transform.FindChild("lock").gameObject);
			Destroy(h_Fence.transform.FindChild("lock").gameObject);

			if (dTC01 != null)
			{
				dTC01.renderer.material.mainTexture = scr_UpgradeTexture.dl_TrollHouse_Tex;
				dTC01.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 12)
		{
			GameObject hTC03 = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03") as GameObject;
			GameManager.levelXPCnt = 18625 ;//800;
			Destroy(h_sunShrine.transform.FindChild("lock").gameObject);
			Destroy(d_moonShrine.transform.FindChild("lock").gameObject);
			Destroy(h_Sunflower.transform.FindChild("lock").gameObject);
			Destroy(h_Watercress.transform.FindChild("lock").gameObject);
			Destroy(d_Moonflower.transform.FindChild("lock").gameObject);
			Destroy(d_BitterBush.transform.FindChild("lock").gameObject);
			Destroy(d_BirdHouse.transform.FindChild("lock").gameObject);
			Destroy(h_Cottage.transform.FindChild("lock").gameObject);
			
			if (hTC03 != null)
			{
				hTC03.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
				hTC03.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 13)
		{
			GameObject dTC02 = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02") as GameObject;
			GameManager.levelXPCnt = 30000 ;//800;
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
			
			Destroy(h_Vervain.transform.FindChild("lock").gameObject);
			Destroy(d_BogBean.transform.FindChild("lock").gameObject);
			Destroy(h_CornField.transform.FindChild("lock").gameObject);
			
			if (dTC02 != null)
			{
				dTC02.renderer.material.mainTexture = scr_UpgradeTexture.dl_TrollHouse_Tex;
				dTC02.transform.FindChild("TrollChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 14)
		{
			GameObject hOC01 = GameObject.Find("HC_B_OrgCave_GO(Clone)_01") as GameObject;
			GameManager.levelXPCnt = 37500 ;//800;
			Destroy(h_Mandrake.transform.FindChild("lock").gameObject);
			Destroy(d_Wolfsbane.transform.FindChild("lock").gameObject);
			Destroy(d_WindMill.transform.FindChild("lock").gameObject);
			Destroy(h_WindMill.transform.FindChild("lock").gameObject);
			
			if (hOC01 != null)
			{
				hOC01.renderer.material.mainTexture = scr_UpgradeTexture.hc_TrollHouse_Tex;
				hOC01.transform.FindChild("OrgChar01").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			orcAttackSystem.GetCave(GameManager.gameLevel);
			scr_SfsRemote.SendRequestForOrgCaveTimer(scr_LoadUserWorld.ReturnObjIdfromTypeId(orcAttackSystem.caveObjId));
		}
		
		if (GameManager.gameLevel == 15)
		{
			
		}
		
		if (GameManager.gameLevel == 16)
		{
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
		}
		
		if (GameManager.gameLevel == 17)
		{
			
		}
		
		if (GameManager.gameLevel == 18)
		{
			
		}
		
		if (GameManager.gameLevel == 19)
		{
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
		}
		
		if (GameManager.gameLevel == 20)
		{
			
		}
		
		if (GameManager.gameLevel == 21)
		{
			
		}
		
		if (GameManager.gameLevel == 22)
		{
			GameManager.placeHGardenPlotBool = true;
			GameManager.placeDGardenPlotBool = true;
		}
		
		if (GameManager.gameLevel == 23)
		{
			
		}
		
		if (GameManager.gameLevel == 24)
		{
			
		}
		
		if (GameManager.gameLevel == 25)
		{
			GameManager.placeDGardenPlotBool = true;
		}
	}
}
