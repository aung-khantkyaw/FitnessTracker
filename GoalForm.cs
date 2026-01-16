using Fitness_Tracker.Controller;
using Fitness_Tracker.Models;
using Fitness_Tracker.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class GoalForm : Form
    {
        private UserController _userController;
        private GoalController _goalController;
        private Main _loginForm;
        private Profile _profileForm;
        private ActivityForm _activityForm;
        private readonly List<string> _statusFilters = new List<string> { "All", "Inprogress", "Complete", "Fail" };

        public GoalForm()
        {
            InitializeComponent();
            _loginForm = new Main();
            _userController = new UserController(_loginForm);
            _goalController = new GoalController(this);
            BuildStatusFilterButtons();
            _goalController.DisplayGoalsByUsername(dataGridViewGoal, SessionManager.Username);
        }

        private void BuildStatusFilterButtons()
        {
            flowLayoutPanelStatusFilters.Controls.Clear();

            foreach (string status in _statusFilters)
            {
                flowLayoutPanelStatusFilters.Controls.Add(CreateStatusButton(status));
            }
        }

        private Button CreateStatusButton(string status)
        {
            Button button = new Button
            {
                Text = status,
                Tag = status,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(5),
                Padding = new Padding(8, 6, 8, 6)
            };

            button.Click += StatusFilter_Click;
            return button;
        }

        private void StatusFilter_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            string status = button.Tag?.ToString() ?? "All";
            string? filterStatus = string.Equals(status, "All", StringComparison.OrdinalIgnoreCase) ? null : status;

            _goalController.DisplayGoalsByFilters(dataGridViewGoal, SessionManager.Username, filterStatus, null, null);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            _profileForm = new Profile(_loginForm);
            this.Hide();
            _profileForm.Show();
        }

        private void btnGoal_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            if (SessionManager.Goal > 0)
            {
                _activityForm = new ActivityForm();
                this.Hide();
                _activityForm.Show();
            }
            else
            {
                ShowErrorMessage("If your have not active goal, you can't go to Activity.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm logout", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _userController.Logout();
                this.Hide();
                _loginForm.Show();
            }
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccessMessage(string message)
        {
            if (MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                _goalController.DisplayGoalsByUsername(dataGridViewGoal, SessionManager.Username);
                tbId.Text = string.Empty;
                tbCalBurn.Text = string.Empty;
                dtpStart.Value = DateTime.Now;
                dtpEnd.Value = DateTime.Now;
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsNumber.IsNumberOrNot(tbCalBurn.Text))
            {
                Goals goal = new Goals
                {
                    Username = SessionManager.Username,
                    Goal = int.TryParse(tbCalBurn.Text, out int parsedGoal) ? parsedGoal : 0,
                    StartDate = dtpStart.Value.ToString("M/dd/yyyy"),
                    EndDate = dtpEnd.Value.ToString("M/dd/yyyy"),
                };

                _goalController.AddGoal(goal);
            }
            else
            {
                ShowErrorMessage("Calories must be Number");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsNumber.IsNumberOrNot(tbCalBurn.Text))
            {
                Goals goal = new Goals
                {
                    Id = int.TryParse(tbId.Text, out int parsedId) ? parsedId : 0,
                    Username = SessionManager.Username,
                    Goal = int.TryParse(tbCalBurn.Text, out int parsedGoal) ? parsedGoal : 0,
                    StartDate = dtpStart.Value.ToString("M/dd/yyyy"),
                    EndDate = dtpEnd.Value.ToString("M/dd/yyyy"),
                };

                _goalController.UpdateGoal(goal);
            }
            else
            {
                ShowErrorMessage("Calories must be Number");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = int.TryParse(tbId.Text, out int parsedId) ? parsedId : 0;
            if (MessageBox.Show("Are you sure you want to Delete Goal?", "Confirm Goal Delete", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _goalController.DeleteGoal(Id);
            }
        }

        private void dataGridViewGoal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridViewGoal.SelectedRows[0];
            if (selectedRow != null)
            {
                tbId.Text = selectedRow.Cells[0].Value.ToString();
                tbCalBurn.Text = selectedRow.Cells[2].Value.ToString();

                if (DateTime.TryParse(selectedRow.Cells[3].Value.ToString(), out DateTime parsedStartDate))
                {
                    dtpStart.Value = parsedStartDate;
                }

                if (DateTime.TryParse(selectedRow.Cells[4].Value.ToString(), out DateTime parsedEndDate))
                {
                    dtpEnd.Value = parsedEndDate;
                }
            }
        }

        private void dataGridViewGoal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
