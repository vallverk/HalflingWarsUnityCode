using UnityEngine;
using System.Collections;

public class storeManager : MonoBehaviour 
{	
	public bool storeMenuBool = false;
	public bool decorationUIBool = false;
	public bool buildingUIBool = false;
	public bool creatureUIBool = false;
	public bool trainingGrndUIBool = false;
	public bool treasureUIBool = false;
	
	public GameObject storeUI;
	public GameObject decorationUI;
	public GameObject buildingUI;
	public GameObject creatureUI;
	public GameObject trainingGrndUI;
	public GameObject treasureUI;
	
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
		/*if (storeMenuBool)
		{
			//GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), marketScreen);
					
			if (GUI.Button(new Rect(Screen.width/2 - 425 , Screen.height/2 - 125, 150, 200), GUIContent.none, ""))
			{
				Debug.Log("Decoration...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
				//decorationUI.active = true;
				decorationUI.SetActiveRecursively(true);
				decorationUIBool = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 80 , Screen.height/2 - 125, 150, 200), GUIContent.none, ""))
			{
				Debug.Log("Building...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
				//buildingUI.active = true;
				buildingUI.SetActiveRecursively(true);
				buildingUIBool = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 + 280 , Screen.height/2 - 125, 150, 200), GUIContent.none, ""))
			{
				Debug.Log("Creatures...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
				//creatureUI.active = true;
				creatureUI.SetActiveRecursively(true);
				creatureUIBool = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 260 , Screen.height/2 + 155, 150, 200), GUIContent.none, ""))
			{
				Debug.Log("Training Ground...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
				//trainingGrndUI.active = true;
				trainingGrndUI.SetActiveRecursively(true);
				trainingGrndUIBool = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 + 85 , Screen.height/2 + 155, 150, 200), GUIContent.none, ""))
			{
				Debug.Log("Treasure...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
				//treasureUI.active = true;
				treasureUI.SetActiveRecursively(true);
				treasureUIBool = true;
			}
			
			if (GUI.Button(new Rect(Screen.width/2 - 525 , Screen.height/2 + 260, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Main Menu...");
				Application.LoadLevel("MainMenu");
			}
			
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 260, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				storeMenuBool = false;
				storeUI.SetActiveRecursively(false);
			}
		}
		
		if (decorationUIBool)
		{
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 270, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				decorationUIBool = false;	
				//decorationUI.active = false;
				decorationUI.SetActiveRecursively(false);
				
				storeMenuBool = true;
				storeUI.SetActiveRecursively(true);
			}
		}
		
		if (buildingUIBool)
		{
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 270, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				buildingUIBool = false;	
				//buildingUI.active = false;
				buildingUI.SetActiveRecursively(false);
				
				storeMenuBool = true;
				storeUI.SetActiveRecursively(true);
			}
		}
		
		if (creatureUIBool)
		{
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 270, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				creatureUIBool = false;	
				//creatureUI.active = false;
				creatureUI.SetActiveRecursively(false);
				
				storeMenuBool = true;
				storeUI.SetActiveRecursively(true);
			}
		}
		
		if (trainingGrndUIBool)
		{
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 270, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				trainingGrndUIBool = false;	
				//trainingGrndUI.active = false;
				trainingGrndUI.SetActiveRecursively(false);
				
				storeMenuBool = true;
				storeUI.SetActiveRecursively(true);
			}
		}
		
		if (treasureUIBool)
		{
			if (GUI.Button(new Rect(Screen.width/2 + 395 , Screen.height/2 + 270, 130, 130), GUIContent.none, ""))
			{
				Debug.Log("Cancel...");
				treasureUIBool = false;	
				//treasureUI.active = false;
				treasureUI.SetActiveRecursively(false);
				
				storeMenuBool = true;
				storeUI.SetActiveRecursively(true);
			}
		}*/
	}
}
