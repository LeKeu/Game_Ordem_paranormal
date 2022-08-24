using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    healthSystem healthSys;

    public void SetUp(healthSystem healthSys)
    {
        this.healthSys = healthSys;
        healthSys.OnHealthChanged += healthSystem_OnHealthChanged;
    }

    private void healthSystem_OnHealthChanged(object slender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSys.GetHealthPercent(), 1);
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }
}
