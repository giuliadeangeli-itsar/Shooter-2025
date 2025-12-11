using UnityEngine;

public class Sponda : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"));
        {
            SoccerManager.Instance?.ResetBall();
        }
    }
}
