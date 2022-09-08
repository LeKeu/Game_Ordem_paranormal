using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiChase : MonoBehaviour
{
    GameObject player;
    public float velInimigo;
    Rigidbody2D rb;
    SpriteRenderer sr;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {

        rb.drag = 20;
        dist = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direc = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velInimigo * Time.deltaTime);

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
    }
}
