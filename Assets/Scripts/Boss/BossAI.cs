using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(BossHealth))]
public class BossAI : MonoBehaviour {

    private BossHealth bossHealth;
    private Animator animator;

    [SerializeField]
    private float ground;
    [SerializeField]
    private float air;
    [SerializeField]
    private GameObject whirlwind;

    private Transform player;

    private enum Attacks { Punch, Whirlwind }
    private Attacks attack;

    private void Start() {
        bossHealth = GetComponent<BossHealth>();
        animator = GetComponent<Animator>();

        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(WaitForAttack());
    }

    private void Update() {
        transform.LookAt(player.position);
    }

    private void Attack() {
        if (!bossHealth.isDead) {
            attack = (Attacks)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Attacks)).Length);

            switch (attack) {
                case Attacks.Punch:
                    animator.SetTrigger("Smash");
                    break;
                case Attacks.Whirlwind:
                    print("whirlwind");

                    animator.SetTrigger("Smash");
                    GameObject whirlwindInstance = Instantiate(whirlwind);
                    whirlwindInstance.transform.position = transform.position;
                    break;
            }

            StartCoroutine(WaitForAttack());
        }
    }

    private IEnumerator WaitForAttack() {
        yield return new WaitForSeconds(UnityEngine.Random.Range(8, 12));
        Attack();
    }
}
