using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject playerController;
    private Transform playerObject;
    public float offsetToPlayer;
    private int wavesCount = 5;

    void Start()
    {
        playerObject = playerController.gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        AttachSpawnManagerToPlayer();
        BulletShootingSystem();
    }
    private void AttachSpawnManagerToPlayer()
    {
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + offsetToPlayer);
    }
    private void BulletShootingSystem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }
    }
    private void SpawningTheWave()
    {

    }
}
