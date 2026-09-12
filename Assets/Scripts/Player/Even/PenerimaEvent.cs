using UnityEngine;
using TMPro;

// Penerima Event (subscriber): berlangganan event dari PengirimEvent dan Enemy (OnZombieMati),
// lalu bereaksi (update UI / log) tanpa perlu tahu siapa yang memancarkan.
public class PenerimaEvent : MonoBehaviour
{
    [Header("UI (opsional, boleh dikosongkan)")]
    public TextMeshProUGUI teksHP;
    public TextMeshProUGUI teksZombieMati;

    private int jumlahZombieMati = 0;

    // Subscribe saat aktif
    void OnEnable()
    {
        PengirimEvent.OnTekanSpasi   += SaatTekanSpasi;
        PengirimEvent.OnGameMulai    += SaatGameMulai;
        PengirimEvent.OnHPBerubah    += SaatHPBerubah;
        PengirimEvent.OnSkorBerubah  += SaatSkorBerubah;
        PengirimEvent.OnPlayerMati   += SaatPlayerMati;
        Enemy.OnZombieMati           += SaatZombieMati;
    }

    // Unsubscribe saat nonaktif (wajib, supaya tidak memory leak / error saat ganti scene)
    void OnDisable()
    {
        PengirimEvent.OnTekanSpasi   -= SaatTekanSpasi;
        PengirimEvent.OnGameMulai    -= SaatGameMulai;
        PengirimEvent.OnHPBerubah    -= SaatHPBerubah;
        PengirimEvent.OnSkorBerubah  -= SaatSkorBerubah;
        PengirimEvent.OnPlayerMati   -= SaatPlayerMati;
        Enemy.OnZombieMati           -= SaatZombieMati;
    }

    void SaatTekanSpasi()
    {
        Debug.Log("Penerima: aku dengar event spasi!");
    }

    void SaatGameMulai()
    {
        Debug.Log("[PenerimaEvent] Game dimulai!");
    }

    void SaatHPBerubah(float hpSekarang, float hpMaks)
    {
        Debug.Log("[PenerimaEvent] HP player: " + hpSekarang + "/" + hpMaks);
        if (teksHP != null) teksHP.text = "HP: " + Mathf.CeilToInt(hpSekarang) + "/" + hpMaks;
    }

    void SaatSkorBerubah(int skor)
    {
        Debug.Log("[PenerimaEvent] Skor sekarang: " + skor);
    }

    void SaatPlayerMati()
    {
        Debug.Log("[PenerimaEvent] Player mati!");
    }

    void SaatZombieMati(Enemy zombie)
    {
        jumlahZombieMati++;
        Debug.Log("[PenerimaEvent] Zombie mati: " + zombie.name + " (total " + jumlahZombieMati + ")");
        if (teksZombieMati != null) teksZombieMati.text = "Zombie mati: " + jumlahZombieMati;
    }
}
