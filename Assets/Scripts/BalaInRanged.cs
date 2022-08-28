using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInRanged : MonoBehaviour
{
    public float balaVel;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProject", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * balaVel * Time.deltaTime);
    }

    void DestroyProject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Debug.Log("WOWOWOOW");
            Destroy(this.gameObject);
        }
    }
}
