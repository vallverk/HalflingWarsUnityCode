using UnityEngine;
using System.Collections;

public class StickMovement : MonoBehaviour 
{
	public bool dragFlag;
	bool potionReady = false;
	bool timeout = false;
	
	public GameObject slider;
	public GameObject liquid;
	public GameObject xpText;
	
	public float stir_speed;
	
	public Rect lblpos;
	public GUIStyle lblStyle;
	public GUIStyle lblStyle1;
	
	public static bool Stiring; //once enabled you can not select more herbs, enabled when you first touch stick 
	
	float endPos;
	Color startColor;
	public Camera miniGamePotionCam;
	public AudioController scr_audioController;
	public SfsRemote scr_sfsRemote ;
	
	float timer;
	
	//private bool xpRewardBool = true;
	
	Potion finalPostion;
	GameObject PotionGame;
	string msg = "";
	private Beaker bk;
	public GameObject stick_move;
	
	private GameObject tutpopup;
	
	private AchivementsDetails ad;
	public bool potionexit;
	public bool potionexitSuccess;
	public Texture2D popup;
	public Texture2D popupfail;
	public Texture2D popupsuccess;
	public GUIStyle ok,textstyle;
	private popUpInformation popupInfoScript;
	void Awake()
	{
		PotionGame = GameObject.Find("potionGame(Clone)").gameObject;
		bk = (Beaker)FindObjectOfType(typeof(Beaker));
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		scr_sfsRemote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
	}

	void Start () {
		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
		popupInfoScript = (popUpInformation)FindObjectOfType(typeof(popUpInformation));
		
		tutpopup = GameObject.Find("potionpopup");
		if(PlayerPrefs.GetInt("potion") == 0)
		{
			tutpopup.active = true;
			PlayerPrefs.SetInt("potion",1);
		}
		else
		{
			tutpopup.active = false;
		}
	}
	
	void OnEnable()
	{
		if(slider || liquid) {
			endPos = -slider.transform.localPosition.x;
			startColor = liquid.renderer.material.color;
			timer = Time.time;
		}
		else {
			this.enabled = false;
		}
	}
	
	void Update () 
	{
		if(finalPostion)
		{
			if(Time.time - timer > finalPostion.timeToPrepare && (!potionReady && !timeout))
			{
				timeout = true;
				Stiring = false;
				msg = "Potion Mixture Fails";
				potionexit = true;
				if(slider.transform.localPosition.x > endPos) {
					liquid.renderer.material.color = Color.black;
					
					//RewardXP();
				}
				//xpRewardBool = false;
			}
		}
		if(Stiring && dragFlag) {
			MoveStick();
		}
		else
			if(Input.GetMouseButtonDown(0) && (!potionReady || !timeout)) {
				Ray ray = miniGamePotionCam.ScreenPointToRay(Input.mousePosition);
				RaycastHit info;
				if(Physics.Raycast(ray,out info))
				{
					if(info.collider == stick_move.gameObject.collider){
						dragFlag = true;
						if(!Stiring && !timeout && !potionReady)
							StartStiring();
					}
				if(info.collider.name == "potionpopup")
				{
					tutpopup.active = false;
				}
				}
			}
		
		
		if(isPlaybubbles)
		{
			PlaybubblesSound();
		}
		
	}
	
	
	private bool isplayStir;
	public void PlayStirringSound()
	{
		scr_audioController.audio_potionStirring.Play();
		scr_audioController.audio_potionStirring.volume = 0.7f;
		scr_audioController.audio_potionStirring.minDistance = 1;
		scr_audioController.audio_potionStirring.maxDistance = 300;
		scr_audioController.audio_potionStirring.loop = true;
		isplayStir = true;
	}
	
	public void MoveStick()
	{
		if(Input.GetMouseButton(0))
		{
			if(dragFlag && Input.GetTouch(0).phase == TouchPhase.Moved) {
				Vector3 movePos = miniGamePotionCam.ScreenToWorldPoint(Input.mousePosition);
				movePos.x = Mathf.Clamp(movePos.x,-2.15f , 2.15f);
				transform.position = new Vector3(movePos.x,transform.position.y,transform.position.z);
				
				if(finalPostion) {
					slider.transform.Translate(Vector3.left * stir_speed * Time.deltaTime * Input.GetTouch(0).deltaPosition.magnitude);
					liquid.renderer.material.color = Color.Lerp(startColor,finalPostion.finalColor,Mathf.Abs((-endPos) - slider.transform.localPosition.x)/ (Mathf.Abs(endPos) * 2));
					if(slider.transform.localPosition.x <= endPos) {
						Stiring = false;
						potionReady = true;
						liquid.renderer.material.color = finalPostion.finalColor;
						if(finalPostion.Name == "none")
						{
							msg = "Opps!!, Sorry Wrong Potion";
							potionexit = true;
						}
						else
						{
						msg = "Yeh, You have done it, Potion is Ready";
							potionexit = true;
							potionexitSuccess = true;
							PotionMixCount();
						}
						if (liquid.renderer.material.color != Color.black)
						{
							RewardXP();
						}
					}
					
					if(!isplayStir)
					{
						PlayStirringSound();
					}
				}
			}
			
			if(dragFlag && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				dragFlag = false;
				isplayStir = false;
				
				if(scr_audioController.audio_potionStirring.isPlaying)
				{
					scr_audioController.audio_potionStirring.Stop();
				}
		}
	}
		else if(Input.GetMouseButtonUp(0))
		{
			if(dragFlag && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				dragFlag = false;
				isplayStir = false;
				
				if(scr_audioController.audio_potionStirring.isPlaying)
				{
					scr_audioController.audio_potionStirring.Stop();
				}
			}
		}
	}
	
