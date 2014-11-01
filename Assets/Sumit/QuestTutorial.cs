using UnityEngine;
using System.Collections;

public class QuestTutorial : MonoBehaviour {
	
	private GameObject arrowHand;
	private GameObject HandObj;
	private GameObject generatedArrow;
	
	private popUpInformation scr_popUpInformation;
	
	void Start () 
	{
		Debug.Log ("quest tutorial step 01...");
		arrowHand = Resources.Load("gameArrowPF") as GameObject;
		scr_popUpInformation = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
		scr_popUpInformation.guiControlInfo.storyLogButton.active = false;
		scr_popUpInformation.guiControlInfo.storyLogButton.SetActive(false);
		Debug.Log ("quest tutorial step 02...");
	}
	
	
	public void PlushArrow(int whichPlace)
	{
		scr_popUpInformation.guiControlInfo.storyLogButton.active = false;
		HandObj = Instantiate(arrowHand) as GameObject;

		switch(whichPlace)
		{
			case 1:
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;
				
				HandObj.transform.localPosition = new Vector3(-49.3f,10,80f);
				HandObj.transform.localRotation = Quaternion.Euler(270f,0,0);
				
				
				break;
				
			case 2:
				panelControl.panelMoveOut = false;
				
				HandObj.transform.localPosition = new Vector3(-35.79398f,13,110.1f);
				HandObj.transform.localRotation = Quaternion.Euler(90f,90f,0);
				
				Invoke("GameHandHandlerTask1",2f);
				
				break;
		}
		
		HandObj.transform.localScale = new Vector3(0.3f,0.3f,0.2f);
		HandObj.layer = 8;
		GameObject child = HandObj.transform.FindChild("Arrow").gameObject;
		child.layer = 8;
	}
	
	void GameHandHandlerTask1()
	{
		if (HandObj != null)
			HandObj.transform.localPosition = new Vector3(-35.79398f,13,101.5f);
		
		Invoke("GameHandHandlerTask2",2f);
	}
	
	void GameHandHandlerTask2()
	{
		if (HandObj != null)
			HandObj.transform.localPosition = new Vector3(-35.79398f,13,93.5f);
		
		Invoke("DestroyHand",2f);
	}
	
	void DestroyHand()
	{
		scr_popUpInformation.storyTutorial(1);
		scr_popUpInformation.guiControlInfo.storyLogButton.active = true;
	}
}
