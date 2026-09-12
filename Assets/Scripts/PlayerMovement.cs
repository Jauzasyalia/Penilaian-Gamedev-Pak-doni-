using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// PlayerMovement + tembak. Abstraction: implementasi IDamageable agar bisa dilukai musuh.
public class PlayerMovement : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData playerData;

    private float currentHP;
    private PlayerInput playerInput;
    private Vector2 moveInput;
    public GameManager gameManager;
    private float attackInput;
    private float previousAttackInput; // Untuk menyimpan nilai serangan sebelumnya
    public GameObject bulletPrefab;
    public TextMeshProUGUI teksScore; // Reference to the UI text for displaying score
    public Transform bulletSpawnPoint; // atau public kalau mau assign di Inspector

    // TAMBAHAN: variabel skor
    public int score = 0;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerInput = GetComponent<PlayerInput>();
        currentHP = playerData.maxHP;

        // Pemancar event: beritahu penerima HP awal player
        PemancarEvent.PancarkanHPBerubah(currentHP, playerData.maxHP);
    }


    void Update()
    {
        if (playerInput == null) return;
        if (GameManager.Instance != null && GameManager.Instance.currentState != GameState.Playing) return;

        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        // Baca input serangan
        attackInput = playerInput.actions["Attack"].ReadValue<float>();

        float h = moveInput.x;
        float v = moveInput.y;

        transform.Translate(new Vector3(h, v, 0) * playerData.moveSpeed * Time.deltaTime);

        // ini untuk ngecek apakah tombol serang baru saja ditekan
        if (previousAttackInput == 0 && attackInput > 0)
        {
           shoot();
        }

        previousAttackInput = attackInput; // Simpan nilai serangan sebelumnya
    }

    void shoot()
    {
        Debug.Log("Player is Shooting!");

        if (PooledObjects.Instance == null)
        {
            Debug.LogWarning("PooledObjects belum ada di scene!");
            return;
        }

        // Determine spawn position
        Vector3 spawnPos = bulletSpawnPoint != null ? bulletSpawnPoint.position : transform.position;

        // Get mouse position in world space for 2D
        Vector3 mouseScreenPos = Mouse.current != null ? (Vector3)Mouse.current.position.ReadValue() : Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0; // Ensure Z is 0 for 2D

        // Calculate direction from player to mouse
        Vector3 shootDirection = (mouseWorldPos - spawnPos).normalized;

        GameObject bulletObj = PooledObjects.Instance.GetPooledObject();

        if (bulletObj != null)
        {
            bulletObj.transform.position = spawnPos;
            bulletObj.transform.rotation = Quaternion.identity;
            bulletObj.SetActive(true);

            Bullet bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetDirection(shootDirection);
            }
            else
            {
                Debug.LogError("Bullet component not found on prefab!");
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TakeDamage(0.1f);
        }
    }

    // TAMBAHAN: fungsi untuk menangkap trigger (koin)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 1;
            if (teksScore != null) teksScore.text = "Score: " + score.ToString();
            Debug.Log("Koin diambil! Skor sekarang: " + score);

            // Pemancar event: skor berubah
            PemancarEvent.PancarkanSkorBerubah(score);

            // PENTING: Lapor ke GameManager agar dicek apakah sudah menang
            if (gameManager != null)
            {
                gameManager.AmbilKoin();
            }
        }
    }

    // Implementasi IDamageable (dipanggil oleh Enemy saat menabrak / menyerang)
    public void KenaDamage(float jumlah)
    {
        TakeDamage(jumlah);
    }

    void TakeDamage(float dmg)
    {
        if (currentHP <= 0) return; // sudah mati, jangan diproses lagi

        currentHP -= dmg;
        Debug.Log("Player HP: " + currentHP);

        // Pemancar event: HP berubah
        PemancarEvent.PancarkanHPBerubah(currentHP, playerData.maxHP);

        if (currentHP <= 0)
        {
            PemancarEvent.PancarkanPlayerMati();
            GameManager.Instance.GameOver();
        }
    }
}
