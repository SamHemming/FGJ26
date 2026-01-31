using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speep : MonoBehaviour
{
	public bool isMasked = false;

	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();	
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isMasked)
		{
			isMasked = true;
			animator.SetBool("isMasked", true);
			StageManager.Singleton.CheckMasks();
		}
	}
}
