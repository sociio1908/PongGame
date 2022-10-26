using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {


   AudioSource fuenteDeAudio;
   //Clips de audio
   public AudioClip inicio; 

void Update () {

    //Si pulsa la tecla P o hace clic izquierdo empieza el juego
    if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0)){
        
        SceneManager.LoadScene("Juego");
    }

}


}
