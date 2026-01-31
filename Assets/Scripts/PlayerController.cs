using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementSpeed = Vector2.one;
    private Item itemInHand;
    public Item ItemInHand
    {
        get => itemInHand;
        
        set
        {
            itemInHand = value;
            if(value != null)
                handSlot.sprite = value.inHandSprite;
            else handSlot.sprite = null;
        }
    }
    public Sprite key, scissor, rug;
    public SpriteRenderer handSlot;

    private Animator animator;
    private Vector2 inputVector = Vector2.zero;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isMoving = false;

    void Start()
    {
        if(!TryGetComponent<Rigidbody2D>(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            //add RB settings???
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if(!TryGetComponent<Animator>(out animator))
        {
            Debug.LogError("CANT FIND ANIMATOR!");
        }
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        animator.SetBool("isMoving", (inputVector.magnitude != 0));

        if (inputVector.x != 0) //moving
        {

            if ((inputVector.x > 0) != isFacingRight)
            {
                //flip texture
                isFacingRight = (inputVector.x > 0);
                gameObject.transform.localScale = new Vector3( (isFacingRight)? 1 : -1 ,1,1);
            }
        }
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + (inputVector * movementSpeed * Time.deltaTime));
	}
}
