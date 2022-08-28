using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRanged : MonoBehaviour
{
    public float movSpeed;
    GameObject player;
    GameObject shotPoint;
    Transform arma;

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
        shotPoint = GameObject.Find("shotPoint");
        arma = gameObject.transform.Find("armaRanged");
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = 20;
        Vector3 differ = player.gameObject.transform.position - arma.position;
        float rotz = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
        arma.rotation = Quaternion.Euler(0f, 0f, rotz);

        if (Vector2.Distance(transform.position, player.gameObject.transform.position) <= followPlyrRange 
            && Vector2.Distance(transform.position,player.gameObject.transform.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (Vector2.Distance(transform.position, player.gameObject.transform.position) <= attackRange)
        {
            if (timeBetwShots <= 0)
            {
                Instantiate(enemyProject, shotPoint.transform.position, shotPoint.transform.rotation);
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
            transform.position = Vector2.MoveTowards(transform.position, player.gameObject.transform.position, movSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlyrRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
