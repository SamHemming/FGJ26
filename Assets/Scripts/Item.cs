using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Key, Scissor, Rug }

public class Item : MonoBehaviour
{
	public ItemType type;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if(player.itemInHand == null)
		{
			player.itemInHand = this;
			gameObject.SetActive(false);
		}
	}
}
