using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    int health;

    public healthSystem(int health) {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

}
