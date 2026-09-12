using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    // logika lain seperti OnTriggerEnter2D untuk bullet mengenai musuh, dll (kalau ada sebelumnya)
}