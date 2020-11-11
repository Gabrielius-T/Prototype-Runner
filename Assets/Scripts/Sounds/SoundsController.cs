using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SoundsController : MonoSingleton<SoundsController>
{
    [Header("Sounds")] 
    [SerializeField] Transform effectsSoundsParent;
    [SerializeField] Transform soundTracksParent;
    [SerializeField] Transform uiSoundsParent;
    [SerializeField] Transform otherSoundsParent;

    List<AudioSource> soundTracks;
    List<AudioSource> effects;

    readonly List<float> timersList = new List<float>(){0, 0, 0};
    int availableTimerIndex = -1;
    float timerThreshold = 0.2f;
    
    public Dictionary<string, AudioSource> allSounds = new Dictionary<string, AudioSource>();

    new void Awake()
    {
        base.Awake();
        Initialize();
    }

    void Update()
    {
        for (int _i = 0; _i < timersList.Count; _i++)
        {
            timersList[_i] -= Time.deltaTime;
        }
    }

    void Initialize()
    {
        CollectAllSceneSounds();
    }

    void CollectAllSceneSounds()
    {
        effects = CollectSounds(effectsSoundsParent);
        soundTracks = CollectSounds(soundTracksParent);
        CollectSounds(uiSoundsParent);
        CollectSounds(otherSoundsParent);
    }

    List<AudioSource> CollectSounds(Transform _soundsParent)
    {
        if (_soundsParent)
        {
            List<AudioSource> _sources = _soundsParent.GetComponentsInChildren<AudioSource>().ToList();
            
            foreach (AudioSource _audioSource in _sources)
            {
                allSounds.Add(_audioSource.name, _audioSource);
            }

            return _sources;
        }
        return null;
    }

    public void PlayOnce(string _audioSourceName, bool _doNotPause = false)
    {
        if (allSounds.ContainsKey(_audioSourceName))
        {
            AudioSource _foundSource = allSounds[_audioSourceName];
            if (!_foundSource.isPlaying)
            {
                _foundSource.Play();
            }
        }
    }

    public float Volume(string _audioSourceName)
    {
        if (allSounds.ContainsKey(_audioSourceName))
        {
            AudioSource _foundSource = allSounds[_audioSourceName];
            return _foundSource.volume;
        }
        return -1f;
    }

    public AudioSource GetAudioSource(string _audioSourceName)
    {
        if (allSounds.ContainsKey(_audioSourceName))
        {
            return allSounds[_audioSourceName];
        }
        return null;
    }

    public void PlayOneShot(string _audioSourceName)
    {
        if (allSounds.ContainsKey(_audioSourceName))
        {
            AudioSource _foundSource = allSounds[_audioSourceName];
            _foundSource.PlayOneShot(_foundSource.clip);
        }
    }

    /// <summary>
    /// All sounds should be named the same only with a different index at the end
    /// </summary>
    /// <param name="_audioSourceName"></param>
    /// <param name="_fadeIn"></param>
    public void PlayRandom(string _audioSourceName, bool _limited, bool _fadeIn = false)
    {
        if (_limited && !TimerAvailable())
        {
            return;
        }
        if (_limited)
        {
            timersList[availableTimerIndex] = timerThreshold;
        }
        List<AudioSource> _foundSources = GetAllSounds(_audioSourceName);
        
        if(_foundSources.Count > 0)
        {
            int _index = Random.Range(0, _foundSources.Count);
            AudioSource _selectedSource = _foundSources[_index];
            _selectedSource.PlayOneShot(_selectedSource.clip);
        }
    }

    bool TimerAvailable()
    {
        for (int _i = 0; _i < timersList.Count; _i++)
        {
            float _timer = timersList[_i];
            if (_timer <= 0f)
            {
                availableTimerIndex = _i;
                return true;
            }
        }
        availableTimerIndex = -1;
        return false;
    }

    List<AudioSource> GetAllSounds(string _audioSourceName)
    {
        List<AudioSource> _foundSources = new List<AudioSource>();
        foreach (AudioSource _audioSource in allSounds.Values)
        {
            if (_audioSource.name.StartsWith(_audioSourceName))
            {
                _foundSources.Add(_audioSource);
            }
        }
        return _foundSources;
    }

    public void Stop(string _audioSourceName)
    {
        if (allSounds.ContainsKey(_audioSourceName))
        {
            AudioSource _foundSource = allSounds[_audioSourceName];
            _foundSource.Stop();
        }
    }
}
