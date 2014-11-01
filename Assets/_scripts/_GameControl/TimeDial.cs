using UnityEngine;
using System.Collections;

public class TimeDial : MonoBehaviour 
{		
	public SfsRemote scr_SfsRemote;
	
	private string Day = "DAY", Night = "NIGHT", Twilight_Night_Day = "TWILIGHT_DAY_NIGHT", Twilight_Day_Night = "TWILIGHT_NIGHT_DAY";
	
	private float transitionTime = 900.0f;
	public GameObject dialObj;
	private float prevRot1 = 1.0f;
	private bool DN_bool = true, ND_bool = true;
	private int ND_cnt = 0, DN_cnt = 0;
	public float zRot = 0f;
	private float curRot = 0f;
	private int sec = 1;
	
	public GameObject hw_FireFly, dw_FireFly;
	
	public dayNightTime scr_DayNightTime;
	
	void Awake()
	{
		scr_SfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_DayNightTime = GameObject.Find("GameManager").GetComponent<dayNightTime>();
	}
	
	
	public void SetDial()
	{	
///***		Debug.Log("dial time :-----> " + scr_SfsRemote.elapsedtime);
		
		scr_DayNightTime.dnCnt = int.Parse(scr_SfsRemote.elapsedtime);
			
		if (scr_SfsRemote.state == Twilight_Night_Day)
		{
///***			Debug.Log("if (scr_SfsRemote.state == Twilight_Night_Day).........");
			
			curRot =  180 - (float.Parse(scr_SfsRemote.elapsedtime) * 0.2f);
		}
		if (scr_SfsRemote.state == Twilight_Day_Night)
		{
///***			Debug.Log("if (scr_SfsRemote.state == Twilight_Day_Night)............");
			curRot = 360 - (float.Parse(scr_SfsRemote.elapsedtime) * 0.2f);
		
		}
///***		Debug.Log("current rot >>>>>>> " + curRot);
		
		dialObj.transform.eulerAngles = new Vector3(90, 0, curRot);
		zRot = curRot;
		
	}
	void Start () 
	{
		//if (GameManager.gameLevel >= 3)
		//{
			/*if (scr_SfsRemote.state == Twilight_Day_Night)
			{
				Debug.Log("if (scr_SfsRemote.state == Twilight_Night_Day).........");
				
				curRot = float.Parse(scr_SfsRemote.elapsedtime) * 0.2f;
			}
			if (scr_SfsRemote.state == Twilight_Night_Day)
			{
				Debug.Log("if (scr_SfsRemote.state == Twilight_Day_Night)............");
				curRot = float.Parse(scr_SfsRemote.elapsedtime) * 0.2f;
			}
			Debug.Log("current rot >>>>>>> " + curRot);
			
			dialObj.transform.eulerAngles = new Vector3(90, 0, curRot);
			zRot = curRot;*/
		//}
		//prevRot1 = dialObj.transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log("dial rot :: " + dialObj.transform.eulerAngles + " --- " + scr_SfsRemote.state + " --- " +  float.Parse(scr_SfsRemote.elapsedtime));
		if (scr_SfsRemote.state == Day)
		{
			sec = 0;
			zRot = 1f;
			dialObj.transform.eulerAngles = new Vector3(90, 0, 1f);
			
			if (hw_FireFly.active == true)
			{
				hw_FireFly.SetActiveRecursively(false);
			}
			
			if (dw_FireFly.active == true)
			{
				dw_FireFly.SetActiveRecursively(false);
			}
		}
		
		if (scr_SfsRemote.state == Night)
		{
			sec = 0;
			zRot = 180f;
			dialObj.transform.eulerAngles = new Vector3(90, 0 , 180);
			
			if (hw_FireFly.active == false)
			{
				hw_FireFly.SetActiveRecursively(true);
				hw_FireFly.GetComponent<ParticleSystem>().Play();
			}
			
			if (dw_FireFly.active == false)
			{
				dw_FireFly.SetActiveRecursively(true);
				dw_FireFly.GetComponent<ParticleSystem>().Play();
			}
		}
		
		if (scr_SfsRemote.state == Twilight_Night_Day && ND_bool)
		{
			sec = 1;
			StartCoroutine(ExecuteND());
			ND_bool = false;
			DN_bool = true;
			
		}
		if (scr_SfsRemote.state == Twilight_Day_Night && DN_bool)
		{
			sec = 1;
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
			DN_cnt = DN_cnt + 1;
			//Debug.Log("day to night conversion..........." + prevRot1 + " --- " + prevRot1/transitionTime + " --- " + zRot);
			//DN_cnt++;
			zRot = zRot + (180 / transitionTime);
			dialObj.transform.eulerAngles = new Vector3(90, 0, zRot);
			
			yield return new WaitForSeconds(sec);
		}
	}
	
	IEnumerator NightDayCnt()
	{
		while(true)
		{
			//ND_cnt = ND_cnt + 180/transitionTime);
			//ND_cnt++;
//			Debug.Log("day to night conversion..........." + prevRot1 + " --- " + prevRot1/transitionTime + " --- " + zRot);
			
			zRot = zRot + (180 / transitionTime);
			dialObj.transform.eulerAngles = new Vector3(90, 0, zRot);
			yield return new WaitForSeconds(sec);
		}
	}
}
