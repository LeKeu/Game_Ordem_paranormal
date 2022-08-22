using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        healthSystem healthSys = new healthSystem(100);

        Debug.Log("vida = " + healthSys.GetHealth());
    }

    // 1m55s do codeMonkey

    // Update is called once per frame
    void Update()
    {
        
    }
}
