using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public bool verticalMovement = false;
    public float patrolDistance = 2;
    public float movementSpeed = 1;
    public GameObject hinge;
    public SpriteRenderer altFace;

    private bool isForward = true;
    private Vector2 startPos;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        var moveAmount = movementSpeed * Time.deltaTime * (isForward? 1 : -1);
        rb.MovePosition(transform.position + (verticalMovement? Vector3.up : Vector3.left) * moveAmount);

        if(isForward && Vector2.Distance(startPos, transform.position) > patrolDistance)
        {
            isForward = false;
            transform.localScale = new Vector3(-1, 1, 1);
            if(verticalMovement) hinge.transform.Rotate(Vector3.forward, 180);
        }
        else if(!isForward && Vector2.Distance(startPos, transform.position) < 0.1f)
        {
            isForward = true;
            transform.localScale = new Vector3(1, 1, 1);
            if(verticalMovement) hinge.transform.Rotate(Vector3.forward, 180);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collision(collision.collider);
    }

    private void Collision(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            //player Spotted!!!!
            //gameover
            animator.SetBool("Spotted", true);
            altFace.enabled = true;
            movementSpeed = 0;
            StageManager.Singleton.Defeat();
        }
    }
}
