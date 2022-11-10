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
            if(entity.GetHealth(true) >= Mathf.InverseLerp(0, entity.GetHealth(false), item.damage))
            {
                Debug.Log($"{item.damage}, {Mathf.InverseLerp(0, entity.GetHealth(false), item.damage)}");
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
