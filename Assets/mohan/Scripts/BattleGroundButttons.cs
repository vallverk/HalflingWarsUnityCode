using UnityEngine;
using System.Collections;



public class BattleGroundButttons : MonoBehaviour 
{
	public GameObject Walk;
	public GameObject Idle;
	public GameObject Action;
	public bool collidingWithDevider = false;
	
	public enum AnimState{
		
		IDLE,ACTION,WALK,BACK_WALK
	}
	public AnimState ANIMATION;
	
	
	void Start () 
	{
		
		ANIMATION = AnimState.WALK;
		
	}
	
	/*
	private void WaitSomeTime()
	{
		if(ANIMATION == AnimState.IDLE)
		{
			
			Idle.GetComponent<Sprite>().enabled = false;
			
			Debug.Log("Idel--------");
		}
		
	}
	
	private void PlayIdelAnim()
	{
		if(ANIMATION == AnimState.IDLE)
		{
			
			Idle.GetComponent<Sprite>().enabled = true;
			Debug.Log("Idel");
		}
		
	}*/
	
	public void ChangeToAction()
	{
		
		ANIMATION = AnimState.ACTION;
		
		Invoke("BackToWalk",4f);
		
	}
	
	
	
//	public void ChangeToActionTimeDelay()
//	{
//		
//		Invoke("TimeDelay",0.6f);
//		Invoke("BackToIdle",4f);
//		
//	}
	
//	void TimeDelay()
//	{
//		ANIMATION = AnimState.ACTION;
//		
//	}
	
	
	void BackToWalk()
	{
		
		ANIMATION = AnimState.WALK;
		
	}
	
	void Update () 
	{
		
		// check distace
//		if(distance1)
//		{
//			collidingWithDevider = true;
//			DoBackWalk();
//			gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,1,1);
//			
//		}
//		
//		if(distance2)
//		{
//			ANIMATION = AnimState.WALK;
//			
//			gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,1,1);
//	
//			
//		}
		
		
		if(ANIMATION == AnimState.WALK)
		{
			
			
			Walk.gameObject.renderer.enabled = true;
			Idle.gameObject.renderer.enabled = false;
			Action.gameObject.renderer.enabled = false;
		}
		
		
		if(ANIMATION == AnimState.ACTION)
		{
			
			//Debug.Log("Playing Animation Action-------******");
			
			Action.gameObject.renderer.enabled = true;
			
			Walk.gameObject.renderer.enabled = false;
			Idle.gameObject.renderer.enabled = false;
		}
		
		
		if(ANIMATION == AnimState.BACK_WALK)
		{
			
			Action.gameObject.renderer.enabled = false;
			Walk.gameObject.renderer.enabled = true;
			Idle.gameObject.renderer.enabled = false;
			
			//Debug.Log("Back Walk ---------->>>");
		}
		
		if(ANIMATION == AnimState.IDLE)
		{
			Idle.gameObject.renderer.enabled = true;
			Action.gameObject.renderer.enabled = false;
			Walk.gameObject.renderer.enabled = false;
		}
		
		
		
		
	}

	
	/*void OnCollisionEnter(Collision collider)
	{
		if(collider.gameObject.tag == "devider")
		{
			collidingWithDevider = true;
			DoBackWalk();
			gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,1,1);
			
		}
		
		if(collider.gameObject.tag == "Boundary")
		{
			ANIMATION = AnimState.WALK;
			
			gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,1,1);
	
			
		}
		
	}*/
	
	void DoIdle()
	{
		
		ANIMATION = AnimState.IDLE;
		Invoke("DoBackWalk",2f);
	}
	
	
	void DoBackWalk()
	{
		
		ANIMATION = AnimState.BACK_WALK;
		
	}
	
	
}
