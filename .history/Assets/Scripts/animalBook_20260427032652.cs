using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class animalBook : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List <Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] Transform firstDragonPage;
    [SerializeField] GameObject unknownImage;
    [SerializeField] GameObject dragonImage;
    [SerializeField] Sprite unknownSprite;
    [SerializeField] Sprite dragonSprite;

    private void Start() {
    InitialState();
    QuestManager.Instance.firstCreatureCollected = true;
    if (firstDragonPage == null)
    {
        Debug.LogError("First Dragon Page is NOT assigned!");
        return;
    }

    bool unlocked = QuestManager.Instance != null && QuestManager.Instance.firstCreatureCollected;

    
    firstDragonPage.gameObject.SetActive(unlocked);

    if (firstDragonCardImage != null)
    {
        firstDragonCardImage.sprite = unlocked ? dragonSprite : unknownSprite;
    }
}
    public Transform GetPage(int index)
    {
        if (index < 0 || index >= pages.Count) return null;
        return pages[index];
    }
    public void InitialState() {
        index = -1;
        for (int i=0; i < pages.Count; i++) {
            pages[i].transform.rotation= Quaternion.identity;
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
    }
  
    public void RotateNext() {

        if (index >= pages.Count - 1) return;
        if (rotate==true) return;
        index++;
        float angle = 180;
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
        BackButtonActions();
        

    }


    public void RotatePrev() {

        if (rotate==true) return;
        if (index <= -1) return;
        float angle = 0;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));

    }
    public void BackButtonActions() {
    backButton.SetActive(index >= 0);
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

    IEnumerator Rotate(float angle, bool forward) {
        rotate = true;
        float value = 0f;
        while(true) {
            Quaternion targetRotation = Quaternion.Euler(0,angle,0);
            value += Time.deltaTime*pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation,value);
            float angle1 = Quaternion.Angle(pages[index].rotation,targetRotation);
            if (angle1 < 0.1f) {
                if (forward == false) {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }

    }
}