using UnityEngine;
using System.Collections;

public class findPath : MonoBehaviour 
{
	public bool halfling_Generate;
	
	public GameObject golum_Halfling_Front_HighHammer;
	public GameObject golum_Halfling_Front_Generate;
	public GameObject golum_Halfling_Front_LowHammer;
		
	public bool Halfing_Front_Hammer;
	
	public bool darkling_Generate;
	
	public GameObject golum_Darkling_Front_HighHammer;
	public GameObject golum_Darkling_Front_Generate;
	public GameObject golum_Darkling_Front_LowHammer;
	
	public bool Darking_Front_Hammer;
	
	public void findGolum()
	{
		golum_Halfling_Front_HighHammer = GameObject.Find("Golem_Front_HighHammering");
		golum_Halfling_Front_Generate = GameObject.Find("Golem_Front_Generate");
		golum_Halfling_Front_LowHammer = GameObject.Find("Golem_Front_LowHammering");
		
		golum_Darkling_Front_HighHammer = GameObject.Find("GolemDarkling_Front_HighHammering");
		golum_Darkling_Front_Generate = GameObject.Find("GolemDarkling_Front_Generate");
		golum_Darkling_Front_LowHammer = GameObject.Find("GolemDarkling_Front_LowHammering");
		
		if(halfling_Generate == true)
		{
			golum_Halfling_Front_Generate.gameObject.renderer.enabled = true;
		}
		if(darkling_Generate == true)
		{
			golum_Darkling_Front_Generate.gameObject.renderer.enabled = true;
		}
	}
}
