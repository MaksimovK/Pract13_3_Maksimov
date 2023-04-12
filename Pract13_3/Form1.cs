using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract13_3
{
  public partial class Form1 : Form
  {
    private MeasuringDevice _measuringDevice = new MeasuringDevice();
    private SortedList<string, MeasuringDevice> data = new SortedList<string, MeasuringDevice>();
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      textBox1.Text = "Номер изобритения";
      textBox2.Text = "Название изобритения";
      textBox3.Text = "Тип";
      textBox4.Text = "Произовидеть";
      textBox5.Text = "Цена";
      textBox6.Text = "Что найти?";
      textBox6.ForeColor = Color.Gray;
      textBox1.ForeColor = Color.Gray;
      textBox2.ForeColor = Color.Gray;
      textBox3.ForeColor = Color.Gray;
      textBox4.ForeColor = Color.Gray;
      textBox5.ForeColor = Color.Gray;
      dataGridView1.Columns.Add("Номер", "Номер");
      dataGridView1.Columns.Add("Название", "Название");
      dataGridView1.Columns.Add("Тип", "Тип");
      dataGridView1.Columns.Add("Производитель", "Производитель");
      dataGridView1.Columns.Add("Цена", "Цена");
    }

    private void textBox1_MouseClick(object sender, MouseEventArgs e)
    {
      textBox1.Text = null;
      textBox1.ForeColor = Color.Black;
    }

    private void textBox2_MouseClick(object sender, MouseEventArgs e)
    {
      textBox2.Text = null;
      textBox2.ForeColor = Color.Black;
    }

    private void textBox3_MouseClick(object sender, MouseEventArgs e)
    {
      textBox3.Text = null;
      textBox3.ForeColor = Color.Black;
    }

    private void textBox4_MouseClick(object sender, MouseEventArgs e)
    {
      textBox4.Text = null;
      textBox4.ForeColor = Color.Black;
    }

    private void textBox5_MouseClick(object sender, MouseEventArgs e)
    {
      textBox5.Text = null;
      textBox5.ForeColor= Color.Black;
    }
    private int CheckKey(TextBox tb)
    {
      try
      {
        foreach(DataGridViewRow row in dataGridView1.Rows)
        {
          if(row.Cells["Номер"].Value != null && row.Cells["Номер"].Value.ToString() == tb.Text)
          {
            tb.Text = "0";
          }
        }
      }
      catch (Exception)
      {
        tb.Text = "0";
      }
      return int.Parse(tb.Text);
    }
    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        int key = CheckKey(textBox1);
        data.Add(key.ToString(), _measuringDevice);
        _measuringDevice.Name = textBox2.Text;
        _measuringDevice.Type = textBox3.Text;
        _measuringDevice.Manufacturer = textBox4.Text;
        _measuringDevice.Price = double.Parse(textBox5.Text);
        dataGridView1.Rows.Add(key,_measuringDevice.Name, _measuringDevice.Type, _measuringDevice.Manufacturer, _measuringDevice.Price);
        dataGridView1.Update();
        dataGridView1.Refresh();
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (dataGridView1.SelectedRows.Count > 0)
      {
        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
        string key = selectedRow.Cells[0].Value.ToString();
        data.Remove(key);
        dataGridView1.Rows.RemoveAt(selectedRow.Index);
      }
    }
    private void textBox6_MouseClick(object sender, MouseEventArgs e)
    {
      textBox6.Text = null;
      textBox6.ForeColor = Color.Black;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (textBox6.Text == "")
      {
        MessageBox.Show("Поле поиска пустое,", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        foreach (var el in textBox6.Text)
        {
          if (!char.IsNumber(el))
          {
            MessageBox.Show("Поле поиска должно содержать только цифры", "Ошибка", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            break;
          }
        }
      }
      else
      {
        for (int i = 0; i < dataGridView1.RowCount; i++)
        {
          dataGridView1.Rows[i].Selected = false;
          for (int j = 0; j < dataGridView1.ColumnCount; j++)
            if (dataGridView1.Rows[i].Cells[j].Value != null)
              if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
              {
                dataGridView1.BackColor = Color.Red;
                dataGridView1.Rows[i].Selected = true;
                break;
              }
        }
      }
    }
  }
}
