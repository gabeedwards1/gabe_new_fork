using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    // Allow other scripts to read the stats
    public PlayerStats Stats => stats;

    void Update()
    {
        
    }
}