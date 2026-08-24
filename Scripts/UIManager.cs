using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image hpMaskImage;
    public Image mpMaskImage;
    private float originalSize;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        originalSize = hpMaskImage.rectTransform.rect.width;
    }

    /// <summary>
    /// 设置血量UI值
    /// </summary>
    /// <param name="fillPercent">填充百分比</param>
    public void SetHPValue(float fillPercent)
    { 
        hpMaskImage.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,fillPercent * originalSize);
    }

    /// <summary>
    /// 设置蓝条UI值
    /// </summary>
    /// <param name="fillPercent">填充百分比</param>
    public void SetMPValue(float fillPercent)
    {
        mpMaskImage.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,fillPercent * originalSize);
    }
}
