using PegaBugApp;
using Newtonsoft.Json;
using System.ServiceProcess;
using TableDependency.Enums;
using TableDependency.EventArgs;
using TableDependency.SqlClient;


namespace PegaBugWinService
{
    public partial class ServicoPegabug : ServiceBase
    {
        public SqlTableDependency<Cobrancas> _sqlTableDependency;

        public ServicoPegabug()
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

        protected override void OnStart(string[] args)
        {
            var updateOfModel = new TableDependency.Mappers.UpdateOfModel<Cobrancas>();
            updateOfModel.Add(i => i.dt_vencimento);
            _sqlTableDependency = new SqlTableDependency<Cobrancas>(Util.connectionStringServerDB, updateOfModel);
            //var tableDependency = new SqlTableDependency<Cobrancas>(Util.connectionStringServerDB, updateOfModel);

            _sqlTableDependency.OnChanged += _sqlTableDependency_OnChanged;
            _sqlTableDependency.Start();
        }

        protected override void OnStop() { }

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
