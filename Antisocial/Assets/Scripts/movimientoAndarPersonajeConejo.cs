using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoAndarPersonajeConejo : MonoBehaviour
{

    //CORRER:


    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;


    public Animator anim;
    public float x, y;




    //public int velEmpujar;


    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);


        if (Input.GetKey(KeyCode.LeftShift)) //he probado con cosas de este tipo _______ if (((Input.GetKey(KeyCode.Space) && Input.GetAxis("Horizontal")) || ((Input.GetKey(KeyCode.Space) && Input.GetAxis("Vertical")))________  o tambien algo asi ___!(x = 0) | !(y = 0))
        {
            velocidadMovimiento = 6;
            anim.SetBool("Correr", true);
        }
        else
        {
            velocidadMovimiento = 3;
            anim.SetBool("Correr", false);
            
        }


        if (Input.GetKey(KeyCode.Space)) //he probado con cosas de este tipo _______ if (((Input.GetKey(KeyCode.Space) && Input.GetAxis("Horizontal")) || ((Input.GetKey(KeyCode.Space) && Input.GetAxis("Vertical")))________  o tambien algo asi ___!(x = 0) | !(y = 0))

        {
            velocidadMovimiento = 5;
            anim.SetBool("Empujar", true);
        }
        else
        {
            velocidadMovimiento = 3;
            anim.SetBool("Empujar", false);
        }


    }
}

