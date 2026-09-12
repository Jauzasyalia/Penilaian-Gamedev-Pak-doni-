using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 25f;
    public float lifeTime = 3f; // peluru otomatis kembali ke pool setelah sekian detik

    private Vector3 direction;
    private float timer;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            gameObject.SetActive(false); // kembalikan ke object pool
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jangan mengenai player sendiri
        if (other.CompareTag("Player")) return;

        // Abstraction: peluru tidak peduli jenis musuhnya, cukup IDamageable
        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null)
        {
            target.KenaDamage(damage);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
