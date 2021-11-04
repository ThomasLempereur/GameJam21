using System.Collections;
public interface IEnemy
{
    // Start is called before the first frame update
    void Start();

    // Update is called once per frame
    void Update();

    /*private void OnCollisionEnter2D(Collision2D collision);*/

    void EnemyDeath();
    IEnumerator WaitAndDestroy();
}
