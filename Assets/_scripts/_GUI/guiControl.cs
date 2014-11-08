using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using Sfs2X.Logging;

public class guiControl : MonoBehaviour 
{
	//public static bool decorationMenuBool = false;
	
	public static bool popUpOpenBool = false;
	public static bool executeTaskBool = false;
	public static bool useRabbitBool = false;
	
	// Sprite Text declaration
	public SpriteText goldCoinScoreInfo;
	public SpriteText plantsScoreInfo;
	public SpriteText sparkScoreInfo;
	public SpriteText levelScoreInfo;
	
	public SpriteText popUpType1_spText;
	public SpriteText title_spText;
	public SpriteText info_spText;
	public SpriteText popUpType3_spText;
	public SpriteText popUpType_QuestNo_spText;
	public SpriteText popUpType_Dig1_spText;
	public SpriteText popUpType_Dig2_spText;
	public SpriteText popUpType_Dig5_spText;
	
	
	
	// Script declaration
	public GameManager gameManagerInfo;
	public storeManager storeManagerInfo;
	public popUpInformation popUpInfoScript;
	public CreatureSystem creatureSystemInfo;
	public infoImageList infoImageListScript;
	public InventoryItems inventoryItemsInfo;
	public objectCost scrObjectCost;
	
	// hud object
	public GameObject timeDisplayHUD;
	public GameObject questProgressBar;
	
	
	// Game Object declaration
	public GameObject arrow;
	public GameObject gameArrow;
	public GameObject rabbitButt;
	public GameObject gameRabbitButt;
	public GameObject trainingGround01;
	public GameObject trainingGround02;
	public GameObject dirtPath;
	public GameObject farmPlot;
	public GameObject turnipPlantGO;
	public GameObject pipeWeedGO;
	public GameObject golumGO;
	public GameObject DarkgolumGO;
	public GameObject innGO;

	// training ground blocks
	public GameObject hEarthTG_block, hPlantTG_block, hWaterTG_block, dEarthTG_block, dSwampTG_block, dFireTG_block;
	
	public GameObject harvestButt;
	
	public GameObject creatureChar;
	
	public GameObject delArrow;
	public GameObject curObj;
	
	private GameObject arrowPos;
	public GameObject creatureTemp;
	public GameObject curAttackingCreature;
	
	
	// PopUp declaration
	public GameObject popUpType1; // with 1 button ("OK")
	public GameObject popUpType2; // Info with 1 button ("OK")
	public GameObject popUpType3; // with 2 button ("Yes/No")
	public GameObject popUpType4;
	public GameObject popUpType5;
	public GameObject FeedMorphPopUp;
	
	public GameObject tutPopup;
	public GameObject levelCompletePopup;
	public GameObject clearCavePopup;
	public GameObject clearCaveInvestPopup;
	public GameObject clearCaveSuccessPopup;
	public GameObject farmPopup;
	public GameObject plotCompletePopup;
	
	
	
	// Menu declaration
	public GameObject storeUI;
	public GameObject DarklingstoreUI;
	public GameObject storeHDUI;
	public GameObject decorationUI;
	public GameObject buildingUI;
	public GameObject creatureUI;
	public GameObject trainingGroundUI;
	public GameObject treasureUI;
	public GameObject plantsUI;
	public GameObject inventoryUI;
	public GameObject defenceUI;
	
	// darkling menu
	public GameObject darklingStoreUI;
	public GameObject darklingDecorationUI;
	public GameObject darklingBuildingUI;
	public GameObject darklingCreatureUI;
	public GameObject darklingTrainingGroundUI;
	public GameObject darklingTreasureUI;
	public GameObject darklingPlantUI;
	public GameObject darklingDefenceUI;
	
	public GameObject infoTrainingGroundUI;
	public GameObject infoDirtPathUI;
	
	public GameObject trainingGrndCompleteUI;
	public GameObject dirtPathCompleteUI;
	
	public GameObject popUpInvestUI;
	public GameObject itemBagPanelUI;
	
	public GameObject storyLogButton;
	
	
	// Static variable declaration
	public static int tutorialCnt = 1;
	
	
	
	// Bool variable declaration
	public bool caveClearInvestPopupBool = false;
	private bool farmBool = false;
	public bool nextPopUpBool = true;
	public bool nextTaskBool = true;
	
	
	// Vector3 variable declaration
	public Vector3 creaturePos;
	
	public Camera cam;
	private float oldCamSize;
	
	// Texture declaration
	//public Texture turnip1, turnip2, turnip3;
	//public Texture pipeWeed1, pipeWeed2;
	
	RaycastHit rabbitHit;
	RaycastHit filpHit;
	
	// feed progress bar
	public GameObject feedPB_Pov;
	public GameObject feedPB;
	
	
	
	
	
	// pop up info titile
	string title01 = "Training Ground";
	
	public GameObject currentRabbitButton, currentHarvestButton;
	
	private int sproutCnt = 1, bargCnt = 1, nixCnt = 1, leechCnt = 1, dHoundCnt = 1;
	
	public GameObject golum ;
	public GameObject Darkgolum ;
	public bool golumbool;
	
	private taskDetails td;
	public bool Halfbtn = false;
	public GameObject taskList;
	private SfsRemote scr_remote;
	private LoadUserWorld scr_userWorld;
	private GameObjectsSvr scr_gameObjsvr;
	private cameraswitch scr_cameraswitch;
	private AudioController scr_audioController;
	
	private GameObject curFlipObj, curDelObj, curPlaceObj, goldObj;
	
	private findPath fp;
	
	public SpriteText habitatTxt, creatureTxt, infoTxt;
	public GameObject fmCreatureTex;
	
	public bool HalflingCancleBool;
	public bool DarklingCancleBool;
	// Use this for initialization
	
	private GameObject[] hPlotCnt = new GameObject[7];
	private GameObject[] dPlotCnt = new GameObject[7];
	
	private GameObject[] cavePatchList = new GameObject[17];
	
	public bool darkDirtPath;
	public Inventory1 inventory1Info;
	public taskDetails taskDetailsInfo;

	public Transform halfwayone;
	public Transform darkwayone;
	
	private Vector3 objPrevPos = Vector3.zero;
	public GameObject potionGame;
	public GameObject BeerGame;
	public bool isGetMaxFeed;
	private Beaker bk;
	
	public GameObject Feedbtn;
	public GameObject Morphbtn;
	
	private dirtPathPlacement dpp;
	public GameObject DarklingUIbtn;
	public GameObject AttackUIbtn;
	public GameObject UpgradeUIbtn, UpgradeFarmBtn, tgUpgradeBtn;
	
	public static bool feedMorphTutorial;
	private GameObject handObjTut;
	
	public GameObject battle;
	private BattleGroundManager bmgr;
	
	public UITextField creatureNameTF;
	
	// Goblin Cave Information
	string [] goblinCaveInfoString = {"You need to be at game Level 4. \nCreature Barg or Cusith need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 6. \nCreature Cusith need to be at feed level 10 in order to attack the cave.",
									"You need to be at game Level 8. \nCreature Sprout/ Nymph/ Dryad need to be at feed level 1 in order to attack the cave.",
									"You need to be at game Level 10. \nCreature Nymph/ Dryad need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 12. \nCreature Dryad need to be at feed level 10 in order to attack the cave.",
									"You need to be at game Level 14. \nCreature Nix/ Draug/ Dagon need to be at feed level 1 in order to attack the cave.",
									"You need to be at game Level 18. \nCreature Draug/ Dagon need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 22. \nCreature Dagon need to be at feed level 10 in order to attack the cave.",
									"You need to be at game Level 5. \nCreature Leech/ Leshy/ Lurker need to be at feed level 1 in order to attack the cave.",
									"You need to be at game Level 7. \nCreature Dark Leshy/ Lurker need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 9. \nCreature Lurker need to be at feed level 10 in order to attack the cave.",
									"You need to be at game Level 11. \nCreature Sprite/ Imp/ Djinn need to be at feed level 1 in order to attack the cave.",
									"You need to be at game Level 13. \nCreature Imp/ Djinn need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 15. \nCreature Djinn need to be at feed level 10 in order to attack the cave.",
									"You need to be at game Level 17. \nCreature Hound/ Fenrir/ Hell Hound need to be at feed level 1 in order to attack the cave.",
									"You need to be at game Level 21. \nCreature Fenrir/ Hell Hound need to be at feed level 5 in order to attack the cave.",
									"You need to be at game Level 25. \nCreature Hell Hound need to be at level 10 in order to attack the cave.",
									"You need to be at game Level 2. \nCreature Hound need to be at level 1 in order to attack the cave."
									};
	
	string [] creatureInfoString = {"Anyone who has known this vicious beast has cause to fear.  From a distance, many have mistaken it for a large dog, coming closer only to realize too late by its brutal size, sunken skin, disfigured body, sinewed muscles and fearless eyes that only hell could spew forth such a creature.",
									"A gigantic and terrible wolf shaped monster freely roams your farm. The creature’s massive head has flames that burn from its eyes and nostrils. The towering Fenrir is said to be the father of all wolves. Under a full-lit moon the Fenrir can be heard howling; cursing the gods that unjustly gave it life.",
									"The incarnation of something once canine now occupies your land. This three headed beast stares down at you with intense fiery eyes. Like something spawned from the pit of hell itself, this enormous creature towers over its master; its hideous glare sends a blood curdling shrill down your spine.",
									"The fire fairy. With its glistening membranous wings and almost iridescent skin, it is often confused with exotic insects or flowers at first glance, often until too late.  This creature is a master of brimfire, an inextinguishable flame summoned from hell itself, that can consume any unwary opponent in seconds.",
									"A small red Imp slinks about your farm. This mischievous demon skitters about hiding in shadows to conceal its hideously fanged face. These bat winged spirits are mostly known for playing unruly pranks and tricks on their masters.",
									"Conjured of smoke and fire, the mighty Djinn is a spell-evoking demon of the blackest magic. These fiery demons are known to attack any who disturb them without hesitation, and are typically found near gravesites devouring the flesh of the freshly fallen.",
									"An enormous bloodsucking leech dwells in your swamps murky water. This menacing creature has rows of razor sharp teeth making it a lethal opponent against all fleshy creatures.",
									"A strange beast surfaces from your murky swamp. This creature appears to have hair and a beard made from living grass and vines, and a mangled fish like tail. Its dark violet skin contrasts with its glowing pale blue fungus eyes, protruding from its bulbous head.",
									"An enormous squid like creature has found a new home just beneath the putrid waters of your swamp. Its oily black tentacles reach over the swamps festering banks franticly searching for fresh prey to feed its gaping maw.",
									"A strangely morphed version of a friendly home pet, this dog like creature was created for one purpose: search and devour any and all evil.  Its iron strong muscles let any foe know it is not a beast to be trifled with; its devastating bite almost surely equals death.",
									"A monstrous dog with huge sabre sized teeth roams your farm.  The Barg’s claws leave deep furrows in the hard ground as it paces the lengths of your land. Its glowing electrical eyes remind you of an explosive lightning storm.",
									"An enormous hound like creature has found a new home on your farm. The great Cusith while loyal to its master is a harbinger of death.",
									"While this creature may seem quite harmless and alluring to look upon, make no mistake, this woodland creature can inflict damaging blows. Weathered with iron-like fibrous armour the Sprout can withstand nearly any known weapon’s damage without the slightest falter.",
									"A divine and beautiful maiden spirit inhabits one of your trees. This peaceful spirit prefers the solitude of deep mountains and cool grottos to the dealing of the fleshy creatures.",
									"Life has taken root in one of your ancient oakey trees. This wise and powerful spirit spends its long years deep in thoughtful contemplation. Only the most perilous and dark hour will wake this majestic tree form to its dealings with fleshy creatures.",
									"Often they appear in human form, singing enchanted songs and luring women and children to drown in their lakes or streams.  Though they have now been recruited by those that seek to destroy the evil forces that threaten to pollute their crystal waters they make their homes.",
									"The consciousness of a brave and mighty hero more than a hundred years past has been reborn into a dark blue, 'human like' form. The Draug or 'one who walks after death' exhumes the graves of important men, once hailed for great deeds and absorb their consciousness.",
									"A brute sea-creature has spawned in the deep caverns of your clear blue pools. Above, the farm grounds tremor and shake as the enormous creature surfaces. Lord of the Waters it is called."
									};
	
	string [] trainingGroundInfoString = {	"This training ground can be purchased from the market.  Sparks are buried here to grow earth type creatures",
										  	"This training ground can be purchased from the market.  Sparks are buried here to grow plant type creatures",
											"This training ground can be purchased from the market.  Sparks are buried here to grow water type creatures",
											"This training ground can be purchased from the market.  Sparks are buried here to grow dark earth type creatures",
											"This training ground can be purchased from the market.  Sparks are buried here to grow swamp type creatures",
											"This training ground can be purchased from the market.  Sparks are buried here to grow fire type creatures"
										};
	
	string [] buildingInfoString = {"Gardens are the best source of food for the Halfling. They produce crops for creature food, herbs for your apothecary and gold for you.  It can be purchased from the Market.",
									"The Inn is the Halfling's Primary source of income.  It can be purchased from the Market.",
									"The stable can be purchased at the market.  It produces gold for you by offering its husbandry services to visitors.",
									"The Blacksmith can be purchased at the market.  It produces gold for you by offering its smithing services to visitors.",
									"The Apothecary is where you brew elixirs & potions made from herbs in your garden.  It can be purchased from the Market.",
									"Taverns are a favorite gathering place for Halflings, which is why it makes so much gold.  Taverns can be purchased from the Market.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"Sun Shrines increase your productivity during the night.  It can be purchased in the Market.",
									"Gardens are the best source of food for the Darkling. They produce crops for creature food, herbs for your apothecary and gold for you.  It can be purchased from the Market.",
									"The Inn is the Darkling's Primary source of income.  It can be purchased from the Market.",
									"The stable can be purchased at the market.  It produces gold for you by offering its husbandry services to visitors.",
									"The Blacksmith can be purchased at the market.  It produces gold for you by offering its smithing services to visitors.",
									"The Apothecary is where you brew elixirs & potions made from herbs in your garden.  It can be purchased from the Market.",
									"Taverns are a favorite gathering place for Darklings, which is why it makes so much gold.  Taverns can be purchased from the Market.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"The magic of the Obelisk is all but lost to the known world.  It draws its power from the elements from which it was created and emanates it to the surrounding area.  Living creatures within its range feed from its aura, gaining strength and stamina.",
									"Moon Shrines increase your productivity during the day.  It can be purchased in the Market.",
									"Hardly worthy of being called a home, this is more of a hovel.  Halflings are used to living in holes, but this seems more fit for a earthmole",
									"Cool, dark & damp.  Hardly large enough to sleep in, but at least it’s cover from daylight."
									};
	
	
	void Awake () 
	{
		goldCoinScoreInfo.text = GameManager.coins.ToString();
		plantsScoreInfo.text = GameManager.food.ToString();
		sparkScoreInfo.text = GameManager.sparks.ToString();
		
		scr_remote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		scr_userWorld = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_gameObjsvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		scr_cameraswitch = (cameraswitch)FindObjectOfType(typeof(cameraswitch));
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
	}
	
	private string oldTextCreature = " ";
	
	void Start()
	{
		Debug.Log ("start 006...");
		bmgr = battle.GetComponent<BattleGroundManager>();
		
		td = (taskDetails)FindObjectOfType(typeof(taskDetails));
		fp = (findPath)FindObjectOfType(typeof(findPath));
		bk = (Beaker)FindObjectOfType(typeof(Beaker));
		
		dpp = (dirtPathPlacement)FindObjectOfType(typeof(dirtPathPlacement));
		DarklingUIbtn = GameObject.Find("UIElements").transform.FindChild("StoreHD_UI").transform.FindChild("storeDarklingButt").gameObject;
		AttackUIbtn = GameObject.Find("UIElements").transform.FindChild("panel_Attack").transform.FindChild("objAttack").gameObject;
		UpgradeUIbtn = GameObject.Find("UIElements").transform.FindChild("ObjectMovePanel").transform.FindChild("objUpgrade").gameObject;
		UpgradeFarmBtn = GameObject.Find("UIElements").transform.FindChild("panel_Farm").transform.FindChild("objUpgrade").gameObject;
		tgUpgradeBtn = GameObject.Find("UIElements").transform.FindChild("ObjectEditPanel").transform.FindChild("objUpgrade").gameObject;
		
		oldTextCreature = "Hound";
	}
	
	
	private int renameCreatureCnt = 0;
	
	Ray rabbitRay;
	// Update is called once per frame
	void Update () 
	{
		// rename creature tutorial
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 7)
		{
			if (oldTextCreature == creatureNameTF.Text)
			{
				Debug.Log("-> text : " + creatureNameTF.Text + " <=> " + renameCreatureCnt);
				renameCreatureCnt = 0;
			}
			else if (renameCreatureCnt == 0)
			{
				renameCreatureCnt++;
				popUpInfoScript.renameCreatureTutorial(5);
			}
		}
		
		Ray rabbitRay = cam.ScreenPointToRay(Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0))
		{
			//popUpInfoScript.scr_audioController.audio_buttonClick.Play();
			
			if (Physics.Raycast(rabbitRay, out rabbitHit))
			{
				if (rabbitHit.collider.gameObject.name == "Rabbit" || rabbitHit.collider.gameObject.name == "Harvest")
				{
					
					if(rabbitHit.collider.gameObject.name == "Rabbit")
					{
						PlayAudioforRabbitBtn();
					}
					currentRabbitButton = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
					currentHarvestButton = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				}
				else if (rabbitHit.collider.gameObject.name == "objFlip")
				{
					curFlipObj = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				}
				else if (rabbitHit.collider.gameObject.name == "objDelete")
				{
					curDelObj = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
					GameManager.curDelObj = curDelObj;
				}
				else if (rabbitHit.collider.gameObject.name == "objPlace")
				{
					////Debug.Log("name >> " + rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);
					curPlaceObj = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				}
				else if (rabbitHit.collider.gameObject.name == "Gold")
				{
					goldObj = rabbitHit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
				}
			}
		}
		
		// check pop up is open or not
		if (popUpType1.active == true || popUpType2.active == true || popUpType3.active == true || popUpType4.active == true ||
			storeUI.active == true || decorationUI.active == true || buildingUI.active == true || creatureUI.active == true ||
			trainingGroundUI.active == true || plantsUI.active == true || inventoryUI.active == true)
		{
			popUpOpenBool = true;
		}
		else
			popUpOpenBool = false;
		
	}
	
//====================================================================================================================================
	
	
	
	// MAIN MENU //
	
	// market menu
	void mainMenuMarket()
	{
		scr_audioController.audio_buttonClick.Play();
		
		// LEVEL 1 //
		if (GameManager.gameLevel == 1)
		{
			buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
			if (marketBP != null)
				Destroy(marketBP);
			
			popUpInfoScript.wall.active = true;
			storeHDUI.SetActiveRecursively(true);
			Destroy(delArrow);
			storeManagerInfo.storeMenuBool = true;
			
			// task 1
			if (GameManager.taskCount == 1)
			{
				buttonPulse storeTG_BP = GameObject.Find("storeHalflingButt").AddComponent("buttonPulse") as buttonPulse;
				storeTG_BP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
				storeTG_BP.minSpeed = 3;
				storeTG_BP.maxSpeed = 8;
				storeTG_BP.minVal = 0.001f;
				storeTG_BP.maxVal = 0.01f;
				storeTG_BP.scaleAnim = true;
				
				GameObject tgs = GameObject.Find("halflingSpwan");
				GameObject temp = Instantiate(arrow, new Vector3(tgs.transform.position.x , tgs.transform.position.y, tgs.transform.position.z + 12), Quaternion.Inverse(tgs.transform.rotation)) as GameObject;
				delArrow = temp;
			}
			
			if (GameManager.taskCount == 3)
			{
				buttonPulse storeTG_BP = GameObject.Find("storeHalflingButt").AddComponent("buttonPulse") as buttonPulse;
				storeTG_BP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
				storeTG_BP.minSpeed = 3;
				storeTG_BP.maxSpeed = 8;
				storeTG_BP.minVal = 0.001f;
				storeTG_BP.maxVal = 0.01f;
				storeTG_BP.scaleAnim = true;
				
				GameObject halflingSpwan = GameObject.Find("halflingSpwan") as GameObject;
				GameObject temp = Instantiate(arrow, new Vector3(halflingSpwan.transform.position.x, halflingSpwan.transform.position.y, halflingSpwan.transform.position.z + 12), Quaternion.Inverse(halflingSpwan.transform.rotation)) as GameObject;
				delArrow = temp;
			}
			
			if (GameManager.taskCount == 8)
			{
				buttonPulse storeTG_BP = GameObject.Find("storeHalflingButt").AddComponent("buttonPulse") as buttonPulse;
				storeTG_BP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
				storeTG_BP.minSpeed = 3;
				storeTG_BP.maxSpeed = 8;
				storeTG_BP.minVal = 0.001f;
				storeTG_BP.maxVal = 0.01f;
				storeTG_BP.scaleAnim = true;

				GameObject halflingSpwan = GameObject.Find("halflingSpwan") as GameObject;
				GameObject temp = Instantiate(arrow, new Vector3(halflingSpwan.transform.position.x, halflingSpwan.transform.position.y, halflingSpwan.transform.position.z + 12), Quaternion.Inverse(halflingSpwan.transform.rotation)) as GameObject;
				delArrow = temp;
			}
		}
		
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 2)
		{
			popUpInfoScript.wall.active = true;
			storeHDUI.SetActiveRecursively(true);
			//storeUI.SetActiveRecursively(true);
			Destroy(delArrow);
			storeManagerInfo.storeMenuBool = true;
			
			if (GameManager.taskCount == 10)
			{
				buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				if (marketBP != null)
					Destroy(marketBP);

				buttonPulse storeTG_BP = GameObject.Find("storeHalflingButt").AddComponent("buttonPulse") as buttonPulse;
				storeTG_BP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
				storeTG_BP.minSpeed = 3;
				storeTG_BP.maxSpeed = 8;
				storeTG_BP.minVal = 0.001f;
				storeTG_BP.maxVal = 0.01f;
				storeTG_BP.scaleAnim = true;

				GameObject halflingSpwan = GameObject.Find("halflingSpwan") as GameObject;
				GameObject temp = Instantiate(arrow, new Vector3(halflingSpwan.transform.position.x, halflingSpwan.transform.position.y, halflingSpwan.transform.position.z + 12), Quaternion.Inverse(halflingSpwan.transform.rotation)) as GameObject;
				delArrow = temp;
			}

			buttonPulse marketBPDestroy = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
			if (marketBPDestroy != null)
				Destroy(marketBPDestroy);
		}
		
		
		// LEVEL 3 //
		if (GameManager.gameLevel >= 3)
		{
			Destroy(delArrow);
			
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;
			
			popUpInfoScript.wall.active = true;
			storeHDUI.SetActiveRecursively(true);
			//storeUI.SetActiveRecursively(true);
		}
	}
	
//=========================================================================================================
	
	// friend menu
	void mainMenuFriends()
	{
		//Debug.Log("Friends...");
	}
	
//=========================================================================================================
	
	// quest menu
	void mainMenuQuest()
	{
		scr_audioController.audio_buttonClick.Play();
		
		GameObject buttonTaskObj = GameObject.Find("button_Task") as GameObject;
		if (buttonTaskObj != null)
		{
			Destroy(buttonTaskObj.GetComponent<buttonPulse>());
		}
		
		if (GameManager.gameLevel >= 2 && GameManager.taskCount >= 15)
		{
			GameObject delArrowObj = GameObject.Find("ArrowPF(Clone)") as GameObject;
			if (delArrowObj != null)
				Destroy(delArrowObj);
			
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;

			popUpInfoScript.wall.active = true;
			taskList.SetActiveRecursively(true);
			Halfbtn=true;
			td.halflingMissionButton();
			guiControl.popUpOpenBool = true;
			
			if (GameManager.taskCount == 15)
			{
				Debug.Log("quest tutorial part 01...");
				Destroy(GameObject.Find("gameArrowPF(Clone)"));
				GameObject gStory = GameObject.Find("FightingTutorial");
				
				gStory.GetComponent<AutoSpeak>().callToWriteText("These are your current activities in order to complete the Level. These activities will keep changing for every Level.");

				GameObject gObj = GameObject.Find("GameManager");
				gObj.GetComponent<QuestTutorial>().PlushArrow(2);
			}
		}
	}
	// END MAIN MENU //
	
	
