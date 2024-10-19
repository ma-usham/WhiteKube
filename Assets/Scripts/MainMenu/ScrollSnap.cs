using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollSnap : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public ScrollRect scrollRect;      // Reference to the ScrollRect
    public RectTransform contentPanel; // The content panel that holds the level pages
    public float snapSpeed = 10f;      // Speed of snapping to the nearest page
    private float[] pagePositions;     // Array of page positions
    private bool isSnapping = false;   // Check if currently snapping
    private int nearestPageIndex = 0;  // Index of nearest page

    private void Start()
    {
        int pageCount = contentPanel.childCount;
        pagePositions = new float[pageCount];

        // Calculate the normalized horizontal positions for each page
        float stepSize = 1f / (pageCount - 1); // Normalized step size between pages
        for (int i = 0; i < pageCount; i++)
        {
            pagePositions[i] = i * stepSize;
        }
    }

    private void Update()
    {
        if (isSnapping)
        {
            // Smoothly move to the nearest page position
            float newPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, pagePositions[nearestPageIndex], snapSpeed * Time.deltaTime);
            scrollRect.horizontalNormalizedPosition = newPosition;

            // Stop snapping when close enough to the target
            if (Mathf.Abs(scrollRect.horizontalNormalizedPosition - pagePositions[nearestPageIndex]) < 0.001f)
            {
                isSnapping = false; // Stop snapping when close to the target
            }
        }
    }

    // Called when user starts dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        isSnapping = false;  // Stop snapping while dragging
    }

    // Called when user ends dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        isSnapping = true;  // Start snapping when drag ends

        // Find the nearest page by calculating the shortest distance
        float currentPosition = scrollRect.horizontalNormalizedPosition;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < pagePositions.Length; i++)
        {
            float distance = Mathf.Abs(currentPosition - pagePositions[i]);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestPageIndex = i;
            }
        }
    }
}
