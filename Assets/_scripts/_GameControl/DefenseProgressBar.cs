using UnityEngine;
using System.Collections;
using System;

public class DefenseProgressBar : MonoBehaviour {

	public float SecCnt;
	
//	public GameObject oblisk;
	public GameObject defenseParticle;
	private UpgradeTexture scrUpgradeTexture;
		
	void Start () 
	{	
		scrUpgradeTexture = GameObject.Find("GameManager").GetComponent<UpgradeTexture>();
		StartCoroutine(updateSeconds());
		
		ChangeTexture();
	}

	IEnumerator updateSeconds()
	{
		while(true)
		{
			if(SecCnt > 0)
			{
	            SecCnt--;
				//this.gameObject.transform.FindChild("defenceTime").GetComponent<SpriteText>().Text = assignSecToTimeSpan(SecCnt).ToString();
				//this.gameObject.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			else
			{			
				//Destroy(this);
				if(this.gameObject != null)
				{
					//Destroy(this.gameObject.GetComponent<DefenseProgressBar>());
					//if(oblisk != null)
						//Destroy(oblisk);
					if(defenseParticle != null)
						Destroy(defenseParticle);
					
					//Destroy(this.gameObject);
					//this.gameObject.transform.FindChild("defenceTime").gameObject.GetComponent<MeshRenderer>().enabled = false;
					//Debug.Log("Defense time is over");
				}
			}
			
		    yield return new WaitForSeconds(1);
//			Debug.Log("time :::: " + assignSecToTimeSpan(SecCnt));
		}
	}

/*
	IEnumerator updateSeconds()
	{
	if (SecCnt > 0) 
		{
			for (int i=0; i<SecCnt; i++) 
			{
				SecCnt--;

				yield return new WaitForSeconds (1);

			}
		} else 
		{

			if(this.gameObject != null)
			{

				if(defenseParticle != null)
				Destroy(defenseParticle);
				Debug.Log("Defense time is over");
			}

		}
	}
*/
	
	private TimeSpan assignSecToTimeSpan(double sec)
	{
		TimeSpan ts = TimeSpan.FromSeconds(sec);
		return ts;
	}
	
	void ChangeTexture()
	{
		if(transform.gameObject.tag == "Inn")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.InnLevel_1;
		
		else if(transform.gameObject.tag == "Apothecary")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.h_Apothecary;
		
		else if(transform.gameObject.tag == "BlackSmith")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.h_BlackSmith;
		
		else if(transform.gameObject.tag == "Stable")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.h_Stable1;
		
		else if(transform.gameObject.tag == "SunShrine")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.h_SunShrine;
		
		else if(transform.gameObject.tag == "Tavern")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.h_Stable1;
		
		else if(transform.gameObject.tag == "TrainingGround")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.earthTG1;
		
		else if(transform.gameObject.tag == "PlantTG")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.plantTG1;
		
		else if(transform.gameObject.tag == "WaterTG")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.waterTG1;
		
		else if(transform.gameObject.tag == "Plot")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.plotLevel1;
		
		
		
		
		else if(transform.gameObject.tag == "DApothecary")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.d_Apothecary;
		
		else if(transform.gameObject.tag == "DBlackSmith")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.d_BlackSmith;
		
		else if(transform.gameObject.tag == "DInn")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.dInnLevel1;
		
		else if(transform.gameObject.tag == "MoonShrine")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.d_MoonShrine;
		
		else if(transform.gameObject.tag == "DStable")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.d_Stable1;
		
		else if(transform.gameObject.tag == "DTavern")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.d_Tavern;
		
		else if(transform.gameObject.tag == "DEarthTG")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.dEarthTF1;
		
		else if(transform.gameObject.tag == "DFireTG")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.fireTG1;
		
		else if(transform.gameObject.tag == "Swamp")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.swampTG1;
		
		else if(transform.gameObject.tag == "DPlot")
			transform.gameObject.renderer.material.mainTexture = scrUpgradeTexture.plotLevel3;
	}
}
