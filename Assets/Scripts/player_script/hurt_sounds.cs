using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt_sounds : MonoBehaviour
{

    [SerializeField] AudioClip[] hurtSoundList;
    AudioSource aux;
    // Start is called before the first frame update
    void Start()
    {
        aux = GameObject.Find("hurts").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "InimigoFast" || collision.gameObject.tag == "InimigoBoss")
        {
            Sounds();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalaInRanged")
        {
            Sounds();
        }
    }

    void Sounds()
    {
        AudioClip clip = hurtSoundList[Random.Range(0, hurtSoundList.Length)];
        aux.PlayOneShot(clip);
    }
}
