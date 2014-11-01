var backDrop:Texture2D;
var errorTexture:Texture2D;
var windowPosition:Vector2=Vector2(0,0);
var windowSize:Vector2=Vector2(96.0,96.0);
var itemIconSize:Vector2=Vector2(350,80);

var updateListDelay=1.0;
var lastUpdate=0.0;
var UpdatedList:GameObject[];
var associatedInventory:Inventory2;
var tas2 : disableScript;

var styl : GUIStyle;
var styl3 : GUIStyle;
var styl1 : GUIStyle;
var styl2 : GUIStyle;
var prevTexture2 :Vector2;
var CurrentTexture2 :Vector2;
var prevfloat2 :float;
var oPos2 :float;
var lent2 :int;
var tlen2 :int;

function UpdateInventoryList()
{
	UpdatedList=associatedInventory.Contents;
}

function OnGUI()
{	
	if(Screen.width == 2048 && Screen.height == 1536)
	{	
		windowSize = Vector2(700,950);
		itemIconSize = Vector2(700,160);
	}
	else
	{
		windowSize = Vector2(350,475);
		itemIconSize = Vector2(350,80);
	}
	if(tas2.QuestLogEntry == true)
	{
		var currentX=windowPosition.x;
		var currentY=windowPosition.y;
		
		for(var i:GameObject in UpdatedList)
		{
			var item=i.GetComponent(Item2);
			lent2 = UpdatedList.Length-6f;
			if(Screen.width == 2048 && Screen.height == 1536)
			{	
				tlen2 = lent2*160f;
			}
			else
			{
			tlen2 = lent2*80f;
			}
			
			GUI.BeginGroup(Rect(Screen.width/1.665f,Screen.height/3.657f,Screen.width/2.9257f,Screen.height/1.6168f));
			GUI.DrawTexture(Rect(currentX+(Screen.width/7.877f),currentY+(Screen.height/9.035f)+prevfloat2,itemIconSize.x-(Screen.width/4.096f),itemIconSize.y-(Screen.height/10.971f)),backDrop);
			GUI.DrawTexture(Rect(currentX+(Screen.width/256),currentY+(Screen.height/33.391f)+prevfloat2,itemIconSize.x-(Screen.width/3.151f),itemIconSize.y-(Screen.height/13.9636f)),errorTexture);
			if(Screen.width == 2048 && Screen.height == 1536)
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat2,itemIconSize.x,itemIconSize.y),item.spr2.Text,styl3))
				{
					tas2.QuestCurrentTaskNumber = item.QuesttaskNumber;
				}
			}
			else
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat2,itemIconSize.x,itemIconSize.y),item.spr2.Text,styl))
				{
					tas2.QuestCurrentTaskNumber = item.QuesttaskNumber;
					Debug.Log("aaa : "+item.spr2.Text);
					Debug.Log("QuestCurrentTaskNumber : "+tas2.QuestCurrentTaskNumber);
				}
			}
			currentX+=itemIconSize.x;
			if(currentX+itemIconSize.x>windowPosition.x+windowSize.x)
			{
				currentX=windowPosition.x;
				currentY+=itemIconSize.y;
				if(currentY+itemIconSize.y>windowPosition.y+windowSize.y)
				{
					//return;
				}
			}
			GUI.EndGroup();
			if(Screen.width == 2048 && Screen.height == 1536)
			{
				if(UpdatedList.Length > 6)
				{
					if(Input.GetMouseButtonDown(0))
					{
						prevTexture2 = Input.mousePosition;
					}
					if(Input.GetMouseButton(0))
					{
						CurrentTexture2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				
						if((Input.mousePosition.x > 1240f) && (Input.mousePosition.x < 1940f) && (Input.mousePosition.y < 1110f) && (Input.mousePosition.y > 170f))
						{
							prevfloat2 = ((prevTexture2.y - CurrentTexture2.y)/3.0f) + oPos2;
							if (prevfloat2 > 0)
							prevfloat2 = 0;
							if (prevfloat2 < -(tlen2))
							prevfloat2 = -(tlen2);
						}
					}
					if (Input.GetMouseButtonUp(0))
					{
						oPos2 = prevfloat2;
					}
				}
			}
			else
			{
			if(UpdatedList.Length > 6)
			{
				if(Input.GetMouseButtonDown(0))
				{
					prevTexture2 = Input.mousePosition;
				}
				if(Input.GetMouseButton(0))
				{
					CurrentTexture2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			
					if((Input.mousePosition.x > 620f) && (Input.mousePosition.x < 970f) && (Input.mousePosition.y < 555f) && (Input.mousePosition.y > 85f))
					{
						prevfloat2 = ((prevTexture2.y - CurrentTexture2.y)/3.0f) + oPos2;
						if (prevfloat2 > 0)
						prevfloat2 = 0;
						if (prevfloat2 < -(tlen2))
						prevfloat2 = -(tlen2);
					}
				}
				if (Input.GetMouseButtonUp(0))
				{
					oPos2 = prevfloat2;
				}
			}
		}
		}
		if(Screen.width == 2048 && Screen.height == 1536)
		{
			if(tas2.QuestCurrentTaskNumber == 41)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Let Farmer McGee borrow your \nHound.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 51)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Rebuild the bridge over the \nChasm.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 61)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Let Uncle Brentas borrow your \nLeech.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 71)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Morph your Hound into a Barg.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 81)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Deliver pumpkins to Widow \nStufflebrew.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 91)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Deliver pumpkins to Widow \nStufflebrew.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 101)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Build a Tavern.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 111)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Grow Aven and deliver it to \nWidow Stufflebrew.",styl2);
			}
			if(tas2.QuestCurrentTaskNumber == 121)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Build an Alchemy.",styl2);
			}
		}
		else
		{
			if(tas2.QuestCurrentTaskNumber == 41)
			{
				Debug.Log("First Story");
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Let Farmer McGee borrow your \nHound.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 51)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Rebuild the bridge over the \nChasm.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 61)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Let Uncle Brentas borrow your \nLeech.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 71)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Morph your Hound into a Barg.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 81)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Deliver pumpkins to Widow \nStufflebrew.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 91)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Deliver pumpkins to Widow \nStufflebrew.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 101)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Build a Tavern.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 111)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Grow Aven and deliver it to \nWidow Stufflebrew.",styl1);
			}
			if(tas2.QuestCurrentTaskNumber == 121)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Build an Alchemy.",styl1);
			}
		}
	}
}


function FixedUpdate()
{
	if(Time.time>lastUpdate)
	{
		lastUpdate=Time.time+updateListDelay;
		UpdateInventoryList();
	}
}