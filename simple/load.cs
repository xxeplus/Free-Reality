using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text text;

    public void LoadNextlevel()
    {
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        loadScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;//���ֵ��������0~1��

            text.text = operation.progress * 100 + "%"; 
            //����ڼ��س�������ߴﵽ90%
            if(operation.progress >= 0.9f)
            {
                slider.value = 1;

                text.text = "Press Any Key to Continue";
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

 }
