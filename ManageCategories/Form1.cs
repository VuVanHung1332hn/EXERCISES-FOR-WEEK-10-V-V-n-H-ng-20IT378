namespace ManageCategoriesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadCategories()
        {
            var categories = ManageCategories.Instance.GetCategories();

            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();

            //binding to textbox
            txtID.DataBindings.Add("Text", categories, "CategoryID");
            txtName.DataBindings.Add("Text", categories, "CategoryName");

            //binding to gridview
            dgvCategory.DataSource = categories;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtName.Text };
                ManageCategories.Instance.InsertCategory(category);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtID.Text),
                    CategoryName = txtName.Text

                };
                ManageCategories.Instance.UpdateCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtID.Text)
                };
                ManageCategories.Instance.DeleteCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
        }
    }
}