using UnityEngine;
using System.Collections;

public class UpgradeTexture : MonoBehaviour 
{
	// Garden plot
	public Texture plotLevel1;
	public Texture plotLevel2, plotLevel3;
	
	// bridge texture
	public Texture bridgeTex;
	
	// hafling Cave Texture
	public Texture hc_GoblinCamp_Tex, hc_TrollHouse_Tex, hc_OrgCave_Tex;
	
	// darklilng Cave Texture;
	public Texture dl_GoblinCamp_Tex, dl_TrollHouse_Tex, dl_OrgCave_Tex;
	
	// Inn building
	public Texture constuctionLevel, d_constructionLevel, h_ObeliskContruction, d_ObeliskConstruction;
	public Texture InnLevel_1, InnLevel_1N, InnLevel_2, InnLevel_2N, InnLevel3, h_Stable1, h_Stable2, h_BlackSmith, h_BlackSmith2, h_Apothecary, h_Tavern, h_SunShrine, 
					h_House1, h_House1N, h_House2, h_House2N, h_House3, h_House3N, h_EarthObelisk, h_EarthObelisk2, h_EarthObelisk3, h_WaterObelisk, h_WaterObelisk2, h_WaterObelisk3, h_PlantObelisk, h_PlantObelisk2, h_PlantObelisk3;
	public Texture d_Stable1, d_Stable2, d_BlackSmith, dBlackSmith_N, dBlackSmith2, dBlackSmith2_N, d_Apothecary, d_Tavern, d_MoonShrine,
					d_SwampObelisk, d_SwampObelisk2, d_SwampObelisk3, d_EarthObelisk, d_EarthObelisk2, d_EarthObelisk3, d_FireObelisk, d_FireObelisk2, d_FireObelisk3;
	public Texture dInnLevel1, dInnLevel1_N, dInnLevel_2, dInnLevel_2N, d_house1, d_house2, d_house2N;
	
	// Training Ground
	public Texture earthTG1, earthTG2, earthTG3, plantTG1, plantTG2, plantTG3, waterTG1, waterTG2, waterTG3;
	public Texture dEarthTF1, dEarthTG2, dEarthTG3, swampTG1, swampTG2, swampTG3, fireTG1, fireTG2, fireTG3;
	
	// Plant
	public Texture plantBurnTex, h_Turnip01, h_PipeWeed01, h_Pumpking01, h_Costmary01, h_FairyLily01, h_Potatoes01, h_Watercress01, h_Mandrake01, h_SunFlower01, h_Vervain01;
	public Texture d_Pumpkin01, d_FirePepper01, d_Columbine01, d_BlackBerry01, d_Aven01, d_BitterBrush01, d_Bogbean01, d_MoonFlower01, d_Wolfsbane01;
	
	// hw Creature 
	public Texture h_BargTex, h_CusithTex, h_DragonTex, h_DraugTex, h_DryadTex, h_NymphTex;
	
	public Texture h_Turnip_Mid_tex,h_PipeWeed_Mid_tex,h_Pumpkin_Mid_tex,h_Costmary_Mid_tex,h_Fairlilly_Mid_tex,h_Potatoes_Mid_tex,h_Watercress_Mid_tex,h_Mandrake_Mid_tex,h_Sunflower_Mid_tex,h_Vervain_Mid_tex;
	public Texture d_Pumpkin_Mid_tex,d_FirePepper_Mid_tex,d_Columbine_Mid_tex,d_Blackberry_Mid_tex,d_Aven_Mix_tex,d_BitterBrush_Mid_tex,d_Bogbean_Mid_tex,d_MoonFlower_Mid_tex,d_Wolfsbane_Mid_tex;
	
	public Texture Spark_level1EarthTg,Spark_level2EarthTg,Spark_level3EarthTg,Spark_level4EarthTg;
	public Texture Spark_level1PlantTg,Spark_level2PlantTg,Spark_level3PlantTg,Spark_level4PlantTg;
	public Texture Spark_level1WaterTg,Spark_level2WaterTg,Spark_level3WaterTg,Spark_level4WaterTg;
	
	public Texture Spark_level1DEarthTg,Spark_level2DEarthTg,Spark_level3DEarthTg,Spark_level4DEarthTg;
	public Texture Spark_level1FireTg,Spark_level2FireTg,Spark_level3FireTg,Spark_level4FireTg;
	public Texture Spark_level1SwampTg,Spark_level2SwampTg,Spark_level3SwampTg,Spark_level4SwampTg;
	
	public Texture h_BattleGroundMnt, h_BattleGround, h_BattleGround_N, d_BattleGroundMnt, d_BattleGround, d_BattleGround_N;
	
		public Texture halflingHound, halflingBarg, halflingCusith, halflingSprout, halflingNymph,
				halflingDryad, halflingNix, halflingDraug, halflingDagon;
	
	public Texture darklingHound, darklingFenrir, darklingHellHound, darklingSprite, darklingImp,
				darklingDjinn, darklingLeech, darklingLeshy, darklingLurker;

	//creature cards
	public Texture halflingHoundCard, halflingBargCard, halflingCusithCard, halflingSproutCard, halflingNymphCard,
				halflingDryadCard, halflingNixCard, halflingDraugCard, halflingDagonCard;
	
	public Texture darklingHoundCard, darklingFenrirCard, darklingHellHoundCard, darklingSpriteCard, darklingImpCard,
				darklingDjinnCard, darklingLeechCard, darklingLeshyCard, darklingLurkerCard;
	
	//obelisk
	public Texture halflingEarthObelisk, halflingPlantObelisk, halflingWaterObelisk;
	public Texture darklingEarthObelisk, darklingFireObelisk, darklingSwampObelisk;

	
	public Texture2D[] potionImage = new Texture2D[18];
	
	public Texture destructionBldg01_tex, destructionBldg02_tex, destructionEarth01_tex, destructionEarth02_tex,
					destructionFire01_tex, destructionFire02_tex, destructionGarden01_tex, destructionGarden02_tex,
					destructionPlant01_tex, destructionPlant02_tex, destructionSwamp01_tex, destructionSwamp02_tex,
					destructionDarkEarth01_tex, destructionDarkEarth02_tex, destructionWater01_tex, destructionWater02_tex;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
