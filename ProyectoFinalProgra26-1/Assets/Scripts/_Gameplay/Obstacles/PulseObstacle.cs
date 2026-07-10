using UnityEngine;

public class PulseObstacle : ObstacleBase
{
    [SerializeField] private float pulseSpeed = 1f;
    [SerializeField] private float pulseTime = 1.5f;
    [SerializeField] private float minScale = 0.1f;

    private Vector3 initialScale;
    private float timer = 0f;
    private bool growing = true;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    protected override void ExtraMovement()
    {
        timer += Time.deltaTime;

        if (growing)
        {
            transform.localScale += Vector3.one * pulseSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 newScale = transform.localScale - Vector3.one * pulseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Max(newScale.x, minScale),
                Mathf.Max(newScale.y, minScale),
                Mathf.Max(newScale.z, minScale)
            );
        }

        if (timer >= pulseTime)
        {
            growing = !growing;
            timer = 0f;
        }
    }

}
