using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    Vector3 mousePos;
    Camera mainCam;
    Rigidbody2D rb;
    public float forca;
    public int dano;
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direct = mousePos - transform.position;
        Vector3 rotat = transform.position - mousePos;

        rb.velocity = new Vector2(direct.x, direct.y).normalized * forca;
        float rot = Mathf.Atan2(rotat.y, rotat.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (!r.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
