using System.Collections;

public interface IEnemy {
    void Damage(int damage);
    void Kill();
    IEnumerator OnDamage();
}

public interface IPlayer {
    void BasicAttack();
    void MagicAttack();
}