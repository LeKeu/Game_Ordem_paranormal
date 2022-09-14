using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobra_anim : MonoBehaviour
{
    Transform trans;
    GameObject player;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
