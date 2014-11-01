using UnityEngine;
using System.Collections;

public class WordDrag : MonoBehaviour 
{
	public GameObject curObject;
	private barallelmover bm;
	public Camera maincamera;
	public Vector3 curPos;
	
	public AudioController scr_audioController;
	void Start () 
	{
		bm = (barallelmover)FindObjectOfType(typeof(barallelmover));
		maincamera = GameObject.Find("BeerCamera").camera ;
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	void Update () 
	{
		curObject = GameObject.FindGameObjectWithTag("destorymug");
		if(Input.GetMouseButtonDown(0) )
		{
			Debug.Log("mouse down");
			Ray r = maincamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit rh;
			if(Physics.Raycast(r,out rh))
			{
				curObject = rh.collider.gameObject;
			}
			else
			{
				//curObject = null;
			}
			if(curObject!=null)
			{	
				Debug.Log("not null");
				if(curObject.tag == "destorymug")
				{
					curObject.rigidbody.isKinematic = false;
				}
			}	
		}

		if(Input.GetMouseButton(0))
		{		
			curPos = Input.mousePosition;
			Vector3 mPos = maincamera.ScreenToWorldPoint(curPos);
			if(curObject!=null)
			{
				if(curObject.tag == "destorymug")
				{
					curObject.transform.position = new Vector3(mPos.x,-2.4f,60f);	
					PlayMugslide();
				}
			}
						
		}
		if(Input.GetMouseButtonUp(0) )
		{		
			if(bm.leveler.pixelInset.height < 290)
			{
				curObject.rigidbody.isKinematic = true;
			}
			else
			{
				curObject.rigidbody.AddForce(Vector3.right *100);
			}
			
			if(scr_audioController.audio_tavernMugslide.isPlaying)
			{
				scr_audioController.audio_tavernMugslide.Stop();
			}
		}
		}
	
	
	 void PlayMugslide()
	{
		if(!scr_audioController.audio_tavernMugslide.isPlaying)
		{
			scr_audioController.audio_tavernMugslide.Play();
			scr_audioController.audio_tavernMugslide.minDistance = 1;
			scr_audioController.audio_tavernMugslide.maxDistance = 300;
			scr_audioController.audio_tavernMugslide.volume = 1f;
			//scr_audioController.audio_tavernMugslide.loop = true;
		}
	
	}
}
