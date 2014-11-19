using UnityEngine;
using System.Collections;
using System.Net;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class GameManager : MonoBehaviour 
{
	public GameObject gameProgressBar;


	public int tutLevel = 1;
	
	public static int trainingGroundCnt = 0;
	//public bool IsGetChild;
	// static game score
	public static double coins=0;// 500;
	public static int sparks =0;// 50;
	public static int plants = 0;
	public static int food = 0;//100;
	public static int oldFood = 0;
	public static float xp = 0f;
	public static int gameLevel;// = 1;
	public static int quest;
	public static int storyCnt;// = 1;
	public static int taskCount;// = 1;
	public static int popUpCount;// = 1;
	public static int MaxLevelxp;
	public static int TotalLevelxp;
	
	// purchase Gold Cost Variable
	public static int hPlot_GoldCost = 20;
	public static int dPlot_GoldCost = 40;
	public static int TG_GoldCost = 50;
	
	// Earn XP Variable
	//public static int hPlot_EarnXP = 40;
	//public static int dPlot_EarnXP = 80;
	//public static int TG_EarnXP = 100;
	
	public static int popUpType1_Count = 1; // with 1 button ("OK")
	public static int popUpType2_Count = 1; // Info with 1 button ("OK")
	public static int popUpType3_Count = 1; // with 2 button ("Yes/No")
	
	public static int curCreatureLevel = 0;
	public static int curCreatureFeed = 0;
	public static int gardenPlotCnt = 0;
	
	// training ground creature count
	public static int earthTG_Creature_Cnt = 0;
	public static int plantTG_Creature_Cnt = 0;
	public static int waterTG_Creature_Cnt = 0;
	
	public static int dEarthTG_Creature_Cnt = 0;
	public static int swampTG_Creature_Cnt = 0;
	public static int fireTG_Creature_Cnt = 0;

	public static int earnGoldVal = 0;
	public static int earnXpVal = 0;
	
	public static int earthTG_Cnt = 0, plantTG_Cnt = 0, waterTG_Cnt = 0, swampTG_Cnt = 0, fireTG_Cnt = 0, dEarthTG_Cnt = 0;
	
	public static GameObject curPlot;
	public static GameObject curTG;
	public static GameObject curBuilding;
	public static GameObject curDecoration;
	public static GameObject curCave;
	public static GameObject curDelObj;
	public static GameObject curGoldBuilding;
	
	public static GameObject currentPlant;
	public static GameObject currentCreature;
	public static GameObject currentSelectedObject = null;
	public static GameObject currentMovableObj = null;
	public static GameObject curCreature01;
	public static GameObject curCreature02;
	public static GameObject hCreatureAttackingCave_GO = null;
	public static GameObject dCreatureAttackingCave_GO = null;
	//public static GameObject curCreature;
	//public static GameObject currentTrainingGround
	
	public static int dPlotCnt = 1, placeDPlotCnt = 1;
	public static int hPlotCnt = 1, placeHPlotCnt = 1;
	public static int dInn01Cnt = 1, placeDInn01Cnt = 1;
	public static int hInn01Cnt = 1, placeHInn01Cnt = 1;
	public static int dStableCnt = 1, placeDStableCnt = 1;
	
	private float curXP = 0f;
	public static int curLevel = 0;
	private float totalXP = 0;


    private static bool _placeObjectBool;
    public static bool placeObjectBool {
        get { return _placeObjectBool; }
        set
        {
            Debug.Log("NEW " + value);
            _placeObjectBool = value;
        }
    }
    public static bool createCreatureBool = false;
	public static bool upgradePlotBool = false;
	public static bool upgradePlotRabbitBool = false;
	public static bool upgradeTrainingGroundBool = false;
	public static bool multipleDecorationBool = false;
	public static bool upgradeInn = false;
	public static bool upgradeInnRabbit = false;
	public static bool upgradeDInn = false;
	public static bool upgradeDInnRabbit = false;
	public static bool upgradeStable = false;
	public static bool upgradeStableRabbit = false;
	public static bool upgradeBlackSmith = false;
	public static bool upgradeBlackSmithRabbit = false;
	public static bool upgradeDStable = false;
	public static bool upgradeDStableRabbit = false;
	public static bool upgradeDBlackSmith = false;
	public static bool upgradeDBlackSmithRabbit = false;
	public static bool upgradeHHouse = false;
	public static bool upgradeHHouseRabbit = false;
	public static bool upgradeDHouse = false;
	public static bool upgradeDHouseRabbit = false;
	public static bool upgradeEarthObelisk = false;
	public static bool upgradeEarthObeliskRabbit = false;
	public static bool upgradePlantObelisk = false;
	public static bool upgradePlantObeliskRabbit = false;
	public static bool upgradeWaterObelisk = false;
	public static bool upgradeWaterObeliskRabbit = false;
	public static bool upgradeSwampObelisk = false;
	public static bool upgradeSwampObeliskRabbit = false;
	public static bool upgradeDEarthObelisk = false;
	public static bool upgradeDEarthObeliskRabbit = false;
	public static bool upgradeFireObelisk = false;
	public static bool upgradeFireObeliskRabbit = false;
	public static bool editCreatureNameTutBool = false;
	
	public static bool readyAttact = false;
	public static bool readyAttackBool = false;
	public static bool readyFarm = false;
	public static bool readyHarvest = false;
	public static bool unlockDarklingBool = false;
	public static bool hBuildingConstructBool = true;
	public static bool dBuildingConstructBool = true;
	public static bool questActivateBool = false;
	public static bool questRunningBool = false;
	public static bool destroyQuestPbBool = false;
	public static bool readyToUnlockDarklingBool = false;

	private static bool _bridgeBuild = false;
	public static bool bridgeBuildBool
	{
		get
		{
			return _bridgeBuild;
		}
		set
		{
			Debug.Log("I am here you piece of " + _bridgeBuild);
			
			_bridgeBuild = value;
		}

	}
	
	public static bool placeHGardenPlotBool = false;
	public static bool placeDGardenPlotBool = false;
	public static bool upgradeHGardenPlotBool = false;
	public static bool upgradeDGardenPlotBool = false;
	
	public static bool panelAccessBool = true;
	public static bool burrySparkBool = false;
	
	public static bool battleActiveBool = false;
	
	public static bool miniGamesaccelerateBool = false;
	
	public static bool FeedMorphPopupCancleBool = true;
	
	// training ground upgrade information
	public static int earthTG_lvl = 1, plantTG_lvl = 1, waterTG_lvl = 1, swampTG_lvl = 1, dEarthTG_lvl = 1, fireTG_lvl = 1;
	
	// halfling creature level
	public static int hound_lvl = 0, barg_lvl = 0, cusith_lvl = 0, sprout_lvl = 0, nymph_lvl = 0, dryad_lvl = 0, nix_lvl = 0, draug_lvl = 0, dragon_lvl = 0;
	
	// darkling creature level
	public static int leech_lvl = 0, dHound_lvl = 0, sprite_lvl = 0, leshy_lvl = 0, fenrir_lvl = 0, imp_lvl = 0, lurker_lvl = 0, hellHound_lvl = 0, djinn_lvl = 0;
	
	// building upgrade
	public static int plot_lvl = 1, dPlot_lvl = 1;
	
	public static int EarthTgGoldlvl1 = 20, EarthTgGoldlvl2 = 60,EarthTgGoldlvl3 = 120;
	public static int PlantTgGoldlvl1 = 80, PlantTgGoldlvl2 = 140, PlantTgGoldlvl3 = 190;
	public static int WaterTgGoldlvl1 = 75, WaterTgGoldlvl2 = 135, WaterTgGoldlvl3 = 195;
	public static int SwampTgGoldlvl1 = 40,SwampTgGoldlvl2 = 70 , SwampTgGoldlvl3 = 120;
	public static int FireTgGoldlvl1 = 60,FireTgGoldlvl2 = 90 , FireTgGoldlvl3 = 140;
	public static int DarkEarthTgGoldlvl1 = 50,DarkEarthTgGoldlvl2 = 80,DarkEarthTgGoldlvl3 = 130;
	
	public static float layerDivVal = 1000;
	
	RaycastHit hit;
	RaycastHit guiHit;
	public Camera cam;
	public Camera guiCam;
	
	public guiControl guiControlInfo;
	public popUpInformation popUpInfoScript;
	public LevelControl levelControlInfo;
	public QuestTextureControl scr_QuestTexControl;
	public unlockCaveTimerTut scr_UnlockCaveTimerTut;
	
	public AudioController scr_audioController;
	private taskDetails scr_TaskDetails;
	
	//public LoadUserWorld scr_LoadUserWorld;
	
	public bool guiHitBool = false;
	
	public static Vector3 selObjectPos;
	public static Vector3 firstDirtPathPos;
	
	//public GameObject CongratsParticleEffect;
	
	
	// public prefab GameObject
	
	// creature
	public GameObject c_Hound_PF, c_Barg_PF, c_Cusith_PF, c_Sprout_PF, c_Nymph_PF, c_Dryad_PF, c_Nix_PF, c_Draug_PF, c_Dragon_PF;
	public GameObject c_DHound_PF, c_Fenrir_PF, c_HellHound_PF, c_Sprite_PF, c_Imp_PF, c_Djinn_PF, c_Leech_PF, c_Leshy_PF, c_Lurker_PF;
	public GameObject houndAttack_PF, bargAttack_PF, cusithAttack_PF, sproutAttack_PF, nymphAttack_PF, dryadAttack_PF, nixAttack_PF, draugAttack_PF, dragonAttack_PF,
						dHoundAttack_PF, fenrirAttack_PF, hellHoundAttack_PF, spriteAttack_PF, impAttack_PF, djinnAttack_PF, leechAttack_PF, leshyAttack_PF, lurkerAttack_PF;
	
	// building
	public GameObject h_Inn_PF, h_Stable_PF, h_BlackSmith_PF, h_Apothecary_PF, h_Tavern_PF, h_EarthObelisk_PF, h_PlantObelisk_PF, h_WaterObelisk_PF, h_SunShrine_PF;
	
	// training ground
	public GameObject tg_TrainingGround_PF, tg_Water_PF;
	public GameObject tg_Swamp_PF, tg_DEarth_PF, tg_DFire_PF;
	
	// Decoration Item
	public GameObject h_DirtPath_PF, h_FruitTree_PF, h_Tree_PF, h_Barrel_PF, h_Well_PF, h_Lantern_PF, h_Woolpile_PF, h_WheelBurrow_PF, h_Shroomrey_PF, h_Cornfield_PF, h_Cottage_PF, h_HalflingKnoll_PF, h_PartyTent_PF, h_Scarecrow_PF, h_WindMill_PF, h_StoneFence_PF,
					  d_DirtPath_PF, d_Tree_PF, d_Well_PF, d_Bog_PF, d_RevenPerch_PF, d_BirdHouse_PF, d_WindMill_PF, d_HuntingTent_PF, d_Scarecrow_PF, d_StoneFence_PF, d_SwampKnoll_PF;
	
	// darkling building
	public GameObject d_Plot_PF;
	public GameObject d_Inn_PF, d_DStable_PF, d_BlackSmith_PF, d_Apothecary_PF, d_Tavern_PF, d_EarthObelisk_PF, d_SwampObelisk_PF, d_FireObelisk_PF, d_MoonShrine_PF;
	
	// halfling Plant
	public GameObject h_Turnip_PF, h_PipeWeed_PF, h_Pumpkin_PF, h_Costmary_PF, h_FairyLily_PF, h_Potatoes_PF, h_Watercress_PF, h_Mandrake_PF, h_Vervain_PF, h_Sunflower_PF;
	
	// darkling Plant
	public GameObject d_Pumpkin_PF, d_FirePepper_PF, d_Columbine_PF, d_BlackBerry_PF, d_Aven_PF, d_BitterBush_PF, d_BogBean_PF, d_Wolfsbane_PF, d_Moonflower_PF;
	
	// Particle
	public GameObject par_Coin_PF, par_Plant_PF, par_Herb_PF, par_LevelFireWork_PF, par_TutFireWork_PF, par_GolumAppear_PF, par_Congratulation_PF,
						par_HCreatureGenEff_PF, par_DCreatureGenEff_PF, par_ObjectUpgrade_PF, par_OrcAttack_PF, par_OrcGen_PF;
	
	// gui text declaration for ref
	public GUIText guiTaskCound;
	public GUIText guiPopUpCount;
	public GUIText guiXP;
	public GUIText guiQuest;
	public GUIText guiSelectedObj;
	public GUIText guiSpark;
	public GUIText guiLevelXP;
	public GUIText guiQuestActivate;
	public GUIText guiQuestRunning;
	public GUIText guiPopUpBool, guiPopUpOpenBool, guiObjectSelectionBool, guiObjectPlaceBool, guiBurrySparkBool, guiNetSpeed;
	public GUIText guiDirthPathPos;
	
	private int gcEarthTG = 50, gcDirtPath = 10, gcPlot = 20, gcInn01 = 35;
	
	public static float levelXPCnt = 100000;
	
	public bool questA = false, questB = false, questC = false;
	public bool loadingBool = true;
	
	public Texture2D loadlingScreen;
	
	public GameObject battle;
	private BattleGroundManager bmgr;
	public GameObject bubbleObj;
	public GameObject speakTextObj;
	
	public int storyCount = 0, clickCounter = 0;
	
	// Level 1 Dialogs
	public	string[] level01Dialog = {"Ahh... nothing like a pint at the end of another day's work... Well, a few pints anyway...",
								"Not sure sleeping and eating cheese counts as work friend.",
								"I say it's hard work tending to all my ladies.",
								"You mean those scrawny hens that kackle about your hovel?",
								"Well sirs, I am off. A lovely night to the most of you."
							 };
	
	public	string[] level02Dialog = {	"*singing* curvy maids a dancin', I'll take one home tonight... and wed come winters morning', and bed come summers night...",
								"*singing* curvy maids a dancin', I'll take one home tonight... and wed come winters morning', and bed come summers night..."
							 };
	
	public	string[] level03Dialog = {	"Oh! Uh, good evening good sir.",
								"Take the Spark... bury it deep in the earth!",
								"What? Who are you?",
								"bury it deep!"
							 };
	
	public	string[] level04Dialog = {	"Wait... I don't want this! Take it back! Who are you?",
								"Wait... I don't want this! Take it back! Who are you?"
							 };
	
	public	string[] level05Dialog = {	"What a strange dream... to much Ale...",
								"It wasn't a dream, what do I do now?",
								"...bury it deep... bury it deep..."
							 };
	
	// LEVEL 3 DAILOGS //
public	string[] level3Dialog = 	{"I heard Ol Farmer McGee is missing 12 chickens this time.",
							 "That old man is full of tales o' lore and dark magic. Nothin' but stories to scare the little ones if you ask me.",
							 "He says it happens in the middle of the night with no trace of the thieves, but a feelin' o' dark magic in the air come mornin.",
							 "Oh, yes.. yes... Next he'll be fillin your head with stories of the dark kind beyond the broken bridge I suppose?",
							 "And just where do you suppose his chickens is goin then?",
							 "How would I know?... Probably being eaten by that very large wife of his! Ha Ha!..."
							};
	
	public	string[] quest_1A = 	{"That's a very large dog you have there!",
						 	 "Oh, hello Master McGee. Yes... he eats well..",
						 	 "Does he eat chickens?!'",
							 "What? No... no, of course not...",
						 	 "Hmmm...' Well, My chickens keep disappearing in the night. Lost 12 the other night. Dark magic if you ask me. Tell you what, I'll give you some gold if you let me borrow him for a night to guard my chickens.",
							};
	
	public	string[] quest_1B = 	{"No chickens lost last night, Your dog fends off dark magic very well.",
							 "Why do you think it's dark magic?",
							 "Ah, you're just like the others. Considering what land you live on, I'd think you'd know better boy.",
							 "The land I live on?  What do you mean?",
							 "Of course you don't know... probably would never have moved on that land...",
							 "If what? What about my land?",
							 "I've lived on this land for eleventy one years and in all that time no one has lived closer to that there chasm as I have. Perhaps that's why I still remember. No one, until you came that is.",
							 "Remember what?",
							 "You live on Darkling land, boy.",
							 "Darkling?",
							 "Thanks for your dog...",
							};
	
	// Quest 2 Dialogs
	public	string[] quest_2A = 	{"Hello friend.",
							 "Who are you?",
							 "As I said, a friend.",
							 "I don't know.",
							 "I am here to help you. To give you this.",
							 "What is that... that... thing?",
							 "The Halflings are breeding an army. They see your clan as a scourge and want to chase you from the crest, or kill you if you stay. This will help you defeat them.",
							 "The Halflings? Who Are you?",
							 "Take it. Bury it deep....bury it deep... bury it deep...",
							};
	
public	string[] quest_2B = 	{"Don't know why I even bother... Hardly nothing grows on this cursed murky land, I should just leave farming to the fat Halflings... Cursed thieves...",
							 "Don't know why I even bother... Hardly nothing grows on this cursed murky land, I should just leave farming to the fat Halflings... Cursed thieves..."
							};
	// Quest 3 Dialogs
public	string[] quest_3 =			{"What is that creature?",
						 "It is the begining uncle. This is how we are going to finally take back what is ours in the crest from those lying Halfling scoundrals.",
						 "Hmmm... well, whatever it is, it looks danderous. Send it with us tonight. We are going to get some more chickens and pipe weed from the old Halfling farmer across the chasm. It will help us if that blasted monstrous hound is still there."
						};
	
	// Quest 4 Dialogs
public	string[] quest_4 = 			{"There you are boy. I'm sorry, your creature is gone.",
						"Uncle Brentas, what happened?",
						"Your creature saved us boy.  We got some chickens before that Hound came at us again, we would have all been killed had your leech not fought it off.",
						"Leech?  Oh, it killed the Hound then?",
						"Don't know boy, they both disappeared into the forest while fighting. It didn't come back. Too bad too, that Leech could his own.",
						"I need to find him."
					   };
	
	// Quest 5 Dialogs
public	string[] quest_5 = 			{"That Hound of yours is quite handy!",
						"Hmmm...",
						"Though... they still did get away with a few of my chickens...",
						"And, who's 'they'.",
						"The Chicken Thieves of course! Only this time, they had some strange dark creature with them.  Took all your Hound had to chase it off!",
						"Hmmm...",
						"As big as that dog of yours is, I wish it were even bigger!",
						"Bigger?  Hmmm... perhaps I can help. Could cost a little gold though.",
						"Let me know if you come up with something.  I'll finish the story about your land."
					   };
	
	
	//Screen Shot – Wizard & Halfling
	public	string[] quest5_DialogA = {	"I'm glad you came. I have something to help you.",
								"A bigger Hound?",
								"Of sorts... yes. Try feeding your Hound X more sparks.",
								"What will happen?",
								"You will see..."
							 };
	
	public string[] quest5_DialogB = {	"Wow, is that the same dog? What happened? Nevermind, I don't want to know. Its not my business what you meddle with on that cursed land. Whatever he is, he should do the trick.",
								"Cursed land?",
								"Don't meddle with dark magic boy, or you could also end up like those darkling neighbors of yours.",
								"You're my only neighbor Master McGee...",
								"Fool of a halfling! Across the chasm, across that bridge that you repaired. There was another fool halfling that meddled in dark magic. owned the same land you live on. Maybe they still do. ",
								"Hmmm...",
								"Bristol Darting was his name.Went to trial for using dark magic. Got banished just over yonder across that chasm, in the swamps.",
								"Hmmm...",
								"Night creatures they are, never come out in the daytime, nobody sees them, but they are there. Dark evil things they are, never met one myself, they were banished before my time, but my ol' Gaffer told me all about them. Stay away from the dark magic, your land is cursed with it."
							  };
	
	// Quest 6 Dialogs
public	string[] quest_6 = 			{"Did you find your creature?",
						"Yes Uncle.  Those Theiving Halflings have blasphemed the Darting name long enough. Its time we took back what is rightfully ours.",
						"That Hound of theirs was strong. We need some more of your leeches to ensure success.",
						"Hmmmm.....",
						"Here, take some of these chickens, along with some tasty pumpkins to Old Widow Stufflebrew. The news of our new creature here, along with some stew, may help revive her tired bones.",
						};
	
	public	string[] quest_6A = {"Thank you for the chickens, but I don't care for pumpkins youngling.",
						"Sorry Widow Stufflebrew, Uncle Brentas thought you might enjoy a stew from them.",
						"That fool Brentas has forgotten too much.",
						"Forgotten?",
						"My mother would never have allowed a pumpkin to be grown on these lands. She was there when our Father Bristol grew the largest pumpkin the Crest had ever seen, and was accused of using dark magic to grow it. Fatling liars!",
						"Bristol Darting was a farmer?",
						"Is none teaching you your own history yougling? Our family was once the grandest farmers in the Crest! Until we were cheated out of our land and cast out to this forsaken swamp that grows so little we turned to hunting for our well-being.",
						"Hmmm...",
						"Toss your pumpkin into the chasm where it belongs..."
						};
	
	public string [] quest_6B = {"You are one of us then!",
								"I humbly serve",
								"You should show your allegiance with more zeal my brother. Take this tabard, wear it with pride.",
								"For the Horde",
								"For the Horde!"
								};
	
public	string[] quest_7 = 		{"We have a problem.",
		                "problem? We?",
		                "A traveler has arrived in the crest.  He is asking questions, too many questions. ",
		                "Oh! Yes, yes. We get many travelers in this area. The Crest is quite famous for our pipe leaf you know...",
		                "Unfortunately this traveler is not after your Halfling leaf. He has come for the spark.",
		                "The spark?  Who is this traveler, can we sell it to him?",
		                "Dimwitted Halfling. Your leaf is slowing your wits... That spark is the only thing that can destroy the... What will you do when those darklings come back for their land? They are building an army Halfling. They will kill any townsfolk that stands in their way.",
		                "Army? Darklings?  What shall we do? Are they coming now? ",
		                 "Why do you think I gave you that spark? You must build an army to protect yourself. Protect your lands. But you need the spark to do it. You must distract the traveler. Keep him off your farm. Keep him... hmmm... keep him full of ale....here is a gift."
                      };
	
	public	string[] quest_7A = {"Greetings young Halfling.",
	                     "Oh, Hello! H-h-how can I h-help you? ",
	                     "That is a very interesting creature you have there, it reminds me of something.  Where did you acquire it? ",
	                     "What? Creature? Oh, you mean that ordinary dog there? Just a mangy lost hound that wandered onto my farm here. You must be very tired, traveling here n' all. Would you care for something to quench your thirst?",
	                     "I would like to ask you some questions young Halfling, but yes, I suppose some ale would not go a miss."  ,
	                     "To the Tavern then good sir."
						};
	
	
//public	string[] quest_8 = {"Brentas asked me to check in on you.",     
//		                "Here youngling. Some stew from those chickens you brought.",
//		                "Thank you Mistress Stufflebrew.",
//		                "Brentas mentioned that you have something of a new pet?",
//		                "Ah yes, my new creature.  It is what is going to help us get back our land Mistress.",
//		                "I see.. So, you have taken up our family's cause then.  And what can this creature do?",
//		                "He may look small, but he is fierce. Uncle Brentas wants me to get more." ,
//		                "Fierce you say? Hmmm... maybe not fierce enough. Visit me in a few days, I may have something to help."
//	                    };
//	
//	public	string[] quest_8A = {"Ah, youngling. Just in time, the serum is almost ready. Just need one last ingredient.",
//		                 "Ingredient? Serum? ",
//		                 "Yes youngling. You want that creature of yours to be fierce you said, yes? This serum will make it that, and more.",
//		                 "What do you need from me? ",
//		                 "Bring me some Aven pedals. It is a flower that grows near swampy areas. Then we shall see how fierce your creature can be.",
//		                 "Ah, Aven pedals! Its great to see something useful finally growing again in this cursed land. Perhaps not all is lost afterall... Infused with my special herbs, you will find Aven has a potent effect on creatures of the swamp, such as your leech. Good luck."
//	                     };

public	string[] quest_8 = {"Brentas asked me to check in on you.",     
		                "Here youngling. Some stew from those chickens you brought.",
		                "Thank you Mistress Stufflebrew.",
		                "Brentas mentioned that you have something of a new pet?",
		                "Ah yes, my new creature.  It is what is going to help us get back our land Mistress.",
		                "I see.. So, you have taken up our family's cause then.  And what can this creature do?",
		                "He may look small, but he is fierce. Uncle Brentas wants me to get more." ,
						"Fierce you say? Hmmm... maybe not fierce enough. Visit me in a few days, I may have something to help.",
						"Ah, youngling. Just in time, the serum is almost ready. Just need one last ingredient.",
		                 "Ingredient? Serum? ",
		                 "Yes youngling. You want that creature of yours to be fierce you said, yes? This serum will make it that, and more.",
		                 "What do you need from me? ",
		                 "Bring me some Aven pedals. It is a flower that grows near swampy areas. Then we shall see how fierce your creature can be.",
	};

	public	string[] quest_8A = {
		                 "Ah, Aven pedals! Its great to see something useful finally growing again in this cursed land. Perhaps not all is lost afterall... Infused with my special herbs, you will find Aven has a potent effect on creatures of the swamp, such as your leech. Good luck."
	                     };
		                
	
public	string[] quest_9 = 			{"How is our friend doing?",
		                "He is still in my tavern, asking suspicious questions about my pet, and talking with the townsfolk. I can't afford to keep distracting him with my best ale!",
		                "Yes, we can't have you slowing progress on our army... ",
		                "Can't you take him for a while, get him out of my tavern! ",
		                "I can't draw him any closer to the spark. Hmmm... but perhaps we can rid ourselves of his prying for a time. Have you any pipe leaf?",
		                "I've already given half my ale, now you want my leaf too ?",
		                "Dimwitted Halfling... an infusement of pipe leaf with a pinch of common costmary produces a strong sleeping drought. Potent enough to make a cusith sleep for days... ",
		                "Sleep for days?  Yes, I could use some rest...",
		                "Not for you! You slowminded... Ah hem... For the traveler.",
		                "Oh, yes, of course, the traveler. Good idea.",
		                "You will need an alchemy for the infusement, and somewhere for our friend to lay his head once its administered of course...",
		                "Greetings Traveler! One more drink before we have our chat?"  
	                   };
		
	public	string[] quest_9A = {"Thank you young Halfling. Truly your Crest Ale is as strong as legend tells. I find myself nere able to walk... Were it not for my purpose here I might find your land and hospitality quite enjoyable...",
		                 "Purpose sir? ",
		                 "I must find it... must return it... It was stolen you see... a powerful young wizard. Stolen from the Eldars. Must return it... too much power. Need to destroy it... no one can possess such power..."
	                    };
	
public	string[] quest_10 = 		{"I see you're making progress here young Master Darting. Unfortunately the Halflings are making progress as well.",
		                 "Those dirty Halflings! What progress are they making? Surely they can't defeat my creatures?  ",
		                  "Don't underestimate their hate for you youngling, they will stop at nothing to see you finished.",
		                  "What can we do? We need more creatures? More potions?  It too costly...",
		                  "You must work harder youngling, work longer. Work in the day as well as night.",
		                  "In the Day?! The day is no good! Too bright, my creatures don't like it, my plants don’t grow... we are hunters here, we are night people. Not fat farming Halflings!",
		                  "Yes, but there is another way. Seek out a moonshrine, and lay upon its altar a moonflower. You will find your daytime much more.... Agreeable."
	                    };
	
	
	public	string[] quest_10A = {"Well done Master Darting. You are beginning to understand the gifts of your ancestors. Bristol often used the moon shrine to grow crops.",
	                      " Bristol? He was known for large pumpkins! Won that contest!",
	                      "Yes, the contest that took his life." ,
	                      "You mean the fat Halflings that killed him?",
	                      "Yes, those fat Halflings. Keep building that army."
						};
	
	
public	string[] quest_11 = 		{"Wha... where am I? Festering Swamp...? He must have found me, he tried to kill me... ",
	                     "Who are you? What are you doing here? ",
	                     "What creature is that? ",
	                     "Nevermind my pet, Who are you? ",
	                     "My business is my own.",
	                     "You are alive now only because my pet has been protecting you from wild creatures since nightfall. Answer my question or you will be left to fend for yourself, and I assure you, you won't last long in this swamp.",
	                     "Last I remember I was at an Inn on a Halfling farm. He lied to me and left me here for dead.  ",
	                     "What do you know of Halflings?",
	                     "I know that you share similar pets." ,
	                     "I could leave you here to die.",
	                     "I know more about the elements and its creatures than you think. Find me some good pipeweed, tell me about your “pet”, and I will show you the true power of the swamp."
	                     };
	
	
	public	string[] quest_11A = {"That is an interesting story Master Darting, truly your people have been wronged by your Halfling brothers. Perhaps I can help.",
	                      "The Halflings are no brothers of mine.  Now, what is this swamp power you spoke of? ",
	                      "I am a guardian of the Eldar, there are many secrets of the elements we know. Build yourself an obelisk from the elements of the swamp. Where you place it, the creatures of that element will grow strong.",
	                      "Creatures? " ,
	                      "Don’t take me for a fool Master Darting. I have seen the unnatural creatures your Halfling brothers possess also. Your Wizard friend is deceiving you."
	                     };
	
public	string[] quest_12 = 		{"Greetings young Halfling, what are you doing here?  Have I not impressed the importance of the work you are doing on your farm? ",
	                     "The traveler is gone. ",
	                     "Gone?....  Where? ",
	                     "He must have wandered off in the night! I thought you said he would sleep for days.",
	                     "And I thought I told you to keep an eye on him. One doesn't always stay in one place when one sleeps.",
	                     "My half cousin on my mothers side often sleep walks, once he woke up in a pig trough. Probably would have kept sleeping had one of the pigs not bitten one of his toes clear off! ",
	                     "Fool of a Halfling... we must find him. Take 3 of your strongest creatures and hunt him down. "
	                     };
	
	public	string[] samSpeak_00 = {"I need your help desperately, and it is a most humble honor to have your service!",
							"Halfings have occupied this land for thousands of years. However, this one you see here has just recently arrived.",
							"Though presently unawares, he is about to play a very important role in the future of not just this land... but all civilization, good & evil.",
							"At the moment however, our young Halfling friend is spending far too much time at the local tavern. In fact, he is on his way there now.",
							"Lets join him..."
							};
	public	string[] samSpeak_01 = {//"Well done Halfling, that creature of yours is fierce. Keep an eye out for more unwelcomed visitors less the attack you while your sleeping.",
							"And remember to speed things alogn with extra sparks... Time, I'm afraid , is not our ally",
							"Watch the global clock carefully. Tap on the clock to activate"
							};
	
	private int samIndex = 0, task13Index = 0;
	
	public int dialogCnt = 0, maxDialogCnt = 0;
	private bool dialogABool = true, diallogBBool = false;
	private bool cheat = true;
	private SfsRemote scr_remote;
	
	private int introStory = 0;
	
	public GameObject halflingChar;
	public GameObject darklingChar;
	public GameObject halflingSmokingChar;
	public GameObject darklingSmokingChar;
	
	private bool gameOverBool = false;
	public Texture gameOverScreen;
	
	private GameObject menuObj;
	
	private GameObject loadingScreenObj;
	
	public GameObject hChar, dChar,hsChar,dsChar;
		
	public static bool houndUsingBool = false, bargUsingBool = false, cusithUsingBool = false, sproutUsingBool = false, nymphUsingBool = false, dryadUsingBool = false, nixUsingBool = false, draugUsingBool = false, dragonUsingBool = false, 
						leechUsingBool = false, leshyUsingBool = false, lurkerUsingBool = false, dHoundUsingBool = false, fenrirUsingBool = false, hellHoundUsingBool = false, spriteUsingBool = false, impUsingBool = false, djinnUsingBool = false;
	
	 private AchivementsDetails ad;
	public static GameObject halfCurrDirtPath;
	public static GameObject darkCurrDirtPath;
	
	public GameObject xpValObj;
	
	public GameObject h_Character, d_Character;
	
	WebClient wc = new WebClient();
	public double kbps;
	string path;
	
	public static Vector3 lastDirtPathPosition, lastDDirtPathPosition;
	
	public static Vector3 hGCreature01, hGCreature02;
	public static Vector3 dGCreature01, dGCreature02;
	
	public GameObject obelisk3x3, obelisk4x4, obelisk8x8;
	
	public GameObject levelCompleteScreen, foodIconCol_pf;
	
	public String houndName, bargName, cusithName, sproutName, nymphName, dryadName, nixName, draugName, dragonName, 
					leechName, leshyName, lurkerName, dHoundName, fenrirName, hellHoundName, spriteName, impName, djinnName;
	
	/*void SpeedTest()
	{
		double startTime;
		Uri url = new Uri("http://www.spirit5.co/spirit5_Projects/HalflingWars/speedtest/HW_speedtest.txt");
		
		if(Application.platform == RuntimePlatform.IPhonePlayer)
		{
			path = Application.dataPath+ "/../../Documents/" + "speedtext.txt";
		}
		else
		{
			path = Application.dataPath +"speedtext.txt";
		}
		startTime = Environment.TickCount;
		
		wc.DownloadFile(url,path);
		double endTime = Environment.TickCount;
		
		double secs = Math.Floor(endTime - startTime) / 1000; 
		double secs2 = Math.Round(secs, 0);
		
		kbps = (Math.Round(1024 / secs))/10;
		//guiNetSpeed.text = kbps.ToString();
		Debug.Log("KBPS  "+kbps);
//		if (kbps < 20)
//		{
//			popUpInfoScript.defaultPopUpBool = true;
//			popUpInfoScript.defaultPopUp(59, 0);
//			scr_remote.runRedirectBool = true;
//		}
	}*/

	public static string objectCost;
	
	void Awake()
	{
		scr_audioController = GameObject.Find("Audio").GetComponent<AudioController>();
		scr_remote = GameObject.Find("sfxConnect").GetComponent<SfsRemote>();
		loadingScreenObj = GameObject.Find("LoadingScreen 1") as GameObject;
		scr_TaskDetails = GameObject.Find("TaskDetails").GetComponent<taskDetails>();
		
		Application.runInBackground = true;

	}
	
	// Use this for initialization
	void Start () 
	{
		//InvokeRepeating("SpeedTest",float.Epsilon,3f);d


		
		if (gameLevel == 1)	levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level1); //51;
		if (gameLevel == 2)	levelXPCnt = 341;//levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level2);//151 ;//241;
		if (gameLevel == 3) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level3);//600;
		if (gameLevel == 4) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level4);//1200;
		if (gameLevel == 5) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level5);// 1600;
		if (gameLevel == 6) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level6);//2300;
		if (gameLevel == 7) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level7);//4500;
		if (gameLevel == 8) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level8);//5625;
		if (gameLevel == 9) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level9);//6900;
		if (gameLevel == 10) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level10);//8250;
		if (gameLevel == 11) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level11);//16125;
		if (gameLevel == 12) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level12);//18625;
		if (gameLevel == 13) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level13);//30000;
		if (gameLevel == 14) levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level14);//37500;
		
		
		hChar = Instantiate(halflingChar, new Vector3(-63f, 0.05f, 2.8f), Quaternion.Euler(90, 0, 0)) as GameObject;
		dChar = Instantiate(darklingChar, new Vector3(60, 0.05f, 2.9f), Quaternion.Euler(90, 0, 0)) as GameObject;
		hsChar = Instantiate(halflingSmokingChar, new Vector3(-64f, 0.1f, 3.7f), Quaternion.Euler(90, 0, 0)) as GameObject;
		dsChar = Instantiate(darklingSmokingChar, new Vector3(63f, 0.1f, 3.7f), Quaternion.Euler(90, 0, 0)) as GameObject;
		 		ad = (AchivementsDetails)FindObjectOfType(typeof(AchivementsDetails));
		
		bmgr = battle.GetComponent<BattleGroundManager>();
		
		h_Character.transform.position = new Vector3(-64.24f, 0.03f, 1.6f);
		hChar.SetActiveRecursively(false);
		dChar.SetActiveRecursively(false);
		
		d_Character.transform.position = new Vector3(64.24f, 0.03f, 1.6f);

		if (gameLevel == 2)
			levelXPCnt = 10000;
		
	}
	
	void OnGUI()
	{
//		if (GUI.Button(new Rect(100, 100, 200, 200), "Kill")) {
//			if(scr_remote.sfs != null)
//				scr_remote.sfs.KillConnection();
//		}
		
		
		//GUILayout.Label(lastDirtPathPosition.ToString());
		guiTaskCound.text = "Task Count :: " + taskCount.ToString();
		guiPopUpCount.text = "PopUp Count :: " + popUpCount.ToString();
		guiXP.text = "XP :: " + xp.ToString();
		guiQuest.text = "Quest :: " + quest.ToString();
		guiSpark.text = "StoryCnt :: " + GameManager.storyCnt.ToString();
		guiLevelXP.text = "Level XP :: " + levelXPCnt.ToString();
		guiSelectedObj.text = "Game Level : " + gameLevel.ToString();
		guiQuestActivate.text = "Quest Activate : " + questActivateBool.ToString();
		guiQuestRunning.text = "Quest Running : " + questRunningBool.ToString();
		guiPopUpBool.text = "Default PopUp Bool : " + popUpInfoScript.defaultPopUpBool.ToString();
		guiPopUpOpenBool.text = "PopUp Open Bool : " + guiControl.popUpOpenBool.ToString();
		guiObjectSelectionBool.text = "Object Selection Bool : " + objectSelection.objectSelectionBool.ToString();
		guiObjectPlaceBool.text = "Object Place Bool : " + placeObjectBool.ToString();
		guiBurrySparkBool.text = "Burry Spark Bool : " + unlockDarklingBool.ToString();
		guiNetSpeed.text = kbps.ToString();
		guiDirthPathPos.text = "DirtPath Pos : " + lastDirtPathPosition.ToString();
		
		if (loadingBool)
		{
			if (loadingScreenObj.activeInHierarchy == false)
				loadingScreenObj.SetActiveRecursively(true);
			
			if (guiControlInfo.popUpType4.activeInHierarchy == true)
				loadingBool = false;
		}
		else
		{
			if (loadingScreenObj.activeInHierarchy == true)
				loadingScreenObj.SetActiveRecursively(false);
		}
		
		if (gameOverBool)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen);
		}
	}
	
	private void PlayAudioforLevelComplete()
	{	
		scr_audioController.audio_FireCracker.Play();
		scr_audioController.audio_FireCracker.minDistance = 1;
		scr_audioController.audio_FireCracker.maxDistance = 300;
		scr_audioController.audio_FireCracker.volume = 0.7f;
		
		scr_audioController.audio_applaud.Play();
		scr_audioController.audio_applaud.minDistance = 1;
		scr_audioController.audio_applaud.maxDistance = 300;
		scr_audioController.audio_applaud.volume = 0.5f;
		
		scr_audioController.audio_achievement.Play();
		scr_audioController.audio_achievement.minDistance = 1;
		scr_audioController.audio_achievement.maxDistance = 300;
		scr_audioController.audio_achievement.volume = 0.9f;
	}
	
	private int indexCnt = 0;
	public static bool levelCheckBool = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.frameCount % 30 == 0)
		{
		    //System.GC.Collect();
		}
		
		if(gameLevel<3)
		{
			hsChar.SetActiveRecursively(false);
			dsChar.SetActiveRecursively(false);
		}
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		Ray guiRay = guiCam.ScreenPointToRay(Input.mousePosition);
		
		if (gameLevel == curLevel && levelCheckBool)
		{
			if (curXP < 1)
			{
				curXP = xp / levelXPCnt;
				gameProgressBar.transform.localScale = new Vector3(curXP, gameProgressBar.transform.localScale.y, gameProgressBar.transform.localScale.z);
			}
			else if (gameLevel > 0)
			{
				gameLevel++;
				if (gameLevel >= 1)
					scr_remote.SendCurrentLevelrequest(gameLevel);
                if (curLevel > 3)
			    {
			        guiControl.I.deleteButton();
			    }
			    curLevel++;
				curXP = 0;
				xp = 0;
				
				//scr_remote.SendRequestforInAppPurchase(1,0); //for sparks adding after each level

				//sparks++;
				guiControlInfo.sparkScoreInfo.Text = sparks.ToString();
				guiControlInfo.levelScoreInfo.Text = gameLevel.ToString();
				levelControlInfo.UnlockItems();
				
				// level 1 pop up
				if (gameLevel == 2)
				{
					popUpInfoScript.curPopUpCnt = 14;
					popUpInfoScript.curPopUpType = 0;
					taskCount = 9;
					popUpInfoScript.updateTaskCount();
					
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level2);//151 ;//241;
					
					Destroy(guiControlInfo.delArrow);
					
					panelControl.panelMoveIn = true;
					panelControl.panelMoveOut = false;
					
//					buttonPulse marketBP = GameObject.Find("button_Market").GetComponent("buttonPulse") as buttonPulse;
//					marketBP.scaleAnim = false;
					
					GameObject.Find("Main Camera").transform.position = GameObject.Find("goblinCamp_cPos").transform.position;
					
					//GameObject.Find("Main Camera").transform.position = GameObject.Find("goblinCamp_cPos").transform.position;
					
					objGridMove.camMoveBool = true;
					grid.curObj = null;
				}
				
				if (gameLevel == 3)
				{
					popUpInfoScript.curPopUpCnt = 22;
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);

					guiControlInfo.popUpType1.transform.FindChild("samImage").gameObject.active = true;
					
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					GameObject tFireWork = Instantiate(par_TutFireWork_PF, new Vector3(-41.5f, 20, 52.7f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					tFireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					questActivateBool = true;
					levelXPCnt =  scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level3); //300;
	///***				Debug.Log("Change tag...");

					GameObject tempTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					if (tempTG != null)
						tempTG.transform.FindChild("Isometric_Collider").tag = "editableObj";	//Added

					GameObject tempPlot = GameObject.Find("HC_B_Plot_GO(Clone)") as GameObject;
					if (tempPlot != null)
						tempPlot.transform.FindChild("Isometric_Collider").tag = "editableObj";
				}
				
				if (gameLevel == 4)
				{	
					//scr_remote.SendRequestForFarmItems("4","1");//Harish 
					
					//popUpInfoScript.BattleUnlock();
					
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					GameManager.popUpCount = 30;
					popUpInfoScript.updatePopUpCount();
					
					popUpInfoScript.curPopUpCnt = 30;
					popUpInfoScript.updateCurPopUpCount();
					
					popUpInfoScript.curPopUpType = 0;
					//popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					
					GameManager.hPlotCnt = 2;
					GameManager.dPlotCnt = 1;
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level4);//1200 ;//600;
					
					popUpInfoScript.turnipBool = false;
					
					//save darkling golum 
			
					popUpInfoScript.scr_GameObjSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
					popUpInfoScript.scr_sfsRemoteCnt.SendRequestForBuyItems("6","decorationType",popUpInfoScript.scr_GameObjSvr.objDarklingGolum.objname,"2");
					//popUpInfoScript.SendPos = new Vector3(54,0.05f,9);
					popUpInfoScript.SendPos = popUpInfoScript.GetabsolutePos(54.0f,0.05f,9.0f);
					popUpInfoScript.SendRot = new Vector3(90,0,0);
				
				}
				
				if (gameLevel == 5)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					GameManager.popUpCount = 37;
					popUpInfoScript.updatePopUpCount();
					
					popUpInfoScript.curPopUpCnt = 37;
					popUpInfoScript.updateCurPopUpCount();
					
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.wall.active = true;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					//GameManager.quest = 3;
					//questA = true;
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level5); //1600; // 800;
					 					ad.percentComplete10 = 100;
				}
				
				if (gameLevel == 6)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					GameManager.popUpCount = 40;
					popUpInfoScript.updatePopUpCount();
					
					popUpInfoScript.curPopUpCnt = 40;
					popUpInfoScript.updateCurPopUpCount();
					
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.wall.active = true;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
					//GameManager.quest = 4;
					levelXPCnt =  scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level6); //2300 ;//1150;
				}
				
				if (gameLevel == 7)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(21, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level7); //4500; //1500;
				}
				
				if (gameLevel == 8)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(22, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level8); //5625; //1875;
				}
				
				if (gameLevel == 9)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					levelCompleteScreen.SetActiveRecursively(true);
					
					/*popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(23, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level9);*/
				}
				
				if (gameLevel == 10)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					 					ad.percentComplete21 = 100;
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(24, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level10); //8250;  //2750;
				}
				
				if (gameLevel == 11)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(25, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level11); //16125; //3225;
				}
				
				if (gameLevel == 12)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(26, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level12); //18625; //3725;
				}
				
				if (gameLevel == 13)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(27, 0);
					
					levelXPCnt = scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level13); //30000; //6000;
				}
				
				if (gameLevel == 14)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					 					ad.percentComplete41 = 100;
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(28	, 0);
					
					levelXPCnt =  scr_remote.scr_userworld.ReturnXpfromLevelInfo((int)GameObjectsSvr.CurrentLevel.Level14); //37500; //7500;
				}
				
				if (gameLevel == 15)
				{
					GameObject fireWork = Instantiate(par_LevelFireWork_PF, new Vector3(-41.5f, 20, 67f), Quaternion.Euler(-30, 0, 0)) as GameObject;
					fireWork.GetComponent<ParticleSystem>().Play();
					
					PlayAudioforLevelComplete();
					
					popUpInfoScript.wall.active = true;
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(29, 0);
				}
			}
		}
		
		if (Input.GetMouseButtonDown(0) & gameLevel>0)
		{
			if (Physics.Raycast(guiRay, out guiHit))
			{
				if (guiHit.collider.name=="Bubble")
				{
					GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().HideUncleSam();
				}
				
//				else if (guiHit.collider.gameObject.name == "foodIcon_col(Clone)")
//				{
//					Debug.Log("---> food icon collider");
//					Destroy(guiHit.collider.gameObject);
//					GameObject arrowDel = GameObject.Find("ArrowPF(Clone)") as GameObject;
//					if (arrowDel != null)
//						Destroy(arrowDel);
//					
//					popUpInfoScript.curPopUpCnt = 11;
//					popUpInfoScript.curPopUpType = 0;
//					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
//				}
			}
		}
		
		if (gameLevel == 0 && Input.GetMouseButtonDown(0))
		{
			if (samIndex <5)
			{
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText(samSpeak_00[samIndex]);
				samIndex++;
			}
			else
			{
				if(scr_audioController.audio_wizardMaster.isPlaying)
				{
					scr_audioController.audio_wizardMaster.Stop();
				}
				
				bubbleObj.SetActiveRecursively(false);
				speakTextObj.active = false;
				if (guiControlInfo.popUpType5.active == false)
					guiControlInfo.popUpType4.SetActiveRecursively(true);
				introScreen();
				storyCount+=1;

				Debug.Log("story end " + storyCount);
			}
		}
		
		// goblin cave clear bubble...
		if (gameLevel == 2 && GameManager.taskCount == 13 && Input.GetMouseButtonDown(0))
		{
			if (task13Index <2)
			{
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText(samSpeak_01[task13Index]);
				task13Index++;
			}
			else
			{
//				if(scr_audioController.audio_wizardMaster.isPlaying)
//				{
//					scr_audioController.audio_wizardMaster.Stop();
//				}
				
				bubbleObj.SetActiveRecursively(false);
				speakTextObj.active = false;
				
				popUpInfoScript.task10(1);
				
//				if (guiControlInfo.popUpType5.active == false)
//					guiControlInfo.popUpType4.SetActiveRecursively(true);
//				introScreen();
//				storyCount+=1;
			}
		}
		
		// task feeding tutorial
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 6 && GameManager.popUpCount == 12 && guiControlInfo.delArrow != null)
		{
//			Debug.Log("1 1 1 1 11 1 1  1 1 ");
			if (Input.GetMouseButtonDown(0))
			{
				//Debug.Log("2 2 2 2 2 2 2 2 2 2 2 2 2 2 ");
				if (Physics.Raycast(ray, out hit))
				{
					//Debug.Log(" 3 3 3 3  3 3 3 3 3 3 3 3 3 3 3 ");
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_TG_TrainingGround_GO(Clone)")
					{
						popUpInfoScript.feedTutorial(3);
					}
				}
			}
		}
		
		// task creature rename tutorial
		if (GameManager.gameLevel == 1 && GameManager.taskCount == 7 && GameManager.popUpCount == 13 && guiControlInfo.delArrow != null)
		{
//			Debug.Log("1 1 1 1 11 1 1  1 1 ");
			if (Input.GetMouseButtonDown(0))
			{
			//	Debug.Log("2 2 2 2 2 2 2 2 2 2 2 2 2 2 ");
				if (Physics.Raycast(ray, out hit))
				{
				//	Debug.Log(" 3 3 3 3  3 3 3 3 3 3 3 3 3 3 3 ");
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_TG_TrainingGround_GO(Clone)")
					{
						popUpInfoScript.renameCreatureTutorial(2);
					}
				}
			}
		}
		
		if (GameManager.taskCount == 11)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_01" && hit.collider.gameObject.name != "Rabbit")
					{
						Destroy(GameObject.Find("gameArrowPF(Clone)").gameObject);
						if (guiControlInfo.delArrow != null)
							Destroy(guiControlInfo.delArrow);
						hit.collider.enabled = false;
						GameManager.curCave = hit.collider.gameObject;
						// find game arrow and destroy
						//GameObject gameArrow = GameObject.Find("gameArrowPF(Clone)").gameObject;
						
						// attack button spwan
						GameObject arrowSpwan = GameObject.Find("attack_spwan") as GameObject;
						GameObject arrowTemp = Instantiate(guiControlInfo.arrow, arrowSpwan.transform.position, Quaternion.Euler(90, 90, 0)) as GameObject;
						guiControlInfo.delArrow = arrowTemp;
						
						objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
						attackPanelInfo.panelMoveIn = false;
						attackPanelInfo.panelMoveOut = true;
						
					}
				}
			}
		}
		
		// for farming
		if (readyFarm)
		{
			if (GameManager.gameLevel == 1 && GameManager.taskCount == 4)
			{
				if (Input.GetMouseButtonDown(0))
				{
					if (Physics.Raycast(ray, out hit))
					{
						if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_Plot_GO(Clone)")
						{
							if (hit.collider.gameObject.tag == "editableObj")
							{
								curPlot = hit.collider.gameObject.transform.root.gameObject;
							
								popUpInfoScript.task6(2);
							
								selObjectPos = hit.collider.gameObject.transform.root.transform.position;
								hit.collider.gameObject.tag = "using";
							}
						}
					}
				}
			}
		}
		
		// DAILOG SYSTEM //
		// LEVEL 3 //
		
		if (GameManager.gameLevel >= 2 && GameManager.taskCount >= 15)
		{
			if(indexCnt == 0)
			{
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.Intro06Town_tex;
				//guiControlInfo.popUpType_Dig1_spText.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
				guiControlInfo.popUpType_Dig1_spText.Text = level3Dialog[dialogCnt];
				indexCnt++;
			}
			
			if (Input.GetMouseButtonDown(0))
			{
				//Resources.UnloadUnusedAssets();			//Free resources
				
				if (Physics.Raycast(guiRay, out guiHit))
				{
					if (guiHit.collider.gameObject.name == "popUpType4_Plate" || guiHit.collider.gameObject.name == "popUpType5_Plate")
					{
						if (GameManager.taskCount == 15 && clickCounter <= 1)
						{
///***							Debug.Log("---> " + clickCounter);
							clickCounter++;
							story01(clickCounter);
						}
						if(scr_TaskDetails.isStory)
						{
							//Debug.Log("clickCounter : "+clickCounter);
							//ShowCurrentStory(showStoryNo[showStoryNo.Count - (showStoryNo.Count - 1)], clickCounter), 
							clickCounter++;
							scr_TaskDetails.ShowCurrentStory(0, clickCounter);

						}
						
					}
				}
			}
			
			if (questRunningBool)
			{
				//popUpInfoScript.audio_buttonClick.Play();
				if (Input.GetMouseButtonDown(0))
				{
					//Resources.UnloadUnusedAssets();			//Free resources
					
					if (Physics.Raycast(guiRay, out guiHit))
					{
						if (guiHit.collider.gameObject.name == "popUpType4_Plate" || guiHit.collider.gameObject.name == "popUpType5_Plate")
						{
//							if (GameManager.taskCount == 15)// && clickCounter <= 1)
//							{
//								Debug.Log("---> " + clickCounter);
//								clickCounter++;
//							}
							if (quest == 0)
							{
								//Quest1();
							}
					
							// Quest 2
//							if (popUpInfoScript.quest2StoryBool)
//							{
//								//Quest2();
//								//quest_2A();
//							}
						
							// Quest 3
							if (quest == 2 && !popUpInfoScript.quest2StoryBool)
							{
								//Quest3();
							}
						
							// Quest 4
							if (quest == 3)
							{
								//Quest4();
							}
							
							// Quest 5
							if (quest == 4)
							{
								//Quest5();
							}
							
							if (quest == 5)
							{
								//Quest6();
							}
							
							if(quest == 6)
							{
								//Quest7();
							}
														
							if(quest == 7)
							{
								//Quest8();
							}
														
							if(quest == 8)
							{
								//Quest9();
							}
														
							if(quest == 9)
							{
								//Quest10();
							}
							
							if(quest == 10)
							{
								//Quest11();
							}
							
							if(quest == 11)
							{
								//Quest12();
							}
						}
					}
				}
			}
		}
		
		
			
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(guiRay, out guiHit))
			{
				guiHitBool = true;
			} 
			else
				guiHitBool = false;
		}
		
			//-----------------------INTRODUCING FIGHTING TUTORIAL-------------------------------//
		
		
		
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				if (GameManager.gameLevel >= 4 && !guiHitBool)
				{
					if ((hit.collider.gameObject.tag == "HBattleGate" || hit.collider.gameObject.tag == "DBattleGate"))
					{
						//Start Battle
						//Resources.UnloadUnusedAssets();			//Free resources
						/*bmgr.IntroduceBattle();
						
						GameObject arrowChk = GameObject.Find("gameArrowPF(Clone)") as GameObject;
						if(arrowChk!=null)
						{
							Destroy(arrowChk);
							
						}*/
						
						// activate battle button
						
						// show battle panel
						objPanelControl battlePanelInfo = GameObject.Find("panel_Battle").GetComponent("objPanelControl") as objPanelControl;
						battlePanelInfo.panelMoveIn = false;
						battlePanelInfo.panelMoveOut = true;
												
						// hide attack panel
						objPanelControl attackPanelInfo = GameObject.Find("panel_Attack").GetComponent("objPanelControl") as objPanelControl;
						attackPanelInfo.panelMoveIn = true;
						attackPanelInfo.panelMoveOut = false;
						
						// hide training ground panel
						objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoTG.panelMoveIn = true;
						objPanelInfoTG.panelMoveOut = false;
						
						// hide farm panel
						objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoFrm.panelMoveIn = true;
						objPanelInfoFrm.panelMoveOut = false;
						
						objPanelControl movePanelInfo = GameObject.Find("ObjectMovePanel").GetComponent<objPanelControl>();
						movePanelInfo.panelMoveIn = true;
						movePanelInfo.panelMoveOut = false;
					}
				}
			}
		}
		
		//------------------------------------END---------------------------------------------//
		
		// after lever 3
		if (GameManager.gameLevel >= 3)
		{
			if (Input.GetMouseButtonDown(0))
			{
				//Resources.UnloadUnusedAssets();			//Free resources
				
				if (Physics.Raycast(ray, out hit))
				{
					// click on garden plot
					/*if ((hit.collider.gameObject.transform.root.gameObject.tag == "Plot" ||
						 hit.collider.gameObject.transform.root.gameObject.tag == "DPlot") 
						 && hit.collider.gameObject.tag == "editableObj" && guiHitBool == false)
					{
						objPanelControl objPanelInfo = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfo.panelMoveIn = false;
						objPanelInfo.panelMoveOut = true;
						
						// hide training ground panel
						objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoTG.panelMoveIn = true;
						objPanelInfoTG.panelMoveOut = false;
					}*/
					
					// click on training ground
					/*if ((hit.collider.gameObject.transform.root.gameObject.tag == "PlantTG" ||
						 hit.collider.gameObject.transform.root.gameObject.tag == "Swamp") && hit.collider.gameObject.tag == "editableObj" && guiHitBool == false)
					{
						objPanelControl objPanelInfoTG = GameObject.Find("ObjectEditPanel").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoTG.panelMoveIn = false;
						objPanelInfoTG.panelMoveOut = true;
						
						objPanelControl objPanelInfoFrm = GameObject.Find("panel_Farm").GetComponent("objPanelControl") as objPanelControl;
						objPanelInfoFrm.panelMoveIn = true;
						objPanelInfoFrm.panelMoveOut = false;
					}*/
				}
			}
		}
		
