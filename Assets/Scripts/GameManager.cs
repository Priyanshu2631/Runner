using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score=0;
    public TextMeshProUGUI Score;
    public GameObject PlayButton;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles(){
        while(true){
            float waitTime=Random.Range(0.5f,2.4f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstacle,spawnPoint.position,Quaternion.identity);
        }
    }

    void ScoreUp(){
        score++;
        Score.text=score.ToString();
    }
    public void GameStart(){
        Player.SetActive(true);
        PlayButton.SetActive(false);

        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp",2f,1f);
    }
}