	void OnGUI()
	{
		/*if(Screen.width == 1536 && Screen.height == 2048)
		{
			GUI.skin.label = lblStyle1;
		}
		else
		{
		GUI.skin.label = lblStyle;
		}*/
		//GUI.matrix = Matrix4x4.Scale(new Vector3(Screen.width / 768.0f, Screen.height / 1024.0f, 1));
		
		if(finalPostion && (!potionReady && !timeout)) 
		{
			if(Screen.width == 1536 && Screen.height == 2048)
			{
				GUI.Label(new Rect(Screen.width/1.13f,Screen.height/51.2f,Screen.width/15.36f,Screen.height/34.1334f),(finalPostion.timeToPrepare - (int)(Time.time-timer)).ToString(),lblStyle1);
			}
			else
			{
				GUI.Label(new Rect(Screen.width/1.13f,Screen.height/51.2f,Screen.width/15.36f,Screen.height/34.1334f),(finalPostion.timeToPrepare - (int)(Time.time-timer)).ToString(),lblStyle);
			}
		}
		
		//GUI.Label(lblpos,msg);
		
		GUI.matrix = Matrix4x4.Scale(new Vector3(1,1,1));
		if(potionexit == true)
		{
			GUI.DrawTexture(new Rect(-20,Screen.height/6.8267f,Screen.width/0.9481f,Screen.height/1.7067f),popup);
			if(potionexitSuccess == true)
			{
				GUI.DrawTexture(new Rect(Screen.width/38.4f,Screen.height/5.12f,Screen.width/1.0521f,Screen.height/3.4134f),popupsuccess);
			}
			else
			{
				GUI.DrawTexture(new Rect(Screen.width/38.4f,Screen.height/5.12f,Screen.width/1.0521f,Screen.height/3.4134f),popupfail);
			}
			GUI.Label(new Rect(Screen.width/4.2667f,Screen.height/2.5f,Screen.width/2.56f,Screen.height/18.6181f),msg,textstyle);
			if(GUI.Button(new Rect(Screen.width/2.15126f,Screen.height/1.99f,Screen.width/13.9636f,Screen.height/18.6181f),"",ok))
			{
				popupInfoScript.wall.active = false;
				bk.inputHerbs = new Herb[0];
				Destroy(PotionGame);
				GameObject.Find("HC_B_Apothecary_GO(Clone)").gameObject.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
				GameObject.Find("DL_B_Apothecary_GO(Clone)").gameObject.transform.FindChild("ApothecaryButton").gameObject.SetActiveRecursively(false);
				Screen.orientation = ScreenOrientation.Landscape;
				
				if(scr_audioController.audio_potionBubbles.isPlaying)
				{
					scr_audioController.audio_potionBubbles.Stop();
				}
				
				if(scr_audioController.audio_potionStirring.isPlaying)
				{
					scr_audioController.audio_potionStirring.Stop();
				}
				
				if(scr_audioController.audio_potionFire.isPlaying)
				{
					scr_audioController.audio_potionFire.Stop();
				}
					
			    if(scr_audioController.audio_PotionTheme.isPlaying)		
				{
				    scr_audioController.audio_PotionTheme.Stop();
				}
				
				scr_audioController.audio_hl.Play();
				scr_audioController.audio_dl.Play();
				
				potionexit = false;
				potionexitSuccess = false;
				
				scr_sfsRemote.getPotionList();
			}
		
		}
	}
	
	
	void StartStiring()
	{
		finalPostion = Beaker.GetPotion();
		timer = Time.time;
		if(finalPostion == null) {
			dragFlag = false;
			msg = "No Potion To Create";
			
		    Beaker.isgotPotion = true;
			SendHerbsNpotiontoSvr();
		}
		else
		{
			Stiring = true;
			stir_speed = 0.15f / finalPostion.timeToPrepare;
			//msg = "Potion : " + finalPostion.Name;
			
			isPlaybubbles = true;
			Beaker.isgotPotion = true;
///***			Debug.Log("Potion TypeId : " + GetPotionTypeId(finalPostion.Name));
			
			SendHerbsNpotiontoSvr();
		}
	}
	
