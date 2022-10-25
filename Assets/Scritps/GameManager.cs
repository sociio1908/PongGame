using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {


   public TextMeshProUGUI ModoJuego;
   public Button btnI; 
       int cont =0;
	
  void Start(){
    btnI.onClick.AddListener(TaskOnClick);
  }

void Update () {
    //Si pulsa la tecla P o hace clic izquierdo empieza el juego
    //|| Input.GetMouseButton(0)
    if (Input.GetKeyDown(KeyCode.P)){
        //Cargo la escena de Juego
        // Nombre de la scene del juego, en mi caso es SampleScene
        SceneManager.LoadScene("Juego");
    }

}
	void TaskOnClick(){
         cont++;
		Debug.Log ("CLICK: "+cont.ToString());
        cambiarModo();
    }
 
 public void cambiarModo(){

    if(ModoJuego.text.ToString() == "GOLES"){
      ModoJuego.text = "TIEMPO";

     }else{

         ModoJuego.text = "GOLES";
     }

 }
 

}
