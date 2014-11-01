using UnityEngine;
using System.Collections;

public class itemBagPanelControl : MonoBehaviour 
{

	public Vector3 startPos = new Vector3(-40, 0, -26.5f);
	public Vector3 endPos = new Vector3(-40, 0, -33.5f);
	public float speed;
		
	private int curTime = 0;
	private float oldTime = 0;
	
	public bool panelMoveIn = false;
	public bool panelMoveOut = false;
	
	void Awake()
	{
		panelMoveIn = true;
		//panelMoveOut = true;
	}
	
	// Use this for initialization
	void Start () 
	{
		oldTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkIdleState();
		
		if (panelMoveOut)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * speed);
		}
		if (panelMoveIn)
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, Time.deltaTime * speed);
		}
	}
	
	void checkIdleState()
	{
		curTime = (int)(Time.time - oldTime);

		if (Input.GetMouseButtonDown(0))
		{
			oldTime = Time.time;
		}
		
		if (curTime > 5)
		{
			panelMoveIn = true;
			panelMoveOut = false;
		}
	}
}
