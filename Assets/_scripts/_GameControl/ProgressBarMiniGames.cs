using UnityEngine;
using System.Collections;

public class ProgressBarMiniGames : MonoBehaviour {

	public GameObject progressBar;
	public GameObject ProgressBarPlate;
	public GameObject progressBarPov;
	
	public int cnt = 0;
	public float seconds = 0f;
	private bool runOneTimeBool = false;
	
	
	// Use this for initialization
	void Start () 
	{	
		Debug.Log ("progress bar mini game...");
		StartCoroutine(updateProgressBar());
	}
	
	IEnumerator updateProgressBar()
    {
		//if (progressBarPov.gameObject == null)
		//	return;
		
        while(true)
        {
			if (cnt <= seconds)
				progressBarPov.transform.localScale = new Vector3(progressBarPov.transform.localScale.x + (1f / seconds)/*0.00167f*/,
																	progressBarPov.transform.localScale.y,
																	progressBarPov.transform.localScale.z);
			cnt++;	
			
//			Debug.Log(cnt);
        	yield return new WaitForSeconds(1);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log(transform.gameObject.name + " --- cnt :: " + cnt + " ----- " + seconds + " --- " + progressBarPov.transform.localScale.x);
		
		if(cnt == seconds)
		{
			if (runOneTimeBool)
			{
				runOneTimeBool = false;
				transform.gameObject.GetComponent<ProgressBarMiniGames>().enabled = false;
				progressBarPov.transform.localScale = new Vector3(0, progressBarPov.transform.localScale.y, progressBarPov.transform.localScale.z);
				cnt = 0;
				
				
				
				
			}
		}
	}
	
}

