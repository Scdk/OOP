using System;

namespace caRegistro
{
	class Program
	{
		static void Main(string[] args)
		{
			// Atributos
			double custo = 0.0;
			double custoTotal = 0.0;
			Funcionario[] f = new Funcionario[10];
			f[0] = new FuncionarioB("Jonathan", "12133");
			f[1] = new FuncionarioEB("Joseph", "11211", "Chapeuzinho");
			f[2] = new FuncionarioEM("Jotaro", "11421", "Chapeuzinho", "Polivalente");
			f[3] = new FuncionarioG("Josuke", "11581", "Chapeuzinho", "Polivalente", "UFU", "Eng.Eletrica");
			f[4] = new FuncionarioB("Giorno", "11444");
			f[5] = new FuncionarioB("Jolyne", "11654");
			f[6] = new FuncionarioG("Johnny", "17775", "Dona Iaia", "Dona Iaia", "USP", "Jornalismo");
			f[7] = new FuncionarioEB("Josefume", "18854", "Nacional");
			f[8] = new FuncionarioEM("Jose", "12214", "Objetivo", "Objetivo");
			f[9] = new FuncionarioEM("João", "12364", "Polivalente", "Polivalente");

			// Relatório
			Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
			Console.WriteLine("Relatório dos custos com funcionários por nivel de escolaridade:");
			Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
			Console.WriteLine("Funcionários sem escolaridade:");
			Console.WriteLine("-----------------------------------------------------------------------------");
			for (int i = 0; i < 10; i++)
			{
				if (f[i].getEscolaridade() == "nenhuma")
				{
					Console.WriteLine("Nome: " + f[i].getNome() + "\nCódigo Funcional: " + f[i].getCodigoFuncional() +
						"\nCusto com o funcionário: " + f[i].getRendaTotal() + "\n");
					custo += f[i].getRendaTotal();
				}
			}
			Console.WriteLine("Custo com funcionários sem escolaridade: " + custo);
			custoTotal += custo;
			custo = 0.0;
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("Funcionários que concluiram o ensino básico: ");
			Console.WriteLine("-----------------------------------------------------------------------------");
			for (int i = 0; i < 10; i++)
			{
				if (f[i].getEscolaridade() == "basico")
				{
					Console.WriteLine("Nome: " + f[i].getNome() + "\nCódigo Funcional: " + f[i].getCodigoFuncional() +
						"\nEscola onde concluiu ensino básico: " + f[i].getEscolaB() +
						"\nCusto com o funcionário: " + f[i].getRendaTotal() + "\n");
					custo += f[i].getRendaTotal();
				}
			}
			Console.WriteLine("Custo com funcionários que concluiram o ensino básico: " + custo);
			custoTotal += custo;
			custo = 0.0;
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("Funcionários que concluiram o ensino médio: ");
			Console.WriteLine("-----------------------------------------------------------------------------");
			for (int i = 0; i < 10; i++)
			{
				if (f[i].getEscolaridade() == "medio")
				{
					Console.WriteLine("Nome: " + f[i].getNome() + "\nCódigo Funcional: " + f[i].getCodigoFuncional() +
						"\nEscola onde concluiu ensino básico: " + f[i].getEscolaB() + "\nEscola onde concluiu ensino medio: " + f[i].getEscolaM() +
						"\nCusto com o funcionário: " + f[i].getRendaTotal() + "\n");
					custo += f[i].getRendaTotal();
				}
			}
			Console.WriteLine("Custo com funcionários que concluiram o ensino médio: " + custo);
			custoTotal += custo;
			custo = 0.0;
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("Funcionários graduado(s): ");
			Console.WriteLine("-----------------------------------------------------------------------------");
			for (int i = 0; i < 10; i++)
			{
				if (f[i].getEscolaridade() == "graduado")
				{
					Console.WriteLine("Nome: " + f[i].getNome() + "\nCódigo Funcional: " + f[i].getCodigoFuncional() +
						"\nEscola onde concluiu ensino básico: " + f[i].getEscolaB() + "\nEscola onde concluiu ensino medio: " + f[i].getEscolaM() +
						"\nUniversidade: " + f[i].getUniversidade() + "\nCurso: " + f[i].getCurso() +
						"\nCusto com o funcionário: " + f[i].getRendaTotal() + "\n");
					custo += f[i].getRendaTotal();
				}
			}
			Console.WriteLine("Custo com funcionários graduados: " + custo);
			custoTotal += custo;
			custo = 0.0;
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
			Console.WriteLine("Custo total com funcionários: " + custoTotal);
			Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
		}
	}
}
