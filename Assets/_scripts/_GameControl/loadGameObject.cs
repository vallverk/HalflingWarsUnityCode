using UnityEngine;
using System.Collections;

public class loadGameObject : MonoBehaviour 
{
	//private Transform

	public Transform[] goSpwan = new Transform[9];
	public Transform[] dCaveSpwan = new Transform[9];
	public GameObject house_pref, goblinCamp_pref, trollHouse_pref, orgCave_pref, darklingHouse_pref;
	public GameObject halflingSpwan, darklingSpwan, halflingChar_pref, darklingChar_pref;
	
	private int index = 0;
	// Use this for initialization
//	void Awake () 
//	{
//		GameObject halflingChar = Instantiate(halflingChar_pref, halflingSpwan.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		GameObject darklingChar = Instantiate(darklingChar_pref, new Vector3(67, darklingSpwan.transform.position.y, 3), Quaternion.Euler(0, 180, 0)) as GameObject;
//		
//		GameObject go1 = Instantiate(house_pref, goSpwan[0].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go1.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		//go1.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		
//		// goblin camp 01
//		GameObject go2 = Instantiate(goblinCamp_pref, goSpwan[1].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go2.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go2.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go2.name = go2.name + "_01";
//		
//		// goblin camp 03
//		GameObject go3 = Instantiate(goblinCamp_pref, goSpwan[2].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go3.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go3.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go3.name = go3.name + "_03";
//		
//		// goblin camp 02
//		GameObject go4 = Instantiate(goblinCamp_pref, goSpwan[3].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go4.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go4.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go4.name = go4.name + "_02";
//		
//		// org cave 02
//		GameObject go5 = Instantiate(orgCave_pref, goSpwan[4].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go5.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go5.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go5.name = go5.name + "_02";
//		
//		// org cave 03
//		GameObject go6 = Instantiate(orgCave_pref, goSpwan[5].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go6.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go6.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go6.name = go6.name + "_03";
//		
//		// org cave 01
//		GameObject go7 = Instantiate(orgCave_pref, goSpwan[6].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go7.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go7.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		go7.name = go7.name + "_01";
//		
//		// troll cave 03
//		GameObject go8 = Instantiate(trollHouse_pref, goSpwan[7].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go8.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go8.name = go8.name + "_03";
//		
//		// troll cave 02
//		GameObject go9 = Instantiate(trollHouse_pref, goSpwan[8].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go9.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go9.name = go9.name + "_02";
//		
//		// troll cave 01
//		GameObject go10 = Instantiate(trollHouse_pref, goSpwan[9].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		go10.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		go10.name = go10.name + "_01";
//		
//		// Darkling Cave
//		
//		// goblin camp 01
//		GameObject dGo1 = Instantiate(goblinCamp_pref, dCaveSpwan[0].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo1.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo1.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo1.name = dGo1.name + "_D_01";
//		
//		// goblin camp 03
//		GameObject dGo2 = Instantiate(goblinCamp_pref, dCaveSpwan[1].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo2.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo2.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo2.name = dGo2.name + "_D_03";
//		
//		// goblin camp 02
//		GameObject dGo3 = Instantiate(goblinCamp_pref, dCaveSpwan[2].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo3.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo3.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo3.name = dGo3.name + "_D_02";
//		
//		// troll cave 03
//		GameObject dGo4 = Instantiate(trollHouse_pref, dCaveSpwan[6].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo4.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		//dGo4.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo4.name = dGo4.name + "_D_03";
//		
//		// troll cave 02
//		GameObject dGo5 = Instantiate(trollHouse_pref, dCaveSpwan[7].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo5.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		//dGo5.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo5.name = dGo5.name + "_D_02";
//		
//		// troll cave 01
//		GameObject dGo6 = Instantiate(trollHouse_pref, dCaveSpwan[8].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo6.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		//dGo6.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo6.name = dGo6.name + "_D_01";
//		
//		// org cave 02
//		GameObject dGo7 = Instantiate(orgCave_pref, dCaveSpwan[3].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo7.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo7.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo7.name = dGo7.name + "_D_02";
//		
//		// org cave 03
//		GameObject dGo8 = Instantiate(orgCave_pref, dCaveSpwan[4].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo8.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo8.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo8.name = dGo8.name + "_D_03";
//		
//		// org cave 01
//		GameObject dGo9 = Instantiate(orgCave_pref, dCaveSpwan[5].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo9.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		dGo9.transform.FindChild("RabbtiButton").gameObject.SetActiveRecursively(false);
//		dGo9.name = dGo9.name + "_D_01";
//		
//		GameObject dGo10 = Instantiate(darklingHouse_pref, dCaveSpwan[9].position, Quaternion.Euler(0, 180, 0)) as GameObject;
//		dGo10.transform.FindChild("ProgressBar").gameObject.SetActiveRecursively(false);
//		
//	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
