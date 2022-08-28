using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class highScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreTXT;
    [SerializeField] KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        highScoreTXT.text = "H I G H  S C O R E : " + PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            SceneManager.LoadScene("SampleScene");
        }   
    }
}
