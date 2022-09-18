namespace RobberAndBackpack
{
    public partial class Form1 : Form
    {
        private List<Items> items;
        public Form1()
        {
            InitializeComponent();
            AddItems();
            ShowItems(items);
        }

        /// <summary>
        /// Метод добавляет предметы в лист 
        /// </summary>
        private void AddItems()
        {
            items = new List<Items>();

            items.Add(new Items("Кольцо", 3, 40));
            items.Add(new Items("Картина", 3, 50));
            items.Add(new Items("Плащ", 5, 60));
            items.Add(new Items("Плита", 12, 100));
            items.Add(new Items("Ноутбук", 18, 200));
        }

        /// <summary>
        /// Метод показывает исходные данные
        /// </summary>
        /// <param name="_items">предметы</param>
        private void ShowItems(List<Items> _items)
        {
            itemsListView.Items.Clear();
            foreach (Items item in _items)
            {
                itemsListView.Items.Add(new ListViewItem(new string[] { item.Name, item.Weight.ToString(),
                    item.Price.ToString() }));
            }
        }
        /// <summary>
        /// Метод показывает во втором листе решение
        /// </summary>
        /// <param name="_items"></param>
        private void ShowItemsSolve(List<Items> _items)
        {
            foreach (Items item in _items)
            {
                itemsSolveListView.Items.Add(new ListViewItem(new string[] { item.Name, item.Weight.ToString(),
                    item.Price.ToString() }));
            }
        }

        /// <summary>
        /// Показывает исходные данные при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowConditionsButton_Click(object sender, EventArgs e)
        {
            ShowItems(items);
        }


        /// <summary>
        /// Метод решает выданную задачу
        /// </summary>
        private void SolveTask()
        {
            try
            {
                Backpack bp = new Backpack(Convert.ToDouble(weightTextBox.Text));
                bp.MakeAllSets(items);
                List<Items> solve = bp.GetBestSet();
                if (solve == null)
                {
                    MessageBox.Show("Нет решения!");
                }
                else
                {
                    //itemsListView.Items.Clear();

                    ShowItemsSolve(solve);

                    MessageBox.Show("Решение приведено в правой таблице");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void solveButton_Click_1(object sender, EventArgs e)
        {
            SolveTask();
        }

        private void ShowConditionsButton_Click_1(object sender, EventArgs e)
        {
            ShowItems(items);
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}