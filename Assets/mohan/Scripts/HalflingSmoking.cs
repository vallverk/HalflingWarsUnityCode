using UnityEngine;
using System.Collections;

public class HalflingSmoking : MonoBehaviour 
{
	public Sprite hs1;
	public Sprite hs2;
	public Sprite hs3;
	public int HwSmokeTimer;
	
	void Start () 
	{
		InvokeRepeating("HWCharSmoke", float.Epsilon, 1f);
	}
	
	void HWCharSmoke()
	{
		HwSmokeTimer++;
	}
	void Update () 
	{
		if(HwSmokeTimer >=0 && HwSmokeTimer <=2)
		{
			hs1.gameObject.active = true;
			hs2.gameObject.active = false;
			hs3.gameObject.active = false;
			hs1.PlayAnim("Halfling_Sitting_01");
		
		}
		else if(HwSmokeTimer >2 && HwSmokeTimer <=60)
		{
			hs1.gameObject.active = false;
			hs2.gameObject.active = true;
			hs3.gameObject.active = false;
			hs2.PlayAnim("Halfling_Sitting_Smoking_Idle_01");
		}
		else if(HwSmokeTimer >=60 && HwSmokeTimer <=62)
		{
			hs1.gameObject.active = false;
			hs2.gameObject.active = false;
			hs3.gameObject.active = true;
			hs3.PlayAnim("Halfling_Smoking_Start");
		}
		else if(HwSmokeTimer >=62 && HwSmokeTimer <=64)
		{
			hs1.gameObject.active = true;
			hs2.gameObject.active = false;
			hs3.gameObject.active = false;
			//hs1.PlayAnim(0);
			//hs1.animations = new UVAnimation_Multi
				hs1.PlayAnimInReverse("Halfling_Sitting_01");
		}
		else if(HwSmokeTimer >64)
		{
			HwSmokeTimer=0;
		}
	}
}
