using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		StartCoroutine(NextLevel());
	}

	private void Defeat()
	{
		Debug.Log("You lose...");
	}

	private IEnumerator NextLevel()
	{
		yield return new WaitForSecondsRealtime(2);

		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		yield return null;
	}
}
