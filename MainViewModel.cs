using CommitTracker;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mixpanel;


    public partial class MainViewModel : ObservableObject
    {
        private readonly string _mixpanelToken = "b8f67a76005e316e79d244055f8f9df8";

    private readonly MixpanelClient _mixpanel;

    [ObservableProperty]
        string _userName;

        [ObservableProperty]
        int _commitCount;

        [ObservableProperty]
        DateTime _commitDate = DateTime.Now;

        [ObservableProperty]
        string _selectedProject;

        public List<int> CommitCounts { get; } = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public List<string> Projects { get; } = new List<string> { "Proj A", "Proj B", "Proj C" };
    public string UserName { get; set; }
    public int CommitCount { get; set; }
    public DateTime CommitDate { get; set; }
    public string SelectedProject { get; set; }

    public MainViewModel()
        {
        _mixpanel = new MixpanelClient();

            _mixpanel = new MixpanelClient(_mixpanelToken);
        }

        [RelayCommand]
        public async void AddToMixpanelCommand()
        {
            var data = new CommitData
            {
                UserName = UserName,
                CommitCount = CommitCount,
                CommitDate = CommitDate,
                Project = SelectedProject
            };

            var properties = new Dictionary<string, object>
        {
            { "UserName", data.UserName },
            { "CommitCount", data.CommitCount },
            { "CommitDate", data.CommitDate },
            { "Project", data.Project }
        };

            await _mixpanel.TrackAsync(data.UserName, "CommitAdded", properties);

            // Optionally, clear the form after submission
            UserName = "";
            CommitCount = 0;
            CommitDate = DateTime.Now;
            SelectedProject = null;
        }
    }
