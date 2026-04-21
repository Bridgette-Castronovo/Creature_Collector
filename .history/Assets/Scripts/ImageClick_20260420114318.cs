using UnityEngine;

public class ImageClick : MonoBehaviour
{
    public animalBook book;
    public int targetPageIndex;
    public Creature creature;

    public void OnImageClicked()
    {
        

        if (book == null) return;

        Transform pageTransform = book.GetPage(targetPageIndex);
        Debug.Log(creature.speciesName);
        if (pageTransform == null)
        {
            Debug.LogError("PAGE TRANSFORM IS NULL");
        }
        if (pageTransform != null)
        {
            PageDisplay page = pageTransform.GetComponent<PageDisplay>();

            if (page == null)
            {
                Debug.LogError("PageDisplay NOT found on this page!");
            }

            if (page != null)
            {
                page.SetData(creature);
            }
        }

        book.GoToPage(targetPageIndex);
    }
}