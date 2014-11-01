using UnityEngine;
using System.Collections;

public class InventoryItems : MonoBehaviour 
{
	public popUpInformation popUpInfoScript;
	public guiControl guiControlInfo;
	
	public GameObject inventoryui;
	public GameObject invCreatureBasePlate,invPlantsBasePlate,invPotionsBasePlate,invRewardBasePlate;
	
	//----------Inventory Base Plate--------------------------------------------------------------------------------------------
	
	public GameObject CreatureHalflingBasePlate,CreatureDarklingBasePlate;
	
	public GameObject PlantsHalflingBasePlate,PlantsDarklingBasePlate;
	
	public GameObject PotionsHalflingBasePlate,PotionsDarklingBasePlate;
	
	public GameObject RewardHalflingBasePlate,RewardDarklingBasePlate;
	
	//----------Creature Halfling--------------------------------
	
	public GameObject CreatureHalflingInvScrollList;
	
	public GameObject Creature_Halfling_Hound,Creature_Halfling_Barg,Creature_Halfling_Cusith,Creature_Halfling_Sprout,
					  Creature_Halfling_Nymph,Creature_Halfling_Dryad,Creature_Halfling_Nix,Creature_Halfling_Draug,
					  Creature_Halfling_Dragon;
	
	public SpriteText Creature_Halfling_Hound_Info_text,Creature_Halfling_Barg_Info_text,Creature_Halfling_Cusith_Info_text,
					  Creature_Halfling_Sprout_Info_text,Creature_Halfling_Nymph_Info_text,Creature_Halfling_Dryad_Info_text,
					  Creature_Halfling_Nix_Info_text,Creature_Halfling_Draug_Info_text,Creature_Halfling_Dragon_Info_text;
	
	//----------Creature Darkling--------------------------------------------------------------------------------------------------
	
	public GameObject CreatureDarklingInvScrollList;
	
	public GameObject Creature_Darkling_Leech,Creature_Darkling_DarkHound,Creature_Darkling_Sprite,Creature_Darkling_Leshy,
					  Creature_Darkling_Fenrir,Creature_Darkling_Imp,Creature_Darkling_Lurker,Creature_Darkling_HellHound,
					  Creature_Darkling_Djinn;
	
	public SpriteText Creature_Darkling_Leech_Info_text,Creature_Darkling_DarkHound_Info_text,Creature_Darkling_Sprite_Info_text,
					  Creature_Darkling_Leshy_Info_text,Creature_Darkling_Fenrir_Info_text,Creature_Darkling_Imp_Info_text,
					  Creature_Darkling_Lurker_Info_text,Creature_Darkling_HellHound_Info_text,Creature_Darkling_Djinn_Info_text;
	
	//----------Plants Halfling-------------------------------------------------------------------------------------------------------
	
	public GameObject PlantsHalflingInvScrollList;
	
	public GameObject Plants_Halfling_Pipeweed,Plants_Halfling_Turnip,Plants_Halfling_PumpkinHalf,Plants_Halfling_Costmary,
					  Plants_Halfling_Potato,Plants_Halfling_FairyLily,Plants_Halfling_Sunflower,Plants_Halfling_WaterCress,
					  Plants_Halfling_Vervain,Plants_Halfling_Mandrake,Plants_Halfling_Lotus,Plants_Halfling_Carrot,
					  Plants_Halfling_BleedingHeart,Plants_Halfling_FoxgloveBeardTongue,Plants_Halfling_WaterCaltrop,
					  Plants_Halfling_Soapwart,Plants_Halfling_BloodRoot,Plants_Halfling_Strawberry,Plants_Halfling_Taro;
	
	public SpriteText Plants_Halfling_Pipeweed_Info_text,Plants_Halfling_Turnip_Info_text,Plants_Halfling_PumpkinHalf_Info_text,
					  Plants_Halfling_Costmary_Info_text,Plants_Halfling_Potato_Info_text,Plants_Halfling_FairyLily_Info_text,
					  Plants_Halfling_Sunflower_Info_text,Plants_Halfling_WaterCress_Info_text,Plants_Halfling_Vervain_Info_text,
					  Plants_Halfling_Mandrake_Info_text,Plants_Halfling_Lotus_Info_text,Plants_Halfling_Carrot_Info_text,
					  Plants_Halfling_BleedingHeart_Info_text,Plants_Halfling_FoxgloveBeardTongue_Info_text,
					  Plants_Halfling_WaterCaltrop_Info_text,Plants_Halfling_Soapwart_Info_text,Plants_Halfling_BloodRoot_Info_text,
					  Plants_Halfling_Strawberry_Info_text,Plants_Halfling_Taro_Info_text;
	
	//----------Plants Darkling---------------------------------------------------------------------------------------------------------
	
	public GameObject PlantsDarklingInvScrollList;
	
	public GameObject Plants_Darkling_PumpkinDark,Plants_Darkling_Firepepper,Plants_Darkling_Aven,Plants_Darkling_Blackberry,
					  Plants_Darkling_Columbine,Plants_Darkling_MoonFlower,Plants_Darkling_BitterBrush,Plants_Darkling_BogBean,
					  Plants_Darkling_WolfsBane,Plants_Darkling_MulesEar,Plants_Darkling_Truffle,Plants_Darkling_LentLily,
					  Plants_Darkling_BitingStoneCrop,Plants_Darkling_Fleabane,Plants_Darkling_BloodRajah,Plants_Darkling_RavenSwing,
					  Plants_Darkling_Mushroom,Plants_Darkling_GasPlant;
		
	public SpriteText Plants_Darkling_PumpkinDark_Info_text,Plants_Darkling_Firepepper_Info_text,Plants_Darkling_Aven_Info_text,
					  Plants_Darkling_Blackberry_Info_text,Plants_Darkling_Columbine_Info_text,Plants_Darkling_MoonFlower_Info_text,
					  Plants_Darkling_BitterBrush_Info_text,Plants_Darkling_BogBean_Info_text,Plants_Darkling_WolfsBane_Info_text,
					  Plants_Darkling_MulesEar_Info_text,Plants_Darkling_Truffle_Info_text,Plants_Darkling_LentLily_Info_text,
					  Plants_Darkling_BitingStoneCrop_Info_text,Plants_Darkling_Fleabane_Info_text,Plants_Darkling_BloodRajah_Info_text,
					  Plants_Darkling_RavenSwing_Info_text,Plants_Darkling_Mushroom_Info_text,Plants_Darkling_GasPlant_Info_text;
		
	//----------Potions Halfling--------------------------------------------------------------------------------------------------------
		
	public GameObject PotionsHalflingInvScrollList;
	
	public GameObject Potions_Halfling_PoppySnap,Potions_Halfling_BitterRoot,Potions_Halfling_VetchSpray,Potions_Halfling_BoggleHorn,
					  Potions_Halfling_MossSalve,Potions_Halfling_Seawhip,Potions_Halfling_WolfTongue,Potions_Halfling_GrubSprout,
					  Potions_Halfling_DwaleBile;
	
	public SpriteText Potions_Halfling_PoppySnap_Info_text,Potions_Halfling_BitterRoot_Info_text,Potions_Halfling_VetchSpray_Info_text,
					  Potions_Halfling_BoggleHorn_Info_text,Potions_Halfling_MossSalve_Info_text,Potions_Halfling_Seawhip_Info_text,
					  Potions_Halfling_WolfTongue_Info_text,Potions_Halfling_GrubSprout_Info_text,Potions_Halfling_DwaleBile_Info_text;
	
	public SpriteText Potions_Halfling_PoppySnap_Cnt_text,Potions_Halfling_BitterRoot_Cnt_text,Potions_Halfling_VetchSpray_Cnt_text,
					  Potions_Halfling_BoggleHorn_Cnt_text,Potions_Halfling_MossSalve_Cnt_text,Potions_Halfling_Seawhip_Cnt_text,
					  Potions_Halfling_WolfTongue_Cnt_text,Potions_Halfling_GrubSprout_Cnt_text,Potions_Halfling_DwaleBile_Cnt_text;
	
	
	//----------Potions Darkling---------------------------------------------------------------------------------------------------------
	
	public GameObject PotionsDarklingInvScrollList;
	
	public GameObject Potions_Darkling_SlugTonic,Potions_Darkling_FeverPitch,Potions_Darkling_MorrowDraught,Potions_Darkling_MonkBlood,
					  Potions_Darkling_ScorchElixir,Potions_Darkling_SpleenBite,Potions_Darkling_Necrobane,Potions_Darkling_DevilIchor,
					  Potions_Darkling_StunkMange;
	
	public SpriteText Potions_Darkling_SlugTonic_Info_text,Potions_Darkling_FeverPitch_Info_text,Potions_Darkling_MorrowDraught_Info_text,
					  Potions_Darkling_MonkBlood_Info_text,Potions_Darkling_ScorchElixir_Info_text,Potions_Darkling_SpleenBite_Info_text,
					  Potions_Darkling_Necrobane_Info_text,Potions_Darkling_DevilIchor_Info_text,Potions_Darkling_StunkMange_Info_text;
	
	public SpriteText Potions_Darkling_SlugTonic_Cnt_text,Potions_Darkling_FeverPitch_Cnt_text,Potions_Darkling_MorrowDraught_Cnt_text,
					  Potions_Darkling_MonkBlood_Cnt_text,Potions_Darkling_ScorchElixir_Cnt_text,Potions_Darkling_SpleenBite_Cnt_text,
					  Potions_Darkling_Necrobane_Cnt_text,Potions_Darkling_DevilIchor_Cnt_text,Potions_Darkling_StunkMange_Cnt_text;
	
	

	//---------- Reward Halfling----------------------------------------------------------------------------------------------------
	
	public GameObject RewardHalflingInvScrollList;
	
	public GameObject Reward_Halfling_BloodStoneTrinket,Reward_Halfling_BloodStoneMedallion,Reward_Halfling_BloodStoneAmulet,Reward_Halfling_EmeraldTrinket,
					  Reward_Halfling_EmeraldMedallion,Reward_Halfling_EmeraldAmulet,Reward_Halfling_SapphireTrinket,Reward_Halfling_SapphireMedallion,Reward_Halfling_SapphireAmulet;
	
	public SpriteText Reward_Halfling_BloodStoneTrinket_Info_text,Reward_Halfling_BloodStoneMedallion_Info_text,Reward_Halfling_BloodStoneAmulet_Info_text,
					  Reward_Halfling_EmeraldTrinket_Info_text,Reward_Halfling_EmeraldMedallion_Info_text,Reward_Halfling_EmeraldAmulet_Info_text,
					  Reward_Halfling_SapphireTrinket_Info_text,Reward_Halfling_SapphireMedallion_Info_text,Reward_Halfling_SapphireAmulet_Info_text;
	
	public SpriteText Reward_Halfling_BloodStoneTrinket_Cnt_text,Reward_Halfling_BloodStoneMedallion_Cnt_text,Reward_Halfling_BloodStoneAmulet_Cnt_text,
					  Reward_Halfling_EmeraldTrinket_Cnt_text,Reward_Halfling_EmeraldMedallion_Cnt_text,Reward_Halfling_EmeraldAmulet_Cnt_text,
					  Reward_Halfling_SapphireTrinket_Cnt_text,Reward_Halfling_SapphireMedallion_Cnt_text,Reward_Halfling_SapphireAmulet_Cnt_text;
	
	
	//----------Reward Darkling-----------------------------------------------------------------------------------------------------
	
	public GameObject RewardDarklingInvScrollList;
	
	public GameObject Reward_Darkling_AmethystTrinket,Reward_Darkling_AmethystMedallion,Reward_Darkling_AmethystAmulet,Reward_Darkling_RubyTrinket,
					  Reward_Darkling_RubyMedallion,Reward_Darkling_RubyAmulet,Reward_Darkling_OnyxTrinket,Reward_Darkling_OnyxMedallion,
					  Reward_Darkling_OnyxAmulet;
	
	public SpriteText Reward_Darkling_AmethystTrinket_Info_text,Reward_Darkling_AmethystMedallion_Info_text,Reward_Darkling_AmethystAmulet_Info_text,
					  Reward_Darkling_RubyTrinket_Info_text,Reward_Darkling_RubyMedallion_Info_text,Reward_Darkling_RubyAmulet_Info_text,
					  Reward_Darkling_OnyxTrinket_Info_text,Reward_Darkling_OnyxMedallion_Info_text,Reward_Darkling_OnyxAmulet_Info_text;
	
