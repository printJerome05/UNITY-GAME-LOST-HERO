using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class endingscript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;
    void Start()
    {
        video.loopPointReached += LoadnextScene;
    }
    void LoadnextScene(VideoPlayer vp)
    {
        //INTRO AFTER THE VIDEO LOADED TO SCHOOL

        SceneManager.LoadScene("StartMenu");
    }

}
