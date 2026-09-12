using System;
using UnityEngine;
using UnityEngine.InputSystem;

// PEMANCAR EVENT (publisher)
// Event = delegate yang lebih aman: kelas lain boleh langganan (+=),
// tapi HANYA pemancar yang boleh Invoke.
// PenerimaEvent berlangganan ke event-event di bawah ini.
public class PengirimEvent : MonoBehaviour
{
    // --- Event sederhana: tekan spasi (sama seperti contoh di kelas) ---
    public static event Action OnTekanSpasi;

    // --- Event gameplay ---
    // Delegate custom untuk event HP
    public delegate void HPBerubahHandler(float hpSekarang, float hpMaks);
    public static event HPBerubahHandler OnHPBerubah;

    // Event berbasis Action (delegate bawaan C#)
    public static event Action<int> OnSkorBerubah;
    public static event Action OnPlayerMati;
    public static event Action OnGameMulai;

    void Start()
    {
        Debug.Log("Pemancar: game mulai, kirim event OnGameMulai.");
        OnGameMulai?.Invoke();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Pemancar: spasi ditekan, kirim event.");
            OnTekanSpasi?.Invoke();
        }
    }

    // Dipanggil oleh PlayerController
    public static void PancarkanHPBerubah(float hpSekarang, float hpMaks)
    {
        OnHPBerubah?.Invoke(hpSekarang, hpMaks);
    }

    public static void PancarkanSkorBerubah(int skor)
    {
        OnSkorBerubah?.Invoke(skor);
    }

    public static void PancarkanPlayerMati()
    {
        OnPlayerMati?.Invoke();
    }
}
