using UnityEngine;

public class ZigZagObstacle : ObstacleBase
{
    [SerializeField] private float horizontalSpeed = 3f;
    [SerializeField] private float timeToChangeDirection = 1.5f;

    private float direction = 1f;
    private float timer = 0f;

    protected override void ExtraMovement()
    {
        transform.Translate(Vector3.right * direction * horizontalSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= timeToChangeDirection)
        {
            direction *= -1f;
            timer = 0f;
        }
    }

}
