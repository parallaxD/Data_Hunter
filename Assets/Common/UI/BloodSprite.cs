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
        if (currentHP <= 20)
        {
            Color color = _bloodSpriteImage.color;
            color.a = 0.6f;
            _bloodSpriteImage.color = color;
        }
        else if (currentHP > 20)
        {
            Color color = _bloodSpriteImage.color;
            color.a = 0;
            _bloodSpriteImage.color = color;
        }
    }
}
