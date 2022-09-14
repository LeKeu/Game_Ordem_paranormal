using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyr_anim : MonoBehaviour
{
    Transform trans;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public Animator animator;
    bool frenteAux = false;
    
    select_personagem s_persn_script;
    string aux_index;


    string[] persn = new string[] { "animator01", "animator02", "animator03", "animator04", "animator05" };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();

        //PlayerPrefs.GetInt("highscore");

        animator.runtimeAnimatorController = Resources.Load(persn[PlayerPrefs.GetInt("personagem", 0)]) as RuntimeAnimatorController;
    }

    void Update()
    {
        frenteAux = true;
        if (!Input.anyKey)
        {
            animator.SetFloat("Vel", 0);
            animator.SetBool("Frente", true);
        }

        if (Input.GetKeyDown("a")|| Input.GetKeyDown("left"))
        {
            Debug.Log("indo para esquerda");
            animator.SetBool("Frente", false);
            animator.SetFloat("Vel", 1);
            frenteAux = false;
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            Debug.Log("indo para direita");
            animator.SetBool("Frente", false);
            animator.SetFloat("Vel", 1);
            frenteAux = false;
        }

        if(Input.GetKeyDown("s") || Input.GetKeyDown("down") || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            Debug.Log("frente");
            animator.SetBool("Frente", true);
            animator.SetFloat("Vel", 1);
            frenteAux = false;
        }


    }
}