//====================================================================================================================================
	
	
	// Halflling Darkling Menu
	
	// halfling
	void halflingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		// set camera to halfling side
		if (GameObject.Find("Main Camera").transform.position.x > -40f)
			GameObject.Find("Main Camera").transform.position = GameObject.Find("halflingHouse_cPos").transform.position;
		
		
		buttonPulse halflingButt_BP = GameObject.Find("storeHalflingButt").GetComponent("buttonPulse") as buttonPulse;
		if (halflingButt_BP != null)
			Destroy(halflingButt_BP);
		
		storeHDUI.SetActiveRecursively(false);
		storeUI.SetActiveRecursively(true);
		
		if (GameManager.taskCount == 1)
		{
			Destroy(delArrow);
			
			// training ground button effect and arrow
			buttonPulse storeTG_BP = GameObject.Find("storeTrainingGroundButt").AddComponent("buttonPulse") as buttonPulse;
			storeTG_BP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
			storeTG_BP.minSpeed = 3;
			storeTG_BP.maxSpeed = 8;
			storeTG_BP.minVal = 0.001f;
			storeTG_BP.maxVal = 0.01f;
			storeTG_BP.scaleAnim = true;
			
			GameObject tgs = GameObject.Find("trainingGroundSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(tgs.transform.position.x , tgs.transform.position.y, tgs.transform.position.z + 12), Quaternion.Inverse(tgs.transform.rotation)) as GameObject;
			delArrow = temp;	
		}
		
		if (GameManager.taskCount == 8)
		{
			Destroy(delArrow);

			buttonPulse dBP = GameObject.Find("storeDecorationButt").AddComponent("buttonPulse") as buttonPulse;
			dBP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
			dBP.minSpeed = 3;
			dBP.maxSpeed = 8;
			dBP.minVal = 0.001f;
			dBP.maxVal = 0.01f;
			dBP.scaleAnim = true;

			GameObject dpathS = GameObject.Find("decorationSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(dpathS.transform.position.x, dpathS.transform.position.y, dpathS.transform.position.z + 12), Quaternion.Inverse(dpathS.transform.rotation)) as GameObject;
			delArrow = temp;
		}
		
		if (GameManager.taskCount == 3)
		{
			Destroy(delArrow);
				
			buttonPulse buildingBP = GameObject.Find("storeBuildingButt").AddComponent("buttonPulse") as buttonPulse;
			buildingBP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
			buildingBP.minSpeed = 3;
			buildingBP.maxSpeed = 8;
			buildingBP.minVal = 0.001f;
			buildingBP.maxVal = 0.01f;
			buildingBP.scaleAnim = true;
			
			GameObject buildingSpwan = GameObject.Find("buildingSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(buildingSpwan.transform.position.x, buildingSpwan.transform.position.y, buildingSpwan.transform.position.z + 12), Quaternion.Inverse(buildingSpwan.transform.rotation)) as GameObject;
			delArrow = temp;
		}
		
		if (GameManager.taskCount == 5)
		{
			Destroy(delArrow);
				
			popUpInfoScript.wall.active = true;
			storeUI.SetActiveRecursively(true);
				
			buttonPulse buildingBP = GameObject.Find("storeBuildingButt").GetComponent("buttonPulse") as buttonPulse;
			buildingBP.scaleAnim = true;
				
			GameObject buildingSpwan = GameObject.Find("buildingSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(buildingSpwan.transform.position.x, buildingSpwan.transform.position.y, buildingSpwan.transform.position.z + 12), Quaternion.Inverse(buildingSpwan.transform.rotation)) as GameObject;
			delArrow = temp;
		}
		
		if (GameManager.taskCount == 9 && GameManager.popUpCount < 25 && GameManager.gameLevel < 3)
		{
			Destroy(delArrow);
				
			popUpInfoScript.wall.active = true;
			storeUI.SetActiveRecursively(true);
			
			buttonPulse buildingBP = GameObject.Find("storeBuildingButt").GetComponent("buttonPulse") as buttonPulse;
			buildingBP.scaleAnim = true;
			
			GameObject buildingSpwan = GameObject.Find("buildingSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(buildingSpwan.transform.position.x, buildingSpwan.transform.position.y, buildingSpwan.transform.position.z + 12), Quaternion.Inverse(buildingSpwan.transform.rotation)) as GameObject;
			delArrow = temp;
		}
		
		if (GameManager.taskCount == 10)
		{
			Destroy(delArrow);
			buttonPulse dBP = GameObject.Find("storeDefenceButt").AddComponent("buttonPulse") as buttonPulse;
			dBP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);
			dBP.minSpeed = 3;
			dBP.maxSpeed = 8;
			dBP.minVal = 0.001f;
			dBP.maxVal = 0.01f;
			dBP.scaleAnim = true;

			GameObject dpathS = GameObject.Find("defenceSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(dpathS.transform.position.x, dpathS.transform.position.y, dpathS.transform.position.z + 12), Quaternion.Inverse(dpathS.transform.rotation)) as GameObject;
			delArrow = temp;
		}
	}

//=========================================================================================================
	
	void halflingDarklingCancleButton()
	{
		GameObject arrowObj = GameObject.Find("ArrowPF(Clone)") as GameObject;
		if (arrowObj != null)
			Destroy(arrowObj);
		
		scr_audioController.audio_buttonClick.Play();
		
		buttonPulse halflingButt_BP = GameObject.Find("storeHalflingButt").GetComponent("buttonPulse") as buttonPulse;
		if (halflingButt_BP != null)
			Destroy(halflingButt_BP);
		
		storeHDUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = false;
		
		if ((GameManager.taskCount == 1 || GameManager.taskCount == 3 || GameManager.taskCount == 5 || GameManager.taskCount == 9 || 
		     GameManager.taskCount == 8 || GameManager.taskCount == 10) && (GameManager.popUpCount < 25 || GameManager.popUpCount == 79))
		{
			Destroy(delArrow);
			
			panelControl.panelMoveOut = true;
			panelControl.panelMoveIn = false;
		
			// market button effect
			buttonPulse marketBP = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
			marketBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
			marketBP.minSpeed = 3;
			marketBP.maxSpeed = 8;
			marketBP.minVal = 0.05f;
			marketBP.maxVal = 0.2f;
			marketBP.scaleAnim = true;
			
			// arrow on market button
			GameObject ms = GameObject.Find("marketSpwan");
			GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			delArrow = temp;
		}
	}
	
	
	
//====================================================================================================================================
	
	
	// HUD //
	
	// Item Bag
	void itemBagButton()
	{
		scr_audioController.audio_buttonClick.Play();
		//popUpInfoScript.destroyPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
		if (popUpType1.active == false && popUpType2.active == false && popUpType3.active == false && popUpType5.active == false && FeedMorphPopUp.active == false && !GameManager.placeObjectBool)
		{
			GameObject go = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			GameObject rabbitButton= null;
			if(go != null){
		      rabbitButton = go.transform.FindChild("RabbtiButton").gameObject;
	    	}
	   		// LEVEL 2
			if (GameManager.gameLevel == 2  && GameManager.taskCount == 11 && rabbitButton.active == false && GameManager.curCave != null)
			{
				// find arrow and destroy
				GameObject arrowTemp = GameObject.Find("ArrowPF(Clone)") as GameObject;
				if (arrowTemp != null)
					Destroy(arrowTemp);
				
				GameObject panelAttack = GameObject.Find("panel_Attack") as GameObject;
				
				objPanelControl attackPanelInfo = panelAttack.GetComponent("objPanelControl") as objPanelControl;
				
				attackPanelInfo.panelMoveIn = true;
				attackPanelInfo.panelMoveOut = false;
				
				popUpInfoScript.wall.active = true;
				inventoryUI.SetActiveRecursively(true);
				
				GameObject invCreatureBut = GameObject.Find("inventoryCreatureButt") as GameObject;

				//added
				buttonPulse iCreatureButtBP = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
				iCreatureButtBP.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
				iCreatureButtBP.minSpeed = 3;
				iCreatureButtBP.maxSpeed = 8;
				iCreatureButtBP.minVal = 0.05f;
				iCreatureButtBP.maxVal = 0.2f;
				iCreatureButtBP.scaleAnim = true;

				GameObject iCreatureSpwan = GameObject.Find("iCreatureSpwan");
				GameObject temp = Instantiate(arrow, new Vector3(iCreatureSpwan.transform.position.x, iCreatureSpwan.transform.position.y, iCreatureSpwan.transform.position.z + 12), Quaternion.Inverse(iCreatureSpwan.transform.rotation)) as GameObject;
				delArrow = temp;
			}
			
			if (GameManager.gameLevel >= 3 && !popUpOpenBool)
			{
				panelControl.panelMoveIn = true;
				panelControl.panelMoveOut = false;
				
				popUpInfoScript.wall.active = true;
				inventoryUI.SetActiveRecursively(true);
				scr_remote.SendRequestforGetHerbs();
			}
		}
	}
	
	// END HUD //
	
	
//====================================================================================================================================
	
	
	// POP UP //
	
	// pop up OK Button
	/*void popUpOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		nextPopUpBool = true;
		nextTaskBool = true;
		
		// END LEVEL 1 //
		
		/////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 2)
		{
			// pop up 6
			if (GameManager.popUpType1_Count == 6 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = false;
				
				popUpType1.SetActiveRecursively(false);
				
				popUpType1.SetActiveRecursively(true);
			}
			
			// pop up 7
			if (GameManager.popUpType1_Count == 7 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = false;
				
				// find golin home
				GameObject gCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
				
				// create arrow on goblin house
				GameObject gArrow = Instantiate(gameArrow, new Vector3(gCamp.transform.position.x, gCamp.transform.position.y, gCamp.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
				GameManager.readyAttact = true;
				
				popUpType1.SetActiveRecursively(false);
			}
			
			// pop up 8
			if (GameManager.popUpType1_Count == 8 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = true;
				
				popUpType3.SetActiveRecursively(false);
			}
			
			// pop up 9
			if (GameManager.popUpType1_Count == 9 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = false;
				
				popUpType1.SetActiveRecursively(false);
				
				popUpType1.SetActiveRecursively(true);
			}
			
			// pop up 10
			if (GameManager.popUpType1_Count == 10 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = true;
				
				popUpType1.SetActiveRecursively(false);
			}
			
			// pop up 11
			if (GameManager.popUpType1_Count == 11 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = true;
				
				popUpType1.SetActiveRecursively(false);
				
			}
			
			// pop up 13
			if (GameManager.popUpType1_Count == 13 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				GameManager.taskCount++;
				popUpInfoScript.updateTaskCount();
				
				nextPopUpBool = false;
				nextTaskBool = true;
				
				popUpType1.SetActiveRecursively(false);
			}
			
			// pop up 14
			if (GameManager.popUpType1_Count == 14 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				nextPopUpBool = false;
				nextTaskBool = false;
			}

			// pop up 16
			if (GameManager.popUpType1_Count == 16 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				nextPopUpBool = false;
				nextTaskBool = false;
				
				popUpType1.SetActiveRecursively(false);
			}
			
			
			// pop up 18
			if (GameManager.popUpType1_Count == 18 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = false;
				
				popUpType1.SetActiveRecursively(false);
				
				popUpType1.SetActiveRecursively(true);
			}
			
			// pop up 19
			if (GameManager.popUpType1_Count == 19 && nextPopUpBool)
			{
				GameManager.popUpType1_Count++;
				
				nextPopUpBool = false;
				nextTaskBool = false;
				
				popUpType1.SetActiveRecursively(false);
				
				popUpType1.SetActiveRecursively(true);
			}
		}
		// END LEVEL 2 //
		
		/////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////
		
		// LEVEL 3 //
		
		// pop up 21
		if (GameManager.popUpType1_Count == 21 && nextPopUpBool)
		{
			GameManager.popUpType1_Count++;
			
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			popUpType1.SetActiveRecursively(true);
		}
		
		// pop up 22
		if (GameManager.popUpType1_Count == 22 && nextPopUpBool)
		{
			GameManager.popUpType1_Count++;
			
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType1.SetActiveRecursively(true);
		}
		
		
		
		// pop up 24
		if (GameManager.popUpType1_Count == 24 && nextPopUpBool)
		{
			GameManager.popUpType1_Count++;
			
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			popUpType1.SetActiveRecursively(true);
		}
		
		// pop up 27
		if (GameManager.popUpType1_Count == 27 && nextPopUpBool)
		{
			GameManager.popUpType1_Count++;
			
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			// create plant training ground pop up
			popUpType1.SetActiveRecursively(true);
		}
		
		// pop up 28
		if (GameManager.popUpType1_Count == 28 && nextPopUpBool)
		{
			GameManager.popUpType1_Count++;
			
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
						
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
		}
		
		// pop up 30
		if (GameManager.popUpType1_Count == 30 && nextPopUpBool)
		{
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType3.SetActiveRecursively(false);
			
		}
		
		// pop up 31
		if (GameManager.popUpType1_Count == 31 && nextPopUpBool)
		{
			nextPopUpBool = false;
			nextTaskBool = false;
			
			popUpType3.SetActiveRecursively(false);	
			
			GameObject creatureTemp = GameObject.Find("HC_C_Sprout_GO(Clone)");
			(creatureTemp.GetComponent("progressBar") as progressBar).enabled = true;
			Transform del_ProgressBar = GameObject.Find("HC_C_Sprout_GO(Clone)").transform.FindChild("ProgressBar");
			Destroy(del_ProgressBar.gameObject);
			
			creatureTemp.renderer.material.color = new Color(creatureTemp.renderer.material.color.r,
																creatureTemp.renderer.material.color.g,
																creatureTemp.renderer.material.color.b, 1);
			
			creatureTemp.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		}
		
		// pop up 32
		if (GameManager.popUpType1_Count == 32 && nextPopUpBool)
		{
			nextPopUpBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
		}
		
		// pop up 33
		if ((GameManager.popUpType1_Count == 33 || GameManager.popUpType1_Count == 34) && nextPopUpBool)
		{
			nextPopUpBool = false;
			
			popUpType1.SetActiveRecursively(false);
			
			GameObject go = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			
			// create rabbit button
			GameObject harvestButton_Inst = Instantiate(harvestButt, new Vector3(go.transform.position.x, go.transform.position.y + 8, go.transform.position.z + 4.5f), Quaternion.identity) as GameObject;
		
			// activate rabbit button pulse effect
			buttonPulse harvestButton_BP = GameObject.Find("HarvestButton(Clone)").GetComponent("buttonPulse") as buttonPulse;
			harvestButton_BP.scaleAnim = true;
		
			// attach guiControl script to rabbit ui button
			Transform harvest = harvestButton_BP.gameObject.transform.FindChild("Harvest") as Transform;
		
			UIButton delObjUIButtonInfo = harvest.gameObject.GetComponent("UIButton") as UIButton;
			guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
		}
		
		// pop up 35
		if (GameManager.popUpType1_Count == 35 && nextPopUpBool)
		{
			nextPopUpBool = false;
			popUpType1.SetActiveRecursively(false);
		}
		
		
		// END LEVEL 3 //
		
		/////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////
		
	}*/

	//=========================================================================================================
	
	// pop up Cancle button
	void popUpCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameManager.upgradePlotBool = false;
		popUpInfoScript.wall.active = false;
		
		GameManager.readyToUnlockDarklingBool = false;
		GameManager.upgradePlotRabbitBool = false;
		
		// pop up 4
		if (GameManager.popUpCount == 4)
		{
			Debug.Log("---> GameManager.popUpCount == 4");
			GameManager.popUpCount++;
			popUpInfoScript.updatePopUpCount();
			
			popUpInfoScript.destroyPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
		}
		// pop up 8 turnip rabbit button cancle  //goblin cave speed cancel
		if (GameManager.popUpCount == 8)
		{
			Debug.Log(" ---> GameManager.popUpCount == 8");
			popUpInfoScript.curPopUpCnt = 7;
			popUpInfoScript.updateCurPopUpCount();
			
//			popUpInfoScript.curPopUpType = 2;
//			popUpInfoScript.destroyPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
//			
//			Destroy(GameObject.Find("RabbtiButton(Clone)"));
			
//			GameManager.popUpCount++;
//			popUpInfoScript.updatePopUpCount();
		}
		
		if (GameManager.taskCount == 2)
		{
			GameManager.popUpCount = 4;
			popUpInfoScript.updatePopUpCount();
			popUpInfoScript.curPopUpCnt = 3;
			popUpInfoScript.updateCurPopUpCount();
			
			popUpType3.SetActiveRecursively(false);
		
			return;
		}
		
		// task 6
		if (GameManager.taskCount == 6)
		{
			popUpType3.SetActiveRecursively(false);
			Destroy(GameObject.Find("RabbitButton(Clone)"));
		}
		
		// pop up 12
		if (GameManager.popUpType1_Count == 12)
		{
			GameObject go = GameObject.Find("RabbtiButton(Clone)") as GameObject;
			Destroy(go);
			GameManager.popUpType1_Count++;
		}
		
		if (GameManager.taskCount == 9 && GameManager.gameLevel == 2)
		{
			popUpType3.SetActiveRecursively(false);
			
			GameObject go = GameObject.Find("RabbtiButton(Clone)") as GameObject;
			Destroy(go);
		}
		
		
		// pop up 31 Quest 2 cancle
		if (GameManager.popUpCount == 31 && popUpInfoScript.curPopUpCnt == 31)
		{
			Destroy(delArrow);
			popUpInfoScript.destroyPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			popUpInfoScript.curPopUpCnt--;
		}
		
		if (GameManager.gameLevel >= 3)
		{
			GameManager.burrySparkBool = false;
			GameManager.upgradeTrainingGroundBool = false;
			popUpInfoScript.destroyPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
		}
		
		// false all the upgrade task
		if (GameManager.gameLevel >= 3)
		{
			GameManager.upgradeEarthObelisk = false;
		}
		
		popUpType3.SetActiveRecursively(false);
	}
	
//=========================================================================================================	

	void levelCompleteOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		levelCompletePopup.SetActiveRecursively(false);
		clearCavePopup.SetActiveRecursively(true);
	}
	
	
//=========================================================================================================	
	
	// invest ok
	void investOkButton()
	{		
		scr_audioController.audio_buttonClick.Play();
		(creatureTemp.GetComponent("progressBar") as progressBar).enabled = true;
		
		Transform del = creatureTemp.transform.FindChild("ProgressBar");
		Destroy(del.gameObject);
		
		// change sparks score
		sparkScoreInfo.Text = (GameManager.sparks - 1).ToString();
		
		// goto market menu
		panelControl.panelMoveOut = true;
		panelControl.panelMoveIn = false;
		// arrow button create and place
		buttonPulse bp = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
		bp.scaleAnim = true;
		GameObject ms = GameObject.Find("marketSpwan");
		GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
		delArrow = temp;
	}
	
//=========================================================================================================	
	
	void clearCaveInvestOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject go = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
		
		Transform pBar = go.transform.FindChild("ProgressBar") as Transform;
		Destroy(go);
		
		curAttackingCreature.SetActiveRecursively(true);
		
		clearCaveInvestPopup.SetActiveRecursively(false);
		
		clearCaveSuccessPopup.SetActiveRecursively(true);
	}
	
//=========================================================================================================	
	
	// invest cancle
	void investCancelButton()
	{
		
	}
	
//=========================================================================================================	
	
	void clearCaveSuccessOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		clearCaveSuccessPopup.SetActiveRecursively(false);
		farmPopup.SetActiveRecursively(true);
	}
	
//=========================================================================================================	
	
	void farmPopupOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		farmPopup.SetActiveRecursively(false);
		
		panelControl.panelMoveOut = true;
		panelControl.panelMoveIn = false;
		
		buttonPulse fBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
		fBP.scaleAnim = true;
		GameObject ms = GameObject.Find("marketSpwan");
		GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
		delArrow = temp;
		
		farmBool = true;
	}
	
//=========================================================================================================	
	
	private int indexLevel3 = 0;
	void rabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject rButton = GameObject.Find("RabbtiButton(Clone)") as GameObject;
		Destroy(rButton);
		
		Debug.Log("taskCount : "+GameManager.taskCount);
		// task 2 rabbit button
		if (GameManager.taskCount == 2)
		{
			GameObject go = GameObject.Find("RabbitButton(Clone)") as GameObject;
			Destroy(go);
			
			// pop up generate
			popUpInfoScript.curPopUpCnt = 4;
			popUpInfoScript.updateCurPopUpCount();
			
			popUpInfoScript.curPopUpType = 2;
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().HideUncleSam();
		}
		
		// LEVEL 2 //
		if (GameManager.gameLevel >= 1)		//Added
		{
			// task 6 turnip rabbit button
			if (GameManager.taskCount == 4)
			{
				GameObject go = GameObject.Find("RabbitButton(Clone)") as GameObject;
				Destroy(go);
				
				popUpInfoScript.curPopUpCnt = 8;//12;
				popUpInfoScript.updateCurPopUpCount();			
				
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().HideUncleSam();
			}
			
			// task 9
			if (GameManager.taskCount == 9)
			{
				Debug.Log("ddddd");
				GameObject go = GameObject.Find("RabbitButton(Clone)") as GameObject;
				Destroy(go);
				
				popUpInfoScript.curPopUpCnt = 17;
				popUpInfoScript.updateCurPopUpCount();
				
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				if(GameManager.gameLevel == 2)							//Added
				{
					GameObject go1 = GameObject.Find("RabbitButton(Clone)") as GameObject;
					Destroy(go1);
					
					popUpInfoScript.curPopUpCnt = 8;//12;
					popUpInfoScript.updateCurPopUpCount();			
					
					popUpInfoScript.curPopUpType = 2;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);	
				}														//Added
			}
		}
		
		if (GameManager.taskCount == 10)
		{
			GameObject go = GameObject.Find("RabbitButton(Clone)") as GameObject;
			Destroy(go);
			
			popUpType3.SetActiveRecursively(true);
			popUpType3_spText.Text = "Creature will generate in 10 min. in order \nto speed the growth invest one spark. \nInvest one spark now??";			
		}
		
		if (GameManager.taskCount == 12)
		{
			Debug.Log("goblin camp 01 remove rabbit button...");
			
			GameManager.popUpCount = 19;
			popUpInfoScript.updatePopUpCount();
				
			popUpInfoScript.curPopUpCnt = 19;
			popUpInfoScript.updateCurPopUpCount();
				
			popUpInfoScript.curPopUpType = 2;
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
		}
		
		// LEVEL 3 //
		if (GameManager.gameLevel >= 3)
		{
			if(indexLevel3 == 0)
			{
				GameObject go = GameObject.Find("RabbitButton(Clone)") as GameObject;
				Destroy(go);
			
				popUpType3.SetActiveRecursively(true);
				popUpType3_spText.Text = "Creature will generate in 10 min. in order \nto speed the growth invest one spark. \nInvest one spark now??";			
				indexLevel3++;
				GameManager.popUpType1_Count = 31;
			}
		}
		
		
	}

//=========================================================================================================	
	
	// Harvest button
	void harvestButton()
	{
		Debug.Log(" cur food --> " + GameManager.food);
		GameManager.oldFood = GameManager.food;

		scr_audioController.audio_buttonClick.Play();
		Debug.Log("Level : "+GameManager.gameLevel);
		Debug.Log("Task count : "+GameManager.taskCount);
		// LEVEL 2 //
		if (GameManager.gameLevel == 1)
		{
			// task 7
			if (GameManager.taskCount == 5)
			{
				popUpInfoScript.task7(2);
			}
		}
		
		// LEVEL 3 //
		if (GameManager.gameLevel >= 3)
		{
			GameObject go = GameObject.Find("HarvestButton(Clone)") as GameObject;
			Destroy(go);
			
			GameObject turnipPlant = GameObject.Find("HC_P_Turnip_GO(Clone)") as GameObject;
			
			if (turnipPlant != null)
				Destroy(turnipPlant);
			
			GameObject pipeWeedPlant = GameObject.Find("HC_P_PipeWeed_GO(Clone)") as GameObject;
			
			if (pipeWeedPlant != null)
				Destroy(pipeWeedPlant);
			
			GameObject.Find("HC_B_Plot_GO(Clone)").transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			
			// score update
			popUpInfoScript.UpdateScore();
			// gui score update
			goldCoinScoreInfo.Text = GameManager.coins.ToString();
		}
	}
	
//=========================================================================================================	
	
	void plotCompletePopUpOkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		plotCompletePopup.SetActiveRecursively(false);
		
		GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			
		GameObject gArrow = Instantiate(gameArrow, new Vector3(plotGO.transform.position.x, plotGO.transform.position.y + 0.2f, plotGO.transform.position.z + 5), Quaternion.Euler(270, 0, 0)) as GameObject;
		
		GameManager.readyFarm = true;
	}
	
//====================================================================================================================================
	
	
	// STORE MENU //
	
	// decoration 
	void storeDecorationButton()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 1 //
		// task 3
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 8)
			{
				buttonPulse decorationBP = GameObject.Find("storeDecorationButt").GetComponent("buttonPulse") as buttonPulse;
				decorationBP.scaleAnim = false;
								
				storeUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				decorationUI.SetActiveRecursively(true);
				
				if (delArrow != null)
					Destroy(delArrow);
				
				if (delArrow != null)
					Destroy(delArrow);
				
				GameObject ms = GameObject.Find("decoration01_Spwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, Quaternion.Inverse(ms.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = ms.transform;
			}
		}
		
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 3)
		{
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			decorationUI.SetActiveRecursively(true);
		}
	}

//=========================================================================================================	
	
	// building
	void storeBuildingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 2 //
		if (GameManager.gameLevel >= 1 && GameManager.taskCount != 8 && GameManager.taskCount > 2)
		{
			Debug.Log("storeBuildingButton : "+GameManager.taskCount);
			buttonPulse buildingBP = GameObject.Find("storeBuildingButt").GetComponent("buttonPulse") as buttonPulse;
			if (buildingBP != null)
				Destroy(buildingBP);
		
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			buildingUI.SetActiveRecursively(true);
			
			if (delArrow != null)
				Destroy(delArrow);
			
			// task 5
			if (GameManager.taskCount == 3 && GameManager.gameLevel == 1)
			{
				GameObject handObj = GameObject.Find("ArrowPF(Clone)") as GameObject;
				if (handObj != null)
				Destroy(handObj);
				
				GameObject building01_Spwan = GameObject.Find("building01_Spwan");
				GameObject temp = Instantiate(arrow, building01_Spwan.transform.position, Quaternion.Inverse(building01_Spwan.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = building01_Spwan.transform;
				
			}
			
			// task 9
			if (GameManager.taskCount == 9)
			{
				GameObject handObj = GameObject.Find("ArrowPF(Clone)") as GameObject;
				if (handObj != null)
				Destroy(handObj);
				
				GameObject bScroll = GameObject.Find("buildingScroll") as GameObject;
				bScroll.transform.localPosition = new Vector3(3, bScroll.transform.localPosition.y, bScroll.transform.localPosition.z);
				
				GameObject building02_Spwan = GameObject.Find("building02_Spwan");
				GameObject temp = Instantiate(arrow, building02_Spwan.transform.position, Quaternion.Inverse(building02_Spwan.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = building02_Spwan.transform;

				panelControl.panelMoveIn = true;
				panelControl.panelMoveOut = false;
			}
		}
		
		// LEVEL 3 and greater
		if (GameManager.gameLevel >= 3)
		{
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			buildingUI.SetActiveRecursively(true);
		}

		Debug.Log(" --------> " + GameManager.unlockDarklingBool);
		if (GameManager.unlockDarklingBool == false)
		{
			buildingUI.transform.FindChild("buildingScroll").gameObject.transform.FindChild("03_Bridge").gameObject.transform.FindChild("block").gameObject.SetActive(false);
		}
	}
	
//=========================================================================================================	
	
	// creature
	void storeCreatureButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 3)
		{
			buttonPulse creatureBP = GameObject.Find("storeCreatureButt").GetComponent("buttonPulse") as buttonPulse;

			if (creatureBP != null)
				creatureBP.scaleAnim = false;
		
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			creatureUI.SetActiveRecursively(true);
		
			if (delArrow != null)
				Destroy(delArrow);
		}
	}
	
//=========================================================================================================
	
	// training ground 
	void storeTrainingGroundButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 1)
			{
				
				buttonPulse trainingGroundBP = GameObject.Find("storeTrainingGroundButt").GetComponent("buttonPulse") as buttonPulse;
				if (trainingGroundBP != null)
					Destroy(trainingGroundBP);
				
				storeUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				trainingGroundUI.SetActiveRecursively(true);
				
				if (delArrow != null)
					Destroy(delArrow);
				
				GameObject ms = GameObject.Find("trainingGrnd01_Spwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, Quaternion.Inverse(ms.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = ms.transform;
			}
		}
		
		if (GameManager.gameLevel >= 3)
		{
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			trainingGroundUI.SetActiveRecursively(true);
			
			if (delArrow != null)
				Destroy(delArrow);
		}

		// check training ground is already present
		GameObject hEarthTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
		GameObject hPlantTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
		GameObject hWaterTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;

		if (hEarthTG == null)
			hEarthTG_block.SetActive(false);
		else
			hEarthTG_block.SetActive(true);

		if (hPlantTG == null)
			hPlantTG_block.SetActive(false);
		else
			hPlantTG_block.SetActive(true);

		if (hWaterTG == null)
		{
			Debug.Log("water lock yes...");
			hWaterTG_block.SetActive(false);
		}
		else
		{
			Debug.Log("water lock no... " + hWaterTG.name);
			hWaterTG_block.SetActive(true);
		}

		if (dSwampTG_block == null)
			dSwampTG_block.SetActive(false);
		else
			dSwampTG_block.SetActive(true);

		if (dEarthTG_block == null)
			dEarthTG_block.SetActive(false);
		else
			dEarthTG_block.SetActive(true);

		if (dFireTG_block == null)
			dFireTG_block.SetActive(false);
		else
			dFireTG_block.SetActive(true);

	}
	
//=========================================================================================================
	
	// defence
	void storeDefenceButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel == 2)
		{
			if (GameManager.taskCount == 10)
			{
				storeUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				defenceUI.SetActiveRecursively(true);
				
				if (delArrow != null)
					Destroy(delArrow);
				
				GameObject ms = GameObject.Find("earthDefence_Spwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, Quaternion.Inverse(ms.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = ms.transform;

				Transform defenceButtonObj = storeUI.transform.FindChild("storeDefenceButt") as Transform;
				if (defenceButtonObj != null)
					Destroy(defenceButtonObj.GetComponent<buttonPulse>());
			}
		}
		
		if (GameManager.gameLevel >= 3)
		{
			if (delArrow != null)
				Destroy(delArrow);
			
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			defenceUI.SetActiveRecursively(true);
		}
			
	}
	
//=========================================================================================================
	
	// plants
	void storePlantsButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 3)
		{
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			defenceUI.SetActiveRecursively(true);
		
			if (delArrow != null)
				Destroy(delArrow);
		
			if (tutorialCnt == 2)
			{
				GameObject ms = GameObject.Find("plant01_Spwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, Quaternion.Inverse(ms.transform.rotation)) as GameObject;
				delArrow = temp;
				temp.transform.parent = ms.transform;
			}
		}
	}
	
//=========================================================================================================
	
	// treasure
	void storeTreasureButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >=3)
		{
			storeUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			treasureUI.SetActiveRecursively(true);
		
			if (delArrow != null)
				Destroy(delArrow);
		}
	}
	
	void DarklingstoreTreasureButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >=3)
		{
			darklingStoreUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			treasureUI.SetActiveRecursively(true);
		
			if (delArrow != null)
				Destroy(delArrow);
		}
	}
