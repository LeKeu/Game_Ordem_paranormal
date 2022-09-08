using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int qntdDeInimigos = 5;
    
    public float spawnIntervalo;
}

public class WaveSp : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI waveTxt;

    [SerializeField] Wave[] waves;
    int indexWave;

    Wave auxWave;
    public Transform[] spawnPoints;
    public GameObject[] tipoDeInimigos;
    public GameObject[] inimigoBoss;
    int qntdInim;
    int qntdInmAux;
    private float nextSpawnTime;
    List<GameObject> inimigosOn = new List<GameObject>();

    bool canSpawn = true;

    private void Start()
    {
        indexWave = 1;
        qntdInim = 2;
        
        // inincialmete qntd de ini eh 5, aumenta 5 a cada wave (sla mn)
    }

    void Update()
    {
        //auxWave = waves[indexWave];
        SpawnWave();
        TextWave();
        if (inimigosOn.Count == 0 && !canSpawn)
        {
            indexWave++;
            Debug.Log("mudou wave = " + indexWave);
            qntdInim = indexWave * 2;
            canSpawn = true;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randEnemy = tipoDeInimigos[Random.Range(0, 3)];
            Transform randPoint = spawnPoints[Random.Range(0, 4)];
            Instantiate(randEnemy, randPoint.position, Quaternion.identity);
            qntdInim--;
            nextSpawnTime = Time.time + 1f; // TEMPO ENTRE SPAWNS
            inimigosOn.Add(randEnemy);
            if (qntdInim == 0)
            {
                if ((indexWave % 5) == 0)
                {
                    Debug.Log("BOSS");
                    GameObject randBoss = inimigoBoss[Random.Range(0, 2)];
                    Transform randPointB = spawnPoints[Random.Range(0, 4)];
                    Instantiate(randBoss, randPointB.position, Quaternion.identity);
                    inimigosOn.Add(randBoss);
                }
                canSpawn = false;
            }
        }
    }

    public void InimiDestr()
    {
        inimigosOn.RemoveAt(0);
    }

    void TextWave()
    {
        waveTxt.text = "WAVE: " + indexWave;
    }
}
