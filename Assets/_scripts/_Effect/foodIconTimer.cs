using UnityEngine;
using System.Collections;

public class foodIconTimer : MonoBehaviour 
{
	private int oldTime, curTime;
	private popUpInformation popUpInfoScript;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log (" food icon timer...");
		oldTime = (int)Time.time;
		popUpInfoScript = GameObject.Find("PopUPManager").GetComponent<popUpInformation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curTime == 3)
		{
			Debug.Log("---> food icon collider");
			
			Destroy(GameObject.Find("foodHUD").gameObject.GetComponent<buttonPulse>());
			GameObject.Find("foodHUD").gameObject.transform.localScale = new Vector3(1,1,1);
			
			GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (arrowDel != null)
				Destroy(arrowDel);
			
//			popUpInfoScript.curPopUpCnt = 11;
//			popUpInfoScript.curPopUpType = 0;
//			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameManager.popUpCount = 12;
			popUpInfoScript.updatePopUpCount();
			popUpInfoScript.curPopUpCnt = 11;
			popUpInfoScript.updateCurPopUpCount();
			popUpInfoScript.feedTutorial(2);
			
			Destroy(this.gameObject);
		}
		curTime = (int)Time.time - oldTime;
	}
}
