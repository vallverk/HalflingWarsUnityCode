using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour
{
	public string Name;
	public Category catagory;
	public Herb[] hrbsRequired;
	public int timeToPrepare;
	public Color finalColor;
	
	public float xpMultiFactor = 10;
	public float goldMultiFactor = 0.5f;
	public int rewardXP;
	public int rewardGold;
	
	public void CalculateReward()
	{
		int xp = 0,gold = 0;
		foreach(Herb h in hrbsRequired) {
			xp += h.rewardXP;
			gold += h.rewardGold;
		}
		
		rewardXP = (int)(xp * xpMultiFactor);
		rewardGold = (int)(gold * goldMultiFactor);
	}
	
	public int GetEarnedXP()
	{
		return rewardXP;
	}
	public int GetEarnedGold()
	{
		return rewardGold;
	}
}