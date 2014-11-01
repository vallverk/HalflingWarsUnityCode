using UnityEngine;
using System.Collections;

public class panelControl : MonoBehaviour 
{
	public static bool panelAnimBool = false;
	
	public Vector3 startPos = new Vector3(-40, 0, -26.5f);
	public Vector3 endPos = new Vector3(-40, 0, -33.5f);
	public float speed;
		
	private int curTime = 0;
	private float oldTime = 0;
	
	public static bool panelMoveIn = false;
	public static bool panelMoveOut = false;
	public static bool autoHidePanelBool = false;
	
	private bool panelInBool = true;
	private bool panelOutBool = false;
	
	RaycastHit guiHit;
	public Camera guiCam;
	
		
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("panel control...");
		oldTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log("level : " + GameManager.gameLevel + " --- " + " quest : " + GameManager.quest);
		Ray ray = guiCam.ScreenPointToRay(Input.mousePosition);
		//Debug.Log(panelAnimBool);
		
		//if (autoHidePanelBool)
			//checkIdleState();
		
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out guiHit))
			{
				if (guiHit.collider.gameObject.name == "scroll" && !guiControl.popUpOpenBool && !GameManager.placeObjectBool)
				{
					
					if (GameManager.gameLevel >= 3 && GameManager.panelAccessBool)// && GameManager.quest > 1)
					{
						objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfo.panelMoveIn = true;
						objPanelInfo.panelMoveOut = false;
						
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
						
						panelAnimBool = true;
						autoHidePanelBool = true;
						
						if (panelInBool)
						{
							panelInBool = false;
							panelOutBool = true;
							
							panelMoveOut = true;
							panelMoveIn = false;
						}
						
						else if (panelOutBool)
						{
							panelOutBool = false;
							panelInBool = true;
							
							panelMoveOut = false;
							panelMoveIn = true;
						}
					}
					
//					if (panelAnimBool)
//					{
////						Debug.Log("..... move out");
//						panelMoveOut = true;
//						panelMoveIn = false;
//					}
				}
			}
		}
		
		if (panelMoveOut)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * speed);
		}
		if (panelMoveIn)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, Time.deltaTime * speed);
		}
	}
	
	void checkIdleState()
	{
		curTime = (int)(Time.time - oldTime);
//		Debug.Log(curTime);
		if (Input.GetMouseButtonDown(0))
		{
			oldTime = Time.time;
		}
		
		if (curTime > 1f)
		{
			panelMoveIn = true;
			panelMoveOut = false;
		}
	}
}
