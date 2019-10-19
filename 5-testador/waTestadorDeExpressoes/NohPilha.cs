using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waTestadorDeExpressoes
{
	class NohPilha
	{
		private char info;
		private NohPilha next = null;
		public NohPilha()
		{
		}
		public NohPilha(char novoInfo)
		{
			info = novoInfo;
		}
		public NohPilha(char novoInfo, NohPilha novoNext)
		{
			info = novoInfo;
			next = novoNext;
		}
		public char getInfo()
		{
			try
			{
				return info;
			}
			catch
			{
				return 'a';
			}
		}
		public NohPilha getNext()
		{
			return next;
		}
		public void setInfo(char novoInfo)
		{
			info = novoInfo;
		}
		public void setNext(NohPilha novoNext)
		{
			next = novoNext;
		}
	}
}
