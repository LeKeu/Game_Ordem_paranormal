using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    int scr;
    [SerializeField] TextMeshProUGUI normalScoreTXT;

    // Start is called before the first frame update
    void Start()
    {
        scr = 0;
    }

    // Update is called once per frame
    void Update()
    {
        normalScoreTXT.text = "S C O R E : " + scr;
    }

    public void aumentarScoreN()
    {
        scr += 100;
    }

    public void aumentarScoreFast()
    {
        scr += 60;
    }

    public void aumentarScoreRanged()
    {
        scr += 80;
    }

    public void aumentarScoreBoss()
    {
        scr += 300;
    }

    public void SalvarScore()
    {
        if (scr > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", scr);
        }
    }

}
