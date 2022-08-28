using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float forca;

    public HealthBar healthBar;
    score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindObjectOfType<score>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            scoreScript.SalvarScore();
            SceneManager.LoadScene("Menu");
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
        else if (collision.gameObject.tag == "InimigoBoss")
        {
            Dano(50);
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
