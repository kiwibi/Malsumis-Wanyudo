﻿using UnityEngine;
using UnityEngine.Experimental.U2D;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Bullet;

    private string fireButton = "Fire1";
    private PlayerStats stats;
    private float playerPistolCooldown;
    private float timeBetweenShoots;
    private AudioPlayer audioPlayer;
    private BulletSpawnPoint bulletSpawnPoint;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        audioPlayer = GetComponent<AudioPlayer>();
        bulletSpawnPoint = GetComponentInChildren<BulletSpawnPoint>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pauseMenu.isPaused != true)
        {
            if (stats.pistolCooldown.Value > 0)
            {
                playerPistolCooldown -= Time.deltaTime;
            }
            if (Input.GetButton(fireButton) == true && playerPistolCooldown < 0)
            {
                timeBetweenShoots = stats.pistolCooldown.Value;

                var bullet = Instantiate(Bullet, new Vector3(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y, 0), Quaternion.identity);
                bullet.GetComponentInChildren<SpriteRenderer>().transform.rotation = spriteRenderer.transform.rotation;
                bullet.GetComponent<BulletBehavior>().direction = GetComponentInChildren<SpriteRenderer>().transform.up;
                playerPistolCooldown = stats.pistolCooldown.Value;
                audioPlayer.PlaySound();
            }
        }
    }
}
