# Penilaian-Gamedev-Pak-doni-

## Identitas
- **Nama** : Jauza Syalia Ghaisani
- **Kelas** : 11 PPLG 1
- **No Absen** : 15

## Isi Project (Unity 6 – 2D)

| No | Ketentuan | File |
|----|-----------|------|
| 1 | GameManager | `Assets/Scripts/Core/GameManager.cs` |
| 2 | PlayerMovement | `Assets/Scripts/Player/PlayerController.cs` (gerak + tembak) |
| 3 | OOP – Inheritance | `Assets/Scripts/Player/Enemy.cs` → diturunkan ke `EnemyChildren.cs` (jenis zombie) |
| 3 | OOP – Polymorph | `EnemyChildren.cs` meng-*override* `Serang()` dan `Mati()` |
| 3 | OOP – Abstraction | `Assets/Scripts/Player/IDamageable.cs` (interface, diimplementasi `Enemy` & `PlayerController`, dipakai `Bullet`) |
| 4 | State (min. 4) | `Assets/Scripts/Player/StateZombie.cs` (IDLE, PATROL, CHASE, ATTACK) dan `Core/GameState.cs` (MainMenu, Playing, Paused, GameOver) |
| 5 | Delegate | `Assets/Scripts/Player/Even/BelajarDelegate.cs` |
| 5 | Pemancar Event | `Assets/Scripts/Player/Even/PengirimEvent.cs` (+ `Enemy.OnZombieMati`) |
| 5 | Penerima Event | `Assets/Scripts/Player/Even/PenerimaEvent.cs` |

----|-----------|------|
| 1 | GameManager | `Assets/Scripts/Core/GameManager.cs` (juga penerima event `Enemy.OnZombieMati`) |
| 2 | PlayerMovement | `Assets/Scripts/PlayerMovement.cs` (gerak + tembak + implement `IDamageable`) |
| 3 | OOP – Inheritance | `Assets/Scripts/OOP/Enemy.cs` → diturunkan ke `ConeZombie`, `BucketHeadZombie`, `FlagZombie`, `EnemyChildren` |
| 3 | OOP – Polymorph | Tiap jenis zombie meng-*override* `Serang()` (dan `EnemyChildren` juga `Mati()`) |
| 3 | OOP – Abstraction | `Assets/Scripts/OOP/IDamageable.cs` (interface, diimplementasi `Enemy` & `PlayerMovement`, dipakai `Bullet`) |
| 4 | State (min. 4) | `Assets/Scripts/OOP/StateZombie.cs` (IDLE, PATROL, CHASE, ATTACK) dan `Core/GameState.cs` (MainMenu, Playing, Paused, GameOver) |
| 5 | Delegate | `Assets/Scripts/Events/BelajarDelegate.cs` |
| 5 | Pemancar Event | `Assets/Scripts/Events/PemancarEvent.cs` (+ `Enemy.OnZombieMati`) |
| 5 | Penerima Event | `Assets/Scripts/Events/PenerimaEvent.cs` |

----|-----------|------|
| 1 | GameManager | `Assets/Scripts/Core/GameManager.cs` |
| 2 | PlayerMovement | `Assets/Scripts/Player/PlayerController.cs` (gerak + tembak) |
| 3 | OOP – Inheritance | `Enemy.cs` → diturunkan ke `EnemyChildren.cs` (jenis zombie) |
| 3 | OOP – Polymorph | `EnemyChildren.cs` meng-*override* `Serang()` dan `Mati()` |
| 3 | OOP – Abstraction | `Assets/Scripts/Player/IDamageable.cs` (interface, diimplementasi `Enemy` & `PlayerController`) |
| 4 | State (min. 4) | `StateZombie.cs` (IDLE, PATROL, CHASE, ATTACK) dan `GameState.cs` (MainMenu, Playing, Paused, GameOver) |
| 5 | Delegate | `Assets/Scripts/Player/Even/BelajarDelegate.cs` |
| 5 | Pemancar Event | `Assets/Scripts/Player/Even/PengirimEvent.cs` (+ `Enemy.OnZombieMati`) |
| 5 | Penerima Event | `Assets/Scripts/Player/Even/PenerimaEvent.cs` |

---

# Panduan Lengkap Penggunaan Git & Repositori

Selamat datang di repositori proyek! Dokumen ini berisi standar operasional dan panduan menggunakan Git agar kolaborasi tim berjalan lancar, rapi, dan meminimalisir *conflict*, terutama saat bekerja dengan file berukuran besar (*assets*).

---

## 1. Inisialisasi Awal & Git LFS (Large File Storage)

Karena proyek ini menggunakan banyak aset berukuran besar (seperti 3D models, audio, tekstur), kita **wajib** menggunakan Git LFS.

**Langkah Pertama (Hanya dilakukan sekali saat baru bergabung):**

1. Pastikan Git dan [Git LFS](https://git-lfs.github.com/) sudah terinstal di komputermu.
2. *Clone* repositori ke komputermu:
   ```bash
   git clone <link-repositori>
   ```
3. Masuk ke folder proyek:
   ```bash
   cd nama-folder-proyek
   ```
4. Aktifkan Git LFS:
   ```bash
   git lfs install
   ```

## 2. Alur Kerja Harian (Daily Workflow)

Untuk mencegah bentrok (merge conflict) dengan pekerjaan anggota tim lain, biasakan melakukan urutan ini setiap kali kamu mulai dan selesai bekerja.

1. Sebelum Mulai Bekerja (Wajib!)
   ```bash
   # 1. Pastikan kamu berada di branch yang benar
   git checkout main  # atau develop, tergantung struktur tim

   # 2. Ambil informasi perubahan terbaru dari server
   git fetch origin

   # 3. Tarik perubahan terbaru ke komputermu
   git pull origin main
   ```

2. Setelah Selesai Bekerja / Ingin Menyimpan Progress
   ```bash
   # 1. Cek apa saja file yang berubah
   git status

   # 2. Tambahkan file yang ingin disimpan (gunakan `git add .` untuk semua file)
   git add .

   # 3. Buat commit dengan pesan yang jelas
   git commit -m "feat: menambahkan script pergerakan karakter utama"

   # 4. Upload perubahan ke server
   git push origin nama-branch-kamu
   ```
