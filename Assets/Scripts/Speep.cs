using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speep : MonoBehaviour
{
	public Sprite maskedSprite;
	public bool isMasked = false;

	private SpriteRenderer sr;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();	
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isMasked) sr.sprite = maskedSprite;
		isMasked = true;
		StageManager.Singleton.CheckMasks();
	}
}
