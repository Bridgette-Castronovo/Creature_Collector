using UnityEngine;

public class ImageClick : MonoBehaviour
{
    public animalBook book;
    public int targetPageIndex;
    public Creature creature;

    public void OnImageClicked()
    {
        Debug.Log(creature.speciesName);

        if (book == null) return;

        Transform pageTransform = book.GetPage(targetPageIndex);

        if (pageTransform != null)
        {
            PageDisplay page = pageTransform.GetComponent<PageDisplay>();

            if (page != null)
            {
                page.SetData(creature);
            }
        }

        book.GoToPage(targetPageIndex);
    }
}