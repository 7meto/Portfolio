using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]   
    private UnityEngine.UI.Image healthBarForegroundImage;

    public void UdateHealthBar(HealthController healthController)
    {
        healthBarForegroundImage.fillAmount = healthController.RemainingHealthPercentage;
    }

}
