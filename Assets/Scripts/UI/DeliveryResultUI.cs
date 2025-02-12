using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += Delivery_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += Delivery_OnRecipeFailed;
        gameObject.SetActive(false);
    }

    private void Delivery_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "DELIVERY\n FAILED";
    }

    private void Delivery_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color=successColor;
        iconImage.sprite = successSprite;
        messageText.text = "DELIVERY\n SUCCESS";
    }
}