//=========================================================================================================
	
	private int index = 0;
	// store cancle
	void storeCancleButton()
	{
		buttonPulse tgBP = GameObject.Find("storeTrainingGroundButt").GetComponent("buttonPulse") as buttonPulse;
		if (tgBP != null)
			Destroy(tgBP);
		
		buttonPulse bldgBP = GameObject.Find("storeBuildingButt").GetComponent("buttonPulse") as buttonPulse;
		if (bldgBP != null)
			Destroy(bldgBP);
		
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		
		GameObject arrowObj = GameObject.Find("ArrowPF(Clone)") as GameObject;
		if (arrowObj != null)
			Destroy(arrowObj);
				
		if (delArrow != null)
			Destroy(delArrow);
		
		if (GameManager.taskCount == 1 || GameManager.taskCount == 3 || GameManager.taskCount == 8 || GameManager.taskCount == 10)
		{
			panelControl.panelMoveIn = false;
			panelControl.panelMoveOut = true;
			
			GameObject ms = GameObject.Find("marketSpwan");
			GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
			delArrow = temp; 
			
			// market button pulse animation on
			buttonPulse bp = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
			bp.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
			bp.minSpeed = 3;
			bp.maxSpeed = 8;
			bp.minVal = 0.05f;
			bp.maxVal = 0.2f;
			bp.scaleAnim = true;
		}
	}
	
//=========================================================================================================
	
	// store home
	void storeHomeButton()
	{
		
	}
	
	// END STORE MENU //
	
//====================================================================================================================================
	
	
	
	// INVENTORY MENU //
	
	// inventory creature
	void inventoryCreatureButton()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 2
		if (GameManager.gameLevel == 2)
		{
			// task 4
			if (GameManager.taskCount == 11)
			{
				GameObject invCB = GameObject.Find("inventoryCreatureButt") as GameObject;

				if (delArrow != null)
					Destroy(delArrow);
				
				inventoryUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				inventoryItemsInfo.inventoryCreature();
				
				// creature button arrow and button effect
				GameObject creatureButtSpwan = GameObject.Find("invHoundSpwan") as GameObject;
				GameObject creatureArrow = Instantiate(arrow, new Vector3(-72.87f, 14f, 103.944f), Quaternion.Euler(270, 180,0)) as GameObject;
				delArrow = creatureArrow;
			}
		}
		
		if(GameManager.gameLevel >= 3)
		{
			inventoryItemsInfo.inventoryCreature();
		}
	}
	
//=========================================================================================================
	
	// inventory plats
	void inventoryPlantButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject plantBut = GameObject.Find("inventoryPlantButt") as GameObject;
		if (plantBut != null)
		{
			buttonPulse plantsBP = plantBut.GetComponent("buttonPulse") as buttonPulse;
			plantsBP.scaleAnim = false;
		}
		// LEVEL 2
		if (GameManager.taskCount == 4)
		{
			popUpInfoScript.task6(3);
			
		}
		
		// LEVEL 3 //
		if (GameManager.gameLevel >= 3)
		{	
			popUpInfoScript.wall.active = true;
						
			GameObject curArrow = GameObject.Find("ArrowPF(Clone)");
			
			if (curArrow != null)
				Destroy(curArrow);

			if (delArrow != null)
				Destroy(delArrow);
			
			inventoryItemsInfo.inventoryPlantButtons();
			inventoryUI.SetActiveRecursively(false);
		}
	}
	
//=========================================================================================================
	
	void inventoryRewardButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject potionBut = GameObject.Find("inventoryRewardButt") as GameObject;

		if (GameManager.gameLevel >= 3)
		{	
			popUpInfoScript.wall.active = true;
						
			GameObject curArrow = GameObject.Find("ArrowPF(Clone)");
			
			if (curArrow != null)
				Destroy(curArrow);

			if (delArrow != null)
				Destroy(delArrow);
			
			inventoryItemsInfo.inventoryRewardButtons();
			inventoryUI.SetActiveRecursively(false);
		}
	}
	void inventoryPotionsButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject potionBut = GameObject.Find("inventoryPotionButt") as GameObject;

		if (GameManager.gameLevel >= 3)
		{	
			popUpInfoScript.wall.active = true;
						
			GameObject curArrow = GameObject.Find("ArrowPF(Clone)");
			
			if (curArrow != null)
				Destroy(curArrow);

			if (delArrow != null)
				Destroy(delArrow);
			
			inventoryItemsInfo.inventoryPotionsButtons();
			inventoryUI.SetActiveRecursively(false);
		}
	}
	
//=========================================================================================================	
	
	// inventory cancle
	void inventoryCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 2 
		if (GameManager.gameLevel == 1)
		{
			// task 4 turnip farming
			if (GameManager.taskCount == 4)
			{
				popUpInfoScript.task6(4);
			}
			
			// task 9
			if (GameManager.taskCount == 9)
			{
				popUpInfoScript.wall.active = false;
				inventoryUI.SetActiveRecursively(false);
			}
		}
		
		// LEVEL 3
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.wall.active = false;
			inventoryUI.SetActiveRecursively(false);
			GameObject plotGO = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			plotGO.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		}
	}
	
//=========================================================================================================
	
	// inventory home
	void inventoryHomeButton()
	{
		if (GameManager.gameLevel >= 3)
		{
			GameManager.bridgeBuildBool = false;

			scr_audioController.audio_buttonClick.Play();
			scr_remote.sfs.Send(new LogoutRequest());
			scr_remote.sfs.RemoveAllEventListeners();
		
			if(scr_remote.isalreadyloggedin) 
			{
				PlayerPrefs.SetString("isalreadyloggedIn","false");
			}
		
			Debug.Log("is already logged in :" + PlayerPrefs.GetString("isalreadyloggedIn"));
			Debug.Log("logged :" + scr_remote.isalreadyloggedin);
			Application.LoadLevel("MainMenu");
		}
	}
	
	// END INVENTORY MENU //

//====================================================================================================================================

	// DECORATION MENU //
	
	// plate 01 -- dirth path
	void decorationPlate01Button()
	{
		if (GameManager.gameLevel == 1)
		{
			//createDirtPath();
			panelControl.panelMoveIn = true;
			panelControl.panelMoveOut = false;
			
			GameObject go = Instantiate(dirtPath, new Vector3(/*-62.56f, 0.02f, 1.36f*/ -64.24f, 0.2f, 1.46f), dirtPath.transform.rotation) as GameObject;
			curObj = go;
			GameManager.firstDirtPathPos = go.transform.position;
			GameObject dirt = GameObject.Find("HWCharacter(Clone)");
			GameObject.Find("Main Camera").transform.position = new Vector3(-75f, 40f, -3f);
			halfwayone = curObj.transform.FindChild("waypoint1") ;
			if (halfwayone != null)
				halfwayone.gameObject.active = false;
			
			Transform tempObjUI = curObj.transform.FindChild("UI");
			Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
			Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
			Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
			Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
			
			go.transform.FindChild("redPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
			guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
			delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton flipButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
			flipButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
			placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
			tempObjDelete.gameObject.active = false;
			
			tempObjFlip.gameObject.active = false;
					
			popUpInfoScript.wall.active = false;
			storeUI.SetActiveRecursively(false);
			decorationUI.SetActiveRecursively(false);
			
			grid.placeButtonBool = true;
			grid.curObj = go;
					
			if (delArrow != null)
				Destroy(delArrow);
		}
		
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 3)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDirtPath.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dirtPathCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDirtPath();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 02 decoration Fruit Tree
	void decorationPlate02Button()
	{
		if (GameManager.gameLevel >= 3)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objFruitTree1.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.fruitTreeCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createFruitTree();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 03 decoration Lantern
	void decorationPlate03Button()
	{
		if (GameManager.gameLevel >= 6)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objLamp.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.lanternCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createLantern();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 04 decoration WheelBurrow
	void decorationPlate04Button()
	{
		if (GameManager.gameLevel >= 7)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWheelbarrow.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.wheelBurrowCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createWheelBurrow();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 05 decoration Shroomrey
	void decorationPlate05Button()
	{
		if (GameManager.gameLevel >= 8)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objShroomery.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.shroomreyCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createShroomrey();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 06 decoration Barell
	void decorationPlate06Button()
	{
		if (GameManager.gameLevel >= 4)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objBarrel.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.barelCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createBarell();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 07 decoration Tree
	void decorationPlate07Button()
	{
		if (GameManager.gameLevel >= 3)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objTree1.objTypeId))
			{
				//GameManager.objectCost = scrObjectCost.treeCost.GetComponent<SpriteText>().Text;
				//GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
				//                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createTree();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 08 decoration Well
	void decorationPlate08Button()
	{
		if (GameManager.gameLevel >= 3)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWell.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.wellCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createWell();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 09 decoration Woodpile
	void decorationPlate09Button()
	{
		if (GameManager.gameLevel >= 3)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWoodpile.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.woodpileCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createWoodpile();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 10 decoration Cornfield
	void decorationPlate10Button()
	{
		if (GameManager.gameLevel >= 13)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objCornfield.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.cornfield.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createCornfield();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 11 decoration Cottage
	void decorationPlate11Button()
	{
		if (GameManager.gameLevel >= 12)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objCottage.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createCottage();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 12 decoration HalflingKnoll
	void decorationPlate12Button()
	{
		if (GameManager.gameLevel >= 10)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objKnollhill.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createHalflingKnoll();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 13 decoration Party Tent
	void decorationPlate13Button()
	{
		if (GameManager.gameLevel >= 9)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPartytent.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createPartyTent();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 14 decoration Scarecrow
	void decorationPlate14Button()
	{
		if (GameManager.gameLevel >= 8)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objScarescrow.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createScarecrow();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 15 decoration StoneFence
	void decorationPlate15Button()
	{
		if (GameManager.gameLevel >= 11)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objFence.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createStoneFence();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// 16 decoration WindMill
	void decorationPlate16Button()
	{
		if (GameManager.gameLevel >= 14)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWindmill.objTypeId))
			{
				GameManager.panelAccessBool = false;
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createWindMill();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// cancle
	void decorationCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		//Debug.Log("decoration cancle button...");
		decorationUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);
		
		if (GameManager.taskCount == 8)
		{
			Destroy(delArrow);
			buttonPulse bp2 = GameObject.Find("storeTrainingGroundButt").GetComponent("buttonPulse") as buttonPulse;
			bp2.scaleAnim = false;
				
			buttonPulse decorBP = GameObject.Find("storeDecorationButt").GetComponent("buttonPulse") as buttonPulse;
			decorBP.scaleAnim = true;
			GameObject ps = GameObject.Find("decorationSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(ps.transform.position.x , ps.transform.position.y, ps.transform.position.z + 12), Quaternion.Inverse(ps.transform.rotation)) as GameObject;
			delArrow = temp;
		}
	}
	// END DECORATION MENU //
	
	
//====================================================================================================================================
	
	
	// BUILDING MENU //	
	
	// plot
	void buildingPlate01Button()
	{
//		if (GameManager.gameLevel != 2)
//		{
			popUpInfoScript.wall.active = false;
			buildingUI.SetActiveRecursively(false);
			guiControl.popUpOpenBool = false;
//		}
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 3)
			{
				popUpInfoScript.wall.active = false;
				buildingUI.SetActiveRecursively(false);
				
				panelControl.panelMoveIn = true;
				panelControl.panelMoveOut = false;
		
				popUpInfoScript.task5(2);
				
				if (delArrow != null)
					Destroy(delArrow);
			}
			
		}
		
		hPlotCnt = GameObject.FindGameObjectsWithTag("Plot");
		
		
		if (popUpInfoScript.cnGrnd <= 8)
		{
			if (GameManager.gameLevel >= 4)// && popUpInfoScript.cnGrnd < 2)//hPlotCnt.Length < 2)
			{
				if (GameManager.placeHGardenPlotBool)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objGarden.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskGardenPlot(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(20, 0);
				}
			}
		}
	}
	
	// Inn plate
	void buildingPlate02Button()
	{
		GameObject innObj = GameObject.Find("HC_B_Inn_GO(Clone)") as GameObject;
		
		// LEVEL 2 //
		if (innObj == null)
		{
			if (GameManager.gameLevel == 2)
			{
				
				// task 9
				if (GameManager.taskCount >= 9)
				{	
					popUpInfoScript.wall.active = false;
					buildingUI.SetActiveRecursively(false);
					guiControl.popUpOpenBool = false;
					
					popUpInfoScript.task9(2);
				}
			}
			
			// LEVEL 3 and above
			if (GameManager.gameLevel >= 3)
			{
				popUpInfoScript.wall.active = false;
				buildingUI.SetActiveRecursively(false);
				guiControl.popUpOpenBool = false;
				
				if (GameManager.hBuildingConstructBool)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objInn.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildInn(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(40,0);
				}
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
			
			popUpInfoScript.wall.active = false;
			buildingUI.SetActiveRecursively(false);
			guiControl.popUpOpenBool = false;
		}
	}
	// Bridge plate
	void buildingPlate03Button()
	{
		Debug.Log("Purchase bridge here... : "+GameManager.bridgeBuildBool);
		
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 4)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objBridge.objTypeId))
			{
				//GameManager.panelAccessBool = false;
				GameObject bridgeArrowObj = GameObject.Find("bridgeArrow") as GameObject;
				if (bridgeArrowObj != null)
					Destroy(bridgeArrowObj);

				objectSelection.objectSelectionBool = false;
				popUpInfoScript.taskBuildBridge(1);
				GameManager.placeObjectBool = false;
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// Stable plate
	void buildingPlate04Button()
	{
		GameObject stableObj = GameObject.Find("HC_B_Stable_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (stableObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 5)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objHalflingStable.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildStable(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
					
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// BlackSmith plate
	void buildingPlate05Button()
	{
		GameObject blackSmithObj = GameObject.Find("HC_B_BlackSmith_GO(Clone)") as GameObject;
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (blackSmithObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 6)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objBlackSmith.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildBlackSmith(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// Apothecary plate
	void buildingPlate06Button()
	{
		GameObject apothecaryObj = GameObject.Find("HC_B_Apothecary_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (apothecaryObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 10)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objApothecary.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildApothecary(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// Tavern plate
	void buildingPlate07Button()
	{
		GameObject tavernObj = GameObject.Find("HC_B_Tavern_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (tavernObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 9)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objTavern.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildTavern(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}

	// Sun Shrine plate
	void buildingPlate11Button()
	{
		GameObject sunShrineObj = GameObject.Find("HC_B_SunShrine_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (sunShrineObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 12)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objSunshrine.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildSunShrine(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// cancle
	void buildingCancleButton()
	{
		GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
		if (arrowDel != null)
			Destroy(arrowDel);
		
		scr_audioController.audio_buttonClick.Play();
		buildingUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);
		
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 1 || GameManager.gameLevel == 2)
		{
			buttonPulse plantsBP = GameObject.Find("storeBuildingButt").GetComponent("buttonPulse") as buttonPulse;
			plantsBP.scaleAnim = true;
			GameObject ps = GameObject.Find("buildingSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(ps.transform.position.x , ps.transform.position.y, ps.transform.position.z + 12), Quaternion.Inverse(ps.transform.rotation)) as GameObject;
			delArrow = temp;
		}
	}
	// END BUILDING MENU //
	
	
//====================================================================================================================================
	
	
	// CREATURE //
		
	// cancle
	void creatureCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel == 1)
		{
			Destroy(delArrow);
			objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
				
			objEditPanelInfo.panelMoveIn = false;
			objEditPanelInfo.panelMoveOut = true;
	
			GameObject objInfo_spwan = GameObject.Find("objInfo_spwan") as GameObject;
			GameObject temp = Instantiate(arrow, objInfo_spwan.transform.position, Quaternion.Euler(90, 90,0)) as GameObject;
			delArrow = temp;
			
			popUpInfoScript.wall.active = false;
			creatureUI.SetActiveRecursively(false);
			guiControl.popUpOpenBool = false;
		}
		
		// LEVEL 2
		if (GameManager.gameLevel == 2)
		{
			// task 4
			if (GameManager.taskCount == 4)
			{
				creatureUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				inventoryUI.SetActiveRecursively(true);
				
				GameObject arrowTemp = GameObject.Find("ArrowPF(Clone)") as GameObject;
				Destroy(arrowTemp);
			
				inventoryUI.SetActiveRecursively(true);
			
				buttonPulse iCreatureButtBP = GameObject.Find("inventoryCreatureButt").GetComponent("buttonPulse") as buttonPulse;
				iCreatureButtBP.scaleAnim = true;
				GameObject iCreatureSpwan = GameObject.Find("iCreatureSpwan");
				GameObject temp = Instantiate(arrow, new Vector3(iCreatureSpwan.transform.position.x, iCreatureSpwan.transform.position.y, iCreatureSpwan.transform.position.z + 12), Quaternion.Inverse(iCreatureSpwan.transform.rotation)) as GameObject;
				delArrow = temp;
			}
		}
		else if (GameManager.gameLevel != 1)
		{
			creatureUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			storeUI.SetActiveRecursively(true);
		}
	}	
	// hound
	public void creaturePlate01Button()
	{
		GameObject checkHound = GameObject.Find ("HC_C_Hound_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 2)
			{
				GameManager.popUpCount = 4;
				popUpInfoScript.curPopUpCnt = 4;
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.updateCurPopUpCount();
				
				popUpInfoScript.task2();
				
				objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
		
				objEditPanelInfo.panelMoveIn = true;
				objEditPanelInfo.panelMoveOut = false;
				
				if (delArrow != null)
					Destroy(delArrow);
			}
		}
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 2)
		{
			// task 4
			if (GameManager.taskCount == 4)
			{
				popUpInfoScript.task4(2);
			}
		}
		
		if (GameManager.gameLevel >= 4 && GameManager.readyAttackBool)
		{
			GameManager.currentCreature = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
			popUpInfoScript.taskGoblinCave(3);
		}
		
		// generate 2nd hound creature on 4th level
		else if (GameManager.gameLevel >= 3 && GameManager.burrySparkBool)
		{
		 	if (GameManager.curTG.tag == "TrainingGround")
			{
				if (checkHound == null)
				{
					if (GameManager.earthTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objHound.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "Hound");
							GameManager.earthTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
	
	// barg
	void creaturePlate02Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 4)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	//  cusith
	void creaturePlate03Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 8)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// sprout
	public void creaturePlate04Button()
	{
		GameObject checkSprout = GameObject.Find("HC_C_Sprout_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		// LEVEL 03 and above
		// generate 2nd hound creature on 4th level
		if (GameManager.gameLevel >= 3 && GameManager.burrySparkBool)
		{
			if (GameManager.curTG.tag == "PlantTG")
			{
				if (checkSprout == null)
				{
					if (GameManager.plantTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objSprout.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "Sprout");
							GameManager.plantTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
	
	// nymph
	void creaturePlate05Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 6)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// dryad
	void creaturePlate06Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 9)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// nix
	public void creaturePlate07Button()
	{
		GameObject checkNix = GameObject.Find("HC_C_Nix_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		// LEVEL 03 and above
		// generate 2nd hound creature on 4th level
		if (GameManager.gameLevel >= 5 && GameManager.burrySparkBool)
		{
			if (GameManager.curTG.tag == "WaterTG")
			{
				if (checkNix == null)
				{
					if (GameManager.waterTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objNix.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "Nix");
							GameManager.waterTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
	
	// draug
	void creaturePlate08Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 8)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// dragon
	void creaturePlate09Button()
	{
		popUpInfoScript.wall.active = false;
		creatureUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (GameManager.gameLevel >= 12)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// END CREATURE MENU
	
	
//====================================================================================================================================
	
	
	// TRAINING GROUND //
	
	// plate 01  earth training ground
	void createTrainingGround01Button()
	{
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		trainingGroundUI.SetActiveRecursively(false);
		
		CreateTrainingGround(gameManagerInfo.tg_TrainingGround_PF, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objTrainingGrnd.objTypeId), "HC_TG_TrainingGround_GO(Clone)");
		
	}
	
	// plate 02 plant training ground
	void createTrainingGround02Button()
	{
		// LEVEL 3 //
		CreateTrainingGround(trainingGround02, 3, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPlantTrainingGrnd.objTypeId), "HC_TG_Plant_GO(Clone)");
	}
		
		// plate 03 Water Training ground 
	void createTrainingGround03Button()
	{
		// LEVEL 5 //
		CreateTrainingGround(gameManagerInfo.tg_Water_PF, 5, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWaterTrainingGrnd.objTypeId), "HC_TG_Water_GO(Clone)");
	}
	
	// cancle
	void trainingGroundCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		//Debug.Log("training ground cancle button...");
		trainingGroundUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);
		
		// destroy arrow
		if (delArrow != null)
			Destroy(delArrow);
		
		if (GameManager.taskCount == 1)
		{
			buttonPulse decorBP = GameObject.Find("storeTrainingGroundButt").AddComponent("buttonPulse") as buttonPulse;
			decorBP.gameObject.transform.localScale = new Vector3(0.12f, 0.16f, 1);			
			decorBP.minSpeed = 3;
			decorBP.maxSpeed = 8;
			decorBP.minVal = 0.001f;
			decorBP.maxVal = 0.01f;
			decorBP.scaleAnim = true;
			
			GameObject ps = GameObject.Find("trainingGroundSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(ps.transform.position.x , ps.transform.position.y, ps.transform.position.z + 12), Quaternion.Inverse(ps.transform.rotation)) as GameObject;
			delArrow = temp;
		}
		
		if (GameManager.taskCount == 3)
		{
			buttonPulse decorBP = GameObject.Find("storeDecorationButt").GetComponent("buttonPulse") as buttonPulse;
			decorBP.scaleAnim = true;
			GameObject ps = GameObject.Find("decorationSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(ps.transform.position.x , ps.transform.position.y, ps.transform.position.z + 12), Quaternion.Inverse(ps.transform.rotation)) as GameObject;
			delArrow = temp;
		}
	}
	// END TRAINING GROUND MENU//
	
	
//====================================================================================================================================
	
	
	// PLANTS MENU //
	
	// plate 01 Turnip
	void plants01CreateButton()
	{	
		popUpInfoScript.wall.active = false;
		plantsUI.SetActiveRecursively(false);
		
		// LEVEL 2
		if (GameManager.gameLevel == 1)
		{
			// task 6
			if (GameManager.taskCount == 4)
			{
				Destroy(delArrow);
				
				popUpInfoScript.task6(5);
			}
		}
		
		// LEVEL 3 //
		if (GameManager.curPlot != null)
		{
			if (GameManager.gameLevel >= 3 && GameManager.curPlot.tag == "Plot")
			{
				if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objTurnips.objTypeId))
				{
					popUpInfoScript.wall.active = false;
					plantsUI.SetActiveRecursively(false);
					popUpInfoScript.taskFarming(1, "Turnip");
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
		}
	}
	
	// plate 02 Pipeweed
	void plants02CreateButton()
	{	
		plantButtonHalfling(3, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPipeweed.objTypeId),
		                    "PipeWeed", scrObjectCost.pipweedCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 03 Pumpkin
	void plants03CreateButton()
	{	
		plantButtonHalfling(5, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPumpkin.objTypeId),
		                    "Pumpkin", scrObjectCost.pumpkinCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 04 Costmary
	void plants04CreateButton()
	{	
		plantButtonHalfling(7, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objCostmaryherb.objTypeId),
		                    "Costmary", scrObjectCost.costmaryCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 05 FairyLily
	void plants05CreateButton()
	{	
		plantButtonHalfling(11, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objFairyLilly.objTypeId),
		                    "FairyLily", scrObjectCost.fairylilyCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 06 Potatoes
	void plants06CreateButton()
	{	
		plantButtonHalfling(10, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPotatoes.objTypeId),
		                    "Potatoes", scrObjectCost.potatoCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 07 Watercress
	void plants07CreateButton()
	{	
		plantButtonHalfling(12, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWatercress.objTypeId),
		                    "Watercress", scrObjectCost.watercreesCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 08 Mandrake
	void plants08CreateButton()
	{	
		plantButtonHalfling(14, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objMandrake.objTypeId),
		                    "Mandrake", scrObjectCost.mandrakeCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 09 Vervain
	void plants09CreateButton()
	{	
		plantButtonHalfling(13, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objVervainHerb.objTypeId),
		                    "Vervain", scrObjectCost.vervainCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 09 Sunflower
	void plants10CreateButton()
	{	
		plantButtonHalfling(12, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objSunflower.objTypeId),
		                    "SunFlower", scrObjectCost.sunflowerCost.GetComponent<SpriteText>().Text);
	}
	
	
	// cancle
	void plantsCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		plantsUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);

		
		// LEVEL 2
		if (GameManager.gameLevel == 1)
		{
			// task 6
			if (GameManager.taskCount == 4)
			{
				Destroy(delArrow);
				storeUI.SetActiveRecursively(false);
				popUpInfoScript.wall.active = true;
				inventoryUI.SetActiveRecursively(true);
				
				buttonPulse inventoryPlantBP = GameObject.Find("inventoryPlantButt").GetComponent("buttonPulse") as buttonPulse;
				inventoryPlantBP.scaleAnim = true;
						
				GameObject iPlantSpwan = GameObject.Find("iPlantSpwan");
				GameObject inventoryPlantArrow = Instantiate(arrow, new Vector3(iPlantSpwan.transform.position.x, iPlantSpwan.transform.position.y, iPlantSpwan.transform.position.z + 12), Quaternion.Euler(90, 180, 0)) as GameObject;
				delArrow = inventoryPlantArrow;
			}
		}
		
		// LEVEL 3
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.wall.active = false;
			inventoryUI.SetActiveRecursively(false);
			GameObject plotGO = GameManager.curPlot;//GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
			Debug.Log("my cur plot : " + GameManager.curPlot.name);
			plotGO.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		}
	}
	// END PLANTS MENU //
	
	void defenceCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		defenceUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);
		
		if (GameManager.taskCount == 10)
		{
			Destroy(delArrow);
//			buttonPulse dBP = GameObject.Find("storeDefenceButt").GetComponent("buttonPulse") as buttonPulse;
//			dBP.scaleAnim = true;
			GameObject dpathS = GameObject.Find("defenceSpwan");
			GameObject temp = Instantiate(arrow, new Vector3(dpathS.transform.position.x, dpathS.transform.position.y, dpathS.transform.position.z + 12), Quaternion.Inverse(dpathS.transform.rotation)) as GameObject;
			delArrow = temp;
		}
	}
	
	
	//====================================================================================================================================
	
	
	// TREASURE //
	
	// cancle
	void treasureCancleButton()
	{
		//Debug.Log("treasure cancle button...");
		scr_audioController.audio_buttonClick.Play();
		treasureUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		storeUI.SetActiveRecursively(true);
	}
	
	// END TREASURE MENU
	void DarklingtreasureCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		treasureUI.SetActiveRecursively(false);
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(true);
	}
	
	//====================================================================================================================================
	
	
	// OBJECT MENU //
	
	// object place
	void placeButton()
	{		
		scr_audioController.audio_buttonClick.Play();
		
		GameManager.panelAccessBool = true;
		// LEVEL 1 //
		objectSelection.objectSelectionBool = true;
		
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 3 || GameManager.taskCount == 8)
				GameManager.placeObjectBool = true;
			
			if(GameManager.placeObjectBool)
			{
				// task 1
				if (grid.curCol != null)
				{
					if (GameManager.taskCount == 1)
					{
						popUpInfoScript.task1();
						GameManager.taskCount++;
						popUpInfoScript.updateTaskCount();
					}
				}
					
				 //task 3 place gardon plot
				if (GameManager.taskCount == 3)
				{
					if(GameManager.placeObjectBool)
					{
						popUpInfoScript.task5(3);
						
						popUpInfoScript.curPopUpCnt = 7;
						popUpInfoScript.updateCurPopUpCount();
						
						popUpInfoScript.curPopUpType = 0;
						popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
						
						GameManager.taskCount = 4;
						popUpInfoScript.updateTaskCount();
					}
				}
				
				if (GameManager.taskCount == 8)
				{
					grid.curObj = curPlaceObj;
					halfwayone = curObj.transform.FindChild("waypoint1") ;
					halfwayone.gameObject.active = false;
					//popUpInfoScript.task3();
					popUpInfoScript.placeDirtPathTutorial(5);
//					GameManager.taskCount = 4;
//					popUpInfoScript.updateTaskCount();
					
					popUpInfoScript.curPopUpCnt = 6;
					popUpInfoScript.updateCurPopUpCount();
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					
				}
			}
		}
		
		
		if (grid.curCol != null)
		{
			// LEVEL 2 //
			if (GameManager.gameLevel == 2)
			{
				
				if (GameManager.taskCount == 10)
				{
					golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
					Destroy(golum);
					popUpInfoScript.taskBuildEarthObelisk(2);


					GameManager.popUpCount = 18;

					GameObject tgObj = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					if (tgObj != null)
						tgObj.GetComponent<HealthProgressBarTutorial>().disablePopUpBool = true;

					GameObject plotObj = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
					if (plotObj != null)
						plotObj.GetComponent<HealthProgressBarTutorial>().disablePopUpBool = true;
				}

				// task 9
				if (GameManager.taskCount == 9)
				{
					if(GameManager.placeObjectBool)
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.task9(3);
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						if(golum != null)
						{
							golumbool = true;
						}
					}
				}
			}
		
		
			// LEVEL 3 //
			if (GameManager.gameLevel >= 3)
			{
				if(GameManager.placeObjectBool)
				{
					Debug.Log("grid.curObj.name : "+grid.curObj.name);
					Debug.Log("grid.curObj.tag : "+grid.curObj.tag);
					
					// object placement
					if (grid.curObj.gameObject.tag == "TrainingGround") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "PlantTG") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "Swamp") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "WaterTG") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "DEarthTG") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "DFireTG") // tg
						popUpInfoScript.taskTrainingGround();
					else if (grid.curObj.gameObject.tag == "Plot") // building
						popUpInfoScript.taskGardenPlot(2);
					else if (grid.curObj.gameObject.tag == "Inn") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildInn(2);
					}
					else if (grid.curObj.gameObject.tag == "Stable") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildStable(2);
					}
					else if (grid.curObj.gameObject.tag == "BlackSmith") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildBlackSmith(2);
					}
					else if (grid.curObj.gameObject.tag == "Apothecary") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildApothecary(2);
					}
					else if (grid.curObj.gameObject.tag == "Tavern") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildTavern(2);
					}
					else if (grid.curObj.gameObject.tag == "EarthObelisk") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildEarthObelisk(2);
					}
					else if (grid.curObj.gameObject.tag == "PlantObelisk") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildPlantObelisk(2);
					}
					else if (grid.curObj.gameObject.tag == "WaterObelisk") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildWaterObelisk(2);
					}
					else if (grid.curObj.gameObject.tag == "SunShrine") // building
					{
						golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
						Destroy(golum);
						popUpInfoScript.taskBuildSunShrine(2);
					}
					else if (grid.curObj.gameObject.tag == "DPlot") // d building
						popUpInfoScript.taskDarklingPlot(2);
					else if (grid.curObj.gameObject.tag == "DInn") // d building
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingInn(2);
					}
					else if (grid.curObj.gameObject.tag == "DStable") // d building
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingStable(2);
					}
					else if (grid.curObj.gameObject.tag == "DBlackSmith") // d building
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingBlackSmith(2);
					}
					else if (grid.curObj.gameObject.tag == "DTavern") // d building
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingTavern(2);
					}
					else if (grid.curObj.gameObject.tag == "DApothecary") // d building
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingApothecary(2);
					}
					else if (grid.curObj.gameObject.tag == "DEarthObelisk")
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingEarthObelisk(2);
					}
					else if (grid.curObj.gameObject.tag == "DSwampObelisk")
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingSwampObelisk(2);
					}
					else if (grid.curObj.gameObject.tag == "DFireObelisk")
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingFireObelisk(2);
					}
					
					else if (grid.curObj.gameObject.tag == "MoonShrine")
					{
						Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
						Destroy(Darkgolum);
						popUpInfoScript.taskDarklingMoonShrine(2);
					}
					else if (grid.curObj.gameObject.tag == "Decoration") // decoration
					{
						popUpInfoScript.taskDecorationItem();
					}
				}
			}
		}
	}
		
//=========================================================================================================
	
	void flipButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (curFlipObj.transform.localScale.x > 0)
		{
			curFlipObj.transform.localScale = new Vector3(curFlipObj.transform.localScale.x * -1, curFlipObj.transform.localScale.y, curFlipObj.transform.localScale.z);
			GameObject ui = curFlipObj.transform.FindChild("UI").gameObject;
			ui.transform.localScale = new Vector3(ui.transform.localScale.x * -1, ui.transform.localScale.y, ui.transform.localScale.z);
		}
		else if (curFlipObj.transform.localScale.x < 0)
		{
			curFlipObj.transform.localScale = new Vector3(curFlipObj.transform.localScale.x * -1, curFlipObj.transform.localScale.y, curFlipObj.transform.localScale.z);
			GameObject ui = curFlipObj.transform.FindChild("UI").gameObject;
			ui.transform.localScale = new Vector3(ui.transform.localScale.x * -1, ui.transform.localScale.y, ui.transform.localScale.z);
		}
	}
	
