using UnityEngine;
using System.Collections;
using System;

public class HealthProgressBarTutorial : MonoBehaviour 
{
	public Transform progressBarPov;
	
	public float seconds;
	public double SecCnt = 2400f;
	public int cnt;
	
	public float totalTime = 0;
	
	private Transform col;
	
	private float waitTime = 1f;
	
	private float remainTime;

	private popUpInformation scrPopUpInformation;

	public bool disablePopUpBool = false;
	
	// Use this for initialization
	void Start () 
	{	
		scrPopUpInformation = GameObject.Find("PopUPManager").gameObject.GetComponent<popUpInformation>() as popUpInformation;

		seconds = (float)SecCnt;
		StartCoroutine(updateProgressBar());
		StartCoroutine(updateSeconds());
		//Debug.Log(this.gameObject.name + " Start time = "+SecCnt);
		
		progressBarPov = this.gameObject.transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("ProgressBarPov") as  Transform;
		
		col = transform.FindChild("Isometric_Collider") as Transform;
		transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfoTG.panelMoveIn = true;
		objPanelInfoTG.panelMoveOut = false;
		
		// hide move panel
		objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent("objPanelControl") as objPanelControl;
		movePanelInfo.panelMoveIn = true;
		movePanelInfo.panelMoveOut = false;
		
		// hide plant panel
		objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;
		
		if (totalTime != 0)
		{
			remainTime = ((float)SecCnt / totalTime); 
			progressBarPov.transform.localScale = new Vector3(remainTime,
																progressBarPov.transform.localScale.y,
																progressBarPov.transform.localScale.z);
		}
		createOrcEffect();
	}

	public void createOrcEffect()
	{
		GameObject parOrcAttackEff = Instantiate(scrPopUpInformation.gameManagerInfo.par_OrcAttack_PF, transform.position, Quaternion.Euler(330, 0, 0)) as GameObject;
		parOrcAttackEff.GetComponent<ParticleSystem>().Play();
	}
	
	void Update()
	{	
		if(SecCnt < 30)
		{
///***			Debug.Log("time stopped");
//			GameObject[] effs = GameObject.FindGameObjectsWithTag("orcDestructEff");
//			foreach(GameObject e in effs)
//			{
//				if (e != null)
//					Destroy(e);
//			}
			Destroy(this);
		}
	}
	
	IEnumerator updateProgressBar()
    {	
        while(true)
        {
			if (SecCnt == 0)
			{
				SecCnt = seconds;
			}
				
			if (cnt < seconds)
			{
				  
				if (seconds != 0)
				{
					if (progressBarPov != null)
					{
						if (progressBarPov.localScale.x >= 0)
						{
							progressBarPov.localScale = new Vector3(progressBarPov.localScale.x - (1f / seconds)/*0.00167f*/,
																progressBarPov.localScale.y,
																progressBarPov.localScale.z);

							// show pop up for purchasing obelisk
							if (cnt > 30 && GameManager.popUpCount == 18 && !disablePopUpBool)
							{
								GameManager.popUpCount = 78;
								scrPopUpInformation.curPopUpCnt = 78;
								scrPopUpInformation.curPopUpType = 0;
								scrPopUpInformation.generatePopUp(scrPopUpInformation.curPopUpCnt, scrPopUpInformation.curPopUpType);

								GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
								if (arrowDel != null)
									Destroy(arrowDel);

								GameObject marketButtObj = GameObject.Find("button_Market") as GameObject;
								if (marketButtObj != null)
								{
									Destroy(marketButtObj.gameObject.GetComponent<buttonPulse>());
									marketButtObj.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
								}

								panelControl.panelMoveIn = true;
								panelControl.panelMoveOut = false;
							}

							if (col != null)
							{
								if (col.gameObject.tag != "attack")
									col.gameObject.tag = "attack";
							}
						}
					}
				}
			}
			else
			{
			}
			cnt++;	
	
			yield return new WaitForSeconds(1);
		}
    }
	
	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
	             SecCnt--;
				
				Transform remainTimeObj = transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime") as Transform;
			
				if (remainTimeObj != null)
				{
					transform.FindChild("HealthProgressBar").gameObject.transform.FindChild("RemainTime").gameObject.GetComponent<SpriteText>().Text = (assignSecondstoTimespan((double)SecCnt)).ToString();
				}
			}
			else if(SecCnt <= 0)
			{
			}
			
		    yield return new WaitForSeconds(1);
		}
	}
	
	private TimeSpan assignSecondstoTimespan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
}
