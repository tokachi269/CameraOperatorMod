using ColossalFramework.UI;
using UnityEngine;

namespace CameraOperatorMod.GUI
{
    public class FieldType: UITextField
    {
        public FieldType()
        {
            cursorBlinkTime = 1f;
            cursorWidth = 2;
            readOnly = false;
            numericalOnly = true;
            allowFloats = true;
            builtinKeyNavigation = true;
            canFocus = true;
            selectOnFocus = true;
            submitOnFocusLost = true;
            selectionSprite = "EmptySprite";
            normalBgSprite = "TextFieldPanel";
            focusedBgSprite = "TextFieldPanel";
            clipChildren = true;
            colorizeSprites = true;
            color = Helper.RGB(50, 50, 50);
            textColor = Helper.RGB(250, 250, 250);
            horizontalAlignment = UIHorizontalAlignment.Left;
            size = new Vector2(70, 22);
            padding = Helper.Padding(0, 6);
            relativePosition = new Vector2(0, 0);
        }

    }
}