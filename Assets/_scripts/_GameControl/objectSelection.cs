using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectSelection : MonoBehaviour 
{
	public static GameObject curSelectedObj = null;
	public Camera cam;
	public Camera guiCam;
	RaycastHit hit;
	RaycastHit guiHit;
	
	// creature button material
	public Material hound_Mat, barg_Mat, cusith_Mat, sprout_Mat, nymph_Mat, dryad_Mat, nix_Mat, draug_Mat, dragon_Mat;
	public Material leech_Mat, leshy_Mat, lurker_Mat, dHound_Mat, fenrir_Mat, hellHound_Mat, sprite_Mat, imp_Mat, djinn_Mat;
	
	// creature button texture
	public Texture houndOrig_Tex, bargOrig_Tex;
	
	// creature button texture sprite atlas
	public Texture houndSA_Tex, bargSA_Tex;
	
	// creature button
	public GameObject creature01_Obj, creature02_Obj;
	
	private bool guiHitBool = false;
	public static bool objectSelectionBool = true;
	public static bool selectionPatchEnableBool = false;
	public guiControl scr_guiControl;
	public SfsRemote scr_sfsRemote;
	private int worldCnt;
	public AudioController scr_audioController;
	
	void Awake()
	{
		scr_guiControl = GameObject.Find("GUIManager").GetComponent<guiControl>();
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//if (curSelectedObj != null && GameManager.currentMovableObj != null)
		//	//Debug.Log("cur selected obj ::> " + curSelectedObj.tag + " --- " + GameManager.currentMovableObj.tag);
		if (!objectSelectionBool)
			return;
		else if (guiControl.popUpOpenBool == false)
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			Ray guiRay = guiCam.ScreenPointToRay(Input.mousePosition);
			
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(guiRay, out guiHit))
				{
					guiHitBool = true;
				}
				else
					guiHitBool = false;
			}
			
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(ray, out hit))
				{
					
					////Debug.Log(" ::: " + hit.collider.gameObject.layer + " <<<--- ");
					if ((hit.collider.gameObject.tag == "editableObj" || hit.collider.gameObject.tag == "nonMovableObj" /*|| hit.collider.gameObject.tag == "working"*/ ) && GameManager.gameLevel >= 3 && guiHitBool == false )
					{
						// find the current Garden Plot
						if (hit.collider.gameObject.transform.root.gameObject.tag == "Plot")
							GameManager.curPlot = hit.collider.gameObject.transform.root.gameObject;
						
						string objectName = hit.collider.gameObject.transform.root.gameObject.name.ToString();
						string[] worlds = objectName.Split('_');
					
						foreach (string world in worlds)
						{
							if (world == "B" || world == "TG" || world == "D")
							{
								if (curSelectedObj != null)
								{
									curSelectedObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
									curSelectedObj = null;
								}
								//GameManager.curDelObj = curSelectedObj;
								curSelectedObj = hit.collider.gameObject.transform.root.gameObject;
								curSelectedObj.transform.FindChild("selectionPatch").gameObject.active = true;
								curSelectedObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = true;
								
								//verify which object is selected and open panel
								if (curSelectedObj.tag == "TrainingGround" || curSelectedObj.tag == "PlantTG" || curSelectedObj.tag == "WaterTG" || curSelectedObj.tag == "Swamp" || curSelectedObj.tag == "DFireTG" || curSelectedObj.tag == "DEarthTG")
								{
									if (GameManager.curTG != null)
										Debug.Log(">>> " + GameManager.curTG.name);
									//Harish Chander
									//worldCnt++ ;
									
									//if(worldCnt <= 1)
									
									scr_guiControl.isGetMaxFeed = true;
									scr_sfsRemote.SendRequestForGetworld();
									
									
									if (curSelectedObj.tag == "TrainingGround")
									{
										TrainingGroundCreature();
										//DisableTGsounds();
									}
									else if (curSelectedObj.tag == "PlantTG")
									{
										PlantTrainingGroundCreature();
										//DisableTGsounds();
									}
									else if (curSelectedObj.tag == "WaterTG")
									{
										WaterTrainingGroundCreature();
									}
									else if (curSelectedObj.tag == "Swamp")
									{
										SwampTrainingGroundCreature();
										
									}
									else if (curSelectedObj.tag == "DEarthTG")
									{
										DEarthTrainingGroundCreature();
										//DisableTGsounds();
									}
									else if (curSelectedObj.tag == "DFireTG")
									{
										FireTrainingGroundCreature();
										//DisableTGsounds();
									}
									
									GameManager.curTG = curSelectedObj;
									GameManager.currentMovableObj = curSelectedObj;
									//GameManager.curDelObj = curSelectedObj;
									
									TrainingGroundBtnUnlock(GameManager.curTG);
									
									////Debug.Log("~~~~~~~~~~~~>>>>  " + GameManager.curCreature.name);
									objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfo.panelMoveIn = false;
									objPanelInfo.panelMoveOut = true;
									
									objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfoFrm.panelMoveIn = true;
									objPanelInfoFrm.panelMoveOut = false;
									
									objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
									attackPanelInfoAttack.panelMoveIn = true;
									attackPanelInfoAttack.panelMoveOut = false;
									
									objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
									movePanelInfo.panelMoveIn = true;
									movePanelInfo.panelMoveOut = false;
									
									// hide battle panel
									objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
									battlePanelInfo.panelMoveIn = true;
									battlePanelInfo.panelMoveOut = false;
									
									panelControl.panelMoveIn = true;
									panelControl.panelMoveOut = false;
								}
								
								if (curSelectedObj.tag == "Plot" || curSelectedObj.tag == "DPlot")
								{
//									//Debug.Log("farming............ " + curSelectedObj.tag);
									GameManager.curPlot = curSelectedObj;
									GameManager.currentMovableObj = curSelectedObj;
									
									int curLevel = curSelectedObj.GetComponent<upgradeProgressBar>().currentUpgradeLevel;
																		
									// deactivate button
									if (curLevel >= 3)										
										EnableUpgradeUIBtn(scr_guiControl.UpgradeFarmBtn,false);
									else
										EnableUpgradeUIBtn(scr_guiControl.UpgradeFarmBtn, true);
									
									objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfo.panelMoveIn = false;
									objPanelInfo.panelMoveOut = true;
									
									// hide training ground panel
									objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfoTG.panelMoveIn = true;
									objPanelInfoTG.panelMoveOut = false;
									
									objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
									attackPanelInfoAttack.panelMoveIn = true;
									attackPanelInfoAttack.panelMoveOut = false;
																		
									// hide move panel
									objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
									movePanelInfo.panelMoveIn = true;
									movePanelInfo.panelMoveOut = false;
									
									// hide battle panel
									objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
									battlePanelInfo.panelMoveIn = true;
									battlePanelInfo.panelMoveOut = false;
									
									panelControl.panelMoveIn = true;
									panelControl.panelMoveOut = false;
									
									//DisableTGsounds();
								}
								
								if ((world == "B" || world == "D") && curSelectedObj.tag != "Plot" && curSelectedObj.tag != "DPlot")// && curSelectedObj.tag != "nonMovableObj")
								{
									if (world == "B")
									{
										GameManager.curBuilding = curSelectedObj;
										GameObject.Find("ObjectMovePanel").gameObject.transform.FindChild("objUpgrade").gameObject.active = true;
									}
									else if (world == "D")
										GameObject.Find("ObjectMovePanel").gameObject.transform.FindChild("objUpgrade").gameObject.active = false;
									
									GameManager.currentMovableObj = curSelectedObj;
									GameManager.curDelObj = curSelectedObj;
									
									EnableBuildingSounds(curSelectedObj);
									
									objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
									movePanelInfo.panelMoveIn = false;
									movePanelInfo.panelMoveOut = true;
									
									// hide farm panel
									objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfo.panelMoveIn = true;
									objPanelInfo.panelMoveOut = false;
									
									// hide training ground panel
									objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfoTG.panelMoveIn = true;
									objPanelInfoTG.panelMoveOut = false;
									
									// hide attack panel
									objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
									attackPanelInfoAttack.panelMoveIn = true;
									attackPanelInfoAttack.panelMoveOut = false;
									
									// hide battle panel
									objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
									battlePanelInfo.panelMoveIn = true;
									battlePanelInfo.panelMoveOut = false;
									
									panelControl.panelMoveIn = true;
									panelControl.panelMoveOut = false;
									
									//DisableTGsounds();
								}
								
								if (world == "B" && (curSelectedObj.transform.root.gameObject.tag == "goblinCamp" || curSelectedObj.transform.root.gameObject.tag == "TrollHouse" || curSelectedObj.transform.root.gameObject.tag == "OrgCave"))
								{
									GameManager.curCave = curSelectedObj;
									
									EnableBuildingSounds(curSelectedObj);
									
									// attack button status
									//CaveAttackUnlock(GameManager.curCave);
									
									objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
									movePanelInfo.panelMoveIn = true;
									movePanelInfo.panelMoveOut = false;
									
									// hide farm panel
									objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfo.panelMoveIn = true;
									objPanelInfo.panelMoveOut = false;
									
									// hide training ground panel
									objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
									objPanelInfoTG.panelMoveIn = true;
									objPanelInfoTG.panelMoveOut = false;
									
									// hide attack panel
									objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
									attackPanelInfoAttack.panelMoveIn = false;
									attackPanelInfoAttack.panelMoveOut = true;
									Debug.Log("curSelectedObj = "+curSelectedObj.transform.name);
									if(GameManager.gameLevel >= 3)
									{
										for(int i=3; i<=GameManager.gameLevel; i++)
											CheckUnlockedCaves(i);
										
										//Debug.Log("objectList.Count = "+objectList.Count );
										CaveAttackButtonState(curSelectedObj);
										objectList.Clear();
									}
									
									// hide battle panel
									objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
									battlePanelInfo.panelMoveIn = true;
									battlePanelInfo.panelMoveOut = false;
									
									panelControl.panelMoveIn = true;
									panelControl.panelMoveOut = false;
									
									//DisableTGsounds();
								}
							}
						}
					}
				
		
					if(hit.collider.gameObject.name == "HalfLing_Map" || hit.collider.gameObject.name == "Darkling_Map")
					{
						if (curSelectedObj != null && !selectionPatchEnableBool)
						{
							
							curSelectedObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
							curSelectedObj = null;
							grid.curObj = null;
							//GameManager.curDelObj = null;
							
						//	DisableTGsounds();
						}
						
						// hide panels
						if (GameManager.gameLevel >= 3)
						{
							// hide attack panel
							objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
							attackPanelInfo.panelMoveIn = true;
							attackPanelInfo.panelMoveOut = false;
						
							// hide battle panel
							objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
							battlePanelInfo.panelMoveIn = true;
							battlePanelInfo.panelMoveOut = false;
							
							// hide plant panel
							objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
							objPanelInfo.panelMoveIn = true;
							objPanelInfo.panelMoveOut = false;
							
							// hide TrainingGround panel
	/*						objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
							sparkPanelInfo.panelMoveIn = true;
							sparkPanelInfo.panelMoveOut = false;*/
							
							// hide move panel
							objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
							movePanelInfo.panelMoveIn = true;
							movePanelInfo.panelMoveOut = false;
						}
					}
				}
			}
		}
	}
	
	private List<GameObject> objectList = new List<GameObject>();
	private void CheckUnlockedCaves(int gameLevel)
	{
		switch(gameLevel)
		{
		case 3 :
			objectList.Add(GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01"));
			break;
			
		case 4 :
			objectList.Add(GameObject.Find("HC_B_GoblinCamp_GO(Clone)_02"));
			
			break;
			
		case 5:
			objectList.Add(GameObject.Find("DL_B_GoblinCamp_GO(Clone)_01"));
			
			break;
		
		case 6:
			
			objectList.Add(GameObject.Find("HC_B_GoblinCamp_GO(Clone)_03"));
			break;
			
		case 7:
			
			objectList.Add(GameObject.Find("DL_B_GoblinCamp_GO(Clone)_02"));
			break;
			
		case 8:
			
			objectList.Add(GameObject.Find("HC_B_TrollHouse_GO(Clone)_01"));
			break;
			
		case 9:
			
			objectList.Add(GameObject.Find("DL_B_GoblinCamp_GO(Clone)_03"));
			break;
			
		case 10:
			
			objectList.Add(GameObject.Find("HC_B_TrollHouse_GO(Clone)_02"));
			break;
			
		case 11:
			
			objectList.Add(GameObject.Find("DL_B_TrollHouse_GO(Clone)_01"));
			break;
			
		case 12:
			
			objectList.Add(GameObject.Find("HC_B_TrollHouse_GO(Clone)_03"));
			break;
			
		case 13:
			
			objectList.Add(GameObject.Find("DL_B_TrollHouse_GO(Clone)_02"));
			break;
			
		case 14:
			
			objectList.Add(GameObject.Find("HC_B_OrgCave_GO(Clone)_01"));
			break;
		
		default :
			break;
		}
	}
	
	private void CaveAttackButtonState(GameObject currentObject)
	{
		if(currentObject == null)
			return;
		
		if(objectList.Contains(currentObject))
			scr_guiControl.AttackUIbtn.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
		else
			scr_guiControl.AttackUIbtn.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.DISABLED);	
	}
	
	public void TrainingGroundCreature()
	{
		Debug.Log("-> Training Ground Creature : " + curSelectedObj.name);
		//Debug.Log("---> Earth <--- " + GameManager.earthTG_Creature_Cnt);
		// creature button 01
		if (curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)") != null && GameManager.earthTG_Creature_Cnt == 1)
		{
			//Debug.Log(" -----> Hound <----- ");
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = hound_Mat;
		}
		else if (curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)") != null && GameManager.earthTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = barg_Mat;
		}
		else if (curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)") != null && GameManager.earthTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = cusith_Mat;
		}
		else
		{
            creature01_Obj.active = false;
            creature02_Obj.active = false;
		}
		
		// hound 01 - barg
		if ((curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)") != null) && GameManager.earthTG_Creature_Cnt == 2)
		{
			//Debug.Log(" +++ hound -- barg +++ 02");
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = barg_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = hound_Mat;
		}
		
		// hound 01 - cusith
		else if ((curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)") != null) && GameManager.earthTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = cusith_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Hound_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = hound_Mat;
		}
		
		// barg - cusith
		else if ((curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)") != null) && GameManager.earthTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Barg_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = barg_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Cusith_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = cusith_Mat;
		}
	}
	
	// Plant Training Ground Creature
	void PlantTrainingGroundCreature()
	{
		if (GameManager.plantTG_Creature_Cnt == 0)
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}
	    bool somethingActive = false;
		//Debug.Log("---> Plant <--- " + GameManager.plantTG_Creature_Cnt);
		// creature button 01
		if (curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)") != null && GameManager.plantTG_Creature_Cnt == 1)
		{
			//Debug.Log("---------------******************----------------");
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = sprout_Mat;
		    somethingActive = true;
		}
		else if (curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)") != null && GameManager.plantTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = nymph_Mat;
            somethingActive = true;

		}
		else if (curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)") != null && GameManager.plantTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = dryad_Mat;
            somethingActive = true;

		}
		
		// sprout -- nymph
		if ((curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)") != null) && GameManager.plantTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = sprout_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = nymph_Mat;
            somethingActive = true;

		}
		
		// sprout -- dryad
		else if ((curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)") != null) && GameManager.plantTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Sprout_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = sprout_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dryad_Mat;
            somethingActive = true;

		}
		
		// dryad -- nymph
		else if ((curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)") != null) && GameManager.plantTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Nymph_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = nymph_Mat;

			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Dryad_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dryad_Mat;
            somethingActive = true;
		}

	    if (!somethingActive)
	    {
            creature01_Obj.active = false;
            creature02_Obj.active = false;
	    }
	}
	
	// Water Training Ground Creature
	void WaterTrainingGroundCreature()
	{
		if (GameManager.waterTG_Creature_Cnt == 0)
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}

	    bool somethingActive = false;
		
			//Debug.Log("---> Water <---  " + GameManager.waterTG_Creature_Cnt);
		// creature button 01
		if (curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)") != null && GameManager.waterTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = nix_Mat;
		    somethingActive = true;
		}
		else if (curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)") != null && GameManager.waterTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = draug_Mat;
            somethingActive = true;

		}
		else if (curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)") != null && GameManager.waterTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = dragon_Mat;
            somethingActive = true;

		}
	
		
		// nix -- draug
		if ((curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)") != null) && GameManager.waterTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = nix_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = draug_Mat;
            somethingActive = true;

		}
	
		
		// nix -- dragon
		else if ((curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)") != null) && GameManager.waterTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Nix_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = nix_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dragon_Mat;
            somethingActive = true;

		}
		
		// dragon -- draug
		else if ((curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)") != null && curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)") != null) && GameManager.waterTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("HC_C_Draug_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = draug_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("HC_C_Dragon_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dragon_Mat;
            somethingActive = true;

		}

	    if (!somethingActive)
	    {
            creature01_Obj.active = false;
            creature02_Obj.active = false;
	    }
	}
	
	// Swamp Training Ground Creature
	void SwampTrainingGroundCreature()
	{
		if (GameManager.swampTG_Creature_Cnt == 0)
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}

	    bool somethingActive = false;

		//Debug.Log("---> Swamp <--- " + GameManager.swampTG_Creature_Cnt);
		// creature button 01
		if (curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)") != null && GameManager.swampTG_Creature_Cnt == 1)
		{
			//Debug.Log("swamp icon change...");
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = leech_Mat;
		    somethingActive = true;
		}
		else if (curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)") != null && GameManager.swampTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
		    somethingActive = true;
			creature01_Obj.renderer.material = leshy_Mat;
            somethingActive = true;
        }
		else if (curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)") != null && GameManager.swampTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = lurker_Mat;
            somethingActive = true;
        }
		
		// creature button 02
		
		// leech -- leech
		/*if ((curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)") != null) && GameManager.swampTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = leech_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = leech_Mat;
		}*/
		
		// leech -- leshy
		if ((curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)") != null) && GameManager.swampTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = leech_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = leshy_Mat;
            somethingActive = true;
        }
		
		// leech -- lurker
		else if ((curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)") != null) && GameManager.swampTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leech_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = leech_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = lurker_Mat;
            somethingActive = true;
        }
		
		// leshy -- lurker
		else if ((curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)") != null) && GameManager.swampTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Leshy_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = leshy_Mat;
			
			// creature button 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Lurker_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = lurker_Mat;
            somethingActive = true;

		}
	    if (!somethingActive)
	    {
            creature01_Obj.active = false;
            creature02_Obj.active = false;
	    }

	    scr_audioController.audio_DLswamp.Play();
					scr_audioController.audio_DLswamp.loop = true;
					scr_audioController.audio_DLswamp.volume = 0.8f;
					scr_audioController.audio_DLswamp.minDistance = 1;
					scr_audioController.audio_DLswamp.maxDistance = 10;
	}
	
	// Dark Earth Training Ground Creature
	void DEarthTrainingGroundCreature()
	{
		if (GameManager.earthTG_Creature_Cnt == 0)
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}

	    bool somethingActive = false;
		
		//Debug.Log("---> D Earth <---" + GameManager.dEarthTG_Creature_Cnt);
		// creature button 01
		if (curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)") != null && GameManager.dEarthTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = dHound_Mat;

		    somethingActive = true;
		}
		else if (curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)") != null && GameManager.dEarthTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = fenrir_Mat;
            somethingActive = true;
        }
		else if (curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)") != null && GameManager.dEarthTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = hellHound_Mat;
            somethingActive = true;
        }
		else
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}
		
		// dhound 01 - fenrir
		if ((curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)") != null) && GameManager.dEarthTG_Creature_Cnt == 2)
		{
			//Debug.Log(" +++ hound -- barg +++ 02");
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = fenrir_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dHound_Mat;
            somethingActive = true;
        }
		
		// dhound 01 - hellHound
		else if ((curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)") != null) && GameManager.dEarthTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = hellHound_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_DHound_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = dHound_Mat;
            somethingActive = true;
        }
		
		// fenrir - hell hound
		else if ((curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)") != null) && GameManager.dEarthTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Fenrir_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = fenrir_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_HellHound_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = hellHound_Mat;
            somethingActive = true;
		}

        if (!somethingActive)
        {
            creature01_Obj.active = false;
            creature02_Obj.active = false;
        }
	}
	
	// Fire Training Ground Creature
	void FireTrainingGroundCreature()
	{
		if (GameManager.fireTG_Creature_Cnt == 0)
		{
			creature01_Obj.active = false;
			creature02_Obj.active = false;
		}

	    bool somethingActive = false;

		//Debug.Log("---> Fire <---");
		// creature button 01
		if (curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)") != null && GameManager.fireTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = sprite_Mat;

		    somethingActive = true;
		}
		else if (curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)") != null && GameManager.fireTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = imp_Mat;
            somethingActive = true;
        }
		else if (curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)") != null && GameManager.fireTG_Creature_Cnt == 1)
		{
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature02_Obj.active = false;
			creature01_Obj.renderer.material = djinn_Mat;
            somethingActive = true;
        }
		
		// sprite 01 - imp
		if ((curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)") != null) && GameManager.fireTG_Creature_Cnt == 2)
		{
			//Debug.Log(" +++ hound -- barg +++ 02");
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = imp_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = sprite_Mat;
            somethingActive = true;
        }
		
		
		// sprite 01 - djinn
		else if ((curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)") != null) && GameManager.fireTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = djinn_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Sprite_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = sprite_Mat;
            somethingActive = true;
        }
		
		// imp - djinn
		else if ((curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)") != null && curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)") != null) && GameManager.fireTG_Creature_Cnt == 2)
		{
			// creature 01
			GameManager.curCreature01 = curSelectedObj.transform.FindChild("DL_C_Imp_GO(Clone)").gameObject;
			creature01_Obj.active = true;
			creature01_Obj.renderer.material = imp_Mat;
			
			// creature 02
			GameManager.curCreature02 = curSelectedObj.transform.FindChild("DL_C_Djinn_GO(Clone)").gameObject;
			creature02_Obj.active = true;
			creature02_Obj.renderer.material = djinn_Mat;
            somethingActive = true;
        }

	    if (!somethingActive)
	    {
            creature01_Obj.active = false;
            creature02_Obj.active = false; 
	    }
	}
	
	
	void EnableUpgradeUIBtn(GameObject go ,bool normalState)
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
	
	void EnableUpgradeBtn(GameObject go,int gamelevel,int objlevel)
	{
		switch(go.gameObject.tag)
		{
			
		    case "HHouse":
			
			           if(gamelevel >= 1 && gamelevel < 7)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					       //  Debug.Log("Disabled : >>>>>>>>");
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         // Debug.Log("Enabled : >>>>>>>>");
					       }
				        }
				        else if(gamelevel >= 7)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         // Debug.Log("disabled : >>>>>>>>");
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         // Debug.Log("Enabled : >>>>>>>>");
					        }
				        }
			
			break;
			case "Inn":
				   
				        if(gamelevel >= 2 && gamelevel < 8)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					       
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					       
					       }
				        }
				        else if(gamelevel >= 8)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         Debug.Log("disabled  " );
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					      Debug.Log("Enabled  " );
					         
					        }
				        }
			
			break;
			
			case "Stable":
			
			           if(gamelevel >= 5 && gamelevel < 11)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					       
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 11)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					          
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					        }
				        }
			
			
			break;
			
			case "BlackSmith":
			
			           if(gamelevel >= 6 && gamelevel < 14)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 14)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					        }
				        }
			
			break;
			
		  case "Tavern":
			
			          if(gamelevel >= 9 && gamelevel < 18)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					       
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 18)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					        }
				        }
			
			break;
			
			case "Apothecary":
			       
			           if(gamelevel >= 10 && gamelevel < 12)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 12)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					        }
				        }
			
			break;
			
			case "DHouse":
			
			         if(gamelevel >= 4 && gamelevel < 7)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 7)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					          
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					        
					        }
				        }
			
			break;
			
			
			case "DInn":
			
			         if(gamelevel >= 4 && gamelevel < 8)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 8)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					          
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					          
					        }
				        }
			
			
			break;
			
			case "DStable":
			
			           if(gamelevel >= 5 && gamelevel < 11)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					       
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 11)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					          
					        }
				        }
			
			break;
			
			case "DApothecary":	
			
			          if(gamelevel >= 10 && gamelevel < 12)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					        
					       }
				        }
				        else if(gamelevel >= 12)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					         
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					          
					        }
				        }
			
			break;
			
			case "DTavern":
			
		            	if(gamelevel >= 9 && gamelevel < 18)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					        
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 18)
				        {
					        if(objlevel == 2) 
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
					          
					        }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					       
					        }
				        }
			
			
			break;
			
			case "DBlackSmith":
			
			           if(gamelevel >= 6 && gamelevel < 14)
			        	{
					       if(objlevel == 1)
					       {
					         EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
				           }
					       else
					       {
						     EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					         
					       }
				        }
				        else if(gamelevel >= 14)
				        {
					        if(objlevel == 2) 
					        {
					           EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,false);
			                }
					        else
					        {
						      EnableUpgradeUIBtn(scr_guiControl.UpgradeUIbtn,true);
					        }
				        }
			
			break;
		}
	}
	
	
	void EnableBuildingSounds(GameObject go)
	{
		upgradeProgressBar scr_Uplvl = go.GetComponent<upgradeProgressBar>();
		
		switch(go.gameObject.tag)
		{
			
		case "goblinCamp":
			
			if(!scr_audioController.audio_Goblincave.isPlaying)
			{			
			scr_audioController.audio_Goblincave.transform.position = go.transform.position;
			scr_audioController.audio_Goblincave.Play();
			scr_audioController.audio_Goblincave.volume = 0.7f;
			scr_audioController.audio_Goblincave.minDistance = 1;
			scr_audioController.audio_Goblincave.maxDistance = 20;
			}
					
			break;
			
		case "TrollHouse":
			
			if(!scr_audioController.audio_TrollCave.isPlaying)
			{
			scr_audioController.audio_TrollCave.transform.position = go.transform.position;
			scr_audioController.audio_TrollCave.Play();
			scr_audioController.audio_TrollCave.volume = 0.7f;
			scr_audioController.audio_TrollCave.minDistance = 1;
			scr_audioController.audio_TrollCave.maxDistance = 20;
			}
			
			break;
			
		case "OrgCave":
			
			if(!scr_audioController.audio_Orgcave.isPlaying)
			{
			scr_audioController.audio_Orgcave.transform.position = go.transform.position;
			scr_audioController.audio_Orgcave.Play();
			scr_audioController.audio_Orgcave.volume = 0.7f;
			scr_audioController.audio_Orgcave.minDistance = 1;
			scr_audioController.audio_Orgcave.maxDistance = 20;
			}
			
			break;
	
			
		case "Apothecary":
		case "DApothecary":	
			
			if(!scr_audioController.audio_Apothecary.isPlaying)
			{
			scr_audioController.audio_Apothecary.transform.position = go.transform.position;
			scr_audioController.audio_Apothecary.Play();
			scr_audioController.audio_Apothecary.volume = 0.7f;
			scr_audioController.audio_Apothecary.minDistance = 1;
			scr_audioController.audio_Apothecary.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			scr_sfsRemote.SendRequestforScheduleTasksinMinigames();
			
			break;
			
		case "BlackSmith":
		case "DBlackSmith":
			
			if(!scr_audioController.audio_Blacksmith.isPlaying)
			{
			scr_audioController.audio_Blacksmith.transform.position = go.transform.position;
			scr_audioController.audio_Blacksmith.Play();
			scr_audioController.audio_Blacksmith.volume = 0.7f;
			scr_audioController.audio_Blacksmith.minDistance = 1;
			scr_audioController.audio_Blacksmith.maxDistance = 20;
			}
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			break;
			
			
		case "HHouse":
		
			if(!scr_audioController.audio_Halfinghouse.isPlaying)
			{
			scr_audioController.audio_Halfinghouse.transform.position = go.transform.position;
			scr_audioController.audio_Halfinghouse.Play();
			scr_audioController.audio_Halfinghouse.volume = 0.7f;
			scr_audioController.audio_Halfinghouse.minDistance = 1;
			scr_audioController.audio_Halfinghouse.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			break;
			
		case "DHouse":
			
			if(!scr_audioController.audio_Darklinghouse.isPlaying)
			{
			scr_audioController.audio_Darklinghouse.transform.position = go.transform.position;
			scr_audioController.audio_Darklinghouse.Play();
			scr_audioController.audio_Darklinghouse.volume = 0.7f;
			scr_audioController.audio_Darklinghouse.minDistance = 1;
			scr_audioController.audio_Darklinghouse.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			break;
			
		case "Inn":
		case "DInn":
			
			if(!scr_audioController.audio_Inn.isPlaying)
			{
			scr_audioController.audio_Inn.transform.position = go.transform.position;
			scr_audioController.audio_Inn.Play();
			scr_audioController.audio_Inn.volume = 0.7f;
			scr_audioController.audio_Inn.minDistance = 1;
			scr_audioController.audio_Inn.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			break;
			
			
		case "Stable":
		case "DStable":
			
			
			if(!scr_audioController.audio_stables.isPlaying)
			{
			scr_audioController.audio_stables.transform.position = go.transform.position;
			scr_audioController.audio_stables.Play();
			scr_audioController.audio_stables.volume = 0.7f;
			scr_audioController.audio_stables.minDistance = 1;
			scr_audioController.audio_stables.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			break;
			
		case "Tavern":
		case "DTavern":
			
			if(!scr_audioController.audio_tavern.isPlaying)
			{			
			scr_audioController.audio_tavern.transform.position = go.transform.position;
			scr_audioController.audio_tavern.Play();
			scr_audioController.audio_tavern.volume = 0.7f;
			scr_audioController.audio_tavern.minDistance = 1;
			scr_audioController.audio_tavern.maxDistance = 20;
			}
			
			EnableUpgradeBtn(go,GameManager.gameLevel,scr_Uplvl.currentUpgradeLevel);
			
			scr_sfsRemote.SendRequestforScheduleTasksinMinigames();
			
			break;
		}
	}
	
	// training ground upgrade button unlock
	void TrainingGroundBtnUnlock(GameObject tgObj)
	{
		if (tgObj.tag == "TrainingGround")
		{
			if (GameManager.earthTG_lvl == 1 && GameManager.gameLevel >= 4)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.earthTG_lvl == 2 && GameManager.gameLevel >= 8)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
		
		if (tgObj.tag == "PlantTG")
		{
			if (GameManager.plantTG_lvl == 1 && GameManager.gameLevel >= 6)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.plantTG_lvl == 2 && GameManager.gameLevel >= 9)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
		
		if (tgObj.tag == "WaterTG")
		{
			if (GameManager.waterTG_lvl == 1 && GameManager.gameLevel >= 8)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.waterTG_lvl == 2 && GameManager.gameLevel >= 12)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
		
		if (tgObj.tag == "DEarthTG")
		{
			if (GameManager.dEarthTG_lvl == 1 && GameManager.gameLevel >= 8)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.dEarthTG_lvl == 2 && GameManager.gameLevel >= 13)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
		
		if (tgObj.tag == "DFireTG")
		{
			if (GameManager.fireTG_lvl == 1 && GameManager.gameLevel >= 9)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.fireTG_lvl == 2 && GameManager.gameLevel >= 14)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
		
		if (tgObj.tag == "Swamp")
		{
			if (GameManager.swampTG_lvl == 1 && GameManager.gameLevel >= 7)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else if (GameManager.swampTG_lvl == 2 && GameManager.gameLevel >= 12)
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, true);
			
			else
				EnableUpgradeUIBtn(scr_guiControl.tgUpgradeBtn, false);
		}
	}
	
	void CaveAttackUnlock(GameObject caveObj)
	{
		// for H Goblin Cave
		GameObject bargCreature = GameObject.Find("HC_C_Barg_GO(Clone)") as GameObject;
		GameObject cusithCreature = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
		
		GameObject sproutCreature = GameObject.Find("HC_C_Sprout_GO(Clone)") as GameObject;
		GameObject nymphCreature = GameObject.Find("HC_C_Nymph_GO(Clone)") as GameObject;
		GameObject dryadCreature = GameObject.Find("HC_C_Dryad_GO(Clone)") as GameObject;
		
		GameObject nixCreature = GameObject.Find("HC_C_Nix_GO(Clone)") as GameObject;
		GameObject draugCreature = GameObject.Find("HC_C_Draug_GO(Clone)") as GameObject;
		GameObject dragonCreature = GameObject.Find("HC_C_Dragon(Clone)") as GameObject;
		
		// for D Caves
		GameObject leechCreature = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
		GameObject leshyCreature = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
		GameObject lurkerCreature = GameObject.Find("DL_C_Lurker_GO(Clone)") as GameObject;
		
		GameObject spriteCreature = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
		GameObject impCreature = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
		GameObject djinnCreature = GameObject.Find("DL_C_Djinn_GO(Clone)") as GameObject;
		
		if (bargCreature != null && GameManager.barg_lvl >= 5 && caveObj.name == "HC_B_GoblinCamp_GO(Clone)_02" && GameManager.gameLevel >= 4)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (cusithCreature != null && GameManager.cusith_lvl >= 5 && caveObj.name == "HC_B_GoblinCamp_GO(Clone)_02" && GameManager.gameLevel >= 4)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (cusithCreature != null && GameManager.cusith_lvl >= 10 && caveObj.name == "HC_B_GoblinCamp_GO(Clone)_03" && GameManager.gameLevel >= 6)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (sproutCreature != null && GameManager.sprout_lvl >= 1 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 8)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (nymphCreature != null && GameManager.nymph_lvl >= 1 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 8)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (dryadCreature != null && GameManager.dryad_lvl >= 1 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 8)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (nymphCreature != null && GameManager.nymph_lvl >= 5 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_02" && GameManager.gameLevel >= 10)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (dryadCreature != null && GameManager.dryad_lvl >= 5 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_02" && GameManager.gameLevel >= 10)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (dryadCreature != null && GameManager.dryad_lvl >= 10 && caveObj.name == "HC_B_TrollHouse_GO(Clone)_03" && GameManager.gameLevel >= 12)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (nixCreature != null && GameManager.nix_lvl >= 1 && caveObj.name == "HC_B_OrgCave_GO(Clone)_01" && GameManager.gameLevel >= 14)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (draugCreature != null && GameManager.draug_lvl >= 1 && caveObj.name == "HC_B_OrgCave_GO(Clone)_01" && GameManager.gameLevel >= 14)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (dragonCreature != null && GameManager.dragon_lvl >= 1 && caveObj.name == "HC_B_OrgCave_GO(Clone)_01" && GameManager.gameLevel >= 14)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		
		else if (leechCreature != null && GameManager.leech_lvl >= 1 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_01" && GameManager.gameLevel >= 5)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (leshyCreature != null && GameManager.leshy_lvl >= 1 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_01" && GameManager.gameLevel >= 5)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (lurkerCreature != null && GameManager.lurker_lvl >= 1 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_01" && GameManager.gameLevel >= 5)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (leshyCreature != null && GameManager.leshy_lvl >= 5 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_02" && GameManager.gameLevel >= 7)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (lurkerCreature != null && GameManager.lurker_lvl >= 5 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_02" && GameManager.gameLevel >= 7)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (lurkerCreature != null && GameManager.lurker_lvl >= 10 && caveObj.name == "DL_B_GoblinCamp_GO(Clone)_03" && GameManager.gameLevel >= 9)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (spriteCreature != null && GameManager.sprite_lvl >= 1 && caveObj.name == "DL_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 11)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (impCreature != null && GameManager.imp_lvl >= 1 && caveObj.name == "DL_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 11)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (djinnCreature != null && GameManager.djinn_lvl >= 1 && caveObj.name == "DL_B_TrollHouse_GO(Clone)_01" && GameManager.gameLevel >= 11)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (impCreature != null && GameManager.imp_lvl >= 5 && caveObj.name == "DL_B_TrollHouse_GO(Clone)_02" && GameManager.gameLevel >= 13)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else if (djinnCreature != null && GameManager.djinn_lvl >= 5 && caveObj.name == "DL_B_TrollHouse_GO(Clone)_02" && GameManager.gameLevel >= 13)
		{
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, true);
		}
		else
			EnableUpgradeUIBtn(scr_guiControl.AttackUIbtn, false);
	}
}
