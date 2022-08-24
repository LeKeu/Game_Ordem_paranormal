using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public Transform pfHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem healthSys = new healthSystem(10);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        healthBar healthBar = healthBarTransform.GetComponent<healthBar>();
        healthBar.SetUp(healthSys);

        Debug.Log("vida = " + healthSys.GetHealthPercent());
        healthSys.Dano(5);
        healthSys.Dano(3);
        Debug.Log("vida = " + healthSys.GetHealthPercent());

        //Debug.Log("vida = " + healthSys.GetHealth());
        healthSys.Cura(33);
        

        //Debug.Log("vida = " + healthSys.GetHealth());

    }

    // 1m55s do codeMonkey

    // Update is called once per frame
    void Update()
    {
        
    }
}
