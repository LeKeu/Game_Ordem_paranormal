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
    float rand_number;

    //ANIMATION
    Transform trans; 
    SpriteRenderer sr;
    public Animator animator;

    AudioSource baterAudio;

    // Start is called before the first frame update
    void Start()
    {
        auxSeg = 0;
        aux = velInimigo;
        baterAudio = GameObject.Find("bater_barto").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        trans = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        rand_number = Random.Range(3f, 8f);
        StartCoroutine(DashTeste());

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

        rb.drag = 20;
        dist = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direc = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, velInimigo * Time.deltaTime);
        
        auxSeg += Time.deltaTime;
        //Debug.Log(auxSeg);
        if(auxSeg >= rand_number)
        {
            Debug.Log(rand_number);
            StartCoroutine(DashTeste());
            auxSeg = 0;
        }
        
        

    }

    IEnumerator DashTeste()
    {

        velInimigo = velDash;
        animator.SetBool("Correr", true);
        yield return new WaitForSeconds(duracaoDash);
        animator.SetBool("Correr", false);
        velInimigo = aux;
        rand_number = Random.Range(3f, 8f);

        Debug.Log(rand_number);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            baterAudio.Play();
        }
    }

}
