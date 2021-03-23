using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EShop.Business.Abstract;
using EShop.Business.DependencyResolvers.Ninject;
using EShop.Entities.Concrete;
using EShop.FormsUI.Helpers;

namespace EShop.FormsUI
{
    public partial class Form1 : Form
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public Form1()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            InitializeComponent();
        }

        private Utilities _utilities = new Utilities();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll().ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    ProductName = tbxProductNameAdd.Text,
                    CategoryId = Convert.ToInt32(tbxCategoryIdAdd.Text),
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceAdd.Text),
                    QuantityProduct = tbxQuantityProductAdd.Text,
                    AmountStock = Convert.ToInt32(tbxAmountStockAdd.Text)
                });
                MessageBox.Show("The product added your basket!", "Message");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName = tbxProductNameUpdate.Text,
                CategoryId = Convert.ToInt32(tbxCategoryIdUpdate.Text),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                QuantityProduct = tbxQuantityProductUpdate.Text,
                AmountStock = Convert.ToInt32(tbxAmountStockUpdate.Text)
            });
            MessageBox.Show("The product has been updated!", "Message");
            LoadProducts();
        }
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dgwProducts.CurrentRow.Cells;
            tbxProductNameUpdate.Text = temp[1].Value.ToString();
            tbxCategoryIdUpdate.Text = temp[2].Value.ToString();
            tbxUnitPriceUpdate.Text = temp[3].Value.ToString();
            tbxAmountStockUpdate.Text = temp[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });

            MessageBox.Show("The product was removed from your basket!", "Message");
            LoadProducts();
        }

        private void tbxProductIdSearching_TextChanged(object sender, EventArgs e)
        {
            var text = tbxProductIdSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                List<Product> results = new List<Product>();
                results.Add(_productService.GetById(Convert.ToInt32(text)));
                dgwProducts.DataSource = results;

            }, LoadProducts);

        }

        private void tbxCategoryNameSearching_TextChanged(object sender, EventArgs e)
        {
            var text = tbxCategoryIdSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                dgwProducts.DataSource = _productService.GetByCategoryId(Convert.ToInt32(text));
            }, LoadProducts);
        }
        private void tbxProductNameSearching_TextChanged(object sender, EventArgs e)
        {
            var text = tbxProductNameSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                dgwProducts.DataSource = _productService.GetByProductName(text);
            }, LoadProducts);
        }

        private void LoadByPrice()
        {
            decimal min = 0;
            decimal max = 5000;
            var minPrice = tbxMinUnitPrice.Text;
            var maxPrice = tbxMaxUnitPrice.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, minPrice, () => { min = Convert.ToDecimal(minPrice); });
            _utilities.Check(_utilities.IsNullOrEmpty, maxPrice, () => { max = Convert.ToDecimal(maxPrice); });
            dgwProducts.DataSource = _productService.GetByUnitPrice(min, max);
        }

        private void tbxMinUnitPrice_TextChanged(object sender, EventArgs e)
        {
            _utilities.Check(_utilities.IsNullOrEmpty, tbxMinUnitPrice.Text, LoadByPrice, LoadProducts);
        }

        private void tbxMaxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            _utilities.Check(_utilities.IsNullOrEmpty, tbxMaxUnitPrice.Text, LoadByPrice, LoadProducts);
        }

        private void LoadCategories()
        {
            dgwCategories.DataSource = _categoryService.GetAll().ToList();
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.Add(new Category
                {
                    CategoryName = tbxCategoryNameAdd.Text,
                    Description = tbxDescriptionAdd.Text
                });
                MessageBox.Show("The category added!", "Message");
                LoadCategories();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdateCategories_Click(object sender, EventArgs e)
        {
            _categoryService.Update(new Category
            {
                CategoryId = Convert.ToInt32(dgwCategories.CurrentRow.Cells[0].Value),
                CategoryName = tbxCategoryNameUpdate.Text,
                Description = tbxDescriptionUpdate.Text
            });
            MessageBox.Show("The category updated!", "Message");
            LoadCategories();
        }

        private void dgwCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dgwCategories.CurrentRow.Cells;
            tbxCategoryNameUpdate.Text = temp[1].Value.ToString();
            tbxDescriptionUpdate.Text = temp[2].Value.ToString();
        }

        private void btnDeleteCategories_Click(object sender, EventArgs e)
        {
            _categoryService.Delete(new Category
            {
                CategoryId = Convert.ToInt32(dgwCategories.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("The category removed", "Message");
            LoadCategories();
        }

        private void tbxCategoryIdSearching_TextChanged(object sender, EventArgs e)
        {
            var text = tbxCategoryIdSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                List<Category> results = new List<Category>();
                results.Add(_categoryService.GetById(Convert.ToInt32(text)));
                dgwCategories.DataSource = results;
            }, LoadCategories);
        }

        private void tbxCategoryNameSearchingCategories_TextChanged(object sender, EventArgs e)
        {
            var text = tbxCategoryNameSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                dgwCategories.DataSource = _categoryService.GetByCategoryName(text);
            }, LoadCategories);
        }

        private void tbxDescriptionSearching_TextChanged(object sender, EventArgs e)
        {
            var text = tbxDescriptionSearching.Text;
            _utilities.Check(_utilities.IsNullOrEmpty, text, () =>
            {
                dgwCategories.DataSource = _categoryService.GetByDescription(text);
            }, LoadCategories);
        }
    }
}
