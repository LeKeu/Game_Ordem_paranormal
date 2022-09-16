using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_buts : MonoBehaviour
{
    [SerializeField] Animator transicao;

    public void Sair()
    {
        Application.Quit();
    }

    private void Awake()
    {
        Cursor.visible = true;
    }

    public void Jogar()
    {
        StartCoroutine(LoadJogo());
    }

    IEnumerator LoadJogo()
    {
        transicao.SetTrigger("Start");

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Creditos()
    {
        StartCoroutine(LoadCred());
    }

    IEnumerator LoadCred()
    {
        transicao.SetTrigger("Start");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("creditos");
    }

    public void Tutorial()
    {
        StartCoroutine(LoadTut());
    }

    IEnumerator LoadTut()
    {
        transicao.SetTrigger("Start");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("tutorial");
    }

    public void Personagem()
    {
        StartCoroutine(LoadPers());
    }

    IEnumerator LoadPers()
    {
        transicao.SetTrigger("Start");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Select_personagem");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
        //StartCoroutine(LoadVoltar());
    }

    IEnumerator LoadVoltar()
    {
        transicao.SetTrigger("Start");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
