using UnityEngine;
using System.Collections;

public class TappingGroup : MonoBehaviour {
	
	public GameObject[] Sgroup1 = new GameObject[2];
	public GameObject[] Sgroup2 = new GameObject[2];
	public GameObject[] Sgroup3 = new GameObject[2];
	public GameObject[] Sgroup4 = new GameObject[2];
	public GameObject[] Sgroup5 = new GameObject[2];
	public GameObject[] Sgroup6 = new GameObject[2];
	
	public GameObject[] Tgroup1 = new GameObject[3];
	public GameObject[] Tgroup2 = new GameObject[3];
	public GameObject[] Tgroup3 = new GameObject[3];
	public GameObject[] Tgroup4 = new GameObject[3];
	
	
	public GameObject[] Fgroup1 = new GameObject[4];
	
	
	public static bool enableTappingButtons = false;
	
	public GameObject tapChange;
	private TapCange tap;
	
	public BattleGroundPlayer scr_BattleGroundPlayer;
	public BattleGroundManager scr_BattleGroundManager;
	
	void Start () 
	{
		Debug.Log ("tapping group...");
		tap = (TapCange)FindObjectOfType(typeof(TapCange));
	
	}
	
	public void Activate()
	{
		Debug.Log("Getting Called------++++");
		GenerateRandoms();
		
	}
	
	private void GenerateRandoms()
	{
		Debug.Log("Generate TapGroup Getting Called----");
		if(enableTappingButtons)
		{
		int whichobject = Random.Range(1,11);
		Debug.Log(whichobject);
		
		StartShowingTappingPoints(whichobject);
		}
	}
	
	public void TutorualActive()
	{
		activateTap(Tgroup1);
		BattleGroundManager.howMany = 3;
		
	}
	
	public void StartShowingTappingPoints(int which)
	{
		
		switch(which)
		{
		case 1:
			
			activateTap(Tgroup1);
			
			StartCoroutine(deactivateTapObject(Tgroup1));
			BattleGroundManager.howMany = 3;
			Debug.Log("Tap -----> case 1");
			break;
			
		case 2:
			
			activateTap(Tgroup2);
			StartCoroutine(deactivateTapObject(Tgroup2));
			BattleGroundManager.howMany = 3;
			Debug.Log("Tap -----> case 2");
			break;
			
		case 3:
			
			activateTap(Tgroup3);
			StartCoroutine(deactivateTapObject(Tgroup3));
			BattleGroundManager.howMany = 3;
			Debug.Log("Tap -----> case 3");
			break;
			
		case 4:
			
			activateTap(Tgroup4);
			StartCoroutine(deactivateTapObject(Tgroup4));
			BattleGroundManager.howMany = 3;
			Debug.Log("Tap -----> case 4");
			break;
			
		case 5:
			
			activateTap(Sgroup1);
			StartCoroutine(deactivateTapObject(Sgroup1));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 5");
			break;
			
		case 6:
			
			activateTap(Sgroup2);
			StartCoroutine(deactivateTapObject(Sgroup2));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 6");
			break;
			
		case 7:
			
			activateTap(Sgroup3);
			StartCoroutine(deactivateTapObject(Sgroup3));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 7");
			break;
			
		case 8:
			
			activateTap(Sgroup4);
			StartCoroutine(deactivateTapObject(Sgroup4));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 8");
			break;
			
		case 9:
			
			activateTap(Sgroup5);
			StartCoroutine(deactivateTapObject(Sgroup5));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 9");
			break;
			
		case 10:
			
			activateTap(Sgroup6);
			StartCoroutine(deactivateTapObject(Sgroup6));
			BattleGroundManager.howMany = 2;
			Debug.Log("Tap -----> case 10");
			break;
			
		case 11:
			
			activateTap(Fgroup1);
			StartCoroutine(deactivateTapObject(Fgroup1));
			BattleGroundManager.howMany = 4;
			Debug.Log("Tap -----> case 11");
			break;
			
			
		}
		
	}
	
	void activateTap(GameObject[] gameObj)
	{
		
		
		for(int i=0;i<gameObj.Length;i++)
		{
			gameObj[i].SetActiveRecursively(true);
		}
	
			
	}
	
	private int index = 0;
	
	IEnumerator deactivateTapObject(GameObject[] gameObj)
	{
		
		yield return new WaitForSeconds(3.5f);			//change to 1.5
			
		for(int i = 0;i<gameObj.Length;i++)
		{
			
			ButtonStateManager(gameObj[i]);
			
			Debug.Log("After 4 Seconds");
			//yield return new WaitForSeconds(2);
			
			
		}
		
		
		yield return new WaitForSeconds(0.5f);
		
		for(int i = 0;i<gameObj.Length;i++)
		{
			Debug.Log(" what is this.....");
			ButtonStateNormal(gameObj[i]);
			gameObj[i].SetActiveRecursively(false);
			
		}
		
		//Debug.Log("****************************************** " + index++);
		yield return new WaitForSeconds(3);
		scr_BattleGroundPlayer.RealGamePlay = true;
		scr_BattleGroundManager.totalTap = 0;
		//Debug.Log("****************************************** " + index++);
		
	}
	
	
	
	public void ButtonStateManager(GameObject g)
	{
			UIButton uiB = g.GetComponent<UIButton>();
			if(uiB != null)
			{
				uiB.SetControlState(UIButton.CONTROL_STATE.DISABLED);
			}
			else{
			
			Debug.Log("Its On Else---");
		}
	}
	
	
	public void ButtonStateNormal(GameObject g)
	{
			UIButton uiB = g.GetComponent<UIButton>();
			if(uiB != null)
			{
				uiB.SetControlState(UIButton.CONTROL_STATE.NORMAL);
			}
			else{
			
			Debug.Log("Its On Else---");
		}
	}
	
}
