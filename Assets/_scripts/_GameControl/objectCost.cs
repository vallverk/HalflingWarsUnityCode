using UnityEngine;
using System.Collections;

public class objectCost : MonoBehaviour 
{
	public GameObject dPlotCost, dInnCost, dApothecaryCost, dStableCost, dBlackSmithCost, dTavernCost, dSwampObeliskCost, dEarthObeliskCost, dFireObeliskCost, dMoonShrineCost;
	
	public GameObject dLeechCost, dLeshyCost, dLurkerCost, dHoundCost, dFenrirCost, dHellHoundCost, dSpriteCost, dImpCost, dDjinnCost;
	
	public GameObject dDirtPathCost, dTreeCost, dWellCost, dBogCost, dRavenPerchCost;
	
	public GameObject dPumpkinCost, dFirePeperCost, dColumbineCost, dBlackBerryCost, dAvenCost, dBitterBushCost, dBogBeanCost, dWolfsbaneCost, dMoonflowerCost;
	
	public GameObject dSwampCost, dEarthCost, dFireCost;
	
	public GameObject plotCost, innCost, stableCost, blacksmithCost, apothecaryCost, tavernCost, earthObeliskCost, plantObeliskCost, waterObeliskCost, sunshrineCost, bridgeCost;
	
	public GameObject houndCost, bargCost, cusithCost, sproutCost, nymphCost, dryadCost, nixCost, draugCost, dragonCost;
	
	public GameObject dirtPathCost, fruitTreeCost, lanternCost, wheelBurrowCost, shroomreyCost, barelCost, treeCost, wellCost, woodpileCost;
	
	public GameObject cornfield, cottage, knollhill, partytent, scarecrow , stonefence, windmill;
	
	public GameObject dbirdhouse,dwindmill,dhuntingtent,dscarecrow,dstonefence,dswamknoll;
	
	public GameObject turnipCost, pipweedCost, pumpkinCost, costmaryCost, fairylilyCost, potatoCost, watercreesCost, mandrakeCost, vervainCost, sunflowerCost;
	
	public GameObject earthCost, plantCost, waterCost;

	public LoadUserWorld scr_Loaduser;
	
	public GameObjectsSvr scr_GameObjectSvr;
	
