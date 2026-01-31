using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	public static StageManager Singleton;
	public List<Speep> speeps = new List<Speep>();


	private void Start()
	{
		if (Singleton != null)
			GameObject.Destroy(this.gameObject);
		Singleton = this;

		speeps.AddRange(FindObjectsByType<Speep>(FindObjectsSortMode.None));
	}

	public void CheckMasks()
	{
		bool isAllMasked = true;
		foreach(var speep in speeps)
		{
			if(!speep.isMasked)
			{ 
				isAllMasked = false;
				break;
			}
		}

		if (isAllMasked) Victory();
	}

	private void Victory()
	{
		Debug.Log("You win!");
	}

	private void Defeat()
	{
		Debug.Log("You lose...");
	}
}
