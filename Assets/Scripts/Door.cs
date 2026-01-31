using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if(player.ItemInHand != null && player.ItemInHand.type == ItemType.Key)
		{
			player.ItemInHand = null;
			Destroy(gameObject);
		}
	}
}
