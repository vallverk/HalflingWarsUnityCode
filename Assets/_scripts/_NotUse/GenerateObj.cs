using UnityEngine;
using System.Collections;

public class GenerateObj : MonoBehaviour 
{
	public GameObject halflingHouse;
	public GameObject trollHouse;
	
	public bool houseButtonBool = true;
	//public bool placeButtonBool = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		if (houseButtonBool == true)
		{
			if (GUI.Button(new Rect(Screen.width - 130, Screen.height - 80, 100, 60), "Halfling House")) 
			{
				//Debug.Log("Clicked the button with text");
				GameObject temp = Instantiate(halflingHouse, new Vector3(-40, 0.01f, 0), Quaternion.identity) as GameObject;
				temp.transform.eulerAngles = new Vector3(0, 180, 0);
				temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				grid.placeButtonBool = true;
				houseButtonBool = false;
				grid.curObj = temp;
				
			}
			
			if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 80, 100, 60), "Troll House"))            
			{
//				Debug.Log("Clicked the button with text");
				GameObject temp = Instantiate(trollHouse, new Vector3(-40, 0.01f, 0), Quaternion.identity) as GameObject;
				temp.transform.eulerAngles = new Vector3(0, 180, 0);
				temp.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
				grid.placeButtonBool = true;
				houseButtonBool = false;
				grid.curObj = temp;
			}
		}
		
		
	}
}
