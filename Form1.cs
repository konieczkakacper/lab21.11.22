using System.Text;
using System.Xml.Serialization;

namespace serializacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "tytul";
            dataGridView1.Columns[1].Name = "autor";
            dataGridView1.Columns[2].Name = "id";
            dataGridView1.Columns[3].Name = "wydawnictwo";
            dataGridView1.Columns[4].Name = "miasto";
            dataGridView1.Columns[5].Name = "rok";
            dataGridView1.Columns[6].Name = "status wypozyczenia";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        
        [Serializable] 
        public class Book 
        {
            public string tytul { get; set; }
            public string autor { get; set; }
            public int id { get; set; }
            public string wydawnictwo { get; set; }
            public string miasto { get; set; }
            public int rok { get; set; }
            public string status_wypozyczenia { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // zapis do pliku
            var aSerializer = new XmlSerializer(typeof(Book));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            aSerializer.Serialize(sw, new Book());
            string xmlResut = sw.GetStringBuilder().ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // odczytywanie danych z pliku csv
            dataGridView1.DataSource = loadCSV(textBox1.Text);
        }

        public List<Book> loadCSV(string csvFile)
        {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(",")
                        select new Book
                        {
                            tytul = data[0],
                            autor = data[1],
                            id = int.Parse(data[2]),
                            wydawnictwo = data[3],
                            miasto = data[4],
                            rok = int.Parse(data[5]),
                            status_wypozyczenia = data[6]
                        };
            return query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            textBox1.Text = dlg.FileName;
        }
    }
}