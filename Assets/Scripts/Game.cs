using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    [SerializeField] Ball[] ballsB;
    float changeSpeed = 10;
    int rdm;
    int nbActive = 3;
    private void Awake()
    {
        foreach (GameObject ball in balls)
        {
            ball.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        foreach (GameObject ball in balls)
        {
            if (!ball.gameObject.activeSelf)
            {
                nbActive -= 1;
            }
        }
        if (nbActive == 0)
        {
            BallSpawn();
        }
        nbActive = 3;
        if (changeSpeed > 0)
        {
            changeSpeed -= Time.deltaTime;
        }
        else
        {
            foreach (Ball ball in ballsB)
            {
                ball.speed += 0.5f;
            }
            changeSpeed = 10;
        }
    }
    public void BallSpawn()
    {
        rdm = Random.Range(0, balls.Length);
        balls[rdm].gameObject.SetActive(true);
        balls[rdm].gameObject.transform.position = new Vector3(Random.Range(-6, 6), 11,0);
    }

}