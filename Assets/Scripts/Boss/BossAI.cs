using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class BossAI : MonoBehaviour {

    [SerializeField]
    private float ground;
    [SerializeField]
    private float air;

    private Transform player;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        transform.LookAt(player.position);
    }
}
