using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private bool useRipple = true;
    [SerializeField] private GameObject rippleParent;
    
    [SerializeField] private RippleUpdateMode rippleUpdateMode = RippleUpdateMode.UNSCALED_TIME;
    [SerializeField] private Sprite rippleShape;
    [Range(0.1f, 5)] public float speed = 1f;
    [Range(0.5f, 25)] public float maxSize = 4f;
    [SerializeField] private Color startColor = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color transitionColor = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private bool centered = false;
    private bool isPointerOn;
    
    public enum RippleUpdateMode
    {
        NORMAL,
        UNSCALED_TIME
    }
    
    void Start()
    {
        if (useRipple == true && rippleParent != null)
            rippleParent.SetActive(false);
        else if (useRipple == false && rippleParent != null)
            Destroy(rippleParent);
    }
    
    private void CreateRipple(Vector2 pos)
    {
        if (rippleParent != null)
        {
            GameObject rippleObj = new GameObject();
            rippleObj.AddComponent<Image>();
            rippleObj.GetComponent<Image>().sprite = rippleShape;
            rippleObj.name = "Ripple";
            rippleParent.SetActive(true);
            rippleObj.transform.SetParent(rippleParent.transform);

            if (centered == true)
            {
                rippleObj.transform.localPosition = new Vector2(0f, 0f);
            }
            else
            {
                rippleObj.transform.position = pos;
            }

            rippleObj.AddComponent<Ripple>();
            Ripple tempRipple = rippleObj.GetComponent<Ripple>();
            tempRipple.speed = speed;
            tempRipple.maxSize = maxSize;
            tempRipple.startColor = startColor;
            tempRipple.transitionColor = transitionColor;

            tempRipple.unscaledTime = rippleUpdateMode != RippleUpdateMode.NORMAL;
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOn = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (useRipple == true && isPointerOn == true)
        {
            CreateRipple(Input.mousePosition);
        }
        else if (useRipple == false)
        {
            this.enabled = false;
        }
    }
}
