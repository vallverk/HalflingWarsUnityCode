using UnityEngine;
using System.Collections;

public class paritcleTex : MonoBehaviour 
{
	public Material particleMat;
	public Texture tex01, tex02, tex03;
	
	private int cnt = 0;
	private int index = 0;
	private bool changeTexBool = true;
	
	private int maxCnt = 570;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.gameObject.GetComponent<ParticleSystem>().isPlaying == false)
		{
			index++;
			if (index == 1)
				particleMat.mainTexture = tex01;
			if (index == 2)
				particleMat.mainTexture = tex02;
			if (index == 3)
			{
				particleMat.mainTexture = tex03;
				index = 0;
			}
//			Debug.Log("Particle stop...");
			transform.gameObject.GetComponent<ParticleSystem>().Play();
		}
	}
}
