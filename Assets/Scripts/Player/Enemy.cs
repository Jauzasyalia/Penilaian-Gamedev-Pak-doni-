
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] public int hp = 100;
    public float ms = 2f;

    // Demage yg di terima enemy seriap kali menabrak player
    [SerializeField] private int damageSaatTabrakan = 20;

    protected Transform player;

    [Header("Pengaturan State Machine")]
    [SerializeField] private float jarakDeteksi = 6f;  
    [SerializeField] private float jarakSerang  = 1.2f; 
    [SerializeField] private float jedaSerang   = 1f;  

    [SerializeField] private float radiusPatrol = 3f;
    private Vector2 titikAwal;    
    private Vector2 tujuanPatrol;  
    private StateZombie state = StateZombie.IDLE;
    private float waktuSerangTerakhir;
    public static event System.Action<Enemy> OnZombieMati;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        titikAwal = transform.position;
        PilihTujuanPatrolBaru();
    }

    void Update()
    {
        PeriksaTransisi();

        switch (state)
        {
            case StateZombie.IDLE:   PerilakuIdle();   break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE:  PerilakuChase();  break;
            case StateZombie.ATTACK: PerilakuAttack(); break;
        }
    }

    void PeriksaTransisi()
    {
        if (player == null) return;

        float jarak = JarakKePlayer();

        if (jarak <= jarakSerang)
            state = StateZombie.ATTACK; 
        else if (jarak <= jarakDeteksi)
            state = StateZombie.CHASE;  
        else
            state = StateZombie.PATROL; 
    }

    void PerilakuIdle() { }

    void PerilakuPatrol()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, tujuanPatrol, ms * 0.5f * Time.deltaTime);

        if (Vector2.Distance(transform.position, tujuanPatrol) < 0.1f)
            PilihTujuanPatrolBaru();
    }

    void PilihTujuanPatrolBaru()
    {
        Vector2 acak = Random.insideUnitCircle * radiusPatrol;
        tujuanPatrol = titikAwal + acak;
    }

    void PerilakuChase()
    {
        Kejar();
    }

    void PerilakuAttack()
    {
        
        if (Time.time >= waktuSerangTerakhir + jedaSerang)
        {
            Serang();
            waktuSerangTerakhir = Time.time;
        }
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy menyerang!");
    }

    // Satu-satunya pintu mengubah hp dari luar
    // (nanti dipanggil oleh senjata/Peashooter milik Player).
    public void KenaDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Enemy Kena damage"+  + damage + " HP Sekarang " + hp);

        if (hp <= 0) 
        {
            Mati();
        }
    }
    
    protected virtual void Mati()
    {
        Debug.Log("Enemy Mati !");
        OnZombieMati?.Invoke(this);
        Destroy(gameObject);
    }

    // Dipanggil otomatis oleh Unity saat collider Enemy
    // menyentuh collider lain yang ber-Trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable playerScript = other.GetComponent<IDamageable>();
            if (playerScript != null)
            {
                playerScript.KenaDamage(damageSaatTabrakan);
            }
        }
    }

}