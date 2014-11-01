using UnityEngine;
using System.Collections;

public class HerbViewRight : MonoBehaviour 
{
	public Herb[] herbs;
	
	public Rect viewPosition = new Rect(0,121,86,797);
	public Rect scrollViewPos = new Rect(0,0,90,90);
	public float yMin;
	
	public float dragSpeed = 0.08f;
	
	public bool dragged;
	public bool enableControl;

	public Vector3 lastTouchPos;
	public Vector2 deltaPos;
	public StickMovement scr_StickMovement;
	
	int herbCount;
	float herbSpecing = 15;
	Rect herbPos = new Rect(Screen.width/204.8f,0,Screen.width/13.6534f,Screen.height/10.24f);
	Rect herbCountPos = new Rect(0,0,Screen.width/13.6534f,Screen.height/10.24f);
	Rect herbPosname = new Rect(Screen.width/204.8f,Screen.height/9.0352f,Screen.width/13.6534f,Screen.height/10.24f);
	
	float xFact,yFact;
	
	public GUIStyle style;
	public GUIStyle style1;
	public GUIStyle style2;
	
	public GUIStyle style3;
	public GUIStyle style4;
	public GUIStyle style5;
	
	void Awake()
	{
		scr_StickMovement = GameObject.Find("potionGame(Clone)").gameObject.transform.FindChild("Stick").gameObject.GetComponent<StickMovement>();
	}
	
	void Start () {
		
		herbCount = herbs.Length;
		scrollViewPos.height  = herbCount * herbPos.height + (herbCount-1) * herbSpecing + 5;
		
		yMin = - (scrollViewPos.height - viewPosition.height);
		if(Screen.width == 1536 && Screen.height == 2048)
		{
			xFact = Screen.width / 1536.0f;
			yFact = Screen.height / 2048.0f;
		}
		else
		{
			xFact = Screen.width / 768.0f;
			yFact = Screen.height / 1024.0f;
		}
		foreach(Herb herb in herbs)
			herb.available = true;
	}

	void Update () 
	{
		if(Screen.width == 1536 && Screen.height == 2048)
		{
			viewPosition = new Rect(0,230,172,1240);
			scrollViewPos = new Rect(0,0,172,1240);
		}
		else
		{
			viewPosition = new Rect(0,115,86,620);
			scrollViewPos = new Rect(0,0,86,620);
		}
		enableControl = ControlTouched();

		if(!enableControl) {
			dragged = false;
			deltaPos = Vector3.Lerp(deltaPos, Vector3.zero,dragSpeed);
		}
		else
			GetTouchCord();

		scrollViewPos.y += deltaPos.y;
		scrollViewPos.y = Mathf.Clamp(scrollViewPos.y, yMin, 0);
	}

	bool ControlTouched()
	{
		if(Input.GetMouseButton(0)) {
			
			float x,y;
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			
			if(x > viewPosition.x * xFact && x < (viewPosition.x * xFact + viewPosition.width * xFact) && y > viewPosition.y * yFact && y < (viewPosition.y * yFact + viewPosition.height * yFact)) 
			{
				if(!enableControl)	{// first time cotrol touched
					lastTouchPos = Input.mousePosition;
				}
				return true;
			}
			return false;
		}
		else
			return false;
	}
	
	void GetTouchCord()
	{
		if(Input.touchCount > 0) {
			if(lastTouchPos != Input.mousePosition) {
				dragged = true;
				deltaPos = new Vector2(Input.GetTouch(0).deltaPosition.x,-Input.GetTouch(0).deltaPosition.y);
				lastTouchPos = Input.mousePosition; 
			}
			else
				deltaPos = Vector2.zero;
		}
	}
	
	void OnGUI()
	{
		//GUI.matrix = Matrix4x4.Scale(new Vector3(xFact, yFact, 1.0f));
		GUI.BeginGroup(viewPosition);
		
		// GUI.Box(viewPosition,"hello");
		GUI.BeginGroup(scrollViewPos);
		herbPos.y = 0;
		herbPosname.y = 0;
		herbCountPos.y =0;
		for(int i = 0 ; i < herbCount ; i++)
		{
			if(herbs[i].available) 
			{
				if(GUI.Button(herbPos, herbs[i].image, GUIStyle.none) && !dragged && !StickMovement.Stiring && Beaker.herbCount < 4)
					herbs[i].UseInBeaker();
				
				if(Screen.width == 1536 && Screen.height == 2048)
				{
					GUI.Label(herbPosname, herbs[i].Herb_Name, style3);
					GUI.Label(herbPos,herbs[i].Count,style4);
					
					int HerbType = Beaker.GetHerbsTypeId(herbs[i].Herb_Name); //Harish 
					GUI.Label(herbCountPos,scr_StickMovement.ReturnHerbCount(HerbType).ToString(),style5);
				}
				else
				{
				GUI.Label(herbPosname, herbs[i].Herb_Name, style);
				GUI.Label(herbPos,herbs[i].Count,style1);
				
				int HerbType = Beaker.GetHerbsTypeId(herbs[i].Herb_Name); //Harish 
				GUI.Label(herbCountPos,scr_StickMovement.ReturnHerbCount(HerbType).ToString(),style2);
				}
				
				//Debug.Log("Count 1>>> :" + herbs[i].Herb_Name);
			}
			else
			{
				if(GUI.Button(herbPos,herbs[i].imageDeactive, GUIStyle.none)){}
				if(Screen.width == 1536 && Screen.height == 2048)
				{
					GUI.Label(herbPosname, herbs[i].Herb_Name, style3);
					GUI.Label(herbPos,herbs[i].Count,style4);
				
					int HerbType = Beaker.GetHerbsTypeId(herbs[i].Herb_Name); //Harish 
					GUI.Label(herbCountPos,scr_StickMovement.ReturnHerbCount(HerbType).ToString(),style5);
				}
				else
				{
				GUI.Label(herbPosname, herbs[i].Herb_Name, style);
				GUI.Label(herbPos,herbs[i].Count,style1);
				
				int HerbType = Beaker.GetHerbsTypeId(herbs[i].Herb_Name); //Harish 
				GUI.Label(herbCountPos,scr_StickMovement.ReturnHerbCount(HerbType).ToString(),style2);
				}
				//Debug.Log("Count 2>>> :" + i);
			}	
			herbPos.y += herbPos.height + herbSpecing;
			herbPosname.y += herbPosname.height+herbSpecing;
			herbCountPos.y += herbCountPos.height+herbSpecing;
		}
		
		GUI.EndGroup();
		
		GUI.EndGroup();
		//GUI.matrix = Matrix4x4.Scale(new Vector3(1,1,1));
	}
	
	
	
}