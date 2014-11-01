using UnityEngine;
using System.Collections;
 
public class AutoType : MonoBehaviour 
{
	public float letterPause = 0.2f;
	public GUIText text1;
	public GUIText text2;
	public int clickcount;
 	public bool i;
	public bool j;
	public int dialogCnt = 0;
	string[] level3Dialog = {"I heard Ol’ Farmer McGee is missing 12 chickens this time",
							 "That old man is full of tales o’ lore and dark magic. \nNothing but stories to scare the little ones if you ask me",
							 "He says it happens in the middle of the night, with no \ntrace of the thieves, but a feelin’ o’ dark magic in the \nair come mornin.",
							 "Oh, yes.. yes… next he’ll be fillin your head with \nstories of the dark kind beyond the broken bridge I suppose?",
							 "And just where do you suppose his chickens is goin \nthen?",
							 "How would I know?... probably being eaten by that \nvery large wife of his!  Ha Ha!..."
							};
	
	void Start () 
	{
		//message = level3Dialog[dialogCnt].ToString() ;
		//text1.text = "";
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{	
			StartCoroutine(TypeText ());
			clickcount++;
			if(clickcount==1)
			{
				dialogCnt =0;
			}
			if(clickcount==2)
			{
				dialogCnt =1;
			}
			if(clickcount==3)
			{
				dialogCnt =2;
			}
			if(clickcount==4)
			{
				dialogCnt =3;
			}
			if(clickcount==5)
			{
				dialogCnt =4;
			}
			if(clickcount==6)
			{
				dialogCnt =5;
			}
		}
		
	}
	
	IEnumerator TypeText () 
	{
		if (dialogCnt <= 5)
		{
			if (dialogCnt % 2 == 0)
			{
				foreach (char letter in level3Dialog[dialogCnt].ToCharArray()) 
				{
						text1.text += letter;
						yield return 0;
						yield return new WaitForSeconds (letterPause);      
				}
				
				dialogCnt++;
			}
			else
			{
				foreach (char letter in level3Dialog[dialogCnt].ToCharArray()) 
				{
						text2.text += letter;
						yield return 0;
						yield return new WaitForSeconds (letterPause);
				}
				dialogCnt++;
				
				yield return new WaitForSeconds(1);
				text1.text  = "";
				text2.text  = "";
				
			}
		}
	}
}