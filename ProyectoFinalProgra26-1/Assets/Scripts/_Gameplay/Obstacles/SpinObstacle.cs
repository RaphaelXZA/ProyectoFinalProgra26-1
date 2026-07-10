using UnityEngine;

public class SpinObstacle : ObstacleBase
{
    [SerializeField] private float orbitSpeed = 90f;

    protected override void ExtraMovement()
    {
        transform.Rotate(Vector3.forward * orbitSpeed * Time.deltaTime);
    }

}