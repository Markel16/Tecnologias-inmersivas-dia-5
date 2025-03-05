using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolaciones : MonoBehaviour
{
    public Transform ObjectAmover;
    public Vector3 PosInicial =new Vector3 (0,0,0);
    public Vector3 PosFinal = new Vector3(10, 0, 0);
    public float Duracion = 5f;
    public float Temporizador = 0f;

    public Light MiLuz;
    public Color ColorInicial = Color.red;
    public Color ColorFinal = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Mi Funcion", 5.0f);
        InvokeRepeating("MiFuncion", 3.0f, 4.0f);
        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador += Time.deltaTime;
        float t = Mathf.Clamp01(Temporizador/Duracion);
        ObjectAmover.position = Vector3.Lerp(PosInicial, PosFinal, t);

        MiLuz.color = Color.Lerp(ColorFinal, ColorInicial, t);
    }
    void MiFuncion()
    {
        Debug.Log("Mi funcion ha sido invocada");
    }

}
