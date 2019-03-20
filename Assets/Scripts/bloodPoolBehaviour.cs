using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodPoolBehaviour : MonoBehaviour
{
    public Sprite[] Bloodpools;
    private AudioPlayer audioPlayer;
    public SimpleAudioEvent deathSound;
    private bool played;
    public IntVariable currentLevel;

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        /////
        int index = Random.Range(0, Bloodpools.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = Bloodpools[index];
        float angle = Random.Range(0.0f, 359.9f);
        Vector3 up = new Vector3(0, 0, 1);
        var rotation = Quaternion.AngleAxis(angle, up);
        rotation.x = 0;
        rotation.y = 0;
        GetComponentInChildren<SpriteRenderer>().transform.rotation = rotation;
    }

    void Update()
    {
        if(played == false)
        {
            PlayDeathSound();
            played = true;
        }
        if(currentLevel.Value != 4)
            transform.position = transform.position + Vector3.down * 0.5f * Time.deltaTime;
    }

    public void PlayDeathSound()
    {
        audioPlayer.AudioEvent = deathSound;
        audioPlayer.PlaySound();
    }
}