//=========================================================================================================
	
	public bool isDelete,isDeleteDec;
	private float x,y,z;
	private string SenddelPosition;
	private string SenddelDecPos;
	public string GetDeleteDecPos()
	{
		return SenddelDecPos;
	}
	
	public string GetDeletePosition()
	{
		return SenddelPosition;
	}
	
	void DeleteObjDecSvr(GameObject delObj)
	{
		isDeleteDec = true;
		if (delObj != null)
		{		
			x = delObj.transform.position.x;
			y = delObj.transform.position.y;
			z = delObj.transform.position.z;
				
		    SenddelDecPos = "("+ x+","+y+","+z+")";
			scr_remote.SendRequestForGetworld();
		}
	}
	
	void DeleteObjSvr(GameObject  delObj)
	{
		isDelete = true;
		if(delObj != null)
		{
			x = delObj.transform.position.x;
			y = delObj.transform.position.y;
			z = delObj.transform.position.z;
			
	    	SenddelPosition = "("+ x+","+y+","+z+")";	
		    scr_remote.SendRequestForGetworld();
		}
	}
	
	// object delete
	void deleteButton()
	{
		Debug.Log ("cur del obj : " + GameManager.curDelObj);
		// Level 1 //
		if (GameManager.gameLevel == 1)
		{
			if (GameManager.taskCount == 1 || GameManager.taskCount == 3 || GameManager.taskCount == 8)
			{
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;
				
				// create arrow on market button
				GameObject ms = GameObject.Find("marketSpwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
				delArrow = temp; 
				
				// market button pulse animation on
				buttonPulse bp = GameObject.Find("button_Market").AddComponent("buttonPulse") as buttonPulse;
				bp.gameObject.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
				bp.minSpeed = 3;
				bp.maxSpeed = 8;
				bp.minVal = 0.05f;
				bp.maxVal = 0.2f;
				bp.scaleAnim = true;
				
				Destroy(GameManager.curDelObj);
				curDelObj = null;
				grid.curObj = null;
			}
		}
		
		// LEVEL 2 //
		if (GameManager.gameLevel == 2)
		{
			// task 5
			if (GameManager.taskCount == 5)
			{
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;
				
				// create arrow on market button
				GameObject ms = GameObject.Find("marketSpwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
				delArrow = temp; 
				
				// market button pulse animation on
				buttonPulse bp = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				bp.scaleAnim = true;
			}
			
			// task 9
			if (GameManager.taskCount == 9)
			{
				// goto market menu
				panelControl.panelMoveOut = true;
				panelControl.panelMoveIn = false;
				// arrow button create and place
				buttonPulse bp = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
				bp.scaleAnim = true;
				GameObject ms = GameObject.Find("marketSpwan");
				GameObject temp = Instantiate(arrow, ms.transform.position, ms.transform.rotation) as GameObject;
				delArrow = temp;
			}
		}
		
		if (GameManager.gameLevel >= 3)
		{
			cavePatchList = GameObject.FindGameObjectsWithTag("cavePatch");
			
			foreach(GameObject cavePatch in cavePatchList)
			{
				if (cavePatch.GetComponent<MeshRenderer>().enabled == true)
					cavePatch.GetComponent<MeshRenderer>().enabled = false;
			}
			
			scr_audioController.audio_buttonClick.Play();
			
			GameManager.panelAccessBool = true;
			objectSelection.objectSelectionBool = true;
			
			GameManager.placeObjectBool = false;
			
			if (GameManager.curDelObj.tag != "HHouse" && GameManager.curDelObj.tag != "DHouse" && GameManager.curDelObj.tag != "notDelete")
			{
				Debug.Log("tag :" + GameManager.curDelObj.tag);
				
				if(GameManager.curDelObj.tag == "Decoration")
				{
				   DeleteObjDecSvr(GameManager.curDelObj);
				}
				else
				{
				   DeleteObjSvr(GameManager.curDelObj);
				}
				
				Destroy(GameManager.curDelObj);
				curDelObj = null;
				grid.curObj = null;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(36, 0);
			}
			
			objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
			movePanelInfo.panelMoveIn = true;
			movePanelInfo.panelMoveOut = false;
			HalflingCancleBool = true;
			DarklingCancleBool = true;

			//disable sounds

			if(scr_audioController.audio_Apothecary.isPlaying)
				popUpInfoScript.scr_audioController.audio_Apothecary.Stop();
			
			if(scr_audioController.audio_Blacksmith.isPlaying)
				popUpInfoScript.scr_audioController.audio_Blacksmith.Stop();
			
			if(scr_audioController.audio_stables.isPlaying)
				popUpInfoScript.scr_audioController.audio_stables.Stop();
			
			if(scr_audioController.audio_tavern.isPlaying)
				popUpInfoScript.scr_audioController.audio_tavern.Stop();
			
			if(scr_audioController.audio_Inn.isPlaying)
				popUpInfoScript.scr_audioController.audio_Inn.Stop();

			if(GameManager.curDelObj.tag == "DPlot")
			{
				popUpInfoScript.cnDGrnd = popUpInfoScript.cnDGrnd - 1;
			}
			
			if(GameManager.curDelObj.tag == "Plot")
			{
				popUpInfoScript.cnGrnd = popUpInfoScript.cnGrnd - 1;
			}
			
			halffirstinst = false;
			darkfirstinst = false;
		}
	}
	
	// END OBJECT MENU //
	
//====================================================================================================================================
	
	private string SendPosBeforeMove;
	public string GetPositionBeforeMove()
	{
		return SendPosBeforeMove;
	}
	
	// OBJECT EDIT MENU	
	
	void objectMoveButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		objectSelection.objectSelectionBool = false;
		
		if (GameManager.gameLevel > 2)
		{
			if (GameManager.currentMovableObj.tag != "HHouse" && GameManager.currentMovableObj.tag != "DHouse" && GameManager.currentMovableObj.transform.position.x != 62.6f)
			{
				Transform waypoint = GameManager.currentMovableObj.transform.FindChild("waypoint1") as Transform;
				
				if (waypoint != null)
					waypoint.gameObject.GetComponent<SphereCollider>().enabled = false;
				
				objPrevPos = GameManager.currentMovableObj.transform.position;
				
				GameManager.placeObjectBool = true;
				GameManager.multipleDecorationBool = false;
				GameManager.currentMovableObj.GetComponent<Sensors>().enabled = true;
				Sensors.sensorWorkBool = true;
				
				GameManager.currentMovableObj.transform.FindChild("selectionPatch").gameObject.active = false;
				
				
				GameManager.currentMovableObj.transform.FindChild("UI").gameObject.SetActiveRecursively(true);
				GameManager.currentMovableObj.transform.FindChild("touchMovePlane").gameObject.SetActiveRecursively(true);
				GameManager.currentMovableObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = true;
				GameManager.currentMovableObj.transform.FindChild("touchMovePlane").gameObject.tag = "movableObj";
				
				GameManager.currentMovableObj.transform.FindChild("Isometric_Collider").gameObject.tag = "movableObj";
				grid.curObj = GameManager.currentMovableObj;
				grid.curCol.tag = "movableObj";
				
				Transform tempObjUI = GameManager.currentMovableObj.transform.FindChild("UI");
				Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
				Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
				Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
				
				UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
				delObjUIButtonInfo.scriptWithMethodToInvoke = this;
				
				UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
				placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
				objPanelControl objPanelEditInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			
				objPanelEditInfo.panelMoveIn = true;
				objPanelEditInfo.panelMoveOut = false;
			
				popUpInfoScript.isObjectMove = true; //move from server
				SendPosBeforeMove = popUpInfoScript.GetabsolutePos(grid.curObj.transform.position.x,grid.curObj.transform.position.y,grid.curObj.transform.position.z);
			
				curObj = grid.curObj;
				
				if (grid.curObj.name == "HC_D_DirtPath_GO(Clone)" || grid.curObj.name == "DL_D_DDirtPath_GO(Clone)")
				{
					grid.curObj.GetComponent<dirtPathPlacement>().enabled = true;
				}
			}
			else
			{
				objectSelection.objectSelectionBool = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(37, 0);
				GameManager.currentMovableObj = null;
			}
			
			objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
			movePanelInfo.panelMoveIn = true;
			movePanelInfo.panelMoveOut = false;
			
			objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;
		}
	}
	
//=========================================================================================================
	
	void editObjectDeleteButton()
	{
		//Debug.Log("edit delete object...");
	}
	
//=========================================================================================================
	
	void battleInfoButton()
	{
		if (GameManager.gameLevel >= 3)
		{
			// show battle panel
			objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
			battlePanelInfo.panelMoveIn = true;
			battlePanelInfo.panelMoveOut = false;
			
			popUpInfoScript.curPopUpCnt = 0;
			popUpInfoScript.curPopUpType = 1;
			popUpInfoScript.defaultPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject infoImage = popUpType2.transform.FindChild("info_Image").gameObject;
			GameObject infoSpriteTxt = popUpType2.transform.FindChild("info_spText").gameObject;
			GameObject infoTitle = popUpType2.transform.FindChild("title_spText").gameObject;
			
			GameObject infoPB = GameObject.Find("InfoProgressBar") as GameObject;
			GameObject infoRabbit = GameObject.Find("RabbitBackgrnd") as GameObject;
			
			infoPB.SetActiveRecursively(false);
			infoRabbit.SetActiveRecursively(false);
			
			infoImage.renderer.material.mainTexture = infoImageListScript.battleFieldTex;
			popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
			infoSpriteTxt.GetComponent<SpriteText>().Text = "Battle feild is to challange other player for fighting with creature";
			infoTitle.GetComponent<SpriteText>().Text = "Battle Field";
		}
	}
	
//=========================================================================================================
	
	void battleButton()
	{
		// hide battle panel
		objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
		battlePanelInfo.panelMoveIn = true;
		battlePanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 4)
		{
			bmgr.IntroduceBattle();
						
			GameObject arrowChk = GameObject.Find("gameArrowPF(Clone)") as GameObject;
			if(arrowChk!=null)
			{
				Destroy(arrowChk);
			}
		}
	}
	
//=========================================================================================================
	
	void caveInfoButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 3)
		{
			objPanelControl attackPanelInfoAttack = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
			attackPanelInfoAttack.panelMoveIn = true;
			attackPanelInfoAttack.panelMoveOut = false;
			
			popUpInfoScript.curPopUpCnt = 0;
			popUpInfoScript.curPopUpType = 1;
			popUpInfoScript.defaultPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject infoImage = popUpType2.transform.FindChild("info_Image").gameObject;
			GameObject infoSpriteTxt = popUpType2.transform.FindChild("info_spText").gameObject;
			GameObject infoTitle = popUpType2.transform.FindChild("title_spText").gameObject;
			
			GameObject infoPB = GameObject.Find("InfoProgressBar") as GameObject;
			GameObject infoRabbit = GameObject.Find("RabbitBackgrnd") as GameObject;
			
			infoPB.SetActiveRecursively(false);
			infoRabbit.SetActiveRecursively(false);
			
			if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.goblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[17];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 01";
			}
			else if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.goblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[0];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 02";
			}
			else if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.goblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[1];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 03";
			}
			else if (GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.orgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[5];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 01";
			}
			else if (GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.orgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[6];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 02";
			}
			else if (GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.orgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[7];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 02";
			}
			else if (GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.trollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[2];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 01";
			}
			else if (GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.trollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[3];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 02";
			}
			else if (GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.trollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[4];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 03";
			}
			else if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dGoblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[8];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 01";
			}
			else if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dGoblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[9];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 02";
			}
			else if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dGoblinCampTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Nasty creatures these  goblins, livin on squirrel meat and mealy insects. And they'll gut you as soon an look at you if you're not careful... not to mention the theft and plunder thy'll bring to your village. Luckily, it doesn't take much to get rid of them.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[10];
				infoTitle.GetComponent<SpriteText>().Text = "Goblin Camp 03";
			}
			else if (GameManager.curCave.name == "DL_B_OrgCave_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dOrgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[14];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 01";
			}
			else if (GameManager.curCave.name == "DL_B_OrgCave_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dOrgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[15];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 02";
			}
			else if (GameManager.curCave.name == "DL_B_OrgCave_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dOrgCaveTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Seems like Orcs are abundant in every land there days. A challenge to eradicate, but the task must be done to avoid your land being overrun. Orcs are vicious, strong and... somhow unnatural. It takes a powerful creature to kill them off.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[16];
				infoTitle.GetComponent<SpriteText>().Text = "Org Cave 03";
			}
			else if (GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dTrollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[11];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 01";
			}
			else if (GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dTrollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[12];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 02";
			}
			else if (GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_03")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dTrollHouseTex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Look at the size of those beasts! What is lacking in intelliegence is make up in brute strength. They will decimate your village if not taken care of, but beware, only the most powerful creatures or magic will drive them away.";
				infoSpriteTxt.GetComponent<SpriteText>().Text = goblinCaveInfoString[13];
				infoTitle.GetComponent<SpriteText>().Text = "Troll House 03";
			}
		}
	}
	
