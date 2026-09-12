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
