var backDrop:Texture2D;
var errorTexture:Texture2D;
var windowPosition:Vector2=Vector2(0,0);
var windowSize:Vector2=Vector2(96.0,96.0);
var itemIconSize:Vector2=Vector2(350,60);

var updateListDelay=1.0;
var lastUpdate=0.0;
var UpdatedList:GameObject[];
var associatedInventory:Inventory;
var tas : disableScript;

var styl : GUIStyle;
var styl3 : GUIStyle;
var styl1 : GUIStyle;
var styl2 : GUIStyle;
var prevTexture :Vector2;
var CurrentTexture :Vector2;
var prevfloat :float;
var oPos :float;
var lent :int;
var tlen :int;

function UpdateInventoryList()
{
	UpdatedList=associatedInventory.Contents;
}

/*
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
	if(tas.HalflingEntry == true)
	{
		var currentX=windowPosition.x;
		var currentY=windowPosition.y;
		
		for(var i:GameObject in UpdatedList)
		{
			var item=i.GetComponent(Item);
			lent = UpdatedList.Length-8f;
			if(Screen.width == 2048 && Screen.height == 1536)
			{	
				tlen = lent*120f;
			}
			else
			{
			tlen = lent*60f;
			}
			
			GUI.BeginGroup(Rect(Screen.width/1.665f,Screen.height/3.657f,Screen.width/2.9257f,Screen.height/1.6168f));
			GUI.DrawTexture(Rect(currentX+(Screen.width/7.877f),currentY+(Screen.height/12.190f)+prevfloat,itemIconSize.x-(Screen.width/4.096f),itemIconSize.y-(Screen.height/15.36f)),backDrop);
			GUI.DrawTexture(Rect(currentX+(Screen.width/256),currentY+(Screen.height/33.391f)+prevfloat,itemIconSize.x-(Screen.width/3.151f),itemIconSize.y-(Screen.height/21.942f)),errorTexture);
			if(Screen.width == 2048 && Screen.height == 1536)
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat,itemIconSize.x,itemIconSize.y),item.spr.Text,styl3))
				{
					tas.HalflingCurrentTaskNumber = item.HalflingtaskNumber;
				}
			}
			else
			{
				if(GUI.Button(Rect(currentX+(Screen.width/204.8f),currentY+(Screen.height/76.8f)+prevfloat,itemIconSize.x,itemIconSize.y),item.spr.Text,styl))
			{
				tas.HalflingCurrentTaskNumber = item.HalflingtaskNumber;
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
						prevTexture = Input.mousePosition;
					}
					if(Input.GetMouseButton(0))
					{
						CurrentTexture = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				
						if((Input.mousePosition.x > 1240f) && (Input.mousePosition.x < 1940f) && (Input.mousePosition.y < 1110f) && (Input.mousePosition.y > 170f))
						{
							prevfloat = ((prevTexture.y - CurrentTexture.y)/3.0f) + oPos;
							if (prevfloat > 0)
							prevfloat = 0;
							if (prevfloat < -(tlen))
							prevfloat = -(tlen);
						}
					}
					if (Input.GetMouseButtonUp(0))
					{
						oPos = prevfloat;
					}
				}
			}
			else
			{
			if(UpdatedList.Length > 8)
			{
				if(Input.GetMouseButtonDown(0))
				{
					prevTexture = Input.mousePosition;
				}
				if(Input.GetMouseButton(0))
				{
					CurrentTexture = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			
					if((Input.mousePosition.x > 620f) && (Input.mousePosition.x < 970f) && (Input.mousePosition.y < 555f) && (Input.mousePosition.y > 85f))
					{
						prevfloat = ((prevTexture.y - CurrentTexture.y)/3.0f) + oPos;
						if (prevfloat > 0)
						prevfloat = 0;
						if (prevfloat < -(tlen))
						prevfloat = -(tlen);
					}
				}
				if (Input.GetMouseButtonUp(0))
				{
					oPos = prevfloat;
				}
			}
			}
			
		}
		
		if(Screen.width == 2048 && Screen.height == 1536)
		{
		if(tas.HalflingCurrentTaskNumber == 31)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market. \nSparks are buried here to grow \nplant type creatures.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 32)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sprouts are grown from burying \nsparks in your plant training \nground.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 33)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pipeweed seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 34)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Turnip seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 41)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Upgrade the Earth training \nground that you had purchased",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 42)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Barg is created by morphing a \nhound by feeding it sparks.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 43)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 44)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source \nof food for the Halfling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you. \nIt can be purchased from the \nMarket.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 51)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market.\nSparks are buried here to grow \nwater type creatures.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 52)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Nix's are grown from burying \nsparks in your water training \nground.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 53)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The stable can be purchased at \nthe market.\nIt produces gold for you by \noffering its husbandry services \nto visitors.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 54)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pumpkin seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 61)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 62)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Nymphs are created by morphing \na Sprout by feeding it Sparks.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 63)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Blacksmith can be purchased \nat the market.\nIt produces gold for you by \noffering its smithing services \nto visitors.",styl2);
		}
		if(tas.HalflingCurrentTaskNumber == 64)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 71)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 72)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pipeweed seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 81)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Draugs are created by morphing \na Nix by feeding it Sparks.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 82)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Cusith's are created by morphing \na Barg by feeding it Sparks.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 83)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 91)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dryads are created by morphing \na Nymph by feeding it Sparks.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 92)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Taverns are a favorite gathering \nplace for Halflings, which is \nwhy it makes so \nmuch gold.\nTaverns can be purchased from \nthe Market.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 93)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Plant Obelisk can be purchased \nat the market.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 101)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 102)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Potato seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 103)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Apothecary is where you \nbrew elixirs and potions made \nfrom herbs in your garden. \nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 104)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 111)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fairlily seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 112)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"water obelisk can be purchased \nat the market.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 121)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dagons are created by morphing \na Draug by feeding it Sparks.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 122)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Watercress seeds can be \npurchased at the market, and \nplanted in your Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 123)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sun Shrines increase your \nproductivity during the night. \nIt can be purchased in the \nMarket.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 124)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 131)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 132)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Vervain seeds can be purchased \nat the market, and planted in \nyour Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 141)
			{
				//GUI.Label(Rect(130,250,550,150),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 142)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Mandrake seeds can be \npurchased at the market, and \nplanted in your Garden.",styl2);
			}
			if(tas.HalflingCurrentTaskNumber == 143)
			{
				//GUI.Label(Rect(130,250,550,150),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl2);
			}
		}
		else
		{
			if(tas.HalflingCurrentTaskNumber == 31)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market. \nSparks are buried here to grow \nplant type creatures.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 32)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sprouts are grown from burying \nsparks in your plant training \nground.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 33)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pipeweed seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 34)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Turnip seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 41)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Upgrade the Earth training \nground that you had purchased",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 42)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Barg is created by morphing a \nhound by feeding it sparks.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 43)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 44)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are the best source \nof food for the Halfling.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you. \nIt can be purchased from the \nMarket.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 51)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"This training ground can be \npurchased from the market.\nSparks are buried here to grow \nwater type creatures.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 52)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Nix's are grown from burying \nsparks in your water training \nground.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 53)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The stable can be purchased at \nthe market.\nIt produces gold for you by \noffering its husbandry services \nto visitors.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 54)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pumpkin seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 61)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 62)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Nymphs are created by morphing \na Sprout by feeding it Sparks.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 63)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Blacksmith can be purchased \nat the market.\nIt produces gold for you by \noffering its smithing services \nto visitors.",styl1);
			}
			if(tas.HalflingCurrentTaskNumber == 64)
			{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear goblin caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 71)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 72)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Pipeweed seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 81)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Draugs are created by morphing \na Nix by feeding it Sparks.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 82)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Cusith's are created by morphing \na Barg by feeding it Sparks.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 83)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 91)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dryads are created by morphing \na Nymph by feeding it Sparks.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 92)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Taverns are a favorite gathering \nplace for Halflings, which is \nwhy it makes so \nmuch gold.\nTaverns can be purchased from \nthe Market.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 93)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Plant Obelisk can be purchased \nat the market.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 101)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 102)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Potato seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 103)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"The Apothecary is where you \nbrew elixirs and potions made \nfrom herbs in your garden. \nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 104)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 111)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Fairlily seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 112)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"water obelisk can be purchased \nat the market.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 121)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Dagons are created by morphing \na Draug by feeding it Sparks.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 122)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Watercress seeds can be \npurchased at the market, and \nplanted in your Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 123)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Sun Shrines increase your \nproductivity during the night. \nIt can be purchased in the \nMarket.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 124)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 131)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/4.267f),"Gardens are essential for any \nHalfling to live.\nThey produce crops for creature \nfood, herbs for your apothecary \nand gold for you.\nIt can be purchased from the \nMarket.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 132)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Vervain seeds can be purchased \nat the market, and planted in \nyour Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 141)
		{
				//GUI.Label(Rect(130,250,550,150),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 142)
		{
				GUI.Label(Rect(Screen.width/7.88f,Screen.height/3.072f,Screen.width/1.86f,Screen.height/5.12f),"Mandrake seeds can be \npurchased at the market, and \nplanted in your Garden.",styl1);
		}
		if(tas.HalflingCurrentTaskNumber == 143)
		{
				//GUI.Label(Rect(130,250,550,150),"Using your creatures to attack \nand clear Troll caves increases \nyour land holdings and earns \nyou gold and experience.",styl1);
			}
		}
	}
}*/

function FixedUpdate()
{
	if(Time.time>lastUpdate)
	{
		lastUpdate=Time.time+updateListDelay;
		UpdateInventoryList();
	}
}