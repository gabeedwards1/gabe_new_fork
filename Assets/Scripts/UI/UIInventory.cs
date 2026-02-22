using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Hand hand;
    [SerializeField] private Image[] ItemSlots;

    void Start()
    {
        // Ensure the hand reference is found
        if (hand == null) hand = GetComponentInChildren<Hand>();
    }

    public void updateInventory()
    {
        if (hand.heldItems == null) { return; }
        for (int i = 0; i < hand.heldItems.Length; i++)
        {
            Debug.Log(ItemSlots[i]);
            if (hand.heldItems[i] != null)
            {
                SpriteRenderer sr = hand.heldItems[i].GetComponentInChildren<SpriteRenderer>(true);
                if (sr != null)
                {
                    ItemSlots[i].sprite = sr.sprite;
                    ItemSlots[i].color = Color.white;
                }
            }
        }
    }
}
