using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    public Sprite shutDownSprite;
    public CCTV cctv;

    private bool isActive = true;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if(isActive && player.ItemInHand != null && player.ItemInHand.type == ItemType.Scissor)
		{
			player.ItemInHand = null;
            sr.sprite = shutDownSprite;
            isActive = false;
            cctv.IsActive = false;
		}
	}
}
