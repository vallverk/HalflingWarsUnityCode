using UnityEngine;
using System.Collections;

public class Aspect : MonoBehaviour 
{
	public float aspect;
	
	void Start () 
	{
		camera.aspect = aspect;
	}
	
	void Update () 
	{
		camera.aspect = aspect;
	}
}
