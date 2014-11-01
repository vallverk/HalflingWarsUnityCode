using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class grid : MonoBehaviour 
{
	public float gridSize = 1.0f;
	
	public float gridSizeX = 2.73f;
	public float gridSizeY = 1.36f;
	
	//private float gridSizeDY = 0.87f;
	
	public CameraControl cameraControlInfo;
	public GenerateObj generateObjInfo;
	
	public static bool placeButtonBool = false;
	public static bool editButtonBool = false;
	public static bool editObjectBool = false;
	public static bool readyToPlace = true;
	
	public static GameObject curObj;
	public static GameObject curCol;
	
	private Transform redPatch;
	private Transform greenPatch;
	
	public CheckOverlap checkOverlapInfo;
	
	private string x = ""; // string to work with the xml file.
 	private string y = ""; // string to work with the xml file.
 	private string z = ""; // string to work with the xml file.
  
 	private float X = 0; // we will apply the values ​​of the strings here.
 	private float Y = 0; // we will apply the values ​​of the strings here.
 	private float Z = 0; // we will apply the values ​​of the strings here.
	
	public LayerMask mask = -1;
	
	public Camera mainCam;
	public Camera guiCam;
	
	private Transform objUI;
	
	public ObjectInformation objectInfo;

	private Vector3 translate = Vector3.zero;
	
	public static float axisY = 0f;
	
	public GameObject dummySphere;
	
	private int index = 0;
	private float storeX, storeY, storeZ;
	
	public objGridMove scr_objGridMove;
	
	private float valX, valY, width = 1.46f, offsetX, offsetY, posX, posY;
	private Vector3 newPos;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	//public Transform obj;
	RaycastHit hit;
	// Update is called once per frame
	void Update () 
	{
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		
		// click on object
		if (Input.GetMouseButton(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				//check object is movable
				if (hit.collider.gameObject.tag == "movableObj")// && GameManager.taskCount != 3)
				{
					objGridMove.gridPointerBool = true;
					Sensors.sensorWorkBool = true;
					curCol = hit.collider.gameObject;
					curObj = hit.collider.gameObject.transform.root.gameObject;
					
					if (dummySphere == null)
						dummySphere = GameObject.Find("Sphere") as GameObject;
					
					//objUI =  hit.collider.gameObject.transform.FindChild("UI") as Transform;
					objUI = hit.collider.gameObject.transform.root.gameObject.transform.FindChild("UI") as Transform;
					
					generateObjInfo.houseButtonBool = false;
					cameraControlInfo.cameraMove = false;
					
					if (curObj.name == "HC_D_DirtPath_GO(Clone)" || curObj.name == "DL_D_DDirtPath_GO(Clone)")
					{
						//gridSizeX = 2.72f;
						//gridSizeY = 1.36f;
						gridSizeX =  gridSizeX; //1.46f;
						gridSizeY =  gridSizeY; //0.73f;
						
						translate = new Vector3(Mathf.Round(hit.point.x / gridSizeX) * gridSizeX, 0.01f,
												Mathf.Round(hit.point.z / gridSizeY) * gridSizeY);
					}
					else
					{
						gridSizeX = gridSizeX; //1.36f;
						gridSizeY = gridSizeY; // 0.68f;
						
						translate = new Vector3(Mathf.Round(hit.point.x / gridSizeX) * gridSizeX, 0.01f,
												Mathf.Round(hit.point.z / gridSizeY) * gridSizeY);
					}
					
					//if (!objGridMove.gridObjSetBool)
						//curObj.transform.position = new Vector3(scr_objGridMove.gridObj.position.x, 0.2f, scr_objGridMove.gridObj.position.z);
					
					// new grid system
					float ymouse = ((2* hit.point.z - hit.point.x)/2);
					float xmouse = (hit.point.x + ymouse);

				
					offsetY = Mathf.Round(ymouse/width);
					offsetX = Mathf.Round(xmouse/width);
				
					float objX = (offsetX * width) + width/2;
					float objY = (offsetY * width) + width/2;
				
					posX = (offsetX - offsetY) * width;
					posY = (offsetX + offsetY) * width/2;
				
					newPos = new Vector3(posX, 0.2f, posY);

					curObj.transform.position = newPos;
					// end new grid system
					
					//cube.transform.position = newPos;
					
					//curObj.transform.position = new Vector3(translate.x, 0.2f, translate.z + 0.14f);
					dummySphere.transform.position = curObj.transform.FindChild("Isometric_Collider").gameObject.transform.position;
					
					if (index == 0)
					{
						index++;
						storeX = curObj.transform.position.x;
						storeY = curObj.transform.position.y;
						storeZ = curObj.transform.position.z;
					}
					
					if (curObj == null)
						curObj = hit.collider.gameObject.transform.root.gameObject;
				}
				else if (hit.collider.gameObject.tag == "editableObj")// && !cameraControlInfo.cameraMove)
				{
					if (guiControl.tutorialCnt >= 4)
					{
						objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
		
						objPanelInfo.panelMoveIn = false;
						objPanelInfo.panelMoveOut = true;
						
						// hide training ground panel
						objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoTG.panelMoveIn = false;
						objPanelInfoTG.panelMoveOut = true;
					}
										
					editButtonBool = true;
					generateObjInfo.houseButtonBool = false;
					cameraControlInfo.cameraMove = true;
					curObj = hit.collider.gameObject.transform.root.gameObject;
					curCol = hit.collider.gameObject;
					
					redPatch = curObj.transform.FindChild("redPatch");
					greenPatch = curObj.transform.FindChild("greenPatch");
					
					if (editObjectBool == true)
					{
						Debug.Log("Move Obj...");
						Vector3 translate = new Vector3(Mathf.Round(hit.point.x / gridSize) * gridSize, 0.2f,
												Mathf.Round(hit.point.z / gridSize) * gridSize);
												
						curObj.transform.position = new Vector3(translate.x, 0.2f, translate.z);
						Debug.Log(hit.point);
					
						if (curObj == null)
							curObj = hit.collider.gameObject.transform.root.gameObject;
					}
				}
				else if (hit.collider.gameObject.tag == "halflingGround" || hit.collider.gameObject.tag == "darklingGround")
				{
					objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
					cameraControlInfo.cameraMove = true;
					if (GameManager.gameLevel >= 3)
					{
						objPanelInfo.panelMoveIn = true;
						objPanelInfo.panelMoveOut = false;
					}
				}
				else
				{
					cameraControlInfo.cameraMove = true;
				}
			}
			
			if (curObj != null && dummySphere != null)
			{
				axisY = (0.0306f -(dummySphere.transform.position.z / GameManager.layerDivVal));
//				Debug.Log(" Axis Y :: " + axisY);
			}
		}
		else
			objGridMove.gridPointerBool = false;
		
		if (Input.GetMouseButtonUp(0))
		{
			Sensors.sensorWorkBool = false;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.tag == "movableObj")
				{
					placeButtonBool = true;
				}
			}
		}
	}
	
//	void OnGUI()
//	{
//		//GUILayout.Label(cameraControlInfo.cameraMove.ToString());
//	}
}
