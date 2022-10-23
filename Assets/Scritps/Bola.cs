using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bola : MonoBehaviour
{

    //Velocidad de la pelota
    public float velocidad = 30.0f;

    //Contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
    //Cajas de texto de los contadores
    public TextMeshProUGUI contadorIzquierda;
    public TextMeshProUGUI contadorDerecha;


    // Use this for initialization
    void Start(){
  

               Vector2 direc_inical = new Vector2(-1, -2);
            GetComponent<Rigidbody2D>().velocity = direc_inical * velocidad;

        //Pongo los contadores a 0
        contadorIzquierda.text = golesIzquierda.ToString()+" GOLES";
        contadorDerecha.text = golesDerecha.ToString()+" GOLES";
    }

    //Se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision){
        //transform.position es la posición de la bola
        //micolision contiene toda la información de la colisión
        //Si la bola colisiona con la raqueta:
        // micolision.gameObject es la raqueta
        // micolision.transform.position es la posición de la raqueta
       
        //Si choca con la raqueta izquierda
        if (micolision.gameObject.name == "Raqueta Izquierda"){
           
            //Valor de x
            int x = 1;
         
            //Valor de y
            int y = direccionY(transform.position, micolision.transform.position);
        
            //Calculo dirección
            Vector2 direccion = new Vector2(x, y);
         
            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
        
        }
        
        //Si choca con la raqueta derecha
        if (micolision.gameObject.name == "Raqueta Derecha"){
           
            //Valor de x
            int x = -1;
           
            //Valor de y
            int y = direccionY(transform.position, micolision.transform.position);
           
            //Calculo dirección (normalizada para que de 1 o -1)
            Vector2 direccion = new Vector2(x, y);
           
            //Aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

        }
    }

    //Direccion Y
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
        Debug.Log("Posiciones B y R = " + posicionBola.y + " y "+ posicionRaqueta.y);
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
    
    //Reinicio la posición de la bola
    public void reiniciarBola(string direccion){

        //Posición 0 de la bola
        transform.position = Vector2.zero;

        //Vector2.zero es lo mismo que new Vector2(0,0);
    

        //Velocidad y dirección
            if (direccion == "Derecha"){

                //Incremento goles al de la derecha
                golesDerecha++;
                
                //Lo escribo en el marcador
                contadorDerecha.text = golesDerecha.ToString()+" GOLES";

                //Reinicio la bola
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
                //Vector2.right es lo mismo que new Vector2(1,0)
            }

            else if (direccion == "Izquierda"){

                //Incremento goles al de la izquierda
                golesIzquierda++;

                //Lo escribo en el marcador
                contadorIzquierda.text = golesIzquierda.ToString() +" GOLES";

                //Reinicio la bola
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
                //Vector2.left es lo mismo que new Vector2(-1,0)
            }
    }


}