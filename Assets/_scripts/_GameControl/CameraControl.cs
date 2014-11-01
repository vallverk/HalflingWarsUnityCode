using UnityEngine;

using System.Collections;

 

public class CameraControl : MonoBehaviour 
{
	public static float newArea = 158.50f;
	
	public Transform target;
	public Transform darklingMap;
	
	private bool darlingActiveBool = false;
	
    private int speed = 1;

    public Camera selectedCamera;
	public Camera guiCamera;

    public float MINSCALE = 2.0F;

    public float MAXSCALE = 5.0F;

    public float varianceInDistances = 5.0F;

    private float touchDelta = 0.0F;

    private Vector2 prevDist = new Vector2(0,0);

    private Vector2 curDist = new Vector2(0,0);

    private float startAngleBetweenTouches = 0.0F;

    private int vertOrHorzOrientation = 0; //this tells if the two fingers to each other are oriented horizontally or vertically, 1 for vertical and -1 for horizontal

    private Vector2 midPoint = new Vector2(0,0); //store and use midpoint to check if fingers exceed a limit defined by midpoint for oriantation of fingers
	
	private Vector3 screenPos;
	private Vector3 offset;
	private Vector3 currentScreenPos;
	private Vector3 currentPos;
	private float panSpeed = 0.1f;
	
	private float touchModifier = 0.3f; //0.6
	private Vector3 translate;
	
	private float temp;
	public bool cameraMove = true;
	
	private Vector3 curCamPos;
	
	public float fov = 30f;
	private float minFOV = 15f;
	private float maxFOV = 30f;
	
	public Vector2[] minMaxAreaX = new Vector2[16];
	public Vector2[] minMaxAreaZ = new Vector2[16];
	public int[] FOV = new int[16];
	
	private int index = 0;
	
	public Transform halflingHouse_cPos;
	
	public GameManager scr_GameManager;
	
	public float stepPerSecond = 1f, orthoMin = 3f, orthoMax = 6f;
    float lastDistance = 0f;
	
	public GUIText camZoomTxt;
	
	private float tVelocity = 0.0f;
	
	public Camera camera;

    void Start () 
    {
//		transform.position = halflingHouse_cPos.position;
		
    	temp = selectedCamera.orthographicSize;
		selectedCamera.orthographicSize = fov;
		
		curCamPos = camera.transform.position;
		
		//fov = 20;
		
	}

    // Update is called once per frame
	RaycastHit hit;
	RaycastHit guiHit;
	
