using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isArmed = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isArmed) return;

        var player = collider.gameObject.GetComponent<PlayerController>();
        if(player == null) return;

        if(player.ItemInHand != null && player.ItemInHand.type == ItemType.Rug)
        {
            //disarm trap
            sr.sprite = player.ItemInHand.asUsedSprite;
            Destroy(player.ItemInHand);
            player.ItemInHand = null;
            isArmed = false;
        }
        else
        {
            //gameover
            StageManager.Singleton.Defeat();
            player.Trapped();
        }
    }
}
