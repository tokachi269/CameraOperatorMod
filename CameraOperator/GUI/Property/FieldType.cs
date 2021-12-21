using ColossalFramework.UI;
using UnityEngine;

namespace CamOpr.GUI
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
            color = Helper.GrayScale(100);
            textColor = Helper.GrayScale(250);
            horizontalAlignment = UIHorizontalAlignment.Left;
            size = new Vector2(70, 22);
            padding = Helper.Padding(0, 6);
            relativePosition = new Vector2(0, 0);
            padding = Helper.Padding(4, 3, 3);
        }

    }
}