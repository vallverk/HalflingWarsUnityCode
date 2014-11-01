using UnityEngine;
using System.Collections;

public class DarklingSmoking : MonoBehaviour 
{
	public Sprite ds1;
	public Sprite ds2;
	public Sprite ds3;
	public int DlSmokeTimer;
	
	void Start () 
	{
		InvokeRepeating("DlCharSmoke", float.Epsilon, 1f);
	}
	
	void DlCharSmoke()
	{
		DlSmokeTimer++;
	}
	void Update () 
	{
		if(DlSmokeTimer >=0 && DlSmokeTimer <=2)
		{
			ds1.gameObject.active = true;
			ds2.gameObject.active = false;
			ds3.gameObject.active = false;
			ds1.PlayAnim("Darkling_Sitting_01");
		
		}
		else if(DlSmokeTimer >2 && DlSmokeTimer <=60)
		{
			ds1.gameObject.active = false;
			ds2.gameObject.active = true;
			ds3.gameObject.active = false;
			ds2.PlayAnim("Darkling_Sitting_Smoking_Idle_01");
		}
		else if(DlSmokeTimer >=60 && DlSmokeTimer <=62)
		{
			ds1.gameObject.active = false;
			ds2.gameObject.active = false;
			ds3.gameObject.active = true;
			ds3.PlayAnim("Darkling_Smoking_Start");
		}
		else if(DlSmokeTimer >=62 && DlSmokeTimer <=64)
		{
			ds1.gameObject.active = true;
			ds2.gameObject.active = false;
			ds3.gameObject.active = false;
			//ds1.PlayAnim(0);
			//ds1.animations = new UVAnimation_Multi
				ds1.PlayAnimInReverse("Darkling_Sitting_01");
		}
		else if(DlSmokeTimer >64)
		{
			DlSmokeTimer=0;
		}
	}
}
