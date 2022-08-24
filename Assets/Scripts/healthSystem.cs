using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;
    int health;
    int healthMax;

    public healthSystem(int healthMax) {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    public void Dano(int qntdDano)
    {
        health -= qntdDano;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Cura(int qntdCura)
    {
        health += qntdCura;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }


}
