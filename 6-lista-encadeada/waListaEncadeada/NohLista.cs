using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waListaEncadeada
{
	class NohLista
	{
		NohLista previous;
		NohLista next;
		int info;
		public NohLista()
		{
			previous = null;
			next = null;
			info = 0;
		}
		public NohLista(int value)
		{
			previous = null;
			next = null;
			info = value;
		}
		public NohLista getPrevious()
		{
			return previous;
		}
		public NohLista getNext()
		{
			return next;
		}
		public int getInfo()
		{
			return info;
		}
		public void setPrevious(NohLista newPrevious)
		{
			previous = newPrevious;
		}
		public void setNext(NohLista newNext)
		{
			next = newNext;
		}
		public void setInfo(int newInfo)
		{
			info = newInfo;
		}
	}
}
