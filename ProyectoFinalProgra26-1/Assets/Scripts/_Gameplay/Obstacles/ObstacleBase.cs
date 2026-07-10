using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField] protected float fallSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        ExtraMovement();
    }

    protected abstract void ExtraMovement();
}