using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{

    public float speed = 3;
    public Rigidbody2D kroppen;
    bool ÄrPåmarken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float controlX = Input.GetAxisRaw("Horizontal");
        Vector3 movementX = Vector3.right * Time.deltaTime * speed * controlX;
        transform.Translate(movementX);





        kroppen = transform.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.Space) && ÄrPåmarken != true)
        {
            ÄrPåmarken = true;
            Debug.Log("AHH");
            float test = 5f;
            kroppen.velocity = Vector3.up * test;
            //Debug.Log(kroppen.velocity);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "marken")
        {
            ÄrPåmarken = false;
        }
        Debug.Log("Enter");
    }
}