//=========================================================================================================
	
	// OBJECT INFO BUTTON
	
	void editObjectInfoButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		// Level 3 //
		if (GameManager.gameLevel >= 3)
		{
			objPanelControl objPanelEditInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
			objPanelEditInfo.panelMoveIn = true;
			objPanelEditInfo.panelMoveOut = false;
			GameManager.curTG.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;		
			
			popUpInfoScript.curPopUpCnt = 0;
			popUpInfoScript.curPopUpType = 1;
			popUpInfoScript.defaultPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject infoImage = popUpType2.transform.FindChild("info_Image").gameObject;
			SpriteText infoSpriteTxt = popUpType2.transform.FindChild("info_spText").gameObject.GetComponent<SpriteText>();
			SpriteText infoTitle = popUpType2.transform.FindChild("title_spText").gameObject.GetComponent<SpriteText>();
			
			GameObject infoPB = GameObject.Find("InfoProgressBar") as GameObject;
			GameObject infoRabbit = GameObject.Find("RabbitBackgrnd") as GameObject;
			
			infoPB.SetActiveRecursively(false);
			infoRabbit.SetActiveRecursively(false);
			
			// Training Ground
			if (GameManager.curTG.tag == "TrainingGround")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.earthTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.earthTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[0].ToString();
				infoTitle.Text = "Earth Training Ground";
			}
			else if (GameManager.curTG.tag == "PlantTG")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.plantTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.plantTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[1].ToString();
				infoTitle.Text = "Plant Training Ground";
			}
			else if (GameManager.curTG.tag == "WaterTG")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.waterTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.waterTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[2].ToString();
				infoTitle.Text = "Water Training Ground";
				
			}
			else if (GameManager.curTG.tag == "Swamp")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.spwampTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.swampTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[4].ToString();
				infoTitle.Text = "Swamp Training Ground";
				
			}
			else if (GameManager.curTG.tag == "DEarthTG")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dEarthTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.dEarthTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[3].ToString();
				infoTitle.Text = "DarkEarth Training Ground";
				
			}
			else if (GameManager.curTG.tag == "DFireTG")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.fireTG_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.fireTG_lvl.ToString();
				infoSpriteTxt.Text = trainingGroundInfoString[5].ToString();
				infoTitle.Text = "Fire Training Ground";
			}
		}
	}
	
	void plotInfoButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 3)
		{
			// hide plant panel
			objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
			objPanelInfo.panelMoveIn = true;
			objPanelInfo.panelMoveOut = false;
			
			popUpInfoScript.curPopUpCnt = 0;
			popUpInfoScript.updateCurPopUpCount();
			
			popUpInfoScript.curPopUpType = 1;
			popUpInfoScript.defaultPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject infoImage = popUpType2.transform.FindChild("info_Image").gameObject;
			SpriteText infoTitle = popUpType2.transform.FindChild("title_spText").gameObject.GetComponent<SpriteText>();
			
			GameObject infoPB = GameObject.Find("InfoProgressBar") as GameObject;
			GameObject infoRabbit = GameObject.Find("RabbitBackgrnd") as GameObject;
			
			infoPB.SetActiveRecursively(false);
			infoRabbit.SetActiveRecursively(false);
			
			// Plot
			if (GameManager.curPlot.tag == "Plot")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.hPlot_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel.ToString();//GameManager.plot_lvl;
				//info_spText.Text = buildingInfoString[0].ToString();
				infoTitle.Text = "Garden Plot";
				int plotLevel = GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel;
				if (plotLevel == 1)
					info_spText.Text = "A small overturned plot for planting. Quite weedy and filled with stones... this soil needs some work. Still, some things grow quite well on it.";
				
				if (plotLevel == 2)
					info_spText.Text = " Still too small for any major crops, but at least the soid is clean and quite rich. A respectable Halfling sized garden. Suitable for vegetables, but powerful herbs need something better.";
			}
			else if (GameManager.curPlot.tag == "DPlot")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dPlot_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel.ToString();//GameManager.dPlot_lvl;
				//info_spText.Text = buildingInfoString[10].ToString();
				infoTitle.Text = "Garden Plot";
				
				int plotLevel = GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel;
				if (plotLevel == 1)
					info_spText.Text = "A small overturned plot for planting. Quite weedy and filled with stones... this soil needs some work. Still, some things grow quite well on it.";
				
				if (plotLevel == 2)
					info_spText.Text = " Still too small for any major crops, but at least the soid is clean and quite rich. A respectable Halfling sized garden. Suitable for vegetables, but powerful herbs need something better.";
			}
		}
	}
	
	void otherObjInfoButton()
	{
		scr_audioController.audio_buttonClick.Play();
		objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
		movePanelInfo.panelMoveIn = true;
		movePanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.curPopUpCnt = 0;
			popUpInfoScript.updateCurPopUpCount();
			
			popUpInfoScript.curPopUpType = 1;
			popUpInfoScript.defaultPopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			GameObject infoImage = popUpType2.transform.FindChild("info_Image").gameObject;
			SpriteText infoSpriteTxt = popUpType2.transform.FindChild("info_spText").gameObject.GetComponent<SpriteText>();
			SpriteText infoTitle = popUpType2.transform.FindChild("title_spText").gameObject.GetComponent<SpriteText>();
			
			string objectName = GameManager.currentMovableObj.name.ToString();
			string[] worlds = objectName.Split('_');
			
			GameObject infoPB = GameObject.Find("InfoProgressBar") as GameObject;
			GameObject infoRabbit = GameObject.Find("RabbitBackgrnd") as GameObject;
			
			infoPB.SetActiveRecursively(false);
			infoRabbit.SetActiveRecursively(false);
			
			// Building
			if (GameManager.currentMovableObj.tag == "HHouse")
			{
				upgradeProgressBar hHouseUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (hHouseUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.hHouse;
					info_spText.Text = "Hardly worthy of being called a home, this is more of a hovel. Halflings are used to living in holes, but this seems more fit for a earthmole."; //buildingInfoString[20].ToString();
				}
				else if (hHouseUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.hHouse2;
					info_spText.Text = "Ok. now we're doing better. A respectable Halfling sized home for one, though don't expect much company.";
				}
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + hHouseUPB.currentUpgradeLevel.ToString();
				//info_spText.Text = "Hardly worthy of being called a home, this is more of a hovel. Halflings are used to living in holes, but this seems more fit for a earthmole."; //buildingInfoString[20].ToString();
				infoTitle.Text = "Halfling House";
			}
			
			else if (GameManager.currentMovableObj.tag == "DHouse")
			{
				upgradeProgressBar dHouseUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dHouseUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.dHouse;
					info_spText.Text = "Cool, dark & damp. Hardly large enough to sleep in, but at least it's cover from daylight.";
				}
				else if (dHouseUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.dHouse2;
					info_spText.Text = "Finally a place to hang last nights prey, though the only place to cook it is on the outside fire. Still cool and dark, though it's a big improvement on the dampness.";
				}
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dHouseUPB.currentUpgradeLevel.ToString();	
				//info_spText.Text = buildingInfoString[21].ToString();
				infoTitle.Text = "Darkling House";
			}
			
			else if (GameManager.currentMovableObj.tag == "Inn")
			{
				upgradeProgressBar innUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (innUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.inn01_tex;
					info_spText.Text = "A small but quaint place to rest, with halfling sized rooms, rarely something available though. It earns enough gold to sustain itself.";
				}
				else if (innUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.inn02_tex;
					info_spText.Text = "With an added bar and ale stock, this Inn makes a tidy profit. Plenty of rooms to accommodate most civilized races.";
				}
				else if (innUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.inn02_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + innUPB.currentUpgradeLevel.ToString();
				//info_spText.Text = buildingInfoString[1].ToString();
				infoTitle.Text = "Inn";
			}
			
			else if (GameManager.currentMovableObj.tag == "Stable")
			{
				upgradeProgressBar stableUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (stableUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.stable_tex;
					info_spText.Text = "A shoddy thatched roof attached to a fe spindly posts. A few locals may pay for this service, but really hardly fit for an ass, let alone a steed.";
				}
				else if (stableUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.stable_tex;
					info_spText.Text = "Respectable quarters for horses and donkey's  alike. Individual stalls with hay matting. Supplies a meager but steady income.";
				}
				else if (stableUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.stable_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + stableUPB.currentUpgradeLevel.ToString();
				//info_spText.Text = buildingInfoString[2].ToString();
				infoTitle.Text = "Stable";
			}
			
			else if (GameManager.currentMovableObj.tag == "BlackSmith")
			{
				upgradeProgressBar blackSmithUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (blackSmithUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.blackSmith_tex;
					info_spText.Text = "A small lean to shelter to cover your anvil and fire. Hardly large enough for horseshoe making, and brings in very little gold.";
				}
				else if (blackSmithUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.blackSmith_tex;
					info_spText.Text = "Finally room for a real forge and decent tools. Capable of filling smaller smithy orders, and makes a steady income.";
				}
				else if (blackSmithUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.blackSmith_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + blackSmithUPB.currentUpgradeLevel.ToString();
				//info_spText.Text = buildingInfoString[3].ToString();
				infoTitle.Text = "Black Smith";
			}
			
			else if (GameManager.currentMovableObj.tag == "Apothecary")
			{
				infoPB.SetActiveRecursively(true);
				infoRabbit.SetActiveRecursively(true);
				
				upgradeProgressBar apothecaryUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (apothecaryUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.apothecary_tex;
					info_spText.Text = "The cauldron is leaky and only the dirt floor to store your herbs, but at least it's a place to mix your elixirs.";
				}
				else if (apothecaryUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.apothecary_tex;
					info_spText.Text = "Shelves for bottles and ingredients, no leaks and a nice window for sunlight. Much more suitable for more complicated recipes.";
				}
				else if (apothecaryUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.apothecary_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + apothecaryUPB.currentUpgradeLevel.ToString();
//				info_spText.Text = buildingInfoString[4].ToString();
				infoTitle.Text = "Apothecary";
				
				//Harish chander
				ProgressBarMiniGames miniGamePB  = popUpType2.transform.FindChild("InfoProgressBar").gameObject.GetComponent<ProgressBarMiniGames>();
				
				Transform rabbit =  popUpType2.transform.FindChild("RabbitBackgrnd").transform.FindChild("qRabbitButton") as Transform;
				UIButton RabbitBtn = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				RabbitBtn.scriptWithMethodToInvoke = popUpInfoScript.guiControlInfo;
				getaccelerate = "ApothecaryMiniGame";	
				
				float tot = 120f;
				float tymSvr = (float) (scr_userWorld.ReturnTimefromMiniGameTimes("ApothecaryMiniGame"));
				
				if(tymSvr <= tot && tymSvr != -1)
				{
				miniGamePB.enabled = true;	
				popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(true);
				miniGamePB.seconds = tymSvr	;
						
				miniGamePB.cnt = (int)((tot) - miniGamePB.seconds);
				float remain = ((float)miniGamePB.cnt) / tot;
				miniGamePB.seconds = tot;
						
				
				miniGamePB.progressBarPov.transform.localScale = new Vector3(remain, miniGamePB.progressBarPov.transform.localScale.y, miniGamePB.progressBarPov.transform.localScale.z);
						
			}
				else
				{
					popUpType2.transform.FindChild("InfoProgressBar").gameObject.SetActiveRecursively(false);
					popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(false);
					miniGamePB.enabled = false;
					
					Debug.Log("Time ::  >>>>>>>>>");
				}
			}
		
			
			else if (GameManager.currentMovableObj.tag == "Tavern")
			{
				Debug.Log("Tavern selected...");
				infoPB.SetActiveRecursively(true);
				infoRabbit.SetActiveRecursively(true);
				
				upgradeProgressBar tavernUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (tavernUPB.currentUpgradeLevel == 1)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.tavern_tex;
					info_spText.Text = "Sure, folks come and buy ale here, but nobody stays long in this hovel.";
				}
				else if (tavernUPB.currentUpgradeLevel == 2)
				{
					infoImage.renderer.material.mainTexture = infoImageListScript.tavern_tex;
					info_spText.Text = "A couple tables and a decent still in the back make this tavern a regular for a few of the locals. Even if they do have to bring their own mugs.";
				}
				else if (tavernUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.tavern_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + tavernUPB.currentUpgradeLevel.ToString();
				//info_spText.Text = buildingInfoString[5].ToString();
				infoTitle.Text = "Tavern";
				
				
				//Harish chander
				ProgressBarMiniGames miniGamePB  = popUpType2.transform.FindChild("InfoProgressBar").gameObject.GetComponent<ProgressBarMiniGames>();
				
				
				Transform rabbit =  popUpType2.transform.FindChild("RabbitBackgrnd").transform.FindChild("qRabbitButton") as Transform;
				UIButton RabbitBtn = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				RabbitBtn.scriptWithMethodToInvoke = popUpInfoScript.guiControlInfo;
				getaccelerate = "TavernMiniGame";
				
				float tot = 120f;
				float tymSvr = (float) (scr_userWorld.ReturnTimefromMiniGameTimes("TavernMiniGame"));
				
				if(tymSvr <= tot && tymSvr != -1)
				{
				miniGamePB.enabled = true;	
				popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(true);
				miniGamePB.seconds = tymSvr	;
						
				miniGamePB.cnt = (int)((tot) - miniGamePB.seconds);
				float remain = ((float)miniGamePB.cnt) / tot;
				miniGamePB.seconds = tot;
						
				
				miniGamePB.progressBarPov.transform.localScale = new Vector3(remain, miniGamePB.progressBarPov.transform.localScale.y, miniGamePB.progressBarPov.transform.localScale.z);
						
				}
				else
				{
					popUpType2.transform.FindChild("InfoProgressBar").gameObject.SetActiveRecursively(false);
					popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(false);
					miniGamePB.enabled = false;
					
					Debug.Log("Time ::  >>>>>>>>>");
				}
			}
			
			else if (GameManager.currentMovableObj.tag == "DInn")
			{
				upgradeProgressBar dInnUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dInnUPB.currentUpgradeLevel == 1)
					infoImage.renderer.material.mainTexture = infoImageListScript.dInn01_tex;
				else if (dInnUPB.currentUpgradeLevel == 2)
					infoImage.renderer.material.mainTexture = infoImageListScript.dInn02_tex;
				else if (dInnUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.dInn01_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dInnUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[11].ToString();
				infoTitle.Text = "Inn";
			}
			
			else if (GameManager.currentMovableObj.tag == "DStable")
			{
				upgradeProgressBar dStableUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dStableUPB.currentUpgradeLevel == 1)
					infoImage.renderer.material.mainTexture = infoImageListScript.dStable_tex;
				else if (dStableUPB.currentUpgradeLevel == 2)
					infoImage.renderer.material.mainTexture = infoImageListScript.dStable2_tex;
				else if (dStableUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.dStable2_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dStableUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[12].ToString();
				infoTitle.Text = "Stable";
			}
			
			else if (GameManager.currentMovableObj.tag == "DBlackSmith")
			{
				upgradeProgressBar dBlackSmithUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dBlackSmithUPB.currentUpgradeLevel == 1)
					infoImage.renderer.material.mainTexture = infoImageListScript.dBlackSmith_Tex;
				else if (dBlackSmithUPB.currentUpgradeLevel == 2)
					infoImage.renderer.material.mainTexture = infoImageListScript.dBlackSmith2_tex;
				else if (dBlackSmithUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.dBlackSmith2_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dBlackSmithUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[13].ToString();
				infoTitle.Text = "Black Smith";
			}
			
			else if (GameManager.currentMovableObj.tag == "DApothecary")
			{
				
				infoPB.SetActiveRecursively(true);
				infoRabbit.SetActiveRecursively(true);
				
				upgradeProgressBar dApothecaryUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dApothecaryUPB.currentUpgradeLevel == 1)
					infoImage.renderer.material.mainTexture = infoImageListScript.dApothecary_tex;
				else if (dApothecaryUPB.currentUpgradeLevel == 2)
					infoImage.renderer.material.mainTexture = infoImageListScript.dApothecary_tex;
				else if (dApothecaryUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.dApothecary_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dApothecaryUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[14].ToString();
				infoTitle.Text = "Apothecary";
				
				//Harish chander
				ProgressBarMiniGames miniGamePB  = popUpType2.transform.FindChild("InfoProgressBar").gameObject.GetComponent<ProgressBarMiniGames>();
				
				Transform rabbit =  popUpType2.transform.FindChild("RabbitBackgrnd").transform.FindChild("qRabbitButton") as Transform;
				UIButton RabbitBtn = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				RabbitBtn.scriptWithMethodToInvoke = popUpInfoScript.guiControlInfo;
				getaccelerate = "ApothecaryMiniGame";	
				
				float tot = 120f;
				float tymSvr = (float) (scr_userWorld.ReturnTimefromMiniGameTimes("ApothecaryMiniGame"));
				
				if(tymSvr <= tot && tymSvr != -1)
				{
				miniGamePB.enabled = true;	
				popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(true);
				miniGamePB.seconds = tymSvr	;
						
				miniGamePB.cnt = (int)((tot) - miniGamePB.seconds);
				float remain = ((float)miniGamePB.cnt) / tot;
				miniGamePB.seconds = tot;
						
				
				miniGamePB.progressBarPov.transform.localScale = new Vector3(remain, miniGamePB.progressBarPov.transform.localScale.y, miniGamePB.progressBarPov.transform.localScale.z);
						
			    }
				else
				{
					popUpType2.transform.FindChild("InfoProgressBar").gameObject.SetActiveRecursively(false);
					popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(false);
					miniGamePB.enabled = false;
					
					Debug.Log("Time ::  >>>>>>>>>");
				}
			}
			
			else if (GameManager.currentMovableObj.tag == "DTavern")
			{
				infoPB.SetActiveRecursively(true);
				infoRabbit.SetActiveRecursively(true);
				
				upgradeProgressBar dTavernUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				if (dTavernUPB.currentUpgradeLevel == 1)
					infoImage.renderer.material.mainTexture = infoImageListScript.dTavern_tex;
				else if (dTavernUPB.currentUpgradeLevel == 2)
					infoImage.renderer.material.mainTexture = infoImageListScript.dTavern_tex;
				else if (dTavernUPB.currentUpgradeLevel == 3)
					infoImage.renderer.material.mainTexture = infoImageListScript.dTavern_tex;
				
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dTavernUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[15].ToString();
				infoTitle.Text = "Tavern";
				
				
				//Harish chander
				ProgressBarMiniGames miniGamePB  = popUpType2.transform.FindChild("InfoProgressBar").gameObject.GetComponent<ProgressBarMiniGames>();
				
				
				Transform rabbit =  popUpType2.transform.FindChild("RabbitBackgrnd").transform.FindChild("qRabbitButton") as Transform;
				UIButton RabbitBtn = rabbit.gameObject.GetComponent("UIButton") as UIButton;
				RabbitBtn.scriptWithMethodToInvoke = popUpInfoScript.guiControlInfo;
				getaccelerate = "TavernMiniGame";
				
				float tot = 120f;
				float tymSvr = (float) (scr_userWorld.ReturnTimefromMiniGameTimes("TavernMiniGame"));
				
				if(tymSvr <= tot && tymSvr != -1)
				{
				miniGamePB.enabled = true;	
				popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(true);
				miniGamePB.seconds = tymSvr	;
						
				miniGamePB.cnt = (int)((tot) - miniGamePB.seconds);
				float remain = ((float)miniGamePB.cnt) / tot;
				miniGamePB.seconds = tot;
						
				
				miniGamePB.progressBarPov.transform.localScale = new Vector3(remain, miniGamePB.progressBarPov.transform.localScale.y, miniGamePB.progressBarPov.transform.localScale.z);
						
				}
				else
				{
					popUpType2.transform.FindChild("InfoProgressBar").gameObject.SetActiveRecursively(false);
					popUpType2.transform.FindChild("RabbitBackgrnd").gameObject.SetActiveRecursively(false);
					miniGamePB.enabled = false;
					
					Debug.Log("Time ::  >>>>>>>>>");
				}
			}
			
			else if (GameManager.currentMovableObj.tag == "EarthObelisk")
			{
				upgradeProgressBar earthObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.earthObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + earthObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = buildingInfoString[6].ToString();
				infoTitle.Text = "Earth Obelisk";
			}
			
			else if (GameManager.currentMovableObj.tag == "PlantObelisk")
			{
				upgradeProgressBar plantObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.plantObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + plantObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = "The magic of the Obelisk is all but lost to the known world. Its draws its power from the elements from which it was created and emanates it to the surrounding area. Living creatures within its range feed from its aura, gaining strength and stamina."; //buildingInfoString[7].ToString();
				infoTitle.Text = "Plant Obelisk";
			}
			
			else if (GameManager.currentMovableObj.tag == "WaterObelisk")
			{
				upgradeProgressBar waterObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.waterObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + waterObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = "The magic of the Obelisk is all but lost to the known world. Its draws its power from the elements from which it was created and emanates it to the surrounding area. Living creatures within its range feed from its aura, gaining strength and stamina."; //buildingInfoString[7].ToString();
				//info_spText.Text = buildingInfoString[8].ToString();
				infoTitle.Text = "Water Obelisk";
			}
			
			else if (GameManager.currentMovableObj.tag == "DEarthObelisk")
			{
				upgradeProgressBar dEarthObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.dEarthObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + dEarthObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = "The magic of the Obelisk is all but lost to the known world. Its draws its power from the elements from which it was created and emanates it to the surrounding area. Living creatures within its range feed from its aura, gaining strength and stamina."; //buildingInfoString[7].ToString();
				//info_spText.Text = buildingInfoString[16].ToString();
				infoTitle.Text = "Dark Earth Obelisk";
			}
			
			else if (GameManager.currentMovableObj.tag == "DSwampObelisk")
			{
				upgradeProgressBar swampObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.swampObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + swampObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = "The magic of the Obelisk is all but lost to the known world. Its draws its power from the elements from which it was created and emanates it to the surrounding area. Living creatures within its range feed from its aura, gaining strength and stamina."; //buildingInfoString[7].ToString();
				//info_spText.Text = buildingInfoString[17].ToString();
				infoTitle.Text = "Swamp Obelisk";
			}
			
			else if (GameManager.currentMovableObj.tag == "DFireObelisk")
			{
				upgradeProgressBar fireObeliskUPB = GameManager.currentMovableObj.GetComponent<upgradeProgressBar>();
				
				infoImage.renderer.material.mainTexture = infoImageListScript.fireObelisk_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "Level : " + fireObeliskUPB.currentUpgradeLevel.ToString();
				info_spText.Text = "The magic of the Obelisk is all but lost to the known world. Its draws its power from the elements from which it was created and emanates it to the surrounding area. Living creatures within its range feed from its aura, gaining strength and stamina."; //buildingInfoString[7].ToString();
				//info_spText.Text = buildingInfoString[18].ToString();
				infoTitle.Text = "Fire Obelisk";
			}
			
			else if (worlds[2] == "DirtPath")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dirtPath_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Dirt Path";
			}
			
			else if (worlds[2] == "Barrel")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.barrel_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Barrel";
				info_spText.Text = "For storing Ale of course... what else?";
			}
			
			else if (worlds[2] == "FruitTree")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.fruitTree_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Fruit Tree";
				info_spText.Text = "Fruit orchards were once what the Crest was known for, until of course people discovered our pipeweed.";
			}
			
			else if (worlds[2] == "Lantern")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.lantern_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Lantern";
				info_spText.Text = "The light helps keep out... unwanted guests.";
			}
			
			else if (worlds[2] == "Shroomrey")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.shroomrey_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Shroomrey";
			}
			
			else if (worlds[2] == "Tree")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.tree_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Tree";
				info_spText.Text = "Shade to smoke a pipe under, or perhaps a nice picnic.";
			}
			
			else if (worlds[2] == "Well")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.well_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Well";
				info_spText.Text = "When you don't want to be drinkin the same river water tha's washin' old lady dungis's bloomers...";
			}
			
			else if (worlds[2] == "WheelBurrow")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.wheelBurrow_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Wheel Burrow";
				info_spText.Text = "For the occasion that work might actually have to be done.";
			}
			
			else if (worlds[2] == "Woodpile")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.woodPile_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Woodpile";
				info_spText.Text = "The firewood isn't going to chop itself you know... Nothin like a solid 5 minute's work before second breakfasts.";
			}
			
			else if (worlds[2] == "DDirtPath")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dDirtPath_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Dirt Path";
			}
			
			else if (worlds[2] == "DBog")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dBog_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Bog";
			}
			
			else if (worlds[2] == "DTree")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dTree_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Tree";
			}
			
			else if (worlds[2] == "DWell")
			{
				infoImage.renderer.material.mainTexture = infoImageListScript.dWell_tex;
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
				infoTitle.Text = "Well";
			}
			else
				popUpType2.transform.FindChild("info_Level").gameObject.GetComponent<SpriteText>().Text = "";
		}
	}
	
	private string getaccelerate;
	public string GetAccelerateMiniGameItem()
	{
		return getaccelerate;
	}
	
	void MiniGameRabbitButton()
	{
		popUpInfoScript.defaultPopUpBool = true;
		GameManager.miniGamesaccelerateBool = true;
	    popUpInfoScript.defaultPopUp(58, 2);
	}
	// END OBJECT EDIT MENU
	
	
//====================================================================================================================================
	
	// ITEM BAG PANEL //
	
	void itemBagPanelClick()
	{
		scr_audioController.audio_buttonClick.Play();
		
		itemBagPanelControl itemBagPanelInfo = itemBagPanelUI.GetComponent("itemBagPanelControl") as itemBagPanelControl;
		itemBagPanelInfo.panelMoveIn = false;
		itemBagPanelInfo.panelMoveOut = true;
	}
	 
	// END ITEM BAG PANEL //
	
//====================================================================================================================================
	
	// 	ATTACK PANEL //
	
	void attackButton()
	{
		Debug.Log("attack");
		scr_audioController.audio_Swordclash.Play();
		
		if (GameManager.taskCount == 11)
		{
			Destroy(delArrow);
			
			// attack button spwan
			GameObject arrowSpwan = GameObject.Find("itemBagUI_spwan") as GameObject;
			GameObject arrowTemp = Instantiate(arrow, arrowSpwan.transform.position, Quaternion.Euler(90, -90, 0)) as GameObject;
			delArrow = arrowTemp;
			
			objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
			attackPanelInfo.panelMoveIn = true;
			attackPanelInfo.panelMoveOut = false;
		}
		
		if (GameManager.gameLevel >= 3)
		{
			objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
			attackPanelInfo.panelMoveIn = true;
			attackPanelInfo.panelMoveOut = false;
		}
		
		if (GameManager.gameLevel >= 4)
		{
			popUpInfoScript.taskGoblinCave(2);
			GameManager.readyAttackBool = true;
		}
		
		if (GameManager.gameLevel >= 5)
		{
			popUpInfoScript.taskGoblinCave(2);
			GameManager.readyAttackBool = true;
		}
		
		if (GameManager.gameLevel >= 6)
		{
			popUpInfoScript.taskGoblinCave(2);
			GameManager.readyAttackBool = true;
		}
	}

//=========================================================================================================
	
	// GOBLIN ATTACK CANCLE BUTTON
	void attackCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		Destroy(delArrow);
		objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
		attackPanelInfo.panelMoveIn = true;
		attackPanelInfo.panelMoveOut = false;
		
		if (GameManager.taskCount == 4)
		{
			// find golin home
			GameObject gCamp = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
			gCamp.GetComponent<BoxCollider>().enabled = true;
				
			// create arrow on goblin house
			GameObject gArrow = Instantiate(gameArrow, new Vector3(gCamp.transform.position.x, gCamp.transform.position.y, gCamp.transform.position.z + 5), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
			delArrow = gArrow;
		}	
	}
	
//=========================================================================================================	
	
	// TIME DISPLAY BUTTON //
	
	void timeDisplayButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.taskCount == 14)
		{
			Destroy(delArrow);
			
			GameManager.popUpCount = 20;
			
			popUpInfoScript.curPopUpCnt = 20;
			popUpInfoScript.updateCurPopUpCount();
			
			popUpInfoScript.curPopUpType = 0;
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
		}
	}
	
//=========================================================================================================	
	
	void test()
	{
		
	}
	
//=========================================================================================================	
	
	// SPARK PLACE PANEL //
	void sparkPlaceButton()
	{
		scr_audioController.audio_buttonClick.Play();
	}

//=========================================================================================================
	
	// SPARK CANCLE BUTTONßß
	void sparkCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
	}
	
//=========================================================================================================
	
	// HALFLING FARM RABBIT BUTTON
	
	void farmRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.taskFarming(2, "tempFarm");
		}
	}
	
//=========================================================================================================
	
	// DARKLING FARM RABBIT BUTTON
	
	void darklingFarmRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.gameLevel >= 4)
		{
			popUpInfoScript.taskDarklingFarming(2, "tempDFarm");
		}
	}
	
//=========================================================================================================
	
	// HAFLLING CREATURE RABBIT BUTTON
	void creatureRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.taskCreature(2, "temp");
		}
	}
	
//=========================================================================================================
	
	// DARKLING CREATURE RABBIT BUTTON
	
	void darklingCreatureRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.taskDarklingCreature(2, "temp");
		}
	}
	
//=========================================================================================================
	
	// HAFLING FARM HARVEST
	
	void farmHarvestButton()
	{
		GameManager.oldFood = GameManager.food;
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 2 //
		if (GameManager.gameLevel == 1)
		{
			// task 7
			if (GameManager.taskCount == 5)
			{
				popUpInfoScript.task7(2);
			}
		}
		
		if (GameManager.gameLevel >= 3)
		{
			popUpInfoScript.taskFarming(4, currentHarvestButton.tag);
		}
	}
	
//=========================================================================================================
	
	// DARKLING FARM HARVEST
	
	void darklingFarmHarvestButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel >= 4)
		{
			popUpInfoScript.taskDarklingFarming(4, currentHarvestButton.tag);
		}
	}
	
//=========================================================================================================
	
	// GOBLIN CAVE RABBIT BUTTON
	void goblinCaveRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		popUpInfoScript.taskGoblinCave(4);
	}
	
//=========================================================================================================
	
	// FARM BUTTON
	void PlantingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;
		
		if (GameManager.curPlot.tag == "Plot")
		{
			popUpInfoScript.wall.active = true;
			plantsUI.SetActiveRecursively(true);
		}
		
		else if (GameManager.curPlot.tag == "DPlot")
		{
			popUpInfoScript.wall.active = true;
			darklingPlantUI.SetActiveRecursively(true);
		}
	}
	
//=========================================================================================================
	
	void canclePlantingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
		objPanelInfo.panelMoveIn = true;
		objPanelInfo.panelMoveOut = false;
	}
	
//=========================================================================================================
	
	void farmUpgradeButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject plotCol = GameManager.curPlot.transform.FindChild("Isometric_Collider").gameObject;
		upgradeProgressBar uPB = GameManager.curPlot.GetComponent<upgradeProgressBar>();
		
		if (GameManager.curPlot.tag == "Plot" && plotCol.tag == "editableObj")
		{
			Debug.Log("upgrade --> 1 1 1 1 1");
			if (uPB.currentUpgradeLevel < 3)
			{
				Debug.Log("upgrade --> 2 2 2 2 2 ");
				if (GameManager.gameLevel >= 3)
				{
					Debug.Log("upgrade --> 3 3 3 3 3 3 -- " + GameManager.coins);
					objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
					objPanelInfoFrm.panelMoveIn = true;
					objPanelInfoFrm.panelMoveOut = false;
					
					if(GameManager.coins >= (10 * (GameManager.gameLevel)))
					{
						Debug.Log("upgrade --> 4 4 4 4 4 4 4 4 ");
						GameManager.upgradePlotBool = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(4, 2);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(43, 0);
			}
		}
		else if (GameManager.curPlot.tag == "DPlot" && plotCol.tag == "editableObj")
		{
			if (uPB.currentUpgradeLevel < 3)
			{
				if (GameManager.gameLevel >= 4)
				{
					objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
					objPanelInfoFrm.panelMoveIn = true;
					objPanelInfoFrm.panelMoveOut = false;
					
					if(GameManager.coins >= (10 * (GameManager.gameLevel)))
					{
						GameManager.upgradePlotBool = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(4, 2);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else 
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(43, 0);
			}
		}
		else
		{
			popUpInfoScript.wall.active = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(41, 0);
		}
	}
	
//=========================================================================================================
	
	// Inn Rabbit button
	void innRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildInn(3);
	}
	
//=========================================================================================================
	
	// Stable Rabbit button
	void stableRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildStable(3);
	}
	
//=========================================================================================================
	
	// Stable Rabbit button
	void blacksmithRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildBlackSmith(3);
	}
	
//=========================================================================================================
	
	// Apothecary Rabbit button
	void apothecaryRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildApothecary(3);
	}
	
//=========================================================================================================
	
	// Tavern Rabbit button
	void tavernRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildTavern(3);
	}
	
//=========================================================================================================
	
	// Earth Obelisk Rabbit button
	void earthObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildEarthObelisk(3);
	}
	
//=========================================================================================================
	
	// Plant Obelisk Rabbit button
	void plantObeliskRabbitButton()
	{
	   scr_audioController.audio_buttonClick.Play();	
		popUpInfoScript.taskBuildPlantObelisk(3);
	}
	
//=========================================================================================================
	
	// Water Obelisk Rabbit button
	void waterObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildWaterObelisk(3);
	}
	
//=========================================================================================================
	
	// Sun Shrine Rabbit button
	void sunShrineRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskBuildSunShrine(3);
	}
				
//=========================================================================================================
	
	// darking inn rabbit button
	void darklingInnRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingInn(3);
	}
	
//=========================================================================================================	
	
	// darking Stable rabbit button
	void darklingStableRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingStable(3);
	}
	
//=========================================================================================================
	
	// darkling BlackSmith rabbit button
	 void darklingBlackSmithRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingBlackSmith(3);
	}
	
//=========================================================================================================
	
	// darkling Tavern rabbit button
	 void darklingTavernRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingTavern(3);
	}
	
//=========================================================================================================
	
	// darkling Apothecary rabbit button
	 void darklingApothecaryRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingApothecary(3);
	}
	
//=========================================================================================================
	
	// darkling D Earth Obelisk rabbit button
	 void darklingDEarthObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingEarthObelisk(3);
	}	
	
//=========================================================================================================
	
	// darkling D Swamp Obelisk rabbit button
	 void darklingDSwampObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingSwampObelisk(3);
	}
	
//=========================================================================================================
	
	// darkling D Moon Shrine rabbit button
	 void darklingDMoonShrineRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingMoonShrine(3);
	}
	
//=========================================================================================================
	
	// darkling D Fire Obelisk rabbit button
	 void darklingDFireObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.taskDarklingFireObelisk(3);
	}
	
