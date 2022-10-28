using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquetas : MonoBehaviour
{

    //Velocidad
    public float velocidad = 5f, h, v;
    //Eje vertical
    public string ejev; //Vertical
    public string ejeh; // Horizontal
    // Es llamado una vez cada fixed frame
    void FixedUpdate () {

        float raquetaI  = GameObject.Find("RaquetaIzquierda").transform.position.x;
        float raquetaD = GameObject.Find("RaquetaDerecha").transform.position.x;
          
        limitarRaqueta(ejeh, raquetaI, raquetaD);

        v = Input.GetAxisRaw(ejev) * velocidad * Time.deltaTime;
        h = Input.GetAxisRaw(ejeh) * velocidad * Time.deltaTime;
        //Capto el valor del eje vertical de la raqueta
        transform.Translate(new Vector3(h, v, 0f));


    }




    void limitarRaqueta(string eje, float ri, float rd){
        if(eje=="Horizontal 2"){
            if(ri < -50)
                transform.position = new Vector3(-50, transform.position.y, transform.position.z);
            if(ri > -10)
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }    
        
        if(eje=="Horizontal"){
            if(rd > 50)
                transform.position = new Vector3(50, transform.position.y, transform.position.z);
            if(rd < 10)
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        

    }




}
