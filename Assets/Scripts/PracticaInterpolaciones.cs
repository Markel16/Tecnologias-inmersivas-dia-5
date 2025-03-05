using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject cubo;
    private GameObject instancairCubo;

    private Vector3 PosicinInicial = new Vector3(0, 0, 0);
    private Vector3 PosicionFinal = new Vector3(5, 0, 0);
    private Quaternion empezarRotacion;
    private Quaternion FinalizarRotacion;

    private bool isProcessing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isProcessing)
        {
            StartCoroutine(Sequence());
        }
    }

    IEnumerator Sequence()
    {
        isProcessing = true;

        // Instanciar el cubo si no existe
        if (instancairCubo == null)
        {
            instancairCubo = Instantiate(cubo, PosicinInicial, Quaternion.identity);
        }

        // Mover el cubo de A a B con Lerp
        yield return StartCoroutine(MoverCubo(PosicinInicial, PosicionFinal, 2f));

        
        yield return new WaitForSeconds(1f);

        // Rotar 
        empezarRotacion = instancairCubo.transform.rotation;
        FinalizarRotacion = Quaternion.Euler(0f, 90f, 0f);
        yield return StartCoroutine(RotateCube(empezarRotacion, FinalizarRotacion, 2f));

        
        yield return new WaitForSeconds(1f);

        // Regresar a posición y rotación inicial
        yield return StartCoroutine(MoverCubo(PosicionFinal, PosicinInicial, 2f));
        yield return StartCoroutine(RotateCube(FinalizarRotacion, Quaternion.identity, 2f));

        isProcessing = false;
    }

    IEnumerator MoverCubo(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            instancairCubo.transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        instancairCubo.transform.position = to;
    }

    IEnumerator RotateCube(Quaternion from, Quaternion t, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            instancairCubo.transform.rotation = Quaternion.Slerp(from, t, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        instancairCubo.transform.rotation = t;
    }
}
