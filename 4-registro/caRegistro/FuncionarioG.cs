using System;
using System.Collections.Generic;
using System.Text;

namespace caRegistro
{
	class FuncionarioG : FuncionarioEM
	{
		// Atributos
		protected string universidade;
		protected string curso;

		// Construtor
		public FuncionarioG(string novoNome, string novoCodigoFuncional, string novaEscola, string novaEscolaM, string novaUniversidade, string novoCurso) 
			: base(novoNome, novoCodigoFuncional, novaEscola, novaEscolaM)
		{
			universidade = novaUniversidade;
			curso = novoCurso;
		}

		// Getters
		public override string getUniversidade()
		{
			return universidade;
		}
		public override string getCurso()
		{
			return curso;
		}
		public override double getRendaTotal()
		{
			return (rendaBasica * 2);
		}
		public override string getEscolaridade()
		{
			return "graduado";
		}
	}
}
