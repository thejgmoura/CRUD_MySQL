using MySql.Data.MySqlClient;
namespace CRUD_MySQL
{
	public partial class Form1 : Form
	{
		private MySqlConnection conector;
		private string data_source = "datasource = localhost; username = root; password = 1234; database = db_cadastros";
		private int? id_selecionado = null;
		public Form1 ()
		{
			InitializeComponent ();
			listView1.View = View.Details;
			listView1.LabelEdit = true;
			listView1.AllowColumnReorder = true;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Columns.Add ("ID", 30, HorizontalAlignment.Left);
			listView1.Columns.Add ("NOME", 150, HorizontalAlignment.Left);
			listView1.Columns.Add ("TELEFONE", 150, HorizontalAlignment.Left);
			listView1.Columns.Add ("E-MAIL", 150, HorizontalAlignment.Left);
			button3.Visible = false;
			button4.Visible = false;
			carregar_cadastros ();
		}
		private void button1_Click (object sender, EventArgs e)
		{
			try
			{
				conector = new MySqlConnection (data_source);
				conector.Open ();
				MySqlCommand comando = new MySqlCommand
				{
					Connection = conector,
					CommandText = "INSERT INTO new_table (nome, telefone, email) VALUES (@nome, @telefone, @email)"
				};
				comando.Parameters.AddWithValue ("@nome", textBox1.Text);
				comando.Parameters.AddWithValue ("@telefone", textBox2.Text);
				comando.Parameters.AddWithValue ("@email", textBox3.Text);
				comando.ExecuteNonQuery ();
				MessageBox.Show ("Cadastro feito!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				carregar_cadastros ();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show ("Erro! " + ex.Number, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Erro! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				conector.Close ();
			}
			textBox1.Clear ();
			textBox2.Clear ();
			textBox3.Clear ();
		}
		private void button2_Click (object sender, EventArgs e)
		{
			try
			{
				conector = new MySqlConnection (data_source);
				conector.Open ();
				MySqlCommand comando = new MySqlCommand
				{
					Connection = conector,
					CommandText = "SELECT * FROM new_table WHERE nome LIKE @q"
				};
				comando.Parameters.AddWithValue ("@q", "%" + textBox4.Text + "%");
				MySqlDataReader reader = comando.ExecuteReader ();
				listView1.Items.Clear ();
				while (reader.Read ())
				{
					string [] row =
					{
						reader.GetInt32 (0).ToString (),
						reader.GetString (1),
						reader.GetString (2),
						reader.GetString (3),
					};
					listView1.Items.Add (new ListViewItem (row));
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show ("Erro! " + ex.Number, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Erro! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				conector.Close ();
			}
		}
		private void carregar_cadastros ()
		{
			try
			{
				conector = new MySqlConnection (data_source);
				conector.Open ();
				MySqlCommand comando = new MySqlCommand
				{
					Connection = conector,
					CommandText = "SELECT * FROM new_table"
				};
				MySqlDataReader reader = comando.ExecuteReader ();
				listView1.Items.Clear ();
				while (reader.Read ())
				{
					string [] row =
					{
						reader.GetInt32 (0).ToString (),
						reader.GetString (1),
						reader.GetString (2),
						reader.GetString (3),
					};
					listView1.Items.Add (new ListViewItem (row));
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show ("Erro! " + ex.Number, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Erro! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				conector.Close ();
			}
		}
		private void listView1_ItemSelectionChanged (object sender, ListViewItemSelectionChangedEventArgs e)
		{
			ListView.SelectedListViewItemCollection itens_selecionados = listView1.SelectedItems;
			foreach (ListViewItem item in itens_selecionados)
			{
				id_selecionado = Convert.ToInt32 (item.SubItems [0].Text);
				textBox1.Text = item.SubItems [1].Text;
				textBox2.Text = item.SubItems [2].Text;
				textBox3.Text = item.SubItems [3].Text;
				button3.Visible = true;
				button4.Visible = true;
			}
		}
		private void zerar ()
		{
			id_selecionado = null;
			textBox1.Text = String.Empty;
			textBox2.Text = "";
			textBox3.Text = "";
			textBox1.Focus ();
			button3.Visible = false;
			button4.Visible = false;
		}
		private void excluir ()
		{
			try
			{
				DialogResult conf = MessageBox.Show ("Certeza disso?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (conf == DialogResult.Yes)
				{
					conector = new MySqlConnection (data_source);
					conector.Open ();
					MySqlCommand comando = new MySqlCommand
					{
						Connection = conector,
						CommandText = "DELETE FROM new_table WHERE id = @id"
					};
					comando.Parameters.AddWithValue ("@id", id_selecionado);
					comando.ExecuteNonQuery ();
					MessageBox.Show ("Apagado!", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					carregar_cadastros ();
					zerar ();
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show ("Erro! " + ex.Number + " " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Erro! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				conector.Close ();
			}
		}
		private void button3_Click (object sender, EventArgs e)
		{
			excluir ();
		}
		private void button4_Click (object sender, EventArgs e)
		{
			try
			{
				conector = new MySqlConnection (data_source);
				conector.Open ();
				MySqlCommand comando = new MySqlCommand
				{
					Connection = conector,
					CommandText = "UPDATE new_table SET nome = @nome, telefone = @telefone, email = @email WHERE id = @id"
				};
				comando.Parameters.AddWithValue ("@nome", textBox1.Text);
				comando.Parameters.AddWithValue ("@telefone", textBox2.Text);
				comando.Parameters.AddWithValue ("@email", textBox3.Text);
				comando.Parameters.AddWithValue ("@id", id_selecionado);
				comando.ExecuteNonQuery ();
				MessageBox.Show ("Atualizado!", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				carregar_cadastros ();
				zerar ();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show ("Erro! " + ex.Number + " " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Erro! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				conector.Close ();
			}
		}
	}
}
