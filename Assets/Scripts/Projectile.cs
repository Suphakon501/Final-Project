using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Projectile : MonoBehaviour
{
    public Rigidbody2D rb; //����Ѻ���仡�˹����������١����ع
    public float speed; //�������ǡ���ع
    public float lifetime; //����ع�����躹�͹ҹ���˹
    protected Transform shooterTransform; //���˹觤��ԧ
    protected string targetTag;
    [SerializeField] int damage;
    protected Transform targetTransform;
    public virtual void SetShooter(Transform shooter)
    {
        shooterTransform = shooter;
        SetTargetTag();
    }
    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);

    }
    protected virtual void Start()
    {
        StartCoroutine(DestroyAfterTime());
        SetDirection();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
        }

    }
    public void SetTargetTag()
    {
        if (shooterTransform.CompareTag("Player"))
        {
            targetTag = "Enemy";
        }
        else if (shooterTransform.CompareTag("Enemy"))
        {
            targetTag = "Player";
        }
    }
    protected abstract void SetDirection();
}
