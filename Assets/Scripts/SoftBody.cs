using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{

    #region Constants
    private const float splineOffset = 0.5f;
    #endregion
    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;
    #endregion

    #region MonoBehaviour CallBacks

    private void Awake()
    {
        UpdateVerticies();
    }
    private void FixedUpdate()
    {
        UpdateVerticies();
    }
    #endregion

    #region PrivateMethods
    private void UpdateVerticies()
    {
        for (int i = 0; i < points.Length -1; i++)
        {
            Vector2 _vertex = points[i].localPosition;

            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;

            float _ColliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;

            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _ColliderRadius));
            }
            catch (System.Exception)
            {
                Debug.Log("Spline Points are too close to each other.. recalculate");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_ColliderRadius + splineOffset)));

            }

            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);

            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);

            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetLeftTangent(i, _newLt);

        }
    }
    #endregion
}