using System;
using System.Collections.Generic;
using System.Text;

namespace caEstacionamento
{
	class Tempo
	{
		// Atributos
		private int hora;
		private int min;
		private int seg;

		// Construtores
		public void constroeTempo()
		{
			hora = 0;
			min = 0;
			seg = 0;
		}
		public void preencheTempo()
		{
			Console.WriteLine("Digite as horas: ");
			hora = testTempo(23);
			Console.WriteLine("Digite os minutos: ");
			min = testTempo(59);
			Console.WriteLine("Digite os segundos: ");
			seg = testTempo(59);
		}
		// Testa se o tempo está entre 0 e 23 horas
		private int testTempo(int max)
		{
			int num = testInput(Console.ReadLine());
			if (num < 0 || num > max)
			{
				Console.WriteLine("O numero deve estar entre 0 e " + max + " :");
				return testTempo(max);
			}
			return num;
		}
		
		// Testa se a horas estão em números
		private int testInput(string input)
		{
			for(int i = 0; i < input.Length; i++)
			{
				if(input[i] < 47 || input[i] > 58)
				{
					Console.WriteLine("Escreva só numeros: ");
					return testInput(Console.ReadLine());
				}
			}
			if (input == "")
				return 0;
			return Convert.ToInt32(input);
		}

		// Getters
		public int getHora()
		{
			return hora;
		}
		public int getMin()
		{
			return min;
		}
		public int getSeg()
		{
			return seg;
		}

		// Setters
		private int setTempo(int max, int num, string tempo)
		{
			if (num < 0 || num > max)
			{
				Console.WriteLine("Os(as) " + tempo + " devem estar entre 0 e " + max + " :");
				return testTempo(max);
			}
			return num;
		}
		public void setHora(int novaHora)
		{
			hora = setTempo(23, novaHora, "horas");
		}
		public void setMin(int novoMin)
		{
			min = setTempo(59, novoMin, "minutos");
		}
		public void setSeg(int novoSeg)
		{
			seg = setTempo(59, novoSeg, "segundos");
		}

		// Mostra o horario no formato hh:mm:ss
		public void mostraHora()
		{
			Console.WriteLine(Convert.ToString(hora).PadLeft(2, '0') + ":" + Convert.ToString(min).PadLeft(2, '0') + ":" + Convert.ToString(seg).PadLeft(2, '0'));
		}

		// Soma os horarios
		public Tempo somaTempo(Tempo t2)
		{
			Tempo t3 = new Tempo();
			t3.setHora(somaTempoAux(23, hora, t2.getHora(), "hora", t3));
			t3.setMin(somaTempoAux(59, min, t2.getMin(), "min", t3));
			t3.setSeg(somaTempoAux(59, seg, t2.getSeg(), "seg", t3));
			return t3;
		}
		private int somaTempoAux(int max, int t1, int t2, string indicador, Tempo t3)
		{
			if((t1 + t2) <= max)
				return (t1 + t2);
			if(indicador == "hora")
				Console.WriteLine("A soma dos tempos é maior que o máximo permitido");
			if(indicador == "min")
			{
				t3.setHora(somaTempoAux(23, t3.getHora(), 1, "hora", t3));
				return somaTempoAux(max, ((t1 + t2) - 60), 0, "min", t3);
			}
			else
			{
				t3.setMin(somaTempoAux(59, t3.getMin(), 1, "min", t3));
				return somaTempoAux(max, ((t1 + t2) - 60), 0, "seg", t3);
			}
		}

		// Subtrai os horarios
		public Tempo subtraiTempo(Tempo t2)
		{
			Tempo t3 = new Tempo();
			t3.setHora(subtraiTempoAux(hora, t2.getHora(), "hora", t3));
			t3.setMin(subtraiTempoAux(min, t2.getMin(), "min", t3));
			t3.setSeg(subtraiTempoAux(seg, t2.getSeg(), "seg", t3));
			return t3;
		}
		private int subtraiTempoAux(int t1, int t2, string indicador, Tempo t3)
		{
			if ((t1 - t2) >= 0)
				return (t1 - t2);
			if (indicador == "hora")
				Console.WriteLine("O tempo 2 deve ser menor que o tempo 1");
			if (indicador == "min")
			{
				t3.setHora(subtraiTempoAux(t3.getHora(), 1, "hora", t3));
				return subtraiTempoAux(((t1 - t2) + 60), 0, "min", t3);
			}
			else
			{
				t3.setMin(subtraiTempoAux(t3.getMin(), 1, "min", t3));
				return subtraiTempoAux(((t1 - t2) + 60), 0, "seg", t3);
			}
		}
	}
}
