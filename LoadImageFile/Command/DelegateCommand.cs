using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoadImageFile.Command
{
    class DelegateCommand : ICommand // 실제로 실행할 메소드와 실행 전의 조건을 검사하는 메소드로 이루어진 클래스
    {
        Action _execute;
        Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute; // Action으로 버튼에 바인딩된 커맨드가 실제로 실행할 함수
            _canExecute = canExecute; // Action이 수행되기 전에 필요한 조건을 검사하는 메소드
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