	public SpriteText Reward_Darkling_AmethystTrinket_Cnt_text,Reward_Darkling_AmethystMedallion_Cnt_text,Reward_Darkling_AmethystAmulet_Cnt_text,
					  Reward_Darkling_RubyTrinket_Cnt_text,Reward_Darkling_RubyMedallion_Cnt_text,Reward_Darkling_RubyAmulet_Cnt_text,
					 Reward_Darkling_OnyxTrinket_Cnt_text,Reward_Darkling_OnyxMedallion_Cnt_text,Reward_Darkling_OnyxAmulet_Cnt_text;
	
	
	//----------To Acess the uiscrolllist gameobjects-------------------------------------------------------------------------------------
	
	public UIScrollList CreatureHalflingInvScrollListInfo,CreatureDarklingInvScrollListInfo;
	
	public UIScrollList RewardHalflingInvScrollListInfo,RewardDarklingInvScrollListInfo;
	
	public UIScrollList PlantsHalflingInvScrollListInfo,PlantsDarklingInvScrollListInfo;
	
	public UIScrollList PotionsHalflingInvScrollListInfo,PotionsDarklingInvScrollListInfo;
	
	
	//----------To make single instance----------------------------------------------------------------------------------------------------
	
	public bool CHbool = false;
	public bool CDbool = false;
	
	public bool RHbool = false;
	public bool RDbool = false;
	
	public bool PHbool = false;
	public bool PDbool = false;
	
	public bool PoHbool = false;
	public bool PoDbool = false;
	
	//Battle Ground Var:
	int index;
	public GameObject Battle;
	private BattleGroundManager bgmScript;
	
	public GameObject sfx;
	private GameObjectsSvr gosScript;
	
