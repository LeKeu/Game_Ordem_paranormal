using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirar : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    //#########################
    public GameObject bala;
    public Transform balaTransf;
    public GameObject balaEsp;
    public Transform balaEspTransf;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public bool canFireE;
    private float timerE;
    public float timeBetweenFiringE;
    //#########################
    [SerializeField] Transform pointer;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();  
        //pointer = GetComponent<Transform>();
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

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            
            canFire = false;
            Instantiate(bala, balaTransf.position, Quaternion.identity);
            //Debug.Log(balaTransf.position);
            cinemachineShake.Instance.shakeCam(5f, .1f);    
            
        }
        if (Input.GetMouseButtonDown(1) && canFireE)
        {
            Vector3 posE = new Vector3(pointer.position.x, pointer.position.y, 0);
            
            canFireE = false;
            Instantiate(balaEsp, posE, Quaternion.identity);
            //Debug.Log(balaEspTransf.position);
            cinemachineShake.Instance.shakeCam(5f, .1f);
        }
        
    }

    
}
