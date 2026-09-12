using UnityEngine;

// Inheritance: EnemyChildren adalah jenis zombie yang menurun dari Enemy
public class EnemyChildren : Enemy
{
    [Header("Pengaturan Zombie Anak")]
    [SerializeField] private float damageSerangan = 5f;
    [SerializeField] private float pengaliKecepatan = 1.5f;

    protected override void Start()
    {
        base.Start();
        // Zombie anak lebih cepat tapi lebih lemah
        ms *= pengaliKecepatan;
        hp = Mathf.Max(1f, hp / 2f);
    }

    // Polymorph: perilaku serang diubah dari versi induk (Enemy)
    public override void Serang()
    {
        Debug.Log("Zombie anak menyerang dengan damage " + damageSerangan + "!");

        if (player != null)
        {
            IDamageable target = player.GetComponent<IDamageable>();
            if (target != null)
            {
                target.KenaDamage(damageSerangan);
            }
        }
    }

    // Polymorph: pesan mati juga diubah
    protected override void Mati()
    {
        Debug.Log("Zombie anak mati!");
        base.Mati(); // tetap memancarkan event OnZombieMati dan Destroy
    }
}
