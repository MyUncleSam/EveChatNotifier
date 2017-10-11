using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace EveChatNotifier.Autostart
{
    public sealed class ManageAutostart
    {
        private static ManageAutostart _Instance = null;

        /// <summary>
        /// get the singleton instance
        /// </summary>
        /// <returns></returns>
        public static ManageAutostart Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ManageAutostart();
                }
                return _Instance;
            }
        }

        private const string Identifier = "EveChatNotifierAutoStart";
        private const string Description = "EveChatNotifier AutoStart";
        private Task AutostartTask = null;

        /// <summary>
        /// initialize the autostart entries (creates them if needed)
        /// </summary>
        private ManageAutostart()
        {
            AutostartTask = GetTask;
            if(GetTask == null)
            {
                CreateTask();
            }
        }
        
        /// <summary>
        /// checks if there is already a known task which should start the evechatnotifier
        /// </summary>
        /// <returns></returns>
        public bool HasTask()
        {
            return GetTask != null;
        }

        /// <summary>
        /// registers the startup task (load on logon) for the current user
        /// </summary>
        private void CreateTask()
        {
            TaskDefinition td = TaskService.Instance.NewTask();
            td.RegistrationInfo.Description = Description;
            td.Settings.Enabled = false; // not enabled by default
            
            LogonTrigger lt = new LogonTrigger();
            lt.Delay = new TimeSpan(0, 5, 0);
            lt.Enabled = true; // action is always enabled, active or not is managed using the task definition
            lt.Id = Identifier;
            lt.UserId = Environment.UserName;
            td.Triggers.Add(lt);

            td.Actions.Add(Application.ExecutablePath, null, System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            AutostartTask = TaskService.Instance.RootFolder.RegisterTaskDefinition(Description, td);
        }

        /// <summary>
        /// gets the task or null if not found
        /// </summary>
        public Task GetTask
        {
            get
            {
                return TaskService.Instance.RootFolder.Tasks.Where(w => w.Name.Equals(Description, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
        }

        /// <summary>
        /// is the logon task enabled or not?
        /// (if it is not there it is going to be created)
        /// </summary>
        /// <returns></returns>
        public bool Enabled
        {
            get
            {
                return GetTask.Enabled;
            }
            set
            {
                if(GetTask.Enabled != value)
                {
                    GetTask.Enabled = value;
                    GetTask.RegisterChanges();
                }
            }
        }
    }
}
