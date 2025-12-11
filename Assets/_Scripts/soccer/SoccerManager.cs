using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerManager : MonoBehaviour
{
    public static SoccerManager Instance;

    public string BallTag => BallTag;
    [SerializeField] string ballTag = "Ball";    
    public string BallSpawnTag => BallSpawnTag;
    [SerializeField] string ballSpawnTag = "BallSpawn";

    [SerializeField, ReadOnly(true)] int points = 0;
    [SerializeField] int pointsToNextGame = 5;

    GameObject ballObject;
    GameObject ballSpawnPoint;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += RefreshLevelReferences;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= RefreshLevelReferences;
    }
    private void RefreshLevelReferences(Scene scene, LoadSceneMode loadSceneMOde)
    {
        ballObject = GameObject.FindGameObjectWithTag(ballTag);
        ballSpawnPoint = GameObject.FindGameObjectWithTag(ballSpawnTag);

        ResetBall();
    }

    public void ScorePoints(int _points)
    {
        this.points += _points;
        Debug.Log($"Scored: {_points}! Total points: {this.points}");

        if (points >= pointsToNextGame) ResetGame();
    }

    private void ResetGame()
    {
        points = 0;
        Debug.Log("Game reset");
    }

    public void ResetBall()
    {
        if (ballObject != null && ballSpawnPoint != null)
        {
            ballObject.transform.position = ballSpawnPoint.transform.position;
            Rigidbody ballRB = ballObject.GetComponent<Rigidbody>();

            ballRB.linearVelocity = Vector3.zero;
            ballRB.angularVelocity = Vector3.zero;

        }
    }


}
