using UnityEngine;
using System.Collections;

public class invCreatureScroll : MonoBehaviour 
{
	public GameObject cButton;
	public GameObject cInfo;
	public GameObject cCnt;
	
	public GameObject cButtMover;
	public GameObject cInfoMover;
	public GameObject cCntMover;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("inv creature scroll...");
		cButtMover = cButton.transform.FindChild("Mover").gameObject;
		cInfoMover = cInfo.transform.FindChild("Mover").gameObject;
		cCntMover = cCnt.transform.FindChild("Mover").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		cInfoMover.transform.localPosition = new Vector3(cInfoMover.transform.localPosition.x, cButtMover.transform.localPosition.y, cInfoMover.transform.localPosition.z);
		
		cCntMover.transform.localPosition = new Vector3(cCntMover.transform.localPosition.x, cButtMover.transform.localPosition.y, cCntMover.transform.localPosition.z);
	}
}
