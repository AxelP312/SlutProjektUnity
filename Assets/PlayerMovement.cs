using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{

    public float speed = 3;
    public Rigidbody2D kroppen;
    bool ÄrPåmarken;

    void Start()
    {
        
    }

    void Update()
    {
        /*Den här delen kollar varje frame om man håller in en horizontel knapp, det vill säga att den kollar om man håller in "a" "d" eller pilarna*/
        float controlX = Input.GetAxisRaw("Horizontal");

        /*Den här delen använder sig av Time.Delta, vilket är ett sätt att göra spelet spelbart för alla framerates. 
         Det som Time.Delta gör är att den tar 1 /Antalet frames och där efter räknar ut att en frame är t.ex. 1/60 av en sekund.
         Den använder sig även av speed, vilket är en en variabel som kan ta in decimaler. Fungerar om en vanlig int. 
         Den tar in controlX vilket är en float, som är antingen 1 -1 eller 0, beroende på vilken knapp man håller in. 
         Vector3.right är en vector3, en vektor med x, y och z koordinater och den använder .right för att x ska vara 1.
         Om man skulle ha .left skulle högerpilen bli vänster, vice versa. 
         Den här multiplikationen blir en vector3 med namnet movementX, vilket gör att karaktären rör sig.
         Den är baserad på x axel, om man rör sig höger blir den positiv viklet gör att man rör sig åt höger. Vice versa. 
         */
        Vector3 movementX = Vector3.right * Time.deltaTime * speed * controlX;
        transform.Translate(movementX);

        //Den här raden tar in rigidbody2d, vilket är den fysiska kroppen som en sprite har genom att använda .GetCompoent och objektets class <Rigidbody2d>.
        //Kroppen har då ett x och y värde som påverkar hur kroppen rör sig. 
        kroppen = transform.GetComponent<Rigidbody2D>();

        /*Den här if satsen kollar om man håller ner sin Spacebar och kollar om boolen  ÄrPåMarken är sann eller inte.
          Själva if satsen gör att om man klickar på spacebar multipliceras vector3.up med test, vilket ändrar kroppens y värde.
          Det i sin tur gör att man flyger upp.*/
        if (Input.GetKeyDown(KeyCode.Space) && ÄrPåmarken != true)
        {
            ÄrPåmarken = true;
            Debug.Log("AHH");
            float test = 5f;
            kroppen.velocity = Vector3.up * test;
        }

        /*Dessa två if satser gör att om man håller in leftshift blir speed = 4.5f, leftcontrol blir speed = 1.5f. 
         Den tar in vilken knapp man håller in. 
         Det ändrar farten som man har när man glider vänster eller höger*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4.5f;
            Debug.Log(speed);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            speed = 1.5f;
            Debug.Log(speed);
        }
        else { speed = 3f; };


    }

    /*Det här är unitys CollisionDetecter, vilket kollar om det sker en kollision med ett gameobjekt.
      Eftersom det här scriptet ligger på "karaktären" kollar den om karaktären går igenom en kollision med ett gameobjekt med taggen marken eller inte. 
      När man hoppar ändras boolen "ÄrPåmarken" till true, vilket gör att man inte kan använda spacebar tills den är false igen. 
      När man påbörjar en kollision med ett gameobjekt med taggen "marken" ändras ÄrPåmarken till false.
      Det gör det möjligt att lägga till flera gameobjekt som motståndare och interaktiva saker som mynt utan att det påverkar hur mycket man kan hoppa.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "marken")
        {
            ÄrPåmarken = false;
        }
        Debug.Log("Enter");
    }
}
