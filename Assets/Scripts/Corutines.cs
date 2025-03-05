using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutines : MonoBehaviour
{
    public Transform Destino;
    public float suavizado = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MiCorrutina(Destino));
        Debug.Log("El script sigue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MiCorrutina(Transform MiDestino)
    {
        Debug.Log("Se inicia la corutina");
        while (Vector3.Distance(transform.position, MiDestino.position) > 0.05f)
        {
            Debug.Log("Moviendo");
            transform.position = Vector3.Lerp(transform.position, MiDestino.position, suavizado * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Se acaba el while");
        yield return new WaitForSeconds(3f);
        Debug.Log("Se acaba la corutina");
    }
}
