using UnityEngine;
using System.Collections;

public class DayNightSystem : MonoBehaviour 
{		
	public int DN_cnt = 0;
	public int ND_cnt = 0;
	public float colorDecrease = 0.05f;
	public float blueColor = 0.02f;
	// Use this for initialization
	public bool runBool = true;
	private int transitionTime = 900;
	private float twilightTime = 0;
	
	public SfsRemote scr_SfsRemote;
	
	private string Day = "DAY", Night = "NIGHT", Twilight_Night_Day = "TWILIGHT_DAY_NIGHT", Twilight_Day_Night = "TWILIGHT_NIGHT_DAY", NOTACTIVE = "DAY_NIGHT MODE NOT ACTIVE";
	private bool DN_bool = true, ND_bool = true;
	
	private float newColor = 0;
	
	private float curVal = 0f, curColor = 0f;
	
	private GameObject hGround, dGround, hGate, dGate;
	//private GameObject dialObj;
	
	private GameObject innCol, dInnCol, blackSmithCol, apothecaryCol, tavernCol, dBlackSmithCol, dApothecaryCol;
	
	public GUIText dayNightTxt;
	
	private int dayIndex = 0, dnIndex = 0, nIndex = 0, ndIndex = 0;
	private int dayCnt = 0, dnCnt = 0, nCnt = 0, ndCnt = 0;
	
	void Awake()
	{
		scr_SfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
	}
	
