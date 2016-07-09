using UnityEngine;
using System.Collections;


//Class is used to store and pull generic values used in game
public static class ConfigurationSettings
{
    private static Vector3 _directionOneStartPoint = new Vector3(-2.02f,0f, 9.54f);
    private static Vector3 _directionTwoStartPoint;
    private static Vector3 _directionOneEndPoint = new Vector3(19f,0,10f);
    private static Vector3 _directionTwoEndPoint;
    private static Vector3 _gridSize = new Vector3(19,0,19);

    public static Vector3 DirectionOneStartPoint
    {
        get
        {
            return _directionOneStartPoint;
        }

        set
        {
            _directionOneStartPoint = value;
        }
    }

    public static Vector3 DirectionTwoStartPoint
    {
        get
        {
            return _directionTwoStartPoint;
        }

        set
        {
            _directionTwoStartPoint = value;
        }
    }

    public static Vector3 DirectionOneEndPoint
    {
        get
        {
            return _directionOneEndPoint;
        }

        set
        {
            _directionOneEndPoint = value;
        }
    }

    public static Vector3 DirectionTwoEndPoint
    {
        get
        {
            return _directionTwoEndPoint;
        }

        set
        {
            _directionTwoEndPoint = value;
        }
    }

    public static Vector3 GridSize
    {
        get
        {
            return _gridSize;
        }

        set
        {
            _gridSize = value;
        }
    }
}
