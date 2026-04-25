using UnityEngine;

public class ImageClick : MonoBehaviour
{
    public animalBook book;
    public int targetPageIndex;
    public Creature creature;

    public void OnImageClicked()
    {
        if (book == null) return;

        if (targetPageIndex >= 0 && targetPageIndex < book.pages.Count)
        {
            PageDisplay page = book.pages[targetPageIndex].GetComponent<PageDisplay>();

            if (page != null)
            {
                page.SetData(creature);
            }
        }

        book.GoToPage(targetPageIndex);
    }
}