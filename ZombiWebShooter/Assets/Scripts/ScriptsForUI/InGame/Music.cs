using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _allMusic;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(CorountineMusic());
    }

 
    
    IEnumerator CorountineMusic()
    {
        while(true)
        {
            int _numberTrack = Random.Range(0, _allMusic.Count - 1);
            _audioSource.clip = _allMusic[_numberTrack];

            _audioSource.Play();
            yield return new WaitForSeconds(_allMusic[_numberTrack].length + Time.deltaTime);
            _audioSource.Stop();

        }
    }

}
