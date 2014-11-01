using UnityEngine;
using System.Collections;

public class ObjectInformation : MonoBehaviour 
{
	public class GameObjects
	{
		public string name = "";
		public string group = "";
		public string type = "";
		public bool resourceGen = false;
		public int level = 0;
		public int costGoldBase = 0;
		public float manualAdjustment = 0;
		public int goldCost = 0;
		public int sparkCost = 0;
		public int sellable = 0;
		public int sellValue = 0;
		public int xpEarn = 0;
		public float timeToCreate = 0.0f;
		public int maxTotalCreation = 1;
	};
	
	GameObjects trainingGround = new GameObjects();
	GameObjects dirtPath = new GameObjects();
	GameObjects hound = new GameObjects();
	GameObjects barg = new GameObjects();
	GameObjects leech = new GameObjects();
	GameObjects plot = new GameObjects();
	GameObjects turnip = new GameObjects();
	GameObjects inn = new GameObjects();
	GameObjects plantTG = new GameObjects();
	GameObjects sprout = new GameObjects();
	GameObjects dDirtPath = new GameObjects();
	GameObjects dTree = new GameObjects();
	GameObjects dWell = new GameObjects();
	GameObjects swampTG = new GameObjects();
	GameObjects dInn = new GameObjects();
	GameObjects dEarthTG = new GameObjects();
	GameObjects stable = new GameObjects();
	GameObjects dStable = new GameObjects();
	GameObjects blackSmith = new GameObjects();
	GameObjects dBlackSmith = new GameObjects();
	GameObjects waterTG = new GameObjects();
	GameObjects fireTG = new GameObjects();
	//GameObjects dEarthTG = new GameObjects();
	
	private bool objectPlacedBool = false;
	private GameObject curObject;
	private int index = 0;
	
