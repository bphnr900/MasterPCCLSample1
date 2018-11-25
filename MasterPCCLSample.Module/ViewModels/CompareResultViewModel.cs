using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using Microsoft.Win32;

namespace MasterPCCLSample.Module.ViewModels
{
    class CompareResultViewModel : BindableBase
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { this.SetProperty(ref filePath, value); }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { this.SetProperty(ref startDate, value); }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { this.SetProperty(ref endDate, value); }
        }

        //結果表示用
        private string result;
        public string Result
        {
            get { return result; }
            set { this.SetProperty(ref result, value); }
        }

        public DelegateCommand GetFilePathCommand { get; }
        public DelegateCommand CompareCommand { get; }
        public CompareResultViewModel()
        {
            this.GetFilePathCommand = new DelegateCommand(() =>
            {
                this.FilePath = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "ファイルを開く";
                openFileDialog.Filter = "全てのファイル(*.*)|*.*";
                if(openFileDialog.ShowDialog() == true)
                {
                    this.FilePath = openFileDialog.FileName;
                }
            });
            this.CompareCommand = new DelegateCommand(() =>
            {
                string str = "";
                str = str + FilePath;
                str = str + StartDate.ToShortDateString();
                str = str + EndDate.ToShortDateString();
                Result = str;
            }, () => !string.IsNullOrWhiteSpace(this.FilePath) 
            && !string.IsNullOrWhiteSpace(this.StartDate.ToShortDateString()) 
            && !string.IsNullOrWhiteSpace(this.EndDate.ToShortDateString()));
            this.CompareCommand.ObservesProperty(() => this.FilePath);
            this.CompareCommand.ObservesProperty(() => this.EndDate);
            this.CompareCommand.ObservesProperty(() => this.StartDate);
        }
    }
}
