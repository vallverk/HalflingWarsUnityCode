using UnityEngine;
using System.Collections;

public class Herb : MonoBehaviour {

	public Category HerbCatagory;
	public string Herb_Name;
	public bool available;
	public Texture2D image;
	public Texture2D imageDeactive;
	public Texture2D Count;
	
	public int rewardXP;
	public int rewardGold;
	
	void Start () {
	
		 available = true;
	}
	
	public void  UseInBeaker() 
	{
		GameObject.Find("Stick").SendMessage("FillHerb",this);
		available = false;
	}
}

public enum Category
{
	Earth,
	DarkEarth,
	Fire,
	Plant,
	Swamp,
	Water
}