//=====================================================================================================================
		
		// using object pop up
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				if (GameManager.gameLevel >= 3)
				{
					//Resources.UnloadUnusedAssets();			//Free resources
					
					if ((hit.collider.gameObject.tag == "using" || hit.collider.gameObject.tag == "working") && guiHitBool == false)
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(46, 0);
					}
				}
			}
		}
		
//=====================================================================================================================
		
		// remove burn plant
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.tag == "burn")
				{
					Destroy(hit.collider.gameObject.transform.parent.gameObject);
					//scr_remote.RemoveBurnedPlant(i
					scr_remote.RemoveBurnedPlant(popUpInfoScript.GetIdFromString(hit.collider.transform.parent.gameObject.name));
				}
			}
		}
		
//=====================================================================================================================
		
		// GOBLIN, TROLL, ORG CAVE
		
		// level 4 halfling goblin cave 02 destroy
		if (Input.GetMouseButtonDown(0))
		{
			//Resources.UnloadUnusedAssets();			//Free resources
			
			if (Physics.Raycast(ray, out hit))
			{
				if (GameManager.gameLevel >= 4)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_02")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 5 darkling goblin cave 01 destroy
				if (GameManager.gameLevel >= 5)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_01")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 6 goblin cave 03 destroy
				if (GameManager.gameLevel >= 6)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_GoblinCamp_GO(Clone)_03")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 7 darkling goblin cave 02 destroy
				if (GameManager.gameLevel >= 7)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_02")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 8 halfling troll cave 01 destroy
				if (GameManager.gameLevel >= 8)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_TrollHouse_GO(Clone)_01")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 9 darkling goblin camp 03 destroy
				if (GameManager.gameLevel >= 9)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "DL_B_GoblinCamp_GO(Clone)_03")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 10 halfling troll cave 02 destroy
				if (GameManager.gameLevel >= 10)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_TrollHouse_GO(Clone)_02")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 11 darkling troll cave 01 destroy
				if (GameManager.gameLevel >= 11)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "DL_B_TrollHouse_GO(Clone)_01")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 12 halfling troll cave 03 destroy
				if (GameManager.gameLevel >= 12)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_TrollHouse_GO(Clone)_03")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 14 halfling org cave 01 destroy
				if (GameManager.gameLevel >= 14)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_OrgCave_GO(Clone)_01")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 18 halfling org cave 02 destroy
				if (GameManager.gameLevel >= 18)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_OrgCave_GO(Clone)_02")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
		
				// level 22 halfling org cave 03 destroy
				if (GameManager.gameLevel >= 22)
				{
					if (hit.collider.gameObject.transform.root.gameObject.name == "HC_B_OrgCave_GO(Clone)_03")
					{
						//ChkforEnablingAttackBtn(hit.collider.gameObject.transform.root.gameObject.name);
						currentSelectedObject = hit.collider.gameObject.transform.root.gameObject;
						curCave = currentSelectedObject;
						popUpInfoScript.taskGoblinCave(1);
					}
				}
			
		
		
