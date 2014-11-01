using UnityEngine;
using System.Collections;

public class BattleGroundPlayer : MonoBehaviour {

	public GameObject my_Player;
	public GameObject opp_Player;
	public static bool isBattleOver = false;

	public BattleGroundManager bgm;
	public GameObject BGM;
	
	private BattleGroundButttons battle;
	private BattleGroundButttons battleOpp;
	
	public GameObject pointA;
	public GameObject pointB;
	public GameObject pointC;
	
	public bool Player_moveAB_Bool = false, Player_moveBA_Bool = false;
	public bool Opponent_moveAB_Bool = false, Opponent_moveBA_Bool = false;
	
	private bool characterFacingAtoB = false;
	private bool opponentFacingAtoB = false;
	
	public bool generateRandomBubbles = false;
	public bool enableTutorialEffect  = false;
	public bool RealGamePlay = false;
	void Start () 
	{
		
	}
	
	public void CustomStart()
	{
		
		battle = my_Player.GetComponent<BattleGroundButttons>();
		battleOpp = opp_Player.GetComponent<BattleGroundButttons>();
		bgm = BGM.GetComponent<BattleGroundManager>();
		Player_moveAB_Bool = true;
		Opponent_moveAB_Bool = true;
	}
	
	public void ResetPlayerData()
	{
		Player_moveAB_Bool = false;
		Player_moveBA_Bool = false;
		Opponent_moveAB_Bool = false;
		Opponent_moveBA_Bool = false;
		
		characterFacingAtoB = false;
		opponentFacingAtoB = false;
	}
	
	public void BringPlayertoCenter()
	{
		
///***		Debug.Log("Called----");
		MovePlayersToMiddle();
		battle.ANIMATION = BattleGroundButttons.AnimState.ACTION;
		battleOpp.ANIMATION = BattleGroundButttons.AnimState.ACTION;
		
		Invoke("SwitchToWalk",3f);
		
	}
	
	private void SwitchToWalk()
	{
		
		battle.ANIMATION = BattleGroundButttons.AnimState.WALK;
		battleOpp.ANIMATION = BattleGroundButttons.AnimState.WALK;
		
	}
	
	public void MovePlayersToMiddle()
	{
		GameObject player = GameObject.Find("Player");
		GameObject Opp = GameObject.Find("Opponent");
		
		my_Player.transform.localPosition = player.transform.localPosition;
		opp_Player.transform.localPosition = Opp.transform.localPosition;
		
		
	}
	
	private void ActivateBubbleTap()
	{
		
		TappingGroup.enableTappingButtons = true;
		GetComponent<TappingGroup>().Activate();
		
	}
	
	private void OneMoreTime()
	{
		
		battle.ANIMATION = BattleGroundButttons.AnimState.WALK;
		battleOpp.ANIMATION = BattleGroundButttons.AnimState.WALK;
		
	}
	
