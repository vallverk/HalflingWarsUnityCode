using UnityEngine;
using System.Collections;

public class AutoSpeak : MonoBehaviour {
	
	public float speakSpeed = 0.1f;
	public SpriteText SepakObject;
	public Material samUncle;
	public Material speaktext;
	public Material Animator;
	
	private bool hideChar = false;
	private bool unhideChar = false;
	private bool hideCharWhenPopupAppears = false;
	
	Color newSamColor;
	Color AnimatorColor;
	
	public MeshCollider popupCollider;
	
	private popUpInformation scr_PopUpInformation;
	
	
	
	void Start () 
	{
		//bubbleObj = GameObject.Find("Bubble") as GameObject;
		scr_PopUpInformation = GameObject.Find("PopUPManager").gameObject.GetComponent<popUpInformation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(guiControl.popUpOpenBool & hideCharWhenPopupAppears & !guiControl.feedMorphTutorial)			// test for hiding uncle sam
		{
			if (GameManager.gameLevel > 2)
			{
				HideUncleSam();
			
				hideCharWhenPopupAppears = false;
			}
		}
		
		if(hideChar & samUncle.color.a>=0)
		{
///***			Debug.Log("hide uncle sam...");
			samUncle.color = new Color(samUncle.color.r,samUncle.color.g,samUncle.color.b,samUncle.color.a - 0.012f);
			Animator.color = new Color(Animator.color.r,Animator.color.g,Animator.color.b,Animator.color.a - 0.012f);
			speaktext.color = new Color(speaktext.color.r,speaktext.color.g,speaktext.color.b,speaktext.color.a - 0.012f);
//			Debug.Log("Calling.....");
			
			if (GameManager.taskCount == 7)
				scr_PopUpInformation.generatePopUp(scr_PopUpInformation.curPopUpCnt, scr_PopUpInformation.curPopUpType);
		}
		
		if(unhideChar)
		{
			samUncle.color = new Color(samUncle.color.r,samUncle.color.g,samUncle.color.b,1f);
			Animator.color = new Color(Animator.color.r,Animator.color.g,Animator.color.b,1f);
			speaktext.color = new Color(speaktext.color.r,speaktext.color.g,speaktext.color.b,1f);
		}
	}
	
	IEnumerator StartSpeaking(string Matter)
	{
		foreach(char letter in Matter.ToCharArray())
		{
			SepakObject.Text+=letter;
			yield return new WaitForSeconds(speakSpeed);
		}
	}
	
	public void callToWriteText(string matter)
	{
		BringbackUncleSam();
		StopAllCoroutines();
		SepakObject.Text ="";
		StartCoroutine(StartSpeaking(matter));
	}
	
	public void HideUncleSam()
	{
///***		Debug.Log("hide uncle sam function()...");
		hideChar = true;
		unhideChar = false;
		popupCollider.enabled = false;
	}
		
	private void BringbackUncleSam()
	{
		hideCharWhenPopupAppears = true;
		hideChar = false;
		unhideChar = true;
		popupCollider.enabled = true;
	}
	
}
