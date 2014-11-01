using UnityEngine;
using System.Collections;

public class cameraswitch : MonoBehaviour 
{
	public GameObject HalflingCamera;
	
	public GameObject beakerbase,fire,goldtextpotion,herbgreen,herbdark,liquid;
	public GameObject MainCameraPotion,PotionBg,progressbar,stick,XPTextPotion;
//	
	public GameObject beer,BeerBg,Beerpost,Count,cube,Cubeleft,Cuberight,GlassFillLevelBase,GlassFillLeveler,
					  GoldTextBeer,MaincameraBeer,platform,timer,XptextBeer,Zcode;
	
	public GameObject Zlist1,Zlist2,Zlist3,Zlist4,Zlist5,Zlist6,Zlist7,Zlist8,Zlist9,Zlist10,
					  Zlist11,Zlist12,Zlist13,Zlist14,Zlist15,Zlist16,Zlist17,Zlist18,Zlist19,Zlist20;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI()
	{
//		if(GUI.Button(new Rect(240,500,100,50),"switch on potion"))
//		{
//			Screen.orientation = ScreenOrientation.Portrait;
//			MainCameraPotion.active = true;
//			HalflingCamera.active = false;
//			beakerbase.active = true;
//			PotionBg.active = true;
//			herbgreen.active = true;
//			herbdark.active = true;
//			liquid.active = true;
//			progressbar.SetActiveRecursively(true);
//			stick.active = true;
//		}
		if(GUI.Button(new Rect(240,560,100,50),"switch off potion"))
		{
			Screen.orientation = ScreenOrientation.Landscape;
			HalflingCamera.active = true;
			
			beakerbase.active = false;
			fire.active = false;
			goldtextpotion.active = false;
			herbgreen.active = false;
			herbdark.active = false;
			liquid.active = false;
			MainCameraPotion.active = false;
			PotionBg.active = false;
			progressbar.SetActiveRecursively(false);
			stick.active = false;
			XPTextPotion.active = false;
			
			Screen.orientation = ScreenOrientation.Landscape;
		}
		if(GUI.Button(new Rect(240,620,100,50),"switch on Beer"))
		{
			Screen.orientation = ScreenOrientation.Portrait;
			HalflingCamera.active = false;
			beer.active = true;
			BeerBg.active = true;
			Count.active = true;
			cube.active = true;
			GlassFillLevelBase.active = true;
			GlassFillLeveler.active = true;
			MaincameraBeer.active = true;
			platform.active = true;
			timer.active = true;
			Zcode.active = true;
			Zlist1.active = true;
			Zlist2.active = true;
			Zlist3.active = true;
			Zlist4.active = true;
			Zlist5.active = true;
			Zlist6.active = true;
			Zlist7.active = true;
			Zlist8.active = true;
			Zlist9.active = true;
			Zlist10.active = true;
			Zlist11.active = true;
			Zlist12.active = true;
			Zlist13.active = true;
			Zlist14.active = true;
			Zlist15.active = true;
			Zlist16.active = true;
			Zlist17.active = true;
			Zlist18.active = true;
			Zlist19.active = true;
			Zlist20.active = true;
		}
		if(GUI.Button(new Rect(240,680,100,50),"switch off Beer"))
		{
			Screen.orientation = ScreenOrientation.Landscape;
			HalflingCamera.active = true;
			beer.active = false;
			BeerBg.active = false;
			Beerpost.active = false;
			Count.active = false;
			cube.active = false;
			Cubeleft.active = false;
			Cuberight.active = false;
			GlassFillLevelBase.active = false;
			GlassFillLeveler.active = false;
			MaincameraBeer.active = false;
			platform.active = false;
			timer.active = false;
			XptextBeer.active = false;
			Zcode.active = false;
			Zlist1.active = false;
			Zlist2.active = false;
			Zlist3.active = false;
			Zlist4.active = false;
			Zlist5.active = false;
			Zlist6.active = false;
			Zlist7.active = false;
			Zlist8.active = false;
			Zlist9.active = false;
			Zlist10.active = false;
			Zlist11.active = false;
			Zlist12.active = false;
			Zlist13.active = false;
			Zlist14.active = false;
			Zlist15.active = false;
			Zlist16.active = false;
			Zlist17.active = false;
			Zlist18.active = false;
			Zlist19.active = false;
			Zlist20.active = false;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PotionsActive()
	{
		    Screen.orientation = ScreenOrientation.Portrait;
			MainCameraPotion.active = true;
			HalflingCamera.active = false;
			beakerbase.active = true;
			PotionBg.active = true;
			herbgreen.active = true;
			herbdark.active = true;
			liquid.active = true;
			progressbar.SetActiveRecursively(true);
			stick.active = true;
	}
}
