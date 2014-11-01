using UnityEngine;
using System.Collections;

public class plantBurn : MonoBehaviour 
{	
	private int cnt = 0;
	
	//public int estimateTime = 0;
	
	public guiControl guiControlInfo;
	public popUpInformation popUpInfoScript;
	public UpgradeTexture upgradeTextureInfo;
	
	private float seconds = 120f;
	private bool runOneTimeBool = false;
	private bool plantBurnBool = false;
	public SfsRemote scr_sfsremote;
	RaycastHit hit;
	private Camera cam;
	
	private bool runSfsOnceBool;
	
	// Use this for initialization
	void Start () 
	{
		//progressBarPov.transform.localScale = new Vector3(0, progressBarPov.transform.localScale.y, progressBarPov.transform.localScale.z);
		cam = GameObject.Find("Main Camera").camera;
			
		//StartCoroutine(updateProgressBar());
		
		guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		popUpInfoScript = GameObject.Find("PopUPManager").GetComponent("popUpInformation") as popUpInformation;
		upgradeTextureInfo = GameObject.Find("GameManager").GetComponent("UpgradeTexture") as UpgradeTexture;
		scr_sfsremote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		runOneTimeBool = true;
		
		runSfsOnceBool = true;
	}
	
	IEnumerator updateProgressBar()
    {
		//if (progressBarPov.gameObject == null)
		//	return;
		
        while(true)
        {
			if (cnt <= seconds)
			{
				//if (progressBarPov.transform.localScale.x <= 1)
					//progressBarPov.transform.localScale = new Vector3(progressBarPov.transform.localScale.x + (1f / seconds)/*0.00167f*///,
					//													progressBarPov.transform.localScale.y,
					//													progressBarPov.transform.localScale.z);
			}
			cnt++;	
			
//			Debug.Log(cnt);
        	yield return new WaitForSeconds(1);
		}
        
    }
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		
		/*if (runOneTimeBool)
		{
			runOneTimeBool = false;
			plantBurnBool = true;
			transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plantBurnTex;
			Destroy(transform.FindChild("HarvestButton").gameObject);
		}	*/
		
		if (cnt == seconds)
		{
			if (runOneTimeBool)
			{
				runOneTimeBool = false;
				plantBurnBool = true;
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plantBurnTex;
				Destroy(transform.FindChild("HarvestButton").gameObject);
			}	
		}
		
		
		if (runSfsOnceBool)
		{
			if(scr_sfsremote.isBurn)
			{
				transform.gameObject.renderer.material.mainTexture = upgradeTextureInfo.plantBurnTex;
				transform.FindChild("Isometric_Collider").gameObject.tag = "burn";
				Destroy(transform.FindChild("HarvestButton").gameObject);
				Debug.Log("*****************************************");
				runOneTimeBool = true;
				runSfsOnceBool = false;
			}
		}
		
		
		if (plantBurnBool)
		{
			Debug.Log("aaaaaaaaaaaaaaaaaaaa");
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("bbbbbbbbbbbbbbbbbbbbbb");
				if (Physics.Raycast(ray, out hit))
				{
//					Debug.Log("ccccccccccccc  " + hit.collider.gameObject.transform.parent.gameObject);
					if (hit.collider.gameObject.transform.parent.gameObject.tag == "PipeWeed" ||
						hit.collider.gameObject.transform.parent.gameObject.tag == "Turnip" ||
						hit.collider.gameObject.transform.parent.gameObject.tag == "DPumpkin")
					{
						Debug.Log("ddddddddddddddddddddddddddddd");
						GameObject go = transform.root.gameObject;
						go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						Destroy(this.transform.gameObject);
					}
				}
			}
		}
	}
}
