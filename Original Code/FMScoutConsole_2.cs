
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutConsole
{
    internal class Program
    {
        /* 
==== FM24 球员数据库（控制台版） ====

功能要求：
1. 添加球员（包括姓名、年龄、国籍、俱乐部、位置、能力值、身价）
2. 显示所有球员信息
3. 根据以下条件搜索球员：
   - 姓名（精确匹配）
   - 国籍
   - 俱乐部
   - 位置
4. 支持排序（按能力值或身价，升序/降序）【选做】
   所有输入需要校验（如年龄不能为负，能力值范围合理等）
5. 支持用户选择退出程序
*/
        class Players
        {
            public string name;
            public int age;
            public string nation;
            public string club;
            public string position;
            public int ability;
            public int MarketValue;

            public void show()
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine($"Name：{name}，Age：{age}，Nation：{nation}，Club：{club}");
                Console.WriteLine($"Positon：{position}，Ability：{ability}，MarketValue：€{MarketValue:N0}");
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            List<Players> PlayerInformations = new List<Players>()
            {
                new Players
                {
                    name = "Harry Kane",
                    age = 31,
                    nation = "England",
                    club = "FC Bayern Munich",
                    position = "ST",
                    ability = 90,
                    MarketValue = 100_000_000
                },
                new Players
                {
                    name = "Kylian Mbappe",
                    age = 25,
                    nation = "France",
                    club = "Real Madrid",
                    position = "LW",
                    ability = 92,
                    MarketValue = 170_000_000
                },
                new Players
                {
                    name = "Erling Haaland",
                    age = 24,
                    nation = "Norway",
                    club = "Manchester City",
                    position = "ST",
                    ability = 91,
                    MarketValue = 200_000_000
                },
                new Players
                {
                    name = "Jude Bellingham",
                    age = 21,
                    nation = "England",
                    club = "Real Madrid",
                    position = "ST",
                    ability = 91,
                    MarketValue = 200_000_000
                },
                new Players
                {
                    name = "Jude Bellingham",
                    age = 21,
                    nation = "England",
                    club = "Real Madrid",
                    position = "CM",
                    ability = 89,
                    MarketValue = 150_000_000
                },
                new Players
                {
                    name = "Florian Wirtz",
                    age = 21,
                    nation = "Germany",
                    club = "Bayer Leverkusen",
                    position = "CAM",
                    ability = 88,
                    MarketValue = 100_000_000
                },
                new Players
                {
                    name = "Alexander Isak",
                    age = 25,
                    nation = "Sweden",
                    club = "Newcastle United",
                    position = "ST",
                    ability = 85,
                    MarketValue = 75_000_000
                },
                new Players
                {
                    name = "Federico Dimarco",
                    age = 26,
                    nation = "Italy",
                    club = "Inter Milan",
                    position = "LWB",
                    ability = 84,
                    MarketValue = 50_000_000
                }
            };
            
            while(true)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Welcome to use FMScoutConsole");
                Console.WriteLine("1,Add player");
                Console.WriteLine("2,Show all the players' informations");
                Console.WriteLine("3,Search player");
                Console.WriteLine("4,Sort");
                Console.WriteLine("5,Exit");
                Console.WriteLine("---------------------------------------");
                Console.Write("Please enter the options according to your needs :");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Please finish player's informations (name,age,nation,club,position,ability,MarketValue)  :");
                    Console.WriteLine("Enter player name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter age:");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter nationality:");
                    string nation = Console.ReadLine();

                    Console.WriteLine("Enter club:");
                    string club = Console.ReadLine();

                    Console.WriteLine("Enter position:");
                    string position = Console.ReadLine();

                    Console.WriteLine("Enter ability rating:");
                    int ability = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter market value (in euros):");
                    int value = Convert.ToInt32(Console.ReadLine());

                    Players newplayer = new Players();

                    PlayerInformations.Add(new Players
                    {
                        name = name,
                        age = age,
                        nation = nation,
                        club = club,
                        position = position,
                        ability = ability,
                        MarketValue = value
                    });

                    Console.WriteLine("Player has been successfully added!");
                    Console.WriteLine("This player's information is :");
                    newplayer.show();


                }
                else if (choice == 2)
                {
                    foreach(var player in PlayerInformations)
                    {
                        player.show();
                    }
                }
                else if (choice == 3)
                {
                    while (true)
                    {
                        Console.WriteLine("1,Search by name");
                        Console.WriteLine("2,Search by nation");
                        Console.WriteLine("3,Search by club");
                        Console.WriteLine("4,Search by position");
                        Console.WriteLine("5,Search by age");
                        Console.WriteLine("6,Exit");
                        Console.Write("Please enter number:");
                        int num = int.Parse(Console.ReadLine());
                        
                        bool found = false;
                        if (num == 1)
                        {
                            Console.Write("Please enter player's name :");
                            string SearchPlayerName = Console.ReadLine();
                            foreach (var player in PlayerInformations)
                            {
                                if (player.name == SearchPlayerName)
                                {
                                    found = true;
                                    player.show();
                                }
                                
                            }
                            if (!found)
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else if (num == 2)
                        {
                            Console.Write("Please enter player's nation :");
                            string SearchPlayerNation = Console.ReadLine();
                            foreach (var player in PlayerInformations)
                            {
                                if (player.nation == SearchPlayerNation)
                                {
                                    found = true;
                                    player.show();
                                }
                                
                            }
                            if (!found)
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else if (num == 3)
                        {
                            Console.Write("Please enter player's club :");
                            string SearchPlayerClub = Console.ReadLine();
                            foreach (var player in PlayerInformations)
                            {
                                if (player.club == SearchPlayerClub)
                                {
                                    found = true;
                                    player.show();
                                }
                                
                            }
                            if (!found)
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else if (num == 4)
                        {
                            Console.Write("Please enter player's position :");
                            string SearchPlayerPositon = Console.ReadLine();
                            foreach (var player in PlayerInformations)
                            {
                                if (player.position == SearchPlayerPositon)
                                {
                                    found = true;
                                    player.show();
                                }
                                
                            }
                            if (!found)
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else if (num == 5)
                        {
                            Console.Write("Please enter player's age :");
                            int SearchPlayerAge = int.Parse(Console.ReadLine());
                            foreach (var player in PlayerInformations)
                            {
                                if (player.age == SearchPlayerAge)
                                {
                                    found = true;
                                    player.show();
                                }
                                
                            }
                            if (!found)
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else if (num == 6)
                        {
                            Console.WriteLine("Program Exit");
                            break;
                        }
                        
                    }
                   
                }
                else if (choice == 4)
                {
                    while (true)
                    {
                        Console.WriteLine("1,Sort by ability");
                        Console.WriteLine("2,Sort by market value");
                        Console.WriteLine("3,Sort by age");
                        Console.WriteLine("4,Exit");
                        Console.Write("Please enter number:");
                        int num1 = int.Parse(Console.ReadLine());
                        
                        if (num1 == 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("1,Ascending");
                                Console.WriteLine("2,Descending ");
                                Console.WriteLine("3,Exit");
                                Console.Write("Please enter a number to determine ascending or descending order:");
                                int num2 = int.Parse(Console.ReadLine());
                                
                                if (num2 == 1)
                                {
                                    var sorted = PlayerInformations.OrderBy(x => x.ability).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num2 == 2)
                                {
                                    var sorted = PlayerInformations.OrderByDescending(x => x.ability).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num2 == 3)
                                {
                                    Console.WriteLine("Program Exit");
                                    break;
                                }
                            }
                            

                        }
                        else if (num1 == 2)
                        {
                            while (true)
                            {
                                Console.WriteLine("1,Ascending");
                                Console.WriteLine("2,Descending ");
                                Console.WriteLine("3,Exit");
                                Console.Write("Please enter a number to determine ascending or descending order:");
                                int num3 = int.Parse(Console.ReadLine());

                                if (num3 == 1)
                                {
                                    var sorted = PlayerInformations.OrderBy(x => x.MarketValue).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num3 == 2)
                                {
                                    var sorted = PlayerInformations.OrderByDescending(x => x.MarketValue).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num3 == 3)
                                {
                                    Console.WriteLine("Program Exit");
                                    break;
                                }
                            }
                        }
                        else if (num1 == 3)
                        {
                            while (true)
                            {
                                Console.WriteLine("1,Ascending");
                                Console.WriteLine("2,Descending ");
                                Console.WriteLine("3,Exit");
                                Console.Write("Please enter a number to determine ascending or descending order:");
                                int num4 = int.Parse(Console.ReadLine());

                                if (num4 == 1)
                                {
                                    var sorted = PlayerInformations.OrderBy(x => x.age).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num4 == 2)
                                {
                                    var sorted = PlayerInformations.OrderByDescending(x => x.age).ToList();
                                    foreach (var player in sorted)
                                    {
                                        player.show();
                                    }
                                }
                                else if (num4 == 3)
                                {
                                    Console.WriteLine("Program Exit");
                                    break;
                                }
                            }
                        }
                        else if (num1 == 4)
                        {
                            Console.WriteLine("Program Exit");
                            break;
                        }

                    }
                    
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Program Exit");
                    break;
                }
            }
            
        }
    }
}
