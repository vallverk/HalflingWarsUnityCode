using UnityEngine;
using System.Collections;

public class getPlantXP : MonoBehaviour 
{
	private float speed = 2.5f;
	private Transform xpValueObj;
	private GameObjectsSvr scr_GameObjectSvr;
	private SfsRemote scr_SfsRemote;
	private LoadUserWorld scr_userLoad;
	
	public bool xpAnimBool = false;
	
	public string xpObj;
	public int xpValue = 0;
	
	// Use this for initialization
	void Start () 
	{
		//xpValueObj = transform.FindChild("xpValue") as Transform;
		scr_GameObjectSvr = GameObject.Find("sfxConnect").gameObject.GetComponent<GameObjectsSvr>();
		scr_SfsRemote = GameObject.Find("sfxConnect").gameObject.GetComponent<SfsRemote>();
		scr_userLoad = GameObject.Find("sfxConnect").gameObject.GetComponent<LoadUserWorld>();
		
	/*	if (xpValue == 0)
			transform.GetComponent<SpriteText>().Text = "Free";
		else
			transform.GetComponent<SpriteText>().Text = "+XP " + xpValue.ToString();*/
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("obje name :: " + xpObj);
		if (xpAnimBool)
		{
			objectXP();
			
			if (transform.gameObject.GetComponent<MeshRenderer>().enabled == false)
				transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
			
			if (transform.gameObject.renderer.material.color.a >= 0)
			{
				transform.Translate(Vector3.up * speed * Time.deltaTime);
				transform.gameObject.renderer.material.color = new Color(transform.gameObject.renderer.material.color.r,
																		transform.gameObject.renderer.material.color.g,
																		transform.gameObject.renderer.material.color.b, 
																		(transform.gameObject.renderer.material.color.a - 0.012f));
				
				transform.localScale = new Vector3(transform.localScale.x + 0.012f, transform.localScale.y + 0.012f, transform.localScale.z + 0.012f);
			}
			else
			{
				Destroy(transform.gameObject);
				Destroy(this);
			}
		}
	}
	
	
	
	
	public void objectPlantXP()
	{
	     if (xpObj == "DAven")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " +  scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "BitterBrush")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " +scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "DBlackBerry")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "BogBean")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "DColumbine")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "DFirePepper")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " +scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "MoonFlower")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "DPumpkin")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Wolfsbane")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		
		else if (xpObj == "Costmary")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "FairyLily")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Mandrake")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "PipeWeed")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Potato")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Pumpkin")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "SunFlower")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Turnip")
		{
			Debug.Log("turnip xp generate...");
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants() ;
		}
		else if (xpObj == "Vervain")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		else if (xpObj == "Watercress")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_SfsRemote.GetxpPlants();
		}
		
	}
	
	void objectXP()
	{
		/*if (xpObj == "HC_D_DirtPath_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDirtPath.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Barrel_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objBarrel.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Cornfield_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objCornfield.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Cottage_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objCottage.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_FruitTree_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objFruitTree1.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_HalflingKnoll_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objKnollhill.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Lantern_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objLamp.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_PartyTent_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objPartytent.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Scarecrow_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objScarescrow.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Shroomrey_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objShroomery.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_StoneFence_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objFence.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Tree_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objTree1.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Well_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWell.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_WheelBurrow_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWheelbarrow.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_WindMill_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWindmill.objTypeId).ToString();
		}
		else if (xpObj == "HC_D_Woodpile_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWoodpile.objTypeId).ToString();
		}
		
		else if (xpObj == "DL_D_BirdHouse_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingBirdHouse.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_DBog_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingBog.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_DDirtPath_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingDirtPath.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_DTree_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingTree1.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_DWell_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingWell.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_DWindMill_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingWindmill.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_HuntingTent_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingHuntingtent.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_RavenPerch_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingRavenPerch.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_Scarecrow_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingScarecrow.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_StoneFence_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingFence.objTypeId).ToString();
		}
		else if (xpObj == "DL_D_SwampKnoll_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingKnollhill.objTypeId).ToString();
		}
		
		else if (xpObj == "HC_B_Apothecary_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objApothecary.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_BlackSmith_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objBlackSmith.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_EarthObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objEarthobelisk.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_Inn_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objInn.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_PlantObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objPlantObelisk.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_Plot_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objGarden.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_Stable_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objHalflingStable.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_SunShrine_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objSunshrine.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_Tavern_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objTavern.objTypeId).ToString();
		}
		else if (xpObj == "HC_B_WaterObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWaterObelisk.objTypeId).ToString();
		}
		
		else if (xpObj == "DL_B_Apothecary_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingApothecary.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_DBlackSmith_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingSmith.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_EarthObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingEarthObelisk.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_FireObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingFireObelisk.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_Inn_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarkLingInn.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_MoonShrine_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objMoonShrine.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_Plot_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingGarden.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_Stable_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarkingStable.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_SwampObelisk_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingSwampObelisk.objTypeId).ToString();
		}
		else if (xpObj == "DL_B_Tavern_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingtavern.objTypeId).ToString();
		}
		
		else if (xpObj == "DL_C_DHound_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objHound.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Djinn_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingDjInn.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Fenrir_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingFenrir.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_HellHound_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingHellhound.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Imp_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingImp.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Leech_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objLeech.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Leshy_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingLeshy.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Lurker_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingLurker.objTypeId).ToString();
		}
		else if (xpObj == "DL_C_Sprite_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingSprite.objTypeId).ToString();
		}
		
		else if (xpObj == "HC_C_Barg_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objBarg.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Cusith_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objCusith.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Dragon_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDragon.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Draug_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDraug.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Dryad_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDryad.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Hound_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objHound.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Nix_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objNix.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Nymph_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objNymph.objTypeId).ToString();
		}
		else if (xpObj == "HC_C_Sprout_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objSprout.objTypeId).ToString();
		}
		
		
		else if (xpObj == "DL_TG_Earth_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarkearthTrainingGrnd.objTypeId).ToString();
		}
		else if (xpObj == "DL_TG_Fire_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objDarklingFireTrainingGrnd.objTypeId).ToString();
		}
		else if (xpObj == "DL_TG_Swamp_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objSwampTrainingGrnd.objTypeId).ToString();
		}
		
		else if (xpObj == "HC_TG_Plant_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objPlantTrainingGrnd.objTypeId).ToString();
		}
		else if (xpObj == "HC_TG_TrainingGround_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objTrainingGrnd.objTypeId).ToString();
		}
		else if (xpObj == "HC_TG_Water_GO(Clone)")
		{
			transform.gameObject.GetComponent<SpriteText>().Text = "+XP " + scr_userLoad.ReturnXPcostTotal(scr_GameObjectSvr.objWaterTrainingGrnd.objTypeId).ToString();
		}*/
		
	}
}
