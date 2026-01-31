using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Key, Scissor, Rug }

public class Item : MonoBehaviour
{
	public ItemType type;
	public Sprite asUsedSprite;

	public Sprite inHandSprite;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if(player.ItemInHand == null)
		{
			player.ItemInHand = this;
			gameObject.SetActive(false);
		}
	}
}
