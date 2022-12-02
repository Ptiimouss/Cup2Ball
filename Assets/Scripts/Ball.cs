using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 7;
    [SerializeField] ScoreManager scoreManager;
    int xInput = 0;
    int yInput = -1;
    // Start is called before the first frame update
    void Awake()
    {
        if (TryGetComponent(out Rigidbody rb))
            this.rb = rb;
    }
    void Start()
    {
        var velocity = new Vector2(0, yInput * speed);
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xInput = -1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            xInput = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xInput = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            xInput = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yInput = -3;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            yInput = -1;
        }
        var velocity = new Vector2(xInput * speed, yInput * speed);
        rb.velocity = velocity;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(gameObject.tag))
        {
            gameObject.SetActive(false);
            yInput = -1;
            xInput = 0;
            scoreManager.AddScore();
            scoreManager.ShowScore(gameObject.tag);
        }
        else
        {
            gameObject.SetActive(false);
            yInput = -1;
            xInput = 0;
            scoreManager.ResetCombo();
        }
    }
}
