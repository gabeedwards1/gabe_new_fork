using TMPro;
using UnityEngine;

public class UIStats : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI strengthText;

    private float speed;
    private float health;
    private float strength;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* UNCOMMENT WHEN PLAYER IS IN SCENE
        player = GetComponent<PlayerController>();

        speed = player.Stats.MoveSpeed;
        health = player.Stats.MaxHealth;
        strength = player.Stats.Strength;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /* UNCOMMENT WHEN PLAYER IS IN SCENE
        speedText.text = string.Format("{0}%", speed);
        healthText.text = string.Format("{0}", health);
        strengthText.text = string.Format ("{0}", strength);
        */

        speedText.text = string.Format("{0}%", 100);
        healthText.text = string.Format("{0}%", 100);
        strengthText.text = string.Format("{0}%", 100);
    }
}
