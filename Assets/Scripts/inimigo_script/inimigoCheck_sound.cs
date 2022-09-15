using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoCheck_sound : MonoBehaviour
{
    [SerializeField] AudioClip[] pigSoundList;
    AudioSource auxPig;
    bool waitPig = true;
    //########################
    [SerializeField] AudioClip[] dogSoundList;
    AudioSource auxDog;
    bool waitDog = true;
    //#######################
    [SerializeField] AudioClip[] snakeSoundList;
    AudioSource auxSnake;
    bool waitSnake = true;
    //#######################
    [SerializeField] AudioClip[] bartoSoundList;
    AudioSource auxBarto;
    bool waitBarto = true;

    // Start is called before the first frame update
    void Start()
    {
        auxPig = GameObject.Find("pig").GetComponent<AudioSource>();
        auxDog = GameObject.Find("dog").GetComponent<AudioSource>();
        auxSnake = GameObject.Find("snake").GetComponent<AudioSource>();
        auxBarto = GameObject.Find("barto").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("InimigoNormal(Clone)") != null && waitPig)
        {
            StartCoroutine(SoundsPig());
        }

        if (GameObject.Find("InimigoFast(Clone)") != null && waitDog)
        {
            StartCoroutine(SoundsDog());
        }
        if (GameObject.Find("InimigoRanged(Clone)") != null && waitSnake)
        {
            StartCoroutine(SoundsSnake());
        }
        if (GameObject.Find("IniBoss1(Clone)") != null && waitBarto)
        {
            StartCoroutine(SoundsBarto());
        }
    }

    IEnumerator SoundsPig()
    {
        AudioClip clip = pigSoundList[Random.Range(0, pigSoundList.Length)];
        auxPig.PlayOneShot(clip);
        waitPig = false;
        yield return new WaitForSeconds(6);
        waitPig = true;
    }

    IEnumerator SoundsDog()
    {
        AudioClip clip = dogSoundList[Random.Range(0, dogSoundList.Length)];
        auxDog.PlayOneShot(clip);
        waitDog = false;
        yield return new WaitForSeconds(5);
        waitDog = true;
    }

    IEnumerator SoundsSnake()
    {
        AudioClip clip = snakeSoundList[Random.Range(0, snakeSoundList.Length)];
        auxSnake.PlayOneShot(clip);
        waitSnake = false;
        yield return new WaitForSeconds(4);
        waitSnake = true;
    }

    IEnumerator SoundsBarto()
    {
        AudioClip clip = bartoSoundList[Random.Range(0, bartoSoundList.Length)];
        auxBarto.PlayOneShot(clip);
        waitBarto = false;
        yield return new WaitForSeconds(5);
        waitBarto = true;
    }
}
