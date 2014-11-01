
var isStackable=false;
var maxStack=9;

var spr : SpriteText;
var HalflingtaskNumber =0;

function OnMouseDown()
{
	if(!collider.isTrigger)
	{
		var playersinv=FindObjectOfType(Inventory);
		playersinv.AddItem(this.gameObject);
		MoveMeToThePlayer(playersinv.transform);
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