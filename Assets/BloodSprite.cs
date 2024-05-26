using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Game.Player;
using UnityEngine.UI;

public class BloodSprite : MonoBehaviour
{
    [SerializeField] private PlayerHpController _hpController;

    [SerializeField] private int valueToReach;

    private Image _bloodSpriteImage;

    void Start()
    {
        _hpController.OnHealthChanged += HandleHealthChange;
        _bloodSpriteImage = GetComponent<Image>();
    }

    private void HandleHealthChange(int currentHP)
    {
        if (currentHP < 20)
        {
            float t = Mathf.InverseLerp(0, 20, currentHP);
            float alpha = Mathf.Lerp(0, 150f / 255f, t); // 150 out of 255 for alpha

            Color color = _bloodSpriteImage.color;
            color.a = alpha;
            _bloodSpriteImage.color = color;
        }
        else
        {
            Color color = _bloodSpriteImage.color;
            color.a = 0;
            _bloodSpriteImage.color = color;
        }
    }
}
