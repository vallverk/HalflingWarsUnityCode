
var isStackable2=false;
var maxStack2=9;

var spr2 : SpriteText;
var QuesttaskNumber =0;

function OnMouseDown()
{
	if(!collider.isTrigger)
	{
		var playersinv2=FindObjectOfType(Inventory2);
		playersinv2.AddItem2(this.gameObject);
		MoveMeToThePlayer(playersinv2.transform);
	}
}

function MoveMeToThePlayer(theplayer:Transform)
{
	transform.collider.isTrigger=true;
	transform.renderer.enabled=false;
	transform.parent=theplayer;
	transform.localPosition=Vector3.zero;
}

function BeDropped()
{
	transform.collider.isTrigger=false;
	transform.renderer.enabled=true;
	transform.parent=null;
}