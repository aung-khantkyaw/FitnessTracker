using Fitness_Tracker.Controller;
using Fitness_Tracker.Models;
using Fitness_Tracker.Utils;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class ActivityForm : Form
    {
        private UserController _userController;
        private GoalController _goalController;
        private ActivityController _activityController;
        private Main _loginForm;
        private Profile _profileForm;
        private GoalForm _goalForm;
        private List<ActivityType> _activityTypes;

        public ActivityForm()
        {
            InitializeComponent();
            _loginForm = new Main();
            _userController = new UserController(_loginForm);
            _activityController = new ActivityController(this);
            _activityController.DisplayActivitiesByUsername(dataGridViewActivity, SessionManager.Username);
            _activityTypes = _activityController.GetActivityTypeList();
            InsertDataToComboBox();
            BuildFilterButtons();
        }

        public void InsertDataToComboBox()
        {
            if (_activityTypes != null && _activityTypes.Any())
            {
                cbType.DataSource = _activityTypes;
                cbType.DisplayMember = "activity";
                cbType.ValueMember = "Id";
            }
            else
            {
                cbType.Items.Clear();
                cbType.Items.Add("No activities available");
                cbType.Enabled = false;
            }
        }

        private void BuildFilterButtons()
        {
            flowLayoutPanelFilters.Controls.Clear();

            Button allButton = CreateFilterButton("All", null);
            flowLayoutPanelFilters.Controls.Add(allButton);

            if (_activityTypes == null || !_activityTypes.Any())
            {
                Button disabledButton = CreateFilterButton("No activities", null);
                disabledButton.Enabled = false;
                flowLayoutPanelFilters.Controls.Add(disabledButton);
                return;
            }

            foreach (ActivityType activityType in _activityTypes)
            {
                flowLayoutPanelFilters.Controls.Add(CreateFilterButton(activityType.activity, activityType.activity));
            }
        }

        private Button CreateFilterButton(string label, string? activityName)
        {
            Button button = new Button
            {
                Text = label,
                Tag = activityName,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(5),
                Padding = new Padding(8, 6, 8, 6)
            };

            button.Click += FilterButton_Click;
            return button;
        }

        private void FilterButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            string? activityName = button.Tag as string;

            if (string.IsNullOrEmpty(activityName))
            {
                _activityController.DisplayActivitiesByUsername(dataGridViewActivity, SessionManager.Username);
            }
            else
            {
                _activityController.DisplayActivitiesByUsernameAndActivity(dataGridViewActivity, SessionManager.Username, activityName);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            _profileForm = new Profile(_loginForm);
            this.Hide();
            _profileForm.Show();
        }

        private void btnGoal_Click(object sender, EventArgs e)
        {
            _goalForm = new GoalForm();
            this.Hide();
            _goalForm.Show();
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            return;
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
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _activityController.DisplayActivitiesByUsername(dataGridViewActivity, SessionManager.Username);
            tbOne.Text = string.Empty;
            tbTwo.Text = string.Empty;
            tbThree.Text = string.Empty;
        }

        private void dataGridViewActivity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridViewActivity.SelectedRows[0];
            if (selectedRow != null)
            {
                tbId.Text = selectedRow.Cells[0].Value.ToString();
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedItem != null)
            {
                ActivityType activity = (ActivityType)cbType.SelectedItem;
                tbOne.PlaceholderText = activity.metric_one.ToString();
                tbTwo.PlaceholderText = activity.metric_two.ToString();
                tbThree.PlaceholderText = activity.metric_three.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsNumber.IsNumberOrNot(tbOne.Text) && IsNumber.IsNumberOrNot(tbTwo.Text) && IsNumber.IsNumberOrNot(tbThree.Text))
            {
                ActivityType activity = (ActivityType)cbType.SelectedItem;
                int metric_one_value = int.TryParse(tbOne.Text, out int parsedOne) ? parsedOne : 0;
                int metric_two_value = int.TryParse(tbTwo.Text, out int parsedTwo) ? parsedTwo : 0;
                int metric_three_value = int.TryParse(tbThree.Text, out int parsedThree) ? parsedThree : 0;

                _activityController.AddActivity(activity.activity, metric_one_value, metric_two_value, metric_three_value);
            }
            else
            {
                ShowErrorMessage("All metrics must be Fill and only number type accept.");
            }
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
