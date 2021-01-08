using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        RandomMove();
    }
    private void RandomMove()
    {
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }
}
