using UnityEngine;
using System.Collections;

public class dirtPathPlacement : MonoBehaviour 
{
	public GameObject marker01, marker02, marker03, marker04, sensor9, sensor1, sensor2, sensor3, sensor4;
	public GameObject redPatch, greenPatch;
	RaycastHit hit01, hit02, hit03, hit04, seneor9Hit, sensor1Hit, sensor2Hit, sensor3Hit, sensor4Hit;
	private bool placePathBool = false;
	public bool front,back,right,left;
	private GameObject tempDPath01 = null, tempDPath02 = null, tempDPath03 = null, tempDPath04 = null, tempDPath2 = null;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 mforward01 = marker01.transform.TransformDirection(Vector3.forward) * 0.5f;
		Vector3 mforward02 = marker02.transform.TransformDirection(Vector3.forward) * 0.5f;
		Vector3 mforward03 = marker03.transform.TransformDirection(Vector3.forward) * 0.5f;
		Vector3 mforward04 = marker04.transform.TransformDirection(Vector3.forward) * 0.5f;
		
       	Debug.DrawRay(marker01.transform.position, mforward01, Color.green);
		Debug.DrawRay(marker02.transform.position, mforward02, Color.green);
		Debug.DrawRay(marker03.transform.position, mforward03, Color.green);
		Debug.DrawRay(marker04.transform.position, mforward04, Color.green);
		
