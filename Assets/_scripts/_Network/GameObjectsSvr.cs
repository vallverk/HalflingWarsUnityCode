using UnityEngine;
using System.Collections;

public class GameObjectsSvr : MonoBehaviour {
	
	//objects stored in database 
	
	public class ObjectSvr
	{
		public string objname;
		public int objTypeId;
		public float CreateTime;
	}
	
	public ObjectSvr objTrainingGrnd = new ObjectSvr();
	public ObjectSvr objHound = new ObjectSvr();
	public ObjectSvr objGarden = new ObjectSvr();
	public ObjectSvr objTurnips = new ObjectSvr();
	public ObjectSvr objInn = new ObjectSvr();
	public ObjectSvr objFarm = new ObjectSvr();
	public ObjectSvr objPipeweed = new ObjectSvr();
	public ObjectSvr objDirtPath = new ObjectSvr();
	public ObjectSvr objGolum = new ObjectSvr();
	public ObjectSvr objPlantTrainingGrnd = new ObjectSvr();
	public ObjectSvr objSprout = new ObjectSvr();
	public ObjectSvr objSwampTrainingGrnd = new ObjectSvr();
	public ObjectSvr objLeech = new ObjectSvr();
	public ObjectSvr objDarkLingInn = new ObjectSvr();
	public ObjectSvr objDarklingGarden = new ObjectSvr();
	public ObjectSvr objPumpkin = new ObjectSvr();
	public ObjectSvr objDarklingPumpkin = new ObjectSvr();
	public ObjectSvr objTree1 = new ObjectSvr();
	public ObjectSvr objWell = new ObjectSvr();
	public ObjectSvr objLamp = new ObjectSvr();
	public ObjectSvr objNymph = new ObjectSvr();
	public ObjectSvr objCusith = new ObjectSvr();
	public ObjectSvr objDarklingWell = new ObjectSvr();
	public ObjectSvr objDarklingTree1 = new ObjectSvr();
	public ObjectSvr objWaterTrainingGrnd = new ObjectSvr();
	public ObjectSvr objNix = new ObjectSvr();
	public ObjectSvr objDraug = new ObjectSvr();
	public ObjectSvr objDryad = new ObjectSvr();
	public ObjectSvr objDragon = new ObjectSvr();
	public ObjectSvr objDarkingStable = new ObjectSvr();
	public ObjectSvr objHalflingStable = new ObjectSvr();
	public ObjectSvr objDarkearthTrainingGrnd = new ObjectSvr();
	public ObjectSvr objDarklinghound = new ObjectSvr();
	public ObjectSvr objDarklingSmith = new ObjectSvr();
	public ObjectSvr objFirePepper = new ObjectSvr();
	public ObjectSvr objGoblinCamp01 = new ObjectSvr();
	public ObjectSvr objGoblinCamp02 = new ObjectSvr();
	public ObjectSvr objGoblinCamp03 = new ObjectSvr();
	public ObjectSvr objOrgCave01 = new ObjectSvr();
	public ObjectSvr objOrgCave02 = new ObjectSvr();
	public ObjectSvr objOrgCave03 = new ObjectSvr();
	public ObjectSvr objTrollCave01 = new ObjectSvr();
	public ObjectSvr objTrollCave02 = new ObjectSvr();
	public ObjectSvr objTrollCave03 = new ObjectSvr();
	public ObjectSvr objDarklingGoblinCamp01 = new ObjectSvr();
	public ObjectSvr objDarklingGoblinCamp02 = new ObjectSvr();
	public ObjectSvr objDarklingGoblinCamp03 = new ObjectSvr();
	public ObjectSvr objDarklingOrgCave01 = new ObjectSvr();
	public ObjectSvr objDarklingOrgCave02 = new ObjectSvr();
	public ObjectSvr objDarklingOrgCave03 = new ObjectSvr();
	public ObjectSvr objDarklingTrollCave01 = new ObjectSvr();
	public ObjectSvr objDarklingTrollCave02 = new ObjectSvr();
	public ObjectSvr objDarklingTrollCave03 = new ObjectSvr();
	public ObjectSvr objDarklingDirtPath = new ObjectSvr();
	public ObjectSvr objFruitTree1 = new ObjectSvr();
	public ObjectSvr objBarg = new ObjectSvr();
	public ObjectSvr objShroomery = new ObjectSvr();
	public ObjectSvr objSunshrine = new ObjectSvr();
	public ObjectSvr objDarklingFireTrainingGrnd = new ObjectSvr();
	public ObjectSvr objDarklingSprite = new ObjectSvr();
	public ObjectSvr objDarklingImp = new ObjectSvr();
	public ObjectSvr objBlackSmith = new ObjectSvr();
	public ObjectSvr objApothecary = new ObjectSvr();
	public ObjectSvr objGarden03 = new ObjectSvr();
	public ObjectSvr objGarden04 = new ObjectSvr();
	public ObjectSvr objGarden02 = new ObjectSvr();
	public ObjectSvr objGarden05 = new ObjectSvr();
	public ObjectSvr objWheelbarrow = new ObjectSvr();
	public ObjectSvr objCostmaryherb = new ObjectSvr();
	public ObjectSvr objEarthobelisk = new ObjectSvr();
	public ObjectSvr objTavern = new ObjectSvr();
	public ObjectSvr objDarklingGarden02 = new ObjectSvr();
	public ObjectSvr objDarklingGarden03 = new ObjectSvr();
	public ObjectSvr objDarklingAvenHerb = new ObjectSvr();
	public ObjectSvr objDarklingRavenPerch = new ObjectSvr();
	public ObjectSvr objDarklingLeshy = new ObjectSvr();
	public ObjectSvr objDarklingFenrir = new ObjectSvr();
	public ObjectSvr objDarklingTree2 = new ObjectSvr();
	public ObjectSvr objDarklingBlackberry = new ObjectSvr();
	public ObjectSvr objDarklingColumbine = new ObjectSvr();
	public ObjectSvr objDarklingBitterbush = new ObjectSvr();
	public ObjectSvr objDarklingMoonFlower = new ObjectSvr();
	public ObjectSvr objDarklingSwampObelisk = new ObjectSvr();
	public ObjectSvr objDarklingEarthObelisk = new ObjectSvr();
	public ObjectSvr objDarklingFireObelisk = new ObjectSvr();
	public ObjectSvr QuestCreation = new ObjectSvr();
	public ObjectSvr objDarklingGolum = new ObjectSvr();
	public ObjectSvr objPlantObelisk = new ObjectSvr();
	public ObjectSvr objWaterObelisk = new ObjectSvr();
	public ObjectSvr objDarklingLurker = new ObjectSvr();
	public ObjectSvr objDarklingHellhound = new ObjectSvr();
	public ObjectSvr objDarklingDjInn = new ObjectSvr();
    public ObjectSvr objPotatoes = new ObjectSvr();
	public ObjectSvr objFairyLilly = new ObjectSvr();
	public ObjectSvr objWatercress = new ObjectSvr();
	public ObjectSvr objMandrake = new ObjectSvr();
	public ObjectSvr objVervainHerb = new ObjectSvr();
	public ObjectSvr objSunflower = new ObjectSvr();
	public ObjectSvr objDarklingApothecary = new ObjectSvr();
	public ObjectSvr objDarklingGarden04 = new ObjectSvr();
	public ObjectSvr objDarklingHerbBogbean = new ObjectSvr();
	public ObjectSvr objDarklingHerbWolfbane = new ObjectSvr();
	public ObjectSvr objMoonShrine = new ObjectSvr();
	public ObjectSvr objWoodpile = new ObjectSvr();
	public ObjectSvr objHalflingHouse  = new ObjectSvr();
	public ObjectSvr objDarklingHouse = new ObjectSvr();
	public ObjectSvr objBarrel = new ObjectSvr();
	