	void Start () 
	{
		
		dayCnt = PlayerPrefs.GetInt("dayCnt");
		nCnt = PlayerPrefs.GetInt("nCnt");
		dnCnt = PlayerPrefs.GetInt("dnCnt");
		ndCnt = PlayerPrefs.GetInt("ndCnt");
		
		dayNightTxt = GameObject.Find("dayNightState_txt").gameObject.GetComponent<GUIText>();
		hGround = GameObject.Find("HalfLing_Map") as GameObject;
		dGround = GameObject.Find("Darkling_Map") as GameObject;
		hGate = GameObject.Find("halflingGate") as GameObject;
		dGate = GameObject.Find("darklingGate") as GameObject;
		
		//StartCoroutine(Execute());
		//dialObj = GameObject.Find("
		if (transform.gameObject.tag == "Inn")
			innCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "DInn")
			dInnCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "BlackSmith")
			blackSmithCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "Apothecary")
			apothecaryCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "Tavern")
			tavernCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "DBlackSmith")
			dBlackSmithCol = transform.FindChild("Isometric_Collider").gameObject;
		if (transform.gameObject.tag == "DApothecary")
			dApothecaryCol = transform.FindChild("Isometric_Collider").gameObject;
		
		//Debug.Log("current state :: " + scr_SfsRemote.state + " --- " + scr_SfsRemote.elapsedtime + " --- " + transform.gameObject.renderer.material.color);
		if (GameManager.gameLevel >= 3)
		{
			if (scr_SfsRemote.state == Twilight_Night_Day)
			{
///***				Debug.Log("night to day...");
				if (int.Parse(scr_SfsRemote.elapsedtime) <= 900 && int.Parse(scr_SfsRemote.elapsedtime) > 675)
					curColor = 0.4616f; //0.9f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) <= 675 && int.Parse(scr_SfsRemote.elapsedtime) > 450)
					curColor = 0.3962f; //0.7f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) <= 450 && int.Parse(scr_SfsRemote.elapsedtime) > 225)
					curColor = 0.3308f; //0.5f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) <= 225 && int.Parse(scr_SfsRemote.elapsedtime) > 0)
					curColor = 0.2654f; //0.3f;
			}
			
			if (scr_SfsRemote.state == Twilight_Day_Night)
			{
				Debug.Log("day to night...");
				if (int.Parse(scr_SfsRemote.elapsedtime) > 0 && int.Parse(scr_SfsRemote.elapsedtime) <= 225)
					curColor = 0.4616f; //0.9f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) >225 && int.Parse(scr_SfsRemote.elapsedtime) <= 450)
					curColor = 0.3962f; //0.7f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) > 450 && int.Parse(scr_SfsRemote.elapsedtime) <= 675)
					curColor = 0.3308f; //0.5f;
				else if (int.Parse(scr_SfsRemote.elapsedtime) > 675 && int.Parse(scr_SfsRemote.elapsedtime) <= 900)
					curColor = 0.2654f; //0.3f;
			}
			
			if (scr_SfsRemote.state == Night)
				curColor = 0.2f;
			
			if (scr_SfsRemote.state == Day)
				curColor = 0.527f;
			
			if (scr_SfsRemote.state == NOTACTIVE)
				curColor = 0.527f;
				
				
			//Debug.Log("current color......... " + curColor + " --- " + curVal + " --- " + scr_SfsRemote.state);
//			if (transform.gameObject.renderer.material.HasProperty("_Color"))
//				transform.gameObject.renderer.material.color = new Color(curColor, curColor, 0.527f, transform.gameObject.renderer.material.color.a);
			
			if (transform.gameObject.name == "HalfLing_Map")
				hGround.renderer.material.color = new Color(curColor, curColor, 0.527f, 1);
			if (transform.gameObject.name == "Darkling_Map")
				dGround.renderer.material.color = new Color(curColor, curColor, 0.527f, 1);
			
			hGate.renderer.material.color = new Color(curColor, curColor, 0.527f, 1);
			dGate.renderer.material.color = new Color(curColor, curColor, 0.527f, 1);
			
			if (transform.gameObject.renderer.material.HasProperty("_Color"))
				transform.gameObject.renderer.material.color = hGround.renderer.material.color;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{		
		//Debug.Log ("day night ---> " + scr_SfsRemote.state);
		//if (transform.gameObject.tag == "halflingGround")
			//Debug.Log("color :: " + transform.gameObject.renderer.material.color);
		
		//Debug.Log(transform.gameObject.name + " ---> " + transform.gameObject.renderer.material.color);
		//dayNightTxt.text = ("State : " + scr_SfsRemote.state);
//		//Debug.Log("current state :: " + scr_SfsRemote.state + " --- " + scr_SfsRemote.elapsedtime + " --- " + transform.gameObject.renderer.material.color);
		
		// day
		if (scr_SfsRemote.state == Day)
		{
			dnIndex = 0;
			if (dayIndex == 0)
			{
				dayIndex++;
				PlayerPrefs.SetInt("dayCnt", dayCnt++);
			}
			
			dayNightTxt.text = (scr_SfsRemote.state + " :: ");
			
			if (transform.gameObject.renderer.material.HasProperty("_Color"))
				transform.gameObject.renderer.material.color = new Color(0.527f, 0.527f, 0.527f, transform.gameObject.renderer.material.color.a);
			
			if (transform.gameObject.name == hGate.name && GameManager.gameLevel > 3)
			{
				transform.FindChild("_halflingGate_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
				transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
						
			if (transform.gameObject.name == dGate.name && GameManager.gameLevel > 3)
			{
				transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
				transform.FindChild("_darklingGate_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			
		}
		
		// night
		if (scr_SfsRemote.state == Night)
		{
			ndIndex = 0;
			if (nIndex == 0)
			{
				nIndex++;
				PlayerPrefs.SetInt("nCnt", nCnt++);
			}
			
			dayNightTxt.text = (scr_SfsRemote.state + " :: ");
			
			if (transform.gameObject.renderer.material.HasProperty("_Color"))
				transform.gameObject.renderer.material.color = new Color(0.2f, 0.2f, 0.527f, transform.gameObject.renderer.material.color.a);
			
			if (transform.gameObject.name == hGate.name && GameManager.gameLevel > 3)
			{
				transform.FindChild("_halflingGate_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
				transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			
			
			if (transform.gameObject.name == dGate.name && GameManager.gameLevel > 3)
			{
				transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
				transform.FindChild("_darklingGate_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			
			
			if (transform.gameObject.tag == "Inn")
			{
				if (innCol.tag == "editableObj")
					transform.FindChild("_Inn_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
				else
					transform.FindChild("_Inn_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			
			if (transform.gameObject.tag == "HHouse")
				transform.FindChild("_House_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			/*if (transform.gameObject.tag == "DHouse")
			{
				transform.FindChild("_DHouse_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}*/
			
			if (transform.gameObject.tag == "DInn") 
			{
				if (dInnCol.tag == "editableObj")
					transform.FindChild("_DInn_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
				else
					transform.FindChild("_DInn_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			
			if (transform.gameObject.tag == "BlackSmith" && blackSmithCol.tag == "editableObj")
				transform.FindChild("_BlackSmith_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.tag == "Apothecary" && apothecaryCol.tag == "editableObj")
				transform.FindChild("_Apothecary_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.tag == "Tavern" && tavernCol.tag == "editableObj")
				transform.FindChild("_Tavern_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.tag == "DBlackSmith" && dBlackSmithCol.tag == "editableObj")
				transform.FindChild("_DBlackSmith_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.tag == "DApothecary" && dApothecaryCol.tag == "editableObj")
				transform.FindChild("_Apothecary_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.name == "HC_D_Lantern_GO(Clone)")
				transform.FindChild("_Lantern_Night").gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
		
		// day to night
		if (scr_SfsRemote.state == Twilight_Night_Day && ND_bool)
		{
			nIndex = 0;
			if (dnIndex == 0)
			{
				dnIndex++;
				PlayerPrefs.SetInt("dnCnt", dnCnt++);
			}
			
			dayNightTxt.text = ("Twilight Day to Night :: ");
			
			newColor = ((float.Parse(scr_SfsRemote.elapsedtime)/transitionTime) - 0.2f);
			if (newColor < 0)
				newColor = newColor * -1;
		
			StartCoroutine(ExecuteND());
			ND_bool = false;
			DN_bool = true;
			
		}
		
		// night to day
		if (scr_SfsRemote.state == Twilight_Day_Night && DN_bool)
		{
			dayIndex = 0;
			if (ndIndex == 0)
			{
				ndIndex++;
				PlayerPrefs.SetInt("ndCnt", ndCnt++);
			}
			
			dayNightTxt.text = ("Twilight Night to Day :: ");
			
			newColor = ((float.Parse(scr_SfsRemote.elapsedtime)/transitionTime) - 0.2f);
			if (newColor < 0)
				newColor = newColor * -1;
			Debug.Log("new color night to day :: " + newColor);
			StartCoroutine(ExecuteDN());
			ND_bool = true;
			DN_bool = false;
			
			if (transform.gameObject.tag == "Inn" && innCol.tag == "editableObj")
				transform.FindChild("_Inn_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "HHouse")
				transform.FindChild("_House_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "DInn" && dInnCol.tag == "editableObj")
				transform.FindChild("_DInn_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "BlackSmith" && blackSmithCol.tag == "editableObj")
				transform.FindChild("_BlackSmith_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "Apothecary" && apothecaryCol.tag == "editableObj")
				transform.FindChild("_Apothecary_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "Tavern" && tavernCol.tag == "editableObj")
				transform.FindChild("_Tavern_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "DBlackSmith" && dBlackSmithCol.tag == "editableObj")
				transform.FindChild("_DBlackSmith_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.tag == "DApothecary" && dApothecaryCol.tag == "editableObj")
				transform.FindChild("_Apothecary_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			if (transform.gameObject.name == "HC_D_Lantern_GO(Clone)")
				transform.FindChild("_Lantern_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			if (transform.gameObject.name == dGate.name && GameManager.gameLevel > 3)
			{
				transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
				transform.FindChild("_darklingGate_Night").gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}
	
	IEnumerator ExecuteDN()
	{
		StartCoroutine("DayNightCnt");
		yield return new WaitForSeconds(transitionTime);
		StopCoroutine("DayNightCnt");
	}
	
	IEnumerator ExecuteND()
	{
		StartCoroutine("NightDayCnt");
		yield return new WaitForSeconds(transitionTime);
		StopCoroutine("NightDayCnt");
	}
	
	IEnumerator DayNightCnt()
	{
		while(true)
		{
			DN_cnt++;
			if (transform.gameObject.renderer.material.HasProperty("_Color"))
			{	
				if (transform.gameObject.renderer.material.color.r <= 0.527f)
				{
					transform.gameObject.renderer.material.color = new Color(transform.gameObject.renderer.material.color.r + colorDecrease/transitionTime,
																			transform.gameObject.renderer.material.color.g + colorDecrease/transitionTime,
																			/*transform.gameObject.renderer.material.color.b + blueColor/transitionTime*/ 0.527f, transform.gameObject.renderer.material.color.a);
				}
			}
			
			yield return new WaitForSeconds(0.05f);
		}
	}
	
	IEnumerator NightDayCnt()
	{
		while(true)
		{
			ND_cnt++;
			
			if (transform.gameObject.renderer.material.HasProperty("_Color"))
			{	
			
				if (transform.gameObject.renderer.material.color.r >= 0.2f)
				{
					transform.gameObject.renderer.material.color = new Color(transform.gameObject.renderer.material.color.r - colorDecrease/transitionTime,
																			transform.gameObject.renderer.material.color.g - colorDecrease/transitionTime,
																			0.527f, transform.gameObject.renderer.material.color.a);
				}
			}
			
			yield return new WaitForSeconds(0.05f);
		}
	}
}
