using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        dustRend = GetComponent<ParticleSystemRenderer>();
        t = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        activeSpeed = vel;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        transform.Translate(moveInput * Time.deltaTime * activeSpeed);

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
