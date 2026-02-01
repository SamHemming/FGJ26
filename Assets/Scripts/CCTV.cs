using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    public float speed = 1;
    public float2 rotationLimit;
    public GameObject hinge;
    public GameObject viewCone;

    public Sprite left,center,right;

    public bool IsActive
    {
        set
        {
            isActive = value;
            if(!value)
            {
                viewCone.SetActive(false);
            }
        }
        get
        {
            return isActive;
        }    
    }
    private bool isActive = true;

    private SpriteRenderer sr;

    private bool cw = true;
    private float third;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        third = (Mathf.Abs(rotationLimit.x) + Mathf.Abs(rotationLimit.y)) / 3f;
    }

    void FixedUpdate()
    {
        if(isActive) Rotate();
    }

    private void Rotate()
    {
        Vector3 newDirection = hinge.transform.localEulerAngles;

        newDirection.z += speed * Time.deltaTime * (cw? -1 : 1);

        if(Mathf.DeltaAngle(newDirection.z, rotationLimit.x) > 1 && cw) //cw limit reached
        {
            cw = false;
        }
        if(Mathf.DeltaAngle(newDirection.z, rotationLimit.y) < 1 && !cw) //ccw limit reached
        {
            cw = true;
        }

        hinge.transform.localEulerAngles = newDirection;

        if(Mathf.DeltaAngle(newDirection.z, rotationLimit.x) > -third)
        {
            //face right
            sr.sprite = right;
        }
        else if(Mathf.DeltaAngle(newDirection.z, rotationLimit.y) < third)
        {
            //face left
            sr.sprite = left;
        }
        else
        {
            sr.sprite = center;
        }
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if(player == null) return;
        
        StageManager.Singleton.Defeat();
    }
}
