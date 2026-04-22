using UnityEngine;

public class ImageClick : MonoBehaviour
{
    public animalBook book;
    public int targetPageIndex;
    public Creature creature;

    public void OnImageClicked()
    {
        if (book == null) return;

       
        Transform contentPage = book.GetPage(targetPageIndex + 1);

        if (contentPage != null)
        {
            PageDisplay page = contentPage.GetComponent<PageDisplay>();

            if (page != null)
            {
                page.SetData(creature);
            }
            else
            {
                Debug.LogError("No PageDisplay on content page!");
            }
        }
        else
        {
            Debug.LogError("Content page is NULL!");
        }

        
        book.GoToPage(targetPageIndex);
    }
}