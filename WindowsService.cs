using PegaBugApp;
using Newtonsoft.Json;
using System.ServiceProcess;
using TableDependency.Enums;
using TableDependency.EventArgs;
using TableDependency.SqlClient;


namespace PegaBugWinService
{
    public partial class WindowsService : ServiceBase
    {
        public SqlTableDependency<Cobrancas> _sqlTableDependency;

        public WindowsService()
        { 
            InitializeComponent();
        }

        public void Start(string[] args) 
        { 
            OnStart(args);

            #if DEBUG
                System.Diagnostics.Debugger.Launch();
            #endif
        }

        /// <summary>
        /// Service Start
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            var updateOfModel = new TableDependency.Mappers.UpdateOfModel<Cobrancas>();
            updateOfModel.Add(i => i.dt_vencimento);
            _sqlTableDependency = new SqlTableDependency<Cobrancas>(Util.connectionStringServerDB, updateOfModel);

            _sqlTableDependency.OnChanged += _sqlTableDependency_OnChanged;
            _sqlTableDependency.Start();
        }

        protected override void OnStop() { }

        /// <summary>
        /// The program has detected something inside the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _sqlTableDependency_OnChanged(object sender, RecordChangedEventArgs<Cobrancas> e)
        {
              
            if (e != null)
                if (e.ChangeType == ChangeType.Update)
                {
                    new Util().LogMessageToFile(JsonConvert.SerializeObject(e.Entity));
                }
        }
    }
}
