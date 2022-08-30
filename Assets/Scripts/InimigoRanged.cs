using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRanged : MonoBehaviour
{
    public float movSpeed;
    GameObject player;
    public GameObject shotPoint;
    GameObject arma;

    public GameObject enemyProject;

    public float followPlyrRange;
    private bool inRange;
    public float attackRange;

    public float startTimeBetwShots;
    private float timeBetwShots;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        //shotPoint = GameObject.Find("shotPoint");
        arma = GameObject.Find("armaRanged");
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = 20;
        Vector2 differ = player.gameObject.transform.position - this.shotPoint.gameObject.transform.position;
        float rotz = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
        this.shotPoint.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotz);

        if (Vector2.Distance(this.transform.position, player.gameObject.transform.position) <= followPlyrRange 
            && Vector2.Distance(this.transform.position,player.gameObject.transform.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (Vector2.Distance(this.transform.position, player.gameObject.transform.position) <= attackRange)
        {
            if (timeBetwShots <= 0)
            {
                Instantiate(enemyProject, this.rb.position, this.shotPoint.transform.rotation);
                timeBetwShots = startTimeBetwShots;
            }
            else
            {
                timeBetwShots -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.gameObject.transform.position, movSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlyrRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
