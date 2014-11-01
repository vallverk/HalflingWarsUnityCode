using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	public GUIText timerText;
	public GUIText counterText;
	
	public TextMesh rewardXP;
	
	public float interval = 100;
	public float timer;
	public int count = 0;
	
	public int xpPerMug = 100;
	public int goldPerMug = 10;
	
	public static bool gamePlay;
	
	public SfsRemote scr_sfsRemote;
	public bool beerexit;
	public Texture2D popup;
	public Texture2D popupsuccess;
	public GUIStyle ok,textstyle;
	private barallelmover bm;
	
	public AudioController scr_audioController;
	private popUpInformation popupInfoScript;
	void Awake()
	{
		gamePlay = true;
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		bm = (barallelmover)FindObjectOfType(typeof(barallelmover));
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		
	}
	
	void Start () 
	{
		timer = Time.time;
		tavernLevel = 1; // to be replaced later
		popupInfoScript = (popUpInformation)FindObjectOfType(typeof(popUpInformation));
		
	}
	
	void Update () 
	{
		if(gamePlay) 
		{
			if(Time.time - timer >= interval) 
			{
				//StopGame();
				beerexit = true;
			}
			if(bm.timer >0)
			{
			timerText.text = Mathf.RoundToInt(interval - (Time.time - timer)).ToString();	
		}
	}
	}
	
	public int tavernLevel;
	double beer;
	void OnGUI()
	{
		if(beerexit == true)
		{
			GUI.DrawTexture(new Rect(-20,Screen.height/6.8267f,Screen.width/0.9481f,Screen.height/1.7067f),popup);
			GUI.DrawTexture(new Rect(Screen.width/38.4f,Screen.height/5.12f,Screen.width/1.0521f,Screen.height/3.4134f),popupsuccess);
			GUI.Label(new Rect(Screen.width/4.2667f,Screen.height/2.5f,Screen.width/2.56f,Screen.height/18.6181f),"Game Completed",textstyle);
			
			if(GUI.Button(new Rect(Screen.width/2.15126f,Screen.height/1.99f,Screen.width/13.9636f,Screen.height/18.6181f),"",ok))
			{
				popupInfoScript.wall.active = false;
				beer =  (double)((100 * tavernLevel) * count);
				scr_sfsRemote.SendRequestforAddbeer(beer);  //initialise tarvernLevel in the game start
				gamePlay = false;
				Destroy(GameObject.Find("Cube(Clone)"));
				Destroy(GameObject.Find("BeerPost"));
				Destroy(GameObject.Find("BeerGame(Clone)"));
				GameObject.Find("HC_B_Tavern_GO(Clone)").gameObject.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
				GameObject.Find("DL_B_Tavern_GO(Clone)").gameObject.transform.FindChild("TavernButton").gameObject.SetActiveRecursively(false);
				Screen.orientation = ScreenOrientation.Landscape;
				
				if(scr_audioController.audio_DrinkingTheme.isPlaying)
				{
					scr_audioController.audio_DrinkingTheme.Stop();
				}	
				
				if(scr_audioController.audio_tavernPouring.isPlaying)
				{
					scr_audioController.audio_tavernPouring.Stop();
				}
				
				if(scr_audioController.audio_tavernMugfill.isPlaying)
				{
					scr_audioController.audio_tavernMugfill.Stop();
				}
				
				if(scr_audioController.audio_tavernMugslide.isPlaying)
				{
					scr_audioController.audio_tavernMugslide.Stop();
				}
				
				scr_audioController.audio_dl.Play();
				scr_audioController.audio_hl.Play();
				//rewardXP.text = (count * xpPerMug).ToString() + " XP";
				//rewardXP.gameObject.GetComponent<Reward>().nextReward.GetComponent<TextMesh>().text = (count * goldPerMug).ToString() + " Gold";
				//rewardXP.gameObject.active = true;
				beerexit = false;
			}
		}
	}
	
	void UpdateCount()
	{
		count ++;
		counterText.text = count.ToString();
	}
}
