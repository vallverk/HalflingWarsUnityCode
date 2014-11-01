using UnityEngine;
using System.Collections;

public class OrcAttackSystem : MonoBehaviour 
{
	private GameObjectsSvr scr_GameObjectSvr;
	private SfsRemote scr_SfsRemote;
	private LoadUserWorld scr_LoadUserworld;
	
	public int caveObjId, attackObjId_01, attackObjId_02;
	
	public GameObject cave, caveCreature_01, caveCreature_02, attackTimer, caveTimer;
	
	public GameObject attackedBuilding_01, attackedBuilding_02;
	
	public Vector3 currentCreature_01Pos, currentCreature_02Pos;
	public Vector3 newCreature_01Pos, newCreature_02Pos;
	
	void Start () 
	{
		scr_GameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_SfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_LoadUserworld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
	}
	
	void Update () 
	{
	}
	
	// find cave
	public void GetCave(int gameLevel)									//----- Fint the Cave when respective level is unlocked and send cave Id to server ----- //
	{
		Debug.Log("gameLevel = "+gameLevel);
		if(scr_GameObjectSvr == null)									//Added
		{
			scr_GameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			Debug.Log("scr_GameObjectSvr found");
		}
		switch(gameLevel)
		{
		case (int)GameObjectsSvr.CurrentLevel.Level4 :
		
			cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02");
			caveObjId = scr_GameObjectSvr.objGoblinCamp02.objTypeId;
			if(cave != null)
			{
				caveCreature_01 = cave.transform.FindChild("GoblinChar01").gameObject;
				caveCreature_02 = cave.transform.FindChild("GoblinChar02").gameObject;
			}
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level5 :		
			
			cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01");
			caveObjId = scr_GameObjectSvr.objDarklingGoblinCamp01.objTypeId;
			
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("GoblinChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("GoblinChar02").gameObject;
			}
			
			break;
		
		case (int)GameObjectsSvr.CurrentLevel.Level6 :		
			
			cave = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03");
			caveObjId = scr_GameObjectSvr.objGoblinCamp03.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("GoblinChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("GoblinChar02").gameObject;
			}
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level7 :		
			
			cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02");
			caveObjId = scr_GameObjectSvr.objDarklingGoblinCamp02.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("GoblinChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("GoblinChar02").gameObject;
			}
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level8 :		
			
			cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_01");
			caveObjId = scr_GameObjectSvr.objTrollCave01.objTypeId;
			
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("TrollChar02").gameObject;
			}
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level9 :		
			
			cave = GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03");
			caveObjId = scr_GameObjectSvr.objDarklingGoblinCamp03.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("GoblinChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("GoblinChar02").gameObject;
			}	
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level10 :		
			
			cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_02");
			caveObjId = scr_GameObjectSvr.objTrollCave02.objTypeId;
			
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("TrollChar02").gameObject;
			}
			
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level11 :		
			
			cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_01");
			caveObjId = scr_GameObjectSvr.objDarklingTrollCave01.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("TrollChar02").gameObject;
			}
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level12 :		
			
			cave = GameObject.Find("HC_B_TrollHouse_GO(Clone)_03");
			caveObjId = scr_GameObjectSvr.objTrollCave03.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("TrollChar02").gameObject;
			}
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level13 :		
			
			cave = GameObject.Find("DL_B_TrollHouse_GO(Clone)_02");
			caveObjId = scr_GameObjectSvr.objDarklingTrollCave02.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("TrollChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("TrollChar02").gameObject;
			}
			break;
			
		case (int)GameObjectsSvr.CurrentLevel.Level14 :		
			
			cave = GameObject.Find("HC_B_OrgCave_GO(Clone)_01");
			caveObjId = scr_GameObjectSvr.objOrgCave01.objTypeId;
			if(cave != null)
			{
			caveCreature_01 = cave.transform.FindChild("OrgChar01").gameObject;
			caveCreature_02 = cave.transform.FindChild("OrgChar02").gameObject;
			}
			break;
			
			
		default :
			
			break;
		}
	}
	
	// display cave attack timer
	public void AddCaveTimer()							//------ Attach attack timer to the cave when server sends the response ------ //
	{
		cave.AddComponent<OrcAttackTimer>();
		caveTimer = (GameObject) Instantiate(attackTimer, new Vector3(cave.transform.position.x, cave.transform.position.y, cave.transform.position.z + 4f), attackTimer.transform.rotation);
		caveTimer.transform.parent = cave.transform;
		
		GameObject cooldownObject = cave.transform.FindChild("CoolDown").gameObject;			//Added
		caveTimer.transform.localPosition = new Vector3(cooldownObject.transform.localPosition.x - 0.07f, cooldownObject.transform.localPosition.y + 5f, cooldownObject.transform.localPosition.z + 0.95f);

//		if (cave.transform.localScale.x < 0)
//		{
//			Debug.Log("---------------------> left --" + cave.transform.position);
//			caveTimer.transform.localScale = new Vector3(0.5f, 0.45f, 1f);
//			caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x * 1,
//			                                                   caveCreature_01.transform.localScale.y,
//			                                                   caveCreature_01.transform.localScale.z);
//
//			caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x * 1,
//			                                                   caveCreature_02.transform.localScale.y,
//			                                                   caveCreature_02.transform.localScale.z);
//		}
//		else
//		{
//			Debug.Log("----------------------> right -- " + cave.transform.position);
//			caveTimer.transform.localScale = new Vector3(-0.5f, 0.45f, 1f);
//
//			caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x * -1,
//			                                                   caveCreature_01.transform.localScale.y,
//			                                                   caveCreature_01.transform.localScale.z);
//			
//			caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x * -1,
//			                                                   caveCreature_02.transform.localScale.y,
//			                                                   caveCreature_02.transform.localScale.z);
//		}

		
		OrcAttackTimer scr_OrcAttackTimer = cave.GetComponent<OrcAttackTimer>();
		scr_OrcAttackTimer.SecCnt = scr_SfsRemote.GetOrgattackTym();
		scr_OrcAttackTimer.cave = cave;
		scr_OrcAttackTimer.caveCreature01 = caveCreature_01;
		scr_OrcAttackTimer.caveCreature02 = caveCreature_02;
		
		Debug.Log("cave = "+cave.name);
		cave.transform.FindChild("caveEffect").renderer.enabled = true;
		caveCreature_01.renderer.enabled = false;
		caveCreature_02.renderer.enabled = false;
	}	
	
	public void CreatureAttackMode(int objID1, int objID2)					//------ Send the cave creature to attack the buildings when server sends the response ------ //
	{	
		string buildingName1 = scr_LoadUserworld.ReturnBuildingNameFromTypeid(objID1); //attackObjId_01
		string buildingName2 = scr_LoadUserworld.ReturnBuildingNameFromTypeid(objID2); //attackObjId_02
		
		Debug.Log("Object ID 1 = "+objID1 + " ------- Object ID 2 = "+objID2 );
		Debug.Log(buildingName1 + " ---------- " + buildingName2);
		
		attackedBuilding_01 = GameObject.Find(buildingName1);
		attackedBuilding_02 = GameObject.Find(buildingName2);
		
		// builing 1 health progress bar and time, assign creature and move creature
		if(attackedBuilding_01 != null )
		{

			attackedBuilding_01.transform.FindChild("Isometric_Collider").gameObject.tag = "attack";
			attackedBuilding_01.AddComponent("HealthProgressBar");
			attackedBuilding_01.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
			HealthProgressBar hPB = attackedBuilding_01.GetComponent<HealthProgressBar>();
			hPB.SecCnt = scr_SfsRemote.getObjTime1;
			hPB.seconds = (float)hPB.SecCnt;
			hPB.attackCreature = caveCreature_01;
			hPB.caveCreaturePosOld = currentCreature_01Pos;
			
			GameObject healthBar =  attackedBuilding_01.transform.FindChild("HealthProgressBar").gameObject;
			healthBar.transform.FindChild("ProgressBarPlate").renderer.enabled = false;
			healthBar.transform.FindChild("RemainTime").renderer.enabled = false;
			healthBar.transform.FindChild("ProgressBarPov").gameObject.transform.FindChild("Plane").renderer.enabled = false;
			
			GameObject currentCave = caveCreature_01.transform.parent.gameObject;
			Debug.Log("currentCave : "+currentCave.name);
			
			if(attackedBuilding_01.transform.position.x < currentCave.transform.position.x)
				caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x * -1, caveCreature_01.transform.localScale.y, caveCreature_01.transform.localScale.z);
			else if(attackedBuilding_01.transform.position.x >= currentCave.transform.position.x)
				caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x, caveCreature_01.transform.localScale.y, caveCreature_01.transform.localScale.z);

			if (caveCreature_01.transform.root.gameObject.transform.localScale.x < 0)
				caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x * -1, caveCreature_01.transform.localScale.y, caveCreature_01.transform.localScale.z);
			else
				caveCreature_01.transform.localScale = new Vector3(caveCreature_01.transform.localScale.x , caveCreature_01.transform.localScale.y, caveCreature_01.transform.localScale.z);
			
			caveCreature_01.gameObject.tag = "busy";
			caveCreature_01.gameObject.renderer.enabled = false;
			caveCreature_01.transform.FindChild("Walk_anim").renderer.enabled = true;
			caveCreature_01.transform.FindChild("attack_anim").renderer.enabled = false;
			caveCreature_01.transform.FindChild("LessAgg1_anim").renderer.enabled = false;
			caveCreature_01.AddComponent("OrcCreatureMove");
			OrcCreatureMove orcCreature = caveCreature_01.GetComponent<OrcCreatureMove>();
			orcCreature.caveCreature = caveCreature_01;
			orcCreature.attackedBuilding = attackedBuilding_01;
			orcCreature.target = attackedBuilding_01.transform.position;
			
			//Stop level upgrade progress bar if level is being upgraded
			if(attackedBuilding_01.transform.FindChild("ProgressBar").gameObject.active == true)
			{
				Debug.Log("Stop level upgrade progress bar >>>>>>> "+attackedBuilding_01.gameObject.name);
				
				attackedBuilding_01.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				attackedBuilding_01.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			}
		
		}
		
		// building 2 health progress bar and time, assign creature and move creature
		if(attackedBuilding_02 != null)
		{
			attackedBuilding_02.transform.FindChild("Isometric_Collider").gameObject.tag = "attack";
			attackedBuilding_02.AddComponent("HealthProgressBar");
			attackedBuilding_02.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(true);
			HealthProgressBar hPB = attackedBuilding_02.GetComponent<HealthProgressBar>();
			hPB.SecCnt = scr_SfsRemote.getObjTime2;
			hPB.seconds = (float)hPB.SecCnt;
			hPB.attackCreature = caveCreature_02;
			hPB.caveCreaturePosOld = currentCreature_02Pos;
			
			GameObject healthBar =  attackedBuilding_02.transform.FindChild("HealthProgressBar").gameObject;
			healthBar.transform.FindChild("ProgressBarPlate").renderer.enabled = false;
			healthBar.transform.FindChild("RemainTime").renderer.enabled = false;
			healthBar.transform.FindChild("ProgressBarPov").gameObject.transform.FindChild("Plane").renderer.enabled = false;
			
			GameObject currentCave = caveCreature_02.transform.parent.gameObject;
			Debug.Log("currentCave : "+currentCave.name);
			
			if(attackedBuilding_02.transform.position.x < currentCave.transform.position.x)
				caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x * -1, caveCreature_02.transform.localScale.y, caveCreature_02.transform.localScale.z);
			else if(attackedBuilding_02.transform.position.x >= currentCave.transform.position.x)
				caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x, caveCreature_02.transform.localScale.y, caveCreature_02.transform.localScale.z);

			if (caveCreature_02.transform.root.gameObject.transform.localScale.x < 0)
				caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x * -1, caveCreature_02.transform.localScale.y, caveCreature_02.transform.localScale.z);
			else
				caveCreature_02.transform.localScale = new Vector3(caveCreature_02.transform.localScale.x , caveCreature_02.transform.localScale.y, caveCreature_02.transform.localScale.z);

			caveCreature_02.gameObject.tag = "busy";
			caveCreature_02.gameObject.renderer.enabled = false;
			caveCreature_02.transform.FindChild("Walk_anim").renderer.enabled = true;
			caveCreature_02.transform.FindChild("attack_anim").renderer.enabled = false;
			caveCreature_02.transform.FindChild("LessAgg2_anim").renderer.enabled = false;
			caveCreature_02.AddComponent("OrcCreatureMove");
			OrcCreatureMove orcCreature = caveCreature_02.GetComponent<OrcCreatureMove>();
			orcCreature.caveCreature = caveCreature_02;
			orcCreature.attackedBuilding = attackedBuilding_02;
			orcCreature.target = attackedBuilding_02.transform.position;
			
			//Stop level upgrade progress bar if level is being upgraded
			if(attackedBuilding_02.transform.FindChild("ProgressBar").gameObject.active == true)
			{
				Debug.Log("Stop level upgrade progress bar >>>>>>>>>>>> "+attackedBuilding_02.gameObject.name);
				
				attackedBuilding_02.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				attackedBuilding_02.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
			}
			
		}
	}
	
	//---- Stop attack tasks when cave is destroyed ---- // 
	public void StopAttackTask(int type01, int type02)
	{
		if(caveTimer != null)
			Destroy(caveTimer);
		
		string building01 = scr_LoadUserworld.ReturnBuildingNameFromTypeid(type01); 
		string building02 = scr_LoadUserworld.ReturnBuildingNameFromTypeid(type02);
		
		GameObject building_01Progress = GameObject.Find(building01);
		GameObject building_02Progress = GameObject.Find(building02);

		if(building_01Progress != null)
		{
			building_01Progress.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			building_01Progress.gameObject.GetComponent<HealthProgressBar>().isProgressBarIncreasing = true;
		}
		
		if(building_02Progress != null)
		{
			building_02Progress.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";	
			building_02Progress.gameObject.GetComponent<HealthProgressBar>().isProgressBarIncreasing = true;
		}
			
	}
	
}
