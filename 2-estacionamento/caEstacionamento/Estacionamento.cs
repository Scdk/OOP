using System;
using System.Collections.Generic;
using System.Text;

namespace caEstacionamento
{
	class Estacionamento
	{
		// Atributos
		private string chapa;
		private string marca;
		private Tempo entrada = new Tempo();
		private Tempo saida = new Tempo();

		// Construtor
		public Estacionamento preencheDados()
		{
			Estacionamento obj = new Estacionamento();
			Console.WriteLine("Digite a placa do carro:");
			obj.chapa = Console.ReadLine();
			Console.WriteLine("Digite a marca do carro:");
			obj.marca = Console.ReadLine();
			Console.WriteLine("Digite o horario de entrada:");
			obj.entrada.preencheTempo();
			Console.WriteLine("Digite o horario de saida:");
			obj.testSaida(obj.entrada);
			return obj;
		}

		// Testa se a saída é maior a entrada
		private void testSaida(Tempo entradaNova)
		{
			saida.preencheTempo();
			if (entradaNova.getHora() > saida.getHora())
			{
				Console.WriteLine("A hora de saida tem que ser maior a de entrada: ");
				testSaida(entradaNova);
			}
			if (entradaNova.getHora() == saida.getHora())
			{
				if (entradaNova.getMin() > saida.getMin())
				{
					Console.WriteLine("A hora de saida tem que ser maior a de entrada: ");
					testSaida(entradaNova);
				}
				if (entradaNova.getMin() == saida.getMin())
				{
					if (entradaNova.getSeg() >= saida.getSeg())
					{
						Console.WriteLine("A hora de saida tem que ser maior a de entrada: ");
						testSaida(entradaNova);
					}
				}
			}

		}

		// Imprime os dados do carro
		public void imprimeDados()
		{
			Console.WriteLine("Placa do carro: " + chapa);
			Console.WriteLine("Marca do carro: " + marca);
			Console.WriteLine("Horário de entrada: " + Convert.ToString(entrada.getHora()).PadLeft(2, '0') + ":"
				+ Convert.ToString(entrada.getMin()).PadLeft(2, '0') + ":" + Convert.ToString(entrada.getSeg()).PadLeft(2, '0'));
			Console.WriteLine("Horário de saida: " + Convert.ToString(saida.getHora()).PadLeft(2, '0') + ":"
				+ Convert.ToString(saida.getMin()).PadLeft(2, '0') + ":" + Convert.ToString(saida.getSeg()).PadLeft(2, '0'));
		}

		// Imprime o preço total a pagar
		public void imprimePreco()
		{
			double total = 0;
			total += (saida.subtraiTempo(entrada).getHora() * 7);
			total += (saida.subtraiTempo(entrada).getMin() * (7.0 / 60.0));
			total += (saida.subtraiTempo(entrada).getSeg() * ((7.0 / 60.0) / 60.0));
			Console.WriteLine("O valor total a ser pago é R$" + Math.Round(total, 2));
		}
	}
}
