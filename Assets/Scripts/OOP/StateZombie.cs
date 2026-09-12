// State machine zombie (minimal 4 state)
public enum StateZombie
{
    IDLE,   // diam menunggu
    PATROL, // berkeliling area
    CHASE,  // mengejar player
    ATTACK  // menyerang player
}
