using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

   AudioSource fuenteDeAudio;
   //Clips de audio
   public AudioClip fin; 

   public void IniciarJuego(){
        SceneManager.LoadScene("Juego");
    }  
    
    public void SalirJuego(){
        Debug.Log("SALIMOS");
    Application.Quit();
    }

 
}
