using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnityToast : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _fadeDuration;

    [Space]
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _canvasGroup;

    private float _elapseTime;

    private ToastAnimationState _animationState;

    private bool _isActive;

    [ContextMenu("Test Show")]
    public void TestShow()
    {
        Show("This is just a test toast");
    }

    public void Show(string msg)
    {
        if (!_isActive)
        {
            _text.text = msg;
            _canvasGroup.gameObject.SetActive(true);

            _canvasGroup.alpha = 0;
            _elapseTime = 0;
            _animationState = ToastAnimationState.FadeIn;

            _isActive = true;
        }
        else
        {
            _text.text = msg;

            if (_animationState == ToastAnimationState.FadeIn || _animationState == ToastAnimationState.Shown)
            {
                _elapseTime = 0;
            }
            else if (_animationState == ToastAnimationState.FadeOut)
            {
                _animationState = ToastAnimationState.FadeIn;
            }
        }
    }

    private void Update()
    {
        _elapseTime += Time.deltaTime;

        if (_animationState == ToastAnimationState.FadeIn)
        {
            _canvasGroup.alpha = Mathf.Lerp(0, 1, _elapseTime / _fadeDuration);

            if (_elapseTime >= _fadeDuration)
            {
                _canvasGroup.alpha = 1;

                _elapseTime = 0;
                _animationState = ToastAnimationState.Shown;
            }
        }
        else if (_animationState == ToastAnimationState.Shown)
        {
            if (_elapseTime >= _duration)
            {
                _elapseTime = 0;
                _animationState = ToastAnimationState.FadeOut;
            }
        }
        else if (_animationState == ToastAnimationState.FadeOut)
        {
            _canvasGroup.alpha = 1 - Mathf.Lerp(0, 1, _elapseTime / _fadeDuration);

            if (_elapseTime >= _fadeDuration)
            {
                _canvasGroup.alpha = 0;

                Destroy(this.gameObject);
            }
        }
    }

    public bool IsDestroyed()
    {
        return this.IsDestroyed();
    }

    private enum ToastAnimationState
    {
        FadeIn,
        Shown,
        FadeOut
    }
}