	void FixedUpdate()
    {
		/*if (cameraMove == true && !guiControl.popUpOpenBool && !GameManager.battleActiveBool && !scr_GameManager.guiHitBool)
		{
	       	if (Input.touchCount != 2)
		    {
	    		lastDistance = 0;
	            return;
	        }
	
	        if (Input.touches[0].phase != TouchPhase.Moved && Input.touches[1].phase != TouchPhase.Moved)
	        {
	           	lastDistance = 0;
	           	return;
	        }
	
	        Touch[] touch = Input.touches;
	
	        float distance = Vector2.Distance(touch[0].position, touch[1].position);
	
	        if (distance == lastDistance) return;
	
	       	float touchDistance = (touch[1].position - touch[0].position).magnitude;
	       	float lastTouchDistance = ((touch[1].position - touch[1].deltaPosition) - (touch[0].position - touch[0].deltaPosition)).magnitude;
	       	float deltaPinch = touchDistance - lastTouchDistance;
			
			
	      	camera.orthographicSize -= deltaPinch * stepPerSecond * Time.deltaTime;
	
	     	if (camera.orthographicSize < orthoMin - 5)
			{
				camera.orthographicSize = orthoMin - 5;
			}
	      	else if (camera.orthographicSize > orthoMax) camera.orthographicSize = orthoMax;
	
	     	lastDistance = distance;
			setPosition();
		}*/
    }
	
	
    void Update () 
    {	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.tag == "wall")
				cameraMove = false;
			else
				cameraMove = true;
		}
				
		if (cameraMove == true && !guiControl.popUpOpenBool && !GameManager.battleActiveBool && !scr_GameManager.guiHitBool)
		{
			if (Input.touchCount == 1)
			{
				Touch touch = Input.touches[0];
				if (touch.phase == TouchPhase.Began)
				{
					curCamPos = camera.transform.position;
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					translate = new Vector3(( touch.deltaPosition.x / ( touchModifier ) * Time.deltaTime), 0, ( touch.deltaPosition.y / ( touchModifier ) * Time.deltaTime) );
				  
					curCamPos -= translate;
										
					setPosition();
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					curCamPos = camera.transform.position;
				}
			}
			
			if (Input.touchCount == 2)
			{
				Touch[] touch = Input.touches;
	
		        float distance = Vector2.Distance(touch[0].position, touch[1].position);
		
		        if (distance == lastDistance) return;
		
		       	float touchDistance = (touch[1].position - touch[0].position).magnitude;
		       	float lastTouchDistance = ((touch[1].position - touch[1].deltaPosition) - (touch[0].position - touch[0].deltaPosition)).magnitude;
		       	float deltaPinch = touchDistance - lastTouchDistance;
				
				
		      	camera.orthographicSize -= deltaPinch * stepPerSecond * Time.deltaTime;
		
		     	if (camera.orthographicSize < orthoMin - 5)
				{
					camera.orthographicSize = orthoMin - 5;
				}
		      	else if (camera.orthographicSize > orthoMax) camera.orthographicSize = orthoMax;
		
		     	lastDistance = distance;
				setPosition();
			}
	   	}
		if (camera.orthographicSize < orthoMin)
		{
			camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, orthoMin, ref tVelocity, 0.5f);
		}
  		else if (camera.orthographicSize > orthoMax) camera.orthographicSize = orthoMax;
	}
	
	private float calX;
	
	void setPosition()
	{
		objGridMove.camMoveBool = true;
		calX = (1.65f + (((camera.orthographicSize - 15)/10) + ((camera.orthographicSize - 15)/100)))/camera.orthographicSize;
		//Debug.Log("cal :: " + calX + " -- " + (-144f + (calX * ((camera.orthographicSize - 15) * 10))));
		
		float newY = (18f - (camera.orthographicSize - 15));
		
		float newX = (-140f + (calX * ((camera.orthographicSize - 15) * 10)));
		
		
		camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, newX, (newX * -1) - newArea), curCamPos.y,
											Mathf.Clamp(curCamPos.z, (newY * -1), newY));
		
		//curCamPos = camera.transform.position;
		/*camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[15].x, minMaxAreaX[15].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[15].x, minMaxAreaZ[15].y));
			curCamPos = camera.transform.position;*/
		
		/*if (selectedCamera.orthographicSize <= FOV[15] && selectedCamera.orthographicSize >= FOV[14])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[15].x, minMaxAreaX[15].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[15].x, minMaxAreaZ[15].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[14] && selectedCamera.orthographicSize >= FOV[13])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[14].x, minMaxAreaX[14].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[14].x, minMaxAreaZ[14].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[13] && selectedCamera.orthographicSize >= FOV[12])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[13].x, minMaxAreaX[13].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[13].x, minMaxAreaZ[13].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[12] && selectedCamera.orthographicSize >= FOV[11])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[12].x, minMaxAreaX[12].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[12].x, minMaxAreaZ[12].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[11] && selectedCamera.orthographicSize >= FOV[10])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[11].x, minMaxAreaX[11].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[11].x, minMaxAreaZ[11].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[10] && selectedCamera.orthographicSize >= FOV[9])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[10].x, minMaxAreaX[10].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[10].x, minMaxAreaZ[10].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[9] && selectedCamera.orthographicSize >= FOV[8])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[9].x, minMaxAreaX[9].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[9].x, minMaxAreaZ[9].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[8] && selectedCamera.orthographicSize >= FOV[7])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[8].x, minMaxAreaX[8].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[8].x, minMaxAreaZ[8].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[7] && selectedCamera.orthographicSize >= FOV[6])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[7].x, minMaxAreaX[7].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[7].x, minMaxAreaZ[7].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[6] && selectedCamera.orthographicSize >= FOV[5])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[6].x, minMaxAreaX[6].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[6].x, minMaxAreaZ[6].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[5] && selectedCamera.orthographicSize >= FOV[4])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[5].x, minMaxAreaX[5].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[5].x, minMaxAreaZ[5].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[4] && selectedCamera.orthographicSize >= FOV[3])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[4].x, minMaxAreaX[4].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[4].x, minMaxAreaZ[4].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[3] && selectedCamera.orthographicSize >= FOV[2])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[3].x, minMaxAreaX[3].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[3].x, minMaxAreaZ[3].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[2] && selectedCamera.orthographicSize >= FOV[1])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[2].x, minMaxAreaX[2].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[2].x, minMaxAreaZ[2].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[1] && selectedCamera.orthographicSize >= FOV[0])
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[1].x, minMaxAreaX[1].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[1].x, minMaxAreaZ[1].y));
			curCamPos = camera.transform.position;
		}
		else if (selectedCamera.orthographicSize <= FOV[0] && selectedCamera.orthographicSize >= FOV[0]-1)
		{
			camera.transform.position = new Vector3(Mathf.Clamp(curCamPos.x, minMaxAreaX[0].x, minMaxAreaX[0].y + newArea), 
													curCamPos.y, 
													Mathf.Clamp(curCamPos.z, minMaxAreaZ[0].x, minMaxAreaZ[0].y));
			curCamPos = camera.transform.position;
		}*/
	}
}