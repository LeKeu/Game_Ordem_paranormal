using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    //#########################
    [SerializeField] Transform pointer;
    [SerializeField] GameObject balaShell;
    //#########################
    [SerializeField] LayerMask AoE;

    //#########################
    [Header("Balas")]
    public GameObject bala;
    public Transform balaTransf;
    public GameObject balaEsp;
    public Transform balaEspTransf;


    [Header("Bala NORMAL")]
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    [Header("Bala ESPECIAL")]
    public bool canFireE;
    private float timerE;
    public float timeBetweenFiringE;

    [Header("EXPLOSION")]
    public bool canFireEx;
    private float timerEx;
    public float timeBetweenFiringEx;
    public float rangeExpl;


    private void Awake()
    {
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (!canFireE)
        {
            timerE += Time.deltaTime;
            if (timerE > timeBetweenFiringE)
            {
                canFireE = true;
                timerE = 0;
            }
        }

        if (!canFireEx)
        {
            timerEx += Time.deltaTime;
            if (timerEx > timeBetweenFiringEx)
            {
                canFireEx = true;
                timerEx = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            AtirarNormal();
            Instantiate(balaShell, transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1) && canFireE)
        {
            AtirarEsp();
            Instantiate(balaShell, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.V) && canFireEx)
        {
            Debug.Log("entrou explosao");
            Explosion();
        }

    }

    public void AtirarNormal()
    {
        canFire = false;
        Instantiate(bala, balaTransf.position, Quaternion.identity);
        
        //Debug.Log(balaTransf.position);
        cinemachineShake.Instance.shakeCam(5f, .1f);
    }

    public void AtirarEsp()
    {
        Vector3 posE = new Vector3(pointer.position.x, pointer.position.y, 0);

        canFireE = false;
        Instantiate(balaEsp, posE, Quaternion.identity);
       
        //Debug.Log(balaEspTransf.position);
        cinemachineShake.Instance.shakeCam(5f, .1f);
    }

    public void Explosion()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(origin, rangeExpl, AoE);

        foreach (Collider2D c in colliders)
        {
            if (c.GetComponent<inimigoVida>())
            {
                c.GetComponent<inimigoVida>().ExplDamage();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeExpl);
    }


}