//=====================================================================================================================
		
				// bridge quest
				if (GameManager.gameLevel >= 4)
				{
					// rebuild bridge
					if (hit.collider.gameObject.name == "bridgeCollider" && guiHitBool == false)
					{
///***						Debug.Log("hit : "+hit.collider.gameObject.name);
						//if (hit.collider.gameObject.tag == "BridgeCol")
						if (hit.collider.gameObject.tag == "BridgeCol" && GameManager.gameLevel >= 4)  		//Added
						{	
							GameManager.popUpCount = 31;
							popUpInfoScript.updatePopUpCount();
							
							popUpInfoScript.curPopUpCnt = 31;
							popUpInfoScript.updateCurPopUpCount();
							
							popUpInfoScript.curPopUpType = 0;
							popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
						}
					}
				}
			}
		}
	}
	
//=====================================================================================================================
	private bool typingText1Bool = false;
	private bool typingText2Bool = false;
	
	
	private bool playaudioStory;
	
	void PlayAudioforStory()
	{
		scr_audioController.audio_storyScreen.Play();
		scr_audioController.audio_storyScreen.loop = true;
	        scr_audioController.audio_storyScreen.volume = 0.7f;
		scr_audioController.audio_storyScreen.minDistance = 1;
		scr_audioController.audio_storyScreen.maxDistance = 300;
		playaudioStory = true;
	}

	
	void introScreenStory(int whichStory)
	{
		switch(whichStory)
		{
			case 1:
			
			if (dialogCnt % 2 == 0)
			{	
				message = level01Dialog[dialogCnt];		
				if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = level01Dialog[dialogCnt-1];
												
				WriteText1(); 
				dialogCnt++;
			}
			else
			{
				message = level01Dialog[dialogCnt];
				guiControlInfo.popUpType_Dig1_spText.Text = level01Dialog[dialogCnt-1];
				WriteText2();
				dialogCnt++;
			}
			
			break;
			
			case 2:
			
			break;
		}
	}
	
	
	void introScreen()
	{
		Ray guiIntroRay = guiCam.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(guiIntroRay, out guiHit))
			{
				if (introStory == 0)
				{
//					Debug.Log("11111");
					scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.Intro01_tex;
				    if(!playaudioStory)
					{
						PlayAudioforStory();
					}
					
					if (guiHit.collider.gameObject.name == "popUpType4_Plate")
					{
						//Debug.Log("2222");
						message = "";
						if (dialogCnt <= 4)
						{
//							Debug.Log("3333");
							if (dialogCnt % 2 == 0)
							{
							//	Debug.Log("444");
								message = level01Dialog[dialogCnt];
								
								if (dialogCnt > 0)
									guiControlInfo.popUpType_Dig2_spText.Text = level01Dialog[dialogCnt-1];
																
								WriteText1();
								dialogCnt++;
							}
							else
							{
								//Debug.Log("555555");
								message = level01Dialog[dialogCnt];
								guiControlInfo.popUpType_Dig1_spText.Text = level01Dialog[dialogCnt-1];
								WriteText2();
								dialogCnt++;
							}
						}
						else
						{
							//Debug.Log("6666");
							popUpInfoScript.wall.active = false;
							guiControlInfo.popUpType4.SetActiveRecursively(false);
							
							dialogCnt = 0;
							guiControlInfo.popUpType_Dig1_spText.Text = "";
							guiControlInfo.popUpType_Dig2_spText.Text = "";
							scr_QuestTexControl.questSingleMat.mainTexture = scr_QuestTexControl.Intro02_tex;
							guiControlInfo.popUpType_Dig5_spText.Text = level02Dialog[0];
							message = level02Dialog[0];
							WriteText3();
							introStory++;
						}
					}
				}
				if (introStory == 1)
				{
					//Debug.Log("aaaa");
					scr_QuestTexControl.questSingleMat.mainTexture = scr_QuestTexControl.Intro02_tex;
					if (guiControlInfo.popUpType5.active == false)
						guiControlInfo.popUpType5.SetActiveRecursively(true);
					
					if (guiHit.collider.gameObject.name == "popUpType5_Plate")
					{
						//Debug.Log("bbbb");
						message = "";
						if (dialogCnt <= 1)
						{
							if (dialogCnt % 2 == 0)
							{
								message = level02Dialog[dialogCnt];
								guiControlInfo.popUpType_Dig5_spText.Text = level02Dialog[dialogCnt];
								WriteText3();
								dialogCnt++;
							}
							else
							{
								guiControlInfo.popUpType_Dig5_spText.Text = level02Dialog[dialogCnt];
								dialogCnt++;
							}
						}
						else
						{
							//Debug.Log("cccc");
							guiControlInfo.popUpType5.SetActiveRecursively(false);
							
							introStory++;
							dialogCnt = 0;
							guiControlInfo.popUpType_Dig5_spText.Text = "";
							guiControlInfo.popUpType_Dig1_spText.Text = "";
							guiControlInfo.popUpType_Dig2_spText.Text = "";
							scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.Intro03_tex;
							
							guiControlInfo.popUpType_Dig1_spText.Text = level03Dialog[0];
							message = level03Dialog[0];
							WriteText1();
							dialogCnt = 1;
							
							if(scr_audioController.audio_storyScreen.isPlaying)
							{
							  scr_audioController.audio_storyScreen.Stop();
							  playaudioStory = false;
							}
						}
					}
				}
				if (introStory == 2)
				{
					if (guiControlInfo.popUpType4.active == false)
						guiControlInfo.popUpType4.SetActiveRecursively(true);
					
					if(!enableQuest)
					{
					   PlayQuestSounds();
					}
					
					if (guiHit.collider.gameObject.name == "popUpType4_Plate")
					{
						message = "";
						if (dialogCnt <= 3)
						{
							if (dialogCnt % 2 == 0)
							{
								message = level03Dialog[dialogCnt];
								
								//if (dialogCnt > 0)
									guiControlInfo.popUpType_Dig2_spText.Text = level03Dialog[dialogCnt-1];
																
								WriteText1();
								dialogCnt++;
							}
							else
							{
								message = level03Dialog[dialogCnt];
								guiControlInfo.popUpType_Dig1_spText.Text = level03Dialog[dialogCnt-1];
								WriteText2();
								dialogCnt++;
							}
						}
						else
						{
							popUpInfoScript.wall.active = false;
							guiControlInfo.popUpType4.SetActiveRecursively(false);
							
							introStory++;
							dialogCnt = 0;
							guiControlInfo.popUpType_Dig1_spText.Text = "";
							guiControlInfo.popUpType_Dig2_spText.Text = "";
							scr_QuestTexControl.questSingleMat.mainTexture = scr_QuestTexControl.Intro04_tex;
							
							guiControlInfo.popUpType_Dig5_spText.Text = level04Dialog[0];
							message = level04Dialog[0];
							WriteText3();
							dialogCnt = 1;
						}
					}
				}
				if (introStory == 3)
				{
					if (guiControlInfo.popUpType5.active == false)
						guiControlInfo.popUpType5.SetActiveRecursively(true);
					
					if (guiHit.collider.gameObject.name == "popUpType5_Plate")
					{
						message = "";
						if (dialogCnt <= 1)
						{
							if (dialogCnt % 2 == 0)
							{
								message = level04Dialog[dialogCnt];
								guiControlInfo.popUpType_Dig5_spText.Text = level04Dialog[dialogCnt];
								WriteText3();
								dialogCnt++;
							}
							else
							{
								guiControlInfo.popUpType_Dig5_spText.Text = level04Dialog[dialogCnt];
								dialogCnt++;
							}
						}
						else
						{
							popUpInfoScript.wall.active = false;
							guiControlInfo.popUpType5.SetActiveRecursively(false);
							
							introStory++;
							dialogCnt = 0;
							guiControlInfo.popUpType_Dig5_spText.Text = "";
							scr_QuestTexControl.questSingleMat.mainTexture = scr_QuestTexControl.Intro05_tex;
							
							guiControlInfo.popUpType_Dig5_spText.Text = level05Dialog[0];
							message = level05Dialog[0];
							WriteText3();
							dialogCnt = 1;
							
							if(scr_audioController.audio_Quest.isPlaying)
							{
								scr_audioController.audio_Quest.Stop();
								enableQuest = false;
							}
						}
					}
				}
				if (introStory == 4)
				{
					if (guiControlInfo.popUpType5.active == false)
						guiControlInfo.popUpType5.SetActiveRecursively(true);
					
					    if(!playaudioStory)
				    	{
						   PlayAudioforStory();
					    }
					
					if (guiHit.collider.gameObject.name == "popUpType5_Plate")
					{
						message = "";
						if (dialogCnt <= 2)
						{
							if (dialogCnt % 2 == 0)
							{
								message = level05Dialog[dialogCnt];
									
								WriteText3();
								dialogCnt++;
							}
							else
							{
								message = level05Dialog[dialogCnt];
								WriteText3();
								dialogCnt++;
							}
						}
						else
						{
							popUpInfoScript.wall.active = false;
							guiControlInfo.popUpType5.SetActiveRecursively(false);
							
							introStory++;
							dialogCnt = 0;
							guiControlInfo.popUpType_Dig5_spText.Text = "";
							GameManager.gameLevel = 1;
							curLevel = 1;
							guiControlInfo.levelScoreInfo.Text = GameManager.gameLevel.ToString();
							
							if (gameLevel >= 1)
								scr_remote.SendCurrentLevelrequest(gameLevel);
							
							GameManager.popUpCount = 0;
							popUpInfoScript.curPopUpCnt = 0;
							GameManager.taskCount = 0;
							popUpInfoScript.updateTaskCount();
							popUpInfoScript.updatePopUpCount();
							popUpInfoScript.updateCurPopUpCount();
							popUpInfoScript.curPopUpType = 0;
							Debug.Log("generate pop up.......");
							popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
							levelControlInfo.UnlockItems();
							GameObject tempObj = Instantiate(Resources.Load("_goldSparkTimerObj"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
//							GameObject goldEff = Instantiate(Resources.Load("HW_rewardGold"), new Vector3(-33.67f, 20, 108.48f), Quaternion.Euler(350,0,0)) as GameObject;
//							GameObject sparkEff = Instantiate(Resources.Load("HW_rewardSparks"), new Vector3(-45.47f, 20, 108.48f), Quaternion.Euler(350,0,0)) as GameObject;
//
							if(scr_audioController.audio_storyScreen.isPlaying)
							{
							  scr_audioController.audio_storyScreen.Stop();
							  AudioController.EnableEnviron = true;
							}
						}
					}
				}
			}
		}
	}
	
