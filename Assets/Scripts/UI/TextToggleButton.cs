using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    /// <summary>
    /// A toggle button allowing the user to pick one of several Text options.
    /// </summary>
    [AddComponentMenu("UI/Text Toggle Button", 31)]
    public class TextToggleButton : Selectable, IPointerClickHandler
    {
        [SerializeField]
        private Text[] texts;
        [Space]
        [SerializeField]
        //private Button.ButtonClickedEvent onClick = new Button.ButtonClickedEvent();

        private int currentTextIndex;

        protected TextToggleButton()
        {        
        }

        public Text CurrentText
        {
            get { return texts[currentTextIndex]; }
        }

        /// <summary>
        /// UnityEvent that is triggered when the text toggle button is pressed.
        /// </summary>
        [HideInInspector]
        public TextToggleButtonClickedEvent OnClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Press();
            }
        }

        public bool TryChangeText(string targetText)
        {
            var newTextIndex = -1;
            for (var i = 0; i < texts.Length; i++)
            {
                if (texts[i].text.Equals(targetText))
                {
                    newTextIndex = i;
                    break;
                }
            }

            if (newTextIndex >= 0)
            {
                ChangeText(newTextIndex);
                return true;
            }

            return false;
        }

        protected override void Awake()
        {
            if (texts.Length > 0)
            {
                targetGraphic = CurrentText;
            }
            else if (targetGraphic != null && targetGraphic is Text)
            {
                texts = new Text[1];
                texts[0] = (Text)targetGraphic;
            }
            else
            {
                throw new MissingReferenceException("You must at least set one Text either in the array or as target graphic!");
            }

            foreach (var text in texts)
            {
                text.gameObject.SetActive(text == CurrentText);
            }
        }

        private void Press()
        {
            if (IsActive() && IsInteractable())
            {
                UISystemProfilerApi.AddMarker("TextToggleButton.OnClick", this);
                if (texts.Length > 1)
                {
                    int newTextIndex = (currentTextIndex + 1) % texts.Length;
                    ChangeText(newTextIndex);
                }
                this.OnClick.Invoke(CurrentText.text);
            }        
        }

        private void ChangeText(int newTextIndex)
        {
            CurrentText.gameObject.SetActive(false);
            currentTextIndex = newTextIndex;
            targetGraphic = CurrentText;
            InstantClearState();
            CurrentText.gameObject.SetActive(true);
        }

        /// <summary>
        /// Class definition for Text Toggle Button's click event. 
        /// </summary>
        [Serializable]
        public class TextToggleButtonClickedEvent : UnityEvent<string> { }
    }
}