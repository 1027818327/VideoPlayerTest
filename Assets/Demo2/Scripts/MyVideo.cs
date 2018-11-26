using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyVideo : MonoBehaviour {
    public VideoPlayer vPlayer;
    public AudioSource source;
    public string url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";

    private void Awake()
    {
        vPlayer = transform.gameObject.AddComponent<VideoPlayer>();
        source = transform.gameObject.AddComponent<AudioSource>();

        vPlayer.playOnAwake = false;
        source.playOnAwake = false;
    }

    // Use this for initialization
    void Start () {
        vPlayer.source = VideoSource.Url;
        vPlayer.url = url;
        vPlayer.SetTargetAudioSource(0, source);
        vPlayer.prepareCompleted += Prepared;
        vPlayer.Prepare();
	}

    private void ChangeVideo() {
        //前进20秒
        vPlayer.time += 20f;
        //后退20秒
        vPlayer.time -= 20f;
    }

    private void ChangeAudio() {
        source.volume += 20f;
        source.volume -= 20f;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void Prepared(VideoPlayer player)
    {
        player.Play();
    }

}
