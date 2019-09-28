using System;

namespace caEstacionamento
{
	class Program
	{
		static void Main(string[] args)
		{
			// Criando matriz de estacionamentos
			Estacionamento[] matriz = new Estacionamento[5];

			// Preenchendo a matriz
			for (int i = 0; i < matriz.Length; i++)
			{
				Console.WriteLine("Preencha os dados do carro " + (i + 1) + ":");
				matriz[i] = new Estacionamento().preencheDados();
			}

			// Imprimindo a matriz
			for (int i = 0; i < matriz.Length; i++)
			{
				Console.WriteLine();
				Console.WriteLine("-------------------------------------------------------------------------------");
				Console.WriteLine("Informações do carro " + (i + 1) + ":");
				matriz[i].imprimeDados();
				matriz[i].imprimePreco();
				Console.WriteLine("-------------------------------------------------------------------------------");
			}
			
		}
	}
}
