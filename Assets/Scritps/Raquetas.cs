using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquetas : MonoBehaviour
{

    //Velocidad
    public float velocidad = 50.0f;
    //Eje vertical
    public string eje;
    // Es llamado una vez cada fixed frame
    void FixedUpdate () {
        //Capto el valor del eje vertical de la raqueta
        float v = Input.GetAxisRaw(eje);

        //Modifico la velocidad de la raqueta
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);
    }


}
