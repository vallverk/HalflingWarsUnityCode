using UnityEngine;
using System.Collections;

public class taskArray : MonoBehaviour 
{
	//private Inventory inv;
	
	void Start () 
	{
		//inv = (Inventory)FindObjectOfType(typeof(Inventory));
		
		
		Task();
	}
	public void Task()
	{
//		inv.AddItem(t1);
//		inv.AddItem(t2);
//		inv.AddItem(t3);
//		inv.AddItem(t4);
	}
	void OnGUI()
	{
		if(GUI.Button(new Rect(100,100,100,100),"t1"))
		{
			//inv.RemoveItem(t1);
		}
		if(GUI.Button(new Rect(100,200,100,100),"t2"))
		{
			//inv.RemoveItem(t2);
		}
		if(GUI.Button(new Rect(100,300,100,100),"t3"))
		{
			//inv.RemoveItem(t3);
		}
		if(GUI.Button(new Rect(100,400,100,100),"t4"))
		{
			//inv.RemoveItem(t4);
		}
		if(GUI.Button(new Rect(100,500,100,100),"t4"))
		{
//			inv.AddItem(t5);
//			inv.AddItem(t6);
//			inv.AddItem(t7);
//			inv.AddItem(t8);
		}
	}
	void Update () 
	{
		
	}
}
