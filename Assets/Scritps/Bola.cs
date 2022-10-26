using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{

      //Velocidad de la pelota
   public float velocidad = 30.0f;
   //Audio Source
   AudioSource fuenteDeAudio;
   //Clips de audio
   public AudioClip audioGol, audioRaqueta, audioRebote, inicio, fin;
   //Contadores de goles
   public int golesIzquierda = 0, golesDerecha = 0, golesGanar=5;
   //Cajas de texto de los contadores
   public TextMeshProUGUI contadorIzquierda;
   public TextMeshProUGUI contadorDerecha;
   private float Delay1 = 5.0f; 
   private float velocidadBola=0.0f;
   // Use this for initialization
   void Start () {
     
      //Recupero el componente audio source;
       fuenteDeAudio = GetComponent<AudioSource>();
       fuenteDeAudio.clip = inicio;
       fuenteDeAudio.Play();
       StartCoroutine(Timer1());

      //Velocidad inicial hacia la derecha
      GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
     
      //Pongo los contadores a 0
      contadorIzquierda.text = golesIzquierda.ToString()+ " GOLES";
      contadorDerecha.text = golesDerecha.ToString()+ " GOLES";
   }
   
   //Se ejecuta si choco con la raqueta
   void OnCollisionEnter2D(Collision2D micolision){
      //Si me choco con la raqueta izquierda
      if (micolision.gameObject.name == "RaquetaIzquierda"){
         //Valor de x
         int x = 1;
         //Valor de y
         int y = direccionY(transform.position, micolision.transform.position);
         //Vector de dirección
         Vector2 direccion = new Vector2(x, y);
         //Aplico la velocidad a la bola
         GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
         //Reproduzco el sonido de la raqueta
         fuenteDeAudio.clip = audioRaqueta;
         fuenteDeAudio.Play();
      }
    //Si me choco con la raqueta derecha
    else if (micolision.gameObject.name == "RaquetaDerecha"){
         //Valor de x
         int x = -1;
         //Valor de y
         int y = direccionY(transform.position, micolision.transform.position);
         //Vector de dirección
         Vector2 direccion = new Vector2(x, y);
         //Aplico la velocidad a la bola
         GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
         //Reproduzco el sonido de la raqueta
         fuenteDeAudio.clip = audioRaqueta;
         fuenteDeAudio.Play();
       }
   //Para el sonido del rebote
   if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){
      //Reproduzco el sonido del rebote
      fuenteDeAudio.clip = audioRebote;
      fuenteDeAudio.Play();
   }
   }

   //Calculo la dirección de Y
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

   //Reinicio la posición de la bola
   public void reiniciarBola(string direccion){


      // Reiniciamos posición 0 de la bola
      transform.position = Vector2.zero;

      //valido si termina el juego
      if(golesDerecha==golesGanar || golesIzquierda==golesGanar){
      //Reproduzco el sonido de incio
         fuenteDeAudio.clip = fin;
         fuenteDeAudio.Play();
        
         if(golesDerecha==golesGanar){
          contadorDerecha.text = "GANADOR";
          contadorIzquierda.text = "F BRO - GOLES "+golesIzquierda;
         }

         if(golesIzquierda==golesGanar){
          contadorIzquierda.text = "GANADOR";
          contadorDerecha.text = "F BRO - GOLES "+golesDerecha;
         }
        
         StartCoroutine(Timer1());
         VolverMenu();
      }
  
     //Velocidad inicial de la bola  
      velocidadBola+=5.0f;
      velocidad = velocidadBola + 30;

      //Velocidad y dirección
      if (direccion == "Derecha"){
         //Incremento goles al de la derecha
         golesDerecha++;
         //Lo escribo en el marcador
         contadorDerecha.text = golesDerecha.ToString()+ " GOLES";
         //Reinicio la bola
         GetComponent<Rigidbody2D>().velocity = new Vector2(1,-1) *
         velocidad;
         //Vector2.right es lo mismo que new Vector2(1,0)
      }
      else if (direccion == "Izquierda"){
         //Incremento goles al de la izquierda
         golesIzquierda++;
         //Lo escribo en el marcador
         contadorIzquierda.text = golesIzquierda.ToString() + " GOLES";
         //Reinicio la bola
         GetComponent<Rigidbody2D>().velocity = new Vector2(-1,1) * velocidad;
         //Vector2.right es lo mismo que new Vector2(-1,0)
      }
      //Reproduzco el sonido del gol
      fuenteDeAudio.clip = audioGol;
      fuenteDeAudio.Play();
   }


   IEnumerator Timer1()
    {
        yield return new WaitForSeconds(Delay1);
 
    } 

   public void VolverMenu(){
       SceneManager.LoadScene("Inicio");
       
    }

}
