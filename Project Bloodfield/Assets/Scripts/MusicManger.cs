using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //This is for the songs that we will be playing in our level
    public AudioSource levelMusic;
    public AudioSource pauseMenuMusic;
    //this is what we use to control which song is being played
    private AudioSource currentMusic;

    void Start()
    {
        // Start playing the level music by default
        PlayMusic(levelMusic);
    }

    //These are our two game states pause and unpaused
    public void Pause()
    {
        currentMusic.Pause();
    }

    public void UnPause()
    {
        currentMusic.UnPause();
    }

    public void SwitchToLevelMusic()
    {
        PlayMusic(levelMusic);
    }

    public void SwitchToPauseMenuMusic()
    {
        PlayMusic(pauseMenuMusic);
    }

    private void PlayMusic(AudioSource musicSource)
    {
        currentMusic = musicSource;
        currentMusic.Play();
        currentMusic.loop = true; // Set looping as needed for the specific track
    }
}
