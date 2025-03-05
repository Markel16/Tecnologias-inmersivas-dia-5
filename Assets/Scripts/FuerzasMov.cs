using UnityEngine;
using TMPro; 

public class FuerzasMov : MonoBehaviour
{
    public float velocidad = 10f; 
    public int score = 0; 
    public TextMeshProUGUI scoreText;
    


    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        
        Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical);

        
        this.GetComponent<Rigidbody>().AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Punto"))
        {
            score += 1; 
            UpdateScoreUI(); 
            Destroy(other.gameObject); 
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score; 
        }
    }
}