	private GameObjectsSvr Scr_gameObj;
	private LoadUserWorld Scr_userLoad;
	private RewardsSvr svr_reward;
	void Awake()
	{
		Scr_gameObj = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		Scr_userLoad = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		svr_reward = (RewardsSvr)FindObjectOfType(typeof(RewardsSvr));
	}
	void Start () 
	{
		bgmScript = Battle.GetComponent<BattleGroundManager>();
		gosScript = sfx.GetComponent<GameObjectsSvr>();
	}
	
//	void itemBagButton()
//	{
//		buttonPulse itemBag = GameObject.Find("ItemBagUIDemo").GetComponent("buttonPulse") as buttonPulse;
//		inventoryui.SetActiveRecursively(true);
//	}
	
	
	
	
	//---------------------------------------FIGHTING GROUND METHODS------------------------------//
	
	
	public void inventoryPotionsForFight()
	{
		if (GameManager.gameLevel >= 3)
		{
			
			//buttonPulse invPotion = GameObject.Find("inventoryPotionButt").GetComponent("buttonPulse") as buttonPulse;
			
			inventoryui.SetActiveRecursively(false);
			
			invPotionsBasePlate.SetActiveRecursively(true);
			PotionsHalflingBasePlate.active = true;
			PotionsDarklingBasePlate.active = false;
			
			PotionsHalflingInvScrollList.SetActiveRecursively(true);
			
			PotionsHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
			
			PotionsHalflingInvScrollListInfo = GameObject.Find("Potions_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
			PotionsHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
			PotionsHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
			PotionsHalflingInvScrollListInfo.sceneItems = new GameObject[9];
			
			PoHbool = true;
			PotionsHalfScrollEntry();
		}
	}
	
	
	private void SendCreatureImageInfo(int id)
	{
		if(bgmScript.curState == state.gameInvitePrepare)
		{
			//Debug.Log("hey");
			bgmScript.InviteCreatureImageManager(id,0);
			inventoryClose();
		}
		if(bgmScript.curState == state.gameInviteAccept)
		{
		//Debug.Log("Inside Accept");
		bgmScript.InviteCreatureImageManager(id,1);
		inventoryClose();
		}
	}
	
	
	
	
	
	//---------------------------------------------------END----------------------------------------//
	
	void inventoryCancleButton()
	{
		buttonPulse invCancle = GameObject.Find("inventoryCancleButtDemo").GetComponent("buttonPulse") as buttonPulse;
		inventoryui.SetActiveRecursively(false);
	}
	
	void storeHomeButton()
	{
		buttonPulse invHome = GameObject.Find("inventoryHomeButtDemo").GetComponent("buttonPulse") as buttonPulse;
		inventoryui.SetActiveRecursively(false);
	}
	
	public	void inventoryCreature()
	{
		//buttonPulse invCreature = GameObject.Find("inventoryCreatureButtDemo").GetComponent("buttonPulse") as buttonPulse;
		
		inventoryui.SetActiveRecursively(false);
		
		invCreatureBasePlate.SetActiveRecursively(true);
		CreatureHalflingBasePlate.active = true;
		CreatureDarklingBasePlate.active = false;
		
		CreatureHalflingInvScrollList.SetActiveRecursively(true);
		
		CreatureHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		CreatureHalflingInvScrollListInfo = GameObject.Find("Creature_halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		CreatureHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		CreatureHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		CreatureHalflingInvScrollListInfo.sceneItems = new GameObject[9];
		
		CHbool = true;
		CreatureHalfScrollEntry();
	}
	
	public void inventoryPlantButtons()
	{
		if (GameManager.gameLevel >= 3)
		{
			GameObject go = GameObject.Find("inventoryPlantButt") as GameObject;
			
			if (go != null)
			{
				buttonPulse invPlant = GameObject.Find("inventoryPlantButt").GetComponent("buttonPulse") as buttonPulse;
			
				inventoryui.SetActiveRecursively(false);
			
				invPlantsBasePlate.SetActiveRecursively(true);
				PlantsHalflingBasePlate.active = true;
				PlantsDarklingBasePlate.active = false;
			
				PlantsHalflingInvScrollList.SetActiveRecursively(true);
			
				PlantsHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
				
				GameObject go1 = GameObject.Find("Plants_Halfling_ScrollList") as GameObject;
				
				if (go1 != null)
				{
					PlantsHalflingInvScrollListInfo = GameObject.Find("Plants_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
					PlantsHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
					PlantsHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
					PlantsHalflingInvScrollListInfo.sceneItems = new GameObject[19];
				}
			
				PHbool = true;
				PlantsHalfScrollEntry();
			}
		}
	}
	
	public void inventoryPotionsButtons()
	{
		if (GameManager.gameLevel >= 3)
		{
			GameObject potionBut = GameObject.Find("inventoryPotionButt") as GameObject;
			if(potionBut != null)
			{
			buttonPulse invPotion = GameObject.Find("inventoryPotionButt").GetComponent("buttonPulse") as buttonPulse;
			}
			inventoryui.SetActiveRecursively(false);
			
			invPotionsBasePlate.SetActiveRecursively(true);
			PotionsHalflingBasePlate.active = true;
			PotionsDarklingBasePlate.active = false;
			
			PotionsHalflingInvScrollList.SetActiveRecursively(true);
			
			PotionsHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
			
			PotionsHalflingInvScrollListInfo = GameObject.Find("Potions_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
			PotionsHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
			PotionsHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
			PotionsHalflingInvScrollListInfo.sceneItems = new GameObject[9];
			
			PoHbool = true;
			PotionsHalfScrollEntry();
		
	}
	}
public void inventoryRewardButtons()
	{
		if (GameManager.gameLevel >= 3)
		{
			GameObject RewardBut = GameObject.Find("inventoryRewardButt") as GameObject;
			if(RewardBut != null)
			{
				buttonPulse invRewards = GameObject.Find("inventoryRewardButt").GetComponent("buttonPulse") as buttonPulse;
				
				inventoryui.SetActiveRecursively(false);
				
				invRewardBasePlate.SetActiveRecursively(true);
				RewardHalflingBasePlate.active = true;
				RewardDarklingBasePlate.active = false;
				
				RewardHalflingInvScrollList.SetActiveRecursively(true);
				
				RewardHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
				
				RewardHalflingInvScrollListInfo = GameObject.Find("Rewards_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
				RewardHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
				RewardHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
				RewardHalflingInvScrollListInfo.sceneItems = new GameObject[9];
				
				RHbool = true;
				RewardHalfScrollEntry();
			}
		}
	}
	
	void inventoryCancleButtondemo()
	{
		if(GameManager.taskCount == 4)
		{
			//creatureUI.SetActiveRecursively(false);
			Destroy(guiControlInfo.delArrow);
			popUpInfoScript.wall.active = true;
			guiControlInfo.inventoryUI.SetActiveRecursively(true);
			
			GameObject arrowTemp = GameObject.Find("ArrowPF(Clone)") as GameObject;
			Destroy(arrowTemp);
			if(!bgmScript.isBattle)
			{
			//Debug.Log("Under Cancel POPUP Button--");
			guiControlInfo.inventoryUI.SetActiveRecursively(true);
			}
			buttonPulse iCreatureButtBP = GameObject.Find("inventoryCreatureButt").GetComponent("buttonPulse") as buttonPulse;
			iCreatureButtBP.scaleAnim = true;
			GameObject iCreatureSpwan = GameObject.Find("iCreatureSpwan");
			GameObject temp = Instantiate(guiControlInfo.arrow, new Vector3(iCreatureSpwan.transform.position.x, iCreatureSpwan.transform.position.y, iCreatureSpwan.transform.position.z + 12), Quaternion.Inverse(iCreatureSpwan.transform.rotation)) as GameObject;
			guiControlInfo.delArrow = temp;
		}
//		if (GameManager.gameLevel >= 3 & !bgmScript.isBattle)
//		{
//			inventoryui.SetActiveRecursively(true);
//		}

		if (GameManager.gameLevel > 3)
		{
			popUpInfoScript.wall.active = false;
			inventoryClose();
		}
	}
	
	void CreatureHalflingInventoryBasePlatebtn()
	{
		CHbool = true;
		CDbool = false;
		
		buttonPulse CreHWInvBpBtn = GameObject.Find("CreatureHalflingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		CreatureHalflingBasePlate.active = true;
		CreatureDarklingBasePlate.active = false;
		
		CreatureHalflingInvScrollList.SetActiveRecursively(true);
		
		CreatureHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		CreatureHalflingInvScrollListInfo = GameObject.Find("Creature_halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		CreatureHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		CreatureHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		CreatureHalflingInvScrollListInfo.sceneItems = new GameObject[9];
		
		CreatureDarkScrollClose();
		
		GameObject cDSMover = GameObject.Find("Creature_Darkling_ScrollList") as GameObject;
		
		if (cDSMover != null)
		{
			Transform dcMover = cDSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Creature_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(CreatureDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
		
		CreatureHalfScrollEntry();
		
		CreatureDarklingInvScrollList.SetActiveRecursively(false);
		
		Creature_Darkling_Leech.SetActiveRecursively(false);
		Creature_Darkling_DarkHound.SetActiveRecursively(false);
		Creature_Darkling_Sprite.SetActiveRecursively(false);
		Creature_Darkling_Leshy.SetActiveRecursively(false);
		Creature_Darkling_Fenrir.SetActiveRecursively(false);
		Creature_Darkling_Imp.SetActiveRecursively(false);
		Creature_Darkling_Lurker.SetActiveRecursively(false);
		Creature_Darkling_HellHound.SetActiveRecursively(false);
		Creature_Darkling_Djinn.SetActiveRecursively(false);
	}
	
	void CreatureDarklingInventoryBasePlatebtn()
	{
		if(GameManager.unlockDarklingBool)
		{
		if (GameManager.gameLevel > 3)
		{
			CHbool = false;
			CDbool = true;
			
			buttonPulse CreDLInvBpBtn = GameObject.Find("CreatureDarklingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
			
			CreatureHalflingBasePlate.active = false;
			CreatureDarklingBasePlate.active = true;
			
			CreatureDarklingInvScrollList.SetActiveRecursively(true);
			
			CreatureDarklingInvScrollList.gameObject.AddComponent("UIScrollList");
			
			CreatureDarklingInvScrollListInfo = GameObject.Find("Creature_Darkling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
			CreatureDarklingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
			CreatureDarklingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
			CreatureDarklingInvScrollListInfo.sceneItems = new GameObject[9];
				
///***			Debug.Log("stuck here 01 <-----");	
			CreatureHalfScrollClose();
			
		
			GameObject cHSMover = GameObject.Find("Creature_halfling_ScrollList") as GameObject;

			if (cHSMover != null)
			{
				Transform hcMover = cHSMover.transform.FindChild("Mover") as Transform;
				Destroy(GameObject.Find("Creature_halfling_ScrollList").transform.FindChild("Mover").gameObject);
				Destroy(CreatureHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			}
				
			CreatureDarkScrollEntry();
			
			CreatureHalflingInvScrollList.SetActiveRecursively(false);
			
			Creature_Halfling_Hound.SetActiveRecursively(false);
			Creature_Halfling_Barg.SetActiveRecursively(false);
			Creature_Halfling_Cusith.SetActiveRecursively(false);
			Creature_Halfling_Sprout.SetActiveRecursively(false);
			Creature_Halfling_Nymph.SetActiveRecursively(false);
			Creature_Halfling_Dryad.SetActiveRecursively(false);
			Creature_Halfling_Nix.SetActiveRecursively(false);
			Creature_Halfling_Draug.SetActiveRecursively(false);
			Creature_Halfling_Dragon.SetActiveRecursively(false);
		}
		}
	}
	
	void PlantsHalflingInventoryBasePlatebtn()
	{
		PHbool = true;
		PDbool =false;
		
		buttonPulse PlaHWInvBpBtn = GameObject.Find("PlantsHalflingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		PlantsHalflingBasePlate.active = true;
		PlantsDarklingBasePlate.active = false;
		
		PlantsHalflingInvScrollList.SetActiveRecursively(true);
		
		PlantsHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		PlantsHalflingInvScrollListInfo = GameObject.Find("Plants_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		PlantsHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		PlantsHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		PlantsHalflingInvScrollListInfo.sceneItems = new GameObject[19];
		
		PlantsDarkScrollClose();
		
		GameObject pDSMover = GameObject.Find("Plants_Darkling_ScrollList") as GameObject;
		
		if (pDSMover != null)
		{
			Transform dpMover = pDSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Plants_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PlantsDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
		
		PlantsHalfScrollEntry();
		
		PlantsDarklingInvScrollList.SetActiveRecursively(false);
		
		Plants_Darkling_PumpkinDark.SetActiveRecursively(false);
		Plants_Darkling_Firepepper.SetActiveRecursively(false);
		Plants_Darkling_Aven.SetActiveRecursively(false);
		Plants_Darkling_Blackberry.SetActiveRecursively(false);
		Plants_Darkling_Columbine.SetActiveRecursively(false);
		Plants_Darkling_MoonFlower.SetActiveRecursively(false);
		Plants_Darkling_BitterBrush.SetActiveRecursively(false);
		Plants_Darkling_BogBean.SetActiveRecursively(false);
		Plants_Darkling_WolfsBane.SetActiveRecursively(false);
		Plants_Darkling_MulesEar.SetActiveRecursively(false);
		Plants_Darkling_Truffle.SetActiveRecursively(false);
		Plants_Darkling_LentLily.SetActiveRecursively(false);
		Plants_Darkling_BitingStoneCrop.SetActiveRecursively(false);
		Plants_Darkling_Fleabane.SetActiveRecursively(false);
		Plants_Darkling_BloodRajah.SetActiveRecursively(false);
		Plants_Darkling_RavenSwing.SetActiveRecursively(false);
		Plants_Darkling_Mushroom.SetActiveRecursively(false);
		Plants_Darkling_GasPlant.SetActiveRecursively(false);
	}
	
	void PlantsDarklingInventoryBasePlatebtn()
	{
		if(GameManager.unlockDarklingBool)
		{
		PHbool = false;
		PDbool = true;
		
		buttonPulse PlaDLInvBpBtn = GameObject.Find("PlantsDarklingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		PlantsHalflingBasePlate.active = false;
		PlantsDarklingBasePlate.active = true;
		
		PlantsDarklingInvScrollList.SetActiveRecursively(true);
		
		PlantsDarklingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		PlantsDarklingInvScrollListInfo = GameObject.Find("Plants_Darkling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		PlantsDarklingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		PlantsDarklingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		PlantsDarklingInvScrollListInfo.sceneItems = new GameObject[18];
		
		PlantsHalfScrollClose();
		
		GameObject pHSMover = GameObject.Find("Plants_Halfling_ScrollList") as GameObject;
		
		if (pHSMover != null)
		{
			Transform hpMover = pHSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Plants_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PlantsHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
			
		PlantsDarkScrollEntry();
		
		PlantsHalflingInvScrollList.SetActiveRecursively(false);
		
		Plants_Halfling_Pipeweed.SetActiveRecursively(false);
		Plants_Halfling_Turnip.SetActiveRecursively(false);
		Plants_Halfling_PumpkinHalf.SetActiveRecursively(false);
		Plants_Halfling_Costmary.SetActiveRecursively(false);
		Plants_Halfling_Potato.SetActiveRecursively(false);
		Plants_Halfling_FairyLily.SetActiveRecursively(false);
		Plants_Halfling_Sunflower.SetActiveRecursively(false);
		Plants_Halfling_WaterCress.SetActiveRecursively(false);
		Plants_Halfling_Vervain.SetActiveRecursively(false);
		Plants_Halfling_Mandrake.SetActiveRecursively(false);
		Plants_Halfling_Lotus.SetActiveRecursively(false);
		Plants_Halfling_Carrot.SetActiveRecursively(false);
		Plants_Halfling_BleedingHeart.SetActiveRecursively(false);
		Plants_Halfling_FoxgloveBeardTongue.SetActiveRecursively(false);
		Plants_Halfling_WaterCaltrop.SetActiveRecursively(false);
		Plants_Halfling_Soapwart.SetActiveRecursively(false);
		Plants_Halfling_BloodRoot.SetActiveRecursively(false);
		Plants_Halfling_Strawberry.SetActiveRecursively(false);
		Plants_Halfling_Taro.SetActiveRecursively(false);
		}
	}
	
	void PotionsHalflingInventoryBasePlatebtn()
	{
		PoHbool =true;
		PoDbool = false;
		
		buttonPulse PotHWInvBpBtn = GameObject.Find("PotionsHalflingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		PotionsHalflingBasePlate.active = true;
		PotionsDarklingBasePlate.active = false;
		
		PotionsHalflingInvScrollList.SetActiveRecursively(true);
		
		PotionsHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		PotionsHalflingInvScrollListInfo = GameObject.Find("Potions_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		PotionsHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		PotionsHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		PotionsHalflingInvScrollListInfo.sceneItems = new GameObject[9];
		
		PotionsDarkScrollClose();
		
		GameObject poDSMover = GameObject.Find("Potions_Darkling_ScrollList") as GameObject;
		
		if (poDSMover != null)
		{
			Transform dpoMover = poDSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Potions_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PotionsDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
		
		PotionsHalfScrollEntry();
		
		PotionsDarklingInvScrollList.SetActiveRecursively(false);
		
		Potions_Darkling_SlugTonic.SetActiveRecursively(false);
		Potions_Darkling_FeverPitch.SetActiveRecursively(false);
		Potions_Darkling_MorrowDraught.SetActiveRecursively(false); 
		Potions_Darkling_MonkBlood.SetActiveRecursively(false);
		Potions_Darkling_ScorchElixir.SetActiveRecursively(false);
		Potions_Darkling_SpleenBite.SetActiveRecursively(false);
		Potions_Darkling_Necrobane.SetActiveRecursively(false);
		Potions_Darkling_DevilIchor.SetActiveRecursively(false);
		Potions_Darkling_StunkMange.SetActiveRecursively(false);
	}
	
	void PotionsDarklingInventoryBasePlatebtn()
	{
		if(GameManager.unlockDarklingBool)
		{
		PoHbool = false;
		PoDbool = true;
		
		buttonPulse potDLInvBpBtn = GameObject.Find("PotionsDarklingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		PotionsHalflingBasePlate.active = false;
		PotionsDarklingBasePlate.active = true;
		
		PotionsDarklingInvScrollList.SetActiveRecursively(true);
		
		PotionsDarklingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		PotionsDarklingInvScrollListInfo = GameObject.Find("Potions_Darkling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		PotionsDarklingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		PotionsDarklingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		PotionsDarklingInvScrollListInfo.sceneItems = new GameObject[9];
		
		PotionsHalfScrollClose();
		
		GameObject poHSMover = GameObject.Find("Potions_Halfling_ScrollList") as GameObject;
		
		if (poHSMover != null)
		{
			Transform hpoMover = poHSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Potions_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PotionsHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
			
		PotionsDarkScrollEntry();
		
		PotionsHalflingInvScrollList.SetActiveRecursively(false);
		
		Potions_Halfling_PoppySnap.SetActiveRecursively(false);
		Potions_Halfling_BitterRoot.SetActiveRecursively(false);
		Potions_Halfling_VetchSpray.SetActiveRecursively(false);
		Potions_Halfling_BoggleHorn.SetActiveRecursively(false);
		Potions_Halfling_MossSalve.SetActiveRecursively(false);
		Potions_Halfling_Seawhip.SetActiveRecursively(false);
		Potions_Halfling_WolfTongue.SetActiveRecursively(false); 
		Potions_Halfling_GrubSprout.SetActiveRecursively(false);
		Potions_Halfling_DwaleBile.SetActiveRecursively(false);
		}
	}
	
	void RewardHalflingInventoryBasePlatebtn()
	{
		RHbool = true;
		RDbool =false;
		
		buttonPulse HerHWInvBpBtn = GameObject.Find("RewardHalflingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
		
		RewardHalflingBasePlate.active = true;
		RewardDarklingBasePlate.active = false;
		
		RewardHalflingInvScrollList.SetActiveRecursively(true);
		
		RewardHalflingInvScrollList.gameObject.AddComponent("UIScrollList");
		
		RewardHalflingInvScrollListInfo = GameObject.Find("Rewards_Halfling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
		RewardHalflingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
		RewardHalflingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
		RewardHalflingInvScrollListInfo.sceneItems = new GameObject[9];
		
		RewardDarkScrollClose();
		
		GameObject rDSMover = GameObject.Find("Rewards_Darkling_ScrollList") as GameObject;
		
		if (rDSMover != null)
		{
			Transform drMover = rDSMover.transform.FindChild("Mover") as Transform;
			Destroy(GameObject.Find("Rewards_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(RewardDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
		}
		
		RewardHalfScrollEntry();
		
		RewardDarklingInvScrollList.SetActiveRecursively(false);
		
		Reward_Darkling_AmethystTrinket.SetActiveRecursively(false);
		Reward_Darkling_AmethystMedallion.SetActiveRecursively(false);
		Reward_Darkling_AmethystAmulet.SetActiveRecursively(false);
		Reward_Darkling_RubyTrinket.SetActiveRecursively(false);
		Reward_Darkling_RubyMedallion.SetActiveRecursively(false);
		Reward_Darkling_RubyAmulet.SetActiveRecursively(false);
		Reward_Darkling_OnyxTrinket.SetActiveRecursively(false);
		Reward_Darkling_OnyxMedallion.SetActiveRecursively(false);
		Reward_Darkling_OnyxAmulet.SetActiveRecursively(false);
	}
	
	void RewardDarklingInventoryBasePlatebtn()
	{
		if(GameManager.unlockDarklingBool)
		{
			RHbool = false;
			RDbool = true;
			
			buttonPulse HerDLInvBpBtn = GameObject.Find("RewardDarklingInventoryBasePlatebtn").GetComponent("buttonPulse") as buttonPulse;
			
			RewardHalflingBasePlate.active = false;
			RewardDarklingBasePlate.active = true;
			
			RewardDarklingInvScrollList .SetActiveRecursively(true);
			
			RewardDarklingInvScrollList.gameObject.AddComponent("UIScrollList");
			
			RewardDarklingInvScrollListInfo  = GameObject.Find("Rewards_Darkling_ScrollList").GetComponent("UIScrollList") as UIScrollList;
			RewardDarklingInvScrollListInfo.viewableArea = new Vector2(74.0f,40.0f);
			RewardDarklingInvScrollListInfo.orientation = UIScrollList.ORIENTATION.VERTICAL;
			RewardDarklingInvScrollListInfo.sceneItems = new GameObject[9];
			
			RewardHalfScrollClose();
		
			GameObject rHSMover = GameObject.Find("Rewards_Halfling_ScrollList") as GameObject;
		
			if (rHSMover != null)
			{
				Transform hrMover = rHSMover.transform.FindChild("Mover") as Transform;
				Destroy(GameObject.Find("Rewards_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
				Destroy(RewardHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			}
			
			RewardDarkScrollEntry();
			
			RewardHalflingInvScrollList.SetActiveRecursively(false);
			
			Reward_Halfling_BloodStoneTrinket.SetActiveRecursively(false);
			Reward_Halfling_BloodStoneMedallion.SetActiveRecursively(false);
			Reward_Halfling_BloodStoneAmulet.SetActiveRecursively(false);
			Reward_Halfling_EmeraldTrinket.SetActiveRecursively(false);
			Reward_Halfling_EmeraldMedallion.SetActiveRecursively(false);
			Reward_Halfling_EmeraldAmulet.SetActiveRecursively(false);
			Reward_Halfling_SapphireTrinket.SetActiveRecursively(false);
			Reward_Halfling_SapphireMedallion.SetActiveRecursively(false);
			Reward_Halfling_SapphireAmulet.SetActiveRecursively(false);
		}
	}
	
	void CreatureHalfScrollEntry()
	{
		GameObject HoundHalf = GameObject.Find("HC_C_Hound_GO(Clone)")  as GameObject;
		GameObject Barg 	 = GameObject.Find("HC_C_Barg_GO(Clone)")   as GameObject;
		GameObject Cusith 	 = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
		GameObject Sprout 	 = GameObject.Find("HC_C_Sprout_GO(Clone)") as GameObject;
		GameObject Nymph 	 = GameObject.Find("HC_C_Nymph_GO(Clone)")  as GameObject;
		GameObject Dryad 	 = GameObject.Find("HC_C_Dryad_GO(Clone)")  as GameObject;
		GameObject Nix 		 = GameObject.Find("HC_C_Nix_GO(Clone)")    as GameObject;
		GameObject Draug 	 = GameObject.Find("HC_C_Draug_GO(Clone)")  as GameObject;
		GameObject Dragon 	 = GameObject.Find("HC_C_Dragon_GO(Clone)") as GameObject;
		
		if(HoundHalf != null)
		{
			Creature_Halfling_Hound.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_hound") as GameObject;
			Creature_Halfling_Hound_Info_text.Text = "Halfling Hound Creature";
		}
		
		if(Barg != null)
		{
			Creature_Halfling_Barg.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_Barg") as GameObject;
			Creature_Halfling_Barg_Info_text.Text = "Halfling Barg Creature";
		}
	
		if(Cusith != null)
		{
			Creature_Halfling_Cusith.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_Cusith") as GameObject;
			Creature_Halfling_Cusith_Info_text.Text = "Halfling Cusith Creature";
		}
	
		if(Sprout != null)
		{
			Creature_Halfling_Sprout.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_Sprout") as GameObject;
			Creature_Halfling_Sprout_Info_text.Text = "Halfling Sprout Creature";
		}
	
		if(Nymph != null)
		{
			Creature_Halfling_Nymph.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_Nymph") as GameObject;
			Creature_Halfling_Nymph_Info_text.Text = "Halfling Nymph Creature";
		}
		
		if(Dryad != null)
		{
			Creature_Halfling_Dryad.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_Dryad") as GameObject;
			Creature_Halfling_Dryad_Info_text.Text = "Halfling Dryad Creature";
		}
		
		if(Nix != null)
		{
			Creature_Halfling_Nix.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_Nix") as GameObject;
			Creature_Halfling_Nix_Info_text.Text = "Halfling Nix Creature";
		}
		
		if(Draug != null)
		{
			Creature_Halfling_Draug.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_Draug") as GameObject;
			Creature_Halfling_Draug_Info_text.Text = "Halfling Draug Creature";
		}
		
		if(Dragon != null)
		{
			Creature_Halfling_Dragon.SetActiveRecursively(true);
			CreatureHalflingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_Dragon") as GameObject;
			Creature_Halfling_Dragon_Info_text.Text = "Halfling Dragon Creature";
		}
	}
	
	void CreatureDarkScrollEntry()
	{
		GameObject Leech 	 = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
		GameObject DarkHound = GameObject.Find("DL_C_DHound_GO(Clone)") as GameObject;
		GameObject Sprite	 = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
		GameObject Leshy	 = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
		GameObject Fenrir	 = GameObject.Find("DL_C_Fenrir_GO(Clone)") as GameObject;
		GameObject Imp		 = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
		GameObject Lurker	 = GameObject.Find("DL_C_Lurker_GO(Clone)") as GameObject;
		GameObject HellHound = GameObject.Find("DL_C_HellHound_GO(Clone)") as GameObject;
		GameObject Djinn	 = GameObject.Find("DL_C_Djinn_GO(Clone)") as GameObject;
		
		if(Leech != null)
		{
			Creature_Darkling_Leech.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_Leech") as GameObject;
			Creature_Darkling_Leech_Info_text.Text = "Darkling Leech Creature";
		}
		
		if(DarkHound != null)
		{
			Creature_Darkling_DarkHound.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list2_DarkHound") as GameObject;
			Creature_Darkling_DarkHound_Info_text.Text = "Darkling Hound Creature";
		}
		
		if(Sprite != null)
		{
			Creature_Darkling_Sprite.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list3_Sprite") as GameObject;
			Creature_Darkling_Sprite_Info_text.Text = "Darkling Sprite Creature";
		}
		
		if(Leshy != null)
		{
			Creature_Darkling_Leshy.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list4_Leshy") as GameObject;
			Creature_Darkling_Leshy_Info_text.Text = "Darkling Leshy Creature";
		}
		
		if(Fenrir != null)
		{
			Creature_Darkling_Fenrir.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list5_Fenrir") as GameObject;
			Creature_Darkling_Fenrir_Info_text.Text = "Darkling Fenrir Creature";
		}
		
		if(Imp != null)
		{
			Creature_Darkling_Imp.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_Imp") as GameObject;
			Creature_Darkling_Imp_Info_text.Text = "Darkling Imp Creature";
		}
		
		if(Lurker != null)
		{
			Creature_Darkling_Lurker.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list7_Lurker") as GameObject;
			Creature_Darkling_Lurker_Info_text.Text = "Darkling Lurker Creature";
		}
		
		if(HellHound != null)
		{
			Creature_Darkling_HellHound.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list8_HellHound") as GameObject;
			Creature_Darkling_HellHound_Info_text.Text = "Darkling HellHound Creature";
		}
		
		if(Djinn != null)
		{
			Creature_Darkling_Djinn.SetActiveRecursively(true);
			CreatureDarklingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list9_Djinn") as GameObject;
			Creature_Darkling_Djinn_Info_text.Text = "Darkling Djinn Creature";
		}
	}
	
	
	void PlantsHalfScrollEntry()
	{
		GameObject Lotus 				= GameObject.Find("") as GameObject;
		GameObject Carrot 				= GameObject.Find("") as GameObject;
		GameObject BleedingHeart 		= GameObject.Find("") as GameObject;
		GameObject FoxgloveBeardTongue 	= GameObject.Find("") as GameObject;
		GameObject WaterCaltrop 		= GameObject.Find("") as GameObject;
		GameObject Soapwart 			= GameObject.Find("") as GameObject;
		GameObject BloodRoot 			= GameObject.Find("") as GameObject;
		GameObject Strawberry 			= GameObject.Find("") as GameObject;
		GameObject Taro 				= GameObject.Find("") as GameObject;
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objPipeweed.objTypeId)>0)
		{
			Plants_Halfling_Pipeweed.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_Pipeweed") as GameObject;
			Plants_Halfling_Pipeweed_Info_text.Text = "Halfling Pipeweed Plant";
		}
			
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objTurnips.objTypeId) > 0)
		{
			Plants_Halfling_Turnip.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_Turnip") as GameObject;
			Plants_Halfling_Turnip_Info_text.Text = "Halfling Turnip Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objPumpkin.objTypeId) >0)
		{
			Plants_Halfling_PumpkinHalf.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_PumpkinHalf") as GameObject;
			Plants_Halfling_PumpkinHalf_Info_text.Text = "Halfling Pumpkin Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objCostmaryherb.objTypeId)>0)
		{
			Plants_Halfling_Costmary.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_Costmary") as GameObject;
			Plants_Halfling_Costmary_Info_text.Text = "Halfling Costmary Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objPotatoes.objTypeId)>0)
		{
			Plants_Halfling_Potato.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_Potato") as GameObject;
			Plants_Halfling_Potato_Info_text.Text = "Halfling Potato Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objFairyLilly.objTypeId)>0)
		{
			Plants_Halfling_FairyLily.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_FairyLily") as GameObject;
			Plants_Halfling_FairyLily_Info_text.Text = "Halfling FairyLily Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objSunflower.objTypeId)>0)
		{
			Plants_Halfling_Sunflower.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_Sunflower") as GameObject;
			Plants_Halfling_Sunflower_Info_text.Text = "Halfling Sunflower Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objWatercress.objTypeId)>0)
		{
			Plants_Halfling_WaterCress.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_WaterCress") as GameObject;
			Plants_Halfling_WaterCress_Info_text.Text = "Halfling WaterCress Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objVervainHerb.objTypeId)>0 )
		{
			Plants_Halfling_Vervain.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_Vervain") as GameObject;
			Plants_Halfling_Vervain_Info_text.Text = "Halfling Vervain Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objMandrake.objTypeId)>0)
		{
			Plants_Halfling_Mandrake.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[9] = GameObject.Find("Container_list10_Mandrake") as GameObject;
			Plants_Halfling_Mandrake_Info_text.Text = "Halfling Mandrake Plant";
		}
		
		if(Lotus != null)
		{
			Plants_Halfling_Lotus.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[10] = GameObject.Find("Container_list11_Lotus") as GameObject;
			Plants_Halfling_Lotus_Info_text.Text = "Halfling Lotus Plant";
		}
		
		if(Carrot != null)
		{
			Plants_Halfling_Carrot.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[11] = GameObject.Find("Container_list12_Carrot") as GameObject;
			Plants_Halfling_Carrot_Info_text.Text = "Halfling Carrot Plant";
		}
		
		if(BleedingHeart != null)
		{
			Plants_Halfling_BleedingHeart.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[12] = GameObject.Find("Container_list13_BleedingHeart") as GameObject;
			Plants_Halfling_BleedingHeart_Info_text.Text = "Halfling BleedingHeart Plant";
		}
		
		if(FoxgloveBeardTongue != null)
		{
			Plants_Halfling_FoxgloveBeardTongue.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[13] = GameObject.Find("Container_list14_FoxgloveBreadtongue") as GameObject;
			Plants_Halfling_FoxgloveBeardTongue_Info_text.Text = "Halfling FoxgloveBeardTongue Plant";
		}
		
		if(WaterCaltrop != null)
		{
			Plants_Halfling_WaterCaltrop.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[14] = GameObject.Find("Container_list15_WaterCaltrop") as GameObject;
			Plants_Halfling_WaterCaltrop_Info_text.Text = "Halfling WaterCaltrop Plant";
		}
		
		if(Soapwart != null)
		{
			Plants_Halfling_Soapwart.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[15] = GameObject.Find("Container_list16_Soapwart") as GameObject;
			Plants_Halfling_Soapwart_Info_text.Text = "Halfling Soapwart Plant";
		}
		
		if(BloodRoot != null)
		{
			Plants_Halfling_BloodRoot.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[16] = GameObject.Find("Container_list17_BloodRoot") as GameObject;
			Plants_Halfling_BloodRoot_Info_text.Text = "Halfling BloodRoot Plant";
		}
		
		if(Strawberry != null)
		{
			Plants_Halfling_Strawberry.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[17] = GameObject.Find("Container_list18_StrawBerry") as GameObject;
			Plants_Halfling_Strawberry_Info_text.Text = "Halfling Strawberry Plant";
		}
		
		if(Taro != null)
		{
			Plants_Halfling_Taro.SetActiveRecursively(true);
			PlantsHalflingInvScrollListInfo.sceneItems[18] = GameObject.Find("Container_list19_Taro") as GameObject;
			Plants_Halfling_Taro_Info_text.Text = "Halfling Taro Plant";
		}
	}
	
	void PlantsDarkScrollEntry()
	{
		GameObject MulesEar 		= GameObject.Find("") as GameObject;
		GameObject Truffle 			= GameObject.Find("") as GameObject;
		GameObject LentLily 		= GameObject.Find("") as GameObject;
		GameObject BitingStoneCrop 	= GameObject.Find("") as GameObject;
		GameObject Fleabane 		= GameObject.Find("") as GameObject;
		GameObject BloodRajah 		= GameObject.Find("") as GameObject;
		GameObject RavenSwing 		= GameObject.Find("") as GameObject;
		GameObject Mushroom 		= GameObject.Find("") as GameObject;
		GameObject GasPlant 		= GameObject.Find("") as GameObject;
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingPumpkin.objTypeId)>0)
		{
			Plants_Darkling_PumpkinDark.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_Pumpkin") as GameObject;
			Plants_Darkling_PumpkinDark_Info_text.Text = "Darkling Pumpkin Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingFirePepper.objTypeId)>0)
		{
			Plants_Darkling_Firepepper.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_FirePepper") as GameObject;
			Plants_Darkling_Firepepper_Info_text.Text = "Darkling Firepepper Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingAvenHerb.objTypeId)>0)
		{
			Plants_Darkling_Aven.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_Aven") as GameObject;
			Plants_Darkling_Aven_Info_text.Text = "Darkling Aven Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingBlackberry.objTypeId)>0)
		{
			Plants_Darkling_Blackberry.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_BlackBerry") as GameObject;
			Plants_Darkling_Blackberry_Info_text.Text = "Darkling Blackberry Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingColumbine.objTypeId)>0)
		{
			Plants_Darkling_Columbine.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_Columbine") as GameObject;
			Plants_Darkling_Columbine_Info_text.Text = "Darkling Columbine Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingMoonFlower.objTypeId)>0)
		{
			Plants_Darkling_MoonFlower.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_MoonFlower") as GameObject;
			Plants_Darkling_MoonFlower_Info_text.Text = "Darkling MoonFlower Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingBitterbush.objTypeId)>0)
		{
			Plants_Darkling_BitterBrush.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_BitterBrush") as GameObject;
			Plants_Darkling_BitterBrush_Info_text.Text = "Darkling BitterBrush Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingHerbBogbean.objTypeId)>0)
		{
			Plants_Darkling_BogBean.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_BogBean") as GameObject;
			Plants_Darkling_BogBean_Info_text.Text = "Darkling BogBean Plant";
		}
		
		if(Scr_userLoad.ReturnHerbandPlantsCount(Scr_gameObj.objDarklingHerbWolfbane.objTypeId)>0)
		{
			Plants_Darkling_WolfsBane.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_WolfsBane") as GameObject;
			Plants_Darkling_WolfsBane_Info_text.Text = "Darkling WolfsBane Plant";
		}
		
		if(MulesEar != null)
		{
			Plants_Darkling_MulesEar.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[9] = GameObject.Find("Container_list10_MulesEar") as GameObject;
			Plants_Darkling_MulesEar_Info_text.Text = "Darkling MulesEar Plant";
		}
		
		if(Truffle != null)
		{
			Plants_Darkling_Truffle.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[10] = GameObject.Find("Container_list11_Truffle") as GameObject;
			Plants_Darkling_Truffle_Info_text.Text = "Darkling Truffle Plant";
		}
		
		if(LentLily != null)
		{
			Plants_Darkling_LentLily.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[11] = GameObject.Find("Container_list12_LentLily") as GameObject;
			Plants_Darkling_LentLily_Info_text.Text = "Darkling LentLily Plant";
		}
		
		if(BitingStoneCrop != null)
		{
			Plants_Darkling_BitingStoneCrop.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[12] = GameObject.Find("Container_list13_BitingStonecrop") as GameObject;
			Plants_Darkling_BitingStoneCrop_Info_text.Text = "Darkling BitingStoneCrop Plant";
		}
		
		if(Fleabane != null)
		{
			Plants_Darkling_Fleabane.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[13] = GameObject.Find("Container_list14_Fleabane") as GameObject;
			Plants_Darkling_Fleabane_Info_text.Text = "Darkling Fleabane Plant";
		}
		
		if(BloodRajah != null)
		{
			Plants_Darkling_BloodRajah.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[14] = GameObject.Find("Container_list15_BloodRajah") as GameObject;
			Plants_Darkling_BloodRajah_Info_text.Text = "Darkling BloodRajah Plant";
		}
		
		if(RavenSwing != null)
		{
			Plants_Darkling_RavenSwing.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[15] = GameObject.Find("Container_list16_RavenSwing") as GameObject;
			Plants_Darkling_RavenSwing_Info_text.Text = "Darkling RavenSwing Plant";
		}
		
		if(Mushroom != null)
		{
			Plants_Darkling_Mushroom.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[16] = GameObject.Find("Container_list17_Mushroom") as GameObject;
			Plants_Darkling_Mushroom_Info_text.Text = "Darkling Mushroom Plant";
		}
		
		if(GasPlant != null)
		{
			Plants_Darkling_GasPlant.SetActiveRecursively(true);
			PlantsDarklingInvScrollListInfo.sceneItems[17] = GameObject.Find("Container_list18_GasPlant") as GameObject;
			Plants_Darkling_GasPlant_Info_text.Text = "Darkling GasPlant Plant";
		}
	}
	
	void PotionsHalfScrollEntry()
	{
		int activeListItems = 0;
		GameObject PoppySnap 	= GameObject.Find("") as GameObject;
		GameObject BitterRoot 	= GameObject.Find("") as GameObject;
		GameObject VetchSpray 	= GameObject.Find("") as GameObject;
		GameObject BoggleHorn 	= GameObject.Find("") as GameObject;
		GameObject MossSalve 	= GameObject.Find("") as GameObject;
		GameObject Seawhip 		= GameObject.Find("") as GameObject;
		GameObject WolfTongue 	= GameObject.Find("") as GameObject;
		GameObject GrubSprout 	= GameObject.Find("") as GameObject;
		GameObject DwaleBile 	= GameObject.Find("") as GameObject;
		
		for(int i=0;i<bgmScript.potDic.Count;i++)
		{
			
			activeListItems = bgmScript.potDic[i];
			
			//Debug.Log("Activating Potion "+activeListItems);
		
		
		switch(activeListItems)
		{
			
		case 402:
		
			
			Potions_Halfling_PoppySnap.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_PoooySnap") as GameObject;
			Potions_Halfling_PoppySnap_Info_text.Text = "Halfling PoppySnap Potion";
			Potions_Halfling_PoppySnap_Cnt_text.Text = "1";
		
			break;
		
		case 404:
		
			Potions_Halfling_BitterRoot.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_BitterRoot") as GameObject;
			Potions_Halfling_BitterRoot_Info_text.Text = "Halfling BitterRoot Potion";
			Potions_Halfling_BitterRoot_Cnt_text.Text = "1";
		
			break;
		
		case 406:
		
			Potions_Halfling_VetchSpray.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_VetchSpray") as GameObject;
			Potions_Halfling_VetchSpray_Info_text.Text = "Halfling VetchSpray Potion";
			Potions_Halfling_VetchSpray_Cnt_text.Text = "1";
		
			break;
		
		case 407:
		
			Potions_Halfling_BoggleHorn.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_BoggleHorn") as GameObject;
			Potions_Halfling_BoggleHorn_Info_text.Text = "Halfling BoggleHorn Potion";
			Potions_Halfling_BoggleHorn_Cnt_text.Text = "1";
		
			break;
		
		case 409:
		
			Potions_Halfling_MossSalve.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_MossSalve") as GameObject;
			Potions_Halfling_MossSalve_Info_text.Text = "Halfling MossSalve Potion";
			Potions_Halfling_MossSalve_Cnt_text.Text = "1";
		
			break;
		
		case 410:
		
			Potions_Halfling_Seawhip.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_Seawhip") as GameObject;
			Potions_Halfling_Seawhip_Info_text.Text = "Halfling Seawhip Potion";
			Potions_Halfling_Seawhip_Cnt_text.Text = "1";
		
			break;
		
		case 413:
			
			Potions_Halfling_WolfTongue.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_WolfTongue") as GameObject;
			Potions_Halfling_WolfTongue_Info_text.Text = "Halfling WolfTongue Potion";
			Potions_Halfling_WolfTongue_Cnt_text.Text = "1";
		
			break;
		
		case 414:
		
			Potions_Halfling_GrubSprout.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_GrubSprout") as GameObject;
			Potions_Halfling_GrubSprout_Info_text.Text = "Halfling GrubSprout Potion";
			Potions_Halfling_GrubSprout_Cnt_text.Text = "1";
		
			break;
		
		case 415:
		
			Potions_Halfling_DwaleBile.SetActiveRecursively(true);
			PotionsHalflingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_DwaleBile") as GameObject;
			Potions_Halfling_DwaleBile_Info_text.Text = "Halfling DwaleBile Potion";
			Potions_Halfling_DwaleBile_Cnt_text.Text = "1";
		
			break;
			
		}
			
		}
	}
	
	void PotionsDarkScrollEntry()
	{
		int activeListItems = 0;
		
		GameObject SlugTonic 		= GameObject.Find("") as GameObject;
		GameObject FeverPitch 		= GameObject.Find("") as GameObject;
		GameObject MorrowDraught 	= GameObject.Find("") as GameObject;
		GameObject MonkBlood 		= GameObject.Find("") as GameObject;
		GameObject ScorchElixir 	= GameObject.Find("") as GameObject;
		GameObject SpleenBite 		= GameObject.Find("") as GameObject;
		GameObject Necrobane 		= GameObject.Find("") as GameObject;
		GameObject DevilIchor 		= GameObject.Find("") as GameObject;
		GameObject StunkMange 		= GameObject.Find("") as GameObject;
		
		for(int i=0;i<bgmScript.potDic.Count;i++)
		{
			
			activeListItems = bgmScript.potDic[i];
			//Debug.Log("Activating Potion "+activeListItems);
		
		switch(activeListItems)
		{
		
		case 401:
		
			Potions_Darkling_SlugTonic.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_Slugtonic") as GameObject;
			Potions_Darkling_SlugTonic_Info_text.Text = "Darkling SlugTonic Potion";
			Potions_Darkling_SlugTonic_Cnt_text.Text = "1";
		
			break;
		
		case 403:
		
			Potions_Darkling_FeverPitch.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_FeverPitch") as GameObject;
			Potions_Darkling_FeverPitch_Info_text.Text = "Darkling FeverPitch Potion";
			Potions_Darkling_FeverPitch_Cnt_text.Text = "1";
		
			break;
		
		case 405:
		
			Potions_Darkling_MorrowDraught.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_MorrowDraught") as GameObject;
			Potions_Darkling_MorrowDraught_Info_text.Text = "Darkling MorrowDraught Potion";
			Potions_Darkling_MorrowDraught_Cnt_text.Text = "1";
		
			break;
		
		case 411:
		
			Potions_Darkling_MonkBlood.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_MonkBlood") as GameObject;
			Potions_Darkling_MonkBlood_Info_text.Text = "Darkling MonkBlood Potion";
			Potions_Darkling_MonkBlood_Cnt_text.Text = "1";
		
			break;
		
		case 412:
		
			Potions_Darkling_ScorchElixir.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_ScorchElixir") as GameObject;
			Potions_Darkling_ScorchElixir_Info_text.Text = "Darkling ScorchElixir Potion";
			Potions_Darkling_ScorchElixir_Cnt_text.Text = "1";
		
			break;
		
		case 408:
		
			Potions_Darkling_SpleenBite.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_SpleenBite") as GameObject;
			Potions_Darkling_SpleenBite_Info_text.Text = "Darkling SpleenBite Potion";
			Potions_Darkling_SpleenBite_Cnt_text.Text = "1";
		
			break;
		
		case 416:
		
			Potions_Darkling_Necrobane.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_Necrobane") as GameObject;
			Potions_Darkling_Necrobane_Info_text.Text = "Darkling Necrobane Potion";
			Potions_Darkling_Necrobane_Cnt_text.Text = "1";
		
			break;
		
		case 417:
		
			Potions_Darkling_DevilIchor.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_DevilIchor") as GameObject;
			Potions_Darkling_DevilIchor_Info_text.Text = "Darkling DevilIchor Potion";
			Potions_Darkling_DevilIchor_Cnt_text.Text = "1";
		
			break;
		
		case 418:
		
			Potions_Darkling_StunkMange.SetActiveRecursively(true);
			PotionsDarklingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_StunkMange") as GameObject;
			Potions_Darkling_StunkMange_Info_text.Text = "Darkling StunkMange Potion";
			Potions_Darkling_StunkMange_Cnt_text.Text = "1";
		
			break;
			}
		}
	}
	
	
	void RewardHalfScrollEntry()
	{
		if(svr_reward.bloodstoneTrinket())
		{
			Reward_Halfling_BloodStoneTrinket.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_bloodstoneTrinket") as GameObject;
			Reward_Halfling_BloodStoneTrinket_Info_text.Text = "Morphed Hound To Barg Creature";
			Reward_Halfling_BloodStoneTrinket_Cnt_text.Text = "1";
		}
		if(svr_reward.bloodstoneMedallion())
		{
			Reward_Halfling_BloodStoneMedallion.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_bloodstoneMedallion") as GameObject;
			Reward_Halfling_BloodStoneMedallion_Info_text.Text = "Feeded Barg To L5";
			Reward_Halfling_BloodStoneMedallion_Cnt_text.Text = "2";
		}
		if(svr_reward.bloodstoneAmulet())
		{
			Reward_Halfling_BloodStoneAmulet.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_bloodstoneAmulet") as GameObject;
			Reward_Halfling_BloodStoneAmulet_Info_text.Text = "Placed One Cusith Creature On Earth TG";
			Reward_Halfling_BloodStoneAmulet_Cnt_text.Text = "3";
		}
		if(svr_reward.emeraldTrinket())
		{
			Reward_Halfling_EmeraldTrinket.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_emeraldTrinket") as GameObject;
			Reward_Halfling_EmeraldTrinket_Info_text.Text = "Reached Level 5";
			Reward_Halfling_EmeraldTrinket_Cnt_text.Text = "3";
		}
		if(PlayerPrefs.GetInt("wonfight") >=10)
		{
			Reward_Halfling_EmeraldMedallion.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_emeraldMedallion") as GameObject;
			Reward_Halfling_EmeraldMedallion_Info_text.Text = "Won 10 Fights";
			Reward_Halfling_EmeraldMedallion_Cnt_text.Text = "4";
		}
		if(svr_reward.emeraldAmulet())
		{
			Reward_Halfling_EmeraldAmulet.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_emeraldAmulet") as GameObject;
			Reward_Halfling_EmeraldAmulet_Info_text.Text = "Mixed 5 Correct Potions";
			Reward_Halfling_EmeraldAmulet_Cnt_text.Text = "5";
		}
		if(svr_reward.sapphireTrinket())
		{
			Reward_Halfling_SapphireTrinket.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_sapphireTrinket") as GameObject;
			Reward_Halfling_SapphireTrinket_Info_text.Text = "Upgraded Nix to Draug";
			Reward_Halfling_SapphireTrinket_Cnt_text.Text = "5";
		}
		if(svr_reward.sapphireMedallion())
		{
			Reward_Halfling_SapphireMedallion.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_sapphireMedallion") as GameObject;
			Reward_Halfling_SapphireMedallion_Info_text.Text = "Feeded Dagon To L10";
			Reward_Halfling_SapphireMedallion_Cnt_text.Text = "6";
		}
		if(svr_reward.sapphireAmulet())
		{
			Reward_Halfling_SapphireAmulet.SetActiveRecursively(true);
			RewardHalflingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_sapphireAmulet") as GameObject;
			Reward_Halfling_SapphireAmulet_Info_text.Text = "Had 6 Creatures On Halfling TG`s";
			Reward_Halfling_SapphireAmulet_Cnt_text.Text = "7";
		}
	}
	
	void RewardDarkScrollEntry()
	{
		if(svr_reward.amethystTrinket())
		{
			Reward_Darkling_AmethystTrinket.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[0] = GameObject.Find("Container_list1_amethystTrinket") as GameObject;
			Reward_Darkling_AmethystTrinket_Info_text.Text = "Purchased Darkling Side Map";
			Reward_Darkling_AmethystTrinket_Cnt_text.Text = "1";
		}
		if(svr_reward.amethystMedallion())
		{
			Reward_Darkling_AmethystMedallion.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[1] = GameObject.Find("Container_list2_amethystMedallion") as GameObject;
			Reward_Darkling_AmethystMedallion_Info_text.Text = "Cleared 2 Enemy Caves On Darkling Side";
			Reward_Darkling_AmethystMedallion_Cnt_text.Text = "2";
		}
		if(svr_reward.amethystAmulet())
		{
			Reward_Darkling_AmethystAmulet.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[2] = GameObject.Find("Container_list3_amethystAmulet") as GameObject;
			Reward_Darkling_AmethystAmulet_Info_text.Text = "Grown 20 Pumpkins On Darkling Side";
			Reward_Darkling_AmethystAmulet_Cnt_text.Text = "3";
		}
		if(svr_reward.rubyTrinket())
		{
			Reward_Darkling_RubyTrinket.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[3] = GameObject.Find("Container_list4_rubyTrinket") as GameObject;
			Reward_Darkling_RubyTrinket_Info_text.Text = "Feeded Djinn To L10";
			Reward_Darkling_RubyTrinket_Cnt_text.Text = "3";
		}
		if(svr_reward.rubyMedallion())
		{
			Reward_Darkling_RubyMedallion.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[4] = GameObject.Find("Container_list5_rubyMedallion") as GameObject;
			Reward_Darkling_RubyMedallion_Info_text.Text = "Morphed Imp To Djinn Creature";
			Reward_Darkling_RubyMedallion_Cnt_text.Text = "4";
		}
		if(svr_reward.rubyYamlet())
		{
			Reward_Darkling_RubyAmulet.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[5] = GameObject.Find("Container_list6_rubyAmulet") as GameObject;
			Reward_Darkling_RubyAmulet_Info_text.Text = "Completed Quest 6";
			Reward_Darkling_RubyAmulet_Cnt_text.Text = "5";
		}
		if(svr_reward.onynxTrinket())
		{
			Reward_Darkling_OnyxTrinket.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[6] = GameObject.Find("Container_list7_onyxTrinket") as GameObject;
			Reward_Darkling_OnyxTrinket_Info_text.Text = "Had F03 & P03 Rewards";
			Reward_Darkling_OnyxTrinket_Cnt_text.Text = "5";
		}
		if(svr_reward.onynxMedallion())
		{
			Reward_Darkling_OnyxMedallion.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[7] = GameObject.Find("Container_list8_onyxMedallion") as GameObject;
			Reward_Darkling_OnyxMedallion_Info_text.Text = "Completed Quest 12";
			Reward_Darkling_OnyxMedallion_Cnt_text.Text = "6";
		}
		if(svr_reward.onynxAmulet())
		{
			Reward_Darkling_OnyxAmulet.SetActiveRecursively(true);
			RewardDarklingInvScrollListInfo.sceneItems[8] = GameObject.Find("Container_list9_onyxAmulet") as GameObject;
			Reward_Darkling_OnyxAmulet_Info_text.Text = "Had 6 Creatures On Darkling TG`s";
			Reward_Darkling_OnyxAmulet_Cnt_text.Text = "7";
		}
	}
	
	void CreatureHalfScrollClose()
	{
		GameObject CreatureHalflingParent = GameObject.Find("Creature_halfling_inventory") as GameObject;
			
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerHound 	= mover.transform.FindChild("Container_list1_hound") 	as Transform;
		Transform ContainerBarg 	= mover.transform.FindChild("Container_list2_Barg") 	as Transform;
		Transform ContainerCusith 	= mover.transform.FindChild("Container_list3_Cusith") as Transform;
		Transform ContainerSprout 	= mover.transform.FindChild("Container_list4_Sprout") as Transform;
		Transform ContainerNumph 	= mover.transform.FindChild("Container_list5_Nymph") 	as Transform;
		Transform ContainerDryad 	= mover.transform.FindChild("Container_list6_Dryad") 	as Transform;
		Transform ContainerNix 		= mover.transform.FindChild("Container_list7_Nix") 	as Transform;
		Transform ContainerDraug 	= mover.transform.FindChild("Container_list8_Draug") 	as Transform;
		Transform ContainerDragon 	= mover.transform.FindChild("Container_list9_Dragon") as Transform;
		
		if(ContainerHound != null)
		{
			ContainerHound.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerBarg != null)
		{
			ContainerBarg.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerCusith != null)
		{
			ContainerCusith.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerSprout != null)
		{
			ContainerSprout.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerNumph != null)
		{
			ContainerNumph.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerDryad != null)
		{
			ContainerDryad.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerNix != null)
		{
			ContainerNix.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerDraug != null)
		{
			ContainerDraug.parent = CreatureHalflingParent.transform;
		}
		
		if(ContainerDragon != null)
		{
			ContainerDragon.parent = CreatureHalflingParent.transform;
		}
	}
	
	void CreatureDarkScrollClose()
	{
		GameObject CreatureDarklingParent = GameObject.Find("Creature_Darkling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerLeech 		= mover.transform.FindChild("Container_list1_Leech") 	as Transform;
		Transform ContainerDarkHound 	= mover.transform.FindChild("Container_list2_DarkHound")as Transform;
		Transform ContainerSprite 		= mover.transform.FindChild("Container_list3_Sprite") 	as Transform;
		Transform ContainerLeshy 		= mover.transform.FindChild("Container_list4_Leshy") 	as Transform;
		Transform ContainerFenrir 		= mover.transform.FindChild("Container_list5_Fenrir") 	as Transform;
		Transform ContainerImp 			= mover.transform.FindChild("Container_list6_Imp") 		as Transform;
		Transform ContainerLurker 		= mover.transform.FindChild("Container_list7_Lurker") 	as Transform;
		Transform ContainerHellHound 	= mover.transform.FindChild("Container_list8_HellHound")as Transform;
		Transform ContainerDjinn 		= mover.transform.FindChild("Container_list9_Djinn") 	as Transform;
			
		if(ContainerLeech != null)
		{
			ContainerLeech.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerDarkHound != null)
		{
			ContainerDarkHound.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerSprite != null)
		{
			ContainerSprite.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerLeshy != null)
		{
			ContainerLeshy.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerFenrir != null)
		{
			ContainerFenrir.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerImp != null)
		{
			ContainerImp.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerLurker != null)
		{
			ContainerLurker.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerHellHound != null)
		{
			ContainerHellHound.parent = CreatureDarklingParent.transform;
		}
		
		if(ContainerDjinn != null)
		{
			ContainerDjinn.parent = CreatureDarklingParent.transform;
		}
	}
	
	void PlantsHalfScrollClose()
	{
		GameObject PlantsHalflingParent = GameObject.Find("Plants_Halfling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerPipeweed 			= mover.transform.FindChild("Container_list1_Pipeweed")				as Transform;
		Transform ContainerTurnip 				= mover.transform.FindChild("Container_list2_Turnip")				as Transform;
		Transform ContainerPumpkinHalf 			= mover.transform.FindChild("Container_list3_PumpkinHalf")			as Transform;
		Transform ContainerCostmary 			= mover.transform.FindChild("Container_list4_Costmary")				as Transform;
		Transform ContainerPotato 				= mover.transform.FindChild("Container_list5_Potato")				as Transform;
		Transform ContainerFairyLily 			= mover.transform.FindChild("Container_list6_FairyLily")			as Transform;
		Transform ContainerSunflower 			= mover.transform.FindChild("Container_list7_Sunflower")			as Transform;
		Transform ContainerWaterCress 			= mover.transform.FindChild("Container_list8_WaterCress") 			as Transform;
		Transform ContainerVervain 				= mover.transform.FindChild("Container_list9_Vervain") 				as Transform;
		Transform ContainerMandrake 			= mover.transform.FindChild("Container_list10_Mandrake")			as Transform;
		Transform ContainerLotus 				= mover.transform.FindChild("Container_list11_Lotus")				as Transform;
		Transform ContainerCarrot 				= mover.transform.FindChild("Container_list12_Carrot")				as Transform;
		Transform ContainerBleedingHeart 		= mover.transform.FindChild("Container_list13_BleedingHeart")		as Transform;
		Transform ContainerFoxgloveBeardTongue  = mover.transform.FindChild("Container_list14_FoxgloveBreadtongue")	as Transform;
		Transform ContainerWaterCaltrop 		= mover.transform.FindChild("Container_list15_WaterCaltrop")		as Transform;
		Transform ContainerSoapwart				= mover.transform.FindChild("Container_list16_Soapwart")			as Transform;
		Transform ContainerBloodRoot			= mover.transform.FindChild("Container_list17_BloodRoot") 			as Transform;
		Transform ContainerStrawberry 			= mover.transform.FindChild("Container_list18_StrawBerry")			as Transform;
		Transform ContainerTaro 				= mover.transform.FindChild("Container_list19_Taro")				as Transform;
		
		if(ContainerPipeweed != null)
		{
			ContainerPipeweed.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerTurnip != null)
		{
			ContainerTurnip.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerPumpkinHalf != null)
		{
			ContainerPumpkinHalf.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerCostmary != null)
		{
			ContainerCostmary.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerPotato != null)
		{
			ContainerPotato.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerFairyLily != null)
		{
			ContainerFairyLily.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerSunflower != null)
		{
			ContainerSunflower.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerWaterCress != null)
		{
			ContainerWaterCress.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerVervain != null)
		{
			ContainerVervain.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerMandrake != null)
		{
			ContainerMandrake.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerLotus != null)
		{
			ContainerLotus.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerCarrot != null)
		{
			ContainerCarrot.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerBleedingHeart != null)
		{
			ContainerBleedingHeart.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerFoxgloveBeardTongue != null)
		{
			ContainerFoxgloveBeardTongue.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerWaterCaltrop != null)
		{
			ContainerWaterCaltrop.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerSoapwart != null)
		{
			ContainerSoapwart.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerBloodRoot != null)
		{
			ContainerBloodRoot.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerStrawberry != null)
		{
			ContainerStrawberry.parent = PlantsHalflingParent.transform;
		}
		
		if(ContainerTaro != null)
		{
			ContainerTaro.parent = PlantsHalflingParent.transform;
		}
	}
	
	void PlantsDarkScrollClose()
	{
		GameObject PlantsDarklingParent = GameObject.Find("Plants_Darkling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerPumpkinDark  	= mover.transform.FindChild("Container_list1_Pumpkin") 			as Transform;
		Transform ContainerFirepepper 		= mover.transform.FindChild("Container_list2_FirePepper") 		as Transform;
		Transform ContainerAven 			= mover.transform.FindChild("Container_list3_Aven")				as Transform;
		Transform ContainerBlackberry 		= mover.transform.FindChild("Container_list4_BlackBerry") 		as Transform;
		Transform ContainerColumbine 		= mover.transform.FindChild("Container_list5_Columbine")		as Transform;
		Transform ContainerMoonFlower		= mover.transform.FindChild("Container_list6_MoonFlower") 		as Transform;
		Transform ContainerBitterBrush 		= mover.transform.FindChild("Container_list7_BitterBrush") 		as Transform;
		Transform ContainerBogBean 			= mover.transform.FindChild("Container_list8_BogBean") 			as Transform;
		Transform ContainerWolfsBane 		= mover.transform.FindChild("Container_list9_WolfsBane")		as Transform;
		Transform ContainerMulesEar 		= mover.transform.FindChild("Container_list10_MulesEar")		as Transform;
		Transform ContainerTruffle 			= mover.transform.FindChild("Container_list11_Truffle") 		as Transform;
		Transform ContainerLentLily 		= mover.transform.FindChild("Container_list12_LentLily")		as Transform;
		Transform ContainerBitingStoneCrop  = mover.transform.FindChild("Container_list13_BitingStonecrop")	as Transform;
		Transform ContainerFleabane 		= mover.transform.FindChild("Container_list14_Fleabane") 		as Transform;
		Transform ContainerBloodRajah 		= mover.transform.FindChild("Container_list15_BloodRajah")		as Transform;
		Transform ContainerRavenSwing 		= mover.transform.FindChild("Container_list16_RavenSwing")		as Transform;
		Transform ContainerMushroom 		= mover.transform.FindChild("Container_list17_Mushroom") 		as Transform;
		Transform ContainerGasPlant 		= mover.transform.FindChild("Container_list18_GasPlant")		as Transform;
		
		if(ContainerPumpkinDark != null)
		{
			ContainerPumpkinDark.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerFirepepper != null)
		{
			ContainerFirepepper.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerAven != null)
		{
			ContainerAven.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerBlackberry != null)
		{
			ContainerBlackberry.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerColumbine != null)
		{
			ContainerColumbine.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerMoonFlower != null)
		{
			ContainerMoonFlower.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerBitterBrush != null)
		{
			ContainerBitterBrush.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerBogBean != null)
		{
			ContainerBogBean.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerWolfsBane != null)
		{
			ContainerWolfsBane.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerMulesEar != null)
		{
			ContainerMulesEar.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerTruffle != null)
		{
			ContainerTruffle.parent = PlantsDarklingParent.transform;
		}
		if(ContainerLentLily != null)
		{
			ContainerLentLily.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerBitingStoneCrop != null)
		{
			ContainerBitingStoneCrop.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerFleabane != null)
		{
			ContainerFleabane.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerBloodRajah != null)
		{
			ContainerBloodRajah.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerRavenSwing != null)
		{
			ContainerRavenSwing.parent = PlantsDarklingParent.transform;
		}
		
		if(ContainerMushroom != null)
		{
			ContainerMushroom.parent = PlantsDarklingParent.transform;
	}
	
		if(ContainerGasPlant != null)
		{
			ContainerGasPlant.parent = PlantsDarklingParent.transform;
		}
	}
	
	void PotionsHalfScrollClose()
	{
		GameObject PotionsHalflingParent = GameObject.Find("Potions_Halfling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerPoppySnap 	= mover.transform.FindChild("Container_list1_PoooySnap")	as Transform;
		Transform ContainerBitterRoot 	= mover.transform.FindChild("Container_list2_BitterRoot") 	as Transform;
		Transform ContainerVetchSpray 	= mover.transform.FindChild("Container_list3_VetchSpray") 	as Transform; 
		Transform ContainerBoggleHorn 	= mover.transform.FindChild("Container_list4_BoggleHorn") 	as Transform;
		Transform ContainerMossSalve 	= mover.transform.FindChild("Container_list5_MossSalve") 	as Transform;
		Transform ContainerSeawhip 		= mover.transform.FindChild("Container_list6_Seawhip") 		as Transform;
		Transform ContainerWolfTongue 	= mover.transform.FindChild("Container_list7_WolfTongue") 	as Transform; 
		Transform ContainerGrubSprout 	= mover.transform.FindChild("Container_list8_GrubSprout") 	as Transform;
		Transform ContainerDwaleBile 	= mover.transform.FindChild("Container_list9_DwaleBile") 	as Transform;
		
		if(ContainerPoppySnap != null)
		{
			ContainerPoppySnap.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerBitterRoot != null)
		{
			ContainerBitterRoot.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerVetchSpray != null)
		{
			ContainerVetchSpray.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerBoggleHorn != null)
		{
			ContainerBoggleHorn.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerMossSalve != null)
		{
			ContainerMossSalve.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerSeawhip != null)
		{
			ContainerSeawhip.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerWolfTongue != null)
		{
			ContainerWolfTongue.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerGrubSprout != null)
		{
			ContainerGrubSprout.parent = PotionsHalflingParent.transform;
		}
		
		if(ContainerDwaleBile != null)
		{
			ContainerDwaleBile.parent = PotionsHalflingParent.transform;
		}
	}
	
	void PotionsDarkScrollClose()
	{
		GameObject PotionsDarklingParent = GameObject.Find("Potions_Darkling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerSlugTonic 		= mover.transform.FindChild("Container_list1_Slugtonic") 	as Transform;
		Transform ContainerFeverPitch 		= mover.transform.FindChild("Container_list2_FeverPitch") 	as Transform;
		Transform ContainerMorrowDraught 	= mover.transform.FindChild("Container_list3_MorrowDraught")as Transform; 
		Transform ContainerMonkBlood 		= mover.transform.FindChild("Container_list4_MonkBlood") 	as Transform;
		Transform ContainerScorchElixir 	= mover.transform.FindChild("Container_list5_ScorchElixir") as Transform;
		Transform ContainerSpleenBite 		= mover.transform.FindChild("Container_list6_SpleenBite") 	as Transform;
		Transform ContainerNecrobane 		= mover.transform.FindChild("Container_list7_Necrobane") 	as Transform;
		Transform ContainerDevilIchor 		= mover.transform.FindChild("Container_list8_DevilIchor") 	as Transform;
		Transform ContainerStunkMange 		= mover.transform.FindChild("Container_list9_StunkMange") 	as Transform;
		
		if(ContainerSlugTonic != null)
		{
			ContainerSlugTonic.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerFeverPitch != null)
		{
			ContainerFeverPitch.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerMorrowDraught != null)
		{
			ContainerMorrowDraught.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerMonkBlood != null)
		{
			ContainerMonkBlood.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerScorchElixir != null)
		{
			ContainerScorchElixir.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerSpleenBite != null)
		{
			ContainerSpleenBite.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerNecrobane != null)
		{
			ContainerNecrobane.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerDevilIchor != null)
		{
			ContainerDevilIchor.parent = PotionsDarklingParent.transform;
		}
		
		if(ContainerStunkMange != null)
		{
			ContainerStunkMange.parent = PotionsDarklingParent.transform;
		}
	}

	void RewardHalfScrollClose()
	{
		GameObject RewardHalflingParent = GameObject.Find("Rewards_Halfling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerBloodStoneTrinket 	= mover.transform.FindChild("Container_list1_bloodstoneTrinket")	as Transform;
		Transform ContainerBloodStoneMedallion 	= mover.transform.FindChild("Container_list2_bloodstoneMedallion") 	as Transform;
		Transform ContainerBloodStoneAmulet 	= mover.transform.FindChild("Container_list3_bloodstoneAmulet") 	as Transform; 
		Transform ContainerEmeraldTrinket 		= mover.transform.FindChild("Container_list4_emeraldTrinket") 		as Transform;
		Transform ContainerEmeraldMedallion 	= mover.transform.FindChild("Container_list5_emeraldMedallion") 	as Transform;
		Transform ContainerEmeraldAmulet 		= mover.transform.FindChild("Container_list6_emeraldAmulet") 		as Transform;
		Transform ContainerSapphireTrinket 		= mover.transform.FindChild("Container_list7_sapphireTrinket") 		as Transform; 
		Transform ContainerSapphireMedallion 	= mover.transform.FindChild("Container_list8_sapphireMedallion") 	as Transform;
		Transform ContainerSapphireAmulet 		= mover.transform.FindChild("Container_list9_sapphireAmulet") 		as Transform;
		
		if(ContainerBloodStoneTrinket != null)
		{
			ContainerBloodStoneTrinket.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerBloodStoneMedallion != null)
		{
			ContainerBloodStoneMedallion.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerBloodStoneAmulet != null)
		{
			ContainerBloodStoneAmulet.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerEmeraldTrinket != null)
		{
			ContainerEmeraldTrinket.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerEmeraldMedallion != null)
		{
			ContainerEmeraldMedallion.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerEmeraldAmulet != null)
		{
			ContainerEmeraldAmulet.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerSapphireTrinket != null)
		{
			ContainerSapphireTrinket.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerSapphireMedallion != null)
		{
			ContainerSapphireMedallion.parent = RewardHalflingParent.transform;
		}
		
		if(ContainerSapphireAmulet != null)
		{
			ContainerSapphireAmulet.parent = RewardHalflingParent.transform;
		}
	}
	
	void RewardDarkScrollClose()
	{
		GameObject RewardDarklingParent = GameObject.Find("Rewards_Darkling_inventory") as GameObject;
		
		GameObject mover = GameObject.Find("Mover") as GameObject;
		
		Transform ContainerAmethystTrinket 	= mover.transform.FindChild("Container_list1_amethystTrinket") 	as Transform;
		Transform ContainerAmethystMedallion= mover.transform.FindChild("Container_list2_amethystMedallion")as Transform;
		Transform ContainerAmethystAmulet 	= mover.transform.FindChild("Container_list3_amethystAmulet")	as Transform; 
		Transform ContainerRubyTrinket 		= mover.transform.FindChild("Container_list4_rubyTrinket") 		as Transform;
		Transform ContainerRubyMedallion 	= mover.transform.FindChild("Container_list5_rubyMedallion") 	as Transform;
		Transform ContainerRubyAmulet 		= mover.transform.FindChild("Container_list6_rubyAmulet") 		as Transform;
		Transform ContainerOnyxTrinket 		= mover.transform.FindChild("Container_list7_onyxTrinket") 		as Transform;
		Transform ContainerOnyxMedallion 	= mover.transform.FindChild("Container_list8_onyxMedallion") 	as Transform;
		Transform ContainerOnyxAmulet 		= mover.transform.FindChild("Container_list9_onyxAmulet") 		as Transform;
		
		if(ContainerAmethystTrinket != null)
		{
			ContainerAmethystTrinket.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerAmethystMedallion != null)
		{
			ContainerAmethystMedallion.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerAmethystAmulet != null)
		{
			ContainerAmethystAmulet.parent = RewardDarklingParent.transform; 
		}
		
		if(ContainerRubyTrinket != null)
		{
			ContainerRubyTrinket.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerRubyMedallion != null)
		{
			ContainerRubyMedallion.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerRubyAmulet != null)
		{
			ContainerRubyAmulet.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerOnyxTrinket != null)
		{
			ContainerOnyxTrinket.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerOnyxMedallion != null)
		{
			ContainerOnyxMedallion.parent = RewardDarklingParent.transform;
		}
		
		if(ContainerOnyxAmulet != null)
		{
			ContainerOnyxAmulet.parent = RewardDarklingParent.transform;
		}
	}
//===============================================================================================================	
	
	// inventory hound button
	void invHoundButton()
	{
		if (GameManager.battleActiveBool == false)
		{
			GameObject gCav = GameObject.Find("HC_B_GoblinCamp_GO(Clone)_01") as GameObject;
		
			/*if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_01")
			{*/
			if (gCav != null && GameManager.gameLevel < 3)
			{
				if (GameManager.taskCount == 11)
				{
					popUpInfoScript.task4(2);
					inventoryClose();
				}
			}
			
			if (GameManager.gameLevel > 3)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					//GameManager.curCave.name == 
					// hound attack on cave
					GameManager.currentCreature = GameObject.Find("HC_C_Hound_GO(Clone)") as GameObject;
					//popUpInfoScript.DestroyCave();	
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
		}
		else
			SendCreatureImageInfo(gosScript.objHound.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory sprout button
	void invSproutButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Sprout_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		
		SendCreatureImageInfo(gosScript.objSprout.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory barg button
	void invBargButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Barg_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		
		SendCreatureImageInfo(gosScript.objBarg.objTypeId);
		
		inventoryClose();
	}

//===============================================================================================================	
	
	// inventory nix button
	void invNixButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Nix_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
			
		SendCreatureImageInfo(gosScript.objNix.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory nymph button
	void invNymphButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Nymph_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		
		SendCreatureImageInfo(gosScript.objNymph.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory draug button
	void invDraugButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Draug_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDraug.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory cusith button
	void invCusithButton()
	{
		if (GameManager.readyAttackBool & !GameManager.battleActiveBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Cusith_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_TrainingGround_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objCusith.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory dryad button
	void invDryadButton()
	{
		if (GameManager.readyAttackBool) 
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Dryad_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Plant_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		
		////Debug.Log(gosScript.objHalflingDryad.objTypeId);
		
		SendCreatureImageInfo(gosScript.objDryad.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory dragon button
	void invDragonButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "HC_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_01" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_02" || GameManager.curCave.name == "HC_B_OrgCave_GO(Clone)_03" ||
					GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_02" || GameManager.curCave.name == "HC_B_TrollHouse_GO(Clone)_03")
				{
					GameManager.currentCreature = GameObject.Find("HC_C_Dragon_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("HC_TG_Water_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDragon.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	// inventory Leech button
	void invLeechButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Leech_GO(Clone)") as GameObject;
					GameManager.currentSelectedObject = GameManager.curCave;
					GameManager.curTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objLeech.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	void invDHoundButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_DHound_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklinghound.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invSpriteButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Sprite_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingSprite.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invLeshyButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01")
			{
				if (GameManager.gameLevel >= 5 && GameManager.leshy_lvl >= 1)
				{
					if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
					{
						GameManager.currentCreature = GameObject.Find("DL_C_Leshy_GO(Clone)") as GameObject;
						GameManager.curTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
						popUpInfoScript.taskGoblinCave(3);
						//inventoryClose();
					}
					else
					{
						popUpInfoScript.defaultPopUpBool = true;
						popUpInfoScript.defaultPopUp(44, 0);
					}
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(45, 0);
				}
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingLeshy.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invFenrirButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Fenrir_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingFenrir.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invImpButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Imp_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingImp.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invLurkerButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Lurker_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Swamp_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingLurker.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invHellHoundButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_HellHound_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Earth_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
					//inventoryClose();
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingHellhound.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================		
	
	void invDjinnButton()
	{
		if (GameManager.readyAttackBool)
		{
			if (GameManager.gameLevel >= 4)
			{
				if (GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_01" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_02" || GameManager.curCave.name == "DL_B_GoblinCamp_GO(Clone)_03" ||
					GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_01" || GameManager.curCave.name == "DL_B_TrollHouse_GO(Clone)_02")
				{
					GameManager.currentCreature = GameObject.Find("DL_C_Djinn_GO(Clone)") as GameObject;
					GameManager.curTG = GameObject.Find("DL_TG_Fire_GO(Clone)") as GameObject;
					popUpInfoScript.taskGoblinCave(3);
				}
				else
				{
					popUpInfoScript.defaultPopUpBool = true;
					popUpInfoScript.defaultPopUp(44, 0);
				}
			}
			else
			{
				popUpInfoScript.defaultPopUpBool = true;
				popUpInfoScript.defaultPopUp(45, 0);
			}
		}
		SendCreatureImageInfo(gosScript.objDarklingDjInn.objTypeId);
		
		inventoryClose();
	}
	
//===============================================================================================================	
	
	
	public void closeMainMenu()
	{
		
		inventoryui.SetActiveRecursively(false);
	}
	
	
	public void inventoryClose()
	{
		popUpInfoScript.wall.active = false;
		//buttonPulse invcancledemo = GameObject.Find("inventoryCancleButt").GetComponent("buttonPulse") as buttonPulse;
		
		invCreatureBasePlate.SetActiveRecursively(false);
		invPlantsBasePlate.SetActiveRecursively(false);
		invPotionsBasePlate.SetActiveRecursively(false);
		invRewardBasePlate.SetActiveRecursively(false);
		
		if(CHbool == true)
		{
///***			Debug.Log("stuck here 02 <-----");
			CreatureHalfScrollClose();
			
			Destroy(GameObject.Find("Creature_halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(CreatureHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			CHbool = false;
		}
		
		if(CDbool == true)
		{
			CreatureDarkScrollClose();
			Destroy(GameObject.Find("Creature_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(CreatureDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
			CDbool = false;
		}
		
		if(PHbool == true)
		{
			PlantsHalfScrollClose();
			Destroy(GameObject.Find("Plants_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PlantsHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			PHbool = false;
		}
		
		if(PDbool == true)
		{
			PlantsDarkScrollClose();
			Destroy(GameObject.Find("Plants_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PlantsDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
			PDbool = false;
		}
		
		if(PoHbool == true)
		{
			PotionsHalfScrollClose();
			Destroy(GameObject.Find("Potions_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PotionsHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			PoHbool = false;
		}
		
		if(PoDbool == true)
		{
			PotionsDarkScrollClose();
			Destroy(GameObject.Find("Potions_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(PotionsDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
			PoDbool = false;
		}
		
		if(RHbool == true)
		{
			RewardHalfScrollClose();
			Destroy(GameObject.Find("Rewards_Halfling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(RewardHalflingInvScrollList.gameObject.GetComponent<UIScrollList>());
			RHbool = false;
		}
		
		if(RDbool == true)
		{
			RewardDarkScrollClose();
			Destroy(GameObject.Find("Rewards_Darkling_ScrollList").transform.FindChild("Mover").gameObject);
			Destroy(RewardDarklingInvScrollList.gameObject.GetComponent<UIScrollList>());
			RDbool = false;
		}
		
		CreatureHalflingInvScrollList.SetActiveRecursively(false);
		CreatureDarklingInvScrollList.SetActiveRecursively(false);
		
		Creature_Halfling_Hound.SetActiveRecursively(false);
		Creature_Halfling_Barg.SetActiveRecursively(false);
		Creature_Halfling_Cusith.SetActiveRecursively(false);
		Creature_Halfling_Sprout.SetActiveRecursively(false);
		Creature_Halfling_Nymph.SetActiveRecursively(false);
		Creature_Halfling_Dryad.SetActiveRecursively(false);
		Creature_Halfling_Nix.SetActiveRecursively(false);
		Creature_Halfling_Draug.SetActiveRecursively(false);
		Creature_Halfling_Dragon.SetActiveRecursively(false);
		
		Creature_Darkling_Leech.SetActiveRecursively(false);
		Creature_Darkling_DarkHound.SetActiveRecursively(false);
		Creature_Darkling_Sprite.SetActiveRecursively(false);
		Creature_Darkling_Leshy.SetActiveRecursively(false);
		Creature_Darkling_Fenrir.SetActiveRecursively(false);
		Creature_Darkling_Imp.SetActiveRecursively(false);
		Creature_Darkling_Lurker.SetActiveRecursively(false);
		Creature_Darkling_HellHound.SetActiveRecursively(false);
		Creature_Darkling_Djinn.SetActiveRecursively(false);
		
		Plants_Darkling_Aven.SetActiveRecursively(false);
		Plants_Darkling_Columbine.SetActiveRecursively(false);
		Plants_Darkling_MoonFlower.SetActiveRecursively(false);
		Plants_Darkling_BitterBrush.SetActiveRecursively(false);
		Plants_Darkling_BogBean.SetActiveRecursively(false);
		Plants_Darkling_WolfsBane.SetActiveRecursively(false);
		Plants_Darkling_MulesEar.SetActiveRecursively(false);
		Plants_Darkling_LentLily.SetActiveRecursively(false);
		Plants_Darkling_BitingStoneCrop.SetActiveRecursively(false);
		Plants_Darkling_Fleabane.SetActiveRecursively(false);
		Plants_Darkling_BloodRajah.SetActiveRecursively(false);
		Plants_Darkling_RavenSwing.SetActiveRecursively(false);
		Plants_Darkling_GasPlant.SetActiveRecursively(false);
		
		Plants_Halfling_Pipeweed.SetActiveRecursively(false);
		Plants_Halfling_Costmary.SetActiveRecursively(false);
		Plants_Halfling_FairyLily.SetActiveRecursively(false);
		Plants_Halfling_Sunflower.SetActiveRecursively(false);
		Plants_Halfling_WaterCress.SetActiveRecursively(false);
		Plants_Halfling_Vervain.SetActiveRecursively(false);
		Plants_Halfling_Mandrake.SetActiveRecursively(false);
		Plants_Halfling_Lotus.SetActiveRecursively(false);
		Plants_Halfling_BleedingHeart.SetActiveRecursively(false);
		Plants_Halfling_FoxgloveBeardTongue.SetActiveRecursively(false);
		Plants_Halfling_WaterCaltrop.SetActiveRecursively(false);
		Plants_Halfling_Soapwart.SetActiveRecursively(false);
		Plants_Halfling_BloodRoot.SetActiveRecursively(false);
		Plants_Halfling_Taro.SetActiveRecursively(false);
		
		
		PlantsDarklingInvScrollList.SetActiveRecursively(false);
		PlantsHalflingInvScrollList.SetActiveRecursively(false);
		
		Plants_Darkling_PumpkinDark.SetActiveRecursively(false);
		Plants_Darkling_Firepepper.SetActiveRecursively(false);
		Plants_Darkling_Blackberry.SetActiveRecursively(false);
		Plants_Darkling_Truffle.SetActiveRecursively(false);
		Plants_Darkling_Mushroom.SetActiveRecursively(false);
		
		Plants_Halfling_Turnip.SetActiveRecursively(false);
		Plants_Halfling_PumpkinHalf.SetActiveRecursively(false);
		Plants_Halfling_Potato.SetActiveRecursively(false);
		Plants_Halfling_Carrot.SetActiveRecursively(false);
		Plants_Halfling_Strawberry.SetActiveRecursively(false);
		
		
		PotionsDarklingInvScrollList.SetActiveRecursively(false);
		PotionsHalflingInvScrollList.SetActiveRecursively(false);
		
		Potions_Darkling_SlugTonic.SetActiveRecursively(false);
		Potions_Darkling_FeverPitch.SetActiveRecursively(false);
		Potions_Darkling_MorrowDraught.SetActiveRecursively(false); 
		Potions_Darkling_MonkBlood.SetActiveRecursively(false);
		Potions_Darkling_ScorchElixir.SetActiveRecursively(false);
		Potions_Darkling_SpleenBite.SetActiveRecursively(false);
		Potions_Darkling_Necrobane.SetActiveRecursively(false);
		Potions_Darkling_DevilIchor.SetActiveRecursively(false);
		Potions_Darkling_StunkMange.SetActiveRecursively(false);
		
		Potions_Halfling_PoppySnap.SetActiveRecursively(false);
		Potions_Halfling_BitterRoot.SetActiveRecursively(false);
		Potions_Halfling_VetchSpray.SetActiveRecursively(false); 
		Potions_Halfling_BoggleHorn.SetActiveRecursively(false);
		Potions_Halfling_MossSalve.SetActiveRecursively(false);
		Potions_Halfling_Seawhip.SetActiveRecursively(false);
		Potions_Halfling_WolfTongue.SetActiveRecursively(false); 
		Potions_Halfling_GrubSprout.SetActiveRecursively(false);
		Potions_Halfling_DwaleBile.SetActiveRecursively(false);

		
		RewardHalflingInvScrollList.SetActiveRecursively(false);
		RewardDarklingInvScrollList.SetActiveRecursively(false);
		
		Reward_Halfling_BloodStoneTrinket.SetActiveRecursively(false);
		Reward_Halfling_BloodStoneMedallion.SetActiveRecursively(false);
		Reward_Halfling_BloodStoneAmulet.SetActiveRecursively(false);
		Reward_Halfling_EmeraldTrinket.SetActiveRecursively(false);
		Reward_Halfling_EmeraldMedallion.SetActiveRecursively(false);
		Reward_Halfling_EmeraldAmulet.SetActiveRecursively(false);
		Reward_Halfling_SapphireTrinket.SetActiveRecursively(false);
		Reward_Halfling_SapphireMedallion.SetActiveRecursively(false);
		Reward_Halfling_SapphireAmulet.SetActiveRecursively(false);
		
		Reward_Darkling_AmethystTrinket.SetActiveRecursively(false);
		Reward_Darkling_AmethystMedallion.SetActiveRecursively(false);
		Reward_Darkling_AmethystAmulet.SetActiveRecursively(false);
		Reward_Darkling_RubyTrinket.SetActiveRecursively(false);
		Reward_Darkling_RubyMedallion.SetActiveRecursively(false);
		Reward_Darkling_RubyAmulet.SetActiveRecursively(false);
		Reward_Darkling_OnyxTrinket.SetActiveRecursively(false);
		Reward_Darkling_OnyxMedallion.SetActiveRecursively(false);
		Reward_Darkling_OnyxAmulet.SetActiveRecursively(false);
	}
	
}
