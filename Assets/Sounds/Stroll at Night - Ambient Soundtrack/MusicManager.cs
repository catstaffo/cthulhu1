using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioClip intro, loop;
   

    void Start() {

        if (intro != null)
        {

            BGMController.Instance.PlayBGMWithIntro(intro, loop);
        }
        else
        {
            BGMController.Instance.PlayBGM(loop);
        }
    }
}
