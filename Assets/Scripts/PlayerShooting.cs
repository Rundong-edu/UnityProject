using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint;     // Where bullets spawn
    public float fireRate = 0.5f;   // Time between shots

    [Header("Audio")]
    public AudioClip shootSfx;      // Drag your SFX here
    [Range(0f, 1f)] public float shootVolume = 0.85f;

    private float nextFireTime = 0f;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 2D. Set to 1f for 3D positional audio.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        if (shootSfx != null)
        {
            // PlayOneShot allows overlapping shots without cutting off earlier ones
            audioSource.PlayOneShot(shootSfx, shootVolume);
        }
    }
}
