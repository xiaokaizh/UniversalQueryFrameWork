using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UniversalQueryFrameWork
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：2016-03-25
    ** Desc：通用性查询框架 ViewModel 数据层
    *********************************************************************************/

    public class Query_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        List<string> sourceData;

        private List<string> SourceData
        {
            get { return sourceData; }
            set
            {
                sourceData = value;
                OnPropertyChanged("SourceData");
            }
        }

        public ICommand Query_Command_Query { get; private set; } 

    }
}
