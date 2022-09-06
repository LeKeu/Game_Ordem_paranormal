using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDash : MonoBehaviour
{
    GameObject player;
    public float velInimigo;
    Rigidbody2D rb;
    float dist;
    [SerializeField] float velDash;
    [SerializeField] float intervTempo;
    [SerializeField] float duracaoDash;
    float auxSeg;
    float aux;
    bool canDash;

    // Start is called before the first frame update
    void Start()
    {
        auxSeg = 0;
        aux = velInimigo;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        StartCoroutine(DashTeste());
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = 20;
        dist = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direc = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velInimigo * Time.deltaTime);
        
        auxSeg += Time.deltaTime;
        Debug.Log(auxSeg);
        if(auxSeg >= intervTempo)
        {
            StartCoroutine(DashTeste());
            auxSeg = 0;
        }
        
        

    }

    IEnumerator DashTeste()
    {
        velInimigo = velDash;
        Debug.Log("O BOSS TA RAPIDAO MN");
        yield return new WaitForSeconds(duracaoDash);
        velInimigo = aux;
    }

}
