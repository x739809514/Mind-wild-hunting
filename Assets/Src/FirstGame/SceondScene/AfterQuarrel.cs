using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterQuarrel : MonoBehaviour
{
    public UI_FadeInFadeOut Ui_FadeInFade;
    public GameObject nextScene;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OutScene", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha == 0)
        {
            gameObject.SetActive(false);
            Invoke("GoToNextScene", 1);
        }
    }

    private void OutScene()
    {
        Ui_FadeInFade.Ui_FadeOut_Event();
    }

    private void GoToNextScene()
    {
        nextScene.SetActive(true);
    }
}