//=========================================================================================================
	
	
	// Training Ground Upgrage
	void trainingGroundUgrade()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.gameLevel >= 3)
		{
			objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;		
			objEditPanelInfo.panelMoveIn = true;
			objEditPanelInfo.panelMoveOut = false;
		}
				
		// Training Ground Upgrade
		if (GameManager.curTG.tag == "TrainingGround")
		{
			if (GameManager.gameLevel >= 4 && GameManager.earthTG_lvl == 1)
			{
				if(GameManager.coins >= GameManager.EarthTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else if (GameManager.gameLevel >= 8 && GameManager.earthTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.EarthTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
		
		// Plant Training Upgrade
		else if (GameManager.curTG.tag == "PlantTG")
		{
			if (GameManager.gameLevel >= 6 && GameManager.plantTG_lvl == 1)
			{
			    if(GameManager.coins >= GameManager.PlantTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			
			else if (GameManager.gameLevel >= 9 && GameManager.plantTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.PlantTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
		
		// Water Training Ground Upgrade
		if (GameManager.curTG.tag == "WaterTG")
		{
			if (GameManager.gameLevel >= 8 && GameManager.waterTG_lvl == 1)
			{
				if(GameManager.coins >= GameManager.WaterTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
						
			else if (GameManager.gameLevel >= 12 && GameManager.waterTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.WaterTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
		
		// Swamp Training Ground Upgrade
		if (GameManager.curTG.tag == "Swamp")
		{
			if (GameManager.gameLevel >= 7 && GameManager.swampTG_lvl == 1)
			{
				if(GameManager.coins >= GameManager.SwampTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			
			else if (GameManager.gameLevel >= 12 && GameManager.swampTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.SwampTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
		
		// Fire Training Ground Upgrade
		if (GameManager.curTG.tag == "DFireTG")
		{
			if (GameManager.gameLevel >= 9 && GameManager.fireTG_lvl == 1)
			{
				if(GameManager.coins >= GameManager.FireTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			
			else if (GameManager.gameLevel >= 14 && GameManager.fireTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.FireTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
		
		// DEarth Training Ground Upgrade
		if (GameManager.curTG.tag == "DEarthTG")
		{
			if (GameManager.gameLevel >= 8 && GameManager.dEarthTG_lvl == 1)
			{
				if(GameManager.coins >= GameManager.DarkEarthTgGoldlvl2)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			
			else if (GameManager.gameLevel >= 13 && GameManager.dEarthTG_lvl == 2)
			{
				if(GameManager.coins >= GameManager.DarkEarthTgGoldlvl3)
				{
					GameManager.upgradeTrainingGroundBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}	
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(19, 0);
			}
		}
	}
	
//=========================================================================================================
	
	// BURRY SPARK BUTTON
	void burrySparkButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (guiControl.popUpOpenBool == false)
		{
			GameManager.curTG.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
			// LEVEL 1 //
			if (GameManager.gameLevel == 1)
			{
				// task 1
				Destroy(delArrow);
				// pop count 2
				nextPopUpBool = true;
				
				// task 2 
				if (GameManager.taskCount == 2)
				{
					creatureUI.SetActiveRecursively(true);
					
					GameObject arrowSpwan = GameObject.Find("creature01_Spwan") as GameObject;
					GameObject temp = Instantiate(arrow, arrowSpwan.transform.position, Quaternion.Inverse(arrowSpwan.transform.rotation)) as GameObject;
					delArrow = temp;
					temp.transform.parent = arrowSpwan.transform;
					
					objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
					objPanelInfo.panelMoveIn = true;
					objPanelInfo.panelMoveOut = false;
				}
				
			}
		
			if (GameManager.gameLevel >= 3)
			{
				objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;		
				objEditPanelInfo.panelMoveIn = true;
				objEditPanelInfo.panelMoveOut = false;
				
				GameManager.createCreatureBool = true;
				if (GameManager.curTG.tag == "TrainingGround" || GameManager.curTG.tag == "PlantTG" || GameManager.curTG.tag == "WaterTG")
				{
					GameManager.burrySparkBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp (55, 2);
				}
				else if (GameManager.curTG.tag == "Swamp" || GameManager.curTG.tag == "DEarthTG" || GameManager.curTG.tag == "DFireTG")
				{
					GameManager.burrySparkBool = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(55, 2);
				}
			
				objPanelControl objPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
				objPanelInfo.panelMoveIn = true;
				objPanelInfo.panelMoveOut = false;
			
				GameManager.createCreatureBool = true;
			}
		}
	}
	
//=========================================================================================================
	
	// earth training ground rabbit button
	void earthTGRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(6, 2);
		
	}
	
//=========================================================================================================
	
	void upgradeInnRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeInnRabbit = true;
		GameManager.upgradeInn = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeHHouseRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeHHouseRabbit = true;
		GameManager.upgradeHHouse = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeDHouseRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeDHouseRabbit = true;
		GameManager.upgradeDHouse = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeStableRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeStableRabbit = true;
		GameManager.upgradeStable = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeBlackSmithRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeBlackSmithRabbit = true;
		GameManager.upgradeBlackSmith = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeDarklingInnRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeDInnRabbit = true;
		GameManager.upgradeDInn = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeEarthObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeEarthObeliskRabbit = true;
		GameManager.upgradeEarthObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradePlantObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradePlantObeliskRabbit = true;
		GameManager.upgradePlantObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeWaterObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeWaterObeliskRabbit = true;
		GameManager.upgradeWaterObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeSwampObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeSwampObeliskRabbit = true;
		GameManager.upgradeSwampObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeDEarthObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeDEarthObeliskRabbit = true;
		GameManager.upgradeDEarthObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeFireObeliskRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeFireObeliskRabbit = true;
		GameManager.upgradeFireObelisk = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeDarklingStableRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeDStableRabbit = true;
		GameManager.upgradeDStable = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	void upgradeDarklingBlackSmithRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(35, 2);
		GameManager.upgradeDBlackSmithRabbit = true;
		GameManager.upgradeDBlackSmith = false;
		GameManager.curTG = null;
		GameManager.curCave = null;
		GameManager.curPlot = null;
	}
	
//=========================================================================================================
	
	// plot rappid button
	
	void plotRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameManager.upgradePlotRabbitBool = true;
		popUpInfoScript.wall.active = true;
		popUpInfoScript.defaultPopUpBool = true;
		popUpInfoScript.defaultPopUp(33, 2);
	}

//=======================================================================================================//	
	
	// DARKLING MENU //
	
	// darkling Store
	void storeDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		if (GameManager.unlockDarklingBool)
		{
			popUpInfoScript.wall.active = true;
			storeHDUI.SetActiveRecursively(false);
			darklingStoreUI.SetActiveRecursively(true);
			EnableDarkling(DarklingUIbtn,true);   //harish 
			
			if (GameObject.Find("Main Camera").transform.position.x < 40f)
				GameObject.Find("Main Camera").transform.position = GameObject.Find("darklingHouse_cPos").transform.position;
		}
	}
	
	// darkling store cancle
	void storeDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingStoreUI.SetActiveRecursively(false);
	}
	
//===============================================================================================================================================================================
	
	// DARKLING DECORATION
	
	void decorationDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(false);
		darklingDecorationUI.SetActiveRecursively(true);
	}
	
	// plate 1 darkling dirth path
	void darklingDecoration01Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 4)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingDirtPath.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dDirtPathCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDDirtPath();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}	
		}
	}
	
	// plate 2 darkling tree
	void darklingDecoration02Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 4)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingTree1.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dTreeCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDTree();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}	
		}
	}
	
	// plate 3 darkling well
	void darklingDecoration03Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 4)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingWell.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dWellCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDWell();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 4 bog
	void darklingDecoration04Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingBog.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dBogCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDBog();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 5 Raven Perch
	void darklingDecoration05Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingRavenPerch.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dRavenPerchCost.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDRevenPerch();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 6 Bird House
	void darklingDecoration06Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingBirdHouse.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dbirdhouse.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDBirdHouse();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 7 Wind Mill
	void darklingDecoration07Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingWindmill.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.windmill.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDWindMill();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 8 Hunting Tent
	void darklingDecoration08Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingHuntingtent.objTypeId))
			{

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDHuntingTent();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 9 Scarecrow
	void darklingDecoration09Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingScarecrow.objTypeId))
			{
//				GameManager.objectCost = scrObjectCost.dscarecrow.GetComponent<SpriteText>().Text;
//				GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), grid.curObj.transform.position,
//				                                     Quaternion.Euler(90,0,0)) as GameObject;

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDScareCrow();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 10 Stone Fence
	void darklingDecoration10Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingFence.objTypeId))
			{
				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDStoneFence();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// plate 11 Swamp Knoll
	void darklingDecoration11Button()
	{
		scr_audioController.audio_buttonClick.Play();
		// LEVEL 3 and above
		if (GameManager.gameLevel >= 5)
		{
			if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingKnollhill.objTypeId))
			{

				GameManager.panelAccessBool = false;
				popUpInfoScript.wall.active = false;
				darklingDecorationUI.SetActiveRecursively(false);
				
				GameManager.multipleDecorationBool = true;
				objectSelection.objectSelectionBool = false;
				createDSwampKnoll();
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(18, 0);
			}
		}
	}
	
	// darkling decoration cancle
	void decorationDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingDecorationUI.SetActiveRecursively(false);
		darklingStoreUI.SetActiveRecursively(true);
	}
	
	
