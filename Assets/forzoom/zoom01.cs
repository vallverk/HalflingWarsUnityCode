using UnityEngine;
using System.Collections;

public class zoom01 : MonoBehaviour 
{

	public float stepPerSecond = 1f, orthoMin = 3f, orthoMax = 6f;
    float lastDistance = 0f;
	
	public GUIText camZoomTxt;
	
	private float tVelocity = 0.0f;
	
	public Camera camera;

   /* void FixedUpdate()
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
		
		
    }
	
	void Update()
	{
		if (camera.orthographicSize < orthoMin)
		{
			camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, orthoMin, ref tVelocity, 0.5f);
		}
      	else if (camera.orthographicSize > orthoMax) camera.orthographicSize = orthoMax;
	}
	
	void OnGUI()
	{
		camZoomTxt.text = camera.orthographicSize.ToString();
	}*/
}
