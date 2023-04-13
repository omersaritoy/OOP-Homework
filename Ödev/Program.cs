
Random rnd= new Random();
int targetx = rnd.Next(50,100);
int targety= rnd.Next(1, 50);

Game game = new Game(targetx, targety);

class Game
{
    public int x { get; set; }
    public int y { get; set; }

    public int targetX { get; set; }
    public int targetY { get; set; }
    public int Score { get ; set; } 
    public Game(int targetX,int targetY)
    {

        x = Console.WindowWidth / 2;
        y = Console.WindowHeight / 2;
        this.targetX = targetX;
        this.targetY = targetY;
        Console.SetCursorPosition(x, y);
        Console.Clear();
        Console.SetCursorPosition(x, y);
        Console.Write("##");//player(oyuncu)


        Console.SetCursorPosition(targetX, targetY);
        Console.Write("Hedef");

        Logic(targetX, targetY);
    }

    private void Logic(int targetX, int targetY)
    {
        int tempx = targetX;
        int tempy = targetY;
        bool ArriveTarget = false;
        while (!ArriveTarget)
        {


            if (Console.KeyAvailable)//control Click
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.SetCursorPosition(x, y);
                Console.Write("  ");
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    Score++;
                    x--;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    Score++;
                    x++;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Score++;
                    y--;
                }
                else
                {
                    y++;
                    Score++;
                }
                Console.SetCursorPosition(x, y);
                Console.Write("##");


            }
            if (x == targetX && y == targetY)
            {
                int select;
                ArriveTarget = true;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Clear();
                Console.WriteLine("Hedefe Ulaşıldı");
                Console.WriteLine("Total Scorunuz:" + Score);
  
               Console.WriteLine("1-Çıkış");
                Console.WriteLine("2-Yeniden oyna");
                Console.Write("Seçiminiz:");
                select = Convert.ToInt32(Console.ReadLine());
                targetX = tempx;
                targetY=tempy;  
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Çıkış yapılıyor");
                        break;
                    case 2:
                        x = Console.WindowWidth / 2;
                        y = Console.WindowHeight / 2;
                        ArriveTarget = false;
                        Console.WriteLine("Yeni oyun Açılıyor");
                        Console.Clear();
                        Console.SetCursorPosition(targetX, targetY);
                        Console.Write("Hedef");
                        Logic(targetX, targetY);
                        


                        break;
                    default:
                        Console.WriteLine("Hatlı girdiniz:");
                        break;
                }

            }

        }
    }

}
