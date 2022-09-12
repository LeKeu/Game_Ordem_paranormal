using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plyrMov : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer t;
    [SerializeField] float vel;
    Vector2 moveInput;
    public ParticleSystem dust;
    ParticleSystemRenderer dustRend;
    
    //aaaaaaaaaaaaaaaa

    private float activeSpeed;
    public float dashVel;

    public float tamanhoDash = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    bool teste = false;

    [SerializeField] KeyCode tecla;
    [SerializeField] Image imgCDDash;

    AudioSource correrAudio;
    bool tocar;
    // Start is called before the first frame update
    void Start()
    {
        tocar = false;
        correrAudio = GameObject.Find("correr").GetComponent<AudioSource>();

        dustRend = GetComponent<ParticleSystemRenderer>();
        t = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        imgCDDash.fillAmount = 0.0f;
        activeSpeed = vel;
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.drag = 20;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        transform.Translate(moveInput * Time.deltaTime * activeSpeed);

        if (moveInput == Vector2.zero)
        {
            correrAudio.Stop();
        }
        else
        {
            if (!correrAudio.isPlaying)
            {
                correrAudio.Play();
            }
        }

        if (moveInput.x == -1)
        {
            
            if (!teste)
            {
                Flipar1();
                teste = true;
            }
        }

        if (moveInput.x == 1)
        {
            if (teste)
            {
                Flipar2();
                teste = false;
            }
        }
        
        if (Input.GetKeyDown(tecla))
        {
            CriarDust();
            imgCDDash.fillAmount = 1f;
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeSpeed = dashVel;
                dashCounter = tamanhoDash;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                imgCDDash.fillAmount = 0f;
                activeSpeed = vel;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;  
        }
    }

    void Flipar1()
    {
        t.flipX = true;
        CriarDust();
    }

    void Flipar2()
    {
        t.flipX = false;
        CriarDust();
    }

    void CriarDust()
    {
        dust.Play();
    }
}
