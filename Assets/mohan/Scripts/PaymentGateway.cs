using UnityEngine;
using System.Collections;

public class PaymentGateway : MonoBehaviour 
{
	/*private SfsRemote scr_sfsremote;
	private guiControl guiControlInfo;
	private popUpInformation pi;
	public GameObject storeWall;
	void Start () 
	{
		scr_sfsremote = (SfsRemote)FindObjectOfType(typeof(SfsRemote));
		guiControlInfo = (guiControl)FindObjectOfType(typeof(guiControl));
		pi = (popUpInformation)FindObjectOfType(typeof(popUpInformation));

		var productIdentifiers = new string[] {"product.hwwar.gold.1000","product.hwwar.gold.3000","product.hwwar.gold.9000","product.hwwar.gold.25000","product.hwwar.sparks.10","product.hwwar.sparks.30","product.hwwar.sparks.100","product.hwwar.sparks.250"};

		StoreKitBinding.requestProductData( productIdentifiers );
	}

	void CoinOne() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
		//string productIdentifiers = "product.hwwar.gold.1000";
		//StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.gold.1000" , 1 );
	}

	void CoinTwo() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.gold.3000";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.gold.3000" , 1 );
	}
	
	void CoinThree() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.gold.9000";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.gold.9000" , 1 );
	}
	
	void CoinFour() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.gold.25000";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.gold.25000" , 1 );
	}
	
	void SparkOne() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.sparks.10";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.sparks.10", 1 );
	}
	
	void SparkTwo() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.sparks.30";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.sparks.30", 1 );
	}
	
	void SparkThree() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.sparks.100";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct(  "product.hwwar.sparks.100", 1 );
	}
	
	void SparkFour() 
	{
		storeWall.active = true;
		bool canMakePayments = StoreKitBinding.canMakePayments();
//		string productIdentifiers = "product.hwwar.sparks.250";
//		StoreKitBinding.requestProductData( productIdentifiers );
		StoreKitBinding.purchaseProduct( "product.hwwar.sparks.250", 1 );
	}
	
	void Update () 
	{
		if(StoreKitEventListener.cancledTranstation == true)
		{
			storeWall.active = false;
			StoreKitEventListener.cancledTranstation = false;
		}
		if(StoreKitEventListener.oneThousandCoins == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(0,1000);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.oneThousandCoins = false;
		}

	    if(StoreKitEventListener.theeeThousandCoins == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(0,3000);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.theeeThousandCoins = false;
		}

	    if(StoreKitEventListener.nineThousandCoins == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(0,9000);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.nineThousandCoins = false;
		}

	    if(StoreKitEventListener.twentyFiveThousandCoins == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(0,25000);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.twentyFiveThousandCoins = false;
		}

	    if(StoreKitEventListener.tenSparks == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(10,0);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.tenSparks = false;
		}

	    if(StoreKitEventListener.thirtySparks == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(30,0);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.thirtySparks = false;
		}

	    if(StoreKitEventListener.hunderedSparks == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(100,0);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.hunderedSparks = false;
		}

	    if(StoreKitEventListener.twofiftySparks == true)
		{
			scr_sfsremote.SendRequestforInAppPurchase(250,0);
			storeWall.active = false;
			pi.wall.active = false;
			guiControlInfo.treasureUI.SetActiveRecursively(false);
			StoreKitEventListener.twofiftySparks = false;
		}
	}*/
}
