using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float steering;
    public TextMeshProUGUI scoreText;
    private float score = 0;
    private GameManager gameManager;

    private Rigidbody2D rb;
    private float timeSinceLastSpeedIncrease = 0.0f;
    private float speedIncreaseInterval = 10.0f; // Increase speed every 10 seconds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float x = 0;

        if (Input.touchCount > 0 && !gameManager.isGameOver)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                x = -1; // Turn left
            }
            else
            {
                x = 1; // Turn right
            }
        }

        // Increase speed only every speedIncreaseInterval seconds
        timeSinceLastSpeedIncrease += Time.deltaTime;
        if (timeSinceLastSpeedIncrease >= speedIncreaseInterval)
        {
            timeSinceLastSpeedIncrease = 0.0f;
            maxSpeed += 0.5f; // Increase maxSpeed by 1 unit every 10 seconds
        }

        Vector2 speed = transform.up * (acceleration * Time.deltaTime);
        rb.AddForce(speed);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));

        if (acceleration > 0)
        {
            if (direction > 0)
            {
                rb.rotation -= x * steering * (rb.velocity.magnitude / maxSpeed);
            }
            else
            {
                rb.rotation += x * steering * (rb.velocity.magnitude / maxSpeed);
            }
        }

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;

        // Update drift score based on drift force
        if (driftForce > 0)
        {
            score += driftForce / 5f;
            Debug.Log("Drift Force: " + driftForce);
        }
        scoreText.text = Mathf.FloorToInt(score).ToString();

        Vector2 relativeForce = Vector2.right * driftForce;

        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if (rb.velocity.magnitude > maxSpeed && !gameManager.isGameOver)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed * 0.5f;
        }

        if(gameManager.isGameOver)
        {
            scoreText.text = "0";
        }
    }

    
}


