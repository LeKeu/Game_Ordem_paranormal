using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiChase : MonoBehaviour
{
    GameObject player;
    public float velInimigo;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direc = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velInimigo * Time.deltaTime);
    }
}
