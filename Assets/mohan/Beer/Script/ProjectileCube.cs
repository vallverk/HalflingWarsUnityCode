using UnityEngine;
using System.Collections;

public class ProjectileCube : MonoBehaviour 
{

	public GameObject projectilePrefab;
	public GameObject groundfiller;
	public GameObject mugfiller;
	RaycastHit hit;
	public bool filler;
	public Sprite leftChar;
	public Sprite rightChar;
	public int charTimer;
	public AudioController scr_audioController;
	
	void Start () 
	{
		InvokeRepeating("CharAnimTimer", float.Epsilon, 1.0f);
		groundfiller =GameObject.Find("liquilflow");
		mugfiller = GameObject.Find("liquilflowhit");
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	void CharAnimTimer()
	{
		charTimer++;
	}
	void Update () 
	{
		Vector3 mforward01 = projectilePrefab.transform.TransformDirection(Vector3.down) * 5.5f;
		Debug.DrawRay(projectilePrefab.transform.position, mforward01, Color.green);
		
		if (Physics.Raycast(projectilePrefab.transform.position, projectilePrefab.transform.TransformDirection(Vector3.down), out hit, 100)) {}
		
		if (hit.collider == null) return;
		
		if (hit.collider.gameObject.name == "Cube" || hit.collider.gameObject.name == "Cube(Clone)" )
		{
			filler = true;
			mugfiller.SetActiveRecursively(true);
			groundfiller.SetActiveRecursively(false);
			PlayMugfill();
			
		//	Debug.Log("Playing beer pouring ");
		}
		else
		{
			filler = false;
			mugfiller.SetActiveRecursively(false);
			groundfiller.SetActiveRecursively(true);
			
			if(scr_audioController.audio_tavernMugfill.isPlaying)
			{
				scr_audioController.audio_tavernMugfill.Stop();
			}
			
///***			Debug.Log("Playing beer pouring stopping ");
		}
		if(charTimer >0 && charTimer<=8)
		{
		}
		else
		{
			charTimer = 0;
			leftChar.PlayAnim("leftcharacter");
			rightChar.PlayAnim("rightcharacter");
		}
		
	}
	
	void PlayMugfill()
	{
		if(!scr_audioController.audio_tavernMugfill.isPlaying)
		{
			scr_audioController.audio_tavernMugfill.Play();
			scr_audioController.audio_tavernMugfill.minDistance = 1;
			scr_audioController.audio_tavernMugfill.maxDistance = 300;
			scr_audioController.audio_tavernMugfill.volume = 1;
			//scr_audioController.audio_tavernMugfill.loop = true;
		}
	}
}
