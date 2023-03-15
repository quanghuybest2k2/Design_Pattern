using System;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;

// System.Console.WriteLine("Cách pha chế");
CaffeineBeverage tea = new Tea();
tea.PrepareRecipe("Trà");

CaffeineBeverage coffee = new Coffee();
coffee.PrepareRecipe("Cà phê");
