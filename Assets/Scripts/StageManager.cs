using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
	public static StageManager Singleton;
	public List<Speep> speeps = new List<Speep>();
	public GameObject canvas;
	public GameObject winText;
	public GameObject defeatText;

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
		canvas.SetActive(true);
		winText.SetActive(true);
		StartCoroutine(NextLevel());
	}

	public void Defeat()
	{
		Debug.Log("You lose...");
		canvas.SetActive(true);
		defeatText.SetActive(true);
		StartCoroutine(RestartLevel());
	}

	private IEnumerator NextLevel()
	{
		yield return new WaitForSecondsRealtime(2);

		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		yield return null;
	}

		private IEnumerator RestartLevel()
	{
		yield return new WaitForSecondsRealtime(2);

		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		yield return null;
	}
}
