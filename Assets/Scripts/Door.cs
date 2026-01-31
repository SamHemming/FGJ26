using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if(player.itemInHand != null && player.itemInHand.type == ItemType.Key)
		{
			player.itemInHand = null;
			Destroy(gameObject);
		}
	}
}
