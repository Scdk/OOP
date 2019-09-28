using System;
using System.Collections.Generic;
using System.Text;

namespace caRegistro
{
	class FuncionarioEM : FuncionarioEB
	{
		// Atributo
		protected string escolaM;

		// Construtor
		public FuncionarioEM(string novoNome, string novoCodigoFuncional, string novaEscola, string novaEscolaM) : base(novoNome, novoCodigoFuncional, novaEscola)
		{
			escolaM = novaEscolaM;
		}

		// Getters
		public override string getEscolaM()
		{
			return escolaM;
		}
		public override double getRendaTotal()
		{
			return (rendaBasica + (rendaBasica * (50.0 / 100.0)));
		}
		public override string getEscolaridade()
		{
			return "medio";
		}
	}
}
