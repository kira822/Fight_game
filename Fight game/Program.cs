using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;


Player player= new Player();

Enemy enemyGoblin= new Enemy("Гоблин", 10);
Enemy enemySkilet = new Enemy("Скелет", 15);
Enemy enemyOrc = new Enemy("Орк", 20);
Enemy enemyDefault = new Enemy("***", 1);

Random rand = new Random();

Enemy value = new Enemy();
int Choose()
{
    int number = rand.Next(-20, 100);
    Console.WriteLine(number);
    return number;
}

value.RandomValue = Choose();

while (enemyDefault.EnemyHealth > 0 && player.Health > 0) { Game(); }

void Game()
{
    while (enemyDefault.EnemyHealth > 0 && player.Health > 0)
    {      
        Console.Write("=>");
        int a = Convert.ToInt32(Console.ReadLine());

        switch (a)
        {
            case 1:
                Fighting();
                break;

            case 2:
                Heal();
                break;

            case 3:
                Stamina();
                Damaging();
                break;
        }

        void Fighting()  
        {
            if (value.RandomValue > 30)
            {               
                enemyDefault.EnemyDamage = rand.Next(1, 4);
                enemyDefault = enemyGoblin;
            }

            else if(value.RandomValue < 30 && value.RandomValue > 0)
            {              
                enemySkilet.EnemyDamage = rand.Next(2, 5);
                enemyDefault = enemySkilet;
            }

            else if(value.RandomValue < 0)
            {   
                enemyOrc.EnemyDamage = rand.Next(3, 6);
                enemyDefault = enemyOrc;
            }

                player.Damage = rand.Next(1, 4);
                player.Health = player.Health - enemyDefault.EnemyDamage;
                enemyDefault.EnemyHealth = enemyDefault.EnemyHealth - player.Damage;
                player.Stamina -= 2;

                Console.WriteLine($"Вы бьете {enemyDefault.EnemyName} и наносите {player.Damage} урона" +
                                  $"\n{enemyDefault.EnemyName} бьет вас и наносит {enemyDefault.EnemyDamage} урона" +
                                  $"\nИгрок: {player.Health } hp, Стамина: {player.Stamina } p" +
                                  $"\n{enemyDefault.EnemyName}: {enemyDefault.EnemyHealth } hp");

                if (enemyDefault.EnemyHealth <= 0)
                {
                    Console.WriteLine("Вы победили");
                }

                else if (player.Stamina == 0)
                {
                    Console.WriteLine("У вас кончились силы");
                    Damaging();
                }

                else if (player.Health <= 0)
                {
                    Console.WriteLine("Вы проиграли");
                }          
        }

        void Damaging()
        {
            enemyDefault.EnemyDamage = rand.Next(1, 4);

            if (a == 3)
            {
                player.Health--;
                Console.WriteLine($"\nМонстр бьет вас и наносит 1 уронa" +
                                  $"\nИгрок:{player.Health} hp");
            }

           else if (player.Health <= 0)
            {
                Console.WriteLine("Вы проиграли");
            }

            else
            {
                player.Health = player.Health - enemyDefault.EnemyDamage;
                Console.WriteLine($"{enemyDefault.EnemyName} бьет вас и наносит {enemyDefault.EnemyDamage} урона" +
                                  $"\nИгрок:{player.Health} hp");
            }   
        }
       
        void Heal()
        {
           
            if (player.HealPotions == 0) Console.WriteLine("Вы потратили все зелья лечения");

            else
            {
                if (player.Health < 10 && player.HealPotions > 0)
                {
                    player.HealPotions --;
                    player.Health += 3;                
                    if (player.Health > 10) { player.Health = 10; }
                    Console.WriteLine($"Вы восстанавливаете здоровье до {player.Health} hp" +
                                      $"\nЗелий лечения осталось: {player.HealPotions}");
                }

                else Console.WriteLine("Вы полностью здоровы");
            }
        }

        void Stamina()
        {
            if(player.Stamina<10)
            {
                player.Stamina += 2;
                if (player.Stamina > 10) { player.Stamina = 10; }
                Console.WriteLine($"Вы переходите в оборону и восстанавливаете силы до {player.Stamina} очков");
            }
        }
    }
}
class Player
{
    public int Health = 10;
    public int Stamina = 10;
    public int HealPotions = 3;
    public int Damage;   
}

class Enemy
{
    public int EnemyHealth;
    public int EnemyDamage;
    public string EnemyName;
    public int RandomValue;
   
    public Enemy(string enemyName,int enemyHealth)
    {
        EnemyName = enemyName;
        EnemyHealth = enemyHealth;
    }

    public Enemy() { }
    
}


