using System;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public static event Action OnLevelEnd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            OnLevelEnd?.Invoke();
        }
    }
}
