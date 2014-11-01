
var isStackable1=false;
var maxStack1=9;

var spr1 : SpriteText;
var DarklingtaskNumber =0;

function OnMouseDown()
{
	if(!collider.isTrigger)
	{
		var playersinv1=FindObjectOfType(Inventory1);
		playersinv1.AddItem1(this.gameObject);
		MoveMeToThePlayer(playersinv1.transform);
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