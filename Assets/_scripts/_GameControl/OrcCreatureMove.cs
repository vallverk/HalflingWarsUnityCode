using UnityEngine;
using System.Collections;

public class OrcCreatureMove : MonoBehaviour 
{
	public GameObject caveCreature, attackedBuilding;
	public Vector3 target;

	private GameObject cave;
	public float speed;
	
	
	void Start () 
	{
		speed = 1.8f;
		if(caveCreature != null)
		{
			cave = caveCreature.transform.parent.gameObject;
//			Debug.Log("cave : "+cave.name);
		}
	}
	
	void Update () 
	{
		//caveCreature.transform.Translate(target * speed * Time.deltaTime);
		if(caveCreature != null)
		{
			caveCreature.transform.renderer.enabled = false;
			if(attackedBuilding.transform.localPosition.x > cave.transform.localPosition.x)
				caveCreature.transform.localScale = new Vector3(1.111111f, 1.111111f, 1.666667f);
			else if(attackedBuilding.transform.localPosition.x < cave.transform.localPosition.x)
				caveCreature.transform.localScale = new Vector3(-1.111111f, 1.111111f, 1.666667f);
			
			caveCreature.transform.position =  Vector3.MoveTowards(caveCreature.transform.position , target, speed * Time.deltaTime);
			//caveCreature.transform.LookAt(target);
			//caveCreature.transform.position = Vector3.Lerp(caveCreature.transform.position, target, speed * Time.deltaTime);
		}
		else if(caveCreature == null)
			Destroy(this);
		
		if(attackedBuilding != null)
		{
			// ----- if attacked building is garden plot -----//
			if((attackedBuilding.gameObject.tag == "Plot") || (attackedBuilding.gameObject.tag == "DPlot"))			
			{
				StopCreatureMovement(4f);
			}
			// ----- if attacked building is training ground -----//
			else if((attackedBuilding.gameObject.tag == "TrainingGround") || (attackedBuilding.gameObject.tag == "PlantTG") || (attackedBuilding.gameObject.tag == "WaterTG")
					|| (attackedBuilding.gameObject.tag == "Swamp")	|| (attackedBuilding.gameObject.tag == "DFireTG") || (attackedBuilding.gameObject.tag == "DEarthTG"))			
			{
				StopCreatureMovement(8.5f);
			}
			// ----- if attacked building is building -----//
			else																							
			{
				StopCreatureMovement(5f);
			}
		}
	}
	


	void StopCreatureMovement(float distance)
	{
		if(Vector3.Distance(caveCreature.transform.position , target) <= distance)
		{
			Debug.Log("Display timer of : "+attackedBuilding.gameObject.name);
			Destroy(this);
			
			GameObject healthBar = attackedBuilding.transform.FindChild("HealthProgressBar").gameObject;

			HealthProgressBar scrHP = attackedBuilding.GetComponent<HealthProgressBar>() as HealthProgressBar;
			if (scrHP != null)
				scrHP.createOrcEffect();
			//attackedBuilding.GetComponent<HealthProgressBar>().createOrcEffect();
			healthBar.transform.FindChild("ProgressBarPlate").renderer.enabled = true;
			healthBar.transform.FindChild("RemainTime").renderer.enabled = true;
			healthBar.transform.FindChild("ProgressBarPov").gameObject.transform.FindChild("Plane").renderer.enabled = true;	
			
			caveCreature.transform.renderer.enabled = false;									
			caveCreature.transform.FindChild("Walk_anim").renderer.enabled = false;
			caveCreature.transform.FindChild("attack_anim").renderer.enabled = true;			//Enable attack animation
			if(caveCreature.transform.FindChild("LessAgg1_anim") != null)
				caveCreature.transform.FindChild("LessAgg1_anim").renderer.enabled = false;
			if(caveCreature.transform.FindChild("LessAgg2_anim") != null)
				caveCreature.transform.FindChild("LessAgg2_anim").renderer.enabled = false;
			caveCreature.transform.position = new Vector3(caveCreature.transform.position.x, 1, caveCreature.transform.position.z);
			
			DestroyClientRunningTask();
		}
	}
	
	void DestroyClientRunningTask()		//Stop food grow task... stop building constructing task.... stop training ground creature growing task
	{
		foreach(Transform child in attackedBuilding.transform)
		{	
			string childGameObject = child.name;
			string [] splitName = childGameObject.Split('_');
			
			foreach(string childList in splitName)
			{
//				Debug.Log("Tag : "+child.gameObject.tag);
				//Stop garden plot farming 
				if(childList == "P")
				{
					Debug.Log("Stop farming >>>>>>> "+child.name);
					GameObject farming = GameObject.Find(child.name);
				
					if(farming != null)
						Destroy(farming);
				}
				
				if (childList == "C")
				{
//					Debug.Log("1 -----------> " + child.name);
					progressBar pb = child.GetComponent<progressBar>();
					if (pb != null)
					{
						if (pb.enabled == true)
						{
							GameObject tgObj = child.transform.root.gameObject;
//							Debug.Log("2 -------------------> " + tgObj.gameObject.name);
							if (tgObj != null)
							{
//								Debug.Log("3 -------------------> " + tgObj.gameObject.name);
								tgObj.transform.FindChild("Spark1").gameObject.GetComponent<MeshRenderer>().enabled = false;
								tgObj.transform.FindChild("Spark2").gameObject.GetComponent<MeshRenderer>().enabled = false;
							}
							Destroy(child.gameObject);
						}
					}
				}
			}
		}
	}
}
