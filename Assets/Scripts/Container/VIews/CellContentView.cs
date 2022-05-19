using System;
using Enums;
using UnityEngine.UI;
using UnityEngine;

namespace Container.VIews
{
    public class CellContentView: MonoBehaviour
    {
        public event Action ContentViewChanged;
        
        [SerializeField]private Image _image;
        
        private Sprite _sprite;
        public Sprite Sprite
        {
            get => _sprite;
            set
            {
                _sprite = value;
                ContentViewChanged?.Invoke();
            }
        }

        private VisibilityType _visibilityType;

        public VisibilityType VisibilityType
        {
            get=>_visibilityType;
            set
            {
                _visibilityType = value;
                ContentViewChanged?.Invoke();
            }
        }

        private void OnEnable()
        {
            ContentViewChanged += OnContentViewChanged;
        }

        private void OnDisable()
        {
            ContentViewChanged -= OnContentViewChanged;
        }

        public void OnContentViewChanged()
        {
            _image.sprite = _sprite;
            switch (VisibilityType)
            {
                case VisibilityType.Visible: _image.enabled = true; break;
                case VisibilityType.Invisible: _image.enabled = false; break;
            }
        }
    }
}