//=====================================================================================================================	
	public bool enableQuest;
	public void PlayQuestSounds()
	{
		 enableQuest = true;
		 AudioController.EnableEnviron = false;
		 scr_audioController.audio_Quest.Play();
		 scr_audioController.audio_Quest.minDistance = 1;
		 scr_audioController.audio_Quest.maxDistance = 300;
		 scr_audioController.audio_Quest.volume = 0.8f;
		 scr_audioController.audio_Quest.loop  = true;       
	}
	
	
	public void Quest1()		
	{
		Debug.Log("1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 :: " + indexCnt);
		    if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
		if(indexCnt == 0)
		{
			Debug.Log("2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2");
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.Intro06Town_tex;
			indexCnt++;
		}
				
		if (storyCnt == 1)
		{
			Debug.Log("3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3 3");
			if (dialogCnt <= 5)
			{
				Debug.Log("4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4");
				if (dialogCnt % 2 == 0)
				{
					Debug.Log("5 5 5 5 5 5 5 5 5 5 5 5 5 5 5");
					message = level3Dialog[dialogCnt];
						
					if (dialogCnt > 0)
					{
						Debug.Log("6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6 6");
						guiControlInfo.popUpType_Dig2_spText.Text = level3Dialog[dialogCnt-1];
					}
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					Debug.Log("7 7 7 7 7 7 7 7 7 7 7 7 7 7 7");
					message = level3Dialog[dialogCnt];
					guiControlInfo.popUpType_Dig1_spText.Text = level3Dialog[dialogCnt-1];
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				Debug.Log("8 8 8 8 8 8 8 8 8 8 8 8 8 8 8");
				questA = true;
				storyCnt++;
				scr_remote.SendStoryCount(storyCnt);
				dialogCnt = 0;
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
			}
		}
						
		// Quest 1
		
		if (questA)
		{
			Debug.Log("9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9");
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01a_tex;
			
			if (dialogCnt <= 4)
			{
				Debug.Log("10 10 10 10 10 10 10 10");
				if (dialogCnt % 2 == 0)
				{
					Debug.Log("11 11 11 11 11 11 11 11 11 11");
					message = quest_1A[dialogCnt];
					
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_1A[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					Debug.Log("12 12 12 12 12 12 12 12");
					message = quest_1A[dialogCnt];
					guiControlInfo.popUpType_Dig1_spText.Text = quest_1A[dialogCnt-1];
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				Debug.Log("13 13 13 13 13 13 13 13");
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				dialogCnt = 0;
				questA = false;
				
				bubbleObj.SetActiveRecursively(true);
				speakTextObj.active = true;
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Wait for the quest to complete or you can spend sparks to speed up");
				
				popUpCount = 24;
				if (popUpCount == 24)
				{
					Debug.Log("14 14 14 14 14 14 14 14 14");
					popUpCount = 26;
					popUpInfoScript.updatePopUpCount();
				
					popUpInfoScript.curPopUpCnt = 26;
					popUpInfoScript.updateCurPopUpCount();
				
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				}
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
			
		if(popUpInfoScript.isQuest1Completed == true)
		{
				questB = true;
			}
							
		if (questB)
		{
			Debug.Log("15 15 15 15 15 15 15 15 15");
			popUpInfoScript.isQuest1Completed = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01b_tex;
			
			guiControlInfo.popUpType4.SetActiveRecursively(true);
			guiControlInfo.popUpType1.SetActiveRecursively(false);
			guiControlInfo.popUpType2.SetActiveRecursively(false);
			guiControlInfo.popUpType3.SetActiveRecursively(false);
			
			if (dialogCnt <= 10)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_1B[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_1B[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_1B[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_1B[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
				GameObject qPBar = GameObject.Find("qProgressBar_Mid_Pov") as GameObject;
				if (qPBar != null)
					qPBar.transform.localScale = new Vector3(qPBar.transform.localScale.x + 0.1f, qPBar.transform.localScale.y, qPBar.transform.localScale.z);
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				questB = false;
				
				bubbleObj.SetActiveRecursively(true);
				speakTextObj.active = true;
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Wait for the quest to complete or you can spend sparks to speed up");
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				popUpInfoScript.curPopUpCnt = 27;
					popUpInfoScript.updateCurPopUpCount();
				
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				//Invoke("LookIntoQuest",4f);
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
	}
	
//=====================================================================================================================	
	
	public void LookIntoQuest()
	{
		//if(PlayerPrefs.GetInt("questtutorial")!=1)
		if (GameManager.taskCount == 15)
		{
			GameObject gStory = GameObject.Find("FightingTutorial");
			gStory.GetComponent<AutoSpeak>().callToWriteText("Look into the quest log .This will guide you throughout the game for every activity.");

//			gameObject.GetComponent<QuestTutorial>().PlushArrow(1); //  arrow will be plushed to quest;
		}
	}
	
		bool tempbool;
	void Quest2()
	{
		
		if (guiControlInfo.popUpType5.active == false && tempbool == false)
		{
			guiControlInfo.popUpType5.SetActiveRecursively(true);
			
			guiControlInfo.popUpType1.SetActiveRecursively(false);
			guiControlInfo.popUpType2.SetActiveRecursively(false);
			guiControlInfo.popUpType3.SetActiveRecursively(false);
			
			tempbool =true;
		}

		if (questA)
		{
			if(!enableQuest)
			{
				PlayQuestSounds();
			}
			
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest02a_tex;
			
			if (dialogCnt == 0)
			{
				message = quest_2B[dialogCnt];
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				guiControlInfo.popUpType_Dig5_spText.Text = quest_2B[dialogCnt];
				WriteText3();
				dialogCnt++;
			}
			else
			{
				guiControlInfo.popUpType5.SetActiveRecursively(false);
				guiControlInfo.popUpType4.SetActiveRecursively(true);
				guiControlInfo.popUpType1.SetActiveRecursively(false);
				guiControlInfo.popUpType2.SetActiveRecursively(false);
				guiControlInfo.popUpType3.SetActiveRecursively(false);
				
				dialogCnt = 0;
				guiControlInfo.popUpType_Dig5_spText.Text = "";
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				questA = false;
				questB = true;
			}
			}
		
		if (questB)
		{
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest02b_tex;
			if (dialogCnt <= 8)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_2A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_2A[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_2A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_2A[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType5.SetActiveRecursively(false);
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				dialogCnt = 0;
				questB = false;
				
				GameManager.popUpCount = 34;
				popUpInfoScript.curPopUpCnt = 34;
				popUpInfoScript.updateCurPopUpCount();
													
				popUpInfoScript.curPopUpType = 0;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				GameManager.questRunningBool = false;
				popUpInfoScript.quest2StoryBool = false;
			}
		}
	}
	
//=====================================================================================================================	
	
	void Quest3()
	{
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
			
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest03_tex;
			if (dialogCnt <= 2)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_3[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_3[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_3[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_3[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				dialogCnt = 0;
				GameManager.popUpCount = 37;
				popUpInfoScript.curPopUpCnt = 37;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				  AudioController.EnableEnviron = true;	
				 enableQuest = false;
				}
			}
		}
	}
//=====================================================================================================================	
	
	void Quest4()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest04_tex;

		if (dialogCnt <= 5)
		{
		        if(!enableQuest)
				{
					PlayQuestSounds();
				}
			
			if (dialogCnt % 2 == 0)
			{
				message = quest_4[dialogCnt];
						
				if (dialogCnt > 0)
				guiControlInfo.popUpType_Dig2_spText.Text = quest_4[dialogCnt-1];
				
				WriteText1();
				dialogCnt++;
			}
			else
			{
				message = quest_4[dialogCnt];
				
				guiControlInfo.popUpType_Dig1_spText.Text = quest_4[dialogCnt-1];
				
				WriteText2();
				dialogCnt++;
			}
		}
		else
		{
			GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
			
			popUpInfoScript.wall.active = false;
			guiControlInfo.popUpType4.SetActiveRecursively(false);
			guiControlInfo.popUpType_Dig1_spText.Text = "";
			guiControlInfo.popUpType_Dig2_spText.Text = "";
			
			GameManager.popUpCount = 40;
			popUpInfoScript.curPopUpCnt = 40;
			popUpInfoScript.curPopUpType = 2;
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			dialogCnt = 0;
			
			if(scr_audioController.audio_Quest.isPlaying)
			{
			 scr_audioController.audio_Quest.Stop();
			 enableQuest = false;
			 AudioController.EnableEnviron = true;	
			}
		}
	}
	
//=====================================================================================================================	

	public void Quest5()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05a_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
			
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05a_tex;
			if (dialogCnt <= 8)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_5[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_5[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_5[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_5[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				GameManager.popUpCount = 42;
				popUpInfoScript.curPopUpCnt = 42;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
		
		if(popUpInfoScript.isQuest5Completed == true)
		{
				questB = true;
			
				if(!enableQuest)
				{
					PlayQuestSounds();
				}
			}
		
		if (questB)
		{
			popUpInfoScript.isQuest5Completed = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05b_tex;
			if (dialogCnt <= 4)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest5_DialogA[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest5_DialogA[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest5_DialogA[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest5_DialogA[dialogCnt-1];
					
					WriteText2(); 
					dialogCnt++;
				}
			}
			else
			{
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				dialogCnt = 0;
				questC = true;
				questB = false;
			}
		}
				
		if (questC)
		{
				scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest05c_tex;
			if (dialogCnt <= 8)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest5_DialogB[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest5_DialogB[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest5_DialogB[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest5_DialogB[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 43;
				popUpInfoScript.curPopUpCnt = 43;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questC = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
			      AudioController.EnableEnviron = true;	
				}
			}
		}
	}	
	
	public void Quest6()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06a_tex;
		
		if (questA)
		{
			if(!enableQuest)
			{
				PlayQuestSounds();
			}
			
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06a_tex;
			if (dialogCnt < 5)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_6[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_6[dialogCnt-1];
						
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_6[dialogCnt];
						
					guiControlInfo.popUpType_Dig1_spText.Text = quest_6[dialogCnt-1];
				
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
					
				GameManager.popUpCount = 48;
				popUpInfoScript.curPopUpCnt = 48;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
		
		if(popUpInfoScript.isQuest6Complete == true)
		{
			questB = true;
			
			 if(!enableQuest)
				{
					PlayQuestSounds();
				}
	}	
	
		if (questB)
		{
			popUpInfoScript.isQuest6Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest06b_tex ;
			if (dialogCnt < 9)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_6A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_6A[dialogCnt-1];

					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_6A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_6A[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
	{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 49;
				popUpInfoScript.curPopUpCnt = 49;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questB = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				  AudioController.EnableEnviron = true;	
				}
			}
		}
	}
		
	public void Quest7()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07a_tex;
			if (dialogCnt < 9)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_7[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_7[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_7[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_7[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
					
				GameManager.popUpCount = 51;
				popUpInfoScript.curPopUpCnt = 51;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questA = false;
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
		
		if(popUpInfoScript.isQuest7Complete == true)
		{
			questB = true;
			
			   if(!enableQuest)
				{
					PlayQuestSounds();
				}
		}
			
		if(questB)
		{
			popUpInfoScript.isQuest7Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest07b_tex;
			if (dialogCnt < 6)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_7A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_7A[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_7A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_7A[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
					guiControlInfo.popUpType_Dig2_spText.Text = " ";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 52;
				popUpInfoScript.curPopUpCnt = 52;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questB = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
	}
	
	public void Quest8()    //Harish chander
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest08_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest08_tex;
			if (dialogCnt < 8)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_8[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_8[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest_8[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_8[dialogCnt-1];
					
					WriteText2(); 
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
					
				GameManager.popUpCount = 54;
				popUpInfoScript.curPopUpCnt = 54;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
								
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
		
		if(popUpInfoScript.isQuest8Complete == true)
		{
				questB = true;
			    if(!enableQuest)
				{
					PlayQuestSounds();
				}
			 
			}
	
		if(questB)
		{
			popUpInfoScript.isQuest8Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest08b_tex;
			if (dialogCnt < 6)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_8A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_8A[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
		}
				else
				{
					message = quest_8A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_8A[dialogCnt-1];
							
					WriteText2(); 
					dialogCnt++;
				}
			}
			else
		{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 55;
				popUpInfoScript.curPopUpCnt = 55;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questB = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
	}
			
	public void Quest9()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest09a_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest09a_tex;
			if (dialogCnt < 12)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_9[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_9[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest_9[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_9[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
					guiControlInfo.popUpType_Dig2_spText.Text = " ";
				
				GameManager.popUpCount = 57;
				popUpInfoScript.curPopUpCnt = 57;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
		
		if(popUpInfoScript.isQuest9Complete == true)
		{
			questB = true;
			
			   if(!enableQuest)
				{
					PlayQuestSounds();
				}
		}
	
		if(questB)
		{
			popUpInfoScript.isQuest9Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest09b_tex;
			if (dialogCnt < 3)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_9A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_9A[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_9A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_9A[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 58;
				popUpInfoScript.curPopUpCnt = 58;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				dialogCnt = 0;
				questB = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}
	}
	
	
	public void Quest10()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest10a_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest10a_tex;
			if (dialogCnt < 7)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_10[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_10[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_10[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_10[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				GameManager.popUpCount = 60;
				popUpInfoScript.curPopUpCnt = 60;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
			}
			
		if(popUpInfoScript.isQuest10Complete == true)
		{
			questB = true;
			
			    if(!enableQuest)
				{
					PlayQuestSounds();
				}
			
		}
			
		if(questB)
		{
			popUpInfoScript.isQuest10Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest10b_tex;
			if (dialogCnt < 5)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_10A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_10A[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest_10A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_10A[dialogCnt-1];
					
					WriteText2(); 
					dialogCnt++;
				}
			}
			else
			{
				
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 61;
				popUpInfoScript.curPopUpCnt = 61;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questB = false;
				
				    if(scr_audioController.audio_Quest.isPlaying)
					{
					 scr_audioController.audio_Quest.Stop();
					 enableQuest = false;
					  AudioController.EnableEnviron = true;	
					}
			}
			}
		}
	
	public void Quest11()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest11_tex;
		
		if (questA)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest11_tex;
			if (dialogCnt < 11)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_11[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_11[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest_11[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_11[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				GameManager.popUpCount = 63;
				popUpInfoScript.curPopUpCnt = 63;
				popUpInfoScript.curPopUpType = 2;
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questA = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				  AudioController.EnableEnviron = true;		
				}
			}
			}
			
		if(popUpInfoScript.isQuest11Complete == true)
		{
			questB = true;
			
			    if(!enableQuest)
				{
					PlayQuestSounds();
				}
		}
			
		if(questB)
		{
			popUpInfoScript.isQuest11Complete = false;
			scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest11_tex;
			if (dialogCnt < 5)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_11A[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_11A[dialogCnt-1];
					
					WriteText1(); 
					dialogCnt++;
				}
				else
				{
					message = quest_11A[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_11A[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				GameManager.popUpCount = 64;
				popUpInfoScript.curPopUpCnt = 64;
				popUpInfoScript.curPopUpType = 0;
				
				popUpInfoScript.updateCurPopUpCount();
				popUpInfoScript.updatePopUpCount();
				popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				
				dialogCnt = 0;
				questB = false;
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				  AudioController.EnableEnviron = true;	
				}
			}
			}
		}
	
	void Quest12()
	{
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest12_tex;
	
		if (dialogCnt < 7)
		{
			 if(!enableQuest)
			{
				PlayQuestSounds();
			}
		
			if (dialogCnt % 2 == 0)
			{
				message = quest_12[dialogCnt];
						
				if (dialogCnt > 0)
				guiControlInfo.popUpType_Dig2_spText.Text = quest_12[dialogCnt-1];
				
				WriteText1();
				dialogCnt++;
		}
			else
			{
				message = quest_12[dialogCnt];
				
				guiControlInfo.popUpType_Dig1_spText.Text = quest_12[dialogCnt-1];
	
				WriteText2();
				dialogCnt++;
			}
		}
		else
		{
			GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
			Congratseff.GetComponent<ParticleSystem>().Play();
				
			
			popUpInfoScript.wall.active = false;
			guiControlInfo.popUpType4.SetActiveRecursively(false);
			guiControlInfo.popUpType_Dig1_spText.Text = "";
			guiControlInfo.popUpType_Dig2_spText.Text = "";
			
			GameManager.popUpCount = 66;
			popUpInfoScript.curPopUpCnt = 66;
			popUpInfoScript.curPopUpType = 2;
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			dialogCnt = 0;
			
			if(scr_audioController.audio_Quest.isPlaying)
			{
			 scr_audioController.audio_Quest.Stop();
			 enableQuest = false;
			 AudioController.EnableEnviron = true;	
			}
		}
	}
	
	public int tempParent;
    public int ParentTypeId()
	{
		return tempParent;
	}
	
	public string message;
	private bool textTypingBool = true;
	
	IEnumerator TypeText1() 
	{
///***		Debug.Log("message : "+message);
		foreach (char letter in message.ToCharArray()) 
		{
			guiControlInfo.popUpType_Dig1_spText.Text += letter;
			yield return 0;
			yield return new WaitForSeconds (0.01f);
		}      
	}
	
	IEnumerator TypeText2() 
	{
///***		Debug.Log("message : "+message);
		foreach (char letter in message.ToCharArray()) 
		{
			guiControlInfo.popUpType_Dig2_spText.Text += letter;
			yield return 0;
			yield return new WaitForSeconds (0.01f);
		}      
	}
	
	IEnumerator TypeText3 () 
	{
		foreach (char letter in message.ToCharArray()) 
		{
			guiControlInfo.popUpType_Dig5_spText.Text += letter;
			yield return 0;
			yield return new WaitForSeconds (0.01f);
		}      
	}
	
	public void WriteText1()
	{
//		Debug.Log("write text :--->");
		StopAllCoroutines();
		guiControlInfo.popUpType_Dig1_spText.Text = "";
		guiControlInfo.popUpType_Dig2_spText.Text = "";
		StartCoroutine(TypeText1());
		
	}
	public void WriteText2()
	{

		StopAllCoroutines();
		guiControlInfo.popUpType_Dig2_spText.Text = "";
		StartCoroutine(TypeText2());
		
	}
	
	public void WriteText3()
	{
		StopAllCoroutines();
		guiControlInfo.popUpType_Dig5_spText.Text = "";
		StartCoroutine(TypeText3());
		
	}
	
	public void StopWritingText()
	{
		StopAllCoroutines();
	}
	
	/*void EnableAttackButton(GameObject go, bool normalState)
	{
		if(go != null)
		{
			UIButton uiB = go.GetComponent<UIButton>();
			if(uiB != null)
			{
				if(normalState)
					uiB.SetControlState(UIButton.CONTROL_STATE.NORMAL);
				else
					uiB.SetControlState(UIButton.CONTROL_STATE.DISABLED);
			}
		}
	}*/
	
	private Transform bargObj,cusithObj,SproutObj,NymphObj,DryadObj,NixObj,DraughObj,DagonObj;
	private Transform LeechObj,LeshyObj,LurkerObj,SpriteObj,ImpObj,DjinnObj,DarkHoundObj,FenrirObj,HellhoundObj;
	
	/*void ChkforEnablingAttackBtn(string GoblinCaveName)
	{
		//Halfling
		
		GameObject EarthTg = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
		GameObject PlantTg = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
		GameObject NixTg = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
		
		
		
		if(EarthTg != null)
		{
		 bargObj =  EarthTg.transform.FindChild("HC_C_Barg_GO(Clone)") as Transform;
		 cusithObj = EarthTg.transform.FindChild("HC_C_Cusith_GO(Clone)") as Transform;
		}
		
		if(PlantTg != null)
		{
		 SproutObj = PlantTg.transform.FindChild("HC_C_Sprout_GO(Clone)") as Transform;
		 NymphObj =  PlantTg.transform.FindChild("HC_C_Nymph_GO(Clone)") as Transform;
		 DryadObj = PlantTg.transform.FindChild("HC_C_Dryad_GO(Clone)") as Transform;
		}
		
		if(NixTg != null)
		{
		 NixObj =  NixTg.transform.FindChild("HC_C_Nix_GO(Clone)") as Transform;
		 DraughObj = NixTg.transform.FindChild("HC_C_Draug_GO(Clone)") as Transform;
		 DagonObj = NixTg.transform.FindChild("HC_C_Dragon_GO(Clone)") as Transform;
		}
			
		//Darkling
		
		GameObject SwampTg = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
		GameObject FireTg = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
		GameObject DarkEarthTg =  GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
		
		if(SwampTg != null)
		{
		 LeechObj = SwampTg.transform.FindChild("DL_C_Leech_GO(Clone)") as Transform;
		 LeshyObj = SwampTg.transform.FindChild("DL_C_Leshy_GO(Clone)") as Transform;
		 LurkerObj = SwampTg.transform.FindChild("DL_C_Lurker_GO(Clone)") as Transform;
		}
		
		if(FireTg != null)
		{
		 SpriteObj = FireTg.transform.FindChild("DL_C_Sprite_GO(Clone)") as Transform;
		 ImpObj = FireTg.transform.FindChild("DL_C_Imp_GO(Clone)") as Transform;
		 DjinnObj = FireTg.transform.FindChild("DL_C_Djinn_GO(Clone)") as Transform;
		}
		
		if(DarkEarthTg != null)
		{
		 DarkHoundObj = DarkEarthTg.transform.FindChild("DL_C_DHound_GO(Clone)") as Transform;
		 FenrirObj = DarkEarthTg.transform.FindChild("DL_C_Fenrir_GO(Clone)") as Transform;
		 HellhoundObj = DarkEarthTg.transform.FindChild("DL_C_HellHound_GO(Clone)") as Transform;
		}
		
		
		switch(GoblinCaveName)
		{
			case "HC_B_GoblinCamp_GO(Clone)_02":
				
			if(bargObj != null || cusithObj != null)
			{
				if(GameManager.barg_lvl > 4 || GameManager.cusith_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
					Debug.Log("Enabled >>>>>>>>>>>>>>>");
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
					Debug.Log("Disabled >>>>>>>>>>>>>");
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				Debug.Log("Disabled >>>>>>>>>>>>>");
			}
				
			break;
			
		case "HC_B_GoblinCamp_GO(Clone)_03":
			
			if(cusithObj != null)
			{
				if(GameManager.cusith_lvl > 9) 
 				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}				
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			
			break;
			
		case "HC_B_TrollHouse_GO(Clone)_01":
			
			if(SproutObj != null || NymphObj != null || DryadObj != null)
			{
				if(GameManager.sprout_lvl >= 1 || GameManager.nymph_lvl >= 1 || GameManager.dryad_lvl >= 1)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}	
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "HC_B_TrollHouse_GO(Clone)_02":
			
			if(NymphObj != null || DryadObj != null)
			{
				if(GameManager.nymph_lvl > 4 || GameManager.dryad_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "HC_B_TrollHouse_GO(Clone)_03":
			
			if(DryadObj != null)
			{
				if(GameManager.dryad_lvl > 9)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "HC_B_OrgCave_GO(Clone)_01":
			
			if(NixObj != null || DraughObj != null || DagonObj != null)
			{
				if(GameManager.nix_lvl >= 1 || GameManager.draug_lvl >= 1 || GameManager.dragon_lvl >= 1)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}	
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "HC_B_OrgCave_GO(Clone)_02":
			
			if(DraughObj != null || DagonObj != null)
			{
				if(GameManager.draug_lvl > 4 || GameManager.dragon_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
				
		case "HC_B_OrgCave_GO(Clone)_03":
			
			if(DagonObj != null)
			{
				if(GameManager.dragon_lvl > 9)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
				
				break;
			
			
			//darkling
			
		case "DL_B_GoblinCamp_GO(Clone)_01":
			
			if(LeechObj != null || LeshyObj != null || LurkerObj != null)
			{
				if(GameManager.leech_lvl >= 1 || GameManager.leshy_lvl >= 1 || GameManager.lurker_lvl >= 1)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}	
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "DL_B_GoblinCamp_GO(Clone)_02":
			
			if(LeshyObj != null || LurkerObj != null)
			{
				if(GameManager.leshy_lvl > 4 || GameManager.lurker_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
				
			break;
			
		case "DL_B_GoblinCamp_GO(Clone)_03":
			
			if(LurkerObj != null)
			{
				if(GameManager.lurker_lvl > 9)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "DL_B_OrgCave_GO(Clone)_01":
			
			if(DarkHoundObj != null || FenrirObj != null || HellhoundObj != null)
			{
				if(GameManager.dHound_lvl >= 1 || GameManager.fenrir_lvl >= 1 || GameManager.hellHound_lvl >= 1)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}	
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "DL_B_OrgCave_GO(Clone)_02":
			
			if(FenrirObj != null || HellhoundObj != null)
			{
				if(GameManager.fenrir_lvl > 4 || GameManager.hellHound_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
				
			
			break;
			
		case "DL_B_OrgCave_GO(Clone)_03":
			
			if(HellhoundObj != null)
			{
				if(GameManager.hellHound_lvl > 9)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			
			break;
			
		case "DL_B_TrollHouse_GO(Clone)_01":
			
			if(SpriteObj != null || ImpObj != null || DjinnObj != null)
			{
				if(GameManager.sprite_lvl >= 1 || GameManager.imp_lvl >= 1 || GameManager.djinn_lvl >= 1)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}	
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
			
		case "DL_B_TrollHouse_GO(Clone)_02":
			
			if(ImpObj != null || DjinnObj != null)
			{
				if(GameManager.imp_lvl > 4 || GameManager.djinn_lvl > 4)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			
			break;
			
		case "DL_B_TrollHouse_GO(Clone)_03":
			
			if(DjinnObj != null)
			{
				if(GameManager.djinn_lvl > 9)
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,true);
				}
				else
				{
					EnableAttackButton(guiControlInfo.AttackUIbtn,false);
				}
			}
			else
			{
				EnableAttackButton(guiControlInfo.AttackUIbtn,false);
			}
			
			break;
		}
	}*/

//====================================================================================================================

	public void story01(int clickCount)
	{
		guiControlInfo.popUpType4.SetActiveRecursively(true);
		scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01b_tex;
		
		if (clickCount == 0)
		{
			Debug.Log("story01 execute <---");
			guiControlInfo.popUpType_Dig1_spText.Text = "Farmer McGee tells Halfling he's on Darkling land.";
			message = "Farmer McGee tells Halfling he's on Darkling land.";
			WriteText1();
		}
		if (clickCount == 1)
		{
			guiControlInfo.popUpType_Dig1_spText.Text = "Farmer McGee tells Halfling he's on Darkling land.";
		}
		if (clickCount == 2)
		{
			//GameManager.taskCount = 16;
			//popUpInfoScript.updateTaskCount();
			guiControlInfo.popUpType4.SetActiveRecursively(false);
			
			popUpCount = 21;
			popUpInfoScript.curPopUpCnt = 21;
			popUpInfoScript.curPopUpType = 0;
			popUpInfoScript.updatePopUpCount();
			popUpInfoScript.updateCurPopUpCount();
			
			popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
			
			//GameManager.xp = GameManager.xp + 3;
			
			//GameManager.taskCount = 16;
			//popUpInfoScript.updateTaskCount();
		}
	}
	
}

		/*	scr_QuestTexControl.questMat.mainTexture = scr_QuestTexControl.quest01b_tex;
			
			
			if (dialogCnt <= 10)
			{
				if (dialogCnt % 2 == 0)
				{
					message = quest_1B[dialogCnt];
						
					if (dialogCnt > 0)
					guiControlInfo.popUpType_Dig2_spText.Text = quest_1B[dialogCnt-1];
					
					WriteText1();
					dialogCnt++;
				}
				else
				{
					message = quest_1B[dialogCnt];
					
					guiControlInfo.popUpType_Dig1_spText.Text = quest_1B[dialogCnt-1];
					
					WriteText2();
					dialogCnt++;
				}
				GameObject qPBar = GameObject.Find("qProgressBar_Mid_Pov") as GameObject;
				if (qPBar != null)
					qPBar.transform.localScale = new Vector3(qPBar.transform.localScale.x + 0.1f, qPBar.transform.localScale.y, qPBar.transform.localScale.z);
			}
			else
			{
				GameObject Congratseff = Instantiate(par_Congratulation_PF, new Vector3(-39.4f, 38.8f,129.8f), Quaternion.Euler(0, 180, 360)) as GameObject;
				Congratseff.GetComponent<ParticleSystem>().Play();
				
				popUpInfoScript.wall.active = false;
				guiControlInfo.popUpType4.SetActiveRecursively(false);
				guiControlInfo.popUpType_Dig1_spText.Text = "";
				guiControlInfo.popUpType_Dig2_spText.Text = "";
				questB = false;
				
				bubbleObj.SetActiveRecursively(true);
				speakTextObj.active = true;
				GameObject.Find("FightingTutorial").gameObject.GetComponent<AutoSpeak>().callToWriteText("Wait for the quest to complete or you can spend sparks to speed up");
				
				questRunningBool = false;
				popUpInfoScript.isQuestStoryAvailable = true;
				
				popUpInfoScript.curPopUpCnt = 27;
					popUpInfoScript.updateCurPopUpCount();
				
					popUpInfoScript.curPopUpType = 0;
					popUpInfoScript.generatePopUp(popUpInfoScript.curPopUpCnt, popUpInfoScript.curPopUpType);
				//Invoke("LookIntoQuest",4f);
				
				if(scr_audioController.audio_Quest.isPlaying)
				{
				 scr_audioController.audio_Quest.Stop();
				 enableQuest = false;
				 AudioController.EnableEnviron = true;	
				}
			}
		}*/