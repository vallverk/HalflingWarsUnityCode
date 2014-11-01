using UnityEngine;
using System.Collections;

public class ObjectStatus : MonoBehaviour 
{
	public int currentUpgradeLevel = 1;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	// level upgrade
	public void levelUpgrade()
	{
		currentUpgradeLevel++;
	}
	
	public void showCurrentUpgradeLevel()
	{
		Debug.Log("-----> " + transform.gameObject.name + " <-----> " + " current Level -----> " + currentUpgradeLevel);
	}
}