//===============================================================================================================================================================================
	
	
	// DARKLING BUILDING
	
	void buildingDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(false);
		darklingBuildingUI.SetActiveRecursively(true);
	}
	
	// plate 01 darkling plot
	void darklingBuilding01Button()
	{
		scr_audioController.audio_buttonClick.Play();
		dPlotCnt = GameObject.FindGameObjectsWithTag("DPlot");
		
		
		if (GameManager.gameLevel >= 4)
		{
			popUpInfoScript.wall.active = false;
			darklingBuildingUI.SetActiveRecursively(false);
			
			if (GameManager.placeDGardenPlotBool)
			{
			 	if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingGarden.objTypeId))
				{
					GameManager.panelAccessBool = false;
					objectSelection.objectSelectionBool = false;
					popUpInfoScript.taskDarklingPlot(1);
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(20, 0);
			}
		}
	}
	
	// plate 02 darkling inn
	void darklingBuilding02Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dInnObj = GameObject.Find("DL_B_Inn_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		// LEVEL 3 and above
		
		if (GameManager.dBuildingConstructBool)
		{
			if (dInnObj == null)
			{
				if (GameManager.gameLevel >= 4)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarkLingInn.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingInn(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// plate 03 darkling Apothecary
	void darklingBuilding03Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dApothecaryObj = GameObject.Find("DL_B_Apothecary_GO(Clone)") as GameObject;
		// LEVEL 3 and above
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		
		if (GameManager.dBuildingConstructBool)
		{
			if (dApothecaryObj == null)
			{
				if (GameManager.gameLevel >= 10)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingApothecary.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingApothecary(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// plate 04 darkling Stable
	void darklingBuilding04Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dStableObj = GameObject.Find("DL_B_Stable_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dStableObj == null)
			{
				if (GameManager.gameLevel >= 5)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarkingStable.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingStable(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// plate 05 darkling Blacksmith
	void darklingBuilding05Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dBlackSmithObj = GameObject.Find("DL_B_DBlackSmith_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dBlackSmithObj == null)
			{
				if (GameManager.gameLevel >= 6)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingSmith.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingBlackSmith(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// plate 06 darkling Tavern
	void darklingBuilding06Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dTavernObj = GameObject.Find("DL_B_Tavern_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dTavernObj == null)
			{
				if (GameManager.gameLevel >= 9)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingtavern.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingTavern(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}

	// plate 10 Moon Shrine
	void darklingBuilding10Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dMoonShrineObj = GameObject.Find("DL_B_MoonShrine_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingBuildingUI.SetActiveRecursively(false);
		
		if (GameManager.dBuildingConstructBool)
		{
			if (dMoonShrineObj == null)
			{
				if (GameManager.gameLevel >= 12)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objMoonShrine.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingMoonShrine(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// darkling building cancle
	void buildingDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingBuildingUI.SetActiveRecursively(false);
		darklingStoreUI.SetActiveRecursively(true);
	}
	
//===============================================================================================================================================================================
	
	// DARKLING CREATURE
	
	void creatureDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(false);
		darklingCreatureUI.SetActiveRecursively(true);
	}
	
	// plate 01 darkling Leech
	public void darklingCreature01Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject checkLeech = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 4 && GameManager.burrySparkBool) 
		{
			if (GameManager.curTG.tag == "Swamp")
			{
				if (checkLeech == null)
				{
					if (GameManager.swampTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objLeech.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "Leech");
							GameManager.swampTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
		
	// plate 02 darkling Leshy
	void darklingCreature02Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 7)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
		
		
	}
	
	// plate 03 darkling Lurker
	void darklingCreature03Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 12)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// plate 04 darkling dark hound
	public void darklingCreature04Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject checkDHound = GameObject.Find("DL_C_DHound_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 5 && GameManager.burrySparkBool) 
		{
			if (GameManager.curTG.tag == "DEarthTG")
			{
				if (checkDHound == null)
				{
					if (GameManager.dEarthTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklinghound.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "DHound");
							GameManager.dEarthTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
	
	// plate 05 darkling Fenrir
	void darklingCreature05Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 8)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// plate 06 darkling Hell Hound
	void darklingCreature06Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 13)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// plate 07 darkling Sprite
	public void darklingCreature07Button()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject checkSprite = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		if (GameManager.gameLevel >= 6 && GameManager.burrySparkBool)
		{
			if (GameManager.curTG.tag == "DFireTG")
			{
				if (checkSprite == null)
				{
					if (GameManager.fireTG_Creature_Cnt < 2)
					{
						if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingSprite.objTypeId))
						{
							popUpInfoScript.taskCreature(1, "Sprite");
							GameManager.fireTG_Creature_Cnt++;
						}
						else
						{
							popUpInfoScript.wall.active = true;
							popUpInfoScript.defaultPopUpBool = true;
							popUpInfoScript.defaultPopUp(18, 0);
						}
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(50, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(38, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(42, 0);
			}
		}
	}
	
	// plate 08 darkling Imp
	void darklingCreature08Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 9)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// plate 09 darkling Djinn
	void darklingCreature09Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingCreatureUI.SetActiveRecursively(false);
		
		objPanelControl sparkPanelInfo = GameObject.Find("SparkPlacePanel").GetComponent("objPanelControl") as objPanelControl;
		sparkPanelInfo.panelMoveIn = true;
		sparkPanelInfo.panelMoveOut = false;
		
		if (GameManager.gameLevel >= 14)
		{
			popUpInfoScript.wall.active = true;
			FeedMorphPopUp.SetActiveRecursively(true);
		}
	}
	
	// darkling creature cancle
	void creatureDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		popUpInfoScript.wall.active = true;
		darklingCreatureUI.SetActiveRecursively(false);
		darklingStoreUI.SetActiveRecursively(true);
	}
	
	
//===============================================================================================================================================================================
	
	
	// DARKLING TRAINING GROUND //
	
	void trainingGroundDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(false);
		darklingTrainingGroundUI.SetActiveRecursively(true);

		// check training ground is already present
		GameObject dSwampTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
		GameObject dEarthTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
		GameObject dFireTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
		
		if (dSwampTG == null)
			dSwampTG_block.SetActive(false);
		else
			dSwampTG_block.SetActive(true);
		
		if (dEarthTG == null)
			dEarthTG_block.SetActive(false);
		else
			dEarthTG_block.SetActive(true);
		
		if (dFireTG == null)
			dFireTG_block.SetActive(false);
		else
			dFireTG_block.SetActive(true);
	}
	
	// swamp training ground
	void darklingTrainingGround_01_Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingTrainingGroundUI.SetActiveRecursively(false);
		// LEVEL 4 //
		
		CreateTrainingGround(gameManagerInfo.tg_Swamp_PF, 4, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objSwampTrainingGrnd.objTypeId), "DL_TG_Swamp_GO(Clone)");
	}
	
	// Earth training ground
	void darklingTrainingGround_02_Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingTrainingGroundUI.SetActiveRecursively(false);
		
		// LEVEL 5 //
		CreateTrainingGround(gameManagerInfo.tg_DEarth_PF, 5, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarkearthTrainingGrnd.objTypeId), "DL_TG_Earth_GO(Clone)");
	}
	
	// Fire training ground
	void darklingTrainingGround_03_Button()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingTrainingGroundUI.SetActiveRecursively(false);
		
		// LEVEL 4 //
		CreateTrainingGround(gameManagerInfo.tg_DFire_PF, 5, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingFireTrainingGrnd.objTypeId), "DL_TG_Fire_GO(Clone)");
	}
	
	// darkling training ground cancle
	void trainingGroundDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingTrainingGroundUI.SetActiveRecursively(false);
	}
	
	void defenceDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingDefenceUI.SetActiveRecursively(false);
	}
	
//===============================================================================================================================================================================
	
	// DARKLING PLANT
	
	void plantDarklingButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingStoreUI.SetActiveRecursively(false);
		//darklingPlantUI.SetActiveRecursively(true);
		darklingDefenceUI.SetActiveRecursively(true);
	}
	
	// plate 01 pumpkin farm
	void darklingPlant_01_Button()
	{
		plantButtonDarkling(4, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingPumpkin.objTypeId),
		                    "DPumpkin", scrObjectCost.dPumpkinCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 02 Fire Pepper farm
	void darklingPlant_02_Button()
	{
		plantButtonDarkling(5, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingFirePepper.objTypeId),
		                    "DFirePepper", scrObjectCost.dFirePeperCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 03 Columbine farm
	void darklingPlant_03_Button()
	{
		plantButtonDarkling(11, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingColumbine.objTypeId),
		                    "DColumbine", scrObjectCost.dColumbineCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 04 Black Berry farm
	void darklingPlant_04_Button()
	{
		plantButtonDarkling(10, 1, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingBlackberry.objTypeId),
		                    "DBlackBerry", scrObjectCost.dBlackBerryCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 05 Aven farm
	void darklingPlant_05_Button()
	{
		plantButtonDarkling(7, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingAvenHerb.objTypeId),
		                    "DAven", scrObjectCost.dAvenCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 06 BitterBush
	void darklingPlant_06_Button()
	{
		plantButtonDarkling(12, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingBitterbush.objTypeId),
		                    "BitterBrush", scrObjectCost.dBitterBushCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 07 Bog Bean
	void darklingPlant_07_Button()
	{
		plantButtonDarkling(13, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingHerbBogbean.objTypeId),
		                    "BogBean", scrObjectCost.dPumpkinCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 08 Wolfsbane
	void darklingPlant_08_Button()
	{
		plantButtonDarkling(14, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingHerbWolfbane.objTypeId),
		                    "Wolfsbane", scrObjectCost.dWolfsbaneCost.GetComponent<SpriteText>().Text);
	}
	
	// plate 09 Moonflower
	void darklingPlant_09_Button()
	{
		plantButtonDarkling(12, 2, scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingMoonFlower.objTypeId),
		                    "Moonflower", scrObjectCost.dMoonflowerCost.GetComponent<SpriteText>().Text);
	}
	
	// darkling plant cancle
	void plantDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		darklingPlantUI.SetActiveRecursively(false);
		darklingStoreUI.SetActiveRecursively(true);
	}
	
//===============================================================================================================================================================================
	
	// DARKLING TREASURE
	
	void treasureDarklingCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		darklingTreasureUI.SetActiveRecursively(false);
	}
	
//===============================================================================================================================================================================	
	
	private int InitialTypeId;
	public int GetInitialId()
	{
		return InitialTypeId;
	}
	
	
	void CreatureFeedTutorial()
	{
		//GameObject gStory = GameObject.Find("FightingTutorial");
		//gStory.GetComponent<AutoSpeak>().callToWriteText("To level up your creatures you need to feed the creatures with food you grow .");
		
		GameObject arrowHand = Resources.Load("gameArrowPF") as GameObject;
		GameObject HandObj = Instantiate(arrowHand) as GameObject;
		
		HandObj.transform.localPosition = new Vector3(-55.00401f,13,96f);
		HandObj.transform.localRotation = Quaternion.Euler(-90f,0,0);
		HandObj.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
	
	}
	
	void CreatureMorphTutorial()					
	{
		
		GameObject gStory = GameObject.Find("FightingTutorial");
		gStory.GetComponent<AutoSpeak>().callToWriteText("Morphing helps you to grow your creature bigger by investing sparks.");
		
		GameObject arrowHand = Resources.Load("gameArrowPF") as GameObject;
		GameObject HandObj = Instantiate(arrowHand) as GameObject;
		
		HandObj.transform.localPosition = new Vector3(-46.14207f,13,96f);
		HandObj.transform.localRotation = Quaternion.Euler(-90f,0,0);
		HandObj.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
	}
	
	// CREATURE 01 BUTTON
	void creature01Button()
	{
		popUpOpenBool = true;
		
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 6)
		{
			popUpInfoScript.feedTutorial(4);
			if(PlayerPrefs.GetInt("feedtuts")!=1)						//SUMIT
			{
				Debug.Log("Feed tutorial is running");
				feedMorphTutorial = true;
				CreatureFeedTutorial();
			}
		}
		
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 7)
			popUpInfoScript.renameCreatureTutorial(3);
		
		Debug.Log("Feed tutorial is running.........");	
		
		
		
		scr_audioController.audio_buttonClick.Play();
		
		objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;		
		objEditPanelInfo.panelMoveIn = true;
		objEditPanelInfo.panelMoveOut = false;
		
		Feedbtn = GameObject.Find("UIElements").transform.FindChild("PopUps").transform.FindChild("Feed_Morph").transform.FindChild("FeedButt").gameObject;
		Morphbtn = GameObject.Find("UIElements").transform.FindChild("PopUps").transform.FindChild("Feed_Morph").transform.FindChild("MorphButt").gameObject;
		
		
		GameManager.currentCreature = GameManager.curCreature01;
		Debug.Log("-----> " + GameManager.currentCreature);
		GameObject informationTxt = null;
		
		if (GameManager.currentCreature.tag == "Hound")
		{
			Debug.Log("-> 1 : Hound " + GameManager.houndUsingBool);
			if (GameManager.houndUsingBool == false)
			{
				Debug.Log("-> 2 GameManager.houndUsingBool == false");
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objHound.objTypeId),scr_gameObjsvr.objHound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objHound.objTypeId;
				
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.houndName; //"Hound";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Hound;

				if (GameManager.hound_lvl == 0)
					GameManager.hound_lvl = 1;

				creatureSystemInfo.level_spText.Text = GameManager.hound_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[09];


				
				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().bargCost.GetComponent<SpriteText>().Text;
				//Debug.Log("morph : " + Morphbtn.gameObject.transform.FindChild("morphTxt").gameObject.GetComponent<SpriteText>().Text);
				Debug.Log("i m here...");
				
				scr_audioController.audio_hound.Play();
				scr_audioController.audio_hound.minDistance = 1;
				scr_audioController.audio_hound.maxDistance = 300;
				scr_audioController.audio_hound.volume = 0.7f;
				
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Barg")
		{
			if (GameManager.bargUsingBool == false)
			{
				
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objBarg.objTypeId),scr_gameObjsvr.objBarg.objTypeId);
				InitialTypeId = scr_gameObjsvr.objBarg.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.bargName; //"Barg";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Barg;
				
				creatureSystemInfo.level_spText.Text = GameManager.barg_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[10];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().cusithCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_barg.Play();
				scr_audioController.audio_barg.minDistance = 1;
				scr_audioController.audio_barg.maxDistance = 300;
				scr_audioController.audio_barg.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Cusith")
		{
			if (GameManager.cusithUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objCusith.objTypeId),scr_gameObjsvr.objCusith.objTypeId);
				InitialTypeId = scr_gameObjsvr.objCusith.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.cusithName; //"Cusith";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Cusith;
				
				creatureSystemInfo.level_spText.Text = GameManager.cusith_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[11];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
			    scr_audioController.audio_cusith.Play();
				scr_audioController.audio_cusith.minDistance = 1;
				scr_audioController.audio_cusith.maxDistance = 300;
				scr_audioController.audio_cusith.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprout")
		{
			if (GameManager.sproutUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objSprout.objTypeId),scr_gameObjsvr.objSprout.objTypeId);
				InitialTypeId = scr_gameObjsvr.objSprout.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.sproutName; //"Sprout";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Sprout;

				Debug.Log("1------> " + GameManager.sprout_lvl);

				if (GameManager.sprout_lvl == 0)
					creatureSystemInfo.level_spText.Text = "1";
				else
					creatureSystemInfo.level_spText.Text = GameManager.sprout_lvl.ToString();

				Debug.Log("2------> " + GameManager.sprout_lvl.ToString());
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[12];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().nymphCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_sprout.Play();
				scr_audioController.audio_sprout.minDistance = 1;
				scr_audioController.audio_sprout.maxDistance = 300;
				scr_audioController.audio_sprout.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Nymph")
		{
			if (GameManager.nymphUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objNymph.objTypeId),scr_gameObjsvr.objNymph.objTypeId);
				InitialTypeId = scr_gameObjsvr.objNymph.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.nymphName; //"Nymph";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Nymph;
				
				creatureSystemInfo.level_spText.Text = GameManager.nymph_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[13];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dryadCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_nymph.Play();
				scr_audioController.audio_nymph.minDistance = 1;
				scr_audioController.audio_nymph.maxDistance = 300;
				scr_audioController.audio_nymph.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Dryad")
		{
			if (GameManager.dryadUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDryad.objTypeId),scr_gameObjsvr.objDryad.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDryad.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.dryadName; //"Dryad";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Dryad;
				
				creatureSystemInfo.level_spText.Text = GameManager.dryad_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[14];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_dryad.Play();
				scr_audioController.audio_dryad.minDistance = 1;
				scr_audioController.audio_dryad.maxDistance = 300;
				scr_audioController.audio_dryad.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Nix")
		{
			if (GameManager.nixUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objNix.objTypeId),scr_gameObjsvr.objNix.objTypeId);
				InitialTypeId = scr_gameObjsvr.objNix.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.nixName; //"Nix";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Nix;
				
				creatureSystemInfo.level_spText.Text = GameManager.nix_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[15];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().draugCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_nix.Play();
				scr_audioController.audio_nix.minDistance = 1;
				scr_audioController.audio_nix.maxDistance = 300;
				scr_audioController.audio_nix.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Draug")
		{
			if (GameManager.draugUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDraug.objTypeId),scr_gameObjsvr.objDraug.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDraug.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.draugName; //"Draug";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Draug;
				
				creatureSystemInfo.level_spText.Text = GameManager.draug_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[16];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dragonCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_draugh.Play();
				scr_audioController.audio_draugh.minDistance = 1;
				scr_audioController.audio_draugh.maxDistance = 300;
				scr_audioController.audio_draugh.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Dragon")
		{
			if (GameManager.dragonUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDragon.objTypeId),scr_gameObjsvr.objDragon.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDragon.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.dragonName; //"Dragon";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Dragon;
				
				creatureSystemInfo.level_spText.Text = GameManager.dragon_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[17];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_dragon.Play();
				scr_audioController.audio_dragon.minDistance = 1;
				scr_audioController.audio_dragon.maxDistance = 300;
				scr_audioController.audio_dragon.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "DHound")
		{
			if (GameManager.dHoundUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklinghound.objTypeId),scr_gameObjsvr.objDarklinghound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklinghound.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.dHoundName; //"Dark Hound";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_DHound;
				
				creatureSystemInfo.level_spText.Text = GameManager.dHound_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[00];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dFenrirCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_darkhound.Play();
				scr_audioController.audio_darkhound.minDistance = 1;
				scr_audioController.audio_darkhound.maxDistance = 300;
				scr_audioController.audio_darkhound.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Fenrir")
		{
			if (GameManager.fenrirUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingFenrir.objTypeId),scr_gameObjsvr.objDarklingFenrir.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingFenrir.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.fenrirName; //"Fenrir";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Fenrir;
				
				creatureSystemInfo.level_spText.Text = GameManager.fenrir_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[01];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dHellHoundCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_fenrir.Play();
				scr_audioController.audio_fenrir.minDistance = 1;
				scr_audioController.audio_fenrir.maxDistance = 300;
				scr_audioController.audio_fenrir.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "HellHound")
		{
			if (GameManager.hellHoundUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingHellhound.objTypeId),scr_gameObjsvr.objDarklingHellhound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingHellhound.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.hellHoundName; //"Hell Hound";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_HellHound;
				
				creatureSystemInfo.level_spText.Text = GameManager.hellHound_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[02];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_hellhound.Play();
				scr_audioController.audio_hellhound.minDistance = 1;
				scr_audioController.audio_hellhound.maxDistance = 300;
				scr_audioController.audio_hellhound.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprite")
		{
			if (GameManager.spriteUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingSprite.objTypeId),scr_gameObjsvr.objDarklingSprite.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingSprite.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.spriteName; //"Sprite";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Sprite;
				
				creatureSystemInfo.level_spText.Text = GameManager.sprite_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[03];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dImpCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_sprite.Play();
				scr_audioController.audio_sprite.minDistance = 1;
				scr_audioController.audio_sprite.maxDistance = 300;
				scr_audioController.audio_sprite.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Imp")
		{
			if (GameManager.impUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingImp.objTypeId),scr_gameObjsvr.objDarklingImp.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingImp.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.impName; //"Imp";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Imp;
				
				creatureSystemInfo.level_spText.Text = GameManager.imp_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[04];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dDjinnCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_imp.Play();
				scr_audioController.audio_imp.minDistance = 1;
				scr_audioController.audio_imp.maxDistance = 300;
				scr_audioController.audio_imp.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Djinn")
		{
			if (GameManager.djinnUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingDjInn.objTypeId),scr_gameObjsvr.objDarklingDjInn.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingDjInn.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.djinnName; //"Djinn";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Djinn;
				
				creatureSystemInfo.level_spText.Text = GameManager.djinn_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[05];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_Djinn.Play();
				scr_audioController.audio_Djinn.minDistance = 1;
				scr_audioController.audio_Djinn.maxDistance = 300;
				scr_audioController.audio_Djinn.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leech")
		{
			if (GameManager.leechUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objLeech.objTypeId),scr_gameObjsvr.objLeech.objTypeId);
				InitialTypeId = scr_gameObjsvr.objLeech.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.leechName; //"Leech";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Leech;
				
				creatureSystemInfo.level_spText.Text = GameManager.leech_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[06];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dLeshyCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_leech.Play();
				scr_audioController.audio_leech.minDistance = 1;
				scr_audioController.audio_leech.maxDistance = 300;
				scr_audioController.audio_leech.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leshy")
		{
			if (GameManager.leshyUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingLeshy.objTypeId),scr_gameObjsvr.objDarklingLeshy.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingLeshy.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.leshyName; //"Leshy";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Leshy;
				
				creatureSystemInfo.level_spText.Text = GameManager.leshy_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[07];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dLurkerCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_leshy.Play();
				scr_audioController.audio_leshy.minDistance = 1;
				scr_audioController.audio_leshy.maxDistance = 300;
				scr_audioController.audio_leshy.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Lurker")
		{
			if (GameManager.lurkerUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingLurker.objTypeId),scr_gameObjsvr.objDarklingLurker.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingLurker.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				informationTxt = GameObject.Find("Feed_Morph").gameObject.transform.FindChild("informationTxt").gameObject;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = gameManagerInfo.lurkerName; //"Lurker";
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Lurker;
				
				creatureSystemInfo.level_spText.Text = GameManager.lurker_lvl.ToString();
				informationTxt.GetComponent<SpriteText>().Text = creatureInfoString[08];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_lurker.Play();
				scr_audioController.audio_lurker.minDistance = 1;
				scr_audioController.audio_lurker.maxDistance = 300;
				scr_audioController.audio_lurker.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		
		confirmButton.active = false;
		creatureNameTF.gameObject.active = false;
		renameTxt.active = false;
		cancleButton.active = false;
		
		if (GameManager.taskCount == 6)
			GameObject.Find("RenameCreatureNameUI").gameObject.SetActiveRecursively(false);
	}
	
//===============================================================================================================================================================================	
	
	// CREATURE 02 BUTTON
	void creature02Button()
	{
		scr_audioController.audio_buttonClick.Play();
		
		objPanelControl objEditPanelInfo = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;		
		objEditPanelInfo.panelMoveIn = true;
		objEditPanelInfo.panelMoveOut = false;
		
		Feedbtn = GameObject.Find("UIElements").transform.FindChild("PopUps").transform.FindChild("Feed_Morph").transform.FindChild("FeedButt").gameObject;
		Morphbtn = GameObject.Find("UIElements").transform.FindChild("PopUps").transform.FindChild("Feed_Morph").transform.FindChild("MorphButt").gameObject;
		
		GameManager.currentCreature = GameManager.curCreature02;
		
		if (GameManager.currentCreature.tag == "Hound")
		{
			if (GameManager.houndUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objHound.objTypeId),scr_gameObjsvr.objHound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objHound.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.hound.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.barg.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Hound;
							
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = "Hound";
				creatureSystemInfo.level_spText.Text = GameManager.hound_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[09];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().bargCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_hound.Play();
				scr_audioController.audio_hound.minDistance = 1;
				scr_audioController.audio_hound.maxDistance = 300;
				scr_audioController.audio_hound.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Barg")
		{
			if (GameManager.bargUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objBarg.objTypeId),scr_gameObjsvr.objBarg.objTypeId);
				InitialTypeId = scr_gameObjsvr.objBarg.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.barg.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.cusith.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Barg;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = "Barg";
				creatureSystemInfo.level_spText.Text = GameManager.barg_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[10];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().cusithCost.GetComponent<SpriteText>().Text;

				scr_audioController.audio_barg.Play();
				scr_audioController.audio_barg.minDistance = 1;
				scr_audioController.audio_barg.maxDistance = 300;
				scr_audioController.audio_barg.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Cusith")
		{
			if (GameManager.cusithUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objCusith.objTypeId),scr_gameObjsvr.objCusith.objTypeId);
				InitialTypeId = scr_gameObjsvr.objCusith.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.cusith.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Cusith;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Earth";
				creatureSystemInfo.creatureName_spText.Text = "Cusith";
				creatureSystemInfo.level_spText.Text = GameManager.cusith_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[11];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_cusith.Play();
				scr_audioController.audio_barg.minDistance = 1;
				scr_audioController.audio_barg.maxDistance = 300;
				scr_audioController.audio_barg.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprout")
		{
			if (GameManager.sproutUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objSprout.objTypeId),scr_gameObjsvr.objSprout.objTypeId);
				InitialTypeId = scr_gameObjsvr.objSprout.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.sprout.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.nymph.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Sprout;
				creatureSystemInfo.info_spText.Text = creatureInfoString[12];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().nymphCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = "Sprout";
				creatureSystemInfo.level_spText.Text = GameManager.sprout_lvl.ToString();
				
				scr_audioController.audio_sprout.Play();
				scr_audioController.audio_sprout.minDistance = 1;
				scr_audioController.audio_sprout.maxDistance = 300;
				scr_audioController.audio_sprout.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Nymph")
		{
			if (GameManager.nymphUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objNymph.objTypeId),scr_gameObjsvr.objNymph.objTypeId);
				InitialTypeId = scr_gameObjsvr.objNymph.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.nymph.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.dryad.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Nymph;
				creatureSystemInfo.info_spText.Text = creatureInfoString[13];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dryadCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = "Nymph";
				creatureSystemInfo.level_spText.Text = GameManager.nymph_lvl.ToString();
				
				scr_audioController.audio_nymph.Play();
				scr_audioController.audio_nymph.minDistance = 1;
				scr_audioController.audio_nymph.maxDistance = 300;
				scr_audioController.audio_nymph.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Dryad")
		{
			if (GameManager.dryadUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDryad.objTypeId),scr_gameObjsvr.objDryad.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDryad.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.dryad.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Dryad;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Plant";
				creatureSystemInfo.creatureName_spText.Text = "Dryad";
				creatureSystemInfo.level_spText.Text = GameManager.dryad_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[14];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_dryad.Play();
				scr_audioController.audio_dryad.minDistance = 1;
				scr_audioController.audio_dryad.maxDistance = 300;
				scr_audioController.audio_dryad.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
			
		}
		else if (GameManager.currentCreature.tag == "Nix")
		{
			if (GameManager.nixUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objNix.objTypeId),scr_gameObjsvr.objNix.objTypeId);
				InitialTypeId = scr_gameObjsvr.objNix.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.nix.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.draug.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Nix;
				creatureSystemInfo.info_spText.Text = creatureInfoString[15];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dDjinnCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = "Nix";
				creatureSystemInfo.level_spText.Text = GameManager.nix_lvl.ToString();
				
				scr_audioController.audio_nix.Play();
				scr_audioController.audio_nix.minDistance = 1;
				scr_audioController.audio_nix.maxDistance = 300;
				scr_audioController.audio_nix.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Draug")
		{
			if (GameManager.draugUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDraug.objTypeId),scr_gameObjsvr.objDraug.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDraug.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.draug.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.dragon.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Draug;
				creatureSystemInfo.info_spText.Text = creatureInfoString[16];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dragonCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = "Draug";
				creatureSystemInfo.level_spText.Text = GameManager.draug_lvl.ToString();
				
				scr_audioController.audio_draugh.Play();
				scr_audioController.audio_draugh.minDistance = 1;
				scr_audioController.audio_draugh.maxDistance = 300;
				scr_audioController.audio_draugh.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Dragon")
		{
			if (GameManager.dragonUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDragon.objTypeId),scr_gameObjsvr.objDragon.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDragon.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.dragon.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Dragon;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Water";
				creatureSystemInfo.creatureName_spText.Text = "Dragon";
				creatureSystemInfo.level_spText.Text = GameManager.dragon_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[17];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_dragon.Play();
				scr_audioController.audio_dragon.minDistance = 1;
				scr_audioController.audio_dragon.maxDistance = 300;
				scr_audioController.audio_dragon.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "DHound")
		{
			if (GameManager.dHoundUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklinghound.objTypeId),scr_gameObjsvr.objDarklinghound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklinghound.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.dHound.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.fenrir.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_DHound;
				creatureSystemInfo.info_spText.Text = creatureInfoString[00];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dFenrirCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = "Dark Hound";
				creatureSystemInfo.level_spText.Text = GameManager.dHound_lvl.ToString();
				
				
				scr_audioController.audio_darkhound.Play();
				scr_audioController.audio_darkhound.minDistance = 1;
				scr_audioController.audio_darkhound.maxDistance = 300;
				scr_audioController.audio_darkhound.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Fenrir")
		{
			if (GameManager.fenrirUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingFenrir.objTypeId),scr_gameObjsvr.objDarklingFenrir.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingFenrir.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.fenrir.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.hellHound.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Fenrir;
				creatureSystemInfo.info_spText.Text = creatureInfoString[01];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dHellHoundCost.GetComponent<SpriteText>().Text;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = "Fenrir";
				creatureSystemInfo.level_spText.Text = GameManager.fenrir_lvl.ToString();
				
				scr_audioController.audio_fenrir.Play();
				scr_audioController.audio_fenrir.minDistance = 1;
				scr_audioController.audio_fenrir.maxDistance = 300;
				scr_audioController.audio_fenrir.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "HellHound")
		{
			if (GameManager.hellHoundUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingHellhound.objTypeId),scr_gameObjsvr.objDarklingHellhound.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingHellhound.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.hellHound.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_HellHound;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Dark Earth";
				creatureSystemInfo.creatureName_spText.Text = "Hell Hound";
				creatureSystemInfo.level_spText.Text = GameManager.hellHound_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[02];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_hellhound.Play();
				scr_audioController.audio_hellhound.minDistance = 1;
				scr_audioController.audio_hellhound.maxDistance = 300;
				scr_audioController.audio_hellhound.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprite")
		{
			if (GameManager.spriteUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingSprite.objTypeId),scr_gameObjsvr.objDarklingSprite.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingSprite.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.sprite.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.imp.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Sprite;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = "Sprite";
				creatureSystemInfo.level_spText.Text = GameManager.sprite_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[03];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dImpCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_sprite.Play();
				scr_audioController.audio_sprite.minDistance = 1;
				scr_audioController.audio_sprite.maxDistance = 300;
				scr_audioController.audio_sprite.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Imp")
		{
			if (GameManager.impUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingImp.objTypeId),scr_gameObjsvr.objDarklingImp.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingImp.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.imp.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.djinn.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Imp;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = "Imp";
				creatureSystemInfo.level_spText.Text = GameManager.imp_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[04];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dDjinnCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_imp.Play();
				scr_audioController.audio_imp.minDistance = 1;
				scr_audioController.audio_imp.maxDistance = 300;
				scr_audioController.audio_imp.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Djinn")
		{
			if (GameManager.djinnUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingDjInn.objTypeId),scr_gameObjsvr.objDarklingDjInn.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingDjInn.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.djinn.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Djinn;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Fire";
				creatureSystemInfo.creatureName_spText.Text = "Djinn";
				creatureSystemInfo.level_spText.Text = GameManager.djinn_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[05];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_Djinn.Play();
				scr_audioController.audio_Djinn.minDistance = 1;
				scr_audioController.audio_Djinn.maxDistance = 300;
				scr_audioController.audio_Djinn.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leech")
		{
			if (GameManager.leechUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objLeech.objTypeId),scr_gameObjsvr.objLeech.objTypeId);
				InitialTypeId = scr_gameObjsvr.objLeech.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.leech.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.leshy.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Leech;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = "Leech";
				creatureSystemInfo.level_spText.Text = GameManager.leech_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[06];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dLeshyCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_leech.Play();
				scr_audioController.audio_leech.minDistance = 1;
				scr_audioController.audio_leech.maxDistance = 300;
				scr_audioController.audio_leech.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leshy")
		{
			if (GameManager.leshyUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingLeshy.objTypeId),scr_gameObjsvr.objDarklingLeshy.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingLeshy.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.leshy.nextFeed.ToString();
				creatureSystemInfo.morph_spText.Text = creatureSystemInfo.lurker.sparkCost.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Leshy;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = "Leshy";
				creatureSystemInfo.level_spText.Text = GameManager.leshy_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[07];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = gameManagerInfo.gameObject.GetComponent<objectCost>().dLurkerCost.GetComponent<SpriteText>().Text;
				
				scr_audioController.audio_leshy.Play();
				scr_audioController.audio_leshy.minDistance = 1;
				scr_audioController.audio_leshy.maxDistance = 300;
				scr_audioController.audio_leshy.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Lurker")
		{
			if (GameManager.lurkerUsingBool == false)
			{
				scr_remote.SendRequestforMaxfeed(scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingLurker.objTypeId),scr_gameObjsvr.objDarklingLurker.objTypeId);
				InitialTypeId = scr_gameObjsvr.objDarklingLurker.objTypeId;
				popUpInfoScript.wall.active = true;
				FeedMorphPopUp.SetActiveRecursively(true);
				
				creatureSystemInfo.feed_spText.Text = creatureSystemInfo.lurker.nextFeed.ToString();
				creatureSystemInfo.creatureImage.renderer.material.mainTexture = creatureSystemInfo.c_Lurker;
				
				creatureSystemInfo.habitatInfo_spText.Text = "Swamp";
				creatureSystemInfo.creatureName_spText.Text = "Lurker";
				creatureSystemInfo.level_spText.Text = GameManager.lurker_lvl.ToString();
				creatureSystemInfo.info_spText.Text = creatureInfoString[08];

				SpriteText morphTxt = Morphbtn.gameObject.transform.FindChild("morph1Txt").gameObject.GetComponent<SpriteText>() as SpriteText;
				morphTxt.Text = "0";
				
				scr_audioController.audio_lurker.Play();
				scr_audioController.audio_lurker.minDistance = 1;
				scr_audioController.audio_lurker.maxDistance = 300;
				scr_audioController.audio_lurker.volume = 0.7f;
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(47, 0);
			}
		}
		
		confirmButton.active = false;
		creatureNameTF.gameObject.active = false;
		renameTxt.active = false;
		cancleButton.active = false;
	}
	
//===============================================================================================================================================================================	
	
	// FEED BUTTON
	
	void feedButton()
	{
		handObjTut = GameObject.Find("gameArrowPF(Clone)");
		if(handObjTut!=null)
		{
			if (GameManager.hound_lvl == 1)
			{
				popUpInfoScript.feedTutorial(5);
			}
		}
		
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.currentCreature.tag == "Hound")
			creatureSystemInfo.updateHoundCreature();
		else if (GameManager.currentCreature.tag == "Barg")
			creatureSystemInfo.updateBargCreature();
		else if (GameManager.currentCreature.tag == "Cusith")
			creatureSystemInfo.updateCusithCreature();
		else if (GameManager.currentCreature.tag == "Sprout")
			creatureSystemInfo.updateSproutCreature();
		else if (GameManager.currentCreature.tag == "Nymph")
			creatureSystemInfo.updateNymphCreature();
		else if (GameManager.currentCreature.tag == "Dryad")
			creatureSystemInfo.updateDryadCreature();
		else if (GameManager.currentCreature.tag == "Nix")
			creatureSystemInfo.updateNixCreature();
		else if (GameManager.currentCreature.tag == "Draug")
			creatureSystemInfo.updateDraugCreature();
		else if (GameManager.currentCreature.tag == "Dragon")
			creatureSystemInfo.updateDragonCreature();
		else if (GameManager.currentCreature.tag == "DHound")
			creatureSystemInfo.updateDHoundCreature();
		else if (GameManager.currentCreature.tag == "Fenrir")
			creatureSystemInfo.updateFenrirCreature();
		else if (GameManager.currentCreature.tag == "HellHound")
			creatureSystemInfo.updateHellHoundCreature();
		else if (GameManager.currentCreature.tag == "Sprite")
			creatureSystemInfo.updateSpriteCreature();
		else if (GameManager.currentCreature.tag == "Imp")
			creatureSystemInfo.updateImpCreature();
		else if (GameManager.currentCreature.tag == "Djinn")
			creatureSystemInfo.updateDjinnCreature();
		else if (GameManager.currentCreature.tag == "Leech")
			creatureSystemInfo.updateLeechCreature();
		else if (GameManager.currentCreature.tag == "Leshy")
			creatureSystemInfo.updateLeshyCreature();
		else if (GameManager.currentCreature.tag == "Lurker")
			creatureSystemInfo.updateLurkerCreature();
	}

//===============================================================================================================================================================================	
	
	// MORPH BUTTON

	void morphButton()
	{
		handObjTut = GameObject.Find("gameArrowPF(Clone)");
		
		if(handObjTut!=null)
		{
			Destroy(handObjTut);
			
			PlayerPrefs.SetInt("feedtuts",1);
			
			feedMorphTutorial = false;
		}
		
		scr_audioController.audio_buttonClick.Play();
		GameObject creatureFind = null;
		
		if (GameManager.currentCreature.tag == "Hound")
		{
			creatureFind = GameObject.Find("HC_C_Barg_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphHoundToBarg();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Barg")
		{
			creatureFind = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphBargToCusith();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprout")
		{
			creatureFind = GameObject.Find("HC_C_Nymph_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphSproutToNymph();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Nymph")
		{
			creatureFind = GameObject.Find("HC_C_Dryad_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphNymphToDryad();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Nix")
		{
			creatureFind = GameObject.Find("HC_C_Draug_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphNixToDraug();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Draug")
		{
			creatureFind = GameObject.Find("HC_C_Dragon_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphDraugToDragon();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "DHound")
		{
			creatureFind = GameObject.Find("DL_C_Fenrir_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphDHoundToFenrir();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Fenrir")
		{
			creatureFind = GameObject.Find("DL_C_HellHound_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphFenrirToHellHound();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Sprite")
		{
			creatureFind = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphSpriteToImp();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Imp")
		{
			creatureFind = GameObject.Find("DL_C_Djinn_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphImpToDjinn();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leech")
		{
			creatureFind = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphLeechToLeshy();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
		else if (GameManager.currentCreature.tag == "Leshy")
		{
			creatureFind = GameObject.Find("DL_C_Lurker_GO(Clone)") as GameObject;
			if (creatureFind == null)
				creatureSystemInfo.morphLeshyToLurker();
			else
			{
				FeedMorphPopUp.SetActiveRecursively(false);
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(38, 0);
			}
		}
	}
	
//===============================================================================================================================================================================		

	// FEED CANCLE BUTTON
	void feedCancleButton()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = false;
		FeedMorphPopUp.SetActiveRecursively(false);
	}
	
	void PlayAudioforGold()
	{
		scr_audioController.audio_GoldBtn.Play();
		scr_audioController.audio_GoldBtn.minDistance = 1;
		scr_audioController.audio_GoldBtn.maxDistance = 300;
		scr_audioController.audio_GoldBtn.volume = 0.8f;
		scr_audioController.audio_GoldBtn.loop = false;
	}
	
	void PlayAudioforRabbitBtn()
	{
		scr_audioController.audio_RabbitBtn.Play();
		scr_audioController.audio_RabbitBtn.minDistance = 1;
		scr_audioController.audio_RabbitBtn.maxDistance = 300;
		scr_audioController.audio_RabbitBtn.volume = 0.8f;
		scr_audioController.audio_RabbitBtn.loop = false;
	}
	
//===============================================================================================================================================================================		
	// Collect Gold
	void collectGold()
	{
		Debug.Log("gold obj ---> " + goldObj.name);
		scr_audioController.audio_buttonClick.Play();
		PlayAudioforGold();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int InnId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objInn.objTypeId);
		scr_remote.SendRequestforCreditGold(InnId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
		//GameObject earnGoldTxt = Instantiate(Resources.Load("goldValue"), goldObj.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
	}
	
//===============================================================================================================================================================================
	
	//gold generation logic ...by harish chander
	
	void collectGoldforDarklingInn()
	{
		PlayAudioforGold();
		scr_audioController.audio_buttonClick.Play();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int DarklingId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarkLingInn.objTypeId);
		scr_remote.SendRequestforCreditGold(DarklingId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
	}
	
	void collectGoldforStable()
	{
		Debug.Log("gold obj ---> " + goldObj.name);
		PlayAudioforGold();
		scr_audioController.audio_buttonClick.Play();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int DarklingId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objHalflingStable.objTypeId);
		scr_remote.SendRequestforCreditGold(DarklingId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
	}
	
	void collectGoldforBlackSmith()
	{
		PlayAudioforGold();
		scr_audioController.audio_buttonClick.Play();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int DarklingId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objBlackSmith.objTypeId);
		scr_remote.SendRequestforCreditGold(DarklingId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
	}
	
	void collectGoldforDarklingStable()
	{
		PlayAudioforGold();
		scr_audioController.audio_buttonClick.Play();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int DarklingId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarkingStable.objTypeId);
		scr_remote.SendRequestforCreditGold(DarklingId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
	}
	
	void collectGoldforDarklingBlackSmith()
	{
		PlayAudioforGold();
		scr_audioController.audio_buttonClick.Play();
		goldObj.transform.FindChild("GoldButton").gameObject.SetActiveRecursively(false);
		GameObject coinParticle = Instantiate(gameManagerInfo.par_Coin_PF, new Vector3(goldObj.transform.position.x, goldObj.transform.position.y + 1, goldObj.transform.position.z), Quaternion.Euler(330, 0, 0)) as GameObject;
		coinParticle.GetComponent<ParticleSystem>().Play();
		int DarklingId = scr_userWorld.ReturnObjIdfromTypeId(scr_gameObjsvr.objDarklingSmith.objTypeId);
		scr_remote.SendRequestforCreditGold(DarklingId);
		GameManager.curGoldBuilding = goldObj;
		Debug.Log("~~~~~~~> " + goldObj + " <~~~~~~~~~~~");
	}
	
//===============================================================================================================================================================================
	// haflding dirt path
	bool halffirstinst;
	public void createDirtPath()
	{
		GameObject go;
		objGridMove.gridObjSetBool = true;
		panelControl.panelMoveIn = true;
		panelControl.panelMoveOut = false;
		
		GameManager.placeObjectBool = true;
		
		Debug.Log("halffirstinst : "+halffirstinst);
		if(halffirstinst == false)
		{
			Debug.Log("------->lastDirtPathPosition : "+GameManager.lastDirtPathPosition);
			go = Instantiate(dirtPath, new Vector3(GameManager.lastDirtPathPosition.x + 1.46f, 0.2f, GameManager.lastDirtPathPosition.z - 0.73f), Quaternion.Euler(0, 180, 0)) as GameObject;
			halffirstinst = true;
		}
		else
		{
			Debug.Log("------> halfdirtpath : "+popUpInfoScript.halfdirtpath);
			go = Instantiate(dirtPath, new Vector3(popUpInfoScript.halfdirtpath.x, 0.2f, popUpInfoScript.halfdirtpath.z), Quaternion.Euler(0, 180, 0)) as GameObject;	
		}
		Debug.Log("go.name : "+go.name);
		grid.curObj = go;
		curObj = go;
		
		grid.curCol = go.transform.FindChild("Isometric_Collider").gameObject;
		
		GameObject hMap = GameObject.Find("HalfLing_Map") as GameObject;
		
		if (hMap != null)
		{
			// set color
			go.renderer.material.color = hMap.renderer.material.color;
		}
		
		GameManager.halfCurrDirtPath = go;
		GameObject dirt = GameObject.Find("HWCharacter(Clone)");
	
//		Debug.Log("curObj.name : "+curObj.name);
		halfwayone = curObj.transform.FindChild("waypoint1") ;
		if (halfwayone != null)
			halfwayone.gameObject.active = false;
	
		Transform tempObjUI = curObj.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
				
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
		
		//grid.placeButtonBool = true;
		grid.curObj = go;
				
		if (delArrow != null)
			Destroy(delArrow);
	}
	
//===============================================================================================================================================================================
	
	public void createFruitTree()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_FruitTree_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_FruitTree_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
		
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createLantern()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Lantern_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Lantern_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}

//===============================================================================================================================================================================
	
	public void createWheelBurrow()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_WheelBurrow_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_WheelBurrow_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createShroomrey()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Shroomrey_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createBarell()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Barrel_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createTree()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Tree_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createWell()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Well_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createWoodpile()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Woolpile_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createCornfield()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Cornfield_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createCottage()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Cottage_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createHalflingKnoll()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_HalflingKnoll_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createPartyTent()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_PartyTent_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createScarecrow()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_Scarecrow_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	
//===============================================================================================================================================================================
	
	public void createStoneFence()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_StoneFence_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	
	

//===============================================================================================================================================================================
	
	public void createWindMill()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.h_WindMill_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.h_Shroomrey_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}	

//===============================================================================================================================================================================
	bool darkfirstinst;
	public void createDDirtPath()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = null;
		GameObject tempObj = GameObject.Find("DL_D_DDirtPath_GO(Clone)") as GameObject;
		
		if (tempObj == null)
		{
			GameManager.multipleDecorationBool = true;
			go = Instantiate(gameManagerInfo.d_DirtPath_PF, new Vector3(64.24f, 0.02913191f/*0.1f*/, 1.46f), gameManagerInfo.d_DirtPath_PF.transform.rotation) as GameObject;
			go.GetComponent<dirtPathPlacement>().enabled = false;
			go.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			go.transform.FindChild("touchMovePlane").gameObject.tag = "editableObj";
			GameManager.placeObjectBool = true;
			go.transform.FindChild("redPatch").gameObject.active = false;
			
		}
		else
		{
			if(darkfirstinst == false)
			{
				Debug.Log("Last darkkling dirtpath =---> " + GameManager.lastDDirtPathPosition);
				go = Instantiate(gameManagerInfo.d_DirtPath_PF, new Vector3(GameManager.lastDDirtPathPosition.x + 1.46f, 0.2f, GameManager.lastDDirtPathPosition.z - 0.73f), gameManagerInfo.d_DirtPath_PF.transform.rotation) as GameObject;
				darkfirstinst = true;
			}
			else
			{
				Debug.Log("Last darkkling dirtpath2 =---> " + GameManager.lastDDirtPathPosition);
				go = Instantiate(gameManagerInfo.d_DirtPath_PF, new Vector3(popUpInfoScript.darkdirtpath.x, 0.2f, popUpInfoScript.darkdirtpath.z), gameManagerInfo.d_DirtPath_PF.transform.rotation) as GameObject;	
			}
		}
		
		grid.curObj = go;
		curObj = go;
		GameManager.darkCurrDirtPath = go;
		GameObject Ddirt = GameObject.Find("DLCharacter(Clone)");
		
		darkwayone = go.transform.FindChild("waypoint2") ;
		darkwayone.gameObject.active = false;
				
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
		grid.curObj = go;
		
		if(GameManager.gameLevel >= 4 && darkDirtPath == false)
		{
			inventory1Info.RemoveItem1(taskDetailsInfo.Four_Dark_task5);
			taskDetailsInfo.Four_Dark_task5_bool = true;
			darkDirtPath = true;
		}
	}
	
//===============================================================================================================================================================================
	
	public void createDTree()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_Tree_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Tree_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
		
		grid.placeButtonBool = true;
		grid.curObj = go;
	}

//===============================================================================================================================================================================
	
	public void createDWell()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_Well_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
			
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}

//===============================================================================================================================================================================
	
	public void createDBog()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_Bog_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDRevenPerch()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_RevenPerch_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDBirdHouse()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_BirdHouse_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDWindMill()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_WindMill_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDHuntingTent()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_HuntingTent_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDScareCrow()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_Scarecrow_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDStoneFence()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_StoneFence_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================
	
	public void createDSwampKnoll()
	{
		objGridMove.gridObjSetBool = true;
		GameObject go = Instantiate(gameManagerInfo.d_SwampKnoll_PF, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), gameManagerInfo.d_Well_PF.transform.rotation) as GameObject;
		
		Transform tempObjUI = go.transform.FindChild("UI");
		Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
		Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
		Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");

		UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
		delObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
		placeObjUIButtonInfo.scriptWithMethodToInvoke = this;
		
		guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		
		Transform tempObjFlip = tempObjPlacePanel.FindChild("objFlip");
		UIButton flipObjUIButtonInfo = tempObjFlip.gameObject.GetComponent("UIButton") as UIButton;
		flipObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
		
		popUpInfoScript.wall.active = false;
		storeUI.SetActiveRecursively(false);
		decorationUI.SetActiveRecursively(false);
			
			
		grid.placeButtonBool = true;
		grid.curObj = go;
	}
	
//===============================================================================================================================================================================

	void FeedMorphPopupCancle()
	{
		if (GameManager.FeedMorphPopupCancleBool)
		{
			if (GameManager.taskCount == 6 && GameManager.popUpCount == 12)
			{
				popUpInfoScript.feedTutorial(6);
			}
			if (GameManager.taskCount == 7 && GameManager.popUpCount == 13)
			{
				popUpInfoScript.renameCreatureTutorial(7);
			}
			
			popUpOpenBool = false;
		
			scr_audioController.audio_buttonClick.Play();
			popUpInfoScript.wall.active = false;
			FeedMorphPopUp.SetActiveRecursively(false);
			handObjTut = GameObject.Find("gameArrowPF(Clone)");
			if(handObjTut!=null)
			{
				Destroy(handObjTut);
			}
		}
	}
	
//===============================================================================================================================================================================
	
	void buildingUpgradeButton()
	{
		scr_audioController.audio_buttonClick.Play();
		
		objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
		movePanelInfo.panelMoveIn = true;
		movePanelInfo.panelMoveOut = false;
		
		if (GameManager.curBuilding != null)
		{
			upgradeProgressBar uPB = GameManager.curBuilding.GetComponent<upgradeProgressBar>();
			
			if (GameManager.curBuilding.tag == "HHouse")
			{
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 7 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeHHouse = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 16 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeHHouse = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			else if (GameManager.curBuilding.tag == "DHouse")
			{
				Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
				if (GameManager.gameLevel >= 7 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeDHouse = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 16 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeDHouse = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
			}
			
			else if (GameManager.curBuilding.tag == "Inn")
			{
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 8 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeInn = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 17 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeInn = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeInn = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
		
			else if (GameManager.curBuilding.tag == "Stable")
			{
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 11 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeStable = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 21 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeStable = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeInn = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
		
			else if (GameManager.curBuilding.tag == "BlackSmith")
			{
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 14 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeBlackSmith = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 20 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeBlackSmith = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeInn = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
		
			else if (GameManager.curBuilding.tag == "DInn")
			{
				Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
				if (GameManager.gameLevel >= 8 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeDInn = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 17 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeDInn = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeDInn = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
		
			else if (GameManager.curBuilding.tag == "DStable")
			{
				Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
				if (GameManager.gameLevel >= 11 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeDStable = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 17 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeDStable = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeDStable = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			else if (GameManager.curBuilding.tag == "DBlackSmith")
			{
				Darkgolum = GameObject.Find("DL_C_Golum_GO(Clone)");
				if (GameManager.gameLevel >= 14 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeDBlackSmith = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 20 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeDBlackSmith = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeDBlackSmith = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade obelisk
			else if (GameManager.curBuilding.tag == "EarthObelisk")
			{
				Debug.Log("earth obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 6 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeEarthObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 7 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeEarthObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeEarthObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade plant obelisk
			else if (GameManager.curBuilding.tag == "PlantObelisk")
			{
				Debug.Log("plant obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 9 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradePlantObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 10 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradePlantObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradePlantObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade water obelisk
			else if (GameManager.curBuilding.tag == "WaterObelisk")
			{
				Debug.Log("water obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 11 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeWaterObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 12 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeWaterObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeWaterObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade swamp obelisk
			else if (GameManager.curBuilding.tag == "SwampObelisk")
			{
				Debug.Log("swamp obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 6 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeSwampObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 7 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeSwampObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeSwampObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade d earth obelisk
			else if (GameManager.curBuilding.tag == "DEarthObelisk")
			{
				Debug.Log("d earth obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 9 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeDEarthObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 10 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeDEarthObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeDEarthObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// upgrade fire obelisk
			else if (GameManager.curBuilding.tag == "FireObelisk")
			{
				Debug.Log("fire obelisk... popup...");
				golum  = GameObject.Find("HC_C_Golum_GO(Clone)") as GameObject;
				if (GameManager.gameLevel >= 12 && uPB.currentUpgradeLevel == 1)
				{
					GameManager.upgradeFireObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else if (GameManager.gameLevel >= 13 && uPB.currentUpgradeLevel == 2)
				{
					GameManager.upgradeFireObelisk = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(4, 2);
				}
				else
				{
					GameManager.upgradeFireObelisk = false;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(19, 0);
				}
			}
			
			// end
			
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(54, 0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(54, 0);
		}
	}
	
//===============================================================================================================================================================================
	
	// Move Cancle
	void CancleMoveObject()
	{
		cavePatchList = GameObject.FindGameObjectsWithTag("cavePatch");
		
		
		
		foreach(GameObject cavePatch in cavePatchList)
		{
			if (cavePatch.GetComponent<MeshRenderer>().enabled == true)
				cavePatch.GetComponent<MeshRenderer>().enabled = false;
		}
		
		scr_audioController.audio_buttonClick.Play();
		GameManager.panelAccessBool = true;
		objectSelection.objectSelectionBool = true;
		GameManager.placeObjectBool = false;
		
		Sensors.sensorWorkBool = false;
		
		GameManager.currentMovableObj.transform.position = new Vector3(objPrevPos.x, objPrevPos.y, objPrevPos.z);
		
		GameManager.currentMovableObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
		GameManager.currentMovableObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
		GameManager.currentMovableObj.transform.FindChild("redPatch").gameObject.active = false;
		GameManager.currentMovableObj.transform.FindChild("greenPatch").gameObject.active = false;
		GameManager.currentMovableObj.transform.FindChild("selectionPatch").gameObject.GetComponent<MeshRenderer>().enabled = false;
		GameManager.currentMovableObj.transform.FindChild("UI").gameObject.SetActiveRecursively(false);
		
		GameManager.currentMovableObj.GetComponent<Sensors>().enabled = false;
		
		Transform waypoint = GameManager.currentMovableObj.transform.FindChild("waypoint1") as Transform;
				
		if (waypoint != null)
			waypoint.gameObject.GetComponent<SphereCollider>().enabled = true;
	}
	
//===============================================================================================================================================================================	
	
	// move object
	void MoveObject()
	{
		scr_audioController.audio_buttonClick.Play();
		objectSelection.objectSelectionBool = true;
		
		if (GameManager.placeObjectBool)
		{
			GameManager.panelAccessBool = true;
			Sensors.sensorWorkBool = false;
			
			grid.curObj.transform.position = new Vector3(grid.curObj.transform.position.x, /*0.01f*/ grid.axisY, grid.curObj.transform.position.z);
			
			grid.curObj.transform.FindChild("touchMovePlane").gameObject.GetComponent<MeshCollider>().enabled = false;
			grid.curObj.transform.FindChild("Isometric_Collider").gameObject.tag = "editableObj";
			Transform redPatch = grid.curObj.gameObject.transform.FindChild("redPatch");
			Transform greenPatch = grid.curObj.gameObject.transform.FindChild("greenPatch");
			redPatch.gameObject.active = false; // hide red patch current game object
			greenPatch.gameObject.active = false; // hide green patch current game object
			grid.curCol.tag = "editableObj";
			
			if (grid.curObj!= null)
			{
				//Move sent to server
				
				popUpInfoScript.isObjectMove = true;
				popUpInfoScript.SendPos = popUpInfoScript.GetabsolutePos(grid.curObj.transform.position.x,grid.axisY,grid.curObj.transform.position.z);
				
				popUpInfoScript.SendRot = new Vector3(0,180,0);
				scr_remote.SendRequestForGetworld();
			}
			
			// hide current object UI
			Transform tempUI = grid.curObj.transform.FindChild("UI");
			
			GameObject placeButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objPlace").gameObject;
			placeButt.GetComponent<UIButton>().methodToInvoke = "MoveObject";
			
			GameObject cancleButt = tempUI.FindChild("ObjectPlacePanel").gameObject.transform.FindChild("objDelete").gameObject;
			cancleButt.GetComponent<UIButton>().methodToInvoke = "CancleMoveObject";
			
			
			tempUI.gameObject.SetActiveRecursively(false);
			
			// destroy current sensor script
			Sensors sensorInof = grid.curObj.GetComponent("Sensors") as Sensors;
			sensorInof.enabled = false;
			GameManager.placeObjectBool = false;
			
			Transform waypoint = grid.curObj.transform.FindChild("waypoint1") as Transform;
				
			if (waypoint != null)
				waypoint.gameObject.GetComponent<SphereCollider>().enabled = true;
		
			if (grid.curObj.name == "HC_D_DirtPath_GO(Clone)" || grid.curObj.name == "DL_D_DDirtPath_GO(Clone)")
			{
				grid.curObj.GetComponent<dirtPathPlacement>().enabled = false;
			}
			
			grid.curObj = null;
		}
	}
	
	
//===============================================================================================================================================================================
	public GameObject qGO = null;
	
	void questRabbitButton()
	{
		scr_audioController.audio_buttonClick.Play();
		PlayAudioforRabbitBtn();
		
		qGO = GameObject.Find("QuestProgressBar(Clone)") as GameObject;
		
		if (GameManager.quest == 0)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 2)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 3)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 4)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 5)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 6)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 7)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 8)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 9)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 10)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 11)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
		else if (GameManager.quest == 12)
		{
			GameManager.destroyQuestPbBool = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(52,2);
		}
	}
	
	private void ActivatePotionGame()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		scr_remote.SendRequestforGetHerbs();
	 	GameObject Potion = Instantiate(potionGame) as GameObject;
		Potion.transform.Find("ProgressBar").gameObject.SetActiveRecursively(true);
		Potion.transform.FindChild("Fire").gameObject.active = false;
		Potion.transform.FindChild("GoldText").gameObject.active = false;
		Potion.transform.FindChild("XPText").gameObject.active = false;
		Beaker.herbCount =0;
		Screen.orientation = ScreenOrientation.Portrait;
		
		
		popUpInfoScript.scr_audioController.audio_PotionTheme.transform.position = Potion.transform.position;
		popUpInfoScript.scr_audioController.audio_PotionTheme.Play();
		popUpInfoScript.scr_audioController.audio_PotionTheme.loop = true;
		popUpInfoScript.scr_audioController.audio_PotionTheme.minDistance = 1;
		popUpInfoScript.scr_audioController.audio_PotionTheme.maxDistance = 300;
		popUpInfoScript.scr_audioController.audio_PotionTheme.volume = 0.7f;
		
		AudioController.EnableEnviron = false;
		
		popUpInfoScript.scr_audioController.audio_dl.Stop();
		popUpInfoScript.scr_audioController.audio_hl.Stop();
		
	}
	 
	private void ActivateBeerGame()
	{
		scr_audioController.audio_buttonClick.Play();
		popUpInfoScript.wall.active = true;
		GameObject Beer = Instantiate(BeerGame, new Vector3(0, 1, 60), Quaternion.identity) as GameObject;
		Beer.transform.FindChild("BeerPost").gameObject.active = false;
		Beer.transform.FindChild("GoldText").gameObject.active = false;
		Beer.transform.FindChild("XPText").gameObject.active = false;
		Screen.orientation = ScreenOrientation.Portrait;
		
		
		popUpInfoScript.scr_audioController.audio_tavernPouring.transform.position = Beer.transform.position;
		popUpInfoScript.scr_audioController.audio_tavernPouring.Play();
		popUpInfoScript.scr_audioController.audio_tavernPouring.minDistance = 1;
		popUpInfoScript.scr_audioController.audio_tavernPouring.maxDistance = 300;
		popUpInfoScript.scr_audioController.audio_tavernPouring.loop = true;
		popUpInfoScript.scr_audioController.audio_tavernPouring.volume = 0.7f;
		
		popUpInfoScript.scr_audioController.audio_DrinkingTheme.Play();
		popUpInfoScript.scr_audioController.audio_DrinkingTheme.loop = true;
		popUpInfoScript.scr_audioController.audio_DrinkingTheme.minDistance = 1;
		popUpInfoScript.scr_audioController.audio_DrinkingTheme.maxDistance = 300;
		popUpInfoScript.scr_audioController.audio_DrinkingTheme.volume = 0.7f;
		
		
		AudioController.EnableEnviron = false;
		
		popUpInfoScript.scr_audioController.audio_dl.Stop();
		popUpInfoScript.scr_audioController.audio_hl.Stop();
	}
	
//===============================================================================================================================================================================
	public static int selectedStoryCount = 0;
   	public void playQuest()
	{
		scr_audioController.audio_buttonClick.Play();
		taskDetailsInfo.CancleStoryPopUp();
		
		if (GameManager.gameLevel <= 2)
			gameManagerInfo.story01(0);
		
		if (selectedStoryCount == 1)
		{
			Debug.Log("Story 1 <-----");
		}
		
		/*if (!GameManager.questRunningBool)
		{
			
			        if(!gameManagerInfo.enableQuest)
					{
						gameManagerInfo.PlayQuestSounds();
					}
			
			if (GameManager.quest == 1 && GameManager.gameLevel  >= 4)
			{
				if (!GameManager.questRunningBool)
						popUpInfoScript.taskArrowOnBrokenBridge();
			}
			else if (GameManager.quest == 2 && GameManager.gameLevel >= 5)
			{
				if (!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest03_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_3[0];
					gameManagerInfo.message = gameManagerInfo.quest_3[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if (GameManager.quest == 3 && GameManager.gameLevel >= 6)
			{
				if (!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest04_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_4[0];
					gameManagerInfo.message = gameManagerInfo.quest_4[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
				}
			}
			else if (GameManager.quest == 4 && GameManager.gameLevel >= 7)
			{
				if (!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest05a_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_5[0];
					gameManagerInfo.message = gameManagerInfo.quest_5[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if (GameManager.quest == 5 && GameManager.gameLevel >= 8)
			{
				if (!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest06a_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_6[0];
					gameManagerInfo.message = gameManagerInfo.quest_6[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 6 && GameManager.gameLevel >= 9)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest07a_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_7[0];
					gameManagerInfo.message = gameManagerInfo.quest_7[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 7 && GameManager.gameLevel >= 10)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest08_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_8[0];
					gameManagerInfo.message = gameManagerInfo.quest_8[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 8 && GameManager.gameLevel >= 11)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest09a_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_9[0];
					gameManagerInfo.message = gameManagerInfo.quest_9[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 9 && GameManager.gameLevel >= 12)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest10a_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_10[0];
					gameManagerInfo.message = gameManagerInfo.quest_10[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 10 && GameManager.gameLevel >= 13)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
						
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest11_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_11[0];
					gameManagerInfo.message = gameManagerInfo.quest_11[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else if(GameManager.quest == 11 && GameManager.gameLevel >= 14)
			{
				if(!GameManager.questRunningBool)
				{
					GameManager.questActivateBool = true;
					GameManager.questRunningBool = true;
					
					popUpInfoScript.wall.active = true;
					popUpType4.SetActiveRecursively(true);
					
					gameManagerInfo.scr_QuestTexControl.questMat.mainTexture = gameManagerInfo.scr_QuestTexControl.quest12_tex;
					popUpType_Dig1_spText.Text = gameManagerInfo.quest_12[0];
					gameManagerInfo.message = gameManagerInfo.quest_12[0];
					gameManagerInfo.WriteText1();
					gameManagerInfo.dialogCnt = 1;
					
					popUpType_Dig2_spText.Text = "";
					gameManagerInfo.questA = true;
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(51, 0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(53, 0);
		}*/
	}
	
	public void EnableDarkling(GameObject go, bool normalState)
	{
		//Debug.Log("why ?????????????????????????????? " + GameManager.unlockDarklingBool);
		
		
		if(go != null)
		{
			UIButton uiB = go.GetComponent<UIButton>();
			if(uiB != null)
			{
				if(normalState)
				{
					//Debug.Log("normal.......................");
					uiB.SetControlState(UIButton.CONTROL_STATE.NORMAL);
				}
				else 
				{
					Debug.Log("disable.........................");
					uiB.SetControlState(UIButton.CONTROL_STATE.DISABLED);
				}
			}
		}
	}
	
//====================================================================================================================
	
	void CreateTrainingGround(GameObject tgObj, int checkLevel, double objTypeId, string tgName)
	{	
		GameObject pTG = GameObject.Find(tgName) as GameObject;
		if (pTG == null)
		{
			if (GameManager.gameLevel >= checkLevel)
			{
				if(GameManager.coins >= objTypeId)
				{
					objGridMove.gridObjSetBool = true;
					GameManager.panelAccessBool = false;
					objectSelection.objectSelectionBool = false;
				
					// hide main menu
					panelControl.panelMoveIn = true;
					panelControl.panelMoveOut = false;
			
					GameObject go = Instantiate(tgObj, new Vector3(gameManagerInfo.cam.transform.position.x, 0.2f, gameManagerInfo.cam.transform.position.z), tgObj.transform.rotation) as GameObject;
					curObj = go;
					go.transform.FindChild("HealthProgressBar").gameObject.SetActiveRecursively(false);
					go.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
					go.transform.FindChild("Spark").gameObject.SetActiveRecursively(false);
					go.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
					
					Transform tempObjUI = curObj.transform.FindChild("UI");
					Transform tempObjPlacePanel = tempObjUI.FindChild("ObjectPlacePanel");
					Transform tempObjDelete = tempObjPlacePanel.FindChild("objDelete");
					Transform tempObjPlace = tempObjPlacePanel.FindChild("objPlace");
		
					Transform rabbitButton = go.transform.FindChild("RabbtiButton").gameObject.transform.FindChild("Rabbit") as Transform;
					UIButton delObjUIButtonInfo = tempObjDelete.gameObject.GetComponent("UIButton") as UIButton;
					guiControl guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
					delObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
			
					UIButton placeObjUIButtonInfo = tempObjPlace.gameObject.GetComponent("UIButton") as UIButton;
					placeObjUIButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
					
					UIButton rabbitButtonInfo = rabbitButton.gameObject.GetComponent("UIButton") as UIButton;
					rabbitButtonInfo.scriptWithMethodToInvoke = guiControlInfo;
					
					popUpInfoScript.wall.active = false;
					storeUI.SetActiveRecursively(false);
					trainingGroundUI.SetActiveRecursively(false);
					
					grid.placeButtonBool = true;
					grid.curObj = go;
		
					rabbitButton.gameObject.SetActiveRecursively(false);
					
					if (delArrow != null)
						Destroy(delArrow);
					
				}
				else
				{
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(18, 0);
				}
			}
			else
			{
				popUpInfoScript.wall.active = true;
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(20, 0);
			}
		}
		else
		{
			trainingGroundUI.SetActiveRecursively(false);
			popUpInfoScript.wall.active = true;
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34, 0);
		}
	}
	
	// earth obelisk button
	public void earthObeliskButton()
	{
		panelControl.panelMoveIn = true;
		panelControl.panelMoveOut = false;
		
		GameObject earthObeliskObj = GameObject.Find("HC_B_EarthObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		defenceUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (earthObeliskObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 2)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objEarthobelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						if (GameManager.taskCount == 10)
							popUpInfoScript.obeliskTutorial(2);
						else
							popUpInfoScript.taskBuildEarthObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// plant obelisk button
	public void plantObeliskButton()
	{
		panelControl.panelMoveIn = true;
		panelControl.panelMoveOut = false;
		
		GameObject plantObeliskObj = GameObject.Find("HC_B_PlantObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		defenceUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (plantObeliskObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 3)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objPlantObelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildPlantObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// water obelisk button
	public void waterObeliskButton()
	{
		panelControl.panelMoveIn = true;
		panelControl.panelMoveOut = false;
		
		GameObject waterObeliskObj = GameObject.Find("HC_B_WaterObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		defenceUI.SetActiveRecursively(false);
		guiControl.popUpOpenBool = false;
		
		if (waterObeliskObj == null)
		{
			if (GameManager.hBuildingConstructBool)
			{
				if (GameManager.gameLevel >= 5)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objWaterObelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskBuildWaterObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(40,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(34,0);
		}
	}
	
	// dark earth obelisk button
	public void dEarthObeliskButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dEarthObeliskObj = GameObject.Find("DL_B_EarthObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingDefenceUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dEarthObeliskObj == null)
			{
				if (GameManager.gameLevel >= 5)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingEarthObelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingEarthObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// swamp obelisk button
	public void swampObeliskButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dSwampObeliskObj = GameObject.Find("DL_B_SwampObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingDefenceUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dSwampObeliskObj == null)
			{
				if (GameManager.gameLevel >= 4)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingSwampObelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingSwampObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	// fire obelisk button
	public void fireObeliskButton()
	{
		scr_audioController.audio_buttonClick.Play();
		GameObject dFireObeliskObj = GameObject.Find("DL_B_FireObelisk_GO(Clone)") as GameObject;
		
		popUpInfoScript.wall.active = false;
		darklingDefenceUI.SetActiveRecursively(false);
		
		// LEVEL 3 and above
		if (GameManager.dBuildingConstructBool)
		{
			if (dFireObeliskObj == null)
			{
				if (GameManager.gameLevel >= 6)
				{
					if(GameManager.coins >= scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingFireObelisk.objTypeId))
					{
						GameManager.panelAccessBool = false;
						objectSelection.objectSelectionBool = false;
						popUpInfoScript.taskDarklingFireObelisk(1);
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(34,0);
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(40,0);
		}
	}
	
	
	public GameObject renameCreatureButton, confirmButton, cancleButton, renameTxt;
	//public GameObject editCreatureNameWindow;
	// rename creature name button
	void renameButton()
	{
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 7)
		{
			popUpInfoScript.renameCreatureTutorial(4);
		}
		
		creatureNameTF.gameObject.active = true;
		renameTxt.active = true;
		cancleButton.active = true;
		confirmButton.active = true;
		renameCreatureButton.active = false;
		creatureNameTF.Text = creatureTxt.Text;
	}
	
	// creature name cancle button
	void renameCancleButton()
	{
		if (GameManager.gameLevel != 1)
		{
			renameCreatureButton.active = true;
			creatureNameTF.Text = "";
			cancleButton.active = false;
			confirmButton.active = false;
			creatureNameTF.gameObject.active = false;
			renameTxt.active = false;
		}
	}
	
	void renameTxtField()
	{
		Debug.Log("my text field <----");
	}
	
	// send creature name to server
	void changeCreatureNameButt()
	{
		if (creatureNameTF.Text != null && creatureNameTF.Text != creatureTxt.Text && !GameManager.editCreatureNameTutBool)
		{
			if (GameManager.gameLevel == 1 && GameManager.taskCount == 7)
			{
				popUpInfoScript.renameCreatureTutorial(6);
			}
			
			renameCreatureButton.active = true;
			cancleButton.active = false;
			creatureNameTF.gameObject.active = false;
			renameTxt.active = false;
			confirmButton.active = false;
			
			Debug.Log("~~~~~~~~~~~> " + GameManager.currentCreature.name + " ~~ " + creatureNameTF.Text);
			if (GameManager.currentCreature.tag == "Hound")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objHound.objTypeId);
				gameManagerInfo.houndName = creatureNameTF.Text;
			}
			else if (GameManager.currentCreature.tag == "Barg")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objBarg.objTypeId);
				gameManagerInfo.bargName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Cusith")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objCusith.objTypeId);
				gameManagerInfo.cusithName = creatureNameTF.Text;		
			}
			
			else if (GameManager.currentCreature.tag == "Sprout")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objSprout.objTypeId);
				gameManagerInfo.sproutName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Nymph")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objNymph.objTypeId);
				gameManagerInfo.nymphName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Draug")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDraug.objTypeId);
				gameManagerInfo.draugName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Nix")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objNix.objTypeId);
				gameManagerInfo.nixName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Dryad")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDryad.objTypeId);
				gameManagerInfo.dryadName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Dragon")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDragon.objTypeId);
				gameManagerInfo.dragonName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "DHound")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklinghound.objTypeId);
				gameManagerInfo.dHoundName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Djinn")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingDjInn.objTypeId);
				gameManagerInfo.djinnName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Fenrir")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingFenrir.objTypeId);
				gameManagerInfo.fenrirName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "HellHound")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingHellhound.objTypeId);
				gameManagerInfo.hellHoundName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Imp")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingImp.objTypeId);
				gameManagerInfo.impName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Leech")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objLeech.objTypeId);
				gameManagerInfo.leechName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Leshy")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingLeshy.objTypeId);
				gameManagerInfo.leshyName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Lurker")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingLurker.objTypeId);
				gameManagerInfo.lurkerName = creatureNameTF.Text;
			}
			
			else if (GameManager.currentCreature.tag == "Sprite")
			{
				popUpInfoScript.scr_sfsRemoteCnt.SendCreatureName(creatureNameTF.Text, popUpInfoScript.scr_GameObjSvr.objDarklingSprite.objTypeId);
				gameManagerInfo.spriteName = creatureNameTF.Text;
			}
			
			creatureTxt.Text = creatureNameTF.Text;
		}
	}
	
//====================================================================================================================
	
	public void stroy01Button()
	{
		GameObject arrowObj = GameObject.Find("gameArrowPF(Clone)") as GameObject;
		
		if (arrowObj != null)
		{
			arrowObj.transform.position = new Vector3(-55.8f, 13, 91.9f);
			arrowObj.transform.eulerAngles = new Vector3(270, 0, 0);
		}
	}


	void plantButtonDarkling(int level, int plantLevel, double cost, string plantName, string plantCost)
	{
		scr_audioController.audio_buttonClick.Play();
		if (GameManager.curPlot != null)
		{
			if (GameManager.gameLevel >= level && GameManager.curPlot.tag == "DPlot")
			{
				int plotLevel = GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel;
				if (plotLevel >= plantLevel)
				{
					if(GameManager.coins >= cost)//scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objDarklingMoonFlower.objTypeId))
					{
						GameManager.objectCost = plantCost;// scrObjectCost.dMoonflowerCost.GetComponent<SpriteText>().Text;
						GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), GameManager.curPlot.transform.position,
						                                     Quaternion.Euler(90,0,0)) as GameObject;
						
						popUpInfoScript.wall.active = false;
						darklingPlantUI.SetActiveRecursively(false);
						popUpInfoScript.taskDarklingFarming(1, plantName);//"Moonflower");
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(56, 0);
				}
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(48, 0);
		}
	
	}

	void plantButtonHalfling(int level, int plantLevel, double cost, string plantName, string plantCost)
	{
		popUpInfoScript.wall.active = false;
		plantsUI.SetActiveRecursively(false);
		
		// LEVEL 5 //
		if (GameManager.curPlot != null)
		{
			if (GameManager.gameLevel >= level && GameManager.curPlot.tag == "Plot")
			{
				int plotLevel = GameManager.curPlot.GetComponent<upgradeProgressBar>().currentUpgradeLevel;
				if (plotLevel >= plantLevel)
				{
					if(GameManager.coins >= cost) //scr_userWorld.ReturnGoldCostTotal(scr_gameObjsvr.objSunflower.objTypeId))
					{
						GameManager.objectCost = plantCost; //scrObjectCost.sunflowerCost.GetComponent<SpriteText>().Text;
						//Debug.Log("----->>>> " + grid.curObj);
						GameObject goldCostTxt = Instantiate(Resources.Load("goldValueMinus"), GameManager.curPlot.transform.position,
						                                     Quaternion.Euler(90,0,0)) as GameObject;
						
						popUpInfoScript.wall.active = false;
						plantsUI.SetActiveRecursively(false);
						
						popUpInfoScript.taskFarming(1, plantName);// "SunFlower");
					}
					else
					{
						popUpInfoScript.wall.active = true;
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(18, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(56, 0);
				}
			}
		}
		else
		{
			popUpInfoScript.defaultPopUpBool = true;
			popUpInfoScript.defaultPopUp(48, 0);
		}
	}
}	