	void Awake()
	{
		scr_Loaduser = GameObject.Find("sfxConnect").GetComponent<LoadUserWorld>();
		scr_GameObjectSvr = GameObject.Find("sfxConnect").GetComponent<GameObjectsSvr>();
		
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	
	public void ObjectcostLoad()
	{
		Debug.Log("@ @ @ " + scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objEarthobelisk.objTypeId).ToString());
		//Debug.Log("object cost load.................................?");
		dPlotCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingGarden.objTypeId).ToString();
		dInnCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarkLingInn.objTypeId).ToString();
		dApothecaryCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingApothecary.objTypeId).ToString();
		dStableCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarkingStable.objTypeId).ToString();
		dBlackSmithCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingSmith.objTypeId).ToString();
		dTavernCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objTavern.objTypeId).ToString();
		dSwampObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingSwampObelisk.objTypeId).ToString();
		dEarthObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingEarthObelisk.objTypeId).ToString();
    	dFireObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingFireObelisk.objTypeId).ToString();
		dMoonShrineCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objMoonShrine.objTypeId).ToString();
		dLeechCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objLeech.objTypeId).ToString();
		dLeshyCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingLeshy.objTypeId).ToString();
		dLurkerCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingLurker.objTypeId).ToString();
		dHoundCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklinghound.objTypeId).ToString();
		dFenrirCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingFenrir.objTypeId).ToString();
		dHellHoundCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingHellhound.objTypeId).ToString();
		dSpriteCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingSprite.objTypeId).ToString();
		dImpCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingImp.objTypeId).ToString();
		dDjinnCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDarklingDjInn.objTypeId).ToString();
		dDirtPathCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingDirtPath.objTypeId).ToString();
		dTreeCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingTree1.objTypeId).ToString();
		dWellCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingWell.objTypeId).ToString();
		dBogCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingBog.objTypeId).ToString();
		dRavenPerchCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingRavenPerch.objTypeId).ToString();
		dPumpkinCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingPumpkin.objTypeId).ToString();
		dFirePeperCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingFirePepper.objTypeId).ToString();
		dColumbineCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingColumbine.objTypeId).ToString();
		dBlackBerryCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingBlackberry.objTypeId).ToString();
		dAvenCost.GetComponent<SpriteText>().Text  = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingAvenHerb.objTypeId).ToString();
		dBitterBushCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingBitterbush.objTypeId).ToString();
		dBogBeanCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingHerbBogbean.objTypeId).ToString();
		dWolfsbaneCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingHerbWolfbane.objTypeId).ToString();
		dMoonflowerCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingMoonFlower.objTypeId).ToString();
		dSwampCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objSwampTrainingGrnd.objTypeId).ToString();
		dEarthCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarkearthTrainingGrnd.objTypeId).ToString();
		dFireCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingFireTrainingGrnd.objTypeId).ToString();
		bridgeCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objBridge.objTypeId).ToString();
		
		
		plotCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objGarden.objTypeId).ToString();
		innCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objInn.objTypeId).ToString();
		stableCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objHalflingStable.objTypeId).ToString();
		blacksmithCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objBlackSmith.objTypeId).ToString();
		apothecaryCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objApothecary.objTypeId).ToString();
		tavernCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objTavern.objTypeId).ToString();
		earthObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objEarthobelisk.objTypeId).ToString();
		plantObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPlantObelisk.objTypeId).ToString();
		waterObeliskCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWaterObelisk.objTypeId).ToString();
		sunshrineCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objSunshrine.objTypeId).ToString();
		houndCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objHound.objTypeId).ToString();
		bargCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objBarg.objTypeId).ToString();
		cusithCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objCusith.objTypeId).ToString();
		sproutCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objSprout.objTypeId).ToString();
		nymphCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objNymph.objTypeId).ToString();
		dryadCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDryad.objTypeId).ToString();
		nixCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objNix.objTypeId).ToString();
		draugCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDraug.objTypeId).ToString();
		dragonCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnSparkCostTotal(scr_GameObjectSvr.objDragon.objTypeId).ToString();
		dirtPathCost.GetComponent<SpriteText>().Text  = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDirtPath.objTypeId).ToString();
		fruitTreeCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objFruitTree1.objTypeId).ToString();
		lanternCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objLamp.objTypeId).ToString();
		wheelBurrowCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWheelbarrow.objTypeId).ToString();
		
		cornfield.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objCornfield.objTypeId).ToString();
		cottage.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objCottage.objTypeId).ToString();
		knollhill.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objKnollhill.objTypeId).ToString();
		partytent.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPartytent.objTypeId).ToString();
		scarecrow.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objScarescrow.objTypeId).ToString();
		stonefence.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objFence.objTypeId).ToString();
		windmill.GetComponent<SpriteText>().Text = "140"; //scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWindmill.objTypeId).ToString();
		
		dbirdhouse.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingBirdHouse.objTypeId).ToString();
		dwindmill.GetComponent<SpriteText>().Text = "140" ;//scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingWindmill.objTypeId).ToString();
		dhuntingtent.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingHuntingtent.objTypeId).ToString();
		dscarecrow.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingScarecrow.objTypeId).ToString();
		dstonefence.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingFence.objTypeId).ToString();
		dswamknoll.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objDarklingKnollhill.objTypeId).ToString();
		
		shroomreyCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objShroomery.objTypeId).ToString();
		barelCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objBarrel.objTypeId).ToString();
		treeCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objTree1.objTypeId).ToString();
		wellCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWell.objTypeId).ToString();
		woodpileCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWoodpile.objTypeId).ToString();
		turnipCost.GetComponent<SpriteText>().Text = "Free";//scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objTurnips.objTypeId).ToString();
		pipweedCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPipeweed.objTypeId).ToString();
		pumpkinCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPumpkin.objTypeId).ToString();
		costmaryCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objCostmaryherb.objTypeId).ToString();
		fairylilyCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objFairyLilly.objTypeId).ToString();
		potatoCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPotatoes.objTypeId).ToString();
		watercreesCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWatercress.objTypeId).ToString();
		mandrakeCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objMandrake.objTypeId).ToString();
		vervainCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objVervainHerb.objTypeId).ToString();
		sunflowerCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objSunflower.objTypeId).ToString();
		earthCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objTrainingGrnd.objTypeId).ToString();
		plantCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objPlantTrainingGrnd.objTypeId).ToString();
		waterCost.GetComponent<SpriteText>().Text = scr_Loaduser.ReturnGoldCostTotal(scr_GameObjectSvr.objWaterTrainingGrnd.objTypeId).ToString();
	
	}
}
