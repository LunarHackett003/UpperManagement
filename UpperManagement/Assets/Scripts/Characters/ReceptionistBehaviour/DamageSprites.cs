using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSprites : MonoBehaviour
{
    [SerializeField] List<DamageSprite> sprites = new List<DamageSprite>();
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] DamageableEntity entity;



    private void FixedUpdate()
    {
        foreach (var item in sprites)
        {
            //Debug.Log($"{item.damage}, {Mathf.InverseLerp(0, entity.GetHealth(false), entity.GetHealth(true))}");
            if (item.damage <= Mathf.InverseLerp(0, entity.GetHealth(false), entity.GetHealth(true)))
            {
                spriteRenderer.sprite = item.sprite;
                break;
            }
        }
    }

    [System.Serializable]
    public class DamageSprite
    {
        public Sprite sprite;
        public float damage;
    }

}
