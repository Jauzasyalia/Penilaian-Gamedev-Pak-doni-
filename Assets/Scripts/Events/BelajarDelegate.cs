using System;
using UnityEngine;

// Script Delegate: mendefinisikan delegate custom dan contoh pemakaiannya
public class BelajarDelegate : MonoBehaviour
{
    // Deklarasi delegate custom: "cetakan" fungsi tanpa parameter & tanpa return
    public delegate void AksiSederhana();

    // Delegate dengan parameter
    public delegate void AksiDenganPesan(string pesan);

    void Start()
    {
        ContohDelegateTunggal();
        ContohMulticastDelegate();
        ContohActionBawaan();
        ContohDelegateParameter();
    }

    // 1. Delegate menunjuk ke satu fungsi
    void ContohDelegateTunggal()
    {
        AksiSederhana aksi = TulisHalo;
        aksi();
    }

    // 2. Multicast delegate: satu delegate memanggil banyak fungsi
    void ContohMulticastDelegate()
    {
        AksiSederhana aksi = TulisHalo;
        aksi += TulisDunia;
        aksi();
    }

    // 3. Action = delegate bawaan C# (tanpa perlu deklarasi sendiri)
    void ContohActionBawaan()
    {
        Action aksi = TulisHalo;
        aksi += TulisDunia;
        aksi();
    }

    // 4. Delegate dengan parameter + lambda
    void ContohDelegateParameter()
    {
        AksiDenganPesan aksi = TulisPesan;
        aksi += (p) => Debug.Log("Lambda menerima: " + p);
        aksi("Delegate dengan parameter");
    }

    void TulisHalo()  { Debug.Log("Halo"); }
    void TulisDunia() { Debug.Log("Dunia"); }
    void TulisPesan(string pesan) { Debug.Log("Pesan: " + pesan); }
}