	private bool isPlaybubbles;
	public void PlaybubblesSound()
	{
		scr_audioController.audio_potionBubbles.Play();
		scr_audioController.audio_potionBubbles.volume = 1;
		scr_audioController.audio_potionBubbles.minDistance = 1;
		scr_audioController.audio_potionBubbles.maxDistance = 300;
		scr_audioController.audio_potionBubbles.loop = true;
		isPlaybubbles = false;
	}
	
	
	
	public void RewardXP()
	{
		finalPostion.CalculateReward();
		xpText.active = true;
		xpText.GetComponent<TextMesh>().text = finalPostion.GetEarnedXP().ToString() + " XP";
		xpText.GetComponent<Reward>().nextReward.GetComponent<TextMesh>().text = finalPostion.GetEarnedGold().ToString() + " Gold";
	}
	
	
	//Harish chander..
			
			
	int cnt = 0;
	public int ReturnHerbCount(int TypeId)
	{
		cnt = 0;
		
		for(int i=0 ; i< Beaker.scr_sfsRemote.lst_HerbObjects.Count ;i++)
		{
			if(Beaker.scr_sfsRemote.lst_HerbObjects[i].ObjectTypeId.Equals(TypeId))
			{
				cnt++ ;
			}
		}
		
		return cnt;		
	}		
			
			
			
	int h1,h2,h3,h4,PotionId ;
	public void SendHerbsNpotiontoSvr()
	{
		if(Beaker.isgotPotion && Beaker.isgotHerbs)
		{
			if(finalPostion != null)
			{
			  PotionId = GetPotionTypeId(finalPostion.Name);
			}
			else 
			{
			   PotionId = -1;
			}
			
			int c = Beaker.lst_HerbsSelected.Count;
			
			if(c == 4)
			{
				h1 = GetHerbsObjId(Beaker.lst_HerbsSelected[0]);
				h2 = GetHerbsObjId(Beaker.lst_HerbsSelected[1]);
				h3 = GetHerbsObjId(Beaker.lst_HerbsSelected[2]);
				h4 = GetHerbsObjId(Beaker.lst_HerbsSelected[3]);
			}
			else if(c == 3)
			{
				h1 = GetHerbsObjId(Beaker.lst_HerbsSelected[0]);
				h2 = GetHerbsObjId(Beaker.lst_HerbsSelected[1]);
				h3 = GetHerbsObjId(Beaker.lst_HerbsSelected[2]);
				h4 = 0;
			}
			else if(c == 2)
			{
				h1 = GetHerbsObjId(Beaker.lst_HerbsSelected[0]);
				h2 = GetHerbsObjId(Beaker.lst_HerbsSelected[1]);
				h3 = 0;
				h4 = 0;
			}
			
			Beaker.scr_sfsRemote.SendRequestforPotionMix(PotionId,h1,h2,h3,h4);
		}
	}
	
	private int HerbObjId;
	private int GetHerbsObjId(int typeId)
	{
		for(int i= 0 ; i < Beaker.scr_sfsRemote.lst_HerbObjects.Count ; i++)
		{
			if(Beaker.scr_sfsRemote.lst_HerbObjects[i].ObjectTypeId.Equals(typeId))
			{
				HerbObjId = Beaker.scr_sfsRemote.lst_HerbObjects[i].ObjectId;				
			}
		}
		
		return HerbObjId;
	}		
					
					
	private int PotionTypeId;
	private int GetPotionTypeId(string potionName)
	{
		
		switch(potionName)
		{
			case "Poppysnap":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objPoppySnap.objTypeId;
			
			break;
			
			case "bitterroot":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objBitterRoot.objTypeId;
			
			break;
			
			case "vetch spray":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objVetchSpray.objTypeId;
			
			break;
			
			case "slug tonic":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objSlugTonic.objTypeId;
			
			break;
			
			case "Fever Pitch":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objFeverPitch.objTypeId;
			
			break;
			
			case "Morrow draught":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objMorrowDraught.objTypeId;
			
			break;
			
			case "boggle horn":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objBoggleHom.objTypeId;
			
			break;
			
			case "Spleen bite":
			
			PotionTypeId = Beaker.scr_gameObjectSvr.objSpleenBite.objTypeId;
			
			break;
		}
		
		return PotionTypeId;
	}
	
	public void PotionMixCount()
	{
		 		ad.potionCount = PlayerPrefs.GetInt("potioncount");
		 		PlayerPrefs.SetInt("potioncount",(ad.potionCount+1));
		
///***		Debug.Log("potioncount count :"+PlayerPrefs.GetInt("potioncount"));
		 		ad.percentComplete24 = 100;
		 		ad.percentComplete32 = 10*PlayerPrefs.GetInt("potioncount");
		 		ad.percentComplete38 = 4*PlayerPrefs.GetInt("potioncount");
		 		ad.percentComplete43 = 2*PlayerPrefs.GetInt("potioncount");
	}
}
