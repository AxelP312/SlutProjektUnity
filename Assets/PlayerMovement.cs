using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float controlX = Input.GetAxisRaw("Horizontal");
        float controlY = Input.GetAxisRaw("Vertical");

        Debug.Log(controlX);
        Debug.Log(controlY);

        Vector3 movementX = Vector3.right * Time.deltaTime * speed * controlX;
        

        transform.Translate(movementX);

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 movementY = Vector3.up * Time.deltaTime * speed * controlY;
            transform.Translate(movementY);
        }
        
    }
}
