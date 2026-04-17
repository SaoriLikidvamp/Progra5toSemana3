using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoGranja
{
    internal class Menu
    {
        public void Execute()
        {
            Farm farm = new Farm();
            int day = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- DIA  " + day + " -----\n");
                Console.WriteLine("Dinero: $" + farm.Money);
                Console.WriteLine("Espacio: " + (farm.Plants.Count + farm.Animals.Count) + "/" + farm.Space);

                Console.WriteLine("\n1. Comprar semilla");
                Console.WriteLine("2. Plantar");
                Console.WriteLine("3. Cosechar");
                Console.WriteLine("4. Comprar animal");
                Console.WriteLine("5. Recolectar producto animal");
                Console.WriteLine("6. Ampliar espacio ( $50 )");
                Console.WriteLine("7. Pasar día");

                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Console.WriteLine("\n --- Semillitas ---");
                    Console.WriteLine("\n1. Trigo ( $10 )");
                    Console.WriteLine("2. Zanahoria ( $15 )");
                    Console.WriteLine("3. Sandía ( $25 )");

                    int seed = int.Parse(Console.ReadLine());

                    if (seed == 1 && farm.Money >= 10)
                    {
                        farm.Money -= 10;
                        farm.Seeds.Add("Trigo");
                        Console.WriteLine(" - -> Compraste 1 semilla de Trigo");
                    }
                    else if (seed == 2 && farm.Money >= 15)
                    {
                        farm.Money -= 15;
                        farm.Seeds.Add("Zanahoria");
                        Console.WriteLine(" - -> Compraste 1 semilla de Zanahoria");
                    }
                    else if (seed == 3 && farm.Money >= 25)
                    {
                        farm.Money -= 25;
                        farm.Seeds.Add("Sandía");
                        Console.WriteLine(" - -> Compraste 1 semilla de Sandía");
                    }
                    else
                    {
                        Console.WriteLine(" - -> Ya no puedes comprar, falta dinero");
                    }
                }

                else if (op == 2)
                {
                    if (farm.Seeds.Count == 0)
                    {
                        Console.WriteLine(" - -> No tienes semillas para plantar uu");
                    }
                    else if (farm.Plants.Count + farm.Animals.Count >= farm.Space)
                    {
                        Console.WriteLine(" - -> No hay espacio para plantar uu");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Semillas disponibles --- \n");

                        for (int i = 0; i < farm.Seeds.Count; i++)
                        {
                            Console.WriteLine(i + ". " + farm.Seeds[i]);
                        }

                        int choose;
                        bool valido = int.TryParse(Console.ReadLine(), out choose);

                        if (valido && choose >= 0 && choose < farm.Seeds.Count)
                        {
                            string seedName = farm.Seeds[choose];

                            if (seedName == "Trigo")
                                farm.Plants.Add(new Plant("Trigo", 2, 25));

                            else if (seedName == "Zanahoria")
                                farm.Plants.Add(new Plant("Zanahoria", 3, 35));

                            else if (seedName == "Sandía")
                                farm.Plants.Add(new Plant("Sandía", 4, 60));

                            farm.Seeds.RemoveAt(choose);

                            Console.WriteLine(" - -> Plantaste " + seedName);
                        }
                        else
                        {
                            Console.WriteLine(" - -> Semilla no válida");
                        }
                    }
                }

                else if (op == 3)
                {
                    if (farm.Plants.Count > 0)
                    {
                        Console.WriteLine("\n --- Cultivos ---");

                        for (int i = 0; i < farm.Plants.Count; i++)
                        {
                            if (farm.Plants[i].DaysLeft > 0)
                            {
                                Console.WriteLine(i+". "+farm.Plants[i].Name+" : listo en " +farm.Plants[i].DaysLeft+ " turnos");
                            }
                            else
                            {
                                Console.WriteLine(i+". "+farm.Plants[i].Name+" : listo para cosechar");
                            }
                        }

                        Console.WriteLine("\n Elegir planta:");
                         
                        int pick = int.Parse(Console.ReadLine());
 
                        if (pick >= 0 && pick < farm.Plants.Count)
                        {
                            if (farm.Plants[pick].DaysLeft <= 0)
                            {
                                Console.WriteLine(" - -> Cosechaste " + farm.Plants[pick].Name);

                                farm.Money += farm.Plants[pick].SellValue;
                                Console.WriteLine(" Vendiste el producto en $ " + farm.Plants[pick].SellValue);

                                farm.Plants.RemoveAt(pick);
                            }
                        else
                        {
                            Console.WriteLine(" - -> Aún no está lista para cosechar uu");
                        }
                         }
                         else
                         {
                            Console.WriteLine(" - -> Planta no válida");
                         }
 
                    }
                    else
                    {
                        Console.WriteLine(" - -> No tienes plantas uu");
                    }
                }

                else if (op == 4)
                {
                    Console.WriteLine("\n --- Animalitos ---");
                    Console.WriteLine("\n1. Gallina ( $30 )");
                    Console.WriteLine("2. Conejo ( $40 )");
                    Console.WriteLine("3. Vaca ( $60 )");

                    int pet = int.Parse(Console.ReadLine());

                    if (farm.Plants.Count + farm.Animals.Count < farm.Space)
                    {
                        if (pet == 1 && farm.Money >= 30)
                        {
                            farm.Money -= 30;
                            farm.Animals.Add(new Animal("Gallina", 15, 2));
                            Console.WriteLine(" - -> Compraste 1 gallina");
                        }
                        else if (pet == 2 && farm.Money >= 40)
                        {
                            farm.Money -= 40;
                            farm.Animals.Add(new Animal("Conejo", 20, 3));
                            Console.WriteLine(" - -> Compraste 1 conejo");
                        }
                        else if (pet == 3 && farm.Money >= 60)
                        {
                            farm.Money -= 60;
                            farm.Animals.Add(new Animal("Vaca", 35, 3));
                            Console.WriteLine(" - -> Compraste 1 vaca");
                        }
                        else
                        {
                            Console.WriteLine(" - -> Ya no puedes comprar falta dinero");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" - -> Ya no puedes comprar falta espacio");
                    }
                }

                else if (op == 5)
                {
                    if (farm.Animals.Count > 0)
                    {
                        Console.WriteLine("\n --- Productos ---");
                        for (int i = 0; i < farm.Animals.Count; i++)
                        {
                            
                            if (farm.Animals[i].DaysLeft > 0)
                            {
                                Console.WriteLine(i + ". " + farm.Animals[i].Name + " : producto disponible en " + farm.Animals[i].DaysLeft + " turnos");
                            }
                            else
                            {
                                Console.WriteLine(i + ". "  + farm.Animals[i].Name + ": producto listo para recolectar");
                            }
                        }

                        Console.WriteLine("\n Elegir animal:\n");

                        int pick = int.Parse(Console.ReadLine());

                        if (pick >= 0 && pick < farm.Animals.Count)
                        {
                            if (farm.Animals[pick].DaysLeft <= 0)
                            {
                                Console.WriteLine("  - -> Recolectaste producto de " + farm.Animals[pick].Name);

                                farm.Money += farm.Animals[pick].ProductValue;
                                Console.WriteLine(" Ganaste $" + farm.Animals[pick].ProductValue);

                                farm.Animals[pick].DaysLeft = farm.Animals[pick].MaxDays;
                            }
                            else
                            {

                                Console.WriteLine("\n  - -> Aún no está listo para recolectar");
                            }
                        }
                        else
                        {
                            Console.WriteLine("  - -> Animal no válido");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  - -> No tienes animales uu");
                    }
                }

                else if (op == 6)
                {
                    if (farm.Money >= 50)
                    {
                        farm.Money -= 50;
                        farm.Space += 1;
                        Console.WriteLine("\n - -> Ampliación comprada!!! :D ");
                    }
                }

                else if (op == 7)
                {
                    day++;

                    for (int i = 0; i < farm.Plants.Count; i++)
                    {
                        if (farm.Plants[i].DaysLeft > 0)
                        {
                            farm.Plants[i].DaysLeft--;
                        }
                    }

                    for (int i = 0; i < farm.Animals.Count; i++)
                    {
                        if (farm.Animals[i].DaysLeft > 0)
                        {
                            farm.Animals[i].DaysLeft--;
                        }
                    }

                    Console.WriteLine(" - -> Pasó un día UwU");
                }

                Console.WriteLine("\nPresiona una tecla para continuar..");
                Console.ReadKey();
            }
        }
    }
}