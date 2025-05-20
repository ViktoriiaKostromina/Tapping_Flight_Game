using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftside = -12f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftside - 2)
        {
            Destroy(gameObject);
        }
    }
}
