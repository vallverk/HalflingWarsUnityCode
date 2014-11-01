using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}		
			
		
			
				
			
		
	/*void Farming(GameObject plantPF, string objName, int objTypeId)
	{
		GameObject go = Instantiate(plantPF, new Vector3(GameManager.curPlot.transform.position.x, 
																					GameManager.curPlot.transform.position.y+0.05f, 
																					GameManager.curPlot.transform.position.z), 
																					Quaternion.Euler(0, 180, 0)) as GameObject;
				
		GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.parent = GameManager.curPlot.transform;
		
		plotInformation plotInfo = go.GetComponent("plotInformation") as plotInformation;
		plotInfo.usingGardenPlot = GameManager.curPlot;
		
		progressBar plantPB = go.GetComponent("progressBar") as progressBar;
		plantPB.enabled = true;
		
		// task sent to server
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_sfsRemoteCnt.SendRequestForBuyItems("5","plantType", objName,"2");			
		SendPos = GameManager.curPlot.transform.position;
		SendRot = new Vector3(0,180,0);
		TempTypeId = objTypeId;
		isTaskFarming = true;
		SendGo = go;
	    plotname = GameManager.curPlot.name;
		
		// activate rabbit button
		Transform harvest = go.transform.FindChild("HarvestButton").gameObject.transform.FindChild("Harvest") as Transform;
		Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false); 
		go.transform.FindChild("RabbtiButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
		
		UIButton h_DelObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
		h_DelObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		UIButton r_DelObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		r_DelObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		harvest.gameObject.SetActiveRecursively(false);
	}*/
	
	/*void HarvestActivation(Texture plantTex)
	{
		GameObject go = GameManager.currentPlant;
		Destroy(go.GetComponent<progressBar>());
		Destroy(go.transform.FindChild("ProgressBar").gameObject);
		go.renderer.material.mainTexture = plantTex;

		// destroy rabbit button
		Destroy(go.transform.FindChild("RabbtiButton").gameObject);
	
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
        taskidSvr = scr_loadUserWorld.ReturnTaskIdforIds(GetIdFromString(go.name));
		scr_sfsRemoteCnt.AcceleratePlantPlantsTask(taskidSvr);
		

		// update spark score
		UpdateScore();
		//GameManager.sparks = GameManager.sparks - 1;
		guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
		go.GetComponent<plantBurn>().enabled = true;
		go.transform.FindChild("HarvestButton").gameObject.SetActiveRecursively(true);
		go.transform.FindChild("HarvestButton").gameObject.GetComponent<buttonPulse>().scaleAnim = false;
	}*/
	
	/*void Harvesting()
	{
		plantHerbsHarvestCount();
				
		guiControlInfo.currentHarvestButton.transform.parent.gameObject.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
		GameObject getXpPref = Instantiate(gameManagerInfo.xpValObj, guiControlInfo.currentHarvestButton.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
		getXpPref.GetComponent<getPlantXP>().xpObj = guiControlInfo.currentHarvestButton.tag;
		getXpPref.GetComponent<getPlantXP>().xpAnimBool = true;
				
		Destroy(guiControlInfo.currentHarvestButton);
				
		//sent to server
		scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
				
		int PlantId = GetIdFromString(guiControlInfo.currentHarvestButton.name);
		scr_sfsRemoteCnt.SendRequestForHarverst(scr_loadUserWorld.ReturnFarmId(PlantId), PlantId);
	}*/
	
	/*void CreateCreature(GameObject creaturePref, string objName, int objTypeId, int objTrainingGroundId, bool morphingBool, float rotX, float rotY, float rotZ, float posY)
	{
		GameObject go = Instantiate(creaturePref, new Vector3(GameManager.curTG.transform.position.x,
																					GameManager.curTG.transform.position.y + 0.01f,
																					GameManager.curTG.transform.position.z + 2f), Quaternion.Euler(rotX, rotY, rotZ)) as GameObject;
		
		go.transform.parent = GameManager.curTG.transform;
		go.transform.position = new Vector3(go.transform.position.x, posY, go.transform.position.z);
				
		GameManager.curTG.transform.FindChild("Isometric_Collider").gameObject.tag = "using";
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		GameObject map = GameObject.Find("HalfLing_Map").gameObject;
				
		GameManager.curTG.transform.FindChild("Spark").gameObject.active = true;
				
		//enable Sounds
		scr_audioController.audio_sparkEarth.transform.position = GameManager.curTG.transform.position;
		scr_audioController.audio_sparkEarth.volume = 0.7f;
		scr_audioController.audio_sparkEarth.Play();
		scr_audioController.audio_sparkEarth.minDistance = 1;
		scr_audioController.audio_sparkEarth.maxDistance = 20;
				
		PlaySparkBirthsound(GameManager.curTG.transform.position);
		
		GameManager.curTG.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
		go.renderer.enabled = false;
		
		// activate creature progress bar
		(go.GetComponent("progressBar") as progressBar).enabled = true;
		guiControlInfo.creatureTemp = go;
		
		// attach guiControl script to rabbit ui button
		Transform rabbit = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
		go.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false); 
		
		UIButton delObjUIButtonInfo = rabbit.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
		panelControl.panelAnimBool = false; //main menu animation off
				
		if (!morphingBool)
		{
			scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
			scr_sfsRemoteCnt.SendRequestForBuyItems("2","creatureType", objName,"2");
			SendParentObjid = objTrainingGroundId;
			TempTypeId = objTypeId;
			SendPos = new Vector3(GameManager.curTG.transform.position.x,GameManager.curTG.transform.position.y,GameManager.curTG.transform.position.z);
			SendRot = new Vector3(0,180,0);
			isTaskCreature = true;
		}
	}*/
}
