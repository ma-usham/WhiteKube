using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollSnap : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public float snapSpeed = 10f;  // The speed of the snapping
    public float swipeThreshold = 0.2f;  // How far the user must swipe to go to the next page

    private float[] pagePositions;
    private int currentPageIndex = 0;
    private bool isDragging = false;
    private float targetPosition;
    private float dragStartPosition;

    void Start()
    {
        try
        {
            int pageCount = contentPanel.childCount;

            if (pageCount < 1)
                throw new System.Exception("Content panel must have at least one child.");

            pagePositions = new float[pageCount];

            // Calculate the normalized positions for each page
            for (int i = 0; i < pageCount; i++)
            {
                pagePositions[i] = (float)i / (pageCount - 1);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ScrollSnap Initialization Error: " + ex.Message);
        }
    }

    void Update()
    {
        try
        {
            if (!isDragging)
            {
                // Smoothly move the content to the target position
                scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPosition, snapSpeed * Time.deltaTime);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ScrollSnap Update Error: " + ex.Message);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        try
        {
            isDragging = true;
            dragStartPosition = scrollRect.horizontalNormalizedPosition;  // Record the position when drag starts
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ScrollSnap OnBeginDrag Error: " + ex.Message);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        try
        {
            isDragging = false;

            float dragDistance = scrollRect.horizontalNormalizedPosition - dragStartPosition;

            // If the user swiped more than the threshold, move to the next or previous page
            if (Mathf.Abs(dragDistance) > swipeThreshold)
            {
                if (dragDistance > 0)
                {
                    // Swiped left, go to the previous page
                    currentPageIndex = Mathf.Max(currentPageIndex - 1, 0);
                }
                else
                {
                    // Swiped right, go to the next page
                    currentPageIndex = Mathf.Min(currentPageIndex + 1, pagePositions.Length - 1);
                }
            }

            // Set the target position to the nearest page
            targetPosition = pagePositions[currentPageIndex];
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ScrollSnap OnEndDrag Error: " + ex.Message);
        }
    }

    public void ScrollToPage(int pageIndex)
    {
        try
        {
            // Manually scroll to a specific page
            currentPageIndex = Mathf.Clamp(pageIndex, 0, pagePositions.Length - 1);
            targetPosition = pagePositions[currentPageIndex];
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ScrollSnap ScrollToPage Error: " + ex.Message);
        }
    }
}
