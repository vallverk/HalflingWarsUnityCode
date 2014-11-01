using UnityEngine;
using System.Collections;

public class objGridMove : MonoBehaviour 
{
	public Transform gridObj;
	public Camera mainCam;
	
	private float mouseRaw = 0.1f;
	
	RaycastHit hit;
	
	public static bool camMoveBool = true, gridPointerBool = false, gridObjSetBool = false;
	public static bool setGridObjBool = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		
//		if (Input.GetAxis("Mouse X") > 0.1f || Input.GetAxis("Mouse Y") > 0.1f)
//		{
			if (camMoveBool && grid.curObj == null)
			{	
				if (Vector2.Distance(new Vector2(gridObj.position.x, gridObj.position.z), new Vector2(camera.transform.position.x, camera.transform.position.z)) > 3)
				{
					if (camera.transform.position.x > gridObj.position.x + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (camera.transform.position.x < gridObj.position.x - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
					if (camera.transform.position.z > gridObj.position.z + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (camera.transform.position.z < gridObj.position.z - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
				}
				else
					camMoveBool = false;
//			}
		}
		
		if (setGridObjBool)
		{
			if (Vector2.Distance(new Vector2(gridObj.position.x, gridObj.position.z), new Vector2(camera.transform.position.x, camera.transform.position.z)) > 3)
				{
					if (camera.transform.position.x > gridObj.position.x + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (camera.transform.position.x < gridObj.position.x - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
					if (camera.transform.position.z > gridObj.position.z + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (camera.transform.position.z < gridObj.position.z - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
				}
				else
					setGridObjBool = false;
		}
		
		if (gridPointerBool)
		{
			if(Input.GetMouseButton(0))
			{
//				if (Input.GetAxisRaw("Mouse X") > mouseRaw || Input.GetAxisRaw("Mouse X") < mouseRaw ||
//					Input.GetAxisRaw("Mouse Y") > mouseRaw || Input.GetAxisRaw("Mouse Y") > mouseRaw)
				
				if (Input.GetAxis("Mouse X") > 0.05f || Input.GetAxis("Mouse Y") > 0.05f ||
					Input.GetAxis("Mouse X") < -0.05f || Input.GetAxis("Mouse Y") < -0.05f)
				{
					if (Physics.Raycast(ray, out hit))
					{
						//if (hit.collider.gameObject.name == "gridObj")
						//{
//						Debug.Log("mouse :: " + hit.point);
						
						if (hit.point.x > gridObj.position.x + 0.6f)
						{
							gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z + 0.73f);
						}
						else if (hit.point.x < gridObj.position.x - 0.8f)
						{
							gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z - 0.73f);
						}
						if (hit.point.z > gridObj.position.z + 0.6f)
						{
							gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z + 0.73f);
						}
						else if (hit.point.z < gridObj.position.z - 0.8f)
						{
							gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z - 0.73f);
						}
						
					//}
					}
				}
			}
		}
		
		if (gridObjSetBool)
		{
			if (grid.curObj != null)
			{
				if (Vector2.Distance(new Vector2(gridObj.position.x, gridObj.position.z), new Vector2(grid.curObj.transform.position.x, grid.curObj.transform.position.z)) > 3)
				{
					if (grid.curObj.transform.position.x > gridObj.position.x + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (grid.curObj.transform.position.x < gridObj.position.x - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
					if (grid.curObj.transform.position.z > gridObj.position.z + 0.6f)
					{
						gridObj.position = new Vector3(gridObj.position.x - 1.46f, 0.2f, gridObj.position.z + 0.73f);
					}
					else if (grid.curObj.transform.position.z < gridObj.position.z - 0.8f)
					{
						gridObj.position = new Vector3(gridObj.position.x + 1.46f, 0.2f, gridObj.position.z - 0.73f);
					}
				}
				else
					gridObjSetBool = false;
			}
		}
	}
}
