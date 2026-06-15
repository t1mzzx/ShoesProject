using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShoesProject
{
    public partial class FormOrders : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormOrders(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser?.FullName;

            SetupOrdersGrid();
            LoadOrders();
        }

        private void SetupOrdersGrid()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.AutoGenerateColumns = false;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.HeaderText = "Информация о заказе";
            colInfo.FillWeight = 50;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colComposition = new DataGridViewTextBoxColumn();
            colComposition.Name = "colComposition";
            colComposition.HeaderText = "Состав заказа";
            colComposition.FillWeight = 35;
            colComposition.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.FillWeight = 15;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colInfo, colComposition, colStatus });
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadOrders()
        {
            try
            {
                using (var db = new shop_dbContext())
                {
                    var orders = db.Order
                        .Include(o => o.Statuse)
                        .Include(o => o.DeliveryPoint)
                        .Include(o => o.ProductsOrder)
                            .ThenInclude(po => po.Product)
                        .ToList();

                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear();

                    foreach (var order in orders)
                    {
                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];

                        row.Cells["colInfo"].Value = FormatOrderInfo(order);
                        row.Cells["colComposition"].Value = FormatOrderComposition(order);
                        row.Cells["colStatus"].Value = order.Statuse?.StatusName ?? "Не указан";

                        ApplyOrderRowStyles(row, order);
                    }

                    dgvOrders.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatOrderInfo(Order order)
        {
            decimal totalSum = 0;
            decimal totalDiscountSum = 0;

            if (order.ProductsOrder != null)
            {
                foreach (var po in order.ProductsOrder)
                {
                    if (po.Product != null)
                    {
                        decimal itemPrice = po.Product.Price;
                        int count = po.Quantity;
                        int discount = po.Product.Discount;

                        totalSum += itemPrice * count;
                        totalDiscountSum += (itemPrice * discount / 100) * count;
                    }
                }
            }

            decimal finalPrice = totalSum - totalDiscountSum;
            string deliveryPointInfo = order.DeliveryPoint != null ? "Указан" : "Не указан";

            return $"Заказ № {order.Id} от {order.OrderDate:dd.MM.yyyy}" + Environment.NewLine
                + $"Пункт выдачи: {deliveryPointInfo}" + Environment.NewLine
                + $"Стоимость: {finalPrice:C} (Скидка: {totalDiscountSum:C})" + Environment.NewLine
                + $"Код для получения: {order.Code}";
        }

        private string FormatOrderComposition(Order order)
        {
            if (order.ProductsOrder == null || order.ProductsOrder.Count == 0)
                return "Состав заказа пуст";

            var lines = order.ProductsOrder.Select(po =>
                $"• {po.Product?.Description ?? "Товар"} — {po.Quantity} шт.");

            return string.Join(Environment.NewLine, lines);
        }

        private void ApplyOrderRowStyles(DataGridViewRow row, Order order)
        {
            if (order.Statuse?.StatusName == "Доставлен" || order.Statuse?.StatusName == "Выдан")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (order.Statuse?.StatusName == "Новый")
            {
                row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
