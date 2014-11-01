
var Contents:GameObject[];
var halfLengthCount : int;

function AddItem(Item:GameObject)
{
	var newContents=new Array(Contents);
	newContents.Add(Item);
	Contents=newContents.ToBuiltin(GameObject);
	halfLengthCount = Contents.Length;
}

function Update()
{
	halfLengthCount = Contents.Length;
}

function RemoveItem(Item:GameObject)
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
		halfLengthCount = Contents.Length;
		
		if(shouldend)
		{
			Contents=newContents.ToBuiltin(GameObject);
			return;
		}
	}
}
