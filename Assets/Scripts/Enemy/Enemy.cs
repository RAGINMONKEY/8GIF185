using System.Collections;
using UnityEngine;

public class Enemy
{
    private string _color1;
    private string _color2;
    private int _life = 1;
    private enum _colors { Red, Blue };

    public Enemy(string color1, string color2 = null)
    {
        _color1 = color1;
    }

    public string[] getColors()
    {
        return new string[] { _color1, _color2 };
    }

    // Use by the enemy when he take a damage
    public bool isHit(string projectileTag)
    {
        if (_color1 != null && _color2 == null)
        {
            switch (projectileTag)
            {
                case "Red" when _color1 == _colors.Red.ToString():
                    _life--;
                    break;
                case "Blue" when _color1 == _colors.Blue.ToString():
                    _life--;
                    break;
            }
        }
        else if (_color1 != null && _color2 != null)
        {
            switch (projectileTag)
            {
                case "Red Blue" when _color1 == _colors.Red.ToString() && _color2 == _colors.Blue.ToString():
                    _life--;
                    break;
                case "Blue Red" when _color1 == _colors.Blue.ToString() && _color2 == _colors.Red.ToString():
                    _life--;
                    break;
            }
        }
        return _life < 0;
    }
}