using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoVida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] GameObject sangueNormal;
    [SerializeField] GameObject sangueMorte;

    public HealthBar healthBar;
    score scoreScript;
    WaveSp waveScript;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindObjectOfType<score>();
        waveScript = GameObject.FindObjectOfType<WaveSp>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            waveScript.InimiDestr();
            scoreScript.aumentarScoreN();
            Destroy(this.gameObject);
            Instantiate(sangueMorte, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Instantiate(sangueNormal, transform.position, Quaternion.identity);
            Dano(15);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalaEspecial")
        {
            Instantiate(sangueNormal, transform.position, Quaternion.identity);
            Dano(20);
        }
    }

    void Dano(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