	public ObjectSvr objScarescrow = new ObjectSvr();
	public ObjectSvr objPartytent = new ObjectSvr();
	public ObjectSvr objKnollhill = new ObjectSvr();
	public ObjectSvr objFence = new ObjectSvr();
	public ObjectSvr objCottage = new ObjectSvr();
	public ObjectSvr objCornfield = new ObjectSvr();
	public ObjectSvr objWindmill = new ObjectSvr();
	
	//new darkling decorations
	public ObjectSvr objDarklingScarecrow = new ObjectSvr();
	public ObjectSvr objDarklingHuntingtent = new ObjectSvr();
	public ObjectSvr objDarklingKnollhill = new ObjectSvr();
	public ObjectSvr objDarklingFence = new ObjectSvr();
	public ObjectSvr objDarklingBirdHouse = new ObjectSvr();
	public ObjectSvr objDarklingWindmill = new ObjectSvr();
		
	//13-12-2012
	public ObjectSvr objDarklingFirePepper = new ObjectSvr();
	public ObjectSvr objDarklingBog = new ObjectSvr();
	public ObjectSvr objDarklingtavern = new ObjectSvr();
	
	//Potions Info
	public ObjectSvr objSlugTonic = new ObjectSvr();
	public ObjectSvr objPoppySnap = new ObjectSvr();
	public ObjectSvr objFeverPitch = new ObjectSvr();
	public ObjectSvr objBitterRoot = new ObjectSvr();
	public ObjectSvr objMorrowDraught = new ObjectSvr();
	public ObjectSvr objVetchSpray = new ObjectSvr();
	public ObjectSvr objBoggleHom = new ObjectSvr();
	public ObjectSvr objSpleenBite = new ObjectSvr();
	public ObjectSvr objBridge = new ObjectSvr();
	
	
	// Use this for initialization
	void Start () {
	
		Debug.Log ("game object svr...");
		objTrainingGrnd.objname = "EarthTrainingGround";
		objTrainingGrnd.objTypeId  = 2;
		
		objHound.objname = "Hound";
		objHound.objTypeId = 3;
		
		objGarden.objname = "Garden01";
		objGarden.objTypeId = 4;
		
		objTurnips.objname = "Turnips";
		objTurnips.objTypeId = 5;
		
		objInn.objname = "Inn";
		objInn.objTypeId= 6;
		
		objFarm.objname = "Farm";
		objFarm.objTypeId = 7;
		
		objPipeweed.objname = "Pipeweed";
		objPipeweed.objTypeId = 8;
		objPipeweed.CreateTime = 60;
		
		objDirtPath.objname = "DirtPath";
		objDirtPath.objTypeId = 12;
		
		objTree1.objname = "Tree1";
		objTree1.objTypeId = 13;
		
		objGolum.objname = "Golem";
		objGolum.objTypeId = 14;
		
		objWell.objname = "Well";
		objWell.objTypeId = 15;
		
		objPlantTrainingGrnd.objname = "PlantTrainingGround";
		objPlantTrainingGrnd.objTypeId = 20;
		
		objSprout.objname = "Sprout";
		objSprout.objTypeId = 21;
		objSprout.CreateTime = 60;
		
		objNymph.objname = "Nymph";
		objNymph.objTypeId = 32;
		
		objPumpkin.objname = "Pumpkin";
		objPumpkin.objTypeId = 27;
		
		objBarrel.objname = "Barrel";
		objBarrel.objTypeId = 58;
		
		objBarg.objname = "Barg";
		objBarg.objTypeId = 22;
		
		objLamp.objname = "Lamp";
		objLamp.objTypeId = 33;
		
		objBlackSmith.objname = "BlackSmith";
		objBlackSmith.objTypeId = 19;
		
		objGarden02.objname = "Garden02";
		objGarden02.objTypeId = 28;
		
		objGarden03.objname = "Garden03";
		objGarden03.objTypeId = 34;
		
		objGarden04.objname = "Garden04";
		objGarden04.objTypeId = 46;
		
		objGarden05.objname = "Garden05";
		objGarden05.objTypeId = 54;
		
		objWheelbarrow.objname = "Wheelbarrow";
		objWheelbarrow.objTypeId = 35;
		
		objCostmaryherb.objname = "CostmaryHerb";
		objCostmaryherb.objTypeId = 36;
		
		objEarthobelisk.objname = "EarthObelisk";
		objEarthobelisk.objTypeId = 37;
		
		objCusith.objname = "Cusith";
		objCusith.objTypeId = 26;
		
		objDraug.objname = "Draug";
		objDraug.objTypeId = 38;
		
		objPlantObelisk.objname = "PlantObelisk";
		objPlantObelisk.objTypeId = 43;
		
		objWaterObelisk.objname = "WaterObelisk";
		objWaterObelisk.objTypeId = 48;
		
		objDragon.objname = "Dagon";
		objDragon.objTypeId = 50;
		
		objPotatoes.objname = "Potato";
		objPotatoes.objTypeId = 45;
		
		objFairyLilly.objname = "FairyLilly";
		objFairyLilly.objTypeId = 47;
		
		objWatercress.objname = "Watercress";
		objWatercress.objTypeId = 49;
		
		objMandrake.objname = "HerbMandrake";
		objMandrake.objTypeId = 55;
		
		objSunflower.objname = "SunFlower";
		objSunflower.objTypeId = 51;
		
		objVervainHerb.objname = "HerbVervain";
		objVervainHerb.objTypeId = 53;
		
		objTavern.objname = "Tavern";
		objTavern.objTypeId = 42;
		
		objApothecary.objname = "Apothecary";
		objApothecary.objTypeId = 44;
		
		objSunshrine.objname = "SunShrine";
		objSunshrine.objTypeId = 52;
		
		objDarklingHerbBogbean.objname = "DarklingHerbBogbean";
		objDarklingHerbBogbean.objTypeId = 238;
		
		objDarklingMoonFlower.objname = "DarklingMoonFlower";
		objDarklingMoonFlower.objTypeId = 235;
		
		objDarklingHerbWolfbane.objname = "DarklingHerbWolfbane";
		objDarklingHerbWolfbane.objTypeId = 240;
		
		objWoodpile.objname = "Woodpile";
		objWoodpile.objTypeId = 1;
		
		objHalflingHouse.objname = "HalflingHouse";
		objHalflingHouse.objTypeId = 110;
		
		objDarklingHouse.objname = "DarklingHouse";
		objDarklingHouse.objTypeId = 120;
		//Darkling items
		
		objDarklingGarden.objname = "DarklingGarden01";
		objDarklingGarden.objTypeId = 201;
		
		objDarklingPumpkin.objname = "DarklingPumpkin";
		objDarklingPumpkin.objTypeId = 202;
		
		
		objDarkLingInn.objname = "DarklingInn";
		objDarkLingInn.objTypeId = 203;
		
		objDarklingTree1.objname = "DarklingTree1";
		objDarklingTree1.objTypeId = 204;
		
			
		objDarklingDirtPath.objname = "DarklingDirtPath";
		objDarklingDirtPath.objTypeId = 205;
		
		objDarklingWell.objname = "DarklingWell";
		objDarklingWell.objTypeId = 206;
			
		objSwampTrainingGrnd.objname = "DarklingSwamp";
		objSwampTrainingGrnd.objTypeId = 207;
		
		objLeech.objname = "DarklingLeech";
		objLeech.objTypeId = 208;
	
		objDarklinghound.objname = "DarklingHound";
		objDarklinghound.objTypeId = 209;
			
		objWaterTrainingGrnd.objname = "WaterTrainingGround";
		objWaterTrainingGrnd.objTypeId = 29;
		
		objNix.objname = "Nix";
		objNix.objTypeId = 24;
		
		objDryad.objname = "Dryad";
		objDryad.objTypeId = 41;
		
		objDarkingStable.objname = "DarklingStable";
		objDarkingStable.objTypeId = 211;
		
		objHalflingStable.objname = "Stable";
		objHalflingStable.objTypeId = 30;
		
		objDarkearthTrainingGrnd.objname = "DarklingEarthTrainingGround";
		objDarkearthTrainingGrnd.objTypeId = 210;
		
		
		objFirePepper.objname = "FirePepper";
		objFirePepper.objTypeId = 36;
		
		objGoblinCamp01.objname = "GoblinCamp01";
		objGoblinCamp01.objTypeId = 101;
		
		objGoblinCamp02.objname = "GoblinCamp02";
		objGoblinCamp02.objTypeId = 102;
		
		objGoblinCamp03.objname = "GoblinCamp03";
		objGoblinCamp03.objTypeId = 103;
		
		objOrgCave01.objname = "OrgCave01";
		objOrgCave01.objTypeId = 104;
		
		objOrgCave02.objname = "OrgCave02";
		objOrgCave02.objTypeId = 105;
		
		objOrgCave03.objname = "OrgCave03";
		objOrgCave03.objTypeId = 106;
		
		objTrollCave01.objname = "TrollCave01";
		objTrollCave01.objTypeId = 107;
		
		objTrollCave02.objname = "TrollCave02";
		objTrollCave02.objTypeId = 108;
		
		objTrollCave03.objname = "TrollCave03";
		objTrollCave03.objTypeId = 109;
		
		objDarklingGoblinCamp01.objname = "DarklingGoblinCamp01";
		objDarklingGoblinCamp01.objTypeId = 111;
		
		objDarklingGoblinCamp02.objname = "DarklingGoblinCamp02";
		objDarklingGoblinCamp02.objTypeId = 112;
		
		objDarklingGoblinCamp03.objname = "DarklingGoblinCamp03";
		objDarklingGoblinCamp03.objTypeId = 113;
		
		objDarklingOrgCave01.objname = "DarklingOrgCave01";
		objDarklingOrgCave01.objTypeId = 114;
		
		objDarklingOrgCave02.objname = "DarklingOrgCave02";
		objDarklingOrgCave02.objTypeId = 115;
		
		objDarklingOrgCave03.objname = "DarklingOrgCave03";
		objDarklingOrgCave03.objTypeId = 116;
		
		objDarklingTrollCave01.objname = "DarklingTrollCave01";
		objDarklingTrollCave01.objTypeId = 117;
		
		objDarklingTrollCave02.objname = "DarklingTrollCave02";
		objDarklingTrollCave02.objTypeId = 118;
		
		objDarklingTrollCave03.objname = "DarklingTrollCave03";
		objDarklingTrollCave03.objTypeId = 119;
		
		objDarklingTree2.objname = "DarklingTree2";
		objDarklingTree2.objTypeId = 217;
		
		objFruitTree1.objname = "FruitTree1";
		objFruitTree1.objTypeId = 31;
		
		objShroomery.objname = "Shroomery";
		objShroomery.objTypeId = 40;		
		
		
		objScarescrow.objname = "ScareCrow";
		objScarescrow.objTypeId = 59;
		
		objPartytent.objname = "PartyTent";
		objPartytent.objTypeId = 60;
		
		objKnollhill.objname = "KnollHill";
		objKnollhill.objTypeId = 61;
		
		objFence.objname = "Fence";
		objFence.objTypeId = 62;
		
		objCottage.objname = "Cottage";
		objCottage.objTypeId = 63;
		
		objCornfield.objname = "CornField";
		objCornfield.objTypeId = 64;
		
		//13-12-2012
		
		objDarklingScarecrow.objname = "DarklingScareCrow";
		objDarklingScarecrow.objTypeId = 246;
		
		objDarklingHuntingtent.objname = "DarklingHuntingTent";
		objDarklingHuntingtent.objTypeId = 247;
		
		objDarklingKnollhill.objname = "DarklingKnollHill";
		objDarklingKnollhill.objTypeId = 248;
		
		objDarklingFence.objname = "DarklingFence";
		objDarklingFence.objTypeId = 249;
		
		objDarklingBirdHouse.objname = "DarklingBirdHouse";
		objDarklingBirdHouse.objTypeId = 250;
		
		
		objDarklingFirePepper.objname = "DarklingFirepepper";
		objDarklingFirePepper.objTypeId = 213;
		
		objDarklingBog.objname = "DarklingBog";
		objDarklingBog.objTypeId = 212;
		
		
		objDarklingFireTrainingGrnd.objname = "DarklingFireTrainingGround";
		objDarklingFireTrainingGrnd.objTypeId = 214;
		
		objDarklingSprite.objname = "DarklingSprite";
		objDarklingSprite.objTypeId = 215;
		
		objDarklingSmith.objname = "DarklingBlackSmith";
		objDarklingSmith.objTypeId = 218;
		
		objDarklingTree1.objname = "DarklingTree1";
		objDarklingTree1.objTypeId = 204;
		
		objDarklingGarden02.objname = "DarklingGarden02";
		objDarklingGarden02.objTypeId = 219;
		
		objDarklingGarden03.objname = "DarklingGarden03";
		objDarklingGarden03.objTypeId =  230 ;
		
		objDarklingGarden04.objname = "DarklingGarden04";
		objDarklingGarden04.objTypeId = 239;
		
		objDarklingAvenHerb.objname = "DarklingAvenHerb";
		objDarklingAvenHerb.objTypeId = 220;
		
		objDarklingRavenPerch.objname = "DarklingRavenPerch";
		objDarklingRavenPerch.objTypeId = 221;
		
		objDarklingLeshy.objname = "DarklingLeshy";
		objDarklingLeshy.objTypeId = 222;
		
		objDarklingSwampObelisk.objname = "DarklingSwampObelisk";
		objDarklingSwampObelisk.objTypeId = 223;
		
		objDarklingEarthObelisk.objname = "DarklingEarthObelisk";
		objDarklingEarthObelisk.objTypeId = 227;
		
		objDarklingFireObelisk.objname = "DarklingFireObelisk";
		objDarklingFireObelisk.objTypeId = 232;
		
		objDarklingFenrir.objname = "DarklingFenrir";
		objDarklingFenrir.objTypeId = 224;
		
		objDarklingGolum.objname = "DarklingGolum";
		objDarklingGolum.objTypeId = 244;
		
		QuestCreation.objname = "Quest";
		QuestCreation.objTypeId = 0;
		
		objDarklingLurker.objname = "DarklingLurker";
		objDarklingLurker.objTypeId = 234;
		
		objDarklingHellhound.objname = "DarklingHellhound";
		objDarklingHellhound.objTypeId = 237;
		
		objDarklingImp.objname = "DarklingImp";
		objDarklingImp.objTypeId = 225;
		
		objDarklingDjInn.objname = "DarklingDjinn";
		objDarklingDjInn.objTypeId = 241;
		
		objDarklingBlackberry.objname = "DarklingBlackberry";
		objDarklingBlackberry.objTypeId = 229;
		
		objDarklingColumbine.objname = "DarklingColumbine";
		objDarklingColumbine.objTypeId = 231;
		
		objDarklingBitterbush.objname = "DarklingBitterbrush";
		objDarklingBitterbush.objTypeId = 233;
		
		objDarklingtavern.objname = "DarklingTavern";
		objDarklingtavern.objTypeId = 226;
		
		objDarklingApothecary.objname = "DarklingApothecary";
		objDarklingApothecary.objTypeId = 228;
		
		objMoonShrine.objname = "DarklingMoonShrine";
		objMoonShrine.objTypeId = 236;
		
		objSlugTonic.objname = "SlugTonic";
		objSlugTonic.objTypeId = 401;
		
		objPoppySnap.objname = "PoppySnap";
		objPoppySnap.objTypeId = 402;
		
		objFeverPitch.objname = "FeverPitch";
		objFeverPitch.objTypeId = 403;
		
		objBitterRoot.objname = "BitterRoot";
		objBitterRoot.objTypeId = 404;
		
		objMorrowDraught.objname = "MorrowDraught";
		objMorrowDraught.objTypeId = 405;
		
		objVetchSpray.objname = "VetchSpray";
		objVetchSpray.objTypeId = 406;
		
		objBoggleHom.objname = "BoggleHom";
		objBoggleHom.objTypeId = 407;
		
		objSpleenBite.objname = "SpleenBite";
		objSpleenBite.objTypeId = 408;
		
		objBridge.objname = "Bridge";
		objBridge.objTypeId = 409;
		
	}
	
	public enum QuestNo
	{
		Quest1= 501,
		Quest2,
		Quest3,
		Quest4,
		Quest5,
		Quest6,
		Quest7,
		Quest8,
		Quest9,
		Quest10,
		Quest11,
		Quest12
	}
	
	public enum CurrentLevel
	{
		Level1=1,
		Level2,
		Level3,
		Level4,
		Level5,
		Level6,
		Level7,
		Level8,
		Level9,
		Level10,
		Level11,
		Level12,
		Level13,
		Level14
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
