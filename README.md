# *Whisker’s Rescue*

Проектот е направен во Unity од: Стефани Стојческа 243175 и Виктор Ефат 243136.

## 1. Објаснување на проблемот

Проектот *Whisker’s Rescue* претставува 2D platformer игра развиена во Unity. Играта има за цел да му овозможи на играчот да контролира маче кое се движи низ различни нивоа, скока по платформи и избегнува пречки, со крајна цел да напредува низ играта.

Приказната е едноставна, но мотивирачка. Одамна, еден човек фрлил топка во небото и таа никогаш не се вратила. Кучето Papuchino тргнало по топката и завршило заглавено високо на небото. Малата мачка Whiskers тргнува во потрага по него, убедена дека сè уште го чека и дека може да го врати дома.

Играта се состои од повеќе динамички нивоа кои постепено стануваат потешки. Првото ниво започнува на земја со тревни платформи, 

<img width="1490" height="832" alt="start" src="https://github.com/user-attachments/assets/1317db6a-0275-4f59-a8b9-16144b1f915b" />

потоа играчот се движи низ гранки од дрвја,

<img width="1485" height="826" alt="secondImage" src="https://github.com/user-attachments/assets/04f58792-e11a-45b6-b880-9aa745e234e7" />

па се искачува на бели облаци

<img width="1489" height="833" alt="thirdImage" src="https://github.com/user-attachments/assets/8fde56c2-7e63-4abf-aab7-38fde63af43a" />

и на крајот, на розови облаци, го наоѓа кучето Papuchino.

<img width="1488" height="831" alt="final" src="https://github.com/user-attachments/assets/c5f2eb94-1d49-4de3-a90d-75f62417196e" />

## 2. Опис на решението

Решението е реализирано со користење на Unity и C#. Главниот лик (Whiskers) користи компоненти како Rigidbody2D за физика, BoxCollider2D за судири и Animator за анимации. LayerMask се користи за да се разликуваат земја и ѕидови.

Движењето и интеракцијата со околината се контролирани преку посебна класа која ја имплементира логиката на играчот.

## 3. Опис на класа – PlayerMovement

Класата `PlayerMovement` е одговорна за движењето, скокањето и интеракцијата со околината. Во продолжение е прикажан дел од кодот кој ги реализира овие механики:

```csharp
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private BoxCollider2D boxColider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        boxColider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocityY);

        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(2,2,2);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 2);

        if (Input.GetKey(KeyCode.Space) && isGrounded() && !onWall())
        {
            jump();
        }

        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", isGrounded());
    }

    private void jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxColider.bounds.center,
            boxColider.bounds.size,
            0,
            Vector2.down,
            0.1f,
            groundLayer
        );
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxColider.bounds.center,
            boxColider.bounds.size,
            0,
            new Vector2(transform.localScale.x, 0),
            0.1f,
            wallLayer
        );
        return raycastHit.collider != null;
    }
}
```

Овој код ја реализира основната механика на играта. Во методот `Update()` се чита корисничкиот input и се поставува хоризонталното движење. Играчот се движи лево и десно со менување на velocity на Rigidbody2D.

Скокањето е имплементирано преку функцијата `jump()`, која ја поставува вертикалната брзина на играчот. Сепак, скокот е дозволен само ако играчот е на земја и не е до ѕид, што се проверува со `isGrounded()` и `onWall()`.

Функцијата `isGrounded()` користи BoxCast за да провери дали постои објект под играчот. Ова спречува играчот да скока во воздух. Слично, `onWall()` проверува дали играчот допира ѕид, со што се ограничуваат одредени движења.

Дополнително, Animator параметрите се ажурираат во зависност од движењето, што овозможува визуелно прикажување на состојбите како трчање и стоење на земја.

## 4. Користење на апликацијата

Играта се игра преку тастатура. Играчот користи A и D или стрелките за движење, додека Space се користи за скокање.

Играчот започнува на земја и треба да се движи нагоре низ нивото, скокајќи по платформи и избегнувајќи опасности како боцки. Со напредување низ играта, околината се менува од шума во гранки и на крај во небо со облаци.

## 5. Користење на генеративна вештачка интелигенција

Во текот на изработката беше користена генеративна вештачка интелигенција, конкретно ChatGPT. Таа беше користена за објаснување на Unity концепти, помош при debugging и подобрување на кодот.

## Заклучок

*Whisker’s Rescue* претставува функционална 2D platformer игра која комбинира движење, скокање и избегнување пречки со едноставна приказна.

