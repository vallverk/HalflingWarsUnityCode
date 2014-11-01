using UnityEngine;
using System.Collections;

public class Sensors : MonoBehaviour 
{
	public static bool sensorWorkBool = true;
	
	public Transform sensor1, sensor2, sensor3, sensor4, sensor5, sensor6, sensor7, sensor8, 
						sensor9, sensor10, sensor11, sensor12, sensor13, sensor14, sensor15, sensor16, 
						sensor17, sensor18, sensor19, sensor20, sensor21, sensor22, sensor23, sensor24, 
						sensor25, sensor26, sensor27, sensor28, sensor29, sensor30, sensor31, sensor32,
						sensor33, sensor34, sensor35, sensor36, sensor37, sensor38, sensor39, sensor40,
						sensor41, sensor42, sensor43, sensor44, sensor45, sensor46, sensor47, sensor48,
						sensor49, sensor50, sensor51, sensor52, sensor53, sensor54, sensor55, sensor56,
						sensor57, sensor58, sensor59, sensor60, sensor61, sensor62, sensor63, sensor64;
		
	public GameObject greenPatch, redPatch;
	
	RaycastHit hit1, hit2, hit3, hit4, hit5, hit6, hit7, hit8, 
				hit9, hit10, hit11, hit12, hit13, hit14, hit15, hit16, 
				hit17, hit18, hit19, hit20, hit21, hit22, hit23, hit24, 
				hit25, hit26, hit27, hit28, hit29, hit30, hit31, hit32,
				hit33, hit34, hit35, hit36, hit37, hit38, hit39, hit40,
				hit41, hit42, hit43, hit44, hit45, hit46, hit47, hit48,
				hit49, hit50, hit51, hit52, hit53, hit54, hit55, hit56,
				hit57, hit58, hit59, hit60, hit61, hit62, hit63, hit64;
	
	private MeshRenderer curCavePatch;
	
	private int index = 0;
	
	GameObject[] cavePatch = new GameObject[18];
	
	private string curString = "";
	private bool activeBool = true;
	
