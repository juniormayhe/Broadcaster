using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcaster
{
    public partial class Form2 : Form
    {
        Form1 f;
        int selectedMessageID;
        public Form2(Form1 form1)
        {
            f = form1;
            
            InitializeComponent();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedMessageID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            select();
            
        }

        private void select()
        {
            try {
                
                selectedMessageID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                var m = f.messages.FirstOrDefault(x => x.MessageID == selectedMessageID);
                f.i = f.messages.ToList().FindIndex(x => x.MessageID == selectedMessageID);
                f.MonthCalendar1.SetDate(m.Created);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houve um problema ao tentar selecionar o aviso:\n\n{ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                
                f.messages = f.mr.FilterByText(f.TextToFind.Trim());
                if (f.messages == null || f.messages.Count() == 0)
                {
                    MessageBox.Show("Nenhum aviso foi encontrado com o termo informado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                dataGridView1.DataSource = f.messages.Select(o => new
                { MessageID = o.MessageID, MessageTitle = o.MessageTitle, MessageBody = o.MessageBody }).ToList();

                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex) {
                MessageBox.Show($"Houve um problema ao tentar buscar avisos com o termo informado:\n\n{ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                select();
            }
        }
    }
}
