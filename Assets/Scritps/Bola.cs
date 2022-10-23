using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    
    //Velocidad
    public float velocidad = 30.0f;
    
    //Se ejecuta al arrancar
    void Start () {
    
        //Velocidad inicial hacia la derecha
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
    
    }

    //Se ejecuta al colisionar
        void OnCollisionEnter2D(Collision2D micolision){
            //Col contiene toda la información de la colisión
            //Si la bola colisiona con la raqueta:
            // micolision.gameObject es la raqueta
            // micolision.transform.position es la posición de la raqueta

    if (micolision.gameObject.name == "RaquetaIzquierda"){
        //Valor de x
        int x = 1;
        //Valor de y
        int y = direccionY(transform.position,
        micolision.transform.position);
        //Calculo dirección
        Vector2 direccion = new Vector2(x, y);
        //Aplico velocidad
        GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
    }
        //Si choca con la raqueta derecha
        if (micolision.gameObject.name == "RaquetaDerecha"){
            //Valor de x
            int x = -1;
            //Valor de y
            int y = direccionY(transform.position,
            micolision.transform.position);
            //Calculo dirección (normalizada para que de 1 o -1)
            Vector2 direccion = new Vector2(x, y);
            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
         }
    }
         //Direccion Y
           int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
            if (posicionBola.y > posicionRaqueta.y){
               return 1;
            }
            else if (posicionBola.y < posicionRaqueta.y){
                 return -1;
            }
            else{
                 return 0;
            }
        }
}
