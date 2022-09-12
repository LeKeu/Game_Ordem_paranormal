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
        player = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.transform.position.x > transform.position.x)
        {
            Debug.Log("player na direita");
            sr.flipX = true;
        }
        else
        {
            Debug.Log("player na esquerda");
            sr.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
