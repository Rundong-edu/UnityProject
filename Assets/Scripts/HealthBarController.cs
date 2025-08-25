using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Header("Refs")]
    public GameManager gameManager;
    public RectTransform container;     // The parent of Background/Green/Red (width = full bar)
    public Image greenFillImage;        // child of container
    public Image redDepleteImage;       // child of container

    private float maxHealth;

    void Awake()
    {
        // Ensure both fills are children of the same container and use correct anchors/pivots
        if (container)
        {
            if (greenFillImage)  SetupLeftLocked(greenFillImage.rectTransform);
            if (redDepleteImage) SetupRightLocked(redDepleteImage.rectTransform);
        }
    }

    void Start()
    {
        if (!gameManager)
        {
            Debug.LogError("GameManager not assigned!");
            return;
        }

        maxHealth = gameManager.globalMaxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (!gameManager || !container || !greenFillImage || !redDepleteImage) return;

        float current = Mathf.Clamp(gameManager.CurrentGlobalHealth, 0f, gameManager.globalMaxHealth);
        float ratio   = (gameManager.globalMaxHealth <= 0f) ? 0f : current / gameManager.globalMaxHealth;

        // Use the container’s actual width; no magic 300f required
        float totalWidth = container.rect.width;

        // Round so the two widths always perfectly cover the bar with no gap/overlap
        float greenWidth = Mathf.Round(totalWidth * ratio);
        float redWidth   = Mathf.Max(0f, totalWidth - greenWidth);

        // Apply widths (x only). Y/height is unchanged (or stretch via vertical anchors if you prefer)
        var gRect = greenFillImage.rectTransform;
        gRect.sizeDelta = new Vector2(greenWidth, gRect.sizeDelta.y);
        gRect.anchoredPosition = new Vector2(0f, 0f); // left edge of container

        var rRect = redDepleteImage.rectTransform;
        rRect.sizeDelta = new Vector2(redWidth, rRect.sizeDelta.y);
        rRect.anchoredPosition = new Vector2(0f, 0f); // right edge of container

        // Together they cover full width; background never shows
        // Green shrinks from right, Red grows from left (visually from the right edge)
    }

    void SetupLeftLocked(RectTransform rt)
    {
        if (rt.parent != container) rt.SetParent(container, false); // keep local alignment
        rt.anchorMin = new Vector2(0f, 0.5f);
        rt.anchorMax = new Vector2(0f, 0.5f);
        rt.pivot     = new Vector2(0f, 0.5f);
        rt.anchoredPosition = Vector2.zero;
    }

    void SetupRightLocked(RectTransform rt)
    {
        if (rt.parent != container) rt.SetParent(container, false);
        rt.anchorMin = new Vector2(1f, 0.5f);
        rt.anchorMax = new Vector2(1f, 0.5f);
        rt.pivot     = new Vector2(1f, 0.5f);
        rt.anchoredPosition = Vector2.zero;
    }

    // Optional: recalc if the bar is resized at runtime (layout/canvas scaler)
    void OnRectTransformDimensionsChange()
    {
        UpdateHealthBar();
    }
}
