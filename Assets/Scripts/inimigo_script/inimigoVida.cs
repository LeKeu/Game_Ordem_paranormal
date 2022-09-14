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
    AudioSource splat;

    score scoreScript;
    WaveSp waveScript;

    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        splat = GameObject.Find("Splat").GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
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
            splat.Play();
            if (rb2D.gameObject.tag == "Inimigo")
            {
                scoreScript.aumentarScoreN();
            }else if (rb2D.gameObject.tag == "InimigoFast")
            {
                scoreScript.aumentarScoreFast();
            }
            else if (rb2D.gameObject.tag == "InimigoRanged")
            {
                scoreScript.aumentarScoreRanged();
            }
            else if (rb2D.gameObject.tag == "InimigoBoss")
            {
                scoreScript.aumentarScoreBoss();
            }
            waveScript.InimiDestr();
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
            Dano(45);
        }
    }

    public void ExplDamage()
    {
        Instantiate(sangueNormal, transform.position, Quaternion.identity);
        Dano(50);
    }

    void Dano(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
