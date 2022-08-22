using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyrMov : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float vel;
    Vector2 moveInput;
    //aaaaaaaaaaaaaaaa

    private float activeSpeed;
    public float dashVel;

    public float tamanhoDash = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    [SerializeField] KeyCode tecla;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        activeSpeed = vel;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        transform.Translate(moveInput * Time.deltaTime * activeSpeed);

        if (Input.GetKeyDown(tecla))
        {
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
}
