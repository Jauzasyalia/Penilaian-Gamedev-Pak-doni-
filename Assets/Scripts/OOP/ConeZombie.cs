using UnityEngine;

// INHERITANCE + POLYMORPHISM
// ConeZombie mewarisi Enemy, lalu meng-override Serang().
public class ConeZombie : Enemy
{
    public bool cone = true;

    public override void Serang()
    {
        Debug.Log("Cone Gigit");

        if (player != null)
        {
            IDamageable target = player.GetComponent<IDamageable>();
            if (target != null) target.KenaDamage(10f);
        }
    }
}