	// Use this for initialization
	void Start () 
	{
		string objectName = transform.gameObject.name.ToString();
		string[] worlds = objectName.Split('_');
		//Debug.Log("world :: " + worlds.Length + " --- " + worlds[0] + " --- " + worlds[1]);
		curString = worlds[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
//		Debug.DrawRay(sensor1.position, sensor1.TransformDirection(Vector3.forward * 2), Color.red);
//		Debug.DrawRay(sensor2.position, sensor2.TransformDirection(Vector3.forward * 2), Color.red);
//	Debug.Log(hit1.collider.gameObject.name + " ===================");
		if (sensorWorkBool)
		{
			if (Physics.Raycast(sensor1.position, sensor1.TransformDirection(Vector3.forward), out hit1, 2)){}
			if (Physics.Raycast(sensor2.position, sensor2.TransformDirection(Vector3.forward), out hit2, 2)){}
			if (Physics.Raycast(sensor3.position, sensor3.TransformDirection(Vector3.forward), out hit3, 2)){}
			if (Physics.Raycast(sensor4.position, sensor4.TransformDirection(Vector3.forward), out hit4, 2)){}
			if (Physics.Raycast(sensor5.position, sensor5.TransformDirection(Vector3.forward), out hit5, 2)){}
			if (Physics.Raycast(sensor6.position, sensor6.TransformDirection(Vector3.forward), out hit6, 2)){}
			if (Physics.Raycast(sensor7.position, sensor7.TransformDirection(Vector3.forward), out hit7, 2)){}
			if (Physics.Raycast(sensor8.position, sensor8.TransformDirection(Vector3.forward), out hit8, 2)){}
			if (Physics.Raycast(sensor9.position, sensor9.TransformDirection(Vector3.forward), out hit9, 2)){}
			if (Physics.Raycast(sensor10.position, sensor10.TransformDirection(Vector3.forward), out hit10, 2)){}
			if (Physics.Raycast(sensor11.position, sensor11.TransformDirection(Vector3.forward), out hit11, 2)){}
			if (Physics.Raycast(sensor12.position, sensor12.TransformDirection(Vector3.forward), out hit12, 2)){}
			if (Physics.Raycast(sensor13.position, sensor13.TransformDirection(Vector3.forward), out hit13, 2)){}
			if (Physics.Raycast(sensor14.position, sensor14.TransformDirection(Vector3.forward), out hit14, 2)){}
			if (Physics.Raycast(sensor15.position, sensor15.TransformDirection(Vector3.forward), out hit15, 2)){}
			if (Physics.Raycast(sensor16.position, sensor16.TransformDirection(Vector3.forward), out hit16, 2)){}
			if (Physics.Raycast(sensor17.position, sensor17.TransformDirection(Vector3.forward), out hit17, 2)){}
			if (Physics.Raycast(sensor18.position, sensor18.TransformDirection(Vector3.forward), out hit18, 2)){}
			if (Physics.Raycast(sensor19.position, sensor19.TransformDirection(Vector3.forward), out hit19, 2)){}
			if (Physics.Raycast(sensor20.position, sensor20.TransformDirection(Vector3.forward), out hit20, 2)){}
			if (Physics.Raycast(sensor21.position, sensor21.TransformDirection(Vector3.forward), out hit21, 2)){}
			if (Physics.Raycast(sensor22.position, sensor22.TransformDirection(Vector3.forward), out hit22, 2)){}
			if (Physics.Raycast(sensor23.position, sensor23.TransformDirection(Vector3.forward), out hit23, 2)){}
			if (Physics.Raycast(sensor24.position, sensor24.TransformDirection(Vector3.forward), out hit24, 2)){}
			if (Physics.Raycast(sensor25.position, sensor25.TransformDirection(Vector3.forward), out hit25, 2)){}
			if (Physics.Raycast(sensor26.position, sensor26.TransformDirection(Vector3.forward), out hit26, 2)){}
			if (Physics.Raycast(sensor27.position, sensor27.TransformDirection(Vector3.forward), out hit27, 2)){}
			if (Physics.Raycast(sensor28.position, sensor28.TransformDirection(Vector3.forward), out hit28, 2)){}
			if (Physics.Raycast(sensor29.position, sensor29.TransformDirection(Vector3.forward), out hit29, 2)){}
			if (Physics.Raycast(sensor30.position, sensor30.TransformDirection(Vector3.forward), out hit30, 2)){}
			if (Physics.Raycast(sensor31.position, sensor31.TransformDirection(Vector3.forward), out hit31, 2)){}
			if (Physics.Raycast(sensor32.position, sensor32.TransformDirection(Vector3.forward), out hit32, 2)){}
			if (Physics.Raycast(sensor33.position, sensor33.TransformDirection(Vector3.forward), out hit33, 2)){}
			if (Physics.Raycast(sensor34.position, sensor34.TransformDirection(Vector3.forward), out hit34, 2)){}
			if (Physics.Raycast(sensor35.position, sensor35.TransformDirection(Vector3.forward), out hit35, 2)){}
			if (Physics.Raycast(sensor36.position, sensor36.TransformDirection(Vector3.forward), out hit36, 2)){}
			if (Physics.Raycast(sensor37.position, sensor37.TransformDirection(Vector3.forward), out hit37, 2)){}
			if (Physics.Raycast(sensor38.position, sensor38.TransformDirection(Vector3.forward), out hit38, 2)){}
			if (Physics.Raycast(sensor39.position, sensor39.TransformDirection(Vector3.forward), out hit39, 2)){}
			if (Physics.Raycast(sensor40.position, sensor40.TransformDirection(Vector3.forward), out hit40, 2)){}
			if (Physics.Raycast(sensor41.position, sensor41.TransformDirection(Vector3.forward), out hit41, 2)){}
			if (Physics.Raycast(sensor42.position, sensor42.TransformDirection(Vector3.forward), out hit42, 2)){}
			if (Physics.Raycast(sensor43.position, sensor43.TransformDirection(Vector3.forward), out hit43, 2)){}
			if (Physics.Raycast(sensor44.position, sensor44.TransformDirection(Vector3.forward), out hit44, 2)){}
			if (Physics.Raycast(sensor45.position, sensor45.TransformDirection(Vector3.forward), out hit45, 2)){}
			if (Physics.Raycast(sensor46.position, sensor46.TransformDirection(Vector3.forward), out hit46, 2)){}
			if (Physics.Raycast(sensor47.position, sensor47.TransformDirection(Vector3.forward), out hit47, 2)){}
			if (Physics.Raycast(sensor48.position, sensor48.TransformDirection(Vector3.forward), out hit48, 2)){}
			if (Physics.Raycast(sensor49.position, sensor49.TransformDirection(Vector3.forward), out hit49, 2)){}
			if (Physics.Raycast(sensor50.position, sensor50.TransformDirection(Vector3.forward), out hit50, 2)){}
			if (Physics.Raycast(sensor51.position, sensor51.TransformDirection(Vector3.forward), out hit51, 2)){}
			if (Physics.Raycast(sensor52.position, sensor52.TransformDirection(Vector3.forward), out hit52, 2)){}
			if (Physics.Raycast(sensor53.position, sensor53.TransformDirection(Vector3.forward), out hit53, 2)){}
			if (Physics.Raycast(sensor54.position, sensor54.TransformDirection(Vector3.forward), out hit54, 2)){}
			if (Physics.Raycast(sensor55.position, sensor55.TransformDirection(Vector3.forward), out hit55, 2)){}
			if (Physics.Raycast(sensor56.position, sensor56.TransformDirection(Vector3.forward), out hit56, 2)){}
			if (Physics.Raycast(sensor57.position, sensor57.TransformDirection(Vector3.forward), out hit57, 2)){}
			if (Physics.Raycast(sensor58.position, sensor58.TransformDirection(Vector3.forward), out hit58, 2)){}
			if (Physics.Raycast(sensor59.position, sensor59.TransformDirection(Vector3.forward), out hit59, 2)){}
			if (Physics.Raycast(sensor60.position, sensor60.TransformDirection(Vector3.forward), out hit60, 2)){}
			if (Physics.Raycast(sensor61.position, sensor61.TransformDirection(Vector3.forward), out hit61, 2)){}
			if (Physics.Raycast(sensor62.position, sensor62.TransformDirection(Vector3.forward), out hit62, 2)){}
			if (Physics.Raycast(sensor63.position, sensor63.TransformDirection(Vector3.forward), out hit63, 2)){}
			if (Physics.Raycast(sensor64.position, sensor64.TransformDirection(Vector3.forward), out hit64, 2)){}
			
			if (hit1.collider.gameObject == null) return;	if (hit2.collider.gameObject == null) return;
			if (hit3.collider.gameObject == null) return;	if (hit4.collider.gameObject == null) return;
			if (hit5.collider.gameObject == null) return;	if (hit6.collider.gameObject == null) return;
			if (hit7.collider.gameObject == null) return;	if (hit8.collider.gameObject == null) return;
			if (hit9.collider.gameObject == null) return;	if (hit10.collider.gameObject == null) return;
			if (hit11.collider.gameObject == null) return;	if (hit12.collider.gameObject == null) return;
			if (hit13.collider.gameObject == null) return;	if (hit14.collider.gameObject == null) return;
			if (hit15.collider.gameObject == null) return;	if (hit16.collider.gameObject == null) return;
			if (hit17.collider.gameObject == null) return;	if (hit18.collider.gameObject == null) return;
			if (hit19.collider.gameObject == null) return;	if (hit20.collider.gameObject == null) return;
			if (hit21.collider.gameObject == null) return;	if (hit22.collider.gameObject == null) return;
			if (hit23.collider.gameObject == null) return;	if (hit24.collider.gameObject == null) return;
			if (hit25.collider.gameObject == null) return;	if (hit26.collider.gameObject == null) return;
			if (hit27.collider.gameObject == null) return;	if (hit28.collider.gameObject == null) return;
			if (hit29.collider.gameObject == null) return;	if (hit30.collider.gameObject == null) return;
			if (hit31.collider.gameObject == null) return;	if (hit32.collider.gameObject == null) return;
			if (hit33.collider.gameObject == null) return;	if (hit34.collider.gameObject == null) return;
			if (hit35.collider.gameObject == null) return;	if (hit36.collider.gameObject == null) return;
			if (hit37.collider.gameObject == null) return;	if (hit38.collider.gameObject == null) return;
			if (hit39.collider.gameObject == null) return;	if (hit40.collider.gameObject == null) return;
			if (hit41.collider.gameObject == null) return;	if (hit42.collider.gameObject == null) return;
			if (hit43.collider.gameObject == null) return;	if (hit44.collider.gameObject == null) return;
			if (hit45.collider.gameObject == null) return;	if (hit46.collider.gameObject == null) return;
			if (hit47.collider.gameObject == null) return;	if (hit48.collider.gameObject == null) return;
			if (hit49.collider.gameObject == null) return;	if (hit50.collider.gameObject == null) return;
			if (hit51.collider.gameObject == null) return;	if (hit52.collider.gameObject == null) return;
			if (hit53.collider.gameObject == null) return;	if (hit54.collider.gameObject == null) return;
			if (hit55.collider.gameObject == null) return;	if (hit56.collider.gameObject == null) return;
			if (hit57.collider.gameObject == null) return;	if (hit58.collider.gameObject == null) return;
			if (hit59.collider.gameObject == null) return;	if (hit60.collider.gameObject == null) return;
			if (hit61.collider.gameObject == null) return;	if (hit62.collider.gameObject == null) return;
			if (hit63.collider.gameObject == null) return;	if (hit64.collider.gameObject == null) return;
			
			
						 
			if ((hit1.collider.gameObject.tag == "movableObj" || hit1.collider.gameObject.tag == "editableObj" || hit1.collider.gameObject.tag == "nonMovableObj" || hit1.collider.gameObject.tag == "using" || hit1.collider.gameObject.tag == "working" || hit1.collider.gameObject.tag == "Dworking" || hit1.collider.gameObject.tag == "attack") ||
				(hit2.collider.gameObject.tag == "movableObj" || hit2.collider.gameObject.tag == "editableObj" || hit2.collider.gameObject.tag == "nonMovableObj" || hit2.collider.gameObject.tag == "using" || hit2.collider.gameObject.tag == "working" || hit2.collider.gameObject.tag == "Dworking" || hit2.collider.gameObject.tag == "attack") ||
				(hit3.collider.gameObject.tag == "movableObj" || hit3.collider.gameObject.tag == "editableObj" || hit3.collider.gameObject.tag == "nonMovableObj" || hit3.collider.gameObject.tag == "using" || hit3.collider.gameObject.tag == "working" || hit3.collider.gameObject.tag == "Dworking" || hit3.collider.gameObject.tag == "attack") ||
				(hit4.collider.gameObject.tag == "movableObj" || hit4.collider.gameObject.tag == "editableObj" || hit4.collider.gameObject.tag == "nonMovableObj" || hit4.collider.gameObject.tag == "using" || hit4.collider.gameObject.tag == "working" || hit4.collider.gameObject.tag == "Dworking" || hit4.collider.gameObject.tag == "attack") ||
				(hit5.collider.gameObject.tag == "movableObj" || hit5.collider.gameObject.tag == "editableObj" || hit5.collider.gameObject.tag == "nonMovableObj" || hit5.collider.gameObject.tag == "using" || hit5.collider.gameObject.tag == "working" || hit5.collider.gameObject.tag == "Dworking" || hit5.collider.gameObject.tag == "attack") ||
				(hit6.collider.gameObject.tag == "movableObj" || hit6.collider.gameObject.tag == "editableObj" || hit6.collider.gameObject.tag == "nonMovableObj" || hit6.collider.gameObject.tag == "using" || hit6.collider.gameObject.tag == "working" || hit6.collider.gameObject.tag == "Dworking" || hit6.collider.gameObject.tag == "attack") ||
				(hit7.collider.gameObject.tag == "movableObj" || hit7.collider.gameObject.tag == "editableObj" || hit7.collider.gameObject.tag == "nonMovableObj" || hit7.collider.gameObject.tag == "using" || hit7.collider.gameObject.tag == "working" || hit7.collider.gameObject.tag == "Dworking" || hit7.collider.gameObject.tag == "attack") ||
				(hit8.collider.gameObject.tag == "movableObj" || hit8.collider.gameObject.tag == "editableObj" || hit8.collider.gameObject.tag == "nonMovableObj" || hit8.collider.gameObject.tag == "using" || hit8.collider.gameObject.tag == "working" || hit8.collider.gameObject.tag == "Dworking" || hit8.collider.gameObject.tag == "attack") ||
				(hit9.collider.gameObject.tag == "movableObj" || hit9.collider.gameObject.tag == "editableObj" || hit9.collider.gameObject.tag == "nonMovableObj" || hit9.collider.gameObject.tag == "using" || hit9.collider.gameObject.tag == "working" || hit9.collider.gameObject.tag == "Dworking" || hit9.collider.gameObject.tag == "attack") ||
				(hit10.collider.gameObject.tag == "movableObj" || hit10.collider.gameObject.tag == "editableObj" || hit10.collider.gameObject.tag == "nonMovableObj" || hit10.collider.gameObject.tag == "using" || hit10.collider.gameObject.tag == "working" || hit10.collider.gameObject.tag == "Dworking" || hit10.collider.gameObject.tag == "attack") ||
				(hit11.collider.gameObject.tag == "movableObj" || hit11.collider.gameObject.tag == "editableObj" || hit11.collider.gameObject.tag == "nonMovableObj" || hit11.collider.gameObject.tag == "using" || hit11.collider.gameObject.tag == "working" || hit11.collider.gameObject.tag == "Dworking" || hit11.collider.gameObject.tag == "attack") ||
				(hit12.collider.gameObject.tag == "movableObj" || hit12.collider.gameObject.tag == "editableObj" || hit12.collider.gameObject.tag == "nonMovableObj" || hit12.collider.gameObject.tag == "using" || hit12.collider.gameObject.tag == "working" || hit12.collider.gameObject.tag == "Dworking" || hit12.collider.gameObject.tag == "attack") ||
				(hit13.collider.gameObject.tag == "movableObj" || hit13.collider.gameObject.tag == "editableObj" || hit13.collider.gameObject.tag == "nonMovableObj" || hit13.collider.gameObject.tag == "using" || hit13.collider.gameObject.tag == "working" || hit13.collider.gameObject.tag == "Dworking" || hit13.collider.gameObject.tag == "attack") ||
				(hit14.collider.gameObject.tag == "movableObj" || hit14.collider.gameObject.tag == "editableObj" || hit14.collider.gameObject.tag == "nonMovableObj" || hit14.collider.gameObject.tag == "using" || hit14.collider.gameObject.tag == "working" || hit14.collider.gameObject.tag == "Dworking" || hit14.collider.gameObject.tag == "attack") ||
				(hit15.collider.gameObject.tag == "movableObj" || hit15.collider.gameObject.tag == "editableObj" || hit15.collider.gameObject.tag == "nonMovableObj" || hit15.collider.gameObject.tag == "using" || hit15.collider.gameObject.tag == "working" || hit15.collider.gameObject.tag == "Dworking" || hit15.collider.gameObject.tag == "attack") ||
				(hit16.collider.gameObject.tag == "movableObj" || hit16.collider.gameObject.tag == "editableObj" || hit16.collider.gameObject.tag == "nonMovableObj" || hit16.collider.gameObject.tag == "using" || hit16.collider.gameObject.tag == "working" || hit16.collider.gameObject.tag == "Dworking" || hit16.collider.gameObject.tag == "attack") ||
				(hit17.collider.gameObject.tag == "movableObj" || hit17.collider.gameObject.tag == "editableObj" || hit17.collider.gameObject.tag == "nonMovableObj" || hit17.collider.gameObject.tag == "using" || hit17.collider.gameObject.tag == "working" || hit17.collider.gameObject.tag == "Dworking" || hit17.collider.gameObject.tag == "attack") ||
				(hit18.collider.gameObject.tag == "movableObj" || hit18.collider.gameObject.tag == "editableObj" || hit18.collider.gameObject.tag == "nonMovableObj" || hit18.collider.gameObject.tag == "using" || hit18.collider.gameObject.tag == "working" || hit18.collider.gameObject.tag == "Dworking" || hit18.collider.gameObject.tag == "attack") ||
				(hit19.collider.gameObject.tag == "movableObj" || hit19.collider.gameObject.tag == "editableObj" || hit19.collider.gameObject.tag == "nonMovableObj" || hit19.collider.gameObject.tag == "using" || hit19.collider.gameObject.tag == "working" || hit19.collider.gameObject.tag == "Dworking" || hit19.collider.gameObject.tag == "attack") ||
				(hit20.collider.gameObject.tag == "movableObj" || hit20.collider.gameObject.tag == "editableObj" || hit20.collider.gameObject.tag == "nonMovableObj" || hit20.collider.gameObject.tag == "using" || hit20.collider.gameObject.tag == "working" || hit20.collider.gameObject.tag == "Dworking" || hit20.collider.gameObject.tag == "attack") ||
				(hit21.collider.gameObject.tag == "movableObj" || hit21.collider.gameObject.tag == "editableObj" || hit21.collider.gameObject.tag == "nonMovableObj" || hit21.collider.gameObject.tag == "using" || hit21.collider.gameObject.tag == "working" || hit21.collider.gameObject.tag == "Dworking" || hit21.collider.gameObject.tag == "attack") ||
				(hit22.collider.gameObject.tag == "movableObj" || hit22.collider.gameObject.tag == "editableObj" || hit22.collider.gameObject.tag == "nonMovableObj" || hit22.collider.gameObject.tag == "using" || hit22.collider.gameObject.tag == "working" || hit22.collider.gameObject.tag == "Dworking" || hit22.collider.gameObject.tag == "attack") ||
				(hit23.collider.gameObject.tag == "movableObj" || hit23.collider.gameObject.tag == "editableObj" || hit23.collider.gameObject.tag == "nonMovableObj" || hit23.collider.gameObject.tag == "using" || hit23.collider.gameObject.tag == "working" || hit23.collider.gameObject.tag == "Dworking" || hit23.collider.gameObject.tag == "attack") ||
				(hit24.collider.gameObject.tag == "movableObj" || hit24.collider.gameObject.tag == "editableObj" || hit24.collider.gameObject.tag == "nonMovableObj" || hit24.collider.gameObject.tag == "using" || hit24.collider.gameObject.tag == "working" || hit24.collider.gameObject.tag == "Dworking" || hit24.collider.gameObject.tag == "attack") ||
				(hit25.collider.gameObject.tag == "movableObj" || hit25.collider.gameObject.tag == "editableObj" || hit25.collider.gameObject.tag == "nonMovableObj" || hit25.collider.gameObject.tag == "using" || hit25.collider.gameObject.tag == "working" || hit25.collider.gameObject.tag == "Dworking" || hit25.collider.gameObject.tag == "attack") ||
				(hit26.collider.gameObject.tag == "movableObj" || hit26.collider.gameObject.tag == "editableObj" || hit26.collider.gameObject.tag == "nonMovableObj" || hit26.collider.gameObject.tag == "using" || hit26.collider.gameObject.tag == "working" || hit26.collider.gameObject.tag == "Dworking" || hit26.collider.gameObject.tag == "attack") ||
				(hit27.collider.gameObject.tag == "movableObj" || hit27.collider.gameObject.tag == "editableObj" || hit27.collider.gameObject.tag == "nonMovableObj" || hit27.collider.gameObject.tag == "using" || hit27.collider.gameObject.tag == "working" || hit27.collider.gameObject.tag == "Dworking" || hit27.collider.gameObject.tag == "attack") ||
				(hit28.collider.gameObject.tag == "movableObj" || hit28.collider.gameObject.tag == "editableObj" || hit28.collider.gameObject.tag == "nonMovableObj" || hit28.collider.gameObject.tag == "using" || hit28.collider.gameObject.tag == "working" || hit28.collider.gameObject.tag == "Dworking" || hit28.collider.gameObject.tag == "attack") ||
				(hit29.collider.gameObject.tag == "movableObj" || hit29.collider.gameObject.tag == "editableObj" || hit29.collider.gameObject.tag == "nonMovableObj" || hit29.collider.gameObject.tag == "using" || hit29.collider.gameObject.tag == "working" || hit29.collider.gameObject.tag == "Dworking" || hit29.collider.gameObject.tag == "attack") ||
				(hit30.collider.gameObject.tag == "movableObj" || hit30.collider.gameObject.tag == "editableObj" || hit30.collider.gameObject.tag == "nonMovableObj" || hit30.collider.gameObject.tag == "using" || hit30.collider.gameObject.tag == "working" || hit30.collider.gameObject.tag == "Dworking" || hit30.collider.gameObject.tag == "attack") ||
				(hit31.collider.gameObject.tag == "movableObj" || hit31.collider.gameObject.tag == "editableObj" || hit31.collider.gameObject.tag == "nonMovableObj" || hit31.collider.gameObject.tag == "using" || hit31.collider.gameObject.tag == "working" || hit31.collider.gameObject.tag == "Dworking" || hit31.collider.gameObject.tag == "attack") ||
				(hit32.collider.gameObject.tag == "movableObj" || hit32.collider.gameObject.tag == "editableObj" || hit32.collider.gameObject.tag == "nonMovableObj" || hit32.collider.gameObject.tag == "using" || hit32.collider.gameObject.tag == "working" || hit32.collider.gameObject.tag == "Dworking" || hit32.collider.gameObject.tag == "attack") ||
				(hit33.collider.gameObject.tag == "movableObj" || hit33.collider.gameObject.tag == "editableObj" || hit33.collider.gameObject.tag == "nonMovableObj" || hit33.collider.gameObject.tag == "using" || hit33.collider.gameObject.tag == "working" || hit33.collider.gameObject.tag == "Dworking" || hit33.collider.gameObject.tag == "attack") ||
				(hit34.collider.gameObject.tag == "movableObj" || hit34.collider.gameObject.tag == "editableObj" || hit34.collider.gameObject.tag == "nonMovableObj" || hit34.collider.gameObject.tag == "using" || hit34.collider.gameObject.tag == "working" || hit34.collider.gameObject.tag == "Dworking" || hit34.collider.gameObject.tag == "attack") ||
				(hit35.collider.gameObject.tag == "movableObj" || hit35.collider.gameObject.tag == "editableObj" || hit35.collider.gameObject.tag == "nonMovableObj" || hit35.collider.gameObject.tag == "using" || hit35.collider.gameObject.tag == "working" || hit35.collider.gameObject.tag == "Dworking" || hit35.collider.gameObject.tag == "attack") ||
				(hit36.collider.gameObject.tag == "movableObj" || hit36.collider.gameObject.tag == "editableObj" || hit36.collider.gameObject.tag == "nonMovableObj" || hit36.collider.gameObject.tag == "using" || hit36.collider.gameObject.tag == "working" || hit36.collider.gameObject.tag == "Dworking" || hit36.collider.gameObject.tag == "attack") ||
				(hit37.collider.gameObject.tag == "movableObj" || hit37.collider.gameObject.tag == "editableObj" || hit37.collider.gameObject.tag == "nonMovableObj" || hit37.collider.gameObject.tag == "using" || hit37.collider.gameObject.tag == "working" || hit37.collider.gameObject.tag == "Dworking" || hit37.collider.gameObject.tag == "attack") ||
				(hit38.collider.gameObject.tag == "movableObj" || hit38.collider.gameObject.tag == "editableObj" || hit38.collider.gameObject.tag == "nonMovableObj" || hit38.collider.gameObject.tag == "using" || hit38.collider.gameObject.tag == "working" || hit38.collider.gameObject.tag == "Dworking" || hit38.collider.gameObject.tag == "attack") ||
				(hit39.collider.gameObject.tag == "movableObj" || hit39.collider.gameObject.tag == "editableObj" || hit39.collider.gameObject.tag == "nonMovableObj" || hit39.collider.gameObject.tag == "using" || hit39.collider.gameObject.tag == "working" || hit39.collider.gameObject.tag == "Dworking" || hit39.collider.gameObject.tag == "attack") ||
				(hit40.collider.gameObject.tag == "movableObj" || hit40.collider.gameObject.tag == "editableObj" || hit40.collider.gameObject.tag == "nonMovableObj" || hit40.collider.gameObject.tag == "using" || hit40.collider.gameObject.tag == "working" || hit40.collider.gameObject.tag == "Dworking" || hit40.collider.gameObject.tag == "attack") ||
				(hit41.collider.gameObject.tag == "movableObj" || hit41.collider.gameObject.tag == "editableObj" || hit41.collider.gameObject.tag == "nonMovableObj" || hit41.collider.gameObject.tag == "using" || hit41.collider.gameObject.tag == "working" || hit41.collider.gameObject.tag == "Dworking" || hit41.collider.gameObject.tag == "attack") ||
				(hit42.collider.gameObject.tag == "movableObj" || hit42.collider.gameObject.tag == "editableObj" || hit42.collider.gameObject.tag == "nonMovableObj" || hit42.collider.gameObject.tag == "using" || hit42.collider.gameObject.tag == "working" || hit42.collider.gameObject.tag == "Dworking" || hit42.collider.gameObject.tag == "attack") ||
				(hit43.collider.gameObject.tag == "movableObj" || hit43.collider.gameObject.tag == "editableObj" || hit43.collider.gameObject.tag == "nonMovableObj" || hit43.collider.gameObject.tag == "using" || hit43.collider.gameObject.tag == "working" || hit43.collider.gameObject.tag == "Dworking" || hit43.collider.gameObject.tag == "attack") ||
				(hit44.collider.gameObject.tag == "movableObj" || hit44.collider.gameObject.tag == "editableObj" || hit44.collider.gameObject.tag == "nonMovableObj" || hit44.collider.gameObject.tag == "using" || hit44.collider.gameObject.tag == "working" || hit44.collider.gameObject.tag == "Dworking" || hit44.collider.gameObject.tag == "attack") ||
				(hit45.collider.gameObject.tag == "movableObj" || hit45.collider.gameObject.tag == "editableObj" || hit45.collider.gameObject.tag == "nonMovableObj" || hit45.collider.gameObject.tag == "using" || hit45.collider.gameObject.tag == "working" || hit45.collider.gameObject.tag == "Dworking" || hit45.collider.gameObject.tag == "attack") ||
				(hit46.collider.gameObject.tag == "movableObj" || hit46.collider.gameObject.tag == "editableObj" || hit46.collider.gameObject.tag == "nonMovableObj" || hit46.collider.gameObject.tag == "using" || hit46.collider.gameObject.tag == "working" || hit46.collider.gameObject.tag == "Dworking" || hit46.collider.gameObject.tag == "attack") ||
				(hit47.collider.gameObject.tag == "movableObj" || hit47.collider.gameObject.tag == "editableObj" || hit47.collider.gameObject.tag == "nonMovableObj" || hit47.collider.gameObject.tag == "using" || hit47.collider.gameObject.tag == "working" || hit47.collider.gameObject.tag == "Dworking" || hit47.collider.gameObject.tag == "attack") ||
				(hit48.collider.gameObject.tag == "movableObj" || hit48.collider.gameObject.tag == "editableObj" || hit48.collider.gameObject.tag == "nonMovableObj" || hit48.collider.gameObject.tag == "using" || hit48.collider.gameObject.tag == "working" || hit48.collider.gameObject.tag == "Dworking" || hit48.collider.gameObject.tag == "attack") ||
				(hit49.collider.gameObject.tag == "movableObj" || hit49.collider.gameObject.tag == "editableObj" || hit49.collider.gameObject.tag == "nonMovableObj" || hit49.collider.gameObject.tag == "using" || hit49.collider.gameObject.tag == "working" || hit49.collider.gameObject.tag == "Dworking" || hit49.collider.gameObject.tag == "attack") ||
				(hit50.collider.gameObject.tag == "movableObj" || hit50.collider.gameObject.tag == "editableObj" || hit50.collider.gameObject.tag == "nonMovableObj" || hit50.collider.gameObject.tag == "using" || hit50.collider.gameObject.tag == "working" || hit50.collider.gameObject.tag == "Dworking" || hit50.collider.gameObject.tag == "attack") ||
				(hit51.collider.gameObject.tag == "movableObj" || hit51.collider.gameObject.tag == "editableObj" || hit51.collider.gameObject.tag == "nonMovableObj" || hit51.collider.gameObject.tag == "using" || hit51.collider.gameObject.tag == "working" || hit51.collider.gameObject.tag == "Dworking" || hit51.collider.gameObject.tag == "attack") ||
				(hit52.collider.gameObject.tag == "movableObj" || hit52.collider.gameObject.tag == "editableObj" || hit52.collider.gameObject.tag == "nonMovableObj" || hit52.collider.gameObject.tag == "using" || hit52.collider.gameObject.tag == "working" || hit52.collider.gameObject.tag == "Dworking" || hit52.collider.gameObject.tag == "attack") ||
				(hit53.collider.gameObject.tag == "movableObj" || hit53.collider.gameObject.tag == "editableObj" || hit53.collider.gameObject.tag == "nonMovableObj" || hit53.collider.gameObject.tag == "using" || hit53.collider.gameObject.tag == "working" || hit53.collider.gameObject.tag == "Dworking" || hit53.collider.gameObject.tag == "attack") ||
				(hit54.collider.gameObject.tag == "movableObj" || hit54.collider.gameObject.tag == "editableObj" || hit54.collider.gameObject.tag == "nonMovableObj" || hit54.collider.gameObject.tag == "using" || hit54.collider.gameObject.tag == "working" || hit54.collider.gameObject.tag == "Dworking" || hit54.collider.gameObject.tag == "attack") ||
				(hit55.collider.gameObject.tag == "movableObj" || hit55.collider.gameObject.tag == "editableObj" || hit55.collider.gameObject.tag == "nonMovableObj" || hit55.collider.gameObject.tag == "using" || hit55.collider.gameObject.tag == "working" || hit55.collider.gameObject.tag == "Dworking" || hit55.collider.gameObject.tag == "attack") ||
				(hit56.collider.gameObject.tag == "movableObj" || hit56.collider.gameObject.tag == "editableObj" || hit56.collider.gameObject.tag == "nonMovableObj" || hit56.collider.gameObject.tag == "using" || hit56.collider.gameObject.tag == "working" || hit56.collider.gameObject.tag == "Dworking" || hit56.collider.gameObject.tag == "attack") ||
				(hit57.collider.gameObject.tag == "movableObj" || hit57.collider.gameObject.tag == "editableObj" || hit57.collider.gameObject.tag == "nonMovableObj" || hit57.collider.gameObject.tag == "using" || hit57.collider.gameObject.tag == "working" || hit57.collider.gameObject.tag == "Dworking" || hit57.collider.gameObject.tag == "attack") ||
				(hit58.collider.gameObject.tag == "movableObj" || hit58.collider.gameObject.tag == "editableObj" || hit58.collider.gameObject.tag == "nonMovableObj" || hit58.collider.gameObject.tag == "using" || hit58.collider.gameObject.tag == "working" || hit58.collider.gameObject.tag == "Dworking" || hit58.collider.gameObject.tag == "attack") ||
				(hit59.collider.gameObject.tag == "movableObj" || hit59.collider.gameObject.tag == "editableObj" || hit59.collider.gameObject.tag == "nonMovableObj" || hit59.collider.gameObject.tag == "using" || hit59.collider.gameObject.tag == "working" || hit59.collider.gameObject.tag == "Dworking" || hit59.collider.gameObject.tag == "attack") ||
				(hit60.collider.gameObject.tag == "movableObj" || hit60.collider.gameObject.tag == "editableObj" || hit60.collider.gameObject.tag == "nonMovableObj" || hit60.collider.gameObject.tag == "using" || hit60.collider.gameObject.tag == "working" || hit60.collider.gameObject.tag == "Dworking" || hit60.collider.gameObject.tag == "attack") ||
				(hit61.collider.gameObject.tag == "movableObj" || hit61.collider.gameObject.tag == "editableObj" || hit61.collider.gameObject.tag == "nonMovableObj" || hit61.collider.gameObject.tag == "using" || hit61.collider.gameObject.tag == "working" || hit61.collider.gameObject.tag == "Dworking" || hit61.collider.gameObject.tag == "attack") ||
				(hit62.collider.gameObject.tag == "movableObj" || hit62.collider.gameObject.tag == "editableObj" || hit62.collider.gameObject.tag == "nonMovableObj" || hit62.collider.gameObject.tag == "using" || hit62.collider.gameObject.tag == "working" || hit62.collider.gameObject.tag == "Dworking" || hit62.collider.gameObject.tag == "attack") ||
				(hit63.collider.gameObject.tag == "movableObj" || hit63.collider.gameObject.tag == "editableObj" || hit63.collider.gameObject.tag == "nonMovableObj" || hit63.collider.gameObject.tag == "using" || hit63.collider.gameObject.tag == "working" || hit63.collider.gameObject.tag == "Dworking" || hit63.collider.gameObject.tag == "attack") ||
				(hit64.collider.gameObject.tag == "movableObj" || hit64.collider.gameObject.tag == "editableObj" || hit64.collider.gameObject.tag == "nonMovableObj" || hit64.collider.gameObject.tag == "using" || hit64.collider.gameObject.tag == "working" || hit64.collider.gameObject.tag == "Dworking" || hit64.collider.gameObject.tag == "attack"))
			{				
				if (hit1.collider.gameObject.tag == "nonMovableObj" && (hit1.collider.gameObject.transform.parent.gameObject.tag == "goblinCamp" || hit1.collider.gameObject.transform.parent.gameObject.tag == "OrgCave" || hit1.collider.gameObject.transform.parent.gameObject.tag == "TrollHouse")) 
				{
					if (curCavePatch != null)
						curCavePatch.enabled = false;
					
					curCavePatch = hit1.collider.gameObject.transform.parent.gameObject.transform.FindChild("caveRedPatch").gameObject.GetComponent<MeshRenderer>();
					curCavePatch.enabled = true;
				}
				else if (hit2.collider.gameObject.tag == "nonMovableObj" && (hit2.collider.gameObject.transform.parent.gameObject.tag == "goblinCamp" || hit2.collider.gameObject.transform.parent.gameObject.tag == "OrgCave" || hit2.collider.gameObject.transform.parent.gameObject.tag == "TrollHouse")) 
				{
					if (curCavePatch != null)
						curCavePatch.enabled = false;
					
					curCavePatch = hit2.collider.gameObject.transform.parent.gameObject.transform.FindChild("caveRedPatch").gameObject.GetComponent<MeshRenderer>();
					curCavePatch.enabled = true;
				}
				else if (hit3.collider.gameObject.tag == "nonMovableObj" && (hit3.collider.gameObject.transform.parent.gameObject.tag == "goblinCamp" || hit3.collider.gameObject.transform.parent.gameObject.tag == "OrgCave" || hit3.collider.gameObject.transform.parent.gameObject.tag == "TrollHouse")) 
				{
					if (curCavePatch != null)
						curCavePatch.enabled = false;
					
					curCavePatch = hit3.collider.gameObject.transform.parent.gameObject.transform.FindChild("caveRedPatch").gameObject.GetComponent<MeshRenderer>();
					curCavePatch.enabled = true;
				}
				else if (hit4.collider.gameObject.tag == "nonMovableObj" && (hit4.collider.gameObject.transform.parent.gameObject.tag == "goblinCamp" || hit4.collider.gameObject.transform.parent.gameObject.tag == "OrgCave" || hit4.collider.gameObject.transform.parent.gameObject.tag == "TrollHouse")) 
				{
					if (curCavePatch != null)
						curCavePatch.enabled = false;
					
					curCavePatch = hit4.collider.gameObject.transform.parent.gameObject.transform.FindChild("caveRedPatch").gameObject.GetComponent<MeshRenderer>();
					curCavePatch.enabled = true;
				}	
				else if (curCavePatch != null)
				{
					curCavePatch.enabled = false;
				}
				
				GameManager.placeObjectBool = false;
				//Debug.Log("i m here........ " + GameManager.placeObjectBool);
				redPatch.GetComponent<MeshRenderer>().enabled = true;
				if (transform.gameObject.name != "HC_D_DirtPath_GO(Clone)" && transform.gameObject.name != "DL_D_DDirtPath_GO(Clone)")
				{
					greenPatch.active = false;
					redPatch.active = true;
				}
			}
			else
			{
//				Debug.Log("floor object :: " + curString + " --- " + hit9.collider.gameObject.tag);
				if (curString == "HC" && hit9.collider.gameObject.tag == "halflingGround")
					activeBool = true;
				else if (curString == "DL" && hit9.collider.gameObject.tag == "darklingGround")
					activeBool = true;
				else
					activeBool = false;
				
				if (activeBool)
				{
					GameManager.placeObjectBool = true;
				
					greenPatch.GetComponent<MeshRenderer>().enabled = true;
				
				
					if (transform.gameObject.name != "HC_D_DirtPath_GO(Clone)" && transform.gameObject.name != "DL_D_DDirtPath_GO(Clone)")
					{
						greenPatch.active = true;
						redPatch.active = false;
					}
				
				
					cavePatch = GameObject.FindGameObjectsWithTag("cavePatch");
					
					foreach (GameObject caveP in cavePatch)
					{
						if (caveP != null)
							caveP.GetComponent<MeshRenderer>().enabled = false;
					}
					
	//				Debug.Log("size :: " + cavePatch.Length);
					
					if (curCavePatch != null && curCavePatch.enabled == true)
						curCavePatch.enabled = false;
				}
			}
		}
	}
}
