using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class select_personagem : MonoBehaviour
{
    public static int persn_index = 0;

    public void Pers01()
    {
        PlayerPrefs.SetInt("personagem", 0);
    }

    public void Pers02()
    {
        PlayerPrefs.SetInt("personagem", 1);
    }

    public void Pers03()
    {
        PlayerPrefs.SetInt("personagem", 2);
    }

    public void Pers04()
    {
        PlayerPrefs.SetInt("personagem", 3);
    }

    public void Pers05()
    {
        PlayerPrefs.SetInt("personagem", 4);
    }


    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }

}
