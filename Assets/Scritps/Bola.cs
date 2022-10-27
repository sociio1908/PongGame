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
   public TextMeshProUGUI ganadorTexto;
   public TextMeshProUGUI contadorDerecha;
  // private float Delay1 = 5.0f; 
   private float velocidadBola=0.0f;
   public Image Breiniciar, Bvolver;

   // Use this for initialization
   void Start () {
      reiniciarJuego();
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

   public void mostrarGanador(){
      
         GetComponent<Rigidbody2D>().velocity = Vector2.zero * 0;

         if(golesDerecha==golesGanar){
          ganadorTexto.text = "* GANADOR PLAYER 2 *";
         
         }
         if(golesIzquierda==golesGanar){
          ganadorTexto.text = "* GANADOR PLAYER 1 *";
         }
 
      Breiniciar.enabled = true ;
      Bvolver.enabled = true;
      
   }


   //Reinicio la posición de la bola
   public void reiniciarBola(string direccion){

      // Reiniciamos posición 0 de la bola
      transform.position = Vector2.zero;
  
      //Velocidad inicial de la bola  
      velocidadBola+=5.0f;
      velocidad = velocidadBola + 30;

      //Velocidad y dirección
      if (direccion == "Derecha"){
         //Incremento goles al de la derecha
         golesDerecha++;
        
         //Lo escribo en el marcador
         contadorDerecha.text = golesDerecha.ToString()+ " GOLES";
         
         //Vector2.right es lo mismo que new Vector2(1,0)
          if(golesDerecha==golesGanar){
          fuenteDeAudio.clip = fin;
          fuenteDeAudio.Play();
          mostrarGanador();

       }else{
         fuenteDeAudio.clip = audioGol;
         fuenteDeAudio.Play();
         //Reinicio la bola
         GetComponent<Rigidbody2D>().velocity = new Vector2(1,-1) * velocidad;
         }

      }
      else if (direccion == "Izquierda"){
         //Incremento goles al de la izquierda
         golesIzquierda++;
         
         //Lo escribo en el marcador
         contadorIzquierda.text = golesIzquierda.ToString() + " GOLES";

         //Vector2.right es lo mismo que new Vector2(-1,0)
          if(golesIzquierda==golesGanar){
          fuenteDeAudio.clip = fin;
          fuenteDeAudio.Play();
          mostrarGanador();
        }else{
         fuenteDeAudio.clip = audioGol;
         fuenteDeAudio.Play();
         GetComponent<Rigidbody2D>().velocity = new Vector2(-1,1) * velocidad;
         }
         
      }

   }


   IEnumerator Timer1()
    {
        yield return new WaitForSeconds(5);
 
    }    
    
    IEnumerator Timergano()
    {
        yield return new WaitForSeconds(3);
 
    } 

   public void VolverMenu(){
       SceneManager.LoadScene("Inicio");
       
    }

    public void reiniciarJuego(){
      golesIzquierda = 0; golesDerecha = 0;
      velocidad = 30.0f;
      //Pongo los contadores a 0
      contadorIzquierda.text = golesIzquierda.ToString()+ " GOLES";
      contadorDerecha.text = golesDerecha.ToString()+ " GOLES";
      ganadorTexto.text="";

      //Recupero el componente audio source;
       fuenteDeAudio = GetComponent<AudioSource>();
      //  fuenteDeAudio.clip = inicio;
      //  fuenteDeAudio.Play();
       
      fuenteDeAudio.PlayOneShot(inicio, 0.7F);

      //Velocidad inicial hacia la derecha
      GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

      Breiniciar.enabled = false;
      Bvolver.enabled = false;
     
   }
    

}
