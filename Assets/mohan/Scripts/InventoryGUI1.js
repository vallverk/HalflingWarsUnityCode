var backDrop:Texture2D;
var errorTexture:Texture2D;
var windowPosition:Vector2=Vector2(0,0);
var windowSize:Vector2=Vector2(96.0,96.0);
var itemIconSize:Vector2=Vector2(350,60);

var updateListDelay=1.0;
var lastUpdate=0.0;
var UpdatedList:GameObject[];
var associatedInventory:Inventory1;
var tas1 : disableScript;

var styl : GUIStyle;
var styl3 : GUIStyle;
var styl1 : GUIStyle;
var styl2 : GUIStyle;
var prevTexture1 :Vector2;
var CurrentTexture1 :Vector2;
var prevfloat1 :float;
var oPos1 :float;
var lent1 :int;
var tlen1 :int;

function UpdateInventoryList()
{
	UpdatedList=associatedInventory.Contents;
}

function OnGUI()
{	
	if(Screen.width == 2048 && Screen.height == 1536)
	{	
		windowSize = Vector2(700,950);
		itemIconSize = Vector2(700,120);
	}
	else
	{
		windowSize = Vector2(350,475);
		itemIconSize = Vector2(350,60);
	}
	if(tas1.DarklingEntry == true)
	{
		var currentX=windowPosition.x;
		var currentY=windowPosition.y;
		
		for(var i:GameObject in UpdatedList)
		{
			var item=i.GetComponent(Item1);
			lent1 = UpdatedList.Length-8f;
			if(Screen.width == 2048 && Screen.height == 1536)
			{	
				tlen1 = lent1*120f;
			}
			else
			{
			tlen1 = lent1*60f;
			}
			
			GUI.BeginGroup(Rect(Screen.width/1.665f,Screen.height/3.657f,Screen.width/2.9257f,Screen.height/1.6168f));
			GUI.DrawTexture(Rect(currentX+(Screen.width/7.877f),currentY+(Screen.height/12.190f)+prevfloat1,itemIconSize.x-(Screen.width/4.096f),itemIconSize.y-(Screen.height/15.36f)),backDrop);
			GUI.DrawTexture(Rect(currentX+(Screen.width/256),currentY+(Screen.height/33.391f)+prevfloat1,itemIconSize.x-(Screen.width/3.151f),itemIconSize.y-(Screen.height/21.942f)),errorTexture);
			if(Screen.width == 2048 && Screen.height == 1536)
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat1,itemIconSize.x,itemIconSize.y),item.spr1.Text,styl3))
				{
					tas1.DarklingCurrentTaskNumber = item.DarklingtaskNumber;
				}
			}
			else
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat1,itemIconSize.x,itemIconSize.y),item.spr1.Text,styl))
			{
				tas1.DarklingCurrentTaskNumber = item.DarklingtaskNumber;
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
				if(UpdatedList.Length > 8)
				{
					if(Input.GetMouseButtonDown(0))
					{
						prevTexture1 = Input.mousePosition;
					}
					if(Input.GetMouseButton(0))
					{
						CurrentTexture1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				
						if((Input.mousePosition.x > 1240f) && (Input.mousePosition.x < 1940f) && (Input.mousePosition.y < 1110f) && (Input.mousePosition.y > 170f))
						{
							prevfloat1 = ((prevTexture1.y - CurrentTexture1.y)/3.0f) + oPos1;
							if (prevfloat1 > 0)
							prevfloat1 = 0;
							if (prevfloat1 < -(tlen1))
							prevfloat1 = -(tlen1);
						}
					}
					if (Input.GetMouseButtonUp(0))
					{
						oPos1 = prevfloat1;
					}
				}
			}
			else
			{
			if(UpdatedList.Length > 8)
			{
				if(Input.GetMouseButtonDown(0))
				{
					prevTexture1 = Input.mousePosition;
				}
				if(Input.GetMouseButton(0))
				{
					CurrentTexture1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			
					if((Input.mousePosition.x > 620f) && (Input.mousePosition.x < 970f) && (Input.mousePosition.y < 555f) && (Input.mousePosition.y > 85f))
					{
						prevfloat1 = ((prevTexture1.y - CurrentTexture1.y)/3.0f) + oPos1;
						if (prevfloat1 > 0)
						prevfloat1 = 0;
						if (prevfloat1 < -(tlen1))
						prevfloat1 = -(tlen1);
					}
				}
				if (Input.GetMouseButtonUp(0))
				{
					oPos1 = prevfloat1;
				}
			}
		}
			
		}
		if(Screen.width == 2048 && Screen.height == 1536)
		{
			if(tas1.DarklingCurrentTaskNumber == 41)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Inn is the Darkling's \nPrimary source of income.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 42)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 43)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pumpkin seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 44)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"In a murky area such as this, a \nwell is necessary to get \ndrinkable water.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 45)
			{
				//GUI.Label(Rect(130,250,550,150),"In a murky area such as this, a \nwell is necessary to get \ndrinkable water.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 51)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market.\nSparks are buried here to grow \nDark Earth type creatures.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 52)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dark Hounds are grown from \nburying sparks in your Dark \nEarth training ground.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 53)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The stable can be purchased at \nthe market.\nIt produces gold for you by \noffering its husbandry services \nto visitors.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 54)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Firepepper seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 55)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 61)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 62)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market. \nSparks are buried here to grow \nfire type creatures.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 63)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sprites are grown from burying \nsparks in your Fire training \nground.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 64)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Blacksmith can be purchased \nat the market. \nIt produces gold for you by \noffering its smithing services \nto visitors.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 71)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling. \nThey produce crops for creature \nfood, \nherbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 72)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Aven seeds can be purchased at \nthe market, and planted in \nyour Garden.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 73)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 81)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fenrirs are created by morphing \na Dark Hound by feeding it \nSparks.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 91)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Imps are created by morphing \na Sprite by feeding it Sparks.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 92)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 101)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 102)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Blackberry seeds can be \npurchased at the market, and \nplanted in your Garden.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 103)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Apothecary is where you \nbrew elixirs and potions made \nfrom herbs in your garden.\nIt can be purchased from the \nMarket.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 111)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Columbine seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 112)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 113)
			{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fire obelisk can be purchased \nat the market.",styl2);
			} 
			if(tas1.DarklingCurrentTaskNumber == 121)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Lurkers are created by morphing \na Leshy by feeding it Sparks.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 122)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Bitterbrush seeds can be \npurchased at the market, and\n planted in your Garden.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 131)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Hell Hounds are created by \nmorphing a Fenrir by feeding \nit Sparks.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 132)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 133)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Bogbean seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 134)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 141)
			{
				//GUI.Label(Rect(130,250,550,150),"Bitterbrush seeds can be \npurchased at the market, and\n planted in your Garden.",styl2);
			}
			if(tas1.DarklingCurrentTaskNumber == 142)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Wolfsbane seeds can be \npurchased at the market, and \nplanted in your Garden",styl2);
			}
		}
		else
		{
		if(tas1.DarklingCurrentTaskNumber == 41)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Inn is the Darkling's \nPrimary source of income.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 42)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 43)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pumpkin seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 44)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"In a murky area such as this, a \nwell is necessary to get \ndrinkable water.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 45)
		{
			//GUI.Label(Rect(130,250,550,150),"In a murky area such as this, a \nwell is necessary to get \ndrinkable water.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 51)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market.\nSparks are buried here to grow \nDark Earth type creatures.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 52)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dark Hounds are grown from \nburying sparks in your Dark \nEarth training ground.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 53)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The stable can be purchased at \nthe market.\nIt produces gold for you by \noffering its husbandry services \nto visitors.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 54)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Firepepper seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 55)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 61)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 62)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market. \nSparks are buried here to grow \nfire type creatures.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 63)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sprites are grown from burying \nsparks in your Fire training \nground.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 64)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Blacksmith can be purchased \nat the market. \nIt produces gold for you by \noffering its smithing services \nto visitors.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 71)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling. \nThey produce crops for creature \nfood, \nherbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 72)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Aven seeds can be purchased at \nthe market, and planted in \nyour Garden.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 73)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 81)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fenrirs are created by morphing \na Dark Hound by feeding it \nSparks.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 91)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Imps are created by morphing \na Sprite by feeding it Sparks.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 92)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 101)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 102)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Blackberry seeds can be \npurchased at the market, and \nplanted in your Garden.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 103)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Apothecary is where you \nbrew elixirs and potions made \nfrom herbs in your garden.\nIt can be purchased from the \nMarket.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 111)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Columbine seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 112)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 113)
		{ 
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fire obelisk can be purchased \nat the market.",styl1);
		} 
		if(tas1.DarklingCurrentTaskNumber == 121)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Lurkers are created by morphing \na Leshy by feeding it Sparks.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 122)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Bitterbrush seeds can be \npurchased at the market, and\n planted in your Garden.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 131)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Hell Hounds are created by \nmorphing a Fenrir by feeding \nit Sparks.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 132)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source of \nfood for the Darkling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 133)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Bogbean seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 134)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 141)
		{
			//GUI.Label(Rect(130,250,550,150),"Bitterbrush seeds can be \npurchased at the market, and\n planted in your Garden.",styl1);
		}
		if(tas1.DarklingCurrentTaskNumber == 142)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Wolfsbane seeds can be \npurchased at the market, and \nplanted in your Garden",styl1);
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