		if (GameManager.gameLevel >= 3)
		{
			if (transform.gameObject.GetComponent<Sensors>().enabled == true)
			{
				if (Physics.Raycast(sensor9.transform.position, sensor9.transform.TransformDirection(Vector3.forward), out seneor9Hit, 2)) {}
				if (Physics.Raycast(sensor1.transform.position, sensor1.transform.TransformDirection(Vector3.forward), out sensor1Hit, 2)) {}
				if (Physics.Raycast(sensor2.transform.position, sensor2.transform.TransformDirection(Vector3.forward), out sensor2Hit, 2)) {}
				if (Physics.Raycast(sensor3.transform.position, sensor3.transform.TransformDirection(Vector3.forward), out sensor3Hit, 2)) {}
				if (Physics.Raycast(sensor4.transform.position, sensor4.transform.TransformDirection(Vector3.forward), out sensor4Hit, 2)) {}
				
				if (Physics.Raycast(marker01.transform.position, marker01.transform.TransformDirection(Vector3.forward), out hit01, 100)) {}
				if (Physics.Raycast(marker02.transform.position, marker02.transform.TransformDirection(Vector3.forward), out hit02, 100)) {}
				if (Physics.Raycast(marker03.transform.position, marker03.transform.TransformDirection(Vector3.forward), out hit03, 100)) {}
				if (Physics.Raycast(marker04.transform.position, marker04.transform.TransformDirection(Vector3.forward), out hit04, 100)) {}
				
				if (hit01.collider == null && PlayerPrefs.GetInt("front") == 1) 
				{
					front = true;placePathBool= true;GameManager.placeObjectBool = true;redPatch.active = false;
					greenPatch.active = true;greenPatch.GetComponent<MeshRenderer>().enabled = true;return;
				}
			
				if (hit02.collider == null && PlayerPrefs.GetInt("left") == 1) 
				{
					left = true;placePathBool= true;GameManager.placeObjectBool = true;redPatch.active = false;
					greenPatch.active = true;greenPatch.GetComponent<MeshRenderer>().enabled = true;return;
				}
				
				if (hit03.collider == null && PlayerPrefs.GetInt("back") == 1) 
				{
					back = true;placePathBool= true;GameManager.placeObjectBool = true;redPatch.active = false;
					greenPatch.active = true;greenPatch.GetComponent<MeshRenderer>().enabled = true;return;
				}
				
				if (hit04.collider == null && PlayerPrefs.GetInt("right") == 1) 
				{
					right = true;placePathBool= true;GameManager.placeObjectBool = true;redPatch.active = false;
					greenPatch.active = true;greenPatch.GetComponent<MeshRenderer>().enabled = true;return;
				}
			
				if (sensor1Hit.collider.gameObject.name == "Isometric_Collider" || sensor1Hit.collider.gameObject.name == "riverCollider" || sensor1Hit.collider.gameObject.name == "caveCollider" || sensor1Hit.collider.gameObject.name == "bridgeCollider" ||
					sensor2Hit.collider.gameObject.name == "Isometric_Collider" || sensor2Hit.collider.gameObject.name == "riverCollider" || sensor2Hit.collider.gameObject.name == "caveCollider" || sensor2Hit.collider.gameObject.name == "bridgeCollider" ||
					sensor3Hit.collider.gameObject.name == "Isometric_Collider" || sensor3Hit.collider.gameObject.name == "riverCollider" || sensor3Hit.collider.gameObject.name == "caveCollider" || sensor3Hit.collider.gameObject.name == "bridgeCollider" ||
					sensor4Hit.collider.gameObject.name == "Isometric_Collider" || sensor4Hit.collider.gameObject.name == "riverCollider" || sensor4Hit.collider.gameObject.name == "caveCollider" || sensor4Hit.collider.gameObject.name == "bridgeCollider" ||
					seneor9Hit.collider.gameObject.name == "Isometric_Collider" || seneor9Hit.collider.gameObject.name == "riverCollider" || seneor9Hit.collider.gameObject.name == "caveCollider" || seneor9Hit.collider.gameObject.name == "bridgeCollider")
					{
					placePathBool = false;
					}
				else
					{	
					placePathBool = true;
					}
				if (hit01.collider.gameObject.name == "Isometric_Collider" && hit01.distance <= 0.5f)
				{
					tempDPath01 = hit01.collider.gameObject.transform.parent.gameObject;
					if (tempDPath01.name == "HC_D_DirtPath_GO(Clone)" || tempDPath01.name == "DL_D_DDirtPath_GO(Clone)")
					{
						tempDPath01 = hit01.collider.gameObject.transform.parent.gameObject;
						front= true;
						PlayerPrefs.SetInt("front",1);	PlayerPrefs.SetInt("left",0);
						PlayerPrefs.SetInt("back",0);	PlayerPrefs.SetInt("right",0);
					}
					else
					{
						tempDPath01 = null;
						front = false;
					}
				}
				else
				{
					tempDPath01 = null;
						front = false;
				}
				
				if (hit02.collider.gameObject.name == "Isometric_Collider" && hit02.distance <= 0.5f)
				{
					tempDPath02 = hit02.collider.gameObject.transform.parent.gameObject;
					if (tempDPath02.name == "HC_D_DirtPath_GO(Clone)" || tempDPath02.name == "DL_D_DDirtPath_GO(Clone)")
					{
						tempDPath02 = hit02.collider.gameObject.transform.parent.gameObject;
						left= true;
						PlayerPrefs.SetInt("front",0);	PlayerPrefs.SetInt("left",1);
						PlayerPrefs.SetInt("back",0);	PlayerPrefs.SetInt("right",0);
					}
					else
					{
						tempDPath02 = null;
						left = false;
					}
				}
				else
				{
					tempDPath02 = null;
					left = false;
				}
				
				if (hit03.collider.gameObject.name == "Isometric_Collider" && hit03.distance <= 1f)
				{
					
					tempDPath03 = hit03.collider.gameObject.transform.parent.gameObject;
					
					if (tempDPath03.name == "HC_D_DirtPath_GO(Clone)" || tempDPath03.name == "DL_D_DDirtPath_GO(Clone)")
					{
						tempDPath03 = hit03.collider.gameObject.transform.parent.gameObject;
						back = true;
						PlayerPrefs.SetInt("front",0);	PlayerPrefs.SetInt("left",0);
						PlayerPrefs.SetInt("back",1);	PlayerPrefs.SetInt("right",0);
					}
					else
					{
						tempDPath03 = null;
						back = false;
					}
				}
				else
				{
					tempDPath03 = null;
					back = false;
				}
				if (hit04.collider.gameObject.name == "Isometric_Collider" && hit04.distance <= 0.5f)
				{
					tempDPath04 = hit04.collider.gameObject.transform.parent.gameObject;
					if (tempDPath04.name == "HC_D_DirtPath_GO(Clone)" || tempDPath04.name == "DL_D_DDirtPath_GO(Clone)")
					{
						tempDPath04 = hit04.collider.gameObject.transform.parent.gameObject;
						right = true;
						PlayerPrefs.SetInt("front",0);	PlayerPrefs.SetInt("left",0);
						PlayerPrefs.SetInt("back",0);	PlayerPrefs.SetInt("right",1);
					}
					else
					{
						tempDPath04 = null;
						right = false;
					}
				}
				else
				{
					tempDPath04 = null;
					right = false;
				}
				
				if ((tempDPath01 != null || tempDPath02 != null || tempDPath03 != null || tempDPath04 != null) && placePathBool == true)
				{
					redPatch.active = false;
					greenPatch.active = true;
					greenPatch.GetComponent<MeshRenderer>().enabled = true;
					GameManager.placeObjectBool = true;
				}
				else
				{
					redPatch.active = true;
					greenPatch.active = false;
					redPatch.GetComponent<MeshRenderer>().enabled = true;
					GameManager.placeObjectBool = false;
				}
				//Debug.Log(tempDPath01.name + " --- " + tempDPath02.name + " --- " + tempDPath03.name + " --- " + tempDPath04.name);
				
				/*if (Physics.Raycast(sensor9.transform.position, sensor9.transform.TransformDirection(Vector3.forward), out seneorHit, 2))
				{
					if (seneorHit.collider.gameObject.name == "Isometric_Collider")
						tempDPath2 = seneorHit.collider.gameObject.transform.parent.gameObject;
				}
			
				if (Physics.Raycast(marker01.transform.position, mforward01, out hit01, 0.5f))
				{
					if (hit01.collider.gameObject != null && hit01.collider.gameObject.name == "Isometric_Collider")
					{
						tempDPath01 = hit01.collider.gameObject.transform.parent.gameObject;
						Debug.Log("marker 01");
					}
					if (tempDPath01 != null && (tempDPath01.name == "HC_D_DirtPath_GO(Clone)" || tempDPath01.name == "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "DL_D_DirtPath_GO(Clone)"))
					{
						redPatch.active = false;
						greenPatch.active = true;
						GameManager.placeObjectBool = true;
					}
				}
				else
				{
					redPatch.active = true;
					greenPatch.active = false;
					GameManager.placeObjectBool = false;
				}
				
				if (Physics.Raycast(marker02.transform.position, mforward02, out hit02, 0.5f))
				{
					if (hit02.collider.gameObject != null && hit02.collider.gameObject.name == "Isometric_Collider")
					{
						tempDPath02 = hit02.collider.gameObject.transform.parent.gameObject;
						Debug.Log("marker 02");
					}
					if (tempDPath02 != null && (tempDPath02.name == "HC_D_DirtPath_GO(Clone)" || tempDPath02.name == "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "DL_D_DirtPath_GO(Clone)"))
					{
						redPatch.active = false;
						greenPatch.active = true;
						GameManager.placeObjectBool = true;
					}
				}
				else
				{
					redPatch.active = true;
					greenPatch.active = false;
					GameManager.placeObjectBool = false;
				}
				
				if (Physics.Raycast(marker03.transform.position, mforward03, out hit03, 0.5f))
				{
					if (hit03.collider.gameObject != null && hit03.collider.gameObject.name == "Isometric_Collider")
					{
						tempDPath03 = hit03.collider.gameObject.transform.parent.gameObject;
						Debug.Log("marker 03");
					}
					if (tempDPath03 != null && (tempDPath03.name == "HC_D_DirtPath_GO(Clone)" || tempDPath03.name == "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "DL_D_DirtPath_GO(Clone)"))
					{
						redPatch.active = false;
						greenPatch.active = true;
						GameManager.placeObjectBool = true;
					}
				}
				else
				{
					redPatch.active = true;
					greenPatch.active = false;
					GameManager.placeObjectBool = false;
				}
				
				if (Physics.Raycast(marker04.transform.position, mforward04, out hit04, 0.5f))
				{
					if (hit04.collider.gameObject != null && hit04.collider.gameObject.name == "Isometric_Collider")
					{
						tempDPath04 = hit04.collider.gameObject.transform.parent.gameObject;
						Debug.Log("marker 04");
					}
					if (tempDPath04 != null && (tempDPath04.name == "HC_D_DirtPath_GO(Clone)" || tempDPath04.name == "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "HC_D_DirtPath_GO(Clone)" || tempDPath2.name != "DL_D_DirtPath_GO(Clone)"))
					{
						redPatch.active = false;
						greenPatch.active = true;
						GameManager.placeObjectBool = true;
					}
				}
				else
				{
					redPatch.active = true;
					greenPatch.active = false;
					GameManager.placeObjectBool = false;
				}*/
			}
		
		/*if (transform.gameObject.GetComponent<Sensors>().enabled == true)
		{
			if (Physics.Raycast(sensor9.transform.position, sensor9.transform.TransformDirection(Vector3.forward), out seneorHit, 2))
			{
				if (seneorHit.collider.gameObject.name == "Isometric_Collider")
						tempDPath2 = seneorHit.collider.gameObject.transform.parent.gameObject;
			}
				
			if (Physics.Raycast(marker01.transform.position, forward, out hit01, 0.5f))
			{
				if (hit01.collider.gameObject != null && hit01.collider.gameObject.name == "Isometric_Collider")
				{
					if (tempDPath.name == "HC_D_DirtPath_GO(Clone)" || tempDPath.name == "HC_D_DirtPath_GO(Clone)")
						tempDPath = hit01.collider.gameObject.transform.parent.gameObject;
				}
				
				if (tempDPath != null && (tempDPath.name == "HC_D_DirtPath_GO(Clone)" || tempDPath.name == "HC_D_DirtPath_GO(Clone)"))
				{
					redPatch.active = false;
					greenPatch.active = true;
					GameManager.placeObjectBool = true;
				}
			}
			else if (Physics.Raycast(marker02.transform.position, forward, out hit02, 0.5f))
			{
				if (hit02.collider.gameObject != null && hit02.collider.gameObject.name == "Isometric_Collider")
				{
					tempDPath = hit02.collider.gameObject.transform.parent.gameObject;
				}
				
				if (tempDPath != null && (tempDPath.name == "HC_D_DirtPath_GO(Clone)" || tempDPath.name == "HC_D_DirtPath_GO(Clone)"))
				{
					redPatch.active = false;
					greenPatch.active = true;
					GameManager.placeObjectBool = true;
				}
			}
			else if (Physics.Raycast(marker03.transform.position, forward, out hit03, 0.5f))
			{
				if (hit03.collider.gameObject != null && hit03.collider.gameObject.name == "Isometric_Collider")
				{
					tempDPath = hit03.collider.gameObject.transform.parent.gameObject;
				}
				
				if (tempDPath != null && (tempDPath.name == "HC_D_DirtPath_GO(Clone)" || tempDPath.name == "HC_D_DirtPath_GO(Clone)"))
				{
					redPatch.active = false;
					greenPatch.active = true;
					GameManager.placeObjectBool = true;
				}
			}	
			else if (Physics.Raycast(marker04.transform.position, forward, out hit04, 0.5f))
			{
				if (hit04.collider.gameObject != null && hit04.collider.gameObject.name == "Isometric_Collider")
				{
					tempDPath = hit04.collider.gameObject.transform.parent.gameObject;
				}
				
				if (tempDPath != null && (tempDPath.name == "HC_D_DirtPath_GO(Clone)" || tempDPath.name == "HC_D_DirtPath_GO(Clone)"))
				{
					redPatch.active = false;
					greenPatch.active = true;
					GameManager.placeObjectBool = true;
				}
			}
			else
			{
				redPatch.active = true;
				greenPatch.active = false;
				GameManager.placeObjectBool = false;
			}
		}*/
		}
	}
}
