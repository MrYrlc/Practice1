using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
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

            //打印出球员信息的函数
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
                string input = Console.ReadLine();
                int num_1;
                if (int.TryParse(input,out num_1 )&& num_1 >0 && num_1 <6)
                {
                    if(num_1 == 1)
                    {
                        int marketvalue;
                        int age;
                        int ability;
                        Console.WriteLine("Please finish player's informations (name,age,nation,club,position,ability,MarketValue)  :");
                        Console.Write("Enter player name:");
                        string name = Console.ReadLine();

                        while (true)
                        {
                            Console.Write("Enter age:");
                            string input_1 = Console.ReadLine();
                            if (int.TryParse(input_1, out age) && age > 0 && age < 60)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input,please enter again.");
                            }
                        }
                        

                        Console.Write("Enter nationality:");
                        string nation = Console.ReadLine();

                        Console.Write("Enter club:");
                        string club = Console.ReadLine();

                        Console.Write("Enter position:");
                        string position = Console.ReadLine();

                        while (true)
                        {
                            Console.Write("Enter ability rating:");
                            string input_2 = Console.ReadLine();
                            if (int.TryParse(input_2, out ability) && ability > 0 && ability < 100)
                            {
                                break;
                             }
                            else
                            {
                                Console.WriteLine("Invalid input,please enter again.");
                            }
                        }
                        

                        while (true)
                        {
                            Console.Write("Enter market value (in euros):");
                            string input_3 = Console.ReadLine();
                            if (int.TryParse(input_3, out marketvalue) && marketvalue > 0 )
                            {
                                break;
                             }
                            else
                            {
                                Console.WriteLine("Invalid input,please enter again.");
                            }
                        }

                        Players newplayer = new Players
                        {
                            name = name,
                            age = age,
                            nation = nation,
                            club = club,
                            position = position,
                            ability = ability,
                            MarketValue = marketvalue
                        };
                        PlayerInformations.Add(newplayer);

                        Console.WriteLine("Player has been successfully added!");
                        Console.WriteLine("This player's information is :");
                        newplayer.show();
                    }

                    else if (num_1 == 2)
                    {
                        foreach (var player in PlayerInformations)
                        {
                            player.show();
                        }
                    }
                    else if (num_1 == 3)
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
                                int SearchPlayerAge;
                                while (true)
                                {
                                    Console.Write("Please enter player's age :");
                                    string input_4 = Console.ReadLine();
                                    if (int.TryParse(input_4, out SearchPlayerAge) && SearchPlayerAge > 0 && SearchPlayerAge < 60)
                                    {
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
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input,please enter again.");
                                    }
                                }

                                
                            }
                            else if (num == 6)
                            {
                                Console.WriteLine("Program Exit");
                                break;
                            }

                        }

                    }
                    else if (num_1 == 4)
                    {
                        int input_4, input_5, input_6;
                        while (true)
                        {
                            Console.WriteLine("1,Sort by ability");
                            Console.WriteLine("2,Sort by market value");
                            Console.WriteLine("3,Sort by age");
                            Console.WriteLine("4,Exit");
                            Console.Write("Please enter number:");
                            string num1 = Console.ReadLine();
                            if (int.TryParse(num1, out input_4) && input_4 > 0 && input_4 < 5)
                            {
                                if (input_4 == 1)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("1,Ascending");
                                        Console.WriteLine("2,Descending ");
                                        Console.WriteLine("3,Exit");
                                        Console.Write("Please enter a number to determine ascending or descending order:");
                                        string num2 = Console.ReadLine();
                                        if (int.TryParse(num2, out input_5) && input_5 > 0 && input_5 < 4)
                                        {
                                            if (input_5 == 1)
                                            {
                                                var sorted = PlayerInformations.OrderBy(x => x.ability).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_5 == 2)
                                            {
                                                var sorted = PlayerInformations.OrderByDescending(x => x.ability).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_5 == 3)
                                            {
                                                Console.WriteLine("Program Exit");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input,please enter again.");
                                        }
                                    }
                                }




                                else if (input_4 == 2)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("1,Ascending");
                                        Console.WriteLine("2,Descending ");
                                        Console.WriteLine("3,Exit");
                                        Console.Write("Please enter a number to determine ascending or descending order:");
                                        string num3 = Console.ReadLine();
                                        if (int.TryParse(num3, out input_5) && input_5 > 0 && input_5 < 4)
                                        {
                                            if (input_5 == 1)
                                            {
                                                var sorted = PlayerInformations.OrderBy(x => x.MarketValue).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_5 == 2)
                                            {
                                                var sorted = PlayerInformations.OrderByDescending(x => x.MarketValue).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_5 == 3)
                                            {
                                                Console.WriteLine("Program Exit");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input,please enter again.");
                                        }



                                    }
                                }
                                else if (input_4 == 3)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("1,Ascending");
                                        Console.WriteLine("2,Descending ");
                                        Console.WriteLine("3,Exit");
                                        Console.Write("Please enter a number to determine ascending or descending order:");
                                        string num4 = Console.ReadLine();
                                        if (int.TryParse(num4, out input_6) && input_6 > 0 && input_6 < 4)
                                        {
                                            if (input_6 == 1)
                                            {
                                                var sorted = PlayerInformations.OrderBy(x => x.age).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_6 == 2)
                                            {
                                                var sorted = PlayerInformations.OrderByDescending(x => x.age).ToList();
                                                foreach (var player in sorted)
                                                {
                                                    player.show();
                                                }
                                            }
                                            else if (input_6 == 3)
                                            {
                                                Console.WriteLine("Program Exit");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input,please enter again.");
                                        }


                                    }
                                }
                                else if (input_4 == 4)
                                {
                                    Console.WriteLine("Program Exit");
                                    break;
                                }



                            }

                        }

                    }
                    


                    else if (num_1 == 5)
                    {
                        Console.WriteLine("Program Exit");
                        break;
                    }



                }
                else
                {
                    Console.WriteLine("Invalid input,please enter again.");
                }

                
            }
            
        }
    }
}
