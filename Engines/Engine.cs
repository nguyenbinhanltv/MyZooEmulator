using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyZooEmulator.Animals;
using MyZooEmulator.Repo;
using MyZooEmulator.Engines;

namespace MyZooEmulator.Engines
{
    class Engine
    {
        private ZooRepo zoo;
        public Engine(ZooRepo zoo)
        {
            this.zoo = zoo;
        }

        public void Run()
        {
            bool allAnimalsDead = false;    // Flag to display message
            int userInput = 0;              // User input command

            do
            {
                // Check if any animal alive
                var animals = zoo.GetAnimalList();
                if (animals.ToArray().Length > 0)
                {
                    var deadAnimals = animals.Where(i => i.Status.Equals(AnimalStatus.Dead));
                    if (animals.ToArray().Length == deadAnimals.ToArray().Length)
                    {
                        allAnimalsDead = true;
                        break;
                    }
                }

                // Print header
                Renderer.PrintHeader();

                // Print menu
                userInput = Renderer.DisplayMenu("Chức năng:", new List<string>
                                                        {
                                                            "1. Thêm sinh vật",
                                                            "2. Cho sinh vật ăn",
                                                            "3. Chữa bệnh cho sinh vật",
                                                            "4. Xóa sổ sinh vật",
                                                            "5. Thông tin các sinh vật",
                                                            "6. Out"
                                                        });


                // Exit command
                if (userInput == 6) break;

                try
                {
                    // Print header
                    Renderer.PrintHeader();

                    switch (userInput)
                    {
                        case 1:

                            // Print menu
                            userInput = Renderer.DisplayMenu("Chọn loại sinh vật:", new List<string>
                                                                {
                                                                    "1. Lion",
                                                                    "2. Tiger",
                                                                    "3. Elephant",
                                                                    "4. Bear",
                                                                    "5. Wolf",
                                                                    "6. Fox",
                                                                    "Ấn bất kì để thoát."
                                                                });

                            // Print header
                            Renderer.PrintHeader();

                            switch (userInput)
                            {
                                case 1:
                                    Console.WriteLine($"Lion đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Lion);
                                    break;
                                case 2:
                                    Console.WriteLine($"Tiger đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Tiger);
                                    break;
                                case 3:
                                    Console.WriteLine($"Elephant đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Elephant);
                                    break;
                                case 4:
                                    Console.WriteLine($"Bear đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Bear);
                                    break;
                                case 5:
                                    Console.WriteLine($"Wolf đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Wolf);
                                    break;
                                case 6:
                                    Console.WriteLine($"Fox đã được thêm vào sở thú:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Fox);
                                    break;
                                default:
                                    break;
                            }

                            userInput = 0;
                            break;

                        case 2:
                            Console.WriteLine($"Tên sinh vật cho ăn:");
                            var feedAnimal = zoo.GetAnimalByName(Console.ReadLine());
                            feedAnimal.Feed();
                            break;
                        case 3:
                            Console.WriteLine($"Tên sinh vật cần chữa:");
                            var cureAnimal = zoo.GetAnimalByName(Console.ReadLine());
                            cureAnimal.Cure();
                            break;
                        case 4:
                            Console.WriteLine($"Tên sinh vật cần xóa:");
                            zoo.DeleteAnimal(Console.ReadLine());
                            break;
                        case 5:

                            // Print menu
                            userInput = Renderer.DisplayMenu("Show:", new List<string>
                                                            {
                                                                "1. Thông tin xếp theo kiểu loài",
                                                                "2. Thông tin xếp theo trạng thái",
                                                                "3. Thông tin all Tigers bị bệnh",
                                                                "4. Thông tin Elephant theo tên",
                                                                "5. Thông tin theo loài không xác định",
                                                                "6. Sức khỏe của sinh vật theo loài",
                                                                "7. Số lượng sinh vật chết mỗi loài",
                                                                "8. Wolfs và bears có health > 3",
                                                                "9. Các sinh vật có min và max sức khỏe",
                                                                "10. Sức khỏe trung bình của các động vật chưa hẹo",
                                                                "Ấn bất kì để thoát."
                                                            });

                            // Print header
                            Renderer.PrintHeader();

                            switch (userInput)
                            {
                                case 1:

                                    Console.WriteLine($"Nhóm sinh vật theo loài:");
                                    zoo.GetAnimalsGroupedByType().ToList()
                                        .ForEach(g =>
                                        {
                                            Console.WriteLine($"Nhóm {g.Key}");
                                            g.ToList().ForEach(i => Console.WriteLine(i));
                                        });

                                    Console.ReadKey();
                                    break;

                                case 2:

                                    // Print menu
                                    userInput = Renderer.DisplayMenu("Chọn trạng thái:", new List<string>
                                                                {
                                                                    "1. Full",
                                                                    "2. Empty",
                                                                    "3. Sick",
                                                                    "4. Dead",
                                                                    "Ấn bất kì để thoát."
                                                                });

                                    // Print header
                                    Renderer.PrintHeader();

                                    var status = new AnimalStatus();

                                    switch (userInput)
                                    {
                                        case 1:
                                            status = AnimalStatus.Full;
                                            break;
                                        case 2:
                                            status = AnimalStatus.Empty;
                                            break;
                                        case 3:
                                            status = AnimalStatus.Sick;
                                            break;
                                        case 4:
                                            status = AnimalStatus.Dead;
                                            break;
                                        default:
                                            break;
                                    }

                                    Console.WriteLine($"Sinh vật có trạng thái đã chọn:");

                                    zoo.GetAnimalsByStatus(status).ToList()
                                        .ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 3:

                                    Console.WriteLine($"Thông tin all Tigers bị bệnh:");

                                    zoo.GetSickTigers().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 4:

                                    Console.WriteLine($"Thông tin Elephant theo tên:");

                                    Console.WriteLine(zoo.GetElephantByName(Console.ReadLine()));

                                    Console.ReadKey();
                                    break;

                                case 5:

                                    Console.WriteLine($"Thông tin theo loài không xác định:");

                                    zoo.GetEmptyAnimalsNames().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 6:

                                    Console.WriteLine($"Sức khỏe của sinh vật theo loài:");

                                    zoo.GetMoreHealthyAnimalsEachType().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 7:

                                    Console.WriteLine($"Số lượng sinh vật chết mỗi loài:");

                                    zoo.GetDeadAnimalsAmountEachType().ToList().ForEach(i => Console.WriteLine($"{i.Key}: {i.Value}"));

                                    Console.ReadKey();
                                    break;

                                case 8:

                                    Console.WriteLine($"Wolfs và bears có health > 3:");

                                    zoo.GetWolfsAndBearsHealthGt3().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 9:

                                    Console.WriteLine($"Các sinh vật có min và max sức khỏe:");

                                    zoo.GetAnimalsMinMaxHealth().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 10:

                                    Console.WriteLine($"Sức khỏe trung bình của các động vật chưa hẹo:");

                                    Console.WriteLine(zoo.GetAnimalsAvgHealth());

                                    Console.ReadKey();
                                    break;
                                default:
                                    break;
                            }

                            userInput = 0;
                            break;

                        default:
                            break;

                    }

                }
                catch (InvalidOperationException)
                {
                    Renderer.PrintMessage("Sinh vật bạn chọn không có");
                }


            }
            while (true);

            // Show message if all animals are dead
            if (allAnimalsDead)
            {
                Console.Clear();
                Console.WriteLine("Sở thú của bạn đã bị hủy diệt.");
                Console.ReadKey();
            }
        }
    }
}
