using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float forca;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var magnitude = 2500;

        var force = transform.position - collision.transform.position;

        force.Normalize();
        GetComponent<Rigidbody2D>().AddForce(force * magnitude);

        if (collision.gameObject.tag == "Inimigo")
        {
            Dano(15);
        }
        else if(collision.gameObject.tag == "InimigoFast")
        {
            Dano(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalaInRanged")
        {
            Dano(20);
        }
    }

    void Dano(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
