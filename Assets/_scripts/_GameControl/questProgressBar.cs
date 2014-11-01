using UnityEngine;
using System.Collections;

public class questProgressBar : MonoBehaviour 
{
	public GameObject progressBarObj;
	public GameObject progressBarPov;
	public SpriteText qestSText;
	
	public int cnt = 0;
	
	public int estimateTime = 0;
	
	public guiControl guiControlInfo;
	public popUpInformation popUpInfoScript;
	
	public float qSeconds;
	private bool runOneTimeBool = false;
	private SfsRemote scr_Remote;
	public int questCnt = 0;
	private AudioController scr_audioController;
	private GameManager gameManagerInfo;
	private AchivementsDetails ad;
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("quest progress bar...");
		StartCoroutine(updateProgressBar());
		
		guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		popUpInfoScript = GameObject.Find("PopUPManager").GetComponent("popUpInformation") as popUpInformation;
		scr_Remote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
	 	scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		
		runOneTimeBool = true;
		questCnt = (GameManager.quest + 1);
		qestSText.Text = questCnt.ToString();
		
		gameManagerInfo = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
	}
	
	IEnumerator updateProgressBar()
    {
		//if (progressBarPov.gameObject == null)
		//	return;
		
        while(true)
        {
			if (cnt <= qSeconds)
				progressBarPov.transform.localScale = new Vector3(progressBarPov.transform.localScale.x + (1f / qSeconds)/*0.00167f*/,
																	progressBarPov.transform.localScale.y,
																	progressBarPov.transform.localScale.z);
			cnt++;	
			
//			Debug.Log(cnt);
        	yield return new WaitForSeconds(1);
		}
        
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (cnt == qSeconds)
		{
			Debug.Log("cnt == qSeconds........");
			if (runOneTimeBool)
			{
				if(GameManager.quest == 0 || GameManager.quest == 4 || GameManager.quest == 5 || GameManager.quest == 6 || GameManager.quest == 7 || GameManager.quest == 8 || GameManager.quest == 9 || GameManager.quest == 10 || GameManager.quest == 11)
				{
				GameManager.questRunningBool = true;
				}
				else
				{
				GameManager.questRunningBool = false;
				}
				Debug.Log("cnt == qSeconds :: runOneTimeBool..........");
				runOneTimeBool = false;
				
				if (GameManager.quest == 0)
				{
					Debug.Log("GameManager.quest == 0............");
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					// hide any open window
					guiControlInfo.inventoryUI.SetActiveRecursively(false);
					guiControlInfo.plantsUI.SetActiveRecursively(false);
					// update score
					GameObject.Find("HC_C_Hound_GO(Clone)").gameObject.GetComponent<MeshRenderer>().enabled = true;
					GameObject.Find("HC_C_Hound_GO(Clone)").gameObject.transform.FindChild("shadow").gameObject.GetComponent<MeshRenderer>().enabled = true;
					 					ad.percentComplete6 = 100;
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 2)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					GameObject.Find("DL_C_Leech_GO(Clone)").gameObject.GetComponent<MeshRenderer>().enabled = true;
					Destroy(this.gameObject);
					GameManager.popUpCount = 38;
					popUpInfoScript.curPopUpCnt = 38;
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.updateCurPopUpCount();
					popUpInfoScript.updatePopUpCount();
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				}
				
				if (GameManager.quest == 3)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					GameObject.Find("DL_C_Leech_GO(Clone)").gameObject.GetComponent<MeshRenderer>().enabled = true;
					gameManagerInfo.dChar.SetActiveRecursively(true);
					Destroy(this.gameObject);
					GameManager.popUpCount = 41;
					popUpInfoScript.curPopUpCnt = 41;
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.updateCurPopUpCount();
					popUpInfoScript.updatePopUpCount();
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				}
				
				if (GameManager.quest == 4)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 5)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					 					ad.percentComplete19 = 100;
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 6)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 7)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 8)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 9)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 10)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
				
				if(GameManager.quest == 11)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest);
					 					ad.percentComplete42 = 100;
					Destroy(this.gameObject);
				}
				
				if (GameManager.quest == 12)
				{
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					scr_Remote.SendRequestforQuestCount(GameManager.quest); //quest sent to server
					Destroy(this.gameObject);
				}
			}
		}
	}
}
