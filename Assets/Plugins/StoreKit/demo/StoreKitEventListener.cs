using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StoreKitEventListener : MonoBehaviour
{
	public static bool oneThousandCoins;
	public static bool theeeThousandCoins;
	public static bool nineThousandCoins;
	public static bool twentyFiveThousandCoins;
	public static bool tenSparks;
	public static bool thirtySparks;
	public static bool hunderedSparks;
	public static bool twofiftySparks;
	public static bool cancledTranstation;
#if UNITY_IPHONE
	void OnEnable()
	{
		// Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
		StoreKitManager.productPurchaseAwaitingConfirmationEvent += productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
		StoreKitManager.purchaseFailedEvent += purchaseFailed;
		StoreKitManager.productListReceivedEvent += productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent += productListRequestFailed;
		StoreKitManager.restoreTransactionsFailedEvent += restoreTransactionsFailed;
		StoreKitManager.restoreTransactionsFinishedEvent += restoreTransactionsFinished;
		StoreKitManager.paymentQueueUpdatedDownloadsEvent += paymentQueueUpdatedDownloadsEvent;
	}
	
	
	void OnDisable()
	{
		// Remove all the event handlers
		StoreKitManager.productPurchaseAwaitingConfirmationEvent -= productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
		StoreKitManager.purchaseFailedEvent -= purchaseFailed;
		StoreKitManager.productListReceivedEvent -= productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent -= productListRequestFailed;
		StoreKitManager.restoreTransactionsFailedEvent -= restoreTransactionsFailed;
		StoreKitManager.restoreTransactionsFinishedEvent -= restoreTransactionsFinished;
		StoreKitManager.paymentQueueUpdatedDownloadsEvent -= paymentQueueUpdatedDownloadsEvent;
	}
	
	
	void productListReceivedEvent( List<StoreKitProduct> productList )
	{
		Debug.Log( "productListReceivedEvent. total products received: " + productList.Count );
		
		// print the products to the console
		foreach( StoreKitProduct product in productList )
			Debug.Log( product.ToString() + "\n" );
	}
	
	
	void productListRequestFailed( string error )
	{
		Debug.Log( "productListRequestFailed: " + error );
		cancledTranstation = true;
	}
	

	void purchaseFailed( string error )
	{
		Debug.Log( "purchase failed with error: " + error );
		cancledTranstation = true;
	}
	

	void purchaseCancelled( string error )
	{
		Debug.Log( "purchase cancelled with error: " + error );
		cancledTranstation = true;
	}
	
	
	void productPurchaseAwaitingConfirmationEvent( StoreKitTransaction transaction )
	{
		Debug.Log( "productPurchaseAwaitingConfirmationEvent: " + transaction );
	}
	
	
	void purchaseSuccessful( StoreKitTransaction transaction )
	{
		Debug.Log( "purchased product: " + transaction );

		if(transaction.productIdentifier == "product.hwwar.gold.1000")
		{
			oneThousandCoins = true;
		}
		if(transaction.productIdentifier == "product.hwwar.gold.3000")
		{
			theeeThousandCoins = true;
		}
		if(transaction.productIdentifier == "product.hwwar.gold.9000")
		{
			nineThousandCoins = true;
		}
		if(transaction.productIdentifier == "product.hwwar.gold.25000")
		{
			twentyFiveThousandCoins = true;
		}
		if(transaction.productIdentifier == "product.hwwar.sparks.10")
		{
			tenSparks = true;
		}
		if(transaction.productIdentifier == "product.hwwar.sparks.30")
		{
			thirtySparks = true;
		}
		if(transaction.productIdentifier == "product.hwwar.sparks.100")
		{
			hunderedSparks = true;
		}
		if(transaction.productIdentifier == "product.hwwar.sparks.250")
		{
			twofiftySparks = true;
		}
	}
	
	
	void restoreTransactionsFailed( string error )
	{
		Debug.Log( "restoreTransactionsFailed: " + error );
		cancledTranstation = true;
	}
	
	
	void restoreTransactionsFinished()
	{
		Debug.Log( "restoreTransactionsFinished" );
	}
	
	
	void paymentQueueUpdatedDownloadsEvent( List<StoreKitDownload> downloads )
	{
		Debug.Log( "paymentQueueUpdatedDownloadsEvent: " );
		foreach( var dl in downloads )
			Debug.Log( dl );
	}
	
#endif
}

