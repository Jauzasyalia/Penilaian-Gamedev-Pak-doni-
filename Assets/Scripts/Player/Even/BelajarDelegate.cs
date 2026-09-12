// using System;
// using UnityEngine;

// public class BelajarDelegate : MonoBehaviour
// {

//     delegate void AksiSederhana();
    
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         ContohAction1();
//         ContohAction2();
//         ContohAction3();
//     }

//     void ContohAction1()
//     {
//         AksiSederhana aksi = TulisHalo;
//         aksi();  
//     }

//     void ContohAction2()
//     {
//         AksiSederhana aksi = TulisHalo;
//         aksi += TulisDunia;
//         aksi();  
//     }

//     void ContohAction3()
//     {
//         Action aksi = TulisHalo;
//         aksi += TulisDunia;
//         aksi();
//     }

//     void TulisHalo()
//     {
//         Debug.Log("Halo");
//     }

//     void TulisDunia()
//     {
//         Debug.Log(" Dunia");
//     }

//     void TulisHaloDunia()
//     {
//         Debug.Log("Halo Dunia");
//     }


// }
