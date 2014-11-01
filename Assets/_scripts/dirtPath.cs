using UnityEngine;
using System.Collections;

public class dirtPath : MonoBehaviour 
{
	public GameObject dirtPathObj;
	
	public GameObject dirtPathPF;
	
	private Vector3 lastPostion;
	
	// Use this for initialization
	void Start () 
	{
		//lastPostion = dirtPathObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (dirtPathObj == null)
		{
			dirtPathObj = GameObject.Find("HC_D_DirtPath_GO(Clone)") as GameObject;
		//	lastPostion = dirtPathObj.transform.position;
		}
		
		if (Input.GetMouseButtonDown(1))
		{
			GameObject temp = Instantiate(dirtPathPF, lastPostion, Quaternion.Euler(0, 180, 0)) as GameObject;
			temp.transform.position = new Vector3(temp.transform.position.x + 1.46f, temp.transform.position.y, temp.transform.position.z - 0.73f);
			lastPostion = temp.transform.position;
			
			temp.SetActiveRecursively(false);
			temp.active = true;
		}
	
	}
}