	// access scritp
	private guiControl guiControlInfo;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("object information...");
		guiControlInfo = GameObject.Find("GUIManager").GetComponent("guiControl") as guiControl;
		/*
		// Training Ground
		trainingGround.name = "TrainingGround";
		trainingGround.type = "game";
		trainingGround.resourceGen = false;
		trainingGround.level = 1;
		trainingGround.costGoldBase = 25;
		trainingGround.manualAdjustment = 0;
		trainingGround.goldCost = 50;
		trainingGround.sparkCost = 0;
		trainingGround.sellable = 0;
		trainingGround.sellValue = 0;
		trainingGround.xpEarn = 40;
		trainingGround.timeToCreate = 0;
		trainingGround.maxTotalCreation = 1;
		
		// waterTG
		waterTG.name = "WaterTG";
		waterTG.type = "game";
		waterTG.resourceGen = false;
		waterTG.level = 1;
		waterTG.costGoldBase = 25;
		waterTG.manualAdjustment = 0;
		waterTG.goldCost = 50;
		waterTG.sparkCost = 0;
		waterTG.sellable = 0;
		waterTG.sellValue = 0;
		waterTG.xpEarn = 40;
		waterTG.timeToCreate = 0;
		waterTG.maxTotalCreation = 1;
		
		// fireTG
		fireTG.name = "FireTG";
		fireTG.type = "game";
		fireTG.resourceGen = false;
		fireTG.level = 1;
		fireTG.costGoldBase = 25;
		fireTG.manualAdjustment = 0;
		fireTG.goldCost = 50;
		fireTG.sparkCost = 0;
		fireTG.sellable = 0;
		fireTG.sellValue = 0;
		fireTG.xpEarn = 40;
		fireTG.timeToCreate = 0;
		fireTG.maxTotalCreation = 1;
		
		
		// Dirt Path
		dirtPath.name = "Decoration";
		dirtPath.type = "decoration";
		dirtPath.resourceGen = false;
		dirtPath.level = 1;
		dirtPath.costGoldBase = 10;
		dirtPath.manualAdjustment = 0;
		dirtPath.goldCost = 10;
		dirtPath.sparkCost = 0;
		dirtPath.sellable = 0;
		dirtPath.sellValue = 0;
		dirtPath.xpEarn = 10;
		dirtPath.timeToCreate = 0;
		dirtPath.maxTotalCreation = 1;
		
		// dark ling Dirt Path
		dDirtPath.name = "Decoration";
		dDirtPath.type = "decoration";
		dDirtPath.resourceGen = false;
		dDirtPath.level = 1;
		dDirtPath.costGoldBase = 10;
		dDirtPath.manualAdjustment = 0;
		dDirtPath.goldCost = 10;
		dDirtPath.sparkCost = 0;
		dDirtPath.sellable = 0;
		dDirtPath.sellValue = 0;
		dDirtPath.xpEarn = 4;
		dDirtPath.timeToCreate = 0;
		dDirtPath.maxTotalCreation = 1;
		
		// dark ling Tree
		dTree.name = "Decoration";
		dTree.type = "decoration";
		dTree.resourceGen = false;
		dTree.level = 1;
		dTree.costGoldBase = 10;
		dTree.manualAdjustment = 0;
		dTree.goldCost = 10;
		dTree.sparkCost = 0;
		dTree.sellable = 0;
		dTree.sellValue = 0;
		dTree.xpEarn = 4;
		dTree.timeToCreate = 0;
		dTree.maxTotalCreation = 1;
		
		// dark ling Well
		dWell.name = "Decoration";
		dWell.type = "decoration";
		dWell.resourceGen = false;
		dWell.level = 1;
		dWell.costGoldBase = 10;
		dWell.manualAdjustment = 0;
		dWell.goldCost = 10;
		dWell.sparkCost = 0;
		dWell.sellable = 0;
		dWell.sellValue = 0;
		dWell.xpEarn = 4;
		dWell.timeToCreate = 0;
		dWell.maxTotalCreation = 1;
		
		// Hound
		hound.name = "Hound";
		hound.type = "creature";
		hound.resourceGen = false;
		hound.level = 1;
		hound.costGoldBase = 0;
		hound.manualAdjustment = 0;
		hound.goldCost = 0;
		hound.sparkCost = 1;
		hound.sellable = 0;
		hound.sellValue = 0;
		hound.xpEarn = 9;
		hound.timeToCreate = 600;
		hound.maxTotalCreation = 1;
		
		// Barg
		barg.name = "Barg";
		barg.type = "creature";
		barg.resourceGen = false;
		barg.level = 1;
		barg.costGoldBase = 0;
		barg.manualAdjustment = 0;
		barg.goldCost = 0;
		barg.sparkCost = 6;
		barg.sellable = 0;
		barg.sellValue = 0;
		barg.xpEarn = 9;
		barg.timeToCreate = 600;
		barg.maxTotalCreation = 1;
		
		// Leech
		leech.name = "Leech";
		leech.type = "creature";
		leech.resourceGen = false;
		leech.level = 1;
		leech.costGoldBase = 0;
		leech.manualAdjustment = 0;
		leech.goldCost = 0;
		leech.sparkCost = 8;
		leech.sellable = 0;
		leech.sellValue = 0;
		leech.xpEarn = 10;
		leech.timeToCreate = 600;
		leech.maxTotalCreation = 1;
		
		// Plot
		plot.name = "Plot";
		plot.level = 2;
		plot.costGoldBase = 20;
		plot.manualAdjustment = 0;
		plot.goldCost = 20;
		plot.sparkCost = 0;
		plot.sellable = 0;
		plot.sellValue = 0;
		plot.xpEarn = 30;
		plot.timeToCreate = 0;
		plot.maxTotalCreation = 1;
		
		// Turnip
		turnip.name = "Turnip";
		turnip.level = 2;
		turnip.costGoldBase = 20;
		turnip.manualAdjustment = 0;
		turnip.goldCost = 20;
		turnip.sparkCost = 0;
		turnip.sellable = 0;
		turnip.sellValue = 0;
		turnip.xpEarn = 0;
		turnip.timeToCreate = 600;
		turnip.maxTotalCreation = 1;
		
		// Inn
		inn.name = "Inn";
		inn.level = 2;
		inn.costGoldBase = 45;
		inn.manualAdjustment = 0;
		inn.goldCost = 45;
		inn.sparkCost = 0;
		inn.sellable = 0;
		inn.sellValue = 0;
		inn.xpEarn = 80;
		inn.timeToCreate = 600;
		inn.maxTotalCreation = 1;
		
		// darkling Inn
		inn.name = "Inn";
		inn.level = 2;
		inn.costGoldBase = 45;
		inn.manualAdjustment = 0;
		inn.goldCost = 45;
		inn.sparkCost = 0;
		inn.sellable = 0;
		inn.sellValue = 0;
		inn.xpEarn = 80;
		inn.timeToCreate = 600;
		inn.maxTotalCreation = 1;
		
		// Plant Training Ground
		plantTG.name = "PlantTG";
		plantTG.level = 3;
		plantTG.costGoldBase = 0;
		plantTG.manualAdjustment = 0;
		plantTG.goldCost = 0;
		plantTG.sparkCost = 0;
		plantTG.sellable = 0;
		plantTG.sellValue = 0;
		plantTG.xpEarn = 60;
		plantTG.timeToCreate = 0;
		plantTG.maxTotalCreation = 1;
		
		// Sprout
		sprout.name = "Sprout";
		sprout.level = 3;
		sprout.costGoldBase = 0;
		sprout.manualAdjustment = 0;
		sprout.goldCost = 0;
		sprout.sparkCost = 4;
		sprout.sellable = 0;
		sprout.sellValue = 0;
		sprout.xpEarn = 20;
		sprout.timeToCreate = 600;
		sprout.maxTotalCreation = 1;
		
		// Swamp Training Ground
		swampTG.name = "Swamp";
		swampTG.level = 3;
		swampTG.costGoldBase = 0;
		swampTG.manualAdjustment = 0;
		swampTG.goldCost = 25;
		swampTG.sparkCost = 0;
		swampTG.sellable = 0;
		swampTG.sellValue = 0;
		swampTG.xpEarn = 40;
		swampTG.timeToCreate = 0;
		swampTG.maxTotalCreation = 1;
		
		// D Earth Training Ground
		dEarthTG.name = "DEarthTG";
		dEarthTG.level = 3;
		dEarthTG.costGoldBase = 0;
		dEarthTG.manualAdjustment = 0;
		dEarthTG.goldCost = 0;
		dEarthTG.sparkCost = 0;
		dEarthTG.sellable = 0;
		dEarthTG.sellValue = 0;
		dEarthTG.xpEarn = 100;
		dEarthTG.timeToCreate = 0;
		dEarthTG.maxTotalCreation = 1;
		
		// stable
		stable.name = "Stable";
		stable.level = 2;
		stable.costGoldBase = 45;
		stable.manualAdjustment = 0;
		stable.goldCost = 45;
		stable.sparkCost = 0;
		stable.sellable = 0;
		stable.sellValue = 0;
		stable.xpEarn = 80;
		stable.timeToCreate = 600;
		stable.maxTotalCreation = 1;
		
		// dStable
		dStable.name = "DStable";
		dStable.level = 2;
		dStable.costGoldBase = 45;
		dStable.manualAdjustment = 0;
		dStable.goldCost = 45;
		dStable.sparkCost = 0;
		dStable.sellable = 0;
		dStable.sellValue = 0;
		dStable.xpEarn = 80;
		dStable.timeToCreate = 600;
		dStable.maxTotalCreation = 1;
		
		// blackSmith
		blackSmith.name = "BlackSmith";
		blackSmith.level = 2;
		blackSmith.costGoldBase = 45;
		blackSmith.manualAdjustment = 0;
		blackSmith.goldCost = 45;
		blackSmith.sparkCost = 0;
		blackSmith.sellable = 0;
		blackSmith.sellValue = 0;
		blackSmith.xpEarn = 80;
		blackSmith.timeToCreate = 600;
		blackSmith.maxTotalCreation = 1;
		
		// dBlackSmith
		dBlackSmith.name = "DBlackSmith";
		dBlackSmith.level = 2;
		dBlackSmith.costGoldBase = 45;
		dBlackSmith.manualAdjustment = 0;
		dBlackSmith.goldCost = 45;
		dBlackSmith.sparkCost = 0;
		dBlackSmith.sellable = 0;
		dBlackSmith.sellValue = 0;
		dBlackSmith.xpEarn = 80;
		dBlackSmith.timeToCreate = 600;
		dBlackSmith.maxTotalCreation = 1;*/
	}
	
	// Update is called once per frame
	void Update () 
	{	
		/*if (index == 0)
		{
			// Training Ground
			if (transform.gameObject.tag == trainingGround.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + trainingGround.xpEarn;
					GameManager.coins = GameManager.coins - trainingGround.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// water TG
			if (transform.gameObject.tag == waterTG.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + waterTG.xpEarn;
					GameManager.coins = GameManager.coins - waterTG.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// fire TG
			if (transform.gameObject.tag == fireTG.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + fireTG.xpEarn;
					GameManager.coins = GameManager.coins - fireTG.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// D Earth Training Ground
			if (transform.gameObject.tag == dEarthTG.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dEarthTG.xpEarn;
					GameManager.coins = GameManager.coins - dEarthTG.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Dirt Path
			if (transform.gameObject.tag == dirtPath.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dirtPath.xpEarn;
					GameManager.coins = GameManager.coins - dirtPath.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Darkling Dirt Path
			if (transform.gameObject.tag == dDirtPath.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dDirtPath.xpEarn;
					GameManager.coins = GameManager.coins - dDirtPath.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Darkling Tree
			if (transform.gameObject.tag == dTree.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dTree.xpEarn;
					GameManager.coins = GameManager.coins - dTree.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			
			// Hound
			if (transform.gameObject.tag == hound.name)
			{
				objectPlacedBool = true;
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
//					Debug.Log("Hound......................");
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + hound.xpEarn;
					GameManager.sparks = GameManager.sparks - hound.sparkCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
					
					index++;
				}
			}
			
			// Leech
			if (transform.gameObject.tag == leech.name)
			{
				objectPlacedBool = true;
				
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + leech.xpEarn;
					GameManager.sparks = GameManager.sparks - leech.sparkCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
					
					index++;
				}
			}
			
			// Barg
			if (transform.gameObject.tag == barg.name)
			{
				objectPlacedBool = true;
				
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + barg.xpEarn;
					GameManager.sparks = GameManager.sparks - barg.sparkCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
					
					index++;
				}
			}
			
			// plot
			if (transform.gameObject.tag == plot.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + plot.xpEarn;
					GameManager.coins = GameManager.coins - plot.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Turnip
			if (transform.gameObject.tag == turnip.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + turnip.xpEarn;
					GameManager.coins = GameManager.coins - turnip.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Inn
			if (transform.gameObject.tag == inn.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + inn.xpEarn;
					GameManager.coins = GameManager.coins - inn.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// stable
			if (transform.gameObject.tag == stable.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + stable.xpEarn;
					GameManager.coins = GameManager.coins - stable.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// d stable
			if (transform.gameObject.tag ==  dStable.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dStable.xpEarn;
					GameManager.coins = GameManager.coins - dStable.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// black smith
			if (transform.gameObject.tag ==  blackSmith.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + blackSmith.xpEarn;
					GameManager.coins = GameManager.coins - blackSmith.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// d black smith
			if (transform.gameObject.tag ==  dBlackSmith.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dBlackSmith.xpEarn;
					GameManager.coins = GameManager.coins - dBlackSmith.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// dInn
			if (transform.gameObject.tag == dInn.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + dInn.xpEarn;
					GameManager.coins = GameManager.coins - dInn.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Plant Training Ground
			if (transform.gameObject.tag == plantTG.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + plantTG.xpEarn;
					GameManager.coins = GameManager.coins - plantTG.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Swamp Training Ground
			if (transform.gameObject.tag == swampTG.name)
			{
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + swampTG.xpEarn;
					GameManager.coins = GameManager.coins - swampTG.goldCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					
					index++;
				}
			}
			
			// Sprout
			if (transform.gameObject.tag == sprout.name)
			{
				Debug.Log("Sprout.......................");
				if (transform.FindChild("Isometric_Collider").gameObject.tag == "editableObj")
					objectPlacedBool = true;
				
				if (objectPlacedBool)
				{
					objectPlacedBool = false;
					
					GameManager.xp = GameManager.xp + sprout.xpEarn;
					GameManager.sparks = GameManager.sparks - sprout.sparkCost;
					
					guiControlInfo.goldCoinScoreInfo.Text = GameManager.coins.ToString();
					guiControlInfo.sparkScoreInfo.Text = GameManager.sparks.ToString();
					
					index++;
				}
			}
		}*/
		
	}
}
