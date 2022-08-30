using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInRanged : MonoBehaviour
{
    public float balaVel;
    public float lifeTime;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyProject", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.gameObject.transform.Translate(Vector2.right * balaVel * Time.deltaTime);
    }

    void DestroyProject()
    {
        Destroy(this.gameObject);
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
