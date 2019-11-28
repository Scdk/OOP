using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace waListaEncadeada
{
	public partial class Form1 : Form
	{
		Lista list = new Lista();
		public Form1()
		{
			InitializeComponent();
		}

		private void printlist()
		{
			if (list.isEmpthy())
			{
				tbLista.Text = "";
			}
			else
			{
				string str = "";
				NohLista temp = new NohLista();
				temp = list.getStart();
				for (int i = 1; temp != null; i++)
				{
					str += " " + Convert.ToString(temp.getInfo());
					temp = temp.getNext();
				}
				tbLista.Text = str;
			}
		}
		private void insere()
		{
			try
			{
				list.insetAtEnd(Convert.ToInt32(tbInsere.Text));
				printlist();
			}
			catch
			{
				MessageBox.Show("Digite um número inteiro");
			}
		}
		private void remove()
		{
			try
			{
				list.remove(Convert.ToInt32(tbRemove.Text));
				printlist();
			}
			catch
			{
				MessageBox.Show("Digite um número inteiro");
			}
		}

		private void btInsere_Click(object sender, EventArgs e)
		{
			insere();
		}

		private void tbInsere_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				insere();
			}
		}

		private void btRemove_Click(object sender, EventArgs e)
		{
			if (list.isEmpthy())
				MessageBox.Show("A lista está vazia");
			else
				remove();
		}

		private void tbRemove_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
				if (list.isEmpthy())
					MessageBox.Show("A lista está vazia");
				else
					remove();
		}

		private void btMaior_Click(object sender, EventArgs e)
		{
			if (list.isEmpthy())
			{
				tbMaior.Text = "";
				MessageBox.Show("A lista está vazia");
			}
			else
				tbMaior.Text = Convert.ToString(list.maior());
		}

		private void tbMaior_KeyPress(object sender, KeyPressEventArgs e)
		{
			if((Keys)e.KeyChar == Keys.Enter)
			{
				if (list.isEmpthy())
				{
					tbMaior.Text = "";
					MessageBox.Show("A lista está vazia");
				}
				else
					tbMaior.Text = Convert.ToString(list.maior());
			}
		}

		private void btMenor_Click(object sender, EventArgs e)
		{
			if (list.isEmpthy())
			{
				tbMenor.Text = "";
				MessageBox.Show("A lista está vazia");
			}
			else
				tbMenor.Text = Convert.ToString(list.menor());
		}

		private void tbMenor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Keys)e.KeyChar == Keys.Enter)
			{
				if (list.isEmpthy())
				{
					tbMenor.Text = "";
					MessageBox.Show("A lista está vazia");
				}
				else
					tbMenor.Text = Convert.ToString(list.menor());
			}
		}

		private void btImprime_Click(object sender, EventArgs e)
		{
			if (list.isEmpthy())
			{
				tbMenor.Text = "";
				MessageBox.Show("A lista está vazia");
			}
			else
				printlist();
		}
	}
}
