
var Contents:GameObject[];
var darkLengthCount : int;

function AddItem1(Item:GameObject)
{
	var newContents=new Array(Contents);
	newContents.Add(Item);
	Contents=newContents.ToBuiltin(GameObject);
	darkLengthCount = Contents.Length;
}

function Update()
{
	darkLengthCount = Contents.Length;
}

function RemoveItem1(Item:GameObject)
{
	print("made it here");
	var newContents=new Array(Contents);
	var index=0;
	var shouldend=false;
	for(var i:GameObject in newContents)
	{
		if(i==Item)
		{
			newContents.RemoveAt(index);
			shouldend=true;
		}
		
		index++;
		darkLengthCount = Contents.Length;
		
		if(shouldend)
		{
			Contents=newContents.ToBuiltin(GameObject);
			return;
		}
	}
}
