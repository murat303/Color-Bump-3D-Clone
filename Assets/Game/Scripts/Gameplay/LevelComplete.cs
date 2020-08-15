using UnityEngine;

namespace ColorBump
{
    public class LevelComplete : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();

            if (!player || LevelManager.ins.IsGameOver) return;

            Messenger.Send(new GameOver(true));
        }
    }
}
