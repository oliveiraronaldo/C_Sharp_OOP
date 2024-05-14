// See https://aka.ms/new-console-template for more information
using Cliente;

Console.Clear();
var cliente = new Client("Ronaldo", "Rua 2", "12654856584", 26);


Console.WriteLine(cliente.ValidaCPF());