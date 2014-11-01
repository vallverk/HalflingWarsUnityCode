using UnityEngine;
using System.Collections;

public class DayNightSystemChar : MonoBehaviour 
{		
	public int DN_cnt = 0;
	public int ND_cnt = 0;
	public float colorDecrease = 0.05f;
	public float blueColor = 0.02f;
	// Use this for initialization
	public bool runBool = true;
	private int transitionTime = 60;
	private float twilightTime = 0;
	
	public SfsRemote scr_SfsRemote;
	
	private string Day = "DAY", Night = "NIGHT", Twilight_Night_Day = "TWILIGHT_DAY_NIGHT", Twilight_Day_Night = "TWILIGHT_NIGHT_DAY";
	private bool DN_bool = true, ND_bool = true;
	
	private float newColor = 0;
	private GameManager gm;
	
	public hCharMove scr_hCharMove;
	public dCharMove scr_DCharMove;
	
	//private GameObject dialObj;
	
//	private HalflingPath hp;
//	private HWCharMgt hcm;
//	private DarklingPath dp;
//	private DLCharMgt dcm;
	
	void Awake()
	{
		scr_SfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
	}
	
	void Start () 
	{
		gm = (GameManager)FindObjectOfType(typeof(GameManager));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (scr_SfsRemote.state == Day)
		{
			if (transform.gameObject.name == "h_Character_dummy")
			{
				//Debug.Log("---> 01 halfing character activate...");
				if (scr_hCharMove.enabled == false)
					scr_hCharMove.enabled = true;
			}
			if (transform.gameObject.name == "d_Character_dummy")
			{
				//Debug.Log("---> 02 darkling character hide...");
				scr_DCharMove.enabled = false;
				scr_DCharMove.d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
			}
			gm.hsChar.SetActiveRecursively(false);
			gm.dsChar.SetActiveRecursively(false);
		}
		
		if (scr_SfsRemote.state == Night)
		{			
			if (transform.gameObject.name == "d_Character_dummy")
			{
				//Debug.Log("---> 03 darkling character activate...");
				if (scr_DCharMove.enabled == false)
					scr_DCharMove.enabled = true;
			}
			if (transform.gameObject.name == "h_Character_dummy")
			{
				//Debug.Log("---> 04 halfing character hide...");
				scr_hCharMove.enabled = false;
				scr_hCharMove.h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
			}
			gm.hsChar.SetActiveRecursively(false);
			gm.dsChar.SetActiveRecursively(false);
		}
		
		// day to night
		if (scr_SfsRemote.state == Twilight_Night_Day )
		{
			newColor = ((float.Parse(scr_SfsRemote.elapsedtime)/transitionTime) - 0.2f);
			if (newColor < 0)
				newColor = newColor * -1;
			if (transform.gameObject.name == "d_Character_dummy")
			{
				//Debug.Log("---> 05 darkling character hide...");
				scr_DCharMove.enabled = false;
				scr_DCharMove.d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
			}
			if (transform.gameObject.name == "h_Character_dummy")
			{
				//Debug.Log("---> 06 halfing character pipeweed... " + scr_SfsRemote.IsSmokePipeweed);
				scr_hCharMove.enabled = false;
				scr_hCharMove.h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
				
				if(scr_SfsRemote.IsSmokePipeweed)
				{
					//Debug.Log("---------------> halfling smoke");
					gm.hsChar.SetActiveRecursively(true);
				}
				else
				{
//					Debug.Log("---------------> halfling not smoke");
					gm.hsChar.SetActiveRecursively(false);
				}
			}
			
			StartCoroutine(ExecuteND());
			ND_bool = false;
			DN_bool = true;

		}
		
		// night to day
		if (scr_SfsRemote.state == Twilight_Day_Night )
		{
			newColor = ((float.Parse(scr_SfsRemote.elapsedtime)/transitionTime) - 0.2f);
			if (newColor < 0)
				newColor = newColor * -1;
			if (transform.gameObject.name == "h_Character_dummy")
			{
				//Debug.Log("---> 07 halfing character hide...");
				scr_hCharMove.enabled = false;
				scr_hCharMove.h_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.h_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_hCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
			}
			if (transform.gameObject.name == "d_Character_dummy")
			{
				//Debug.Log("---> 08 darkling character pipeweed... " + scr_SfsRemote.IsSmokePipeweed);
				scr_DCharMove.enabled = false;
				scr_DCharMove.d_FrontIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackIdle.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_FrontWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_BackWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_LeftWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.d_RightWalk.GetComponent<MeshRenderer>().enabled = false;
				scr_DCharMove.shadow.GetComponent<MeshRenderer>().enabled = false;
				
				if(scr_SfsRemote.IsSmokePipeweed)
				{
					gm.dsChar.SetActiveRecursively(true);
				}
				else
				{
					gm.dsChar.SetActiveRecursively(false);
				}
			}
			
			StartCoroutine(ExecuteDN());
			ND_bool = true;
			DN_bool = false;
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
			
			yield return new WaitForSeconds(0.05f);
		}
	}
	
	IEnumerator NightDayCnt()
	{
		while(true)
		{
			ND_cnt++;
			
			yield return new WaitForSeconds(0.05f);
		}
	}
}
