
var Contents:GameObject[];
var QuestLengthCount : int;

function AddItem2(Item:GameObject)
{
	var newContents=new Array(Contents);
	newContents.Add(Item);
	Contents=newContents.ToBuiltin(GameObject);
	QuestLengthCount = Contents.Length;
}

function Update()
{
	QuestLengthCount = Contents.Length;
}

function RemoveItem2(Item:GameObject)
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
		QuestLengthCount = Contents.Length;
		
		if(shouldend)
		{
			Contents=newContents.ToBuiltin(GameObject);
			return;
		}
	}
}