	void Update () 
	{
		
		if(enableTutorialEffect)
		{
			if(characterFacingAtoB & opponentFacingAtoB)
			{
				GetComponent<TappingGroup>().TutorualActive();
				
				battle.ANIMATION = BattleGroundButttons.AnimState.IDLE;
				battleOpp.ANIMATION = BattleGroundButttons.AnimState.IDLE;
				enableTutorialEffect = false;
				
			}
		}
		
		if(!generateRandomBubbles & RealGamePlay)
		{
			if(characterFacingAtoB & opponentFacingAtoB)
			{
				//BringPlayertoCenter();
///***				Debug.Log("Activate bubble here....");
				ActivateBubbleTap();
				
				battle.ANIMATION = BattleGroundButttons.AnimState.IDLE;
				battleOpp.ANIMATION = BattleGroundButttons.AnimState.IDLE;
				Invoke("OneMoreTime",5f);
				
				RealGamePlay = false;
				//generateRandomBubbles = true;
			}
		}
		
		if (Player_moveAB_Bool)
		{
			//Debug.Log("BOOL-- " + Vector3.Distance(my_Player.transform.position, pointC.transform.position));
			if (Vector3.Distance(my_Player.transform.position, pointC.transform.position) < 10f)
			{
				my_Player.transform.localScale = new Vector3(-my_Player.transform.localScale.x,1,1);
				
				battle.ANIMATION = BattleGroundButttons.AnimState.BACK_WALK;
				//Debug.Log("A------->B");
				
				characterFacingAtoB = false;
				Player_moveAB_Bool = false;
				Player_moveBA_Bool = true;
			}
			
		}
		
		if (Player_moveBA_Bool)
		{
			if (Vector3.Distance(my_Player.transform.position, pointA.transform.position) < 5f)
			{
				//Debug.Log("new bool -- " + Vector3.Distance(my_Player.transform.position, pointC.transform.position));
				my_Player.transform.localScale = new Vector3(-my_Player.transform.localScale.x,1,1);
				
				battle.ANIMATION = BattleGroundButttons.AnimState.WALK;
					//Debug.Log("B------->A");
				
				characterFacingAtoB = true;
				Player_moveAB_Bool = true;
				Player_moveBA_Bool = false;
			}
			
		}
		
		
		if (Opponent_moveAB_Bool)
		{
			//Debug.Log("BOOL OPPP-- " + Vector3.Distance(opp_Player.transform.position, pointC.transform.position));
			if (Vector3.Distance(opp_Player.transform.position, pointC.transform.position) < 10f)
			{
				opp_Player.transform.localScale = new Vector3(-opp_Player.transform.localScale.x,1,1);
				
				battleOpp.ANIMATION = BattleGroundButttons.AnimState.BACK_WALK;
				//Debug.Log("AA------->BB");
				
				opponentFacingAtoB = false;
				Opponent_moveAB_Bool = false;
				Opponent_moveBA_Bool = true;
			}
			
		}
		
		if (Opponent_moveBA_Bool)
		{
			if (Vector3.Distance(opp_Player.transform.position, pointB.transform.position) < 4f)
			{
				//Debug.Log("new bool OPP-- " + Vector3.Distance(opp_Player.transform.position, pointB.transform.position));
				opp_Player.transform.localScale = new Vector3(-opp_Player.transform.localScale.x,1,1);
				
				battleOpp.ANIMATION = BattleGroundButttons.AnimState.WALK;
					//Debug.Log("B------->A");
				
				opponentFacingAtoB = true;
				Opponent_moveAB_Bool = true;
				Opponent_moveBA_Bool = false;
			}
			
		}
		
		
		
		
		
//		if(isBattleOver)								//hide character after battle over
//		{
//			my_Player.SetActiveRecursively(false);
//			opp_Player.SetActiveRecursively(false);
//			
//			isBattleOver = false;
//		}
		
		
		/*
		if(battle.collidingWithDevider & battleOpp.collidingWithDevider)
		{
			battle.ANIMATION = BattleGroundButttons.AnimState.ACTION;
			battleOpp.ANIMATION = BattleGroundButttons.AnimState.ACTION;
			
			battle.collidingWithDevider = false;
			battleOpp.collidingWithDevider = false;
		}
		else if(battle.collidingWithDevider)
		{
			battle.ANIMATION = BattleGroundButttons.AnimState.IDLE;
			
		}
		else if(battleOpp.collidingWithDevider)
		{
			
			battleOpp.ANIMATION = BattleGroundButttons.AnimState.IDLE;
		}
		
		*/
		if (battle != null)
		{
			if(battle.ANIMATION == BattleGroundButttons.AnimState.WALK)
			{
	
				
				//Debug.Log("front wwalk..");
				my_Player.transform.position =new Vector3(my_Player.transform.position.x+0.04f,my_Player.transform.position.y,my_Player.transform.position.z);
				
				
			}
			if(battle.ANIMATION == BattleGroundButttons.AnimState.BACK_WALK)
			{
				
				
				//Debug.Log("back walk...");
				my_Player.transform.position =new Vector3(my_Player.transform.position.x-0.04f,my_Player.transform.position.y,my_Player.transform.position.z);
				
			}
		
			if(battleOpp.ANIMATION == BattleGroundButttons.AnimState.BACK_WALK)
			{
				
				//Debug.Log("back walk...oppp");
				
				opp_Player.transform.position =new Vector3(opp_Player.transform.position.x+0.04f,opp_Player.transform.position.y,opp_Player.transform.position.z);
	
			}
			
			if(battleOpp.ANIMATION == BattleGroundButttons.AnimState.WALK)
			{
				
				//Debug.Log("front walk...oppp");
				
				opp_Player.transform.position =new Vector3(opp_Player.transform.position.x-0.04f,opp_Player.transform.position.y,opp_Player.transform.position.z);
	

			}
	
		}
	
	
	}
}
