using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class animalBook : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List <Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    private void Start() {
        backButton.SetActive(false);

    }
  
    public void RotateNext() {
        Debug.Log(index);
        Debug.Log("next");
        if (index >= pages.Count - 1) return;
        if (rotate==true) return;
        index++;
        float angle = 180;
        ForwardButtonAction();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
        

    }

    public void ForwardButtonAction() {
        if (backButton.activeInHierarchy == false) {
            backButton.SetActive(true);
        }
        if (index >= pages.Count - 1) {
            forwardButton.SetActive(false);
        }
    }

    public void RotatePrev() {
        Debug.Log(index);
        Debug.Log("prev");
        if (rotate==true) return;
        if (index <= -1) return;
        float angle = 0;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));

    }
    public void BackButtonActions() {
        if(forwardButton.activeInHierarchy == false) {
            forwardButton.SetActive(true);
        }
        if(index -1 == -1) {
            backButton.SetActive(false);
        }
    }
    public void GoToPage(int targetIndex)
    {
        if (rotate) return;

        if (targetIndex < 0 || targetIndex >= pages.Count) return;

        StartCoroutine(FlipToPage(targetIndex));
    }

    IEnumerator FlipToPage(int targetIndex)
    {
        while (index < targetIndex)
        {
            RotateNext();
            yield return new WaitUntil(() => rotate == false);
        }

        while (index > targetIndex)
        {
            RotatePrev();
            yield return new WaitUntil(() => rotate == false);
        }
    }

    IEnumerator FlipToPage(int targetIndex)
    {
        while (index < targetIndex)
        {
            int prevIndex = index;

            RotateNext();
            yield return new WaitUntil(() => rotate == false);

            if (index == prevIndex) yield break; 
        }

        while (index > targetIndex)
        {
            int prevIndex = index;

            RotatePrev();
            yield return new WaitUntil(() => rotate == false);

            if (index == prevIndex) yield break; 
        }
    }
}
